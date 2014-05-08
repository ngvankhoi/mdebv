using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibVP;

namespace Vienphi
{
    public partial class frmEvent_new : Form
    {          
        private string user, stime, sql, fie;
        private DataSet ds1 = new DataSet();
        private DataSet ds2;
        DataColumn dc;
        private DataTable dt = new DataTable();
        private AccessData m_v;

        public frmEvent_new(LibVP.AccessData acc)
        {
            InitializeComponent();
            m_v = acc;
        }

        private void frmEvent_new_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = m_v.user; stime = "'" + m_v.f_ngay + "'";
            dt = m_v.get_data("select * from " + user + ".dmtables").Tables[0];
            computerid.DataSource = m_v.get_data("select * from " + user + ".dmcomputer order by id").Tables[0];
            computerid.DisplayMember = "COMPUTER";
            computerid.ValueMember = "ID";
            computerid.SelectedIndex = -1;

            sql = "select id,hoten from " + user + ".dlogin ";
            sql += " union all select id,hoten from " + user + ".d_dlogin ";
            sql += " union all select id,hoten from " + user + ".v_dlogin ";
            userid.DataSource = m_v.get_data(sql).Tables[0];
            userid.DisplayMember = "HOTEN";
            userid.ValueMember = "ID";
            userid.SelectedIndex = -1;

            tableid.DataSource = m_v.get_data("select id,case when diengiai is null then tables else diengiai end as tables from " + user + ".dmtables order by id").Tables[0];
            tableid.DisplayMember = "TABLES";
            tableid.ValueMember = "ID";
            tableid.SelectedIndex = -1;

            ds1.ReadXml("..\\..\\..\\xml\\event.xml");
            dataGrid1.DataSource = ds1.Tables[0];
            AddGridTableStyle();
        }
        private void load_grid()
        {
            DataSet tmp;
            sql = "select to_char(a.ngay,'dd/mm/yyyy') as ngay,b.computer as may,c.hoten as user,case when d.diengiai is null then d.tables else d.diengiai end as noidung,";
            sql += " a.ins,a.upd,a.del,a.tableid,a.computerid,a.userid ";
            sql += " from " + user + ".eve_tables a," + user + ".dmcomputer b," + user + ".dlogin c," + user + ".dmtables d ";
            sql += " where a.computerid=b.id and a.userid=c.id and a.tableid=d.id ";
            sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            if (computerid.SelectedIndex != -1) sql += " and a.computerid=" + int.Parse(computerid.SelectedValue.ToString());
            if (userid.SelectedIndex != -1) sql += " and a.userid=" + int.Parse(userid.SelectedValue.ToString());
            if (tableid.SelectedIndex != -1) sql += " and a.tableid=" + int.Parse(tableid.SelectedValue.ToString());
            sql += " union all ";
            sql += "select to_char(a.ngay,'dd/mm/yyyy') as ngay,b.computer as may,c.hoten as user,case when d.diengiai is null then d.tables else d.diengiai end as noidung,";
            sql += " a.ins,a.upd,a.del,a.tableid,a.computerid,a.userid ";
            sql += " from " + user + ".eve_tables a," + user + ".dmcomputer b," + user + ".d_dlogin c," + user + ".dmtables d ";
            sql += " where a.computerid=b.id and a.userid=c.id and a.tableid=d.id ";
            sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            if (computerid.SelectedIndex != -1) sql += " and a.computerid=" + int.Parse(computerid.SelectedValue.ToString());
            if (userid.SelectedIndex != -1) sql += " and a.userid=" + int.Parse(userid.SelectedValue.ToString());
            if (tableid.SelectedIndex != -1) sql += " and a.tableid=" + int.Parse(tableid.SelectedValue.ToString());
            sql += " union all ";
            sql += "select to_char(a.ngay,'dd/mm/yyyy') as ngay,b.computer as may,c.hoten as user,case when d.diengiai is null then d.tables else d.diengiai end as noidung,";
            sql += " a.ins,a.upd,a.del,a.tableid,a.computerid,a.userid ";
            sql += " from " + user + ".eve_tables a," + user + ".dmcomputer b," + user + ".v_dlogin c," + user + ".dmtables d ";
            sql += " where a.computerid=b.id and a.userid=c.id and a.tableid=d.id ";
            sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            if (computerid.SelectedIndex != -1) sql += " and a.computerid=" + int.Parse(computerid.SelectedValue.ToString());
            if (userid.SelectedIndex != -1) sql += " and a.userid=" + int.Parse(userid.SelectedValue.ToString());
            if (tableid.SelectedIndex != -1) sql += " and a.tableid=" + int.Parse(tableid.SelectedValue.ToString());
            tmp = m_v.get_data(sql);

            sql = "select to_char(a.ngay,'dd/mm/yyyy') as ngay,b.computer as may,c.hoten as user,case when d.diengiai is null then d.tables else d.diengiai end as noidung,";
            sql += " a.ins,a.upd,a.del,a.tableid,a.computerid,a.userid ";
            sql += " from medibvmmyy.eve_tables a," + user + ".dmcomputer b," + user + ".dlogin c," + user + ".dmtables d ";
            sql += " where a.computerid=b.id and a.userid=c.id and a.tableid=d.id ";
            sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            if (computerid.SelectedIndex != -1) sql += " and a.computerid=" + int.Parse(computerid.SelectedValue.ToString());
            if (userid.SelectedIndex != -1) sql += " and a.userid=" + int.Parse(userid.SelectedValue.ToString());
            if (tableid.SelectedIndex != -1) sql += " and a.tableid=" + int.Parse(tableid.SelectedValue.ToString());
            sql += " union all ";
            sql += "select to_char(a.ngay,'dd/mm/yyyy') as ngay,b.computer as may,c.hoten as user,case when d.diengiai is null then d.tables else d.diengiai end as noidung,";
            sql += " a.ins,a.upd,a.del,a.tableid,a.computerid,a.userid ";
            sql += " from medibvmmyy.eve_tables a," + user + ".dmcomputer b," + user + ".d_dlogin c," + user + ".dmtables d ";
            sql += " where a.computerid=b.id and a.userid=c.id and a.tableid=d.id ";
            sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            if (computerid.SelectedIndex != -1) sql += " and a.computerid=" + int.Parse(computerid.SelectedValue.ToString());
            if (userid.SelectedIndex != -1) sql += " and a.userid=" + int.Parse(userid.SelectedValue.ToString());
            if (tableid.SelectedIndex != -1) sql += " and a.tableid=" + int.Parse(tableid.SelectedValue.ToString());
            sql += " union all ";
            sql += "select to_char(a.ngay,'dd/mm/yyyy') as ngay,b.computer as may,c.hoten as user,case when d.diengiai is null then d.tables else d.diengiai end as noidung,";
            sql += " a.ins,a.upd,a.del,a.tableid,a.computerid,a.userid ";
            sql += " from medibvmmyy.eve_tables a," + user + ".dmcomputer b," + user + ".v_dlogin c," + user + ".dmtables d ";
            sql += " where a.computerid=b.id and a.userid=c.id and a.tableid=d.id ";
            sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            if (computerid.SelectedIndex != -1) sql += " and a.computerid=" + int.Parse(computerid.SelectedValue.ToString());
            if (userid.SelectedIndex != -1) sql += " and a.userid=" + int.Parse(userid.SelectedValue.ToString());
            if (tableid.SelectedIndex != -1) sql += " and a.tableid=" + int.Parse(tableid.SelectedValue.ToString());
            tmp = m_v.merge(tmp, m_v.get_data_mmyy(sql, tu.Text, den.Text, true));
            ds1.Clear();
            ds1.Merge(tmp.Tables[0].Select("true", "ngay"));
            dataGrid1.DataSource = ds1.Tables[0];
        }

