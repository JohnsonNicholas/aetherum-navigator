using System;
using TwilightShards.genLibrary;

namespace TwilightShards.AetherumExplorerW
{
    public partial class AetherumSettings : PropertyHandler
    {
        /// <summary>
        /// Returns the minimum stellar distance. Wraps around the longer call.
        /// </summary>
        /// <returns>float of min stellar distance</returns>
        public double GetMinStellarDistance()
        {
            return this.Get<double>(PropertyName.MinimumStellarSeperation);
        }

        /// <summary>
        /// Return the stellar density. Wraps around the longer call.
        /// </summary>
        /// <returns>float of stellar density</returns>
        public double GetStellarDensity()
        {
            return this.Get<double>(PropertyName.StellarDensity);
        }

        /// <summary>
        /// Returns the grid type. Wraps around the longer call
        /// </summary>
        /// <returns>Int describing the grid type</returns>
        public int GetGridType()
        {
            return this.Get<int>(PropertyName.Is3DGrid);
        }

        /// <summary>
        /// Returns the sector side (in ly) per side of the cube. Wrapper around the longer call.
        /// </summary>
        /// <returns>int decribing the sector size</returns>
        public int GetSectorSizePerSide()
        {
            return this.Get<int>(PropertyName.SectorSizePerSide);
        }

        /// <summary>
        /// This function returns the light year resolution
        /// </summary>
        /// <returns>An int containing the light year fraction</returns>
        public int GetLightYearResolution()
        {
            return this.Get<int>(PropertyName.LightYearResolution);
        }

        /// <summary>
        /// This returns the sector prefix.
        /// </summary>
        /// <returns>The sector prefix</returns>
        public string GetSectorPrefix()
        {
            return this.Get<string>(PropertyName.DefaultSectorPrefix);
        }

        /// <summary>
        /// Returns the sector catalog max number
        /// </summary>
        /// <returns>The sector catalog max number</returns>
        public long GetSectorMaxNum()
        {
            return this.Get<long>(PropertyName.MaxSizeOfSectorCatalog);
        }

        /// <summary>
        /// This function returns the type of grid we are using.
        /// </summary>
        /// <returns>True if it is 3D, False if it is 2D</returns>
        /// <exception cref="ArgumentOutOfRangeException">The function throws an error if it is neither 2D or 3D.</exception>
        public bool GridTypeIs3D()
        {
            return this.Get<bool>(PropertyName.Is3DGrid);
        }

        /// <summary>
        /// Retrieves the space opera override property
        /// </summary>
        /// <returns>A bool describing the space opera override</returns>
        public bool AllowForSpaceOperaOverride()
        {
            return this.Get<bool>(PropertyName.AllowForSpaceOperaOverride);
        }

        /// <summary>
        /// Retrieves the rare astronomical object probablity
        /// </summary>
        /// <returns>A double describing the rare astronomical object probablity</returns>
        public double GetRareAstronomicalObjectProbability() 
        {
            return this.Get<double>(PropertyName.RareAstronomicalObjectProbability);
        }

        /// <summary>
        /// Retrieves the threshold probablity for placing a nebula
        /// </summary>
        /// <returns>A double describing the threshold probability</returns>
        public double GetThresholdForNebulaPlacement()
        {
            return this.Get<double>(PropertyName.ThresholdForNebulaPlacement);
        }

        /// <summary>
        /// Retrieves the threshold probability for an interstellar nebula 
        /// </summary>
        /// <returns>A double describing the interstellar nebula probablity</returns>
        public double GetInterstellarNebulaThreshold()
        {
            return this.Get<double>(PropertyName.InterstellarNebulaThreshold);
        }

        /// <summary>
        /// Retrieves the threshold probablity for a planetary nebula
        /// </summary>
        /// <returns>A double describing the planetary Nebula Threshold</returns>
        public double GetPlanetaryNebulaTreshold()
        {
            return this.Get<double>(PropertyName.PlanetaryNebulaThreshold); 
        }

        /// <summary>
        /// Retrieves the factor we multiply star generation probablity if it's a 2D grid.
        /// </summary>
        /// <returns>A int factor for multiplcation</returns>
        public int GetTwoDMultiplication()
        {
            return this.Get<int>(PropertyName.TwoDMultiplication);
        }

        /// <summary>
        /// Retrieves whether or not the grid is allowed to be negative.
        /// </summary>
        /// <returns>A bool describing the probablity</returns>
        public bool GetAllowNegativeGrid()
        {
            return this.Get<bool>(PropertyName.AllowNegativeGrid);
        }

        /// <summary>
        /// Retrieves the system prefix.
        /// </summary>
        /// <returns>String describing the prefix</returns>
        public string GetSystemPrefix()
        {
            return this.Get<string>(PropertyName.DefaultSystemPrefix);
        }

        /// <summary>
        /// Retrieves the system maximum number
        /// </summary>
        /// <returns>Long describing the maximum number the system can be</returns>
        public long GetSystemMaxNum()
        {
            return this.Get<long>(PropertyName.MaxSizeOfSystemCatalog);
        }

        /// <summary>
        /// Retrieves the minimum planetary distance when generating orbits 
        /// </summary>
        /// <returns>minimum planetary distance in AU</returns>
        public double GetMinPlanetaryAUDist()
        {
            return this.Get<double>(PropertyName.OrbitRangeMinAU);
        }

        /// <summary>
        /// Retrieves the minimum planetary multiple when generating orbits
        /// </summary>
        /// <returns>Minimum ratio when generating orbits</returns>
        public double GetMinPlanetaryMultiple()
        {
            return this.Get<double>(PropertyName.OrbitRangeMinRadius);
        }

        /// <summary>
        /// Retrieves the maxmimum planetary multiple when generating orbits
        /// </summary>
        /// <returns>Maxmimum ratio when generating orbits</returns>
        public double GetMaxPlanetaryMultiple()
        {
            return this.Get<double>(PropertyName.OrbitRangeMaxRadius);
        }

        /// <summary>
        /// Retrieves setting for favoring garden worlds when generating stellar masses
        /// </summary>
        /// <returns>Bool describing garden world favorability</returns>
        public bool GetFavorGardenWorldMass()
        {
            return this.Get<bool>(PropertyName.FavorGardenWorldMass);
        }
        
        /// <summary>
        /// Retieves setting for prefering higher mass stars during stellar mass generator
        /// </summary>
        /// <returns>Bool describing higher mass generation during system gen.</returns>
        public bool GetAlternateHighMassGeneration()
        {
            return this.Get<bool>(PropertyName.AlternateHighMassGeneration);
        }
    }
}
