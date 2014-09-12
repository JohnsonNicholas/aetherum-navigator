using System;
using System.Collections.Generic;
using TwilightShards.genLibrary;

namespace TwilightShards.AetherumExplorerW
{
    /// <summary>
    /// This class generates a unique catalog name given a prefix and range.
    /// </summary>
    internal class CatalogGenerator
    {
        /// <summary>
        /// This is the dice object used in the code.
        /// </summary>
        private Dice OurDice;

        /// <summary>
        /// The numbers already selected.
        /// </summary>
        private List<long> TakenNumbers;

        /// <summary>
        /// The catalog prefix
        /// </summary>
        private string CatalogPrefix;

        /// <summary>
        /// The maximum number permitted by the catalog.
        /// </summary>
        private long MaxSizeCatalog;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="d">Dice object</param>
        /// <param name="maxSize">Maximum Size</param>
        /// <param name="prefix">The catalog prefix</param>
        public CatalogGenerator(Dice d, string prefix, long maxSize)
        {
            this.OurDice = d;
            this.CatalogPrefix = prefix;
            this.MaxSizeCatalog = maxSize;
            this.TakenNumbers = new List<long>();
        }

        /// <summary>
        /// This resets the taken catalog numbers, freeing it up
        /// </summary>
        public void ResetCatalog()
        {
            this.TakenNumbers.Clear();
        }

        /// <summary>
        /// This returns a unique catagory number. Primary use is for using catalogs as unique id
        /// </summary>
        /// <returns>A unique category string</returns>
        public string newUniqueNum()
        {
            string catalogNum;
            long genNum = 0;
            do{
                genNum = OurDice.rollInLongRange(0, MaxSizeCatalog); 
            } while (TakenNumbers.Contains(genNum));

            TakenNumbers.Add(genNum); //add the number to restricted numbers
            catalogNum = CatalogPrefix + genNum.ToString();

            return catalogNum;
        }

    }
}
