using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Medisoft
{
    public partial class frmThongtinBLGD : Form
    {
        LibMedi.AccessData m;
        Language lan = new Language();
        DataTable dt = new DataTable();
        DataTable dtblgd = new DataTable();
        DataTable dttrinhdo = new DataTable();
        DataTable dthonnhan = new DataTable();
        DataTable dtthoigian = new DataTable();
        DataTable dtquanhe = new DataTable();
        DataTable dtloaiBLGD = new DataTable();
        DataTable dtmucdotonhai = new DataTable();
        DataTable dttam = new DataTable();

        string sql = "", s_mabn = "", s_msg = "", s_mmyy = "",s_ngay="";
        Decimal d_mavaovien = 0, d_maql = 0;
        int i_userid = 0;

        public frmThongtinBLGD(LibMedi.AccessData _m,string _mabn,decimal _mavaovien,decimal _maql,string _mmyy,int _userid,string _ngay)
        {
            InitializeComponent();
            m = _m;
            s_mabn = _mabn;
            d_mavaovien = _mavaovien;
            d_maql = _maql;
            s_mmyy = _mmyy;
            i_userid = _userid;
            s_ngay = _ngay;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }

        private void frmThongtinBLGD_Load(object sender, EventArgs e)
        {
            s_msg = LibMedi.AccessData.Msg;
            string[] s_loaibl;

            sql = "select * from " + m.user + ".blgd_loaibaoluc";
            dtloaiBLGD = m.get_data(sql).Tables[0];
            checkedListBox1.DataSource = dtloaiBLGD;
            checkedListBox1.DisplayMember = "ten";
            checkedListBox1.ValueMember = "id";

            sql = "select * from " + m.user + ".blgd_tonhaisk";
            dtmucdotonhai = m.get_data(sql).Tables[0];
            cmbTonhai.DataSource = dtmucdotonhai;
            cmbTonhai.DisplayMember = "ten";
            cmbTonhai.ValueMember = "id";

            sql = "select * from " + m.user + ".blgd_tgchiudung";
            dtthoigian = m.get_data(sql).Tables[0];
            cmbThoigian.DataSource = dtthoigian;
            cmbThoigian.DisplayMember = "ten";
            cmbThoigian.ValueMember = "id";

            sql = "select * from " + m.user + ".blgd_nguoigaybl";
            dtquanhe = m.get_data(sql).Tables[0];
            cmbQuanhe.DataSource = dtquanhe;
            cmbQuanhe.DisplayMember = "ten";
            cmbQuanhe.ValueMember = "id";

            sql = "select * from " + m.user + ".blgd_tthonnhan";
            dthonnhan = m.get_data(sql).Tables[0];
            cmbHonnhan.DataSource = dthonnhan;
            cmbHonnhan.DisplayMember = "ten";
            cmbHonnhan.ValueMember = "id";

            sql = "select * from " + m.user + ".blgd_tdhv";
            dttrinhdo = m.get_data(sql).Tables[0];
            cmbTrinhdo.DataSource = dttrinhdo;
            cmbTrinhdo.DisplayMember = "ten";
            cmbTrinhdo.ValueMember = "id";

            sql = "select a.mabn,a.hoten,c.tuoivao,case when a.phai=0 then 'Nam' else 'Nữ' end phai,c.thon,aa.tentt,bb.tenquan,cc.tenpxa,case when trim(d.didong)='' then d.nha else d.didong end dienthoai, ";
            sql += " e.hoten||'-'||e.diachi||'-'||e.dienthoai lienhe,dd.tennn, f.noidung tiensu ";
            sql += " from " + m.user + ".btdbn a left join " + m.user + ".dienthoai d on a.mabn=d.mabn left join " + m.user + ".theodoitsu f on a.mabn=f.mabn left join " + m.user + s_mmyy + ".tiepdon b on a.mabn=b.mabn left join " + m.user + s_mmyy + ".quanhe e on b.maql=e.maql ";            
            //sql += " " + m.user + s_mmyy + ".lienhe c, " + m.user + ".btdtt aa," + m.user + ".btdquan bb," + m.user + ".btdpxa cc," + m.user + ".btdnn dd ";
            sql += " left join " + m.user + s_mmyy + ".lienhe c on b.maql=c.maql left join " + m.user + ".btdtt aa on a.matt=aa.matt left join " + m.user + ".btdquan bb on a.maqu=bb.maqu left join " + m.user + ".btdpxa cc on a.maphuongxa=cc.maphuongxa left join " + m.user + ".btdnn dd on a.mann=dd.mann ";
            sql += " where a.mabn='"+s_mabn+"'";// and a.mabn=b.mabn and b.maql=c.maql and c.matt=aa.matt and c.maqu=bb.maqu and c.maphuongxa=cc.maphuongxa and dd.mann=a.mann";
            

            dt = m.get_data(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                txtMabn.Text = dt.Rows[0]["mabn"].ToString();
                txtHoten.Text = dt.Rows[0]["hoten"].ToString();
                txtTuoi.Text = dt.Rows[0]["tuoivao"].ToString();
                txtGioitinh.Text = dt.Rows[0]["phai"].ToString();
                txtDiachi.Text = dt.Rows[0]["thon"].ToString().Trim() + ", " + dt.Rows[0]["tenpxa"].ToString() + ", " + dt.Rows[0]["tenquan"].ToString() + ", " + dt.Rows[0]["tentt"].ToString();
                txtDienthoai.Text = dt.Rows[0]["dienthoai"].ToString();
                txtNguoilienhe.Text = dt.Rows[0]["lienhe"].ToString();
                txtNghenghiep.Text = dt.Rows[0]["tennn"].ToString();
                txtLoikhai.Text = dt.Rows[0]["tiensu"].ToString();
            }
            txtNgay.Text = s_ngay;

            sql = "select * from " + m.user + ".blgd_vao a, " + m.user + ".blgd_ra b where a.mavaovien=b.mavaovien and a.mavaovien="+d_mavaovien;
            dtblgd = m.get_data(sql).Tables[0];
            if (dtblgd.Rows.Count != 0)
            {
                cmbTrinhdo.SelectedValue = int.Parse(dtblgd.Rows[0]["tdhv"].ToString());
                cmbHonnhan.SelectedValue=int.Parse(dtblgd.Rows[0]["tthonnhan"].ToString());
                txtChungsong.Text = dtblgd.Rows[0]["chungsong"].ToString();
                txtTrai.Text = dtblgd.Rows[0]["contrai"].ToString();
                txtGai.Text = dtblgd.Rows[0]["congai"].ToString();
                txtNguoigaybl.Text = dtblgd.Rows[0]["tennguoigaybl"].ToString();
                cmbQuanhe.SelectedValue = int.Parse(dtblgd.Rows[0]["quanhe"].ToString());
                cmbThoigian.SelectedValue=int.Parse(dtblgd.Rows[0]["tgchiudung"].ToString());
                txtThoigianchiudung.Text = dtblgd.Rows[0]["tgchiudungkhac"].ToString();
                txtGhichu.Text = dtblgd.Rows[0]["ghichu"].ToString();
                txtLoikhai.Text = dtblgd.Rows[0]["tiensu"].ToString();
                txtKhamthucthe.Text = dtblgd.Rows[0]["khamtt"].ToString();
                cmbTonhai.SelectedValue=int.Parse(dtblgd.Rows[0]["tonhaisk"].ToString());
                txtXuly.Text = dtblgd.Rows[0]["xuly"].ToString();
                chkKedon.Checked = dtblgd.Rows[0]["kedon"].ToString()=="1"?true:false;
                txtDanhgiaantoan.Text = dtblgd.Rows[0]["danhgiaantoan"].ToString();
                txtTuvan.Text = dtblgd.Rows[0]["tuvan"].ToString();
                txtKehoach.Text = dtblgd.Rows[0]["kehoachantoan"].ToString();
                txtTinhtrangsk.Text = dtblgd.Rows[0]["tinhtrangsk"].ToString();
                s_loaibl = dtblgd.Rows[0]["loaibaoluc"].ToString().Trim(',').Split(',');
                for (int i = 0; i < s_loaibl.Length; i++)
                {
                    for (int j = 0; j < dtloaiBLGD.Rows.Count; j++)
                    {
                        if (dtloaiBLGD.Rows[j]["id"].ToString() == s_loaibl[i])
                            checkedListBox1.SetItemChecked(j, true);
                    }
                }
            }
            sql = "select mavaovien from xxx.bhytkb where mavaovien="+d_mavaovien;
            if (m.get_data_mmyy(sql, s_ngay, m.Ngaygio_hienhanh, 0).Tables[0].Rows.Count>0)
            {
                chkKedon.Checked = true;
            }
            chkNhapvien.Checked = false;
            sql = "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvao,a.ngayrv ngayra,c.ten,e.tenbv from " + m.user + s_mmyy + ".benhancc a left join " + m.user + ".ketqua c on a.ketqua=c.ma left join " + m.user + ".chuyenvien d on a.maql=d.maql ";
            sql += " left join " + m.user + ".tenvien e on d.mabv=e.mabv where a.maql="+d_maql;
            dttam = m.get_data(sql).Tables[0];
            if (dttam.Rows.Count > 0)
            {
                chkNhapvien.Checked = false;
                txtTungay.Text = dttam.Rows[0]["ngayvao"].ToString();
                txtDenngay.Text = dttam.Rows[0]["ngayra"].ToString().Trim() == "" ? m.Ngaygio_hienhanh : dttam.Rows[0]["ngayra"].ToString();
                txtTinhtrangsk.Text = dttam.Rows[0]["ten"].ToString();
                txtChuyenvien.Text = dttam.Rows[0]["tenbv"].ToString();
            }
            sql = "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvao,to_char(a.ngay,'dd/mm/yyyy') ngayra,e.tenbv from " + m.user + s_mmyy + ".benhanpk a left join " + m.user + ".chuyenvien d on a.maql=d.maql ";
            sql += " left join " + m.user + ".tenvien e on d.mabv=e.mabv where a.maql="+d_maql;
            dttam = m.get_data(sql).Tables[0];
            if (dttam.Rows.Count > 0)
            {
                chkNhapvien.Checked = false;
                txtTungay.Text = dttam.Rows[0]["ngayvao"].ToString();
                txtDenngay.Text = dttam.Rows[0]["ngayra"].ToString().Trim() == "" ? m.Ngaygio_hienhanh : dttam.Rows[0]["ngayra"].ToString();
                txtChuyenvien.Text = dttam.Rows[0]["tenbv"].ToString();
            }
            sql = "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvao,to_char(b.ngay,'dd/mm/yyyy hh24:mi') ngayra,c.ten,e.tenbv from " + m.user + ".benhandt a left join  " + m.user + ".xuatvien b on a.maql=b.maql left join  " + m.user + ".ketqua c on b.ketqua=c.ma left join " + m.user + ".chuyenvien d on a.maql=d.maql left join " + m.user + ".tenvien e on d.mabv=e.mabv  where a.mavaovien=" + d_mavaovien ;
            dttam = m.get_data(sql).Tables[0];
            if (dttam.Rows.Count > 0)
            {
                chkNhapvien.Checked = true;
                txtTungay.Text = dttam.Rows[0]["ngayvao"].ToString();
                txtDenngay.Text = dttam.Rows[0]["ngayra"].ToString().Trim() == "" ? m.Ngaygio_hienhanh : dttam.Rows[0]["ngayra"].ToString();
                txtTinhtrangsk.Text = dttam.Rows[0]["ten"].ToString();
                txtChuyenvien.Text = dttam.Rows[0]["tenbv"].ToString();
                return;
            }
            
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtChungsong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void butHuy_Click(object sender, EventArgs e)
        {
            sql = "select mavaovien from " + m.user + ".blgd_vao where mavaovien=" + d_mavaovien;
            if (m.get_data(sql).Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Thông tin nạn nhân bạo lực gia đình chưa lưu, không thể xóa!"), s_msg);
                return;
            }
            if (MessageBox.Show(lan.Change_language_MessageText("Bạn muốn xóa Thông tin nạn nhân bạo lực gia đình này?"), s_msg, MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                if (!m.execute_data("delete from " + m.user + ".blgd_ra where mabn='" + s_mabn + "' and mavaovien=" + d_mavaovien))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Xóa không thành công!"), s_msg);
                    return;
                }
                else
                    if (!m.execute_data("delete from " + m.user + ".blgd_vao where mabn='" + s_mabn + "' and mavaovien=" + d_mavaovien))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Xóa không thành công!"), s_msg);
                        return;
                    }
                MessageBox.Show(lan.Change_language_MessageText("Xóa thành công!"), s_msg);
            }
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            string s_loaibl = "";
            for (int i = 0; i < dtloaiBLGD.Rows.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i) == true)
                    s_loaibl += dtloaiBLGD.Rows[i]["id"].ToString()+",";
            }
            s_loaibl = s_loaibl.Trim(',');
            if (!m.upd_blgd_vao(s_mabn, d_mavaovien, d_maql, txtNgay.Text, int.Parse(cmbTrinhdo.SelectedValue.ToString()), int.Parse(cmbHonnhan.SelectedValue.ToString()), int.Parse(txtChungsong.Text), int.Parse(txtTrai.Text), int.Parse(txtGai.Text), txtNguoigaybl.Text.Trim(), int.Parse(cmbQuanhe.SelectedValue.ToString()), int.Parse(cmbThoigian.SelectedValue.ToString()), txtThoigianchiudung.Text.Trim(),s_loaibl, txtGhichu.Text.Trim(), txtLoikhai.Text.Trim(), txtKhamthucthe.Text.Trim(), int.Parse(cmbTonhai.SelectedValue.ToString()), i_userid))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được phiếu sàng lọc nạn nhân bạo lực gia đình!"), s_msg);
                return;
            }
            else //chua lay duoc field xutri (nhapvien hay ko)
                if (!m.upd_blgd_ra(s_mabn, d_mavaovien, d_maql,txtXuly.Text.Trim(),chkKedon.Checked?1:0,txtDanhgiaantoan.Text.Trim(),txtTuvan.Text.Trim(),txtKehoach.Text.Trim(),0,txtTinhtrangsk.Text.Trim(), i_userid))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được phiếu sàng lọc nạn nhân bạo lực gia đình!"), s_msg);
                    return;
                }
            MessageBox.Show(lan.Change_language_MessageText("Cập nhật thành công!"), s_msg);
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            decimal stt=0;
            try
            {
            stt=decimal.Parse(m.get_data("select sott from "+m.user+".blgd_sangloc where mavaovien="+d_mavaovien).Tables[0].Rows[0][0].ToString());
            }
            catch
            {
            stt=m.sttSangLocBLGD;
            }
            DataSet dsthongtin = new DataSet();
            sql = "select a.*,b.*,d.hoten as bacsi,e.ten as trinhdo from " + m.user + ".blgd_vao a left join " + m.user + m.mmyy(s_ngay) + ".benhanpk c on a.maql=c.maql left join " + m.user + ".dmbs d on c.mabs=d.ma inner join " + m.user + ".blgd_tdhv e on a.tdhv=e.id," + m.user + ".blgd_ra b where a.mavaovien=b.mavaovien and a.mavaovien=" + d_mavaovien;
            dsthongtin = m.get_data(sql);
            if (dsthongtin.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Phiếu sàng lọc nạn nhân bạo lực gia đình chưa lưu!"), s_msg);
                return;
            }
            dsthongtin.WriteXml("..\\..\\dataxml\\rptThongtinBLGD.xml");
            dllReportM.frmReport f = new dllReportM.frmReport(m, dsthongtin.Tables[0], "rptThongtinBLGD.rpt",stt.ToString(),s_mabn,txtHoten.Text,txtTuoi.Text,txtGioitinh.Text,txtDiachi.Text,txtDienthoai.Text,txtNguoilienhe.Text,txtNghenghiep.Text,"",10 );
            f.ShowDialog();
        }

        private void txtMabn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void butInxacnhan_Click(object sender, EventArgs e)
        {
            DataSet dsGiayxn = new DataSet();
            string tiensu = "";
            string user = m.user;   
            string mmyy = m.mmyy(s_ngay);   
            sql = "select a.mabn,a.hoten,case when a.ngaysinh is null then a.namsinh else to_char(a.ngaysinh,'dd/mm/yyyy') end ngaysinh,case when a.phai=0 then '" + lan.Change_language_MessageText("Nam") + "' else '" + lan.Change_language_MessageText("Nữ") + "' end phai, a.cmnd,a.sonha,a.thon, b.tenpxa, ";
            sql += " c.tenquan, d.tentt,e.tennn || (case when trim(a.cholam)='' then '' else ' - '||a.cholam end) nghenghiep ,to_char(f.ngay,'dd/mm/yyyy hh24:mi') ngayvaopk, ";
            sql += " to_char(f.ngay,'dd/mm/yyyy hh24:mi') ngayrapk, to_char(fff.ngay,'dd/mm/yyyy hh24:mi') ngayvaocc,case when fff.ngayrv is null then to_char(Now(),'dd/mm/yyyy hh24:mi') else to_char(fff.ngayrv,'dd/mm/yyyy hh24:mi') end ngayracc, ";
            sql += " to_char(ff.ngay,'dd/mm/yyyy hh24:mi') ngayvaonoitru,to_char(ffa.ngay,'dd/mm/yyyy hh24:mi') ngayranoitru, ";
            sql += " 0 noitru,'' tiensu,f.chandoan chandoanpk, ";
            sql += " ffa.chandoan chandoannoitru,fff.chandoan chandoancc,g.kedon,g.tinhtrangsk,i.tenbv chuyenvien ";
            sql += " from " + user + ".btdbn a left join " + user + ".btdpxa b on a.maphuongxa=b.maphuongxa left join " + user + ".btdquan c on a.maqu=c.maqu left join " + user + ".btdtt d on a.matt=d.matt  ";
            sql += " left join " + user + ".btdnn e on a.mann=e.mann  ";
            sql += " left join " + user + mmyy + ".benhanpk f on a.mabn=f.mabn and f.maql=" + d_maql;
            sql += " left join " + user + ".benhandt ff on a.mabn=ff.mabn and ff.mavaovien=" + d_mavaovien;
            sql += " left join " + user + ".xuatvien ffa on ff.maql=ffa.maql ";
            sql += " left join " + user + mmyy + ".benhancc fff on a.mabn=fff.mabn and fff.maql=" + d_maql;
            sql += " left join " + user + ".blgd_ra g on a.mabn=g.mabn and g.mavaovien=" + d_mavaovien;
            sql += " left join " + user + ".chuyenvien h on h.maql=" + d_maql;
            sql += " left join " + user + ".tenvien i on h.mabv=i.mabv  ";
            sql += " where a.mabn='" + s_mabn + "' ";
            dsGiayxn = m.get_data(sql);
            if (dsGiayxn.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), s_msg);
                return;
            }
            sql = "select noidung from " + user + ".theodoitsu where mabn='" + s_mabn + "'";
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                tiensu += r["noidung"].ToString() + "; ";
            }
            dsGiayxn.Tables[0].Rows[0]["tiensu"] = tiensu;
            dsGiayxn.WriteXml("..\\xml\\rptGiayxacnhanBLGD.xml", XmlWriteMode.WriteSchema);
            dllReportM.frmReport f = new dllReportM.frmReport(m, dsGiayxn.Tables[0], "rptGiayxacnhanBLGD.rpt", "", "", "", "", "", "", "", "", "", "");
            f.ShowDialog();
        }
    }
}