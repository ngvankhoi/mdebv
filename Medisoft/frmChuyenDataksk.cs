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
    public partial class frmChuyenDataksk : Form
    {
        private LibMedi.AccessData ksk = new LibMedi.AccessData();        
        private DataTable dtCNNguon;
        private DataTable dtCNDich;
        private int i_IDChiNhanh = 0;
        private string s_mabn = "";
        private bool bDatabaseLink = false;
        //
        public frmChuyenDataksk(string _mabn)
        {
            InitializeComponent();
            s_mabn = _mabn;
        }

        private void butTranfer_Click(object sender, EventArgs e)
        {

            if (txtmabn.Text.Trim().Trim('0') == "")
            {
                MessageBox.Show("Đề nghị chọn bệnh nhân để chuyển.");
                txtmabn.Focus();
                return;
            }
            if (cmbChiNhanhDich.SelectedValue.ToString() == cmbChiNhanhNguon.SelectedValue.ToString())
            {
                MessageBox.Show("Chi nhánh nhận phải khác chi nhánh chuyển.");
                return;
            }
            if (txtIPDich.Text.Trim() == "" || txtDatabaseDich.Text.Trim() == "" || txtPortDich.Text.Trim() == "")
            {
                MessageBox.Show("Đề nghị chọn chi nhánh nhận.");
                cmbChiNhanhDich.Focus();
                SendKeys.Send("F4");
                return;
            }
            bDatabaseLink = chkdblink.Checked;
            string s_loaiTTChuyen = "";
            string s_dstables_chuyen = "medibv.btdbn,medibvxxx.tiepdon,medibvxx.lienhe,medibvxxx.v_chidinh";
            if (chkKSK.Checked)
            {                                
                s_loaiTTChuyen = "1,";
            }
            if (chkChuyenChidinh.Checked)
            {                                
                s_loaiTTChuyen += "4,";
            }
            if (chkKetQuaXN.Checked)
            {
                //                               
                s_loaiTTChuyen += "2,";
            }
            if (chkKetquaCDHA.Checked)
            {                                
                s_loaiTTChuyen += "3,";
            }
            if (chkToathuoc.Checked)
            {                
                s_loaiTTChuyen += "6,";
            }

            if (chkChuyenvienphi.Checked)
            {
             
                s_loaiTTChuyen += "7,";
            }
            
            if (chkChuyenDMGiavp.Checked) Dongbo(s_dstables_chuyen, "-2", txtmabn.Text);
            if (chkdmbd.Checked) Dongbo(s_dstables_chuyen, "-3", txtmabn.Text);
            //if (chkChuyendmksk.Checked) Dongbo(s_dstables_chuyen, "-1", txtmabn.Text);
            if (s_loaiTTChuyen.Trim().Trim(',') != "") Dongbo(s_dstables_chuyen, s_loaiTTChuyen, txtmabn.Text);
            lblStatus.Text = "Xong";
            Cursor = Cursors.Default;
        }        
        /// <summary>
        /// Dong bo data dua vao table syn_dmtable_ksk
        /// </summary>
        /// <param name="s_Table"></param>
        private void Dongbo(string s_Table, string s_LoaiThongTinChuyen, string a_mabn)
        {
            this.Cursor = Cursors.WaitCursor;
            string[] arr_table = s_Table.Trim(',').Split(',');
            int i_khoang_cach_ngay = int.Parse(txtSoNgayLayData.Value.ToString());
            string schema = "", table = "", s_dieukienloc = "";
            int i_IDChiNhanh = GetIDChiNhanhNhan(txtIPDich.Text, txtDatabaseDich.Text);
            int i_IDChiNhanh_nguon = GetIDChiNhanhNhan(txtIPNguon.Text, txtDatabaseNguon.Text);
            if (i_IDChiNhanh == 11 && i_IDChiNhanh_nguon == 11) i_IDChiNhanh = 12;
            string Server_Error_Connection = "";
            //
            //string s_iddoanksk = "900000011";
            if (s_LoaiThongTinChuyen == "-2")//chuyen dm gia vp
            {
                schema = "medibv";// arr_table[ii].Split('.')[0];
                table = "v_giavp";                
                lblStatus.Text = table;
                if (chkdblink.Checked)
                {
                    ksk.update_dblink(txtIPNguon.Text, txtPortNguon.Text, txtDatabaseNguon.Text, schema, table, i_IDChiNhanh, ref Server_Error_Connection, s_dieukienloc, lblStatus, txtIPDich.Tag.ToString());
                }
                else
                {
                    ksk.update(txtIPNguon.Text, txtPortNguon.Text, txtDatabaseNguon.Text, txtIPDich.Text, txtPortDich.Text, txtDatabaseDich.Text, schema, table, i_IDChiNhanh, ref Server_Error_Connection, s_dieukienloc, chkAddFieldChuyendi.Checked, lblStatus);
                }
            }
            if (s_LoaiThongTinChuyen == "-3")//chuyen dm gia vp
            {
                schema = "medibv";// arr_table[ii].Split('.')[0];
                table = "d_dmbd";

                lblStatus.Text = table;
                if (chkdblink.Checked)
                {
                    ksk.update_dblink(txtIPNguon.Text, txtPortNguon.Text, txtDatabaseNguon.Text, schema, table, i_IDChiNhanh, ref Server_Error_Connection, s_dieukienloc, lblStatus, txtIPDich.Tag.ToString());
                }
                else
                {
                    ksk.update(txtIPNguon.Text, txtPortNguon.Text, txtDatabaseNguon.Text, txtIPDich.Text, txtPortDich.Text, txtDatabaseDich.Text, schema, table, i_IDChiNhanh, ref Server_Error_Connection, s_dieukienloc, chkAddFieldChuyendi.Checked, lblStatus);
                }
            }
            //Chuyen data goc
            string sql1 = "";
            if (s_LoaiThongTinChuyen.Trim().Trim(',') != "")
            {
                sql1 = "select * from medibv.syn_dmtable_bn where schema_name='medibv' and hide=0";
                if (s_LoaiThongTinChuyen.Trim().Trim(',') != "") sql1 += " and lastday in(" + s_LoaiThongTinChuyen.Trim().Trim(',') + ")"; 
                sql1 += " order by stt ";
                string s_conn_nguon = ksk.GetConnString(txtIPNguon.Text, txtPortNguon.Text, txtDatabaseNguon.Text);
                DataSet dsTblChuyen = ksk.get_data_con(sql1, s_conn_nguon);
                if (dsTblChuyen.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsTblChuyen.Tables[0].Rows)//for (int ii = 0; ii < arr_table.Length; ii++)
                    {

                        schema = dr["schema_name"].ToString();// arr_table[ii].Split('.')[0];
                        //schema = schema.Replace("xxx", mmyy);
                        table = dr["table_name"].ToString();// arr_table[ii].Split('.')[1];
                        s_dieukienloc = dr["dieukien"].ToString().Replace(":bn_mabn", "'" + a_mabn + "'");
                        lblStatus.Text = table;
                        if (chkdblink.Checked)
                        {
                            ksk.update_dblink(txtIPNguon.Text, txtPortNguon.Text, txtDatabaseNguon.Text, schema, table, i_IDChiNhanh, ref Server_Error_Connection, s_dieukienloc, lblStatus, txtIPDich.Tag.ToString());
                        }
                        else
                        {
                            ksk.update(txtIPNguon.Text, txtPortNguon.Text, txtDatabaseNguon.Text, txtIPDich.Text, txtPortDich.Text, txtDatabaseDich.Text, schema, table, i_IDChiNhanh, ref Server_Error_Connection, s_dieukienloc, chkAddFieldChuyendi.Checked, lblStatus);
                        }
                    }
                }

                //Chuyen data thang - nam
                sql1 = "select * from medibv.syn_dmtable_bn where schema_name='medibvxxx' and hide=0";
                if (s_LoaiThongTinChuyen.Trim().Trim(',') != "") sql1 += " and lastday in(" + s_LoaiThongTinChuyen.Trim().Trim(',') + ")";                                
                sql1 += " order by stt ";

                dsTblChuyen = ksk.get_data_con(sql1, s_conn_nguon);
                if (dsTblChuyen.Tables[0].Rows.Count > 0)
                {
                    //
                    DateTime tn = DateTime.Now.AddDays(-(double)i_khoang_cach_ngay);
                    DateTime dn = DateTime.Now.AddDays((double)i_khoang_cach_ngay);
                    int y1 = tn.Year, y2 = dn.Year;
                    int m1 = tn.Month, m2 = dn.Month;
                    int itu = 0, iden = 0;
                    for (int j = y1; j <= y2; j++)
                    {
                        itu = (j == y1) ? m1 : 1;
                        iden = (j == y2) ? m2 : 12;
                        for (int i = itu; i <= iden; i++)
                        {
                            string mmyy = i.ToString().PadLeft(2, '0') + j.ToString().Substring(2, 2);
                            foreach (DataRow dr in dsTblChuyen.Tables[0].Rows)//for (int ii = 0; ii < arr_table.Length; ii++)
                            {

                                schema = dr["schema_name"].ToString();// arr_table[ii].Split('.')[0];
                                schema = schema.Replace("xxx", mmyy);
                                table = dr["table_name"].ToString();// arr_table[ii].Split('.')[1];
                                s_dieukienloc = dr["dieukien"].ToString().Replace(":bn_mabn", "'" + a_mabn + "'");
                                s_dieukienloc=s_dieukienloc.Replace("xxx",mmyy);//Thuy 23.06.2012
                                //Kiểm tra xem schema có tồn tại không? 
                                if (ksk.bMmyy(mmyy))
                                {
                                    lblStatus.Text = table;
                                    if (chkdblink.Checked)
                                    {
                                        ksk.update_dblink(txtIPNguon.Text, txtPortNguon.Text, txtDatabaseNguon.Text, schema, table, i_IDChiNhanh, ref Server_Error_Connection, s_dieukienloc, lblStatus, txtIPDich.Tag.ToString());
                                    }
                                    else
                                    {
                                        ksk.update(txtIPNguon.Text, txtPortNguon.Text, txtDatabaseNguon.Text, txtIPDich.Text, txtPortDich.Text, txtDatabaseDich.Text, schema, table, i_IDChiNhanh, ref Server_Error_Connection, s_dieukienloc, chkAddFieldChuyendi.Checked, lblStatus);
                                    }
                                }
                            }
                        }

                    }
                }
            }
            this.Cursor = Cursors.Default;
            
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int GetIDChiNhanhNhan(string sIP, string s_Database)
        {
            int i_IDCN = 11;
            string asql = "select * from medibv.dmchinhanh where database_local='" + s_Database + "' and ip='" + sIP + "'";
            DataSet lds = ksk.get_data(asql);
            if (lds != null && lds.Tables.Count > 0 && lds.Tables[0].Rows.Count > 0)
            {
                i_IDCN = int.Parse(lds.Tables[0].Rows[0]["id"].ToString());
            }
            return i_IDCN;
        }

        private string get_dsTable_Chuyen()
        {
            string s_tables = "";
            string asql = "select * from medibv.syn_dmtable_ksk where hide=0 order by stt";
            DataSet lds = ksk.get_data(asql);
            if (lds != null && lds.Tables.Count > 0)
            {
                foreach (DataRow r in lds.Tables[0].Rows)
                {
                    s_tables += r["schema_name"].ToString() + "." + r["table_name"].ToString() + ",";
                }
            }
            return s_tables.Trim(',');
        }
        /// <summary>
        /// Lay dm table de chuyen data
        /// </summary>
        /// <param name="i_loaithongtin">4: Chi dinh, 2: KQ xet nghiem; 3: kq chan doan ha; 1: Thong tin doan, Kham; 0: tat ca</param>
        /// <returns></returns>
        private string get_dsTable_Chuyen(int i_loaithongtin)
        {
            //i_loaithongtin: 1 --> KSK chung
            //i_loaithongtin: 2 --> KQ Xet nghiem
            //i_loaithongtin: 3 --> KQ CĐHA
            string s_tables = "";
            string asql = "select * from medibv.syn_dmtable_ksk where hide=0 ";
            if (i_loaithongtin != 0) asql += " and lastday=" + i_loaithongtin;
            asql += " order by stt";
            DataSet lds = ksk.get_data(asql);
            if (lds != null && lds.Tables.Count > 0)
            {
                foreach (DataRow r in lds.Tables[0].Rows)
                {
                    s_tables += r["schema_name"].ToString() + "." + r["table_name"].ToString() + ",";
                }
            }
            return s_tables.Trim(',');
        }

        private void WriteThongSo()
        {

        }


        public void LoadChiNhanh_nguon()
        {
            string asql = "select * from medibv.dmchinhanh where id >0 order by id ";
            dtCNNguon = ksk.get_data(asql).Tables[0].Copy();
            cmbChiNhanhNguon.DataSource = dtCNNguon;
            cmbChiNhanhNguon.DisplayMember = "TEN";
            cmbChiNhanhNguon.ValueMember = "ID";
        }
        public void LoadChiNhanh_Dich( int i_IDCN_Nguon)
        {
            string asql = "select * from medibv.dmchinhanh where id >0 and id<>" + i_IDCN_Nguon + " order by id ";
            dtCNDich = ksk.get_data(asql).Tables[0].Copy();
            cmbChiNhanhDich.DataSource = dtCNDich;// ksk.get_data(asql).Tables[0];
            cmbChiNhanhDich.DisplayMember = "TEN";
            cmbChiNhanhDich.ValueMember = "ID";
        }
        private void frmChuyenDataksk_Load(object sender, EventArgs e)
        {            
            LoadChiNhanh_nguon();
            LoadChiNhanh_Dich(0);
            if (s_mabn.Trim() != "")
            {
                txtmabn.Text = s_mabn;
                txtmabn_Validated(null, null);
            }
            i_IDChiNhanh = ksk.i_Chinhanh_hientai;
            cmbChiNhanhNguon.SelectedValue = i_IDChiNhanh;
            cmbChiNhanhNguon_SelectedIndexChanged(null, null);
        }

        private void cmbChiNhanhNguon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cmbChiNhanhNguon || sender == null)
            {
                int i_IDCNNguon = (cmbChiNhanhNguon.SelectedIndex >= 0) ? int.Parse(cmbChiNhanhNguon.SelectedValue.ToString()) : 0;
                LoadChiNhanh_Dich(i_IDCNNguon);
                Load_thongtin_cnNguon(i_IDCNNguon);
            }
        }

        private void Load_thongtin_cnNguon(int i_idCN)
        {
            DataRow dr = ksk.getrowbyid(dtCNNguon, "id=" + i_idCN);
            if (dr != null)
            {
                txtIPNguon.Text = dr["ip"].ToString();
                txtPortNguon.Text = dr["port"].ToString();
                txtDatabaseNguon.Text = dr["database_local"].ToString();
            }
        }

        private void Load_thongtin_cnDich(int i_idCN)
        {
            DataRow dr = ksk.getrowbyid(dtCNDich, "id=" + i_idCN);
            if (dr != null)
            {
                txtIPDich.Text = dr["ip"].ToString();
                txtPortDich.Text = dr["port"].ToString();
                txtDatabaseDich.Text = dr["database_local"].ToString();
                txtIPDich.Tag = dr["database"].ToString();
            }
        }

        private void Load_thongtin_cn_Hientai_nguon()
        {
            txtIPNguon.Text = ksk.Maincode("Ip");
            txtPortNguon.Text = ksk.Maincode("Post");
            txtDatabaseNguon.Text = ksk.Maincode("Database");
            txtIPNguon.Tag = "";//dr["database"].ToString();
        }

        private void Load_thongtin_cn_Hientai_Dich()
        {
            txtIPDich.Text = ksk.Maincode("Ip");
            txtPortDich.Text = ksk.Maincode("Post");
            txtDatabaseDich.Text = ksk.Maincode("Database");
        }
        private void cmbChiNhanhDich_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cmbChiNhanhDich || sender == null)
            {
                Load_thongtin_cnDich (cmbChiNhanhDich.SelectedIndex < 0 ? 0 : int.Parse(cmbChiNhanhDich.SelectedValue.ToString()));
            }
        }

      
        private void load_thongtinbn(string amabn)
        {
            string asql = "select mabn, hoten, namsinh, phai, nam from medibv.btdbn where mabn='" + amabn + "'";
            DataSet lds = ksk.get_data(asql);
            foreach (DataRow dr in lds.Tables[0].Rows)
            {
                txtHoten.Text = dr["hoten"].ToString();
                txtHoten.Tag = dr["nam"].ToString();
                txtnamsinh.Text = dr["namsinh"].ToString();
                txtphai.Text = (dr["phai"].ToString() == "1") ? "Nữ" : "Nam";
                break;
            }
        }

        private void txtmabn_Validated(object sender, EventArgs e)
        {
            if (txtmabn.Text.Trim() == "") return;
            load_thongtinbn(txtmabn.Text);
        }

        private void txtmabn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
    }
}