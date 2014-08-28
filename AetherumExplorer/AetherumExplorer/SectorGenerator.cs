using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TwilightShards.genLibrary;
using ILNumerics.Drawing;

namespace TwilightShards.AetherumExplorer
{
    /// <summary>
    /// This class contains the generation methods for creating a sector. 
    /// </summary>
    /// <remarks>This class contains everything you'd need to generate any part of the sector. It also tracks state.</remarks>
    internal class SectorGenerator
    {
        //************************************** STATE VARIABLES
        /// <summary>
        /// Tracks system creation state
        /// </summary>
        private bool systemsCreated = false;

        /// <summary>
        /// Tracks if the systems have been initiated
        /// </summary>  
        private bool systemsInitiated = false;

        /// <summary>
        /// Tracks if the orbits have been created
        /// </summary>
        private bool orbitsCreated = false;

        /// <summary>
        /// Tracks if planets have been initiated
        /// </summary>
        private bool planetsIniitated = false;

        //************************************* OBJECTS
        /// <summary>
        /// This is the dice object we use for any rolls.
        /// </summary>
        private Dice velvetBag { get; set; }

        /// <summary>
        /// This is the program settings pointer.
        /// </summary>
        private AetherumSettings prgSettings {get; set;}

        //************************************** CONSTRUCTIONS

        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="v">Dice object</param>
        internal SectorGenerator(Dice v, AetherumSettings p)
        {
            this.velvetBag = v;
            this.prgSettings = p;
        }   

        /// <summary>
        /// This function creates the sector, and initiates it.
        /// </summary>
        /// <param name="s">Our sector</param>
        internal void initateSector(Sector s)
        {
            //first set the sector name
            s.setSectName(prgSettings.getSectorPrefix() + this.velvetBag.rng(1, prgSettings.getSectorMaxNum()));

            //get values
            double minStellarDistance = this.prgSettings.getMinStellarDistance() * this.prgSettings.getLightYearResolution();
            double stellarDensity = this.prgSettings.getStellarDensity();
            bool isTwoDGrid = !(this.prgSettings.gridTypeIs3D());
            int gridLimit = this.prgSettings.getLightYearResolution() * this.prgSettings.getSectorSizePerSide();
            
            //do any alterations now.
            if (isTwoDGrid)
                stellarDensity = stellarDensity * this.prgSettings.getTwoDMultiplication();
            
            //list of points time
            List<PlotPoint> ourPoints = new List<PlotPoint>();

            //Fixed an intersting bug. Always one under. Now using Ceiling...
            int numberOfStars = (int)Math.Ceiling(Math.Pow(this.prgSettings.getSectorSizePerSide(), 3) * stellarDensity); 

            for (int i = 0; i < numberOfStars; i++)
            {
                PlotPoint newPoint = new PlotPoint(0, 0, 0); //generic point.
                
                do
                {
                    newPoint.SetCoords(new int[] {velvetBag.rng(1, gridLimit), velvetBag.rng(1, gridLimit), velvetBag.rng(1, gridLimit) });
                } while (((from c in ourPoints where c.getDistance(newPoint) <= minStellarDistance select c).Any()));

                ourPoints.Add(new PlotPoint(newPoint));
            }

            //our points are now generated. Let's add them to the sector.
            for (int i = 0; i < ourPoints.Count; i++)
            {
                s.ourSystem.Add(new StellarSystem(ourPoints[i]));
            }
                    
            //We're done setting sector
            this.systemsInitiated = true;
        }

