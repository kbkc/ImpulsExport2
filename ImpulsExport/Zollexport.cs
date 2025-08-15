using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ImpulsExport.Properties;

namespace ImpulsExport
{
	public class Zollexport : Form
	{
		private Ausfuhranmeldung AF;

		private DataTable gridtable = new DataTable();

		private int Rechnungsanzahl = 0;

		public int zeit;

		public int zeit2;

		private IContainer components = null;

		private ListBox listBox1;

		private Button button1;

		private TextBox textBox2;

		private TextBox textBox3;

		private DataGridView dataGridView1;

		private TextBox textBox4;

		private Button button4;

		private Label label1;

		private MaskedTextBox maskedTextBox1;

		private Label label2;

		private Label label3;

		private MaskedTextBox maskedTextBox2;

		private Label label4;

		private Button button2;

		private Button button3;

		private Button button5;

		private Button button6;

		private Button button7;

		private MaskedTextBox maskedTextBox3;

		private Label label5;

		private Button button8;

		private Button button9;

		private Button button10;

		private Label label6;

		private System.Windows.Forms.Timer timer1;

		private MaskedTextBox maskedTextBox5;

		private Label label8;

		private Label label9;

		private MaskedTextBox maskedTextBox6;

		private RadioButton radioButton_add;

		private RadioButton radioButton_rem;

		private System.Windows.Forms.Timer timer2;

		private RadioButton radioButton_daf;

		public Zollexport()
		{
			InitializeComponent();
			AF = new Ausfuhranmeldung();
			gridtable.Columns.Add("Posid", typeof(string));
			gridtable.Columns.Add("Warenbezeichnung", typeof(string));
			gridtable.Columns.Add("Preis", typeof(string));
			gridtable.Columns.Add("Warennummer", typeof(string));
			gridtable.Columns.Add("ArtNummer", typeof(string));
			gridtable.Columns.Add("Rohmasse", typeof(string));
			gridtable.Columns.Add("Besondere Masseinheit", typeof(string));
			gridtable.Columns.Add("Statistischer Wert", typeof(string));
			gridtable.Columns.Add("Editiert", typeof(bool));
			dataGridView1.DataSource = gridtable;
			foreach (DataGridViewColumn column in dataGridView1.Columns)
			{
				column.SortMode = DataGridViewColumnSortMode.NotSortable;
				column.ReadOnly = true;
			}
			dataGridView1.Columns[8].Visible = false;
			dataGridView1.Columns[5].ReadOnly = false;
			dataGridView1.Columns[1].ReadOnly = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (Convert.ToInt32(maskedTextBox1.Text.Length) <= 0)
			{
				return;
			}
			int count = AF.Rechnungen.Count;
			AF.addRechnung(Convert.ToInt32(maskedTextBox1.Text));
			if (AF.Rechnungen.Count > count)
			{
				radioButton_rem.Enabled = true;
				radioButton_add.Enabled = true;
				radioButton_daf.Enabled = true;
				update_text3();
				update_text2();
				listBox1.Items.Add(maskedTextBox1.Text);
				maskedTextBox1.Text = "";
				update_table();
				button5_Click(sender, e);
				if (AF.Rechnungen[0].has_kAnschrift)
				{
					button3.Enabled = true;
				}
				if (AF.Rechnungen[0].has_aAnschrift)
				{
					button5.Enabled = true;
				}
				AF.Calc_Rohmasse();
				AF.Calc_Preis();
				AF.Calc_rechnungbrutto();
				AF.Calc_Fracht();
				rechnungspreis_aktuell();
				statistischer_aktuell();
				update_text3();
				if (radioButton_rem.Checked)
				{
					rechnung_neu();
				}
				if (radioButton_add.Checked)
				{
					statistisch_neu();
				}
			}
			else
			{
				zeit = 4;
				timer1.Enabled = true;
			}
		}

		private void rechnungspreis_aktuell()
		{
			maskedTextBox6.Text = ToDouble(AF.rechnungbrutto.ToString()) + " €";
		}

		private void statistischer_aktuell()
		{
			maskedTextBox5.Text = Math.Round(ToDouble(AF.rechnungbrutto.ToString())).ToString();
		}

