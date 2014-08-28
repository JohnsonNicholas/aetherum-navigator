using System;


namespace TwilightShards.AetherumExplorer
{
    /// <summary>
    /// This object represents any object that may be found in a star system. Including nebulas
    /// </summary>
    public class AstronomicalObject
    {
        /// <summary>
        /// The object type.
        /// </summary>
        protected AstroObjectType objType { get; set; }
        
        /// <summary>
        /// The mass of the object. This may be null.
        /// </summary>
        public double? objMass { get; private set; }

        /// <summary>
        /// The distance from the center of the system. 
        /// </summary>
        public double distFromPrimary { get; private set; }

        /// <summary>
        /// The brightness of a star
        /// </summary>
        public double? stellarBrightness { get; private set; }
        
        /// <summary>
        /// Flag tracking if it has been destroyed.
        /// </summary>
        public bool objectDestroyed { get; private set; }

        /// <summary>
        /// Tracks if this is a flare star
        /// </summary>
        public bool isFlareStar { get; private set; }

        public bool hasAccretion { get; private set; }

        public bool isEngulfed { get; private set; }

        /// <summary>
        /// Base constructor
        /// </summary>
        public AstronomicalObject()
        {
        }

        public AstronomicalObject(AstroObjectType oType)
        {
            this.objType = oType;
            this.objMass = null;
            this.stellarBrightness = null;
            this.distFromPrimary = 0;
            this.objectDestroyed = false;
        }

        /// <summary>
        /// This is the full constructor
        /// </summary>
        /// <param name="oType">The type of the object</param>
        /// <param name="oMass">The mass of the object</param>
        /// <param name="oDist">The distance from the center</param>
        public AstronomicalObject(AstroObjectType oType, double? oMass, double oDist, double? brightness)
        {
            this.objType = oType;
            this.objMass = oMass;
            this.distFromPrimary = oDist;
            this.stellarBrightness = brightness;
            this.objectDestroyed = false;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="o">object being copied</param>
        public AstronomicalObject(AstronomicalObject o)
        {
            this.objType = o.objType;
            this.objMass = o.objMass;
            this.distFromPrimary = o.distFromPrimary;
            this.stellarBrightness = o.stellarBrightness;
            this.objectDestroyed = o.objectDestroyed;
        }

        //****************************************************** Functions
        public AstroObjectType getStellarType()
        {
            return this.objType;
        }

        public void setObjectDestroyed()
        {
            this.objectDestroyed = true;
        }

        public void setObjectAlive()
        {
            this.objectDestroyed = false;
        }
    }
}