        private void AddGridTableStyle()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = ds1.Tables[0].TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.ReadOnly = false;
            ts.RowHeaderWidth = 10;

            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ngay";
            TextCol.HeaderText = "Ngày";
            TextCol.Width = 70;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "may";
            TextCol.HeaderText = "Tên máy";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "user";
            TextCol.HeaderText = "Người dùng";
            TextCol.Width = 200;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "noidung";
            TextCol.HeaderText = "Nội dung";
            TextCol.Width = 220;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ins";
            TextCol.HeaderText = "Thêm";
            TextCol.Width = 50;
            TextCol.Format = "### ### ##0";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "upd";
            TextCol.HeaderText = "Thay đổi";
            TextCol.Width = 50;
            TextCol.Format = "### ### ##0";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "del";
            TextCol.HeaderText = "Hủy";
            TextCol.Width = 50;
            TextCol.Format = "### ### ##0";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tableid";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "computerid";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "userid";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
        }

        private void AddGridTableStyle1()
        {
            dataGrid2.TableStyles.Clear();
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = ds2.Tables[0].TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.ReadOnly = false;
            ts.RowHeaderWidth = 10;

            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ngayevent";
            TextCol.HeaderText = "Ngày";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "command";
            TextCol.HeaderText = "Thao tác";
            TextCol.Width = 60;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            if (fie == "")
            {
                TextCol = new DataGridTextBoxColumn();
                TextCol.MappingName = "noidung";
                TextCol.HeaderText = "Nội dung";
                TextCol.Width = 582;
                ts.GridColumnStyles.Add(TextCol);
                dataGrid2.TableStyles.Add(ts);
            }
            else
            {
                string ten = "";
                for (int i = 3; i < ds2.Tables[0].Columns.Count; i++)
                {
                    ten = ds2.Tables[0].Columns[i].ColumnName;
                    TextCol = new DataGridTextBoxColumn();
                    TextCol.MappingName = ten;
                    TextCol.HeaderText = ten;
                    TextCol.Width = (ten.IndexOf("chandoan") != -1) ? 200 : 80;
                    ts.GridColumnStyles.Add(TextCol);
                    dataGrid2.TableStyles.Add(ts);
                }
            }
        }

        private void butxem_Click(object sender, EventArgs e)
        {
            load_grid();
        }
        private void ref_text()
        {
            
            string ngay = tu.Text;
            int itable = 0, icomputer = 0, iuser = 0;
            try
            {
                int i = dataGrid1.CurrentCell.RowNumber;
                ngay = dataGrid1[i, 0].ToString();
                itable = int.Parse(dataGrid1[i, 7].ToString());
                icomputer = int.Parse(dataGrid1[i, 8].ToString());
                iuser = int.Parse(dataGrid1[i, 9].ToString());
            }
            catch { }
            load_data(ngay, itable, icomputer, iuser);
        }

        private void load_data(string ngay, int itable, int icomputer, int iuser)
        {
            try
            {
                DataSet tmp;
                int i = dataGrid1.CurrentCell.RowNumber;
                sql = "select to_char(ngay,'yymmddhh24mi') as yymmdd,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngayevent,case when command='upd' then 'Thay đổi' else 'Hủy' end as command,noidung ";
                sql += " from " + user + ".eve_upd_del where to_char(ngay,'dd/mm/yyyy')='" + ngay + "' and tableid=" + itable + " and computerid=" + icomputer + " and userid=" + iuser;
                tmp = m_v.get_data(sql);
                sql = "select to_char(ngay,'yymmddhh24mi') as yymmdd,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngayevent,case when command='upd' then 'Thay đổi' else 'Hủy' end as command,noidung ";
                sql += " from medibvmmyy.eve_upd_del where to_char(ngay,'dd/mm/yyyy')='" + ngay + "' and tableid=" + itable + " and computerid=" + icomputer + " and userid=" + iuser;
                tmp = m_v.merge(tmp, m_v.get_data_mmyy(sql, tu.Text, den.Text, true));
                ds2 = new DataSet();
                ds2.ReadXml("..\\..\\..\\xml\\event_upd_del.xml");
                DataRow r1 = m_v.getrowbyid(dt, "id=" + itable);
                if (r1 != null) fie = r1["fields"].ToString().Trim();
                else fie = "";
                if (fie != "")
                {
                    ds2.Tables[0].Columns.Remove("noidung");
                    int j = 0, len = fie.Length, k = 0;
                    string s = "", s1 = "";
                    while (j < len)
                    {
                        if (fie.Substring(j, 1) == "^")
                        {
                            dc = new DataColumn();
                            dc.ColumnName = s;
                            dc.DataType = Type.GetType("System.String");
                            ds2.Tables[0].Columns.Add(dc);
                            s = "";
                        }
                        else s += fie.Substring(j, 1);
                        j++;
                    }
                    if (s != "")
                    {
                        dc = new DataColumn();
                        dc.ColumnName = s;
                        dc.DataType = Type.GetType("System.String");
                        ds2.Tables[0].Columns.Add(dc);
                    }
                    foreach (DataRow r in tmp.Tables[0].Rows)
                    {
                        r1 = ds2.Tables[0].NewRow();
                        r1["ngayevent"] = r["ngayevent"].ToString();
                        r1["command"] = r["command"].ToString();
                        k = 3; j = 0; s = ""; s1 = r["noidung"].ToString().Trim(); len = s1.Length;
                        while (j < len)
                        {
                            if (s1.Substring(j, 1) == "^")
                            {
                                r1[k] = s;
                                k++; s = "";
                            }
                            else s += s1.Substring(j, 1);
                            j++;
                        }
                        if (s != "") r1[k] = s;
                        ds2.Tables[0].Rows.Add(r1);
                    }
                }
                else ds2.Merge(tmp.Tables[0].Select("true", "command,yymmdd"));
                
                dataGrid2.CaptionText = ngay + "; " + dataGrid1[i, 1].ToString().Trim() + "; " + dataGrid1[i, 2].ToString().Trim() + "; " + dataGrid1[i, 3].ToString().Trim();
                dataGrid2.DataSource = ds2.Tables[0];
                AddGridTableStyle1();

            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #region SỰ KIỆN
        private void tu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void den_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void computerid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void userid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void tableid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }
        #endregion

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            ref_text();
        }

        private void butketthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}