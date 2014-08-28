//SRC: http://stackoverflow.com/questions/424366/c-sharp-string-enums
//ATH: user29964

namespace TwilightShards.genLibrary
{
    using System;

    /// <summary>
    /// This is an attribute that allows for a String to be added to an element.
    /// </summary>
    public class StringValueAttribute : System.Attribute
    {
        private string _value;

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="value">The string within the attribute</param>
        public StringValueAttribute(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Function that returns the value
        /// </summary>
        public string Value
        {
            get { return _value; }
        }

    }
}
