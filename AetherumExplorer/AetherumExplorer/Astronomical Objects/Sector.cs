using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using TwilightShards.genLibrary;

namespace TwilightShards.AetherumExplorer
{
    /// <summary>
    /// This is a stellar sector.
    /// </summary>
    public class Sector
    {
        /// <summary>
        /// Sector name
        /// </summary>
        public string sectName { get; private set; }

        /// <summary>
        /// List of the systems within the sectors
        /// </summary>
        public List<StellarSystem> ourSystem { get; private set; }

        /// <summary>
        /// List of the dice object
        /// </summary>
        public Dice ourDice { get; set; }

        /// <summary>
        /// This is the internal generator for a catalog name
        /// </summary>
        //private CatalogGenerator catalogGen;

        //************CONSTRUCTORS
        /// <summary>
        /// Base constructor. 
        /// </summary>
        public Sector()
        {
            this.ourSystem = new List<StellarSystem>();
            this.ourDice = new Dice();
            //this.catalogGen = new CatalogGenerator(this.ourDice);
        }

        //************SET METHODS

        /// <summary>
        /// This function sets the sector name
        /// </summary>
        /// <param name="name">The new sector name</param>
        public void setSectName(string name)
        {
            this.sectName = name;
        }

      

        /// <summary>
        /// This returns the number of systems within this sector
        /// </summary>
        /// <returns>Number of systems</returns>
        public int getNumberOfSystems()
        {
            return this.ourSystem.Count;
        }


        /// <summary>
        /// Returns an array of points usable for drawing in iLnumerics
        /// </summary>
        /// <returns>iLnumerics usable array</returns>
        public float[,] getStarPlot(bool is3D)
        {
             //set number of dimensions
            int numDimension = 0;
            if (!(is3D)) numDimension = 2;
            else numDimension = 3;

            //get the array converted into an array
            float[,] tempArray = new float[ourSystem.Count,numDimension];
            for (int i = 0; i < ourSystem.Count; i++)
            {
                float[] p = ourSystem[i].location.ConvertPointToFloatArray();
                if (!(is3D))
                {
                    tempArray[i, 0] = p[0];
                    tempArray[i, 1] = p[1];
                }
                else
                {                 
                    tempArray[i, 0] = p[0];
                    tempArray[i, 1] = p[1];
                    tempArray[i, 2] = p[2];
                }
            }

            return tempArray;
        }
        
        /// <summary>
        /// Generates a random name, given a prefix and number of digits
        /// </summary>
        /// <param name="prefix">Prefix of the star name</param>
        /// <param name="numDigits">Number attached to the star</param>
        /// <returns>The stellar name</returns>
        private string genRandomName(string prefix, int numDigits)
        {
            return prefix + ourDice.rng(1, (int)Math.Pow(10, numDigits));
        }
        
        /// <summary>
        /// This function updates the system with the new details. 
        /// </summary>
        /// <param name="catName">Category name of the system</param>
        /// <param name="s">The new stellar details</param>
        public void updateStellarSystem(string catName, StellarSystem s)
        {
            for (int i = 0; i < this.ourSystem.Count; i++)
            {
                if (this.ourSystem[i].catName == catName)
                    this.ourSystem[i] = new StellarSystem(s);
            }
        }

        /// <summary>
        /// This finds the system by category name
        /// </summary>
        /// <param name="catName">The category name to be found</param>
        /// <returns>The system if found</returns>
        /// <exception cref="MissingMemberException">Exception thrown if it's not found</exception>
        public StellarSystem getStellarSystem(string catName)
        {
            foreach (StellarSystem s in this.ourSystem)
            {
                if (s.catName == catName)
                    return s;
            }

            throw new MissingMemberException("This system is not in the sector.");
        }    
    }
}
