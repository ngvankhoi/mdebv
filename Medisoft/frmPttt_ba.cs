using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;
using LibVienphi;

namespace Medisoft
{
	public class frmPttt_ba : System.Windows.Forms.Form
    {
        #region Khai bao
        Language lan = new Language();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox hoten;
		private MaskedTextBox.MaskedTextBox mabn2;
		private System.Windows.Forms.TextBox tuoi;
		private System.Windows.Forms.TextBox phai;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.TextBox giuong;
		private System.Windows.Forms.ComboBox tenkp;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.ComboBox loaipt;
		private System.Windows.Forms.TextBox phuongphap;
		private System.Windows.Forms.ComboBox tenphuongphap;
		private System.Windows.Forms.TextBox mabs;
		private System.Windows.Forms.ComboBox taibien;
		private System.Windows.Forms.ComboBox tuvong;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.TextBox icd_vk;
		private System.Windows.Forms.TextBox cd_vk;
		private MaskedTextBox.MaskedTextBox icd_t;
		private MaskedTextBox.MaskedTextBox mapt;
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
        private string m_makp, m_mabn, m_hoten, m_tuoi, m_phai, m_diachi, m_sothe, s_msg, m_loaipt, m_ngayra, s_nhomvp_pttt;
		private string s_mabn,m_tuoivao,m_loaituoi,m_giuong,m_ngayvv,m_cd_vk,m_icd_vk,s_ngay,user,xxx,mmyy,nam;
		private int m_userid,songay,i_traituyen=0;
		private System.Windows.Forms.ComboBox tinhhinh;
		private decimal l_maql,l_id,l_idvpkhoa,l_idkhoa,l_idduoc;
		private System.Windows.Forms.TextBox sophieu;
		private bool bStatus=false,b_bacsi,bAdmin,bPttt_pmo,bMat,bPttt_vp,bPttt_thuoc,bEdit_vp,bTiepdon_pttt,bSophieu,bHoisuc,bChandoan,bCapso,bPttt_tsoduoc,bPhucap,bPttt_makp_user;
		private MaskedTextBox.MaskedTextBox icd_s;
		private LibList.List listpttt;
		private System.Windows.Forms.TextBox tenpt;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button butPttt;
		private System.ComponentModel.IContainer components;
		private string s_icd_t="",s_icd_s="",sql,s_makp,s_madoituong,s_sovaovien;
		private System.Windows.Forms.TextBox cd_t;
		private System.Windows.Forms.TextBox cd_s;
		private LibList.List listICD;
		private DataTable dticd=new DataTable();
		private LibList.List listBS;
		private DataTable dtpt=new DataTable();
		private DataSet dsngay=new DataSet();
		private DataSet dsmau=new DataSet();
		private DataTable dtvp=new DataTable();
		private DataTable dtmavp=new DataTable();
		private DataTable dtduockp=new DataTable();
		private DataSet dslmau=new DataSet();
		private DataSet ds=new DataSet();
		private System.Windows.Forms.TextBox tenbs;
		private System.Windows.Forms.Label label11;
		private MaskedBox.MaskedBox nhietdo;
		private MaskedTextBox.MaskedTextBox huyetap;
		private MaskedTextBox.MaskedTextBox mach;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.TextBox phu1;
		private System.Windows.Forms.TextBox tenphu1;
		private System.Windows.Forms.TextBox tenphu2;
		private System.Windows.Forms.TextBox phu2;
		private System.Windows.Forms.TextBox tenktvgayme;
		private System.Windows.Forms.TextBox ktvgayme;
		private System.Windows.Forms.TextBox tenbsgayme;
		private System.Windows.Forms.TextBox bsgayme;
		private System.Windows.Forms.TextBox tendungcu;
		private System.Windows.Forms.TextBox dungcu;
		private System.Windows.Forms.TextBox tenhoisuc;
		private System.Windows.Forms.TextBox hoisuc;
		private System.Windows.Forms.Label label35;
		private MaskedTextBox.MaskedTextBox mamau;
		private System.Windows.Forms.TextBox tenmau;
		private System.Windows.Forms.CheckBox chktuongtrinh;
		private System.Windows.Forms.ComboBox mautuongtrinh;
		private System.Windows.Forms.TextBox noidung; 
		private DataTable dtbs=new DataTable();
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.ComboBox loaibn;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label lmat;
		private System.Windows.Forms.ComboBox mapmo;
		private System.Windows.Forms.NumericUpDown somat;
		private DataSet dsmo=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataSet dsloaibn=new DataSet();
		private DataTable dtpm=new DataTable();
		private System.Windows.Forms.CheckBox molaimien;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.ComboBox loaivp;
		private System.Windows.Forms.TextBox sotien;
		private System.Windows.Forms.ComboBox mavp;
		private System.Windows.Forms.Button butThuoc;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.TextBox mabn3;
		private MaskedBox.MaskedBox ngay;
		private MaskedBox.MaskedBox ngaykt;
		private MaskedBox.MaskedBox gio;
		private MaskedBox.MaskedBox giokt;
		private System.Windows.Forms.ComboBox lmau;
		private System.Windows.Forms.TextBox tenpttt;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private MaskedBox.MaskedBox giovv;
		private MaskedBox.MaskedBox ngayvv;
		private System.Windows.Forms.CheckBox chkXem;
		private DataTable dtkp=new DataTable();
		private System.Windows.Forms.Button butThem;
        private dllReportM.Print print = new dllReportM.Print();
		private string makho,manguon,ngay_thuoc,mmyy_thuoc;
		private int nhom,kp,loai,phieu,makhoa;
		private System.Windows.Forms.ComboBox ngayvao;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Button butHinh;
		private System.Windows.Forms.CheckBox chkXML;
		private System.Windows.Forms.CheckBox noisoi;
		private System.Windows.Forms.Button butRef;
		private AsYetUnnamedColor.MultiColumnListBoxColor list;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.CheckBox butTuongtrinh;
		private AsYetUnnamedColor.MultiColumnListBoxColor listMo;
		private System.Windows.Forms.TextBox timmo;
		private System.Windows.Forms.CheckBox bienchung;
		private decimal l_duyet;
        private int i_loaiba;
        private int i_maxlenghth_mabn = 8;
        #endregion

