using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace TwilightShards.AetherumExplorerW
{
    /// <summary>
    /// This object tracks and calculates information for a Stellar Sector.
    /// </summary>
    internal class Sector : INotifyPropertyChanged
    {
        /// <summary>
        /// The sector name.
        /// </summary>
        private string _sectorName;

        /// <summary>
        /// The starfield data.
        /// </summary>
        private List<Point3D> _starfieldData;

        /// <summary>
        /// The systems in this sector
        /// </summary>
        private List<StellarSystem> _sectorSystems;

        /// <summary>
        /// Number of systems.
        /// </summary>
        private int _numberOfSystems;

        /// <summary>
        /// This is the name of the Sector
        /// </summary>
        public string SectorName {
            get { return _sectorName; }
            set {
                if (value != this._sectorName)
                {
                    this._sectorName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// This gets the number of systems
        /// </summary>
        public int NumberOfSystems
        {
            get
            {
                NotifyPropertyChanged();
                return this._starfieldData.Count();
            }
        }

        /// <summary>
        /// This contains all of the systems in the sector.
        /// </summary>
        public List<StellarSystem> SectorSystems {
            get { return this._sectorSystems; }
            set
            {
                if (value != this._sectorSystems)
                {
                    this._sectorSystems = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// This contains the starfield data.
        /// </summary>
        public List<Point3D> StarfieldData
        {
            get { return _starfieldData; }
            set
            {
                if (value != this._starfieldData)
                {
                    this._starfieldData = value;
                    NotifyPropertyChanged();
                }
            }
        }


        
        /// <summary>
        /// This is from INotifyPropertyChanged. Notifies if something is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This function impleemts RaisePropertyChanged. Used to notify INotifyPropertChanged
        /// </summary>
        /// <remarks>This abuses reflection to do so, though. </remarks>
        /// <param name="propertyName">The property being changed</param>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null) 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// This creates the light for the Starfield display.
        /// </summary>
        public Model3DGroup StarfieldLights 
        {
            get
            {
                var group = new Model3DGroup();
                group.Children.Add(new AmbientLight(Colors.White));
                return group;
            }
        }

        /// <summary>
        /// This creates the brush for the Starfield display.
        /// </summary>
        public Brush SurfaceBrush
        {
            get { return Brushes.White; }
        }

        /// <summary>
        /// This creates the sector
        /// </summary>
        public Sector()
        {
            this.StarfieldData = new List<Point3D>();
            this.SectorSystems = new List<StellarSystem>();
            UpdateModel();
        } 

        /// <summary>
        /// This tells the bindings that the model has been updated
        /// </summary>
        private void UpdateModel()
        {
            NotifyPropertyChanged("StarfieldData");
            NotifyPropertyChanged("SurfaceBrush");
        }

        /// <summary>
        /// This gets a system by matching GUIDs
        /// </summary>
        /// <param name="g">The GUID of the system</param>
        /// <param name="sys">The system to be returned</param>
        /// <returns>True if it can retrieve it, false if it cannot.</returns>
        public bool GetSystem(Guid g, out StellarSystem sys)
        {
            foreach (StellarSystem s in this.SectorSystems) {
                if (s.SystemID == g) {
                    sys = s;
                    return true;
                }
            }
            sys = null;
            return false;
        }

        /// <summary>
        /// This updates the number of systems
        /// </summary>
        public void UpdateNumberOfSystems(){
            this._numberOfSystems = this.StarfieldData.Count();
            NotifyPropertyChanged("NumberOfSystems");
        }

        /// <summary>
        /// This updates the system in the list by GUID
        /// </summary>
        /// <param name="g">The GUID of the system</param>
        /// <returns>True if set, false if not</returns>
        public bool SetSystem(StellarSystem g)
        {
            for (int i = 0; i < this.SectorSystems.Count; i++)
                if (this.SectorSystems[i].SystemID == g.SystemID)
                {
                    this.SectorSystems[i] = g;
                    return true;
                }

            return false;
        }

        /// <summary>
        /// This resets the sector
        /// </summary>
        public void Reset()
        {
            this.SectorName = "";
            this._starfieldData.Clear();
            this._sectorSystems.Clear();
        }
   }
}
