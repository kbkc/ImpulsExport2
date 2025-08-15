using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ImpulsExport
{
	public class Zusammenfassen : Form
	{
		private IContainer components = null;

		private TextBox textBox1;

		private Button button1;

		private Button button2;

		public Zusammenfassen()
		{
			InitializeComponent();
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			base.SuspendLayout();
			this.textBox1.Location = new System.Drawing.Point(12, 12);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(874, 302);
			this.textBox1.TabIndex = 0;
			this.button1.Location = new System.Drawing.Point(12, 320);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Abbrechen";
			this.button1.UseVisualStyleBackColor = true;
			this.button2.Location = new System.Drawing.Point(810, 320);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "OK";
			this.button2.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(898, 359);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.textBox1);
			base.Name = "Zusammenfassen";
			this.Text = "Zusammenfassen";
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
