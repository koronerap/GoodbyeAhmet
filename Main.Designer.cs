namespace GoodbyeAhmet
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            launchButton = new Button();
            notifyIcon = new NotifyIcon(components);
            notifyContextMenuStrip = new ContextMenuStrip(components);
            resetToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            aboutButton = new Button();
            settingsButton = new Button();
            notifyContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // launchButton
            // 
            launchButton.BackColor = Color.FromArgb(255, 207, 119);
            launchButton.FlatAppearance.BorderSize = 0;
            launchButton.FlatStyle = FlatStyle.Flat;
            launchButton.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            launchButton.ForeColor = Color.FromArgb(66, 66, 66);
            launchButton.Location = new Point(5, 278);
            launchButton.Margin = new Padding(0, 0, 0, 3);
            launchButton.Name = "launchButton";
            launchButton.Size = new Size(169, 30);
            launchButton.TabIndex = 4;
            launchButton.Text = "LAUNCH";
            launchButton.UseVisualStyleBackColor = false;
            launchButton.Click += launchButton_Click;
            // 
            // notifyIcon
            // 
            notifyIcon.ContextMenuStrip = notifyContextMenuStrip;
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "Goodbye Ahmet";
            notifyIcon.Visible = true;
            // 
            // notifyContextMenuStrip
            // 
            notifyContextMenuStrip.Items.AddRange(new ToolStripItem[] { resetToolStripMenuItem, closeToolStripMenuItem });
            notifyContextMenuStrip.Name = "notifyContextMenuStrip";
            notifyContextMenuStrip.Size = new Size(104, 48);
            // 
            // resetToolStripMenuItem
            // 
            resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resetToolStripMenuItem.Size = new Size(103, 22);
            resetToolStripMenuItem.Text = "Reset";
            resetToolStripMenuItem.Click += resetToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(103, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.gbyeahmet_logo;
            pictureBox1.Location = new Point(5, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(229, 270);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // aboutButton
            // 
            aboutButton.BackColor = Color.FromArgb(22, 22, 22);
            aboutButton.BackgroundImage = Properties.Resources.questionmark;
            aboutButton.BackgroundImageLayout = ImageLayout.Zoom;
            aboutButton.FlatAppearance.BorderSize = 0;
            aboutButton.FlatStyle = FlatStyle.Flat;
            aboutButton.Font = new Font("Segoe UI", 8F);
            aboutButton.Location = new Point(204, 278);
            aboutButton.Margin = new Padding(0, 0, 0, 3);
            aboutButton.Name = "aboutButton";
            aboutButton.Size = new Size(30, 30);
            aboutButton.TabIndex = 10;
            aboutButton.UseVisualStyleBackColor = false;
            aboutButton.Click += aboutButton_Click;
            // 
            // settingsButton
            // 
            settingsButton.BackColor = Color.FromArgb(22, 22, 22);
            settingsButton.BackgroundImage = Properties.Resources.settings;
            settingsButton.BackgroundImageLayout = ImageLayout.Zoom;
            settingsButton.FlatAppearance.BorderSize = 0;
            settingsButton.FlatStyle = FlatStyle.Flat;
            settingsButton.Font = new Font("Segoe UI", 8F);
            settingsButton.Location = new Point(174, 278);
            settingsButton.Margin = new Padding(0, 0, 0, 3);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(30, 30);
            settingsButton.TabIndex = 11;
            settingsButton.UseVisualStyleBackColor = false;
            settingsButton.Click += settingsButton_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 22, 22);
            ClientSize = new Size(238, 315);
            Controls.Add(settingsButton);
            Controls.Add(aboutButton);
            Controls.Add(pictureBox1);
            Controls.Add(launchButton);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Main";
            Text = "Goodbye Ahmet";
            FormClosing += Form1_FormClosing;
            Load += Main_Load;
            notifyContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button launchButton;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip notifyContextMenuStrip;
        private ToolStripMenuItem resetToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private PictureBox pictureBox1;
        private Button aboutButton;
        private Button settingsButton;
    }
}
