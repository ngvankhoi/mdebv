using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using LibMedi;
using Npgsql;
using NpgsqlTypes;

namespace Medisoft
{
	/// <summary>
	/// Summary description for ClassLib.
	/// </summary>
	public class Language
	{
		private DataSet ds = new DataSet();
        private int flag_language = 0;
        private AccessData m = new AccessData();
        //==================================
        private string m_db_database = "medisoft2007";
        private string m_db_host = "192.168.1.14";
        private string m_db_port = "5432";
        private string m_db_userid = "medisoft2007";
        private string m_db_password = "links1920";
        private string m_db_encoding = "UNICODE";
        private string m_db_schemaroot = "medibv";
        private string m_db_connectionstring = "Server=192.168.1.14;Port=5432;User Id=medisoft2007;Password=medisoft2007;Database=medisoft2007;Encoding=UNICODE;";
        //==================================
        private NpgsqlDataAdapter m_dataadapter;
        private NpgsqlConnection m_connection;
        private NpgsqlCommand m_command;
		public Language()
		{
			//
			// TODO: Add constructor logic here
			//
            f_load_maincode();
            m_db_connectionstring = "Server=" + m_db_host + ";Port=" + m_db_port + ";User Id=" + m_db_userid + ";Password=" + m_db_password + ";Database=" + m_db_database + ";Encoding=" + m_db_encoding + ";";
		}
        private void f_load_maincode()
        {
            DataSet m_ds = new DataSet();
            try
            {
                m_ds = new DataSet();
                m_ds.ReadXml("..//..//..//xml//maincode.xml");
                try
                {
                    m_db_database = m_ds.Tables[0].Rows[0]["database"].ToString();
                }
                catch
                {
                    m_db_database = "";
                }
                if (m_db_database == "")
                {
                    m_db_database = "medisoft";
                }

                m_db_host = m_ds.Tables[0].Rows[0]["ip"].ToString();
                m_db_port = m_ds.Tables[0].Rows[0]["post"].ToString();
                try
                {
                    m_db_userid = m_ds.Tables[0].Rows[0]["userid"].ToString();
                }
                catch
                {
                    m_db_userid = "";
                }
                if (m_db_userid == "")
                {
                    m_db_userid = "medisoft";
                }

                try
                {
                    m_db_password = m_ds.Tables[0].Rows[0]["password"].ToString();
                }
                catch
                {
                    m_db_password = "";
                }
                if (m_db_password == "")
                {
                    m_db_password = "links1920";
                }
                m_db_encoding = "UNICODE";// m_ds.Tables[0].Rows[0]["encoding"].ToString();
                try
                {
                    m_db_schemaroot = m_ds.Tables[0].Rows[0]["user"].ToString();
                }
                catch
                {
                    m_db_schemaroot = "";
                }
                if (m_db_schemaroot == "")
                {
                    m_db_schemaroot = "medibv";
                }
            }
            catch
            {
            }
        }
        public decimal f_get_id_Language
        {

            get
            {
                try
                {
                    decimal _value = 1;
                    string m_sql = "";
                    m_sql = "select nextval('" + m.user + ".language1_id_seq');";
                    m_connection = new NpgsqlConnection(m_db_connectionstring);
                    m_connection.Open();
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    object obj = m_command.ExecuteScalar();
                    if (obj != null)
                    {
                        _value = decimal.Parse(obj.ToString());
                    }
                    return _value;
                }
                catch
                {
                    return 1;
                }
                finally
                {
                    m_connection.Dispose(); m_command.Dispose();
                }
            }

        }
        public bool upd_langage(decimal v_id, string v_tenviet, string v_teneng, string v_other)
        {
            string m_sql = "";
            m_sql = "update " + m.user + ".language set  ";
            m_sql += " vietnamese=:v_tenviet,english=:v_teneng,other=:v_other";
            m_sql += " where id=:v_id";
            m_connection = new NpgsqlConnection(m_db_connectionstring);
            m_command = new NpgsqlCommand(m_sql, m_connection);
            m_command.CommandType = CommandType.Text;


            m_command.Parameters.Add("v_tenviet", NpgsqlDbType.Varchar, 200).Value = v_tenviet;
            m_command.Parameters.Add("v_teneng", NpgsqlDbType.Varchar, 200).Value = v_teneng;
            m_command.Parameters.Add("v_other", NpgsqlDbType.Varchar, 200).Value = v_other;
            m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;

            try
            {
                m_connection.Open();
                int irec = m_command.ExecuteNonQuery();
                m_command.Dispose();
                if (irec == 0)
                {
                    m_sql = "insert into " + m.user + ".language(id,vietnamese,english,other) ";
                    m_sql += " values(:v_id,:v_tenviet,:v_teneng,:v_other)";
                    m_command = new NpgsqlCommand(m_sql, m_connection);
                    m_command.CommandType = CommandType.Text;
                    m_command.Parameters.Add("v_id", NpgsqlDbType.Numeric).Value = v_id;
                    m_command.Parameters.Add("v_tenviet", NpgsqlDbType.Varchar, 200).Value = v_tenviet;
                    m_command.Parameters.Add("v_teneng", NpgsqlDbType.Varchar, 200).Value = v_teneng;
                    m_command.Parameters.Add("v_other", NpgsqlDbType.Varchar, 200).Value = v_other;


                    irec = m_command.ExecuteNonQuery();
                    m_command.Dispose();
                }
            }
            catch (Exception ex)
            {
                //upd_xn_error(ex.Message, m_computername, "xn_worksheetll");
                return false;
            }
            finally
            {
                m_command.Dispose();
                m_connection.Dispose();
            }
            return true;
        }
		
