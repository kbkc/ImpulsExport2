using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

namespace ImpulsExport
{
    public class MessageBox_self_close : Form
    {
        private int i;

        private IContainer components = null;

        private Label label1;

        private System.Windows.Forms.Timer timer1; // Explicitly specify System.Windows.Forms.Timer to resolve ambiguity

        private Label label2;

        private PictureBox pictureBox1;

        private PictureBox pictureBox2;

        public MessageBox_self_close()
        {
            InitializeComponent();
            closer();
        }

        private void closer()
        {
            if (Environment.UserName.ToString() == "tb")
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
            }
            i = 5;
            label1.Text = "Export erfolgreich!";
            label2.Text = "(Fenster schliesst sich in " + i + " Sekunden)";
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i > -1)
            {
                label2.Text = "(Fenster schliesst sich in " + i + " Sekunden)";
                i--;
            }
            else
            {
                timer1.Enabled = false;
                Close();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImpulsExport.MessageBox_self_close));
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components); // Explicitly specify System.Windows.Forms.Timer
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
            base.SuspendLayout();
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.label1.Location = new System.Drawing.Point(96, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nachricht";
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(timer1_Tick);
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            this.pictureBox1.Location = new System.Drawing.Point(12, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
            this.pictureBox2.Location = new System.Drawing.Point(12, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(63, 63);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(292, 75);
            base.Controls.Add(this.pictureBox2);
            base.Controls.Add(this.pictureBox1);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "MessageBox_self_close";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nachricht";
            base.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}
