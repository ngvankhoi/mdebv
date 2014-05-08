using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibDuoc;
namespace Duoc
{
    public partial class frmDuyetdutrucstt : Form
    {
        private AccessData d;
        private string user, s_ngaydangnhap, format_soluong,s_makho,s_nhomkho,s_makp,sql;
        private decimal l_id = 0,l_iddutru=0;
        private int i_userid,i_makho,i_makp;
        private DataTable dtct, dtphieu;
        public frmDuyetdutrucstt(AccessData acc,string _ngaydangnhap,string _makho,string _makp,int _userid,string _nhomkho)
        {
            InitializeComponent();
            d = acc;
            s_ngaydangnhap = _ngaydangnhap;
            s_nhomkho = _nhomkho;
            s_makho = _makho;
            s_makp = _makp;
            i_userid = _userid;
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
            TextCol1.MappingName = "ma";
            TextCol1.HeaderText = "Mã";
            TextCol1.Width = 50;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 1);
            TextCol1.MappingName = "tenhc";
            TextCol1.HeaderText = "Hoạt chất";
            TextCol1.Width = 120;
            TextCol1.NullText = string.Empty;
            TextCol1.ReadOnly = true;
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
            TextCol1.MappingName = "sldutru";
            TextCol1.HeaderText = "Dự trù ";
            TextCol1.Width = 60;
            TextCol1.NullText = "0";
            TextCol1.Format = format_soluong;
            TextCol1.ReadOnly = true;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 4);
            TextCol1.MappingName = "soluong";
            TextCol1.HeaderText = " Duyệt ";
            TextCol1.Width = 60;
            TextCol1.NullText = "0";
            TextCol1.Format = format_soluong;
            TextCol1.ReadOnly = true;
            TextCol1.Alignment = HorizontalAlignment.Right;
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
        private void frmDuyetdutrutt_Load(object sender, EventArgs e)
        {
            user = d.user;
            cmbSophieu.DisplayMember = "sophieu";
            cmbSophieu.ValueMember = "id";
            format_soluong = d.format_soluong(1);
            load_phieu();
            load_grid();
            load_treeview();
            AddGridTableStyle();
        }
        private void load_treeview()
        {
            try
            {
                treeView1.Nodes.Clear();
                DateTime ngay_dangnhap = new DateTime(int.Parse(s_ngaydangnhap.Substring(6, 4)), int.Parse(s_ngaydangnhap.Substring(3, 2)), int.Parse(s_ngaydangnhap.Substring(0, 2)));
                int i_ngaykiemke = d.iNgaykiemke;
                sql = " select a.sophieu,a.id,to_char(a.ngay,'dd/mm/yyyy') as ngay,b.ten from " + user + ".d_dutrucsttll a," + 
                    user + ".d_duockp b " + " where a.makp=b.id and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + ngay_dangnhap.AddDays(-i_ngaykiemke).ToString("dd/MM/yyyy") + "','dd/mm/yyyy') and to_date('" + ngay_dangnhap.AddDays(i_ngaykiemke).ToString("dd/MM/yyyy") + "','dd/mm/yyyy') and done=2";
                foreach (DataRow row in d.get_data(sql).Tables[0].Rows)
                {
                    TreeNode node = new TreeNode(row["ten"].ToString() + " ( " + row["ngay"].ToString() + " )");
                    node.Tag = row["id"].ToString();
                    node.Nodes.Add("");
                    treeView1.Nodes.Add(node);
                }
            }
            catch { }
        }
        private void load_phieu()
        {
            cmbSophieu.DataSource = null;
            cmbSophieu.DisplayMember = "phieu";
            cmbSophieu.ValueMember = "id";
            sql = "select to_char(a.ngay,'dd/mm/yyyy') as ngay, a.id,a.phieu,c.ten as tenkho,d.ten as tenkhoa,b.makp,b.makho,b.id_dutru ";
            sql += " from " + user + ".d_duyetdutrucsttll a," + user + ".d_theodoiduyetdutrucstt b, " + user + ".d_dmkho c,"+user+".d_duockp d";
            sql += " where a.id=b.id and b.makho=c.id and b.makp=d.id and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngaydangnhap + "'";
            dtphieu = d.get_data(sql).Tables[0];
            cmbSophieu.DataSource = dtphieu;
        }
        private void load_grid()
        {
            dataGrid1.DataSource = null;
            sql = "select b.ma,trim(b.ten)||' '||b.hamluong as ten,b.dang,";
            sql += " b.tenhc,a.* ";
            sql += " from " + user + ".d_duyetdutrucsttct a," + user + ".d_dmbd b ";
            sql += " where a.mabd=b.id ";
            sql += " and a.id=" + l_id; ;
            sql += " order by b.ma";
            dtct = d.get_data(sql).Tables[0];
            dataGrid1.DataSource = dtct;
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
            DataView dv = (DataView)cm.List;
            dv.AllowEdit = false;
            dv.AllowDelete = false;
            dv.AllowNew = false;
        }

