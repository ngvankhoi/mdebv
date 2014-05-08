using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibMedi;

namespace Medisoft
{
    public partial class frmPhieuksk : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private AccessData m;
        private decimal l_doan,l_id=0;
        private int i_loai = 0,i_userid;
        private bool bMabn_ct;
        private decimal stt = 0;
        private string sql, user, mmyy,xxx,ngay,ma,nam,s_mann="",s_madantoc="",s_matt="",vd_namsinh="",s_doan;
        private DataTable dtbs = new DataTable();
        private DataTable dtlist = new DataTable();
        private DataSet dsll = new DataSet();
        private DataSet ds = new DataSet();
        private DataTable dtmuc = new DataTable();
        private DataTable dtmucct = new DataTable();
        private DataTable dtdv = new DataTable();
        public frmPhieuksk(AccessData acc,decimal _iddoan,string _mmyy,int _loai,string _ngay,int userid,string _doan)
        {
            InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; l_doan = _iddoan; mmyy = _mmyy; i_loai = _loai; ngay = _ngay; i_userid = userid; s_doan = _doan;
        }

        private void frmPhieuksk_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = m.user; xxx = user + mmyy; bMabn_ct = m.bMabn_ct_rieng;
            if (!bMabn_ct)
            {
                s_mann = m.vodanh_nghenghiep; s_madantoc = m.vodanh_dantoc; s_matt = m.vodanh_tinh;
                int ns = DateTime.Now.Year - m.vodanh_tuoi;
                vd_namsinh = ns.ToString().PadLeft(4, '0');
            }
            dtmuc = m.get_data("select * from " + user + ".ct_muc where iddoan=" + l_doan + " order by stt").Tables[0];
            dtmucct = m.get_data("select b.*,c.ten from " + user + ".ct_muc a," + user + ".ct_mucct b,"+user+".ct_giavp c where a.id=b.id and b.mavp=c.id and a.iddoan=" + l_doan + " order by stt").Tables[0];
            sql = "select * from " + user + ".ct_donvi where iddoan=" + l_doan + " order by stt";
            dtdv = m.get_data(sql).Tables[0];
            donvi.DisplayMember = "TEN";
            donvi.ValueMember = "ID";
            donvi.DataSource = dtdv;

            loai.DataSource = m.get_data("select * from " + user + ".ct_loai order by id").Tables[0];
            loai.DisplayMember = "ten";
            loai.ValueMember = "id";

            dtbs = m.get_data("select * from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
            listBS.DisplayMember = "MA";
            listBS.ValueMember = "HOTEN";
            listBS.DataSource = dtbs;

            listMabn.DisplayMember = "MABN";
            listMabn.ValueMember = "HOTEN";

            list.DisplayMember = "HOTEN";
            list.ValueMember = "MABN";
            list.ColumnWidths[0] = 55;
            list.ColumnWidths[1] = list.Width - 55;
            load_list();

            load_grid();
            AddGridTableStyle();
        }

        private void load_list()
        {
            list.DataSource = null;
            dsll.Clear();
            if (donvi.SelectedIndex != -1)
            {
                ma = dtdv.Rows[donvi.SelectedIndex]["ma"].ToString();
                sql = "select mabn,hoten,namsinh,phai,stt,hotenkdau,done from " + xxx + ".ct_btdbn where iddonvi=" + decimal.Parse(donvi.SelectedValue.ToString()) + " order by stt";
                dtlist = m.get_data(sql).Tables[0];
                list.DataSource = dtlist;
                listMabn.DataSource = m.get_data(sql).Tables[0];
                sql = "select * from " + xxx + ".ct_ketqua where iddonvi=" + decimal.Parse(donvi.SelectedValue.ToString());
                //sql += " and to_char(ngay,'dd/mm/yyyy')='" + ngay + "'";
                sql += " order by mabn";
                dsll = m.get_data(sql);
                if (list.Items.Count > 0)
                {
                    mabn.Text = list.SelectedValue.ToString();
                    mabn_Validated(null, null);
                }
                int i1 = dtlist.Select("done=1").Length, i2 = dtlist.Rows.Count - i1;
                lbl1.Text = "Chưa thực hiện : " + i2.ToString().Trim();
                lbl2.Text = "Đã thực hiện : " + i1.ToString().Trim();
            }
        }

