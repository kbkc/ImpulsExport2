using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Text.RegularExpressions;

namespace ImpulsExport
{
	internal class DBConn
	{
		private OdbcConnection conn;

		public List<int> getLsId_by_RN(int rechnungsnummer)
		{
			List<int> lsid = new List<int>();
			OdbcCommand DbCommand = conn.CreateCommand();
			DbCommand.CommandText = string.Concat("select " + rechnungsnummer);
			OdbcDataReader DbReader = DbCommand.ExecuteReader();
			while (DbReader.Read())
			{
				lsid.Add(DbReader.GetInt32(0));
			}
			return lsid;
		}

		public string rechnungbrutto(int rechnungsnummer)
		{
			double rechnungbrutto = 0.0;
			OdbcCommand DbCommand = conn.CreateCommand();
			DbCommand.CommandText = string.Concat("SELECT doctotal  FROM OINV T0 WHERE T0.[DocNum] =" + rechnungsnummer);
			OdbcDataReader DbReader = DbCommand.ExecuteReader();
			while (DbReader.Read())
			{
				rechnungbrutto = DbReader.GetDouble(0);
			}
			return rechnungbrutto.ToString();
		}

		public double frachtkosten(int rechnungsnummer)
		{
			double fracht = 0.0;
			OdbcCommand DbCommand = conn.CreateCommand();
			DbCommand.CommandText = string.Concat("select coalesce(OINV.TotalExpns, 0) as Frachtkosten from OINV where OINV.DocNum=" + rechnungsnummer);
			OdbcDataReader DbReader = DbCommand.ExecuteReader();
			while (DbReader.Read())
			{
				fracht = DbReader.GetDouble(0);
			}
			return fracht;
		}

		public int getAuID_by_RN(int rechnungsnummer)
		{
			int auid = 0;
			OdbcCommand DbCommand = conn.CreateCommand();
			DbCommand.CommandText = string.Concat("select " + rechnungsnummer);
			OdbcDataReader DbReader = DbCommand.ExecuteReader();
			while (DbReader.Read())
			{
				auid = DbReader.GetInt32(0);
			}
			return auid;
		}

		public int get_KVersandID_by_LS(int lsid)
		{
			int kvid = 0;
			OdbcCommand DbCommand = conn.CreateCommand();
			DbCommand.CommandText = string.Concat("declare @docNum int, @cardCode varchar(30) set @docNum=" + lsid
				, " select top 1 @cardCode=CardCode " +
				"from ODLN " +
				"where ODLN.DocNum=@docNum " +
				"order by DocEntry desc if(@cardCode is NULL) " +
				"begin select top 1 @cardCode=CardCode " +
				"from OINV where OINV.DocNum=@docNum order by DocEntry desc " +
				"end select @cardCode as kunden_id");
			OdbcDataReader DbReader = DbCommand.ExecuteReader();
			DbReader.Read();
			return DbReader.GetInt32(0);
		}

		public int get_LVersandID_by_LS(int lsid)
		{
			int lvid = 0;
			OdbcCommand DbCommand = conn.CreateCommand();
			DbCommand.CommandText = string.Concat("declare @docNum int,@addresID int set @docNum=" + lsid
				, " select top 1 @addresID=(OCRD.DocEntry*100+CRD1.LineNum) " +
				"from OCRD join CRD1 on CRD1.CardCode=OCRD.CardCode and CRD1.AdresType='S' " +
				"join ODLN on ODLN.ShipToCode=CRD1.Address and ODLN.CardCode=CRD1.CardCode and ODLN.DocNum=@docNum " +
				"order by ODLN.DocEntry desc if(@addresID is NULL) " +
				"begin select top 1 @addresID=(OCRD.DocEntry*100+CRD1.LineNum) " +
				"from OCRD " +
				"join CRD1 on CRD1.CardCode=OCRD.CardCode and CRD1.AdresType='S' " +
				"join OINV on OINV.ShipToCode=CRD1.Address and OINV.CardCode=CRD1.CardCode and OINV.DocNum=@docNum " +
				"order by OINV.DocEntry desc " +
				"end " +
				"select @addresID as lieferschein_anschrift_id ");
			OdbcDataReader DbReader = DbCommand.ExecuteReader();
			DbReader.Read();
			if (!DbReader.IsDBNull(0))
			{
				return DbReader.GetInt32(0);
			}
			return 0;
		}

