using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using LibMedi;

namespace Medisoft
{
    public partial class frmDoan : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private AccessData m;
        private string sql, user,s_ma="",s_mmyy="";
        private int i_userid,i_loai;
        private DataRow r1;
        private bool be = true;
        private long l_doan, l_donvi, l_muc,l_save;
        private DataSet ds = new DataSet();
        private DataSet dsxml = new DataSet();
        private DataTable dt1 = new DataTable();
        private DataTable dt2 = new DataTable();
        private DataTable dt3 = new DataTable();
        private DataTable dt4 = new DataTable();
        private DataTable dtgia = new DataTable();
        private DataTable dtmuc = new DataTable();
        private DataTable dtmucct = new DataTable();
        private FileStream fstr;
        private byte[] imagemabn;

        public frmDoan(AccessData acc,int userid)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; i_userid = userid;
        }

        private void frmDoan_Load(object sender, EventArgs e)
        {
            user = m.user;
            loai.SelectedIndex = 0;
            DataTable tmp = m.get_data("select id from " + user + ".ct_loai order by id").Tables[0];
            i_loai = (tmp.Rows.Count > 0) ? int.Parse(tmp.Rows[0]["id"].ToString()) : 0;
            dsxml.ReadXml("..//..//..//xml//m_khamksk.xml");
            dtgia = m.get_data("select * from " + user + ".ct_giavp").Tables[0];
            sql = "select a.*,to_char(a.ngay,'dd/mm/yyyy') as ngayhd,to_char(a.ngayud,'mmyy') as mmyy from " + user + ".ct_doan a order by a.id desc ";
            ds = m.get_data(sql);
            cmbten.DisplayMember = "TEN";
            cmbten.ValueMember = "ID";
            cmbten.DataSource = ds.Tables[0];
            l_doan = (cmbten.SelectedIndex != -1) ? long.Parse(cmbten.SelectedValue.ToString()) : 0;
            load_doan();
        }

        private void ten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void loai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (loai.SelectedIndex == -1) loai.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void cmbten_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cmbten && cmbten.SelectedIndex!=-1)
            {
                upd_ct_mucct();
                l_doan = long.Parse(cmbten.SelectedValue.ToString());
                load_doan();
            }
        }

        private void load_doan()
        {
            r1=m.getrowbyid(ds.Tables[0],"id="+l_doan);
            if (r1 != null)
            {
                ten.Text = r1["ten"].ToString();
                sohd.Text = r1["sohd"].ToString();
                ngay.Text = r1["ngayhd"].ToString();
                loai.SelectedIndex = int.Parse(r1["loai"].ToString());
                diachi.Text = r1["diachi"].ToString();
                dienthoai.Text = r1["dienthoai"].ToString();
                fax.Text = r1["fax"].ToString();
                email.Text = r1["email"].ToString();
                masothue.Text = r1["masothue"].ToString();
                nguoilienhe.Text = r1["nguoilienhe"].ToString();
                ghichu.Text = r1["ghichu"].ToString();
                s_ma = r1["ma"].ToString();
                s_mmyy = r1["mmyy"].ToString();
            }
            load_donvi();
            load_danhsach();
            load_muc();
            load_mucct();
            be = false;
        }

        private void ngay_Validated(object sender, EventArgs e)
        {
            if (ngay.Text == "")
            {
                ngay.Focus();
                return;
            }
            ngay.Text = ngay.Text.Trim();
            if (ngay.Text.Length == 6) ngay.Text = ngay.Text + DateTime.Now.Year.ToString();
            if (ngay.Text.Length < 10)
            {
                MessageBox.Show(
lan.Change_language_MessageText(
"Yêu cầu nhập Ngày!"));
                ngay.Focus();
                return;
            }
            if (!m.bNgay(ngay.Text))
            {
                MessageBox.Show(
lan.Change_language_MessageText(
"Ngày và giờ không hợp lệ !"));
                ngay.Focus();
                return;
            }

        }

        private void ena_object(bool ena)
        {
            cmbten.Visible = !ena;
            ten.Enabled = ena;
            sohd.Enabled = ena;
            ngay.Enabled = ena;
            loai.Enabled = ena;
            diachi.Enabled = ena;
            dienthoai.Enabled = ena;
            fax.Enabled = ena;
            email.Enabled = ena;
            masothue.Enabled = ena;
            nguoilienhe.Enabled = ena;
            ghichu.Enabled = ena;
            butMoi.Enabled = !ena;
            butSua.Enabled = !ena;
            butLuu.Enabled = ena;
            butBoqua.Enabled = ena;
            butHuy.Enabled = !ena;
            butIn.Enabled = !ena;
            butKetthuc.Enabled = !ena;
            butdvthem.Enabled = !ena;
            butdvsua.Enabled = !ena;
            butdvxoa.Enabled = !ena;
            butmucsua.Enabled = !ena;
            butmucthem.Enabled = !ena;
            butmucxoa.Enabled = !ena;
            butdssua.Enabled = !ena;
            butdsthem.Enabled = !ena;
            butdsxoa.Enabled = !ena;
            butFile.Enabled = !ena;
            butdvsua.Enabled = !ena;
            butctthem.Enabled = !ena;
            butctxoa.Enabled = !ena;
        }

        private void emp_text()
        {
            l_doan = 0; l_donvi = 0; l_muc = 0; s_ma = "";
            ten.Text = ""; sohd.Text = ""; ngay.Text = m.ngayhienhanh_server.Substring(0, 10);
            s_mmyy = m.mmyy(ngay.Text); diachi.Text = ""; dienthoai.Text = ""; fax.Text = ""; email.Text = "";
            masothue.Text = ""; nguoilienhe.Text = ""; ghichu.Text = "";
            dt1.Clear(); dt2.Clear(); dt3.Clear(); dt4.Clear();
        }

        private void butMoi_Click(object sender, EventArgs e)
        {
            upd_ct_mucct();
            l_save = (cmbten.SelectedIndex!=-1)?long.Parse(cmbten.SelectedValue.ToString()):0;
            ena_object(true);
            emp_text();
            ten.Focus();
        }

        private void butSua_Click(object sender, EventArgs e)
        {
            if (cmbten.SelectedIndex == -1) return;
            l_save = long.Parse(cmbten.SelectedValue.ToString());
            ena_object(true);
            ten.Focus();
        }

        private bool kiemtra()
        {
            if (ten.Text == "")
            {
                MessageBox.Show(
lan.Change_language_MessageText(
"Yêu cầu nhập tên đoàn !"), LibMedi.AccessData.Msg);
                ten.Focus();
                return false;
            }
            return true;
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            if (!kiemtra()) return;
            if (l_doan == 0) 
            {
                l_doan = m.get_id_ct_doan;
                s_ma=m.get_ma_kskdoan(ngay.Text);
            }
            m.upd_ct_doan(l_doan, sohd.Text, ngay.Text, loai.SelectedIndex, s_ma, ten.Text, diachi.Text, dienthoai.Text, fax.Text, email.Text, masothue.Text, nguoilienhe.Text, ghichu.Text, i_userid);
            updrec();
            cmbten.SelectedValue = l_doan.ToString();
            load_doan();
            ena_object(false);
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            cmbten.SelectedValue = l_save.ToString();
            l_doan = (cmbten.SelectedIndex != -1) ? long.Parse(cmbten.SelectedValue.ToString()) : 0;
            load_doan();
            ena_object(false);
        }

        private void butHuy_Click(object sender, EventArgs e)
        {
            if (cmbten.SelectedIndex == -1) return;
            if (m.get_data("select a.* from "+user+s_mmyy+".ct_btdbn a,"+user+".ct_donvi b where a.iddonvi=b.id and b.iddoan="+l_doan+" and a.done=1").Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(
lan.Change_language_MessageText(
"Đã nhập kết qủa, không được hủy !"), LibMedi.AccessData.Msg);
                return;
            }
            if (MessageBox.Show(
lan.Change_language_MessageText(
"Đồng ý hủy")+"\n" + cmbten.Text, LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach(DataRow r in m.get_data("select * from "+user+".ct_muc where iddoan="+l_doan).Tables[0].Rows)
                    m.execute_data("delete from " + user + ".ct_mucct where id=" + long.Parse(r["id"].ToString()));
                m.execute_data("delete from " + user + ".ct_muc where iddoan=" + l_doan);
                foreach (DataRow r in m.get_data("select * from " + user + ".ct_donvi where iddoan=" + l_doan).Tables[0].Rows)
                    m.execute_data("delete from " + user + s_mmyy + ".ct_btdbn where iddonvi="+long.Parse(r["id"].ToString()));
                m.execute_data("delete from " + user + ".ct_donvi where iddoan=" + l_doan);
                m.execute_data("delete from " + user + ".ct_doan where id=" + l_doan);
                sql = "select a.*,to_char(a.ngay,'dd/mm/yyyy') as ngayhd,to_char(a.ngayud,'mmyy') as mmyy from " + user + ".ct_doan a order by a.id desc ";
                ds = m.get_data(sql);
                cmbten.DataSource = ds.Tables[0];
                l_doan = (cmbten.SelectedIndex != -1) ? long.Parse(cmbten.SelectedValue.ToString()) : 0;
                load_doan();
            }
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            upd_ct_mucct();
            m.close();this.Close();
        }

        private void updrec()
        {
            r1 = m.getrowbyid(ds.Tables[0], "id=" + l_doan);
            if (r1 == null)
            {
                DataRow r2 = ds.Tables[0].NewRow();
                r2["id"] = l_doan;
                r2["ma"] = s_ma;
                r2["ten"] = ten.Text;
                r2["sohd"] = sohd.Text;
                r2["ngayhd"] = ngay.Text;
                r2["loai"] = loai.SelectedIndex;
                r2["diachi"] = diachi.Text;
                r2["dienthoai"] = dienthoai.Text;
                r2["fax"] = fax.Text;
                r2["email"] = email.Text;
                r2["masothue"] = masothue.Text;
                r2["nguoilienhe"] = nguoilienhe.Text;
                r2["ghichu"] = ghichu.Text;
                r2["mmyy"] = s_mmyy;
                ds.Tables[0].Rows.Add(r2);
            }
            else
            {
                DataRow[] dr = ds.Tables[0].Select("id=" + l_doan);
                if (dr.Length > 0)
                {
                    dr[0]["ma"] = s_ma;
                    dr[0]["ten"] = ten.Text;
                    dr[0]["sohd"] = sohd.Text;
                    dr[0]["ngayhd"] = ngay.Text;
                    dr[0]["loai"] = loai.SelectedIndex;
                    dr[0]["diachi"] = diachi.Text;
                    dr[0]["dienthoai"] = dienthoai.Text;
                    dr[0]["fax"] = fax.Text;
                    dr[0]["email"] = email.Text;
                    dr[0]["masothue"] = masothue.Text;
                    dr[0]["nguoilienhe"] = nguoilienhe.Text;
                    dr[0]["ghichu"] = ghichu.Text;
                    dr[0]["mmyy"] = s_mmyy;
                }
            }
        }

        private void butdvthem_Click(object sender, EventArgs e)
        {
            if (l_doan == 0) return;
            dllDanhmucMedisoft.frmDonvi f = new dllDanhmucMedisoft.frmDonvi(m, l_doan, 0, i_userid, dt1, cmbten.Text);
            f.ShowDialog();
            if (f.bOk) load_donvi();
        }

        private void load_donvi()
        {
            sql = "select id,iddoan,stt,ma,ten,to_char(tu,'dd/mm/yyyy') as tu,to_char(den,'dd/mm/yyyy') as den from " + user + ".ct_donvi where iddoan=" + l_doan + " order by stt";
            dt1 = m.get_data(sql).Tables[0];
            dataGrid1.DataSource = dt1;
            l_donvi = (dt1.Rows.Count > 0) ? long.Parse(dt1.Rows[0]["id"].ToString()) : 0;
            dataGrid1.CaptionText = 
lan.Change_language_MessageText(
"Đơn vị trong đoàn :")+" " + dt1.Rows.Count.ToString();
            if (be) AddGridTableStyle1();
            lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
            lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

        }

        private void AddGridTableStyle1()
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
            TextCol.MappingName = "id";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "stt";
            TextCol.HeaderText = "Stt";
            TextCol.Width = 30;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ten";
            TextCol.HeaderText = "Đơn vị";
            TextCol.Width = 225;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tu";
            TextCol.HeaderText = "Từ ngày";
            TextCol.Width = 65;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "den";
            TextCol.HeaderText = "Đến";
            TextCol.Width = 65;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ma";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
        }

        private void butdvsua_Click(object sender, EventArgs e)
        {
            if (dt1.Rows.Count > 0)
            {
                dllDanhmucMedisoft.frmDonvi f = new dllDanhmucMedisoft.frmDonvi(m, l_doan, long.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 0].ToString()), i_userid, dt1, cmbten.Text);
                f.ShowDialog();
                if (f.bOk) load_donvi();               
            }
        }

        private void butdvxoa_Click(object sender, EventArgs e)
        {
            if (dt1.Rows.Count > 0)
            {
                if (dt2.Select("done=1").Length > 0)
                {
                    MessageBox.Show(
lan.Change_language_MessageText(
"Đã nhập kết qủa, không được hủy !"), LibMedi.AccessData.Msg);
                    return;
                }
                if (MessageBox.Show(
lan.Change_language_MessageText(
"Đồng ý xóa")+" \n" + dataGrid1[dataGrid1.CurrentCell.RowNumber, 2].ToString() + "?", LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sql = "delete from " + user + ".ct_donvi where id=" + long.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 0].ToString());
                    m.execute_data(sql);
                    sql = "delete from " + user+s_mmyy + ".ct_btdbn where iddonvi=" + long.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 0].ToString());
                    m.execute_data(sql);
                    load_donvi();
                    load_danhsach();
                }
            }
        }

        private void load_danhsach()
        {
            if (s_mmyy == "") return;
            string xxx = user + s_mmyy;
            sql = "select stt,mabn,hoten,namsinh,phai,case when phai=0 then 'Nam' else 'Nữ ' end as gioitinh,done from " + xxx + ".ct_btdbn where iddonvi=" + l_donvi + " order by stt";
            dt2 = m.get_data(sql).Tables[0];
            dataGrid2.DataSource = dt2;
            dt1.AcceptChanges();
            dataGrid2.CaptionText = ((dt1.Rows.Count>0)?dataGrid1[dataGrid1.CurrentCell.RowNumber, 2].ToString():"")+ " : " + dt2.Rows.Count.ToString();
            if (be) AddGridTableStyle2();
            lan.Read_dtgrid_to_Xml(dataGrid2, this.Name.ToString()+"_"+dataGrid2.Name.ToString());
            lan.Change_dtgrid_HeaderText_to_English(dataGrid2, this.Name.ToString()+"_"+dataGrid2.Name.ToString());

        }

        private void AddGridTableStyle2()
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
            TextCol.MappingName = "stt";
            TextCol.HeaderText = "Stt";
            TextCol.Width = 30;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "mabn";
            TextCol.HeaderText = "Mã số";
            TextCol.Width = 60;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "hoten";
            TextCol.HeaderText = "Họ và tên";
            TextCol.Width = 225;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "namsinh";
            TextCol.HeaderText = "NS";
            TextCol.Width = 35;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "gioitinh";
            TextCol.HeaderText = "Giới tính";
            TextCol.Width = 35;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "done";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);
        }

        private void butdsthem_Click(object sender, EventArgs e)
        {
            if (dt1.Rows.Count == 0) return;
            l_donvi = long.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 0].ToString());
            frmDanhsach f = new frmDanhsach(m, s_mmyy, s_ma + dataGrid1[dataGrid1.CurrentCell.RowNumber, 5].ToString(), "", l_donvi, i_userid, dt2, dataGrid1[dataGrid1.CurrentCell.RowNumber, 2].ToString());
            f.ShowDialog();
            if (f.bOk) load_danhsach();
        }

        private void butdssua_Click(object sender, EventArgs e)
        {
            if (dt1.Rows.Count == 0 || dt2.Rows.Count==0) return;
            l_donvi = long.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 0].ToString());
            frmDanhsach f = new frmDanhsach(m, s_mmyy, s_ma + dataGrid1[dataGrid1.CurrentCell.RowNumber, 5].ToString(), dataGrid2[dataGrid2.CurrentCell.RowNumber, 1].ToString(), l_donvi, i_userid, dt2, dataGrid1[dataGrid1.CurrentCell.RowNumber, 2].ToString());
            f.ShowDialog();
            if (f.bOk) load_danhsach();
        }

        private void butdsxoa_Click(object sender, EventArgs e)
        {
            if (dt2.Rows.Count > 0)            
            {
                if (dataGrid2[dataGrid2.CurrentCell.RowNumber, 5].ToString() == "1")
                {
                    MessageBox.Show(
lan.Change_language_MessageText(
"Đã nhập kết quả, không được hủy !"), LibMedi.AccessData.Msg);
                    return;
                }
                if (MessageBox.Show(
lan.Change_language_MessageText(
"Đồng ý xóa")+" \n" + dataGrid2[dataGrid2.CurrentCell.RowNumber, 2].ToString() + "?", LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sql = "delete from " + user+s_mmyy + ".ct_btdbn where mabn='" + dataGrid2[dataGrid2.CurrentCell.RowNumber, 1].ToString()+"'";
                    m.execute_data(sql);
                    load_danhsach();
                }
            }
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                l_donvi = long.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 0].ToString());
            }
            catch { l_donvi = 0;}
            load_danhsach();
        }

        private void butFile_Click(object sender, EventArgs e)
        {
            if (dt1.Rows.Count == 0) return;
            l_donvi = long.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 0].ToString());
            dllDanhmucMedisoft.frmDsexcel f = new dllDanhmucMedisoft.frmDsexcel(m, s_mmyy, s_ma + dataGrid1[dataGrid1.CurrentCell.RowNumber, 5].ToString(), l_donvi, i_userid, dataGrid1[dataGrid1.CurrentCell.RowNumber, 2].ToString());
            f.ShowDialog();
            if (f.bOk) load_danhsach();
        }

        private void load_muc()
        {
            sql = "select * from " + user + ".ct_muc where iddoan=" + l_doan + " order by stt";
            dt3 = m.get_data(sql).Tables[0];
            l_muc = (dt3.Rows.Count > 0) ? long.Parse(dt3.Rows[0]["id"].ToString()) : 0;
            dataGrid3.DataSource = dt3;
            dataGrid3.CaptionText = 
lan.Change_language_MessageText(
"Mục đăng ký trong đoàn :")+" " + dt3.Rows.Count.ToString();
            if (be) AddGridTableStyle3();
            lan.Read_dtgrid_to_Xml(dataGrid3, this.Name.ToString() + "_" + dataGrid3.Name.ToString());
            lan.Change_dtgrid_HeaderText_to_English(dataGrid3, this.Name.ToString() + "_" + dataGrid3.Name.ToString());


        }

        private void AddGridTableStyle3()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dt3.TableName;
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
            TextCol.MappingName = "id";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "stt";
            TextCol.HeaderText = "Stt";
            TextCol.Width = 20;
            TextCol.ReadOnly = true;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ghichu";
            TextCol.HeaderText = "Nội dung";
            TextCol.Width = 307;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);
        }

        private void butmucthem_Click(object sender, EventArgs e)
        {
            if (l_doan == 0) return;
            dllDanhmucMedisoft.frmMuc f = new dllDanhmucMedisoft.frmMuc(m, 0, l_doan, dt3, cmbten.Text);
            f.ShowDialog();
            if (f.bOk) load_muc();
        }

        private void butmucsua_Click(object sender, EventArgs e)
        {
            if (l_doan == 0 || dt3.Rows.Count==0) return;
            l_muc=long.Parse(dataGrid3[dataGrid3.CurrentCell.RowNumber,0].ToString());
            dllDanhmucMedisoft.frmMuc f = new dllDanhmucMedisoft.frmMuc(m, l_muc, l_doan, dt3, cmbten.Text);
            f.ShowDialog();
            if (f.bOk) load_muc();
        }

        private void butmucxoa_Click(object sender, EventArgs e)
        {
            if (dt3.Rows.Count > 0)
            {
                if (MessageBox.Show(
lan.Change_language_MessageText(
"Đồng ý xóa")+"\n" + dataGrid3[dataGrid3.CurrentCell.RowNumber, 2].ToString() + "?", LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sql = "delete from " + user + ".ct_mucct where id=" + long.Parse(dataGrid3[dataGrid3.CurrentCell.RowNumber, 0].ToString());
                    m.execute_data(sql);
                    sql = "delete from " + user + ".ct_muc where id=" + long.Parse(dataGrid3[dataGrid3.CurrentCell.RowNumber, 0].ToString());
                    m.execute_data(sql);
                    load_muc();
                    load_mucct();
                }
            }
        }

        private void dataGrid3_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                l_muc = long.Parse(dataGrid3[dataGrid3.CurrentCell.RowNumber, 0].ToString());
            }
            catch { l_muc = 0; }
            upd_ct_mucct();
            load_mucct();
        }

        private void load_mucct()
        {
            sql = "select a.*,b.ten from " + user + ".ct_mucct a,"+user+".ct_giavp b where a.mavp=b.id and a.id=" + l_muc + " order by a.stt";
            dt4 = m.get_data(sql).Tables[0];
            dataGrid4.DataSource = dt4;
            dt3.AcceptChanges();
            dataGrid4.CaptionText = ((dt3.Rows.Count > 0) ? dataGrid3[dataGrid3.CurrentCell.RowNumber, 2].ToString() : "") + " : " + dt4.Rows.Count.ToString();
            if (be) AddGridTableStyle4();
            lan.Read_dtgrid_to_Xml(dataGrid4, this.Name.ToString() + "_" + dataGrid4.Name.ToString());
            lan.Change_dtgrid_HeaderText_to_English(dataGrid4, this.Name.ToString() + "_" + dataGrid4.Name.ToString());

        }

        private void AddGridTableStyle4()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dt4.TableName;
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
            TextCol.MappingName = "mavp";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid4.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "stt";
            TextCol.HeaderText = "Stt";
            TextCol.Width = 20;
            TextCol.ReadOnly = true;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid4.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ten";
            TextCol.HeaderText = "Nội dung";
            TextCol.Width = 130;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid4.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "gia_nv";
            TextCol.HeaderText = "Nội viện";
            TextCol.Width = 60;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.Format = "### ### ### ###";
            ts.GridColumnStyles.Add(TextCol);
            dataGrid4.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "gia_ngv";
            TextCol.HeaderText = "Ngoại viện";
            TextCol.Width = 60;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.Format = "### ### ### ###";
            ts.GridColumnStyles.Add(TextCol);
            dataGrid4.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ghichu";
            TextCol.HeaderText = "Ghi chú";
            TextCol.Width = 200;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid4.TableStyles.Add(ts);
        }

        private void butctthem_Click(object sender, EventArgs e)
        {
            if (l_muc == 0) return;
            frmChonchidinh_ct f = new frmChonchidinh_ct(m);
            f.ShowDialog();
            if (f.dt.Rows.Count > 0)
            {
                int stt = 1;
                if (dt4.Rows.Count > 0) stt = int.Parse(dt4.Rows[dt4.Rows.Count - 1]["stt"].ToString()) + 1;
                DataRow r1;
                foreach (DataRow r in f.dt.Rows)
                {
                    r1 = m.getrowbyid(dtgia, "id=" + long.Parse(r["mavp"].ToString()));
                    if (r1!=null)
                        m.upd_ct_mucct(l_muc, long.Parse(r["mavp"].ToString()), stt++, decimal.Parse(r["dongia"].ToString()), decimal.Parse(r["vattu"].ToString()),r1["ghichu"].ToString());
                }
                load_mucct();
            }
        }

        private void butctxoa_Click(object sender, EventArgs e)
        {
            if (dt4.Rows.Count > 0)
            {
                try
                {
                    if (MessageBox.Show(
lan.Change_language_MessageText(
"Đồng ý xóa")+"\n" + dataGrid4[dataGrid4.CurrentCell.RowNumber, 2].ToString() + "?", LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sql = "delete from " + user + ".ct_mucct where id=" + l_muc + " and mavp=" + long.Parse(dataGrid4[dataGrid4.CurrentCell.RowNumber, 0].ToString());
                        m.execute_data(sql);
                        m.delrec(dt4, "id=" + l_muc + " and mavp=" + long.Parse(dataGrid4[dataGrid4.CurrentCell.RowNumber, 0].ToString()));
                        dt4.AcceptChanges();
                    }
                }
                catch { }
            }
        }

        private void tim_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == tim) RefreshChildren(tim.Text);
        }

        private void tim_Enter(object sender, EventArgs e)
        {
            tim.Text = "";
        }

        public void RefreshChildren(string text)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[cmbten.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "ten like '%" + text.Trim() + "%' or sohd like '%" + text + "%'";
                if (cmbten.Items.Count > 0) l_doan = long.Parse(cmbten.SelectedValue.ToString());
                else l_doan = 0;                
            }
            catch { l_doan = 0; }
            load_doan();
        }

        private void upd_ct_mucct()
        {
            dt4.AcceptChanges();
            foreach (DataRow r in dt4.Rows)
                m.upd_ct_mucct(long.Parse(r["id"].ToString()), long.Parse(r["mavp"].ToString()), decimal.Parse(r["stt"].ToString()),(r["gia_nv"].ToString()=="")?0:decimal.Parse(r["gia_nv"].ToString()),(r["gia_ngv"].ToString()=="")?0:decimal.Parse(r["gia_ngv"].ToString()), r["ghichu"].ToString());
        }

        private void chkAlldv_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkAlldv && chkAlldv.Checked && chkAll.Checked) chkAll.Checked = false;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkAll && chkAlldv.Checked && chkAll.Checked) chkAlldv.Checked = false;
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            dsxml.Clear();
            if (cmbten.SelectedIndex == -1) return;
            string s = "'",xxx=user+s_mmyy,_ngay=m.ngayhienhanh_server.Substring(0,10);
            long l_id=0;
            if (chkAll.Checked) s = "','";
            else if (chkAlldv.Checked) foreach (DataRow r in dt2.Rows) s += r["mabn"].ToString() + "','";
            else if (dt2.Rows.Count > 0) s += dataGrid2[dataGrid2.CurrentCell.RowNumber, 1].ToString() + "','";
            if (s.Length > 1)
            {
                s = s.Substring(0, s.Length - 2);
                sql = "select f.ten as donvi,a.mabn,a.hoten,a.namsinh,a.phai,a.iddonvi";
                sql += " from " + xxx + ".ct_btdbn a inner join " + user + ".ct_donvi f on a.iddonvi=f.id ";
                if (chkAll.Checked) sql += " where f.iddoan=" + l_doan;
                else sql += " where a.mabn in (" + s + ")";
                sql += " order by f.stt,a.stt";
                dtmuc = m.get_data("select * from " + user + ".ct_muc where iddoan=" + l_doan + " order by stt").Tables[0];
                dtmucct = m.get_data("select b.*,c.ten from " + user + ".ct_muc a," + user + ".ct_mucct b," + user + ".ct_giavp c where a.id=b.id and b.mavp=c.id and a.iddoan=" + l_doan + " order by stt").Tables[0];
                foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                {
                    barcode.Text = r["mabn"].ToString();
                    barcode.Update();
                    barcode.Picture.Save("..//..//..//xml//barcode.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                    fstr = new FileStream("..//..//..//xml//barcode.bmp", FileMode.Open, FileAccess.Read);
                    imagemabn = new byte[fstr.Length];
                    fstr.Read(imagemabn, 0, System.Convert.ToInt32(fstr.Length));
                    fstr.Dispose();
                    fstr.Close();
                    updrec(cmbten.Text.ToUpper(),r["donvi"].ToString(),r["mabn"].ToString(),r["hoten"].ToString(),r["namsinh"].ToString(),int.Parse(r["phai"].ToString()));
                    //
                    if (m.get_data("select id from " + xxx + ".ct_ketqua where mabn='" + r["mabn"].ToString() + "' and iddonvi=" + long.Parse(r["iddonvi"].ToString())).Tables[0].Rows.Count==0)
                    {
                        l_id = m.get_id_ct_ketqua;
                        m.upd_ct_ketqua(s_mmyy, l_id, long.Parse(r["iddonvi"].ToString()), r["mabn"].ToString(), _ngay,"",i_loai,"", i_userid);
                        foreach (DataRow r1 in dsxml.Tables[0].Select("mabn='"+r["mabn"].ToString()+"'","stt"))
                            m.upd_ct_chitiet(s_mmyy, l_id, int.Parse(r1["stt"].ToString()), long.Parse(r1["mavp"].ToString()), r1["ten"].ToString(), decimal.Parse(r1["dongia"].ToString()), 0, "", "", "");
                    }
                    //
                }
                if (dsxml.Tables[0].Rows.Count > 0)
                {
                    dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml, cmbten.Text.ToUpper(), "rptPhieuksk.rpt");
                    f.ShowDialog();
                }
                else MessageBox.Show(
lan.Change_language_MessageText(
"Không có số liệu !"), LibMedi.AccessData.Msg);
            }
            else MessageBox.Show(
lan.Change_language_MessageText(
"Không có số liệu !"), LibMedi.AccessData.Msg);
        }

        private void updrec(string doan,string donvi,string mabn,string hoten,string namsinh,int phai)
        {
            DataRow[] dr;
            bool bFound = false;
            sql = "true";
            if (phai != -1) sql += " and phai=" + phai;
            foreach (DataRow r2 in dtmuc.Select(sql, "stt"))
            {
                sql = "true";
                if (phai != -1) sql += " and phai=" + phai;
                if (namsinh != "") sql += " and namsinh<>'' and namsinh" + r2["tt"].ToString().Trim() + "'" + namsinh + "'";
                foreach (DataRow r in dtmuc.Select(sql, "stt"))
                {
                    sql = "true";
                    if (phai != -1) sql += " and phai=" + phai;
                    if (namsinh != "" && r["namsinh"].ToString() != "") sql += " and namsinh" + r["tt"].ToString().Trim() + "'" + namsinh + "'";
                    dr = dtmuc.Select(sql);
                    if (dr.Length > 0)
                    {
                        ins_items(doan,donvi,mabn,hoten,namsinh,phai,long.Parse(r["id"].ToString()));
                        bFound = true;
                        break;
                    }
                }
                if (bFound) break;
            }
            if (!bFound)
            {
                sql = "true";
                if (phai != -1) sql += " and phai=" + phai;
                foreach (DataRow r in dtmuc.Select(sql, "phai,namsinh,stt"))
                {
                    sql = "true";
                    if (phai != -1 && r["phai"].ToString() != "-1") sql += " and phai=" + phai;
                    if (namsinh != "" && r["namsinh"].ToString() != "") sql += " and namsinh" + r["tt"].ToString().Trim() + "'" + namsinh + "'";
                    dr = dtmuc.Select(sql);
                    if (dr.Length > 0)
                    {
                        ins_items(doan,donvi, mabn, hoten, namsinh, phai, long.Parse(r["id"].ToString()));
                        break;
                    }
                }
            }
        }

        private void ins_items(string doan,string donvi,string mabn,string hoten,string namsinh,int phai,long id)
        {
            DataRow r2;
            foreach (DataRow r1 in dtmucct.Select("id=" + id, "stt"))
            {
                r2 = dsxml.Tables[0].NewRow();
                r2["doan"] = doan;
                r2["donvi"] = donvi.ToUpper();
                r2["mabn"] = mabn;
                r2["hoten"] = hoten;
                r2["namsinh"] = namsinh;
                r2["phai"] = (phai == 1) ? "Nữ" : "Nam";
                r2["luuy"] = ghichu.Text;
                r2["image"] = imagemabn;
                r2["stt"] = r1["stt"].ToString();
                r2["mavp"] = r1["mavp"].ToString();
                r2["ten"] = r1["ten"].ToString();
                r2["dongia"] = (loai.SelectedIndex == 0) ? r1["gia_nv"].ToString() : r1["gia_ngv"].ToString();
                r2["ghichu"] = r1["ghichu"].ToString();
                dsxml.Tables[0].Rows.Add(r2);
            }
        }
   }
}