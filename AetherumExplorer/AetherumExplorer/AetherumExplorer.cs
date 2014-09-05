using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using ILNumerics;
using ILNumerics.Drawing.Plotting;
using ILNumerics.Drawing;

using TwilightShards.genLibrary;

namespace TwilightShards.AetherumExplorer
{
    public partial class AetherumExplorer : Form
    {
        /// <summary>
        /// This contains the program setings.
        /// </summary>
        internal AetherumSettings prgSettings;

        /// <summary>
        /// This contains the sector. This is the container for the data
        /// </summary>
        internal Sector ourSector;

        /// <summary>
        /// This contains our Dice object.
        /// </summary>
        private Dice ourDice;
        private BindingList<SystemView> ourSystems;
        private SectorGenerator ourGenerator; 

        public delegate void updateInfoDisplay(StellarSystem s);

        /// <summary>
        /// Constructor for the main form.
        /// </summary>
        public AetherumExplorer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This function handles establishing needed objects for the program
        /// </summary>
        /// <param name="sender">object starting this (not needed)</param>
        /// <param name="e">Event arguments (not needed)</param>
        private void AetherumExplorer_Load(object sender, EventArgs e)
        {
            //initalize the settings and the container
            this.prgSettings = new AetherumSettings();
            this.ourDice = new Dice();
            this.ourSystems = new BindingList<SystemView>();
            this.ourGenerator = new SectorGenerator(this.ourDice, this.prgSettings);

            //load our settings up from the file
            this.prgSettings.SaveFilePath(@"settings.json");
            this.prgSettings.LoadProperties();

            //some work on drawing controls
            dgvStarListing.AllowUserToAddRows = false;
            dgvStarListing.AllowUserToDeleteRows = false;

            createSector();
        }

        /// <summary>
        /// This function refreshes the information display of the sector
        /// </summary>
        /// <param name="s">The sector we are in</param>
        public void refreshDataInfo(Sector s)
        {
            lblNumStars.Text = "Number of Stars: " + s.ourSystem.Count().ToString();
            lblSectorName.Text ="Sector Name: " + s.sectName;
        }

        /// <summary>
        /// This function generates a sector and displays information
        /// </summary>
        public void createSector()
        {
            //second, populate the sector name and give it the points
            this.ourSector = new Sector();
            ourGenerator.initateSector(this.ourSector);
            ourGenerator.createStarSystems(this.ourSector);
            /*
            foreach (StellarSystem ourSys in this.ourSector.ourSystem)
            {
                ourGenerator.createOrbits(ourSys);
            }*/

            populateTable();
            
            DrawMap(this.prgSettings.gridTypeIs3D(), ourSector.getStarPlot(prgSettings.gridTypeIs3D())); 
        
        }

        /// <summary>
        /// This function updates the listing when passed a stellar system that has changed
        /// </summary>
        /// <param name="s"></param>
        public void refreshInfo(StellarSystem s)
        {
            foreach (SystemView sv in ourSystems)
            {
                if (sv.catalog == s.catName)
                {
                    sv.name = s.name;
                    sv.sectorCoords = s.location.ToString(); //.sumString();
                    sv.stellarDetails = "[Pending]"; // s.getDescStars();
                    sv.numOfPlanets = s.getNumPlanets();
                    sv.hasHabitablePlanets = s.isHabitable();
                }
            }
        }

        private void populateTable()
        {
            refreshDataInfo(this.ourSector);

            //dgvStarListing.
            /*
            foreach (StellarSystem sys in this.ourSector.ourSystem)
            {
                ourSystems.Add(new SystemView(sys.catName,sys.name, sys.location.descString(prgSettings.getLightYearResolution()), sys.getShortDesc(), sys.getAge(), sys.getNumPlanets(), sys.getNumStars(), sys.isHabitable()));
            }*/

            //at the end, bind the data list to the systems
            dgvStarListing.AutoGenerateColumns = false;

            //setup our columns
            var catalogColumn = new DataGridViewTextBoxColumn();
            catalogColumn.DataPropertyName = "catalog";
            catalogColumn.Name = "Catalog Name";

            var nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "name";
            nameColumn.HeaderText = "System Name";

            var locColumn = new DataGridViewTextBoxColumn();
            locColumn.DataPropertyName = "sectorCoords";
            locColumn.HeaderText = "Location";

            var steColumn = new DataGridViewTextBoxColumn();
            steColumn.DataPropertyName = "stellarDetails";
            steColumn.HeaderText = "Details of Stars in System";
            steColumn.Width = 250;
            steColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            var numColumn = new DataGridViewTextBoxColumn();
            numColumn.DataPropertyName = "numOfPlanets";
            numColumn.HeaderText = "Number of Planets";
            numColumn.Width = 100;
            numColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            var starColumn = new DataGridViewTextBoxColumn();
            starColumn.DataPropertyName = "stars";
            starColumn.HeaderText = "Number of Stellar Objects";
            starColumn.Width = 100;
            starColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            var habColumn = new DataGridViewTextBoxColumn();
            habColumn.DataPropertyName = "hasHabitablePlanets";
            habColumn.HeaderText = "Habitable?";

            var ageColumn = new DataGridViewTextBoxColumn();
            ageColumn.DataPropertyName = "starAge";
            ageColumn.HeaderText = "Max Stellar Age";

            //and add them to the listing
            dgvStarListing.Columns.Add(catalogColumn);
            dgvStarListing.Columns.Add(nameColumn);
            dgvStarListing.Columns.Add(locColumn);
            dgvStarListing.Columns.Add(steColumn);
            dgvStarListing.Columns.Add(numColumn);
            dgvStarListing.Columns.Add(starColumn);
            dgvStarListing.Columns.Add(ageColumn);
            dgvStarListing.Columns.Add(habColumn);

            //load the data grid view
            dgvStarListing.DataSource = ourSystems;
        }

