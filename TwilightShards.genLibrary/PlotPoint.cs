using System;

namespace TwilightShards.genLibrary
{
    /// <summary>
    /// This is a point for a 3d plot.
    /// </summary>
    public class PlotPoint
    {
        /// <summary>
        /// The x coordinate
        /// </summary>
        protected int ptX { get; set; }

        /// <summary>
        /// The y coordinate
        /// </summary>
        protected int ptY { get; set; }

        /// <summary>
        /// The z coordinate
        /// </summary>
        protected int ptZ { get; set; }

        /// <summary>
        /// Base constructor
        /// </summary>
        public PlotPoint()
        {
            ptX = 0;
            ptY = 0;
            ptZ = 0;
        }

        /// <summary>
        /// 2d point constructor
        /// </summary>
        /// <param name="x">X coord</param>
        /// <param name="y">Y coord</param>
        public PlotPoint(int x, int y)
        {
            ptX = x;
            ptY = y;
        }

        /// <summary>
        /// 3d point constructor
        /// </summary>
        /// <param name="x">X coord</param>
        /// <param name="y">Y coord</param>
        /// <param name="z">Z coord</param>
        public PlotPoint(int x, int y, int z)
        {
            ptX = x;
            ptY = y;
            ptZ = z;
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="c">PlotPoint being copied</param>
        public PlotPoint(PlotPoint c)
        {
            this.ptX = c.getCoordX();
            this.ptY = c.getCoordY();
            this.ptZ = c.getCoordZ();
        }

        //get methods - defined here in case I need to do any verification later.
        public int getCoordX()
        {
            return this.ptX;
        }

        public int getCoordY()
        {
            return this.ptY;
        }

        public int getCoordZ()
        {
            return this.ptZ;
        }

        /// <summary>
        /// This adds the two points together using standard point addition
        /// </summary>
        /// <param name="p1">The first point</param>
        /// <param name="p2">The second point</param>
        /// <returns>The combined point</returns>
        public static PlotPoint operator +(PlotPoint p1, PlotPoint p2)
        {
            return new PlotPoint(p1.getCoordX() + p2.getCoordX(), p1.getCoordY() + p2.getCoordY(), p1.getCoordZ() + p2.getCoordZ());
        }

        /// <summary>
        /// This subtracts the two points together using standard point subtraction
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static PlotPoint operator -(PlotPoint p1, PlotPoint p2)
        {
            return new PlotPoint(p1.getCoordX() - p2.getCoordX(), p1.getCoordY() - p2.getCoordY(), p1.getCoordZ()- p2.getCoordZ());
        } 

        //the two equal overrides.

        /// <summary>
        /// Overrides System.Object equals to test if the point is equal
        /// </summary>
        /// <param name="obj">The object being compared</param>
        /// <returns>true if equal, false if not</returns>
        public override bool Equals(object obj)
        {
            //a null point obviously isn't equal.
            if (obj == null) return false;

            PlotPoint p = obj as PlotPoint;
            if ((Object)p == null) return false; // if the cast fails, return false

            return (ptX == p.getCoordX()) && (ptY == p.getCoordY()) && (ptZ == p.getCoordZ());
        }

        /// <summary>
        /// Override if you are explicitly passing it a plotpoint.
        /// </summary>
        /// <param name="p">The plot point being compared</param>
        /// <returns>True if equal, false if not</returns>
        public bool Equals(PlotPoint p)
        {
            if ((object)p == null) return false;

            return (ptX == p.getCoordX()) && (ptY == p.getCoordY()) && (ptZ == p.getCoordZ());
        }

        public override int GetHashCode()
        {
            return ptX ^ ptY ^ ptZ;
        }
        
        /// <summary>
        /// Converts the point to a float[] array. Useful for mapping.
        /// </summary>
        /// <returns>A float[] of the points</returns>
        public float[] convertPointToArray()
        {
            return new float[] { this.ptX, this.ptY, this.ptZ };
        }

        /// <summary>
        /// Calculates the distance from this point and the new point
        /// </summary>
        /// <param name="B">The plot point being compared from</param>
        /// <returns>The distance</returns>
        public double getDistance(PlotPoint B)
        {
            double distX, distY, distZ;

            distX = Math.Pow(B.getCoordX() - this.ptX, 2);
            distY = Math.Pow(B.getCoordY() - this.ptY, 2);
            distZ = Math.Pow(B.getCoordZ() - this.ptZ, 2);

            return Math.Sqrt(distX + distY + distZ);
        }

        /// <summary>
        /// Resets the point with all new points, if an array is used
        /// </summary>
        /// <param name="points">The points being used</param>
        public void SetCoords(int[] points)
        {
            this.ptX = points[0];
            this.ptY = points[1];
            this.ptZ = points[2];
        }

        /// <summary>
        /// This function overrides the toString functionality.
        /// </summary>
        /// <returns>A string describing the object</returns>
        public override string ToString()
        {
            return ("{" + this.ptX + "," + this.ptY + "," + this.ptZ + "}");
        }
    }
}
