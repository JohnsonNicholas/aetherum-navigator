namespace TwilightShards.AetherumExplorer
{
    partial class AetherumExplorer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AetherumExplorer));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvStarListing = new System.Windows.Forms.DataGridView();
            this.pnlInfoDisp = new System.Windows.Forms.Panel();
            this.lblNumStars = new System.Windows.Forms.Label();
            this.lblSectorName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ilStarChart = new ILNumerics.Drawing.ILPanel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStarListing)).BeginInit();
            this.pnlInfoDisp.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1584, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // dgvStarListing
            // 
            this.dgvStarListing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStarListing.Location = new System.Drawing.Point(837, 27);
            this.dgvStarListing.Name = "dgvStarListing";
            this.dgvStarListing.Size = new System.Drawing.Size(747, 661);
            this.dgvStarListing.TabIndex = 2;
            this.dgvStarListing.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStarListing_CellContentClick);
            this.dgvStarListing.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStarListing_CellFormatting);
            // 
            // pnlInfoDisp
            // 
            this.pnlInfoDisp.Controls.Add(this.lblNumStars);
            this.pnlInfoDisp.Controls.Add(this.lblSectorName);
            this.pnlInfoDisp.Location = new System.Drawing.Point(835, 694);
            this.pnlInfoDisp.Name = "pnlInfoDisp";
            this.pnlInfoDisp.Size = new System.Drawing.Size(748, 43);
            this.pnlInfoDisp.TabIndex = 3;
            // 
            // lblNumStars
            // 
            this.lblNumStars.AutoSize = true;
            this.lblNumStars.Location = new System.Drawing.Point(337, 0);
            this.lblNumStars.Name = "lblNumStars";
            this.lblNumStars.Size = new System.Drawing.Size(86, 13);
            this.lblNumStars.TabIndex = 1;
            this.lblNumStars.Text = "Number of Stars:";
            // 
            // lblSectorName
            // 
            this.lblSectorName.AutoSize = true;
            this.lblSectorName.Location = new System.Drawing.Point(3, 0);
            this.lblSectorName.Name = "lblSectorName";
            this.lblSectorName.Size = new System.Drawing.Size(72, 13);
            this.lblSectorName.TabIndex = 0;
            this.lblSectorName.Text = "Sector Name:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ilStarChart);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 715);
            this.panel1.TabIndex = 4;
            // 
            // ilStarChart
            // 
            this.ilStarChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ilStarChart.Driver = ILNumerics.Drawing.RendererTypes.OpenGL;
            this.ilStarChart.Editor = null;
            this.ilStarChart.Location = new System.Drawing.Point(0, 0);
            this.ilStarChart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ilStarChart.Name = "ilStarChart";
            this.ilStarChart.Rectangle = ((System.Drawing.RectangleF)(resources.GetObject("ilStarChart.Rectangle")));
            this.ilStarChart.ShowUIControls = false;
            this.ilStarChart.Size = new System.Drawing.Size(834, 715);
            this.ilStarChart.TabIndex = 0;
            // 
            // AetherumExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 740);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlInfoDisp);
            this.Controls.Add(this.dgvStarListing);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AetherumExplorer";
            this.Text = "Aetherum Explorer";
            this.Load += new System.EventHandler(this.AetherumExplorer_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStarListing)).EndInit();
            this.pnlInfoDisp.ResumeLayout(false);
            this.pnlInfoDisp.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvStarListing;
        private System.Windows.Forms.Panel pnlInfoDisp;
        private System.Windows.Forms.Label lblNumStars;
        private System.Windows.Forms.Label lblSectorName;
        private System.Windows.Forms.Panel panel1;
        private ILNumerics.Drawing.ILPanel ilStarChart;
    }
}

