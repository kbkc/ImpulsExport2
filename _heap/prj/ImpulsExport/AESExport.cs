using System;
using System.Configuration;
using System.Xml;
using ImpulsExport.Properties;

namespace ImpulsExport
{
	internal class AESExport
	{
		public AESExport(ref Ausfuhranmeldung AF, string name)
		{
			string walds2 = "Weil am Rhein";
			string kiel2 = "Kiel-Wik";
			string stgt2 = "Stuttgart Flughafen";
			string ort = "DE003305";
			string ort2 = "";
			string art = "33";
			string verkehrszweig = "3";
			string art2 = "40";
			string verkehrszweig2 = "4";
			XmlDocument doc = new XmlDocument();
			XmlNode myRoot = doc.CreateElement("AES.net_AE");
			doc.AppendChild(myRoot);
			XmlNode myNachricht = doc.CreateElement("NACHRICHT");
			myRoot.AppendChild(myNachricht);
			XmlNode myNodeKopf = doc.CreateElement("KOPF");
			myNachricht.AppendChild(myNodeKopf);
			XmlNode myNodeElement = doc.CreateElement("Anmeldungsart_Verfahren");
			myNodeElement.InnerText = "AM";
			myNodeKopf.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Anmeldungsart_Ueberfuehrung");
			myNodeElement.InnerText = AF.Anmeldungsart_Ueberfuehrung;
			myNodeKopf.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Ausfuhrland");
			myNodeElement.InnerText = Settings.Default.Ausfuhrland;
			myNodeKopf.AppendChild(myNodeElement);
			string Postiso = ConfigurationSettings.AppSettings["PostIso"];
			string[] Postisoone = Postiso.Split(',');
			string[] array = Postisoone;
			foreach (string postisotmp in array)
			{
				if (AF.EMNOW_Land == postisotmp.Split('-')[0])
				{
					AF.EMNOW_Land = postisotmp.Split('-')[1];
				}
			}
			myNodeElement = doc.CreateElement("Bestimmungsland");
			myNodeElement.InnerText = AF.EMNOW_Land;
			myNodeKopf.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Zeitpunkt_der_Anmeldung");
			myNodeElement.InnerText = AF.Zeitpunkt_der_Anmeldung;
			myNodeKopf.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Statistische_Meldung");
			myNodeElement.InnerText = "0";
			myNodeKopf.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Beteiligtenkonstellation");
			myNodeElement.InnerText = Settings.Default.Beteiligtenkonst;
			myNodeKopf.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Adressatenkonstellation");
			myNodeElement.InnerText = "2";
			myNodeKopf.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Gesamtrohmasse");
			myNodeElement.InnerText = AF.Gesamtrohmasse + " kg";
			myNodeKopf.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Kennnummer_der_Sendung");
			myNodeElement.InnerText = AF.Bezugsnummer.Split(' ')[0];
			myNodeKopf.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Bezugsnummer");
			myNodeElement.InnerText = AF.Bezugsnummer.Split(' ')[0];
			myNodeKopf.AppendChild(myNodeElement);
			XmlNode myBefoer = doc.CreateElement("BEFOERDERUNGSMITTEL");
			myNachricht.AppendChild(myBefoer);
			XmlNode myBefoer2 = doc.CreateElement("INLAND");
			myBefoer.AppendChild(myBefoer2);
			myNodeElement = doc.CreateElement("Verkehrszweig");
			myNodeElement.InnerText = Settings.Default.Verkehrszweig;
			myBefoer2.AppendChild(myNodeElement);
			myBefoer2 = doc.CreateElement("GRENZE");
			myBefoer.AppendChild(myBefoer2);
			switch (AF.EMNOW_Land)
			{
			case "CH":
				myNodeElement = doc.CreateElement("Verkehrszweig");
				myNodeElement.InnerText = verkehrszweig;
				myBefoer2.AppendChild(myNodeElement);
				myNodeElement = doc.CreateElement("Art");
				myNodeElement.InnerText = art;
				myBefoer2.AppendChild(myNodeElement);
				ort2 = walds2;
				break;
			case "US":
				myNodeElement = doc.CreateElement("Verkehrszweig");
				myNodeElement.InnerText = verkehrszweig2;
				myBefoer2.AppendChild(myNodeElement);
				myNodeElement = doc.CreateElement("Art");
				myNodeElement.InnerText = art2;
				myBefoer2.AppendChild(myNodeElement);
				ort2 = stgt2;
				break;
			case "CA":
				myNodeElement = doc.CreateElement("Verkehrszweig");
				myNodeElement.InnerText = verkehrszweig2;
				myBefoer2.AppendChild(myNodeElement);
				myNodeElement = doc.CreateElement("Art");
				myNodeElement.InnerText = art2;
				myBefoer2.AppendChild(myNodeElement);
				ort2 = stgt2;
				break;
			case "RU":
				myNodeElement = doc.CreateElement("Verkehrszweig");
				myNodeElement.InnerText = verkehrszweig2;
				myBefoer2.AppendChild(myNodeElement);
				myNodeElement = doc.CreateElement("Art");
				myNodeElement.InnerText = art2;
				myBefoer2.AppendChild(myNodeElement);
				ort2 = stgt2;
				break;
			case "TW":
				myNodeElement = doc.CreateElement("Verkehrszweig");
				myNodeElement.InnerText = verkehrszweig2;
				myBefoer2.AppendChild(myNodeElement);
				myNodeElement = doc.CreateElement("Art");
				myNodeElement.InnerText = art2;
				myBefoer2.AppendChild(myNodeElement);
				ort2 = stgt2;
				break;
			case "JP":
				myNodeElement = doc.CreateElement("Verkehrszweig");
				myNodeElement.InnerText = verkehrszweig2;
				myBefoer2.AppendChild(myNodeElement);
				myNodeElement = doc.CreateElement("Art");
				myNodeElement.InnerText = art2;
				myBefoer2.AppendChild(myNodeElement);
				ort2 = stgt2;
				break;
			case "UA":
				myNodeElement = doc.CreateElement("Verkehrszweig");
				myNodeElement.InnerText = verkehrszweig2;
				myBefoer2.AppendChild(myNodeElement);
				myNodeElement = doc.CreateElement("Art");
				myNodeElement.InnerText = art2;
				myBefoer2.AppendChild(myNodeElement);
				ort2 = stgt2;
				break;
			case "NO":
				myNodeElement = doc.CreateElement("Verkehrszweig");
				myNodeElement.InnerText = verkehrszweig;
				myBefoer2.AppendChild(myNodeElement);
				myNodeElement = doc.CreateElement("Art");
				myNodeElement.InnerText = art;
				myBefoer2.AppendChild(myNodeElement);
				ort2 = kiel2;
				break;
			}
			myNodeElement = doc.CreateElement("Staatszugehoerigkeit");
			myNodeElement.InnerText = Settings.Default.Staatszugeh;
			myBefoer2.AppendChild(myNodeElement);
			XmlNode myNode = doc.CreateElement("LADEORT");
			myNachricht.AppendChild(myNode);
			myNodeElement = doc.CreateElement("Strasse");
			myNodeElement.InnerText = Settings.Default.Lade_Strasse;
			myNode.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("PLZ");
			myNodeElement.InnerText = Settings.Default.Lade_PLZ;
			myNode.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Ort");
			myNodeElement.InnerText = Settings.Default.Lade_Ort;
			myNode.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Zusatz");
			myNodeElement.InnerText = Settings.Default.Lade_Zusatz;
			myNode.AppendChild(myNodeElement);
			XmlNode myZoll = doc.CreateElement("ZOLLSTELLEN");
			myNachricht.AppendChild(myZoll);
			myNodeElement = doc.CreateElement("Ausfuhr_Zollstelle");
			myNodeElement.InnerText = Settings.Default.Ausfuhr_Zollstelle;
			myZoll.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Vorgesehene_Ausgangzollstelle");
			myNodeElement.InnerText = ort;
			myZoll.AppendChild(myNodeElement);
			XmlNode myGesch = doc.CreateElement("GESCHAEFTSVORGANG");
			myNachricht.AppendChild(myGesch);
			myNodeElement = doc.CreateElement("Art");
			myNodeElement.InnerText = Settings.Default.Art;
			myGesch.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Rechnungspreis");
			myNodeElement.InnerText = AF.rechnungbrutto;
			myGesch.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Waehrung");
			myNodeElement.InnerText = Settings.Default.Waehrung;
			myGesch.AppendChild(myNodeElement);
			XmlNode myGest = doc.CreateElement("GESTELLUNG");
			myNachricht.AppendChild(myGest);
			myNodeElement = doc.CreateElement("Anfang");
			string text = DateTime.Now.DayOfWeek.ToString();
			string text2 = text;
			if (!(text2 == "Friday"))
			{
				if (text2 == "Saturday")
				{
					myNodeElement.InnerText = DateTime.Now.AddDays(2.0).ToShortDateString() + " 08:00";
				}
				else
				{
					myNodeElement.InnerText = DateTime.Now.AddDays(1.0).ToShortDateString() + " 08:00";
				}
			}
			else
			{
				myNodeElement.InnerText = DateTime.Now.AddDays(3.0).ToShortDateString() + " 08:00";
			}
			myGest.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Ende");
			string text3 = DateTime.Now.DayOfWeek.ToString();
			string text4 = text3;
			if (!(text4 == "Friday"))
			{
				if (text4 == "Saturday")
				{
					myNodeElement.InnerText = DateTime.Now.AddDays(2.0).ToShortDateString() + " 10:00";
				}
				else
				{
					myNodeElement.InnerText = DateTime.Now.AddDays(1.0).ToShortDateString() + " 10:00";
				}
			}
			else
			{
				myNodeElement.InnerText = DateTime.Now.AddDays(3.0).ToShortDateString() + " 10:00";
			}
			myGest.AppendChild(myNodeElement);
			XmlNode myAnm = doc.CreateElement("ANMELDER");
			myNachricht.AppendChild(myAnm);
			myNodeElement = doc.CreateElement("TIN");
			myNodeElement.InnerText = Settings.Default.TIN;
			myAnm.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Niederlassungsnummer");
			myNodeElement.InnerText = "0000";
			myAnm.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Name");
			myNodeElement.InnerText = Settings.Default.Firma;
			myAnm.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Strasse");
			myNodeElement.InnerText = Settings.Default.Strasse;
			myAnm.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Ort");
			myNodeElement.InnerText = Settings.Default.Ort;
			myAnm.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("PLZ");
			myNodeElement.InnerText = Settings.Default.PLZ;
			myAnm.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Land");
			myNodeElement.InnerText = Settings.Default.Land;
			myAnm.AppendChild(myNodeElement);
			XmlNode myAnsp = doc.CreateElement("ANSPRECHPARTNER");
			myAnm.AppendChild(myAnsp);
			myNodeElement = doc.CreateElement("Stellung");
			myNodeElement.InnerText = Settings.Default.Stellenbeschreibung;
			myAnsp.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Sachbearbeiter");
			myNodeElement.InnerText = Settings.Default.Name;
			myAnsp.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Telefon_Nummer");
			myNodeElement.InnerText = Settings.Default.Telefon;
			myAnsp.AppendChild(myNodeElement);
			XmlNode myNodeEmpfänger = doc.CreateElement("EMPFAENGER");
			myNachricht.AppendChild(myNodeEmpfänger);
			myNodeElement = doc.CreateElement("Name");
			myNodeElement.InnerText = AF.EMNOW_Name;
			myNodeEmpfänger.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Strasse");
			myNodeElement.InnerText = AF.EMNOW_Strasse;
			myNodeEmpfänger.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Ort");
			myNodeElement.InnerText = AF.EMNOW_Ort;
			myNodeEmpfänger.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("PLZ");
			myNodeElement.InnerText = AF.EMNOW_PLZ;
			myNodeEmpfänger.AppendChild(myNodeElement);
			myNodeElement = doc.CreateElement("Land");
			myNodeElement.InnerText = AF.EMNOW_Land;
			myNodeEmpfänger.AppendChild(myNodeElement);
			if (name == "exw")
			{
				XmlNode myLiefer = doc.CreateElement("LIEFERBEDINGUNG");
				myNachricht.AppendChild(myLiefer);
				myNodeElement = doc.CreateElement("Kodierung");
				myNodeElement.InnerText = "EXW";
				myLiefer.AppendChild(myNodeElement);
				myNodeElement = doc.CreateElement("Ort");
				myNodeElement.InnerText = Settings.Default.Lade_Ort;
				myLiefer.AppendChild(myNodeElement);
			}
			if (name == "dap")
			{
				XmlNode myLiefer = doc.CreateElement("LIEFERBEDINGUNG");
				myNachricht.AppendChild(myLiefer);
				myNodeElement = doc.CreateElement("Kodierung");
				myNodeElement.InnerText = "DAP";
				myLiefer.AppendChild(myNodeElement);
				myNodeElement = doc.CreateElement("Ort");
				myNodeElement.InnerText = ort2;
				myLiefer.AppendChild(myNodeElement);
			}
			if (name == "daf")
			{
				XmlNode myLiefer = doc.CreateElement("LIEFERBEDINGUNG");
				myNachricht.AppendChild(myLiefer);
				myNodeElement = doc.CreateElement("Kodierung");
				myNodeElement.InnerText = "DAF";
				myLiefer.AppendChild(myNodeElement);
				myNodeElement = doc.CreateElement("Ort");
				myNodeElement.InnerText = ort2;
				myLiefer.AppendChild(myNodeElement);
			}
			int firstpos = 1;
			foreach (Rechnung tmprec in AF.Rechnungen)
			{
				foreach (Ausfuhrposition tmppos in tmprec.Positionsliste)
				{
					XmlNode myNodeTop = doc.CreateElement("WARE");
					myNachricht.AppendChild(myNodeTop);
					XmlNode myNodeSub = doc.CreateElement("WARENKENNZEICHNUNG");
					myNodeTop.AppendChild(myNodeSub);
					myNodeElement = doc.CreateElement("Nummer_KN8");
					myNodeElement.InnerText = tmppos.Warennummer;
					myNodeSub.AppendChild(myNodeElement);
					myNodeSub = doc.CreateElement("ZUSAETZLICHE");
					myNodeTop.AppendChild(myNodeSub);
					myNodeElement = doc.CreateElement("Warenbezeichnung");
					if (firstpos == 1)
					{
						myNodeElement.InnerText = tmppos.Menge + " Stück " + tmppos.Warenbezeichnung;
					}
					else
					{
						myNodeElement.InnerText = tmppos.Menge + " Stück " + tmppos.Warenbezeichnung;
					}
					myNodeSub.AppendChild(myNodeElement);
					myNodeElement = doc.CreateElement("Ursprungsbundesland");
					myNodeElement.InnerText = tmppos.Ursprungscode;
					myNodeSub.AppendChild(myNodeElement);
					myNodeElement = doc.CreateElement("Eigenmasse");
					if (tmppos.Rohmasse.StartsWith(","))
					{
						tmppos.Rohmasse = "0" + tmppos.Rohmasse;
					}
					tmppos.Rohmasse = tmppos.Rohmasse.Replace(",", ".");
					myNodeElement.InnerText = string.Concat(tmppos.Rohmasse);
					myNodeSub.AppendChild(myNodeElement);
					if (firstpos == 1)
					{
						myNodeElement = doc.CreateElement("Rohmasse");
						AF.GesamtrohmasseoK = AF.GesamtrohmasseoK.Replace(",", ".");
						myNodeElement.InnerText = string.Concat(AF.GesamtrohmasseoK);
						myNodeSub.AppendChild(myNodeElement);
					}
					else
					{
						myNodeElement = doc.CreateElement("Rohmasse");
						myNodeElement.InnerText = "0";
						myNodeSub.AppendChild(myNodeElement);
					}
					myNodeSub = doc.CreateElement("VERFAHREN");
					myNodeTop.AppendChild(myNodeSub);
					myNodeElement = doc.CreateElement("angemeldetes");
					myNodeElement.InnerText = "10";
					myNodeSub.AppendChild(myNodeElement);
					myNodeElement = doc.CreateElement("vorangegangenes");
					myNodeElement.InnerText = "00";
					myNodeSub.AppendChild(myNodeElement);
					myNodeSub = doc.CreateElement("AUSSENHANDELSSTATISTIK");
					myNodeTop.AppendChild(myNodeSub);
					if (tmppos.hat_BM)
					{
						myNodeElement = doc.CreateElement("Menge");
						myNodeElement.InnerText = tmppos.BMass;
						myNodeSub.AppendChild(myNodeElement);
					}
					myNodeElement = doc.CreateElement("Wert");
					if (name == "dap" || name == "daf")
					{
						myNodeElement.InnerText = tmppos.Statistischer_Wert;
					}
					else if (name == "exw")
					{
						double temp = Zollexport.ToDouble(tmppos.Statistischer_Wert);
						double tempb = Math.Round(temp / 100.0 * (double)Settings.Default.statistischer);
						myNodeElement.InnerText = (temp + tempb).ToString();
					}
					myNodeSub.AppendChild(myNodeElement);
					if (firstpos == 1)
					{
						myNodeSub = doc.CreateElement("PACKSTUECK");
						myNodeTop.AppendChild(myNodeSub);
						myNodeElement = doc.CreateElement("Anzahl");
						myNodeElement.InnerText = AF.Anzahl_Kartons;
						myNodeSub.AppendChild(myNodeElement);
						myNodeElement = doc.CreateElement("Verpackungsart");
						myNodeElement.InnerText = "CT";
						myNodeSub.AppendChild(myNodeElement);
						myNodeElement = doc.CreateElement("Zeichen_Nummern");
						myNodeElement.InnerText = "1-" + AF.Anzahl_Kartons.ToString();
						myNodeSub.AppendChild(myNodeElement);
						myNodeSub = doc.CreateElement("UNTERLAGE");
						myNodeTop.AppendChild(myNodeSub);
						myNodeElement = doc.CreateElement("Typ");
						myNodeElement.InnerText = "N862";
						myNodeSub.AppendChild(myNodeElement);
					}
					else
					{
						myNodeSub = doc.CreateElement("PACKSTUECK");
						myNodeTop.AppendChild(myNodeSub);
						myNodeElement = doc.CreateElement("Anzahl");
						myNodeElement.InnerText = "0";
						myNodeSub.AppendChild(myNodeElement);
						myNodeElement = doc.CreateElement("Verpackungsart");
						myNodeElement.InnerText = "CT";
						myNodeSub.AppendChild(myNodeElement);
						myNodeElement = doc.CreateElement("Zeichen_Nummern");
						myNodeElement.InnerText = "1-" + AF.Anzahl_Kartons.ToString();
						myNodeSub.AppendChild(myNodeElement);
					}
					firstpos = 0;
				}
			}
			doc.Save(ConfigurationSettings.AppSettings["AESImportPfad"] + "\\test.xml");
		}
	}
}
