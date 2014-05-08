using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Duoc
{
    public partial class frmDuyetdutrukho : Form
    {
        int i_id_chinhanh = 0;
        private LibDuoc.AccessData d;
        private int i_userid,i_makho;
        private string s_ngaydangnhap, sql, user, format_soluong;
        private DataTable dtct,dtphieu;
        private decimal l_id = 0,l_iddutru=0;
        private Language lan = new Language();
        public frmDuyetdutrukho(LibDuoc.AccessData acc,int userid,string ngaydangnhap,int _id_chinhanh)
        {
            InitializeComponent();
            d = acc;
            i_userid = userid;
            s_ngaydangnhap = ngaydangnhap;
            i_id_chinhanh = _id_chinhanh;
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
        private void butMoi_Click(object sender, EventArgs e)
        {
            frmDuyetdutru f = new frmDuyetdutru(d,i_userid,i_id_chinhanh);
            f.ShowInTaskbar = false;
            f.ShowDialog();
            load_phieu();
            cmbSophieu_SelectedIndexChanged(null, null);
            load_treeview();
        }

        private void frmDuyetdutrukho_Load(object sender, EventArgs e)
        {
            user = d.user;
            cmbSophieu.DisplayMember = "Phieu";
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
                sql = " select a.sophieu,a.id,to_char(a.ngay,'dd/mm/yyyy') as ngay,b.ten from " 
                    + user + ".d_dutrukholl a," + user + ".d_dmkho b " + 
                    " where a.makho=b.id and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" 
                    + ngay_dangnhap.AddDays(-i_ngaykiemke).ToString("dd/MM/yyyy") + "','dd/mm/yyyy') and to_date('" 
                    + ngay_dangnhap.AddDays(i_ngaykiemke).ToString("dd/MM/yyyy") + "','dd/mm/yyyy') and done=2";
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
            sql = "select to_char(a.ngay,'dd/mm/yyyy') as ngay, a.id,a.phieu,c.ten as tenkho,b.makho,b.id_dutru ";
            sql += " from " + user + ".d_duyetdutrukholl a," + user + ".d_theodoiduyetdutru b, " + user + ".d_dmkho c";
            sql += " where a.id=b.id and b.makho=c.id and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngaydangnhap + "'";
            dtphieu = d.get_data(sql).Tables[0];
            cmbSophieu.DataSource = dtphieu;
        }
        private void load_grid()
        {
            sql = "select b.ma,trim(b.ten)||' '||b.hamluong as ten,b.dang,";
            sql += " b.tenhc,a.* ";
            sql += " from " + user + ".d_duyetdutrukhoct a," + user + ".d_dmbd b " ;
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
                    i_makho = int.Parse(dr[0]["makho"].ToString());
                    l_iddutru = decimal.Parse(dr[0]["id_dutru"].ToString());
                }
                load_grid();
            }
            catch
            {
                l_id = 0;
                i_makho = 0;
                l_iddutru = 0;
            }
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butThuhoi_Click(object sender, EventArgs e)
        {
            if (l_id != 0 && cmbSophieu.Text !="")
            {
                if (d.get_data("select done from " + user + ".d_theodoiduyetdutru where id=" + l_id).Tables[0].Rows[0]["done"].ToString() == "2")
                {
                    MessageBox.Show("Phiếu này đã được duyệt, không thể thu hồi !", d.Msg);
                    return;
                }
                if (MessageBox.Show("Bạn muốn thu hồi phiếu " + cmbSophieu.Text + " ?", d.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (!d.huy_duyetdutrukho(l_id, l_iddutru, i_makho, decimal.Parse(cmbSophieu.Text)))
                        {
                            MessageBox.Show("Hủy duyệt không thành công !", d.Msg);
                            return;
                        }
                        load_phieu();
                        cmbSophieu_SelectedIndexChanged(null, null);
                        load_treeview();
                    }
                    catch { }
                }
            }
        }

        private void timkiem_Enter(object sender, EventArgs e)
        {
            timkiem.BackColor = Color.PaleGoldenrod;
            timkiem.Text = "";
        }

        private void timkiem_Leave(object sender, EventArgs e)
        {
            timkiem.BackColor = Color.WhiteSmoke;
            timkiem.Text = "Tìm kiếm";
        }

        private void timkiem_TextChanged(object sender, EventArgs e)
        {
            if (timkiem.Text == "Tìm kiếm") return;
            filter_phieu(timkiem.Text);
        }
        private void filter_phieu(string _sophieu)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[cmbSophieu.DataSource];
            DataView dv = (DataView)cm.List;
            if (_sophieu.Trim() == "")
            {
                dv.RowFilter = "";
            }
            else
            {
               // dv.RowFilter="phieu like '%"+ _sophieu +"%'";
            }
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "select f.sophieu,b.ma,b.id as mabd1 ,trim(b.ten)||' '||b.hamluong as ten,b.dang,c.stt as sttnhom,c.ten as tennhom,d.ten as tenhang,";
                sql += "b.sltoithieu, b.tenhc,a.*,0 as slduyet,b.vtyt,h.ten as tennuoc ";
                sql += " from " + user + ".d_dutrukhoct a," + user + ".d_dutrukholl f," + user + ".d_dmbd b," + user + ".d_dmnhom c," + 
                    user + ".d_dmhang d," + user + ".d_dmkho e, "+user+".d_dmnuoc h ";
                sql += " where a.mabd=b.id and b.manhom=c.id and b.mahang=d.id and e.id=f.makho and b.manuoc=h.id and a.id=f.id and f.makho=" + i_makho;
                sql += " and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngaydangnhap + "'";
                sql += " and a.id=" + l_iddutru + " and sophieu=" + cmbSophieu.Text;
                sql += " and a.soluong >0 ";
                sql += " and f.done =2 ";
                sql += " order by c.stt,b.ma";
                DataSet ds = d.get_data(sql);

                foreach (DataRow row in d.get_data("select * from " + user + ".d_duyetdutrukhoct where id=" + l_id).Tables[0].Rows)
                {
                    DataRow[] dr = ds.Tables[0].Select("mabd1=" + row["mabd"].ToString());
                    if (dr.Length > 0)
                    {
                        dr[0]["slduyet"] = decimal.Parse(row["soluong"].ToString());   
                    }
                }
               // ds.Tables.Add(dv.Table.Copy());
                if (chkXem.Checked) ds.WriteXml("..//..//dataxml//d_duyetdutrukho.xml", XmlWriteMode.WriteSchema);
                frmReport f = new frmReport(d, ds, i_userid, d.f_getten_chinhanh(i_id_chinhanh), "d_duyetdutrukho.rpt");
                f.ShowDialog();
            }
            catch (Exception er)
            {
                MessageBox.Show(lan.Change_language_MessageText("Lỗi :") + er.Message, "d_duyetdutrukho.rpt");
            }

        }

        private void butRefresh_Click(object sender, EventArgs e)
        {
            load_treeview();
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                TreeNode pNode = e.Node;
                string s_id = pNode.Tag.ToString();
                DateTime ngay_dangnhap = new DateTime(int.Parse(s_ngaydangnhap.Substring(6, 4)), int.Parse(s_ngaydangnhap.Substring(3, 2)), int.Parse(s_ngaydangnhap.Substring(0, 2)));
                int i_ngaykiemke = d.iNgaykiemke;
                pNode.Nodes.Clear();
                sql = " select trim(c.ten)||' '||c.hamluong as ten,b.soluong from " 
                    + user + ".d_dutrukholl a," + user + ".d_dutrukhoct b,"+user+".d_dmbd c " 
                    + " where a.id=b.id and c.id=b.mabd and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" 
                    + ngay_dangnhap.AddDays(-i_ngaykiemke).ToString("dd/MM/yyyy") + "','dd/mm/yyyy') and to_date('" 
                    + ngay_dangnhap.AddDays(i_ngaykiemke).ToString("dd/MM/yyyy") + "','dd/mm/yyyy') and done=2 and b.soluong>0 and a.id="+s_id;

                foreach (DataRow row in d.get_data(sql).Tables[0].Rows)
                {
                    pNode.Nodes.Add(row["ten"].ToString() + "(" + row["soluong"].ToString() + ")");
                }
            }
            catch { }
        }

        private void frmDuyetdutrukho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                load_treeview();
            }
        }
    }
}