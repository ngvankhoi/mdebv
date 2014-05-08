using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Duoc
{
    public partial class frmCosottDuyet : Form
    {
        private LibDuoc.AccessData d;
        private Language lan;
        private string s_ngay;
        private decimal l_sophieu, l_iddutru, l_id;
        private int i_makho, i_userid,i_makhoa;
        private DataTable dtct;
        private string sql,s_makp,s_makho;
        private string format_soluong;
        private string user;
        public frmCosottDuyet(LibDuoc.AccessData acc, int userid,string _makho,string _makhoa)
        {
            InitializeComponent();
            d = acc;
            //format_soluong = d.format_soluong;
            user = d.user;
            i_userid = userid;
            lan = new Language();
            dtct = new DataTable("Table");
            s_makho = _makho;
            s_makp = _makhoa;
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

        private void frmCosottDuyet_Load(object sender, EventArgs e)
        {
            AddGridTableStyle();
        }

        private void butLaysolieu_Click(object sender, EventArgs e)
        {
            frmChonphieucstt f = new frmChonphieucstt(d,s_makp,s_makho);
            f.ShowInTaskbar = false;
            f.ShowDialog();
            if (f.bChon)
            {
                s_ngay = f.Ngay;
                l_iddutru = f.ID;
                l_sophieu = f.Sophieu;
                i_makho = f.IDKHO;
                i_makhoa = f.IDKHOA;
                load_grid(s_ngay, l_iddutru, l_sophieu, i_makho,i_makhoa);
            }
        }
        private void load_grid(string s_ngay, decimal l_id, decimal l_sophieu, int idkho,int idkhoa)
        {
            sql = "select b.ma,b.id as mabd1 ,trim(b.ten)||' '||b.hamluong as ten,b.hamluong,b.dang,g.ten as nhasx,f.sophieu,c.stt as sttnhom,c.ten as tennhom,d.ten as tenhang,";
            sql += "b.sltoithieu, b.tenhc,a.*,a.soluong as slduyet,e.ten as tenkho ";
            sql += " from " + user + ".d_dutrucsttct a," + user + ".d_dutrucsttll f," + user + ".d_dmbd b," + user + ".d_dmnhom c," + user + ".d_dmhang d," + user + ".d_dmkho e,"+user+".d_dmnx g ";
            sql += " where a.mabd=b.id and b.manhom=c.id and b.mahang=d.id and e.id=f.makho and b.madv=g.id and a.id=f.id and f.makho=" + idkho;
            sql += " and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
            sql += " and a.id=" + l_id + " and sophieu=" + l_sophieu;
            sql += " and a.soluong >0 ";
            sql += " and f.done =2 and makp='" + i_makhoa + "'";
            sql += " order by c.stt,b.ma";
            dtct = d.get_data(sql).Tables[0];
            dataGrid1.DataSource = dtct;
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
            DataView dv = (DataView)cm.List;
            dv.AllowNew = false;
            dv.AllowDelete = false;
        }

        private void butLuuIn_Click(object sender, EventArgs e)
        {
            Luu();
            print();
            load_grid(s_ngay, l_id, l_sophieu, i_makho, i_makhoa);
        }
        private void Luu()
        {
            if (dtct.Rows.Count > 0)
            {
                if (d.bPhieudachuyencstt(l_iddutru, l_sophieu) == 1)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Phiếu này đã được duyệt "), d.Msg + " d_duyetdutrucsttll ");
                    return;
                }
                l_id = d.getidyymmddhhmiss_stt_computer;
                if (!d.upd_duyetdutrucsttll(l_id, l_sophieu, s_ngay, i_userid))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Lưu thông tin duyệt không thành công"), d.Msg + " d_duyetdutrucsttll ");
                    return;
                }
                if (!d.upd_d_theodoiduyetdutrucstt(l_id, l_iddutru, i_makho, i_makhoa, 0))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Lưu thông tin duyệt không thành công"), d.Msg + "d_theodoiduyetdutrucstt");
                    return;
                }
                dtct.AcceptChanges();
                int stt = 1;
                foreach (DataRow row in dtct.Rows)
                {
                    d.upd_d_duyetdutrucsttct(l_id, stt++, decimal.Parse(row["mabd"].ToString()), decimal.Parse(row["slduyet"].ToString().Trim() == "" ? "0" : row["slduyet"].ToString().Trim()), decimal.Parse(row["soluong"].ToString() == "" ? "0" : row["soluong"].ToString()));
                }
                if (CHKXML.Checked) dtct.WriteXml("..//..//dataxml//d_duyetdutrucstt.xml", XmlWriteMode.WriteSchema);
            }
           
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            Luu();
        }
        private void print()
        {
            try
            {
                // lay ten bo phan
                sql = "select * from "+user+".d_nhomkhoa where makp like '%"+i_makhoa+"%'";
                string s_bophan = "",s_tenkp="",s_tenkho="";
                foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                {
                    s_bophan = r["ten"].ToString();
                    break;
                }
                sql = "select ten from " + user + ".d_duockp where id=" + i_makhoa ;
                foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                {
                    s_tenkp = r["ten"].ToString();
                    break;
                }
                sql = "select ten from " + user + ".d_dmkho where id=" + i_makho;
                foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                {
                    s_tenkho = r["ten"].ToString();
                    break;
                }
                dtct.AcceptChanges();
                frmReport f = new frmReport(d, dtct, i_userid, "d_duyetdutrucstt.rpt", s_bophan, d.TenChiNhanhHienTai, s_ngay, s_tenkp.ToUpper(), s_tenkho.ToUpper(), "", "", "", "", "");
                f.ShowDialog();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "d_duyetdutrucstt.rpt");
            }

        }
    }
}