        private void cmbSophieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                l_id = decimal.Parse(cmbSophieu.SelectedValue.ToString());
                DataRow[] dr = dtphieu.Select("id=" + l_id);
                if (dr.Length > 0)
                {
                    ngaysp.Text = dr[0]["ngay"].ToString();
                    txtTitle.Text = dr[0]["tenkho"].ToString();
                    txtKhoa.Text = dr[0]["tenkhoa"].ToString();
                    i_makho = int.Parse(dr[0]["makho"].ToString());
                    i_makp = int.Parse(dr[0]["makp"].ToString());
                    l_iddutru = decimal.Parse(dr[0]["id_dutru"].ToString());
                }
                load_grid();
            }
            catch
            {
                l_id = 0;
                i_makho = 0;
                l_iddutru = 0;
                load_grid();
            }
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butDuyet_Click(object sender, EventArgs e)
        {
            frmCosottDuyet f = new frmCosottDuyet(d, i_userid, s_makho, s_makp);
            f.ShowDialog(this);
            load_phieu();
            load_treeview();
            try
            {
                cmbSophieu.SelectedIndex = 0;
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            load_treeview();
        }

        private void butThuhoi_Click(object sender, EventArgs e)
        {
            if (l_id != 0 && cmbSophieu.Text != "")
            {
                if (MessageBox.Show("Bạn muốn thu hồi phiếu " + cmbSophieu.Text + " ?", d.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (d.get_data("select done from " + user + ".d_theodoiduyetdutrucstt where id=" + l_id).Tables[0].Rows[0]["done"].ToString() == "1")
                        {
                            MessageBox.Show("Phiếu này đã được duyệt, không thể hủy !", d.Msg);
                            return;
                        }
                        if (!d.huy_duyetdutrucstt(l_id, l_iddutru, i_makho, decimal.Parse(cmbSophieu.Text),i_makp.ToString()))
                        {
                            MessageBox.Show("Hủy duyệt không thành công !", d.Msg);
                            return;
                        }
                        load_phieu();
                        load_treeview();
                        cmbSophieu.SelectedIndex=0;
                    }
                    catch { }
                }
            }
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            if (l_id != 0 && cmbSophieu.Text.Trim() != "")
            {
                sql = "select b.ma,b.id as mabd1 ,trim(b.ten)||' '||b.hamluong as ten,b.hamluong,b.dang,g.ten as nhasx,f.sophieu,c.stt as sttnhom,c.ten as tennhom,d.ten as tenhang,";
                sql += "b.sltoithieu, b.tenhc,a.*,a.soluong as slduyet,e.ten as tenkho ";
                sql += " from " + user + ".d_dutrucsttct a," + user + ".d_dutrucsttll f," + user + ".d_dmbd b," + user + ".d_dmnhom c," + user + ".d_dmhang d," + user + ".d_dmkho e," + user + ".d_dmnx g ";
                sql += " where a.mabd=b.id and b.manhom=c.id and b.mahang=d.id and e.id=f.makho and b.madv=g.id and a.id=f.id and f.makho=" + i_makho;
                sql += " and to_char(f.ngay,'dd/mm/yyyy')='" + ngaysp.Text.Substring(0,10) + "'";
                sql += " and a.id=" + l_iddutru + " and sophieu=" + cmbSophieu.Text;
                sql += " and a.soluong >0 ";
                sql += " and f.done =1 and makp='" + i_makp + "'";
                sql += " order by c.stt,b.ma";
                DataTable tmp = d.get_data(sql).Tables[0];
                sql = "select * from " + user + ".d_nhomkhoa where makp like '%" + i_makp + "%'";
                string s_bophan = "", s_tenkp = "", s_tenkho = "";
                foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                {
                    s_bophan = r["ten"].ToString();
                    break;
                }
                sql = "select ten from " + user + ".d_duockp where id=" + i_makp;
                foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                {
                    s_tenkp = r["ten"].ToString();
                    break;
                }
                sql = "select ten from " + user + ".d_dmkho where hide=0 and id=" + i_makho;
                foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                {
                    s_tenkho = r["ten"].ToString();
                    break;
                }
                try
                {
                    frmReport f = new frmReport(d, tmp,i_userid, "d_duyetdutrucstt.rpt", s_bophan, d.TenChiNhanhHienTai, ngaysp.Text.Substring(0,10), s_tenkp.ToUpper(), s_tenkho.ToUpper(), "", "", "", "", "");
                    f.ShowDialog();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message, "d_duyetdutrucstt.rpt");
                }
            }
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //if (chkChitiet.Checked)
            {
                try
                {
                    TreeNode pNode = e.Node;
                    pNode.Nodes.Clear();
                    DateTime ngay_dangnhap = new DateTime(int.Parse(s_ngaydangnhap.Substring(6, 4)), int.Parse(s_ngaydangnhap.Substring(3, 2)), int.Parse(s_ngaydangnhap.Substring(0, 2)));
                    int i_ngaykiemke = d.iNgaykiemke;

                    string id = pNode.Tag.ToString();
                    if (id != "")
                    {
                        sql = " select trim(d.ten)||' '||d.hamluong as ten,c.soluong,a.sophieu,a.id,to_char(a.ngay,'dd/mm/yyyy') as ngay from " + user + ".d_dutrucsttll a," +
                      user + ".d_dutrucsttct c," + user + ".d_dmbd d " +
                      " where a.id=c.id and c.mabd=d.id and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') " +
                      "between to_date('" + ngay_dangnhap.AddDays(-i_ngaykiemke).ToString("dd/MM/yyyy") + "','dd/mm/yyyy') and to_date('" +
                      ngay_dangnhap.AddDays(i_ngaykiemke).ToString("dd/MM/yyyy") + "','dd/mm/yyyy') and a.done=2 and c.soluong>0 and a.id=" + id;
                        foreach (DataRow row in d.get_data(sql).Tables[0].Rows)
                        {
                            pNode.Nodes.Add(row["ten"].ToString() + "(" + (row["soluong"].ToString()) + ")");
                        }
                    }
                }
                catch { };
            }
        }

        private void frmDuyetdutrucstt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5) load_treeview();
        }
    }
}