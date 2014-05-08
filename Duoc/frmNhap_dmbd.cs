using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using LibVienphi;
using Duoc;
namespace Duoc
{
    public partial class frmNhap_dmbd : Form
    {
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        LibMedi.AccessData m = new LibMedi.AccessData();
        LibDuoc.AccessData d = new LibDuoc.AccessData();
        DataTable dt;
        DataTable dtdm;
        DataRow r1;
        
        public string d_mmyy;
        public frmNhap_dmbd()
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void imp_dmduongdung(string file)
        {
            dtdm = d.get_data("select * from " + d.user + ".d_dmduongdung ").Tables[0];
            dt = get_excel(path.Text).Tables[0];
            DataRow r1;
            foreach(DataRow r in dt.Rows)
            {
                r1 = d.getrowbyid(dtdm, "trim(ten)='" + r[0].ToString() + "'");
                if(r1==null)
                {
                    d.upd_dmduongdung("d_dmduongdung", r[0].ToString(), r[0].ToString(), 0);
                }

            }
        }

        private void butPath_Click(object sender, EventArgs e)
        {
            string sDir = System.Environment.CurrentDirectory.ToString();
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "*.XLS|*.*";
            of.ShowDialog();
            path.Text = of.FileName.ToString();
            System.Environment.CurrentDirectory = sDir;
            
        }

        private DataSet get_excel(string fileName)
        {
           
                OleDbConnection con = this.ReturnConnection(fileName);
                con.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", con);
                OleDbDataAdapter dest = new OleDbDataAdapter();
                dest.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dest.Fill(ds);
                cmd.Dispose();
                con.Close();
                return ds;
   
        }

        private OleDbConnection ReturnConnection(string fileName)
        {
            return new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=" + fileName + ";" +
                " Jet OLEDB:Engine Type=5;Extended Properties=\"Excel 8.0;\"");
        }

        private void button1_Click(object sender, EventArgs e)//05052012-Phuoc
        {
            if (path.Text != "") imp_DMBD(path.Text);
            else
            {
                MessageBox.Show("Chọn file excel cần nhập danh mục thuốc!");
            }
            path.Text = "";
        }

        private void imp_dmhangsx(string file)
        {
            dtdm = d.get_data("select * from " + d.user + ".d_dmhang where nhom>0 ").Tables[0];
            dt = get_excel(path.Text).Tables[0];
            DataRow r1;
            decimal l_id = 0;
            d.execute_data("update " + d.user + ".d_capid set id=(select max(id) from medibv.d_dmhang) where ma=3 ");
            foreach (DataRow r in dt.Rows)
            {
                
                if (r[0].ToString().Trim() != "")
                {
                    r1 = d.getrowbyid(dtdm, "trim(ten)='" + r[0].ToString() + "'");
                    if (r1 == null)
                    {
                        l_id = d.get_id_dmhang;
                        d.upd_dmhang(l_id,"", r[0].ToString(), 1, 1, 0);
                        dtdm.Dispose();
                        dtdm = d.get_data("select * from " + d.user + ".d_dmhang where nhom>0 ").Tables[0];
                    }
                }
            }
        }

        private void imp_dmnuocsx(string file)
        {
            dtdm = d.get_data("select * from " + d.user + ".d_dmnuoc where nhom>0 ").Tables[0];
            dt = get_excel(path.Text).Tables[0];
            DataRow r1;
            decimal l_id = 0;
            d.execute_data("update " + d.user + ".d_capid set id=(select max(id) from medibv.d_dmnuoc) where ma=13 ");
            foreach (DataRow r in dt.Rows)
            {
                if (r[0].ToString().Trim() != "")
                {
                    r1 = d.getrowbyid(dtdm, "trim(ten)='" + r[0].ToString() + "'");
                    if (r1 == null)
                    {
                        l_id = d.get_id_dmnuoc;
                        d.upd_dmnuoc(l_id,"", r[0].ToString(), 1, 1, 0);
                    }
                }
            }
        }

        private void imp_dmnhacc(string file)
        {
            dtdm = d.get_data("select * from " + d.user + ".d_dmnx where nhom>0 ").Tables[0];
            dt = get_excel(path.Text).Tables[0];
            DataRow r1;
            decimal l_id = 0;
            int ima = 0;
            d.execute_data("update " + d.user + ".d_capid set id=(select max(id) from medibv.d_dmnx) where ma=2 ");
            foreach (DataRow r in dt.Rows)
            {
                if (r[0].ToString().Trim() != "")
                {
                    r1 = d.getrowbyid(dtdm, "trim(ten)='" + r[0].ToString() + "'");
                    if (r1 == null)
                    {
                        ima += 1;
                        l_id = d.get_id_dmnx;

                        d.upd_dmnx(l_id, ima.ToString().PadLeft(4, '0'), r[0].ToString(), 1, 0, 1, "", "", "", "", "");
                    }
                }
            }
        }

        private void imp_dmnhom(string file)
        {
            dtdm = d.get_data("select * from " + d.user + ".d_dmnhom where nhom>0 ").Tables[0];
            dt = get_excel(path.Text).Tables[0];
            d.execute_data("update " + d.user + ".d_capid set id=(select max(id) from medibv.d_dmnhom) where ma=100 ");
            DataRow r1;
            decimal l_id = 0;
            foreach (DataRow r in dt.Rows)
            {
                if (r[0].ToString().Trim() != "")
                {
                    r1 = d.getrowbyid(dtdm, "trim(ten)='" + r[0].ToString() + "'");
                    if (r1 == null)
                    {
                        l_id = d.get_id_dmnhom;
                        if (l_id == 1) d.execute_data("update " + d.user + ".d_capid set id=(select max(id) from medibv.d_dmnhom) where ma=100 ");
                        l_id = d.get_id_dmnhom;
                        d.upd_dmnhom(l_id,"", r[0].ToString(), 1, 1, 1, 1, 0);
                    }
                }
            }
        }

        private void imp_dmloiai(string file)
        {            
            dtdm = d.get_data("select * from " + d.user + ".d_dmloai where nhom>0 ").Tables[0];
            dt = get_excel(path.Text).Tables[0];
            d.execute_data("update " + d.user + ".d_capid set id=(select max(id) from medibv.d_dmloai) where ma=101 ");
            DataRow r1;
            decimal l_id = 0;
            foreach (DataRow r in dt.Rows)
            {
                if (r[0].ToString().Trim() != "")
                {
                    r1 = d.getrowbyid(dtdm, "trim(ten)='" + r[0].ToString() + "'");
                    if (r1 == null)
                    {
                        l_id = d.get_capid(101);
                        if (l_id == 1) d.execute_data("update " + d.user + ".d_capid set id=(select max(id) from medibv.d_dmloai) where ma=101 ");
                        l_id = d.get_capid(101);
                        d.upd_dmloai(l_id,"", r[0].ToString(), 1, 1, 0);
                    }
                }
            }
        }

