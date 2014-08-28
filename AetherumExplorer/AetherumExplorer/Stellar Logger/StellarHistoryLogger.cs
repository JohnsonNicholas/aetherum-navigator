using System;
using System.Text;
using System.Collections.Generic;
using System.Drawing;

using TwilightShards.genLibrary;

namespace TwilightShards.AetherumExplorer
{
    public class StellarHistoryLogger
    {
        public List<StellarHistoryEvent> ourEvents {get; protected set;}

        public int lastWrittenLine { get; protected set; }

        public StellarHistoryLogger()
        {
            this.ourEvents = new List<StellarHistoryEvent>();
            this.lastWrittenLine = 0;
        }

        public StellarHistoryLogger(StellarHistoryLogger h)
        {
            this.ourEvents = new List<StellarHistoryEvent>();
            this.lastWrittenLine = h.lastWrittenLine;

            foreach (StellarHistoryEvent e in h.ourEvents)
            {
                this.ourEvents.Add(new StellarHistoryEvent(e));
            }
        }

        private void AddFullEvent(StellarEventInvoker si, double year, string eventInfo)
        {
            this.ourEvents.Add(new StellarHistoryEvent(si, year, eventInfo));
        }

        public void AddSystemEvent(double year, string eventInfo)
        {
            this.AddFullEvent(StellarEventInvoker.System, year, eventInfo);
        }

        public void AddStellarEvent(double year, string eventInfo)
        {
            this.AddFullEvent(StellarEventInvoker.Star, year, eventInfo);
        }

        public void AddPlanetEvent(double year, string eventInfo)
        {
            this.AddFullEvent(StellarEventInvoker.Planet, year, eventInfo);
        }

        public void AddNebulaEvent(double year, string eventInfo)
        {
            this.AddFullEvent(StellarEventInvoker.Nebula, year, eventInfo);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (StellarHistoryEvent sEvent in this.ourEvents)
            {
                sb.Append(sEvent);
            }

            return sb.ToString();
        }

        public void printFormattedText(System.Windows.Forms.RichTextBox text)
        {
            text.Text = "";
            for (int i = 0; i < this.ourEvents.Count; i++)
            {
                text.AppendBoldText(genHelper.formatForAstronomicalYear(this.ourEvents[i].getEventYear()));
                text.AppendText("   [" + this.ourEvents[i].getInit().ToString() + "]  ", StellarHistoryLogger.getColor(this.ourEvents[i]));
                text.AppendText(this.ourEvents[i].getEventText());
                text.AppendText(Environment.NewLine);

                this.lastWrittenLine = i;
            }
        }

        public void appendNewText(System.Windows.Forms.RichTextBox text)
        {
            if (this.lastWrittenLine == (this.ourEvents.Count - 1))
                return;

            for (int i = this.lastWrittenLine; i < this.ourEvents.Count; i++)
            {
                text.AppendBoldText(genHelper.formatForAstronomicalYear(this.ourEvents[i].getEventYear()));
                text.AppendText("  [" + this.ourEvents[i].getInit().ToString() + "]  ", StellarHistoryLogger.getColor(this.ourEvents[i]));
                text.AppendText(this.ourEvents[i].getEventText());
                text.AppendText(Environment.NewLine);

                this.lastWrittenLine = i;
            }
        }

        public void purgeLog()
        {
            this.ourEvents.Clear();            
        }

        protected static Color getColor(StellarHistoryEvent s)
        {
            switch (s.getInit())
            {
                case StellarEventInvoker.Nebula:
                    return Color.DeepSkyBlue;
                case StellarEventInvoker.Other:
                    return Color.YellowGreen;
                case StellarEventInvoker.Planet:
                    return Color.Green;
                case StellarEventInvoker.Satelite:
                    return Color.Teal;
                case StellarEventInvoker.Star:
                    return Color.Blue;
                case StellarEventInvoker.StellarCollapse:
                    return Color.DarkBlue;
                case StellarEventInvoker.StellarDeath:
                    return Color.Violet;
                case StellarEventInvoker.StellarGiantPhase:
                    return Color.Red;
                case StellarEventInvoker.System:
                    return Color.DarkOliveGreen;
                case StellarEventInvoker.None:
                default:
                    return Color.Black;
            }
        }
    }
}