        private void mabn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void mabs_Validated(object sender, EventArgs e)
        {
            if (mabs.Text != "")
            {
                DataRow r = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                if (r != null) tenbs.Text = r["hoten"].ToString();
                else tenbs.Text = "";
            }
        }

        private void tenbs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listBS.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listBS.Visible) listBS.Focus();
                else SendKeys.Send("{Tab}");
            }		
        }

        private void tenbs_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == tenbs)
            {
                Filt_tenbs(tenbs.Text);
                listBS.BrowseToICD10(tenbs, mabs, loai, mabs.Location.X, mabs.Location.Y + mabs.Height, mabs.Width + tenbs.Width + 2, mabs.Height);
            }		
        }

        private void Filt_tenbs(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listBS.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "hoten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void donvi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == donvi) load_list();
        }

        private void ena_object(bool ena)
        {
            donvi.Enabled = !ena;
            if (!chkThem.Checked) mabn.Enabled = ena;
            hoten.Enabled = ena;
            //if (chkThem.Checked)
            //{
                namsinh.Enabled = ena;
                phai.Enabled = ena;
            //}
                butPs.Enabled = ena;
                chkThem.Enabled = !ena;
            butThem.Enabled = ena;
            butEdit.Enabled = ena;
            butXoa.Enabled = ena;
            mabs.Enabled = ena;
            tenbs.Enabled = ena;
            loai.Enabled = ena;
            ketluan.Enabled = ena;
            butMoi.Enabled = !ena;
            butSua.Enabled = !ena;
            butLuu.Enabled = ena;
            butBoqua.Enabled = ena;
            butHuy.Enabled = !ena;
            butIn.Enabled = !ena;
            butKetthuc.Enabled = !ena;
            if (!ena && !list.Enabled) list.Enabled = true;
        }

        private void emp_text()
        {
            mabn.Text = ""; hoten.Text = ""; namsinh.Text = ""; phai.SelectedIndex = -1;
            mabs.Text = ""; tenbs.Text = ""; loai.SelectedIndex = -1; ketluan.Text = "";
            ds.Clear(); l_id = 0;
        }

        private void mabn_Validated(object sender, EventArgs e)
        {
            if (mabn.Text != "")
            {
                DataRow r = m.getrowbyid(dtlist, "mabn='" + mabn.Text + "'");
                if (r != null)
                {
                    stt = decimal.Parse(r["stt"].ToString());
                    hoten.Text = r["hoten"].ToString();
                    namsinh.Text = r["namsinh"].ToString();
                    phai.SelectedIndex = int.Parse(r["phai"].ToString());
                }
                r = m.getrowbyid(dsll.Tables[0], "mabn='" + mabn.Text + "'");
                l_id = (r != null) ? decimal.Parse(r["id"].ToString()) : 0;
                if (l_id != 0)
                {
                    mabs.Text = r["mabs"].ToString();
                    DataRow r1 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                    if (r1 != null) tenbs.Text = r1["hoten"].ToString();
                    else tenbs.Text = "";
                    if (r["loai"].ToString() != "0") loai.SelectedValue = r["loai"].ToString();
                    else loai.SelectedIndex = -1;
                    ketluan.Text = r["ketluan"].ToString();
                }
                else
                {
                    mabs.Text = ""; tenbs.Text = ""; loai.SelectedIndex = -1; ketluan.Text = "";
                }                
                if (butLuu.Enabled && l_id==0) updrec();
                else load_grid();
            }
        }

        private void Filt_hoten(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listMabn.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "hoten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void hoten_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == hoten && !chkThem.Checked)
            {
                Filt_hoten(hoten.Text);
                listMabn.OtherList(hoten, mabn, namsinh, mabn.Location.X, mabn.Location.Y + mabn.Height, mabn.Width + hoten.Width +label3.Width + 2, mabn.Height);
            }		
        }

        private void hoten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listMabn.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listMabn.Visible) listMabn.Focus();
                else SendKeys.Send("{Tab}");
            }		
        }

        private void butMoi_Click(object sender, EventArgs e)
        {
            ena_object(true);
            emp_text();
            if (list.Items.Count > 0 && !chkThem.Checked)
            {
                mabn.Text = list.SelectedValue.ToString();
                mabn_Validated(sender, e);
            }
            if (chkThem.Checked) hoten.Focus();
            else mabn.Focus();
        }

        private void butSua_Click(object sender, EventArgs e)
        {
            if (l_id == 0) return;
            ena_object(true);
            list.Enabled = false;
        }

        private bool kiemtra()
        {
            if (donvi.SelectedIndex == -1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn đơn vị !"), LibMedi.AccessData.Msg);
                donvi.Focus();
                return false;
            }
            if (mabn.Text == "" && !chkThem.Checked)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn mã số !"), LibMedi.AccessData.Msg);
                mabn.Focus();
                return false;
            }
            if (hoten.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn họ tên !"), LibMedi.AccessData.Msg);
                hoten.Focus();
                return false;
            }
            if (loai.SelectedIndex == -1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn phân loại !"), LibMedi.AccessData.Msg);
                loai.Focus();
                return false;
            }
            return true;
        }
        private void butLuu_Click(object sender, EventArgs e)
        {
            if (!kiemtra()) return;
            ds.AcceptChanges();
            if (chkThem.Checked && l_id==0)
            {
                stt = 1;
                if (dtlist.Rows.Count > 0) stt = decimal.Parse(dtlist.Rows[dtlist.Rows.Count - 1]["stt"].ToString())+1;
                if (bMabn_ct) mabn.Text = ma + m.get_ma_btdbn(mmyy,decimal.Parse(donvi.SelectedValue.ToString()));
                else mabn.Text = mmyy.Substring(2, 2) + m.get_mabn(int.Parse(mmyy.Substring(2, 2)), 1, 1, true).ToString().PadLeft(6, '0');
                m.upd_ct_btdbn(mmyy,decimal.Parse(donvi.SelectedValue.ToString()),stt, mabn.Text, hoten.Text, namsinh.Text, phai.SelectedIndex, i_userid);
                if (!bMabn_ct)
                {
                    nam = m.get_mabn_nam(mabn.Text);
                    if (nam.IndexOf(mmyy + "+") == -1) nam = nam + mmyy + "+";
                    m.upd_btdbn(mabn.Text, hoten.Text, "", (namsinh.Text == "") ? vd_namsinh : namsinh.Text, (phai.SelectedIndex==-1)?0:phai.SelectedIndex, s_mann, s_madantoc, "", "", "", s_matt, s_matt + "00", s_matt + "0000", i_userid, nam);
                }
            }
            if (!chkThem.Checked) m.upd_ct_btdbn(mmyy, decimal.Parse(donvi.SelectedValue.ToString()), stt, mabn.Text, hoten.Text, namsinh.Text, phai.SelectedIndex, i_userid);
            if (l_id != 0) m.execute_data("delete from " + xxx + ".ct_chitiet where id=" + l_id);
            else l_id=m.get_id_ct_ketqua;
            m.upd_ct_ketqua(mmyy, l_id, decimal.Parse(donvi.SelectedValue.ToString()), mabn.Text, ngay, mabs.Text, int.Parse(loai.SelectedValue.ToString()), ketluan.Text, i_userid);            
            foreach (DataRow r in ds.Tables[0].Rows)
                m.upd_ct_chitiet(mmyy, l_id, int.Parse(r["stt"].ToString()), decimal.Parse(r["mavp"].ToString()), r["ten"].ToString(), decimal.Parse(r["dongia"].ToString()), int.Parse(r["ngoaihd"].ToString()), r["lamthem"].ToString(), r["ketqua"].ToString(), r["ghichu"].ToString());
            upd_btdbn(stt);
            upd_ketqua();
            ena_object(false);
        }

        private void upd_btdbn(decimal stt)
        {
            DataRow r1 = m.getrowbyid(dtlist, "mabn='" + mabn.Text + "'");
            if (r1 == null)
            {
                DataRow r = dtlist.NewRow();
                r["mabn"] = mabn.Text;
                r["hoten"] = hoten.Text;
                r["phai"] = phai.SelectedIndex;
                r["namsinh"] = namsinh.Text;
                r["stt"] = stt;
                r["hotenkdau"] = m.Hoten_khongdau(hoten.Text);
                r["done"] = 1;
                dtlist.Rows.Add(r);
            }
            else
            {
                DataRow[] dr = dtlist.Select("mabn='" + mabn.Text + "'");
                if (dr.Length > 0)
                {
                    dr[0]["hoten"] = hoten.Text;
                    dr[0]["phai"] = phai.SelectedIndex;
                    dr[0]["namsinh"] = namsinh.Text;
                    dr[0]["stt"] = stt;
                    dr[0]["hotenkdau"] = m.Hoten_khongdau(hoten.Text);
                    dr[0]["done"] = 1;
                }
            }
        }
        private void upd_ketqua()
        {
            DataRow r = m.getrowbyid(dsll.Tables[0], "id=" + l_id);
            if (r == null)
            {
                DataRow r1 = dsll.Tables[0].NewRow();
                r1["id"] = l_id;
                r1["iddonvi"] = decimal.Parse(donvi.SelectedValue.ToString());
                r1["mabn"] = mabn.Text;
                r1["mabs"] = mabs.Text;
                r1["loai"] = int.Parse(loai.SelectedValue.ToString());
                r1["ketluan"] = ketluan.Text;
                dsll.Tables[0].Rows.Add(r1);
            }
            else
            {
                DataRow[] dr = dsll.Tables[0].Select("id=" + l_id);
                if (dr.Length > 0)
                {
                    dr[0]["iddonvi"] = decimal.Parse(donvi.SelectedValue.ToString());
                    dr[0]["mabn"] = mabn.Text;
                    dr[0]["mabs"] = mabs.Text;
                    dr[0]["loai"] = int.Parse(loai.SelectedValue.ToString());
                    dr[0]["ketluan"] = ketluan.Text;
                }
            }
            if (!chkThem.Checked)
            {
                r = m.getrowbyid(dtlist, "mabn='" + mabn.Text + "'");
                if (r != null) r["done"] = 1;
            }
            m.execute_data("update " + xxx + ".ct_btdbn set done=1 where mabn='" + mabn.Text + "'");
            int i1 = dtlist.Select("done=1").Length, i2 = dtlist.Rows.Count - i1;
            lbl1.Text = "Chưa thực hiện : " + i2.ToString().Trim();
            lbl2.Text = "Đã thực hiện : " + i1.ToString().Trim();
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            ena_object(false);
            load_grid();
            list.Focus();
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            m.close();this.Close();
        }

        private void tim_Enter(object sender, EventArgs e)
        {
            tim.Text = "";
        }

        private void tim_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == tim) Filt_mabn(tim.Text);
        }

        private void Filt_mabn(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[list.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "hoten like '%" + ten.Trim() + "%' or mabn like '%"+ten.Trim()+"%'";
                if (list.Items.Count > 0)
                {
                    mabn.Text = list.SelectedValue.ToString();
                    mabn_Validated(null, null);
                }
                else ds.Clear();
            }
            catch {}
        }

        private void list_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) load_mabn();
        }

        private void list_DoubleClick(object sender, EventArgs e)
        {
            load_mabn();
        }

        private void load_mabn()
        {
            if (list.Items.Count > 0)
            {
                mabn.Text = list.SelectedValue.ToString();
                mabn_Validated(null, null);
            }
        }

        private void load_grid()
        {
            sql = "select * from " + xxx + ".ct_chitiet where id=" + l_id + " order by stt";
            ds = m.get_data(sql);
            dataGrid1.DataSource = ds.Tables[0];
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource, dataGrid1.DataMember];
            DataView dv = (DataView)cm.List;
            dv.AllowNew = false;
        }

        private void AddGridTableStyle()
        {
            DataGridColoredTextBoxColumn TextCol;
            delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = ds.Tables[0].TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.ReadOnly = false;
            ts.RowHeaderWidth = 5;

            TextCol = new DataGridColoredTextBoxColumn(de, 0);
            TextCol.MappingName = "stt";
            TextCol.HeaderText = "Stt";
            TextCol.Width = 20;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 1);
            TextCol.MappingName = "ten";
            TextCol.HeaderText = "Nội dung";
            TextCol.Width = 140;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 2);
            TextCol.MappingName = "dongia";
            TextCol.HeaderText = "Đơn giá";
            TextCol.Width = 60;
            TextCol.Format = "###,###,##0";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 3);
            TextCol.MappingName = "lamthem";
            TextCol.HeaderText = "Làm thêm";
            TextCol.Width = 140;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 4);
            TextCol.MappingName = "ketqua";
            TextCol.HeaderText = "Kết quả";
            TextCol.Width = 200;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 5);
            TextCol.MappingName = "ghichu";
            TextCol.HeaderText = "Ghi chú";
            TextCol.Width = 300;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 6);
            TextCol.MappingName = "mavp";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 7);
            TextCol.MappingName = "ngoaihd";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
        }

        public Color MyGetColorRowCol(int row, int col)
        {
            if (this.dataGrid1[row, 7].ToString().Trim() == "1") return Color.Red;
            else return Color.Black;
        }

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
                }
                catch { }
                finally
                {
                    base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
                }
            }
        }

        private void updrec()
        {
            DataRow[] dr;
            ds.Clear();
            bool bFound = false;
            sql = "true";
            if (phai.SelectedIndex != -1) sql += " and phai=" + phai.SelectedIndex;
            foreach (DataRow r2 in dtmuc.Select(sql, "stt"))
            {
                sql = "true";
                if (phai.SelectedIndex != -1) sql += " and phai=" + phai.SelectedIndex;
                if (namsinh.Text != "") sql += " and namsinh<>'' and namsinh" + r2["tt"].ToString().Trim() + "'" + namsinh.Text + "'";
                foreach (DataRow r in dtmuc.Select(sql, "stt"))
                {
                    sql = "true";
                    if (phai.SelectedIndex != -1) sql += " and phai=" + phai.SelectedIndex;
                    if (namsinh.Text != "" && r["namsinh"].ToString() != "") sql += " and namsinh" + r["tt"].ToString().Trim() + "'" + namsinh.Text + "'";
                    dr = dtmuc.Select(sql);
                    if (dr.Length > 0)
                    {
                        ins_items(decimal.Parse(r["id"].ToString()));
                        bFound = true;
                        break;
                    }
                }
                if (bFound) break;
            }
            if (!bFound)
            {
                sql = "true";
                if (phai.SelectedIndex != -1) sql += " and phai=" + phai.SelectedIndex;
                foreach (DataRow r in dtmuc.Select(sql, "phai,namsinh,stt"))
                {
                    sql = "true";
                    if (phai.SelectedIndex != -1 && r["phai"].ToString() != "-1") sql += " and phai=" + phai.SelectedIndex;
                    if (namsinh.Text != "" && r["namsinh"].ToString() != "") sql += " and namsinh" + r["tt"].ToString().Trim() + "'" + namsinh.Text + "'";
                    dr = dtmuc.Select(sql);
                    if (dr.Length > 0)
                    {
                        ins_items(decimal.Parse(r["id"].ToString()));
                        break;
                    }
                }
            }
        }

        private void ins_items(decimal id)
        {
            DataRow r2;
            foreach (DataRow r1 in dtmucct.Select("id=" + id, "stt"))
            {
                r2 = ds.Tables[0].NewRow();
                r2["stt"] = r1["stt"].ToString();
                r2["mavp"] = r1["mavp"].ToString();
                r2["ten"] = r1["ten"].ToString();
                r2["dongia"] = (i_loai == 0) ? r1["gia_nv"].ToString() : r1["gia_ngv"].ToString();
                r2["ngoaihd"] = 0;
                r2["lamthem"] = "";
                r2["ketqua"] = "";
                r2["ghichu"] = "";
                ds.Tables[0].Rows.Add(r2);
            }
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == list && butMoi.Enabled)
            {
                mabn.Text = list.SelectedValue.ToString();
                mabn_Validated(sender, e);
            }
        }

        private void butHuy_Click(object sender, EventArgs e)
        {
            if (l_id == 0) return;
            if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy.")+"\n" + hoten.Text + "?", LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m.execute_data("delete from " + xxx + ".ct_chitiet where id=" + l_id);
                m.execute_data("delete from " + xxx + ".ct_ketqua where id=" + l_id);
                m.delrec(dsll.Tables[0], "id=" + l_id);
                DataRow r = m.getrowbyid(dtlist, "mabn='" + mabn.Text + "'");
                if (r != null) r["done"] = 0;
                m.execute_data("update " + xxx + ".ct_btdbn set done=0 where mabn='" + mabn.Text + "'");
                int i1 = dtlist.Select("done=1").Length, i2 = dtlist.Rows.Count - i1;
                lbl1.Text = "Chưa thực hiện : " + i2.ToString().Trim();
                lbl2.Text = "Đã thực hiện : " + i1.ToString().Trim();
                emp_text();
                list.Focus();
            }
        }

        private void butXoa_Click(object sender, EventArgs e)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?")+" \n" + dataGrid1[dataGrid1.CurrentCell.RowNumber, 1].ToString() + "?", LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    m.delrec(ds.Tables[0], "stt=" + int.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 0].ToString()));
            }
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                frmEditkq f = new frmEditkq(m, int.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 0].ToString()), ds.Tables[0], dataGrid1[dataGrid1.CurrentCell.RowNumber, 1].ToString());
                f.ShowDialog();
                if (f.bOk)
                {
                    DataRow r = m.getrowbyid(ds.Tables[0], "stt=" + dataGrid1[dataGrid1.CurrentCell.RowNumber, 0].ToString());
                    if (r != null)
                    {
                        r["dongia"] = (f._dongia=="")?0:decimal.Parse(f._dongia);
                        r["lamthem"] = f._lamthem;
                        r["ketqua"] = f._ketqua;
                        r["ghichu"] = f._ghichu;
                    }
                }
            }
        }

        private void butPs_Click(object sender, EventArgs e)
        {
            if (mabn.Text == "" || hoten.Text == "") return;
            frmChonchidinh_ct f = new frmChonchidinh_ct(m);
            f.ShowDialog();
            if (f.dt.Rows.Count > 0)
            {
                int stt = 1;
                if (ds.Tables[0].Rows.Count > 0) stt = int.Parse(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["stt"].ToString()) + 1;
                DataRow r1;
                foreach (DataRow r in f.dt.Rows)
                {
                    r1 = ds.Tables[0].NewRow();
                    r1["id"] = l_id;
                    r1["stt"] = stt++;
                    r1["mavp"] = decimal.Parse(r["mavp"].ToString());
                    r1["ten"] = r["ten"].ToString();
                    r1["dongia"]=(i_loai==0)?decimal.Parse(r["dongia"].ToString()): decimal.Parse(r["vattu"].ToString());
                    r1["ngoaihd"] = 0;
                    r1["lamthem"] = "";
                    r1["ketqua"] = "";
                    r1["ghichu"] = "";
                    ds.Tables[0].Rows.Add(r1);
                }
            }
        }

        private void butThem_Click(object sender, EventArgs e)
        {
            if (mabn.Text == "" || hoten.Text == "") return;
            frmChonchidinh f = new frmChonchidinh(m, "", 2, "", "", 2, "", 4, 2,false);
            f.ShowDialog();
            if (f.dt.Rows.Count > 0)
            {
                int stt = 1;
                if (ds.Tables[0].Rows.Count > 0) stt = int.Parse(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["stt"].ToString()) + 1;
                DataRow r1;
                foreach (DataRow r in f.dt.Rows)
                {
                    r1 = ds.Tables[0].NewRow();
                    r1["id"] = l_id;
                    r1["stt"] = stt++;
                    r1["mavp"] = decimal.Parse(r["mavp"].ToString());
                    r1["ten"] = r["ten"].ToString();
                    r1["dongia"] = decimal.Parse(r["dongia"].ToString());
                    r1["ngoaihd"] = 1;
                    r1["lamthem"] = r["ten"].ToString();
                    r1["ketqua"] = "";
                    r1["ghichu"] = "";
                    ds.Tables[0].Rows.Add(r1);
                }
            }
        }

        private void namsinh_Validated(object sender, EventArgs e)
        {
            if (namsinh.Text != "")
                if (namsinh.Text.Length < 4)
                    namsinh.Text = Convert.ToString(DateTime.Now.Year - int.Parse(namsinh.Text));
        }

        private void namsinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}{F4}");            
        }

        private void phai_Validated(object sender, EventArgs e)
        {
            if (l_id==0) updrec();
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            string s="'";
            if (chkAll.Checked) s = "','";
            else if (chkAlldv.Checked) foreach (DataRow r in dtlist.Rows) s += r["mabn"].ToString() + "','";
            else if (mabn.Text != "") s += mabn.Text + "','";
            if (s.Length > 1)
            {
                s = s.Substring(0, s.Length - 2);
                sql = "select f.ten as donvi,a.mabn,a.hoten,a.namsinh,case when a.phai=1 then 'Nữ' else 'Nam' end as phai,";
                sql += "to_char(b.ngay,'dd/mm/yyyy') as ngay,c.ten,c.ketqua,b.ketluan,e.ten as loai,d.hoten as tenbs ";
                sql += " from " + xxx + ".ct_btdbn a inner join " + xxx + ".ct_ketqua b on a.mabn=b.mabn ";
                sql += " inner join " + xxx + ".ct_chitiet c on b.id=c.id ";
                sql += " left join " + user + ".dmbs d on b.mabs=d.ma ";
                sql += " inner join " + user + ".ct_loai e on b.loai=e.id ";
                sql += " inner join " + user + ".ct_donvi f on a.iddonvi=f.id ";
                if (chkAll.Checked) sql += " where f.iddoan=" + l_doan;
                else sql += " where a.mabn in (" + s + ")";
                sql += " order by f.stt,a.stt,c.stt";
                DataSet dsxml = m.get_data(sql);
                if (dsxml.Tables[0].Rows.Count > 0)
                {
                    dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml,s_doan, "rptKetquaksk.rpt");
                    f.ShowDialog();
                }
                else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), LibMedi.AccessData.Msg);
            }
            else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), LibMedi.AccessData.Msg);
        }

        private void phai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == phai && l_id == 0) updrec();
        }

        private void chkAlldv_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkAlldv && chkAlldv.Checked && chkAll.Checked) chkAll.Checked = false;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkAll && chkAlldv.Checked && chkAll.Checked) chkAlldv.Checked = false;
        }

        private void ketluan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}