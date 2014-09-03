using System;
using System.Text;
using System.IO;
using System.Security.AccessControl;

namespace TwilightShards.genLibrary
{
    /// <summary>
    /// A collection of general helper functions
    /// </summary>
    public static class genHelper
    {
        public const long MILLION  = 1000000;
        public const long BILLION  = 1000000000;
        public const long TRILLION = 1000000000000;

        /// <summary>
        /// This function formats for an astronomical year.
        /// </summary>
        /// <param name="year">Number of years</param>
        /// <returns></returns>
        public static string formatForAstronomicalYear(double year) 
        {
            //Millions are MYa, Billions are GYa, Trillions are TYa
            if (year < 10000)
                return String.Format("{0:F3} Kyr", year);
            if (year >= 100000 && year < MILLION)
                return String.Format("{0:F3} Myr", (year / MILLION));
            
            if (year >= MILLION && year < BILLION)
                return String.Format("{0:F3} Myr", (year / MILLION));

            if (year >= BILLION && year < TRILLION)
                return String.Format("{0:F3} Gyr", (year / BILLION));
            if (year >= TRILLION)
                return String.Format("{0:F3} Tyr", (year / TRILLION));

            return year.ToString() + " ???";            
        }

        /// <summary>
        /// This function parses an string to an Enum
        /// </summary>
        /// <typeparam name="T">The Enum we are converting to</typeparam>
        /// <param name="value">The string value we are converting from</param>
        /// <returns>The enum value</returns>
        public static T parseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static bool validateTextInput(int numChars, string input)
        {
            if (input.Length > numChars)
                return false;

            return true;
        }


        /// <summary>
        /// This prints a variable number of lines to the Console. (ONLY call when you are using the Console.)
        /// </summary>
        /// <param name="lines">Number of lines to be printed</param>
        public static void printMultipleLines(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Finds if the program has write permissions to this folder
        /// </summary>
        /// <param name="path">The folder to be tested</param>
        /// <returns>True for write permissions; False for none</returns>
        public static bool HasWritePermissionOnDir(string path)
        {
            var writeAllow = false;
            var writeDeny = false;
            try
            {
                var accessControlList = Directory.GetAccessControl(path);
                if (accessControlList == null)
                    return false;
                var accessRules = accessControlList.GetAccessRules(true, true,
                                            typeof(System.Security.Principal.SecurityIdentifier));
                if (accessRules == null)
                    return false;

                foreach (FileSystemAccessRule rule in accessRules)
                {
                    if ((FileSystemRights.Write & rule.FileSystemRights) != FileSystemRights.Write)
                        continue;

                    if (rule.AccessControlType == AccessControlType.Allow)
                        writeAllow = true;
                    else if (rule.AccessControlType == AccessControlType.Deny)
                        writeDeny = true;
                }

                return writeAllow && !writeDeny;
            }
            catch (UnauthorizedAccessException)
            {
                //the user cannot access the rights.
                return false; 
            }
        }

        /// <summary>
        /// Finds if this program has read permissions in this folder
        /// </summary>
        /// <param name="path">The folder to be tested</param>
        /// <returns>True for read permissions; False for none</returns>
        public static bool HasReadPermissionOnDir(string path)
        {
            var readAllow = false;
            var readDeny = false;
            try
            {
                var accessControlList = Directory.GetAccessControl(path);
                if (accessControlList == null)
                    return false;
                var accessRules = accessControlList.GetAccessRules(true, true,
                                            typeof(System.Security.Principal.SecurityIdentifier));
                if (accessRules == null)
                    return false;

                foreach (FileSystemAccessRule rule in accessRules)
                {
                    if ((FileSystemRights.Read & rule.FileSystemRights) != FileSystemRights.Read)
                        continue;

                    if (rule.AccessControlType == AccessControlType.Allow)
                        readAllow = true;
                    else if (rule.AccessControlType == AccessControlType.Deny)
                        readDeny = true;
                }

                return readAllow && !readDeny;
            }
            catch (UnauthorizedAccessException)
            {
                //the user cannot access the rights.
                return false;
            }
        }

    }
}