		public int get_lAnschrift_by_lversandid(int id, ref Anschrift lAnschrift)
		{
			OdbcCommand DbCommand = conn.CreateCommand();
			DbCommand.CommandText = string.Concat("declare @addresID int set @addresID=" + id + " " +
				"select top 1 OCRD.CardName as Vorname, OCRD.CardFName as Name, CRD1.Street as Strasse" +
				", CRD1.ZipCode as PLZ, CRD1.City as ORT, CRD1.Country as Plz_Zeichen " +
				"from OCRD left join CRD1 on CRD1.CardCode=OCRD.CardCode and CRD1.LineNum=(@addresID%100) " +
				"where OCRD.DocEntry=(@addresID/100)");
			OdbcDataReader DbReader = DbCommand.ExecuteReader();
			DbReader.Read();
			if (DbReader.HasRows)
			{
				if (!DbReader.IsDBNull(0))
				{
					lAnschrift.Vorname = DbReader.GetString(0);
				}
				if (!DbReader.IsDBNull(1))
				{
					lAnschrift.Nachname = DbReader.GetString(1);
				}
				if (!DbReader.IsDBNull(2))
				{
					lAnschrift.Strasse = DbReader.GetString(2);
				}
				if (!DbReader.IsDBNull(3))
				{
					lAnschrift.PLZ = DbReader.GetString(3);
				}
				if (!DbReader.IsDBNull(4))
				{
					lAnschrift.Ort = DbReader.GetString(4);
				}
				if (!DbReader.IsDBNull(5))
				{
					lAnschrift.Land = DbReader.GetString(5);
				}
				DbReader.Close();
				return 0;
			}
			DbReader.Close();
			return 1;
		}

		public int get_kAnschrift_by_kversandid(int id, ref Anschrift kAnschrift)
		{
			OdbcCommand DbCommand = conn.CreateCommand();
			DbCommand.CommandText = string.Concat("declare @cardCode varchar(30) set @cardCode=" + id 
				+ " select top 1 OCRD.CardName as Vorname, OCRD.CardFName as Name" +
				", CRD1.Street as Strasse, CRD1.ZipCode as PLZ, CRD1.City as ORT, CRD1.Country as Plz_Zeichen " +
				"from OCRD " +
				"left join CRD1 on CRD1.CardCode=OCRD.CardCode and (CRD1.Address=OCRD.ShipToDef or CRD1.Address=OCRD.BillToDef)" +
				" where OCRD.CardCode=@cardCode order by CRD1.AdresType desc");
			OdbcDataReader DbReader = DbCommand.ExecuteReader();
			DbReader.Read();
			if (DbReader.HasRows)
			{
				if (!DbReader.IsDBNull(0))
				{
					kAnschrift.Vorname = DbReader.GetString(0);
				}
				if (!DbReader.IsDBNull(1))
				{
					kAnschrift.Nachname = DbReader.GetString(1);
				}
				if (!DbReader.IsDBNull(2))
				{
					kAnschrift.Strasse = DbReader.GetString(2);
				}
				if (!DbReader.IsDBNull(3))
				{
					kAnschrift.PLZ = DbReader.GetString(3);
				}
				if (!DbReader.IsDBNull(4))
				{
					kAnschrift.Ort = DbReader.GetString(4);
				}
				if (!DbReader.IsDBNull(5))
				{
					kAnschrift.Land = DbReader.GetString(5);
				}
				DbReader.Close();
				return 0;
			}
			DbReader.Close();
			return 1;
		}

