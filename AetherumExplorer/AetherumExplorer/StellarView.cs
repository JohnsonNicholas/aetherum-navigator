using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TwilightShards.genLibrary;
using AetherExp = TwilightShards.AetherumExplorer.AetherumExplorer;

namespace TwilightShards.AetherumExplorer
{
    public partial class StellarView : Form
    {
        /// <summary>
        /// This function is called to update display information
        /// </summary>
        private AetherExp.updateInfoDisplay updater;

        /// <summary>
        /// The system we are working on.
        /// </summary>
        protected StellarSystem system;

        /// <summary>
        /// This stores the formatted planet data.
        /// </summary>
        private BindingList<PlanetView> planetInfo;

        public StellarView()
        {
            InitializeComponent();

            this.planetInfo = new BindingList<PlanetView>(); 

            //control properties:
            dgvPlanetaryInfo.AllowUserToAddRows = false;
            dgvPlanetaryInfo.AllowUserToDeleteRows = false;
        }


        /// <summary>
        /// This populates the screen with the details from the system
        /// </summary>
        /// <param name="s">The stellar system</param>
        /// <param name="prSettings">The program settings</param>
        /// <param name="update">The function we call to update info</param>
        public void popDetails(StellarSystem s, AetherumSettings prSettings, AetherExp.updateInfoDisplay update)
        {
            this.updater = update;
            this.system = s;

            //propagate the info
            txtStellar.Text = system.name;
            txtCatalog.Text = system.catName;
            double lyR = prSettings.getLightYearResolution();
            txtLocation.Text = String.Format("{0:f1}, {1:f1}, {2:f1})", (system.location.getCoordX() / lyR), (system.location.getCoordY() / lyR), (system.location.getCoordZ() / lyR));
            //txtLocation.Text = system.location.descString(prSettings.getLightYearResolution());

            if (s.ourStars.Count > 1)
            {
                lblDist.Text = "Distance of stars from primary: ";
                double[] distances = s.getDistArray();

                
                for (int i = 1; i < distances.Length; i++)
                {
                    lblDist.Text = lblDist.Text + "(" + (i + 1) + ") " + distances[i] + " AU ";
                }
                
            }
            else
                lblDist.Visible = false;

            //Hide controls we don't need to see.
            if (s.ourStars.Count < 4)
                pnlObjectD.Visible = false;
            
            if (s.ourStars.Count < 3)
            {
                pnlObjectC.Visible = false;
                lblObj3Age.Visible = false;
                lblObj3Bright.Visible = false;
                lblObj3Mass.Visible = false;
                lblObj3Name.Visible = false;
                lblObj3Type.Visible = false;
                lblObj3FlareStar.Visible = false;
            }
            
            if (s.ourStars.Count < 2)
            {
                pnlObjectB.Visible = false;
                lblObj2Age.Visible = false;
                lblObj2Bright.Visible = false;
                lblObj2Mass.Visible = false;
                lblObj2Name.Visible = false;
                lblObj2Type.Visible = false;
                lblObj2FlareStar.Visible = false;
            }

            //go through the solar objects.
            for (int i = 0; i < s.ourStars.Count; i++)
            {
                StellarObject ourStar = s.ourStars[i].getStellarObject();
                PictureBox picObj = null;

                //set image
                if (i == 0) picObj = picObjA;
                else if (i == 1) picObj = picObjB;
                else if (i == 2) picObj = picObjC;
                else picObj = picObjD;

                if (ourStar.stellarType == SOOpCode.Anomaly)
                    picObj.Image = TwilightShards.AetherumExplorer.Properties.Resources.anamoly;
                else if (ourStar.stellarType == SOOpCode.NebulaPlanetaryDense)
                    picObj.Image = TwilightShards.AetherumExplorer.Properties.Resources.planetaryNebula;
                else if (ourStar.stellarType == SOOpCode.StarG0V || ourStar.stellarType == SOOpCode.StarG5V)
                    picObj.Image = TwilightShards.AetherumExplorer.Properties.Resources.typeGstar;
                else if (ourStar.stellarType == SOOpCode.StarA5V || ourStar.stellarType == SOOpCode.StarA0V)
                    picObj.Image = TwilightShards.AetherumExplorer.Properties.Resources.typeAstar;
                else if (ourStar.stellarType == SOOpCode.StarK5V || ourStar.stellarType == SOOpCode.StarK0V)
                    picObj.Image = TwilightShards.AetherumExplorer.Properties.Resources.typeKstar;
                else if (ourStar.stellarType == SOOpCode.StarM5V || ourStar.stellarType == SOOpCode.StarM0V)
                    picObj.Image = TwilightShards.AetherumExplorer.Properties.Resources.typeMstar;
                else if (ourStar.stellarType == SOOpCode.StarF5V || ourStar.stellarType == SOOpCode.StarF0V)
                    picObj.Image = TwilightShards.AetherumExplorer.Properties.Resources.typeFstar;
                else if (ourStar.stellarType == SOOpCode.ProtoStar)
                    picObj.Image = TwilightShards.AetherumExplorer.Properties.Resources.protostar;
                else if (ourStar.stellarType == SOOpCode.Pulsar)
                    picObj.Image = TwilightShards.AetherumExplorer.Properties.Resources.neutronStar;
                else if (ourStar.stellarType == SOOpCode.BlackHole)
                    picObj.Image = TwilightShards.AetherumExplorer.Properties.Resources.blackhole;
                else if (ourStar.stellarType == SOOpCode.NebulaPlanetaryDense)
                    picObj.Image = TwilightShards.AetherumExplorer.Properties.Resources.planetaryNebula;
                else if (ourStar.stellarType == SOOpCode.NebulaInterstellar)
                    picObj.Image = TwilightShards.AetherumExplorer.Properties.Resources.intestellarNebula;
                else if (ourStar.stellarType == SOOpCode.StarRedGiant)
                    picObj.Image = TwilightShards.AetherumExplorer.Properties.Resources.redgiant;
                else if (ourStar.stellarType == SOOpCode.WhiteDwarf)
                    picObj.Image = TwilightShards.AetherumExplorer.Properties.Resources.whiteDwarf;
                else if (ourStar.stellarType == SOOpCode.TypeOGiant || ourStar.stellarType == SOOpCode.TypeBGiant || ourStar.stellarType == SOOpCode.TypeAGiant)
                    picObj.Image = TwilightShards.AetherumExplorer.Properties.Resources.Blue_Giant;

                //image set. Now let's display info. For now, we're just going to be displaying info.
                if (i == 0)
                {
                    lblObj1Age.Text = "Age: " + AetherumExplorer.formatAge(ourStar.age);
                    lblObj1Bright.Text = "Brightness: " + ourStar.brightness + " solar brightness";
                    lblObj1Mass.Text = "Mass: " + ourStar.stellarMass + " solar masses";
                    lblObj1Name.Text = "Object Name: " + ourStar.stellarName;
                    lblObj1Type.Text = "Object Type: " + ourStar.stellarType;
                    if (ourStar.isFlareStar)
                        lblObjAFlareStar.Text = "Flare Star: Yes";
                    else
                        lblObjAFlareStar.Visible = false;
                }

                if (i == 1)
                {
                    lblObj2Age.Text = "Age: " + AetherumExplorer.formatAge(ourStar.age);
                    lblObj2Bright.Text = "Brightness: " + ourStar.brightness + " solar brightness";
                    lblObj2Mass.Text = "Mass: " + ourStar.stellarMass + " solar masses";
                    lblObj2Name.Text = "Object Name: " + ourStar.stellarName;
                    lblObj2Type.Text = "Object Type: " + ourStar.stellarType;
                    if (ourStar.isFlareStar)
                        lblObj2FlareStar.Text = "Flare Star: Yes";
                    else
                        lblObj2FlareStar.Visible = false;
                }

                if (i == 2)
                {
                    lblObj3Age.Text = "Age: " + AetherumExplorer.formatAge(ourStar.age);
                    lblObj3Bright.Text = "Brightness: " + ourStar.brightness + " solar brightness";
                    lblObj3Mass.Text = "Mass: " + ourStar.stellarMass + " solar masses";
                    lblObj3Name.Text = "Object Name: " + ourStar.stellarName;
                    lblObj3Type.Text = "Object Type: " + ourStar.stellarType;
                    if (ourStar.isFlareStar)
                        lblObj3FlareStar.Text = "Flare Star: Yes";
                    else
                        lblObj3FlareStar.Visible = false;
                }

                if (i == 3)
                {
                    lblObj4Age.Text = "Age: " + AetherumExplorer.formatAge(ourStar.age);
                    lblObj4Bright.Text = "Brightness: " + ourStar.brightness + " solar brightness";
                    lblObj4Mass.Text = "Mass: " + ourStar.stellarMass + " solar masses";
                    lblObj4Name.Text = "Object Name: " + ourStar.stellarName;
                    lblObj4Type.Text = "Object Type: " + ourStar.stellarType;
                    if (ourStar.isFlareStar)
                        lblObj4FlareStar.Text = "Flare Star: Yes";
                    else
                        lblObj4FlareStar.Visible = false;
                }
            }
            populatePlanetaryInfo(system);

            this.ShowDialog();
        }

