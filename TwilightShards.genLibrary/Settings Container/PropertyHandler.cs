//Code thanks to Jon Bangsberg
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwilightShards.genLibrary
{
    /// <summary>
    /// This class is meant to be a generic container for properties. 
    /// </summary>
    /// <remarks>When implementing it or calling it, remember you need to write your own Enum containing the property names.</remarks>
    public class PropertyHandler
    {
        protected Dictionary<System.Enum, object> Properties = new Dictionary<System.Enum, object>();
        protected string FilePath;

        /// <summary>
        /// This tracks if the file is up to date
        /// </summary>
        public bool isSettingsModified = true;

        /// <summary>
        /// Default constructor
        /// </summary>
        public PropertyHandler()
        {
        }

        /// <summary>
        /// This constructor takes the filepath and adds 
        /// </summary>
        /// <param name="filePath"></param>
        public PropertyHandler(string filePath)
        {
            this.FilePath = filePath;
        }

        /// <summary>
        /// This sets the file path settings are save and read from
        /// </summary>
        /// <param name="filePath">The file path</param>
        public void SaveFilePath(string filePath)
        {
            this.FilePath = filePath;
        }

        /// <summary>
        /// This function gets the value from the dictionary and returns it.
        /// </summary>
        /// <typeparam name="T">The type of the value we want</typeparam>
        /// <param name="PropertyName">The property we are retriveing</param>
        /// <returns>The value</returns>
        public T Get<T>(System.Enum PropertyName)
        {
            if (!Properties.ContainsKey(PropertyName))
                throw new ArgumentException("Invalid property");
            if (Properties[PropertyName].GetType() != typeof(T))
            {
                throw new ArgumentException("Invalid type. Type requested is " + typeof(T) + " , type gotten is " + Properties[PropertyName].GetType());
            }
      

            return (T)Properties[PropertyName];
        }

        /// <summary>
        /// This function sets the value
        /// </summary>
        /// <param name="PropertyName"></param>
        /// <param name="PropertyValue"></param>
        public void Set(System.Enum PropertyName, object PropertyValue)
        {
            Properties[PropertyName] = PropertyValue;
            this.isSettingsModified = true;
        }

    }

}//namespace close