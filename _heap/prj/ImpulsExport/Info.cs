using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ImpulsExport
{
	public class Info : Form
	{
		private IContainer components = null;

		public TextBox textBox1;

		public Info()
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
			base.SuspendLayout();
			this.textBox1.Location = new System.Drawing.Point(12, 12);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(268, 242);
			this.textBox1.TabIndex = 0;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(292, 266);
			base.Controls.Add(this.textBox1);
			base.Name = "Info";
			this.Text = "Info";
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
