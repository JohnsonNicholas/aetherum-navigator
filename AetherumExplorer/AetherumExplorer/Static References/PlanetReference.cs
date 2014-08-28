using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwilightShards.AetherumExplorer
{
    public static class PlanetReference
    {
        public static string convertPlanetCode(PlanetaryZone c)
        {
            switch (c)
            {
                case PlanetaryZone.UnknownZone:
                    return "Unknown Zone";
                case PlanetaryZone.BlackZone:
                    return "Black Zone";
                case PlanetaryZone.YellowZone:
                    return "Yellow Zone";
                case PlanetaryZone.GreenZone:
                    return "Green Zone";
                case PlanetaryZone.BlueZone:
                    return "Blue Zone";
                case PlanetaryZone.NoZone:
                    return "ERROR. DANGER WILL ROBINSON";
                default:
                    return "!?!?!?!?!?";
            }
        }
    }
}
