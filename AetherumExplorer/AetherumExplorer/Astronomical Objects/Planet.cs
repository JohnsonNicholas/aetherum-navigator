using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwilightShards.AetherumExplorer
{
    /// <summary>
    /// This class contains the information of a generated planet
    /// </summary>
    public class Planet
    {
        /// <summary>
        /// The zone the planet is in 
        /// </summary>
        public PlanetaryZone locCode;

        /// <summary>
        /// The orbital radius of the planet/orbit
        /// </summary>
        public double orbitalRadius;

        /// <summary>
        /// The parent object of the star
        /// </summary>
        public AstronomicalObject parentPtr;

        /// <summary>
        /// The name of the planet
        /// </summary>
        public string planetName;
       
        /// <summary>
        /// Base constructor
        /// </summary>
        public Planet()
        {
            this.parentPtr = null;
            this.locCode = PlanetaryZone.UnknownZone;
            this.orbitalRadius = 0;
        }

        /// <summary>
        /// Constructor placing an unset planet (orbit) in place.
        /// </summary>
        /// <param name="parent">The parent object. This is a pointer to it.</param>
        /// <param name="loc">The zone this orbit is in.</param>
        /// <param name="radius">The orbital radius.</param>
        public Planet(AstronomicalObject parent, PlanetaryZone loc, double radius)
        {
            this.parentPtr = parent;
            this.locCode = loc;
            this.orbitalRadius = radius;
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="p">Planet being copied</param>
        public Planet(Planet p)
        {
            this.parentPtr = p.parentPtr;
            this.locCode = p.locCode;
            this.orbitalRadius = p.orbitalRadius;
        }
    }
}