		public void Changelanguage_to_English(string frmName, Form frm)
		{
			//ds.ReadXml(@"..\..\..\language\"+frmName+".xml");
            ds = m.get_data("select vietnamese as Vviet,english as Vanh,other from " + m.user + ".language where english<>'' order by id");
			string lbl="",m_ngonngu="";
			string rong="";
            char[] c = new char[] { ' ' }; 
			TabControl tabclt;
            Panel p_c;
			flag_language=int.Parse(m.Thongso("Ngonngu").ToString());
            //Nhan sua.
			if (flag_language==0) return;
			switch (flag_language)
			{
				case 0:
					m_ngonngu="Vviet";
					break;
				case 1:
					m_ngonngu="Vanh";
					break;
				case 2:
                    m_ngonngu = "other";
					break;
			}
			frm.Text=get_text(ds.Tables[0],"vviet='"+frm.Text+"'",m_ngonngu);
			foreach(Control ctl in frm.Controls)
			{
				switch (ctl.GetType().ToString())
				{
                    case "System.Windows.Forms.ToolStrip":
                        ToolStrip tlbtrp = (ToolStrip)(ctl);
                        ToolStripSplitButton toolMenu;//= (ToolStripSplitButton
                        foreach (ToolStripItem ttrip in tlbtrp.Items)
                        {
                            lbl = ttrip.Text;
                            if (lbl != "")
                                ttrip.Text = get_text(ds.Tables[0], "vviet='" + lbl + "'");
                            if (ttrip.GetType().ToString() == "System.Windows.Forms.ToolStripSplitButton")
                            {
                                toolMenu = (ToolStripSplitButton)ttrip;
                                foreach (ToolStripItem ait in toolMenu.DropDownItems)
                                {
                                    if (ait.GetType().ToString() == "System.Windows.Forms.ToolStripMenuItem")
                                    {
                                        ToolStripMenuItem amenu = (ToolStripMenuItem)(ait);
                                        amenu.Text = get_text(ds.Tables[0], "vviet='" +
                                            amenu.Text + "'", "vanh");
                                        if (amenu.DropDownItems.Count > 0)
                                        {
                                            amenu.Enabled = true;
                                            f_change_submenu(ds, amenu);
                                        }
                                    }
                                }
                                
                            }

                        }
                        break;
                    case "System.Windows.Forms.SplitContainer":
                        Change_SplitContainer((SplitContainer)ctl, ds);
                        break;
                    case "System.Windows.Forms.Panel":
                        p_c = (Panel)ctl;
                        Change_Panel(p_c,ds);    	
						break;
					case "System.Windows.Forms.GroupBox":
                        ctl.Text = get_text(ds.Tables[0], "vviet='" + ctl.Text + "'");
                        Change_groupbox((GroupBox)ctl, ds);	
						break;
					case "System.Windows.Forms.Label":
						string rong1="";
						lbl=ctl.Text;
						if( ctl.Name.IndexOf("l_")>=0)
						  ctl.Text=rong1.PadLeft(7,' ')+ get_text(ds.Tables[0],"vviet='"+lbl.Trim()+"'").Trim();
						else
						  ctl.Text=get_text(ds.Tables[0],"vviet='"+lbl.Trim()+"'").Trim();
						break;
					case "System.Windows.Forms.Button":
						lbl=ctl.Text.TrimEnd();
                        string[] arr = new string[] { "" };
                        if (lbl.IndexOfAny(c)==0)
						   arr = lbl.Split(' ');
						ctl.Text=((arr.Length>1)?rong.PadLeft(7,' '):"")+get_text(ds.Tables[0],"vviet='"+lbl.Trim()+"'").Trim();
						break;
					case "System.Windows.Forms.TabControl":
						tabclt=(TabControl)ctl;
						foreach(TabPage tab in tabclt.TabPages )
						{
                            tab.Text = get_text(ds.Tables[0], "vviet='" + tab.Text + "'");
                            Change_TabControl(tab, ds); 
						}
						break;
                    case "System.Windows.Forms.DataGridView":
                        DataGridView gv = (DataGridView)ctl;
                        for (int i = 0; i <= gv.Columns.Count - 1; i++)
                        {
                            gv.Columns[i].HeaderText = get_text(ds.Tables[0], "vviet='" + gv.Columns[i].HeaderText.ToString() + "'");
                        }
                        break;
					default:
						if (ctl.GetType().ToString()=="MaskedBox.MaskedBox")
							continue;
						if (ctl.GetType().ToString()=="MaskedTextBox.MaskedTextBox")
							continue;
						lbl=ctl.Text;
						//lbl=lbl.Replace("&","");
                        if (lbl!="")
						    ctl.Text=get_text(ds.Tables[0],"vviet='"+lbl+"'");
						break;
				}
			}
		}
		public string Change_language_MessageText(string s_text)
		{
            string gttv = "";
            flag_language = int.Parse(m.Thongso("Ngonngu").ToString());
            //Nhan sua.
            decimal id_lang = 0;
            if (flag_language != 0)
            {
                //ds.ReadXml(@"..\..\..\language\Messagebox.xml");
                ds = m.get_data("select vietnamese as Vviet,english as Vanh,other from " + m.user + ".language where english<>'' order by id");
                switch (flag_language)
                {
                    case 0:
                        gttv = s_text;// get_text(ds.Tables[0], "vviet='" + s_text + "'", "Vviet");
                        break;
                    case 1:
                        gttv = get_text(ds.Tables[0], "vviet='" + s_text + "'", "Vanh");
                        break;
                    case 2:
                        gttv = get_text(ds.Tables[0], "vviet='" + s_text + "'", "other");
                        break;
                }
            }
            if (gttv == "")
            {
                ds = m.get_data("select vietnamese as Vviet,english as Vanh from " + m.user + ".language where (english='' or english is null) order by id");
                DataRow r = getrowbyid(ds.Tables[0], "vviet='" + s_text + "'");
                if (r == null)
                {
                    id_lang = f_get_id_Language;
                    upd_langage(id_lang, s_text, "", "");
                }
            }
            return (gttv.Trim() != "") ? gttv : s_text;
		}
        //Nhan them void dich dataset
        public DataSet Change_language_MessageText(DataSet ds_lan)
        {
            flag_language = int.Parse(m.Thongso("Ngonngu").ToString());
            if ((flag_language != 0)&&(ds_lan!=null)&&(ds_lan.Tables[0].Rows.Count>0))
            {
                //ds.ReadXml(@"..\..\..\language\Messagebox.xml");
                ds = m.get_data("select vietnamese as Vviet,english as Vanh,other from " + m.user + ".language where english<>'' order by id");
                foreach(DataRow dr_lan in ds_lan.Tables[0].Rows)
                {
                    switch (flag_language)
                    {
                        case 0:
                            dr_lan["tendich"] = get_text(ds.Tables[0], "vviet='" + dr_lan["ten"].ToString() + "'", "Vviet");
                            break;
                        case 1:
                            dr_lan["tendich"] = get_text(ds.Tables[0], "vviet='" + dr_lan["ten"].ToString() + "'", "Vanh");
                            break;
                        case 2:
                            dr_lan["tendich"] = get_text(ds.Tables[0], "vviet='" + dr_lan["ten"].ToString() + "'", "Vphap");
                            break;
                    }
                }
                ds_lan.AcceptChanges();
            }
            return ds_lan;
        }
        //End.
		public void Changelanguage_to_Vietnam(string frmName, Form frm)
		{
            //ds.ReadXml(@"..\..\..\language\" + frmName + ".xml");
            ds = m.get_data("select vietnamese as Vviet,english as Vanh,other from " + m.user + ".language where english<>'' order by id");
            string lbl = "";
            foreach (Control ctl in frm.Controls)
            {
                switch (ctl.GetType().ToString())
                {
                    case "System.Windows.Forms.Panel":

                        foreach (Control ctl1 in ctl.Controls)
                        {
                            lbl = ctl1.Text;
                            lbl = lbl.Replace("&", "");
                            ctl1.Text = get_text(ds.Tables[0], "vanh='" + lbl + "'", "Vviet");
                        }
                        break;
                    case "System.Windows.Forms.GroupBox":

                        foreach (Control ctl1 in ctl.Controls)
                        {
                            lbl = ctl1.Text;
                            lbl = lbl.Replace("&", "");
                            ctl1.Text = get_text(ds.Tables[0], "vanh='" + lbl + "'", "Vviet");
                        }
                        break;
                    case "MaskedTextBox.MaskedTextBox":
                    case "MaskedBox.MaskedBox":
                        continue;
                    default:
                        lbl = ctl.Text;
                        lbl = lbl.Replace("&", "");
                        ctl.Text = get_text(ds.Tables[0], "vanh='" + lbl + "'", "Vviet");
                        break;
                }
            }
		}
		
