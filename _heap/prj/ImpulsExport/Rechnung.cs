using System.Collections.Generic;

namespace ImpulsExport
{
	internal class Rechnung
	{
		public int rechnungsnummer;

		public List<int> lsid = new List<int>();

		public int auid;

		public int kversandid;

		public int lversandid;

		public double frachtkost;

		public string rechnungbrutto;

		public List<Ausfuhrposition> Positionsliste = new List<Ausfuhrposition>();

		public Anschrift kAnschrift = new Anschrift();

		public Anschrift lAnschrift = new Anschrift();

		public Anschrift aAnschrift = new Anschrift();

		public bool has_kAnschrift;

		public bool has_lAnschrift;

		public bool has_aAnschrift;

		public int lese_kopfdaten()
		{
			DBConn conn = new DBConn();
			lsid = conn.getLsId_by_RN(rechnungsnummer);
			auid = conn.getAuID_by_RN(rechnungsnummer);
			if (auid == 0)
			{
				return 0;
			}
			frachtkost = conn.frachtkosten(rechnungsnummer);
			rechnungbrutto = conn.rechnungbrutto(rechnungsnummer);
			if (conn.get_aAnschrift_by_auid(auid, ref aAnschrift) == 0)
			{
				has_aAnschrift = true;
			}
			else
			{
				has_aAnschrift = false;
			}
			return 0;
		}

		public int lese_positionsdaten()
		{
			DBConn conn = new DBConn();
			conn.getpos_by_lsid(lsid, ref Positionsliste, auid);
			return 0;
		}

		public Rechnung(int rn)
		{
			rechnungsnummer = rn;
			lese_kopfdaten();
			lese_positionsdaten();
		}

		~Rechnung()
		{
		}
	}
}
