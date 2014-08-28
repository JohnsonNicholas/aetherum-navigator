using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TwilightShards.AetherumExplorer
{
    internal class PlanetView : INotifyPropertyChanged
    {
        private string _stellarName;
        private string _planetName;
        private double _orbDistance;
        private string _code;

        /// <summary>
        /// Event that tracks if the property has changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public PlanetView(string stellarName, string planetName, double orbDistance, PlanetaryZone pCode)
        {
            _stellarName = stellarName;
            _planetName = planetName;
            _orbDistance = orbDistance;
            _code = PlanetReference.convertPlanetCode(pCode);
        }

        /// <summary>
        /// This function raises if the property has been changed. Code from StackOverflow
        /// </summary>
        /// <param name="propertyName">The propertyName being changed. Uses reflection to get the name</param>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string stellarName
        {
            get { return _stellarName; }
            set
            {
                if (value != this._stellarName)
                {
                    _stellarName = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public string planetName
        {
            get { return _planetName; }
            set
            {
                if (value != this._planetName)
                {
                    _planetName = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public string planetZone
        {
            get { return _code; }
            set
            {
                if (value != this._code)
                {
                    _code = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public double orbitalDistance
        {
            get { return _orbDistance; }
            set
            {
                if (value != this._orbDistance)
                {
                    _orbDistance = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
    }
}