		private void update_text2()
		{
			textBox2.Text = AF.EMNOW_Name + "\r\n" + AF.EMNOW_Strasse + "\r\n" + AF.EMNOW_PLZ + " " + AF.EMNOW_Ort + "\r\n" + AF.EMNOW_Land;
		}

		private void update_text3()
		{
			textBox3.Text = string.Concat("Rechnungsnummer:", AF.Rechnungen[0].rechnungsnummer, "\r\n", "Lieferschein ID:", AF.Rechnungen[0].lsid, "\r\n", "KVID:", AF.Rechnungen[0].kversandid, "LVID:", AF.Rechnungen[0].lversandid, "\r\nGesamtrohmasse:", AF.Gesamtrohmasse);
		}

		private void update_table()
		{
			gridtable.Clear();
			AF.Bezugsnummer = "";
			foreach (Rechnung tmprec in AF.Rechnungen)
			{
				AF.Bezugsnummer = AF.Bezugsnummer + tmprec.rechnungsnummer + " ";
				foreach (Ausfuhrposition tmppos in tmprec.Positionsliste)
				{
					gridtable.Rows.Add(tmppos.PosID, tmppos.Warenbezeichnung, tmppos.Preis, tmppos.Warennummer, tmppos.Artikelnummer, tmppos.Rohmasse, tmppos.BMass, tmppos.Statistischer_Wert, tmppos.editiert);
				}
			}
			AF.Calc_Rohmasse();
			update_text3();
			foreach (DataGridViewRow row in (IEnumerable)dataGridView1.Rows)
			{
				if (row.Cells[5].Value.ToString() == "0")
				{
					row.DefaultCellStyle.BackColor = Color.LightCoral;
				}
				if (row.Cells[8].Value.ToString().ToLower() == "true")
				{
					row.DefaultCellStyle.BackColor = Color.LightGreen;
				}
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			string str = "";
			if (!radioButton_add.Checked && !radioButton_rem.Checked && !radioButton_daf.Checked)
			{
				zeit2 = 4;
				timer2.Enabled = true;
				return;
			}
			if (Settings.Default.zusammenfassen)
			{
				zusammenfassen();
			}
			if (radioButton_add.Checked)
			{
				str = "exw";
			}
			if (radioButton_rem.Checked)
			{
				str = "dap";
				korrektur_statistischer_Wert();
			}
			if (radioButton_daf.Checked)
			{
				str = "daf";
			}
			AESExport Exporter = new AESExport(ref AF, str);
			Form MessageBox_self_close = new MessageBox_self_close();
			MessageBox_self_close.ShowDialog();
		}

		private void korrektur_statistischer_Wert()
		{
			if (radioButton_rem.Checked)
			{
				double temp = ToDouble(AF.Gesamtpreis);
				temp += AF.Frachtkosten;
				AF.Gesamtpreis = temp.ToString().Replace(",", ".");
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			if (Settings.Default.Name.Length < 3)
			{
				label6.Visible = true;
			}
			if (!Settings.Default.zusammenfassen)
			{
				button9.Visible = true;
			}
		}

		private void maskedTextBox2_Leave(object sender, EventArgs e)
		{
			AF.Anzahl_Kartons = maskedTextBox2.Text.ToString();
			AF.Calc_Rohmasse();
			update_text3();
		}

		private void maskedTextBox3_Leave(object sender, EventArgs e)
		{
			AF.Anzahl_Paletten = maskedTextBox3.Text.ToString();
			AF.Calc_Rohmasse();
			update_text3();
		}

		private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
		{
		}

		private void button3_Click(object sender, EventArgs e)
		{
			AF.EMNOW_Name = AF.EMK_Name;
			AF.EMNOW_Strasse = AF.EMK_Strasse;
			AF.EMNOW_PLZ = AF.EMK_PLZ;
			AF.EMNOW_Ort = AF.EMK_Ort;
			AF.EMNOW_Land = AF.EMK_Land;
			update_text2();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			AF.EMNOW_Name = AF.EML_Name;
			AF.EMNOW_Strasse = AF.EML_Strasse;
			AF.EMNOW_PLZ = AF.EML_PLZ;
			AF.EMNOW_Ort = AF.EML_Ort;
			AF.EMNOW_Land = AF.EML_Land;
			update_text2();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			AF.EMNOW_Name = AF.EMA_Name;
			AF.EMNOW_Strasse = AF.EMA_Strasse;
			AF.EMNOW_PLZ = AF.EMA_PLZ;
			AF.EMNOW_Ort = AF.EMA_Ort;
			AF.EMNOW_Land = AF.EMA_Land;
			update_text2();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			update_table();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			Info info1 = new Info();
			List<int> posliste = GetSelectedRows(dataGridView1);
			bool cando = true;
			int tmpwn = 0;
			foreach (int tmppos in posliste)
			{
				foreach (Rechnung tmprn in AF.Rechnungen)
				{
					foreach (Ausfuhrposition tmprnpos in tmprn.Positionsliste)
					{
						if (tmprnpos.PosID == tmppos)
						{
							if (tmpwn == 0)
							{
								tmpwn = int.Parse(tmprnpos.Warennummer);
							}
							else if (int.Parse(tmprnpos.Warennummer) != tmpwn)
							{
								cando = false;
								MessageBox.Show("Verschiedene Warennummern");
								return;
							}
						}
					}
				}
			}
			if (!cando)
			{
			}
		}

		public List<int> GetSelectedRows(DataGridView dg)
		{
			List<int> al = new List<int>();
			CurrencyManager cm = (CurrencyManager)BindingContext[dg.DataSource, dg.DataMember];
			DataView dv = (DataView)cm.List;
			foreach (DataGridViewRow dr in dg.SelectedRows)
			{
				al.Add(int.Parse(dr.Cells[0].Value.ToString()));
			}
			return al;
		}

		private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			update_value(gridtable.Rows[e.RowIndex][0].ToString(), gridtable.Rows[e.RowIndex][5].ToString(), gridtable.Rows[e.RowIndex][1].ToString());
		}

		private void update_value(string posid, string gewicht, string bez)
		{
			foreach (Rechnung tmprec in AF.Rechnungen)
			{
				foreach (Ausfuhrposition tmppos in tmprec.Positionsliste)
				{
					if (tmppos.PosID.ToString() == posid)
					{
						tmppos.Rohmasse = gewicht;
						tmppos.Warenbezeichnung = bez;
						tmppos.editiert = true;
					}
				}
			}
			update_table();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			Application.Restart();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			zusammenfassen();
		}

		private void zusammenfassen()
		{
			if (dataGridView1.RowCount == 0)
			{
				return;
			}
			string[,] arPositionen = new string[dataGridView1.RowCount, 8];
			string[,] tempposi = new string[1, 17];
			foreach (Rechnung tmprec in AF.Rechnungen)
			{
				string[,] Positionen = new string[tmprec.Positionsliste.Count, 17];
				int i = 0;
				foreach (Ausfuhrposition tmppos in tmprec.Positionsliste)
				{
					Positionen[i, 0] = tmppos.Artikelid.ToString();
					Positionen[i, 1] = tmppos.Artikelnummer;
					Positionen[i, 2] = tmppos.AuftragPosID.ToString();
					Positionen[i, 3] = tmppos.BMass;
					Positionen[i, 4] = tmppos.editiert.ToString();
					Positionen[i, 5] = tmppos.Eigenmasse;
					Positionen[i, 6] = tmppos.hat_BM.ToString();
					Positionen[i, 7] = tmppos.Menge;
					Positionen[i, 8] = tmppos.PosID.ToString();
					Positionen[i, 9] = tmppos.Preis;
					Positionen[i, 10] = tmppos.Rohmasse;
					Positionen[i, 11] = tmppos.Statistischer_Wert;
					Positionen[i, 12] = tmppos.Ursprungscode;
					Positionen[i, 13] = tmppos.Ursprungsland;
					Positionen[i, 14] = tmppos.Verfahren;
					Positionen[i, 15] = tmppos.Warenbezeichnung;
					Positionen[i, 16] = tmppos.Warennummer;
					i++;
				}
				for (int ii = 0; ii < Positionen.GetUpperBound(0); ii++)
				{
					for (i = 0; i < Positionen.GetUpperBound(0); i++)
					{
						if (Convert.ToInt64(Positionen[i, 16]) > Convert.ToInt64(Positionen[i + 1, 16]))
						{
							for (int j = 0; j < 17; j++)
							{
								tempposi[0, j] = Positionen[i, j];
								Positionen[i, j] = Positionen[i + 1, j];
								Positionen[i + 1, j] = tempposi[0, j];
							}
						}
					}
				}
				for (i = 0; i < Positionen.GetUpperBound(0); i++)
				{
					if (Convert.ToInt64(Positionen[i, 16]) != Convert.ToInt64(Positionen[i + 1, 16]))
					{
						continue;
					}
					Positionen[i, 1] = Positionen[i, 1] + "," + Positionen[i + 1, 1];
					if (Positionen[i, 1].Length > 200)
					{
						Positionen[i, 1] = Positionen[i, 1].Substring(0, 200);
					}
					double tempa = ((Positionen[i, 3].Length <= 0) ? 0.0 : ToDouble(Positionen[i, 3]));
					double tempb = ((Positionen[i + 1, 3].Length <= 0) ? 0.0 : ToDouble(Positionen[i + 1, 3]));
					Positionen[i, 3] = Convert.ToString(tempa + tempb);
					if (Positionen[i, 3].Length > 200)
					{
						Positionen[i, 3] = Positionen[i, 3].Substring(0, 200);
					}
					tempa = ((Positionen[i, 7].Length <= 0) ? 0.0 : ToDouble(Positionen[i, 7]));
					tempb = ((Positionen[i + 1, 7].Length <= 0) ? 0.0 : ToDouble(Positionen[i + 1, 7]));
					Positionen[i, 7] = Convert.ToString(tempa + tempb);
					tempa = ((Positionen[i, 9].Length <= 0) ? 0.0 : ToDouble(Positionen[i, 9]));
					tempb = ((Positionen[i + 1, 9].Length <= 0) ? 0.0 : ToDouble(Positionen[i + 1, 9]));
					Positionen[i, 9] = Convert.ToString(tempa + tempb);
					tempa = ((Positionen[i, 10].Length <= 0) ? 0.0 : ToDouble(Positionen[i, 10]));
					tempb = ((Positionen[i + 1, 10].Length <= 0) ? 0.0 : ToDouble(Positionen[i + 1, 10]));
					Positionen[i, 10] = Convert.ToString(tempa + tempb);
					Positionen[i, 11] = Math.Round(ToDouble(Positionen[i, 9])).ToString();
					Positionen[i, 15] = Positionen[i, 15] + "," + Positionen[i + 1, 15];
					if (Positionen[i, 15].Length > 200)
					{
						Positionen[i, 15] = Positionen[i, 15].Substring(0, 200);
					}
					Array.Clear(Positionen, (i + 1) * 17, 17);
					for (int ii = 0; ii < Positionen.GetUpperBound(0); ii++)
					{
						for (int iii = 0; iii < Positionen.GetUpperBound(0); iii++)
						{
							if (Convert.ToInt64(Positionen[iii, 16]) > Convert.ToInt64(Positionen[iii + 1, 16]))
							{
								for (int j = 0; j < 17; j++)
								{
									tempposi[0, j] = Positionen[iii, j];
									Positionen[iii, j] = Positionen[iii + 1, j];
									Positionen[iii + 1, j] = tempposi[0, j];
								}
							}
						}
					}
				}
				tmprec.Positionsliste.RemoveRange(0, tmprec.Positionsliste.Count);
				for (int ii = 0; ii < Positionen.GetUpperBound(0) + 1; ii++)
				{
					if (Positionen[ii, 0] != null)
					{
						Ausfuhrposition Pos = new Ausfuhrposition(-1, ii, Positionen, 0);
						tmprec.Positionsliste.Add(Pos);
					}
				}
			}
			update_table();
		}

		private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				button1_Click(sender, e);
			}
		}

