namespace GoodbyeAhmet
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            label2 = new Label();
            label3 = new Label();
            linkLabel2 = new LinkLabel();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoEllipsis = true;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(10, 10);
            label1.Name = "label1";
            label1.Size = new Size(461, 48);
            label1.TabIndex = 0;
            label1.Text = "This application works using the GoodbyeDPI application. Its main purpose is to hide the GoodbyeDPI application interface from the taskbar and make it a Tray icon.\r\n\r\n";
            label1.UseWaitCursor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Dock = DockStyle.Top;
            linkLabel1.Location = new Point(10, 73);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(228, 15);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "https://github.com/ValdikSS/GoodbyeDPI";
            linkLabel1.VisitedLinkColor = Color.Blue;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(10, 58);
            label2.Name = "label2";
            label2.Size = new Size(117, 15);
            label2.TabIndex = 3;
            label2.Text = "GoodbyeDPI GitHub:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Location = new Point(10, 88);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 15, 0, 0);
            label3.Size = new Size(135, 30);
            label3.TabIndex = 4;
            label3.Text = "GoodbyeAhmet GitHub:";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Dock = DockStyle.Top;
            linkLabel2.Location = new Point(10, 118);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(257, 15);
            linkLabel2.TabIndex = 5;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "https://github.com/koronerap/GoodbyeAhmet";
            linkLabel2.VisitedLinkColor = Color.Blue;
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Location = new Point(10, 133);
            label4.Name = "label4";
            label4.Padding = new Padding(0, 15, 0, 0);
            label4.Size = new Size(175, 30);
            label4.TabIndex = 6;
            label4.Text = "Project Logo by Ainul Muttakin.";
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 182);
            Controls.Add(label4);
            Controls.Add(linkLabel2);
            Controls.Add(label3);
            Controls.Add(linkLabel1);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "About";
            Padding = new Padding(10);
            Text = "About";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private LinkLabel linkLabel1;
        private Label label2;
        private Label label3;
        private LinkLabel linkLabel2;
        private Label label4;
    }
}