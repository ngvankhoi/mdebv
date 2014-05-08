using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Medisoft
{
    class clsDoitiengviet
    {
        private DataSet ds=new DataSet();

        public string Doi_kytuviet_sang_ma(string strchuoigoc)
        {
            string strChuoiketqua = "";
            ds.ReadXml("DOITIENGVIET.xml");
            for (int i = 0; i < strchuoigoc.Length; i++)
            {
                string stmp = strchuoigoc.Substring(i, 1);
                DataRow dr = getrowbyid(ds.Tables[0], "kytu='" + stmp + "'");
                if(dr==null)
                    strChuoiketqua+=stmp;
                else
                    strChuoiketqua+=dr["MA"].ToString();

            }
            ds.Dispose();
            return strChuoiketqua;
        }

        public string Doi_ma_sang_kytuviet(string strchuoigoc)
        {

            ds.ReadXml("DOITIENGVIET.xml");
            string strChuoiketqua = "";
            for (int i = 0; i < strchuoigoc.Length; i++)
            {
                string stmp = (strchuoigoc.Length-i>=3)?strchuoigoc.Substring(i, 3):strchuoigoc.Substring(i);
                DataRow dr = getrowbyid(ds.Tables[0], "ma='" + stmp + "'");
                if (dr == null)
                {
                    dr = getrowbyid(ds.Tables[0], "ma='" + ((stmp.Length>=2)?stmp.Substring(0, 2):stmp.Substring(0)) + "'");
                    if (dr == null)
                    {
                        strChuoiketqua += stmp.Substring(0, 1).ToUpper();
                    }
                    else
                    {
                        strChuoiketqua += dr["KYTU"].ToString();
                        i = i + 1;
                    }
                }
                else
                {
                    strChuoiketqua += dr["KYTU"].ToString();
                    i = i + stmp.Trim().Length-1;
                }
            }            
            ds.Dispose();
            return strChuoiketqua;
        }

        public DataRow getrowbyid(DataTable dt, string exp)
        {
            try
            {
                DataRow[] r = dt.Select(exp);
                return r[0];
            }
            catch { return null; }
        }
    }
}