		private DataTable Create_table()
		{
			DataTable dt = new DataTable("Language");
			DataColumn col = new DataColumn("Vviet",typeof(string));
			dt.Columns.Add(col);

			col = new DataColumn("Vanh",typeof(string));
			dt.Columns.Add(col);

			col = new DataColumn("Vphap",typeof(string));
			dt.Columns.Add(col);

			return dt;

		}
		public DataRow getrowbyid (DataTable dt,string exp ) 
		{
			try
			{
				DataRow[] r = dt.Select ( exp ) ;
				return r[0] ;
			}
			catch{return null ;}
		}
		private string get_text(DataTable dt,string dkt,string anhviet)
		{
			string gttv="";
			DataRow row = getrowbyid(dt,dkt);
			if (row!=null)
			{
				gttv=row[anhviet].ToString();
			}
			return gttv.Trim();
		}
		private string get_text(DataTable dt,string dkt)
		{
			string gttv="";
			flag_language=int.Parse(m.Thongso("Ngonngu").ToString());
			DataRow row = getrowbyid(dt,dkt);
			if (row!=null)
			{
				switch (flag_language)	
				{
					case 0:
						gttv=row["vviet"].ToString();
						break;
					case 1:
						gttv=row["vanh"].ToString();
						break;
					case 2:
                        gttv = row["other"].ToString();
						break;
				}
			}
			return gttv.Trim();
		}
		public void Read_Language_to_Xml(string frmName,Form frm)
		{
			DataSet dsTemp = new DataSet();
			try
			{
				//dsTemp.ReadXml(@"..\..\..\language\"+frmName+".xml");
                dsTemp = m.get_data("select vietnamese as Vviet,english as Vanh,id from " + m.user + ".language order by id");
				Write_to_Xml(frmName,frm,dsTemp.Tables[0]);
			}
			catch//(Exception eee)
			{
                //MessageBox.Show(eee.ToString());
                //Write_to_Xml(frmName,frm);
			}
		}
        public void Read_Language_ctl_to_Xml(string ctlName, UserControl frm)
        {
            DataSet dsTemp = new DataSet();
            try
            {
                dsTemp = m.get_data("select vietnamese as Vviet,english as Vanh,id from " + m.user + ".language order by id");
                Write_usrclt_to_Xml(ctlName, frm, dsTemp.Tables[0]);
            }
            catch//(Exception eee)
            {
                //MessageBox.Show(eee.ToString());
                //Write_usrclt_to_Xml(ctlName, frm);
            }
        }
		public void Write_to_Xml(string frmName, Form frm,DataTable dt)
		{
            ds = new DataSet();
            ds.Tables.Add(Create_table());
			string lbl="";
			DataRow r;
			TabControl tabclt;
            Panel p1;
            decimal id_lang = 0;
			foreach(Control ctl in frm.Controls)
			{
				switch (ctl.GetType().ToString())
				{
                                    
                    case "System.Windows.Forms.SplitContainer":
                        Read_SplitContainer((SplitContainer)ctl, ds, dt);
                        break;
                    
                    case "System.Windows.Forms.Panel":
                        p1 = (Panel)ctl;
                        Read_Panel(p1,ds,dt);
						break;
					case "System.Windows.Forms.GroupBox":
                        //r = ds.Tables[0].NewRow();
                        //r["vviet"] = ctl.Text.Trim();
                        //r["vanh"] = get_text(dt, "vviet='" + ctl.Text.Trim() + "'", "vanh");
                        //r["vphap"] = "";
                        //ds.Tables[0].Rows.Add(r);
                        r = getrowbyid(dt, "vviet='" + ctl.Text.Trim() + "'");
                        if (r == null)
                        {
                            id_lang = f_get_id_Language;
                            upd_langage(id_lang, ctl.Text.Trim(), "", "");
                        }
                        Read_GroupBox((GroupBox)ctl, ds, dt);
						break;
					
					case "MaskedTextBox.MaskedTextBox":
					case "MaskedBox.MaskedBox":
						break;
					case "System.Windows.Forms.TabControl":
						tabclt=(TabControl)ctl;
                        foreach (TabPage tab in tabclt.TabPages)
                        {
                            //r = ds.Tables[0].NewRow();
                            //r["vviet"] = tab.Text.Trim();
                            //r["vanh"] = get_text(dt, "vviet='" + tab.Text.Trim() + "'", "vanh");
                            //r["vphap"] = get_text(dt, "vviet='" + tab.Text.Trim() + "'", "vphap");
                            //ds.Tables[0].Rows.Add(r);
                            r = getrowbyid(dt, "vviet='" + tab.Text.Trim() + "'");
                            if (r == null)
                            {
                                id_lang = f_get_id_Language;
                                upd_langage(id_lang, tab.Text.Trim(), "", "");
                            }
                            Read_TabControl(tab, ds, dt);
                        }
						break;
                    case "System.Windows.Forms.DataGridView":
                        DataGridView  gv = (DataGridView)ctl;
                        for (int i = 0; i <= gv.Columns.Count - 1; i++)
                        {
                            //r = ds.Tables[0].NewRow();
                            //r["vviet"] = gv.Columns[i].HeaderText.Trim();
                            //r["vanh"] = get_text(dt, "vviet='" + gv.Columns[i].HeaderText.Trim() + "'", "vanh");
                            //r["vphap"] = get_text(dt, "vviet='" + gv.Columns[i].HeaderText.Trim() + "'", "vphap");
                            //ds.Tables[0].Rows.Add(r);
                            r = getrowbyid(dt, "vviet='" + gv.Columns[i].HeaderText.Trim() + "'");
                            if (r == null)
                            {
                                id_lang = f_get_id_Language;
                                upd_langage(id_lang, gv.Columns[i].HeaderText.Trim(), "", "");
                            }
                        }
                        break;
                    case "System.Windows.Forms.ToolStrip":
                        ToolStrip tlbtrp = (ToolStrip)(ctl);
                        ToolStripSplitButton toolMenu;//= (ToolStripMenuItem)ttrip;
                        foreach (ToolStripItem  ttrip in tlbtrp.Items)
                        {
                            lbl = ttrip.Text;
                            if (lbl!="")
                            {
                                //r = ds.Tables[0].NewRow();
                                //r["vviet"] = lbl;
                                //r["vanh"] = get_text(dt, "vviet='" + lbl + "'", "vanh");
                                //r["vphap"] = get_text(dt, "vviet='" + lbl + "'", "vphap");
                                //ds.Tables[0].Rows.Add(r);
                                r = getrowbyid(dt, "vviet='" + lbl + "'");
                                if (r == null)
                                {
                                    id_lang = f_get_id_Language;
                                    upd_langage(id_lang, lbl, "", "");
                                }
                            }
                            
                            if (ttrip.GetType().ToString() == "System.Windows.Forms.ToolStripSplitButton")
                            {
                                toolMenu = (ToolStripSplitButton)ttrip;
                                try
                                {
                                    
                                    foreach (ToolStripItem ait in toolMenu.DropDownItems)
                                    {
                                        if (ait.GetType().ToString() == "System.Windows.Forms.ToolStripMenuItem")
                                        {
                                            ToolStripMenuItem amenu = (ToolStripMenuItem)(ait);
                                            //r = ds.Tables[0].NewRow();
                                            //r["vviet"] = ait.Text.Trim();
                                            //r["vanh"] = get_text(dt, "vviet='" + ait.Text.Trim() + "'", "vanh");
                                            //r["vphap"] = get_text(dt, "vviet='" + ait.Text.Trim() + "'", "vphap");
                                            //ds.Tables[0].Rows.Add(r);
                                            r = getrowbyid(dt, "vviet='" + ait.Text.Trim() + "'");
                                            if (r == null)
                                            {
                                                id_lang = f_get_id_Language;
                                                upd_langage(id_lang, ait.Text.Trim(), "", "");
                                            }
                                            if (amenu.DropDownItems.Count > 0)
                                            {
                                                amenu.Enabled = true;
                                                f_Set_Node(ds, amenu, dt);
                                            }
                                        }
                                    }
                                }
                                catch
                                {
                                }
                            }
                        }
                        break;
					default:
						if (ctl.GetType().ToString()!="MaskedBox.MaskedBox")
						{
							if(ctl.GetType().ToString()!="System.Windows.Forms.ComboBox") 
							{
								if (ctl.GetType().ToString()!="System.Windows.Forms.TextBox")
								{
									lbl=ctl.Text.Trim();
									if (lbl!="")
									{                                        
                                        r = getrowbyid(dt, "vviet='" + lbl+ "'");
                                        if (r == null)
                                        {
                                            id_lang = f_get_id_Language;
                                            upd_langage(id_lang, lbl, "", "");
                                        }
									}
								}
							}
						}
						break;
				}
			}
            //r = ds.Tables[0].NewRow();
            //r["vviet"]=frm.Text.Trim();
            //r["vanh"]=get_text(dt,"vviet='"+frm.Text.Trim()+"'","vanh");
            //r["vphap"]=get_text(dt,"vviet='"+frm.Text.Trim()+"'","vphap");
            //ds.Tables[0].Rows.Add(r);
            //ds.WriteXml(@"..\..\..\language\"+frmName+".xml",XmlWriteMode.WriteSchema);
            r = getrowbyid(dt, "vviet='" + frm.Text.Trim() + "'");
            if (r == null)
            {
                id_lang = f_get_id_Language;
                upd_langage(id_lang, frm.Text.Trim(), "", "");
            }
        }
        #region  System.Windows.Forms.GroupBox
        void Read_GroupBox(GroupBox group, DataSet dstmp, DataTable dttmp)
        {
            DataRow r;
            Panel p_c = new Panel();
            decimal id_lang=0;
            foreach (Control c in group.Controls)
            {
                if (c.GetType().ToString() == "MaskedBox.MaskedBox")
                    continue;
                if (c.GetType().ToString() == "MaskedTextBox.MaskedTextBox")
                    continue;
                if (c.GetType().ToString() == "System.Windows.Forms.Panel")
                {
                    p_c = (Panel)c;
                    Read_Panel(p_c, dstmp, dttmp);
                }
                if (c.GetType().ToString() != "System.Windows.Forms.ComboBox")
                {
                    if (c.GetType().ToString() != "System.Windows.Forms.TextBox")
                    {
                        //r = dstmp.Tables[0].NewRow();
                        //r["vviet"] = c.Text.Trim();
                        //r["vanh"] = get_text(dttmp, "vviet='" + c.Text.Trim() + "'", "vanh");
                        //r["vphap"] = get_text(dttmp, "vviet='" + c.Text.Trim() + "'", "vphap");
                        //dstmp.Tables[0].Rows.Add(r);
                        r = getrowbyid(dttmp, "vviet='" + c.Text.Trim() + "'");
                        if (r == null)
                        {
                            id_lang = f_get_id_Language;
                            upd_langage(id_lang, c.Text.Trim(), "", "");
                        }
                    }
                }
                if (c.GetType().ToString() == "System.Windows.Forms.DataGridView")
                {
                    DataGridView gv = (DataGridView)c;
                    for (int i = 0; i <= gv.Columns.Count - 1; i++)
                    {
                        //r = dstmp.Tables[0].NewRow();
                        //r["vviet"] = gv.Columns[i].HeaderText.Trim();
                        //r["vanh"] = get_text(dttmp, "vviet='" + gv.Columns[i].HeaderText.Trim() + "'", "vanh");
                        //r["vphap"] = get_text(dttmp, "vviet='" + gv.Columns[i].HeaderText.Trim() + "'", "vphap");
                        //dstmp.Tables[0].Rows.Add(r);
                        r = getrowbyid(dttmp, "vviet='" + gv.Columns[i].HeaderText.Trim() + "'");
                        if (r == null)
                        {
                            id_lang = f_get_id_Language;
                            upd_langage(id_lang, gv.Columns[i].HeaderText.Trim(), "", "");
                        }
                    }
                }
            }
        }
        private void Change_groupbox(GroupBox gbox, DataSet dstmp)
        {
            Panel p_c = new Panel();
            foreach (Control c in gbox.Controls)
            {
                if (c.GetType().ToString() == "MaskedBox.MaskedBox")
                    continue;
                if (c.GetType().ToString() == "MaskedTextBox.MaskedTextBox")
                    continue;
                if (c.GetType().ToString() =="System.Windows.Forms.Panel")
                {
                     p_c = (Panel)c;
                     Change_Panel(p_c, dstmp);
                }
                if (c.GetType().ToString() == "System.Windows.Forms.DataGridView")
                {
                    DataGridView gv = (DataGridView)c;
                    for (int i = 0; i <= gv.Columns.Count - 1; i++)
                    {
                        gv.Columns[i].HeaderText = get_text(dstmp.Tables[0], "vviet='" + gv.Columns[i].HeaderText.ToString() + "'");
                    }
                }
                if (c.Text.Trim()!="")
                c.Text = get_text(dstmp.Tables[0], "vviet='" + c.Text.Trim() + "'");
            }
        }
        #endregion
        #region System.Windows.Forms.TabControl
        void Read_TabControl(TabPage tab,DataSet dstmp, DataTable dttmp )
        {
            DataRow r;
            DataGridView gv;
            decimal id_lang = 0;
            string lbl = "";
                foreach (Control ct in tab.Controls)
                {
                    switch (ct.GetType().ToString())
                    {
                        case "MaskedBox.MaskedBox":
                        case "System.Windows.Forms.ComboBox":
                        case "System.Windows.Forms.TextBox":
                            break;
                        case "System.Windows.Forms.GroupBox":
                            //r = dstmp.Tables[0].NewRow();
                            //r["vviet"] = ct.Text.Trim();
                            //r["vanh"] = get_text(dttmp, "vviet='" + ct.Text.Trim() + "'", "vanh");
                            //r["vphap"] = get_text(dttmp, "vviet='" + ct.Text.Trim() + "'", "vphap");
                            //dstmp.Tables[0].Rows.Add(r);
                            r = getrowbyid(dttmp, "vviet='" + ct.Text.Trim() + "'");
                            if (r == null)
                            {
                                id_lang = f_get_id_Language;
                                upd_langage(id_lang, ct.Text.Trim(), "", "");
                            }
                            Read_GroupBox((GroupBox)ct, dstmp, dttmp);
                            break;
                        case "System.Windows.Forms.DataGridView" :
                            gv = (DataGridView)ct;
                            for (int i = 0; i <= gv.Columns.Count - 1; i++)
                            {
                                //r = dstmp.Tables[0].NewRow();
                                //r["vviet"] = gv.Columns[i].HeaderText.Trim();
                                //r["vanh"] = get_text(dttmp, "vviet='" + gv.Columns[i].HeaderText.Trim() + "'", "vanh");
                                //r["vphap"] = get_text(dttmp, "vviet='" + gv.Columns[i].HeaderText.Trim() + "'", "vphap");
                                //dstmp.Tables[0].Rows.Add(r);
                                r = getrowbyid(dttmp, "vviet='" + gv.Columns[i].HeaderText.Trim() + "'");
                                if (r == null)
                                {
                                    id_lang = f_get_id_Language;
                                    upd_langage(id_lang, gv.Columns[i].HeaderText.Trim(), "", "");
                                }
                            }
                            break;
                        case "System.Windows.Forms.Panel" :
                            Panel p1 = (Panel)ct;
                            Read_Panel(p1, dstmp, dttmp);
                            break;
                        default:
                            lbl = ct.Text.Trim();
                            if (lbl != "")
                            {
                                //r = dstmp.Tables[0].NewRow();
                                //r["vviet"] = ct.Text.Trim();
                                //r["vanh"] = get_text(dttmp, "vviet='" + ct.Text.Trim() + "'", "vanh");
                                //r["vphap"] = get_text(dttmp, "vviet='" + ct.Text.Trim() + "'", "vphap");
                                //ds.Tables[0].Rows.Add(r);
                                r = getrowbyid(dttmp, "vviet='" + ct.Text.Trim() + "'");
                                if (r == null)
                                {
                                    id_lang = f_get_id_Language;
                                    upd_langage(id_lang, ct.Text.Trim(), "", "");
                                }
                            }

                            break;
                    }
                }
            
        }
        private void Change_TabControl(TabPage  tab, DataSet dstmp)
        {
            string lbl = "";
            string rong = "";
            //DataRow r;
            char[] c = new char[] { ' ' };
            foreach (Control ct in tab.Controls)
            {
                switch (ct.GetType().ToString())
                {
                    case "MaskedBox.MaskedBox":
                    case "System.Windows.Forms.ComboBox":
                    case "System.Windows.Forms.TextBox":
                        break;
                    case "System.Windows.Forms.GroupBox":
                        ct.Text = get_text(dstmp.Tables[0], "vviet='" + ct.Text + "'");
                        foreach (Control ct1 in ct.Controls)
                        {
                            switch (ct1.GetType().ToString())
                            {
                                case "System.Windows.Forms.DataGridView":
                               
                                    DataGridView gv1 = (DataGridView)ct1;
                                    for (int i = 0; i <= gv1.Columns.Count - 1; i++)
                                    {
                                        gv1.Columns[i].HeaderText = get_text(dstmp.Tables[0], "vviet='" + gv1.Columns[i].HeaderText.ToString() + "'");
                                    }                                
                                    
                                    break;
                                case "System.Windows.Forms.GroupBox":
                                    Change_groupbox((GroupBox)ct1, dstmp);
                                    break;
                                case "System.Windows.Forms.Panel":
                                    Change_Panel((Panel)ct1, dstmp);
                                    break;
                                default:
                                    ct1.Text = get_text(dstmp.Tables[0], "vviet='" + ct1.Text + "'");
                                    break;
                           }
                        }
                        //
                        break;
                    case "System.Windows.Forms.Button":
                        lbl = ct.Text.TrimEnd();
                        string[] arr3 = new string[] { "" };
                        if (lbl.IndexOfAny(c) == 0)
                            arr3 = lbl.Split(' ');
                        ct.Text = ((arr3.Length > 1) ? rong.PadLeft(7, ' ') : "") + get_text(dstmp.Tables[0], "vviet='" + lbl.Trim() + "'").Trim();
                        break;
                    case "System.Windows.Forms.Panel":
                        Panel p1 = (Panel)ct;
                        Change_Panel(p1, dstmp);
                        break;
                    case "System.Windows.Forms.DataGridView":
                        DataGridView gv = (DataGridView)ct;
                        for (int i = 0; i <= gv.Columns.Count - 1; i++)
                        {
                            gv.Columns[i].HeaderText = get_text(dstmp.Tables[0], "vviet='" + gv.Columns[i].HeaderText.ToString() + "'");
                        }
                        break;
                    default:
                        lbl = ct.Text.Trim();
                        if (lbl != "")
                        {
                            ct.Text = get_text(dstmp.Tables[0], "vviet='" + ct.Text + "'");
                        }

                        break;
                }
            }
        }
        #endregion
        #region System.Windows.Forms.Panel
        private void Read_Panel(System.Windows.Forms.Panel pnel,DataSet dstmp, DataTable dtmp)
        {
            string lbl = "";
            DataRow r;
            Panel p_c;
            decimal id_lang = 0;
            foreach (Control c in pnel.Controls)
            {
                switch (c.GetType().ToString())
                {
                    case "System.Windows.Forms.ToolStrip":
                        ToolStrip tlbtrp1 = (ToolStrip)(c);
                        foreach (ToolStripItem ttrip1 in tlbtrp1.Items)
                        {
                            lbl = ttrip1.Text;
                            if (lbl != "")
                            {                                
                                r = getrowbyid(dtmp, "vviet='" + lbl + "'");
                                if (r == null)
                                {
                                    id_lang = f_get_id_Language;
                                    upd_langage(id_lang, lbl, "", "");
                                }
                            }
                        }
                        break;
                    case "System.Windows.Forms.DataGridView":
                        DataGridView gv = (DataGridView)c;
                        for (int i = 0; i <= gv.Columns.Count - 1; i++)
                        {                          
                            r = getrowbyid(dtmp, "vviet='" + gv.Columns[i].HeaderText.Trim() + "'");
                            if (r == null)
                            {
                                id_lang = f_get_id_Language;
                                upd_langage(id_lang, gv.Columns[i].HeaderText.Trim(), "", "");
                            }
                        }
                        break;
                    case "MaskedBox.MaskedBox":
                    case "MaskedTextBox.MaskedTextBox":
                        break;
                    case "System.Windows.Forms.Panel":
                        p_c = (Panel)c;
                        Read_Panel(p_c,dstmp,dtmp );
                        break;
                    case "System.Windows.Forms.TabControl":
                        TabControl p_tab = (TabControl)c;
                        foreach (TabPage t_p in p_tab.TabPages)
                        {                           
                            r = getrowbyid(dtmp, "vviet='" + t_p.Text + "'");
                            if (r == null)
                            {
                                id_lang = f_get_id_Language;
                                upd_langage(id_lang, t_p.Text, "", "");
                            }
                            Read_TabControl(t_p, dstmp, dtmp);
                        }
                        break;
                    case "System.Windows.Forms.GroupBox":
                        r = getrowbyid(dtmp, "vviet='" + c.Text + "'");
                        if (r == null)
                        {
                            id_lang = f_get_id_Language;
                            upd_langage(id_lang, c.Text, "", "");
                        }
                        Read_GroupBox((GroupBox)c, dstmp, dtmp);
                        break;
                    default:
                        //MessageBox.Show(c.GetType().ToString());
                        if (c.GetType().ToString() != "System.Windows.Forms.TextBox")
                        {
                          
                            r = getrowbyid(dtmp, "vviet='" + c.Text + "'");
                            if (r == null)
                            {
                                id_lang = f_get_id_Language;
                                upd_langage(id_lang, c.Text, "", "");
                            }
                        }
                        break;
                }
                
            }
        }
        private void Read_SplitContainer(System.Windows.Forms.SplitContainer pnel, DataSet dstmp, DataTable dtmp)
        {
            string lbl = "";
            DataRow r;
            Panel p_c;
            decimal id_lang = 0;
            foreach (Control c in pnel.Controls)
            {
                switch (c.GetType().ToString())
                {
                    case "System.Windows.Forms.ToolStrip":
                        ToolStrip tlbtrp1 = (ToolStrip)(c);
                        foreach (ToolStripItem ttrip1 in tlbtrp1.Items)
                        {
                            lbl = ttrip1.Text;
                            if (lbl != "")
                            {
                                //r = dstmp.Tables[0].NewRow();
                                //r["vviet"] = lbl;
                                //r["vanh"] = get_text(dtmp, "vviet='" + lbl + "'", "vanh");
                                //r["vphap"] = get_text(dtmp, "vviet='" + lbl + "'", "vphap");
                                //dstmp.Tables[0].Rows.Add(r);
                                r = getrowbyid(dtmp, "vviet='" + lbl + "'");
                                if (r == null)
                                {
                                    id_lang = f_get_id_Language;
                                    upd_langage(id_lang, lbl, "", "");
                                }
                            }
                        }
                        break;
                         
                    case "System.Windows.Forms.DataGridView":
                        DataGridView gv = (DataGridView)c;
                        for (int i = 0; i <= gv.Columns.Count - 1; i++)
                        {
                            //r = dstmp.Tables[0].NewRow();
                            //r["vviet"] = gv.Columns[i].HeaderText.Trim();
                            //r["vanh"] = get_text(dtmp, "vviet='" + gv.Columns[i].HeaderText.Trim() + "'", "vanh");
                            //r["vphap"] = get_text(dtmp, "vviet='" + gv.Columns[i].HeaderText.Trim() + "'", "vphap");
                            //dstmp.Tables[0].Rows.Add(r);
                            r = getrowbyid(dtmp, "vviet='" + gv.Columns[i].HeaderText.Trim() + "'");
                            if (r == null)
                            {
                                id_lang = f_get_id_Language;
                                upd_langage(id_lang, gv.Columns[i].HeaderText.Trim(), "", "");
                            }
                        }
                        break;
                    case "MaskedBox.MaskedBox":
                    case "MaskedTextBox.MaskedTextBox":
                        break;
                    case "System.Windows.Forms.SplitterPanel":
                        p_c = (Panel)c;
                        Read_Panel(p_c, dstmp, dtmp);
                        break;
                    
                    case "System.Windows.Forms.TabControl":
                        TabControl p_tab = (TabControl)c;
                        foreach (TabPage t_p in p_tab.TabPages)
                        {
                            //r = dstmp.Tables[0].NewRow();
                            //r["vviet"] = t_p.Text.Trim();
                            //r["vanh"] = get_text(dtmp, "vviet='" + t_p.Text + "'", "vanh");
                            //r["vphap"] = get_text(dtmp, "vviet='" + t_p.Text + "'", "vphap");
                            //dstmp.Tables[0].Rows.Add(r);
                             r = getrowbyid(dtmp, "vviet='" + t_p.Text + "'");
                            if (r == null)
                            {
                                id_lang = f_get_id_Language;
                                upd_langage(id_lang, t_p.Text, "", "");
                            }
                            Read_TabControl(t_p, dstmp, dtmp);
                        }
                        break;
                    case "System.Windows.Forms.GroupBox":
                        r = getrowbyid(dtmp, "vviet='" + c.Text + "'");
                        if (r == null)
                        {
                            id_lang = f_get_id_Language;
                            upd_langage(id_lang, c.Text, "", "");
                        }
                        Read_GroupBox((GroupBox)c, dstmp, dtmp);
                        break;
                    default:
                        MessageBox.Show(c.GetType().ToString());
                        if (c.GetType().ToString() != "System.Windows.Forms.TextBox")
                        {
                            //r = dstmp.Tables[0].NewRow();
                            //r["vviet"] = c.Text.Trim();
                            //r["vanh"] = get_text(dtmp, "vviet='" + c.Text.Trim() + "'", "vanh");
                            //r["vphap"] = get_text(dtmp, "vviet='" + c.Text.Trim() + "'", "vphap");
                            //dstmp.Tables[0].Rows.Add(r);
                            r = getrowbyid(dtmp, "vviet='" + c.Text + "'");
                            if (r == null)
                            {
                                id_lang = f_get_id_Language;
                                upd_langage(id_lang, c.Text, "", "");
                            }
                        }
                        break;
                }

            }
        }
        private void Change_SplitContainer(System.Windows.Forms.SplitContainer pnel, DataSet dstmp)
        {
            string lbl = "";
            string rong = "";
            //DataRow r;
            Panel p_c;
            foreach (Control c in pnel.Controls)
            {
                switch (c.GetType().ToString())
                {
                    case "System.Windows.Forms.ToolStrip":
                        ToolStrip tlbtrp1 = (ToolStrip)(c);
                        foreach (ToolStripItem ttrip1 in tlbtrp1.Items)
                        {
                            lbl = ttrip1.Text;
                            if (lbl != "")
                                ttrip1.Text = get_text(dstmp.Tables[0], "vviet='" + lbl.Trim() + "'").Trim();
                        }
                        break;
                    case "System.Windows.Forms.Button":
                        lbl = c.Text.TrimEnd();
                        string[] arr1 = lbl.Split(' ');
                        c.Text = ((arr1.Length > 0) ? rong.PadLeft(7, ' ') : "") + get_text(dstmp.Tables[0], "vviet='" + lbl.Trim() + "'").Trim();
                        break;
                    case "MaskedBox.MaskedBox":
                    case "MaskedTextBox.MaskedTextBox":
                        break;
                    case "System.Windows.Forms.SplitterPanel":
                        p_c = (Panel)c;
                        Change_Panel(p_c, dstmp);
                        break;
                    case "System.Windows.Forms.TabControl":
                        TabControl tabclt = (TabControl)c;
                        foreach (TabPage tab in tabclt.TabPages)
                        {
                            tab.Text = get_text(dstmp.Tables[0], "vviet='" + tab.Text + "'");
                            Change_TabControl(tab, dstmp);
                        }
                        break;
                    case "System.Windows.Forms.GroupBox":
                        c.Text = get_text(dstmp.Tables[0], "vviet='" + c.Text + "'");
                        Change_groupbox((GroupBox)c, dstmp);
                        break;
                    case "System.Windows.Forms.DataGridView":
                        DataGridView gv = (DataGridView)c;
                        for (int i = 0; i <= gv.Columns.Count - 1; i++)
                        {
                            gv.Columns[i].HeaderText = get_text(dstmp.Tables[0], "vviet='" + gv.Columns[i].HeaderText.ToString() + "'");
                        }
                        break;
                    default:
                        if (c.GetType().ToString() != "System.Windows.Forms.TextBox")
                        {
                            lbl = c.Text.Trim();
                            if (lbl != "")
                                c.Text = get_text(dstmp.Tables[0], "vviet='" + lbl + "'");
                        }
                        break;
                }

            }
        }
        //
        private void Change_Panel(System.Windows.Forms.Panel pnel, DataSet dstmp)
        {
            string lbl = "";
            string rong = "";
            //DataRow r;
            Panel p_c;
            foreach (Control c in pnel.Controls)
            {
                switch (c.GetType().ToString())
                {
                    case "System.Windows.Forms.ToolStrip":
                        ToolStrip tlbtrp1 = (ToolStrip)(c);
                        foreach (ToolStripItem ttrip1 in tlbtrp1.Items)
                        {
                            lbl = ttrip1.Text;
                            if (lbl != "")
                                ttrip1.Text = get_text(dstmp.Tables[0], "vviet='" + lbl.Trim() + "'").Trim();
                        }
                        break;
                    case "System.Windows.Forms.Button":
                        lbl = c.Text.TrimEnd();
                        string[] arr1 = lbl.Split(' ');
                        c.Text = ((arr1.Length > 0) ? rong.PadLeft(7, ' ') : "") + get_text(dstmp.Tables[0], "vviet='" + lbl.Trim() + "'").Trim();
                        break;
                    case "MaskedBox.MaskedBox":
                    case "MaskedTextBox.MaskedTextBox":
                        break;
                    case "System.Windows.Forms.Panel":
                        p_c = (Panel)c;
                        Change_Panel(p_c, dstmp);
                        break;
                    case "System.Windows.Forms.TabControl":
                        TabControl tabclt = (TabControl)c;
                        foreach (TabPage tab in tabclt.TabPages)
                        {
                            tab.Text = get_text(dstmp.Tables[0], "vviet='" + tab.Text + "'");
                            Change_TabControl(tab, dstmp);
                        }
                        break;
                    case "System.Windows.Forms.GroupBox":
                        c.Text = get_text(dstmp.Tables[0], "vviet='" + c.Text + "'");
                        Change_groupbox((GroupBox)c, dstmp);
                        break;
                    case "System.Windows.Forms.DataGridView":
                        DataGridView gv = (DataGridView)c;
                        for (int i = 0; i <= gv.Columns.Count - 1; i++)
                        {
                            gv.Columns[i].HeaderText = get_text(dstmp.Tables[0], "vviet='" + gv.Columns[i].HeaderText.ToString() + "'");
                        }
                        break;
                    default:
                        if (c.GetType().ToString() != "System.Windows.Forms.TextBox")
                        {
                            lbl = c.Text.Trim();
                            if (lbl!="")
                             c.Text = get_text(dstmp.Tables[0], "vviet='" + lbl + "'");
                        }
                        break;
                }

            }
        }
        #endregion
        #region MenuBar
        private void write_mainmenu_to_xml(string frmName,Control c1 )
		{
            ds = new DataSet();
            ds.Tables.Add(Create_table());
			DataRow r;
            MenuStrip mnu = (MenuStrip) c1;
            
			foreach(ToolStripItem i in mnu.Items)
			{
                if (i.GetType().ToString() == "System.Windows.Forms.ToolStripMenuItem")
                {
                    ToolStripMenuItem amenu = (ToolStripMenuItem)(i);
                    r = ds.Tables[0].NewRow();
                    r["vviet"] = i.Text;
                    r["vanh"] = "";
                    r["vphap"] = "";
                    ds.Tables[0].Rows.Add(r);
                    if (amenu.DropDownItems.Count > 0)
                    {
                        f_Set_Node(ds, amenu);
                    }
                }
				
			}			
			//ds.WriteXml(@"..\..\..\language\"+frmName+".xml",XmlWriteMode.WriteSchema);
		}

