namespace TwilightShards.genLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    /// <summary>
    /// This class provides a DebugConsole window.
    /// </summary>
    public partial class DebugConsole : Form
    {
        /// <summary>
        /// A constructor
        /// </summary>
        public DebugConsole()
        {
            InitializeComponent();
        }

        private void DebugConsole_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This function reloads the data on our console from a string
        /// </summary>
        /// <param name="s">The string</param>
        public void reLoadConsole(string s)
        {
            txtDebug.Text = s;
            this.Show();
        }

        /// <summary>
        /// This function reloads the data on our console from a StringBuilder
        /// </summary>
        /// <param name="s"></param>
        public void reLoadConsole(StringBuilder s)
        {
            txtDebug.Text = s.ToString();
            this.Show();
        }

        /// <summary>
        /// Clear the console
        /// </summary>
        public void clearConsole()
        {
            txtDebug.Text = "";
        }
    }
}
