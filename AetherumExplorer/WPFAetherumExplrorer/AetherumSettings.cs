using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;

//custom refrences
using TwilightShards.genLibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TwilightShards.AetherumExplorerW
{    
    /// <summary>
    /// This class contains the settings for this program. It extends the base class to specify the property names and allow for 
    /// save/loading from json.
    /// </summary>
    public partial class AetherumSettings : PropertyHandler
    {
       
        /// <summary>
        /// This function checks if a value is between two ends.
        /// </summary>
        /// <typeparam name="T">The type of the value</typeparam>
        /// <param name="val">The value being tested</param>
        /// <param name="lowerVal">Lower bound of the range</param>
        /// <param name="upperVal">Upper bound of the range</param>
        /// <returns>True if between or equal, false otherwise</returns>
        private static bool IsBetweenVal<T>(T val, T lowerVal, T upperVal)
            where T : IComparable
        {
            if (lowerVal.CompareTo(val) <= 0 && upperVal.CompareTo(val) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// This tests if a string is between 1 and n characters
        /// </summary>
        /// <param name="val">The string</param>
        /// <param name="higherBound">the upper bound of the string</param>
        /// <returns>True if between or equal, false otherwise</returns>
        private static bool StringLengthBetween(string val, int higherBound)
        {
            if (val.Length >= 1 && val.Length <= higherBound)
                return true;
            else
                return false;
        }

        /// <summary>
        /// This function validates the property according to attributes set in the property file
        /// </summary>
        /// <param name="prop">The property being validated</param>
        /// <param name="rawInput">The raw input from the file reader</param>
        /// <returns>True if validated, false otherwise</returns>
        public bool ValidateProperty(PropertyName prop, object rawInput)
        {
            switch (GetAttribute(prop).AttributeType)
            {
                case ValType.IntegerType:
                    return (ObjectConverter.VerifyInteger(rawInput) && IsBetweenVal<int>(Convert.ToInt32(rawInput), 
                                                                                         Convert.ToInt32(GetAttribute(prop).MinValue), 
                                                                                         Convert.ToInt32(GetAttribute(prop).MaxValue)));
                case ValType.DoubleType:
                    return (ObjectConverter.VerifyDouble(rawInput) && IsBetweenVal<double>(Convert.ToDouble(rawInput), 
                                                                                           Convert.ToDouble(GetAttribute(prop).MinValue), 
                                                                                           Convert.ToDouble(GetAttribute(prop).MaxValue)));
                case ValType.StringType:
                    return (ObjectConverter.VerifyString(rawInput) && StringLengthBetween(Convert.ToString(rawInput), 
                                                                                          GetAttribute(prop).MinStringLength));
                case ValType.LongType:
                    return (ObjectConverter.VerifyLong(rawInput) && IsBetweenVal<long>(Convert.ToInt64(rawInput), 
                                                                                       Convert.ToInt64(GetAttribute(prop).MinValue), 
                                                                                       Convert.ToInt64(GetAttribute(prop).MaxValue)));
                case ValType.BoolType: //it's a bool. If it doesn't fail the cast, let it go.
                    return (ObjectConverter.VerifyBool(rawInput));
                case ValType.EnumType:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// This sets the value according to the attribute
        /// </summary>
        /// <param name="name">Property Name</param>
        /// <param name="value">The value from the parse</param>
        /// <returns></returns>
        public object SetValue(PropertyName name, object value)
        {
            switch (GetAttribute(name).AttributeType)
            {
                case ValType.IntegerType:
                    return Convert.ToInt32(value);
                case ValType.DoubleType:
                    return Convert.ToDouble(value);
                case ValType.StringType:
                    return Convert.ToString(value);
                case ValType.LongType:
                    return Convert.ToInt64(value);
                case ValType.BoolType: //it's a bool. If it doesn't fail the cast, let it go.
                    return Convert.ToBoolean(value);
                case ValType.EnumType:
                    return (AetherumGenerationFlags)Convert.ToInt32(value);
                default:
                    return false;
            }
        } 

        /// <summary>
        /// This gets the attribute of the PropertyName passed to it. Thanks to NewtonBit
        /// </summary>
        /// <param name="parameter">The enum/PropertyName passed to</param>
        /// <returns>The attribute</returns>
        private PropDefs GetAttribute(PropertyName parameter)
        {
            var type = typeof(PropertyName);
            var memInfo = type.GetMember(parameter.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(PropDefs), false);
            return ((PropDefs)attributes[0]);
        }
        
        /*
        /// <summary>
        /// This gets the parameter value from the Properties
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>The paramter value</returns>
        public object GetParameterValue(PropertyName parameter)
        {
            return Properties[parameter];
        } */


        //**HELPER FUNCTIONS

        /// <summary>
        /// This function handles if the setting is not properly set. It ensures a common output. If the user does not set it, it exits the application.
        /// </summary>
        /// <param name="p">The property name</param>
        private void SettingInvalidSet(PropertyName p)
        {
            string warningMessage = "The setting " + p.ToString() + " has been set outside bounds. Do you wish to reset this to the default setting?";
            MessageBoxResult dr = MessageBox.Show(warningMessage, "Invalid Setting Detected", MessageBoxButton.YesNo);
            if (dr == MessageBoxResult.Yes)
                this.Set(p, GetAttribute(p).DefaultValue);
            else
            {
                Application.Current.Shutdown(-1);
                return; //actually terminate the application
            }
        }

        //**LOAD/SAVE FUNCTIONALITY

        /// <summary>
        /// This function writes the set properties to a json-formatted file
        /// </summary>
        public void SaveProperties()
        {
            using (FileStream fs = File.Open(this.FilePath, FileMode.OpenOrCreate))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, this.Properties);
            }

            base.isSettingsModified = false;
        }

        /// <summary>
        /// This function loads the properties from the json-formatted file
        /// </summary>
        public void LoadProperties()
        {
            using (StreamReader sr = new StreamReader(base.FilePath))
            {
                JObject rawInput = JObject.Parse(sr.ReadToEnd());
                foreach (var entry in rawInput)
                {
                    try
                    {
                        /* This bit reads the file by parsing the value pair and checking to see if it's a Enum
                         * Then validates it according to the properties settings (See PropDefs). If it's valid, sets it
                         * by casting it via Convert, if not, it uses a default setting. 
                         */
                        PropertyName thisProperty = Utility.ParseEnum<PropertyName>(entry.Key);
                        if (ValidateProperty(thisProperty, entry.Value.Value<object>()))
                            this.Set(thisProperty, SetValue(thisProperty, entry.Value.Value<object>()));
                        else
                            SettingInvalidSet(thisProperty);

                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show("Invalid setting detected. This setting is either missing from the known settings or"
                                        + "is in the file and is no longer a setting");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error when parsing setting detected. Attempting to continue. Error: " + ex.ToString());
                    }
                }
            }
        }

    }
}