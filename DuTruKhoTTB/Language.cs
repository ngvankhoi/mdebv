using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using LibTTB;

namespace DuTruKhoTTB
{
	/// <summary>
	/// Summary description for ClassLib.
	/// </summary>
	public class Language
	{
        Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		DataSet ds = new DataSet();
		int flag_language=0;
		AccessData m = new AccessData();
		public Language()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public void Write_to_Xml(string frmName, Form frm)
		{
			ds.Tables.Add(Creat_table());
			string lbl="";
			DataRow r;
			foreach(Control ctl in frm.Controls)
			{
				
				switch (ctl.GetType().ToString())
				{
					case "System.Windows.Forms.Panel":
					
						foreach(Control ctl1 in ctl.Controls)
						{
							if (ctl1.GetType().ToString()=="MaskedBox.MaskedBox")
								continue;
							if (ctl1.GetType().ToString()=="MaskedTextBox.MaskedTextBox")
								continue;
							if(ctl1.GetType().ToString()!="System.Windows.Forms.ComboBox") 
							{
								if (ctl1.GetType().ToString()!="System.Windows.Forms.TextBox")
								{
									r = ds.Tables[0].NewRow();
									r["vviet"]=ctl1.Text.Trim();
									r["vanh"]="";
									r["vphap"]="";
									ds.Tables[0].Rows.Add(r);
								}
							}
						}
						break;
					case "System.Windows.Forms.GroupBox":
                        r = ds.Tables[0].NewRow();
                        r["vviet"] = ctl.Text.Trim();
                        r["vanh"] = "";
                        r["vphap"] = "";
                        ds.Tables[0].Rows.Add(r);
						foreach(Control ctl1 in ctl.Controls)
						{
							if (ctl1.GetType().ToString()=="MaskedBox.MaskedBox")
								continue;
							if (ctl1.GetType().ToString()=="MaskedTextBox.MaskedTextBox")
								continue;
							if(ctl1.GetType().ToString()!="System.Windows.Forms.ComboBox") 
							{
								if (ctl1.GetType().ToString()!="System.Windows.Forms.TextBox")
								{
									r = ds.Tables[0].NewRow();
									r["vviet"]=ctl1.Text.Trim();
									r["vanh"]="";
									r["vphap"]="";
									ds.Tables[0].Rows.Add(r);
								}
							}
						}
						break;
					
					case "MaskedTextBox.MaskedTextBox":
					case "MaskedBox.MaskedBox":
						continue;
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
										r = ds.Tables[0].NewRow();
										r["vviet"]=ctl.Text.Trim();
										r["vanh"]="";
										r["vphap"]="";
										ds.Tables[0].Rows.Add(r);
									}
								}
							}
						}
						break;
				}
			}
			r = ds.Tables[0].NewRow();
			r["vviet"]=frm.Text.Trim();
			r["vanh"]="";
			r["vphap"]="";
			ds.Tables[0].Rows.Add(r);
			ds.WriteXml(@"..\..\..\Language\"+frmName+".xml",XmlWriteMode.WriteSchema);
		}

		public void Changelanguage_to_English(string frmName, Form frm)
		{
            string lbl = "", m_ngonngu = "";
            string rong = "";
            char[] c = new char[] { ' ' };
            TabControl tabclt;
            flag_language = int.Parse(m.Thongso("Ngonngu").ToString());
            if (flag_language == 0) return;
            if (File.Exists(@"..\..\..\Language\" + frmName + ".xml")) ds.ReadXml(@"..\..\..\Language\" + frmName + ".xml");
            else
            {
                MessageBox.Show("File Not found '" + @"..\..\..\Language\" + frmName + ".xml" + "'");
                return;
            }
			switch (flag_language)
			{
				case 0:
					m_ngonngu="Vviet";
					break;
				case 1:
					m_ngonngu="Vanh";
					break;
				case 2:
					m_ngonngu="Vphap";
					break;
			}
			frm.Text=get_text(ds.Tables[0],"vviet='"+frm.Text+"'",m_ngonngu);
			foreach(Control ctl in frm.Controls)
			{
				switch (ctl.GetType().ToString())
				{
					case "System.Windows.Forms.Panel":
					
						foreach(Control ctl1 in ctl.Controls)
						{
							if (ctl1.GetType().ToString()=="MaskedBox.MaskedBox")
								continue;
							if (ctl1.GetType().ToString()=="MaskedTextBox.MaskedTextBox")
								continue;
							if (ctl1.GetType().ToString()=="System.Windows.Forms.Button")
							{
								lbl=ctl1.Text.TrimEnd();
								string[] arr1 = lbl.Split(' ');
								ctl1.Text=((arr1.Length>0)?rong.PadLeft(7,' '):"")+get_text(ds.Tables[0],"vviet='"+lbl.Trim()+"'").Trim();
								continue;
							}
							lbl=ctl1.Text.Trim();
							ctl1.Text=get_text(ds.Tables[0],"vviet='"+lbl+"'");
							foreach(Control ctl2 in ctl1.Controls)
							{
								if (ctl2.GetType().ToString()=="MaskedBox.MaskedBox")
									continue;
								if (ctl2.GetType().ToString()=="MaskedTextBox.MaskedTextBox")
									continue;
								lbl=ctl2.Text;
								ctl2.Text=get_text(ds.Tables[0],"vviet='"+lbl+"'");
							}
						}
						break;
					case "System.Windows.Forms.GroupBox":
                        ctl.Text = get_text(ds.Tables[0], "vviet='" + ctl.Text + "'");
						foreach(Control ctl1 in ctl.Controls)
						{
							if (ctl1.GetType().ToString()=="MaskedBox.MaskedBox")
								continue;
							if (ctl1.GetType().ToString()=="MaskedTextBox.MaskedTextBox")
								continue;
							ctl1.Text=get_text(ds.Tables[0],"vviet='"+ctl1.Text+"'");
						}
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
							foreach(Control ct in tab.Controls )
							{
								switch(ct.GetType().ToString())
								{
									case "MaskedBox.MaskedBox":
									case "System.Windows.Forms.ComboBox":
									case "System.Windows.Forms.TextBox":
										break;
									case "System.Windows.Forms.GroupBox":
										ct.Text=get_text(ds.Tables[0],"vviet='"+ct.Text+"'");
										foreach(Control ct1 in ct.Controls)
											ct1.Text=get_text(ds.Tables[0],"vviet='"+ct1.Text+"'");
										break;
									case "System.Windows.Forms.Button":
										lbl=ct.Text.TrimEnd();
                                        string[] arr3= new string[] {""};
                                        if (lbl.IndexOfAny(c) == 0)
                                            arr3 = lbl.Split(' ');
										ct.Text=((arr3.Length>1)?rong.PadLeft(7,' '):"")+get_text(ds.Tables[0],"vviet='"+lbl.Trim()+"'").Trim();
										break;
									default:
										lbl=ct.Text.Trim();
										if (lbl!="")
										{
											ct.Text=get_text(ds.Tables[0],"vviet='"+ct.Text+"'");
										}
											
										break;									
								}
							}
						}
						break;
					default:
						if (ctl.GetType().ToString()=="MaskedBox.MaskedBox")
							continue;
						if (ctl.GetType().ToString()=="MaskedTextBox.MaskedTextBox")
							continue;
						lbl=ctl.Text;
						//lbl=lbl.Replace("&","");
						ctl.Text=get_text(ds.Tables[0],"vviet='"+lbl+"'");
						break;
				}
			}
		}
		public string Change_language_MessageText(string s_text)
		{
			string gttv="";
			flag_language=int.Parse(m.Thongso("Ngonngu").ToString());
            if (flag_language != 0)
            {
                if (File.Exists(@"..\..\..\Language\Messagebox.xml")) ds.ReadXml(@"..\..\..\Language\Messagebox.xml");
                else
                {
                    MessageBox.Show("File Not found '" + @"..\..\..\Language\Messagebox.xml"+"'");
                    return s_text;
                }
                switch (flag_language)
                {
                    case 0:
                        gttv = get_text(ds.Tables[0], "vviet='" + s_text + "'", "Vviet");
                        break;
                    case 1:
                        gttv = get_text(ds.Tables[0], "vviet='" + s_text + "'", "Vanh");
                        break;
                    case 2:
                        gttv = get_text(ds.Tables[0], "vviet='" + s_text + "'", "Vphap");
                        break;
                }
            }
			return (gttv=="")?s_text:gttv.Trim();
		}
		public void Changelanguage_to_Vietnam(string frmName, Form frm)
		{
			ds.ReadXml(@"..\..\..\Language\"+frmName+".xml");
			string lbl="";
			foreach(Control ctl in frm.Controls)
			{
				switch (ctl.GetType().ToString())
				{
					case "System.Windows.Forms.Panel":
					
						foreach(Control ctl1 in ctl.Controls)
						{
							lbl=ctl1.Text;
							lbl=lbl.Replace("&","");
							ctl1.Text=get_text(ds.Tables[0],"vanh='"+lbl+"'","Vviet");
						}
						break;
					case "System.Windows.Forms.GroupBox":
					
						foreach(Control ctl1 in ctl.Controls)
						{
							lbl=ctl1.Text;
							lbl=lbl.Replace("&","");
							ctl1.Text=get_text(ds.Tables[0],"vanh='"+lbl+"'","Vviet");
						}
						break;
					
					case "MaskedTextBox.MaskedTextBox":
					case "MaskedBox.MaskedBox":
						continue;
					default:
						lbl=ctl.Text;
						lbl=lbl.Replace("&","");
						ctl.Text=get_text(ds.Tables[0],"vanh='"+lbl+"'","Vviet");
						break;
				}
			}
		}
		
		private DataTable Creat_table()
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
						gttv=row["vphap"].ToString();
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
				dsTemp.ReadXml(@"..\..\..\Language\"+frmName+".xml");
				Write_to_Xml(frmName,frm,dsTemp.Tables[0]);
			}
			catch
			{
				Write_to_Xml(frmName,frm);
			}
		}
		public void Write_to_Xml(string frmName, Form frm,DataTable dt)
		{
			ds.Tables.Add(Creat_table());
			string lbl="";
			DataRow r;
			TabControl tabclt;
			foreach(Control ctl in frm.Controls)
			{
				switch (ctl.GetType().ToString())
				{
					case "System.Windows.Forms.Panel":
						
						foreach(Control ctl1 in ctl.Controls)
						{
							switch (ctl1.GetType().ToString())
							{
								case "MaskedBox.MaskedBox":
								case "MaskedTextBox.MaskedTextBox":
										break;
								case "System.Windows.Forms.Panel":
										foreach(Control ctl2 in ctl1.Controls)
										{
											if (ctl2.GetType().ToString()=="MaskedBox.MaskedBox")
												continue;
											if (ctl2.GetType().ToString()=="MaskedTextBox.MaskedTextBox")
												continue;
											if(ctl2.GetType().ToString()!="System.Windows.Forms.ComboBox") 
											{
												if (ctl2.GetType().ToString()!="System.Windows.Forms.TextBox")
												{
													r = ds.Tables[0].NewRow();
													r["vviet"]=ctl2.Text.Trim();
													r["vanh"]=get_text(dt,"vviet='"+ctl2.Text.Trim()+"'","vanh");
													r["vphap"]=get_text(dt,"vviet='"+ctl2.Text.Trim()+"'","vphap");
													ds.Tables[0].Rows.Add(r);
												}
											}
										}
									break;
								default:
										if (ctl1.GetType().ToString()!="System.Windows.Forms.TextBox")
										{
											r = ds.Tables[0].NewRow();
											r["vviet"]=ctl1.Text.Trim();
											r["vanh"]=get_text(dt,"vviet='"+ctl1.Text.Trim()+"'","vanh");
											r["vphap"]=get_text(dt,"vviet='"+ctl1.Text.Trim()+"'","vphap");
											ds.Tables[0].Rows.Add(r);
										}
									break;
							}
							//end
						}
						break;
					case "System.Windows.Forms.GroupBox":
                        r = ds.Tables[0].NewRow();
                        r["vviet"] = ctl.Text.Trim();
                        r["vanh"] = get_text(dt, "vviet='" + ctl.Text.Trim() + "'", "vanh");
                        r["vphap"] = "";
                        ds.Tables[0].Rows.Add(r);
						foreach(Control ctl1 in ctl.Controls)
						{
							if (ctl1.GetType().ToString()=="MaskedBox.MaskedBox")
								continue;
							if (ctl1.GetType().ToString()=="MaskedTextBox.MaskedTextBox")
								continue;
							if(ctl1.GetType().ToString()!="System.Windows.Forms.ComboBox") 
							{
								if (ctl1.GetType().ToString()!="System.Windows.Forms.TextBox")
								{
									r = ds.Tables[0].NewRow();
									r["vviet"]=ctl1.Text.Trim();
									r["vanh"]=get_text(dt,"vviet='"+ctl1.Text.Trim()+"'","vanh");
									r["vphap"]=get_text(dt,"vviet='"+ctl1.Text.Trim()+"'","vphap");
									ds.Tables[0].Rows.Add(r);
								}
							}
						}
						break;
					
					case "MaskedTextBox.MaskedTextBox":
					case "MaskedBox.MaskedBox":
						break;
					case "System.Windows.Forms.TabControl":
						tabclt=(TabControl)ctl;
						foreach(TabPage tab in tabclt.TabPages )
						{
							foreach(Control ct in tab.Controls )
							{
								switch(ct.GetType().ToString())
								{
									case "MaskedBox.MaskedBox":
									case "System.Windows.Forms.ComboBox":
									case "System.Windows.Forms.TextBox":
											break;
									case "System.Windows.Forms.GroupBox":
                                        r = ds.Tables[0].NewRow();
                                        r["vviet"] = ct.Text.Trim();
                                        r["vanh"] = get_text(dt, "vviet='" + ct.Text.Trim() + "'", "vanh");
                                        r["vphap"] = get_text(dt, "vviet='" + ct.Text.Trim() + "'", "vphap");
                                        ds.Tables[0].Rows.Add(r);
										foreach(Control ct1 in ct.Controls)
										{
											r = ds.Tables[0].NewRow();
											r["vviet"]=ct1.Text.Trim();
											r["vanh"]=get_text(dt,"vviet='"+ct1.Text.Trim()+"'","vanh");
											r["vphap"]=get_text(dt,"vviet='"+ct1.Text.Trim()+"'","vphap");
											ds.Tables[0].Rows.Add(r);
											
										}
										break;
									default:
										lbl=ct.Text.Trim();
										if (lbl!="")
										{
											r = ds.Tables[0].NewRow();
											r["vviet"]=ct.Text.Trim();
											r["vanh"]=get_text(dt,"vviet='"+ct.Text.Trim()+"'","vanh");
											r["vphap"]=get_text(dt,"vviet='"+ct.Text.Trim()+"'","vphap");
											ds.Tables[0].Rows.Add(r);
										}
											
									break;									
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
										r = ds.Tables[0].NewRow();
										r["vviet"]=ctl.Text.Trim();
										r["vanh"]=get_text(dt,"vviet='"+ctl.Text.Trim()+"'","vanh");
										r["vphap"]=get_text(dt,"vviet='"+ctl.Text.Trim()+"'","vphap");
										ds.Tables[0].Rows.Add(r);
									}
								}
							}
						}
						break;
				}
			}
			r = ds.Tables[0].NewRow();
			r["vviet"]=frm.Text.Trim();
			r["vanh"]=get_text(dt,"vviet='"+frm.Text.Trim()+"'","vanh");
			r["vphap"]=get_text(dt,"vviet='"+frm.Text.Trim()+"'","vphap");
			ds.Tables[0].Rows.Add(r);
			ds.WriteXml(@"..\..\..\Language\"+frmName+".xml",XmlWriteMode.WriteSchema);
		}
		#region MenuBar
		private void write_mainmenu_to_xml(string frmName,MainMenu mnu )
		{
			ds.Tables.Add(Creat_table());
			DataRow r;
			for(int i=0;i<=mnu.MenuItems.Count-1;i++)
			{
				r = ds.Tables[0].NewRow();
				r["vviet"]=mnu.MenuItems[i].Text.Trim();
				r["vanh"]="";
				r["vphap"]="";
				ds.Tables[0].Rows.Add(r);
				for(int j=0;j<=mnu.MenuItems[i].MenuItems.Count-1;j++)
				{
					if (mnu.MenuItems[i].MenuItems[j].Text!="-")
					{
						r = ds.Tables[0].NewRow();
						r["vviet"]=mnu.MenuItems[i].MenuItems[j].Text;
						r["vanh"]="";
						r["vphap"]="";
						ds.Tables[0].Rows.Add(r);
					}
					for(int x=0;x<=mnu.MenuItems[i].MenuItems[j].MenuItems.Count-1;x++)
					{
						if (mnu.MenuItems[i].MenuItems[j].MenuItems[x].Text!="-")
						{
							r = ds.Tables[0].NewRow();
							r["vviet"]=mnu.MenuItems[i].MenuItems[j].MenuItems[x].Text;
							r["vanh"]="";
							r["vphap"]="";
							ds.Tables[0].Rows.Add(r);
						}
					}
				}
			}			
			ds.WriteXml(@"..\..\..\Language\"+frmName+".xml",XmlWriteMode.WriteSchema);
		}
		private void write_mainmenu_to_xml(string frmName,MainMenu mnu, DataTable dt )
		{
			ds.Tables.Add(Creat_table());
			DataRow r;
			for(int i=0;i<=mnu.MenuItems.Count-1;i++)
			{
				r = ds.Tables[0].NewRow();
				r["vviet"]=mnu.MenuItems[i].Text.Trim();
				r["vanh"]=get_text(dt,"vviet='"+mnu.MenuItems[i].Text.Trim()+"'","vanh");
				r["vphap"]=get_text(dt,"vviet='"+mnu.MenuItems[i].Text.Trim()+"'","vphap");
				ds.Tables[0].Rows.Add(r);
				for(int j=0;j<=mnu.MenuItems[i].MenuItems.Count-1;j++)
				{
					if (mnu.MenuItems[i].MenuItems[j].Text!="-")
					{
						r = ds.Tables[0].NewRow();
						r["vviet"]=mnu.MenuItems[i].MenuItems[j].Text;
						r["vanh"]=get_text (dt,"vviet='"+mnu.MenuItems[i].MenuItems[j].Text+"'","vanh");
						r["vphap"]=get_text(dt,"vviet='"+mnu.MenuItems[i].MenuItems[j].Text+"'","vphap");
						ds.Tables[0].Rows.Add(r);
					}
					for(int x=0;x<=mnu.MenuItems[i].MenuItems[j].MenuItems.Count-1;x++)
					{
						if (mnu.MenuItems[i].MenuItems[j].MenuItems[x].Text!="-")
						{
							r = ds.Tables[0].NewRow();
							r["vviet"]=mnu.MenuItems[i].MenuItems[j].MenuItems[x].Text;
							r["vanh"]=get_text(dt,"vviet='"+mnu.MenuItems[i].MenuItems[j].MenuItems[x].Text+"'","vanh");
							r["vphap"]=get_text(dt,"vviet='"+mnu.MenuItems[i].MenuItems[j].MenuItems[x].Text+"'","vphap");
							ds.Tables[0].Rows.Add(r);
						}
					}
				}
			}			
			ds.WriteXml(@"..\..\..\Language\"+frmName+".xml",XmlWriteMode.WriteSchema);
		}
		public void Read_MainMenu_to_Xml(string frmName,MainMenu mnu)
		{
			DataSet dsTemp = new DataSet();
			try
			{
				dsTemp.ReadXml(@"..\..\..\Language\"+frmName+".xml");
				write_mainmenu_to_xml(frmName,mnu,dsTemp.Tables[0]);
			}
			catch
			{
				write_mainmenu_to_xml(frmName,mnu);
			}
		}
		
		public void Change_mainmenu_to_English(string frmName,MainMenu mnu )
		{
            flag_language = int.Parse(m.Thongso("Ngonngu").ToString());
            ds.ReadXml(@"..\..\..\Language\"+frmName+".xml");
			for(int i=0;i<=mnu.MenuItems.Count-1;i++)
			{
				//==
				switch (flag_language)
				{
					case 0:
						mnu.MenuItems[i].Text=get_text(ds.Tables[0],"vviet='"+
							mnu.MenuItems[i].Text+"'","vviet");
						break;
					case 1:
						mnu.MenuItems[i].Text=get_text(ds.Tables[0],"vviet='"+
							mnu.MenuItems[i].Text+"'","vanh");
						break;
				}
				for(int j=0;j<=mnu.MenuItems[i].MenuItems.Count-1;j++)
				{
					if (mnu.MenuItems[i].MenuItems[j].Text!="-")
					{
						switch (flag_language)
						{
							case 0:
							mnu.MenuItems[i].MenuItems[j].Text=get_text(ds.Tables[0],"vviet='"+
								mnu.MenuItems[i].MenuItems[j].Text+"'","vviet");
								break;
							case 1:
								mnu.MenuItems[i].MenuItems[j].Text=get_text(ds.Tables[0],"vviet='"+
									mnu.MenuItems[i].MenuItems[j].Text+"'","vanh");
								break;
							case 2:
								mnu.MenuItems[i].MenuItems[j].Text=get_text(ds.Tables[0],"vviet='"+
									mnu.MenuItems[i].MenuItems[j].Text+"'","vphap");
								break;

						}
																	
					}
					for(int x=0;x<=mnu.MenuItems[i].MenuItems[j].MenuItems.Count-1;x++)
					{
						if (mnu.MenuItems[i].MenuItems[j].MenuItems[x].Text!="-")
						{
							switch (flag_language)
							{
								case 0:
									mnu.MenuItems[i].MenuItems[j].MenuItems[x].Text=get_text(ds.Tables[0],"vviet='"+
										mnu.MenuItems[i].MenuItems[j].MenuItems[x].Text+"'","vviet");
									break;
								case 1:
									mnu.MenuItems[i].MenuItems[j].MenuItems[x].Text=get_text(ds.Tables[0],"vviet='"+
										mnu.MenuItems[i].MenuItems[j].MenuItems[x].Text+"'","vanh");
									break;
							}
						}
					}
				}
			}

		}
#endregion
		#region DataGrid
		private void Write_dtgrid_to_xml(DataGrid grid,string f_name)
		{
			ds.Tables.Clear();
			ds = new DataSet();
			ds.Tables.Add(Creat_table());
			DataRow r;
			GridColumnStylesCollection myColumns;   
			foreach(DataGridTableStyle myTableStyle in grid.TableStyles)
			{
				myColumns = myTableStyle.GridColumnStyles;
				foreach (DataGridColumnStyle dgCol in myColumns)
				{
					r = ds.Tables[0].NewRow();
					r["vviet"]=dgCol.HeaderText.ToString();
					r["vanh"]="";
					r["vphap"]="";
					ds.Tables[0].Rows.Add(r);
				}
				break;
			}
			ds.WriteXml(@"..\..\..\Language\"+f_name+".xml",XmlWriteMode.WriteSchema);
		}
		private void Write_dtgrid_to_xml(DataGrid grid,string f_name,DataTable dt)
		{
			ds.Tables.Clear();
			ds = new DataSet();
			ds.Tables.Add(Creat_table());
			DataRow r;
			GridColumnStylesCollection myColumns;   
			foreach(DataGridTableStyle myTableStyle in grid.TableStyles)
			{
				myColumns = myTableStyle.GridColumnStyles;
				foreach (DataGridColumnStyle dgCol in myColumns)
				{
					r = ds.Tables[0].NewRow();
					r["vviet"]=dgCol.HeaderText.Trim();
					r["vanh"]=get_text(dt,"vviet='"+dgCol.HeaderText.Trim()+"'","vanh");
					r["vphap"]=get_text(dt,"vviet='"+dgCol.HeaderText.Trim()+"'","vphap");
					ds.Tables[0].Rows.Add(r);
				}
				break;
			}
			ds.WriteXml(@"..\..\..\Language\"+f_name+".xml",XmlWriteMode.WriteSchema);
		}
		public void Read_dtgrid_to_Xml(DataGrid grid,string f_name)
		{
			DataSet dsTemp = new DataSet();
			try
			{
				dsTemp.ReadXml(@"..\..\..\Language\"+f_name+".xml");
				Write_dtgrid_to_xml(grid,f_name,dsTemp.Tables[0]);
			}
			catch
			{
				Write_dtgrid_to_xml(grid,f_name);
			}
		}
		public void Change_dtgrid_HeaderText_to_English(DataGrid grid,string f_name)
		{
			ds.ReadXml(@"..\..\..\Language\"+f_name+".xml");
			
			GridColumnStylesCollection myColumns;   
			foreach(DataGridTableStyle myTableStyle in grid.TableStyles)
			{
				myColumns = myTableStyle.GridColumnStyles;
				foreach (DataGridColumnStyle dgCol in myColumns)
				{
					dgCol.HeaderText=get_text(ds.Tables[0],"vviet='"+dgCol.HeaderText.ToString()+"'"); 				
				}
				break;
			}
			
		}
		#endregion
	}
}
