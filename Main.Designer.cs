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
            label1 = new Label();
            modesetTextBox = new TextBox();
            dnsV4AddressTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            dnsV4PortTextBox = new TextBox();
            label4 = new Label();
            dnsV6AddressTextBox = new TextBox();
            label5 = new Label();
            dnsV6PortTextBox = new TextBox();
            launchButton = new Button();
            notifyIcon = new NotifyIcon(components);
            notifyContextMenuStrip = new ContextMenuStrip(components);
            resetToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            aboutButton = new Button();
            notifyContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(158, 12);
            label1.Name = "label1";
            label1.Size = new Size(112, 30);
            label1.TabIndex = 0;
            label1.Text = "Modeset";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // modesetTextBox
            // 
            modesetTextBox.BackColor = Color.FromArgb(44, 44, 44);
            modesetTextBox.BorderStyle = BorderStyle.None;
            modesetTextBox.Dock = DockStyle.Fill;
            modesetTextBox.ForeColor = Color.FromArgb(255, 207, 119);
            modesetTextBox.Location = new Point(7, 7);
            modesetTextBox.Name = "modesetTextBox";
            modesetTextBox.Size = new Size(204, 16);
            modesetTextBox.TabIndex = 1;
            modesetTextBox.Text = "-5";
            // 
            // dnsV4AddressTextBox
            // 
            dnsV4AddressTextBox.BackColor = Color.FromArgb(44, 44, 44);
            dnsV4AddressTextBox.BorderStyle = BorderStyle.None;
            dnsV4AddressTextBox.Dock = DockStyle.Fill;
            dnsV4AddressTextBox.ForeColor = Color.FromArgb(255, 207, 119);
            dnsV4AddressTextBox.Location = new Point(7, 7);
            dnsV4AddressTextBox.Name = "dnsV4AddressTextBox";
            dnsV4AddressTextBox.Size = new Size(204, 16);
            dnsV4AddressTextBox.TabIndex = 3;
            dnsV4AddressTextBox.Text = "77.88.8.8";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(158, 48);
            label2.Name = "label2";
            label2.Size = new Size(112, 30);
            label2.TabIndex = 2;
            label2.Text = "DNS V4 Address";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(158, 85);
            label3.Name = "label3";
            label3.Size = new Size(112, 30);
            label3.TabIndex = 2;
            label3.Text = "DNS V4 Port";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dnsV4PortTextBox
            // 
            dnsV4PortTextBox.BackColor = Color.FromArgb(44, 44, 44);
            dnsV4PortTextBox.BorderStyle = BorderStyle.None;
            dnsV4PortTextBox.Dock = DockStyle.Fill;
            dnsV4PortTextBox.ForeColor = Color.FromArgb(255, 207, 119);
            dnsV4PortTextBox.Location = new Point(7, 7);
            dnsV4PortTextBox.Name = "dnsV4PortTextBox";
            dnsV4PortTextBox.Size = new Size(204, 16);
            dnsV4PortTextBox.TabIndex = 3;
            dnsV4PortTextBox.Text = "1253";
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(158, 121);
            label4.Name = "label4";
            label4.Size = new Size(112, 30);
            label4.TabIndex = 2;
            label4.Text = "DNS V6 Address";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dnsV6AddressTextBox
            // 
            dnsV6AddressTextBox.BackColor = Color.FromArgb(44, 44, 44);
            dnsV6AddressTextBox.BorderStyle = BorderStyle.None;
            dnsV6AddressTextBox.Dock = DockStyle.Fill;
            dnsV6AddressTextBox.ForeColor = Color.FromArgb(255, 207, 119);
            dnsV6AddressTextBox.Location = new Point(7, 7);
            dnsV6AddressTextBox.Name = "dnsV6AddressTextBox";
            dnsV6AddressTextBox.Size = new Size(204, 16);
            dnsV6AddressTextBox.TabIndex = 3;
            dnsV6AddressTextBox.Text = "2a02:6b8::feed:0ff";
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(158, 157);
            label5.Name = "label5";
            label5.Size = new Size(112, 30);
            label5.TabIndex = 2;
            label5.Text = "DNS V6 Port";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dnsV6PortTextBox
            // 
            dnsV6PortTextBox.BackColor = Color.FromArgb(44, 44, 44);
            dnsV6PortTextBox.BorderStyle = BorderStyle.None;
            dnsV6PortTextBox.Dock = DockStyle.Fill;
            dnsV6PortTextBox.ForeColor = Color.FromArgb(255, 207, 119);
            dnsV6PortTextBox.Location = new Point(7, 7);
            dnsV6PortTextBox.Name = "dnsV6PortTextBox";
            dnsV6PortTextBox.Size = new Size(204, 16);
            dnsV6PortTextBox.TabIndex = 3;
            dnsV6PortTextBox.Text = "1253";
            // 
            // launchButton
            // 
            launchButton.BackColor = Color.FromArgb(255, 207, 119);
            launchButton.FlatAppearance.BorderSize = 0;
            launchButton.FlatStyle = FlatStyle.Flat;
            launchButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            launchButton.ForeColor = Color.FromArgb(66, 66, 66);
            launchButton.Location = new Point(276, 193);
            launchButton.Name = "launchButton";
            launchButton.Size = new Size(218, 30);
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
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(140, 211);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(44, 44, 44);
            panel1.Controls.Add(dnsV6PortTextBox);
            panel1.Location = new Point(276, 157);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(7);
            panel1.Size = new Size(218, 30);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(44, 44, 44);
            panel2.Controls.Add(dnsV6AddressTextBox);
            panel2.Location = new Point(276, 121);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(7);
            panel2.Size = new Size(218, 30);
            panel2.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(44, 44, 44);
            panel3.Controls.Add(dnsV4PortTextBox);
            panel3.Location = new Point(276, 85);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(7);
            panel3.Size = new Size(218, 30);
            panel3.TabIndex = 8;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(44, 44, 44);
            panel4.Controls.Add(dnsV4AddressTextBox);
            panel4.Location = new Point(276, 48);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(7);
            panel4.Size = new Size(218, 30);
            panel4.TabIndex = 9;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(44, 44, 44);
            panel5.Controls.Add(modesetTextBox);
            panel5.Location = new Point(276, 12);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(7);
            panel5.Size = new Size(218, 30);
            panel5.TabIndex = 9;
            // 
            // aboutButton
            // 
            aboutButton.BackColor = Color.FromArgb(33, 33, 33);
            aboutButton.FlatAppearance.BorderSize = 0;
            aboutButton.FlatStyle = FlatStyle.Flat;
            aboutButton.Font = new Font("Segoe UI", 8F);
            aboutButton.Location = new Point(158, 193);
            aboutButton.Name = "aboutButton";
            aboutButton.Size = new Size(112, 30);
            aboutButton.TabIndex = 10;
            aboutButton.Text = "ABOUT";
            aboutButton.UseVisualStyleBackColor = false;
            aboutButton.Click += this.aboutButton_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 22, 22);
            ClientSize = new Size(506, 239);
            Controls.Add(aboutButton);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(launchButton);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Main";
            Text = "Goodbye Ahmet";
            FormClosing += Form1_FormClosing;
            notifyContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox modesetTextBox;
        private TextBox dnsV4AddressTextBox;
        private Label label2;
        private Label label3;
        private TextBox dnsV4PortTextBox;
        private Label label4;
        private TextBox dnsV6AddressTextBox;
        private Label label5;
        private TextBox dnsV6PortTextBox;
        private Button launchButton;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip notifyContextMenuStrip;
        private ToolStripMenuItem resetToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Button aboutButton;
    }
}
