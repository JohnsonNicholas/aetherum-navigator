using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TwilightShards.genLibrary;

namespace TwilightShards.AetherumExplorer
{
    class CatalogGenerator
    {
        private Dice ourDice;
        private List<int> takenNumbers;

        /// <summary>
        /// Constructor
        /// </summary>
        public CatalogGenerator(Dice d)
        {
            this.ourDice = d;
            this.takenNumbers = new List<int>();
        }

        /// <summary>
        /// This resets the taken catalog numbers, freeing it up
        /// </summary>
        public void resetCatalog()
        {
            this.takenNumbers.Clear();
        }

        /// <summary>
        /// This returns a unique catagory number. Primary use is for using catalogs as unique id
        /// </summary>
        /// <returns>A unique NGC category number</returns>
        public string newUniqueNum()
        {
            
            string catalogNum = "NGC ";
            int genNum = 0;
            do{
                genNum = ourDice.rollInIntRange(0,10000); //reduced from 1million.
            } while (this.takenNumbers.Contains(genNum));

            this.takenNumbers.Add(genNum); //add the number to restricted numbers
            catalogNum = catalogNum + genNum.ToString();

            return catalogNum;
        }

    }
}
