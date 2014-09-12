using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TwilightShards.genLibrary;

namespace TwilightShards.AetherumExplorerW
{
    /// <summary>
    /// This class is used to control what information is displayed, and if it needs formatting.
    /// </summary>
    internal class SystemInfoView : INotifyPropertyChanged
    {
        /// <summary>
        /// This is the parent ID
        /// </summary>
        public Guid _parentID;

        /// <summary>
        /// This is the system name
        /// </summary>
        private string _name;

        /// <summary>
        /// This is the catalog name
        /// </summary>
        private string _catalog;

        /// <summary>
        /// The formatted coordinates
        /// </summary>
        private string _sectorCoords;

        /// <summary>
        /// The details of the system
        /// </summary>
        private string _stellarDetails;

        /// <summary>
        /// The number of planets
        /// </summary>
        private int _planetCount;

        /// <summary>
        /// The number of stars
        /// </summary>
        private int _starCount;
        
        /// <summary>
        /// If this system has a habitable planet
        /// </summary>
        private bool _hasHabitablePlanets;

        /// <summary>
        /// The age of the system, formatted.
        /// </summary>
        private string _age;

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
        /// <param name="parentID">GUID of the parent.</param>
        /// <param name="age">The stellar age</param>
        /// <param name="catalog">The catalog name</param>
        /// <param name="stars">Number of stars</param>
        public SystemInfoView(string catalog, string name, string coords, string starDetail, string age, int planets, int stars, bool habitable, Guid parentID)
        {
            _name = name;
            _sectorCoords = coords;
            _stellarDetails = starDetail;
            _planetCount = planets;
            _starCount = stars;
            _hasHabitablePlanets = habitable;
            _catalog = catalog;
            _age = age;
            _parentID = parentID;
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
    
        /// <summary>
        /// Get and set accessor for the System Name
        /// </summary>
        public string SystemName
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

        /// <summary>
        /// Get and set accessor for the Location details.
        /// </summary>
        public string Location
        {
            get { return _sectorCoords; }
            set
            {
                _sectorCoords = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Get and set accessor for the description of the system
        /// </summary>
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

        /// <summary>
        /// Get and set for the number of planets
        /// </summary>
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

        /// <summary>
        /// Get and set for habitable planets.
        /// </summary>
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

        /// <summary>
        /// Get and set for system catalog
        /// </summary>
        public string SystemCatalog
        {
            get { return _catalog; }
            set
            {
                if (value != this._catalog)
                {
                    this._catalog = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Get and set for the system age
        /// </summary>
        public string SystemAge
        {
            get { return _age; }
            set
            {
                this._age = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Get and set for the number of stars
        /// </summary>
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