        private void imp_DMBD(string file)
        {
            dtdm = d.get_data("select id, ma, stt from " + d.user + ".d_dmbd where nhom>0 ").Tables[0];
            dt = get_excel(path.Text).Tables[0];
            
            LibMedi.AccessData m = new LibMedi.AccessData();
            m.f_kiemtra_idduoc_idgiavp();            
            DataRow r1;
            decimal l_id = 0;
            string exp = "", asql = "", s_manhom = "", s_maloai = "", s_manhomin = "", s_nhombc = "", s_manuoc = "", s_mahang = "", s_nhacc = "";
            string l_ma = "", l_tenbd = "", l_tenhc = "", l_dvt = "", l_hamluong = "", l_duongdung = "", l_stt05 = "", l_stt31 = "", l_dvsd = "", l_sodk = "", l_stt_soyt="";
            int l_manhom = 0, l_maloai = 0, l_nhomin = 0, l_nhombv = 0, l_mahang = 0, l_manuoc = 0, l_manhacc = 0, l_stt = 0, l_gaynghien = 0;//l_nhombo = 0,
            decimal l_bhyt = 0,l_sldonggoi=0, l_sltoithieu = 0;
            if (dt.Rows.Count > 0)
            {
                asql = "update " + d.user + ".d_dmbd set stt=0 where stt>0 ";
                d.execute_data(asql);
            }
            foreach (DataRow r in dt.Rows)
            {
                if (r[1].ToString().Trim() != "")
                {
                    l_stt = int.Parse(r[0].ToString());
                    l_ma = r[1].ToString();
                    r1 = d.getrowbyid(dtdm, "ma='" + l_ma + "'");
                    if ( r1 !=null )
                    {
                        asql = "update " + d.user + ".d_dmbd set stt=" + l_stt + " where id=" + r1["id"].ToString() + "";
                        d.execute_data(asql);
                        asql = "update " + d.user + ".d_dmbd set stt=" + l_stt + " where id=" + r1["id"].ToString() + "";
                        d.execute_data(asql);
                        continue;
                    }
                    else l_id = d.get_id_dmbd;

                    l_tenbd = r[2].ToString().Replace("'", "''");
                    l_tenhc = r[3].ToString().Replace("'", "''");
                    l_hamluong = r[4].ToString().Replace("'", "''"); 
                    l_dvt = r[5].ToString().Replace("'", "''"); 
                    l_dvsd = r[6].ToString().Replace("'", "''"); 
                    l_duongdung = r[7].ToString();

                    l_manhom=int.Parse(r[8].ToString());
                    l_maloai=int.Parse(r[9].ToString());
                    l_nhombv=int.Parse(r[11].ToString());
                    l_nhomin=int.Parse(r[10].ToString());
                    l_manuoc = int.Parse(r[12].ToString());
                    l_mahang = int.Parse(r[14].ToString());
                    l_manhacc = int.Parse(r[13].ToString());
                    s_nhacc = r[13].ToString();
                    s_mahang = r[14].ToString();
                    l_bhyt = int.Parse(r[15].ToString());
                    l_stt05 = r[16].ToString();            
                    l_stt31 = r[17].ToString();
                    l_gaynghien= int.Parse(r[18].ToString());
                    l_sltoithieu = decimal.Parse(r[19].ToString());
                    l_sldonggoi = decimal.Parse(r[20].ToString());
                    exp = "trim(ten)='" + l_tenbd + "'";
                    exp += " and tenhc='" + l_tenhc + "'";
                    exp += " and hamluong='" + l_hamluong + "'";
                    exp += " and mahang=" + l_mahang;
                    exp += " and manuoc=" + l_mahang;
                    exp += " and madv=" + l_manhacc;
                    r1 = d.getrowbyid(dtdm, exp);
                    if (r1 == null)
                    {
                    
                        d.upd_dmbd(l_id, l_ma, l_tenbd, l_dvt, l_hamluong, l_manhom, l_maloai, l_mahang,
                                   l_manuoc,l_nhombv, 100, 0, 0, l_tenhc, "", 0, 1, l_sodk,l_sltoithieu, 7, 0, 0, 0,l_stt,"",
                                   l_nhomin, 0, l_duongdung, "", l_manhacc, "", l_sldonggoi, l_dvt,0);
                        d.execute_data("update " + d.user + ".d_dmbd set sttvb='" + l_stt_soyt + "',  stt=" + l_stt + " where id=" + l_id);
                        
                    }
                }
            }
            DialogResult thongbao;
            thongbao = MessageBox.Show("Cập nhật danh mục thuốc thành công", "Quản lý dược", MessageBoxButtons.OK, MessageBoxIcon.None);
            if (thongbao == DialogResult.OK) this.Close();
        }
        private void imp_dmnhapkho(string file)
        {
            
            dt = get_excel(path.Text).Tables[0];

            LibMedi.AccessData m = new LibMedi.AccessData();
            decimal d_id = 0;
            string d_ngaysp = "", d_ngaysp1 = "", d_ngaysp2 = "", d_sohd = "", d_ngayhd = "", d_nguoigiao = "", d_sophieu = "";
            int d_madv = 1, d_makho = 1, d_manguon = 1, d_nhomcc = 1;

            //d_nhapct
            decimal d_stt = 0;
            string d_handung = "", d_losx = "";
            int d_mabd=0, d_vat = 0, d_sttn=0;
            decimal d_soluong = 0, d_dongia = 0, d_sotien = 0, d_giaban = 0, d_giamua = 0;
           
            r1 = dt.Rows[1];
            d_ngaysp1 = r1[2].ToString().Substring(3,2);
            d_ngaysp2 = r1[2].ToString().Substring(8, 2);
            d_mmyy = d_ngaysp1 + d_ngaysp2;
            if ((r1[2].ToString().Trim() != ""))
            {

                d_sophieu = r1[1].ToString();
                dtdm = d.get_data("select id from " + d.user + d_mmyy+".d_nhapll where sophieu= " + d_sophieu + "").Tables[0];
                
                if (dtdm.Rows.Count == 0)
                {
                    d_id = d.getidyymmddhhmiss_stt_computer;
                }
                else d_id = decimal.Parse(dtdm.Rows[0][0].ToString());
                d_ngaysp = r1[2].ToString();
                d_sohd = r1[3].ToString();
                d_ngayhd = r1[4].ToString();
                d_nguoigiao = r1[5].ToString();
                d_madv = int.Parse(r1[6].ToString());
                d_makho = int.Parse(r1[7].ToString());
                d_manguon = int.Parse(r1[8].ToString());
                d_nhomcc = int.Parse(r1[9].ToString());

                d.upd_nhapll(d_mmyy, d_id, 1, d_sophieu, d_ngaysp, d_sohd, d_ngayhd, "", "", "M", d_nguoigiao, d_madv, d_makho, d_manguon, d_nhomcc, "", "", 0, 0, 0);
                
            }
            foreach (DataRow r in dt.Rows)
            {
                if (r[10].ToString().Trim() != "")
                {

                    d_stt = decimal.Parse(r[10].ToString());
                    d_sttn = int.Parse(r[10].ToString());
                    d_mabd = int.Parse(r[11].ToString());
                    d_handung = r[12].ToString();
                    d_losx = r[13].ToString();
                    d_vat = int.Parse(r[14].ToString());
                    d_soluong = decimal.Parse(r[15].ToString());
                    d_dongia = decimal.Parse(r[16].ToString());
                    d_sotien = decimal.Parse(r[17].ToString());
                    d_giaban = decimal.Parse(r[18].ToString());
                    d_giamua = decimal.Parse(r[19].ToString());

                        d.upd_nhapct(d_mmyy, d_id, d_stt, d_mabd, d_handung, d_losx, d_vat, d_soluong, d_dongia, d_sotien, d_giaban, d_giamua, d_soluong, 1, 0, 0, 0, "", "", 0, 0, 0, "", 0, 0, 0, 0, 0, 0,"");
                        //d.upd_nhapct(d_mmyy, d_id, d_stt, d_mabd, d_handung, d_losx, d_vat, d_soluong, d_dongia, d_sotien, d_giaban, d_giamua, d_sl1, d_sl2, d_tyle, d_cuocvc, d_chaythu, d_namsx, d_tailieu, d_baohanh, d_nguongoc, d_tinhtrang, d_sothe, d_giabancu, d_giamuacu, d_giaban2, d_tyle2, d_tyle_ggia, d_st_ggia);
                        d.upd_tonkhoct_nhapct(d.insert, d_mmyy, "", d_id, d_sttn, d_soluong, d_sotien, d_vat, d_makho, d_manguon, d_nhomcc, d_mabd, d_handung, d_losx, d_giaban, "", 0, 0, "", 0, 0, 0, 0, "", 0, 0, 0, 0, d_dongia, 0, 0, 0, 0, true,"");
            
                }
            }
               
                    MessageBox.Show("Cập nhật nhập kho thành công");
 
        }
        private void imp_DMBD_VATTU(string file)
        {
            dtdm = d.get_data("select stt, ma,ten from " + d.user + ".d_dmbd where nhom>0 ").Tables[0];
            dt = get_excel(path.Text).Tables[0];
            //
            DataTable dtnhom = d.get_data("select id, ten from medibv.d_dmnhom where nhom>0").Tables[0];
            DataTable dtloai = d.get_data("select id, ten from medibv.d_dmloai where nhom>0").Tables[0];
            DataTable dtnhomin = d.get_data("select id, ten from medibv.d_nhomin where nhom>0").Tables[0];
            DataTable dtnhombo = d.get_data("select id, ten from medibv.d_nhombo where nhom>0").Tables[0];
            DataTable dtnuoc = d.get_data("select id, ten from medibv.d_dmnuoc where nhom>0").Tables[0];
            DataTable dtnhacc = d.get_data("select id, ten from medibv.d_dmnx where nhom>0").Tables[0];
            DataTable dthang = d.get_data("select id, ten from medibv.d_dmhang where nhom>0").Tables[0];
            //
            LibMedi.AccessData m = new LibMedi.AccessData();
            m.f_kiemtra_idduoc_idgiavp();
            DataRow r1;
            decimal l_id = 0;
            string exp = "";
            string d_ma = "", d_tenbd = "", d_tenhc = "", d_dvt = "", d_hamluong = "", d_sodk = "", d_duongdung = "", d_donggoi="";
            string d_mack = "", d_manhomck = "", d_ck = "", d_idtutruc = "";
            int d_manhom = 1, d_maloai = 1, d_mahang = 1, d_manuoc = 1, d_manhacc = 0, i_stt = 0, d_nhomin = 0;
            decimal  d_dongia = 0, d_giaban = 0, d_giabh = 0, d_sldongoi = 0;
            d.execute_data("update " + d.user + ".d_capid set id=(select max(id) from medibv.d_dmbd) where ma=1");

            string ma_error = "";
            bool b_error = false;
            foreach (DataRow r in dt.Rows)
            {
                if (r[4].ToString().Trim() != "")
                {
                    d_tenbd = r[2].ToString().Replace("'", "''");
                    d_ma = r[5].ToString().Replace("'", "''"); //d.getMabd("d_dmbd", d_tenbd, 1);
                    d_tenhc = "";// r[5].ToString().Replace("'", "''");
                    d_dvt = r[10].ToString().Replace("'", "''"); ;
                    d_hamluong = "";// r[8].ToString().Replace("'", "''"); ;
                    d_manhom = (r[4].ToString() == "") ? 0 : int.Parse(r[4].ToString());// f_get_manhom(dtnhom, r[6].ToString());
                    d_maloai = (r[3].ToString() == "") ? 0 : int.Parse(r[3].ToString());// f_get_manhom(dtloai, r[7].ToString());
                    d_mahang = f_get_manhom(dthang, r[12].ToString());
                    d_manuoc = f_get_manhom(dtnuoc, r[13].ToString());
                    d_manhacc = f_get_manhom(dtnhacc, r[14].ToString(), 0);
                    if (d_manhom == 4) d_nhomin = 9;//hoa chat
                    else if (d_manhom == 9) d_nhomin = 6;//vat tu
                    else d_nhomin = 8;//VTTH
                    d_donggoi = r[10].ToString();
                    d_sodk = "";// r[3].ToString();
                    d_duongdung = "";// r[9].ToString();
                    d_hamluong = "";

                    d_dongia = (r[16].ToString() == "") ? 0 : decimal.Parse(r[16].ToString());//gia theo don vi nho nhat
                    d_giaban = (r[15].ToString() == "") ? 0 : decimal.Parse(r[15].ToString());//giaban2: gia dong goi ban dau
                    d_giabh = (r[16].ToString() == "") ? 0 : decimal.Parse(r[16].ToString());//gia theo don vi nho nhat
                    i_stt = int.Parse(r[1].ToString());

                    d_mack = r[6].ToString();
                    d_manhomck = r[7].ToString();
                    d_ck = r[8].ToString();
                    d_sldongoi = (r[11].ToString() == "") ? 0 : decimal.Parse(r[11].ToString());
                    d_idtutruc = r[0].ToString();
                    exp = "ma='" + r[5].ToString() + "'";
                    r1 = d.getrowbyid(dtdm, exp);
                    if (r1 == null)
                    {
                        l_id = d.get_id_dmbd;

                        b_error= d.upd_dmbd(l_id, d_ma, d_tenbd, d_dvt, d_hamluong, d_manhom, d_maloai, d_mahang, d_manuoc, 1, 100, 0, 0, d_tenhc, "", 0, 1, d_sodk,
                            0, 7, 0, 0, 0, 0, "", d_nhomin, 0, d_duongdung, d_idtutruc, d_manhacc, "", d_sldongoi, d_dvt,0);
                        if (b_error)
                        {
                            ma_error += d_ma + ", ";
                        }
                        d.execute_data("update medibv.d_dmbd set dongia=" + d_dongia + ",gia_bh=" + d_giabh + ",giaban2=" + d_giaban + ",machuyenkhoa='" + d_mack + "',manhomck='" + d_manhomck + "',chuyenkhoa='" + d_ck + "', stt=" + i_stt + ", vtyt=1 where id=" + l_id);
                        //dtdm.Dispose();
                        dtdm.Dispose();
                        dtdm = new DataTable();
                        dtdm = d.get_data("select stt, ma,ten from " + d.user + ".d_dmbd where nhom>0 ").Tables[0];
                    }
                }
            }
            if (ma_error != "") MessageBox.Show(ma_error);
        }

