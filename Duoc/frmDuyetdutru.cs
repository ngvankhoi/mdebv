using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Duoc
{
    public partial class frmDuyetdutru : Form
    {
        int i_id_chinhanh = 0;
        private LibDuoc.AccessData d;
        private Language lan;
        private string s_ngay;
        private decimal l_sophieu, l_iddutru, l_id;
        private int i_makho, i_userid;
        private DataTable dtct;
        private string sql;
        private string format_soluong;
        private string user;
        public frmDuyetdutru(LibDuoc.AccessData acc, int userid, int _id_chinhanh)
        {
            InitializeComponent();
            d = acc;
            //format_soluong = d.format_soluong;
            user = d.user;
            i_userid = userid;
            i_id_chinhanh = _id_chinhanh;
            lan = new Language();
            dtct = new DataTable("Table");
        }
        private void AddGridTableStyle()
        {
            DataGridColoredTextBoxColumn TextCol1;
            delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.RowHeaderWidth = 10;
            ts.MappingName = dtct.TableName;

            TextCol1 = new DataGridColoredTextBoxColumn(de, 0);
            TextCol1.MappingName = "tenhc";
            TextCol1.HeaderText = "Hoạt chất";
            TextCol1.Width = 120;
            TextCol1.NullText = string.Empty;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 1);
            TextCol1.MappingName = "mabd";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 2);
            TextCol1.MappingName = "ten";
            TextCol1.HeaderText = "Tên thuốc - hàm lượng";
            TextCol1.Width = 200;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 3);
            TextCol1.MappingName = "dang";
            TextCol1.HeaderText = "ĐVT";
            TextCol1.Width = 40;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 4);
            TextCol1.MappingName = "soluong";
            TextCol1.HeaderText = "Dự trù ";
            TextCol1.Width = 60;
            TextCol1.NullText = "0";
            TextCol1.Format = format_soluong;
            TextCol1.ReadOnly = true;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 5);
            TextCol1.MappingName = "slduyet";
            TextCol1.HeaderText = "Duyệt";
            TextCol1.Width = 60;
            TextCol1.NullText = "0";
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 6);
            TextCol1.MappingName = "id";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);
        }
        #region delegate
        public delegate Color delegateGetColorRowCol(int row, int col);
        public class DataGridColoredTextBoxColumn : DataGridTextBoxColumn
        {
            private delegateGetColorRowCol _getColorRowCol;
            private int _column;
            public DataGridColoredTextBoxColumn(delegateGetColorRowCol getcolorRowCol, int column)
            {
                _getColorRowCol = getcolorRowCol;
                _column = column;
            }
            protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
            {
                try
                {
                    foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
                    //backBrush = new SolidBrush(Color.GhostWhite);
                }

                catch { }
                finally
                {
                    base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
                }
            }
        }
        public Color MyGetColorRowCol(int row, int col)
        {
            //if (dataGrid1[row, 12].ToString().Trim() != "") return Color.Red;
            return Color.Black;
        }
        #endregion
        private void butLaysolieu_Click(object sender, EventArgs e)
        {
            frmChonthongso f = new frmChonthongso(d);
            f.ShowInTaskbar = false;
            f.ShowDialog();
            if (f.bChon)
            {
                s_ngay = f.Ngay;
                l_iddutru = f.ID;
                l_sophieu = f.Sophieu;
                i_makho = f.IDKHO;
                load_grid(s_ngay, l_iddutru, l_sophieu, i_makho);
            }
        }

        private void load_grid(string s_ngay, decimal l_id, decimal l_sophieu, int idkho)
        {
            sql = "select f.sophieu,b.ma,b.id as mabd1 ,trim(b.ten)||' '||b.hamluong as ten,b.dang,c.stt as sttnhom,c.ten as tennhom,d.ten as tenhang,";
            sql += "b.sltoithieu, b.tenhc,a.*,a.soluong as slduyet,b.vtyt,g.ten as tennuoc,e.ten as tenkho,to_char(f.ngay,'dd/mm/yyyy') as ngaydutru ";
            sql += " from " + user + ".d_dutrukhoct a," + user + ".d_dutrukholl f," + user + ".d_dmbd b," + user + ".d_dmnhom c," + user + ".d_dmhang d," +
                user + ".d_dmkho e, ";
            sql += user + ".d_dmnuoc g ";
            sql += " where a.mabd=b.id and b.manhom=c.id and b.mahang=d.id and e.id=f.makho and a.id=f.id and b.manuoc=g.id and f.makho=" + idkho;
            sql += " and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
            sql += " and a.id=" + l_id + " and sophieu=" + l_sophieu;
            sql += " and a.soluong >0 ";
            sql += " and f.done =1 ";
            sql += " order by c.stt,b.ma";
            dtct = d.get_data(sql).Tables[0];
            dataGrid1.DataSource = dtct;
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
            DataView dv = (DataView)cm.List;
            dv.AllowNew = false;
            dv.AllowDelete = false;
        }

        private void frmDuyetdutru_Load(object sender, EventArgs e)
        {
            AddGridTableStyle();
        }

        private void butLuuIn_Click(object sender, EventArgs e)
        {
            Luu();
            print();
            load_grid(s_ngay, l_iddutru, l_sophieu, i_makho);
        }

        private void print()
        {
            try
            {
                dtct.AcceptChanges();
                frmReport f = new frmReport(d, dtct, i_userid , d.f_getten_chinhanh(i_id_chinhanh), "d_duyetdutrukho.rpt");
                f.ShowDialog();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "d_duyetdutrukho.rpt");
            }

        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            Luu();
            load_grid(s_ngay, l_iddutru, l_sophieu, i_makho);
        }
        private void Luu()
        {
            if (dtct.Rows.Count > 0)
            {
                if (d.bPhieudachuyen(l_iddutru, l_sophieu) == 2)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Phiếu này đã được duyệt "), d.Msg);
                    return;
                }
                l_id = d.getidyymmddhhmiss_stt_computer;
                if (!d.upd_duyetdutrukholl(l_id, l_sophieu, s_ngay, i_userid))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Lưu thông tin duyệt không thành công"), d.Msg);
                    return;
                }
                if (!d.upd_d_theodoiduyetdutru_cn(l_id, l_iddutru, i_makho, d.i_Chinhanh_hientai, 0))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Lưu thông tin duyệt không thành công"), d.Msg);
                    return;
                }
                dtct.AcceptChanges();
                int stt = 1;
                foreach (DataRow row in dtct.Rows)
                {
                    d.upd_d_duyetdutrukhoct(l_id, stt++, decimal.Parse(row["mabd"].ToString()), decimal.Parse(row["slduyet"].ToString().Trim() == "" ? "0" : row["slduyet"].ToString().Trim()), decimal.Parse(row["soluong"].ToString() == "" ? "0" : row["soluong"].ToString()));
                }
                if (CHKXML.Checked) dtct.WriteXml("..//..//dataxml//d_duyetdutrukho1.xml", XmlWriteMode.WriteSchema);
            }
        }
    }
}