        private void write_ContextMenuStrip_to_xml(string frmName, Control c1)
        {
            ds = new DataSet();
            ds.Tables.Add(Create_table());
            DataRow r;
            ContextMenuStrip mnu = (ContextMenuStrip)c1;
            foreach (ToolStripItem i in mnu.Items)
            {
                if (i.GetType().ToString() == "System.Windows.Forms.ToolStripMenuItem")
                {
                    ToolStripMenuItem amenu = (ToolStripMenuItem)(i);
                    r = ds.Tables[0].NewRow();
                    r["vviet"] = i.Text;
                    r["vanh"] = "";
                    r["vphap"] = "";
                    ds.Tables[0].Rows.Add(r);
                    if (amenu.DropDownItems.Count > 0)
                    {
                        f_Set_Node(ds, amenu);
                    }
                }

            }
            //ds.WriteXml(@"..\..\..\language\" + frmName + ".xml", XmlWriteMode.WriteSchema);
        }
        private void f_Set_Node(DataSet v_ds, ToolStripMenuItem v_item)
        {
            DataRow r;
            foreach (ToolStripItem ait in v_item.DropDownItems)
            {
                if (ait.GetType().ToString() == "System.Windows.Forms.ToolStripMenuItem")
                {
                    ToolStripMenuItem amenu = (ToolStripMenuItem)(ait);
                    r = v_ds.Tables[0].NewRow();
                    r["vviet"] = ait.Text;
                    r["vanh"] = "";
                    r["vphap"] = "";
                    ds.Tables[0].Rows.Add(r);
                    if (amenu.DropDownItems.Count > 0)
                    {
                        amenu.Enabled = true;
                        f_Set_Node(v_ds, amenu);
                    }
                }
            }
        }
        private void f_Set_Node(DataSet v_ds, ToolStripMenuItem v_item,DataTable dt)
        {
            DataRow r;
            foreach (ToolStripItem ait in v_item.DropDownItems)
            {
                if (ait.GetType().ToString() == "System.Windows.Forms.ToolStripMenuItem")
                {
                    ToolStripMenuItem amenu = (ToolStripMenuItem)(ait);
                    r = v_ds.Tables[0].NewRow();
                    r["vviet"] = ait.Text.Trim();
                    r["vanh"] = get_text(dt, "vviet='" + ait.Text.Trim() + "'", "vanh");
                    r["vphap"] = get_text(dt, "vviet='" + ait.Text.Trim() + "'", "vphap");
                    v_ds.Tables[0].Rows.Add(r);
                    if (amenu.DropDownItems.Count > 0)
                    {
                        amenu.Enabled = true;
                        f_Set_Node(v_ds, amenu,dt);
                    }
                }
            }
        }
        private void f_change_submenu(DataSet v_ds, ToolStripMenuItem v_item)
        {
            //DataRow r;
            foreach (ToolStripItem ait in v_item.DropDownItems)
            {
                if (ait.GetType().ToString() == "System.Windows.Forms.ToolStripMenuItem")
                {
                    ToolStripMenuItem amenu = (ToolStripMenuItem)(ait);
                    switch (flag_language)
                    {
                        case 0:
                            amenu.Text = get_text(v_ds.Tables[0], "vviet='" +
                                amenu.Text + "'", "vviet");
                            break;
                        case 1:
                            amenu.Text = get_text(v_ds.Tables[0], "vviet='" +
                                amenu.Text + "'", "vanh");
                            break;
                    }
                    if (amenu.DropDownItems.Count > 0)
                    {
                        f_change_submenu(v_ds, amenu);
                    }
                }
            }
        }
        private void write_ContextMenuStrip_to_xml(string frmName, Control c1, DataTable dt)
        {
            ds = new DataSet();
            ds.Tables.Add(Create_table());
            DataRow r;
            ContextMenuStrip mnu = (ContextMenuStrip)c1;
            foreach (ToolStripItem ait in mnu.Items)
            {

                if (ait.GetType().ToString() == "System.Windows.Forms.ToolStripMenuItem")
                {
                    ToolStripMenuItem amenu = (ToolStripMenuItem)(ait);
                    r = ds.Tables[0].NewRow();
                    r["vviet"] = ait.Text.Trim();
                    r["vanh"] = get_text(dt, "vviet='" + ait.Text.Trim() + "'", "vanh");
                    r["vphap"] = get_text(dt, "vviet='" + ait.Text.Trim() + "'", "vphap");
                    ds.Tables[0].Rows.Add(r);

                    if (amenu.DropDownItems.Count > 0)
                    {
                        amenu.Enabled = true;
                        f_Set_Node(ds, amenu, dt);
                    }
                }

            }
            //ds.WriteXml(@"..\..\..\language\" + frmName + ".xml", XmlWriteMode.WriteSchema);
        }
        
