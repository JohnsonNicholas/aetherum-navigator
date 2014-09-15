using System;
using TwilightShards.genLibrary;

namespace TwilightShards.AetherumExplorerW
{
    /// <summary>
    /// This describes a stellar event.
    /// </summary>
    public class StellarEvent
    {
        /// <summary>
        /// The event type.
        /// </summary>
        public StellarEventType EventType { get; set; }
        
        /// <summary>
        /// This is the description of the event.
        /// </summary>
        public string EventDesc { get; set; }

        public string FormattedEventYear { get; private set; }

        /// <summary>
        /// This is the year the event occured
        /// </summary>
        public double EventYear { get; private set; }

        /// <summary>
        /// Constructor!
        /// </summary>
        public StellarEvent()
        {
            EventType = StellarEventType.None;
            EventDesc = default(string);
            EventYear = default(double);
        }

        /// <summary>
        /// Full constructor.
        /// </summary>
        /// <param name="t">The event type</param>
        /// <param name="d">Event description</param>
        /// <param name="y">Event year</param>
        public StellarEvent(StellarEventType t, string d, double y)
        {
            EventType = t;
            EventDesc = d;
            EventYear = y;
            FormattedEventYear = Utility.FormatForAstronomicalYear(y);
        }

        public StellarEvent(StellarEvent s)
        {
            EventType = s.EventType;
            EventDesc = s.EventDesc;
            EventYear = s.EventYear;
            FormattedEventYear = Utility.FormatForAstronomicalYear(s.EventYear);
        }

        public void UpdateEventYear(double y)
        {
            EventYear = y;
            FormattedEventYear = Utility.FormatForAstronomicalYear(y);

        }

        /// <summary>
        /// Prints a string representation of the object
        /// </summary>
        /// <returns>A representation of the object</returns>
        public override string ToString()
        {
            string s = "[" + Utility.FormatForAstronomicalYear(EventYear) + "]";
            s = s + " " + EventType + ": " + EventDesc;

            return s;
        }
    }
}