        private int f_get_manhom(DataTable dtdm, string d_ten)
        {
            int i_id = 1;
            DataRow r1 = d.getrowbyid(dtdm, "ten='" + d_ten + "'");
            if (r1 != null) i_id = int.Parse(r1["id"].ToString());
            return i_id;
        }

        private int f_get_manhom(DataTable dtdm, string d_ten, int d_def)
        {
            int i_id = d_def;
            DataRow r1 = d.getrowbyid(dtdm, "ten='" + d_ten + "'");
            if (r1 != null) i_id = int.Parse(r1["id"].ToString());
            return i_id;
        }

        private void imp_dmgiavp(string file)
        {
            LibVP.AccessData v = new LibVP.AccessData();
            dtdm = d.get_data("select * from " + d.user + ".v_giavp ").Tables[0];
            dt = get_excel(path.Text).Tables[0];

            DataRow r1;
            decimal l_id = 0, v_idloai=0;
            decimal d_gia_bh=0, d_gia_th = 0, d_gia_dv = 0, d_gia_nn = 0, d_gia_cs = 0;
            int i_stt = 0, i_bhyt=100, i_ktcao=-1;;
            string d_mavp = "", s_mack = "", s_manhom = "",  s_tenkt="", s_dvt="", s_maExcel="";
            foreach (DataRow r in dt.Rows)
            {
                if (r[0].ToString().Trim() != "")
                {
                    d_mavp = r[3].ToString();
                    i_stt = int.Parse(r[0].ToString());
                    r1 = v.getrowbyid(dtdm, "stt=" + i_stt);
                    if (r1 != null)
                    {
                        l_id = decimal.Parse(r1["id"].ToString());
                        s_mack  = r1["ma"].ToString();
                    }
                    else
                    {
                        for (; ; )
                        {
                            l_id = v.get_id_v_giavp;
                            if (d.get_data("select id from medibv.v_giavp where id=" + l_id).Tables[0].Rows.Count <= 0) break;
                        }
                        s_mack = v.f_get_mavp(r[1].ToString());
                    }
                    v_idloai = decimal.Parse(r[11].ToString());

                    s_tenkt=r[1].ToString();
                    s_dvt=r[2].ToString();
                   
                    s_manhom = r[3].ToString();//ma vp tu file excel
                   if(r[12].ToString().ToLower ()=="c") i_bhyt=100;
                   else i_bhyt=0;

                    if(r[13].ToString().Trim()!="")i_ktcao=0;
                    else i_ktcao=-1;

                    s_maExcel=r[3].ToString();
                    d_gia_dv = (r[4].ToString() == "") ? 0 : decimal.Parse(r[4].ToString());
                    d_gia_bh = (r[5].ToString() == "") ? 0 : decimal.Parse(r[5].ToString());
                    d_gia_th = (r[6].ToString() == "") ? 0 : decimal.Parse(r[6].ToString());
                    if (d_gia_dv == 0)d_gia_dv= d_gia_th;
                    //d_gia_dv = (r[6].ToString() == "") ? 0 : decimal.Parse(r[6].ToString());
                    d_gia_nn = d_gia_dv;// (r[6].ToString() == "") ? 0 : decimal.Parse(r[6].ToString());
                    d_gia_cs = d_gia_dv;// (r[6].ToString() == "") ? 0 : decimal.Parse(r[6].ToString());



                    v.upd_v_giavp(l_id, v_idloai, (decimal)i_stt, s_mack, s_tenkt, s_dvt, d_gia_th, d_gia_bh, d_gia_dv, d_gia_nn, d_gia_cs, 0, 0, 0, 0, 0, (decimal)i_bhyt, 0, 0, 0, 0, 0, 0, 0, "", 0, 1, 0, d_gia_th, 0, 0, (decimal)i_ktcao, "");

                }
            }
        }


        private void imp_Gia_DMBD(string file)
        {
            //dtdm = d.get_data("select * from " + d.user + ".d_dmbd where nhom>0 ").Tables[0];
            dt = get_excel(path.Text).Tables[0];
            LibMedi.AccessData m = new LibMedi.AccessData();
            //m.f_kiemtra_idduoc_idgiavp();
            int  i_stt = 0;
            decimal  d_dongia = 0, d_giaban = 0, d_giabh = 0, d_giabhnovat;
            bool bBHYT = false;
            foreach (DataRow r in dt.Rows)
            {
                if (r[0].ToString().Trim() != "")
                {
                    d_giabhnovat = (r[1].ToString() == "") ? 0 : decimal.Parse(r[1].ToString());
                    d_dongia = (r[2].ToString() == "") ? 0 : decimal.Parse(r[2].ToString());
                    d_giaban = (r[4].ToString() == "") ? d_dongia : decimal.Parse(r[4].ToString());
                    d_giabh = (r[3].ToString() == "") ? 0 : decimal.Parse(r[3].ToString());
                    i_stt = int.Parse(r[0].ToString());
                    bBHYT = r[11].ToString().ToLower() == "bhyt";

                    //d.execute_data("update medibv.d_dmbd set bhyt=" + (bBHYT ? "100" : "0") + " where stt=" + i_stt);
                    d.execute_data("update medibv.d_dmbd set dongia=" + d_dongia + ",gia_bh=" + d_giabh + ",giaban=" + d_giaban + ", gia_bh_novat=" + d_giabhnovat + ", bhyt=" + (bBHYT ? "100" : "0") + " where stt=" + i_stt);

                }
            }
        }

        private void imp_stt_DMBD(string file)
        {
            dtdm = d.get_data("select * from " + d.user + ".d_dmbd where nhom>0  and stt=0 ").Tables[0];
            dt = get_excel(path.Text).Tables[0];
            LibMedi.AccessData m = new LibMedi.AccessData();
            //m.f_kiemtra_idduoc_idgiavp();
            decimal l_id = 0;
            int  i_stt = 0;
            foreach (DataRow r in dt.Rows)
            {
                if (r[0].ToString().Trim() != "")
                {
                    
                    l_id = decimal.Parse(r[1].ToString());
                    DataRow rr = d.getrowbyid(dtdm, "id=" + l_id);
                    if (rr != null)
                    {
                        i_stt = int.Parse(r[0].ToString());
                        d.execute_data("update medibv.d_dmbd set stt=" + i_stt + " where id=" + l_id);
                    }

                }
            }
        }