        private DataTable Creat_table()
        {
            DataTable dt = new DataTable("Language");
            DataColumn col = new DataColumn("Vviet", typeof(string));
            dt.Columns.Add(col);

            col = new DataColumn("Vanh", typeof(string));
            dt.Columns.Add(col);

            col = new DataColumn("Vphap", typeof(string));
            dt.Columns.Add(col);

            return dt;

        }
        
        private void write_mainmenu_to_xml(string frmName, MainMenu mnu, DataTable dt)
        {
            ds.Tables.Add(Creat_table());
            DataRow r;
            decimal id_lang = 0;
            for (int i = 0; i <= mnu.MenuItems.Count - 1; i++)
            {
                r = getrowbyid(dt, "vviet='" + mnu.MenuItems[i].Text.Trim() + "'");
                if (r == null)
                {
                    id_lang = f_get_id_Language;
                    upd_langage(id_lang, mnu.MenuItems[i].Text.Trim(), "", "");
                }                
                for (int j = 0; j <= mnu.MenuItems[i].MenuItems.Count - 1; j++)
                {
                    if (mnu.MenuItems[i].MenuItems[j].Text != "-")
                    {                        
                        r = getrowbyid(dt, "vviet='" + mnu.MenuItems[i].MenuItems[j].Text + "'");
                        if (r == null)
                        {
                            id_lang = f_get_id_Language;
                            upd_langage(id_lang, mnu.MenuItems[i].MenuItems[j].Text, "", "");
                        }
                    }
                    for (int x = 0; x <= mnu.MenuItems[i].MenuItems[j].MenuItems.Count - 1; x++)
                    {
                        if (mnu.MenuItems[i].MenuItems[j].MenuItems[x].Text != "-")
                        {                           
                            r = getrowbyid(dt, "vviet='" + mnu.MenuItems[i].MenuItems[j].MenuItems[x].Text + "'");
                            if (r == null)
                            {
                                id_lang = f_get_id_Language;
                                upd_langage(id_lang, mnu.MenuItems[i].MenuItems[j].MenuItems[x].Text, "", "");
                            }
                        }
                    }
                }
            }            
        }
        public void Read_MainMenu_to_Xml(string frmName, MainMenu mnu)
        {
            DataSet dsTemp = new DataSet();
            try
            {
                //dsTemp.ReadXml(@"..\..\..\Language\" + frmName + ".xml");
                dsTemp = m.get_data("select vietnamese as Vviet,english as Vanh,id,other from " + m.user + ".language order by id");
                write_mainmenu_to_xml(frmName, mnu, dsTemp.Tables[0]);
            }
            catch
            {
                //write_mainmenu_to_xml(frmName, mnu);
            }
        }