        /// <summary>
        /// This function creates the systems. It goes as far as creating the orbits.
        /// </summary>
        /// <param name="s">Our sector</param>
        internal void createStarSystems(Sector s)
        {
            //first handle exceptions and throw them if needed
            if (this.systemsInitiated)
                throw new Exception("The sector has not yet been initiated. Please initiate the sector first.");

            if (s.getNumberOfSystems() == 0)
               throw new Exception("There are no systems in this sector. Exiting!");
                
            //now start generating the system
            foreach (StellarSystem ourSys in s.ourSystem)
            {        
                //set system name
                ourSys.setName(prgSettings.getSystemPrefix() + this.velvetBag.rng(1, prgSettings.getSystemMaxNum()));

                //we need to determine how many stars we are going to add.
                int numStars = StellarReference.getNumberOfStars(velvetBag.rng(2, 6));
                
                //now, before we add anything else, we need to determine if this system is really a nebula
                if (velvetBag.dblProb() < prgSettings.getThresholdForNebulaPlacement())
                {
                    System.Windows.Forms.MessageBox.Show("Alert! We have a nebula!");
                    double nebProb = velvetBag.dblProb(), interNebProb = prgSettings.getInterstellarNebulaThreshold();
                    double planetProb = interNebProb + prgSettings.getPlanetaryNebulaTreshold();
                    
                    //Set the nebula
                    if (nebProb <= interNebProb)
                        ourSys.addObject(AstroObjectType.InterstellarNebula);
                    else if (nebProb > interNebProb && nebProb <= planetProb)
                        ourSys.addObject(AstroObjectType.PlanetaryDenseNebula);
                    else if (nebProb > planetProb)
                        ourSys.addObject(AstroObjectType.ProtoStarNebula);                    
                }

                //skip to the next cycle. There's going to be no more stars here...               
                if (ourSys.hasObjects())
                   continue;

                //Initiate the system history
                ourSys.systemHistory.AddStellarEvent(0, "The giant molecular cloud seperates from the nearby nebula.");

                //begin stellar generation
                for (int i = 0; i < numStars; i++) 
                {
                    double maxMass = 0, sysAge = StellarReference.genSystemAge(velvetBag);
                    int firstRoll = velvetBag.gurpsRoll(), secondRoll = velvetBag.gurpsRoll();
                    AstroObjectType astroType = AstroObjectType.NoObject;

                    //first, let's determine if it's a rare type - then pick the type.
                    if (velvetBag.dblProb() < prgSettings.getRareAstronomicalObjectProbability())
                        astroType = StellarReference.bonusAstronomicalObject.PickRandom(velvetBag);
                    
                    //now override for FavorableGardenWorld
                    if (prgSettings.getFavorGardenWorldMass()) firstRoll = generateFavorableGardenWorldGen();

                    //now override for alternate high mass generation
                    if (prgSettings.getAlternateHighMassGeneration()) firstRoll = generateAlternateHighMassGen();

                    //now, get the default mass.
                    maxMass = StellarReference.stellarMassTree.Walk<double>(firstRoll, secondRoll);
                    if (astroType != AstroObjectType.NoObject){
                        maxMass = StellarReference.convBonusAstroObjectToMass(astroType, velvetBag);
                        sysAge = StellarReference.convBonusAstroObjectToAge(astroType, velvetBag);
                    }
                }
               
                /*
                //generate the number of stars and then get the spacing
                int numStars = StellarReference.getNumberOfStars(velvetBag.rng(2, 6));

                List<starLayout> newStars = new List<starLayout>();
                for (int i = 0; i < numStars; i++)
                {
                    newStars[i] = new starLayout(new StellarObject(), i, 0);
                } 

                //Distance generation in the base ruleset we are using has specific rules.
                //2 stars, you can have the second star orbit the first at any distance
                //3 stars, the third will automatically be distant, the second close.
                //4 stars, the second close, third distant, fourth close to third.

                switch (numStars)
                {
                    case 4:
                       double dist = 0;
                       newStars[1].setDistance(StellarReference.genCloseOrbitalDist(0, velvetBag));
                       dist = StellarReference.genFartherOrbitalDist(0, velvetBag); //orbits at further distance
                       newStars[2].setDistance(dist);
                       newStars[3].setDistance(StellarReference.genCloseOrbitalDist(dist, velvetBag));
                       break;
                    case 3:                     
                       newStars[1].setDistance(StellarReference.genCloseOrbitalDist(0, velvetBag)); //second star orbits close
                       newStars[2].setDistance(StellarReference.genFartherOrbitalDist(0, velvetBag)); //third star orbits at further distance
                       break;
                    case 2:
                       newStars[1].setDistance(StellarReference.genOrbitalSeperation(0, velvetBag));
                       break;
                    case 1:
                       break;
                    default:
                       throw new Exception("Abnormal number of stars");
                } */
                //now create our orbits.
            }
        }


        /// <summary>
        /// This function generates the diceroll for a stellar mass favorable to garden worlds
        /// </summary>
        /// <param name="d">Dice object</param>
        /// <returns>The diceroll used</returns>
        private int generateFavorableGardenWorldGen()
        {
            switch (velvetBag.rng(6))
            {
                case 1:
                    return 5;
                case 2:
                    return 6;
                case 3:
                case 4:
                    return 7;
                case 5:
                case 6:
                    return 8;
                default:
                    return 7;
            }
        }

        private int generateAlternateHighMassGen()
        {
            switch (velvetBag.rng(5))
            {
                case 1:
                    return 3;
                case 2:
                    return 4;
                case 3:
                    return 5;
                case 4:
                    return 6;
                case 5:
                    return 7;
                default:
                    return 4;
            }
        }

    }
}
