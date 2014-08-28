namespace TwilightShards.genLibrary
{
    using System;

    /// <summary>
    /// This class is used for ranges.
    /// </summary>
    class ValueWithError
    {
        /// <summary>
        /// This is the base value in a value with error pair
        /// </summary>
        protected double baseValue { get; set; }

        /// <summary>
        /// This is the error value in a value with error pair
        /// </summary>
        protected double errorValue { get; set; }

        /// <summary>
        /// CONSTRUCTOR - takes the value and error
        /// </summary>
        /// <param name="val">The base value</param>
        /// <param name="err">The error bar</param>
        public ValueWithError(double val, double err)
        {
            this.baseValue = val;
            this.errorValue = err;
        }

        /// <summary>
        /// This returns the base value
        /// </summary>
        /// <returns>The base value</returns>
        public double getBaseValue()
        {
            return this.baseValue;
        }

        /// <summary>
        /// Returns if the value is within the possible range
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>true if valid, false if not</returns>
        public bool isValidValue(double value)
        {
            if (value >= (this.baseValue - this.errorValue) && value <= (this.baseValue + this.errorValue))
                return true;
            else
                return false;
        }

        /// <summary>
        /// The minimum possible value
        /// </summary>
        /// <returns>(value - error)</returns>
        public double getMinValue()
        {
            return this.baseValue - this.errorValue;
        }

        /// <summary>
        /// The maximum possible value
        /// </summary>
        /// <returns>(value + error)</returns>
        public double getMaxValue()
        {
            return this.baseValue + this.errorValue;
        }
        
    }
}