		public int get_aAnschrift_by_auid(int auid, ref Anschrift aAnschrift)
		{
			OdbcCommand DbCommand = conn.CreateCommand();
			DbCommand.CommandText = string.Concat("declare @docNum int set @docNum=" + auid 
				+ " select top 1 OINV.CardCode as KUNDEN_ID, OINV.CardName as KUNDEN_NAME" +
				", INV12.CountryB as LAND,INV12.ZipCodeB as PLZ,INV12.CityB ORT, StreetB as 'Strasse'  " +
				"into #Address " +
				"from OINV " +
				"left join INV12 on INV12.DocEntry=OINV.DocEntry " +
				"where OINV.DocNum=@docNum " +
				"update #Address " +
				"set LAND=OCRD.MailCountr " +
				"from OCRD " +
				"join #Address on #Address.KUNDEN_ID=OCRD.CardCode collate DATABASE_DEFAULT and #Address.LAND is NULL " +
				"update #Address " +
				"set PLZ=OCRD.MailZipCod " +
				"from OCRD " +
				"join #Address on #Address.KUNDEN_ID=OCRD.CardCode collate DATABASE_DEFAULT and #Address.PLZ is NULL " +
				"update #Address " +
				"set ORT=OCRD.MailCity " +
				"from OCRD " +
				"join #Address on #Address.KUNDEN_ID=OCRD.CardCode collate DATABASE_DEFAULT and #Address.ORT is NULL " +
				"select * from #Address drop table #Address");
			OdbcDataReader DbReader = DbCommand.ExecuteReader();
			DbReader.Read();
			if (DbReader.HasRows)
			{
				int tmpkunu = DbReader.GetInt32(0);
				aAnschrift.Vorname = "";
				if (!DbReader.IsDBNull(1))
				{
					aAnschrift.Nachname = DbReader.GetString(1);
				}
				if (!DbReader.IsDBNull(2))
				{
					aAnschrift.Land = DbReader.GetString(2);
				}
				if (!DbReader.IsDBNull(3))
				{
					aAnschrift.PLZ = DbReader.GetString(3);
				}
				if (!DbReader.IsDBNull(4))
				{
					aAnschrift.Ort = DbReader.GetString(4);
				}
				if (!DbReader.IsDBNull(5))
				{
					aAnschrift.Strasse = DbReader.GetString(5);
				}
				DbReader.Close();
				return 0;
			}
			DbReader.Close();
			return 1;
		}

		public int getpos_by_lsid(List<int> idlist, ref List<Ausfuhrposition> Positionen, int auid)
		{
			OdbcCommand DbCommand = conn.CreateCommand();
			foreach (int id in idlist)
			{
				DbCommand.CommandText = string.Concat("declare @docNum int set @docNum=" + id 
					+ " select INV1.LineNum as Auftrag_posi_ID from INV1 join OINV on OINV.DocEntry=INV1.DocEntry and OINV.DocNum=@docNum");
				OdbcDataReader DbReader = DbCommand.ExecuteReader();
				List<int> tmpids = new List<int>();
				while (DbReader.Read())
				{
					tmpids.Add(DbReader.GetInt32(0));
				}
				foreach (int aktpos in tmpids)
				{
					Ausfuhrposition Pos = new Ausfuhrposition(aktpos, id, new string[2, 2]
					{
						{ "1", "2" },
						{ "3", "4" }
					}, auid);
					if (Pos.Menge != "0")
					{
						Positionen.Add(Pos);
					}
				}
				DbReader.Close();
			}
			return 0;
		}

		private string RemoveDoubleSpaceCharacters(string text)
		{
			return Regex.Replace(text, "[ ]+", " ");
		}