        private void imp_tondau_khochan_hep(string file)
        {
            dtdm = d.get_data("select * from " + d.user + ".d_dmbd a where nhom>0 and dongia>0 and vtyt=1").Tables[0];//and stt>1000
            
            DataTable dtkho = d.get_data("select id, ten from medibv.d_dmkho where nhom>0 and id=6014").Tables[0];
            //DataTable dtnhacc = d.get_data("select id, ten from medibv.d_dmnx where nhom>0").Tables[0];
            //
            LibMedi.AccessData m = new LibMedi.AccessData();
            //m.f_kiemtra_idduoc_idgiavp();
            decimal l_id = 0;
            int  d_manhacc = 0;
            foreach (DataRow rkho in dtkho.Rows)
            {
                foreach (DataRow r in dtdm.Rows)
                {

                    l_id = d.get_id_tonkho;
                    d_manhacc = (r["madv"].ToString() == "") ? 0 : int.Parse(r["madv"].ToString());
                    d.upd_theodoi("0911", l_id, int.Parse(r["id"].ToString()), 1, int.Parse(r["madv"].ToString()), "", "", "", "", "", 0, 0, 0, decimal.Parse(r["dongia"].ToString()), decimal.Parse(r["giaban"].ToString()), decimal.Parse(r["gia_bh_novat"].ToString()), 0, 0);
                    d.upd_tonkhoct("0911", int.Parse(rkho["id"].ToString()), l_id, int.Parse(r["id"].ToString()), 2000);
                        
                }
            }
        }

        private void imp_dinhmuc(string file)
        {
            dtdm = d.get_data("select id, ma, ten from " + d.user + ".d_dmbd where vtyt=1 ").Tables[0];
            dt = get_excel(path.Text).Tables[0];
            //
            DataTable dtxn = d.get_data("select id,id_vienphi, ten from medibv.xn_bv_ten").Tables[0];
            DataTable dtvp = d.get_data("select id,ma, ten from medibv.v_giavp").Tables[0];
            //
            LibMedi.AccessData m = new LibMedi.AccessData();
            //m.f_kiemtra_idduoc_idgiavp();
            string d_tenbd="";
            int d_id_ten = 0, d_idvp = 0, d_idbd = 0,  d_haohut=0, d_sttimp=0;
            decimal d_soluong=0;
            DataRow r1,r2,r3;
            foreach (DataRow r in dt.Rows)
            {
                d_soluong = (r[11].ToString() == "") ? 0 : decimal.Parse(r[11].ToString());
                //if (d_soluong == 0) continue;
                if (r[0].ToString().Trim() != "")
                {
                    d_tenbd = r[8].ToString();
                    r1 = d.getrowbyid(dtdm, "ten='" + d_tenbd + "'");
                    if (r1 != null) d_idbd = int.Parse(r1["id"].ToString());
                    else continue;

                    r2 = d.getrowbyid(dtvp, "ma='" + r[6].ToString() + "'");
                    if (r2 != null) d_idvp = int.Parse(r2["id"].ToString());
                    else continue;

                    r3 = d.getrowbyid(dtxn, "ID_VIENPHI=" + d_idvp + "");
                    if (r3 != null) d_id_ten = int.Parse(r3["id"].ToString());
                    else continue;

                    d_soluong = (r[11].ToString() == "") ? 0 : decimal.Parse(r[11].ToString());
                    d_haohut = (r[12].ToString() == "") ? 0 : int.Parse(r[12].ToString());
                    d_sttimp = (r[0].ToString() == "") ? 0 : int.Parse(r[0].ToString());
                }
            }
        }

