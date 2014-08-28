using System;
using System.Collections.Generic;
using System.Linq;
using TwilightShards.genLibrary;

namespace TwilightShards.AetherumExplorer
{
    /// <summary>
    /// This object contains all of the system members - planets, stellar objects.
    /// </summary>
    public class StellarSystem
    {
        //******************** MEMBERS
        /// <summary>
        /// Location of the system
        /// </summary>
        public PlotPoint location { get; private set; }

        /// <summary>
        /// System name.
        /// </summary>
        public string name { get; private set; }

        /// <summary>
        /// The catalog name of the system
        /// </summary>
        public string catName { get; private set; }

        /// <summary>
        /// List of any planets within the system.
        /// </summary>
        public List<Planet> ourPlanets { get; private set; }

        /// <summary>
        /// The age of the system
        /// </summary>
        public double systemAge { get; private set; }

        /// <summary>
        /// List of the objects within the system. Stars, nebula, black holes, that kind of thing.
        /// </summary>
        public List<AstronomicalObject> stellarMembers { get; private set; }

        public StellarHistoryLogger systemHistory { get; private set; }

        //******************** CONSTRUCTORS
        /// <summary>
        /// Base constructor.
        /// </summary>
        public StellarSystem()
        {
            this.location = new PlotPoint();
            this.ourPlanets = new List<Planet>();
            this.stellarMembers = new List<AstronomicalObject>();
            this.systemHistory = new StellarHistoryLogger();
        }

        /// <summary>
        /// Constructor, given an ordinal coordinate for the system
        /// </summary>
        /// <param name="p"></param>
        public StellarSystem(PlotPoint p)
        {
            this.location = new PlotPoint(p);
            this.ourPlanets = new List<Planet>();
            this.stellarMembers = new List<AstronomicalObject>();
            this.systemHistory = new StellarHistoryLogger();
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="s">Object being copied</param>
        public StellarSystem(StellarSystem s)
        {
            //copy basic details
            this.location = new PlotPoint(s.location);
            this.name = name;
            this.catName = catName;

            //copy lists
            s.ourPlanets.ForEach((item) =>
            {
                this.ourPlanets.Add(new Planet(item));
            });

            //copy lists
            s.stellarMembers.ForEach((item) =>
            {
                this.stellarMembers.Add(new AstronomicalObject(item));
            });

            this.systemHistory = new StellarHistoryLogger(s.systemHistory);
        }


        /// <summary>
        /// Sets the catalog name
        /// </summary>
        /// <param name="cName"></param>
        public void setCatalog(string cName)
        {
            this.catName = cName;
        }

        /// <summary>
        /// Sets the system name
        /// </summary>
        /// <param name="name"></param>
        public void setName(string name)
        {
            this.name = name;
        }


        /// <summary>
        /// Gets the number of planets within the system
        /// </summary>
        /// <returns>number of planets</returns>
        public int getNumPlanets()
        {
            return this.ourPlanets.Count;
        }
        //***************************** ASTRONOMICAL OBJECT GENERATION FUNCTIONS
        /// <summary>
        /// Helper function. Nebulas will be largely null beyond the type. This just adds a generic object
        /// </summary>
        /// <param name="objType">The object type being added</param>
        public void addObject(AstroObjectType objType)
        {
            this.stellarMembers.Add(new AstronomicalObject(objType));
        }

        
        /// <summary>
        /// This function determines if the orbital in question is not within the danger zone of another star.
        /// </summary>
        /// <param name="orbital">The orbital distance</param>
        /// <returns>Returns if it is safe or not</returns>
      /*  public bool isSafe(double orbital)
        {
            //short circuit.
            if (this.getNumStars() == 1)
                return true;

            for (int i = 0; i < this.ourStars.Count; i++)
            {
                double dist = this.ourStars[i].getDistanceFromCenter();
                if ((orbital >= ( dist / 3)) && (orbital <= dist * 3))
                    return false;
            }

            return true;
        } */

        /* public void addAStellarObject(Star sCode)
        {
            this.ourStars.Add(new starLayout(new StellarObject(sCode),this.ourStars.Count,0));
        } */

      /*  public void updateDistanceOfOrder(int i, double dist)
        {
            this.ourStars[i].setDistance(dist);
        } */


        //***************************** HELPER FUNCTIONS
        /// <summary>
        /// Tracks wherther or not any planets in here are habitable.
        /// </summary>
        /// <returns>true if a planet is habitable, false if not.</returns>
        public bool isHabitable()
        {
            return false;
        }

        /// <summary>
        /// This checks if objects exist within the stellar objects.
        /// </summary>
        /// <returns>true if there are stellar objects, false if there are none.</returns>
        public bool hasObjects()
        {
            return ((from s in this.stellarMembers where s.getStellarType() != AstroObjectType.NoObject select s).Any());
        }

        /*
        public double[] getDistArray()
        {
            IEnumerable<double> distScan = from starObj in this.ourStars select starObj.getDistanceFromCenter();
            return distScan.ToArray();
        } */

    }
}