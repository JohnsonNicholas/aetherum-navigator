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
            this.ptX = c.GetCoordX();
            this.ptY = c.GetCoordY();
            this.ptZ = c.GetCoordZ();
        }

        /// <summary>
        /// This function returns the X coordinate of the point.
        /// </summary>
        /// <returns>The x coordinate</returns>
        public int GetCoordX()
        {
            return this.ptX;
        }

        /// <summary>
        /// This function returns the Y coordinate of the point
        /// </summary>
        /// <returns>The y coordinate</returns>
        public int GetCoordY()
        {
            return this.ptY;
        }

        /// <summary>
        /// This function returns the Z coordinate of the point
        /// </summary>
        /// <returns>The z coordinate</returns>
        public int GetCoordZ()
        {
            return this.ptZ;
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

            return (ptX == p.GetCoordX()) && 
                   (ptY == p.GetCoordY()) && 
                   (ptZ == p.GetCoordZ());
        }

        /*
        /// <summary>
        /// Override if you are explicitly passing it a plotpoint.
        /// </summary>
        /// <param name="p">The plot point being compared</param>
        /// <returns>True if equal, false if not</returns>
        public bool Equals(PlotPoint p)
        {
            if ((object)p == null) return false;

            return (ptX == p.getCoordX()) && (ptY == p.getCoordY()) && (ptZ == p.getCoordZ());
        } */

        /// <summary>
        /// This function returns the hash value of this object
        /// </summary>
        /// <returns>The hash value of the object</returns>
        public override int GetHashCode()
        {
            return ptX ^ ptY ^ ptZ;
        }
        
        /// <summary>
        /// Converts the point to a float[] array. Useful for mapping.
        /// </summary>
        /// <returns>A float[] of the points</returns>
        public float[] ConvertPointToFloatArray()
        {
            return new float[] { this.ptX, this.ptY, this.ptZ };
        }

        /// <summary>
        /// Converts the point to a double[] array. Useful for mapping.
        /// </summary>
        /// <returns>A double[] of the points</returns>
        public double[] ConvertPointToDoubleArray()
        {
            return new double[] { this.ptX, this.ptY, this.ptZ };
        }

        /// <summary>
        /// Calculates the distance from this point and the new point
        /// </summary>
        /// <param name="B">The plot point being compared from</param>
        /// <returns>The distance</returns>
        public double GetDistance(PlotPoint B)
        {
            double distX, distY, distZ;

            distX = Math.Pow(B.GetCoordX() - this.ptX, 2);
            distY = Math.Pow(B.GetCoordY() - this.ptY, 2);
            distZ = Math.Pow(B.GetCoordZ() - this.ptZ, 2);

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
