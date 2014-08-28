using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TwilightShards.genLibrary;

namespace TwilightShards.AetherumExplorer
{
    public partial class AetherumSettings : PropertyHandler
    {
        /// <summary>
        /// Returns the minimum stellar distance. Wraps around the longer call.
        /// </summary>
        /// <returns>float of min stellar distance</returns>
        public double getMinStellarDistance()
        {
            return this.Get<double>(PropertyName.MinimumStellarSeperation);
        }

        /// <summary>
        /// Return the stellar density. Wraps around the longer call.
        /// </summary>
        /// <returns>float of stellar density</returns>
        public double getStellarDensity()
        {
            return this.Get<double>(PropertyName.StellarDensity);
        }

        /// <summary>
        /// Returns the grid type. Wraps around the longer call
        /// </summary>
        /// <returns>Int describing the grid type</returns>
        public int getGridType()
        {
            return this.Get<int>(PropertyName.Is3DGrid);
        }

        /// <summary>
        /// Returns the sector side (in ly) per side of the cube. Wrapper around the longer call.
        /// </summary>
        /// <returns>int decribing the sector size</returns>
        public int getSectorSizePerSide()
        {
            return this.Get<int>(PropertyName.SectorSizePerSide);
        }

        /// <summary>
        /// This function returns the light year resolution
        /// </summary>
        /// <returns>An int containing the light year fraction</returns>
        public int getLightYearResolution()
        {
            return this.Get<int>(PropertyName.LightYearResolutionFactor);
        }

        /// <summary>
        /// This returns the sector prefix.
        /// </summary>
        /// <returns>The sector prefix</returns>
        public string getSectorPrefix()
        {
            return this.Get<string>(PropertyName.DefaultSectorPrefix);
        }

        /// <summary>
        /// Returns the stellar prefix
        /// </summary>
        /// <returns>The stellar prefix</returns>
        public string getStellarPrefix()
        {
            return this.Get<string>(PropertyName.DefaultStellarPrefix);
        }

        /// <summary>
        /// Returns the sector catalog max number
        /// </summary>
        /// <returns>The sector catalog max number</returns>
        public int getSectorMaxNum()
        {
            return this.Get<int>(PropertyName.MaxSizeOfSectorCatalog);
        }

        /// <summary>
        /// Returns the stellar maximum number
        /// </summary>
        /// <returns>The stellar maximum number</returns>
        public int getStellarMaxNum()
        {
            return this.Get<int>(PropertyName.MaxSizeOfStellarCatalog);
        }

        /// <summary>
        /// This function returns the type of grid we are using.
        /// </summary>
        /// <returns>True if it is 3D, False if it is 2D</returns>
        /// <exception cref="ArgumentOutOfRangeException">The function throws an error if it is neither 2D or 3D.</exception>
        public bool gridTypeIs3D()
        {
            return this.Get<bool>(PropertyName.Is3DGrid);
        }

        /// <summary>
        /// Retrieves the space opera override property
        /// </summary>
        /// <returns>A bool describing the space opera override</returns>
        public bool allowForSpaceOperaOverride()
        {
            return this.Get<bool>(PropertyName.AllowForSpaceOperaOverride);
        }

        public double getRareAstronomicalObjectProbability() 
        {
            return this.Get<double>(PropertyName.RareAstronomicalObjectProbability);
        }

        public double getThresholdForNebulaPlacement()
        {
            return this.Get<double>(PropertyName.ThresholdForNebulaPlacement);
        }

        public double getInterstellarNebulaThreshold()
        {
            return this.Get<double>(PropertyName.InterstellarNebulaThreshold);
        }

        public double getPlanetaryNebulaTreshold()
        {
            return this.Get<double>(PropertyName.PlanetaryNebulaThreshold); 
        }

        public int getTwoDMultiplication()
        {
            return this.Get<int>(PropertyName.TwoDMultiplication);
        }

        public bool getAllowNegativeGrid()
        {
            return this.Get<bool>(PropertyName.AllowNegativeGrid);
        }

        public string getSystemPrefix()
        {
            return this.Get<string>(PropertyName.DefaultSystemPrefix);
        }

        public int getSystemMaxNum()
        {
            return this.Get<int>(PropertyName.MaxSizeOfSystemCatalog);
        }

        public double getMinPlanetaryAUDist()
        {
            return this.Get<double>(PropertyName.OrbitRangeMinAU);
        }

        public double getMinPlanetaryMultiple()
        {
            return this.Get<double>(PropertyName.OrbitRangeMinRadius);
        }

        public double getMaxPlanetaryMultiple()
        {
            return this.Get<double>(PropertyName.OrbitRangeMaxRadius);
        }

        public bool getFavorGardenWorldMass()
        {
            return this.Get<bool>(PropertyName.FavorGardenWorldMass);
        }
        
        public bool getAlternateHighMassGeneration()
        {
            return this.Get<bool>(PropertyName.AlternateHighMassGeneration);
        }
    }
}
