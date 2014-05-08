using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
//using UI;
namespace DAL
{
    public static class Manager
    {
        //Accessdata acc = new Accessdata();
        public static void TaoTable(Client server)
        {
            Accessdata ac = new Accessdata();
            ac.TaoTable(server);
            ac.upd_manager_schema(server.DbLink);
        }
        public static void TaoTable()
        {
            Accessdata ac = new Accessdata();
            ac.TaoTable();
            //ac.upd_manager_schema(server.DbLink);
        }
        public static List<Client> listClient(Client sever)
        {
            Accessdata acc = new Accessdata();
            return acc.getClient(sever);
        }
        public static List<Client> listClient()
        {
            Accessdata acc = new Accessdata();
            return acc.getClient();
        }
        public static bool LuuClient(Client client, Client server)
        {
            Accessdata acc = new Accessdata();
            return acc.LuuClient(client,server);
        }
        public static bool LuuClient(Client client)
        {
            Accessdata acc = new Accessdata();
            return acc.LuuClient(client);
        }
        //public static bool XoaClient(Client client, Client server)
        //{
        //    Accessdata acc = new Accessdata();
        //    return acc.XoaClient(client, server);
        //}
        public static void DongBo(System.Data.DataTable table1, List<Client> list, Client server,bool bprogress)
        {
            string mmyy = DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2, 2);
            string schema = "", table = "", field = "", key = "";
            frmProgressBar progress = new frmProgressBar();
            if (bprogress)
            {
                progress.Show();
                progress.Maximum = table1.Rows.Count;
                progress.Step = 1;
                progress.Value = 1;
            }
            Accessdata acc = new Accessdata();
            foreach (System.Data.DataRow row in table1.Rows)
            {
                schema = row["schema"].ToString();
                schema = schema.Replace("xxx", mmyy);
                table = row["tablename"].ToString();
                field = row["field"].ToString();
                key = row["key"].ToString();
                if (bprogress)
                {
                    progress.Status = schema + "." + table;
                    progress.PerformStep();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    acc.Syschronise2Server(schema, table, key, field, list[i], server);
                }
            }
            if (bprogress)
            {
                progress.Close();
                progress.Dispose();
            }
        }
        public static void DongBo(System.Data.DataTable table1, Client client, Client server)
        {
            string mmyy = DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2, 2);
            string schema = "", table = "", field = "", key = "";
            Accessdata acc = new Accessdata();
            foreach (System.Data.DataRow row in table1.Rows)
            {
                schema = row["schema"].ToString();
                schema = schema.Replace("xxx", mmyy);
                table = row["tablename"].ToString();
                field = row["field"].ToString();
                key = row["key"].ToString();
                acc.Syschronise2Server(schema, table, key, field, client, server);
            }
        }
        //public static void ThemField(System.Data.DataTable table1, string valueDefault, Client server,DataTable dtmmyy)
        //{
        //    string mmyy = DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2, 2);
        //    string schema = "", table = "";//, field = "", key = "";
        //    Accessdata acc = new Accessdata();
        //    bool done = false;
        //    foreach (DataRow r in dtmmyy.Rows)
        //    {
        //        done = true;
        //        mmyy = r["mmyy"].ToString();
        //        foreach (System.Data.DataRow row in table1.Rows)
        //        {
        //            schema = row["schema"].ToString();
        //            schema = schema.Replace("xxx", mmyy);
        //            table = row["tablename"].ToString();
        //            acc.AlterTable(schema, table, valueDefault, server);
        //        }
        //    }
        //    if (!done)
        //    {
        //        foreach (System.Data.DataRow row in table1.Rows)
        //        {
        //            schema = row["schema"].ToString();
        //            schema = schema.Replace("xxx", mmyy);
        //            table = row["tablename"].ToString();
        //            acc.AlterTable(schema, table, valueDefault, server);
        //        }
        //    }
        //}
        public static void upd_chuyendi(System.Data.DataTable table1, string valueDefault, Client server, DataTable dtmmyy)
        {
            string mmyy = DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2, 2);
            string schema = "", table = "";//, field = "", key = "";
            Accessdata acc = new Accessdata();
            bool done = false;
            foreach (DataRow r in dtmmyy.Rows)
            {
                done = true;
                mmyy = r["mmyy"].ToString();
                foreach (System.Data.DataRow row in table1.Rows)
                {
                    schema = row["schema"].ToString();
                    schema = schema.Replace("xxx", mmyy);
                    table = row["tablename"].ToString();
                    acc.update(schema, table, valueDefault, server);
                }
            }
            if (!done)
            {
                foreach (System.Data.DataRow row in table1.Rows)
                {
                    schema = row["schema"].ToString();
                    schema = schema.Replace("xxx", mmyy);
                    table = row["tablename"].ToString();
                    acc.update(schema, table, valueDefault, server);
                }
            }
        }
        public static DataTable getMMYY(string dblinks_server)
        {
            Accessdata acc = new Accessdata();
            try
            {
                return acc.get_data("select mmyy from " + acc.User + ".syn_manager_schema@" + dblinks_server + " where syn=1").Tables[0];
            }
            catch
            {
                return null;
            }
        }
        public static DataSet SynTable(string dblink)
        {
            Accessdata acc = new Accessdata();
            if (dblink != "") dblink = "@" + dblink;
            try
            {
                return acc.get_data("select * from " + acc.User + ".syn_dmtable" + dblink + " where hide=0 order by stt ");
            }
            catch
            {
                return null;
            }
        }

        public static DataSet SynTable_chungtu(string dblink)
        {
            Accessdata acc = new Accessdata();
            if (dblink != "") dblink = "@" + dblink;
            try
            {
                return acc.get_data("select * from " + acc.User + ".syn_dmtable_chungtu" + dblink + "  where hide=0 order by stt ");
            }
            catch
            {
                return null;
            }
        }

        public static DataSet SynTable_KSK(string dblink)
        {
            Accessdata acc = new Accessdata();
            if (dblink != "") dblink = "@" + dblink;
            try
            {
                return acc.get_data("select * from " + acc.User + ".syn_dmtable_ksk" + dblink + "  where hide=0 order by stt ");
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// copy tất cả file và thư mục từ thư mục nguồn sang thư mục đích
        /// </summary> 
        /// <param name="srcPath">đường dẫn thư mục nguồn</param>
        /// <param name="disPath">đường dẫn thư mục đích</param>
        public static void copyfile(string s_SourcePath, string s_DestPath, bool b_OverWrite, System.Windows.Forms.ToolStripStatusLabel status)
        {
            //label_source.Text = srcPath;
            //label_dest.Text = disPath;
            try
            {
                int i_cout = 0, i_stt=0;
                
                string[] filenames = Directory.GetFiles(s_SourcePath);
                string tmp_dest = "";
                i_cout =filenames.Length;
                if ( i_cout!= 0)
                {
                    //progressBar1.Maximum = filenames.Length;
                    //progressBar1.Minimum = 0;
                    //progressBar1.Value = 0;
                    foreach (string filename in filenames)
                    {
                        i_stt += 1;
                        status.Text = "Copy from " + s_SourcePath + " to " + s_DestPath + ": " + i_stt + "/" + i_cout;
                        
                        try
                        {
                            //label_copying.Text = filename.Substring(srcPath.Length + 1);
                           // Refresh();
                            int index = filename.LastIndexOf("\\");
                            string tenfile = filename.Substring(index).Trim('\\');
                            //if (tenfile.ToLower() == "update.exe")
                            //{
                            //    if (System.IO.File.Exists(disPath + "\\update.exe")) continue;
                            //}
                            tmp_dest = s_DestPath + filename.Substring(s_SourcePath.Length);
                            File.Copy(filename, tmp_dest , b_OverWrite);
                            //progressBar1.Value += 1;
                        }
                        catch (Exception exx) { }
                    }
                }
                //Copy tat ca cac thu muc con
                string[] Directs = Directory.GetDirectories(s_SourcePath);
                foreach (string Direct in Directs)
                {
                    Directory.CreateDirectory(s_DestPath + Direct.Substring(s_SourcePath.Length));
                    copyfile( Direct, s_DestPath + Direct.Substring(s_SourcePath.Length),b_OverWrite,status );
                }
            }
            catch (Exception exx)
            {
                //MessageBox.Show("Không tìm thấy thư mục nguồn: " + srcPath + " + " + disPath);
                //return;
            }
        }
    }
}
