using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Media3D;
using TwilightShards.genLibrary;

namespace TwilightShards.AetherumExplorerW
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
        private bool SystemsCreated = false;
        
        /*
        /// <summary>
        /// Tracks if the systems have been initiated
        /// </summary>  
        private bool SystemsInitiated = false;

        /// <summary>
        /// Tracks if the orbits have been created
        /// </summary>
        private bool OrbitsCreated = false;

        /// <summary>
        /// Tracks if planets have been initiated
        /// </summary>
        private bool PlanetsInitiated = false; */

        //************************************* OBJECTS
        /// <summary>
        /// This is the dice object we use for any rolls.
        /// </summary>
        private Dice VelvetBag { get; set; }

        /// <summary>
        /// This is the program settings pointer.
        /// </summary>
        private AetherumSettings PrgSettings {get; set;}

        /// <summary>
        /// This is the catalog generator for stellar
        /// </summary>
        private CatalogGenerator StellarCatalog { get; set; }

        //************************************** CONSTRUCTIONS

        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="v">Dice object</param>
        internal SectorGenerator(Dice v, AetherumSettings p)
        {
            this.VelvetBag = v;
            this.PrgSettings = p;
            this.StellarCatalog = new CatalogGenerator(VelvetBag, 
                                                       PrgSettings.GetSystemPrefix(), 
                                                       PrgSettings.GetSystemMaxNum());
        }

        /// <summary>
        /// This resets the sector.
        /// </summary>
        internal void ResetSector(Sector s)
        {
            //reset the sector
            s.Reset();

            //reset internal trackers
            this.StellarCatalog.ResetCatalog();
            
            //finally, reset all indicators
            this.SystemsCreated = false;
            /* this.SystemsInitiated = false;
            this.OrbitsCreated = false;
            this.PlanetsInitiated = false; */
        }
        
        /// <summary>
        /// This function creates the sector, and initiates it.
        /// </summary>
        /// <param name="s">Our sector</param>
        internal void InitateSector(Sector s)
        {
            if (SystemsCreated)
            {
                //uhm.. we have one already.
                MessageBoxResult res = MessageBox.Show("This will reset the sector. Are you OK with that?", "Sector Initalized", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                    ResetSector(s);
                if (res == MessageBoxResult.No)
                    return; //do nothing.
            }
            //first set the sector name
            s.SectorName = PrgSettings.GetSectorPrefix() + VelvetBag.rng(1, PrgSettings.GetSectorMaxNum());

            //get values
            double minStellarDistance = PrgSettings.GetMinStellarDistance() * PrgSettings.GetLightYearResolution();
            double stellarDensity = PrgSettings.GetStellarDensity();
            bool isTwoDGrid = !(PrgSettings.GridTypeIs3D());
            int gridLimit = PrgSettings.GetLightYearResolution() * PrgSettings.GetSectorSizePerSide();
            
            //do any alterations now.
            if (isTwoDGrid)
                stellarDensity = stellarDensity * PrgSettings.GetTwoDMultiplication();
            
            //list of points time
            List<Point3D> ourPoints = new List<Point3D>();

            //Fixed an intersting bug. Always one under. Now using Ceiling...
            int numberOfStars = (int)Math.Ceiling(Math.Pow(PrgSettings.GetSectorSizePerSide(), 3) * stellarDensity); 

            for (int i = 0; i < numberOfStars; i++)
            {
                Point3D newPoint = new Point3D(0, 0, 0); //generic point.
                
                do
                {
                    newPoint.X = VelvetBag.rng(1, gridLimit);
                    newPoint.Y = VelvetBag.rng(1, gridLimit);
                    newPoint.Z = VelvetBag.rng(1, gridLimit);
                } while (((from c in ourPoints where c.GetDistance(newPoint) <= minStellarDistance select c).Any()));

                ourPoints.Add(new Point3D(newPoint.X, newPoint.Y, newPoint.Z));
            }

            //add the point to the systems and display information.
            foreach (Point3D p in ourPoints) 
            {
                s.StarfieldData.Add(new Point3D(p.X, p.Y, p.Z));
                s.SectorSystems.Add(new StellarSystem(p, 
                                                   StellarCatalog.newUniqueNum(),
                                                   0.0));
            }

            s.UpdateNumberOfSystems();
            SystemsCreated = true; //done with system creation
        }

    }
}