        public frmPttt_ba(LibMedi.AccessData acc,string makp,string mabn,string hoten,string tuoi,string phai,string diachi,string sothe,string giuong,string ngayvv,string cd_vk,string icd_vk,string loaipt,int userid,string ngayra,string _makp,string _madoituong,string _makho,string _manguon,string _mmyy,int imakp,int _nhom,int _loai,int _phieu,decimal _duyet,string _ngay,int _makhoa, int traituyen)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m_makp=makp;m_mabn=mabn;m_hoten=hoten;m_tuoi=tuoi;m_phai=phai;m_diachi=diachi;m_sothe=sothe;
			m_giuong=giuong;m_ngayvv=ngayvv;m_cd_vk=cd_vk;m_icd_vk=icd_vk;m_userid=userid;makhoa=_makhoa;
			m=acc;s_makp=_makp;s_madoituong=_madoituong;m_loaipt=loaipt;m_ngayra=ngayra;ngay_thuoc=_ngay;
			kp=imakp;loai=_loai;phieu=_phieu;makho=_makho;manguon=_manguon;mmyy_thuoc=_mmyy;l_duyet=_duyet;nhom=_nhom;
            i_traituyen = traituyen;
			if (m_tuoi.Length==4)
			{
				switch (int.Parse(m_tuoi.Substring(3,1)))
				{
					case 0: m_loaituoi="TU";
						break;
					case 1: m_loaituoi="TH";
						break;
					case 2: m_loaituoi="NG";
						break;
					default: m_loaituoi="GI";
						break;
				}
				m_tuoi=m_tuoi.Substring(0,3)+m_loaituoi;
			}
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        public frmPttt_ba(LibMedi.AccessData acc, string makp, string mabn, string hoten, string tuoi, string phai, string diachi, string sothe, string giuong, string ngayvv, string cd_vk, string icd_vk, string loaipt, int userid, string ngayra, string _makp, string _madoituong, string _makho, string _manguon, string _mmyy, int imakp, int _nhom, int _loai, int _phieu, decimal _duyet, string _ngay, int _makhoa, int traituyen,int _loaiba)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m_makp = makp; m_mabn = mabn; m_hoten = hoten; m_tuoi = tuoi; m_phai = phai; m_diachi = diachi; m_sothe = sothe;
            m_giuong = giuong; m_ngayvv = ngayvv; m_cd_vk = cd_vk; m_icd_vk = icd_vk; m_userid = userid; makhoa = _makhoa;
            m = acc; s_makp = _makp; s_madoituong = _madoituong; m_loaipt = loaipt; m_ngayra = ngayra; ngay_thuoc = _ngay;
            kp = imakp; loai = _loai; phieu = _phieu; makho = _makho; manguon = _manguon; mmyy_thuoc = _mmyy; l_duyet = _duyet; nhom = _nhom;
            i_traituyen = traituyen; i_loaiba = _loaiba;
            if (m_tuoi.Length == 4)
            {
                switch (int.Parse(m_tuoi.Substring(3, 1)))
                {
                    case 0: m_loaituoi = "TU";
                        break;
                    case 1: m_loaituoi = "TH";
                        break;
                    case 2: m_loaituoi = "NG";
                        break;
                    default: m_loaituoi = "GI";
                        break;
                }
                m_tuoi = m_tuoi.Substring(0, 3) + m_loaituoi;
            }
        }

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPttt_ba));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.mabn2 = new MaskedTextBox.MaskedTextBox();
            this.tuoi = new System.Windows.Forms.TextBox();
            this.phai = new System.Windows.Forms.TextBox();
            this.diachi = new System.Windows.Forms.TextBox();
            this.sothe = new System.Windows.Forms.TextBox();
            this.giuong = new System.Windows.Forms.TextBox();
            this.tenkp = new System.Windows.Forms.ComboBox();
            this.makp = new System.Windows.Forms.TextBox();
            this.icd_vk = new System.Windows.Forms.TextBox();
            this.cd_vk = new System.Windows.Forms.TextBox();
            this.icd_t = new MaskedTextBox.MaskedTextBox();
            this.mapt = new MaskedTextBox.MaskedTextBox();
            this.loaipt = new System.Windows.Forms.ComboBox();
            this.phuongphap = new System.Windows.Forms.TextBox();
            this.tenphuongphap = new System.Windows.Forms.ComboBox();
            this.mabs = new System.Windows.Forms.TextBox();
            this.tinhhinh = new System.Windows.Forms.ComboBox();
            this.taibien = new System.Windows.Forms.ComboBox();
            this.tuvong = new System.Windows.Forms.ComboBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.sophieu = new System.Windows.Forms.TextBox();
            this.icd_s = new MaskedTextBox.MaskedTextBox();
            this.listpttt = new LibList.List();
            this.tenpt = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.butPttt = new System.Windows.Forms.Button();
            this.butRef = new System.Windows.Forms.Button();
            this.list = new AsYetUnnamedColor.MultiColumnListBoxColor();
            this.listMo = new AsYetUnnamedColor.MultiColumnListBoxColor();
            this.cd_t = new System.Windows.Forms.TextBox();
            this.cd_s = new System.Windows.Forms.TextBox();
            this.listICD = new LibList.List();
            this.listBS = new LibList.List();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.nhietdo = new MaskedBox.MaskedBox();
            this.huyetap = new MaskedTextBox.MaskedTextBox();
            this.mach = new MaskedTextBox.MaskedTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.phu1 = new System.Windows.Forms.TextBox();
            this.tenphu1 = new System.Windows.Forms.TextBox();
            this.tenphu2 = new System.Windows.Forms.TextBox();
            this.phu2 = new System.Windows.Forms.TextBox();
            this.tenktvgayme = new System.Windows.Forms.TextBox();
            this.ktvgayme = new System.Windows.Forms.TextBox();
            this.tenbsgayme = new System.Windows.Forms.TextBox();
            this.bsgayme = new System.Windows.Forms.TextBox();
            this.tendungcu = new System.Windows.Forms.TextBox();
            this.dungcu = new System.Windows.Forms.TextBox();
            this.tenhoisuc = new System.Windows.Forms.TextBox();
            this.hoisuc = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.mamau = new MaskedTextBox.MaskedTextBox();
            this.tenmau = new System.Windows.Forms.TextBox();
            this.chktuongtrinh = new System.Windows.Forms.CheckBox();
            this.mautuongtrinh = new System.Windows.Forms.ComboBox();
            this.noidung = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.loaibn = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.lmat = new System.Windows.Forms.Label();
            this.mapmo = new System.Windows.Forms.ComboBox();
            this.somat = new System.Windows.Forms.NumericUpDown();
            this.molaimien = new System.Windows.Forms.CheckBox();
            this.butHuy = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.loaivp = new System.Windows.Forms.ComboBox();
            this.sotien = new System.Windows.Forms.TextBox();
            this.mavp = new System.Windows.Forms.ComboBox();
            this.butThuoc = new System.Windows.Forms.Button();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.mabn3 = new System.Windows.Forms.TextBox();
            this.ngay = new MaskedBox.MaskedBox();
            this.ngaykt = new MaskedBox.MaskedBox();
            this.gio = new MaskedBox.MaskedBox();
            this.giokt = new MaskedBox.MaskedBox();
            this.lmau = new System.Windows.Forms.ComboBox();
            this.tenpttt = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.giovv = new MaskedBox.MaskedBox();
            this.ngayvv = new MaskedBox.MaskedBox();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.butThem = new System.Windows.Forms.Button();
            this.ngayvao = new System.Windows.Forms.ComboBox();
            this.label42 = new System.Windows.Forms.Label();
            this.butHinh = new System.Windows.Forms.Button();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.noisoi = new System.Windows.Forms.CheckBox();
            this.tim = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.butTuongtrinh = new System.Windows.Forms.CheckBox();
            this.timmo = new System.Windows.Forms.TextBox();
            this.bienchung = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.somat)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(895, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 80;
            this.label1.Text = "Số phiếu :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(859, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 72;
            this.label2.Text = "Mã BN :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(288, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 73;
            this.label3.Text = "Họ tên :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(656, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 23);
            this.label4.TabIndex = 75;
            this.label4.Text = "Tuổi :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(432, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "&Khoa :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(552, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 23);
            this.label6.TabIndex = 83;
            this.label6.Text = "Phẫu thủ thuật lúc :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Location = new System.Drawing.Point(158, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 23);
            this.label7.TabIndex = 94;
            this.label7.Text = "CĐ Trước phẫu thủ thuật :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Location = new System.Drawing.Point(150, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(184, 23);
            this.label8.TabIndex = 95;
            this.label8.Text = "CĐ Sau phẫu thủ thuật :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.Location = new System.Drawing.Point(198, 514);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 23);
            this.label9.TabIndex = 98;
            this.label9.Text = "Phương pháp vô cảm :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label10.Location = new System.Drawing.Point(72, 827);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(192, 23);
            this.label10.TabIndex = 9;
            this.label10.Text = "Phương pháp phẫu thủ thuật :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label12.Location = new System.Drawing.Point(198, 134);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(136, 23);
            this.label12.TabIndex = 93;
            this.label12.Text = "Chẩn đoán vào khoa :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label13.Location = new System.Drawing.Point(800, 803);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 23);
            this.label13.TabIndex = 97;
            this.label13.Text = "Loại :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label14.Location = new System.Drawing.Point(597, 514);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 23);
            this.label14.TabIndex = 99;
            this.label14.Text = "Phẫu thủ thuật viên :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label15.Location = new System.Drawing.Point(552, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 23);
            this.label15.TabIndex = 74;
            this.label15.Text = "Giới tính :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label16.Location = new System.Drawing.Point(728, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 76;
            this.label16.Text = "Địa chỉ :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label17.Location = new System.Drawing.Point(280, 60);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 23);
            this.label17.TabIndex = 77;
            this.label17.Text = "Số thẻ :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label18.Location = new System.Drawing.Point(624, 60);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 23);
            this.label18.TabIndex = 78;
            this.label18.Text = "Giường :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label19.Location = new System.Drawing.Point(264, 83);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 23);
            this.label19.TabIndex = 81;
            this.label19.Text = "Vào viện lúc :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(827, 111);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(184, 96);
            this.treeView1.TabIndex = 110;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // label20
            // 
            this.label20.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label20.Location = new System.Drawing.Point(198, 614);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(136, 23);
            this.label20.TabIndex = 106;
            this.label20.Text = "Tình hình :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label21.Location = new System.Drawing.Point(417, 614);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 23);
            this.label21.TabIndex = 107;
            this.label21.Text = "Tai biến :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label22.Location = new System.Drawing.Point(659, 614);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 23);
            this.label22.TabIndex = 108;
            this.label22.Text = "Tử vong :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(334, 33);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(226, 23);
            this.hoten.TabIndex = 7;
            // 
            // mabn2
            // 
            this.mabn2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn2.Location = new System.Drawing.Point(912, 6);
            this.mabn2.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabn2.MaxLength = 2;
            this.mabn2.Name = "mabn2";
            this.mabn2.Size = new System.Drawing.Size(23, 23);
            this.mabn2.TabIndex = 7;
            this.mabn2.Validated += new System.EventHandler(this.mabn2_Validated);
            // 
            // tuoi
            // 
            this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoi.Enabled = false;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(688, 33);
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(48, 23);
            this.tuoi.TabIndex = 9;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(608, 33);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(48, 23);
            this.phai.TabIndex = 8;
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(784, 33);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(226, 23);
            this.diachi.TabIndex = 10;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(334, 58);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(120, 23);
            this.sothe.TabIndex = 11;
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.Enabled = false;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(688, 58);
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(48, 23);
            this.giuong.TabIndex = 13;
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(520, 6);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(160, 24);
            this.tenkp.TabIndex = 5;
            this.tenkp.SelectedIndexChanged += new System.EventHandler(this.tenkp_SelectedIndexChanged);
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(488, 6);
            this.makp.MaxLength = 2;
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(30, 23);
            this.makp.TabIndex = 4;
            this.makp.Validated += new System.EventHandler(this.makp_Validated);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // icd_vk
            // 
            this.icd_vk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_vk.Enabled = false;
            this.icd_vk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_vk.Location = new System.Drawing.Point(334, 134);
            this.icd_vk.Name = "icd_vk";
            this.icd_vk.Size = new System.Drawing.Size(56, 23);
            this.icd_vk.TabIndex = 26;
            // 
            // cd_vk
            // 
            this.cd_vk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_vk.Enabled = false;
            this.cd_vk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_vk.Location = new System.Drawing.Point(392, 134);
            this.cd_vk.Name = "cd_vk";
            this.cd_vk.Size = new System.Drawing.Size(433, 23);
            this.cd_vk.TabIndex = 27;
            // 
            // icd_t
            // 
            this.icd_t.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_t.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_t.Enabled = false;
            this.icd_t.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_t.Location = new System.Drawing.Point(334, 158);
            this.icd_t.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_t.MaxLength = 9;
            this.icd_t.Name = "icd_t";
            this.icd_t.Size = new System.Drawing.Size(56, 23);
            this.icd_t.TabIndex = 28;
            this.icd_t.Validated += new System.EventHandler(this.icd_t_Validated);
            // 
            // mapt
            // 
            this.mapt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mapt.Enabled = false;
            this.mapt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapt.Location = new System.Drawing.Point(248, 819);
            this.mapt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mapt.MaxLength = 6;
            this.mapt.Name = "mapt";
            this.mapt.Size = new System.Drawing.Size(56, 23);
            this.mapt.TabIndex = 33;
            this.mapt.Validated += new System.EventHandler(this.mapt_Validated);
            // 
            // loaipt
            // 
            this.loaipt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaipt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaipt.Enabled = false;
            this.loaipt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaipt.Location = new System.Drawing.Point(633, 208);
            this.loaipt.Name = "loaipt";
            this.loaipt.Size = new System.Drawing.Size(64, 24);
            this.loaipt.TabIndex = 34;
            // 
            // phuongphap
            // 
            this.phuongphap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phuongphap.Enabled = false;
            this.phuongphap.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phuongphap.Location = new System.Drawing.Point(334, 514);
            this.phuongphap.MaxLength = 2;
            this.phuongphap.Name = "phuongphap";
            this.phuongphap.Size = new System.Drawing.Size(24, 23);
            this.phuongphap.TabIndex = 37;
            this.phuongphap.Validated += new System.EventHandler(this.phuongphap_Validated);
            this.phuongphap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phuongphap_KeyDown);
            // 
            // tenphuongphap
            // 
            this.tenphuongphap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenphuongphap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenphuongphap.Enabled = false;
            this.tenphuongphap.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenphuongphap.Location = new System.Drawing.Point(359, 514);
            this.tenphuongphap.Name = "tenphuongphap";
            this.tenphuongphap.Size = new System.Drawing.Size(257, 24);
            this.tenphuongphap.TabIndex = 38;
            this.tenphuongphap.SelectedIndexChanged += new System.EventHandler(this.tenphuongphap_SelectedIndexChanged);
            this.tenphuongphap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenphuongphap_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(714, 514);
            this.mabs.MaxLength = 4;
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(38, 23);
            this.mabs.TabIndex = 39;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // tinhhinh
            // 
            this.tinhhinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tinhhinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tinhhinh.Enabled = false;
            this.tinhhinh.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinhhinh.Location = new System.Drawing.Point(334, 614);
            this.tinhhinh.Name = "tinhhinh";
            this.tinhhinh.Size = new System.Drawing.Size(91, 24);
            this.tinhhinh.TabIndex = 53;
            this.tinhhinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tinhhinh_KeyDown);
            // 
            // taibien
            // 
            this.taibien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.taibien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.taibien.Enabled = false;
            this.taibien.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taibien.Location = new System.Drawing.Point(473, 614);
            this.taibien.Name = "taibien";
            this.taibien.Size = new System.Drawing.Size(111, 24);
            this.taibien.TabIndex = 54;
            this.taibien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.taibien_KeyDown);
            // 
            // tuvong
            // 
            this.tuvong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuvong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tuvong.Enabled = false;
            this.tuvong.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuvong.Location = new System.Drawing.Point(714, 614);
            this.tuvong.Name = "tuvong";
            this.tuvong.Size = new System.Drawing.Size(118, 24);
            this.tuvong.TabIndex = 56;
            this.tuvong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tuvong_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.BackColor = System.Drawing.SystemColors.Control;
            this.butMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butMoi.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(197, 667);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 28);
            this.butMoi.TabIndex = 64;
            this.butMoi.Text = "     &Mới";
            this.butMoi.UseVisualStyleBackColor = false;
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.BackColor = System.Drawing.SystemColors.Control;
            this.butSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSua.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(267, 667);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 28);
            this.butSua.TabIndex = 65;
            this.butSua.Text = "    &Sửa";
            this.butSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSua.UseVisualStyleBackColor = false;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.BackColor = System.Drawing.SystemColors.Control;
            this.butLuu.Enabled = false;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(421, 667);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 28);
            this.butLuu.TabIndex = 62;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.UseVisualStyleBackColor = false;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.BackColor = System.Drawing.SystemColors.Control;
            this.butBoqua.Enabled = false;
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(631, 667);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 28);
            this.butBoqua.TabIndex = 63;
            this.butBoqua.Text = "    &Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.UseVisualStyleBackColor = false;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butIn
            // 
            this.butIn.BackColor = System.Drawing.SystemColors.Control;
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(561, 667);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 28);
            this.butIn.TabIndex = 68;
            this.butIn.Text = "      &In";
            this.butIn.UseVisualStyleBackColor = false;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // sophieu
            // 
            this.sophieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sophieu.Enabled = false;
            this.sophieu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sophieu.Location = new System.Drawing.Point(967, 58);
            this.sophieu.Name = "sophieu";
            this.sophieu.Size = new System.Drawing.Size(43, 23);
            this.sophieu.TabIndex = 15;
            this.sophieu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sophieu_KeyPress);
            this.sophieu.Validated += new System.EventHandler(this.sophieu_Validated);
            this.sophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // icd_s
            // 
            this.icd_s.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_s.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_s.Enabled = false;
            this.icd_s.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_s.Location = new System.Drawing.Point(334, 183);
            this.icd_s.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_s.MaxLength = 9;
            this.icd_s.Name = "icd_s";
            this.icd_s.Size = new System.Drawing.Size(56, 23);
            this.icd_s.TabIndex = 30;
            this.icd_s.Validated += new System.EventHandler(this.icd_s_Validated);
            // 
            // listpttt
            // 
            this.listpttt.BackColor = System.Drawing.SystemColors.Info;
            this.listpttt.ColumnCount = 0;
            this.listpttt.Location = new System.Drawing.Point(472, 723);
            this.listpttt.MatchBufferTimeOut = 1000;
            this.listpttt.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listpttt.Name = "listpttt";
            this.listpttt.Size = new System.Drawing.Size(75, 17);
            this.listpttt.TabIndex = 39;
            this.listpttt.TextIndex = -1;
            this.listpttt.TextMember = null;
            this.listpttt.ValueIndex = -1;
            this.listpttt.Visible = false;
            this.listpttt.Validated += new System.EventHandler(this.listpttt_Validated);
            // 
            // tenpt
            // 
            this.tenpt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenpt.Enabled = false;
            this.tenpt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenpt.Location = new System.Drawing.Point(312, 819);
            this.tenpt.Name = "tenpt";
            this.tenpt.Size = new System.Drawing.Size(433, 23);
            this.tenpt.TabIndex = 34;
            this.tenpt.Validated += new System.EventHandler(this.tenpt_Validated);
            this.tenpt.TextChanged += new System.EventHandler(this.tenpt_TextChanged);
            this.tenpt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenpt_KeyDown);
            // 
            // butPttt
            // 
            this.butPttt.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butPttt.Location = new System.Drawing.Point(88, 795);
            this.butPttt.Name = "butPttt";
            this.butPttt.Size = new System.Drawing.Size(22, 22);
            this.butPttt.TabIndex = 40;
            this.butPttt.Text = "...";
            this.toolTip1.SetToolTip(this.butPttt, "Liệt kê danh mục phẫu thuật - thủ thuật");
            this.butPttt.Visible = false;
            this.butPttt.Click += new System.EventHandler(this.butPttt_Click);
            // 
            // butRef
            // 
            this.butRef.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butRef.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butRef.Location = new System.Drawing.Point(185, 1);
            this.butRef.Name = "butRef";
            this.butRef.Size = new System.Drawing.Size(22, 21);
            this.butRef.TabIndex = 72;
            this.butRef.Text = "...";
            this.toolTip1.SetToolTip(this.butRef, "Danh sách người bệnh");
            this.butRef.Click += new System.EventHandler(this.butRef_Click);
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Enabled = false;
            this.list.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list.Location = new System.Drawing.Point(0, 25);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamedColor.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(208, 316);
            this.list.TabIndex = 1;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.toolTip1.SetToolTip(this.list, "F7 chọn");
            this.list.ValueIndex = -1;
            this.list.DoubleClick += new System.EventHandler(this.list_DoubleClick);
            this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
            // 
            // listMo
            // 
            this.listMo.BackColor = System.Drawing.SystemColors.Info;
            this.listMo.ColumnCount = 0;
            this.listMo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listMo.Location = new System.Drawing.Point(0, 368);
            this.listMo.MatchBufferTimeOut = 1000;
            this.listMo.MatchEntryStyle = AsYetUnnamedColor.MatchEntryStyle.FirstLetterInsensitive;
            this.listMo.Name = "listMo";
            this.listMo.Size = new System.Drawing.Size(208, 290);
            this.listMo.TabIndex = 266;
            this.listMo.TextIndex = -1;
            this.listMo.TextMember = null;
            this.toolTip1.SetToolTip(this.listMo, "F7 chọn");
            this.listMo.ValueIndex = -1;
            // 
            // cd_t
            // 
            this.cd_t.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_t.Enabled = false;
            this.cd_t.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_t.Location = new System.Drawing.Point(392, 158);
            this.cd_t.Name = "cd_t";
            this.cd_t.Size = new System.Drawing.Size(433, 23);
            this.cd_t.TabIndex = 29;
            this.cd_t.TextChanged += new System.EventHandler(this.cd_t_TextChanged);
            this.cd_t.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_t_KeyDown);
            // 
            // cd_s
            // 
            this.cd_s.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_s.Enabled = false;
            this.cd_s.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_s.Location = new System.Drawing.Point(392, 182);
            this.cd_s.Name = "cd_s";
            this.cd_s.Size = new System.Drawing.Size(433, 23);
            this.cd_s.TabIndex = 31;
            this.cd_s.TextChanged += new System.EventHandler(this.cd_s_TextChanged);
            this.cd_s.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_t_KeyDown);
            // 
            // listICD
            // 
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(336, 723);
            this.listICD.MatchBufferTimeOut = 1000;
            this.listICD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listICD.Name = "listICD";
            this.listICD.Size = new System.Drawing.Size(75, 17);
            this.listICD.TabIndex = 223;
            this.listICD.TextIndex = -1;
            this.listICD.TextMember = null;
            this.listICD.ValueIndex = -1;
            this.listICD.Visible = false;
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(184, 739);
            this.listBS.MatchBufferTimeOut = 1000;
            this.listBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS.Name = "listBS";
            this.listBS.Size = new System.Drawing.Size(75, 17);
            this.listBS.TabIndex = 224;
            this.listBS.TextIndex = -1;
            this.listBS.TextMember = null;
            this.listBS.ValueIndex = -1;
            this.listBS.Visible = false;
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(753, 514);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(255, 23);
            this.tenbs.TabIndex = 40;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label11.Location = new System.Drawing.Point(824, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 23);
            this.label11.TabIndex = 85;
            this.label11.Text = "đến";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhietdo
            // 
            this.nhietdo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhietdo.Enabled = false;
            this.nhietdo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhietdo.Location = new System.Drawing.Point(512, 109);
            this.nhietdo.Mask = "##.##";
            this.nhietdo.Name = "nhietdo";
            this.nhietdo.Size = new System.Drawing.Size(43, 23);
            this.nhietdo.TabIndex = 24;
            this.nhietdo.Text = "  .  ";
            // 
            // huyetap
            // 
            this.huyetap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyetap.Enabled = false;
            this.huyetap.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap.Location = new System.Drawing.Point(656, 109);
            this.huyetap.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.huyetap.MaxLength = 7;
            this.huyetap.Name = "huyetap";
            this.huyetap.Size = new System.Drawing.Size(56, 23);
            this.huyetap.TabIndex = 25;
            // 
            // mach
            // 
            this.mach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mach.Enabled = false;
            this.mach.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mach.Location = new System.Drawing.Point(334, 109);
            this.mach.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.mach.MaxLength = 5;
            this.mach.Name = "mach";
            this.mach.Size = new System.Drawing.Size(35, 23);
            this.mach.TabIndex = 23;
            this.mach.Validated += new System.EventHandler(this.mach_Validated);
            // 
            // label23
            // 
            this.label23.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label23.Location = new System.Drawing.Point(294, 109);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(40, 23);
            this.label23.TabIndex = 87;
            this.label23.Text = "Mạch :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label24.Location = new System.Drawing.Point(369, 109);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(48, 23);
            this.label24.TabIndex = 88;
            this.label24.Text = "lần/phút";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label25.Location = new System.Drawing.Point(448, 109);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(64, 23);
            this.label25.TabIndex = 89;
            this.label25.Text = "Nhiệt độ :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label26.Location = new System.Drawing.Point(555, 109);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(18, 23);
            this.label26.TabIndex = 90;
            this.label26.Text = "°C";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label27.Location = new System.Drawing.Point(600, 109);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(56, 23);
            this.label27.TabIndex = 91;
            this.label27.Text = "Huyết áp :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label28.Location = new System.Drawing.Point(712, 108);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(38, 23);
            this.label28.TabIndex = 92;
            this.label28.Text = "mmHg";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label29.Location = new System.Drawing.Point(198, 538);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(136, 23);
            this.label29.TabIndex = 100;
            this.label29.Text = "Phụ mỗ 1 :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label30
            // 
            this.label30.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label30.Location = new System.Drawing.Point(605, 538);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(112, 23);
            this.label30.TabIndex = 101;
            this.label30.Text = "Phụ mỗ 2 :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label31.Location = new System.Drawing.Point(198, 565);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(136, 23);
            this.label31.TabIndex = 102;
            this.label31.Text = "Gây mê 1 :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label32.Location = new System.Drawing.Point(597, 565);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(120, 23);
            this.label32.TabIndex = 103;
            this.label32.Text = "Gây mê 2 :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            this.label33.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label33.Location = new System.Drawing.Point(198, 589);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(136, 23);
            this.label33.TabIndex = 104;
            this.label33.Text = "Dụng cụ trong :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            this.label34.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label34.Location = new System.Drawing.Point(605, 589);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(112, 23);
            this.label34.TabIndex = 105;
            this.label34.Text = "Dụng cụ ngoài :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phu1
            // 
            this.phu1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phu1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.phu1.Enabled = false;
            this.phu1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phu1.Location = new System.Drawing.Point(334, 539);
            this.phu1.MaxLength = 4;
            this.phu1.Name = "phu1";
            this.phu1.Size = new System.Drawing.Size(38, 23);
            this.phu1.TabIndex = 41;
            this.phu1.Validated += new System.EventHandler(this.phu1_Validated);
            this.phu1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // tenphu1
            // 
            this.tenphu1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenphu1.Enabled = false;
            this.tenphu1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenphu1.Location = new System.Drawing.Point(374, 539);
            this.tenphu1.Name = "tenphu1";
            this.tenphu1.Size = new System.Drawing.Size(242, 23);
            this.tenphu1.TabIndex = 42;
            this.tenphu1.TextChanged += new System.EventHandler(this.tenphu1_TextChanged);
            this.tenphu1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // tenphu2
            // 
            this.tenphu2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenphu2.Enabled = false;
            this.tenphu2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenphu2.Location = new System.Drawing.Point(753, 539);
            this.tenphu2.Name = "tenphu2";
            this.tenphu2.Size = new System.Drawing.Size(255, 23);
            this.tenphu2.TabIndex = 44;
            this.tenphu2.TextChanged += new System.EventHandler(this.tenphu2_TextChanged);
            this.tenphu2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // phu2
            // 
            this.phu2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phu2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.phu2.Enabled = false;
            this.phu2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phu2.Location = new System.Drawing.Point(714, 539);
            this.phu2.MaxLength = 4;
            this.phu2.Name = "phu2";
            this.phu2.Size = new System.Drawing.Size(38, 23);
            this.phu2.TabIndex = 43;
            this.phu2.Validated += new System.EventHandler(this.phu2_Validated);
            this.phu2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // tenktvgayme
            // 
            this.tenktvgayme.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenktvgayme.Enabled = false;
            this.tenktvgayme.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenktvgayme.Location = new System.Drawing.Point(753, 564);
            this.tenktvgayme.Name = "tenktvgayme";
            this.tenktvgayme.Size = new System.Drawing.Size(255, 23);
            this.tenktvgayme.TabIndex = 48;
            this.tenktvgayme.TextChanged += new System.EventHandler(this.tenktvgayme_TextChanged);
            this.tenktvgayme.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // ktvgayme
            // 
            this.ktvgayme.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ktvgayme.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ktvgayme.Enabled = false;
            this.ktvgayme.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktvgayme.Location = new System.Drawing.Point(714, 564);
            this.ktvgayme.MaxLength = 4;
            this.ktvgayme.Name = "ktvgayme";
            this.ktvgayme.Size = new System.Drawing.Size(38, 23);
            this.ktvgayme.TabIndex = 47;
            this.ktvgayme.Validated += new System.EventHandler(this.ktvgayme_Validated);
            this.ktvgayme.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // tenbsgayme
            // 
            this.tenbsgayme.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbsgayme.Enabled = false;
            this.tenbsgayme.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbsgayme.Location = new System.Drawing.Point(374, 564);
            this.tenbsgayme.Name = "tenbsgayme";
            this.tenbsgayme.Size = new System.Drawing.Size(242, 23);
            this.tenbsgayme.TabIndex = 46;
            this.tenbsgayme.TextChanged += new System.EventHandler(this.tenbsgayme_TextChanged);
            this.tenbsgayme.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // bsgayme
            // 
            this.bsgayme.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bsgayme.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bsgayme.Enabled = false;
            this.bsgayme.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsgayme.Location = new System.Drawing.Point(334, 564);
            this.bsgayme.MaxLength = 4;
            this.bsgayme.Name = "bsgayme";
            this.bsgayme.Size = new System.Drawing.Size(38, 23);
            this.bsgayme.TabIndex = 45;
            this.bsgayme.Validated += new System.EventHandler(this.bsgayme_Validated);
            this.bsgayme.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // tendungcu
            // 
            this.tendungcu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendungcu.Enabled = false;
            this.tendungcu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendungcu.Location = new System.Drawing.Point(753, 589);
            this.tendungcu.Name = "tendungcu";
            this.tendungcu.Size = new System.Drawing.Size(255, 23);
            this.tendungcu.TabIndex = 52;
            this.tendungcu.TextChanged += new System.EventHandler(this.tendungcu_TextChanged);
            this.tendungcu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // dungcu
            // 
            this.dungcu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dungcu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dungcu.Enabled = false;
            this.dungcu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dungcu.Location = new System.Drawing.Point(714, 589);
            this.dungcu.MaxLength = 4;
            this.dungcu.Name = "dungcu";
            this.dungcu.Size = new System.Drawing.Size(38, 23);
            this.dungcu.TabIndex = 51;
            this.dungcu.Validated += new System.EventHandler(this.dungcu_Validated);
            this.dungcu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // tenhoisuc
            // 
            this.tenhoisuc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhoisuc.Enabled = false;
            this.tenhoisuc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhoisuc.Location = new System.Drawing.Point(374, 589);
            this.tenhoisuc.Name = "tenhoisuc";
            this.tenhoisuc.Size = new System.Drawing.Size(242, 23);
            this.tenhoisuc.TabIndex = 50;
            this.tenhoisuc.TextChanged += new System.EventHandler(this.tenhoisuc_TextChanged);
            this.tenhoisuc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // hoisuc
            // 
            this.hoisuc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoisuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoisuc.Enabled = false;
            this.hoisuc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoisuc.Location = new System.Drawing.Point(334, 589);
            this.hoisuc.MaxLength = 4;
            this.hoisuc.Name = "hoisuc";
            this.hoisuc.Size = new System.Drawing.Size(38, 23);
            this.hoisuc.TabIndex = 49;
            this.hoisuc.Validated += new System.EventHandler(this.hoisuc_Validated);
            this.hoisuc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // label35
            // 
            this.label35.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label35.Location = new System.Drawing.Point(180, 208);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(154, 23);
            this.label35.TabIndex = 96;
            this.label35.Text = "Phương pháp PTTT :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mamau
            // 
            this.mamau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mamau.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mamau.Enabled = false;
            this.mamau.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mamau.Location = new System.Drawing.Point(832, 875);
            this.mamau.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mamau.MaxLength = 10;
            this.mamau.Name = "mamau";
            this.mamau.Size = new System.Drawing.Size(83, 23);
            this.mamau.TabIndex = 27;
            this.mamau.Validated += new System.EventHandler(this.mamau_Validated);
            // 
            // tenmau
            // 
            this.tenmau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenmau.Enabled = false;
            this.tenmau.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenmau.Location = new System.Drawing.Point(334, 208);
            this.tenmau.Name = "tenmau";
            this.tenmau.Size = new System.Drawing.Size(83, 23);
            this.tenmau.TabIndex = 32;
            this.tenmau.TextChanged += new System.EventHandler(this.tenmau_TextChanged);
            this.tenmau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenpt_KeyDown);
            // 
            // chktuongtrinh
            // 
            this.chktuongtrinh.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chktuongtrinh.Enabled = false;
            this.chktuongtrinh.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chktuongtrinh.Location = new System.Drawing.Point(33, 723);
            this.chktuongtrinh.Name = "chktuongtrinh";
            this.chktuongtrinh.Size = new System.Drawing.Size(130, 24);
            this.chktuongtrinh.TabIndex = 59;
            this.chktuongtrinh.Text = "Tường trình theo mẫu";
            this.chktuongtrinh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chktuongtrinh.Visible = false;
            this.chktuongtrinh.CheckedChanged += new System.EventHandler(this.chktuongtrinh_CheckedChanged);
            this.chktuongtrinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // mautuongtrinh
            // 
            this.mautuongtrinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mautuongtrinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mautuongtrinh.Enabled = false;
            this.mautuongtrinh.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mautuongtrinh.Location = new System.Drawing.Point(168, 795);
            this.mautuongtrinh.Name = "mautuongtrinh";
            this.mautuongtrinh.Size = new System.Drawing.Size(624, 24);
            this.mautuongtrinh.TabIndex = 60;
            this.mautuongtrinh.Visible = false;
            this.mautuongtrinh.SelectedIndexChanged += new System.EventHandler(this.mautuongtrinh_SelectedIndexChanged);
            this.mautuongtrinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // noidung
            // 
            this.noidung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.noidung.Enabled = false;
            this.noidung.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noidung.Location = new System.Drawing.Point(334, 233);
            this.noidung.Multiline = true;
            this.noidung.Name = "noidung";
            this.noidung.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.noidung.Size = new System.Drawing.Size(674, 279);
            this.noidung.TabIndex = 36;
            // 
            // label36
            // 
            this.label36.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label36.Location = new System.Drawing.Point(262, 5);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(72, 23);
            this.label36.TabIndex = 70;
            this.label36.Text = "Người bệnh :";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loaibn
            // 
            this.loaibn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaibn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaibn.Enabled = false;
            this.loaibn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaibn.Location = new System.Drawing.Point(334, 6);
            this.loaibn.Name = "loaibn";
            this.loaibn.Size = new System.Drawing.Size(122, 24);
            this.loaibn.TabIndex = 2;
            this.loaibn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaibn_KeyDown);
            // 
            // label37
            // 
            this.label37.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label37.Location = new System.Drawing.Point(672, 5);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(68, 23);
            this.label37.TabIndex = 71;
            this.label37.Text = "Phòng mỗ :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmat
            // 
            this.lmat.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lmat.Location = new System.Drawing.Point(464, 84);
            this.lmat.Name = "lmat";
            this.lmat.Size = new System.Drawing.Size(48, 23);
            this.lmat.TabIndex = 82;
            this.lmat.Text = "Số mắt :";
            this.lmat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mapmo
            // 
            this.mapmo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapmo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapmo.Location = new System.Drawing.Point(744, 6);
            this.mapmo.Name = "mapmo";
            this.mapmo.Size = new System.Drawing.Size(128, 24);
            this.mapmo.TabIndex = 6;
            this.mapmo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mapmo_KeyDown);
            // 
            // somat
            // 
            this.somat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.somat.Enabled = false;
            this.somat.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.somat.Location = new System.Drawing.Point(512, 84);
            this.somat.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.somat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.somat.Name = "somat";
            this.somat.Size = new System.Drawing.Size(32, 23);
            this.somat.TabIndex = 18;
            this.somat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.somat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // molaimien
            // 
            this.molaimien.Enabled = false;
            this.molaimien.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.molaimien.Location = new System.Drawing.Point(920, 620);
            this.molaimien.Name = "molaimien";
            this.molaimien.Size = new System.Drawing.Size(104, 16);
            this.molaimien.TabIndex = 58;
            this.molaimien.Text = "Mỗ lại miễn phí";
            this.molaimien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // butHuy
            // 
            this.butHuy.BackColor = System.Drawing.SystemColors.Control;
            this.butHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butHuy.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(491, 667);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 28);
            this.butHuy.TabIndex = 67;
            this.butHuy.Text = "&Hủy";
            this.butHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butHuy.UseVisualStyleBackColor = false;
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.SystemColors.Control;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(803, 667);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 28);
            this.butKetthuc.TabIndex = 70;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label38
            // 
            this.label38.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label38.Location = new System.Drawing.Point(198, 640);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(136, 23);
            this.label38.TabIndex = 109;
            this.label38.Text = "Viện phí :";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loaivp
            // 
            this.loaivp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaivp.Enabled = false;
            this.loaivp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaivp.Location = new System.Drawing.Point(334, 640);
            this.loaivp.Name = "loaivp";
            this.loaivp.Size = new System.Drawing.Size(160, 24);
            this.loaivp.TabIndex = 59;
            this.loaivp.SelectedIndexChanged += new System.EventHandler(this.loaivp_SelectedIndexChanged);
            this.loaivp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavp_KeyDown);
            // 
            // sotien
            // 
            this.sotien.Enabled = false;
            this.sotien.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotien.Location = new System.Drawing.Point(920, 640);
            this.sotien.Name = "sotien";
            this.sotien.Size = new System.Drawing.Size(88, 23);
            this.sotien.TabIndex = 61;
            this.sotien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mavp
            // 
            this.mavp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mavp.Enabled = false;
            this.mavp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavp.Location = new System.Drawing.Point(496, 640);
            this.mavp.Name = "mavp";
            this.mavp.Size = new System.Drawing.Size(424, 24);
            this.mavp.TabIndex = 60;
            this.mavp.SelectedIndexChanged += new System.EventHandler(this.mavp_SelectedIndexChanged);
            this.mavp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavp_KeyDown);
            // 
            // butThuoc
            // 
            this.butThuoc.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.butThuoc.Image = ((System.Drawing.Image)(resources.GetObject("butThuoc.Image")));
            this.butThuoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThuoc.Location = new System.Drawing.Point(701, 667);
            this.butThuoc.Name = "butThuoc";
            this.butThuoc.Size = new System.Drawing.Size(102, 28);
            this.butThuoc.TabIndex = 69;
            this.butThuoc.Text = "Thuốc+&vật tư";
            this.butThuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThuoc.Click += new System.EventHandler(this.butThuoc_Click);
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Enabled = false;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(784, 58);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(128, 24);
            this.madoituong.TabIndex = 14;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label39
            // 
            this.label39.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label39.Location = new System.Drawing.Point(728, 60);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(56, 23);
            this.label39.TabIndex = 79;
            this.label39.Text = "Đối tượng ";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn3
            // 
            this.mabn3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn3.Location = new System.Drawing.Point(936, 6);
            this.mabn3.MaxLength = 8;
            this.mabn3.Name = "mabn3";
            this.mabn3.Size = new System.Drawing.Size(73, 23);
            this.mabn3.TabIndex = 8;
            this.mabn3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mabn3_KeyPress);
            this.mabn3.Validated += new System.EventHandler(this.mabn3_Validated);
            this.mabn3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(656, 84);
            this.ngay.Mask = "##/##/####";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(80, 23);
            this.ngay.TabIndex = 19;
            this.ngay.Text = "  /  /    ";
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            // 
            // ngaykt
            // 
            this.ngaykt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaykt.Enabled = false;
            this.ngaykt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaykt.Location = new System.Drawing.Point(856, 84);
            this.ngaykt.Mask = "##/##/####";
            this.ngaykt.Name = "ngaykt";
            this.ngaykt.Size = new System.Drawing.Size(80, 23);
            this.ngaykt.TabIndex = 21;
            this.ngaykt.Text = "  /  /    ";
            this.ngaykt.Validated += new System.EventHandler(this.ngaykt_Validated);
            // 
            // gio
            // 
            this.gio.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gio.Enabled = false;
            this.gio.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gio.Location = new System.Drawing.Point(784, 84);
            this.gio.Mask = "##:##";
            this.gio.Name = "gio";
            this.gio.Size = new System.Drawing.Size(43, 23);
            this.gio.TabIndex = 20;
            this.gio.Text = "  :  ";
            this.gio.Validated += new System.EventHandler(this.gio_Validated);
            // 
            // giokt
            // 
            this.giokt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giokt.Enabled = false;
            this.giokt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giokt.Location = new System.Drawing.Point(967, 84);
            this.giokt.Mask = "##:##";
            this.giokt.Name = "giokt";
            this.giokt.Size = new System.Drawing.Size(43, 23);
            this.giokt.TabIndex = 22;
            this.giokt.Text = "  :  ";
            this.giokt.Validated += new System.EventHandler(this.giokt_Validated);
            // 
            // lmau
            // 
            this.lmau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lmau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lmau.Enabled = false;
            this.lmau.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmau.Location = new System.Drawing.Point(419, 208);
            this.lmau.Name = "lmau";
            this.lmau.Size = new System.Drawing.Size(213, 24);
            this.lmau.TabIndex = 33;
            this.lmau.SelectedIndexChanged += new System.EventHandler(this.lmau_SelectedIndexChanged);
            this.lmau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lmau_KeyDown);
            // 
            // tenpttt
            // 
            this.tenpttt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenpttt.Enabled = false;
            this.tenpttt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenpttt.Location = new System.Drawing.Point(698, 209);
            this.tenpttt.Name = "tenpttt";
            this.tenpttt.Size = new System.Drawing.Size(311, 23);
            this.tenpttt.TabIndex = 35;
            this.tenpttt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenpttt_KeyDown);
            // 
            // label40
            // 
            this.label40.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label40.Location = new System.Drawing.Point(752, 84);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(28, 23);
            this.label40.TabIndex = 84;
            this.label40.Text = "giờ :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label41
            // 
            this.label41.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label41.Location = new System.Drawing.Point(936, 84);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(28, 23);
            this.label41.TabIndex = 86;
            this.label41.Text = "giờ :";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giovv
            // 
            this.giovv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giovv.Enabled = false;
            this.giovv.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giovv.Location = new System.Drawing.Point(424, 84);
            this.giovv.Mask = "##:##";
            this.giovv.Name = "giovv";
            this.giovv.Size = new System.Drawing.Size(43, 23);
            this.giovv.TabIndex = 17;
            this.giovv.Text = "  :  ";
            this.giovv.Validated += new System.EventHandler(this.giovv_Validated);
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Enabled = false;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(334, 84);
            this.ngayvv.Mask = "##/##/####";
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(88, 23);
            this.ngayvv.TabIndex = 16;
            this.ngayvv.Text = "  /  /    ";
            this.ngayvv.Validated += new System.EventHandler(this.ngayvv_Validated);
            // 
            // chkXem
            // 
            this.chkXem.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkXem.Location = new System.Drawing.Point(0, 673);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(104, 16);
            this.chkXem.TabIndex = 256;
            this.chkXem.Text = "Xem trước khi in";
            // 
            // butThem
            // 
            this.butThem.BackColor = System.Drawing.SystemColors.Control;
            this.butThem.Enabled = false;
            this.butThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butThem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(337, 667);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(84, 28);
            this.butThem.TabIndex = 66;
            this.butThem.Text = "&Nhân viên";
            this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThem.UseVisualStyleBackColor = false;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // ngayvao
            // 
            this.ngayvao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngayvao.Enabled = false;
            this.ngayvao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvao.Location = new System.Drawing.Point(512, 58);
            this.ngayvao.Name = "ngayvao";
            this.ngayvao.Size = new System.Drawing.Size(130, 24);
            this.ngayvao.TabIndex = 12;
            this.ngayvao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
            // 
            // label42
            // 
            this.label42.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label42.Location = new System.Drawing.Point(440, 60);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(72, 23);
            this.label42.TabIndex = 259;
            this.label42.Text = "Ngày vào :";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butHinh
            // 
            this.butHinh.Enabled = false;
            this.butHinh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butHinh.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.butHinh.Location = new System.Drawing.Point(221, 488);
            this.butHinh.Name = "butHinh";
            this.butHinh.Size = new System.Drawing.Size(112, 21);
            this.butHinh.TabIndex = 260;
            this.butHinh.Text = "Hình phẫu thủ thuật";
            this.butHinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHinh.Click += new System.EventHandler(this.butHinh_Click);
            // 
            // chkXML
            // 
            this.chkXML.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkXML.Location = new System.Drawing.Point(104, 673);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(88, 16);
            this.chkXML.TabIndex = 261;
            this.chkXML.Text = "Xuất ra XML";
            // 
            // noisoi
            // 
            this.noisoi.Enabled = false;
            this.noisoi.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.noisoi.Location = new System.Drawing.Point(840, 620);
            this.noisoi.Name = "noisoi";
            this.noisoi.Size = new System.Drawing.Size(80, 16);
            this.noisoi.TabIndex = 57;
            this.noisoi.Text = "Mỗ nội soi";
            this.noisoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // tim
            // 
            this.tim.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(0, 1);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(208, 21);
            this.tim.TabIndex = 0;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            // 
            // label43
            // 
            this.label43.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label43.Location = new System.Drawing.Point(237, 232);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(97, 23);
            this.label43.TabIndex = 265;
            this.label43.Text = "Tường trình :";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butTuongtrinh
            // 
            this.butTuongtrinh.Appearance = System.Windows.Forms.Appearance.Button;
            this.butTuongtrinh.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butTuongtrinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTuongtrinh.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.butTuongtrinh.Image = ((System.Drawing.Image)(resources.GetObject("butTuongtrinh.Image")));
            this.butTuongtrinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTuongtrinh.Location = new System.Drawing.Point(88, 704);
            this.butTuongtrinh.Name = "butTuongtrinh";
            this.butTuongtrinh.Size = new System.Drawing.Size(90, 28);
            this.butTuongtrinh.TabIndex = 67;
            this.butTuongtrinh.Text = "&Tường trình";
            this.butTuongtrinh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butTuongtrinh.Visible = false;
            this.butTuongtrinh.CheckedChanged += new System.EventHandler(this.butTuongtrinh_CheckedChanged);
            // 
            // timmo
            // 
            this.timmo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.timmo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timmo.ForeColor = System.Drawing.Color.Red;
            this.timmo.Location = new System.Drawing.Point(0, 344);
            this.timmo.Name = "timmo";
            this.timmo.Size = new System.Drawing.Size(208, 21);
            this.timmo.TabIndex = 267;
            this.timmo.Text = "Tìm kiếm";
            this.timmo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timmo.Enter += new System.EventHandler(this.timmo_Enter);
            this.timmo.TextChanged += new System.EventHandler(this.timmo_TextChanged);
            this.timmo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.timmo_KeyDown);
            // 
            // bienchung
            // 
            this.bienchung.Enabled = false;
            this.bienchung.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bienchung.Location = new System.Drawing.Point(584, 620);
            this.bienchung.Name = "bienchung";
            this.bienchung.Size = new System.Drawing.Size(104, 16);
            this.bienchung.TabIndex = 55;
            this.bienchung.Text = "Biến chứng";
            this.bienchung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // frmPttt_ba
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.tuvong);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.bienchung);
            this.Controls.Add(this.timmo);
            this.Controls.Add(this.listMo);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.giuong);
            this.Controls.Add(this.butRef);
            this.Controls.Add(this.list);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.noidung);
            this.Controls.Add(this.noisoi);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.butHinh);
            this.Controls.Add(this.ngayvao);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.chkXem);
            this.Controls.Add(this.giovv);
            this.Controls.Add(this.ngayvv);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.tenpttt);
            this.Controls.Add(this.lmau);
            this.Controls.Add(this.giokt);
            this.Controls.Add(this.gio);
            this.Controls.Add(this.mapt);
            this.Controls.Add(this.ngaykt);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.mabn3);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.butThuoc);
            this.Controls.Add(this.loaivp);
            this.Controls.Add(this.sotien);
            this.Controls.Add(this.mavp);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.loaibn);
            this.Controls.Add(this.molaimien);
            this.Controls.Add(this.somat);
            this.Controls.Add(this.mapmo);
            this.Controls.Add(this.lmat);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.butTuongtrinh);
            this.Controls.Add(this.mautuongtrinh);
            this.Controls.Add(this.chktuongtrinh);
            this.Controls.Add(this.tenmau);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.tenhoisuc);
            this.Controls.Add(this.tenbsgayme);
            this.Controls.Add(this.tenphu1);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.tendungcu);
            this.Controls.Add(this.dungcu);
            this.Controls.Add(this.hoisuc);
            this.Controls.Add(this.tenktvgayme);
            this.Controls.Add(this.ktvgayme);
            this.Controls.Add(this.bsgayme);
            this.Controls.Add(this.tenphu2);
            this.Controls.Add(this.phu2);
            this.Controls.Add(this.phu1);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.nhietdo);
            this.Controls.Add(this.huyetap);
            this.Controls.Add(this.mach);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.listICD);
            this.Controls.Add(this.cd_s);
            this.Controls.Add(this.cd_t);
            this.Controls.Add(this.butPttt);
            this.Controls.Add(this.tenpt);
            this.Controls.Add(this.listpttt);
            this.Controls.Add(this.icd_s);
            this.Controls.Add(this.sophieu);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.taibien);
            this.Controls.Add(this.tinhhinh);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.tenphuongphap);
            this.Controls.Add(this.phuongphap);
            this.Controls.Add(this.loaipt);
            this.Controls.Add(this.icd_t);
            this.Controls.Add(this.cd_vk);
            this.Controls.Add(this.icd_vk);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.mabn2);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.mamau);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmPttt_ba";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin phẫu thủ thuật";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPttt_ba_KeyDown);
            this.Load += new System.EventHandler(this.frmPttt_ba_Load);
            ((System.ComponentModel.ISupportInitialize)(this.somat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmPttt_ba_Load(object sender, System.EventArgs e)
		{
            i_maxlenghth_mabn =LibMedi.AccessData.i_maxlength_mabn;
            mabn3.MaxLength = i_maxlenghth_mabn-2;
			user=m.user;mmyy=m.mmyy(m.ngayhienhanh_server);xxx=user+mmyy;
			bPttt_makp_user=m.bPttt_makp_user;
			chkXem.Checked=m.bPreview;
			bSophieu=m.bSophieu_pttt;
			bHoisuc=m.bHoisuc_dungcu;
			bTiepdon_pttt=m.bTiepdon(LibMedi.AccessData.Phauthuthuat);
			bPttt_pmo=m.bPttt_phongmo;
			bPttt_vp=m.bPttt_vienphi;
			bEdit_vp=m.bEdit_pttt_vienphi;
			bPttt_thuoc=m.bPttt_thuoc;
			bPttt_tsoduoc=m.bPttt_tsoduoc;
			dsngay.ReadXml("..\\..\\..\\xml\\m_ngayvao.xml");
			dsloaibn.ReadXml("..\\..\\..\\xml\\m_loaibn.xml");
			dsxml.ReadXml("..\\..\\..\\xml\\m_pttt.xml");
			DataColumn dc = new DataColumn("Image", typeof(byte[]));
			dsxml.Tables[0].Columns.Add(dc);
			dc = new DataColumn("Image1", typeof(byte[]));
			dsxml.Tables[0].Columns.Add(dc);
			dc = new DataColumn("Image2", typeof(byte[]));
			dsxml.Tables[0].Columns.Add(dc);

			bAdmin=m.bAdmin(m_userid);
			b_bacsi=m.bsPttt;
			bChandoan=m.bChandoan_icd10;
			butThuoc.Enabled=bPttt_thuoc;

			ngayvao.DisplayMember="NGAYVAO";
			ngayvao.ValueMember="MAQL";
			ngayvao.DataSource=dsngay.Tables[0];

            dtduockp = m.get_data("select * from " + user + ".d_duockp").Tables[0];
			tenkp.DisplayMember="TENKP";
			tenkp.ValueMember="MAKP";
			load_btdkp();

			mapmo.DisplayMember="TEN";
			mapmo.ValueMember="MA";
			if (bPttt_pmo) load_btdpm(makp.Text);
			mapmo.Enabled=bPttt_pmo;

            s_nhomvp_pttt=m.iNhompttt;
            sql = "select a.* from " + user + ".v_giavp a," + user + ".v_loaivp b where a.id_loai=b.id ";
            if (s_nhomvp_pttt.Trim().Trim(',') != "") sql += " and b.id_nhom in(" + s_nhomvp_pttt.Trim().Trim(',') + ")";
            dtmavp = m.get_data(sql).Tables[0];
            //dtmavp = m.get_data("select a.* from " + user + ".v_giavp a," + user + ".v_loaivp b where a.id_loai=b.id and b.id_nhom=" + m.iNhompttt).Tables[0];

            sql = "select * from " + user + ".v_loaivp ";
            if (s_nhomvp_pttt.Trim().Trim(',') != "") sql += " where id_nhom in(" + s_nhomvp_pttt.Trim().Trim(',') + ")";
            sql += " order by stt";

			loaivp.DisplayMember="TEN";
			loaivp.ValueMember="ID";
            loaivp.DataSource = m.get_data(sql).Tables[0];// m.get_data("select * from " + user + ".v_loaivp where id_nhom=" + m.iNhompttt + " order by stt").Tables[0];

			mavp.DisplayMember="TEN";
			mavp.ValueMember="ID";

            dsmau = m.get_data("select ma,ten,mapt,mabs,makp,noidung,mavp,image1,image2 from " + user + ".pttt_mau order by ma");
            dsmau.Merge(m.get_data("select mapt as ma,noi_dung as ten,mapt,'' as mabs,'' as makp,'' noidung,cast(0 as numeric) as mavp,image1,image2 from " + user + ".dmpttt order by mapt"));
            dtpt = m.get_data("select MAPT,NOI_DUNG,DACBIET,LOAI1,LOAI2,LOAI3 from " + user + ".dmpttt").Tables[0];

			listpttt.DisplayMember="TEN";
			listpttt.ValueMember="MA";
			listpttt.DataSource=dsmau.Tables[0];

			loaibn.DisplayMember="TEN";
			loaibn.ValueMember="ID";
			loaibn.DataSource=dsloaibn.Tables[0];

			tenphuongphap.DisplayMember="TEN";
			tenphuongphap.ValueMember="MA";
            tenphuongphap.DataSource = m.get_data("select * from " + user + ".dmmete order by ma").Tables[0];

            sql = "select * from " + user + ".doituong ";
			if (s_madoituong!="") sql+=" where madoituong in ("+s_madoituong.Substring(0,s_madoituong.Length-1)+")";
			sql+=" order by madoituong";
			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
			madoituong.DataSource=m.get_data(sql).Tables[0];

			loaipt.DisplayMember="TEN";
			loaipt.ValueMember="MA";
            loaipt.DataSource = m.get_data("select * from " + user + ".loaipttt order by ma").Tables[0];

			taibien.DisplayMember="TEN";
			taibien.ValueMember="MA";
            taibien.DataSource = m.get_data("select * from " + user + ".taibienpt order by ma").Tables[0];

			lmau.DisplayMember="TEN";
			lmau.ValueMember="MA";

			mautuongtrinh.DisplayMember="TEN";
			mautuongtrinh.ValueMember="NOIDUNG";

			tinhhinh.DisplayMember="TEN";
			tinhhinh.ValueMember="MA";
            tinhhinh.DataSource = m.get_data("select * from " + user + ".tinhhinhpt order by ma desc").Tables[0];
			
			tuvong.DisplayMember="TEN";
			tuvong.ValueMember="MA";
            tuvong.DataSource = m.get_data("select * from " + user + ".tuvongpt order by ma").Tables[0];


            dtbs = m.get_data("select * from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
			listBS.DisplayMember="MA";
			listBS.ValueMember="HOTEN";
			listBS.DataSource=dtbs;

            dticd = m.get_data("select cicd10,vviet from " + user + ".icd10 order by cicd10").Tables[0];
			listICD.DisplayMember="CICD10";
			listICD.ValueMember="VVIET";
			listICD.DataSource=dticd;

			s_msg=LibMedi.AccessData.Msg;
			songay=m.Ngaylv_Ngayht;
			mabn2.Text=DateTime.Now.Year.ToString().Substring(2,2);
			if (m_mabn!="")
			{
				mabn2.Text=m_mabn.Substring(0,2);
				mabn3.Text=m_mabn.Substring(2,i_maxlenghth_mabn-2);
				l_maql=0;
				l_idkhoa=0;
				ena_object(true);
				emp_text();
				if (tenkp.SelectedIndex!=-1) makp.Text=tenkp.SelectedValue.ToString();
				bStatus=true;
				mabn2.Enabled=false;
				mabn3.Enabled=false;
				makp.Enabled=false;
				tenkp.Enabled=false;
				load_mabn();//
				if (loaibn.Enabled) loaibn.Focus();
				else ngayvao.Focus();
			}

			list.DisplayMember="HOTEN";
			list.ValueMember="MABN";
			load_list();
			list.ColumnWidths[0]=60;
			list.ColumnWidths[1]=150;
			list.ColumnWidths[2]=0;
			list.SetSensive(2,1,Color.Red);

			listMo.DisplayMember="HOTEN";
			listMo.ValueMember="MABN";
			load_mo();
			listMo.ColumnWidths[0]=60;
			listMo.ColumnWidths[1]=150;
			listMo.ColumnWidths[2]=0;
			listMo.SetSensive(2,1,Color.Red);
		}

		private void load_list()
		{
			Cursor=Cursors.WaitCursor;
			string _ngay=m.ngayhienhanh_server;
            #region Bo
            //sql = "select a.mabn,trim(b.hoten)||'('||trim(to_char(to_char(sysdate,'yyyy')-b.namsinh))||')' as ten,b.hoten,";//,a.hoichan
            //sql+="b.phai,a.id,a.maql,a.idkhoa,a.maicd,a.chandoan,a.mamau,a.phuongphap,a.ptv,a.bsgayme,a.phu1,a.phu2,a.ktvgayme,";
            //sql+=" a.hoisuc,a.dungcu,a.noisoi,to_char(a.ngaymo,'dd/mm/yyyy hh24:mi') as ngaymo,a.makp,a.mapmo,a.noisoi,";
            //sql+="to_char(i.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,i.sovaovien,j.tuoivao,k.sothe,j.giuong,i.madoituong,";
            //sql+="j.maicd as maicdvk,j.chandoan as chandoanvk";
            //sql += " from " + user + m.mmyy(_ngay) + ".pttt_lichmo a," + user + ".btdbn b," + user + ".benhandt i," + user + ".nhapkhoa j," + user + ".bhyt k";
            //sql+=" where a.mabn=b.mabn ";
            //sql+=" and a.maql=i.maql and a.idkhoa=j.id and i.maql=k.maql(+) and a.done=1";
            //sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+m.DateToString("dd/MM/yyyy",m.StringToDate(_ngay.Substring(0,10)).AddDays(-1))+"','dd/mm/yy') and to_date('"+_ngay.Substring(0,10)+"','dd/mm/yy')";
            //if (s_makp!="") sql+=" and a.makp='"+s_makp+"'";
            //sql+=" order by a.ngay,a.stt";
            #endregion
            if (i_loaiba == 2)
            {
                sql = "select a.mabn,trim(b.hoten)||'('||trim(to_char(to_number(to_char(sysdate,'yyyy'))-to_number(b.namsinh)))||')' as ten,b.hoten,b.phai,a.id,a.maql,a.idkhoa,";
                sql += "a.maicdt,'' as chandoan,a.mamau,a.phuongphap,a.ptv,a.phu1 as phu1,a.phu2 as phu2,'' as noisoi,'' as hoisuc, ";
                sql += "a.makp,to_char(i.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,i.sovaovien,a.makp as mapmo,'' as dungcu,'' as ktvgayme,'' as bsgayme, ";
                sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngaymo,to_char(to_number(to_char(sysdate,'yyyy'))-to_number(b.namsinh)) as tuoivao,k.sothe,'' as giuong,i.madoituong,i.maicd as maicdvk,i.chandoan as chandoanvk ";
                sql += "from " + user + m.mmyy(_ngay) + ".pttt a," + user + ".btdbn b," + user + ".benhanngtr i," + user + ".bhyt k ";//" + user + ".nhapkhoa j,
                sql += "where a.mabn=b.mabn  and a.maql=i.maql and i.maql=k.maql(+) ";//and a.idkhoa=j.id 
                sql += "and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + m.DateToString("dd/MM/yyyy", m.StringToDate(_ngay.Substring(0, 10)).AddDays(-1)) + "','dd/mm/yyyy') and to_date('" + _ngay.Substring(0, 10) + "','dd/mm/yyyy')";
                sql += "order by a.ngay ";//,a.stt
            }
            else if (i_loaiba == 4)
            {
                sql = "select a.mabn,trim(b.hoten)||'('||trim(to_char(to_number(to_char(sysdate,'yyyy'))-to_number(b.namsinh)))||')' as ten,b.hoten,b.phai,a.id,a.maql,a.idkhoa,";
                sql += "a.maicdt,'' as chandoan,a.mamau,a.phuongphap,a.ptv,a.phu1 as phu1,a.phu2 as phu2,'' as noisoi,'' as hoisuc, ";
                sql += "a.makp,to_char(i.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,i.sovaovien,a.makp as mapmo,'' as dungcu,'' as ktvgayme,'' as bsgayme, ";
                sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngaymo,to_char(to_number(to_char(sysdate,'yyyy'))-to_number(b.namsinh)) as tuoivao,k.sothe,'' as giuong,i.madoituong,i.maicd as maicdvk,i.chandoan as chandoanvk ";
                sql += "from " + user + m.mmyy(_ngay) + ".pttt a," + user + ".btdbn b," + user + m.mmyy(_ngay) + ".benhancc i," + user + ".bhyt k ";//" + user + ".nhapkhoa j,
                sql += "where a.mabn=b.mabn  and a.maql=i.maql and i.maql=k.maql(+) ";//and a.idkhoa=j.id 
                sql += "and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + m.DateToString("dd/MM/yyyy", m.StringToDate(_ngay.Substring(0, 10)).AddDays(-1)) + "','dd/mm/yyyy') and to_date('" + _ngay.Substring(0, 10) + "','dd/mm/yyyy')";
                sql += "order by a.ngay ";//,a.stt
            }
            else
            {
                sql = "select a.mabn,trim(b.hoten)||'('||trim(to_char(to_number(to_char(sysdate,'yyyy'))-to_number(b.namsinh)))||')' as ten,b.hoten,b.phai,a.id,a.maql,a.idkhoa,";
                sql += "a.maicd,'' as chandoan,a.mamau,a.phuongphap,a.ptv,a.phu as phu1,a.phu as phu2,'' as noisoi,'' as hoisuc, ";
                sql += "a.makp,to_char(i.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,i.sovaovien,a.makp as mapmo,'' as dungcu,'' as ktvgayme,'' as bsgayme, ";
                sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngaymo,j.tuoivao,k.sothe,j.giuong,i.madoituong,j.maicd as maicdvk,j.chandoan as chandoanvk ";
                sql += "from " + user + m.mmyy(_ngay) + ".pttt_lichmo a," + user + ".btdbn b," + user + ".benhandt i," + user + ".nhapkhoa j," + user + ".bhyt k ";
                sql += "where a.mabn=b.mabn  and a.maql=i.maql and a.idkhoa=j.id and i.maql=k.maql(+) ";
                sql += "and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + m.DateToString("dd/MM/yyyy", m.StringToDate(_ngay.Substring(0, 10)).AddDays(-1)) + "','dd/mm/yyyy') and to_date('" + _ngay.Substring(0, 10) + "','dd/mm/yyyy')";
                sql += "order by a.ngay,a.stt ";
            }
			ds=m.get_data(sql);
			list.DataSource=ds.Tables[0];
			Cursor=Cursors.Default;
		}

		private void load_mo()
		{
			Cursor=Cursors.WaitCursor;
			string _ngay=m.ngayhienhanh_server;
            sql = "select a.mabn,trim(b.hoten)||'('||trim(to_char(to_number(to_char(sysdate,'yyyy'))-to_number(b.namsinh)))||')' as ten,a.noisoi,b.hoten,a.id ";
            sql += " from " + user + m.mmyy(_ngay) + ".pttt a," + user + ".btdbn b where a.mabn=b.mabn ";
			sql+=" and to_date(to_char(a.ngay,'dd/mm/yy'),'dd/mm/yyyy') between to_date('"+m.DateToString("dd/MM/yyyy",m.StringToDate(_ngay.Substring(0,10)).AddDays(-1))+"','dd/mm/yyyy') and to_date('"+_ngay.Substring(0,10)+"','dd/mm/yyyy')";
			if (s_makp!="") sql+=" and a.makp='"+s_makp+"'";
			sql+=" order by a.ngay";
			dsmo=m.get_data(sql);
			listMo.DataSource=dsmo.Tables[0];
			Cursor=Cursors.Default;
		}

		private void get_mabn(string _mabn)
		{
			mabn2.Text=_mabn.Substring(0,2);
			mabn3.Text=_mabn.Substring(2);
			load_mabn();
			string m_tuoivao,m_loaituoi="TU";
			DataRow r1,r=m.getrowbyid(ds.Tables[0],"mabn='"+_mabn+"'");
			if (r!=null)
			{
				bStatus=false;
				hoten.Text=r["hoten"].ToString();
				m_tuoivao=r["tuoivao"].ToString();
				if (m_tuoivao.Length==4)
				{
					switch (int.Parse(m_tuoivao.Substring(3,1)))
					{
						case 0: m_loaituoi="TU";
							break;
						case 1: m_loaituoi="TH";
							break;
						case 2: m_loaituoi="NG";
							break;
						default: m_loaituoi="GI";
							break;
					}
				}
				tuoi.Text=m_tuoivao.Substring(0,3)+m_loaituoi;
				phai.Text=(r["phai"].ToString()=="0")?"Nam":"Nữ";
				giuong.Text=r["giuong"].ToString();
				sothe.Text=r["sothe"].ToString();
				ngayvv.Text=r["ngayvv"].ToString().Substring(0,10);
				giovv.Text=r["ngayvv"].ToString().Substring(11);
				madoituong.SelectedValue=r["madoituong"].ToString();
				cd_t.Text=r["chandoan"].ToString();
				icd_t.Text=r["maicd"].ToString();
				cd_s.Text=r["chandoan"].ToString();
				icd_s.Text=r["maicd"].ToString();
				cd_vk.Text=r["chandoanvk"].ToString();
				icd_vk.Text=r["maicdvk"].ToString();
				l_id=decimal.Parse(r["id"].ToString());
				l_idkhoa=decimal.Parse(r["idkhoa"].ToString());
				l_maql=decimal.Parse(r["maql"].ToString());
				s_sovaovien=r["sovaovien"].ToString();
				s_icd_t=icd_t.Text;
				s_icd_s=icd_s.Text;
				tenphuongphap.SelectedValue=r["phuongphap"].ToString();
				mamau.Text=r["mamau"].ToString();
				tenmau.Text=mamau.Text;
				r1=m.getrowbyid(dsmau.Tables[0],"ma='"+mamau.Text+"'");
				if (r1!=null)
				{
					if (bPttt_vp) load_vienphi(mamau.Text);
					tenpttt.Text=r1["ten"].ToString();
					mapt.Text=r1["mapt"].ToString();
					noidung.Text=r1["noidung"].ToString();
					mapt_Validated(null,null);
					load_mau(mamau.Text.Substring(0,6));
					lmau.SelectedValue=mamau.Text;
				}

				noisoi.Checked=r["noisoi"].ToString()=="1";
				r1=m.getrowbyid(dtpt,"mapt='"+mapt.Text+"'");
				if (r1!=null) tenpt.Text=r1["noi_dung"].ToString();
				gan_text(r["ptv"].ToString(),mabs,tenbs);
				gan_text(r["phu1"].ToString(),phu1,tenphu1);
				gan_text(r["phu2"].ToString(),phu2,tenphu2);
				gan_text(r["bsgayme"].ToString(),bsgayme,tenbsgayme);
				gan_text(r["ktvgayme"].ToString(),ktvgayme,tenktvgayme);
				gan_text(r["hoisuc"].ToString(),hoisuc,tenhoisuc);
				gan_text(r["dungcu"].ToString(),dungcu,tendungcu);
				makp.Text=r["makp"].ToString();
				tenkp.SelectedValue=makp.Text;
				load_btdpm(makp.Text);
				mapmo.SelectedValue=r["mapmo"].ToString();
				loaibn.SelectedValue="1";
				ngay.Focus();
			}
		}

		private void makp_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tenkp.SelectedValue=makp.Text;
				DataRow r=m.getrowbyid(dtkp,"makpbo='25' and makp='"+makp.Text+"'");
				bMat=r!=null;
				lmat.Visible=bMat;
				somat.Visible=bMat;
				load_btdpm(makp.Text);
			}
			catch{}
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void tenkp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenkp.SelectedIndex==-1) tenkp.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tenkp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenkp)
			{
				makp.Text=tenkp.SelectedValue.ToString();
				DataRow r=m.getrowbyid(dtkp,"makpbo='25' and makp='"+makp.Text+"'");
				bMat=r!=null;
				lmat.Visible=bMat;
				somat.Visible=bMat;
				load_btdpm(makp.Text);
			}
		}

		private void load_btdkp()
		{
            sql = "select * from " + user + ".btdkp_bv ";
			if (s_makp!="" && bPttt_makp_user) sql+=" where makp in("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=" order by loai,makp";
			dtkp=m.get_data(sql).Tables[0];
            if (dtkp.Rows.Count == 0) dtkp = m.get_data("select * from " + user + ".btdkp_bv order by loai,makp").Tables[0];
			tenkp.DataSource=dtkp;
			makp.Text=tenkp.SelectedValue.ToString();
		}

		private void mabn2_Validated(object sender, System.EventArgs e)
		{
			mabn2.Text=mabn2.Text.PadLeft(2,'0');
		}

		private void mabn3_Validated(object sender, System.EventArgs e)
		{
			bCapso=false;
			nam="";
			if (mabn3.Text=="" && butLuu.Enabled)
			{
				if (makp.Text=="")
				{
					makp.Focus();
					return;
				}
				if (mabn2.Text=="")
				{
					mabn2.Focus();return;
				}
				if (m.get_capso(makp.Text))
				{
					bCapso=true;
					mabn3.Text=m.get_mabn(int.Parse(mabn2.Text),2,int.Parse(makp.Text),true).ToString().PadLeft(i_maxlenghth_mabn-2,'0');
					frmSuahc f=new frmSuahc(m,"",m_userid,false,mabn2.Text+mabn3.Text);
					f.ShowDialog(this);
					if (f.m_mabn!="")
					{
                        sql = "select a.*,nvl(b.tentt,' ') as tentt,nvl(c.tenquan,' ') as tenquan,nvl(d.tenpxa,' ') as tenpxa from " + user + ".btdbn a," + user + ".btdtt b," + user + ".btdquan c," + user + ".btdpxa d ";
						sql+=" where a.matt=b.matt(+) and a.maqu=c.maqu(+) and a.maphuongxa=d.maphuongxa(+)";
						sql+=" and mabn='"+s_mabn+"'";
						foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
						{
							hoten.Text=r["hoten"].ToString();
							phai.Text=(r["phai"].ToString()=="0")?"Nam":"Nữ";
							diachi.Text=r["sonha"].ToString()+" "+r["thon"].ToString()+" "+r["tenpxa"].ToString().Trim()+"-"+r["tenquan"].ToString().Trim()+"-"+r["tentt"].ToString().Trim();
							int ituoi=DateTime.Now.Year-int.Parse(r["namsinh"].ToString());
							tuoi.Text=ituoi.ToString();
							break;
						}
						ngayvv.Enabled=true;giovv.Enabled=true;
						ngayvv.Text=m.Ngaygio_hienhanh.Substring(0,10);
						giovv.Text=m.Ngaygio_hienhanh.Substring(11);
					}
					else
					{
						makp.Focus();
						return;
					}
				}
			}
			if (mabn3.Text=="") 
			{
				mabn2.Focus();
				return;
			}
			mabn3.Text=mabn3.Text.PadLeft(i_maxlenghth_mabn-2,'0');
			l_maql=0;
			if (mabn2.Text+mabn3.Text!=m_mabn) 
			{
				int iRet=load_mabn();
				if (iRet!=0)
				{
					if (bTiepdon_pttt && butLuu.Enabled)
					{
						if (MessageBox.Show(lan.Change_language_MessageText("Chưa có thông tin hành chính\nBạn có muốn nhập không ?"),s_msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
						{
							frmSuahc f=new frmSuahc(m,"",m_userid,false,mabn2.Text+mabn3.Text);
							f.ShowDialog(this);
							if (f.m_mabn!="")
							{
                                sql = "select a.*,nvl(b.tentt,' ') as tentt,nvl(c.tenquan,' ') as tenquan,nvl(d.tenpxa,' ') as tenpxa from " + user + ".btdbn a," + user + ".btdtt b," + user + ".btdquan c," + user + ".btdpxa d ";
								sql+=" where a.matt=b.matt(+) and a.maqu=c.maqu(+) and a.maphuongxa=d.maphuongxa(+)";
								sql+=" and mabn='"+s_mabn+"'";
								foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
								{
									nam=r["nam"].ToString().Trim();
									hoten.Text=r["hoten"].ToString();
									phai.Text=(r["phai"].ToString()=="0")?"Nam":"Nữ";
									diachi.Text=r["sonha"].ToString()+" "+r["thon"].ToString()+" "+r["tenpxa"].ToString().Trim()+"-"+r["tenquan"].ToString().Trim()+"-"+r["tentt"].ToString().Trim();
									int ituoi=DateTime.Now.Year-int.Parse(r["namsinh"].ToString());
									tuoi.Text=ituoi.ToString();
									break;
								}
								ngayvv.Enabled=true;giovv.Enabled=true;
								ngayvv.Text=m.Ngaygio_hienhanh.Substring(0,10);
								giovv.Text=m.Ngaygio_hienhanh.Substring(11);
							}
							else
							{
								makp.Focus();
								return;
							}
						}
						else
						{
							makp.Focus();
							return;
						}
					}
					else
					{
						string msg=(iRet==1)?lan.Change_language_MessageText("Thông tin hành chính không tìm thấy !"):lan.Change_language_MessageText("Bệnh nhân chưa nhập khoa !")+tenkp.Text.Trim();
						MessageBox.Show(msg,s_msg);
						makp.Focus();
						return;
					}
				}
			}
		}

		private int load_mabn()
		{
			s_mabn=mabn2.Text+mabn3.Text;
			int ret=1,ituoi;
            sql = "select a.*,nvl(b.tentt,' ') as tentt,nvl(c.tenquan,' ') as tenquan,nvl(d.tenpxa,' ') as tenpxa from " + user + ".btdbn a," + user + ".btdtt b," + user + ".btdquan c," + user + ".btdpxa d ";
			sql+=" where a.matt=b.matt(+) and a.maqu=c.maqu(+) and a.maphuongxa=d.maphuongxa(+)";
			sql+=" and mabn='"+s_mabn+"'";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				nam=r["nam"].ToString().Trim();
				hoten.Text=r["hoten"].ToString();
				phai.Text=(r["phai"].ToString()=="0")?"Nam":"Nữ";
				diachi.Text=r["sonha"].ToString()+" "+r["thon"].ToString()+" "+r["tenpxa"].ToString().Trim()+"-"+r["tenquan"].ToString().Trim()+"-"+r["tentt"].ToString().Trim();
				ituoi=DateTime.Now.Year-int.Parse(r["namsinh"].ToString());
				tuoi.Text=ituoi.ToString();
				ret=0;
				break;
			}
			if (ret==0)
			{
				load_treeView();
				if (butMoi.Enabled)
				{
					l_maql=0;l_idkhoa=0; 
					load_pttt("");
				}
				else
				{
					if (nam=="") nam=m.mmyy(m.ngayhienhanh_server)+"+";
					sql="select 0 as loai,2 as loaiba,maql,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngayvao,madoituong,to_char(ngay,'yymmddhh24mi') as yymmdd,sovaovien ";
                    //sql += " from " + user + ".benhandt where mabn='" + s_mabn + "'";
                    //TU:15/04/2011
                    sql += " from " + user + ".benhanngtr where mabn='" + s_mabn + "'";
                    //end TU
					DataSet ds1=m.get_data(sql);

					//sql="select 1 as loai,loaiba,a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,a.madoituong,to_char(a.ngay,'yymmddhh24mi') as yymmdd,sovaovien from xxx.benhandt a where a.mabn='"+s_mabn+"'";
                    sql = "select 1 as loai,4 as loaiba,a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,a.madoituong,to_char(a.ngay,'yymmddhh24mi') as yymmdd,sovaovien from xxx.benhancc a where a.mabn='" + s_mabn + "'";
                    sql += " union all ";
                    sql += "select 1 as loai,3 as loaiba,a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,a.madoituong,to_char(a.ngay,'yymmddhh24mi') as yymmdd,sovaovien from xxx.benhanpk a where a.mabn='" + s_mabn + "'";
					sql+=" union all ";
					sql+="select 2 as loai,3 as loaiba,a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,a.madoituong,to_char(a.ngay,'yymmddhh24mi') as yymmdd,sovaovien from xxx.tiepdon a where noitiepdon=0 and a.mabn='"+s_mabn+"'";
                    sql += " union all ";
                    sql += "select 1 as loai,1 as loaiba,a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,a.madoituong,to_char(a.ngay,'yymmddhh24mi') as yymmdd,sovaovien from "+user+".benhandt a where a.mabn='" + s_mabn + "'";
					ds1.Merge(m.get_data_nam(nam,sql));

					dsngay.Clear();
					DataRow r1;
					foreach(DataRow r in ds1.Tables[0].Select("true","yymmdd desc,loai desc,loaiba"))
					{
						r1=dsngay.Tables[0].NewRow();
						r1["maql"]=r["maql"].ToString();
						r1["ngayvao"]=r["ngayvao"].ToString();
						r1["madoituong"]=r["madoituong"].ToString();
						r1["maphu"]=r["loai"].ToString();
						s_sovaovien=r["sovaovien"].ToString();
						dsngay.Tables[0].Rows.Add(r1);
					}
					ngayvao.DataSource=dsngay.Tables[0];				
					if (dsngay.Tables[0].Rows.Count>0) ngayvao.SelectedIndex=0;
					l_maql=(ngayvao.SelectedIndex!=-1)?decimal.Parse(ngayvao.SelectedValue.ToString()):0;
					if (l_maql!=0) load_vv(false);
				}
			}
			return ret;
		}

		private void ngay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void icd_t_Validated(object sender, System.EventArgs e)
		{
			if (icd_t.Text!=s_icd_t)
			{
				if (icd_t.Text=="") cd_t.Text="";
				else cd_t.Text=m.get_vviet(icd_t.Text).Trim();
				if (cd_t.Text=="" && icd_t.Text!="")
				{
                    dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_t.Text, cd_t.Text, true);
					f.ShowDialog();
					if (f.mICD!="")
					{
						cd_t.Text=f.mTen;
						icd_t.Text=f.mICD;
					}
				}
				if (cd_s.Text=="")
				{
					cd_s.Text=cd_t.Text;
					icd_s.Text=icd_t.Text;
					s_icd_s=icd_s.Text;
					if (cd_vk.Text=="")
					{
						cd_vk.Text=cd_t.Text;
						icd_vk.Text=icd_t.Text;
					}
				}
				s_icd_t=icd_t.Text;
			}
		}

		private void cd_t_Validated(object sender, System.EventArgs e)
		{
			if (icd_t.Text=="") icd_t.Text=m.get_cicd10(cd_t.Text);
			if (!m.bMaicd(icd_t.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã ICD10 này không có trong danh mục !"),s_msg);
				icd_t.Text="";
				icd_t.Focus();
			}
		}

		private void icd_s_Validated(object sender, System.EventArgs e)
		{
			if (icd_s.Text!=s_icd_s)
			{
				if (icd_s.Text=="") cd_s.Text="";
				else cd_s.Text=m.get_vviet(icd_s.Text).Trim();
				if (cd_s.Text=="" && icd_s.Text!="")
				{
                    dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_s.Text, cd_s.Text, true);
					f.ShowDialog();
					if (f.mICD!="")
					{
						cd_s.Text=f.mTen;
						icd_s.Text=f.mICD;
					}
				}
				s_icd_s=icd_s.Text;
			}
		}

		private void cd_s_Validated(object sender, System.EventArgs e)
		{
			if (icd_s.Text=="") icd_s.Text=m.get_cicd10(cd_s.Text);
			if (!m.bMaicd(icd_s.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã ICD10 này không có trong danh mục !"),s_msg);
				icd_s.Text="";
				icd_s.Focus();
			}
		}

		private void mapt_Validated(object sender, System.EventArgs e)
		{
			string s=m.get_tenpt(mapt.Text).Trim();
			if (s!="")
			{
				tenpt.Text=s.Substring(1);
				loaipt.SelectedValue=s.Substring(0,1);
			}
			else tenpt.Text="";
		}

		private void phuongphap_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tenphuongphap.SelectedValue=phuongphap.Text;
			}
			catch{}
		}

		private void phuongphap_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void tenphuongphap_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenphuongphap.SelectedIndex==-1) tenphuongphap.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tenphuongphap_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				phuongphap.Text=tenphuongphap.SelectedValue.ToString();
			}
			catch{}
		}

		private void tinhhinh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void taibien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void tuvong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ena_object(bool ena)
		{
			bCapso=false;
			butTuongtrinh.Checked=false;
			noidung.Enabled=ena;
			if (bSophieu) sophieu.Enabled=ena;
			list.Enabled=ena;
			ngay.Enabled=ena;
			cd_t.Enabled=ena;
			icd_t.Enabled=ena;
			cd_s.Enabled=ena;
			icd_s.Enabled=ena;
			if (somat.Visible) somat.Enabled=ena;
			if (bEdit_vp) loaivp.Enabled=ena;
			mavp.Enabled=loaivp.Enabled;
			madoituong.Enabled=ena;
			loaibn.Enabled=ena;
			ngayvao.Enabled=ena;
			molaimien.Enabled=ena;
			noisoi.Enabled=ena;
			bienchung.Enabled=ena;
			chktuongtrinh.Checked=false;
			phuongphap.Enabled=ena;
			tenphuongphap.Enabled=ena;
			ngaykt.Enabled=ena;
			mach.Enabled=ena;
			nhietdo.Enabled=ena;
			huyetap.Enabled=ena;
			//mamau.Enabled=ena;
			tenmau.Enabled=ena;
			phu1.Enabled=ena;
			tenphu1.Enabled=ena;
			phu2.Enabled=ena;
			tenphu2.Enabled=ena;
			bsgayme.Enabled=ena;
			tenbsgayme.Enabled=ena;
			ktvgayme.Enabled=ena;
			tenktvgayme.Enabled=ena;
			gio.Enabled=ena;
			giokt.Enabled=ena;
			lmau.Enabled=ena;
			tenpttt.Enabled=ena;
			if (bHoisuc)
			{
				hoisuc.Enabled=ena;
				tenhoisuc.Enabled=ena;
				dungcu.Enabled=ena;
				tendungcu.Enabled=ena;
			}
			//mautuongtrinh.Enabled=ena;
			chktuongtrinh.Enabled=ena;
			mabs.Enabled=ena;
			tenbs.Enabled=ena;
			tinhhinh.Enabled=ena;
			taibien.Enabled=ena;
			tuvong.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butThem.Enabled=ena;
			butLuu.Enabled=ena;
			butHinh.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butIn.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			if (ena)
			{
				cd_t.Enabled=m.bChandoan;
				cd_s.Enabled=cd_t.Enabled;
			}
			else
			{
				ngayvv.Enabled=ena;
				giovv.Enabled=ena;
			}
		}

		private void emp_text()
		{
			treeView1.Nodes.Clear();
			molaimien.Checked=false;
			noisoi.Checked=false;
			bienchung.Checked=false;
			if (somat.Visible) somat.Value=1;
			sophieu.Text="";
			mabn2.Text=DateTime.Now.Year.ToString().Substring(2,2);
			mabn3.Text="";cd_t.Text="";
			icd_t.Text="";cd_s.Text="";
			icd_s.Text="";mapt.Text="";
			tenpt.Text="";mach.Text="";
			nhietdo.Text="";huyetap.Text="";
			mamau.Text="";tenmau.Text="";
			phu1.Text="";tenphu1.Text="";
			phu2.Text="";tenphu2.Text="";
			bsgayme.Text="";tenbsgayme.Text="";
			ktvgayme.Text="";tenktvgayme.Text="";
			hoisuc.Text="";tenhoisuc.Text="";
			dungcu.Text="";tendungcu.Text="";
			noidung.Text="";tenpttt.Text="";
			lmau.SelectedIndex=-1;
			mautuongtrinh.SelectedIndex=-1;
			loaipt.SelectedIndex=-1;
			tinhhinh.SelectedIndex=0;
			taibien.SelectedIndex=0;
			tuvong.SelectedIndex=0;
			tenphuongphap.SelectedIndex=-1;
			loaivp.SelectedIndex=-1;
			mavp.SelectedIndex=-1;
			hoten.Text=m_hoten;tuoi.Text=m_tuoi;
			phai.Text=m_phai;diachi.Text=m_diachi;
			sothe.Text=m_sothe;giuong.Text=m_giuong;
			ngayvv.Text=m.Ngaygio_hienhanh.Substring(0,10);
			giovv.Text=m.Ngaygio_hienhanh.Substring(11);
			cd_vk.Text=m_cd_vk;
			icd_vk.Text=m_icd_vk;
			int dd=DateTime.Now.Day;
			int mm=DateTime.Now.Month;
			int yyyy=DateTime.Now.Year;
			int hh=DateTime.Now.Hour;
			int mi=DateTime.Now.Minute;
			ngay.Text=m.Ngaygio_hienhanh.Substring(0,10);
			ngaykt.Text=ngay.Text;
			gio.Text=m.Ngaygio_hienhanh.Substring(11);
			giokt.Text=gio.Text;
			s_ngay=ngay.Text;s_icd_t="";s_icd_s="";s_sovaovien="";
			if (m_mabn!="")
			{
				mabn2.Text=m_mabn.Substring(0,2);
				mabn3.Text=m_mabn.Substring(2,i_maxlenghth_mabn-2);
				tenkp.SelectedValue=m_makp;
			}
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			dsngay.Clear();
			ena_object(true);
			emp_text();
			l_id=0;
			bStatus=true;
			if (m_mabn=="")
			{
				if (ds.Tables[0].Rows.Count>0) list.Focus();
				else if (loaibn.Enabled) loaibn.Focus();
				else makp.Focus();
			}
			else sophieu.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (hoten.Text=="") return;
			bStatus=false;
			try
			{
                foreach (DataRow r in m.get_data("select id,maql,idkhoa,idvpkhoa,idduoc from " + user + m.mmyy(ngay.Text) + ".pttt where mabn='" + s_mabn + "'" + " and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + ngay.Text + " " + gio.Text + "'").Tables[0].Rows) 
				{
					l_id=decimal.Parse(r["id"].ToString());
					l_idkhoa=decimal.Parse(r["idkhoa"].ToString());
					l_idduoc=decimal.Parse(r["idduoc"].ToString());
					l_idvpkhoa=decimal.Parse(r["idvpkhoa"].ToString());
					l_maql=decimal.Parse(r["maql"].ToString());
					bPhucap=r["phucap"].ToString()=="1";
				}
			}
			catch{}
			if (bPhucap)
			{
				MessageBox.Show(lan.Change_language_MessageText("Ca phẫu thủ thuật này đã phụ cấp không được sửa !"),LibMedi.AccessData.Msg);
				return;
			}
			ena_object(true);
			sophieu.Focus();
			load_mabn();
		}

		private bool kiemtra()
		{
			if (tenkp.SelectedIndex==-1)
			{
				makp.Focus();
				return false;
			}
			if (hoten.Text=="")
			{
				mabn3.Focus();
				return false;
			}
			if (tenpttt.Text=="")
			{
				tenpttt.Focus();
				return false;
			}
			if (sophieu.Text=="" && sophieu.Enabled)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập số phiếu phẫu thuật / thủ thuật !"),s_msg);
				sophieu.Focus();
				return false;
			}
			if (bChandoan)
			{
				if (cd_t.Text=="" || icd_t.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán trước phẫu thuật / thủ thuật !"),s_msg);
					icd_t.Focus();
					return false;
				}
				if (!m.Kiemtra_maicd(dticd,icd_t.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"),LibMedi.AccessData.Msg);
					icd_t.Focus();
					return false;
				}
				if (!m.Kiemtra_tenbenh(dticd,cd_t.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"),LibMedi.AccessData.Msg);
					cd_t.Focus();
					return false;
				}
				if (cd_s.Text=="" || icd_s.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán sau phẫu thuật / thủ thuật !"),s_msg);
					icd_s.Focus();
					return false;
				}
				if (!m.Kiemtra_maicd(dticd,icd_s.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"),LibMedi.AccessData.Msg);
					icd_s.Focus();
					return false;
				}
				if (!m.Kiemtra_tenbenh(dticd,cd_s.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"),LibMedi.AccessData.Msg);
					cd_s.Focus();
					return false;
				}
			}
			if (mapt.Text=="" || tenpt.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Phương pháp phẫu thuật / thủ thuật !"),s_msg);
				mapt.Focus();
				return false;
			}

			if (!m.Kiemtra_mapt(dtpt,mapt.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã phẫu thuật - thủ thuật không hợp lệ !"),LibMedi.AccessData.Msg);
				mapt.Focus();
				return false;
			}
			if (!m.Kiemtra_tenpt(dtpt,tenpt.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Tên phẫu thuật - thủ thuật không hợp lệ !"),LibMedi.AccessData.Msg);
				tenpt.Focus();
				return false;
			}
			if (tenphuongphap.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Phương pháp vô cảm !"),s_msg);
				phuongphap.Focus();
				return false;
			}

			if (mabs.Text=="" || tenbs.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Phẫu thuật / thủ thuật viên !"),s_msg);
				mabs.Focus();
				return false;
			}

			if (ngayvv.Text!="")
			{
				if (!m.bNgaygio(ngay.Text+" "+gio.Text,ngayvv.Text+" "+giovv.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày phẫu thuật / thủ thuật không được nhỏ hơn ngày vào viện !"),s_msg);
					ngay.Focus();
					return false;
				}
			}
			if (!m.bNgaygio(ngaykt.Text+" "+giokt.Text,ngay.Text+" "+gio.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày giờ kết thúc không được nhỏ hơn ngày giờ bắt đầu !"),s_msg);
				ngaykt.Focus();
				return false;
			}
			if (m_ngayra!="")
			{
				if (!m.bNgaygio(m_ngayra,ngaykt.Text+" "+giokt.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày phẫu thuật / thủ thuật không được lớn hơn ngày ra viện !"),s_msg);
					ngay.Focus();
					return false;
				}
			}
			if (bPttt_pmo)
			{
				if (mapmo.SelectedIndex==-1)
				{
					MessageBox.Show(lan.Change_language_MessageText("Chọn phòng mỗ !"),LibMedi.AccessData.Msg);
					mapmo.Focus();
					return false;
				}
			}
			if (madoituong.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn đối tượng !"),s_msg);
				madoituong.Focus();
				return false;
			}
			if (bStatus)
			{
                if (m.get_data("select * from " + user + m.mmyy(ngay.Text) + ".pttt where mabn='" + s_mabn + "' and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + ngay.Text + " " + gio.Text + "'").Tables[0].Rows.Count > 0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh")+" "+hoten.Text+"\nĐã nhập ngày "+ngay.Text+" "+gio.Text,LibMedi.AccessData.Msg);
					ngay.Focus();
					return false;
				}
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			if (bStatus || l_id==0)
			{
				l_id=m.get_capid(6);
				if (bPttt_vp && !molaimien.Checked && mavp.SelectedIndex!=-1) l_idvpkhoa=v.get_id_vpkhoa;
				if (bPttt_thuoc) l_idduoc=d.get_id_xuatsd;
                m.execute_data("update " + user + ".pttt_bs set id=" + l_id + " where id=0");
			}
			if (!bAdmin)
			{
                DataTable tmp = m.get_data("select * from " + user + m.mmyy(ngay.Text) + ".pttt where id=" + l_id).Tables[0];
				if (tmp.Rows.Count!=0)
				{
					if (int.Parse(tmp.Rows[0]["userid"].ToString())!=m_userid)
					{
						MessageBox.Show(lan.Change_language_MessageText("Bạn không có quyền chỉnh sửa thông tin !"),LibMedi.AccessData.Msg);
						return;
					}
				}
			}
            if (!m.upd_pttt(l_id, mabn2.Text + mabn3.Text, l_maql, l_maql, makp.Text, (sophieu.Text != "") ? decimal.Parse(sophieu.Text) : 0, ngay.Text + " " + gio.Text, cd_t.Text, icd_t.Text, cd_s.Text, icd_s.Text, mapt.Text, tenpttt.Text, phuongphap.Text, int.Parse(tinhhinh.SelectedValue.ToString()), mabs.Text, int.Parse(taibien.SelectedValue.ToString()), int.Parse(tuvong.SelectedValue.ToString()), m_userid, tenmau.Text, ngaykt.Text + " " + giokt.Text, (mach.Text != "") ? decimal.Parse(mach.Text) : 0, (nhietdo.Text != "") ? decimal.Parse(nhietdo.Text) : 0, huyetap.Text, phu1.Text, phu2.Text, bsgayme.Text, ktvgayme.Text, hoisuc.Text, dungcu.Text, noidung.Text, int.Parse(loaibn.SelectedValue.ToString()), (bPttt_pmo) ? mapmo.SelectedValue.ToString() : "", (somat.Visible) ? Convert.ToInt32(somat.Value) : 1, (molaimien.Checked) ? 1 : 0, l_idvpkhoa, l_idduoc, l_idkhoa, (mavp.SelectedIndex != -1) ? int.Parse(mavp.SelectedValue.ToString()) : 0, int.Parse(madoituong.SelectedValue.ToString()), 0, (noisoi.Checked) ? 1 : 0))//;, (bienchung.Checked) ? 1 : 0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin phẩu thuật / thủ thuật !"),s_msg);
				return;
			}
            //Tu:21/05/2011 insert vao bang theodoitsu
            try
            {
                DataRow dr = m.getrowbyid(dsmau.Tables[0], "mapt='" + mapt.Text.Trim() + "'");
                if (dr != null)
                {
                    string s_mabn = mabn2.Text + mabn3.Text;
                    DataSet ds_tiendu = m.get_data("select (max(stt)+1) from " + user + ".theodoitsu where mabn='" + s_mabn + "'");
                    int i_stt = 1;
                    try { i_stt = int.Parse(ds_tiendu.Tables[0].Rows[0][0].ToString()); }
                    catch { i_stt = 1; }
                    m.upd_theodoitsu(s_mabn, tenpt.Text, ngayvv.Text.Substring(0, 10), mapt.Text, i_stt);
                    decimal i_stt_tsu = 0;
                    try { i_stt_tsu = decimal.Parse(m.get_data("select (max(stt)+1) from " + user + ".dmtheodoi").Tables[0].Rows[0][0].ToString()); }
                    catch { i_stt_tsu = 1; }
                    m.upd_dmtheodoi(mapt.Text, i_stt_tsu, tenpttt.Text);
                }
            }
            catch { }
            //end Tu
            if (bPttt_vp && !molaimien.Checked && mavp.SelectedIndex != -1)
            {
                v.upd_vpkhoa(l_idvpkhoa, mabn2.Text + mabn3.Text, l_maql, l_maql, l_idkhoa, ngay.Text + " " + gio.Text, makp.Text, int.Parse(madoituong.SelectedValue.ToString()), int.Parse(mavp.SelectedValue.ToString()), 1, decimal.Parse(dtvp.Rows[mavp.SelectedIndex]["gia_th"].ToString()), decimal.Parse(dtvp.Rows[mavp.SelectedIndex]["vattu_th"].ToString()), m_userid, 0);
                m.execute_data("update " + user + m.mmyy(ngay.Text) + ".v_vpkhoa set readonly=1 where id=" + l_idvpkhoa);
            }
            else if (!bStatus && molaimien.Checked) m.execute_data("delete from " + user + m.mmyy(ngay.Text) + ".v_vpkhoa where id=" + l_idvpkhoa);
			ena_object(false);
			DataRow r1=m.getrowbyid(ds.Tables[0],"id="+l_id);
			if (r1!=null)
			{
                m.execute_data("update " + user + m.mmyy(ngay.Text) + ".pttt_lichmo set done=2 where id=" + l_id);
				load_list();
			}
			load_mabn();
			load_mo();
			if (!chkXem.Checked) butIn_Click(sender,e);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
            butLuu_Click(sender, e);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (bPhucap)
			{
				MessageBox.Show(lan.Change_language_MessageText("Ca phẫu thủ thuật này đã phụ cấp không được hủy !"),LibMedi.AccessData.Msg);
				return;
			}
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),s_msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				s_mabn=mabn2.Text+mabn3.Text;
				if (bPttt_thuoc)
				{
                    sql = "select a.* from " + user + m.mmyy(ngay.Text) + ".d_duyet a," + user + m.mmyy(ngay.Text) + ".d_xtutrucll b where a.id=b.idduyet and b.id=" + l_idduoc + " and a.done=2";
					if (m.get_data(sql).Tables[0].Rows.Count>0)
					{
						MessageBox.Show(lan.Change_language_MessageText("Khoa Dược Đã duyệt thuốc & vật tư không cho phép hủy ?"),LibMedi.AccessData.Msg);
						return;
					}
					int kp=0;
					DataRow r=m.getrowbyid(dtduockp,"makp='"+makp.Text+"'");
					if (r!=null) kp=int.Parse(r["id"].ToString());
					string s_mmyy=ngay.Text.Substring(3,2)+ngay.Text.Substring(8,2);
                    foreach (DataRow r1 in m.get_data("select a.*,b.giamua,b.gianovat, a.gia_bh from " + user + s_mmyy + ".d_thucxuat a,"+user+s_mmyy+".d_theodoi b where a.sttt=b.id and a.id=" + l_idduoc).Tables[0].Rows)
					{
                        d.upd_tonkhoct_thucxuat(d.delete, s_mmyy, kp, 2, 1, decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), /*int.Parse(r1["nhomcc"].ToString()), */int.Parse(r1["mabd"].ToString()), /*r1["handung"].ToString(), r1["losx"].ToString(), */decimal.Parse(r1["soluong"].ToString()));//,decimal.Parse(r1["sotien"].ToString()),decimal.Parse(r1["giaban"].ToString()),decimal.Parse(r1["giamua"].ToString()));
                        //d.upd_theodoicongno(d.delete, mabn2.Text + mabn3.Text, l_maql, l_maql, l_idkhoa, int.Parse(r1["madoituong"].ToString()), decimal.Parse(r1["sotien"].ToString()), "thuoc");
                        //d.upd_tienthuoc(d.delete, s_mmyy,l_idduoc, mabn2.Text + mabn3.Text, l_maql, l_maql, l_idkhoa, ngay.Text, kp, 2, int.Parse(r1["madoituong"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), /*decimal.Parse(r1["sotien"].ToString()),*/ decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()));
                        d.upd_tienthuoc(d.delete, s_mmyy, l_idduoc, mabn2.Text + mabn3.Text, l_maql, l_maql, l_idkhoa, ngay.Text, kp, 2, int.Parse(r1["madoituong"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), /*decimal.Parse(r1["sotien"].ToString()),*/ decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["gianovat"].ToString()), 0, decimal.Parse(r1["gia_bh"].ToString()),mabs.Text);
                    }
                    d.execute_data("delete from " + user + s_mmyy + ".d_xuatsdct where id=" + l_idduoc);
                    d.execute_data("delete from " + user + s_mmyy + ".d_thucxuat where id=" + l_idduoc);
                    d.execute_data("delete from " + user + s_mmyy + ".d_xuatsdll where id=" + l_idduoc);
                    d.execute_data("delete from " + user + s_mmyy + ".d_xtutrucll where id=" + l_idduoc);
                    d.execute_data("delete from " + user + s_mmyy + ".d_xtutrucct where id=" + l_idduoc);
                    d.execute_data("update " + user + s_mmyy + ".pttt_lichmo set done=1 where id=" + l_id);
					load_list();
					load_mo();
				}
                m.execute_data("delete from " + user + m.mmyy(ngay.Text) + ".pttt where mabn='" + s_mabn + "'" + " and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + ngay.Text + " " + gio.Text + "'");
                if (bPttt_vp) v.execute_data("delete from " + user + m.mmyy(ngay.Text) + ".v_vpkhoa where id=" + l_idvpkhoa);
				load_mabn();
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (hoten.Text=="") return;
			string s;
			dsxml.Clear();
			DataRow r;
			r=dsxml.Tables[0].NewRow();
			r["mabn"]=mabn2.Text+mabn3.Text;
			r["hoten"]=hoten.Text;
			r["tuoi"]=tuoi.Text;
			r["phai"]=phai.Text;
			r["diachi"]=diachi.Text;
			r["khoa"]=tenkp.Text;
			r["giuong"]=giuong.Text;
			s=ngayvv.Text+" "+giovv.Text;
			if (s.Length==16)
				r["ngayvv"]=s.Substring(11,2)+" giờ "+s.Substring(14,2)+" phút, "+"       "+"Ngày "+s.Substring(0,2)+" tháng "+s.Substring(3,2)+" năm "+s.Substring(6,4);
			s=ngay.Text+" "+gio.Text;
			r["ngaypt"]=s.Substring(11,2)+" giờ "+s.Substring(14,2)+" phút, "+"       "+"Ngày "+s.Substring(0,2)+" tháng "+s.Substring(3,2)+" năm "+s.Substring(6,4);
			r["chandoanvk"]=cd_vk.Text;
			r["chandoant"]=cd_t.Text;
			r["chandoans"]=cd_s.Text;
			r["tenpt"]=tenpttt.Text;
			r["loaipt"]=loaipt.Text;
			r["vocam"]=tenphuongphap.Text;
			r["ptv"]=tenbs.Text;
			r["phu1"]=tenphu1.Text;
			r["phu2"]=tenphu2.Text;
			r["bsgayme"]=tenbsgayme.Text;
			r["ktvgayme"]=tenktvgayme.Text;
			r["hoisuc"]=tenhoisuc.Text;
			r["dungcu"]=tendungcu.Text;
			r["noidung"]=noidung.Text;
			DataRow r1=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
            if (r1 != null)
            {
                try { r["image"] = (byte[])(r1["image"]); }
                catch { }
            }
            foreach (DataRow r2 in m.get_data("select * from " + user + m.mmyy(ngay.Text) + ".pttt_hinh where id=" + l_id).Tables[0].Rows)
			{
				r["image1"]=(byte[])(r2["image1"]);
				r["image2"]=(byte[])(r2["image2"]);
			}
            dsxml.Tables[0].Rows.Add(r);
			if (chkXML.Checked)
			{
				if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
				dsxml.WriteXml("..\\xml\\pttt.xml",XmlWriteMode.WriteSchema);
			}
			if (chkXem.Checked)
			{				
				dllReportM.frmReport f=new dllReportM.frmReport(m,dsxml,"","rptTuongtrinh.rpt",true);
				f.ShowDialog();
			}
			else print.Printer(m,dsxml,"rptTuongtrinh.rpt","",1);
			butMoi.Focus();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void load_vv(bool skip)
		{
			s_mabn=mabn2.Text+mabn3.Text;
			string sql="";
			int i_tuoi;
			bool bFound=false;
            if (l_maql == 0)
            {
                sql = "select a.namsinh,b.mabn,b.mavaovien,b.maql,b.makp,b.ngay,b.dentu,b.nhantu,b.lanthu,b.madoituong,b.chandoan,b.maicd,b.mabs,b.sovaovien,b.loaiba,b.userid from " + user + ".btdbn a," + user + ".benhandt b where a.mabn=b.mabn and a.mabn='" + s_mabn + "' ";//order by b.ngay desc";
                sql += " union all ";
                sql += " select a.namsinh,b.mabn,b.mavaovien,b.maql,b.makp,b.ngay,b.dentu,b.nhantu,cast(0 as numeric) as lanthu,b.madoituong,b.chandoan,b.maicd,b.mabs,b.sovaovien,2 as loaiba,b.userid from " + user + ".btdbn a," + user + ".benhanngtr b where a.mabn=b.mabn and a.mabn='" + s_mabn + "' order by ngay desc";
            }
            else
            {
                sql = "select a.namsinh,b.mabn,b.mavaovien,b.maql,b.makp,b.ngay,b.dentu,b.nhantu,b.lanthu,b.madoituong,b.chandoan,b.maicd,b.mabs,b.sovaovien,b.loaiba,b.userid from " + user + ".btdbn a," + user + ".benhandt b where a.mabn=b.mabn and b.maql=" + l_maql;
                sql += " union all ";
                sql += " select a.namsinh,b.mabn,b.mavaovien,b.maql,b.makp,b.ngay,b.dentu,b.nhantu,cast(0 as numeric) as lanthu,b.madoituong,b.chandoan,b.maicd,b.mabs,b.sovaovien,2 as loaiba,b.userid from " + user + ".btdbn a," + user + ".benhanngtr b where a.mabn=b.mabn and b.maql=" + l_maql;
            }
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				l_maql=decimal.Parse(r["maql"].ToString());
				string s_ngay=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
				ngayvv.Text=s_ngay.Substring(0,10);
				giovv.Text=s_ngay.Substring(11);
				cd_vk.Text=r["chandoan"].ToString();
				icd_vk.Text=r["maicd"].ToString();
				if (!skip) madoituong.SelectedValue=r["madoituong"].ToString();
				i_tuoi=DateTime.Now.Year-int.Parse(r["namsinh"].ToString());
				tuoi.Text=i_tuoi.ToString();
				s_sovaovien=r["sovaovien"].ToString();
				bFound=true;
				break;
			}
			if (!bFound)
			{
				if (l_maql==0)	
				{
					sql="select 0 as loai,a.maql,a.ngay,a.madoituong,b.tuoivao,to_char(a.ngay,'yymmdd') as yymmdd,sovaovien from xxx.benhanpk a,xxx.lienhe b where a.maql=b.maql and a.mabn='"+s_mabn+"'";
					sql+=" union all ";
                    sql = " select 0 as loai,a.maql,a.ngay,a.madoituong,b.tuoivao,to_char(a.ngay,'yymmdd') as yymmdd,sovaovien from xxx.benhancc a,xxx.lienhe b where a.maql=b.maql and a.mabn='" + s_mabn + "'";
                    sql += " union all ";
					sql+=" select 1 as loai,a.maql,a.ngay,a.madoituong,a.tuoivao,to_char(a.ngay,'yymmdd') as yymmdd,sovaovien from xxx.tiepdon a where a.mabn='"+s_mabn+"'";
				}
				else 
				{
					sql="select 0 as loai,a.maql,a.ngay,a.madoituong,b.tuoivao,to_char(a.ngay,'yymmdd') as yymmdd,sovaovien from xxx.benhanpk a,xxx.lienhe b where a.maql=b.maql and a.maql="+l_maql;
					sql+=" union all ";
                    sql = " select 0 as loai,a.maql,a.ngay,a.madoituong,b.tuoivao,to_char(a.ngay,'yymmdd') as yymmdd,sovaovien from xxx.benhancc a,xxx.lienhe b where a.maql=b.maql and a.maql=" + l_maql;
                    sql += " union all ";
					sql+=" select 1 as loai,a.maql,a.ngay,a.madoituong,a.tuoivao,to_char(a.ngay,'yymmdd') as yymmdd,sovaovien from xxx.tiepdon a where a.maql="+l_maql;
				}
				foreach(DataRow r in m.get_data_nam(nam,sql).Tables[0].Select("true","loai,yymmdd desc"))
				{
					l_maql=decimal.Parse(r["maql"].ToString());
					if (!skip) madoituong.SelectedValue=r["madoituong"].ToString();
					string s_ngay=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
					ngayvv.Text=s_ngay.Substring(0,10);
					giovv.Text=s_ngay.Substring(11);
					m_tuoivao=r["tuoivao"].ToString();
					s_sovaovien=r["sovaovien"].ToString(); 
					break;
				}
			}
			else 
			{
                foreach (DataRow r in m.get_data("select * from " + user + ".nhapkhoa where makp='" + makp.Text + "'" + " and maql=" + l_maql + " order by ngay desc").Tables[0].Rows)
				{
					m_tuoivao=r["tuoivao"].ToString();
					cd_vk.Text=r["chandoan"].ToString();
					icd_vk.Text=r["maicd"].ToString();
					giuong.Text=r["giuong"].ToString();
					l_idkhoa=decimal.Parse(r["id"].ToString());
					break;
				}
				m_tuoivao=m.get_tuoivao(l_maql).Trim();
			}
            DataTable tmp = m.get_data("select * from " + user + ".bhyt where maql=" + l_maql).Tables[0];
			if (tmp.Rows.Count==0) tmp=m.get_data_nam_dec(nam,"select * from xxx.bhyt where maql="+l_maql).Tables[0];
			foreach(DataRow r in tmp.Rows)
			{
				sothe.Text=r["sothe"].ToString();
			}
			try
			{
				switch (int.Parse(m_tuoivao.Substring(3,1)))
				{
					case 0: m_loaituoi="TU";
						break;
					case 1: m_loaituoi="TH";
						break;
					case 2: m_loaituoi="NG";
						break;
					default: m_loaituoi="GI";
						break;
				}
				tuoi.Text=m_tuoivao.Substring(0,3)+m_loaituoi;
			}
			catch{}
		}

		private void load_treeView()
		{
			s_mabn=mabn2.Text+mabn3.Text;
			treeView1.Nodes.Clear();
			TreeNode node;
            foreach (DataRow r in m.get_data("select ngay,tenpt from " + user + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2) + ".pttt where mabn='" + s_mabn + "'" + " order by ngay desc").Tables[0].Rows)
			{
				node=treeView1.Nodes.Add(m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString())));
				node.Nodes.Add(r["tenpt"].ToString());
			}
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (e.Action==TreeViewAction.ByMouse)
			{
				try
				{
					string s=e.Node.FullPath.Trim();
					int iPos=s.IndexOf("/");
					s_ngay=s.Substring(iPos-2,16);
					s_mabn=mabn2.Text+mabn3.Text;
					load_pttt(s_ngay);
				}
				catch{}
			}
		}

		private void load_pttt(string s_ngay)
		{
			string sql="",s_ngaykt="";
			DataRow r1;
			bPhucap=false;
			s_mabn=mabn2.Text+mabn3.Text;
            if (s_ngay != "") sql = "select * from " + user + m.mmyy(s_ngay) + ".pttt where to_char(ngay,'dd/mm/yyyy hh24:mi')='" + s_ngay + "' and mabn='" + s_mabn + "'";
            else sql = "select * from " + user + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2) + ".pttt where mabn='" + s_mabn + "' order by ngay desc";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				l_id=decimal.Parse(r["id"].ToString());
				l_maql=decimal.Parse(r["maql"].ToString());
				l_idkhoa=decimal.Parse(r["idkhoa"].ToString());
				l_idvpkhoa=decimal.Parse(r["idvpkhoa"].ToString());
				l_idduoc=decimal.Parse(r["idduoc"].ToString());
				s_ngay=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
				if (r["ngaykt"].ToString()!="") s_ngaykt=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngaykt"].ToString()));
				else s_ngaykt=s_ngay;
				ngay.Text=s_ngay.Substring(0,10);
				gio.Text=s_ngay.Substring(11);
				ngaykt.Text=s_ngaykt.Substring(0,10);
				giokt.Text=s_ngaykt.Substring(11);
				tenkp.SelectedValue=r["makp"].ToString();
				makp.Text=r["makp"].ToString();
				if (bPttt_pmo)
				{
					load_btdpm(makp.Text);
					mapmo.SelectedValue=r["mapmo"].ToString();
				}
				r1=m.getrowbyid(dtkp,"makpbo='25' and makp='"+makp.Text+"'");
				bMat=r1!=null;
				lmat.Visible=bMat;
				somat.Visible=bMat;
				if (somat.Visible) somat.Value=decimal.Parse(r["somat"].ToString());
				molaimien.Checked=r["molaimien"].ToString()=="1";
				noisoi.Checked=r["noisoi"].ToString()=="1";
				bienchung.Checked=r["bienchung"].ToString()=="1";
				madoituong.SelectedValue=r["madoituong"].ToString();
				loaibn.SelectedValue=r["loaibn"].ToString();
				sophieu.Text=r["sophieu"].ToString();
				cd_t.Text=r["chandoant"].ToString();
				icd_t.Text=r["maicdt"].ToString();
				cd_s.Text=r["chandoans"].ToString();
				icd_s.Text=r["maicds"].ToString();
				mapt.Text=r["mapt"].ToString();
				tenpttt.Text=r["tenpt"].ToString();
				mamau.Text=r["mamau"].ToString();
				tenmau.Text=mamau.Text;
				load_mau(mamau.Text.Substring(0,6));
				lmau.SelectedValue=mamau.Text;
				r1=m.getrowbyid(dtpt,"mapt='"+mapt.Text+"'");
				if (r1!=null) tenpt.Text=r1["noi_dung"].ToString();
				tenphuongphap.SelectedValue=r["phuongphap"].ToString();
				tinhhinh.SelectedValue=r["tinhhinh"].ToString();
				taibien.SelectedValue=r["taibien"].ToString();
				tuvong.SelectedValue=r["tuvong"].ToString();
				mach.Text=r["mach"].ToString();
				nhietdo.Text=r["nhietdo"].ToString();
				huyetap.Text=r["huyetap"].ToString();
				noidung.Text=r["noidung"].ToString();
				gan_text(r["ptv"].ToString(),mabs,tenbs);
				gan_text(r["phu1"].ToString(),phu1,tenphu1);
				gan_text(r["phu2"].ToString(),phu2,tenphu2);
				gan_text(r["bsgayme"].ToString(),bsgayme,tenbsgayme);
				gan_text(r["ktvgayme"].ToString(),ktvgayme,tenktvgayme);
				gan_text(r["hoisuc"].ToString(),hoisuc,tenhoisuc);
				gan_text(r["dungcu"].ToString(),dungcu,tendungcu);
				try
				{
                    loaipt.SelectedValue = m.get_data("select loaipt from " + user + ".dmpttt where mapt='" + mapt.Text + "'").Tables[0].Rows[0][0].ToString();
				}
				catch{loaipt.SelectedIndex=0;}
				if (bPttt_vp)
				{
					r1=m.getrowbyid(dtmavp,"id="+int.Parse(r["mavp"].ToString()));
					if (r1!=null)
					{
						loaivp.SelectedValue=r1["id_loai"].ToString();
						mavp.SelectedValue=r1["id"].ToString();
					}
					else
					{
						loaivp.SelectedIndex=-1;
						mavp.SelectedIndex=-1;
					}
				}
                try { bPhucap = r["phucap"].ToString() == "1"; }
                catch { }
				break;
			}
			s_icd_t=icd_t.Text;
			s_icd_s=icd_s.Text;
			load_vv(true);
		}

		private void gan_text(string s,TextBox ma,TextBox ten)
		{
			if (s!="")
			{
				ma.Text=s;
				DataRow r=m.getrowbyid(dtbs,"ma='"+s+"'");
				if (r!=null) ten.Text=r["hoten"].ToString();
				else ten.Text="";
			}
			else ten.Text="";
		}

		private void ngay_Validated(object sender, System.EventArgs e)
		{
			ngay.Text=ngay.Text.Trim();
			if (ngay.Text.Length==6) ngay.Text=ngay.Text+DateTime.Now.Year.ToString();
			if (ngay.Text.Length<10)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ngày !"),s_msg);
				ngay.Focus();
				return;
			}
			if (!m.bNgay(ngay.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				ngay.Focus();
				return;
			}
			if (!m.ngay(m.StringToDate(ngay.Text.Substring(0,10)),DateTime.Now,songay))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày phẫu thuật / thủ thuật không hợp lệ so với khai báo hệ thống (")+songay.ToString()+")!",s_msg);
				ngay.Focus();
				return;
			}
		}

		private void sophieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void sophieu_Validated(object sender, System.EventArgs e)
		{
			try
			{
				sophieu.Text=decimal.Parse(sophieu.Text.ToString()).ToString();
			}
			catch{sophieu.Text="0";}
		}

		private void frmPttt_ba_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F3:
					if (butMoi.Enabled) butMoi_Click(sender,e);
					break;
				case Keys.F5:
					if (butThem.Enabled) butThem_Click(sender,e);
					break;
				case Keys.F6:
					if (butLuu.Enabled) butLuu_Click(sender,e);
					break;
				case Keys.F7:
					if (list.Enabled) get_mabn(list.SelectedValue.ToString());
					break;
				case Keys.F9:
					if (butIn.Enabled) butIn_Click(sender,e);
					break;
				case Keys.F10:
					if (butKetthuc.Enabled) butKetthuc_Click(sender,e);
					break;
			}
		}

		private void tenpt_Validated(object sender, System.EventArgs e)
		{
			string s=m.get_mapt(tenpt.Text);
			if (s!="")
			{
				mapt.Text=s.Substring(1);
				loaipt.SelectedValue=s.Substring(0,1);
			}
			if(!listpttt.Focused)listpttt.Hide();
		}

		private void tenpt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listpttt.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listpttt.Visible)
				{
					listpttt.Focus();
					SendKeys.Send("{Up}");
				}
				else SendKeys.Send("{Tab}");
			}
		}

		private void tenpt_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenpt)
			{
				Filt_pttt(tenpt.Text);
				listpttt.BrowseToText(tenpt,mapt,phuongphap);
			}
		}

		private void Filt_pttt(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listpttt.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten LIKE '%"+ten.Trim()+"%' or ma like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void butPttt_Click(object sender, System.EventArgs e)
		{
            dllDanhmucMedisoft.frmDmpttt f = new dllDanhmucMedisoft.frmDmpttt(m, mapt.Text, tenpt.Text, true);
			f.ShowDialog();
			if (f.m_mapt!="")
			{
				tenpt.Text=f.m_tenpt;
				mapt.Text=f.m_mapt;
				loaipt.SelectedValue=f.m_loaipt;
			}
		}

		private void listpttt_Validated(object sender, System.EventArgs e)
		{
			mamau_Validated(sender,e);
		}

		private void cd_t_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listICD.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listICD.Visible) listICD.Focus();
				else SendKeys.Send("{Tab}{Home}");
			}		
		}

		private void Filt_ICD(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listICD.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="vviet like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void cd_t_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cd_t)
			{
				if (bChandoan || icd_t.Text=="")
				{
					Filt_ICD(cd_t.Text);
					listICD.BrowseToICD10(cd_t,icd_t,icd_s,icd_t.Location.X,icd_t.Location.Y+icd_t.Height,icd_t.Width+cd_t.Width+2,icd_t.Height);
				}
			}		
		}

		private void cd_s_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cd_s)
			{
				if (bChandoan || icd_s.Text=="")
				{
					Filt_ICD(cd_s.Text);
					listICD.BrowseToICD10(cd_s,icd_s,mapt,icd_s.Location.X,icd_s.Location.Y+icd_s.Height,icd_s.Width+cd_s.Width+2,icd_s.Height);
				}
			}		
		}

		private void sophieu_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listBS.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listBS.Visible) listBS.Focus();
				else SendKeys.Send("{Tab}{Home}");
			}		
		}

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbs)
			{
				Filt_tenbs(tenbs.Text);
				listBS.BrowseToICD10(tenbs,mabs,phu1,mabs.Location.X,mabs.Location.Y+mabs.Height,mabs.Width+tenbs.Width+2,mabs.Height);
			}		
		}

		private void Filt_tenbs(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listBS.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void mabs_Validated(object sender, System.EventArgs e)
		{
			gan_text(mabs.Text,mabs,tenbs);
		}

		private void mabs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ngaykt_Validated(object sender, System.EventArgs e)
		{
			ngaykt.Text=ngaykt.Text.Trim();
			if (ngaykt.Text.Length==6) ngaykt.Text=ngaykt.Text+DateTime.Now.Year.ToString();
			if (ngaykt.Text.Length<10)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ngày !"),s_msg);
				ngaykt.Focus();
				return;
			}
			if (!m.bNgay(ngaykt.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				ngaykt.Focus();
				return;
			}
			if (!m.ngay(m.StringToDate(ngaykt.Text.Substring(0,10)),DateTime.Now,songay))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày phẫu thuật / thủ thuật không hợp lệ so với khai báo hệ thống (")+songay.ToString()+")!",s_msg);
				ngaykt.Focus();
				return;
			}
		}

		private void phu1_Validated(object sender, System.EventArgs e)
		{
			gan_text(phu1.Text,phu1,tenphu1);
		}

		private void phu2_Validated(object sender, System.EventArgs e)
		{
			gan_text(phu2.Text,phu2,tenphu2);
		}

		private void bsgayme_Validated(object sender, System.EventArgs e)
		{
			gan_text(bsgayme.Text,bsgayme,tenbsgayme);
		}

		private void ktvgayme_Validated(object sender, System.EventArgs e)
		{
			gan_text(ktvgayme.Text,ktvgayme,tenktvgayme);
		}

		private void hoisuc_Validated(object sender, System.EventArgs e)
		{
			gan_text(hoisuc.Text,hoisuc,tenhoisuc);
		}

		private void dungcu_Validated(object sender, System.EventArgs e)
		{
			gan_text(dungcu.Text,dungcu,tendungcu);
		}

		private void tenphu1_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenphu1)
			{
				Filt_tenbs(tenphu1.Text);
				listBS.BrowseToICD10(tenphu1,phu1,phu2,phu1.Location.X,phu1.Location.Y+phu1.Height,phu1.Width+tenphu1.Width+2,phu1.Height);
			}		
		}

		private void tenphu2_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenphu2)
			{
				Filt_tenbs(tenphu2.Text);
				listBS.BrowseToICD10(tenphu2,phu2,bsgayme,phu2.Location.X,phu2.Location.Y+phu2.Height,phu2.Width+tenphu2.Width+2,phu2.Height);
			}		
		}

		private void tenbsgayme_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbsgayme)
			{
				Filt_tenbs(tenbsgayme.Text);
				listBS.BrowseToICD10(tenbsgayme,bsgayme,ktvgayme,bsgayme.Location.X,bsgayme.Location.Y+bsgayme.Height,bsgayme.Width+tenbsgayme.Width+2,bsgayme.Height);
			}		
		}

		private void tenktvgayme_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenktvgayme)
			{
				Filt_tenbs(tenktvgayme.Text);
				listBS.BrowseToICD10(tenktvgayme,ktvgayme,hoisuc,ktvgayme.Location.X,ktvgayme.Location.Y+ktvgayme.Height,ktvgayme.Width+tenktvgayme.Width+2,ktvgayme.Height);
			}		
		}

		private void tenhoisuc_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenhoisuc)
			{
				Filt_tenbs(tenhoisuc.Text);
				listBS.BrowseToICD10(tenhoisuc,hoisuc,dungcu,hoisuc.Location.X,hoisuc.Location.Y+hoisuc.Height,hoisuc.Width+tenhoisuc.Width+2,hoisuc.Height);
			}		
		}

		private void tendungcu_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tendungcu)
			{
				Filt_tenbs(tendungcu.Text);
				listBS.BrowseToICD10(tendungcu,dungcu,tinhhinh,dungcu.Location.X,dungcu.Location.Y+dungcu.Height,dungcu.Width+tendungcu.Width+2,dungcu.Height);
			}		
		}

		private void mamau_Validated(object sender, System.EventArgs e)
		{
			if (mamau.Text!="")
			{
				DataRow r=m.getrowbyid(dsmau.Tables[0],"ma='"+mamau.Text+"'");
				if (r!=null)
				{
					if (bPttt_vp) load_vienphi(mamau.Text);
					tenpttt.Text=r["ten"].ToString();
					mapt.Text=r["mapt"].ToString();
					noidung.Text=r["noidung"].ToString();
					mapt_Validated(sender,e);
					load_mau(mamau.Text.Substring(0,6));
					lmau.SelectedValue=mamau.Text;
				}
			}
		}

		private void load_mau(string ma)
		{
            dslmau = m.get_data("select ma,ten,mapt,mabs,makp,noidung,mavp from " + user + ".pttt_mau where ma like '%" + ma.Trim() + "%' order by ma");
            dslmau.Merge(m.get_data("select mapt as ma,noi_dung as ten,mapt,'' as mabs,'' as makp,'' noidung,cast(0 as numeric) mavp from " + user + ".dmpttt where mapt like '%" + ma.Trim() + "%' order by mapt"));
			lmau.DataSource=dslmau.Tables[0];
		}

		private void tenmau_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenmau)
			{
				Filt_pttt(tenmau.Text);
				listpttt.BrowseToPTTT(tenmau,mamau,lmau,tenmau.Location.X,tenmau.Location.Y+tenmau.Height,tenmau.Width+lmau.Width+tenpttt.Width+4,tenmau.Height);
			}
		}

		private void butTuongtrinh_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==butTuongtrinh)
			{
				noidung.Visible=butTuongtrinh.Checked;
			}
		}

		private void chktuongtrinh_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==chktuongtrinh)
			{
				if (chktuongtrinh.Checked)
				{
					if (mamau.Text!="")
					{
                        mautuongtrinh.DataSource = m.get_data("select * from " + user + ".pttt_mau where ma like '%" + mamau.Text.Trim().Substring(0, 6) + "%'").Tables[0];
						if (!noidung.Visible) mautuongtrinh_SelectedIndexChanged(sender,e);
						else if (mautuongtrinh.Items.Count>0) noidung.Text=mautuongtrinh.SelectedValue.ToString();
					}
					else mautuongtrinh.DataSource=null;
				}
				else noidung.Text="";
				mautuongtrinh.Enabled=chktuongtrinh.Checked;
			}
		}

		private void mautuongtrinh_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mautuongtrinh)
			{
				if (mautuongtrinh.Items.Count>0) noidung.Text=mautuongtrinh.SelectedValue.ToString();
				if (bPttt_vp) load_vienphi(mautuongtrinh.SelectedValue.ToString());
			}
		}

		private void load_vienphi(string ma)
		{
			DataRow r,r1;
			r1=m.getrowbyid(dsmau.Tables[0],"ma='"+ma+"'");
			if (r1!=null)
			{
				r=m.getrowbyid(dtmavp,"id="+int.Parse(r1["mavp"].ToString()));
				if (r!=null)
				{
					loaivp.SelectedValue=r["id_loai"].ToString();
					mavp.SelectedValue=r1["mavp"].ToString();
				}
				else
				{
					loaivp.SelectedIndex=-1;
					mavp.SelectedIndex=-1;
				}
			}
		}

		private void loaibn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (loaibn.SelectedIndex==-1 && loaibn.Items.Count>0) loaibn.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void mapmo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (mapmo.SelectedIndex==-1 && mapmo.Items.Count>0) mapmo.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void mavp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mavp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (mavp.SelectedIndex!=-1) 
			{
				decimal st=decimal.Parse(dtvp.Rows[mavp.SelectedIndex]["gia_th"].ToString())+decimal.Parse(dtvp.Rows[mavp.SelectedIndex]["vattu_th"].ToString());
				sotien.Text=st.ToString("###,###,###,###");
			}
		}

		private void loaivp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (loaivp.SelectedIndex!=-1) load_mavp();
		}
		
		private void load_mavp()
		{
            dtvp = m.get_data("select * from " + user + ".v_giavp where id_loai=" + int.Parse(loaivp.SelectedValue.ToString()) + " order by stt").Tables[0];
			mavp.DataSource=dtvp;
		}

		private void mabn3_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void butThuoc_Click(object sender, System.EventArgs e)
		{
			if (butLuu.Enabled) butLuu_Click(sender,e);
			if (mamau.Text=="") return;
			if (!bPttt_tsoduoc)
			{
				loai=0;phieu=0;kp=0;nhom=m.nhom_duoc;l_duyet=0;ngay_thuoc=ngay.Text;
				mmyy_thuoc=ngay.Text.Substring(3,2)+ngay.Text.Substring(8,2);makho="";manguon="";
				DataRow r;
				r=m.getrowbyid(dtduockp,"makp='"+makp.Text+"'");
				if (r!=null) kp=int.Parse(r["id"].ToString());
				makhoa=kp;
                sql = "select mmyy from " + user + ".table order by substr(mmyy,3,2) desc,substr(mmyy,1,2) desc";
				DataTable dt=m.get_data(sql).Tables[0];
				foreach(DataRow r1 in dt.Rows)
				{
					mmyy_thuoc=r1["mmyy"].ToString();
                    if (m.get_data("select a.* from " + user + mmyy_thuoc + ".d_tutrucct a," + user + ".d_dmkho b where a.makho=b.id and b.nhom=" + nhom + " and a.makp=" + kp).Tables[0].Rows.Count > 0) break;
				}
                sql = "select a.id loai,b.id phieu from " + user + ".d_dmphieu a," + user + ".d_loaiphieu b where a.id=b.loai and a.id=2 and b.nhom=" + nhom + " order by b.stt";
				foreach(DataRow r1 in m.get_data(sql).Tables[0].Rows)
				{
                    sql = "select id,done from " + user + m.mmyy(ngay.Text) + ".d_duyet where nhom=" + nhom + " and to_char(ngay,'dd/mm/yyyy')='" + ngay.Text + "'";
					sql+=" and loai="+int.Parse(r1["loai"].ToString())+" and phieu="+int.Parse(r1["phieu"].ToString());
					sql+=" and makhoa="+makhoa;
					dt=m.get_data(sql).Tables[0];
					if (dt.Rows.Count>0)
					{
						if (int.Parse(dt.Rows[0]["done"].ToString())==1)
						{
							loai=int.Parse(r1["loai"].ToString());
							phieu=int.Parse(r1["phieu"].ToString());
							l_duyet=decimal.Parse(dt.Rows[0]["id"].ToString());
							break;
						}
					}
					else
					{
						loai=int.Parse(r1["loai"].ToString());
						phieu=int.Parse(r1["phieu"].ToString());
						l_duyet=d.get_id_duyet;
                        d.upd_duyet(mmyy_thuoc, l_duyet, nhom, ngay.Text, loai, phieu, kp, 1, m_userid, makhoa,0);
						break;
					}
				}
				if (loai==0 || phieu==0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Khoa dược đã duyệt !"),LibMedi.AccessData.Msg);
					return;
				}
                sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + nhom + " and loai=1";
                r = d.getrowbyid(dtduockp, "id=" + kp);
                if (r != null) makho = r["makho"].ToString();
                if (makho == "") makho = d.get_data("select kho from " + user + ".d_dmphieu where id=2").Tables[0].Rows[0][0].ToString();
				if (makho!="") sql+=" and id in ("+makho.Substring(0,makho.Length-1)+")";
				makho="";
				foreach(DataRow r1 in d.get_data(sql).Tables[0].Rows) makho+=r1["id"].ToString().Trim()+",";
                manguon = d.get_data("select nguon from " + user + ".d_dmphieu where id=2").Tables[0].Rows[0][0].ToString();
			}
			else
			{
				if (l_duyet==0) l_duyet=d.get_id_duyet;
                d.upd_duyet(mmyy_thuoc, l_duyet, nhom, ngay_thuoc, loai, phieu, kp, 1, m_userid, makhoa,0);
			}
			if (loai!=0 && phieu!=0 && kp!=0 && mmyy_thuoc!="")
			{
                //frmPttt_thuoc f = new frmPttt_thuoc(nhom, mamau.Text, lmau.Text, kp, ngay_thuoc + " " + gio.Text, loai, phieu, mmyy_thuoc, makho, manguon, l_duyet, bStatus, mabn2.Text + mabn3.Text, l_maql, l_maql, l_idkhoa, m_userid, l_idduoc);//, makhoa);
                frmPttt_thuoc f = new frmPttt_thuoc(nhom, mamau.Text, lmau.Text, kp, ngay_thuoc + " " + gio.Text, loai, phieu, mmyy_thuoc, makho, manguon, l_duyet, bStatus, mabn2.Text + mabn3.Text, l_maql, l_maql, l_idkhoa, m_userid, l_idduoc, makhoa,ngayvv.Text,mapt.Text,i_traituyen );
                f.ShowDialog(this);
			}
		}

		private void gio_Validated(object sender, System.EventArgs e)
		{
			string sgio=(gio.Text.Trim()=="")?"00:00":gio.Text.Trim();
			gio.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
			if (!m.bGio(gio.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
				gio.Focus();
				return;
			}
			if (ngayvv.Text!="")
			{
				if (!m.bNgaygio(ngay.Text+" "+gio.Text,ngayvv.Text+" "+giovv.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày phẫu thuật / thủ thuật không được nhỏ hơn ngày vào viện !"),s_msg);
					ngay.Focus();
					return;
				}
				if (m_ngayra!="")
				{
					if (!m.bNgaygio(m_ngayra,ngay.Text+" "+gio.Text))
					{
						MessageBox.Show(lan.Change_language_MessageText("Ngày phẫu thuật / thủ thuật không được lớn hơn ngày ra viện !"),s_msg);
						ngay.Focus();
						return;
					}
				}
			}
		}

		private void giokt_Validated(object sender, System.EventArgs e)
		{
			string sgio=(giokt.Text.Trim()=="")?"00:00":giokt.Text.Trim();
			giokt.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
			if (!m.bGio(giokt.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
				giokt.Focus();
				return;
			}
			if (!m.bNgaygio(ngaykt.Text+" "+giokt.Text,ngay.Text+" "+gio.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày kết thúc không được nhỏ hơn ngày bắt đầu !"),s_msg);
				ngaykt.Focus();
				return;
			}
		}

		private void lmau_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (lmau.SelectedIndex==-1 && lmau.Items.Count>0) lmau.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void lmau_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==lmau)
			{
				DataRow r=m.getrowbyid(dslmau.Tables[0],"ma='"+lmau.SelectedValue.ToString()+"'");
				if (r!=null)
				{
					noidung.Text=r["noidung"].ToString();
					tenmau.Text=r["ma"].ToString();
					tenpttt.Text=lmau.Text;
				}
			}
		}

		private void tenpttt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{Home}");
		}

		private void mach_Validated(object sender, System.EventArgs e)
		{
			if (mach.Text=="") icd_t.Focus();
		}

		private void ngayvv_Validated(object sender, System.EventArgs e)
		{
			ngayvv.Text=ngayvv.Text.Trim();
			if (ngayvv.Text.Length==6) ngayvv.Text=ngayvv.Text+DateTime.Now.Year.ToString();
			if (ngayvv.Text.Length<10)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ngày !"),s_msg);
				ngayvv.Focus();
				return;
			}
			if (!m.bNgay(ngayvv.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				ngayvv.Focus();
				return;
			}
			if (!m.ngay(m.StringToDate(ngayvv.Text.Substring(0,10)),DateTime.Now,songay))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày vào viện không hợp lệ so với khai báo hệ thống (")+songay.ToString()+")!",s_msg);
				ngayvv.Focus();
				return;
			}		
		}

		private void giovv_Validated(object sender, System.EventArgs e)
		{
			string sgio=(giovv.Text.Trim()=="")?"00:00":giovv.Text.Trim();
			giovv.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).PadLeft(2,'0');
			if (!m.bGio(giovv.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
				giovv.Focus();
				return;
			}
		}

		private void load_btdpm(string ma)
		{
            dtpm = m.get_data("select * from " + user + ".btdpmo where makp like '%" + ma.Trim() + ",%' order by ma").Tables[0];
            if (dtpm.Rows.Count == 0) dtpm = m.get_data("select * from " + user + ".btdpmo order by ma").Tables[0];
			mapmo.DataSource=dtpm; 
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			if (mabs.Text=="" || tenbs.Text=="")
			{
				mabs.Focus();
				return;
			}
			frmPttt_bs f=new frmPttt_bs(m,l_id);
			f.ShowDialog();
		}

		private void ngayvao_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (ngayvao.SelectedIndex==-1 && ngayvao.Items.Count>0) ngayvao.SelectedIndex=0;
				l_maql=(ngayvao.SelectedIndex!=-1)?decimal.Parse(ngayvao.SelectedValue.ToString()):0;
				load_vv(false);
				SendKeys.Send("{Tab}");
			}
		}

		private void butHinh_Click(object sender, System.EventArgs e)
		{
			if (l_id==0) butLuu_Click(sender,e);
            frmPttt_hinh f = new frmPttt_hinh(m, ngay.Text, l_id, dsmau.Tables[0], mamau.Text);
			f.ShowDialog(this);
		}

		private void tim_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) list.Focus();
		}

		private void tim_Enter(object sender, System.EventArgs e)
		{
			tim.Text="";			
		}

		private void tim_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim)
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[list.DataSource];
				DataView dv=(DataView)cm.List;
				if (tim.Text!="")
					dv.RowFilter="hoten like '%"+tim.Text.Trim()+"%' or mabn like '%"+tim.Text.Trim()+"%'";
				else
					dv.RowFilter="";
			}
		}

		private void list_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Escape) mabn3.Focus();
			else if (e.KeyCode==Keys.Enter) get_mabn(list.SelectedValue.ToString());
		}

		private void list_DoubleClick(object sender, System.EventArgs e)
		{
			get_mabn(list.SelectedValue.ToString());
		}

		private void butRef_Click(object sender, System.EventArgs e)
		{
			load_list();
			list.Focus();
		}

		private void timmo_Enter(object sender, System.EventArgs e)
		{
			timmo.Text="";
		}

		private void timmo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) listMo.Focus();
		}

		private void timmo_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==timmo)
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listMo.DataSource];
				DataView dv=(DataView)cm.List;
				if (tim.Text!="")
					dv.RowFilter="hoten like '%"+timmo.Text.Trim()+"%' or mabn like '%"+timmo.Text.Trim()+"%'";
				else
					dv.RowFilter="";
			}		
		}
	}
}