		public static double ToDouble(string In)
		{
			In = In.Replace(",", ".");
			return double.Parse(In, CultureInfo.InvariantCulture);
		}

		private void button10_Click(object sender, EventArgs e)
		{
			Form Ansprechpartner = new Einstellungen();
			Ansprechpartner.ShowDialog();
			if (Settings.Default.Name.Length > 3)
			{
				label6.Visible = false;
			}
			else
			{
				label6.Visible = true;
			}
			if (Settings.Default.zusammenfassen)
			{
				button9.Visible = false;
			}
			else
			{
				button9.Visible = true;
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (zeit > -1)
			{
				if (zeit % 2 == 0)
				{
					button1.Text = "falsch";
					button1.ForeColor = Color.Red;
				}
				else
				{
					button1.ForeColor = Color.Black;
				}
				zeit--;
			}
			else
			{
				timer1.Enabled = false;
				button1.Text = ">>";
				button1.ForeColor = Color.Black;
			}
		}

		private void radioButton_add_CheckedChanged(object sender, EventArgs e)
		{
			statistisch_neu();
		}

		private void statistisch_neu()
		{
			double statistischer = Math.Round(ToDouble(AF.rechnungbrutto));
			double versand = Math.Round(statistischer / 100.0 * (double)Settings.Default.statistischer);
			maskedTextBox5.Text = (statistischer + versand).ToString();
			rechnungspreis_aktuell();
		}

		private void radioButton_rem_CheckedChanged(object sender, EventArgs e)
		{
			rechnung_neu();
		}

		private void rechnung_neu()
		{
			double gesamtpr = ToDouble(AF.rechnungbrutto);
			gesamtpr += AF.Frachtkosten;
			maskedTextBox6.Text = gesamtpr + " €";
			statistischer_aktuell();
		}

		private void radioButton_daf_CheckedChanged(object sender, EventArgs e)
		{
			rechnung_daf();
		}

		private void rechnung_daf()
		{
			double statistischer = Math.Round(ToDouble(AF.Gesamtpreis));
			maskedTextBox5.Text = statistischer.ToString();
			rechnungspreis_aktuell();
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			if (zeit2 > -1)
			{
				if (zeit2 % 2 == 0)
				{
					radioButton_add.ForeColor = Color.Red;
					radioButton_rem.ForeColor = Color.Red;
					radioButton_daf.ForeColor = Color.Red;
				}
				else
				{
					radioButton_add.ForeColor = Color.Black;
					radioButton_rem.ForeColor = Color.Black;
					radioButton_daf.ForeColor = Color.Black;
				}
				zeit2--;
			}
			else
			{
				timer2.Enabled = false;
				radioButton_add.ForeColor = Color.Black;
				radioButton_rem.ForeColor = Color.Black;
				radioButton_daf.ForeColor = Color.Black;
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImpulsExport.Zollexport));
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.maskedTextBox5 = new System.Windows.Forms.MaskedTextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.maskedTextBox6 = new System.Windows.Forms.MaskedTextBox();
			this.radioButton_add = new System.Windows.Forms.RadioButton();
			this.radioButton_rem = new System.Windows.Forms.RadioButton();
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.radioButton_daf = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)this.dataGridView1).BeginInit();
			base.SuspendLayout();
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(735, 40);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(120, 95);
			this.listBox1.TabIndex = 1;
			this.button1.Location = new System.Drawing.Point(677, 66);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(52, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = ">>";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(button1_Click);
			this.textBox2.Location = new System.Drawing.Point(12, 40);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(310, 95);
			this.textBox2.TabIndex = 4;
			this.textBox3.Location = new System.Drawing.Point(329, 40);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(342, 95);
			this.textBox3.TabIndex = 5;
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridView1.Location = new System.Drawing.Point(12, 167);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(843, 413);
			this.dataGridView1.TabIndex = 6;
			this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
			this.textBox4.Location = new System.Drawing.Point(12, 483);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(843, 76);
			this.textBox4.TabIndex = 7;
			this.textBox4.Visible = false;
			this.button4.Location = new System.Drawing.Point(780, 596);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 9;
			this.button4.Text = "Export";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(button4_Click);
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Empfänger";
			this.maskedTextBox1.Location = new System.Drawing.Point(673, 40);
			this.maskedTextBox1.Mask = "00000099";
			this.maskedTextBox1.Name = "maskedTextBox1";
			this.maskedTextBox1.Size = new System.Drawing.Size(56, 20);
			this.maskedTextBox1.TabIndex = 0;
			this.maskedTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(maskedTextBox1_KeyDown);
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(674, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(99, 13);
			this.label2.TabIndex = 13;
			this.label2.Text = "Rechnungsnummer";
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 148);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "Positionen";
			this.maskedTextBox2.Location = new System.Drawing.Point(740, 586);
			this.maskedTextBox2.Mask = "099";
			this.maskedTextBox2.Name = "maskedTextBox2";
			this.maskedTextBox2.Size = new System.Drawing.Size(24, 20);
			this.maskedTextBox2.TabIndex = 15;
			this.maskedTextBox2.Text = "1";
			this.maskedTextBox2.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(maskedTextBox2_MaskInputRejected);
			this.maskedTextBox2.Leave += new System.EventHandler(maskedTextBox2_Leave);
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(656, 589);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(78, 13);
			this.label4.TabIndex = 16;
			this.label4.Text = "Anzahl Kartons";
			this.button2.Location = new System.Drawing.Point(76, 12);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(95, 23);
			this.button2.TabIndex = 19;
			this.button2.Text = "Lieferanschrift";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Visible = false;
			this.button2.Click += new System.EventHandler(button2_Click);
			this.button3.Enabled = false;
			this.button3.Location = new System.Drawing.Point(177, 12);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(95, 23);
			this.button3.TabIndex = 20;
			this.button3.Text = "Kundenanschrift";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Visible = false;
			this.button3.Click += new System.EventHandler(button3_Click);
			this.button5.Enabled = false;
			this.button5.Location = new System.Drawing.Point(278, 12);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(95, 23);
			this.button5.TabIndex = 21;
			this.button5.Text = "Auftragsanschrift";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Visible = false;
			this.button5.Click += new System.EventHandler(button5_Click);
			this.button6.Location = new System.Drawing.Point(12, 605);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(134, 23);
			this.button6.TabIndex = 22;
			this.button6.Text = "Tabellenupdate";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Visible = false;
			this.button6.Click += new System.EventHandler(button6_Click);
			this.button7.Location = new System.Drawing.Point(24, 454);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(134, 23);
			this.button7.TabIndex = 23;
			this.button7.Text = "Zusammenfassen";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Visible = false;
			this.button7.Click += new System.EventHandler(button7_Click);
			this.maskedTextBox3.Location = new System.Drawing.Point(740, 608);
			this.maskedTextBox3.Mask = "099";
			this.maskedTextBox3.Name = "maskedTextBox3";
			this.maskedTextBox3.Size = new System.Drawing.Size(24, 20);
			this.maskedTextBox3.TabIndex = 24;
			this.maskedTextBox3.Text = "0";
			this.maskedTextBox3.Leave += new System.EventHandler(maskedTextBox3_Leave);
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(656, 611);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(81, 13);
			this.label5.TabIndex = 25;
			this.label5.Text = "Anzahl Paletten";
			this.button8.Location = new System.Drawing.Point(481, 12);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(95, 23);
			this.button8.TabIndex = 1;
			this.button8.Text = "Neu";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(button8_Click);
			this.button9.Location = new System.Drawing.Point(118, 596);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(120, 23);
			this.button9.TabIndex = 27;
			this.button9.Text = "Warennummer zus.";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Visible = false;
			this.button9.Click += new System.EventHandler(button9_Click);
			this.button10.Location = new System.Drawing.Point(12, 596);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(81, 23);
			this.button10.TabIndex = 28;
			this.button10.Text = "Einstellungen";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(button10_Click);
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = System.Drawing.Color.Firebrick;
			this.label6.Location = new System.Drawing.Point(330, 138);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(525, 24);
			this.label6.TabIndex = 29;
			this.label6.Text = "Achtung Ansprechpartner in Einstellungen hinterlegen!";
			this.label6.Visible = false;
			this.timer1.Interval = 500;
			this.timer1.Tick += new System.EventHandler(timer1_Tick);
			this.maskedTextBox5.Enabled = false;
			this.maskedTextBox5.Location = new System.Drawing.Point(432, 586);
			this.maskedTextBox5.Name = "maskedTextBox5";
			this.maskedTextBox5.Size = new System.Drawing.Size(71, 20);
			this.maskedTextBox5.TabIndex = 32;
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(364, 589);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(62, 13);
			this.label8.TabIndex = 33;
			this.label8.Text = "Statis. Wert";
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(345, 611);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(84, 13);
			this.label9.TabIndex = 34;
			this.label9.Text = "Rechnungspreis";
			this.maskedTextBox6.Enabled = false;
			this.maskedTextBox6.Location = new System.Drawing.Point(432, 608);
			this.maskedTextBox6.Name = "maskedTextBox6";
			this.maskedTextBox6.Size = new System.Drawing.Size(71, 20);
			this.maskedTextBox6.TabIndex = 35;
			this.radioButton_add.AutoSize = true;
			this.radioButton_add.Enabled = false;
			this.radioButton_add.Location = new System.Drawing.Point(520, 589);
			this.radioButton_add.Name = "radioButton_add";
			this.radioButton_add.Size = new System.Drawing.Size(116, 17);
			this.radioButton_add.TabIndex = 36;
			this.radioButton_add.TabStop = true;
			this.radioButton_add.Text = "+ Stat. Wert (EXW)";
			this.radioButton_add.UseVisualStyleBackColor = true;
			this.radioButton_add.CheckedChanged += new System.EventHandler(radioButton_add_CheckedChanged);
			this.radioButton_rem.AutoSize = true;
			this.radioButton_rem.Enabled = false;
			this.radioButton_rem.Location = new System.Drawing.Point(520, 609);
			this.radioButton_rem.Name = "radioButton_rem";
			this.radioButton_rem.Size = new System.Drawing.Size(127, 17);
			this.radioButton_rem.TabIndex = 37;
			this.radioButton_rem.TabStop = true;
			this.radioButton_rem.Text = "+ Versandkost. (DAP)";
			this.radioButton_rem.UseVisualStyleBackColor = true;
			this.radioButton_rem.CheckedChanged += new System.EventHandler(radioButton_rem_CheckedChanged);
			this.timer2.Interval = 500;
			this.timer2.Tick += new System.EventHandler(timer2_Tick);
			this.radioButton_daf.AutoSize = true;
			this.radioButton_daf.Enabled = false;
			this.radioButton_daf.Location = new System.Drawing.Point(244, 602);
			this.radioButton_daf.Name = "radioButton_daf";
			this.radioButton_daf.Size = new System.Drawing.Size(61, 17);
			this.radioButton_daf.TabIndex = 38;
			this.radioButton_daf.TabStop = true;
			this.radioButton_daf.Text = "= (DAF)";
			this.radioButton_daf.UseVisualStyleBackColor = true;
			this.radioButton_daf.Visible = false;
			this.radioButton_daf.CheckedChanged += new System.EventHandler(radioButton_daf_CheckedChanged);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(867, 630);
			base.Controls.Add(this.radioButton_daf);
			base.Controls.Add(this.radioButton_rem);
			base.Controls.Add(this.radioButton_add);
			base.Controls.Add(this.maskedTextBox6);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.maskedTextBox5);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.button10);
			base.Controls.Add(this.button9);
			base.Controls.Add(this.button8);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.maskedTextBox3);
			base.Controls.Add(this.button7);
			base.Controls.Add(this.button6);
			base.Controls.Add(this.button5);
			base.Controls.Add(this.button3);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.maskedTextBox2);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.maskedTextBox1);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.button4);
			base.Controls.Add(this.textBox4);
			base.Controls.Add(this.dataGridView1);
			base.Controls.Add(this.textBox3);
			base.Controls.Add(this.textBox2);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.listBox1);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Zollexport";
			this.Text = "Zollexport";
			base.Load += new System.EventHandler(Form1_Load);
			((System.ComponentModel.ISupportInitialize)this.dataGridView1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
