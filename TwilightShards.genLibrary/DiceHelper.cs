using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace TwilightShards.genLibrary
{
    /// <summary>
    /// This class contains extension methods that use the Dice object.
    /// </summary>
    public static class DiceHelper
    {
        /// <summary>
        /// This is a extension method for RangePair that rolls within the range
        /// </summary>
        /// <param name="s">The RangePair</param>
        /// <returns></returns>
        public static double RollInRange(this RangePair s, Dice d)
        {
            return d.rollInRange(s.lowBound, s.highBound);
        }
        
        /// <summary>
        /// This extension method for a list picks a random item from the list.
        /// </summary>
        /// <typeparam name="T">The type of the list</typeparam>
        /// <param name="s">The List</param>
        /// <param name="d">The Dice</param>
        /// <returns>A random item from the list</returns>
        public static T PickRandom<T>(this List<T> s, Dice d)
        {
            return s[d.rollInIntRange(0, (s.Count -1))];
        }

        public static U PickRandom<T,U>(this Dictionary<T, U> s, Dice d)
        {
            List<U> values = Enumerable.ToList(s.Values);
            return values[d.rollInIntRange(0,values.Count-1)];
        }

        public static int PickRandom(this int[] a, Dice d) 
        {
            return a[d.rollInIntRange(0, a.Length - 1)];
        }

        public static T PickRandom<T>(this T[] source, Dice d)
        {
            return source[d.rollInIntRange(0, source.Length - 1)];
        }
    }
}
