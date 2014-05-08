using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MEDISOFT2011.DESKTOP
{
    public partial class frmMThongtinnguoidung : Form
    {
        public bool _admin = false;
        public string _id = "0";
        public LibVP.AccessData v;
        Medisoft.Language lan = new Medisoft.Language();
        public frmMThongtinnguoidung()
        {
            InitializeComponent();
            InitMultiLanguage();
        }
        public frmMThongtinnguoidung(bool v_admin, string v_id)
        {
            _admin = v_admin;
            _id = v_id;
            v = new LibVP.AccessData();
            InitializeComponent();
           
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            InitMultiLanguage();
            f_Load_CB();
            f_ShowInfo();
        }
        private void InitMultiLanguage()
        {
            dg_dmkhudt.lbTitle.Text = ResourceManager.GetString("khudieutri");
            dg_d_dmnhomkho.lbTitle.Text = ResourceManager.GetString("nhomkho");
            dg_d_dmnhom.lbTitle.Text = ResourceManager.GetString("nhombietduoc");
            dg_doituong.lbTitle.Text = ResourceManager.GetString("doituong");
            dg_d_dmkho.lbTitle.Text = ResourceManager.GetString("kho");
            dg_btdkp_bv.lbTitle.Text = ResourceManager.GetString("khoaphong");
            dg_d_duockp.lbTitle.Text = ResourceManager.GetString("duockhoaphong");
            dg_d_dmkhac.lbTitle.Text = ResourceManager.GetString("loaikhac");
        }
        private void f_load_data()
        {
            try
            {
                string asql = "";
                asql = "select ten,id from medibv.dmkhudt order by ten asc";
                dg_dmkhudt.f_set_ds(v.get_data(asql), "Tên", "TEN", "TEN");
                dg_dmkhudt.lbTitle.Text =ResourceManager.GetString( "khudieutri");
                dg_dmkhudt.dgData.ColumnHeadersVisible = false;
                dg_dmkhudt.dgData.BorderStyle = BorderStyle.None;

                asql = "select ten,id from medibv.d_dmnhomkho order by ten asc";
                dg_d_dmnhomkho.f_set_ds(v.get_data(asql), "Tên", "TEN", "TEN");
                //dg_d_dmnhomkho.lbTitle.Text = "Nhóm kho";
                dg_d_dmnhomkho.lbTitle.Text = ResourceManager.GetString("nhomkho");
                dg_d_dmnhomkho.dgData.ColumnHeadersVisible = false;
                dg_d_dmnhomkho.dgData.BorderStyle = BorderStyle.None;

                asql = "select ten,id from medibv.d_dmnhom order by ten asc";
                dg_d_dmnhom.f_set_ds(v.get_data(asql), "Tên", "TEN", "TEN");
               // dg_d_dmnhom.lbTitle.Text = "Nhóm biệt dược";
                dg_d_dmnhom.lbTitle.Text = ResourceManager.GetString("nhombietduoc");
                dg_d_dmnhom.dgData.ColumnHeadersVisible = false;
                dg_d_dmnhom.dgData.BorderStyle = BorderStyle.None;

                asql = "select doituong as ten,madoituong as id from medibv.doituong order by doituong asc";
                dg_doituong.f_set_ds(v.get_data(asql), "Tên", "TEN", "TEN");
                //dg_doituong.lbTitle.Text = "Đối tượng";
                dg_doituong.lbTitle.Text = ResourceManager.GetString("doituong");
                dg_doituong.dgData.ColumnHeadersVisible = false;
                dg_doituong.dgData.BorderStyle = BorderStyle.None;

                asql = "select a.ten as ten,a.id as id, b.ten as nhomkho from medibv.d_dmkho a left join medibv.d_dmnhomkho b on a.nhom=b.id order by b.ten,a.ten asc";
                dg_d_dmkho.f_set_ds(v.get_data(asql), "Tên~Nhóm kho", "TEN~NHOMKHO", "TEN");
                //dg_d_dmkho.lbTitle.Text = "Kho";
                dg_d_dmkho.lbTitle.Text = ResourceManager.GetString("kho");
                dg_d_dmkho.dgData.ColumnHeadersVisible = false;
                dg_d_dmkho.dgData.BorderStyle = BorderStyle.None;

                asql = "select ten,id from medibv.d_dmloaint order by ten asc";
                dg_d_dmloaint.f_set_ds(v.get_data(asql), "Tên", "TEN", "TEN");
               // dg_d_dmloaint.lbTitle.Text = "Loại nội trú";
                dg_d_dmloaint.lbTitle.Text = ResourceManager.GetString("loainoitru");
                dg_d_dmloaint.dgData.ColumnHeadersVisible = false;
                dg_d_dmloaint.dgData.BorderStyle = BorderStyle.None;

                asql = "select tenkp as ten,makp as id from medibv.btdkp_bv order by tenkp asc";
                dg_btdkp_bv.f_set_ds(v.get_data(asql), "Tên", "TEN", "TEN");
               // dg_btdkp_bv.lbTitle.Text = "Khoa phòng";
                dg_btdkp_bv.lbTitle.Text = ResourceManager.GetString("khoaphong");
                dg_btdkp_bv.dgData.ColumnHeadersVisible = false;
                dg_btdkp_bv.dgData.BorderStyle = BorderStyle.None;

                asql = "select ten,id from medibv.d_duockp order by ten asc";
                dg_d_duockp.f_set_ds(v.get_data(asql), "Tên", "TEN", "TEN");
                //dg_d_duockp.lbTitle.Text = "Dược khoa phòng";
                dg_d_duockp.lbTitle.Text = ResourceManager.GetString("duockhoaphong");
                dg_d_duockp.dgData.ColumnHeadersVisible = false;
                dg_d_duockp.dgData.BorderStyle = BorderStyle.None;

                asql = "select ten,id from medibv.d_dmkhac order by ten asc";
                dg_d_dmkhac.f_set_ds(v.get_data(asql), "Tên", "TEN", "TEN");
               // dg_d_dmkhac.lbTitle.Text = "Loại khác";
                dg_d_dmkhac.lbTitle.Text = ResourceManager.GetString("loaikhac");
                dg_d_dmkhac.dgData.ColumnHeadersVisible = false;
                dg_d_dmkhac.dgData.BorderStyle = BorderStyle.None;


            }
            catch
            {
            }
        }
        private void f_ShowInfo()
        {
            butAdd.Visible = _admin;
            butDel.Visible = _admin;
            chkSaveandnew.Visible = butAdd.Visible;
        }
        private void f_Load_CB()
        {
            try
            {
                cbGioitinh.DisplayMember = "TEN";
                cbGioitinh.ValueMember = "MA";
                cbGioitinh.DataSource = v.get_data("select ma,ten from medibv.dmphai order by ten").Tables[0];

                cbBacsi.DisplayMember = "TEN";
                cbBacsi.ValueMember = "MA";
                cbBacsi.DataSource = v.get_data("select '' as ma,'' as ten union all select ma as ma,ma||'  '||hoten||'' as ten from medibv.dmbs order by ten").Tables[0];

                cbNhomnv.DisplayMember = "TEN";
                cbNhomnv.ValueMember = "MA";
                cbNhomnv.DataSource = v.get_data("select id as ma,ten from medibv.nhomnhanvien order by ten").Tables[0];

                cbChinhanh.DisplayMember = "TEN";
                cbChinhanh.ValueMember = "MA";
                cbChinhanh.DataSource = v.get_data("select 0 as ma,'' as ten union all select id as ma,ten from medibv.dmchinhanh order by ten").Tables[0];
            }
            catch
            {
            }
        }
        private void f_Load_User()
        {
            try
            {
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtHoten.Text = "";
                txtNgaysinh.Text = "";
                txtDiachi.Text = "";
                txtDTNha.Text = "";
                txtDTCoquan.Text = "";
                txtDTDidong.Text = "";
                txtEmail.Text = "";
                try
                {
                    cbGioitinh.SelectedIndex = 0;
                }
                catch
                {
                }
                try
                {
                    cbNhomnv.SelectedIndex = 0;
                }
                catch
                {
                }
                try
                {
                    cbBacsi.SelectedIndex = 0;
                }
                catch
                {
                }
                try
                {
                    cbChinhanh.SelectedIndex = 0;
                }
                catch
                {
                }

                chkAdmin.Checked = false;
                chkTao.Checked = false;
                chkThuhoi.Checked = false;
                chkMau38_duyetcls.Checked = false;
                chkMau38_duyetthuoc.Checked = false;
                chkDuyetcv.Checked = false;


                chkPHBN.Checked = false;
                chkPHVP.Checked = false;
                chkPHD.Checked = false;
                chkPHXN.Checked = false;
                chkPHCDHA.Checked = false;
                chkPHNS.Checked = false;
                chkPHRP.Checked = false;
                chkPHCT.Checked = false;

                dg_dmkhudt.f_set_check("id", "");
                dg_doituong.f_set_check("id", "");
                dg_btdkp_bv.f_set_check("id", "");
                dg_d_dmnhomkho.f_set_check("id", "");
                dg_d_dmkho.f_set_check("id", "");
                dg_d_duockp.f_set_check("id", "");
                dg_d_dmnhom.f_set_check("id", "");
                dg_d_dmloaint.f_set_check("id", "");
                dg_d_dmkhac.f_set_check("id", "");

                foreach (DataRow r in v.get_data("select * from medibv.mdlogin where id=" + _id).Tables[0].Rows)
                {
                    txtUsername.Text = r["userid"].ToString();
                    txtPassword.Text = r["password_"].ToString();
                    txtHoten.Text = r["hoten"].ToString();
                    txtNgaysinh.Text = r["ngaysinh"].ToString();
                    txtDiachi.Text = r["diachi"].ToString();
                    txtDTNha.Text = r["dtnha"].ToString();
                    txtDTCoquan.Text = r["dtcoquan"].ToString();
                    txtDTDidong.Text = r["dtdidong"].ToString();
                    txtEmail.Text = r["email"].ToString();
                    try
                    {
                        cbGioitinh.SelectedValue = r["gioitinh"].ToString();
                    }
                    catch
                    {
                    }
                    chkAdmin.Checked = (r["admin_"].ToString() == "1");

                    chkPHBN.Checked = (r["id_m"].ToString() != "0");
                    chkPHVP.Checked = (r["id_v"].ToString() != "0");
                    chkPHD.Checked = (r["id_d"].ToString() != "0");
                    chkPHXN.Checked = (r["id_xn"].ToString() != "0");
                    chkPHCDHA.Checked = (r["id_cdha"].ToString() != "0");
                    chkPHNS.Checked = (r["id_ns"].ToString() != "0");
                    chkPHRP.Checked = (r["id_rp"].ToString() != "0");
                    chkPHCT.Checked = (r["id_ct"].ToString() != "0");

                    if (chkPHBN.Checked)
                    {
                        foreach (DataRow r1 in v.get_data("select * from medibv.dlogin where id=" + r["id_m"].ToString()).Tables[0].Rows)
                        {
                            try
                            {
                                cbNhomnv.SelectedValue = r1["manhom"].ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                cbBacsi.SelectedValue = r1["mabs"].ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                cbChinhanh.SelectedValue = r1["chinhanh"].ToString();
                            }
                            catch
                            {
                            }
                            chkDuyetcv.Checked = (r1["duyetcv"].ToString() == "1");
                            //chkTao.Checked = (r1["tao"].ToString() == "1");
                            //chkThuhoi.Checked = (r1["thuhoi"].ToString() == "1");
                            //chkMau38_duyetcls.Checked = (r1["cls38"].ToString() == "1");
                            //chkMau38_duyetthuoc.Checked = (r1["thuoc38"].ToString() == "1");

                            dg_dmkhudt.f_set_check("id", r1["khu"].ToString().Trim(',').Replace(",", "~"));
                            dg_doituong.f_set_check("id", r1["madoituong"].ToString().Trim(',').Replace(",", "~"));
                            dg_btdkp_bv.f_set_check("id", r1["makp"].ToString().Trim(',').Replace(",", "~"));
                            dg_d_dmnhomkho.f_set_check("id", r1["nhomkho"].ToString().Trim(',').Replace(",", "~"));
                            //dg_d_dmkho.f_set_check("id", r1["makho"].ToString().Trim(',').Replace(",","~"));
                            //dg_d_duockp.f_set_check("id", r1["makp"].ToString().Trim(',').Replace(",","~"));
                            //dg_d_dmnhom.f_set_check("id", r1["manhom"].ToString().Trim(',').Replace(",","~"));
                            //dg_d_dmloaint.f_set_check("id", r1["loaint"].ToString().Trim(',').Replace(",","~"));
                            //dg_d_dmkhac.f_set_check("id", r1["loaikhac"].ToString().Trim(',').Replace(",","~"));
                        }
                    }
                    if (chkPHVP.Checked)
                    {
                        foreach (DataRow r1 in v.get_data("select * from medibv.v_dlogin where id=" + r["id_v"].ToString()).Tables[0].Rows)
                        {
                            //try
                            //{
                            //    cbNhomnv.SelectedValue = r1["manhom"].ToString();
                            //}
                            //catch
                            //{
                            //}
                            //try
                            //{
                            //    cbBacsi.SelectedValue = r1["mabs"].ToString();
                            //}
                            //catch
                            //{
                            //}
                            //try
                            //{
                            //    cbChinhanh.SelectedValue = r1["chinhanh"].ToString();
                            //}
                            //catch
                            //{
                            //}
                            //chkDuyetcv.Checked = (r1["duyetcv"].ToString() == "1");
                            //chkTao.Checked = (r1["tao"].ToString() == "1");
                            //chkThuhoi.Checked = (r1["thuhoi"].ToString() == "1");
                            //chkMau38_duyetcls.Checked = (r1["cls38"].ToString() == "1");
                            //chkMau38_duyetthuoc.Checked = (r1["thuoc38"].ToString() == "1");

                            //dg_dmkhudt.f_set_check("id", r1["khu"].ToString().Trim(',').Replace(",","~"));
                            //dg_doituong.f_set_check("id", r1["madoituong"].ToString().Trim(',').Replace(",","~"));
                            //dg_btdkp_bv.f_set_check("id", r1["makp"].ToString().Trim(',').Replace(",","~"));
                            //dg_d_dmnhomkho.f_set_check("id", r1["nhomkho"].ToString().Trim(',').Replace(",","~"));
                            //dg_d_dmkho.f_set_check("id", r1["makho"].ToString().Trim(',').Replace(",","~"));
                            //dg_d_duockp.f_set_check("id", r1["makp"].ToString().Trim(',').Replace(",","~"));
                            //dg_d_dmnhom.f_set_check("id", r1["manhom"].ToString().Trim(',').Replace(",","~"));
                            //dg_d_dmloaint.f_set_check("id", r1["loaint"].ToString().Trim(',').Replace(",","~"));
                            //dg_d_dmkhac.f_set_check("id", r1["loaikhac"].ToString().Trim(',').Replace(",","~"));
                        }
                    }
                    if (chkPHD.Checked)
                    {
                        foreach (DataRow r1 in v.get_data("select * from medibv.d_dlogin where id=" + r["id_d"].ToString()).Tables[0].Rows)
                        {
                            //try
                            //{
                            //    cbNhomnv.SelectedValue = r1["manhom"].ToString();
                            //}
                            //catch
                            //{
                            //}
                            //try
                            //{
                            //    cbBacsi.SelectedValue = r1["mabs"].ToString();
                            //}
                            //catch
                            //{
                            //}
                            //try
                            //{
                            //    cbChinhanh.SelectedValue = r1["chinhanh"].ToString();
                            //}
                            //catch
                            //{
                            //}
                            //chkDuyetcv.Checked = (r1["duyetcv"].ToString() == "1");
                            chkTao.Checked = (r1["tao"].ToString() == "1");
                            chkThuhoi.Checked = (r1["thuhoi"].ToString() == "1");
                            chkMau38_duyetcls.Checked = (r1["cls38"].ToString() == "1");
                            chkMau38_duyetthuoc.Checked = (r1["thuoc38"].ToString() == "1");

                            //dg_dmkhudt.f_set_check("id", r1["khu"].ToString().Trim(',').Replace(",","~"));
                            //dg_doituong.f_set_check("id", r1["madoituong"].ToString().Trim(',').Replace(",","~"));
                            //dg_btdkp_bv.f_set_check("id", r1["makp"].ToString().Trim(',').Replace(",","~"));
                            //dg_d_dmnhomkho.f_set_check("id", r1["nhomkho"].ToString().Trim(',').Replace(",","~"));
                            dg_d_dmkho.f_set_check("id", r1["makho"].ToString().Trim(',').Replace(",", "~"));
                            dg_d_duockp.f_set_check("id", r1["makp"].ToString().Trim(',').Replace(",", "~"));
                            dg_d_dmnhom.f_set_check("id", r1["manhom"].ToString().Trim(',').Replace(",", "~"));
                            dg_d_dmloaint.f_set_check("id", r1["loaint"].ToString().Trim(',').Replace(",", "~"));
                            dg_d_dmkhac.f_set_check("id", r1["loaikhac"].ToString().Trim(',').Replace(",", "~"));
                        }
                    }

                    if (chkPHCDHA.Checked)
                    {
                        foreach (DataRow r1 in v.get_data("select * from medibv.cdha_dlogin where id=" + r["id_cdha"].ToString()).Tables[0].Rows)
                        {
                            //try
                            //{
                            //    cbNhomnv.SelectedValue = r1["manhom"].ToString();
                            //}
                            //catch
                            //{
                            //}
                            //try
                            //{
                            //    cbBacsi.SelectedValue = r1["mabs"].ToString();
                            //}
                            //catch
                            //{
                            //}
                            //try
                            //{
                            //    cbChinhanh.SelectedValue = r1["chinhanh"].ToString();
                            //}
                            //catch
                            //{
                            //}
                            //chkDuyetcv.Checked = (r1["duyetcv"].ToString() == "1");
                            chkTao.Checked = (r1["tao"].ToString() == "1");
                            chkThuhoi.Checked = (r1["thuhoi"].ToString() == "1");
                            chkMau38_duyetcls.Checked = (r1["cls38"].ToString() == "1");
                            chkMau38_duyetthuoc.Checked = (r1["thuoc38"].ToString() == "1");

                            //dg_dmkhudt.f_set_check("id", r1["khu"].ToString().Trim(',').Replace(",","~"));
                            //dg_doituong.f_set_check("id", r1["madoituong"].ToString().Trim(',').Replace(",","~"));
                            //dg_btdkp_bv.f_set_check("id", r1["makp"].ToString().Trim(',').Replace(",","~"));
                            //dg_d_dmnhomkho.f_set_check("id", r1["nhomkho"].ToString().Trim(',').Replace(",","~"));
                            dg_d_dmkho.f_set_check("id", r1["makho"].ToString().Trim(',').Replace(",", "~"));
                            dg_d_duockp.f_set_check("id", r1["makp"].ToString().Trim(',').Replace(",", "~"));
                            dg_d_dmnhom.f_set_check("id", r1["manhom"].ToString().Trim(',').Replace(",", "~"));
                            dg_d_dmloaint.f_set_check("id", r1["loaint"].ToString().Trim(',').Replace(",", "~"));
                            dg_d_dmkhac.f_set_check("id", r1["loaikhac"].ToString().Trim(',').Replace(",", "~"));
                        }
                    }


                    if (chkPHXN.Checked)
                    {
                        foreach (DataRow r1 in v.get_data("select * from medibv.xn_dlogin where id=" + r["id_xn"].ToString()).Tables[0].Rows)
                        {
                            //try
                            //{
                            //    cbNhomnv.SelectedValue = r1["manhom"].ToString();
                            //}
                            //catch
                            //{
                            //}
                            //try
                            //{
                            //    cbBacsi.SelectedValue = r1["mabs"].ToString();
                            //}
                            //catch
                            //{
                            //}
                            //try
                            //{
                            //    cbChinhanh.SelectedValue = r1["chinhanh"].ToString();
                            //}
                            //catch
                            //{
                            //}
                            //chkDuyetcv.Checked = (r1["duyetcv"].ToString() == "1");
                            chkTao.Checked = (r1["tao"].ToString() == "1");
                            chkThuhoi.Checked = (r1["thuhoi"].ToString() == "1");
                            chkMau38_duyetcls.Checked = (r1["cls38"].ToString() == "1");
                            chkMau38_duyetthuoc.Checked = (r1["thuoc38"].ToString() == "1");

                            //dg_dmkhudt.f_set_check("id", r1["khu"].ToString().Trim(',').Replace(",","~"));
                            //dg_doituong.f_set_check("id", r1["madoituong"].ToString().Trim(',').Replace(",","~"));
                            //dg_btdkp_bv.f_set_check("id", r1["makp"].ToString().Trim(',').Replace(",","~"));
                            //dg_d_dmnhomkho.f_set_check("id", r1["nhomkho"].ToString().Trim(',').Replace(",","~"));
                            dg_d_dmkho.f_set_check("id", r1["makho"].ToString().Trim(',').Replace(",", "~"));
                            dg_d_duockp.f_set_check("id", r1["makp"].ToString().Trim(',').Replace(",", "~"));
                            dg_d_dmnhom.f_set_check("id", r1["manhom"].ToString().Trim(',').Replace(",", "~"));
                            dg_d_dmloaint.f_set_check("id", r1["loaint"].ToString().Trim(',').Replace(",", "~"));
                            dg_d_dmkhac.f_set_check("id", r1["loaikhac"].ToString().Trim(',').Replace(",", "~"));
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void f_Enable(bool v_bool)
        {
            try
            {
                butAdd.Enabled = !v_bool;
                butSave.Enabled = v_bool;
                butEdit.Enabled = !v_bool && _id != "0";
                butDel.Enabled = !v_bool && _id != "0";
                butCancel.Enabled = v_bool;
                butKetthuc.Enabled = true;

                txtUsername.Enabled = v_bool;
                txtPassword.Enabled = v_bool;
                txtHoten.Enabled = v_bool;
                txtNgaysinh.Enabled = v_bool;
                txtDiachi.Enabled = v_bool;
                txtDTNha.Enabled = v_bool;
                txtDTCoquan.Enabled = v_bool;
                txtDTDidong.Enabled = v_bool;
                txtEmail.Enabled = v_bool;
                cbGioitinh.Enabled = v_bool;
                cbBacsi.Enabled = v_bool;
                cbChinhanh.Enabled = v_bool;
                cbNhomnv.Enabled = v_bool;

                chkTao.Enabled = v_bool;
                chkThuhoi.Enabled = v_bool;
                chkMau38_duyetcls.Enabled = v_bool;
                chkMau38_duyetthuoc.Enabled = v_bool;

                chkAdmin.Enabled = v_bool;
                chkPHBN.Enabled = v_bool;
                chkPHVP.Enabled = v_bool;
                chkPHD.Enabled = v_bool;
                chkPHXN.Enabled = v_bool;
                chkPHCDHA.Enabled = v_bool;
                chkPHNS.Enabled = v_bool;
                chkPHRP.Enabled = v_bool;
                chkPHCT.Enabled = v_bool;

                dg_dmkhudt.Enabled = v_bool;
                dg_doituong.Enabled = v_bool;
                dg_btdkp_bv.Enabled = v_bool;
                dg_d_dmnhomkho.Enabled = v_bool;
                dg_d_dmkho.Enabled = v_bool;
                dg_d_duockp.Enabled = v_bool;
                dg_d_dmnhom.Enabled = v_bool;
                dg_d_dmloaint.Enabled = v_bool;
                dg_d_dmkhac.Enabled = v_bool;
            }
            catch
            {
            }
        }
        private void f_Add()
        {
            try
            {
                _id = "";
                f_Load_User();
                f_Enable(true);
                txtUsername.Focus();
            }
            catch
            {
            }
        }
        private void f_Save()
        {
            try
            {
                f_Enable(false);
                string auserid = txtUsername.Text.Replace("'", "").Trim();
                string apassword_ = txtPassword.Text.Replace("'", "").Trim();
                string ahoten = txtHoten.Text.Replace("'", "").Trim();
                string angaysinh = txtNgaysinh.Text.Replace("'", "").Trim();
                string adiachi = txtDiachi.Text.Replace("'", "").Trim();
                string adtnha = txtDTNha.Text.Replace("'", "").Trim();
                string adtcoquan = txtDTCoquan.Text.Replace("'", "").Trim();
                string adtdidong = txtDTDidong.Text.Replace("'", "").Trim();
                string aemail = txtEmail.Text.Replace("'", "").Trim();
                string agioitinh = cbGioitinh.SelectedValue.ToString().Trim();
                string anhomnv = cbNhomnv.SelectedValue.ToString().Trim();
                string abacsi = cbBacsi.SelectedValue.ToString().Trim();
                string achinhanh = cbChinhanh.SelectedValue.ToString().Trim();
                string aadmin_ = chkAdmin.Checked ? "1" : "0";
                string atao = chkTao.Checked ? "1" : "0";
                string athuhoi = chkThuhoi.Checked ? "1" : "0";
                string amau38_duyetcls = chkMau38_duyetcls.Checked ? "1" : "0";
                string amau38_duyenthuoc = chkMau38_duyetthuoc.Checked ? "1" : "0";
                string aduyetcv = chkDuyetcv.Checked ? "1" : "0";
                string aid_m = "0";
                string aid_v = "0";
                string aid_d = "0";
                string aid_xn = "0";
                string aid_cdha = "0";
                string aid_ns = "0";
                string aid_rp = "0";
                string aid_ct = "0";

                string akhudt = dg_dmkhudt.f_get_check("id");
                string adoituong = dg_doituong.f_get_check("id");
                string abtdkp_bv = dg_btdkp_bv.f_get_check("id").Replace("'", "");
                string ad_dmnhomkho = dg_d_dmnhomkho.f_get_check("id");
                string ad_dmkho = dg_d_dmkho.f_get_check("id");
                string ad_duockp = dg_d_duockp.f_get_check("id");
                string ad_dmnhom = dg_d_dmnhom.f_get_check("id");
                string ad_dmloaint = dg_d_dmloaint.f_get_check("id");
                string ad_dmkhac = dg_d_dmkhac.f_get_check("id");

                if (akhudt != "") akhudt += ",";
                if (adoituong != "") adoituong += ",";
                if (abtdkp_bv != "") abtdkp_bv += ",";
                if (ad_dmnhomkho != "") ad_dmnhomkho += ",";
                if (ad_dmkho != "") ad_dmkho += ",";
                if (ad_duockp != "") ad_duockp += ",";
                if (ad_dmnhom != "") ad_dmnhom += ",";
                if (ad_dmloaint != "") ad_dmloaint += ",";
                if (ad_dmkhac != "") ad_dmkhac += ",";

                if (_id == "")
                {
                    _id = "0";
                }

                if (ahoten == "")
                {
                    MessageBox.Show(this, "Nhập họ tên!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    f_Enable(true);
                    txtHoten.Focus();
                    return;
                }
                if (auserid == "")
                {
                    MessageBox.Show(this, "Nhập tên đăng nhập!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    f_Enable(true);
                    txtUsername.Focus();
                    return;
                }
                if (apassword_ == "")
                {
                    MessageBox.Show(this, "Nhập mật khẩu!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    f_Enable(true);
                    txtPassword.Focus();
                    return;
                }
                if (txtPassword.Text != txtPassword1.Text)
                {
                    MessageBox.Show(this, "Xác nhận mậ khẩu không đúng!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    f_Enable(true);
                    txtPassword1.Focus();
                    return;
                }
                foreach (DataRow r in v.get_data("select * from medibv.mdlogin where id=" + _id).Tables[0].Rows)
                {
                    aid_m = r["id_m"].ToString();
                    aid_v = r["id_v"].ToString();
                    aid_d = r["id_d"].ToString();
                    aid_xn = r["id_xn"].ToString();
                    aid_cdha = r["id_cdha"].ToString();
                    aid_ns = r["id_ns"].ToString();
                    aid_rp = r["id_rp"].ToString();
                    aid_ct = r["id_ct"].ToString();
                }

                if (v.get_data("select * from medibv.mdlogin where userid='" + auserid + "' and id<>" + _id).Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(this, "Tên đăng nhập đã tồn tại!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    f_Enable(true);
                    txtUsername.Focus();
                    return;
                }
                if (ad_dmnhomkho == "")
                {
                    ad_dmnhomkho = "0,";
                }
                //xoa cac ban con
                if (!chkPHBN.Checked)
                {
                    //v.execute_data("delete from medibv.dlogin where id in (select id_m from medibv.mdlogin where id=" + _id + ")");
                    //aid_m = "0";
                }
                if (!chkPHVP.Checked)
                {
                    //v.execute_data("delete from medibv.v_dlogin where id in (select id_v from medibv.mdlogin where id=" + _id + ")");
                    //aid_v = "0";
                }
                if (!chkPHD.Checked)
                {
                    //v.execute_data("delete from medibv.d_dlogin where id in (select id_d from medibv.mdlogin where id=" + _id + ")");
                    //aid_d = "0";
                }
                if (!chkPHXN.Checked)
                {
                    //v.execute_data("delete from medibv.xn_dlogin where id in (select id_xn from medibv.mdlogin where id=" + _id + ")");
                    //aid_xn = "0";
                }
                if (!chkPHCDHA.Checked)
                {
                    //v.execute_data("delete from medibv.cdha_dlogin where id in (select id_cdha from medibv.mdlogin where id=" + _id + ")");
                    //aid_cdha = "0";
                }
                if (!chkPHNS.Checked)
                {
                    //v.execute_data("delete from medibv.ns_dlogin where id in (select id_ns from medibv.mdlogin where id=" + _id + ")");
                    //aid_ns = "0";
                }
                if (!chkPHRP.Checked)
                {
                    //v.execute_data("delete from medibv.bc_dlogin where id in (select id_rp from medibv.mdlogin where id=" + _id + ")");
                    //aid_rp = "0";
                }
                if (!chkPHRP.Checked)
                {
                    //v.execute_data("delete from medibv.bc_dlogin where id in (select id_rp from medibv.mdlogin where id=" + _id + ")");
                    //aid_rp = "0";
                }
                if (!chkPHCT.Checked)
                {
                    //v.execute_data("delete from medibv.ct_dlogin where id in (select id_ct from medibv.mdlogin where id=" + _id + ")");
                    //aid_rp = "0";
                }

                //them cac ban con
                if (chkPHBN.Checked)
                {
                    if (aid_m == "0")
                    {
                        try
                        {
                            aid_m = decimal.Parse(v.get_data("select max(id)+1 as id from medibv.dlogin").Tables[0].Rows[0][0].ToString()).ToString();
                        }
                        catch
                        {
                            aid_m = "1";
                        }
                        v.execute_data("insert into medibv.dlogin(id,userid,password_,hoten,manhom,makp,madoituong,nhomkho,mabs,chinhanh,khu,duyetcv) values(" + aid_m + ",'" + auserid + "','" + apassword_ + "','" + ahoten + "'," + anhomnv + ",'" + abtdkp_bv + "','" + adoituong + "','" + ad_dmnhomkho + "','" + abacsi + "'," + achinhanh + ",'" + akhudt + "'," + aduyetcv + ")");
                        v.execute_data("insert into medibv.dlogin(id,userid,password_,hoten,manhom,makp,madoituong,nhomkho,mabs,chinhanh,khu,duyetcv) values(" + aid_m + ",'" + auserid + "','" + apassword_ + "','" + ahoten + "'," + anhomnv + ",'" + abtdkp_bv + "','" + adoituong + "','" + ad_dmnhomkho + "','" + abacsi + "'," + achinhanh + ",'" + akhudt + "'," + aduyetcv + ")");
                    }
                    else
                    {
                        v.execute_data("update medibv.dlogin set userid='" + auserid + "',password_='" + apassword_ + "',hoten='" + ahoten + "',manhom=" + anhomnv + ",makp='" + abtdkp_bv + "',madoituong='" + adoituong + "',nhomkho='" + ad_dmnhomkho + "',mabs='" + abacsi + "',chinhanh=" + achinhanh + ",khu='" + akhudt + "',duyetcv=" + aduyetcv + " where id=" + aid_m);
                        v.execute_data("update medibv.dlogin set userid='" + auserid + "',password_='" + apassword_ + "',hoten='" + ahoten + "',manhom=" + anhomnv + ",makp='" + abtdkp_bv + "',madoituong='" + adoituong + "',nhomkho='" + ad_dmnhomkho + "',mabs='" + abacsi + "',chinhanh=" + achinhanh + ",khu='" + akhudt + "',duyetcv=" + aduyetcv + " where id=" + aid_m);
                    }
                }
                if (chkPHVP.Checked)
                {
                    if (aid_v == "0")
                    {
                        try
                        {
                            aid_v = decimal.Parse(v.get_data("select max(id)+1 as id from medibv.v_dlogin").Tables[0].Rows[0][0].ToString()).ToString();
                        }
                        catch
                        {
                            aid_v = "1";
                        }
                        v.execute_data("insert into medibv.v_dlogin(id,userid,password_,hoten,id_nhom,khudt,chinhanh) values(" + aid_v + ",'" + auserid + "','" + apassword_ + "','" + ahoten + "'," + anhomnv + ",'" + akhudt + "'," + achinhanh + ")");
                        v.execute_data("insert into medibv.v_dlogin(id,userid,password_,hoten,id_nhom,khudt,chinhanh) values(" + aid_v + ",'" + auserid + "','" + apassword_ + "','" + ahoten + "'," + anhomnv + ",'" + akhudt + "'," + achinhanh + ")");
                    }
                    else
                    {
                        v.execute_data("update medibv.v_dlogin set userid='" + auserid + "',password_='" + apassword_ + "',hoten='" + ahoten + "',id_nhom=" + anhomnv + ",khudt='" + akhudt + "',chinhanh=" + achinhanh + " where id=" + aid_v);
                        v.execute_data("update medibv.v_dlogin set userid='" + auserid + "',password_='" + apassword_ + "',hoten='" + ahoten + "',id_nhom=" + anhomnv + ",khudt='" + akhudt + "',chinhanh=" + achinhanh + " where id=" + aid_v);
                    }
                }
                if (chkPHD.Checked)
                {
                    if (aid_d == "0")
                    {
                        try
                        {
                            aid_d = decimal.Parse(v.get_data("select max(id)+1 as id from medibv.d_dlogin").Tables[0].Rows[0][0].ToString()).ToString();
                        }
                        catch
                        {
                            aid_d = "1";
                        }
                        v.execute_data("insert into medibv.d_dlogin(id,userid,password_,hoten,admin,tao,thuhoi,thuoc38,cls38,nhomkho," +
                            "makho,makp,manhom,loaint,loaikhac,khu,chinhanh) values(" + aid_d + ",'" + auserid + "','" + apassword_ + "','" +
                            ahoten + "'," + aadmin_ + "," + atao + "," + athuhoi + "," + amau38_duyenthuoc + "," + amau38_duyetcls + "," +
                            ad_dmnhomkho + ",'" + ad_dmkho + "','" + ad_duockp + "','" + ad_dmnhomkho + "','" + ad_dmloaint + "','" + ad_dmkhac +
                            "','" + akhudt + "'," + achinhanh + ")");
                        v.execute_data("insert into medibv.d_dlogin(id,userid,password_,hoten,admin,tao,thuhoi,thuoc38,cls38,nhomkho," +
                            "makho,makp,manhom,loaint,loaikhac,khu,chinhanh) values(" + aid_d + ",'" + auserid + "','" + apassword_ + "','" +
                            ahoten + "'," + aadmin_ + "," + atao + "," + athuhoi + "," + amau38_duyenthuoc + "," + amau38_duyetcls + "," +
                            ad_dmnhomkho + ",'" + ad_dmkho + "','" + ad_duockp + "','" + ad_dmnhomkho + "','" + ad_dmloaint + "','" + ad_dmkhac +
                            "','" + akhudt + "'," + achinhanh + ")");
                    }
                    else
                    {
                        v.execute_data("update medibv.d_dlogin set userid='" + auserid + "',password_='" + apassword_ + "',hoten='" + ahoten + "',admin=" + aadmin_ + ",tao=" + atao + ",thuhoi=" + athuhoi + ",thuoc38=" + amau38_duyenthuoc + ",cls38=" + amau38_duyetcls + ",nhomkho='" + ad_dmnhomkho + "',makho='" + ad_dmkho + "',makp='" + ad_duockp + "',manhom='" + ad_dmnhomkho + "',loaint='" + ad_dmloaint + "',loaikhac='" + ad_dmkhac + "',khu='" + akhudt + "',chinhanh=" + achinhanh + " where id=" + aid_d);
                        v.execute_data("update medibv.d_dlogin set userid='" + auserid + "',password_='" + apassword_ + "',hoten='" + ahoten + "',admin=" + aadmin_ + ",tao=" + atao + ",thuhoi=" + athuhoi + ",thuoc38=" + amau38_duyenthuoc + ",cls38=" + amau38_duyetcls + ",nhomkho='" + ad_dmnhomkho + "',makho='" + ad_dmkho + "',makp='" + ad_duockp + "',manhom='" + ad_dmnhomkho + "',loaint='" + ad_dmloaint + "',loaikhac='" + ad_dmkhac + "',khu='" + akhudt + "',chinhanh=" + achinhanh + " where id=" + aid_d);
                    }
                }
                if (chkPHXN.Checked)
                {
                    if (aid_xn == "0")
                    {
                        try
                        {
                            aid_xn = decimal.Parse(v.get_data("select max(id)+1 as id from medibv.xn_dlogin").Tables[0].Rows[0][0].ToString()).ToString();
                        }
                        catch
                        {
                            aid_xn = "1";
                        }
                        v.execute_data("insert into medibv.xn_dlogin(id,userid,password_,hoten,id_nhom,makp,idchinhanh) values(" + aid_xn + ",'" + auserid + "','" + apassword_ + "','" + ahoten + "'," + anhomnv + ",'" + abtdkp_bv + "'," + achinhanh + ")");
                        v.execute_data("insert into medibv.xn_dlogin(id,userid,password_,hoten,id_nhom,makp,idchinhanh) values(" + aid_xn + ",'" + auserid + "','" + apassword_ + "','" + ahoten + "'," + anhomnv + ",'" + abtdkp_bv + "'," + achinhanh + ")");
                    }
                    else
                    {
                        v.execute_data("update medibv.xn_dlogin set userid='" + auserid + "',password_='" + apassword_ + "',hoten='" + ahoten + "',id_nhom=" + anhomnv + ",makp='" + abtdkp_bv + "',idchinhanh=" + achinhanh + " where id=" + aid_xn);
                        v.execute_data("update medibv.xn_dlogin set userid='" + auserid + "',password_='" + apassword_ + "',hoten='" + ahoten + "',id_nhom=" + anhomnv + ",makp='" + abtdkp_bv + "',idchinhanh=" + achinhanh + " where id=" + aid_xn);
                    }
                }
                if (chkPHCDHA.Checked)
                {
                    if (aid_cdha == "0")
                    {
                        try
                        {
                            aid_cdha = decimal.Parse(v.get_data("select max(id)+1 as id from medibv.cdha_dlogin").Tables[0].Rows[0][0].ToString()).ToString();
                        }
                        catch
                        {
                            aid_cdha = "1";
                        }
                        v.execute_data("insert into medibv.cdha_dlogin(id,userid,password_,hoten,idchinhanh) values(" + aid_cdha + ",'" + auserid + "','" + apassword_ + "','" + ahoten + "'," + achinhanh + ")");
                        v.execute_data("insert into medibv.cdha_dlogin(id,userid,password_,hoten,idchinhanh) values(" + aid_cdha + ",'" + auserid + "','" + apassword_ + "','" + ahoten + "'," + achinhanh + ")");
                    }
                    else
                    {
                        v.execute_data("update medibv.cdha_dlogin set userid='" + auserid + "',password_='" + apassword_ + "',hoten='" + ahoten + "', chinhanh=" + achinhanh + " where id=" + aid_cdha);
                        v.execute_data("update medibv.cdha_dlogin set userid='" + auserid + "',password_='" + apassword_ + "',hoten='" + ahoten + "', chinhanh=" + achinhanh + " where id=" + aid_cdha);
                    }
                }
                if (chkPHNS.Checked)
                {
                    if (aid_ns == "0")
                    {
                        try
                        {
                            aid_ns = decimal.Parse(v.get_data("select max(id)+1 as id from nhansu.pwhuman").Tables[0].Rows[0][0].ToString()).ToString();
                        }
                        catch
                        {
                            aid_ns = "1";
                        }
                        v.execute_data("insert into nhansu.pwhuman(id,username,pass,ten) values(" + aid_ns + ",'" + auserid + "','" + apassword_ + "','" + ahoten + "')");
                    }
                    else
                    {
                        v.execute_data("update nhansu.pwhuman set userid='" + auserid + "',password_='" + apassword_ + "',hoten='" + ahoten + "' where id=" + aid_ns);
                    }
                }
                if (chkPHRP.Checked)
                {
                    if (aid_rp == "0")
                    {
                        try
                        {
                            aid_rp = decimal.Parse(v.get_data("select max(id)+1 as id from medibv.bc_dlogin").Tables[0].Rows[0][0].ToString()).ToString();
                        }
                        catch
                        {
                            aid_rp = "1";
                        }
                        v.execute_data("insert into medibv.bc_dlogin(id,userid,password_,hoten) values(" + aid_rp + ",'" + auserid + "','" + apassword_ + "','" + ahoten + "')");
                        v.execute_data("insert into medibv.bc_dlogin(id,userid,password_,hoten) values(" + aid_rp + ",'" + auserid + "','" + apassword_ + "','" + ahoten + "')");
                    }
                    else
                    {
                        v.execute_data("update medibv.bc_dlogin set userid='" + auserid + "',password_='" + apassword_ + "',hoten='" + ahoten + "' where id=" + aid_rp);
                        v.execute_data("update medibv.bc_dlogin set userid='" + auserid + "',password_='" + apassword_ + "',hoten='" + ahoten + "' where id=" + aid_rp);
                    }
                }
                if (chkPHCT.Checked)
                {
                    if (aid_ct == "0")
                    {
                        try
                        {
                            aid_ct = decimal.Parse(v.get_data("select max(id)+1 as id from medibv.ct_dlogin").Tables[0].Rows[0][0].ToString()).ToString();
                        }
                        catch
                        {
                            aid_ct = "1";
                        }
                        v.execute_data("insert into medibv.ct_dlogin(id,userid,password_,hoten) values(" + aid_ct + ",'" + auserid + "','" + apassword_ + "','" + ahoten + "')");
                        v.execute_data("insert into medibv.ct_dlogin(id,userid,password_,hoten) values(" + aid_ct + ",'" + auserid + "','" + apassword_ + "','" + ahoten + "')");
                    }
                    else
                    {
                        v.execute_data("update medibv.ct_dlogin set userid='" + auserid + "',password_='" + apassword_ + "',hoten='" + ahoten + "' where id=" + aid_ct);
                        v.execute_data("update medibv.ct_dlogin set userid='" + auserid + "',password_='" + apassword_ + "',hoten='" + ahoten + "' where id=" + aid_ct);
                    }
                }

                if (_id == "0")
                {
                    try
                    {
                        _id = decimal.Parse(v.get_data("select max(id)+1 as id from medibv.mdlogin").Tables[0].Rows[0][0].ToString()).ToString();
                    }
                    catch
                    {
                        _id = "1";
                    }
                    v.execute_data("insert into medibv.mdlogin(id,userid,password_,hoten,ngaysinh,gioitinh,diachi,dtnha,dtcoquan,dtdidong,email,admin_,id_m,id_v,id_d,id_xn,id_cdha,id_ns,id_rp,id_ct) values(" + _id + ",'" + auserid + "','" + apassword_ + "','" + ahoten + "','" + angaysinh + "'," + agioitinh + ",'" + adiachi + "','" + adtnha + "','" + adtcoquan + "','" + adtdidong + "','" + aemail + "'," + aadmin_ + "," + aid_m + "," + aid_v + "," + aid_d + "," + aid_xn + "," + aid_cdha + "," + aid_ns + "," + aid_rp + "," + aid_ct + ")");
                    v.execute_data("insert into medibv.mdlogin(id,userid,password_,hoten,ngaysinh,gioitinh,diachi,dtnha,dtcoquan,dtdidong,email,admin_,id_m,id_v,id_d,id_xn,id_cdha,id_ns,id_rp,id_ct) values(" + _id + ",'" + auserid + "','" + apassword_ + "','" + ahoten + "','" + angaysinh + "'," + agioitinh + ",'" + adiachi + "','" + adtnha + "','" + adtcoquan + "','" + adtdidong + "','" + aemail + "'," + aadmin_ + "," + aid_m + "," + aid_v + "," + aid_d + "," + aid_xn + "," + aid_cdha + "," + aid_ns + "," + aid_rp + "," + aid_ct + ")");
                }
                else
                {
                    v.execute_data("update medibv.mdlogin set userid='" + auserid + "',password_='" + apassword_ + "',hoten='" + ahoten + "',ngaysinh='" + angaysinh + "',diachi='" + adiachi + "',dtnha='" + adtnha + "',dtcoquan='" + adtcoquan + "',dtdidong='" + adtdidong + "',email='" + aemail + "',gioitinh=" + agioitinh + ",admin_=" + aadmin_ + ",id_m=" + aid_m + ",id_v=" + aid_v + ",id_d=" + aid_d + ",id_xn=" + aid_xn + ",id_cdha=" + aid_cdha + ",id_ns=" + aid_ns + ",id_rp=" + aid_rp + ",id_ct=" + aid_ct + " where id=" + _id);
                    v.execute_data("update medibv.mdlogin set userid='" + auserid + "',password_='" + apassword_ + "',hoten='" + ahoten + "',ngaysinh='" + angaysinh + "',diachi='" + adiachi + "',dtnha='" + adtnha + "',dtcoquan='" + adtcoquan + "',dtdidong='" + adtdidong + "',email='" + aemail + "',gioitinh=" + agioitinh + ",admin_=" + aadmin_ + ",id_m=" + aid_m + ",id_v=" + aid_v + ",id_d=" + aid_d + ",id_xn=" + aid_xn + ",id_cdha=" + aid_cdha + ",id_ns=" + aid_ns + ",id_rp=" + aid_rp + ",id_ct=" + aid_ct + " where id=" + _id);
                }
                butEdit.Focus();
            }
            catch
            {
            }
        }
        private void f_Edit()
        {
            try
            {
                f_Enable(true);
                txtUsername.Focus();
            }
            catch
            {
            }
        }
        private void f_Del()
        {
            try
            {
                if (MessageBox.Show(this, "Đồng ý xóa?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    v.execute_data("delete from medibv.mdlogin where id="+_id);
                    v.execute_data("delete from medibv.mdlogin where id=" + _id);
                    _id = "0";
                    f_Load_User();
                }
            }
            catch
            {
            }
        }
        private void f_Cancel()
        {
            try
            {
                f_Load_User();
                f_Enable(false);
            }
            catch
            {
            }
        }

        private void frmMThongtinnguoidung_Load(object sender, EventArgs e)
        {
            f_load_data();
            f_Load_User();
            f_Enable(false);
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            f_Add();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            f_Save();
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            f_Edit();
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            f_Del();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            f_Cancel();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}{F4}");
                }
            }
            catch
            {
            }
        }

        private void txtControl_Enter(object sender, EventArgs e)
        {
            try
            {
                Control ac = (Control)(sender);
                ac.BackColor = Color.LightYellow;
            }
            catch
            {
            }
        }

        private void txtControl_Leave(object sender, EventArgs e)
        {
            try
            {
                Control ac = (Control)(sender);
                ac.BackColor = Color.White;
            }
            catch
            {
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

    }
}