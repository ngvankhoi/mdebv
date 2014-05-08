using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Medisoft
{
    public partial class frmOutput : Form
    {
        private LibMedi.AccessData m;
        private string user="medibv";
        private DataTable dt= new DataTable();
        private DataTable dt1 = new DataTable();
        private DataTable dt2 = new DataTable();
        private string s_ngay = DateTime.Now.ToString("dd/MM/yyyy");
        public frmOutput(LibMedi.AccessData acc, string _ngay)
        {
            InitializeComponent();
            s_ngay = _ngay;
            m = acc;
        }
        private void AddGridTableStyle()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dt1.TableName;
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
            TextCol.MappingName = "tenkp";
            TextCol.HeaderText = "Phòng khám";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tongso";
            TextCol.HeaderText = "Tổng số";
            TextCol.Width = 90;
            TextCol.Format = "# ### ###";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "chua";
            TextCol.HeaderText = "Chưa khám";
            TextCol.Width = 90;
            TextCol.Format = "# ### ###";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            //TextCol = new DataGridTextBoxColumn();
            //TextCol.MappingName = "dichvu";
            //TextCol.HeaderText = "Đi làm dịch vụ";
            //TextCol.Width = 90;
            //TextCol.Format = "# ### ###";
            //TextCol.Alignment = HorizontalAlignment.Right;
            //ts.GridColumnStyles.Add(TextCol);
            //dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "xong";
            TextCol.HeaderText = "Đã khám";
            TextCol.Width = 90;
            TextCol.Format = "# ### ###";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
        }
        private void AddGridTableStyle1()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dt2.TableName;
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
            TextCol.MappingName = "tenkp";
            TextCol.HeaderText = "Phòng khám";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tongso";
            TextCol.HeaderText = "Tổng số";
            TextCol.Width = 90;
            TextCol.Format = "# ### ###";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "chua";
            TextCol.HeaderText = "Chưa khám";
            TextCol.Width =90;
            TextCol.Format = "# ### ###";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            //TextCol = new DataGridTextBoxColumn();
            //TextCol.MappingName = "dichvu";
            //TextCol.HeaderText = "Đi làm dịch vụ";
            //TextCol.Width = 90;
            //TextCol.Format = "# ### ###";
            //TextCol.Alignment = HorizontalAlignment.Right;
            //ts.GridColumnStyles.Add(TextCol);
            //dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "xong";
            TextCol.HeaderText = "Đã khám";
            TextCol.Width = 90;
            TextCol.Format = "# ### ###";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);
        }
        private void load_grid()
        {
            string mmyy = m.mmyy(s_ngay);
            string sql = "";
            dataGrid1.DataSource = null;
            dataGrid2.DataSource = null;
            if (m.bMmyy(mmyy))
            {
                string xxx = user + mmyy;
                sql = "select b.tenkp,sum(1) as tongso,sum(case when a.done is null then 1 else 0 end) as chua,";
                sql += "sum(case when a.done='?' then 1 else 0 end) as dichvu,sum(case when a.done is not null then 1 else 0 end) as xong ";
                sql += " from " + xxx + ".tiepdon a," + user + ".btdkp_bv b where a.makp=b.makp and a.noitiepdon in (0,1,5) and b.loai=1";
                sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                //if (makp.SelectedIndex != -1) sql += " and a.makp='" + makp.SelectedValue.ToString() + "'";
                //if (madoituong.SelectedIndex != -1) sql += " and a.madoituong=" + int.Parse(madoituong.SelectedValue.ToString());
                sql += " group by b.tenkp order by b.tenkp";
                dt = m.get_data(sql).Tables[0];
                dt1 = dt.Clone();
                dt2 = dt.Clone();
                int i_countrow=dt.Rows.Count;
                DataRow row;
                for (int i = 0; i < i_countrow; i++)
                {
                    if (i <= (i_countrow / 2))
                    {
                        row = dt1.NewRow();
                        row["tenkp"] = dt.Rows[i]["tenkp"].ToString();
                        row["tongso"] = int.Parse(dt.Rows[i]["tongso"].ToString());
                        row["chua"] = int.Parse(dt.Rows[i]["chua"].ToString());
                        row["xong"] = int.Parse(dt.Rows[i]["xong"].ToString());
                        dt1.Rows.Add(row);
                    }
                    else
                    {
                        row = dt2.NewRow();
                        row["tenkp"] = dt.Rows[i]["tenkp"].ToString();
                        row["tongso"] = int.Parse(dt.Rows[i]["tongso"].ToString());
                        row["chua"] = int.Parse(dt.Rows[i]["chua"].ToString());
                        row["xong"] = int.Parse(dt.Rows[i]["xong"].ToString());
                        dt2.Rows.Add(row);
                    }
                }
                dataGrid1.DataSource = dt1;
                dataGrid2.DataSource = dt2;
            }
        }

        private void frmOutput_Load(object sender, EventArgs e)
        {
            try
            {
                this.Location = new Point(int.Parse(m.Thongso("x_lcd")), int.Parse(m.Thongso("y_lcd")));
                this.Width = int.Parse(m.Thongso("r_lcd"));
                this.Height= int.Parse(m.Thongso("c_lcd"));
                timer1.Interval = int.Parse(m.Thongso("t_lcd")) * 60000;
                timer1.Start();
            }
            catch
            {
                timer1.Interval = 60000;
                timer1.Start();
            }
            load_grid();
            AddGridTableStyle();
            AddGridTableStyle1();
            
        }

        private void frmOutput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.O && e.Control && e.Alt) 
            {
                frmCauhinhOutput f = new frmCauhinhOutput(m);
                f.ShowDialog(this);
                if (f.bOK)
                {
                    this.Location= new Point(f.X, f.Y);
                    this.Width = f.R;
                    this.Height = f.H;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            load_grid();
        }
    }
}