		public int getposinfo_by_posid(ref string artnr, int lsid, int AuftragPosID, ref int Artikelid, ref string Warennummer, ref string Ursprungsland, ref string Ursprungscode, ref string Rohmasse, ref string Eigenmasse, ref string Verfahren, ref string Statistischer_Wert, ref string Warenbezeichnung, ref string Preis, ref int posid, ref string menge, int auid)
		{
			int tmpmenge = 0;
			double tmppreis = 0.0;
			double tmpgewicht = 0.0;
			ArrayList Groessenids = new ArrayList();
			OdbcCommand DbCommand = conn.CreateCommand();
			DbCommand.CommandText = string.Concat("declare @docNum int, @lineNum int set @docNum=" 
				+ auid + "set @lineNum=" + AuftragPosID + 
				"select INV1.ItemCode as Artikel_ID, INV1.Dscription as Bezeichnung, OITM.SWeight1 as Gewicht, INV1.Price as VK_Preis " +
				"from INV1 " +
				"join OINV on OINV.DocEntry=INV1.DocEntry and OINV.DocNum=@docNum " +
				"join OITM on OITM.ItemCode=INV1.ItemCode where INV1.LineNum=@lineNum");
			OdbcDataReader DbReader = DbCommand.ExecuteReader();
			DbReader.Read();
			string artikelid2 = DbReader.GetString(0);
			Warenbezeichnung = DbReader.GetString(1);
			Warenbezeichnung = RemoveDoubleSpaceCharacters(Warenbezeichnung);
			if (!DbReader.IsDBNull(2))
			{
				Rohmasse = Convert.ToString(DbReader.GetDecimal(2));
			}
			Preis = DbReader.GetString(3);
			DbReader.Close();
			DbCommand.CommandText = string.Concat("select ODCI.Code as Nr, OITM.ItemCode " +
				"from ODCI " +
				"join ITM10 on ITM10.ISCommCode=ODCI.AbsEntry " +
				"join OITM on OITM.ItemCode=ITM10.ItemCode and OITM.ItemCode='" + artikelid2 
				+ "' where ODCI.ConfType='C'");
			DbReader = DbCommand.ExecuteReader();
			DbReader.Read();
			artnr = DbReader.GetString(1);
			Warennummer = DbReader.GetString(0);
			artnr = DbReader.GetString(1);
			Warennummer = Warennummer.Replace(" ", "");
			DbReader.Close();
			DbCommand.CommandText = string.Concat("select " +
				"convert(varchar(30), INV1.DocEntry) +right('0000'+convert(varchar(4), INV1.LineNum), 4)  as id " +
				"from INV1 " +
				"join OINV on OINV.DocEntry=INV1.DocEntry and OINV.DocNum=" + lsid + " where INV1.LineNum=" + AuftragPosID);
			DbReader = DbCommand.ExecuteReader();
			DbReader.Read();
			posid = DbReader.GetInt32(0);
			DbReader.Close();
			DbCommand.CommandText = string.Concat("declare @id varchar(30) set @id=" + posid 
				+ " select INV1.Quantity as Liefermenge" +
				", convert(varchar(30), INV1.DocEntry) +right('0000'+convert(varchar(4), INV1.LineNum), 4)  as Groessen_posi_id " +
				"from INV1 " +
				"where len(@id)>4 " +
				"and isNumeric(right(@id, 4))=1 " +
				"and INV1.LineNum=convert(int, right(@id, 4)) " +
				"and isNumeric(left(@id, len(@id)-4))=1 and INV1.DocEntry=convert(int, left(@id, len(@id)-4))");
			DbReader = DbCommand.ExecuteReader();
			while (DbReader.Read())
			{
				tmpmenge += DbReader.GetInt32(0);
				int tmpgrpos = DbReader.GetInt32(1);
				Groessenids.Add(new int[2]
				{
					tmpgrpos,
					DbReader.GetInt32(0)
				});
			}
			DbReader.Close();
			foreach (int[] remeposgrp in Groessenids)
			{
				DbCommand.CommandText = string.Concat("declare @id varchar(30) set @id=" + remeposgrp[0] 
					+ "select iNV1.Quantity as Liefermenge,INV1.LineTotal as vk_preis" +
					",coalesce(oitm.sweight1,oitm.bweight1)*inv1.quantity as Gewicht " +
					"from INV1 " +
					"inner join oitm on oitm.itemcode=inv1.itemcode " +
					"where len(@id)>4 and isNumeric(right(@id, 4))=1 " +
					"and INV1.LineNum=convert(int, right(@id, 4)) " +
					"and isNumeric(left(@id, len(@id)-4))=1 " +
					"and INV1.DocEntry=convert(int, left(@id, len(@id)-4))");
				DbReader = DbCommand.ExecuteReader();
				DbReader.Read();
				int pgmenge = remeposgrp[1];
				string eppreis = DbReader.GetString(1).Replace('.', ',');
				double zeppreis = double.Parse(eppreis);
				tmppreis += zeppreis;
				tmpgewicht += DbReader.GetDouble(2);
				DbReader.Close();
			}
			Rohmasse = tmpgewicht.ToString();
			Preis = tmppreis.ToString().Replace('.', ',');
			menge = tmpmenge.ToString();
			return 0;
		}

		public int dbclose()
		{
			conn.Close();
			return 0;
		}

		public DBConn()
		{
			conn = new OdbcConnection();
			conn.ConnectionString = "Driver={SQL Server};Server=SAPDB22;UID=excel24;PWD=abfrageengel24;Database=Engel;";
			conn.Open();
		}

		~DBConn()
		{
		}
	}
}
