using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace tiemchung
{
    public partial class frmPhanungsautiemchung : Form
    {
        Language lan = new Language();
        string s_mabn = "", s_hoten = "", s_tuoi = "",s_phai="",s_diachi="",ngaysrv="",sql="";
        bool bIn = false;
        LibMedi.AccessData m;
        decimal d_id = 0;
        int i_userid = 0, i_ngaylv_ngayht=0;
        DataTable dtThongtin = new DataTable();
        DataTable dtVaccin = new DataTable();
        DataTable dtTinhtrang = new DataTable();
        DataTable dtTiensu = new DataTable();

        public frmPhanungsautiemchung(LibMedi.AccessData _m, string _mabn, string _hoten, string _tuoi, string _phai,string _diachi, decimal _id,int _userid)
        {
            InitializeComponent();//
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = _m;
            s_mabn = _mabn; s_tuoi = _tuoi; s_hoten = _hoten; s_phai = _phai; s_diachi = _diachi;
            d_id = _id;
            i_userid = _userid;
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPhanungsautiemchung_Load(object sender, EventArgs e)
        {
            i_ngaylv_ngayht = m.Ngaylv_Ngayht;
            ngaysrv=m.Ngaygio_hienhanh;
            txtMabn.Text = s_mabn;
            txtHoten.Text = s_hoten;
            txtDiachi.Text = s_diachi;
            txtTuoi.Text = s_tuoi;
            txtGioitinh.Text = s_phai;

            sql = "select * from " + m.user + ".dmtinhtrangsautc";
            dtTinhtrang = m.get_data(sql).Tables[0];
            if (dtTinhtrang.Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chưa khai báo danh mục tình trạng phản ứng sau tiêm chủng !"), LibMedi.AccessData.Msg);
                this.Close();
            }
            cmbTinhtrang.DataSource = dtTinhtrang;
            cmbTinhtrang.DisplayMember = "ten";
            cmbTinhtrang.ValueMember = "id";

            sql = "select b.ten thuoc,a.muitiem,b.duongdung,a.vitritiem,c.hoten,to_char(a.ngaytiem,'dd/mm/yyyy hh24:mi') ngaytiem,a.phanung,a.mabd from " + m.user + ".phieutiemchung a left join " + m.user + ".dmbs c on a.mabs=c.ma, " + m.user + ".d_dmbd b where a.mabd=b.id and a.id="+d_id;
            dtVaccin = m.get_data(sql).Tables[0];
            if (dtVaccin.Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Đợt này chưa tiêm chủng!"), LibMedi.AccessData.Msg);
                this.Close();
            }
            dataGridView1.DataSource = dtVaccin;

            sql = "select * from " + m.user + ".phanung_sautc where id="+d_id+" and mabn='"+s_mabn.Trim()+"'";
            dtThongtin = m.get_data(sql).Tables[0];

            if (dtThongtin.Rows.Count != 0)
            {
                load_data();
            }
            else
            {
                clear_detail();
            }
            loadTiensu();

        }

        private void loadTiensu()
        {
            sql = "select * from "+m.user+".theodoitsu where mabn='"+s_mabn+"'";
            dtTiensu = m.get_data(sql).Tables[0];
            string s_tsu = "";
            for (int i = 0; i < dtTiensu.Rows.Count; i++)
            {
                s_tsu += dtTiensu.Rows[i]["maicd"].ToString() + ": " + dtTiensu.Rows[i]["noidung"].ToString()+"; ";
            }
            txtTiensu.Text = s_tsu;
        }

        private void load_data()
        {
            txtngay.Text = dtThongtin.Rows[0]["ngay"].ToString().Substring(3,3)+dtThongtin.Rows[0]["ngay"].ToString().Substring(0,2)+ dtThongtin.Rows[0]["ngay"].ToString().Substring(5);
            txtMota.Text = dtThongtin.Rows[0]["mota"].ToString();
            txtTiensu.Text = dtThongtin.Rows[0]["tiensu"].ToString();
            cmbTinhtrang.SelectedValue = int.Parse(dtThongtin.Rows[0]["id_tinhtrang"].ToString());
            txtGhichu.Text = dtThongtin.Rows[0]["ghichu"].ToString();
            txtTenbome.Text = dtThongtin.Rows[0]["tenbome"].ToString();
        }

        private void clear_detail()
        {
            try
            {
                txtngay.Text = ngaysrv;
                txtMota.Text = "";
                txtTiensu.Text = "";
                cmbTinhtrang.SelectedValue = "";
                txtGhichu.Text = "";
                txtTenbome.Text = "";
            }
            catch { }
        }
        bool dachon = false;
        private void butLuu_Click(object sender, EventArgs e)
        {
            dachon= false;
            foreach (DataRow r in dtVaccin.Rows)
            {
                if (r["phanung"].ToString() == "1") dachon = true;
            }
            if (!dachon)
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu chọn Vacxin gây phản ứng!"), LibMedi.AccessData.Msg);
                return;
            }
            if (!m.bNgay(txtngay.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày tiêm không hợp lệ !"), LibMedi.AccessData.Msg);
                txtngay.Focus();
                return;
            }
            if (!m.upd_phanung_sautc(s_mabn, d_id, 1, txtTenbome.Text.Trim(), txtMota.Text.Trim(), txtTiensu.Text.Trim(), int.Parse(cmbTinhtrang.SelectedValue.ToString()), txtGhichu.Text.Trim(), txtngay.Text.Trim(), i_userid))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin  !"), LibMedi.AccessData.Msg);
                return;
            }
            foreach (DataRow r in dtVaccin.Rows)
            {
                m.execute_data("update "+m.user+".phieutiemchung set phanung="+(r["phanung"].ToString()=="1"?"1":"0")+" where mabd="+r["mabd"].ToString()+" and id="+d_id );
            }
            //if(!bIn)
            //    MessageBox.Show(lan.Change_language_MessageText("Cập nhật thành công !"), LibMedi.AccessData.Msg);
        }

        private void txtTenbome_Validated(object sender, EventArgs e)
        {
            txtTenbome.Text = m.Caps(txtTenbome.Text);
        }

        private void txtTenbome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void cmbTinhtrang_SelectedIndexChanged(object sender, EventArgs e)
        {
                //SendKeys.Send("{Tab}");
        }

        private void butHuy_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(lan.Change_language_MessageText("Bạn đồng ý xóa thông tin phản ứng thuốc sau tiêm chủng này?"), LibMedi.AccessData.Msg,MessageBoxButtons.YesNoCancel)==DialogResult.Yes)
            {
                if (!m.execute_data("delete from " + m.user + ".phanung_sautc where stt=1 and id=" + d_id))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Xóa không thành công!"), LibMedi.AccessData.Msg);
                    return;
                }
                //MessageBox.Show(lan.Change_language_MessageText("Xóa thành công!"), LibMedi.AccessData.Msg);
                clear_detail();
            }
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            sql = "select * from " + m.user + ".phanung_sautc where id=" + d_id + " and mabn='" + s_mabn.Trim() + "'";
            dtThongtin = m.get_data(sql).Tables[0];

            if (dtThongtin.Rows.Count != 0)
            {
                load_data();
            }
            else
            {
                clear_detail();
            }
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            bIn = true;
            butLuu_Click(null, null);
            if (!dachon) return;
            bIn = false;
            DataTable dt = new DataTable();

            string[] s_mmyy = m.get_s_mmyy(m.StringToDate(dtVaccin.Rows[0]["ngaytiem"].ToString()).AddDays(-i_ngaylv_ngayht), m.StringToDate(dtVaccin.Rows[0]["ngaytiem"].ToString()).AddDays(i_ngaylv_ngayht)).Split(',');
            for (int i = 0; i < s_mmyy.Length; i++)
            {
                try
                {
                    sql = "select j.ten loai,b.ten thuoc,a.muitiem,b.duongdung,a.vitritiem,c.hoten,to_char(a.ngaytiem,'dd/mm/yyyy hh24:mi') ngaytiem , d.sttt,g.ten hangsx,h.ten nhacungcap, ";
                    sql += " case when to_number(f.handung)=0 then '' else f.handung end handung,f.losx,k.mabn, k.tenbome,k.mota,k.tiensu,k.ghichu,to_char(k.ngay,'dd/mm/yyyy hh:mi') ngaypu,m.ten tinhtrang,n.hoten nguoinhap,a.phanung,a.mabd ";
                    sql += " from " + m.user + ".phieutiemchung a left join " + m.user + ".dmbs c on a.mabs=c.ma, " + m.user + ".d_dmbd b, " + m.user + s_mmyy[i] + ".v_chidinh e," + m.user + s_mmyy[i] + ".d_xuatsdct d, ";
                    sql += " " + m.user + s_mmyy[i] + ".d_theodoi f," + m.user + ".d_dmhang g, " + m.user + ".d_dmnx h ," + m.user + ".d_dmloai j," + m.user + ".phanung_sautc k," + m.user + ".dmtinhtrangsautc m," + m.user + ".dlogin n ";
                    sql += " where a.mabd=b.id and e.idduoc=d.id and a.mabd=d.mabd and a.id="+d_id.ToString()+" and e.id=a.id and f.id=d.sttt and b.mahang=g.id and f.nhomcc=h.id and j.id=b.maloai and k.id=a.id and m.id=k.id_tinhtrang and k.userid=n.id";
                    dt = m.get_data(sql).Tables[0];
                    if (dt.Rows.Count != 0)
                    {
                        break;
                    }
                }
                catch { }
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Không có số liệu!"), LibMedi.AccessData.Msg);
                return;
            }
            if(chkXml.Checked)
                dt.WriteXml("..\\xml\\rptThongtinpu_sautc.xml");
            dllReportM.frmReport f = new dllReportM.frmReport(m, dt, "rptThongtinpu_sautc.rpt", txtMabn.Text, txtHoten.Text, txtTuoi.Text, txtGioitinh.Text,txtDiachi.Text,"","", "", "", "");
            f.ShowDialog();
            if (dt.Select("phanung=1").Length > 0)
            {
                dllReportM.frmReport f1 = new dllReportM.frmReport(m, dt, "rptTheodoiPhanung_sautc.rpt", txtMabn.Text, txtHoten.Text, txtTuoi.Text, txtGioitinh.Text, txtDiachi.Text, "", "", "", "", "");
                f1.ShowDialog();
            }
        }

        private void butSuaTS_Click(object sender, EventArgs e)
        {
            //Medisoft.frmTheodoitsu f = new Medisoft.frmTheodoitsu(m, s_mabn, s_hoten, "", s_phai);
            //f.ShowInTaskbar = false;
            //f.ShowDialog();
            //loadTiensu();
        }
    }



}