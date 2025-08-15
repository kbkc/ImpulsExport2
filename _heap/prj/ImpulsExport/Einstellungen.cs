using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ImpulsExport.Properties;

namespace ImpulsExport
{
	public class Einstellungen : Form
	{
		private IContainer components = null;

		private Label label1;

		private Button button1;

		private TextBox textBox_ansp;

		private Label label2;

		private TextBox textBox_tel;

		private GroupBox groupBox1;

		private GroupBox groupBox2;

		private TextBox textBox_firma;

		private Label label3;

		private TextBox textBox_stellenbe;

		private Label label4;

		private Label label7;

		private Label label6;

		private Label label5;

		private Label label8;

		private TextBox textBox_land;

		private TextBox textBox_ort;

		private TextBox textBox_plz;

		private TextBox textBox_strasse;

		private GroupBox groupBox3;

		private TextBox textBox_tin;

		private TextBox textBox_ausfuhrzollst;

		private TextBox textBox_ausfuhrland;

		private Label label10;

		private Label label11;

		private Label label12;

		private TextBox textBox_beteiligten;

		private Label label13;

		private GroupBox groupBox4;

		private TextBox textBox_ladezusa;

		private TextBox textBox_ladeort;

		private TextBox textBox_ladeplz;

		private TextBox textBox_ladestr;

		private Label label9;

		private Label label14;

		private Label label15;

		private Label label16;

		private TextBox textBox_staatszugeh;

		private Label label18;

		private TextBox textBox_verkehrzweig;

		private Label label17;

		private GroupBox groupBox5;

		private GroupBox groupBox6;

		private TextBox textBox_waehr;

		private Label label19;

		private Label label20;

		private TextBox textBox_art;

		private CheckBox checkBox_zusammenfassung;

		private GroupBox groupBox7;

		private Label label21;

		private MaskedTextBox maskedTextBox_statist;

		public Einstellungen()
		{
			InitializeComponent();
		}

