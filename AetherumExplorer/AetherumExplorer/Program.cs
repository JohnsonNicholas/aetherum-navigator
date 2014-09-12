using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using TwilightShards.AetherumExplorerW;

namespace TwilightShards.AetherumExplorer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new AetherumExplorer());
            //Application.Run(new TwilightShards.AetherumExplorerW.MainWindow());
        }
    }
}