        private void imp_dmgiavp_chuyenctu(string file)
        {
            string sql = "";            
            dtdm = d.get_data("select * from " + d.user + ".v_giavp ").Tables[0];
            dt = get_excel(path.Text).Tables[0];

            DataRow r1;
            int i_stt = 0;
            string d_mavp = "",  s_cn = "";
            int i_col_chinhanh = 16;//13 - cn1;  14 - cn2.....
            foreach (DataRow r in dt.Rows)
            {
                if (r[4].ToString() != "" && r[i_col_chinhanh].ToString().Trim()!="" && r[i_col_chinhanh].ToString().Trim() != "0" && r[i_col_chinhanh].ToString().Trim() != "-1") 
                {
                    d_mavp = r[4].ToString();
                    i_stt = int.Parse(r[0].ToString());
                    r1 = d.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "' and stt=" + i_stt);
                    if (r1 != null)
                    {

                        s_cn = r[i_col_chinhanh].ToString();//13 - cn1;  14 - cn2....
                        if (s_cn.Trim() != "" && s_cn.Trim() != "-1")
                        {
                            sql = " update medibv.v_giavp set ";
                            sql += " guinguoi=0, guimau=0, chuyenchungtu=1, coso="+s_cn;                            
                            sql += " where id=" + r1["id"].ToString();
                        }
                        d.execute_data(sql);
                    }
                }
            }
        }

        private void imp_dmgiavp_chuyennguoi(string file)
        {
            string sql = "";
            dtdm = d.get_data("select * from " + d.user + ".v_giavp ").Tables[0];
            dt = get_excel(path.Text).Tables[0];

            DataRow r1;
            int i_stt = 0;
            string d_mavp = "", s_cn = "";
            int i_col_chinhanh = 24;//19 - cn1;  20 - cn2....
            foreach (DataRow r in dt.Rows)
            {
                if (r[4].ToString() != "" && r[i_col_chinhanh].ToString().Trim() != "" && r[i_col_chinhanh].ToString().Trim() != "0" && r[i_col_chinhanh].ToString().Trim() != "-1")
                {
                    d_mavp = r[4].ToString();
                    i_stt = int.Parse(r[0].ToString());
                    r1 = d.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "' and stt=" + i_stt);
                    if (r1 != null)
                    {

                        s_cn = r[i_col_chinhanh].ToString();//19 - cn1;  20 - cn2....
                        if (s_cn.Trim() != "" && s_cn.Trim() != "-1")
                        {
                            sql = " update medibv.v_giavp set ";
                            sql += " guinguoi=1, guimau=0, chuyenchungtu=0, coso=" + s_cn;
                            sql += " where id=" + r1["id"].ToString();
                        }
                        d.execute_data(sql);
                    }
                }
            }
        }
        private void imp_dmgiavp_tuyen(string file)
        {
            string sql = "";
            dtdm = d.get_data("select * from " + d.user + ".v_giavp ").Tables[0];
            dt = get_excel(path.Text).Tables[0];

            DataRow r1;
            int i_tw = 0, i_tinh = 0, i_huyen = 0, i_xa = 0, i_tuyen = 0;
            int i_stt = 0;
            string d_mavp = "", s_mack = "", s_manhom = "";
            foreach (DataRow r in dt.Rows)
            {
                if (r[1].ToString().Trim() != "")
                {
                    d_mavp = r[4].ToString();
                    i_stt = int.Parse(r[0].ToString());
                    r1 = d.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "' and stt=" + i_stt);
                    if (r1 != null)
                    {
                        s_manhom = r[3].ToString();
                        s_mack = r[2].ToString();


                        i_tuyen = int.Parse(r[5].ToString());
                        i_xa = i_tuyen == 4 ? 1 : 0;
                        i_huyen = i_tuyen == 3 ? 1 : 0;
                        i_tinh = i_tuyen == 2 ? 1 : 0;
                        i_tw = i_tuyen == 1 ? 1 : 0;

                        sql = " update medibv.v_giavp set ";
                        sql += " tuyentw=" + i_tw + ", tuyentinh=" + i_tinh + ", tuyenhuyen=" + i_huyen + ",tuyenxa=" + i_xa;
                        if (i_tw == 1) sql += " , bhyt_tt=30";
                        else if (i_tinh == 1) sql += " , bhyt_tt=50";
                        else sql += ", bhyt_tt=bhyt";
                        sql += " where id=" + r1["id"].ToString();
                        d.execute_data(sql);
                    }
                }
            }
        }
        private void imp_dmgiavp_xamlan(string file)
        {
            string sql = "";
            dtdm = d.get_data("select * from " + d.user + ".v_giavp ").Tables[0];
            dt = get_excel(path.Text).Tables[0];

            DataRow r1;
            int i_stt = 0;
            string d_mavp = "",  s_cn = "";
            int i_col_chinhanh = 13;//xam lan
            foreach (DataRow r in dt.Rows)
            {
                if (r[4].ToString() != "" && r[i_col_chinhanh].ToString().Trim() != "" && r[i_col_chinhanh].ToString().Trim() != "0" && r[i_col_chinhanh].ToString().Trim() != "-1")
                {
                    d_mavp = r[4].ToString();
                    i_stt = int.Parse(r[0].ToString());
                    r1 = d.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "' and stt=" + i_stt);
                    if (r1 != null)
                    {

                        s_cn = r[i_col_chinhanh].ToString();//12
                        if (s_cn.Trim() != "" && s_cn.Trim() != "-1")
                        {
                            sql = " update medibv.v_giavp set ";
                            sql += " xamlan=1 ";
                            sql += " where id=" + r1["id"].ToString();
                        }
                        d.execute_data(sql);
                    }
                }
            }
        }

        private void chkdinhmuc_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void imp_dinhmuc_ktcls(string file)
        {
            dtdm = d.get_data("select id, ma, ten from " + d.user + ".d_dmbd where vtyt=1 ").Tables[0];
            dt = get_excel(path.Text).Tables[0];
            DataTable dtvp = d.get_data("select id,ma, ten from medibv.v_giavp").Tables[0];
            //
            string sql = "alter table medibv.cdha_dinhmuc_thuocvattu add idvp numeric default 0";
            d.execute_data(sql);
            sql = "alter table medibv.cdha_dinhmuc_thuocvattu add stt numeric default 0";
            d.execute_data(sql);
            sql = "alter table medibv.cdha_dinhmuc_thuocvattu add ghichu text";
            d.execute_data(sql);
            sql = "alter table medibv.cdha_dinhmuc_thuocvattu add haohut numeric default 0";
            d.execute_data(sql);
            
            string d_tenbd = "", v_makt = "", v_ghichu = "";
            int  d_idvp = 0, d_idbd = 0,  d_haohut = 0, d_sttimp = 0;
            decimal d_soluong = 0;
            DataRow r1, r2;
            foreach (DataRow r in dt.Rows)
            {
                if (r[7].ToString().Trim() != "")
                {
                    d_tenbd = r[7].ToString();
                    r1 = d.getrowbyid(dtdm, "ten='" + d_tenbd + "'");
                    if (r1 != null) d_idbd = int.Parse(r1["id"].ToString());
                    else continue;

                    v_makt = r[5].ToString();//makt
                    r2 = d.getrowbyid(dtvp, "ma='" + v_makt + "'");
                    if (r2 != null) d_idvp = int.Parse(r2["id"].ToString());
                    else continue;
                                      
                    try{d_soluong = (r[10].ToString() == "") ? 0 : decimal.Parse(r[10].ToString());}
                    catch{d_soluong=0;}
                    try{d_haohut = (r[11].ToString() == "") ? 0 : int.Parse(r[11].ToString());}
                    catch{d_haohut=0;}
                    try{d_sttimp = (r[0].ToString() == "") ? 0 : int.Parse(r[0].ToString());}
                    catch{d_sttimp=0;}
                    v_ghichu = "";// r[13].ToString();
                }
            }
        }

        private void imp_dmkt_sytduyet(string file)
        {          
            dtdm = d.get_data("select * from " + d.user + ".v_giavp ").Tables[0];
            dt = get_excel(path.Text).Tables[0];

            DataRow r1;
            decimal l_id = 0;
            int i_stt = 0;
            string d_mavp = "";
            int v_ad1 = 0, v_ad2 = 0, v_ad3 = 0, v_ad4 = 0, v_ad5 = 0, v_ad6 = 0;
            int v_tuyen = 7;
            foreach (DataRow r in dt.Rows)
            {
                if (r[5].ToString().Trim() != "")
                {
                    d_mavp = r[5].ToString();
                    i_stt = int.Parse(r[0].ToString());
                    r1 = d.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "'");
                    if (r1 != null)
                    {
                        l_id = decimal.Parse(r1["id"].ToString());
                        d_mavp = r[5].ToString();
                        v_tuyen = (r[7].ToString() == "") ? 7 : int.Parse(r[7].ToString());
                        v_ad1 = (r[13].ToString() == "") ? 0 : 1;
                        v_ad2 = (r[14].ToString() == "") ? 0 : 1;
                        v_ad3 = (r[15].ToString() == "") ? 0 : 1;
                        v_ad4 = (r[16].ToString() == "") ? 0 : 1;
                        v_ad5 = (r[17].ToString() == "") ? 0 : 1;
                        v_ad6 = (r[18].ToString() == "") ? 0 : 1;
                    }
                }
            }
        }

        private void imp_dmkt_guimau(string file)
        {
            string sql = "";
            dtdm = d.get_data("select * from " + d.user + ".v_giavp ").Tables[0];
            dt = get_excel(path.Text).Tables[0];

            DataRow r1;
            decimal l_id = 0;
            string d_mavp = "";
            int v_gm1 = 0, v_gm2 = 0, v_gm3 = 0, v_gm4 = 0, v_gm5 = 0, v_gm6 = 0;
            int v_bv1 = 0, v_bv2 = 0, v_bv3 = 0, v_bv4 = 0, v_bv5 = 0, v_bv6 = 0;
            //
            string asql="insert into medibv.v_dmkt_duyet (id, ma) ";
            asql += " select a.id, a.ma from medibv.v_giavp a left join medibv.v_dmkt_duyet b on a.id=b.id where b.id is null ";
            d.execute_data(asql);
            //
            foreach (DataRow r in dt.Rows)
            {
                if (r[5].ToString().Trim() != "")
                {
                    d_mavp = r[5].ToString();
                   // i_stt = int.Parse(r[0].ToString());
                    r1 = d.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "'");
                    if (r1 != null)
                    {
                        l_id = decimal.Parse(r1["id"].ToString());
                        d_mavp = r[5].ToString();
                        //v_tuyen = (r[6].ToString() == "") ? 7 : int.Parse(r[6].ToString());
                        //7
                        v_gm1 = (r[6].ToString() == "Gửi" && r[7].ToString() == "CN3") ? 3 : 0;
                        v_gm2 = (r[8].ToString() == "Gửi" && r[9].ToString() == "CN3") ? 3 : 0;
                        v_gm3 = (r[10].ToString() == "Gửi" && r[11].ToString() == "CN3") ? 3 : 0;
                        v_gm4 = (r[12].ToString() == "Gửi" && r[13].ToString() == "CN3") ? 3 : 0;
                        v_gm5 = (r[14].ToString() == "Gửi" && r[15].ToString() == "CN3") ? 3 : 0;
                        v_gm6 = (r[16].ToString() == "Gửi" && r[17].ToString() == "CN3") ? 3 : 0;
                        //13-18: ap dung
                        v_bv1 = (r[6].ToString() == "Gửi") ? (r[7].ToString() == "MEDIC") ? 1 : ((r[7].ToString() == "Đại học Y dược") ? 2 : 0) : 0;
                        v_bv2 = (r[8].ToString() == "Gửi") ? (r[9].ToString() == "MEDIC") ? 1 : ((r[9].ToString() == "Đại học Y dược") ? 2 : 0) : 0;
                        v_bv3 = (r[10].ToString() == "Gửi") ? (r[11].ToString() == "MEDIC") ? 1 : ((r[11].ToString() == "Đại học Y dược") ? 1 : 0) : 0;
                        v_bv4 = (r[12].ToString() == "Gửi") ? (r[13].ToString() == "MEDIC") ? 1 : ((r[13].ToString() == "Đại học Y dược") ? 1 : 0) : 0;
                        v_bv5 = (r[14].ToString() == "Gửi") ? (r[15].ToString() == "MEDIC") ? 1 : ((r[15].ToString() == "Đại học Y dược") ? 1 : 0) : 0;
                        v_bv6 = (r[16].ToString() == "Gửi") ? (r[17].ToString() == "MEDIC") ? 1 : ((r[17].ToString() == "Đại học Y dược") ? 1 : 0) : 0;
                                                
                        sql = " update medibv.v_dmkt_duyet set gm_1 =" + v_gm1 + ", gm_2 =" + v_gm2 + ", gm_3 =" + v_gm3 + ", gm_4 =" + v_gm4 + ", gm_5 =" + v_gm5 + ", gm_6 =" + v_gm6 + ",";
                        sql += " gbv_1 =" + v_bv1 + ", gbv_2 =" + v_bv2 + ", gbv_3 =" + v_bv3 + ", gbv_4 =" + v_bv4 + ", gbv_5 =" + v_bv5 + ", gbv_6 =" + v_bv6 + "";
                        sql += " where id=" + l_id;
                        d.execute_data(sql);
                        //
                        //
                    }
                }
            }
        }

        private void imp_dmkt_camdoan(string file)
        {
            string sql = "";
            dtdm = d.get_data("select * from " + d.user + ".v_giavp ").Tables[0];
            dt = get_excel(path.Text).Tables[0];

            DataRow r1;
            decimal l_id = 0;

            string d_mavp = "";
            int v_camdoan = 0, v_hoichan = 0, v_xamlan = 0;
            foreach (DataRow r in dt.Rows)
            {
                if (r[5].ToString().Trim() != "")
                {
                    d_mavp = r[5].ToString();
                    r1 = d.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "'");
                    if (r1 != null)
                    {
                        l_id = decimal.Parse(r1["id"].ToString());
                        d_mavp = r[5].ToString();v_camdoan  = (r[6].ToString() == "") ? 7 : int.Parse(r[6].ToString());
                        //7-12: syt
                        v_camdoan  = (r[26].ToString() == "0") ? 0 : 1;
                        v_hoichan  = (r[25].ToString() == "0") ? 0 : 1;
                        v_xamlan  = (r[27].ToString() == "0") ? 0 : 1;
                        
                        sql = "update medibv.v_giavp set hoichan=" + v_hoichan + ", giaycamdoan=" + v_camdoan + ", xamlan=" + v_xamlan + " where id = " + l_id;
                        d.execute_data(sql);
                        sql = "update medibv.v_giavp@medisoft_cn1 set hoichan=" + v_hoichan + ", giaycamdoan=" + v_camdoan + ", xamlan=" + v_xamlan + " where id = " + l_id;
                        d.execute_data(sql);
                        sql = "update medibv.v_giavp@medisoft_cn2 set hoichan=" + v_hoichan + ", giaycamdoan=" + v_camdoan + ", xamlan=" + v_xamlan + " where id = " + l_id;
                        d.execute_data(sql);
                        sql = "update medibv.v_giavp@medisoft_cn3 set hoichan=" + v_hoichan + ", giaycamdoan=" + v_camdoan + ", xamlan=" + v_xamlan + " where id = " + l_id;
                        d.execute_data(sql);
                        sql = "update medibv.v_giavp@medisoft_cn4 set hoichan=" + v_hoichan + ", giaycamdoan=" + v_camdoan + ", xamlan=" + v_xamlan + " where id = " + l_id;
                        d.execute_data(sql);
                        sql = "update medibv.v_giavp@medisoft_cn5 set hoichan=" + v_hoichan + ", giaycamdoan=" + v_camdoan + ", xamlan=" + v_xamlan + " where id = " + l_id;
                        d.execute_data(sql);
                        sql = "update medibv.v_giavp@medisoft_cn6 set hoichan=" + v_hoichan + ", giaycamdoan=" + v_camdoan + ", xamlan=" + v_xamlan + " where id = " + l_id;
                        d.execute_data(sql);
                    }
                }
            }
        }

        private void imp_dmbs(string file)
        {
            string sql = "";
            
            dt = get_excel(path.Text).Tables[0];
            string m_mabs, m_hoten = "";
            int m_nhom = 0;
            foreach (DataRow r in dt.Rows)
            {
                if (r[5].ToString().Trim().Length == 4)
                {
                    m_mabs = r[5].ToString();
                    m_hoten = r[4].ToString().ToUpper();
                    m_nhom = int.Parse(r[9].ToString());
                    sql = "update medibv_vn.dmbs set hoten='" + m_hoten + "' where ma='" + m_mabs + "'";
                    m.execute_data(sql);

                    sql = "update medibv_en.dmbs set hoten='" + m_hoten + "' where ma='" + m_mabs + "'";
                    m.execute_data(sql);
                }
            }
            DialogResult thongbao;
            thongbao = MessageBox.Show("Cập nhật danh mục Bác sỹ thành công", "Quản lý dược", MessageBoxButtons.OK, MessageBoxIcon.None);
            if (thongbao == DialogResult.OK) this.Close();
        }

        private void imp_vattu_xuattheothang(string file)
        {
            dtdm = d.get_data("select id, ma, ten from " + d.user + ".d_dmbd where vtyt=1 ").Tables[0];
            dt = get_excel(path.Text).Tables[0];

            string sql = "";

            //m.f_kiemtra_idduoc_idgiavp();
            
            string  d_ma="",d_tenbd = "";
            int d_idbd = 0, i_xuatthang = 0;
            DataRow r1;
            foreach (DataRow r in dt.Rows)
            {               
                if (r[7].ToString().Trim() != "")
                {
                    d_ma = r[7].ToString();
                    d_tenbd = r[4].ToString();
                    r1 = d.getrowbyid(dtdm, "ma='" + d_ma + "'");
                    if (r1 != null) d_idbd = int.Parse(r1["id"].ToString());
                    else
                    {
                        r1 = d.getrowbyid(dtdm, "ten='" + d_tenbd + "'");
                        if (r1 != null) d_idbd = int.Parse(r1["id"].ToString());
                        else continue;
                    }
                    i_xuatthang = (r[9].ToString().Trim().ToUpper() == "X") ? 1 : 0;

                    sql = "update medibv.d_dmbd set xuatthang=" + i_xuatthang + " where id=" + d_idbd;
                    d.execute_data(sql);

                }
            }
        }
        private void imp_dmbs_dlogin()
        {
            dtdm = d.get_data("select * from " + d.user + ".dmbs where nhom<8 ").Tables[0];//bs
            //dt = get_excel(path.Text).Tables[0];
            int m_id=0, m_nhom=0;
            string m_userid = "", m_hoten = "", m_pw = "", m_makp = "", m_right = "", m_madoituong = "", m_nhomkho = "", m_cls = "", m_mabs = "", m_may = "";
            foreach (DataRow r in dtdm.Rows)
            {
                m_id = int.Parse(r["chinhanh"].ToString()+ m.get_capid(-30).ToString().PadLeft(3,'0'));
                m_hoten = r["hoten"].ToString();
                string[] arrten = m_hoten.Split(' ');
                if (arrten.Length > 0) m_userid = m.Hoten_khongdau(arrten[arrten.Length -2] + arrten[arrten.Length - 1]).ToLower();
                if (m_userid != "")
                {
                    m_pw = m_userid;
                    m_madoituong = ""; m_right = ""; m_nhomkho = ""; m_cls = ""; m_may = "?";
                    m_mabs = r["ma"].ToString();
                    m.upd_dlogin(m_id, m_hoten, m_userid, m_pw, m_nhom, m_makp, m_right, m_madoituong, m_nhomkho, m_cls, m_mabs, m_may);
                    m_may = "update medibv.dlogin set chinhanh=" + r["chinhanh"].ToString() + " where id=" + m_id;
                    m.execute_data(m_may);
                }
            }
        }
        private void imp_dmkt_tgtrakq(string file)
        {
            string sql = "";
            dtdm = d.get_data("select * from " + d.user + ".v_giavp ").Tables[0];
            dt = get_excel(path.Text).Tables[0];

            DataRow r1;
            decimal l_id = 0;
            string d_mavp = "";
            string v_tg1 ="", v_tg2 = "", v_tg3 = "", v_tg4 = "", v_tg5 = "", v_tg6 = "";
            string v_tgkq1 = "", v_tgkq2 = "", v_tgkq3 = "", v_tgkq4 = "", v_tgkq5 = "", v_tgkq6 = "";
            
            int v_col = 7;
            string[] arrkq;
            foreach (DataRow r in dt.Rows)
            {
                if (r[5].ToString().Trim() != "")
                {
                    d_mavp = r[5].ToString();
                    //i_stt = int.Parse(r[0].ToString());
                    r1 = d.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "'");
                    if (r1 != null)
                    {
                        l_id = decimal.Parse(r1["id"].ToString());
                        d_mavp = r[5].ToString();
                        //
                        v_col = 6;
                        v_tgkq1 = r[v_col].ToString();
                        arrkq = r[v_col].ToString().Split(' ');
                        if (arrkq.Length == 3)
                        {
                            if (arrkq[0] == "Sau") v_tg1 = "0";//"1";
                            else v_tg1 = "0";
                            v_tg1 += arrkq[1].PadLeft(7, '0');
                            v_tg1 = v_tg1 + "-";
                            if (arrkq[2] == "ngày") v_tg1 += "1";
                            else if (arrkq[2] == "giờ") v_tg1 += "0";
                        }
                        //7
                        v_col += 1;
                        v_tgkq2 = r[v_col].ToString();
                        arrkq = r[v_col].ToString().Split(' ');
                        if (arrkq.Length == 3)
                        {
                            if (arrkq[0] == "Sau") v_tg2 = "0";//"1";
                            else v_tg2 = "0";
                            v_tg2 += arrkq[1].PadLeft(7, '0');
                            v_tg2 = v_tg2 + "-";
                            if (arrkq[2] == "ngày") v_tg2 += "1";
                            else if (arrkq[2] == "giờ") v_tg2 += "0";
                        }
                        v_col += 1;
                        v_tgkq3 = r[v_col].ToString();
                        arrkq = r[v_col].ToString().Split(' ');
                        if (arrkq.Length == 3)
                        {
                            if (arrkq[0] == "Sau") v_tg3 = "0";//"1";
                            else v_tg3 = "0";
                            v_tg3 += arrkq[1].PadLeft(7, '0');
                            v_tg3 = v_tg3 + "-";
                            if (arrkq[2] == "ngày") v_tg3 += "1";
                            else if (arrkq[2] == "giờ") v_tg3 += "0";
                        }
                        v_col += 1;
                        v_tgkq4 = r[v_col].ToString();
                        arrkq = r[v_col].ToString().Split(' ');
                        if (arrkq.Length == 3)
                        {
                            if (arrkq[0] == "Sau") v_tg4 = "0";//"1";
                            else v_tg4 = "0";
                            v_tg4 += arrkq[1].PadLeft(7, '0');
                            v_tg4 = v_tg4 + "-";
                            if (arrkq[2] == "ngày") v_tg4 += "1";
                            else if (arrkq[2] == "giờ") v_tg4 += "0";
                        }
                        v_col += 1;
                        v_tgkq5 = r[v_col].ToString();
                        arrkq = r[v_col].ToString().Split(' ');
                        if (arrkq.Length == 3)
                        {
                            if (arrkq[0] == "Sau") v_tg5 = "0";//"1";
                            else v_tg5 = "0";
                            v_tg5 += arrkq[1].PadLeft(7, '0');
                            v_tg5 = v_tg5 + "-";
                            if (arrkq[2] == "ngày") v_tg5 += "1";
                            else if (arrkq[2] == "giờ") v_tg5 += "0";
                        }
                        v_col += 1;
                        v_tgkq6 = r[v_col].ToString();
                        arrkq = r[v_col].ToString().Split(' ');
                        if (arrkq.Length == 3)
                        {
                            if (arrkq[0] == "Sau") v_tg6 = "0";//"1";
                            else v_tg6 = "0";
                            v_tg6 += arrkq[1].PadLeft(7, '0');
                            v_tg6 = v_tg6 + "-";
                            if (arrkq[2] == "ngày") v_tg6 += "1";
                            else if (arrkq[2] == "giờ") v_tg6 += "0";
                        }
                        sql = "update medibv.v_dmkt_duyet set tgtkq_1 ='" + v_tg1 + "', tgtkq_2 ='" + v_tg2 + "', tgtkq_3 ='" + v_tg3 + "', tgtkq_4 ='" + v_tg4 + "', tgtkq_5 ='" + v_tg5 + "', tgtkq_6 ='" + v_tg6 + "'";
                        sql+= ",tgtrakq_1 ='" + v_tgkq1 + "', tgtrakq_2 ='" + v_tgkq2 + "', tgtrakq_3 ='" + v_tgkq3 + "', tgtrakq_4 ='" + v_tgkq4 + "', tgtrakq_5 ='" + v_tgkq5 + "', tgtrakq_6 ='" + v_tgkq6 + "'";                        
                        sql += " where id=" + l_id;
                        d.execute_data(sql);

                    }
                }
            }
        }

        private void chkgiadm_td_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void imp_giatondau_DMBD(string file)
        {
            dtdm = d.get_data("select * from " + d.user + ".d_dmbd where vtyt=0 ").Tables[0];
            dt = get_excel(path.Text).Tables[0];
            LibMedi.AccessData m = new LibMedi.AccessData();
            //m.f_kiemtra_idduoc_idgiavp();
            decimal l_id = 0;
            decimal  d_giaban = 0;
            foreach (DataRow r in dt.Rows)
            {
                if (r[1].ToString().Trim() != "")
                {

                    l_id = decimal.Parse(r[1].ToString());
                    DataRow rr = d.getrowbyid(dtdm, "id=" + l_id);
                    if (rr != null)
                    {
                        d_giaban = Math.Round(decimal.Parse(r[4].ToString()),0);
                    }

                }
            }
        }

        private void chkdinhmuc_cls_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void imp_dinhmuc_MANHOM_ktcls(string file)
        {
            dtdm = d.get_data("select id, ma, ten from " + d.user + ".d_dmbd where vtyt=1 ").Tables[0];
            dt = get_excel(path.Text).Tables[0];
            DataTable dtvp = d.get_data("select id,ma, ten, manhom from medibv.v_giavp where id in(619, 620, 621 )").Tables[0];
            string sql = "alter table medibv.cdha_dinhmuc_thuocvattu add idvp numeric default 0";
            d.execute_data(sql);
            sql = "alter table medibv.cdha_dinhmuc_thuocvattu add stt numeric default 0";
            d.execute_data(sql);
            sql = "alter table medibv.cdha_dinhmuc_thuocvattu add ghichu text";
            d.execute_data(sql);
            sql = "alter table medibv.cdha_dinhmuc_thuocvattu add haohut numeric default 0";
            d.execute_data(sql);

            //m.f_kiemtra_idduoc_idgiavp();
            string  d_tenbd = "", v_makt = "", v_ghichu = "", d_mavt = "", d_manhom = "";
            int d_idvp = 0, d_idbd = 0,  d_haohut = 0, d_sttimp = 0;
            decimal d_soluong = 0;
            DataRow r1;
            DataTable dtnhom = d.get_data("select distinct id, ma, machuyenkhoa from medibv.v_giavp where machuyenkhoa is not null and id in(619, 620, 621 ) ").Tables[0];

            foreach(DataRow rnhom in dtnhom.Select("","machuyenkhoa"))
            {
                if (rnhom["machuyenkhoa"].ToString().ToLower() == "") continue;
                v_makt = rnhom["ma"].ToString();//makt
                d_idvp = int.Parse(rnhom["id"].ToString());
                foreach (DataRow r in dt.Select("mack='" + rnhom["machuyenkhoa"].ToString() + "'")) //.Rows)
                {
                    if (r[2].ToString().ToLower() != rnhom["machuyenkhoa"].ToString().ToLower()) continue;
                    if (r[2].ToString().Trim() != "" && r[9].ToString().Trim() != "" && r[10].ToString().Trim() != "")
                    {
                        d_tenbd = r[5].ToString();
                        d_mavt = r[9].ToString();
                        d_manhom = r[2].ToString();

                        r1 = d.getrowbyid(dtdm, "ma='" + d_mavt + "'");
                        if (r1 != null) d_idbd = int.Parse(r1["id"].ToString());
                        else continue;

                        d_haohut = 0;
                        d_soluong = 1;
                        d_sttimp = 0;

                        v_ghichu = "";// r[13].ToString();
                       // d.upd_cdha_dinhmuc_thuocvattu(d_idbd, d_soluong, d_haohut, 1, 5, v_makt, v_ghichu, d_sttimp, d_idvp);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mmyy = m.mmyy(m.Ngaygio_hienhanh.Substring(0, 10));
            if (txt1.Text.IndexOf("xxx") < 0) mmyy = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string asql = "select ma, id, bhyt, round(giaban,0) as giaban, round(gia_bh_novat,0) as gia_bh_novat, round(gianovat) as gianovat from medibv.d_dmbd";//cty
            DataSet ldscty = m.get_data(asql);
            Cursor = Cursors.WaitCursor;
            asql = "select ma, id, bhyt, round(giaban,0) as giaban, round(gia_bh_novat,0) as gia_bh_novat, round(gianovat) as gianovat from medibv.d_dmbd@medisoft_cn" + txtcn.Text;//cn
            DataSet ldscn = m.get_data(asql);
            DataRow r1;
            int ij = 0, iz=0;
            string s_ma = "";
            bool bluu = chkluugia.Checked;
            foreach (DataRow r in ldscty.Tables[0].Rows)
            {
                r1 = m.getrowbyid(ldscn.Tables[0], "id=" + r["id"].ToString() + " and bhyt<>" + r["bhyt"].ToString());
                if (r1 != null)
                {
                    asql = "update medibv.d_dmbd@medisoft_cn" + txtcn.Text + " set bhyt=" + r["bhyt"].ToString() + " where id=" + r["id"].ToString() + " and bhyt<>" + r["bhyt"].ToString();
                    if(bluu)m.execute_data(asql);
                    ij += 1;
                }
                r1 = m.getrowbyid(ldscn.Tables[0], "id=" + r["id"].ToString() + " and giaban<>" + r["giaban"].ToString());
                if (r1 != null)
                {
                    asql = "update medibv.d_dmbd@medisoft_cn" + txtcn.Text + " set giaban=" + r["giaban"].ToString() + " where id=" + r["id"].ToString();
                    if (bluu) m.execute_data(asql);
                    iz += 1;
                }

                 r1 = m.getrowbyid(ldscn.Tables[0], "id=" + r["id"].ToString() + " and gianovat<>" + r["gianovat"].ToString());
                 if (r1 != null)
                 {
                     asql = "update medibv.d_dmbd@medisoft_cn" + txtcn.Text + " set gianovat=" + r["gianovat"].ToString() + " where id=" + r["id"].ToString();
                     if (bluu) m.execute_data(asql);
                     s_ma += "'" + r["ma"].ToString() + "',";
                     iz += 1;
                 }
                 r1 = m.getrowbyid(ldscn.Tables[0], "id=" + r["id"].ToString() + " and gia_bh_novat<>" + r["gia_bh_novat"].ToString());
                 if (r1 != null)
                 {
                     asql = "update medibv.d_dmbd@medisoft_cn" + txtcn.Text + " set gia_bh_novat=" + r["gia_bh_novat"].ToString() + " where id=" + r["id"].ToString();
                     if (bluu) m.execute_data(asql);
                     if(s_ma.IndexOf(r["ma"].ToString())<0) s_ma += "'"+r["ma"].ToString() + "',";
                     iz += 1;
                 }
            }
            textBox2.Text = s_ma;
            Cursor = Cursors.Default;
            MessageBox.Show("Có " + ij.ToString() + " thuốc, vật tư khac ty le bhyt so voi danh muc tai cty" + "\nCó " + iz.ToString() + " thuốc khác giá bán.");
            Cursor = Cursors.WaitCursor;
            //
            asql = "select id, bhyt from medibv.v_giavp";//cty
            ldscty = m.get_data(asql);

            asql = "select id, bhyt from medibv.v_giavp@medisoft_cn" + txtcn.Text;//cn
            ldscn = m.get_data(asql);            
            ij = 0;
            foreach (DataRow r in ldscty.Tables[0].Rows)
            {
                r1 = m.getrowbyid(ldscn.Tables[0], "id=" + r["id"].ToString() + " and bhyt<>" + r["bhyt"].ToString());
                if (r1 != null)
                {
                    asql = "update medibv.v_giavp@medisoft_cn" + txtcn.Text + " set bhyt=" + r["bhyt"].ToString() + " where id=" + r["id"].ToString() + " and bhyt<>" + r["bhyt"].ToString();
                    m.execute_data(asql);
                    ij += 1;
                }
            }
            Cursor = Cursors.Default;
            MessageBox.Show("Có " + ij.ToString() + " Kỹ thuật khac ty le bhyt so voi danh muc tai cty");
        }

        private void button4_Click(object sender, EventArgs e)
        {
           // m.reset_sequence_current(m.ngayhienhanh_server.Substring(0, 10));
        }

        private void imp_dmgiavp_01012012(string file)//05052012-Phuoc
        {
        
        }

        private void imp_dmgiavp_maphongcmy_mack_manhom(string file)
        {
            LibVP.AccessData m_v = new LibVP.AccessData();
            dtdm = d.get_data("select * from " + d.user + ".v_giavp ").Tables[0];
            dt = get_excel(path.Text).Tables[0];

            DataRow r1;

            decimal l_id = 0;
            int i_stt = 0;
            string d_mavp = "", s_mapcmy = "", s_mack = "", s_manhom = "";
            foreach (DataRow r in dt.Rows)
            {
                if (r[5].ToString() != "")
                {
                    d_mavp = r[5].ToString();
                    i_stt = int.Parse(r[0].ToString());
                    r1 = d.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "'");
                    if (r1 != null)
                    {
                        s_mapcmy = r[4].ToString();
                        s_mack = r[2].ToString();
                        s_manhom = r[3].ToString(); 
                        l_id = decimal.Parse(r1["id"].ToString());
                        //i_hide = (r[i_col_chinhanh].ToString().ToLower() == "x") ? 0 : 1;
                        d.execute_data("update medibv.v_giavp set maphongcmy='" + s_mapcmy + "', manhom='" + s_manhom + "', machuyenkhoa='" + s_mack + "' where id=" + l_id);
                    }
                }
            }
        }
        private void butnuochangnhacc_Click(object sender, EventArgs e)
        {
            CapNhatMaHangNuocNhacc();
        }

        private void CapNhatMaHangNuocNhacc()
        {
            string asql = "select distinct hangsx from medibv.d_dmbd ";
            DataSet dshang = d.get_data(asql);
            asql="select id, ten from medibv.d_dmhang ";
            DataSet dshang1 = d.get_data(asql);

            asql = "select distinct nuocsx from medibv.d_dmbd ";
            DataSet dsnuoc = d.get_data(asql);
            asql="select id, ten from medibv.d_dmnuoc ";
            DataSet dsnuoc1 = d.get_data(asql);

            asql = "select distinct nhacungcap from medibv.d_dmbd ";
            DataSet dsnhacc = d.get_data(asql);
            asql="select id, ten from medibv.d_dmnx ";
            DataSet dsnhacc1 = d.get_data(asql);

            DataRow r2;
            decimal i_idhangsx = 0, i_idnuocsx = 0, i_idnhacc = 0;
            //Cap nhat hang sx 
            foreach (DataRow r1 in dshang.Tables[0].Rows)
            {
                i_idhangsx=0;
                if (r1["hangsx"].ToString().Trim() == "")
                {
                    i_idhangsx = 0;
                    asql = "update medibv.d_dmbd set mahang=0 where hangsx='' or hangsx is null ";
                    d.execute_data(asql);
                    continue;
                }

                r2 = d.getrowbyid(dshang1.Tables[0], "ten='" + r1["hangsx"].ToString().Trim() + "'");
                if (r2 == null)
                {
                    for (; ; )
                    {
                        i_idhangsx = d.get_id_dmhang;
                        asql = "select id from medibv.d_dmhang where id=" + i_idhangsx;
                        if (d.get_data(asql).Tables[0].Rows.Count <= 0) break;
                    }
                    d.upd_dmhang(i_idhangsx,"", r1["hangsx"].ToString().Trim(), 1, 1, i_idhangsx);
                    asql = "update medibv.d_dmbd set mahang=" + i_idhangsx + " where mahang=0 and hangsx='" + r1["hangsx"].ToString().Trim()+ "'";
                    d.execute_data(asql);
                }
                else
                {
                    i_idhangsx = int.Parse(r2["id"].ToString());
                    asql = "update medibv.d_dmbd set mahang=" + i_idhangsx + " where mahang=0 and hangsx='" + r1["hangsx"].ToString().Trim() + "'";
                    d.execute_data(asql);
                }
            }

            //Cap nhat nuoc sx 
            foreach (DataRow r1 in dsnuoc.Tables[0].Rows)
            {
                i_idnuocsx = 0;
                if (r1["nuocsx"].ToString().Trim() == "")
                {
                    i_idnuocsx = 0;
                    asql = "update medibv.d_dmbd set manuoc=0 where nuocsx='' or nuocsx is null ";
                    d.execute_data(asql);
                    continue;
                }

                r2 = d.getrowbyid(dsnuoc1.Tables[0], "ten='" + r1["nuocsx"].ToString().Trim() + "'");
                if (r2 == null)
                {
                    
                    for (; ; )
                    {
                        i_idnuocsx = d.get_id_dmnuoc;
                        asql = "select id from medibv.d_dmnuoc where id=" + i_idnuocsx;
                        if (d.get_data(asql).Tables[0].Rows.Count <= 0) break;
                    }
                    d.upd_dmnuoc(i_idnuocsx,"", r1["nuocsx"].ToString().Trim(), 1, 1, i_idnuocsx);
                    asql = "update medibv.d_dmbd set manuoc=" + i_idnuocsx + " where manuoc=0 and nuocsx='" + r1["nuocsx"].ToString().Trim() + "'";
                    d.execute_data(asql);
                }
                else
                {
                    i_idnuocsx = int.Parse(r2["id"].ToString());
                    asql = "update medibv.d_dmbd set manuoc=" + i_idnuocsx + " where manuoc=0 and nuocsx='" + r1["nuocsx"].ToString().Trim() + "'";
                    d.execute_data(asql);
                }
            }

            //Cap nhat nha cung cap 
            foreach (DataRow r1 in dsnhacc.Tables[0].Rows)
            {
                i_idnhacc  = 0;
                if (r1["nhacungcap"].ToString().Trim() == "")
                {
                    i_idhangsx = 0;
                    asql = "update medibv.d_dmbd set madv=0 where nhacungcap='' or nhacungcap is null ";
                    d.execute_data(asql);
                    continue;
                }

                r2 = d.getrowbyid(dsnhacc1.Tables[0], "ten='" + r1["nhacungcap"].ToString().Trim() + "'");
                if (r2 == null)
                {
                    
                    for (; ; )
                    {
                        i_idnhacc = d.get_id_dmnx;
                        asql = "select id from medibv.d_dmnx where id=" + i_idnhacc;
                        if (d.get_data(asql).Tables[0].Rows.Count <= 0) break;
                    }
                    d.upd_dmhang(i_idnhacc,"", r1["nhacungcap"].ToString().Trim(), 1, 1, i_idnhacc);
                    asql = "update medibv.d_dmbd set madv=" + i_idnhacc + " where nhacungcap='" + r1["nhacungcap"].ToString().Trim() + "'";
                    d.execute_data(asql);
                }
                else
                {
                    i_idnhacc  = int.Parse(r2["id"].ToString());
                    asql = "update medibv.d_dmbd set madv=" + i_idnhacc + " where nuocsx='" + r1["nhacungcap"].ToString().Trim() + "'";
                    d.execute_data(asql);
                }
            }
        }

        private void imp_dmgiavp_chinhanhapdung(string file, int i_cn)
        {
            string sql = "";
            dtdm = d.get_data("select * from " + d.user + ".v_giavp ").Tables[0];
            dt = get_excel(path.Text).Tables[0];

            DataRow r1;
            int i_stt = 0;
            string d_mavp = "", s_cn = "";
            int i_col_chinhanh = 12 + i_cn;//chi nhanh ap dung
            foreach (DataRow r in dt.Rows)
            {
                if (r[5].ToString() != "")// && r[i_col_chinhanh].ToString().Trim() != "" && r[i_col_chinhanh].ToString().Trim() != "0" && r[i_col_chinhanh].ToString().Trim() != "-1")
                {
                    d_mavp = r[5].ToString();
                    i_stt = int.Parse(r[0].ToString());
                    r1 = d.getrowbyid(dtdm, "trim(ma)='" + d_mavp + "'");
                    if (r1 != null)
                    {

                        s_cn = r[i_col_chinhanh].ToString();//

                        sql = " update medibv.v_giavp set ";
                        if (s_cn.Trim() == "x") sql += " hide=1 ";
                        else sql += " hide=0 ";
                        sql += " where id=" + r1["id"].ToString();

                        d.execute_data(sql);
                    }
                }
            }
        }

        private void imp_dmgiavp_15042012(string file)//05052012-Phuoc
        {
            
        }

        private void chkdmbd_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkdmnk_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}