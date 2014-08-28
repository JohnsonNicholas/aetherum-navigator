using System;

namespace TwilightShards.genLibrary
{
    /// <summary>
    /// generic pair struct
    /// </summary>
    public struct RangePair
    {
        /// <summary>
        /// Lower bound
        /// </summary>
        public double lowBound;

        /// <summary>
        /// Higher bound
        /// </summary>
        public double highBound;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="l">Lower bound</param>
        /// <param name="h">Higher bound</param>
        public RangePair(double l, double h)
        {
            this.lowBound = l;
            this.highBound = h;
        }

        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="r">The value for this pair</param>
        public RangePair(double r)
        {
            this.lowBound = this.highBound = r;
        }
    }
}
