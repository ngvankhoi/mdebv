using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmHieuchinh_Stt_tonkho : Form
    {
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private string sql = "", user = "", mmyy = "", user_sau = "";
        private int i_makho, i_makho_nhap, i_makp;
        public frmHieuchinh_Stt_tonkho(LibVP.AccessData v)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            this.m_v = v;
        }

        private void frmHieuchinh_Stt_tonkho_Load(object sender, EventArgs e)
        {
            this.thang.Value = decimal.Parse(DateTime.Now.Month.ToString());
            decimal dt = decimal.Parse(DateTime.Now.Year.ToString());
            this.nam.Maximum = dt + 3;
            this.nam.Value = dt;

            cboNhomkho.DisplayMember = "TEN";
            cboNhomkho.ValueMember = "ID";
            cboNhomkho.DataSource = m_v.get_data("select * from medibv.d_dmnhomkho order by id").Tables[0];

            cboKho.DisplayMember = "TEN";
            cboKho.ValueMember = "ID";

            cboTutruc.DisplayMember = "TEN";
            cboTutruc.ValueMember = "ID";

            cboKhoNhap.DisplayMember = "TEN";
            cboKhoNhap.ValueMember = "ID";

            load_kho();
            load_tutruc();
            load_kho_nhap();
            cboTutruc.Visible = false;
        }
        private void load_tutruc()
        {
            try
            {
                cboTutruc.DataSource = m_v.get_data("select * from medibv.d_duockp where nhom like '%" + int.Parse(cboNhomkho.SelectedValue.ToString()) + "%' order by id").Tables[0];
            }
            catch { }
        }

        private void load_kho()
        {
            try
            {
                cboKho.DataSource = m_v.get_data("select * from medibv.d_dmkho where nhom=" + int.Parse(cboNhomkho.SelectedValue.ToString()) + " order by id").Tables[0];
            }
            catch { }
        }

        private void load_kho_nhap()
        {
            try
            {
                cboKhoNhap.DataSource = m_v.get_data("select * from medibv.d_dmkho where nhom=" + int.Parse(cboNhomkho.SelectedValue.ToString()) + " and id <> "+int.Parse(cboKho.SelectedValue.ToString())+" order by id").Tables[0];
            }
            catch { }
        }


        private void cboNhomkho_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_kho();
            load_kho_nhap();
        }

        private void cboKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_kho_nhap();
        }

        private void butCapnhat_Click(object sender, EventArgs e)
        {
            decimal l_sttt = 0;
            mmyy = thang.Value.ToString().PadLeft(2, '0') + nam.Value.ToString().Substring(2);
            user = m_v.user + mmyy;
            user_sau = m_v.user + (thang.Value + 1).ToString().PadLeft(2, '0') + nam.Value.ToString().Substring(2);

            i_makho = int.Parse(cboKho.SelectedValue.ToString());
            i_makho_nhap = int.Parse(cboKhoNhap.SelectedValue.ToString());
            i_makp = int.Parse(cboTutruc.SelectedValue.ToString());

            DataSet dsdm = get_dmbd();
            DataSet dstutruc_sau = get_tutruc_sau();
            DataRow row = null;

            this.Refresh();

            if (!chkTutruc.Checked)
            {
                #region Chuyển STTT tồn đầu nhà thuốc(để không trùng với STTT kho chẳn để sửa giá các kho)
                foreach (DataRow r in get_tondau_chuaxuat().Tables[0].Rows)
                {
                    l_sttt = m_v.get_id_tonkho;
                    if (m_v.upd_theodoi(mmyy, l_sttt, int.Parse(r["mabd"].ToString()), int.Parse(r["manguon"].ToString()), int.Parse(r["nhomcc"].ToString()), r["handung"].ToString(), r["losx"].ToString(), "", "", "", 0, 0, 0, decimal.Parse(r["giamua"].ToString()), decimal.Parse(r["giaban"].ToString()), decimal.Parse(r["gianovat"].ToString()), 0, 0))
                    {
                        m_v.execute_data("update " + user + ".d_tonkhoct set stt=" + l_sttt + " where mabd=" + int.Parse(r["mabd"].ToString()) + " and makho=" + i_makho + " and stt=" + decimal.Parse(r["stt"].ToString()));
                        row = m_v.getrowbyid(dsdm.Tables[0], "id=" + int.Parse(r["mabd"].ToString()));
                        if (row != null)
                        {
                            lShow.Text = row["ten"].ToString() + " - - - - " + l_sttt.ToString();
                        }
                    }
                    this.Refresh();
                }
                //
                foreach (DataRow r in get_tondau_daxuat_khongcotrongtondaukhonhap().Tables[0].Rows)
                {
                    l_sttt = m_v.get_id_tonkho;
                    if (m_v.upd_theodoi(mmyy, l_sttt, int.Parse(r["mabd"].ToString()), int.Parse(r["manguon"].ToString()), int.Parse(r["nhomcc"].ToString()), r["handung"].ToString(), r["losx"].ToString(), "", "", "", 0, 0, 0, decimal.Parse(r["giamua"].ToString()), decimal.Parse(r["giaban"].ToString()), decimal.Parse(r["gianovat"].ToString()), 0, 0))
                    {
                        m_v.execute_data("update " + user + ".d_tonkhoct set stt=" + l_sttt + " where mabd=" + int.Parse(r["mabd"].ToString()) + " and makho=" + i_makho + " and stt=" + decimal.Parse(r["stt"].ToString()));
                        m_v.execute_data("update " + user + ".d_xuatct set sttt=" + l_sttt + " where id in (select id from " + user + ".d_xuatll where khox=" + i_makho + ") and mabd=" + int.Parse(r["mabd"].ToString()) + " and sttt=" + decimal.Parse(r["stt"].ToString()));
                        row = m_v.getrowbyid(dsdm.Tables[0], "id=" + int.Parse(r["mabd"].ToString()));
                        if (row != null)
                        {
                            lShow.Text = row["ten"].ToString() + " - - - - " + l_sttt.ToString();
                        }
                    }
                    this.Refresh();
                }
                //
                decimal d_tondau = 0;
                foreach (DataRow r in get_tondau_daxuat_cotrongtondaukhonhap().Tables[0].Rows)
                {
                    l_sttt = m_v.get_id_tonkho;
                    DataRow rr = m_v.getrowbyid(get_tondau_khonhap().Tables[0], "stt=" + decimal.Parse(r["stt"].ToString()));
                    if (rr != null)
                    {
                        if (decimal.Parse(rr["tondau"].ToString()) >= decimal.Parse(rr["slxuat"].ToString()))
                        {
                            m_v.upd_theodoi(mmyy, l_sttt, int.Parse(r["mabd"].ToString()), int.Parse(r["manguon"].ToString()), int.Parse(r["nhomcc"].ToString()), r["handung"].ToString(), r["losx"].ToString(), "", "", "", 0, 0, 0, decimal.Parse(r["giamua"].ToString()), decimal.Parse(r["giaban"].ToString()), decimal.Parse(r["gianovat"].ToString()), 0, 0);
                            if (!m_v.upd_tonkhoct(mmyy, i_makho_nhap, l_sttt, int.Parse(rr["mabd"].ToString()), decimal.Parse(rr["slnhap"].ToString()), "slnhap"))
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin tồn kho !"), m_v.s_AppName);
                                return;
                            }
                            m_v.execute_data("update " + user + ".d_tonkhoct set slnhap=0 where makho=" + i_makho_nhap + " and stt=" + decimal.Parse(rr["stt"].ToString()));
                            m_v.execute_data("update " + user + ".d_tonkhoth set slnhap=0 where makho=" + i_makho_nhap + " and mabd=" + int.Parse(rr["mabd"].ToString()));
                            m_v.upd_tonkhoth(mmyy, i_makho_nhap, int.Parse(rr["manguon"].ToString()), int.Parse(rr["mabd"].ToString()), decimal.Parse(rr["slnhap"].ToString()), "slnhap");
                            m_v.execute_data("update " + user + ".d_tonkhoct set stt=" + l_sttt + " where mabd=" + int.Parse(rr["mabd"].ToString()) + " and makho=" + i_makho + " and stt=" + decimal.Parse(rr["stt"].ToString()));
                            m_v.execute_data("update " + user + ".d_xuatct set sttt=" + l_sttt + " where id in (select id from " + user + ".d_xuatll where khox=" + i_makho + ") and mabd=" + int.Parse(rr["mabd"].ToString()) + " and sttt=" + decimal.Parse(rr["stt"].ToString()));
                            row = m_v.getrowbyid(dsdm.Tables[0], "id=" + int.Parse(r["mabd"].ToString()));
                            if (row != null)
                            {
                                lShow.Text = row["ten"].ToString() + " - - - - " + l_sttt.ToString();
                            }
                            this.Refresh();
                        }
                        else
                        {
                            d_tondau = decimal.Parse(rr["tondau"].ToString());
                            decimal d_soluong = 0;
                            //Upd so luong nhap
                            m_v.upd_theodoi(mmyy, l_sttt, int.Parse(r["mabd"].ToString()), int.Parse(r["manguon"].ToString()), int.Parse(r["nhomcc"].ToString()), r["handung"].ToString(), r["losx"].ToString(), "", "", "", 0, 0, 0, decimal.Parse(r["giamua"].ToString()), decimal.Parse(r["giaban"].ToString()), decimal.Parse(r["gianovat"].ToString()), 0, 0);
                            if (!m_v.upd_tonkhoct(mmyy, i_makho_nhap, l_sttt, int.Parse(rr["mabd"].ToString()), decimal.Parse(rr["slnhap"].ToString()), "slnhap"))
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin tồn kho !"), m_v.s_AppName);
                                return;
                            }
                            m_v.execute_data("update " + user + ".d_tonkhoct set slnhap=0 where makho=" + i_makho_nhap + " and stt=" + decimal.Parse(rr["stt"].ToString()));
                            m_v.execute_data("update " + user + ".d_tonkhoth set slnhap=0 where makho=" + i_makho_nhap + " and mabd=" + int.Parse(rr["mabd"].ToString()));
                            m_v.upd_tonkhoth(mmyy, i_makho_nhap, int.Parse(rr["manguon"].ToString()), int.Parse(rr["mabd"].ToString()), decimal.Parse(rr["slnhap"].ToString()), "slnhap");
                            m_v.execute_data("update " + user + ".d_tonkhoct set stt=" + l_sttt + " where mabd=" + int.Parse(rr["mabd"].ToString()) + " and makho=" + i_makho + " and stt=" + decimal.Parse(rr["stt"].ToString()));
                            m_v.execute_data("update " + user + ".d_xuatct set sttt=" + l_sttt + " where id in (select id from " + user + ".d_xuatll where khox=" + i_makho + ") and mabd=" + int.Parse(rr["mabd"].ToString()) + " and sttt=" + decimal.Parse(rr["stt"].ToString()));
                            //
                            sql = "select b.sttt, b.mabd, b.soluong from " + user + ".d_ngtrull a, " + user + ".d_ngtruct b where a.id=b.id and b.makho=" + i_makho_nhap + " and b.sttt=" + decimal.Parse(rr["stt"].ToString());
                            foreach (DataRow r1 in m_v.get_data(sql).Tables[0].Rows)
                            {
                                if (decimal.Parse(r1["soluong"].ToString()) <= d_tondau)
                                {
                                    d_tondau -= decimal.Parse(r1["soluong"].ToString());
                                    d_soluong += decimal.Parse(r1["soluong"].ToString());
                                    m_v.execute_data("update " + user + ".d_tonkhoct set slxuat=" + d_soluong + " where makho=" + i_makho_nhap + " and stt=" + decimal.Parse(rr["stt"].ToString()));
                                    m_v.execute_data("update " + user + ".d_tonkhoth set slxuat=" + d_soluong + " where makho=" + i_makho_nhap + " and mabd=" + int.Parse(rr["mabd"].ToString()));
                                }
                                else
                                {
                                    m_v.execute_data("update " + user + ".d_ngtruct set sttt=" + l_sttt + " where makho=" + i_makho_nhap + " and mabd=" + int.Parse(r1["mabd"].ToString()) + " and sttt=" + decimal.Parse(r1["sttt"].ToString()));
                                    if (!m_v.upd_tonkhoct(mmyy, i_makho_nhap, l_sttt, int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), "slxuat"))
                                    {
                                        MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin tồn kho !"), m_v.s_AppName);
                                        return;
                                    }
                                    m_v.upd_tonkhoth(mmyy, i_makho_nhap, int.Parse(rr["manguon"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), "slxuat");
                                }
                                row = m_v.getrowbyid(dsdm.Tables[0], "id=" + int.Parse(r1["mabd"].ToString()));
                                if (row != null)
                                {
                                    lShow.Text = row["ten"].ToString() + " - - - - " + l_sttt.ToString();
                                }
                                this.Refresh();
                            }
                            //
                            sql = " select b.sttt, b.mabd, b.soluong from " + user + ".d_xuatll a, " + user + ".d_xuatct b where a.id=b.id and a.khox=" + i_makho_nhap + " and b.sttt=" + decimal.Parse(rr["stt"].ToString());
                            foreach (DataRow r1 in m_v.get_data(sql).Tables[0].Rows)
                            {
                                if (decimal.Parse(r1["soluong"].ToString()) <= d_tondau)
                                {
                                    d_tondau -= decimal.Parse(r1["soluong"].ToString());
                                    d_soluong += decimal.Parse(r1["soluong"].ToString());
                                    m_v.execute_data("update " + user + ".d_tonkhoct set slxuat=" + d_soluong + " where makho=" + i_makho_nhap + " and stt=" + decimal.Parse(rr["stt"].ToString()));
                                    m_v.execute_data("update " + user + ".d_tonkhoth set slxuat=" + d_soluong + " where makho=" + i_makho_nhap + " and mabd=" + int.Parse(rr["mabd"].ToString()));
                                }
                                else
                                {
                                    m_v.execute_data("update " + user + ".d_xuatct set sttt=" + l_sttt + " where id in(select id from " + user + ".d_xuatll where khox=" + i_makho_nhap + ") and mabd=" + int.Parse(r1["mabd"].ToString()) + " and sttt=" + decimal.Parse(r1["sttt"].ToString()));
                                    if (!m_v.upd_tonkhoct(mmyy, i_makho_nhap, l_sttt, int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), "slxuat"))
                                    {
                                        MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin tồn kho !"), m_v.s_AppName);
                                        return;
                                    }
                                    m_v.upd_tonkhoth(mmyy, i_makho_nhap, int.Parse(rr["manguon"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), "slxuat");
                                }
                                row = m_v.getrowbyid(dsdm.Tables[0], "id=" + int.Parse(r1["mabd"].ToString()));
                                if (row != null)
                                {
                                    lShow.Text = row["ten"].ToString() + " - - - - " + l_sttt.ToString();
                                }
                                this.Refresh();
                            }
                        }
                    }
                }
                #endregion
            }
            else
            {
                #region Chuyển STTT tồn đầu tủ trực (để không trùng với STTT kho lẻ)
                foreach (DataRow r in get_tondau_tutruc_chuaxuat().Tables[0].Rows)
                {
                    l_sttt = m_v.get_id_tonkho;
                    if (m_v.upd_theodoi(mmyy, l_sttt, int.Parse(r["mabd"].ToString()), int.Parse(r["manguon"].ToString()), int.Parse(r["nhomcc"].ToString()), r["handung"].ToString(), r["losx"].ToString(), "", "", "", 0, 0, 0, decimal.Parse(r["giamua"].ToString()), decimal.Parse(r["giaban"].ToString()), decimal.Parse(r["gianovat"].ToString()), 0, 0))
                    {
                        m_v.execute_data("update " + user + ".d_tutrucct set stt=" + l_sttt + " where mabd=" + int.Parse(r["mabd"].ToString()) + " and makp=" + i_makp + " and makho=" + i_makho_nhap + " and stt=" + decimal.Parse(r["stt"].ToString()));

                        if (m_v.bMmyy(user_sau.Substring(6)))
                        {
                            row = m_v.getrowbyid(dstutruc_sau.Tables[0], "mabd=" + int.Parse(r["mabd"].ToString()) + " and stt=" + decimal.Parse(r["stt"].ToString()));
                            if (row != null)
                            {
                                //m_v.execute_data("delete from " + user_sau + ".d_tutrucct where mabd=" + int.Parse(r["mabd"].ToString()) + " and makho=" + i_makho_nhap + " and stt=" + decimal.Parse(r["stt"].ToString()));
                                m_v.execute_data("update " + user_sau + ".d_theodoi set id =" + l_sttt + " where mabd=" + int.Parse(r["mabd"].ToString()) + " and id=" + decimal.Parse(r["stt"].ToString()));
                                m_v.execute_data("update " + user_sau + ".d_tutrucct set stt=" + l_sttt + " where mabd=" + int.Parse(r["mabd"].ToString()) + " and makp=" + i_makp + " and makho=" + i_makho_nhap + " and stt=" + decimal.Parse(r["stt"].ToString()));
                                //m_v.execute_data("insert into " + user_sau + ".d_tutrucct values (" + i_makp + "," + i_makho_nhap + "," + l_sttt + "," + int.Parse(r["mabd"].ToString()) + "," + decimal.Parse(row["tondau"].ToString()) + "," + decimal.Parse(row["slnhap"].ToString()) + "," + decimal.Parse(row["slxuat"].ToString()) + ")");

                                m_v.execute_data("update " + user_sau + ".d_thucxuat set sttt=" + l_sttt + " where id in (select id from " + user_sau + ".d_xuatsdll where makho=" + i_makho_nhap + " and makp=" + i_makp + " and loai = 2) and mabd=" + int.Parse(r["mabd"].ToString()) + " and sttt=" + decimal.Parse(r["stt"].ToString()));
                                m_v.execute_data("update " + user_sau + ".d_xuatsdct set sttt=" + l_sttt + " where id in (select id from " + user_sau + ".d_xuatsdll where makho=" + i_makho_nhap + " and makp=" + i_makp + " and loai = 2) and mabd=" + int.Parse(r["mabd"].ToString()) + " and sttt=" + decimal.Parse(r["stt"].ToString()));
                                m_v.execute_data("update " + user + ".d_bucstt set sttt=" + l_sttt + " where id in (select id from " + user + ".d_xuatsdll where makho=" + i_makho_nhap + " and makp=" + i_makp + " and loai = 2) and mabd=" + int.Parse(r["mabd"].ToString()) + " and sttt=" + decimal.Parse(r["stt"].ToString()));
                            }
                        }

                        row = m_v.getrowbyid(dsdm.Tables[0], "id=" + int.Parse(r["mabd"].ToString()));
                        if (row != null)
                        {
                            lShow.Text = row["ten"].ToString() + " - - - - " + l_sttt.ToString();
                        }
                    }
                    this.Refresh();
                }
                //
                foreach (DataRow r in get_tondau_tutruc_daxuat().Tables[0].Rows)
                {
                    l_sttt = m_v.get_id_tonkho;
                    if (m_v.upd_theodoi(mmyy, l_sttt, int.Parse(r["mabd"].ToString()), int.Parse(r["manguon"].ToString()), int.Parse(r["nhomcc"].ToString()), r["handung"].ToString(), r["losx"].ToString(), "", "", "", 0, 0, 0, decimal.Parse(r["giamua"].ToString()), decimal.Parse(r["giaban"].ToString()), decimal.Parse(r["gianovat"].ToString()), 0, 0))
                    {
                        m_v.execute_data("update " + user + ".d_tutrucct set stt=" + l_sttt + " where mabd=" + int.Parse(r["mabd"].ToString()) + " and makp=" + i_makp + " and makho=" + i_makho_nhap + " and stt=" + decimal.Parse(r["stt"].ToString()));
                        m_v.execute_data("update " + user + ".d_thucxuat set sttt=" + l_sttt + " where id in (select id from " + user + ".d_xuatsdll where makho=" + i_makho_nhap + " and makp=" + i_makp + " and loai = 2) and mabd=" + int.Parse(r["mabd"].ToString()) + " and sttt=" + decimal.Parse(r["stt"].ToString()));
                        m_v.execute_data("update " + user + ".d_xuatsdct set sttt=" + l_sttt + " where id in (select id from " + user + ".d_xuatsdll where makho=" + i_makho_nhap + " and makp=" + i_makp + " and loai = 2) and mabd=" + int.Parse(r["mabd"].ToString()) + " and sttt=" + decimal.Parse(r["stt"].ToString()));
                        m_v.execute_data("update " + user + ".d_bucstt set sttt=" + l_sttt + " where id in (select id from " + user + ".d_xuatsdll where makho=" + i_makho_nhap + " and makp=" + i_makp + " and loai = 2) and mabd=" + int.Parse(r["mabd"].ToString()) + " and sttt=" + decimal.Parse(r["stt"].ToString()));
                        
                        if (m_v.bMmyy(user_sau.Substring(6)))
                        {
                            row = m_v.getrowbyid(dstutruc_sau.Tables[0], "mabd=" + int.Parse(r["mabd"].ToString()) + " and stt=" + decimal.Parse(r["stt"].ToString()));
                            if (row != null)
                            {
                                //m_v.execute_data("delete from " + user_sau + ".d_tutrucct where mabd=" + int.Parse(r["mabd"].ToString()) + " and makho=" + i_makho_nhap + " and stt=" + decimal.Parse(r["stt"].ToString()));
                                m_v.execute_data("update " + user_sau + ".d_theodoi set id =" + l_sttt + " where mabd=" + int.Parse(r["mabd"].ToString()) + " and id=" + decimal.Parse(r["stt"].ToString()));
                                m_v.execute_data("update " + user_sau + ".d_tutrucct set stt=" + l_sttt + " where mabd=" + int.Parse(r["mabd"].ToString()) + " and makp=" + i_makp + " and makho=" + i_makho_nhap + " and stt=" + decimal.Parse(r["stt"].ToString()));
                                //m_v.execute_data("insert into " + user_sau + ".d_tutrucct values (" + i_makp + "," + i_makho_nhap + "," + l_sttt + "," + int.Parse(r["mabd"].ToString()) + "," + decimal.Parse(row["tondau"].ToString()) + "," + decimal.Parse(row["slnhap"].ToString()) + "," + decimal.Parse(row["slxuat"].ToString()) + ")");

                                m_v.execute_data("update " + user_sau + ".d_thucxuat set sttt=" + l_sttt + " where id in (select id from " + user_sau + ".d_xuatsdll where makho=" + i_makho_nhap + " and makp=" + i_makp + " and loai = 2) and mabd=" + int.Parse(r["mabd"].ToString()) + " and sttt=" + decimal.Parse(r["stt"].ToString()));
                                m_v.execute_data("update " + user_sau + ".d_xuatsdct set sttt=" + l_sttt + " where id in (select id from " + user_sau + ".d_xuatsdll where makho=" + i_makho_nhap + " and makp=" + i_makp + " and loai = 2) and mabd=" + int.Parse(r["mabd"].ToString()) + " and sttt=" + decimal.Parse(r["stt"].ToString()));
                                m_v.execute_data("update " + user + ".d_bucstt set sttt=" + l_sttt + " where id in (select id from " + user + ".d_xuatsdll where makho=" + i_makho_nhap + " and makp=" + i_makp + " and loai = 2) and mabd=" + int.Parse(r["mabd"].ToString()) + " and sttt=" + decimal.Parse(r["stt"].ToString()));
                            }
                        }

                        row = m_v.getrowbyid(dsdm.Tables[0], "id=" + int.Parse(r["mabd"].ToString()));
                        if (row != null)
                        {
                            lShow.Text = row["ten"].ToString() + " - - - - " + l_sttt.ToString();
                        }
                    }
                    this.Refresh();
                }
                #endregion
            }
            MessageBox.Show(lan.Change_language_MessageText("Đã cập nhật thành công!"), m_v.s_AppName);
        }

        #region Get data nhà thuốc
        private DataSet get_tondau_chuaxuat()
        {
            sql = "select a.stt, a.mabd, b.manguon, b.nhomcc, b.handung, b.losx, b.giamua, b.giaban, b.gianovat from " + user + ".d_tonkhoct a, " + user + ".d_theodoi b where a.stt=b.id and a.tondau<>0 and a.slxuat=0 and a.makho=" + i_makho;
            return m_v.get_data(sql);
        }
        //
        private DataSet get_tondau_daxuat_khongcotrongtondaukhonhap()
        {
            sql = "select a.stt, a.mabd, b.manguon, b.nhomcc, b.handung, b.losx, b.giamua, b.giaban, b.gianovat from " + user + ".d_tonkhoct a, " + user + ".d_theodoi b where a.stt=b.id and a.tondau<>0 and a.slxuat<>0 and a.makho=" + i_makho +" and stt not in(select stt from " + user + ".d_tonkhoct where makho=" + i_makho_nhap + " and tondau<>0)";
            return m_v.get_data(sql); 
        }
        //
        private DataSet get_tondau_daxuat_cotrongtondaukhonhap()
        {
            sql = "select a.stt, a.mabd, b.manguon, b.nhomcc, b.handung, b.losx, b.giamua, b.giaban, b.gianovat from " + user + ".d_tonkhoct a, " + user + ".d_theodoi b where a.stt=b.id and a.tondau<>0 and a.slxuat<>0 and a.makho=" + i_makho + " and stt in(select stt from " + user + ".d_tonkhoct where makho=" + i_makho_nhap + " and tondau<>0)";
            return m_v.get_data(sql);
        }
        //
        private DataSet get_tondau_khonhap()
        {
            sql = "select a.stt, a.mabd, a.tondau, a.slnhap, a.slxuat, b.manguon, b.nhomcc, b.handung, b.losx, b.giamua, b.giaban, b.gianovat from " + user + ".d_tonkhoct a, " + user + ".d_theodoi b where a.stt=b.id and a.tondau<>0 and a.makho=" + i_makho_nhap;
            return m_v.get_data(sql);
        }
        //
        private DataSet get_dmbd()
        {
            sql = "select id, trim(ten||' '||hamluong) as ten from medibv.d_dmbd where nhom=" + int.Parse(cboNhomkho.SelectedValue.ToString());
            return m_v.get_data(sql);
        }
        #endregion

        #region Get data tủ trực

        private DataSet get_tutruc_sau()
        {
            sql = "select a.stt, a.mabd, b.manguon, b.nhomcc, b.handung, b.losx, b.giamua, b.giaban, b.gianovat, a.tondau, a.slnhap, a.slxuat from " + user_sau + ".d_tutrucct a, " + user_sau + ".d_theodoi b where a.stt=b.id and a.tondau<>0 and a.makho=" + i_makho_nhap + " and a.makp=" + i_makp;
            return m_v.get_data(sql);
        }
        private DataSet get_tondau_tutruc_chuaxuat()
        {
            sql = "select a.stt, a.mabd, b.manguon, b.nhomcc, b.handung, b.losx, b.giamua, b.giaban, b.gianovat from " + user + ".d_tutrucct a, " + user + ".d_theodoi b where a.stt=b.id and a.tondau<>0 and a.slxuat=0 and a.makho=" + i_makho_nhap + " and a.makp=" + i_makp;
            return m_v.get_data(sql);
        }
        //
        private DataSet get_tondau_tutruc_daxuat()
        {
            sql = "select a.stt, a.mabd, b.manguon, b.nhomcc, b.handung, b.losx, b.giamua, b.giaban, b.gianovat from " + user + ".d_tutrucct a, " + user + ".d_theodoi b where a.stt=b.id and a.tondau<>0 and a.slxuat<>0 and a.makho=" + i_makho_nhap + " and a.makp=" + i_makp;
            return m_v.get_data(sql);
        }
        //
        private DataSet get_toncuoi_tutruc()
        {
            sql = "select a.stt, a.mabd, b.manguon, b.nhomcc, b.handung, b.losx, b.giamua, b.giaban, b.gianovat from " + user + ".d_tutrucct a, " + user + ".d_theodoi b where a.stt=b.id and a.tondau+a.slnhap-a.slxuat<>0 and a.makho=" + i_makho_nhap + " and a.makp=" + i_makp;
            return m_v.get_data(sql);
        }

        #endregion

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkTutruc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTutruc.Checked)
            {
                l1.Text = "Tủ trực :";
                l2.Text = "Kho :";
                cboKho.Visible = false;
                cboTutruc.Visible = true;
                cboTutruc.BringToFront();
            }
            else
            {
                l1.Text = "Kho xuất :";
                l2.Text = "Kho nhập :";
                cboKho.Visible = true;
                cboTutruc.Visible = false;
                cboKho.BringToFront();
            }
        }

        private void butKiemtra_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(lan.Change_language_MessageText("Bạn đồng ý kiểm tra tồn tủ trực không?"), LibVP.AccessData.Msg, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                mmyy = thang.Value.ToString().PadLeft(2, '0') + nam.Value.ToString().Substring(2);
                m_v.upd_tutruc(int.Parse(cboNhomkho.SelectedValue.ToString()), mmyy);
            }
            MessageBox.Show(lan.Change_language_MessageText("Đã kiểm tra thành công!"), m_v.s_AppName);
        }
    }
}