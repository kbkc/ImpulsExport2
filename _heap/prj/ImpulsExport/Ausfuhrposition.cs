using System;
using System.Configuration;
using System.Globalization;

namespace ImpulsExport
{
	internal class Ausfuhrposition
	{
		public string Warennummer;

		public string Ursprungsland;

		public string Ursprungscode = "08";

		public string Rohmasse;

		public string Eigenmasse;

		public string Verfahren = "1000";

		public string Statistischer_Wert;

		public string Warenbezeichnung;

		public int Artikelid;

		public string Preis;

		public string BMass;

		public string Menge;

		public int AuftragPosID;

		public int PosID;

		public bool hat_BM;

		public bool editiert = false;

		public string Artikelnummer;

		public int auid;

		private int fill_pos_data(int lsid, int auid)
		{
			DBConn conn = new DBConn();
			conn.getposinfo_by_posid(ref Artikelnummer, lsid, AuftragPosID, ref Artikelid, ref Warennummer, ref Ursprungsland, ref Ursprungscode, ref Rohmasse, ref Eigenmasse, ref Verfahren, ref Statistischer_Wert, ref Warenbezeichnung, ref Preis, ref PosID, ref Menge, auid);
			Preis = Preis.Replace(".", ",");
			Rohmasse = Rohmasse.Replace(".", ",");
			Statistischer_Wert = Math.Round(ToDouble(Preis)).ToString();
			conn.dbclose();
			string WN_ohne = ConfigurationSettings.AppSettings["Nobm_Warennummern"];
			if (WN_ohne.Contains(Warennummer))
			{
				BMass = "";
				hat_BM = false;
			}
			else
			{
				BMass = Menge;
				hat_BM = true;
			}
			return 0;
		}

		public Ausfuhrposition(int posid, int lsid, string[,] Posis, int auid)
		{
			if (posid == -1)
			{
				Warennummer = Posis[lsid, 16];
				Ursprungsland = Posis[lsid, 13];
				Ursprungscode = Posis[lsid, 12];
				Rohmasse = Posis[lsid, 10];
				Eigenmasse = Posis[lsid, 5];
				Verfahren = Posis[lsid, 14];
				Statistischer_Wert = Posis[lsid, 11];
				Warenbezeichnung = Posis[lsid, 15];
				Artikelid = Convert.ToInt32(Posis[lsid, 0]);
				Preis = Posis[lsid, 9];
				BMass = Posis[lsid, 3];
				Menge = Posis[lsid, 7];
				AuftragPosID = Convert.ToInt32(Posis[lsid, 2]);
				PosID = Convert.ToInt32(Posis[lsid, 8]);
				hat_BM = Convert.ToBoolean(Posis[lsid, 6]);
				editiert = true;
				Artikelnummer = Posis[lsid, 1];
			}
			else
			{
				AuftragPosID = posid;
				fill_pos_data(lsid, auid);
			}
		}

		public static double ToDouble(string In)
		{
			In = In.Replace(",", ".");
			return double.Parse(In, CultureInfo.InvariantCulture);
		}
	}
}
