using System;
using System.Collections.Generic;

namespace ImpulsExport
{
	internal class Ausfuhranmeldung
	{
		public List<Rechnung> Rechnungen;

		public string Zeitpunkt_der_Anmeldung;

		public string Anmeldungsart_Ausfuhr;

		public string Anmeldungsart_Ueberfuehrung = "c";

		public string Beteiligtenkonstellation = "0000";

		public string Herkunftsland = "DE";

		public string Sendnugsnummer;

		public string Bezugsnummer;

		public string Bewilligungsnummer;

		public string Registriernummer;

		public string Vermerk;

		public string Gesamtrohmasse;

		public string GesamtrohmasseoK;

		public string Gesamtpreis;

		public double Frachtkosten;

		public string rechnungbrutto;

		public string Anzahl_Kartons = "1";

		public string Anzahl_Paletten = "0";

		public string EMK_TIN;

		public string EMK_Name;

		public string EMK_Strasse;

		public string EMK_Ort;

		public string EMK_PLZ;

		public string EMK_Land;

		public string EML_TIN;

		public string EML_Name;

		public string EML_Strasse;

		public string EML_Ort;

		public string EML_PLZ;

		public string EML_Land;

		public string EMNOW_TIN;

		public string EMNOW_Name;

		public string EMNOW_Strasse;

		public string EMNOW_Ort;

		public string EMNOW_PLZ;

		public string EMNOW_Land;

		public string EMA_TIN;

		public string EMA_Name;

		public string EMA_Strasse;

		public string EMA_Ort;

		public string EMA_PLZ;

		public string EMA_Land;

		public string AN_TIN;

		public string AN_Ist_Deutsche_Zollnummer;

		public string AN_Name;

		public string AN_Strasse;

		public string AN_Ort;

		public string AN_PLZ;

		public string AN_Land;

		public string AF_TIN;

		public string AF_Ist_Deutsche_Zollnummer;

		public string AF_Name;

		public string AF_Strasse;

		public string AF_Ort;

		public string AF_PLZ;

		public string AF_Land;

		public int addRechnung(int rn)
		{
			Rechnung newr;
			if (Rechnungen.Count == 0)
			{
				newr = new Rechnung(rn);
				if (newr.auid == 0)
				{
					return 1;
				}
				Zeitpunkt_der_Anmeldung = DateTime.Now.ToShortDateString();
				EMNOW_Name = EML_Name;
				EMNOW_Strasse = EML_Strasse;
				EMNOW_PLZ = EML_PLZ;
				EMNOW_Ort = EML_Ort;
				EMNOW_Land = EML_Land;
				EML_Name = newr.lAnschrift.Nachname;
				EML_Strasse = string.Concat(newr.lAnschrift.Strasse);
				EML_PLZ = string.Concat(newr.lAnschrift.PLZ);
				EML_Ort = string.Concat(newr.lAnschrift.Ort);
				EML_Land = string.Concat(newr.lAnschrift.Land);
				EMA_Name = newr.aAnschrift.Nachname;
				EMA_Strasse = string.Concat(newr.aAnschrift.Strasse);
				EMA_PLZ = string.Concat(newr.aAnschrift.PLZ);
				EMA_Ort = string.Concat(newr.aAnschrift.Ort);
				EMA_Land = string.Concat(newr.aAnschrift.Land);
				EMK_Name = newr.kAnschrift.Nachname;
				EMK_Strasse = string.Concat(newr.kAnschrift.Strasse);
				EMK_PLZ = string.Concat(newr.kAnschrift.PLZ);
				EMK_Ort = string.Concat(newr.kAnschrift.Ort);
				EMK_Land = string.Concat(newr.kAnschrift.Land);
				Frachtkosten = newr.frachtkost;
				rechnungbrutto = newr.rechnungbrutto;
			}
			else
			{
				newr = new Rechnung(rn);
			}
			if (newr.auid > 0)
			{
				Rechnungen.Add(newr);
				return 0;
			}
			return newr.rechnungsnummer;
		}

		public void Calc_Rohmasse()
		{
			double masse = 0.0;
			foreach (Rechnung tmprec in Rechnungen)
			{
				foreach (Ausfuhrposition tmppos in tmprec.Positionsliste)
				{
					masse += double.Parse(tmppos.Rohmasse);
				}
			}
			masse += double.Parse(Anzahl_Kartons) * 0.5;
			masse += double.Parse(Anzahl_Paletten) * 15.0;
			GesamtrohmasseoK = masse.ToString();
			Gesamtrohmasse = masse.ToString();
		}

		public void Calc_Preis()
		{
			double preis = 0.0;
			foreach (Rechnung tmprec in Rechnungen)
			{
				foreach (Ausfuhrposition tmppos in tmprec.Positionsliste)
				{
					preis += double.Parse(tmppos.Preis);
				}
			}
			Gesamtpreis = Math.Round(preis, 2).ToString();
			Gesamtpreis = Gesamtpreis.Replace(",", ".");
		}

		public void Calc_rechnungbrutto()
		{
			double preis = 0.0;
			foreach (Rechnung tmprec in Rechnungen)
			{
				preis += double.Parse(tmprec.rechnungbrutto);
			}
			rechnungbrutto = Math.Round(preis, 2).ToString();
			rechnungbrutto = rechnungbrutto.Replace(",", ".");
		}

		public void Calc_Fracht()
		{
			double fracht = 0.0;
			foreach (Rechnung tmprec in Rechnungen)
			{
				fracht += tmprec.frachtkost;
			}
			Frachtkosten = fracht;
		}

		public Ausfuhranmeldung()
		{
			Rechnungen = new List<Rechnung>();
		}

		~Ausfuhranmeldung()
		{
		}
	}
}
