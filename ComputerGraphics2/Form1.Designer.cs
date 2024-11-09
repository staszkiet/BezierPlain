namespace ComputerGraphics2
{
    partial class Form1
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
            splitContainer1 = new SplitContainer();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            button1 = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            trackBarm = new TrackBar();
            trackBarks = new TrackBar();
            trackBarkd = new TrackBar();
            checkBox1 = new CheckBox();
            trackBar3 = new TrackBar();
            trackBar2 = new TrackBar();
            trackBar1 = new TrackBar();
            colorDialog1 = new ColorDialog();
            colorDialog2 = new ColorDialog();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarkd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Panel2.Controls.Add(button1);
            splitContainer1.Panel2.Controls.Add(label6);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(trackBarm);
            splitContainer1.Panel2.Controls.Add(trackBarks);
            splitContainer1.Panel2.Controls.Add(trackBarkd);
            splitContainer1.Panel2.Controls.Add(checkBox1);
            splitContainer1.Panel2.Controls.Add(trackBar3);
            splitContainer1.Panel2.Controls.Add(trackBar2);
            splitContainer1.Panel2.Controls.Add(trackBar1);
            splitContainer1.Size = new Size(1003, 450);
            splitContainer1.SplitterDistance = 612;
            splitContainer1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(612, 450);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += PictureBox_Paint;
            // 
            // button2
            // 
            button2.Location = new Point(23, 328);
            button2.Name = "button2";
            button2.Size = new Size(175, 34);
            button2.TabIndex = 14;
            button2.Text = "Light Color";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(23, 288);
            button1.Name = "button1";
            button1.Size = new Size(172, 34);
            button1.TabIndex = 13;
            button1.Text = "Object Color";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(166, 241);
            label6.Name = "label6";
            label6.Size = new Size(28, 25);
            label6.TabIndex = 12;
            label6.Text = "m";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(166, 213);
            label5.Name = "label5";
            label5.Size = new Size(29, 25);
            label5.TabIndex = 11;
            label5.Text = "ks";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(166, 185);
            label4.Name = "label4";
            label4.Size = new Size(32, 25);
            label4.TabIndex = 10;
            label4.Text = "kd";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(162, 99);
            label3.Name = "label3";
            label3.Size = new Size(88, 25);
            label3.TabIndex = 9;
            label3.Text = "x rotation";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(162, 56);
            label2.Name = "label2";
            label2.Size = new Size(88, 25);
            label2.TabIndex = 8;
            label2.Text = "z rotation";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(162, 12);
            label1.Name = "label1";
            label1.Size = new Size(80, 25);
            label1.TabIndex = 7;
            label1.Text = "Triangles";
            label1.Click += label1_Click;
            // 
            // trackBarm
            // 
            trackBarm.Location = new Point(12, 241);
            trackBarm.Maximum = 100;
            trackBarm.Minimum = 5;
            trackBarm.Name = "trackBarm";
            trackBarm.Size = new Size(156, 69);
            trackBarm.TabIndex = 6;
            trackBarm.Value = 5;
            trackBarm.ValueChanged += trackBarm_ValueChanged;
            // 
            // trackBarks
            // 
            trackBarks.Location = new Point(12, 213);
            trackBarks.Maximum = 100;
            trackBarks.Name = "trackBarks";
            trackBarks.Size = new Size(156, 69);
            trackBarks.TabIndex = 5;
            trackBarks.Value = 1;
            trackBarks.ValueChanged += trackBarks_ValueChanged;
            // 
            // trackBarkd
            // 
            trackBarkd.Location = new Point(12, 181);
            trackBarkd.Maximum = 100;
            trackBarkd.Name = "trackBarkd";
            trackBarkd.Size = new Size(156, 69);
            trackBarkd.TabIndex = 4;
            trackBarkd.Value = 1;
            trackBarkd.ValueChanged += trackBarkd_ValueChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(23, 146);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(81, 29);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Mesh";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(12, 106);
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(156, 69);
            trackBar3.TabIndex = 2;
            trackBar3.ValueChanged += trackBar3_ValueChanged;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(12, 55);
            trackBar2.Maximum = 45;
            trackBar2.Minimum = -45;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(156, 69);
            trackBar2.TabIndex = 1;
            trackBar2.ValueChanged += trackBar2_ValueChanged;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(12, 12);
            trackBar1.Maximum = 100;
            trackBar1.Minimum = 2;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(156, 69);
            trackBar1.TabIndex = 0;
            trackBar1.Value = 5;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1003, 450);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarm).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarks).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarkd).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private PictureBox pictureBox1;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private TrackBar trackBar3;
        private CheckBox checkBox1;
        private TrackBar trackBarm;
        private TrackBar trackBarks;
        private TrackBar trackBarkd;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label6;
        private Label label5;
        private Button button1;
        private ColorDialog colorDialog1;
        private Button button2;
        private ColorDialog colorDialog2;
    }
}