		private void Einstellungen_Load(object sender, EventArgs e)
		{
			textBox_ansp.Text = Settings.Default.Name;
			textBox_tel.Text = Settings.Default.Telefon;
			textBox_stellenbe.Text = Settings.Default.Stellenbeschreibung;
			textBox_firma.Text = Settings.Default.Firma;
			textBox_strasse.Text = Settings.Default.Strasse;
			textBox_plz.Text = Settings.Default.PLZ;
			textBox_ort.Text = Settings.Default.Ort;
			textBox_land.Text = Settings.Default.Land;
			textBox_ladeort.Text = Settings.Default.Lade_Ort;
			textBox_ladeplz.Text = Settings.Default.Lade_PLZ;
			textBox_ladestr.Text = Settings.Default.Lade_Strasse;
			textBox_ladezusa.Text = Settings.Default.Lade_Zusatz;
			textBox_ausfuhrland.Text = Settings.Default.Ausfuhrland;
			textBox_ausfuhrzollst.Text = Settings.Default.Ausfuhr_Zollstelle;
			textBox_tin.Text = Settings.Default.TIN;
			textBox_beteiligten.Text = Settings.Default.Beteiligtenkonst;
			textBox_staatszugeh.Text = Settings.Default.Staatszugeh;
			textBox_verkehrzweig.Text = Settings.Default.Verkehrszweig;
			textBox_waehr.Text = Settings.Default.Waehrung;
			textBox_art.Text = Settings.Default.Art;
			checkBox_zusammenfassung.Checked = Settings.Default.zusammenfassen;
			maskedTextBox_statist.Text = Settings.Default.statistischer.ToString();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Settings.Default.Name = textBox_ansp.Text;
			Settings.Default.Telefon = textBox_tel.Text;
			Settings.Default.Stellenbeschreibung = textBox_stellenbe.Text;
			Settings.Default.Firma = textBox_firma.Text;
			Settings.Default.Strasse = textBox_strasse.Text;
			Settings.Default.PLZ = textBox_plz.Text;
			Settings.Default.Ort = textBox_ort.Text;
			Settings.Default.Land = textBox_land.Text;
			Settings.Default.Lade_Ort = textBox_ladeort.Text;
			Settings.Default.Lade_PLZ = textBox_ladeplz.Text;
			Settings.Default.Lade_Strasse = textBox_ladestr.Text;
			Settings.Default.Lade_Zusatz = textBox_ladezusa.Text;
			Settings.Default.Ausfuhrland = textBox_ausfuhrland.Text;
			Settings.Default.Ausfuhr_Zollstelle = textBox_ausfuhrzollst.Text;
			Settings.Default.TIN = textBox_tin.Text;
			Settings.Default.Beteiligtenkonst = textBox_beteiligten.Text;
			Settings.Default.Staatszugeh = textBox_staatszugeh.Text;
			Settings.Default.Verkehrszweig = textBox_verkehrzweig.Text;
			Settings.Default.Waehrung = textBox_waehr.Text;
			Settings.Default.Art = textBox_art.Text;
			Settings.Default.zusammenfassen = checkBox_zusammenfassung.Checked;
			Settings.Default.statistischer = Convert.ToInt32(maskedTextBox_statist.Text);
			Settings.Default.Save();
			Close();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImpulsExport.Einstellungen));
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox_ansp = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_tel = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox_land = new System.Windows.Forms.TextBox();
			this.textBox_ort = new System.Windows.Forms.TextBox();
			this.textBox_plz = new System.Windows.Forms.TextBox();
			this.textBox_strasse = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox_firma = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBox_stellenbe = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.textBox_waehr = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.textBox_art = new System.Windows.Forms.TextBox();
			this.textBox_tin = new System.Windows.Forms.TextBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.textBox_staatszugeh = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.textBox_verkehrzweig = new System.Windows.Forms.TextBox();
			this.textBox_ausfuhrzollst = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.textBox_beteiligten = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBox_ausfuhrland = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.textBox_ladezusa = new System.Windows.Forms.TextBox();
			this.textBox_ladeort = new System.Windows.Forms.TextBox();
			this.textBox_ladeplz = new System.Windows.Forms.TextBox();
			this.textBox_ladestr = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.checkBox_zusammenfassung = new System.Windows.Forms.CheckBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.maskedTextBox_statist = new System.Windows.Forms.MaskedTextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox7.SuspendLayout();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ansprechpartner";
			this.button1.Location = new System.Drawing.Point(287, 500);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Speichern";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(button1_Click);
			this.textBox_ansp.Location = new System.Drawing.Point(134, 19);
			this.textBox_ansp.Name = "textBox_ansp";
			this.textBox_ansp.Size = new System.Drawing.Size(160, 20);
			this.textBox_ansp.TabIndex = 0;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Telefonnummer";
			this.textBox_tel.Location = new System.Drawing.Point(134, 54);
			this.textBox_tel.Name = "textBox_tel";
			this.textBox_tel.Size = new System.Drawing.Size(160, 20);
			this.textBox_tel.TabIndex = 1;
			this.groupBox1.Controls.Add(this.textBox_land);
			this.groupBox1.Controls.Add(this.textBox_ort);
			this.groupBox1.Controls.Add(this.textBox_plz);
			this.groupBox1.Controls.Add(this.textBox_strasse);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.textBox_firma);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(309, 193);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Firmenadresse";
			this.textBox_land.Location = new System.Drawing.Point(134, 158);
			this.textBox_land.Name = "textBox_land";
			this.textBox_land.Size = new System.Drawing.Size(160, 20);
			this.textBox_land.TabIndex = 11;
			this.textBox_ort.Location = new System.Drawing.Point(134, 123);
			this.textBox_ort.Name = "textBox_ort";
			this.textBox_ort.Size = new System.Drawing.Size(160, 20);
			this.textBox_ort.TabIndex = 10;
			this.textBox_plz.Location = new System.Drawing.Point(134, 88);
			this.textBox_plz.Name = "textBox_plz";
			this.textBox_plz.Size = new System.Drawing.Size(160, 20);
			this.textBox_plz.TabIndex = 9;
			this.textBox_strasse.Location = new System.Drawing.Point(134, 54);
			this.textBox_strasse.Name = "textBox_strasse";
			this.textBox_strasse.Size = new System.Drawing.Size(160, 20);
			this.textBox_strasse.TabIndex = 8;
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(15, 161);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(31, 13);
			this.label8.TabIndex = 6;
			this.label8.Text = "Land";
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(15, 126);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(21, 13);
			this.label7.TabIndex = 6;
			this.label7.Text = "Ort";
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(15, 91);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(27, 13);
			this.label6.TabIndex = 6;
			this.label6.Text = "PLZ";
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(15, 57);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(42, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Strasse";
			this.textBox_firma.Location = new System.Drawing.Point(134, 19);
			this.textBox_firma.Name = "textBox_firma";
			this.textBox_firma.Size = new System.Drawing.Size(160, 20);
			this.textBox_firma.TabIndex = 6;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Firma";
			this.groupBox2.Controls.Add(this.textBox_stellenbe);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.textBox_tel);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.textBox_ansp);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(336, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(309, 130);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Ansprechpartner";
			this.textBox_stellenbe.Location = new System.Drawing.Point(134, 89);
			this.textBox_stellenbe.Name = "textBox_stellenbe";
			this.textBox_stellenbe.Size = new System.Drawing.Size(160, 20);
			this.textBox_stellenbe.TabIndex = 5;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(15, 92);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(103, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Stellenbeschreibung";
			this.groupBox3.Controls.Add(this.groupBox6);
			this.groupBox3.Controls.Add(this.textBox_tin);
			this.groupBox3.Controls.Add(this.groupBox5);
			this.groupBox3.Controls.Add(this.textBox_ausfuhrzollst);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.textBox_beteiligten);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Controls.Add(this.textBox_ausfuhrland);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Location = new System.Drawing.Point(12, 304);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(633, 184);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Zoll";
			this.groupBox6.Controls.Add(this.textBox_waehr);
			this.groupBox6.Controls.Add(this.label19);
			this.groupBox6.Controls.Add(this.label20);
			this.groupBox6.Controls.Add(this.textBox_art);
			this.groupBox6.Location = new System.Drawing.Point(0, 94);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(315, 90);
			this.groupBox6.TabIndex = 16;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Geschäftsvorgang";
			this.textBox_waehr.Location = new System.Drawing.Point(134, 52);
			this.textBox_waehr.Name = "textBox_waehr";
			this.textBox_waehr.Size = new System.Drawing.Size(160, 20);
			this.textBox_waehr.TabIndex = 14;
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(15, 20);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(20, 13);
			this.label19.TabIndex = 11;
			this.label19.Text = "Art";
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(15, 55);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(51, 13);
			this.label20.TabIndex = 13;
			this.label20.Text = "Währung";
			this.textBox_art.Location = new System.Drawing.Point(134, 17);
			this.textBox_art.Name = "textBox_art";
			this.textBox_art.Size = new System.Drawing.Size(160, 20);
			this.textBox_art.TabIndex = 12;
			this.textBox_tin.Location = new System.Drawing.Point(458, 111);
			this.textBox_tin.Name = "textBox_tin";
			this.textBox_tin.Size = new System.Drawing.Size(160, 20);
			this.textBox_tin.TabIndex = 10;
			this.groupBox5.Controls.Add(this.textBox_staatszugeh);
			this.groupBox5.Controls.Add(this.label17);
			this.groupBox5.Controls.Add(this.label18);
			this.groupBox5.Controls.Add(this.textBox_verkehrzweig);
			this.groupBox5.Location = new System.Drawing.Point(318, 0);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(315, 90);
			this.groupBox5.TabIndex = 15;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Inland";
			this.textBox_staatszugeh.Location = new System.Drawing.Point(140, 52);
			this.textBox_staatszugeh.Name = "textBox_staatszugeh";
			this.textBox_staatszugeh.Size = new System.Drawing.Size(160, 20);
			this.textBox_staatszugeh.TabIndex = 14;
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(21, 20);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(76, 13);
			this.label17.TabIndex = 11;
			this.label17.Text = "Verkehrszweig";
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(21, 55);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(106, 13);
			this.label18.TabIndex = 13;
			this.label18.Text = "Staatszugehoerigkeit";
			this.textBox_verkehrzweig.Location = new System.Drawing.Point(140, 17);
			this.textBox_verkehrzweig.Name = "textBox_verkehrzweig";
			this.textBox_verkehrzweig.Size = new System.Drawing.Size(160, 20);
			this.textBox_verkehrzweig.TabIndex = 12;
			this.textBox_ausfuhrzollst.Location = new System.Drawing.Point(134, 51);
			this.textBox_ausfuhrzollst.Name = "textBox_ausfuhrzollst";
			this.textBox_ausfuhrzollst.Size = new System.Drawing.Size(160, 20);
			this.textBox_ausfuhrzollst.TabIndex = 9;
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(15, 20);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(63, 13);
			this.label12.TabIndex = 7;
			this.label12.Text = "Ausfuhrland";
			this.textBox_beteiligten.Location = new System.Drawing.Point(458, 146);
			this.textBox_beteiligten.Name = "textBox_beteiligten";
			this.textBox_beteiligten.Size = new System.Drawing.Size(160, 20);
			this.textBox_beteiligten.TabIndex = 6;
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(15, 54);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(90, 13);
			this.label11.TabIndex = 6;
			this.label11.Text = "Ausfuhr_Zollstelle";
			this.textBox_ausfuhrland.Location = new System.Drawing.Point(134, 17);
			this.textBox_ausfuhrland.Name = "textBox_ausfuhrland";
			this.textBox_ausfuhrland.Size = new System.Drawing.Size(160, 20);
			this.textBox_ausfuhrland.TabIndex = 8;
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(339, 149);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(115, 13);
			this.label13.TabIndex = 0;
			this.label13.Text = "Beteiligtenkonstellation";
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(339, 114);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(25, 13);
			this.label10.TabIndex = 6;
			this.label10.Text = "TIN";
			this.groupBox4.Controls.Add(this.textBox_ladezusa);
			this.groupBox4.Controls.Add(this.textBox_ladeort);
			this.groupBox4.Controls.Add(this.textBox_ladeplz);
			this.groupBox4.Controls.Add(this.textBox_ladestr);
			this.groupBox4.Controls.Add(this.label9);
			this.groupBox4.Controls.Add(this.label14);
			this.groupBox4.Controls.Add(this.label15);
			this.groupBox4.Controls.Add(this.label16);
			this.groupBox4.Location = new System.Drawing.Point(12, 211);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(633, 87);
			this.groupBox4.TabIndex = 12;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Ladeort";
			this.textBox_ladezusa.Location = new System.Drawing.Point(458, 50);
			this.textBox_ladezusa.Name = "textBox_ladezusa";
			this.textBox_ladezusa.Size = new System.Drawing.Size(160, 20);
			this.textBox_ladezusa.TabIndex = 11;
			this.textBox_ladeort.Location = new System.Drawing.Point(458, 15);
			this.textBox_ladeort.Name = "textBox_ladeort";
			this.textBox_ladeort.Size = new System.Drawing.Size(160, 20);
			this.textBox_ladeort.TabIndex = 10;
			this.textBox_ladeplz.Location = new System.Drawing.Point(134, 53);
			this.textBox_ladeplz.Name = "textBox_ladeplz";
			this.textBox_ladeplz.Size = new System.Drawing.Size(160, 20);
			this.textBox_ladeplz.TabIndex = 9;
			this.textBox_ladestr.Location = new System.Drawing.Point(134, 19);
			this.textBox_ladestr.Name = "textBox_ladestr";
			this.textBox_ladestr.Size = new System.Drawing.Size(160, 20);
			this.textBox_ladestr.TabIndex = 8;
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(339, 53);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(39, 13);
			this.label9.TabIndex = 6;
			this.label9.Text = "Zusatz";
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(339, 18);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(21, 13);
			this.label14.TabIndex = 6;
			this.label14.Text = "Ort";
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(15, 56);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(27, 13);
			this.label15.TabIndex = 6;
			this.label15.Text = "PLZ";
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(15, 22);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(42, 13);
			this.label16.TabIndex = 7;
			this.label16.Text = "Strasse";
			this.checkBox_zusammenfassung.AutoSize = true;
			this.checkBox_zusammenfassung.Location = new System.Drawing.Point(18, 25);
			this.checkBox_zusammenfassung.Name = "checkBox_zusammenfassung";
			this.checkBox_zusammenfassung.Size = new System.Drawing.Size(126, 17);
			this.checkBox_zusammenfassung.TabIndex = 14;
			this.checkBox_zusammenfassung.Text = "Zusammenfass. aktiv";
			this.checkBox_zusammenfassung.UseVisualStyleBackColor = true;
			this.groupBox7.Controls.Add(this.maskedTextBox_statist);
			this.groupBox7.Controls.Add(this.label21);
			this.groupBox7.Controls.Add(this.checkBox_zusammenfassung);
			this.groupBox7.Location = new System.Drawing.Point(336, 148);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(309, 57);
			this.groupBox7.TabIndex = 15;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Exporteinstellung";
			this.maskedTextBox_statist.Location = new System.Drawing.Point(159, 28);
			this.maskedTextBox_statist.Mask = "99";
			this.maskedTextBox_statist.Name = "maskedTextBox_statist";
			this.maskedTextBox_statist.Size = new System.Drawing.Size(135, 20);
			this.maskedTextBox_statist.TabIndex = 17;
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(156, 12);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(138, 13);
			this.label21.TabIndex = 16;
			this.label21.Text = "Aufschlag statistischer Wert";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(657, 530);
			base.Controls.Add(this.groupBox7);
			base.Controls.Add(this.groupBox4);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.button1);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Einstellungen";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Einstellungen";
			base.Load += new System.EventHandler(Einstellungen_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
