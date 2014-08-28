using System;
using TwilightShards.genLibrary;

namespace TwilightShards.AetherumExplorer
{
    public class StellarHistoryEvent
    {
        protected StellarEventInvoker eventInit {get; set;}
        protected double yearDate { get; set; }
        protected string eventText { get; set; }

        public StellarHistoryEvent(StellarEventInvoker init, double year, string eventStr)
        {
            this.eventInit = init;
            this.yearDate = year;
            this.eventText = eventStr;
        }

        public StellarHistoryEvent(StellarHistoryEvent s)
        {
            this.eventInit = s.eventInit;
            this.yearDate = s.yearDate;
            this.eventText = s.eventText;
        }

        public override string ToString()
        {
            string s = "[" + this.eventInit + "] ";
            s += genHelper.formatForAstronomicalYear(this.yearDate) + ": ";
            s += this.eventText;
            return s;
        }

        public StellarEventInvoker getInit()
        {
            return this.eventInit;
        }

        public string getEventText()
        {
            return this.eventText;
        }

        public double getEventYear()
        {
            return this.yearDate;
        }
    }
}
