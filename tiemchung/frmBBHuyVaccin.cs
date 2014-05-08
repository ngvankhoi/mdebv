using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace tiemchung
{
    public partial class frmBBHuyVaccin : Form
    {
        LibMedi.AccessData m;
        Language lan = new Language();
        DataTable dt = new DataTable();
        DataTable dtbs = new DataTable();
        DataTable dtVaccin = new DataTable();
        int i_userid = 0,i_chinhanh=0;
        string sql = "",user="";
        decimal d_id = 0;
        bool bNew = false;

        public frmBBHuyVaccin(LibMedi.AccessData _m,int _userid,int _chinhanh)
        {
            InitializeComponent();
            m = _m;
            i_userid = _userid;
            i_chinhanh = _chinhanh;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }

        private void frmBBHuyVaccin_Load(object sender, EventArgs e)
        {
            user = m.user;
            sql = "select ma,hoten from "+user+".dmbs where chinhanh="+i_chinhanh;
            dtbs = m.get_data(sql).Tables[0];

            listDDT.DataSource = dtbs;
            listDDT.ValueMember = "hoten";
            listDDT.DisplayMember = "ma";

            listDDPT.DataSource = dtbs.Copy();
            listDDPT.ValueMember = "hoten";
            listDDPT.DisplayMember = "ma";

            listNTT.DataSource = dtbs.Copy();
            listNTT.ValueMember = "hoten";
            listNTT.DisplayMember = "ma";

            sql = "select id,ten||' '||hamluong as ten,ma from " + user + ".d_dmbd where vacxin=1";
            dtVaccin = m.get_data(sql).Tables[0];
            listVaccin.DataSource = dtVaccin.Copy();
            listVaccin.ValueMember = "ten";
            listVaccin.DisplayMember = "id";

            load_data();
            cmbSoluutru.DisplayMember = "soluutru";
            cmbSoluutru.ValueMember = "id";

            if (dt.Rows.Count > 0)
            {
                cmbSoluutru.SelectedIndex = 0;
                cmbSoluutru_SelectedIndexChanged(null, null);
            }
        }

        private void load_data()
        {
            sql = "select id,soluutru,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay, madieuduong,truongbophan,dieuduongphong,to_char(tungay,'dd/mm/yyyy') as tungay,to_char(denngay,'dd/mm/yyyy') as denngay,mabd,soluong,losx,userid  from "+user+".huyvacxin ";
            dt = m.get_data(sql).Tables[0];
            cmbSoluutru.DataSource = dt;
        }

        private void emp_detail()
        {
            txtNgay.Value = DateTime.Now;
            txtMaDDTruong.Text = "";
            txtMaDDPTiem.Text = "";
            txtMaTruongnhathuoc.Text = "";
            txtMaVaccin.Text = "";
            txtSoluong.Text = "0";
            txtTenVaccin.Text = "";
            txtTruongnhathuoc.Text = "";
            txtLosx.Text = "";
            txtDDTruong.Text = "";
            txtDDPTiem.Text = "";
            tungay.Value = DateTime.Now;
            denngay.Value = DateTime.Now;
        }

        private void cmbSoluutru_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                d_id = decimal.Parse(cmbSoluutru.SelectedValue.ToString());
                DataRow r = m.getrowbyid(dt, "id=" + d_id);
                txtNgay.Text = r["ngay"].ToString();
                txtMaDDTruong.Text = r["madieuduong"].ToString();
                txtMaDDTruong_Validated(null, null);
                txtMaTruongnhathuoc.Text = r["truongbophan"].ToString();
                txtMaTruongnhathuoc_Validated(null, null);
                txtMaDDPTiem.Text = r["dieuduongphong"].ToString();
                txtMaDDPTiem_Validated(null, null);
                tungay.Text = r["tungay"].ToString();
                denngay.Text = r["denngay"].ToString();
                txtSoluong.Text = r["soluong"].ToString();
                txtLosx.Text = r["losx"].ToString();
                txtMabd.Text = r["mabd"].ToString();
                txtMabd_Validated(null, null);
            }
            catch { }
        }

        private void txtDDTruong_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txtDDTruong)
            {
                Filt_tenbs(txtDDTruong.Text,listDDT);

                listDDT.BrowseToICD10(txtDDTruong, txtMaDDTruong, txtMaTruongnhathuoc, txtMaDDTruong.Location.X, txtMaDDTruong.Location.Y + txtMaDDTruong.Height - 2, txtMaDDTruong.Width + txtDDTruong.Width + 2, txtDDTruong.Height);
                
            }		
        }

        private void Filt_tenbs(string ten,LibList.List list)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[list.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "hoten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void txtDDTruong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listDDT.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listDDT.Visible) listDDT.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }		
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMaDDTruong_Validated(object sender, EventArgs e)
        {
            if (txtMaDDTruong.Text != "")
            {
                DataRow r = m.getrowbyid(dtbs, "ma='" + txtMaDDTruong.Text.Trim() + "'");
                if (r != null) txtDDTruong.Text = r["hoten"].ToString();
                else txtDDTruong.Text = "";
            }
        }

        private void txtTruongnhathuoc_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txtTruongnhathuoc)
            {
                Filt_tenbs(txtTruongnhathuoc.Text, listNTT);

                listNTT.BrowseToICD10(txtTruongnhathuoc, txtMaTruongnhathuoc, txtMaDDPTiem, txtMaTruongnhathuoc.Location.X, txtMaTruongnhathuoc.Location.Y + txtMaTruongnhathuoc.Height - 2, txtMaTruongnhathuoc.Width + txtTruongnhathuoc.Width + 2, txtTruongnhathuoc.Height);

            }		
        }

        private void txtMaTruongnhathuoc_Validated(object sender, EventArgs e)
        {
            if (txtMaTruongnhathuoc.Text != "")
            {
                DataRow r = m.getrowbyid(dtbs, "ma='" + txtMaTruongnhathuoc.Text.Trim() + "'");
                if (r != null) txtTruongnhathuoc.Text = r["hoten"].ToString();
                else txtTruongnhathuoc.Text = "";
            }
        }

        private void txtTruongnhathuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listNTT.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listNTT.Visible) listNTT.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }	
        }

        private void txtDDPTiem_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txtDDPTiem)
            {
                Filt_tenbs(txtDDPTiem.Text, listDDPT);

                listDDPT.BrowseToICD10(txtDDPTiem, txtMaDDPTiem, txtMaVaccin, txtMaDDPTiem.Location.X, txtMaDDPTiem.Location.Y + txtMaDDPTiem.Height - 2, txtMaDDPTiem.Width + txtDDPTiem.Width + 2, txtDDPTiem.Height);

            }	
        }

        private void txtDDPTiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listDDPT.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listDDPT.Visible) listDDPT.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }	
        }

        private void txtMaDDPTiem_Validated(object sender, EventArgs e)
        {
            if (txtMaDDPTiem.Text != "")
            {
                DataRow r = m.getrowbyid(dtbs, "ma='" + txtMaDDPTiem.Text.Trim() + "'");
                if (r != null) txtDDPTiem.Text = r["hoten"].ToString();
                else txtDDPTiem.Text = "";
            }
        }

        private void txtTenVaccin_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txtTenVaccin)
            {
                Filt_tenbs(txtTenVaccin.Text, listVaccin);

                listVaccin.BrowseToICD10(txtTenVaccin, txtMabd, txtMaVaccin, txtMaVaccin.Location.X, txtMaVaccin.Location.Y + txtMaVaccin.Height - 2, txtMaVaccin.Width + txtTenVaccin.Width + 2, txtTenVaccin.Height);

            }	
        }

        private void txtTenVaccin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listVaccin.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listVaccin.Visible) listVaccin.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
        }

        private void txtMaVaccin_Validated(object sender, EventArgs e)
        {
            if (txtMaVaccin.Text != "")
            {
                DataRow r = m.getrowbyid(dtVaccin, "ma='" + txtMaVaccin.Text.Trim() + "'");
                if (r != null)
                {
                    txtTenVaccin.Text = r["ten"].ToString();
                    txtMabd.Text = r["id"].ToString();
                }
                else
                {
                    txtTenVaccin.Text = "";
                    txtMabd.Text = "0";
                }
            }
        }

        private void listVaccin_VisibleChanged(object sender, EventArgs e)
        {
            if (!listVaccin.Visible)
            {
                DataRow r = m.getrowbyid(dtVaccin, "id='" + txtMabd.Text.Trim() + "'");
                if (r != null)
                {
                    txtTenVaccin.Text = r["ten"].ToString();
                    txtMaVaccin.Text = r["ma"].ToString();
                }
                else
                {
                    txtTenVaccin.Text = "";
                    txtMaVaccin.Text = "";
                }
            }
        }

        private void butMoi_Click(object sender, EventArgs e)
        {
            bNew = true;
            emp_detail();
            cmbSoluutru.Enabled = false;
            cmbSoluutru.Text = "";
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            bNew = false;
            if (dt.Rows.Count > 0)
            {
                cmbSoluutru.SelectedIndex = 0;
                cmbSoluutru_SelectedIndexChanged(null, null);
            }
            butHuy.Enabled = false;
            butIn.Enabled = false;
        }

        private void butHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(lan.Change_language_MessageText("Bạn có đồng ý hủy thông tin này không?"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                m.execute_data("delete " + user + ".huyvacxin where id="+d_id);
            }
            load_data();
            if (dt.Rows.Count > 0)
            {
                cmbSoluutru.SelectedIndex = 0;
                cmbSoluutru_SelectedIndexChanged(null, null);
            }
            else
                emp_detail();
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            if (txtDDPTiem.Text == "" || txtMaDDPTiem.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập tên điều dưỡng phòng tiêm thuốc!"), LibMedi.AccessData.Msg);
                txtMaDDPTiem.Focus();
                return;
            }
            if (txtDDTruong.Text == "" || txtMaDDTruong.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập tên điều dưỡng trưởng!"), LibMedi.AccessData.Msg);
                txtMaDDTruong.Focus();
                return;
            }
            if (txtTruongnhathuoc.Text == "" || txtMaTruongnhathuoc.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập tên trưởng bộ phận nhà thuốc!"), LibMedi.AccessData.Msg);
                txtMaTruongnhathuoc.Focus();
                return;
            }
            if (txtMaVaccin.Text == "" || txtTenVaccin.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập tên Vaccin!"), LibMedi.AccessData.Msg);
                txtMaVaccin.Focus();
                return;
            }
            if (txtLosx.Text == "" )
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập số lô!"), LibMedi.AccessData.Msg);
                txtLosx.Focus();
                return;
            }
            if (decimal.Parse(txtSoluong.Text) == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập số lượng!"), LibMedi.AccessData.Msg);
                txtSoluong.Focus();
                return;
            }
            string soluutru = "";
            if (bNew || cmbSoluutru.Text.Trim() == "")
            {
                d_id = decimal.Parse(m.getidyymmddhhmiss_stt_computer.ToString());
                soluutru = m.getSoluutru_huyVacxin(i_chinhanh);
            }
            else
                soluutru = cmbSoluutru.Text;
            if (!m.upd_huyvacxin(d_id, soluutru, txtNgay.Text, txtMaDDTruong.Text.Trim(), txtMaTruongnhathuoc.Text.Trim(), txtMaDDPTiem.Text.Trim(), tungay.Text.Trim(), denngay.Text.Trim(), int.Parse(txtMabd.Text), decimal.Parse(txtSoluong.Text), txtLosx.Text.Trim(), i_userid))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin!"), LibMedi.AccessData.Msg);
                return;
            }
            load_data();
            cmbSoluutru.Enabled = true;
            cmbSoluutru_SelectedIndexChanged(null, null);
            butHuy.Enabled = true ;
            butIn.Enabled = true;
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add("Table");
            DataRow r = m.getrowbyid(dt, "id=" + d_id);
            if (r == null) return;
            ds.Tables[0].Columns.Add("soluutru");
            ds.Tables[0].Columns.Add("ngay");
            ds.Tables[0].Columns.Add("dieuduongtruong");
            ds.Tables[0].Columns.Add("truongbophan");
            ds.Tables[0].Columns.Add("dieuduongphong");
            ds.Tables[0].Columns.Add("tungay");
            ds.Tables[0].Columns.Add("denngay");
            ds.Tables[0].Columns.Add("vaccin");
            ds.Tables[0].Columns.Add("soluong");
            ds.Tables[0].Columns.Add("losx");
            DataRow r1 = ds.Tables[0].NewRow();
            r1["soluutru"] = r["soluutru"];
            r1["ngay"] = r["ngay"];
            r1["dieuduongtruong"]=m.getrowbyid(dtbs,"ma='"+r["madieuduong"].ToString()+"'")["hoten"].ToString();
            r1["truongbophan"]=m.getrowbyid(dtbs,"ma='"+r["truongbophan"].ToString()+"'")["hoten"].ToString();
            r1["dieuduongphong"]=m.getrowbyid(dtbs,"ma='"+r["dieuduongphong"].ToString()+"'")["hoten"].ToString();
            r1["tungay"] = r["tungay"];
            r1["denngay"] = r["denngay"];
            r1["vaccin"] = m.getrowbyid(dtVaccin, "id='" + r["mabd"].ToString() + "'")["ten"].ToString();
            r1["soluong"] = r["soluong"];
            r1["losx"] = r["losx"];
            ds.Tables[0].Rows.Add(r1);
            if (chkXml.Checked)
            {
                if (!System.IO.Directory.Exists("..\\..\\dataxml")) System.IO.Directory.CreateDirectory("..\\..\\dataxml");
                ds.WriteXml("..\\..\\dataxml\\rptBBHuyvolovaccin.xml", XmlWriteMode.WriteSchema);
            }
            dllReportM.frmReport f = new dllReportM.frmReport(m, ds.Tables[0], "rptBBHuyvolovaccin.rpt", "","","","","","","", "", "", "");
            f.ShowDialog();
        }

        private void txtMaDDTruong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtMabd_Validated(object sender, EventArgs e)
        {
            DataRow r = m.getrowbyid(dtVaccin, "id='" + txtMabd.Text.Trim() + "'");
            if (r != null)
            {
                txtTenVaccin.Text = r["ten"].ToString();
                txtMaVaccin.Text = r["ma"].ToString();
            }
            else
            {
                txtTenVaccin.Text = "";
                txtMaVaccin.Text = "";
            }
        }
        
    }
}