        private void populatePlanetaryInfo(StellarSystem s)
        {
            foreach (Planet p in s.ourPlanets)
            {
                string parName = p.parentPtr.stellarName + " (" + starLayout.renderOrder(s.returnStarOrder(p.parentPtr)) + ")";
                planetInfo.Add(new PlanetView(p.parentPtr.stellarName, p.planetName, p.orbitalRadius, p.locCode));
            }
            dgvPlanetaryInfo.AutoGenerateColumns = false; // do not auto generate.

            //specify columns
            var parNameColumn = new DataGridViewTextBoxColumn();
            var plaNameColumn = new DataGridViewTextBoxColumn();
            var orbRadiColumn = new DataGridViewTextBoxColumn();
            var locCodeColumn = new DataGridViewTextBoxColumn();

            parNameColumn.HeaderText = "Parent Star";
            plaNameColumn.HeaderText = "Planet Name";
            orbRadiColumn.HeaderText = "Orbital Radius";
            locCodeColumn.HeaderText = "Orbital Zone";

            parNameColumn.DataPropertyName = "stellarName";
            plaNameColumn.DataPropertyName = "planetName";
            orbRadiColumn.DataPropertyName = "orbitalDistance";
            locCodeColumn.DataPropertyName = "planetZone";

            parNameColumn.Width = 250;
            parNameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            plaNameColumn.Width = 250;
            plaNameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvPlanetaryInfo.Columns.Add(parNameColumn);
            dgvPlanetaryInfo.Columns.Add(plaNameColumn);
            dgvPlanetaryInfo.Columns.Add(orbRadiColumn);
            dgvPlanetaryInfo.Columns.Add(locCodeColumn);

            dgvPlanetaryInfo.DataSource = planetInfo;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (genHelper.validateTextInput(20, txtStellar.Text))
                system.setName(txtStellar.Text);

            //update the info display, which will also update the underlying object.
            updater(system);

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlSysDrawing_Paint(object sender, PaintEventArgs e)
        {
            if (this.system != null)
                drawSystem();
        }

        /// <summary>
        /// This draws the system on the screen.
        /// </summary>
        private void drawSystem()
        {
            int centY = (int)Math.Floor(pnlSysDrawing.Height / 2.0);
            int centX = (int)Math.Floor(pnlSysDrawing.Width / 2.0);
            Graphics ourSpace = pnlSysDrawing.CreateGraphics();
            Pen brush = new Pen(new SolidBrush(Color.LightBlue));
            
            //let's get the maximum spacing
            if (system.getNumStars() > 1)
            {
                double dist = system.getFurthestDistance();
                double scale = (pnlSysDrawing.Width - 200) / dist;
       
                for (int i = 0; i < system.ourStars.Count; i++)
                {
                    if (!(StellarReference.isAnExoticObject(system.ourStars[i].getStellarType())))
                    {
                        int pos = 0;
                        if (!(Double.IsInfinity(scale)))
                           pos = (int)Math.Round(system.getPos(i) * scale);
                        ourSpace.DrawEllipse(brush, pos, centY, 30, 30);
                    }
                }
            }
            else
            {
                ourSpace.DrawEllipse(brush, centX, centY, 30, 30);
            }
        }
    }
}