        /// <summary>
        /// This function draws the map. It draws if it's 2D or 3D 
        /// </summary>
        public void DrawMap(bool is3D, float[,] ourPoints)
        {
            ILArray<float> ourPositions = ourPoints;

            ILScene scene = new ILScene();
            //Create our scene!
            if (is3D)
            {
                scene.Add(new ILPlotCube(twoDMode: false) {
                        new ILPoints {
                            Positions = ourPositions,
                            Size = 5,
                            Color = Color.White
                        }});
            }
            else
            {
                scene.Add(new ILPlotCube(twoDMode: false) {
                    new ILPlotCube(twoDMode: true) {
                        new ILPoints {
                            Positions = ourPositions,
                            Size = 5,
                            Color = Color.White
                        }
                    }
                });
            }

            //configure the plot cube appearence
            scene.First<ILPlotCube>().FieldOfView = 120;
            scene.First<ILPlotCube>().LookAt = new Vector3(0, 0, 0);
            scene.First<ILPlotCube>().ScaleModes.XAxisScale = AxisScale.Linear;
            scene.First<ILPlotCube>().ScaleModes.YAxisScale = AxisScale.Linear;
            scene.First<ILPlotCube>().ScaleModes.ZAxisScale = AxisScale.Linear;

            //set label colors. This is all over the place.
            var xLabel = scene.First<ILPlotCube>().Axes.XAxis.Ticks.DefaultLabel;
            xLabel.Color = Color.White;

            var yLabel = scene.First<ILPlotCube>().Axes.YAxis.Ticks.DefaultLabel;
            yLabel.Color = Color.White;

            var zLabel = scene.First<ILPlotCube>().Axes.ZAxis.Ticks.DefaultLabel;
            zLabel.Color = Color.White;

            scene.First<ILPlotCube>().Axes.XAxis.Label.Color = Color.White;
            scene.First<ILPlotCube>().Axes.YAxis.Label.Color = Color.White;
            scene.First<ILPlotCube>().Axes.ZAxis.Label.Color = Color.White;

            //designed to create a starfield look.
            ilStarChart.Scene = scene;

            ilStarChart.BackColor = Color.Black;
            ilStarChart.ForeColor = Color.White;
            ilStarChart.Scene.Configure();

        }

        /// <summary>
        /// Helper function to format the age.
        /// </summary>
        /// <param name="age">Age</param>
        /// <returns>formatted age</returns>
        public static string formatAge(double age)
        {
            if (age < genHelper.MILLION)
                return String.Format("{0:N0}", age);
            else if (age >= genHelper.MILLION && age < genHelper.BILLION)
                return Math.Round(age / genHelper.MILLION, 2) + " MYr";
            else if (age >= genHelper.BILLION)
                return Math.Round(age / genHelper.BILLION, 2) + " GYr";

            return "?!?!?!?!?";
        }

        //handles clean up tasks
        private void ApplicationExitHandler(Object sender, EventArgs e)
        {
            if (this.prgSettings.isSettingsModified)
            {
                DialogResult result = MessageBox.Show("The settings file has not been saved since last modification. Do you want to save?", "Do you want to save", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    this.prgSettings.SaveProperties();
                }
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvStarListing_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn column = dgvStarListing.Columns[e.ColumnIndex];
            switch (column.DataPropertyName)
            {
                case "starAge":
                    double y = (double)((double?)e.Value ?? 0);
                    e.Value = AetherumExplorer.formatAge(y);
                    break;
            }
        }

        private void dgvStarListing_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStarListing.CurrentCell != null && dgvStarListing.CurrentCell.Value != null)
            {
                StellarView ourSystem = new StellarView();
                string catName = dgvStarListing.CurrentRow.Cells[0].Value.ToString();
                StellarSystem target = ourSector.getStellarSystem(catName);
                updateInfoDisplay update = this.refreshInfo;

                ourSystem.popDetails(target, prgSettings, update);

            }
        }
    }
}