        public void Change_mainmenu_to_English(string frmName, MainMenu mnu)
        {
            flag_language = int.Parse(m.Thongso("Ngonngu").ToString());
            //ds.ReadXml(@"..\..\..\Language\" + frmName + ".xml");
            ds = m.get_data("select vietnamese as Vviet,english as Vanh,other from " + m.user + ".language where english<>'' order by id");
            for (int i = 0; i <= mnu.MenuItems.Count - 1; i++)
            {
                //==
                switch (flag_language)
                {
                    case 0:
                        mnu.MenuItems[i].Text = get_text(ds.Tables[0], "vviet='" +
                            mnu.MenuItems[i].Text + "'", "vviet");
                        break;
                    case 1:
                        mnu.MenuItems[i].Text = get_text(ds.Tables[0], "vviet='" +
                            mnu.MenuItems[i].Text + "'", "vanh");
                        break;
                    case 2:
                        mnu.MenuItems[i].Text = get_text(ds.Tables[0], "vviet='" +
                            mnu.MenuItems[i].Text + "'", "other");
                        break;
                }
                for (int j = 0; j <= mnu.MenuItems[i].MenuItems.Count - 1; j++)
                {
                    if (mnu.MenuItems[i].MenuItems[j].Text != "-")
                    {
                        switch (flag_language)
                        {
                            case 0:
                                mnu.MenuItems[i].MenuItems[j].Text = get_text(ds.Tables[0], "vviet='" +
                                    mnu.MenuItems[i].MenuItems[j].Text + "'", "vviet");
                                break;
                            case 1:
                                mnu.MenuItems[i].MenuItems[j].Text = get_text(ds.Tables[0], "vviet='" +
                                    mnu.MenuItems[i].MenuItems[j].Text + "'", "vanh");
                                break;
                            case 2:
                                mnu.MenuItems[i].MenuItems[j].Text = get_text(ds.Tables[0], "vviet='" +
                                    mnu.MenuItems[i].MenuItems[j].Text + "'", "other");
                                break;

                        }

                    }
                    for (int x = 0; x <= mnu.MenuItems[i].MenuItems[j].MenuItems.Count - 1; x++)
                    {
                        if (mnu.MenuItems[i].MenuItems[j].MenuItems[x].Text != "-")
                        {
                            switch (flag_language)
                            {
                                case 0:
                                    mnu.MenuItems[i].MenuItems[j].MenuItems[x].Text = get_text(ds.Tables[0], "vviet='" +
                                        mnu.MenuItems[i].MenuItems[j].MenuItems[x].Text + "'", "vviet");
                                    break;
                                case 1:
                                    mnu.MenuItems[i].MenuItems[j].MenuItems[x].Text = get_text(ds.Tables[0], "vviet='" +
                                        mnu.MenuItems[i].MenuItems[j].MenuItems[x].Text + "'", "vanh");
                                    break;
                                case 2:
                                    mnu.MenuItems[i].MenuItems[j].MenuItems[x].Text = get_text(ds.Tables[0], "vviet='" +
                                        mnu.MenuItems[i].MenuItems[j].MenuItems[x].Text + "'", "other");
                                    break;
                            }
                        }
                    }
                }
            }

        }
        #endregion
		#region DataGrid
		private void Write_dtgrid_to_xml(DataGridView  grid,string f_name)
		{
			ds.Tables.Clear();
			ds = new DataSet();
			ds.Tables.Add(Create_table());
			DataRow r;            
            for (int i = 0; i <= grid.Columns.Count - 1; i++)
            {
                r = ds.Tables[0].NewRow();
                r["vviet"] = grid.Columns[i].HeaderText.Trim();
                r["vanh"] = "";
                r["vphap"] = "";
                ds.Tables[0].Rows.Add(r);
            }
			//ds.WriteXml(@"..\..\..\language\"+f_name+".xml",XmlWriteMode.WriteSchema);
		}
		private void Write_dtgrid_to_xml(DataGridView  grid,string f_name,DataTable dt)
		{
			ds.Tables.Clear();
			ds = new DataSet();
			ds.Tables.Add(Create_table());
			DataRow r;           
            for (int i = 0; i <= grid.Columns.Count - 1; i++)
            {
                r = ds.Tables[0].NewRow();
                r["vviet"] = grid.Columns[i].HeaderText.Trim();
                r["vanh"] = get_text(dt, "vviet='" + grid.Columns[i].HeaderText.Trim() + "'", "vanh");
                r["vphap"] = get_text(dt, "vviet='" + grid.Columns[i].HeaderText.Trim() + "'", "vphap");
                ds.Tables[0].Rows.Add(r);
            }
			//ds.WriteXml(@"..\..\..\language\"+f_name+".xml",XmlWriteMode.WriteSchema);
		}        
        public void Read_dtgrid_to_Xml(DataGrid grid, string f_name)
        {
            DataSet dsTemp = new DataSet();
            try
            {
                //dsTemp.ReadXml(@"..\..\..\language\" + f_name + ".xml");
                dsTemp = m.get_data("select vietnamese as Vviet,english as Vanh,id from " + m.user + ".language order by id");
                Write_dtgrid2002_to_xml(grid, f_name, dsTemp.Tables[0]);
            }
            catch
            {
                //Write_dtgrid2002_to_xml(grid, f_name);
            }
        }
        private void Write_dtgrid_to_xml(DataGrid grid, string f_name, DataTable dt)
        {
            ds.Tables.Clear();
            ds = new DataSet();
            ds.Tables.Add(Create_table());
            DataRow r;
            GridColumnStylesCollection myColumns;
            foreach (DataGridTableStyle myTableStyle in grid.TableStyles)
            {
                myColumns = myTableStyle.GridColumnStyles;
                foreach (DataGridColumnStyle dgCol in myColumns)
                {
                    r = ds.Tables[0].NewRow();
                    r["vviet"] = dgCol.HeaderText.Trim();
                    r["vanh"] = get_text(dt, "vviet='" + dgCol.HeaderText.Trim() + "'", "vanh");
                    r["vphap"] = get_text(dt, "vviet='" + dgCol.HeaderText.Trim() + "'", "vphap");
                    ds.Tables[0].Rows.Add(r);
                }
                break;
            }
          //  ds.WriteXml(@"..\..\..\Language\" + f_name + ".xml", XmlWriteMode.WriteSchema);
        }
        private void Write_dtgrid_to_xml(DataGrid grid, string f_name)
        {
            ds.Tables.Clear();
            ds = new DataSet();
            ds.Tables.Add(Create_table());
            DataRow r;
            GridColumnStylesCollection myColumns;
            decimal id_lang = 0;
            foreach (DataGridTableStyle myTableStyle in grid.TableStyles)
            {
                myColumns = myTableStyle.GridColumnStyles;
                foreach (DataGridColumnStyle dgCol in myColumns)
                {
                    //r = ds.Tables[0].NewRow();
                    //r["vviet"] = dgCol.HeaderText.ToString();
                    //r["vanh"] = "";
                    //r["vphap"] = "";
                    //ds.Tables[0].Rows.Add(r);
                    r = m.getrowbyid(ds.Tables[0], "vviet='" + dgCol.HeaderText.ToString() + "'");
                    if (r == null)
                    {
                        id_lang = f_get_id_Language;
                        upd_langage(id_lang, dgCol.HeaderText.ToString(), "", "");
                    }
                }
                break;
            }
         //   ds.WriteXml(@"..\..\..\language\" + f_name + ".xml", XmlWriteMode.WriteSchema);
        }
        public void Change_dtgrid_HeaderText_to_English(DataGrid grid, string f_name)
        {
            //ds.ReadXml(@"..\..\..\language\" + f_name + ".xml");
            ds = m.get_data("select vietnamese as Vviet,english as Vanh,other from " + m.user + ".language where english<>'' order by id");
            GridColumnStylesCollection myColumns;
            foreach (DataGridTableStyle myTableStyle in grid.TableStyles)
            {
                myColumns = myTableStyle.GridColumnStyles;
                foreach (DataGridColumnStyle dgCol in myColumns)
                {
                    dgCol.HeaderText = get_text(ds.Tables[0], "vviet='" + dgCol.HeaderText.ToString() + "'");
                }
                break;
            }

        }
        //============
        public void Read_dtgrid2002_to_Xml(DataGrid grid, string f_name)
        {
            DataSet dsTemp = new DataSet();
            try
            {
                //dsTemp.ReadXml(@"..\..\..\language\" + f_name + ".xml");
                dsTemp = m.get_data("select vietnamese as Vviet,english as Vanh,id from " + m.user + ".language order by id");
                Write_dtgrid2002_to_xml(grid, f_name, dsTemp.Tables[0]);
            }
            catch
            {
                //Write_dtgrid2002_to_xml(grid, f_name);
            }
        }
        private void Write_dtgrid2002_to_xml(DataGrid grid, string f_name, DataTable dt)
        {
            ds.Tables.Clear();
            ds = new DataSet();
            ds.Tables.Add(Create_table());
            DataRow r;
            GridColumnStylesCollection myColumns;
            decimal id_lang = 0;
            foreach (DataGridTableStyle myTableStyle in grid.TableStyles)
            {
                myColumns = myTableStyle.GridColumnStyles;
                foreach (DataGridColumnStyle dgCol in myColumns)
                {
                    //r = ds.Tables[0].NewRow();
                    //r["vviet"] = dgCol.HeaderText.Trim();
                    //r["vanh"] = get_text(dt, "vviet='" + dgCol.HeaderText.Trim() + "'", "vanh");
                    //r["vphap"] = get_text(dt, "vviet='" + dgCol.HeaderText.Trim() + "'", "vphap");
                    //ds.Tables[0].Rows.Add(r);
                    r = m.getrowbyid(dt, "vviet='" + dgCol.HeaderText.ToString() + "'");
                    if (r == null)
                    {
                        id_lang = f_get_id_Language;
                        upd_langage(id_lang, dgCol.HeaderText.ToString(), "", "");
                    }
                }
                break;
            }
           // ds.WriteXml(@"..\..\..\Language\" + f_name + ".xml", XmlWriteMode.WriteSchema);
        }
        
