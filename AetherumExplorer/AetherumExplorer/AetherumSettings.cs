namespace TwilightShards.AetherumExplorer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Windows.Forms;

    //custom refrences
    using TwilightShards.genLibrary;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// This class contains the settings for this program. It extends the base class to specify the property names and allow for save/loading from json
    /// </summary>
    public partial class AetherumSettings : PropertyHandler
    {
        private static bool IsBetweenVal<T>(T val, T lowerVal, T upperVal)
            where T : IComparable
        {
            if (lowerVal.CompareTo(val) <= 0 && upperVal.CompareTo(val) >= 0)
                return true;
            else
                return false;
        }

        private static bool StringLengthBetween(string val, int higherBound)
        {
            if (val.Length >= 1 && val.Length <= higherBound)
                return true;
            else
                return false;
        }

        public bool validateProperty(PropertyName prop, object rawInput)
        {
            switch (GetAttribute(prop).attributeType)
            {
                case ValType.IntegerType:
                    return (ObjectConverter.verifyInteger(rawInput) && IsBetweenVal<int>(Convert.ToInt32(rawInput), Convert.ToInt32(GetAttribute(prop).minValue), Convert.ToInt32(GetAttribute(prop).maxValue)));
                case ValType.DoubleType:
                    return (ObjectConverter.verifyDouble(rawInput) && IsBetweenVal<double>(Convert.ToDouble(rawInput), Convert.ToDouble(GetAttribute(prop).minValue), Convert.ToDouble(GetAttribute(prop).maxValue)));
                case ValType.StringType:
                    return (ObjectConverter.verifyString(rawInput) && StringLengthBetween((string)rawInput, GetAttribute(prop).minStringLength));
                case ValType.LongType:
                    return (ObjectConverter.verifyLong(rawInput) && IsBetweenVal<long>(Convert.ToInt64(rawInput), Convert.ToInt64(GetAttribute(prop).minValue), Convert.ToInt64(GetAttribute(prop).maxValue)));
                case ValType.BoolType: //it's a bool. If it doesn't fail the cast, let it go.
                    return (ObjectConverter.verifyBool(rawInput));
                case ValType.EnumType:
                    return true;
                default:
                    return false;
            }
        }

        public object SetValue(PropertyName name, object value)
        {
            switch (GetAttribute(name).attributeType)
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

        public object GetParameterValue(PropertyName parameter)
        {
            return Properties[parameter];
        }


        //**HELPER FUNCTIONS

        /// <summary>
        /// This function handles if the setting is not properly set. It ensures a common output. If the user does not set it, it exits the application.
        /// </summary>
        /// <param name="p">The property name</param>
        private void settingInvalidSet(PropertyName p)
        {
            string warningMessage = "The setting " + p.ToString() + " has been set outside bounds. Do you wish to reset this to the default setting?";
            DialogResult dr = MessageBox.Show(warningMessage, "Invalid Setting Detected", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                this.Set(p, GetAttribute(p).defaultValue);
            else
                Application.Exit();
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
                        PropertyName thisProperty = genHelper.parseEnum<PropertyName>(entry.Key);
                        if (validateProperty(thisProperty, entry.Value.Value<object>()))
                            this.Set(thisProperty, SetValue(thisProperty, entry.Value.Value<object>()));
                        else
                            settingInvalidSet(thisProperty);

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