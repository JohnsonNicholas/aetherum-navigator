using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwilightShards.genLibrary
{
    public static class ObjectConverter
    {
        public static bool verifyBool(object rawInput)
        {
            try
            {
                bool test = (bool)rawInput;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool verifyInteger(object rawInput)
        {
            try
            {
                if ((rawInput.GetType() == typeof(double)) && (Convert.ToInt32(rawInput) != Convert.ToDouble(rawInput)))
                    return false;
                if (Convert.ToInt32(rawInput) != Convert.ToDouble(rawInput))
                    return false;

                int test = Convert.ToInt32(rawInput);

                return true;

            }
            catch (Exception)
            {
                //Console.WriteLine("Exception: " + ex.ToString());
                return false;
            }
        }

        public static bool verifyDouble(object rawInput)
        {
            try
            {
                double test = (double)rawInput;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool verifyLong(object rawInput)
        {
            try
            {
                long test = (long)rawInput;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool verifyShort(object rawInput)
        {
            try
            {
                short test = (short)rawInput;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool verifyString(object rawInput)
        {
            try
            {
                string test = (string)rawInput;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