        public void Change_dtgrid2002_HeaderText_to_English(DataGrid grid, string f_name)
        {
            //ds.ReadXml(@"..\..\..\language\" + f_name + ".xml");
            ds = m.get_data("select vietnamese as Vviet,english as Vanh,other from " + m.user + ".language where english<>'' order by id");
            GridColumnStylesCollection myColumns;
            foreach (DataGridTableStyle myTableStyle in grid.TableStyles)
            {
                myColumns = myTableStyle.GridColumnStyles;
                foreach (DataGridColumnStyle dgCol in myColumns)
                {
                    dgCol.HeaderText = get_text(ds.Tables[0], "vviet='" + dgCol.HeaderText.ToString() + "'");
                }
                break;
            }

        }
        #endregion
        #region UserControl
        
        public void Write_usrclt_to_Xml(string usrCltname, UserControl usrctl, DataTable dt)
        {
            ds = new DataSet();
            ds.Tables.Add(Create_table());
            string lbl = "";
            DataRow r;
            TabControl tabclt;
            Panel p1;
            decimal id_lang=0;
            foreach (Control ctl in usrctl.Controls)
            {
                switch (ctl.GetType().ToString())
                {

                    case "System.Windows.Forms.SplitContainer":
                        Read_SplitContainer((SplitContainer)ctl, ds, dt);
                        break;

                    case "System.Windows.Forms.Panel":
                        p1 = (Panel)ctl;
                        Read_Panel(p1, ds, dt);
                        break;
                    case "System.Windows.Forms.GroupBox":
                        //r = ds.Tables[0].NewRow();
                        //r["vviet"] = ctl.Text.Trim();
                        //r["vanh"] = get_text(dt, "vviet='" + ctl.Text.Trim() + "'", "vanh");
                        //r["vphap"] = "";
                        //ds.Tables[0].Rows.Add(r);
                        r = getrowbyid(dt, "vviet='" + ctl.Text.Trim() + "'");
                        if (r == null)
                        {
                            id_lang = f_get_id_Language;
                            upd_langage(id_lang, ctl.Text.Trim(), "", "");
                        }
                        Read_GroupBox((GroupBox)ctl, ds, dt);
                        break;

                    case "MaskedTextBox.MaskedTextBox":
                    case "MaskedBox.MaskedBox":
                        break;
                    case "System.Windows.Forms.TabControl":
                        tabclt = (TabControl)ctl;
                        foreach (TabPage tab in tabclt.TabPages)
                        {
                            //r = ds.Tables[0].NewRow();
                            //r["vviet"] = tab.Text.Trim();
                            //r["vanh"] = get_text(dt, "vviet='" + tab.Text.Trim() + "'", "vanh");
                            //r["vphap"] = get_text(dt, "vviet='" + tab.Text.Trim() + "'", "vphap");
                            //ds.Tables[0].Rows.Add(r);
                            r = getrowbyid(dt, "vviet='" + tab.Text.Trim() + "'");
                            if (r == null)
                            {
                                id_lang = f_get_id_Language;
                                upd_langage(id_lang, tab.Text.Trim(), "", "");
                            }
                            Read_TabControl(tab, ds, dt);
                        }
                        break;
                    case "System.Windows.Forms.DataGridView":
                        DataGridView gv = (DataGridView)ctl;
                        for (int i = 0; i <= gv.Columns.Count - 1; i++)
                        {
                            //r = ds.Tables[0].NewRow();
                            //r["vviet"] = gv.Columns[i].HeaderText.Trim();
                            //r["vanh"] = get_text(dt, "vviet='" + gv.Columns[i].HeaderText.Trim() + "'", "vanh");
                            //r["vphap"] = get_text(dt, "vviet='" + gv.Columns[i].HeaderText.Trim() + "'", "vphap");
                            //ds.Tables[0].Rows.Add(r);
                            r = getrowbyid(dt, "vviet='" + gv.Columns[i].HeaderText.Trim() + "'");
                            if (r == null)
                            {
                                id_lang = f_get_id_Language;
                                upd_langage(id_lang, gv.Columns[i].HeaderText.Trim(), "", "");
                            }
                        }
                        break;
                    case "System.Windows.Forms.ToolStrip":
                        ToolStrip tlbtrp = (ToolStrip)(ctl);
                        ToolStripSplitButton toolMenu;//= (ToolStripMenuItem)ttrip;
                        foreach (ToolStripItem ttrip in tlbtrp.Items)
                        {
                            lbl = ttrip.Text;
                            if (lbl != "")
                            {
                                //r = ds.Tables[0].NewRow();
                                //r["vviet"] = lbl;
                                //r["vanh"] = get_text(dt, "vviet='" + lbl + "'", "vanh");
                                //r["vphap"] = get_text(dt, "vviet='" + lbl + "'", "vphap");
                                //ds.Tables[0].Rows.Add(r);
                                r = getrowbyid(dt, "vviet='" + lbl + "'");
                                if (r == null)
                                {
                                    id_lang = f_get_id_Language;
                                    upd_langage(id_lang, lbl, "", "");
                                }
                            }

                            if (ttrip.GetType().ToString() == "System.Windows.Forms.ToolStripSplitButton")
                            {
                                toolMenu = (ToolStripSplitButton)ttrip;
                                try
                                {

                                    foreach (ToolStripItem ait in toolMenu.DropDownItems)
                                    {
                                        if (ait.GetType().ToString() == "System.Windows.Forms.ToolStripMenuItem")
                                        {
                                            ToolStripMenuItem amenu = (ToolStripMenuItem)(ait);
                                            //r = ds.Tables[0].NewRow();
                                            //r["vviet"] = ait.Text.Trim();
                                            //r["vanh"] = get_text(dt, "vviet='" + ait.Text.Trim() + "'", "vanh");
                                            //r["vphap"] = get_text(dt, "vviet='" + ait.Text.Trim() + "'", "vphap");
                                            //ds.Tables[0].Rows.Add(r);
                                            r = getrowbyid(dt, "vviet='" + ait.Text.Trim() + "'");
                                            if (r == null)
                                            {
                                                id_lang = f_get_id_Language;
                                                upd_langage(id_lang, ait.Text.Trim(), "", "");
                                            }
                                            if (amenu.DropDownItems.Count > 0)
                                            {
                                                amenu.Enabled = true;
                                                f_Set_Node(ds, amenu, dt);
                                            }
                                        }
                                    }
                                }
                                catch
                                {
                                }
                            }
                        }
                        break;
                    default:
                        if (ctl.GetType().ToString() != "MaskedBox.MaskedBox")
                        {
                            if (ctl.GetType().ToString() != "System.Windows.Forms.ComboBox")
                            {
                                if (ctl.GetType().ToString() != "System.Windows.Forms.TextBox")
                                {
                                    lbl = ctl.Text.Trim();
                                    if (lbl != "")
                                    {
                                        //r = ds.Tables[0].NewRow();
                                        //r["vviet"] = ctl.Text.Trim();
                                        //r["vanh"] = get_text(dt, "vviet='" + ctl.Text.Trim() + "'", "vanh");
                                        //r["vphap"] = get_text(dt, "vviet='" + ctl.Text.Trim() + "'", "vphap");
                                        //ds.Tables[0].Rows.Add(r);
                                        r = getrowbyid(dt, "vviet='" + ctl.Text.Trim() + "'");
                                        if (r == null)
                                        {
                                            id_lang = f_get_id_Language;
                                            upd_langage(id_lang, ctl.Text.Trim(), "", "");
                                        }
                                    }
                                }
                            }
                        }
                        break;
                }
            }
            //r = ds.Tables[0].NewRow();
            //r["vviet"] = usrctl.Text.Trim();
            //r["vanh"] = get_text(dt, "vviet='" + usrctl.Text.Trim() + "'", "vanh");
            //r["vphap"] = get_text(dt, "vviet='" + usrctl.Text.Trim() + "'", "vphap");
            //ds.Tables[0].Rows.Add(r);
            //ds.WriteXml(@"..\..\..\language\" + usrCltname + ".xml", XmlWriteMode.WriteSchema);
            r = getrowbyid(dt, "vviet='" + usrctl.Text.Trim() + "'");
            if (r == null)
            {
                id_lang = f_get_id_Language;
                upd_langage(id_lang, usrctl.Text.Trim(), "", "");
            }
        }
        public void Changelanguage_usrclt_to_English(string usrCltname, UserControl usrctl)
        {
            //ds.ReadXml(@"..\..\..\language\" + usrCltname + ".xml");
            ds = m.get_data("select vietnamese as Vviet,english as Vanh,other from " + m.user + ".language where english<>'' order by id");
            string lbl = "", m_ngonngu = "";
            string rong = "";
            char[] c = new char[] { ' ' };
            TabControl tabclt;
            Panel p_c;
            flag_language = int.Parse(m.Thongso("Ngonngu").ToString());
            //Nhan sua.
            if (flag_language == 0) return;
            switch (flag_language)
            {
                case 0:
                    m_ngonngu = "Vviet";
                    break;
                case 1:
                    m_ngonngu = "Vanh";
                    break;
                case 2:
                    m_ngonngu = "other";
                    break;
            }
            usrctl.Text = get_text(ds.Tables[0], "vviet='" + usrctl.Text + "'", m_ngonngu);
            foreach (Control ctl in usrctl.Controls)
            {
                switch (ctl.GetType().ToString())
                {
                    case "System.Windows.Forms.ToolStrip":
                        ToolStrip tlbtrp = (ToolStrip)(ctl);
                        ToolStripSplitButton toolMenu;//= (ToolStripSplitButton
                        foreach (ToolStripItem ttrip in tlbtrp.Items)
                        {
                            lbl = ttrip.Text;
                            if (lbl != "")
                                ttrip.Text = get_text(ds.Tables[0], "vviet='" + lbl + "'");
                            if (ttrip.GetType().ToString() == "System.Windows.Forms.ToolStripSplitButton")
                            {
                                toolMenu = (ToolStripSplitButton)ttrip;
                                foreach (ToolStripItem ait in toolMenu.DropDownItems)
                                {
                                    if (ait.GetType().ToString() == "System.Windows.Forms.ToolStripMenuItem")
                                    {
                                        ToolStripMenuItem amenu = (ToolStripMenuItem)(ait);
                                        amenu.Text = get_text(ds.Tables[0], "vviet='" +
                                            amenu.Text + "'", "vanh");
                                        if (amenu.DropDownItems.Count > 0)
                                        {
                                            amenu.Enabled = true;
                                            f_change_submenu(ds, amenu);
                                        }
                                    }
                                }

                            }

                        }
                        break;
                    case "System.Windows.Forms.SplitContainer":
                        Change_SplitContainer((SplitContainer)ctl, ds);
                        break;
                    case "System.Windows.Forms.Panel":
                        p_c = (Panel)ctl;
                        Change_Panel(p_c, ds);
                        break;
                    case "System.Windows.Forms.GroupBox":
                        ctl.Text = get_text(ds.Tables[0], "vviet='" + ctl.Text + "'");
                        Change_groupbox((GroupBox)ctl, ds);
                        break;
                    case "System.Windows.Forms.Label":
                        string rong1 = "";
                        lbl = ctl.Text;
                        if (ctl.Name.IndexOf("l_") >= 0)
                            ctl.Text = rong1.PadLeft(7, ' ') + get_text(ds.Tables[0], "vviet='" + lbl.Trim() + "'").Trim();
                        else
                            ctl.Text = get_text(ds.Tables[0], "vviet='" + lbl.Trim() + "'").Trim();
                        break;
                    case "System.Windows.Forms.Button":
                        lbl = ctl.Text.TrimEnd();
                        string[] arr = new string[] { "" };
                        if (lbl.IndexOfAny(c) == 0)
                            arr = lbl.Split(' ');
                        ctl.Text = ((arr.Length > 1) ? rong.PadLeft(7, ' ') : "") + get_text(ds.Tables[0], "vviet='" + lbl.Trim() + "'").Trim();
                        break;
                    case "System.Windows.Forms.TabControl":
                        tabclt = (TabControl)ctl;
                        foreach (TabPage tab in tabclt.TabPages)
                        {
                            tab.Text = get_text(ds.Tables[0], "vviet='" + tab.Text + "'");
                            Change_TabControl(tab, ds);
                        }
                        break;
                    case "System.Windows.Forms.DataGridView":
                        DataGridView gv = (DataGridView)ctl;
                        for (int i = 0; i <= gv.Columns.Count - 1; i++)
                        {
                            gv.Columns[i].HeaderText = get_text(ds.Tables[0], "vviet='" + gv.Columns[i].HeaderText.ToString() + "'");
                        }
                        break;
                    default:
                        if (ctl.GetType().ToString() == "MaskedBox.MaskedBox")
                            continue;
                        if (ctl.GetType().ToString() == "MaskedTextBox.MaskedTextBox")
                            continue;
                        lbl = ctl.Text;
                        //lbl=lbl.Replace("&","");
                        if (lbl!="")
                        ctl.Text = get_text(ds.Tables[0], "vviet='" + lbl + "'");
                        break;
                }
            }
        }
        #endregion
    }
}
