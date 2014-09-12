using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TwilightShards.genLibrary;

namespace TwilightShards.AetherumExplorerW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// This is our sector.
        /// </summary>
        internal Sector OurSector { get; private set; }

        /// <summary>
        /// This is the generator used to generate the sector
        /// </summary>
        internal SectorGenerator SecGenerator { get; private set; }

        /// <summary>
        /// The dice object used for randomization.
        /// </summary>
        internal Dice OurDice { get; private set; }

        /// <summary>
        /// The program setings
        /// </summary>
        internal AetherumSettings PrgSettings { get; private set; }

        /// <summary>
        /// The display list used for the gridview
        /// </summary>
        internal List<SystemInfoView> OurSystemsDisplay { get; private set; }

        /// <summary>
        /// This function initializes the main window
        /// </summary>
        public MainWindow()
        {
            //init our objects
            this.OurSector = new Sector();
            this.OurDice = new Dice();
            this.PrgSettings = new AetherumSettings();
            this.OurSystemsDisplay = new List<SystemInfoView>();

            //load settings
            this.PrgSettings.SaveFilePath(@"settings.json");
            this.PrgSettings.LoadProperties();

            //do calculations
            this.SecGenerator = new SectorGenerator(OurDice, PrgSettings);
            this.SecGenerator.InitateSector(OurSector);            
            InitializeComponent();
            populateInfoView();

            //data binding
            this.DataContext = OurSector;
            lvSystemDisplay.ItemsSource = OurSystemsDisplay;
        }

        /// <summary>
        /// This function displays systems. Since it's all bound, it updates itself.
        /// </summary>
        private void populateInfoView() 
        {
            double lightYearRes = PrgSettings.GetLightYearResolution();
            foreach (StellarSystem sys in OurSector.SectorSystems) 
            {
                sys.CreateInfoView(lightYearRes);
                this.OurSystemsDisplay.Add(sys.InfoView);
            }
        }

        /// <summary>
        /// Turn the application off.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event arguments</param>
        private void FileItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// This function handles what happens if you click on the datagrid.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event arguments</param>
        private void HandleGridViewClick(object sender, MouseButtonEventArgs e)
        {
            StellarSystem targetSystem = null;

            if (lvSystemDisplay.SelectedItem == null) //if somehow nothing is selected, don't do anything!
                return;

            //let's get the target system
            if (OurSector.GetSystem(((SystemInfoView)lvSystemDisplay.SelectedItem)._parentID, out targetSystem))
            {
                SystemDisplay sysDisplay = new SystemDisplay(targetSystem);
                sysDisplay.ShowDialog(); //display it!
            }
        }
    }
}
