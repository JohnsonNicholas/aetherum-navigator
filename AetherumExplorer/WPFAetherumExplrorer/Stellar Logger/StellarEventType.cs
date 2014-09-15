using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwilightShards.AetherumExplorerW
{
    /// <summary>
    /// This tracks what type of event occured.
    /// </summary>
    public enum StellarEventType
    {
        /// <summary>
        /// No type of event
        /// </summary>
        None,

        /// <summary>
        /// This event happened during system creation
        /// </summary>
        SystemCreation,

        /// <summary>
        /// This event happened to/by the system
        /// </summary>
        System,

        /// <summary>
        /// This event happened during stellar creation
        /// </summary>
        StellarCreation,

        /// <summary>
        /// This event happened to/by the star
        /// </summary>
        Stellar,

        /// <summary>
        /// This event happened during planetary creation
        /// </summary>
        PlanetaryCreation,

        /// <summary>
        /// This event happened to/by the planet
        /// </summary>
        Planetary,

        /// <summary>
        /// This event happened during the star dying
        /// </summary>
        StellarDeath,

        /// <summary>
        /// This event happend to/by a nebula.
        /// </summary>
        Nebula
    }
}
