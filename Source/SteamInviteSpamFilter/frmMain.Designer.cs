namespace SteamInviteSpamFilter
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lnkSignIn = new System.Windows.Forms.LinkLabel();
            this.lblCookieStatus = new System.Windows.Forms.Label();
            this.tmrCheckCookieData = new System.Windows.Forms.Timer(this.components);
            this.tmrCheckInvites = new System.Windows.Forms.Timer(this.components);
            this.radIgnoreLevel = new System.Windows.Forms.RadioButton();
            this.radIgnoreAll = new System.Windows.Forms.RadioButton();
            this.numLevel = new System.Windows.Forms.NumericUpDown();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.ssFooter = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsInviteBlockedCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startMinimizedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.picCookieStatus = new System.Windows.Forms.PictureBox();
            this.chkBlock = new System.Windows.Forms.CheckBox();
            this.lnkResetCookies = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numLevel)).BeginInit();
            this.ssFooter.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCookieStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // lnkSignIn
            // 
            this.lnkSignIn.AutoSize = true;
            this.lnkSignIn.Location = new System.Drawing.Point(278, 33);
            this.lnkSignIn.Name = "lnkSignIn";
            this.lnkSignIn.Size = new System.Drawing.Size(45, 13);
            this.lnkSignIn.TabIndex = 8;
            this.lnkSignIn.TabStop = true;
            this.lnkSignIn.Text = "(Sign in)";
            this.lnkSignIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSignIn_LinkClicked);
            // 
            // lblCookieStatus
            // 
            this.lblCookieStatus.AutoSize = true;
            this.lblCookieStatus.Location = new System.Drawing.Point(30, 34);
            this.lblCookieStatus.Name = "lblCookieStatus";
            this.lblCookieStatus.Size = new System.Drawing.Size(248, 13);
            this.lblCookieStatus.TabIndex = 6;
            this.lblCookieStatus.Text = "Steam Invite Spam Filter is not connected to Steam";
            // 
            // tmrCheckCookieData
            // 
            this.tmrCheckCookieData.Enabled = true;
            this.tmrCheckCookieData.Tick += new System.EventHandler(this.tmrCheckCookieData_Tick);
            // 
            // tmrCheckInvites
            // 
            this.tmrCheckInvites.Enabled = true;
            this.tmrCheckInvites.Tick += new System.EventHandler(this.tmrCheckInvites_Tick);
            // 
            // radIgnoreLevel
            // 
            this.radIgnoreLevel.AutoSize = true;
            this.radIgnoreLevel.Checked = true;
            this.radIgnoreLevel.Location = new System.Drawing.Point(15, 88);
            this.radIgnoreLevel.Name = "radIgnoreLevel";
            this.radIgnoreLevel.Size = new System.Drawing.Size(240, 17);
            this.radIgnoreLevel.TabIndex = 10;
            this.radIgnoreLevel.TabStop = true;
            this.radIgnoreLevel.Text = "Ignore invites from users at or lower than level";
            this.radIgnoreLevel.UseVisualStyleBackColor = true;
            // 
            // radIgnoreAll
            // 
            this.radIgnoreAll.AutoSize = true;
            this.radIgnoreAll.Location = new System.Drawing.Point(15, 112);
            this.radIgnoreAll.Name = "radIgnoreAll";
            this.radIgnoreAll.Size = new System.Drawing.Size(101, 17);
            this.radIgnoreAll.TabIndex = 11;
            this.radIgnoreAll.Text = "Ignore all invites";
            this.radIgnoreAll.UseVisualStyleBackColor = true;
            // 
            // numLevel
            // 
            this.numLevel.Location = new System.Drawing.Point(255, 88);
            this.numLevel.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numLevel.Name = "numLevel";
            this.numLevel.Size = new System.Drawing.Size(59, 20);
            this.numLevel.TabIndex = 12;
            this.numLevel.ValueChanged += new System.EventHandler(this.numLevel_ValueChanged);
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Enabled = false;
            this.chkEnable.Location = new System.Drawing.Point(15, 56);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(65, 17);
            this.chkEnable.TabIndex = 13;
            this.chkEnable.Text = "Enabled";
            this.chkEnable.UseVisualStyleBackColor = true;
            this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            // 
            // ssFooter
            // 
            this.ssFooter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsStatusText,
            this.tsInviteBlockedCount});
            this.ssFooter.Location = new System.Drawing.Point(0, 153);
            this.ssFooter.Name = "ssFooter";
            this.ssFooter.Size = new System.Drawing.Size(363, 22);
            this.ssFooter.TabIndex = 14;
            this.ssFooter.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabel1.Text = "  ";
            // 
            // tsStatusText
            // 
            this.tsStatusText.Image = global::SteamInviteSpamFilter.Properties.Resources.imgFalse;
            this.tsStatusText.Name = "tsStatusText";
            this.tsStatusText.Size = new System.Drawing.Size(115, 17);
            this.tsStatusText.Text = "Filter not running";
            // 
            // tsInviteBlockedCount
            // 
            this.tsInviteBlockedCount.Name = "tsInviteBlockedCount";
            this.tsInviteBlockedCount.Size = new System.Drawing.Size(15, 17);
            this.tsInviteBlockedCount.Text = "()";
            this.tsInviteBlockedCount.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(363, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startMinimizedToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // startMinimizedToolStripMenuItem
            // 
            this.startMinimizedToolStripMenuItem.Image = global::SteamInviteSpamFilter.Properties.Resources.imgFalse;
            this.startMinimizedToolStripMenuItem.Name = "startMinimizedToolStripMenuItem";
            this.startMinimizedToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.startMinimizedToolStripMenuItem.Text = "&Start Minimized";
            this.startMinimizedToolStripMenuItem.Click += new System.EventHandler(this.startMinimizedToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(154, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Steam Invite Spam Filter";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseSingleClick);
            // 
            // picCookieStatus
            // 
            this.picCookieStatus.Location = new System.Drawing.Point(15, 33);
            this.picCookieStatus.Name = "picCookieStatus";
            this.picCookieStatus.Size = new System.Drawing.Size(15, 16);
            this.picCookieStatus.TabIndex = 9;
            this.picCookieStatus.TabStop = false;
            // 
            // chkBlock
            // 
            this.chkBlock.AutoSize = true;
            this.chkBlock.Enabled = false;
            this.chkBlock.Location = new System.Drawing.Point(86, 56);
            this.chkBlock.Name = "chkBlock";
            this.chkBlock.Size = new System.Drawing.Size(81, 17);
            this.chkBlock.TabIndex = 16;
            this.chkBlock.Text = "Block users";
            this.chkBlock.UseVisualStyleBackColor = true;
            this.chkBlock.CheckedChanged += new System.EventHandler(this.chkBlock_CheckedChanged);
            // 
            // lnkResetCookies
            // 
            this.lnkResetCookies.AutoSize = true;
            this.lnkResetCookies.Location = new System.Drawing.Point(256, 33);
            this.lnkResetCookies.Name = "lnkResetCookies";
            this.lnkResetCookies.Size = new System.Drawing.Size(52, 13);
            this.lnkResetCookies.TabIndex = 7;
            this.lnkResetCookies.TabStop = true;
            this.lnkResetCookies.Text = "(Sign out)";
            this.lnkResetCookies.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkResetCookies_LinkClicked);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 175);
            this.Controls.Add(this.chkBlock);
            this.Controls.Add(this.ssFooter);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.chkEnable);
            this.Controls.Add(this.numLevel);
            this.Controls.Add(this.radIgnoreAll);
            this.Controls.Add(this.radIgnoreLevel);
            this.Controls.Add(this.picCookieStatus);
            this.Controls.Add(this.lnkSignIn);
            this.Controls.Add(this.lnkResetCookies);
            this.Controls.Add(this.lblCookieStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Steam Invite Spam Filter";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.numLevel)).EndInit();
            this.ssFooter.ResumeLayout(false);
            this.ssFooter.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCookieStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkSignIn;
        private System.Windows.Forms.Label lblCookieStatus;
        private System.Windows.Forms.Timer tmrCheckCookieData;
        private System.Windows.Forms.Timer tmrCheckInvites;
        private System.Windows.Forms.PictureBox picCookieStatus;
        private System.Windows.Forms.RadioButton radIgnoreLevel;
        private System.Windows.Forms.RadioButton radIgnoreAll;
        private System.Windows.Forms.NumericUpDown numLevel;
        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.StatusStrip ssFooter;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusText;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel tsInviteBlockedCount;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startMinimizedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.CheckBox chkBlock;
        private System.Windows.Forms.LinkLabel lnkResetCookies;

    }
}

