using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Media3D;
using TwilightShards.genLibrary;

namespace TwilightShards.AetherumExplorerW
{
    /// <summary>
    /// This object contains all of the system members - planets, stellar objects.
    /// </summary>
    public class StellarSystem : INotifyPropertyChanged
    {
        //************************* PROPERTIES
        private Guid _systemID;
        private Point3D _location;
        private string _sysName;
        private string _catName;
        private double _sysAge;
        private double _lightFactor;

        //************************* MEMBERS
        /// <summary>
        /// The ID of the System.
        /// </summary>
        public Guid SystemID {
            get { return _systemID; }

            set
            {
                if (value != this._systemID) 
                {
                    _systemID = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Location of the system
        /// </summary>
        public Point3D location {
            get { return _location; }

            set
            {
                if (value != this._location) 
                {
                    _location = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// System name.
        /// </summary>
        public string SystemName {
            get { return _sysName; }
            set
            {
                if (value != this._sysName)
                {
                    _sysName = value;
                    this.NotifyPropertyChanged();
                }

            }
        
        }

        /// <summary>
        /// The catalog name of the system
        /// </summary>
        public string CatalogName {
            get { return _catName; }
            set
            {
                if (value != this._catName)
                {
                    this._catName = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// The age of the system
        /// </summary>
        public double SystemAge {
            get { return this._sysAge; }
            set
            {
                if (value != this._sysAge)
                {
                    this._sysAge = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// The light year resolution. Stored for later use.
        /// </summary>
        public double lightYFactor {
            get { return this._lightFactor;  }
            set
            {
                if (value != this._lightFactor)
                {
                    this._lightFactor = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// The SystemInfoView object.
        /// </summary>
        internal SystemInfoView InfoView { get; set; }

        /// <summary>
        /// Event that tracks if the property has changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This function raises if the property has been changed. Code from StackOverflow
        /// </summary>
        /// <param name="propertyName">The propertyName being changed. Uses reflection to get the name</param>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null) 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            if (InfoView != null) 
                updateInfoView();            
        }

        //******************** CONSTRUCTORS
        /// <summary>
        /// Base constructor.
        /// </summary>
        public StellarSystem()
        {
            this.location = new Point3D();
            this.SystemID = Guid.NewGuid();
        }

        /// <summary>
        /// Constructor, given an ordinal coordinate for the system
        /// </summary>
        /// <param name="p"></param>
        public StellarSystem(Point3D P)
        {
            this.location = new Point3D(P.X, P.Y, P.Z);
            this.SystemID = Guid.NewGuid();
        }

        /// <summary>
        /// Normal constructor
        /// </summary>
        /// <param name="P">Point for the star system</param>
        /// <param name="name">The catalog name</param>
        /// <param name="sysAge">The system age</param>
        public StellarSystem(Point3D P, string name, double sysAge)
        {
            this.location = new Point3D(P.X, P.Y, P.Z);
            this.SystemName = "";
            this.CatalogName = name;
            this.SystemAge = sysAge;
            this.SystemID = Guid.NewGuid();
        }

        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="P">Point for the star system</param>
        /// <param name="sysName">System name</param>
        /// <param name="name">The catalog name</param>
        /// <param name="sysAge">The system age</param>
        public StellarSystem(Point3D P, string name, string sysName, double sysAge)
        {
            this.location = new Point3D(P.X, P.Y, P.Z);
            this.SystemName = sysName;
            this.CatalogName = name;
            this.SystemAge = sysAge;
            this.SystemID = Guid.NewGuid();
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="s">Object being copied</param>
        public StellarSystem(StellarSystem s)
        {
            //copy basic details
            this.location = new Point3D(s.location.X, s.location.Y, s.location.Z);
            this.SystemName = s.SystemName;
            this.CatalogName = s.CatalogName;
            this.SystemAge = s.SystemAge;
            this.SystemID = s.SystemID;
        }

        /// <summary>
        /// This function returns a formatted location. Helper function
        /// </summary>
        /// <returns>Formatted Point3D location</returns>
        private string FormatLocation() 
        {
            return String.Format("{0:00.00} , {1:00.00} , {2:00.00}", (double)(this.location.X / this.lightYFactor),
                  (double)(this.location.Y / this.lightYFactor), (double)(this.location.Z / this.lightYFactor));
        }

        /// <summary>
        /// This creates the info view used to display information to forms.
        /// </summary>
        /// <param name="lightYearRes">The setting for light year resolution</param>
        public void CreateInfoView(double lightYearRes)
        {
            this.lightYFactor = lightYearRes;
            this.InfoView = new SystemInfoView(this.CatalogName,
                                               this.SystemName,
                                               String.Format("{0:00.00} , {1:00.00} , {2:00.00}",
                                                                    (double)(this.location.X / this.lightYFactor),
                                                                    (double)(this.location.Y / this.lightYFactor),
                                                                    (double)(this.location.Z / this.lightYFactor)),
                                               "[TODO]",
                                               Utility.FormatForAstronomicalYear(this.SystemAge),
                                               this.SystemStarCount(), //star count goes here
                                               this.SystemPlanetCount(), //planet count goes here
                                               this.CheckForHabitablePlanets(), //hability check goes here
                                               this.SystemID
                                               );
        }

        /// <summary>
        /// Returns the number of planets in the system
        /// </summary>
        /// <returns>Int describing the number of planets</returns>
        public int SystemPlanetCount()
        {
            return 0;
        }

        /// <summary>
        /// Returns the number of stars in the system
        /// </summary>
        /// <returns>Int describing the number of stars</returns>
        public int SystemStarCount()
        {
            return 0;
        }

        /// <summary>
        /// Returns if this system has any habitable planets
        /// </summary>
        /// <returns>True if one or more planets is habitable</returns>
        public bool CheckForHabitablePlanets() 
        {
            return false;
        }

        /// <summary>
        /// This updates the location info view.
        /// </summary>
        private void updateInfoView() {
            if (this.InfoView == null) //sanity check
                return;

            this.InfoView.Location = this.FormatLocation();
            this.InfoView.SystemCatalog = this.CatalogName;
            this.InfoView.SystemName = this.SystemName;
            this.InfoView.SystemAge = Utility.FormatForAstronomicalYear(this.SystemAge);
            this.InfoView.numOfPlanets = this.SystemPlanetCount();
            this.InfoView.stars = this.SystemStarCount();
            this.InfoView.hasHabitablePlanets = this.CheckForHabitablePlanets(); 
        }

        /// <summary>
        /// Sets the system name
        /// </summary>
        /// <param name="name"></param>
        public void SetName(string name)
        {
            this.SystemName = name;
        }
    }
}