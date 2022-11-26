
namespace Eraki.UTTools.UTQuickLauncher.WinForm
{
    partial class FormUTQuickLauncher
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUTQuickLauncher));
			this.lblName = new System.Windows.Forms.Label();
			this.tbName = new System.Windows.Forms.TextBox();
			this.cbAsSpectator = new System.Windows.Forms.CheckBox();
			this.btnLaunch = new System.Windows.Forms.Button();
			this.dgvFavorites = new System.Windows.Forms.DataGridView();
			this.chName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.chPlayers = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.chAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnAbout = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.cmsTray = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
			this.niTray = new System.Windows.Forms.NotifyIcon(this.components);
			this.tsmiServers = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.dgvFavorites)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.cmsTray.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.lblName.Location = new System.Drawing.Point(14, 18);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(51, 20);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "Name";
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(80, 20);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(218, 20);
			this.tbName.TabIndex = 3;
			// 
			// cbAsSpectator
			// 
			this.cbAsSpectator.AutoSize = true;
			this.cbAsSpectator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.cbAsSpectator.Location = new System.Drawing.Point(18, 46);
			this.cbAsSpectator.Name = "cbAsSpectator";
			this.cbAsSpectator.Size = new System.Drawing.Size(121, 24);
			this.cbAsSpectator.TabIndex = 4;
			this.cbAsSpectator.Text = "As Spectator";
			this.cbAsSpectator.UseVisualStyleBackColor = true;
			// 
			// btnLaunch
			// 
			this.btnLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLaunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.btnLaunch.Location = new System.Drawing.Point(335, 18);
			this.btnLaunch.Name = "btnLaunch";
			this.btnLaunch.Size = new System.Drawing.Size(111, 46);
			this.btnLaunch.TabIndex = 6;
			this.btnLaunch.Text = "Launch";
			this.btnLaunch.UseVisualStyleBackColor = true;
			this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
			// 
			// dgvFavorites
			// 
			this.dgvFavorites.AllowUserToAddRows = false;
			this.dgvFavorites.AllowUserToDeleteRows = false;
			this.dgvFavorites.AllowUserToOrderColumns = true;
			this.dgvFavorites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvFavorites.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			this.dgvFavorites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvFavorites.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chName,
            this.chPlayers,
            this.chAddress});
			this.dgvFavorites.Location = new System.Drawing.Point(12, 82);
			this.dgvFavorites.Name = "dgvFavorites";
			this.dgvFavorites.ReadOnly = true;
			this.dgvFavorites.RowHeadersVisible = false;
			this.dgvFavorites.Size = new System.Drawing.Size(758, 252);
			this.dgvFavorites.TabIndex = 7;
			this.dgvFavorites.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFavorites_CellMouseDoubleClick);
			this.dgvFavorites.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFavorites_ColumnHeaderMouseClick);
			// 
			// chName
			// 
			this.chName.DataPropertyName = "Name";
			this.chName.HeaderText = "Name";
			this.chName.Name = "chName";
			this.chName.ReadOnly = true;
			this.chName.Width = 60;
			// 
			// chPlayers
			// 
			this.chPlayers.DataPropertyName = "Players";
			this.chPlayers.HeaderText = "Players";
			this.chPlayers.Name = "chPlayers";
			this.chPlayers.ReadOnly = true;
			this.chPlayers.Width = 66;
			// 
			// chAddress
			// 
			this.chAddress.DataPropertyName = "Address";
			this.chAddress.HeaderText = "Address";
			this.chAddress.Name = "chAddress";
			this.chAddress.ReadOnly = true;
			this.chAddress.Width = 70;
			// 
			// btnAbout
			// 
			this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAbout.Location = new System.Drawing.Point(504, 18);
			this.btnAbout.Name = "btnAbout";
			this.btnAbout.Size = new System.Drawing.Size(79, 46);
			this.btnAbout.TabIndex = 8;
			this.btnAbout.Text = "About";
			this.btnAbout.UseVisualStyleBackColor = true;
			this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefresh.Location = new System.Drawing.Point(691, 20);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(79, 46);
			this.btnRefresh.TabIndex = 9;
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
			this.statusStrip1.Location = new System.Drawing.Point(0, 341);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(782, 22);
			this.statusStrip1.TabIndex = 10;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tsslStatus
			// 
			this.tsslStatus.Name = "tsslStatus";
			this.tsslStatus.Size = new System.Drawing.Size(70, 17);
			this.tsslStatus.Text = "Initializing...";
			// 
			// cmsTray
			// 
			this.cmsTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiServers,
            this.tsmiOpen,
            this.tsmiExit});
			this.cmsTray.Name = "cmsTray";
			this.cmsTray.Size = new System.Drawing.Size(181, 92);
			// 
			// tsmiOpen
			// 
			this.tsmiOpen.Name = "tsmiOpen";
			this.tsmiOpen.Size = new System.Drawing.Size(180, 22);
			this.tsmiOpen.Text = "&Open";
			this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
			// 
			// tsmiExit
			// 
			this.tsmiExit.Name = "tsmiExit";
			this.tsmiExit.Size = new System.Drawing.Size(180, 22);
			this.tsmiExit.Text = "E&xit";
			this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
			// 
			// niTray
			// 
			this.niTray.ContextMenuStrip = this.cmsTray;
			this.niTray.Icon = ((System.Drawing.Icon)(resources.GetObject("niTray.Icon")));
			this.niTray.Text = "UTQL";
			this.niTray.Visible = true;
			this.niTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.niTray_MouseDoubleClick);
			// 
			// tsmiServers
			// 
			this.tsmiServers.Name = "tsmiServers";
			this.tsmiServers.Size = new System.Drawing.Size(180, 22);
			this.tsmiServers.Text = "&Servers";
			// 
			// FormUTQuickLauncher
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(782, 363);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.btnAbout);
			this.Controls.Add(this.dgvFavorites);
			this.Controls.Add(this.btnLaunch);
			this.Controls.Add(this.cbAsSpectator);
			this.Controls.Add(this.tbName);
			this.Controls.Add(this.lblName);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormUTQuickLauncher";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "UT Quick Launcher v0.1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUTQuickLauncher_FormClosing);
			this.Load += new System.EventHandler(this.FormUTQuickLauncher_Load);
			this.Resize += new System.EventHandler(this.FormUTQuickLauncher_Resize);
			((System.ComponentModel.ISupportInitialize)(this.dgvFavorites)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.cmsTray.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.CheckBox cbAsSpectator;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.DataGridView dgvFavorites;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
		private System.Windows.Forms.DataGridViewTextBoxColumn chName;
		private System.Windows.Forms.DataGridViewTextBoxColumn chPlayers;
		private System.Windows.Forms.DataGridViewTextBoxColumn chAddress;
		private System.Windows.Forms.ContextMenuStrip cmsTray;
		private System.Windows.Forms.ToolStripMenuItem tsmiExit;
		private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
		private System.Windows.Forms.NotifyIcon niTray;
		private System.Windows.Forms.ToolStripMenuItem tsmiServers;
	}
}

