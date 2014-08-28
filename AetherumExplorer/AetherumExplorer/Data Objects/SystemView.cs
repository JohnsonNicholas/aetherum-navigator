using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TwilightShards.AetherumExplorer
{
    /// <summary>
    /// This class is used to control what information is displayed, and if it needs formatting.
    /// </summary>
    internal class SystemView : INotifyPropertyChanged
    {
        private string _name;
        private string _sectorCoords;
        private string _stellarDetails;
        private string _sectorCatalog;
        private int _planetCount;
        private int _starCount;
        private bool _hasHabitablePlanets;
        private double _age;

        /// <summary>
        /// Event that tracks if the property has changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Constructor object.
        /// </summary>
        /// <param name="name">Name of the system</param>
        /// <param name="coords">Stellar Coordinates, formatted.</param>
        /// <param name="starDetail">Details of the System</param>
        /// <param name="planets">Number of Planets</param>
        /// <param name="habitable">Has a Habitable System</param>
        public SystemView(string catalog, string name, string coords, string starDetail, double age, int planets, int stars, bool habitable)
        {
            _name = name;
            _sectorCoords = coords;
            _stellarDetails = starDetail;
            _planetCount = planets;
            _starCount = stars;
            _hasHabitablePlanets = habitable;
            _sectorCatalog = catalog;
            _age = age;
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

        //********************************************** VALUE ACCESSORS. These are used to make sure we include NotifyPropertyChanged()        
        public string name
        {
            get { return _name; }
            set
            {
                if (value != this._name){
                _name = value;
                this.NotifyPropertyChanged();
                }
            }
        }
        public string sectorCoords
        {
            get { return _sectorCoords; }
            set
            {
                if (value != this._sectorCoords)
                {
                    _sectorCoords = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public string stellarDetails
        {
            get { return _stellarDetails; }
            set
            {
                if (value != this._stellarDetails)
                {
                    this._stellarDetails = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public int numOfPlanets
        {
            get { return _planetCount; }
            set
            {
                if (value != _planetCount)
                {
                    _planetCount = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public bool hasHabitablePlanets
        {
            get { return _hasHabitablePlanets; }
            set
            {
                if (value != this._hasHabitablePlanets)
                {
                    this._hasHabitablePlanets = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public string catalog
        {
            get { return _sectorCatalog; }
            set
            {
                if (value != this._sectorCatalog)
                {
                    this._sectorCatalog = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public double starAge
        {
            get { return _age; }
            set
            {
                if (value != _age)
                {
                    this._age = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public int stars
        {
            get { return _starCount; }
            set
            {
                if (value != this._starCount)
                {
                    this._starCount = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

    }
}
