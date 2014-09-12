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
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace TwilightShards.AetherumExplorerW
{
    /// <summary>
    /// Interaction logic for SystemDisplay.xaml
    /// </summary>
    public partial class SystemDisplay : Window
    {
        /// <summary>
        /// This is the system the form uses for all display.
        /// </summary>
        private StellarSystem ourSystem;
        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="s">The system to display</param>
        public SystemDisplay(StellarSystem s)        
        {
            this.ourSystem = s;
            InitializeComponent();
            this.DataContext = this.ourSystem;
        }

        /// <summary>
        /// This closes the form.
        /// </summary>
        /// <param name="sender">Object that sent this event</param>
        /// <param name="e">Event arguments</param>
        private void CloseForm(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
