using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Medisoft
{
    public partial class frmTiepdon_new : frmDkkb_chung
    {
        LibMedi.AccessData m = null;
        Language lan = new Language();
        string sql = "", s_mabn, s_lydokham = "+", s_lydodungtuyen = "+", s_mabhyt = "", s_msg = "", s_sotheuudai = "",ngayhienhanh="",s_chedo="";
        bool edit = false,bMienphuthu=false;
        int i_userid = 0,i_computer=0,i_chinhanh=0;
        decimal d_mavaovien_tam = 0;
        DateTime ngayhethong=new DateTime();
        DataSet ds;
        DataTable dt = new DataTable();
        DataTable dtlydokham = new DataTable();
        DataTable dtlydodungtuyen = new DataTable();
        DataTable dtduyetmien = new DataTable();
        DataTable dtcaclankham = new DataTable();
        DataTable dttyle = new DataTable();
        DataTable dtthe = new DataTable();
        DataTable dtphongcls = new DataTable();
        DataTable dtloaitg = new DataTable();
        DataTable dtngayle = new DataTable();
        DataTable dtngaynghi = new DataTable();
        DataTable dttyle_tam = new DataTable();
        private DataSet ds_bnmien = new DataSet();
        private DataSet ds_chidinhbn = new DataSet();
        private string s_ngay = "";
        

        public frmTiepdon_new(LibMedi.AccessData _acc, string _makp, string _hoten, int _userid, int _sohieu, int _loai, string _madoituong, int _khudieutri,int _chinhanh)
        {
            InitializeComponent();
            base.acc = _acc;
            base.KhuDieuTri = _khudieutri;
            base.MaKhoaPhong = _makp;
            base.HoTenUser = _hoten;
            base.UserID = _userid;
            base.SoHieu = _sohieu;
            base.Loai = _loai;
            base.MaDoiTuong = _madoituong;
            base.init();
            i_userid = _userid;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            i_chinhanh = _chinhanh;
            base.chinhanhid = i_chinhanh;
            m = _acc;
        }

        private void frmTiepdon_new_Load(object sender, EventArgs e)
        {
            ngayhienhanh = m.ngayhienhanh_server;
            base.load_form();
            s_msg = LibMedi.AccessData.Msg;
            
            ngayhethong = m.StringToDate(ngayhienhanh);
            cmbUudai.Items.AddRange(new object[] {
            "",
            lan.Change_language_MessageText("Miễn giảm"),
            lan.Change_language_MessageText("Khuyến mãi"),
            lan.Change_language_MessageText("Ưu đãi"),
            lan.Change_language_MessageText("Khuyến mãi theo thẻ BHYT")});

            sql = "select 0 stt,'' ngay,'' phongkham,'' chinhanh,'' bacsi,'' lydokham,'' ngayhen from dual";
            dt = m.get_data(sql).Tables[0];
            lydo.Visible = false;
            llydo.Visible = false;
            AddGridTableStyle();
            sql = "select * from " + m.user + ".dmlydokham";
            dtlydokham=m.get_data(sql).Tables[0];
            if (dtlydokham.Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chưa nhập danh mục lý do khám !"), s_msg);
                this.Close();
                return;
            }
            cklLydokham.DataSource = dtlydokham;
            cklLydokham.DisplayMember = "ten";
            cklLydokham.ValueMember = "id";

            sql = "select * from " + m.user + ".dmlydodungtuyen";
            dtlydodungtuyen = m.get_data(sql).Tables[0];
            if (dtlydodungtuyen.Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chưa nhập danh mục lý do đúng tuyến!"), s_msg);
                this.Close();
                return;
            }
            cklLydodungtuyen.DataSource = dtlydodungtuyen;
            cklLydodungtuyen.DisplayMember = "ten";
            cklLydodungtuyen.ValueMember = "id";

            sql = "select * from " + m.user + ".dmloaibhyt" ;
            dtthe = m.get_data(sql).Tables[0];

            sql = "select * from " + m.user + ".dmloaitg";
            dtloaitg = m.get_data(sql).Tables[0];
            cmbLoaitg.DataSource = dtloaitg;
            cmbLoaitg.DisplayMember = "ten";
            cmbLoaitg.ValueMember = "id";

            sql = "select * from " + m.user + ".ngaynghi";
            dtngaynghi = m.get_data(sql).Tables[0];

            sql = "select * from " + m.user + ".letet";
            dtngayle = m.get_data(sql).Tables[0];

            int giohanhchanh = phanloaiThoigian();
            cmbLoaitg.SelectedValue = giohanhchanh;

            //G87
            bMienphuthu = m.bMienphuthuKham_BnDiungthuoc;
            //chkViewClick();
            //chkView_CheckedChanged_1(null, null);
            loadphongcls();
            AddGridTableStyle1();
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            s_ngay = ngayvv.Text.Substring(0, 10);
            if (!base.bKiemtra) return;
            int giohanhchanh = phanloaiThoigian();
            cmbLoaitg.SelectedValue = giohanhchanh;
            i_computer = m.get_dmcomputer();
            if (!bNhapdaydu)//Dung trong form tiepdon moi cua hepa
            {
                return;
            }
            if (l_maql_moi != 0)
            {
                if (!m.upd_lydokham(l_maql_moi, ngayvv.Text, txtLydokham.Text.Trim(), s_lydokham, s_lydodungtuyen))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin lý do khám !"), s_msg);
                    return;
                }
                if(madstt.Text.Trim()!="")
                    m.upd_noigioithieu(ngayvv.Text, l_maql_moi, madstt.Text, "", "");
                else m.execute_data("delete from " + m.user + m.mmyy(ngayvv.Text) + ".noigioithieu where maql=" + l_maql_moi);
            }
            if (l_mavaovien_moi != 0 && edit)
            {
                if (cmbUudai.SelectedIndex != 0 && cmbDuyetmien.SelectedValue!=null)
                {
                    
                    for (int i = 0; i < dttyle.Rows.Count; i++)
                    {
                        switch (cmbUudai.SelectedIndex)
                        {
                            case 0:
                                
                                m.execute_data("delete from " + m.user + ".tylemien_km where mavaovien=" + l_mavaovien_moi + " and mabn='" + s_mabn + "'");
                                m.execute_data("delete from " + m.user + ".tylemien_ud where mavaovien=" + l_mavaovien_moi + " and mabn='" + s_mabn + "'");
                                m.execute_data("delete from " + m.user + ".tylemien_mg where mavaovien=" + l_mavaovien_moi + " and mabn='" + s_mabn + "'");
                                break;
                            case 1://mien giam
                                
                                m.execute_data("delete from " + m.user + ".tylemien_km where mavaovien=" + l_mavaovien_moi + " and mabn='" + s_mabn + "'");
                                m.execute_data("delete from " + m.user + ".tylemien_ud where mavaovien=" + l_mavaovien_moi + " and mabn='" + s_mabn + "'");
                                if (!m.upd_tylemien_mg(s_mabn, decimal.Parse(l_mavaovien_moi.ToString()), int.Parse(dttyle.Rows[i]["id"].ToString()), int.Parse(dttyle.Rows[i]["tyle"].ToString()), int.Parse(cmbDuyetmien.SelectedValue.ToString()), i_userid, i_computer))
                                {
                                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin ưu đãi !"), s_msg);
                                    return;
                                }
                                break;
                            case 2://khuyen mai
                               
                                m.execute_data("delete from " + m.user + ".tylemien_ud where mavaovien=" + l_mavaovien_moi + " and mabn='" + s_mabn + "'");
                                m.execute_data("delete from " + m.user + ".tylemien_mg where mavaovien=" + l_mavaovien_moi + " and mabn='" + s_mabn + "'");
                                if (!m.upd_tylemien_km(s_mabn, decimal.Parse(l_mavaovien_moi.ToString()), 2, int.Parse(dttyle.Rows[i]["id"].ToString()), int.Parse(dttyle.Rows[i]["tyle"].ToString()), decimal.Parse(cmbDuyetmien.SelectedValue.ToString()), i_userid, i_computer,0))
                                {
                                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin ưu đãi !"), s_msg);
                                    return;
                                }
                                break;
                            case 3://uu dai
                                
                                m.execute_data("delete from " + m.user + ".tylemien_km where mavaovien=" + l_mavaovien_moi + " and mabn='" + s_mabn + "'");
                                m.execute_data("delete from " + m.user + ".tylemien_mg where mavaovien=" + l_mavaovien_moi + " and mabn='" + s_mabn + "'");
                                if (!m.upd_tylemien_ud(s_mabn, decimal.Parse(l_mavaovien_moi.ToString()), int.Parse(dttyle.Rows[i]["id"].ToString()), int.Parse(dttyle.Rows[i]["tyle"].ToString()), decimal.Parse(cmbDuyetmien.SelectedValue.ToString()), i_userid, i_computer))
                                {
                                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin ưu đãi !"), s_msg);
                                    return;
                                }
                                break;
                            case 4://khuyen mai theo loai the bhyt
                                
                                m.execute_data("delete from " + m.user + ".tylemien_ud where mavaovien=" + l_mavaovien_moi + " and mabn='" + s_mabn + "'");
                                m.execute_data("delete from " + m.user + ".tylemien_mg where mavaovien=" + l_mavaovien_moi + " and mabn='" + s_mabn + "'");
                                if (!m.upd_tylemien_km(s_mabn, decimal.Parse(l_mavaovien_moi.ToString()), 4, int.Parse(dttyle.Rows[i]["id"].ToString()), int.Parse(dttyle.Rows[i]["tyle"].ToString()), decimal.Parse(cmbDuyetmien.SelectedValue.ToString()), i_userid, i_computer, int.Parse(dttyle.Rows[i]["tldongchitra"].ToString())))
                                {
                                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin ưu đãi !"), s_msg);
                                    return;
                                }
                                break;
                        }
                        
                    }
                }
            }
            if (m.get_data("select mavaovien from " + m.user + ".bndk_tg where mavaovien=" + l_mavaovien_moi).Tables[0].Rows.Count == 0)
            {
                if (!m.upd_bndk_tg(s_mabn, l_mavaovien_moi, int.Parse(cmbLoaitg.SelectedValue.ToString())))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin giờ hành chính !"), s_msg);
                    return;
                }
            }
            edit = false;
            ///Dong them
            ds_chidinhbn = m.get_data(" select id,mabn,madoituong,mavp,soluong,dongia,done,idchidinh,hide from " + m.user + m.mmyy(s_ngay) + ".v_chidinh where mabn='" + s_mabn + "' and mavaovien=" + l_mavaovien_moi + " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "'");
            if (ds_chidinhbn.Tables[0].Rows.Count > 0)
            {
                //decimal d_id = 0;
                int i_madt = 0;
                int i_mavp = 0;
                //int i_sl = 0;
                //decimal d_dongia = 0;
                //int i_done = 0;
                decimal d_idchidinh = 0;
                foreach (DataRow dr in ds_chidinhbn.Tables[0].Rows)
                {
                    i_mavp = int.Parse(dr["mavp"].ToString());
                    d_idchidinh = decimal.Parse(dr["idchidinh"].ToString());
                    i_madt = int.Parse(dr["madoituong"].ToString());
                    f_bnmien(i_mavp);
                    if (ds_bnmien.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow r1 in ds_bnmien.Tables[0].Rows)
                        {
                            int i_tylegiam = int.Parse(r1["tylemien"].ToString());
                            decimal d_thanhtien = 0;
                            if (i_tylegiam > 0)
                            {
                                foreach (DataRow r2 in m.get_data(" select id,done,soluong,idchidinh,dongia from " + m.user + m.mmyy(s_ngay) + ".v_chidinh where mavaovien=" + l_mavaovien_moi + " and mabn='" + s_mabn + "' and abs(idchidinh)=" + d_idchidinh + " and madoituong<>1 ").Tables[0].Rows)//and done=1 and tylegiam=0
                                {
                                    d_thanhtien = decimal.Parse(r2["soluong"].ToString()) * decimal.Parse(r2["dongia"].ToString());
                                    m.execute_data(" update " + m.user + m.mmyy(s_ngay) + ".v_chidinh set tylegiam=" + i_tylegiam + ",stgiam=(" + i_tylegiam + "*" + d_thanhtien + ")/100 where id=" + decimal.Parse(r2["id"].ToString()));
                                }
                            }
                        }
                    }
                }
            }
            ///End dong
            ///

            for (int i = 0; i < dtlydokham.Rows.Count; i++)
            {
                if (cklLydokham.GetSelected(i) && dtlydokham.Rows[i]["danhmuc"].ToString() == "3")//Khong dap ung dieu tri
                {

                }
                else if (cklLydokham.GetItemChecked(i) && dtlydokham.Rows[i]["danhmuc"].ToString() == "4")//Di ung thuoc
                {
                    if (bMienphuthu)
                    {
                        m.execute_data("delete from " + m.user + m.mmyy(ngayvv.Text) + ".v_chidinh where maql=" + l_maql_moi + " and paid=0 and hide=1 and mavp in (select a.id from " + m.user + ".v_giavp a," + m.user + ".v_loaivp b where b.id_nhom=4 and a.id_loai=b.id)");
                    }
                    if (MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân bị dị ứng thuốc, bạn có muốn nhập thông tin dị ứng thuốc của bệnh nhân này không?"), s_msg, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        l_diungthuoc_Click(null, null);
                    }
                }
            }
            chkViewClick();
            chkView_CheckedChanged_1(null, null);
            loadphongcls();
        }
        
        /// <summary>
        /// Dong
        /// </summary>
        /// <param name="idvp"></param>
        private void f_bnmien(int idvp)
        {
            foreach (DataRow r in m.get_data(" select id_loai from " + m.user + ".v_giavp where id=" + idvp).Tables[0].Rows)
            {
                sql = "select mabn,mavaovien,tyle as tylemien,tldongchitra from " + m.user + ".tylemien_km a inner join medibv.v_nhommien b on a.id_nhommien=b.id where a.mabn='" + s_mabn + "' and a.mavaovien=" + l_mavaovien_moi + " and b.loaivp like '%" + r["id_loai"].ToString() + "%' and b.sudung=1";
                sql += " union ";
                sql += " select mabn,mavaovien,tyle as tylemien,0 as tldongchitra from " + m.user + ".tylemien_mg a inner join medibv.v_nhommien b on a.id_nhommien=b.id where a.mabn='" + s_mabn + "' and a.mavaovien=" + l_mavaovien_moi + " and b.loaivp like '%" + r["id_loai"].ToString() + "%' and b.sudung=1";
                sql += " union ";
                sql += " select mabn,mavaovien,tyle as tylemien,0 as tldongchitra  from " + m.user + ".tylemien_ud a inner join medibv.v_nhommien b on a.id_nhommien=b.id where a.mabn='" + s_mabn + "' and a.mavaovien=" + l_mavaovien_moi + " and b.loaivp like '%" + r["id_loai"].ToString() + "%' and b.sudung=1";
                sql += " order by mabn";
                ds_bnmien = m.get_data(sql);
            }
        }
        
        // End Dong
        
        private void mabn3_Validated(object sender, EventArgs e)
        {
            
            //string s_idlydokham="",s_lydokham="";

            bKiemtra = true;
            try
            {
                string[] nam = null;
                s_mabn = base.f_get_mabn();// mabn2.Text + mabn3.Text;
                sql = "select nam from " + m.user + ".btdbn where mabn='" + s_mabn + "'";
                ds = m.get_data(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    nam = ds.Tables[0].Rows[0][0].ToString().Trim().Trim('+').Split('+');
                }
                else
                {
                    if (i_chinhanh.ToString().PadLeft(2, '0') != mabn1.Text)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Mã bệnh nhân mới không hợp lệ.\nĐối với bệnh nhân mới, mã chi nhánh không được khác chi nhánh hiện tại. \nKhuyến cáo người dùng nên sử dụng chức năng cấp mã tự động của chương trình."), s_msg);
                        mabn1.Focus();
                    }
                    return;
                }
                sql = "";
                for (int i = 0; i < nam.Length; i++)
                {
                    if (i > 0)
                        sql += " union all ";
                    sql += " select 0 stt,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngay,e.tenkp phongkham,d.ten chinhanh,b.hoten bacsi,a.maicd,a.chandoan,'' lydokham,to_char(a.ngay + cast(to_char(c.songay)||' days' as interval),'dd/mm/yyyy hh24:mi') ngayhen,a.maql,nvl(f.songay,0) songay,a.mabs from " + m.user + nam[i] + ".benhanpk a left join " + m.user + nam[i] + ".hen c on a.maql=c.maql left join " + m.user + ".btdkp_bv e on a.makp=e.makp left join " + m.user + ".dmchinhanh d on e.chinhanh=d.id left join " + m.user + nam[i] + ".d_toathuocll f on f.maql=a.maql," + m.user + ".dmbs b ";
                    sql += " where a.mabn='" + s_mabn + "' and a.mabs=b.ma order by a.ngay desc";
                }
                dtcaclankham = m.get_data(sql).Tables[0];
                //for (int i = 0; i < dtcaclankham.Rows.Count;i++ )
                //{
                //    try
                //    {
                //        sql = "select id_lydokham from " + m.user + m.mmyy(dtcaclankham.Rows[i]["ngay"].ToString()) + ".lydokham where maql in (select a.maql from " + m.user + m.mmyy(dtcaclankham.Rows[i]["ngay"].ToString()) + ".benhanpk a," + m.user + m.mmyy(dtcaclankham.Rows[i]["ngay"].ToString()) + ".tiepdon b where a.mavaovien=b.mavaovien and a.maql=" + dtcaclankham.Rows[i]["maql"].ToString()+")";
                //        s_idlydokham = m.get_data(sql).Tables[0].Rows[0][0].ToString().Trim('+').Replace('+', ',');
                //        foreach (DataRow r in dtlydokham.Select("id in (" + s_idlydokham + ")"))
                //        {
                //            s_lydokham += r["ten"].ToString() + ", ";                            
                //        }
                //        s_lydokham.Trim().Trim(',');
                //        dtcaclankham.Rows[i]["lydokham"] = s_lydokham;
                //    }
                //    catch (Exception exx){ }
                //}
                //dtcaclankham.AcceptChanges();
                dataGrid3.DataSource = dtcaclankham;

                for (int i = 0; i < dtcaclankham.Rows.Count; i++)
                {
                    if (m.StringToDate(dtcaclankham.Rows[i]["ngay"].ToString()).AddDays(int.Parse(dtcaclankham.Rows[i]["songay"].ToString())) > ngayhethong)
                    {
                        if (dtcaclankham.Rows[i]["chinhanh"].ToString().Trim() == "")
                            MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đã khám !"), s_msg);
                        else
                            MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đã khám ở " + dtcaclankham.Rows[i]["chinhanh"].ToString() + "!"), s_msg);
                    }
                    if (dtcaclankham.Rows[i]["ngayhen"].ToString().Trim() != "")
                    {
                        if (m.StringToDate(dtcaclankham.Rows[i]["ngayhen"].ToString()) > ngayhethong)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân được hẹn tái khám ngày " + dtcaclankham.Rows[i]["ngayhen"].ToString().Trim() + ".\nBệnh nhân tái khám sớm!"), s_msg);
                        }
                    }
                }
                emp_details();
            }
            catch { }
        }
        private void AddGridTableStyle()
        {

            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dt.TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            //ts.SelectionBackColor = Color.FromArgb(0, 255, 255);
            //ts.SelectionForeColor = Color.PaleGreen;
            ts.RowHeaderWidth = 10;


            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "stt";
            TextCol.HeaderText = "STT";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ngay";
            TextCol.HeaderText = lan.Change_language_MessageText("Ngày");
            TextCol.Width = 100;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "chinhanh";
            TextCol.HeaderText = lan.Change_language_MessageText("Chi nhánh");
            TextCol.Width = 100;
            TextCol.ReadOnly = true;
            TextCol.NullText = "";
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "phongkham";
            TextCol.HeaderText = lan.Change_language_MessageText("Phòng khám");
            TextCol.Width = 150;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);


            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "bacsi";
            TextCol.HeaderText = lan.Change_language_MessageText("Bác sĩ");
            TextCol.Width = 130;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "maicd";
            TextCol.HeaderText = lan.Change_language_MessageText("ICD10");
            TextCol.Width = 60;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "chandoan";
            TextCol.HeaderText = lan.Change_language_MessageText("Chẩn đoán");
            TextCol.Width = 200;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "lydokham";
            TextCol.HeaderText = lan.Change_language_MessageText("Lý do khám");
            TextCol.Width =0;
            TextCol.NullText = "";
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ngayhen";
            TextCol.HeaderText = lan.Change_language_MessageText("Ngày hẹn");
            TextCol.Width = 100;
            TextCol.ReadOnly = true;
            TextCol.NullText = "";
            ts.GridColumnStyles.Add(TextCol);
            dataGrid3.TableStyles.Add(ts);

        }

        private void AddGridTableStyle1()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dtphongcls.TableName;
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


            TextCol.Width = 120;


            ts.GridColumnStyles.Add(TextCol);
            dgrPhongcls.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tongso";
            TextCol.HeaderText = "T.Số";
            TextCol.Width = 40;
            TextCol.Format = "# ### ###";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dgrPhongcls.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "chua";
            TextCol.HeaderText = "Chưa";
            TextCol.Width = 40;
            TextCol.Format = "# ### ###";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dgrPhongcls.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "dichvu";
            TextCol.HeaderText = "CLS";
            TextCol.Width = 40;
            TextCol.Format = "# ### ###";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dgrPhongcls.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "xong";
            TextCol.HeaderText = "Đã";
            TextCol.Width = 40;
            TextCol.Format = "# ### ###";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dgrPhongcls.TableStyles.Add(ts);
        }

        private void AddGridTableStyle2()
        {

            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dttyle.TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            

            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            //ts.SelectionBackColor = Color.FromArgb(0, 255, 255);
            //ts.SelectionForeColor = Color.PaleGreen;
            ts.RowHeaderWidth = 10;


            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "id";
            TextCol.HeaderText = "id";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid4.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ten";
            TextCol.HeaderText = lan.Change_language_MessageText("Nhóm miễn giảm");
            TextCol.Width = cmbUudai.SelectedIndex==4?275:320;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid4.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tyle";
            TextCol.HeaderText = lan.Change_language_MessageText("Tỷ lệ");
            TextCol.Width = 50;
            TextCol.ReadOnly = cmbUudai.SelectedIndex==1?false:true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid4.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ma";
            TextCol.HeaderText = "ma";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid4.TableStyles.Add(ts);

            if (cmbUudai.SelectedIndex == 4)
            {
                TextCol = new DataGridTextBoxColumn();
                TextCol.MappingName = "tldongchitra";
                TextCol.HeaderText = lan.Change_language_MessageText("TL ĐCT");
                TextCol.Width = 50;
                TextCol.ReadOnly = true;
                ts.GridColumnStyles.Add(TextCol);
                dataGrid4.TableStyles.Add(ts);
            }

            

        }

        private void cklLydokham_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cklLydokham_SelectedValueChanged(object sender, EventArgs e)
        {
            bool danhmuc = false, texttudo = false;
            //traituyen.Enabled = false;
            s_lydokham = "+";
            for (int i = 0; i < dtlydokham.Rows.Count; i++)
            {
                if (dtlydokham.Rows[i]["danhmuc"].ToString() == "1" && cklLydokham.GetItemCheckState(i) == CheckState.Checked)//chon trong danh muc ly do dung tuyen
                {
                    if (tendoituong.SelectedValue.ToString() != "1" ||(tendoituong.SelectedValue.ToString() != "1" && traituyen.SelectedIndex==0))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Lựa chọn này chỉ được dùng cho đối tượng Bảo hiểm y tế trái tuyến."),s_msg);
                        cklLydokham.SetItemCheckState(i,CheckState.Unchecked) ;
                        return;
                    }
                    
                    danhmuc = true;
                    if (cklLydokham.GetItemCheckState(i) == CheckState.Checked)
                        s_lydokham += dtlydokham.Rows[i]["id"].ToString()+"+";
                }
                if (dtlydokham.Rows[i]["danhmuc"].ToString() == "2" && cklLydokham.GetItemCheckState(i) == CheckState.Checked)// go text tu do
                {
                    texttudo = true;
                    s_lydokham += dtlydokham.Rows[i]["id"].ToString() + "+";
                }
                else if(cklLydokham.GetItemCheckState(i) == CheckState.Checked)
                    s_lydokham += dtlydokham.Rows[i]["id"].ToString() + "+";
            }
            cklLydodungtuyen.Enabled = danhmuc;
            if (danhmuc) traituyen.SelectedIndex = 0; else traituyen.SelectedIndex = 1;
            txtLydokham.Enabled = texttudo;
            if (!danhmuc)
            {
                madstt.Enabled = false;
                tendstt.Enabled = false;
                base.bNhapdaydu = true; 
            }
        }

        private void cklLydokham_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            cklLydokham_SelectedValueChanged(null, null);
        }

        private void groupBox1_Validated(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();
            bool check = false,chklydo=false,chkchuyenvien=false;
            for (int i = 0; i < dtlydokham.Rows.Count; i++)
            {
                if (dtlydokham.Rows[i]["danhmuc"].ToString() == "1" && cklLydokham.GetItemCheckState(i) == CheckState.Checked)//chon trong danh muc ly do dung tuyen
                {
                    chklydo = true;
                    for (int j = 0; j < dtlydodungtuyen.Rows.Count; j++)
                    {
                        if (cklLydodungtuyen.GetItemCheckState(j) == CheckState.Checked)
                        { 
                            check = true;
                            if (dtlydodungtuyen.Rows[j]["chuyenvien"].ToString() == "1")
                                chkchuyenvien = true;
                        }
                    }
                }
                if (dtlydokham.Rows[i]["danhmuc"].ToString() == "2" && cklLydokham.GetItemCheckState(i) == CheckState.Checked && txtLydokham.Text.Trim()=="")//chon nhap ly do
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập lý do khám (ô Ghi chú - Lý do khám)."), s_msg);
                    txtLydokham.Focus();
                    return;
                }

                if (dtlydokham.Rows[i]["danhmuc"].ToString() == "3" && cklLydokham.GetItemCheckState(i) == CheckState.Checked && txtLydokham.Text.Trim() == "")//chon khong dap ung dieu tri
                {
                    if (dtcaclankham.Rows.Count != 0)
                    {
                        sql = "select * from "+m.user+".user_active a,"+m.user+".btdkp_bv b where a.makp=b.makp and a.mabs='"+dtcaclankham.Rows[0]["mabs"].ToString()+"' and to_char(a.ngay,'dd/mm/yyyy')='"+ngayhienhanh.Substring(0,10)+"' order by ngay desc";
                        dtuser = m.get_data(sql).Tables[0];
                        if (dtuser.Rows.Count != 0)
                        {
                            if (MessageBox.Show(lan.Change_language_MessageText("Bác sĩ " + dtcaclankham.Rows[0]["bacsi"].ToString() + " khám lần trước, hiện tại vừa đăng nhập phòng khám "+dtuser.Rows[0]["tenkp"].ToString()+".\n Bạn có muốn chỉ định bệnh nhân vào khám phòng này không?"), s_msg,MessageBoxButtons.YesNoCancel)==DialogResult.Yes)
                            {
                                makp.Text = dtuser.Rows[0]["makp"].ToString();
                                tenkp.Text = dtuser.Rows[0]["tenkp"].ToString();
                            }
                        }
                    }
                }
            }
            if (!check && chklydo)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn lý do đúng tuyến."),s_msg);
                cklLydodungtuyen.Focus();
                return;
            }
            if (check && chklydo && tendstt.Text.Trim() == ""&&chkchuyenvien)
            {
                bNhapdaydu = false;
            }
            else bNhapdaydu = true;
        }

        private void cklLydodungtuyen_SelectedValueChanged(object sender, EventArgs e)
        {
            s_lydodungtuyen = "+";
            madstt.Enabled = false;
            tendstt.Enabled = false;
            for (int i = 0; i < dtlydodungtuyen.Rows.Count; i++)
            {
                if (cklLydodungtuyen.GetItemCheckState(i) == CheckState.Checked && dtlydodungtuyen.Rows[i]["chuyenvien"].ToString() == "1")
                {
                    madstt.Enabled = true;
                    tendstt.Enabled = true;
                    base.bNhapdaydu = false;
                }
                else
                {
                    if (!tendstt.Enabled)
                    {
                        madstt.Enabled = false;
                        tendstt.Enabled = false;
                        base.bNhapdaydu = true;
                    }
                }
                if (cklLydodungtuyen.GetItemCheckState(i) == CheckState.Checked)
                    s_lydodungtuyen += dtlydodungtuyen.Rows[i]["id"].ToString() + "+";
            }
        }

        private void cklLydodungtuyen_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            cklLydodungtuyen_SelectedValueChanged(null, null);
        }

        private void tendstt_Validated(object sender, EventArgs e)
        {
            if (!listdstt.Focused)
            {
                if (madstt.Text.Trim() == "" || tendstt.Text.Trim() == "")
                {
                    base.bNhapdaydu = false;
                }
                else
                    base.bNhapdaydu = true;
            }
        }

        private void butTiep_Click(object sender, EventArgs e)
        {
            bKiemtra = true;
            s_lydodungtuyen = "+";
            s_lydokham = "+";
            for (int i = 0; i < dtlydodungtuyen.Rows.Count; i++)
            {
                cklLydodungtuyen.SetItemCheckState(i, CheckState.Unchecked);
            }
            for (int i = 0; i < dtlydokham.Rows.Count; i++)
            {
                cklLydokham.SetItemCheckState(i, CheckState.Unchecked);
            }
            madstt.Enabled = false;
            tendstt.Enabled = false;
            cmbUudai.SelectedIndex = 0;
            emp_details();
            int giohanhchanh = phanloaiThoigian();
            cmbLoaitg.SelectedValue = giohanhchanh;
            chkViewClick();
            //chkView_CheckedChanged_1(null, null);
            loadphongcls();
        }

        private void emp_details()
        {
            for (int i = 0; i < dtlydokham.Rows.Count; i++)
            {
                cklLydokham.SetItemCheckState(i, CheckState.Unchecked);
            }
            for (int i = 0; i < dtlydodungtuyen.Rows.Count; i++)
            {
                cklLydodungtuyen.SetItemCheckState(i, CheckState.Unchecked);
            }
            txtLydokham.Text = "";
            cmbUudai.SelectedIndex = 0;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string[] s_id_lydokham = null, s_id_lydodungtuyen = null;
            DataTable dttmp = new DataTable();
            string s = e.Node.FullPath.Trim();
            int iPos = s.IndexOf("/");
            string ngay = s.Substring(iPos - 2, 16);
            string title = "";
            madstt.Text = "";
            tendstt.Text = "";
            madstt.Enabled = false;
            tendstt.Enabled = false;
            cklLydodungtuyen.Enabled = false;
            if (l_maql_moi != 0)
            {
                sql = "select * from " + m.user + m.mmyy(ngayvv.Text) + ".lydokham a left join  " + m.user + m.mmyy(ngayvv.Text) + ".noigioithieu b on a.maql=b.maql left join " + m.user + ".dstt c on b.mabv=c.mabv where a.maql=" + l_maql_moi;
                dt = m.get_data(sql).Tables[0];

                for (int i = 0; i < dtlydokham.Rows.Count; i++)
                {
                    cklLydokham.SetItemCheckState(i, CheckState.Unchecked);
                }
                for (int i = 0; i < dtlydodungtuyen.Rows.Count; i++)
                {
                    cklLydodungtuyen.SetItemCheckState(i, CheckState.Unchecked);
                }

                if (dt.Rows.Count != 0)
                {
                    txtLydokham.Text = dt.Rows[0]["lydo"].ToString();
                    s_id_lydodungtuyen = dt.Rows[0]["id_lydodungtuyen"].ToString().Split('+');
                    s_id_lydokham = dt.Rows[0]["id_lydokham"].ToString().Split('+');
                    s_lydokham = dt.Rows[0]["id_lydokham"].ToString();
                    s_lydodungtuyen = dt.Rows[0]["id_lydodungtuyen"].ToString();
                    madstt.Text = dt.Rows[0]["mabv"].ToString();
                    tendstt.Text = dt.Rows[0]["tenbv"].ToString();

                    for (int i = 0; i < dtlydokham.Rows.Count; i++)
                    {
                        for (int j = 0; j < s_id_lydokham.Length; j++)
                        {
                            if (dtlydokham.Rows[i]["id"].ToString() == s_id_lydokham[j])
                            {
                                cklLydokham.SetItemCheckState(i, CheckState.Checked);

                                if (dtlydokham.Rows[i]["danhmuc"].ToString() == "1")
                                    cklLydodungtuyen.Enabled = true;
                            }
                        }
                    }
                    for (int i = 0; i < dtlydodungtuyen.Rows.Count; i++)
                    {
                        for (int j = 0; j < s_id_lydodungtuyen.Length; j++)
                        {
                            if (dtlydodungtuyen.Rows[i]["id"].ToString() == s_id_lydodungtuyen[j])
                            {
                                cklLydodungtuyen.SetItemCheckState(i, CheckState.Checked);
                                if (dtlydodungtuyen.Rows[i]["chuyenvien"].ToString().Trim() == "1")
                                {
                                    madstt.Enabled = true;
                                    tendstt.Enabled = true;
                                }
                            }
                        }
                    }
                }
            }
            dataGrid4.DataSource = null;
            dataGrid4.TableStyles.Clear();
            cmbUudai.SelectedIndex = 0;
                    d_mavaovien_tam = decimal.Parse(m.get_mavaovien_tiepdon(l_maql_moi, ngay.Substring(3, 2) + ngay.Substring(8, 2)).ToString());
            if (d_mavaovien_tam != 0)
            {
                //sql = "select * from " + m.user + ".tylemien_km where mavaovien=" + l_mavaovien_moi + " and mabn='" + s_mabn + "'";
                sql = "select a.id_nhommien id,b.ten,a.tyle,a.loaiuudai,a.tldongchitra,c.ten ten1 from " + m.user + ".tylemien_km a, " + m.user + ".v_nhommien b," + m.user + ".v_dot_khuyenmai c where b.sudung=1 and a.id_nhommien=b.id and a.iddotkm=c.id and a.mavaovien="+d_mavaovien_tam;
                dttyle = m.get_data(sql).Tables[0];
                if (dttyle.Rows.Count != 0)
                {
                    if (dttyle.Rows[0]["loaiuudai"].ToString()=="")
                    dttmp = dttyle.Copy();
                    dataGrid4.DataSource = dttyle;
                    AddGridTableStyle2();
                    title = dttyle.Rows[0]["ten1"].ToString();
                    cmbUudai.SelectedIndex = int.Parse(dttyle.Rows[0]["loaiuudai"].ToString());
                    dataGrid4.DataSource = dttmp;
                    cmbDuyetmien.Text = title;
                    cmbDuyetmien.Enabled = false;
                    CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid4.DataSource];
                    DataView dv = (DataView)cm.List;
                    dv.AllowNew = false;
                }
                else
                {
                    sql = "select a.id_nhommien id,b.ten,a.tyle,3 loaiuudai,d.ten||' ('||c.sothe||') ' ten1 from " + m.user + ".tylemien_ud a, " + m.user + ".v_nhommien b," + m.user + ".btdbn_uudai c," + m.user + ".v_dmloaithe_uudai d where b.sudung=1 and a.id_nhommien=b.id and a.id_theuudai=c.id and c.idthe=d.id and a.mavaovien=" + d_mavaovien_tam;
                    dttyle = m.get_data(sql).Tables[0];
                    if (dttyle.Rows.Count != 0)
                    {
                        dttmp = dttyle.Copy();
                        dataGrid4.DataSource = dttyle;
                        AddGridTableStyle2();
                        title = dttyle.Rows[0]["ten1"].ToString();
                        cmbUudai.SelectedIndex = int.Parse(dttyle.Rows[0]["loaiuudai"].ToString());
                        dataGrid4.DataSource = dttmp;
                        cmbDuyetmien.Text = title;
                        cmbDuyetmien.Enabled = false;
                        CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid4.DataSource];
                        DataView dv = (DataView)cm.List;
                        dv.AllowNew = false;
                    }
                    else
                    {
                        sql = "select a.id_nhommien id,b.ten,a.tyle,1 loaiuudai,c.ten ten1 from " + m.user + ".tylemien_mg a, " + m.user + ".v_nhommien b," + m.user + ".v_dsduyet c where b.sudung=1 and a.id_nhommien=b.id and a.nguoiduyetmien=c.ma and a.mavaovien=" + d_mavaovien_tam;
                        dttyle = m.get_data(sql).Tables[0];
                        if (dttyle.Rows.Count != 0)
                        {
                            dttmp = dttyle.Copy();
                            dataGrid4.DataSource = dttyle;
                            AddGridTableStyle2();
                            title = dttyle.Rows[0]["ten1"].ToString();
                            cmbUudai.SelectedIndex = int.Parse(dttyle.Rows[0]["loaiuudai"].ToString());
                            dataGrid4.DataSource = dttmp;
                            cmbDuyetmien.Text = title;
                            cmbDuyetmien.Enabled = false;
                            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid4.DataSource];
                            DataView dv = (DataView)cm.List;
                            dv.AllowNew = false;
                        }
                    }
                }
                
            }
        }

        private void tendoituong_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dtlydokham.Rows.Count; i++)
            {
                if (dtlydokham.Rows[i]["danhmuc"].ToString() == "1")
                {
                    cklLydokham.SetItemCheckState(i, CheckState.Unchecked);
                    for (int j = 0; j < dtlydodungtuyen.Rows.Count; j++)
                    {
                        cklLydodungtuyen.SetItemCheckState(j, CheckState.Unchecked);
                    }
                }
            }
        }

        private void cmbUudai_SelectedIndexChanged(object sender, EventArgs e)
        {
            edit = true;
            switch (cmbUudai.SelectedIndex)
            { 
                case 0: //Trang
                    lbDuyetMien.Text = "...";
                    cmbDuyetmien.Enabled = false;
                    dataGrid4.DataSource = null;
                    cmbDuyetmien.DataSource = null;
                    break;
                case 1: //Mien giam
                    lbDuyetMien.Text = lan.Change_language_MessageText("Người duyệt miễn:");
                    dataGrid4.TableStyles.Clear();
                    load_miengiam();
                    break;
                case 2: //Khuyen mai
                    lbDuyetMien.Text = lan.Change_language_MessageText("Chương trình khuyến mãi:");
                    dataGrid4.TableStyles.Clear();
                    load_khuyenmai();
                    break;
                case 3: //Uu dai
                    lbDuyetMien.Text = lan.Change_language_MessageText("Thẻ ưu đãi:");
                    dataGrid4.TableStyles.Clear();
                    load_uudai();

                    break;
                case 4: //khuyen mai theo the bhyt
                    lbDuyetMien.Text = lan.Change_language_MessageText("Chương trình khuyến mãi:");
                    dataGrid4.TableStyles.Clear();
                    load_khuyenmai_bhyt();
                    break;
            }
        }


        private void load_miengiam()
        {
            cmbDuyetmien.Enabled = true;
            dataGrid4.DataSource = null;
            cmbDuyetmien.DataSource = null;
            sql = "select * from " + m.user + ".v_dsduyet " ;
            dtduyetmien = m.get_data(sql).Tables[0];
            cmbDuyetmien.DataSource = dtduyetmien;
            cmbDuyetmien.ValueMember = "ma";
            cmbDuyetmien.DisplayMember = "ten";
            cmbDuyetmien_SelectedIndexChanged(null, null);
        }

        private void load_khuyenmai()
        {
            cmbDuyetmien.Enabled = true;
            dataGrid4.DataSource = null;
            cmbDuyetmien.DataSource = null;
            sql = "select * from " + m.user + ".v_dot_khuyenmai where hide=0 and loai=1 ";
            dtduyetmien = m.get_data(sql).Tables[0];
            cmbDuyetmien.DataSource = dtduyetmien;
            cmbDuyetmien.ValueMember = "id";
            cmbDuyetmien.DisplayMember = "ten";
            cmbDuyetmien_SelectedIndexChanged(null, null);
        }

        private void load_uudai()
        {
            cmbDuyetmien.Enabled = true;
            dataGrid4.DataSource = null;
            cmbDuyetmien.DataSource = null;
            sql = "select a.id,'('||a.sothe||') ' || b.ten ten,a.sothe from  " + m.user + ".btdbn_uudai a," + m.user + ".v_dmloaithe_uudai b where a.mabn='" + s_mabn + "' and sysdate between tungay and denngay and a.idthe=b.id";
            dtduyetmien = m.get_data(sql).Tables[0];
            cmbDuyetmien.DataSource = dtduyetmien;
            cmbDuyetmien.ValueMember = "id";
            cmbDuyetmien.DisplayMember = "ten";
            cmbDuyetmien_SelectedIndexChanged(null, null);
        }

        private void load_khuyenmai_bhyt()
        {
            cmbDuyetmien.Enabled = false;
            dataGrid4.DataSource = null;
            cmbDuyetmien.DataSource = null;
            s_mabhyt = "";
            DataTable dttam = new DataTable();
            if (tendoituong.SelectedValue != null)
            {
                if (sothe.Text.Trim() == "" || int.Parse(tendoituong.SelectedValue.ToString()) != 1)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Lựa chọn này chỉ dành cho đối tượng BHYT và đã nhập số thẻ BHYT!"), s_msg);
                    cmbUudai.SelectedIndex = 0;
                    return;
                }
                load_khuyenmai();
            }
        }

        private void cmbDuyetmien_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbUudai.SelectedIndex == 1)//mien giam
                {
                    sql = "select b.id,b.ten,nvl(a.tyle,0) tyle,a.ma from " + m.user + ".v_tyleduyetmien a right join " + m.user + ".v_nhommien b on a.id_nhommien=b.id and a.ma=" + cmbDuyetmien.SelectedValue + " where b.sudung=1 order by b.ten";
                    dttyle = m.get_data(sql).Tables[0];
                    dataGrid4.DataSource = dttyle;
                    dttyle_tam = dttyle.Copy();
                    CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid4.DataSource];
                    DataView dv = (DataView)cm.List;
                    dv.AllowNew = false;
                    AddGridTableStyle2();
                }

                else if (cmbUudai.SelectedIndex == 2)//khuyen mai
                {
                    sql = "select b.id,b.ten,nvl(a.tyle,0) tyle,nvl(a.iddot,0) ma from " + m.user + ".v_km_nhommien a right join " + m.user + ".v_nhommien b on a.id_nhommien=b.id and a.iddot=" + cmbDuyetmien.SelectedValue + " where b.sudung=1 order by b.ten";
                    dttyle = m.get_data(sql).Tables[0];
                    dataGrid4.DataSource = dttyle;
                    dttyle_tam = dttyle.Copy();
                    CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid4.DataSource];
                    DataView dv = (DataView)cm.List;
                    dv.AllowNew = false;
                    AddGridTableStyle2();
                }
                else if (cmbUudai.SelectedIndex == 3)//uu dai
                {
                    if (cmbDuyetmien.SelectedValue != null)
                    {
                        sql = "select c.id,c.ten,nvl(b.tyle,0) tyle,nvl(a.sothe,0) ma from " + m.user + ".btdbn_uudai a left join " + m.user + ".btdbn_uudaict b on a.id=b.id left join " + m.user + ".v_nhommien c on b.id_nhommien=c.id where b.id=" + cmbDuyetmien.SelectedValue + " and c.sudung=1 order by c.ten";
                        dttyle = m.get_data(sql).Tables[0];
                        dataGrid4.DataSource = dttyle;
                        dttyle_tam = dttyle.Copy();
                        CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid4.DataSource];
                        DataView dv = (DataView)cm.List;
                        dv.AllowNew = false;
                        AddGridTableStyle2();
                    }
                }
                else if (cmbUudai.SelectedIndex == 4)//khuyen mai theo the bhyt
                {
                    for (int i = 0; i < dtthe.Rows.Count; i++)
                    {
                        if (sothe.Text.Length == int.Parse(dtthe.Rows[i]["chieudai"].ToString()) && sothe.Text.Substring(int.Parse(dtthe.Rows[i]["tu"].ToString() )- 1, int.Parse(dtthe.Rows[i]["den"].ToString()) + 1 - int.Parse(dtthe.Rows[i]["tu"].ToString())) == dtthe.Rows[i]["ma"].ToString())
                        {
                            dataGrid4.TableStyles.Clear();
                            s_mabhyt = dtthe.Rows[i]["ma"].ToString();
                            sql = "select b.id,b.ten,nvl(a.tyle,0) tyle,ma,nvl(a.tldongchitra,0) tldongchitra from " + m.user + ".tyleuudai_loaibhyt a, " + m.user + ".v_nhommien b where a.id_nhommien=b.id and b.sudung=1 and a.iddotkm=" + cmbDuyetmien.SelectedValue + " and a.ma='" + s_mabhyt + "'";
                            dttyle = m.get_data(sql).Tables[0];
                            dataGrid4.DataSource = dttyle;
                            dttyle_tam = dttyle.Copy();
                            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid4.DataSource];
                            DataView dv = (DataView)cm.List;
                            dv.AllowNew = false;
                            AddGridTableStyle2();
                        }
                    }
                }
            }
            catch (Exception exx){ }
        }

        private void dataGrid4_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dttyle.Rows.Count; i++)
                {
                    if (int.Parse(dttyle.Rows[i]["tyle"].ToString()) > int.Parse(m.getrowbyid(dttyle_tam, "id=" + dttyle.Rows[i]["id"].ToString())["tyle"].ToString()))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Tỷ lệ miễn giảm mới không được lớn hơn giá trị mặc định (Giá trị mặc định sẽ được nạp lại)!"),s_msg);
                        dttyle = dttyle_tam.Copy();
                        dataGrid4.DataSource = dttyle;
                    }
                    if (int.Parse(dttyle.Rows[i]["tyle"].ToString()) < 0 || int.Parse(dttyle.Rows[i]["tyle"].ToString()) >100 )
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Tỷ lệ miễn giảm không hợp lệ (Giá trị mặc định sẽ được nạp lại)!"),s_msg);
                        dttyle = dttyle_tam.Copy();
                        dataGrid4.DataSource = dttyle;
                    }
                }
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid4.DataSource];
                DataView dv = (DataView)cm.List;
                dv.AllowNew = false;
            }
            catch { }
        }

        private void dataGrid4_Validated(object sender, EventArgs e)
        {
            dataGrid4_CurrentCellChanged(null, null);
        }

        private void sothe_Validated(object sender, EventArgs e)
        {
            //traituyen.Enabled = false;
            string noidkkb = "";
            if (sothe.Text.Trim().Length>15 && int.Parse(tendoituong.SelectedValue.ToString())==1)
            {
                noidkkb = sothe.Text.Trim().Substring(sothe.Text.Trim().Length-5);
                if (noidkkb == m.Mabvbhyt)
                {
                    traituyen.SelectedIndex = 0;
                }
                else
                    traituyen.SelectedIndex = 1;
            }
        }

        private void quanhe_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cklLydokham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private int phanloaiThoigian()
        {
            
            DateTime ngay_1, ngay_2, ngay_3, ngay_4, ngay_5;
            string ngayhethong = m.get_data("select to_char(to_date('" + ngayvv.Text.Trim() + " " + giovv.Text + "','dd/mm/yyyy hh24:mi'),'DY dd/mm/yyyy hh24:mi') from dual").Tables[0].Rows[0][0].ToString();
                //ngayvv.Text.Trim() + " " + giovv.Text;
               // m.get_data("select to_char(sysdate,'DY dd/mm/yyyy hh24:mi') from dual").Tables[0].Rows[0][0].ToString();
            
            //kiem tra ngay le
            for (int i = 0; i < dtngayle.Rows.Count; i++)
            {
                if (dtngayle.Rows[i]["ngay"].ToString() == ngayhethong.Substring(4, 5))
                {
                    return 3;
                }
            }

            //kiem tra ngay nghi
            for (int i = 0; i < dtngaynghi.Rows.Count; i++)
            {
                if (int.Parse(dtngaynghi.Rows[i]["nghi"].ToString()) == 1 && dtngaynghi.Rows[i]["day"].ToString().ToUpper()==ngayhethong.Substring(0,3).ToUpper())
                {
                    if (dtngaynghi.Rows[i]["tugio"].ToString().Trim() == "") //neu ko set thoi gian co nghia la ngay nghi do nghi nguyen ngay
                        return 2;
                    else
                    {     //trong gio: nghi nua ngay thu 7
                        ngay_1 = m.StringToDateTime(ngayhethong.Substring(4));
                        ngay_2 = m.StringToDateTime(ngayhethong.Substring(4, 11) + dtngaynghi.Rows[i]["tugio"].ToString());
                        ngay_3 = m.StringToDateTime(ngayhethong.Substring(4, 11) + dtngaynghi.Rows[i]["dengio"].ToString());
                        if (ngay_1 > ngay_2 && ngay_1 < ngay_3) //neu roi vao truong hop nghi nua ngay t7 thi nua ngay la trong gio, nua ngay la ngay nghi
                            return 0;
                        else return 2;
                    }
                }
            }
            DataRow r = m.getrowbyid(dtloaitg, "id=0");
            ngay_1 = m.StringToDateTime(ngayhethong.Substring(4));
            ngay_2 = m.StringToDateTime(ngayhethong.Substring(4, 11) + r["tugio_s"].ToString());
            ngay_3 = m.StringToDateTime(ngayhethong.Substring(4, 11) + r["dengio_s"].ToString());
            ngay_4 = m.StringToDateTime(ngayhethong.Substring(4, 11) + r["tugio_c"].ToString());
            ngay_5 = m.StringToDateTime(ngayhethong.Substring(4, 11) + r["dengio_c"].ToString());
            //kiem tra trong gio
            if ((ngay_1 > ngay_2 && ngay_1 < ngay_3) || (ngay_1 > ngay_4 && ngay_1 < ngay_5))
                return 0;
            else return 1;//nguoc la la ngoai gio
        }

        private void listdstt_Validated(object sender, EventArgs e)
        {
            if (madstt.Text.Trim() == "" || tendstt.Text.Trim() == "")
            {
                base.bNhapdaydu = false;
            }
            else
                base.bNhapdaydu = true;
        }

        private void mabn2_Validated(object sender, EventArgs e)
        {
            
        }

        private void mabn1_Validated(object sender, EventArgs e)
        {
            if (mabn1.Text.Trim() == "")
            {
                mabn1.Text = i_chinhanh.ToString().PadLeft(2, '0');
                return;
            }
            mabn1.Text = mabn1.Text.Trim().PadLeft(2, '0');
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dtcaclankham.Rows.Count != 0)
            {
                frmXemcaclankham f = new frmXemcaclankham(lan.Change_language_MessageText("Bệnh nhân: ")+hoten.Text.Trim()+" ( "+ s_mabn+" )",dtcaclankham);
                f.ShowInTaskbar = false;
                f.ShowDialog();
            }

        }

        private void chkView_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                DataTable dttam = new DataTable();
                sql = "select b.ten tenkp,count(idphongthuchiencls) tongso,sum(case when done=0 then 1 else 0 end) chua,0 dichvu, sum(case when done<>0 then 1 else 0 end) xong ";
                sql += " from " + m.user + m.mmyy(ngayhienhanh) + ".v_chidinh a," + m.user + ".dmphongthuchiencls b ";
                sql += " where a.idphongthuchiencls=b.id and a.hide=0 and a.paid<>0 and to_char(a.ngay,'dd/mm/yyyy')='" + ngayhienhanh.Substring(0, 10) + "'";
                sql += " group by b.ten";
                dttam = m.get_data(sql).Tables[0];
                foreach (DataRow r in dttam.Rows)
                {
                    DataRow r1 = m.getrowbyid(base.dtv, "tenkp='"+r["tenkp"].ToString()+"'");
                    if (r1 == null)
                    {
                        DataRow nrow = base.dtv.NewRow();
                        nrow["tenkp"] = r["tenkp"];
                        nrow["tongso"] = r["tongso"];
                        nrow["chua"] = r["chua"];
                        nrow["dichvu"] = r["dichvu"];
                        nrow["xong"] = r["xong"];
                        base.dtv.Rows.Add(nrow);
                    }
                    else
                    {
                        DataRow[] dr = base.dtv.Select("tenkp='" + r["tenkp"].ToString() + "'");
                        dr[0]["tongso"] = r["tongso"];
                        dr[0]["chua"] = r["chua"];
                        dr[0]["dichvu"] = r["dichvu"];
                        dr[0]["xong"] = r["xong"];
                    }
                }
                base.dtv.AcceptChanges();
                //dttam.Merge(base.dtv);
                dataGrid2.DataSource = base.dtv;
            }
            catch (Exception exx) { }
        }
        private void loadphongcls()
        {
            try
            {
                
                sql = "select b.ten tenkp,count(idphongthuchiencls) tongso,sum(case when done=0 then 1 else 0 end) chua,0 dichvu, sum(case when done<>0 then 1 else 0 end) xong ";
                sql += " from " + m.user + m.mmyy(ngayhienhanh) + ".v_chidinh a," + m.user + ".dmphongthuchiencls b ";
                sql += " where a.idphongthuchiencls=b.id and a.hide=0 and a.paid<>0 and to_char(a.ngay,'dd/mm/yyyy')='" + ngayhienhanh.Substring(0, 10) + "'";
                sql += " group by b.ten";
                dtphongcls = m.get_data(sql).Tables[0];
                //foreach (DataRow r in dttam.Rows)
                //{
                //    DataRow r1 = m.getrowbyid(base.dtv, "tenkp='" + r["tenkp"].ToString() + "'");
                //    if (r1 == null)
                //    {
                //        DataRow nrow = base.dtv.NewRow();
                //        nrow["tenkp"] = r["tenkp"];
                //        nrow["tongso"] = r["tongso"];
                //        nrow["chua"] = r["chua"];
                //        nrow["dichvu"] = r["dichvu"];
                //        nrow["xong"] = r["xong"];
                //        base.dtv.Rows.Add(nrow);
                //    }
                //    else
                //    {
                //        DataRow[] dr = base.dtv.Select("tenkp='" + r["tenkp"].ToString() + "'");
                //        dr[0]["tongso"] = r["tongso"];
                //        dr[0]["chua"] = r["chua"];
                //        dr[0]["dichvu"] = r["dichvu"];
                //        dr[0]["xong"] = r["xong"];
                //    }
                //}
                //base.dtv.AcceptChanges();
                //dttam.Merge(base.dtv);
                dgrPhongcls.DataSource = dtphongcls;
            }
            catch (Exception exx) { }
        }
        private void butChitiet_Click(object sender, EventArgs e)
        {
            //frmChonchedo_uudai f = new frmChonchedo_uudai(m, "1,3,", "");
            //f.ShowInTaskbar = false;
            //f.ShowDialog();
        }
    }
}
