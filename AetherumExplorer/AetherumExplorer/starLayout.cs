using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwilightShards.AetherumExplorer
{
    public class starLayout
    {
        /// <summary>
        /// The stellar object
        /// </summary>
        protected StellarObject starObject;

        /// <summary>
        /// Where is it located (order wise) in the system
        /// </summary>
        protected int starOrder;
        
        /// <summary>
        /// The distance from the center
        /// </summary>
        protected double distanceFromCenter;

        public starLayout()
        {
            this.starObject = null;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="s">starLayout being copied</param>
        public starLayout(starLayout s)
        {
            this.starObject = new StellarObject(s.starObject); 
            this.starOrder = s.starOrder;
            this.distanceFromCenter = s.distanceFromCenter;
        }

        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="so">The stellar object</param>
        /// <param name="order">The order of the object</param>
        /// <param name="dist">distance from center</param>
        public starLayout(StellarObject so, int order, double dist)
        {
            this.starObject = so;
            this.starOrder = order;
            this.distanceFromCenter = dist;
        }

        /// <summary>
        /// This function will find the distance if the object is in the list.
        /// </summary>
        /// <param name="so">The stellar object being checked for</param>
        /// <param name="dist">The distance. Will return NaN if not found</param>
        /// <returns>True on success, false if not.</returns>
        public bool findDistanceIfObjectExists(StellarObject so, out double dist)
        {
            if (this.starObject.ident == so.ident)
            {
                dist = this.distanceFromCenter;
                return true;
            }

            else
            {
                dist = Double.NaN;
                return false; //object not found.
            }
            
        }

        /// <summary>
        /// This function will return a description of the order
        /// </summary>
        /// <param name="order">Int of the order (0-3)</param>
        /// <returns>String description of the order</returns>
        public static string renderOrder(int order)
        {
            switch (order)
            {
                case 0:
                    return "Primary";
                case 1:
                    return "Secondary";
                case 2:
                    return "Trinary";
                case 3:
                    return "Quaternary";
                default:
                    return "NEMESIS!";
            }
        }

        /// <summary>
        /// This returns the distance from the center for this star object
        /// </summary>
        /// <returns>The distance</returns>
        public double getDistanceFromCenter()
        {
            return this.distanceFromCenter;
        }

        /// <summary>
        /// Set the distance from the center
        /// </summary>
        /// <param name="d">Distance</param>
        public void setDistance(double d)
        {
            this.distanceFromCenter = d;
        }

        /// <summary>
        /// Returns the stellar type of this star
        /// </summary>
        /// <returns></returns>
        /// 
        public SOOpCode getStellarType()
        {
            return this.starObject.stellarType;
        }

        /// <summary>
        /// Returns the stellar object.
        /// </summary>
        /// <returns>The stellar object</returns>
        public StellarObject getStellarObject()
        {
            return this.starObject;
        }

        public void setStellarObject(StellarObject sObject)
        {
            this.starObject = new StellarObject(sObject);
        }

        public double getInnerLimit()
        {
            return this.starObject.calcInnerLimit();
        }

        public double getOuterLimit()
        {
            return this.starObject.calcOuterLimit();
        }
    }
}
