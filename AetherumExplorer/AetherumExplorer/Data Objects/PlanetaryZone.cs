using System;


namespace TwilightShards.AetherumExplorer
{
    public enum PlanetaryZone
    {
        /// <summary>
        /// This planet is in the "unknown" zone. Unset or doesn't orbit a zone.
        /// </summary>
        UnknownZone, 

        /// <summary>
        /// This planet is in the "red" zone, indicating it orbits too close to the star (close or within the inner limit radius of planetary generation)
        /// </summary>
        RedZone,

        /// <summary>
        /// This planet is in the "yellow" zone, indicating it orbits between the inner limit radius and the inner boundary of the goldilocks zone 
        /// </summary>
        YellowZone,

        /// <summary>
        /// This planet is in the "green" zone, indicates it orbits within the goldilocks zone.
        /// </summary>
        GreenZone,

        /// <summary>
        /// This planeat is in the "blue" zone, indicates that it orbits between the goldliocks zone and the far out reaches of the system. 
        /// </summary>
        BlueZone,

        /// <summary>
        /// This planet is in the "black" zone, indicating that it orbits in the far out reaches in the system.
        /// </summary>
        BlackZone,

        /// <summary>
        /// This indicates there is no zone available. This is an error code.
        /// </summary>
        NoZone
    }
}
