//SRC: http://stackoverflow.com/questions/424366/c-sharp-string-enums
//ATH: user29964

namespace TwilightShards.genLibrary
{
    using System;
    using System.Reflection;

    /// <summary>
    /// This class provides a StringEnum refrence. Used to pull the StringValueAttribute from a Enum.
    /// </summary>
    public static class StringEnum
    {
        /// <summary>
        /// Looks at an Enum and retrieves the StringValueAttribute, returning it as a string.
        /// </summary>
        /// <param name="value">The Enum we are looking at</param>
        /// <returns>The StringValueAttribute</returns>
        public static string GetStringValue(Enum value)
        {
            string output = null;
            Type type = value.GetType();

            //Check first in our cached results...

            //Look for our 'StringValueAttribute' 

            //in the field's custom attributes

            FieldInfo fi = type.GetField(value.ToString());
            StringValueAttribute[] attrs =
               fi.GetCustomAttributes(typeof(StringValueAttribute),
                                       false) as StringValueAttribute[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Value;
            }

            return output;
        }
    }
}
