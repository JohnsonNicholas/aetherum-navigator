using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media;
using TwilightShards.genLibrary;

namespace TwilightShards.AetherumExplorerW
{
    /// <summary>
    /// This logs stellar events.
    /// </summary>
    public class StellarEventLogger : TwilightLogger, INotifyPropertyChanged
    {
        /// <summary>
        /// Overrides base events with the new logger.
        /// </summary>
        new public List<StellarEvent> LoggedEvents { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This function raises if the property has been changed. Code from StackOverflow
        /// </summary>
        /// <param name="propertyName">The propertyName being changed. Uses reflection to get the name</param>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// This function adds an event to the log.
        /// </summary>
        /// <param name="desc">Event description</param>
        /// <param name="year">Event year</param>
        /// <param name="eventType">The event type</param>
        public void AddLogEvent(String desc, double year, StellarEventType eventType)
        {
            LoggedEvents.Add(new StellarEvent(eventType, desc, year));
            NotifyPropertyChanged("LoggedEvents");
        }

        public void AddLogEvent(StellarEvent newEvent)
        {
            LoggedEvents.Add(newEvent);
            NotifyPropertyChanged("LoggedEvents");
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public StellarEventLogger()
            : base()
        {
            LoggedEvents = new List<StellarEvent>();
        }

        /// <summary>
        /// This is the internal output writer.
        /// </summary>
        /// <param name="start">The logEvent you want to start with.</param>
        new protected void WriteOutput(int start = 0)
        {
            for (int i = start; i < LoggedEvents.Count; i++)
            {
                if (GetConsoleOutputAllowed())
                    Console.WriteLine(LoggedEvents[i].ToString());
                if (GetFileOutputAllowed() && FileOutput != null)
                    FileOutput.Write(LoggedEvents[i].ToString());
                //TODO add Database and Internet write functionality.
            }
            CurrentLastWrittenEvent = LoggedEvents.Count;
        }
    }
}
