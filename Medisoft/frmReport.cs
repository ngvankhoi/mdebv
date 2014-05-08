using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel;
using System.IO;
using LibMedi;
using LibDuoc;

namespace Medisoft
{
	/// <summary>
	/// Summary description for Freport.
	/// </summary>
	public class frmReport : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();
        private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		ReportDocument oRpt;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		public bool bPrinter;
        ExportOptions crExportOptions;
        DiskFileDestinationOptions crDiskFileDestinationOptions;
		private LibMedi.AccessData m;	
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
        private string msg, ReportFile, ExportPath;
		private DataSet ds=new DataSet();
		private System.Data.DataTable dt=new System.Data.DataTable();
		private CrystalDecisions.Windows.Forms.CrystalReportViewer Report;
		private int d01,d02,d03,d04,d05,d06,d07,d08,d09,d10;
		private int i_nhom=1,i_soluong_le=0,i_dongia_le=0,i_thanhtien_le=0;
		private string c1,c2,c3,c4,c5,c6,c7,c8,c9,c10;
		private bool b_145=false,b_benhan=false,b_bienlai=false,b_baohiem=false,bDoc=false,bia=false,bIcd10;
		private string MaBenhAn,Khoa,Giuong,SoLuuTru,MaYT,HoTen,NgaySinh,Tuoi,GioiTinh,TenNgheNghiep,MaNgheNghiep,TenDanToc,MaDanToc,TenNgoaiKieu,MaNgoaiKieu;
		private string SoNha,ThonPho,XaPhuong,TenQuanHuyen,MaQuanHuyen,TenTinhThanh,MaTinhThanh,ChoLam,MaDoiTuong,NgayBHYT,SoTheBHYT,QuanHe,DienThoai,ThoiGianBiBong,NgayVaoVien,TrucTiepVao;
		private string NoiGioiThieu,LanVaoVien,VaoKhoa,NgayVaoKhoa,SoNgayDieuTriVaoKhoa,ChuyenKhoa1,NgayChuyenKhoa1,SoNgayDieuTriChuyenKhoa1,ChuyenKhoa2,NgayChuyenKhoa2,SoNgayDieuTriChuyenKhoa2;
		private string ChuyenKhoa3,NgayChuyenKhoa3,SoNgayDieuTriChuyenKhoa3,ChuyenVien,ChuyenDen,NgayRaVien,TinhTrangLucRaVien,TongNgayDieuTri,ChanDoanNoiChuyen,ICDChanDoanNoiChuyen,ChanDoanKhoaKhamBenhCapCuu,ICDChanDoanKhoaKhamBenhCapCuu;
		private string ChanDoanVaoKhoa,ICDChanDoanVaoKhoa,CoThuThuat,CoPhauThuat,ChanDoanRaVienBenhChinh,ICDChanDoanRaVienBenhChinh,ChanDoanRaVienBenhKemTheo,ICDChanDoanRaVienBenhKemTheo,CoTaiBien,CoBienChung,KetQuaDieuTri,GiaiPhauBenh,NgayTuVong;
		private string TinhTrangTuVong,ThoiDiemTuVong,NguyenNhanTuVong,ICDNguyenNhanTuVong,CoKhamNghiemTuThi,ChanDoanTuThi,ICDChanDoanTuThi,NguyenNhanTaiBienBienChung,TongSoNgayDieuTriSauPhauThuat,TongSoLanPhauThuat,ChanDoanRaVienBenhChinhNguyenNhan,ICDChanDoanRaVienBenhChinhNguyenNhan;
		private string ChanDoanTruocPhauThuat,ICDChanDoanTruocPhauThuat,ChanDoanSauPhauThuat,ICDChanDoanSauPhauThuat,TinhTrangPhauThuat,TrinhDoVanHoa,HoTenBo,NgheNghiepBo,TrinhDoVanHoaBo,HoTenMe,NgheNghiepMe,TrinhDoVanHoaMe,NgaySinhMe,MaNgheNghiepMe,DeLanMay,NgaySinhBo;
		private string MaNgheNghiepBo,NhomMauMe,TienThai,NgayDe,NgoiThai,CachThucDe,CoKiemSoatTuCung,KiemSoatTuCung,PhuongPhapPhauThuat,LoaiThai,GioiTinhTre,TreConSong,TreCoDiTat,TreDiTat,TreCanNang,ChanDoanVaoKhoaT,ChanDoanVaoKhoaN,ChanDoanVaoKhoaM,ChanDoanVaoKhoaGiaiDoan;
		private string ChanDoanRaVienBenhChinhT,ChanDoanRaVienBenhChinhN,ChanDoanRaVienBenhChinhM,ChanDoanRaVienBenhChinhGiaiDoan;
        private System.Windows.Forms.NumericUpDown banin;
		private System.Windows.Forms.NumericUpDown den;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown tu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butIn;
        private System.Windows.Forms.Button butExcel;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butPdf;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmReport(LibMedi.AccessData acc,System.Data.DataTable ta,string report,string s1,string s2,string s3,string s4,string s5,string s6,string s7,string s8,string s9,string s10)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; dt = ta; c1 = s1; c2 = s2; c3 = s3; c4 = s4; c5 = s5; c6 = s6; c7 = s7; c8 = s8; c9 = s9; c10 = s10;
			b_baohiem=true;
			ReportFile=report;
			this.Text=report;
		}
        public frmReport(LibMedi.AccessData acc, System.Data.DataTable ta, string report, string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10,decimal sobanin)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; dt = ta; c1 = s1; c2 = s2; c3 = s3; c4 = s4; c5 = s5; c6 = s6; c7 = s7; c8 = s8; c9 = s9; c10 = s10;
            b_baohiem = true; banin.Value = Math.Max(1,sobanin);
            ReportFile = report;
            this.Text = report;
        }
		public frmReport(DataSet dset,string s1,string s2,string report)
		{
			InitializeComponent();
			ds=dset;
			c1=s1;c2=s2;
			b_bienlai=true;
			ReportFile=report;
			this.Text=report;
		}
		public frmReport(LibMedi.AccessData acc,DataSet dset,string mMsg,string report)
		{
			InitializeComponent();
			m=acc;
			ds=dset;
			msg=mMsg;
			ReportFile=report;
			this.Text=report;
		}

		public frmReport(LibMedi.AccessData acc,DataSet dset,string mMsg,string report,bool doc)
		{
			InitializeComponent();
			m=acc;
			ds=dset;
			msg=mMsg;
			ReportFile=report;
			bDoc=doc;
			this.Text=report;
		}

        public frmReport(LibMedi.AccessData acc, DataSet dset, string s1, string s2, string s3,string report)
        {
            InitializeComponent();
            m = acc;
            ds = dset;
            c1 = s1; c2 = s2; c3 = s3;
            ReportFile = report;
            bIcd10 = true;
            this.Text = report;
        }

        public frmReport(LibMedi.AccessData acc, DataSet dset, string mMsg, string report, bool doc,int done)
        {
            InitializeComponent();
            m = acc;
            ds = dset;
            msg = mMsg;
            ReportFile = report;
            bDoc = doc;
            butIn.Enabled = done == 0;
            butPdf.Enabled = done == 0;
            Report.ShowExportButton = done == 0;
            Report.ShowPrintButton = done == 0;
            this.Text = report;
        }

		public frmReport(LibMedi.AccessData acc,DataSet dset,string mMsg,string report,int i01,int i02,int i03,int i04,int i05,int i06,int i07,int i08,int i09,int i10)
		{
			InitializeComponent();
            m = acc; ds = dset; msg = mMsg; d01 = i01; d02 = i02; d03 = i03; d04 = i04; d05 = i05; d06 = i06; d07 = i07; d08 = i08; d09 = i09; d10 = i10; b_145 = true; ReportFile = report; this.Text = report;
		}

		public frmReport(LibMedi.AccessData acc,DataSet dset,string report,string s1,string s2,string s3,string s4,string s5,string s6)
		{
			InitializeComponent();
            m = acc; ds = dset; c1 = s1; c2 = s2; c3 = s3; c4 = s4; c5 = s5; c6 = s6; bia = true; ReportFile = report; this.Text = report;
		}

		public frmReport(LibMedi.AccessData acc,DataSet dset,string report,string mabenhan,string khoa,string giuong,string soluutru,string mayt,string hoten,string ngaysinh,string tuoi,string gioitinh,string tennghenghiep,string manghenghiep,string tendantoc,string madantoc,string tenngoaikieu,string mangoaikieu,
			string sonha,string thonpho,string xaphuong,string tenquanhuyen,string maquanhuyen,string tentinhthanh,string matinhthanh,string cholam,string madoituong,string ngaybhyt,string sothebhyt,string quanhe,string dienthoai,string thoigianbibong,string ngayvaovien,string tructiepvao,string noigioithieu,string lanvaovien,
			string vaokhoa,string ngayvaokhoa,string songaydieutrivaokhoa,string chuyenkhoa1,string ngaychuyenkhoa1,string songaydieutrichuyenkhoa1,string chuyenkhoa2,string ngaychuyenkhoa2,string songaydieutrichuyenkhoa2,string chuyenkhoa3,string ngaychuyenkhoa3,string songaydieutrichuyenkhoa3,string chuyenvien,
			string chuyenden,string ngayravien,string tinhtranglucravien,string tongngaydieutri,string chandoannoichuyen,string icdchandoannoichuyen,string chandoankhoakhambenhcapcuu,string icdchandoankhoakhambenhcapcuu,string chandoanvaokhoa,string icdchandoanvaokhoa,string cothuthuat,string cophauthuat,string chandoanravienbenhchinh,
			string icdchandoanravienbenhchinh,string chandoanravienbenhkemtheo,string icdchandoanravienbenhkemtheo,string cotaibien,string cobienchung,string ketquadieutri,string giaiphaubenh,string ngaytuvong,string tinhtrangtuvong,string thoidiemtuvong,string nguyennhantuvong,string icdnguyennhantuvong,string cokhamnghiemtuthi,
			string chandoantuthi,string icdchandoantuthi,string nguyennhantaibienbienchung,string tongsongaydieutrisauphauthuat,string tongsolanphauthuat,string chandoanravienbenhchinhnguyennhan,string icdchandoanravienbenhchinhnguyennhan,string chandoantruocphauthuat,string icdchandoantruocphauthuat,string chandoansauphauthuat,string icdchandoansauphauthuat,string tinhtrangphauthuat,string trinhdovanhoa,string hotenbo,string nghenghiepbo,
			string trinhdovanhoabo,string hotenme,string nghenghiepme,string trinhdovanhoame,string ngaysinhme,string manghenghiepme,string delanmay,string ngaysinhbo,string manghenghiepbo,string nhommaume,string tienthai,string ngayde,string ngoithai,string cachthucde,string cokiemsoattucung,string kiemsoattucung,string phuongphapphauthuat,string loaithai,
			string gioitinhtre,string treconsong,string trecoditat,string treditat,string trecannang,string chandoanvaokhoat,string chandoanvaokhoan,string chandoanvaokhoam,string chandoanvaokhoagiaidoan,string chandoanravienbenhchinht,string chandoanravienbenhchinhn,string chandoanravienbenhchinhm,string chandoanravienbenhchinhgiaidoan)
		{
			InitializeComponent();
			m=acc;
			ds=dset;
			ReportFile=report;
			b_benhan=true;
			MaBenhAn=mabenhan;Khoa=khoa;Giuong=giuong;SoLuuTru=soluutru;MaYT=mayt;HoTen=hoten;NgaySinh=ngaysinh;Tuoi=tuoi;GioiTinh=gioitinh;TenNgheNghiep=tennghenghiep;MaNgheNghiep=manghenghiep;TenDanToc=tendantoc;MaDanToc=madantoc;TenNgoaiKieu=tenngoaikieu;MaNgoaiKieu=mangoaikieu;
			SoNha=sonha;ThonPho=thonpho;XaPhuong=xaphuong;TenQuanHuyen=tenquanhuyen;MaQuanHuyen=maquanhuyen;TenTinhThanh=tentinhthanh;MaTinhThanh=matinhthanh;ChoLam=cholam;MaDoiTuong=madoituong;NgayBHYT=ngaybhyt;SoTheBHYT=sothebhyt;QuanHe=quanhe;DienThoai=dienthoai;ThoiGianBiBong=thoigianbibong;NgayVaoVien=ngayvaovien;TrucTiepVao=tructiepvao;
			NoiGioiThieu=noigioithieu;LanVaoVien=lanvaovien;VaoKhoa=vaokhoa;NgayVaoKhoa=ngayvaokhoa;SoNgayDieuTriVaoKhoa=songaydieutrivaokhoa;ChuyenKhoa1=chuyenkhoa1;NgayChuyenKhoa1=ngaychuyenkhoa1;SoNgayDieuTriChuyenKhoa1=songaydieutrichuyenkhoa1;ChuyenKhoa2=chuyenkhoa2;NgayChuyenKhoa2=ngaychuyenkhoa2;SoNgayDieuTriChuyenKhoa2=songaydieutrichuyenkhoa2;
			ChuyenKhoa3=chuyenkhoa3;NgayChuyenKhoa3=ngaychuyenkhoa3;SoNgayDieuTriChuyenKhoa3=songaydieutrichuyenkhoa3;ChuyenVien=chuyenvien;ChuyenDen=chuyenden;NgayRaVien=ngayravien;TinhTrangLucRaVien=tinhtranglucravien;TongNgayDieuTri=tongngaydieutri;ChanDoanNoiChuyen=chandoannoichuyen;ICDChanDoanNoiChuyen=icdchandoannoichuyen;ChanDoanKhoaKhamBenhCapCuu=chandoankhoakhambenhcapcuu;ICDChanDoanKhoaKhamBenhCapCuu=icdchandoankhoakhambenhcapcuu;
			ChanDoanVaoKhoa=chandoanvaokhoa;ICDChanDoanVaoKhoa=icdchandoanvaokhoa;CoThuThuat=cothuthuat;CoPhauThuat=cophauthuat;ChanDoanRaVienBenhChinh=chandoanravienbenhchinh;ICDChanDoanRaVienBenhChinh=icdchandoanravienbenhchinh;ChanDoanRaVienBenhKemTheo=chandoanravienbenhkemtheo;ICDChanDoanRaVienBenhKemTheo=icdchandoanravienbenhkemtheo;CoTaiBien=cotaibien;CoBienChung=cobienchung;KetQuaDieuTri=ketquadieutri;GiaiPhauBenh=giaiphaubenh;NgayTuVong=ngaytuvong;
			TinhTrangTuVong=tinhtrangtuvong;ThoiDiemTuVong=thoidiemtuvong;NguyenNhanTuVong=nguyennhantuvong;ICDNguyenNhanTuVong=icdnguyennhantuvong;CoKhamNghiemTuThi=cokhamnghiemtuthi;ChanDoanTuThi=chandoantuthi;ICDChanDoanTuThi=icdchandoantuthi;NguyenNhanTaiBienBienChung=nguyennhantaibienbienchung;TongSoNgayDieuTriSauPhauThuat=tongsongaydieutrisauphauthuat;TongSoLanPhauThuat=tongsolanphauthuat;ChanDoanRaVienBenhChinhNguyenNhan=chandoanravienbenhchinhnguyennhan;
			ICDChanDoanRaVienBenhChinhNguyenNhan=icdchandoanravienbenhchinhnguyennhan;ChanDoanTruocPhauThuat=chandoantruocphauthuat;ICDChanDoanTruocPhauThuat=icdchandoantruocphauthuat;ChanDoanSauPhauThuat=chandoansauphauthuat;ICDChanDoanSauPhauThuat=icdchandoansauphauthuat;TinhTrangPhauThuat=tinhtrangphauthuat;TrinhDoVanHoa=trinhdovanhoa;HoTenBo=hotenbo;NgheNghiepBo=nghenghiepbo;TrinhDoVanHoaBo=trinhdovanhoabo;HoTenMe=hotenme;NgheNghiepMe=nghenghiepme;TrinhDoVanHoaMe=trinhdovanhoame;NgaySinhMe=ngaysinhme;MaNgheNghiepMe=manghenghiepme;DeLanMay=delanmay;NgaySinhBo=ngaysinhbo;
			MaNgheNghiepBo=manghenghiepbo;NhomMauMe=nhommaume;TienThai=tienthai;NgayDe=ngayde;NgoiThai=ngoithai;CachThucDe=cachthucde;CoKiemSoatTuCung=cokiemsoattucung;KiemSoatTuCung=kiemsoattucung;PhuongPhapPhauThuat=phuongphapphauthuat;LoaiThai=loaithai;GioiTinhTre=gioitinhtre;TreConSong=treconsong;TreCoDiTat=trecoditat;TreDiTat=treditat;TreCanNang=trecannang;ChanDoanVaoKhoaT=chandoanvaokhoat;ChanDoanVaoKhoaN=chandoanvaokhoan;ChanDoanVaoKhoaM=chandoanvaokhoam;ChanDoanVaoKhoaGiaiDoan=chandoanvaokhoagiaidoan;
			ChanDoanRaVienBenhChinhT=chandoanravienbenhchinht;ChanDoanRaVienBenhChinhN=chandoanravienbenhchinhn;ChanDoanRaVienBenhChinhM=chandoanravienbenhchinhm;ChanDoanRaVienBenhChinhGiaiDoan=chandoanravienbenhchinhgiaidoan;
			this.Text=report;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>

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
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.Report = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.banin = new System.Windows.Forms.NumericUpDown();
            this.den = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butExcel = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.butPdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.banin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            this.SuspendLayout();
            // 
            // Report
            // 
            this.Report.ActiveViewIndex = -1;
            this.Report.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Report.DisplayGroupTree = false;
            this.Report.Location = new System.Drawing.Point(-1, 0);
            this.Report.Name = "Report";
            this.Report.SelectionFormula = "";
            this.Report.ShowCloseButton = false;
            this.Report.ShowPrintButton = false;
            this.Report.Size = new System.Drawing.Size(949, 358);
            this.Report.TabIndex = 9;
            this.Report.ViewTimeSelectionFormula = "";
            // 
            // banin
            // 
            this.banin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.banin.Location = new System.Drawing.Point(374, 5);
            this.banin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.banin.Name = "banin";
            this.banin.Size = new System.Drawing.Size(34, 21);
            this.banin.TabIndex = 1;
            this.banin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.banin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.banin_KeyDown);
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(535, 5);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(44, 21);
            this.den.TabIndex = 5;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.banin_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(505, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "đến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(458, 5);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(45, 21);
            this.tu.TabIndex = 3;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.banin_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(406, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Từ trang :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(582, 4);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(45, 22);
            this.butIn.TabIndex = 6;
            this.butIn.Text = "In";
            this.butIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butIn.UseVisualStyleBackColor = true;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butExcel
            // 
            this.butExcel.Image = ((System.Drawing.Image)(resources.GetObject("butExcel.Image")));
            this.butExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExcel.Location = new System.Drawing.Point(628, 4);
            this.butExcel.Name = "butExcel";
            this.butExcel.Size = new System.Drawing.Size(60, 22);
            this.butExcel.TabIndex = 7;
            this.butExcel.Text = "Excel";
            this.butExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butExcel.UseVisualStyleBackColor = true;
            this.butExcel.Click += new System.EventHandler(this.butExcel_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(745, 4);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(73, 22);
            this.butKetthuc.TabIndex = 8;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(312, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "&Số bản in :";
            // 
            // butPdf
            // 
            this.butPdf.Image = ((System.Drawing.Image)(resources.GetObject("butPdf.Image")));
            this.butPdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butPdf.Location = new System.Drawing.Point(689, 4);
            this.butPdf.Name = "butPdf";
            this.butPdf.Size = new System.Drawing.Size(55, 22);
            this.butPdf.TabIndex = 10;
            this.butPdf.Text = "PDF";
            this.butPdf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butPdf.UseVisualStyleBackColor = true;
            this.butPdf.Click += new System.EventHandler(this.butPdf_Click);
            // 
            // frmReport
            // 
            this.AcceptButton = this.butIn;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1016, 713);
            this.Controls.Add(this.butPdf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butExcel);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.banin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Report);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medisoft";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closed += new System.EventHandler(this.frmReport_Closed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReport_KeyDown);
            this.Load += new System.EventHandler(this.frmReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.banin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmReport_Load(object sender, System.EventArgs e)
		{
            this.Size = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
			this.Report.Size = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width,Screen.PrimaryScreen.WorkingArea.Height);
            string dir = System.IO.Directory.GetCurrentDirectory();
            ExportPath = "";
            int j = 0;
            for (int i = 0; i < dir.Length; i++)
            {
                if (dir.Substring(i, 1) == "\\") j++;
                if (j == 2) break;
                ExportPath += dir.Substring(i, 1);
            }
            ExportPath += "\\pdf\\";
            if (!System.IO.Directory.Exists(ExportPath)) System.IO.Directory.CreateDirectory(ExportPath);
			i_soluong_le=d.d_soluong_le(i_nhom);
			i_dongia_le=d.d_dongia_le(i_nhom);
			i_thanhtien_le=d.d_thanhtien_le(i_nhom);
			this.Tag=System.Environment.CurrentDirectory.ToString();
            if (bIcd10) icd10();
			else if (b_baohiem) Baohiem();
			else if (b_bienlai) Bienlai();
			else if (ds==null || bia) Bia();
			else if (b_145) Report145();
			else if (b_benhan) Benhan();
			else PreviewReport();
		}

		private void Benhan()
		{
			try
			{
				oRpt=new ReportDocument();
				oRpt.Load("..//..//..//report//"+ReportFile+".rpt",OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(ds);
				oRpt.DataDefinition.FormulaFields["SoYTe"].Text="'"+m.Syte+"'";
				oRpt.DataDefinition.FormulaFields["BenhVien"].Text="'"+m.Tenbv+"'";
				oRpt.DataDefinition.FormulaFields["MaBenhAn"].Text="'"+MaBenhAn+"'";
				oRpt.DataDefinition.FormulaFields["Khoa"].Text="'"+Khoa+"'";
				oRpt.DataDefinition.FormulaFields["Giuong"].Text="'"+Giuong+"'";
				oRpt.DataDefinition.FormulaFields["SoLuuTru"].Text="'"+SoLuuTru+"'";
				oRpt.DataDefinition.FormulaFields["MaYT"].Text="'"+MaYT+"'";
				oRpt.DataDefinition.FormulaFields["HoTen"].Text="'"+HoTen+"'";
				oRpt.DataDefinition.FormulaFields["NgaySinh"].Text="'"+NgaySinh+"'";
				oRpt.DataDefinition.FormulaFields["Tuoi"].Text="'"+Tuoi+"'";
				oRpt.DataDefinition.FormulaFields["GioiTinh"].Text="'"+GioiTinh+"'";
				oRpt.DataDefinition.FormulaFields["TenNgheNghiep"].Text="'"+TenNgheNghiep+"'";
				oRpt.DataDefinition.FormulaFields["MaNgheNghiep"].Text="'"+MaNgheNghiep+"'";
				oRpt.DataDefinition.FormulaFields["TenDanToc"].Text="'"+TenDanToc+"'";
				oRpt.DataDefinition.FormulaFields["MaDanToc"].Text="'"+MaDanToc+"'";
				oRpt.DataDefinition.FormulaFields["TenNgoaiKieu"].Text="'"+TenNgoaiKieu+"'";
				oRpt.DataDefinition.FormulaFields["MaNgoaiKieu"].Text="'"+MaNgoaiKieu+"'";
				oRpt.DataDefinition.FormulaFields["SoNha"].Text="'"+SoNha+"'";
				oRpt.DataDefinition.FormulaFields["ThonPho"].Text="'"+ThonPho+"'";
				oRpt.DataDefinition.FormulaFields["XaPhuong"].Text="'"+XaPhuong+"'";
				oRpt.DataDefinition.FormulaFields["TenQuanHuyen"].Text="'"+TenQuanHuyen+"'";
				oRpt.DataDefinition.FormulaFields["MaQuanHuyen"].Text="'"+MaQuanHuyen+"'";
				oRpt.DataDefinition.FormulaFields["TenTinhThanh"].Text="'"+TenTinhThanh+"'";
				oRpt.DataDefinition.FormulaFields["MaTinhThanh"].Text="'"+MaTinhThanh+"'";
				oRpt.DataDefinition.FormulaFields["ChoLam"].Text="'"+ChoLam+"'";
				oRpt.DataDefinition.FormulaFields["MaDoiTuong"].Text="'"+MaDoiTuong+"'";
				oRpt.DataDefinition.FormulaFields["NgayBHYT"].Text="'"+NgayBHYT+"'";
				oRpt.DataDefinition.FormulaFields["SoTheBHYT"].Text="'"+SoTheBHYT+"'";
				oRpt.DataDefinition.FormulaFields["QuanHe"].Text="'"+QuanHe+"'";
				oRpt.DataDefinition.FormulaFields["DienThoai"].Text="'"+DienThoai+"'";
				oRpt.DataDefinition.FormulaFields["ThoiGianBiBong"].Text="'"+ThoiGianBiBong+"'";
				oRpt.DataDefinition.FormulaFields["NgayVaoVien"].Text="'"+NgayVaoVien+"'";
				oRpt.DataDefinition.FormulaFields["TrucTiepVao"].Text="'"+TrucTiepVao+"'";
				oRpt.DataDefinition.FormulaFields["NoiGioiThieu"].Text="'"+NoiGioiThieu+"'";
				oRpt.DataDefinition.FormulaFields["LanVaoVien"].Text="'"+LanVaoVien+"'";
				oRpt.DataDefinition.FormulaFields["VaoKhoa"].Text="'"+VaoKhoa+"'";
				oRpt.DataDefinition.FormulaFields["NgayVaoKhoa"].Text="'"+NgayVaoKhoa+"'";
				oRpt.DataDefinition.FormulaFields["SoNgayDieuTriVaoKhoa"].Text="'"+SoNgayDieuTriVaoKhoa+"'";
				oRpt.DataDefinition.FormulaFields["ChuyenKhoa1"].Text="'"+ChuyenKhoa1+"'";
				oRpt.DataDefinition.FormulaFields["NgayChuyenKhoa1"].Text="'"+NgayChuyenKhoa1+"'";
				oRpt.DataDefinition.FormulaFields["SoNgayDieuTriChuyenKhoa1"].Text="'"+SoNgayDieuTriChuyenKhoa1+"'";
				oRpt.DataDefinition.FormulaFields["ChuyenKhoa2"].Text="'"+ChuyenKhoa2+"'";
				oRpt.DataDefinition.FormulaFields["NgayChuyenKhoa2"].Text="'"+NgayChuyenKhoa2+"'";
				oRpt.DataDefinition.FormulaFields["SoNgayDieuTriChuyenKhoa2"].Text="'"+SoNgayDieuTriChuyenKhoa2+"'";
				oRpt.DataDefinition.FormulaFields["ChuyenKhoa3"].Text="'"+ChuyenKhoa3+"'";
				oRpt.DataDefinition.FormulaFields["NgayChuyenKhoa3"].Text="'"+NgayChuyenKhoa3+"'";
				oRpt.DataDefinition.FormulaFields["SoNgayDieuTriChuyenKhoa3"].Text="'"+SoNgayDieuTriChuyenKhoa3+"'";
				oRpt.DataDefinition.FormulaFields["ChuyenVien"].Text="'"+ChuyenVien+"'";
				oRpt.DataDefinition.FormulaFields["ChuyenDen"].Text="'"+ChuyenDen+"'";
				oRpt.DataDefinition.FormulaFields["NgayRaVien"].Text="'"+NgayRaVien+"'";
				oRpt.DataDefinition.FormulaFields["TinhTrangLucRaVien"].Text="'"+TinhTrangLucRaVien+"'";
				oRpt.DataDefinition.FormulaFields["TongNgayDieuTri"].Text="'"+TongNgayDieuTri+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanNoiChuyen"].Text="'"+ChanDoanNoiChuyen+"'";
				oRpt.DataDefinition.FormulaFields["ICDChanDoanNoiChuyen"].Text="'"+ICDChanDoanNoiChuyen+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanKhoaKhamBenhCapCuu"].Text="'"+ChanDoanKhoaKhamBenhCapCuu+"'";
				oRpt.DataDefinition.FormulaFields["ICDChanDoanKhoaKhamBenhCapCuu"].Text="'"+ICDChanDoanKhoaKhamBenhCapCuu+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanVaoKhoa"].Text="'"+ChanDoanVaoKhoa+"'";
				oRpt.DataDefinition.FormulaFields["ICDChanDoanVaoKhoa"].Text="'"+ICDChanDoanVaoKhoa+"'";
				oRpt.DataDefinition.FormulaFields["CoThuThuat"].Text="'"+CoThuThuat+"'";
				oRpt.DataDefinition.FormulaFields["CoPhauThuat"].Text="'"+CoPhauThuat+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanRaVienBenhChinh"].Text="'"+ChanDoanRaVienBenhChinh+"'";
				oRpt.DataDefinition.FormulaFields["ICDChanDoanRaVienBenhChinh"].Text="'"+ICDChanDoanRaVienBenhChinh+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanRaVienBenhKemTheo"].Text="'"+ChanDoanRaVienBenhKemTheo+"'";
				oRpt.DataDefinition.FormulaFields["ICDChanDoanRaVienBenhKemTheo"].Text="'"+ICDChanDoanRaVienBenhKemTheo+"'";
				oRpt.DataDefinition.FormulaFields["CoTaiBien"].Text="'"+CoTaiBien+"'";
				oRpt.DataDefinition.FormulaFields["CoBienChung"].Text="'"+CoBienChung+"'";
				oRpt.DataDefinition.FormulaFields["KetQuaDieuTri"].Text="'"+KetQuaDieuTri+"'";
				oRpt.DataDefinition.FormulaFields["GiaiPhauBenh"].Text="'"+GiaiPhauBenh+"'";
				oRpt.DataDefinition.FormulaFields["NgayTuVong"].Text="'"+NgayTuVong+"'";
				oRpt.DataDefinition.FormulaFields["TinhTrangTuVong"].Text="'"+TinhTrangTuVong+"'";
				oRpt.DataDefinition.FormulaFields["ThoiDiemTuVong"].Text="'"+ThoiDiemTuVong+"'";
				oRpt.DataDefinition.FormulaFields["NguyenNhanTuVong"].Text="'"+NguyenNhanTuVong+"'";
				oRpt.DataDefinition.FormulaFields["ICDNguyenNhanTuVong"].Text="'"+ICDNguyenNhanTuVong+"'";
				oRpt.DataDefinition.FormulaFields["CoKhamNghiemTuThi"].Text="'"+CoKhamNghiemTuThi+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanTuThi"].Text="'"+ChanDoanTuThi+"'";
				oRpt.DataDefinition.FormulaFields["ICDChanDoanTuThi"].Text="'"+ICDChanDoanTuThi+"'";
				oRpt.DataDefinition.FormulaFields["NguyenNhanTaiBienBienChung"].Text="'"+NguyenNhanTaiBienBienChung+"'";
				oRpt.DataDefinition.FormulaFields["TongSoNgayDieuTriSauPhauThuat"].Text="'"+TongSoNgayDieuTriSauPhauThuat+"'";
				oRpt.DataDefinition.FormulaFields["TongSoLanPhauThuat"].Text="'"+TongSoLanPhauThuat+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanRaVienBenhChinhNguyenNhan"].Text="'"+ChanDoanRaVienBenhChinhNguyenNhan+"'";
				oRpt.DataDefinition.FormulaFields["ICDChanDoanRaVienBenhChinhNguyenNhan"].Text="'"+ICDChanDoanRaVienBenhChinhNguyenNhan+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanTruocPhauThuat"].Text="'"+ChanDoanTruocPhauThuat+"'";
				oRpt.DataDefinition.FormulaFields["ICDChanDoanTruocPhauThuat"].Text="'"+ICDChanDoanTruocPhauThuat+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanSauPhauThuat"].Text="'"+ChanDoanSauPhauThuat+"'";
				oRpt.DataDefinition.FormulaFields["ICDChanDoanSauPhauThuat"].Text="'"+ICDChanDoanSauPhauThuat+"'";
				oRpt.DataDefinition.FormulaFields["TinhTrangPhauThuat"].Text="'"+TinhTrangPhauThuat+"'";
				oRpt.DataDefinition.FormulaFields["TrinhDoVanHoa"].Text="'"+TrinhDoVanHoa+"'";
				oRpt.DataDefinition.FormulaFields["HoTenBo"].Text="'"+HoTenBo+"'";
				oRpt.DataDefinition.FormulaFields["NgheNghiepBo"].Text="'"+NgheNghiepBo+"'";
				oRpt.DataDefinition.FormulaFields["TrinhDoVanHoaBo"].Text="'"+TrinhDoVanHoaBo+"'";
				oRpt.DataDefinition.FormulaFields["HoTenMe"].Text="'"+HoTenMe+"'";
				oRpt.DataDefinition.FormulaFields["NgheNghiepMe"].Text="'"+NgheNghiepMe+"'";
				oRpt.DataDefinition.FormulaFields["TrinhDoVanHoaMe"].Text="'"+TrinhDoVanHoaMe+"'";
				oRpt.DataDefinition.FormulaFields["NgaySinhMe"].Text="'"+NgaySinhMe+"'";
				oRpt.DataDefinition.FormulaFields["MaNgheNghiepMe"].Text="'"+MaNgheNghiepMe+"'";
				oRpt.DataDefinition.FormulaFields["DeLanMay"].Text="'"+DeLanMay+"'";
				oRpt.DataDefinition.FormulaFields["NgaySinhBo"].Text="'"+NgaySinhBo+"'";
				oRpt.DataDefinition.FormulaFields["MaNgheNghiepBo"].Text="'"+MaNgheNghiepBo+"'";
				oRpt.DataDefinition.FormulaFields["NhomMauMe"].Text="'"+NhomMauMe+"'";
				oRpt.DataDefinition.FormulaFields["TienThai"].Text="'"+TienThai+"'";
				oRpt.DataDefinition.FormulaFields["NgayDe"].Text="'"+NgayDe+"'";
				oRpt.DataDefinition.FormulaFields["NgoiThai"].Text="'"+NgoiThai+"'";
				oRpt.DataDefinition.FormulaFields["CachThucDe"].Text="'"+CachThucDe+"'";
				oRpt.DataDefinition.FormulaFields["CoKiemSoatTuCung"].Text="'"+CoKiemSoatTuCung+"'";
				oRpt.DataDefinition.FormulaFields["KiemSoatTuCung"].Text="'"+KiemSoatTuCung+"'";
				oRpt.DataDefinition.FormulaFields["PhuongPhapPhauThuat"].Text="'"+PhuongPhapPhauThuat+"'";
				oRpt.DataDefinition.FormulaFields["LoaiThai"].Text="'"+LoaiThai+"'";
				oRpt.DataDefinition.FormulaFields["GioiTinhTre"].Text="'"+GioiTinhTre+"'";
				oRpt.DataDefinition.FormulaFields["TreConSong"].Text="'"+TreConSong+"'";
				oRpt.DataDefinition.FormulaFields["TreCoDiTat"].Text="'"+TreCoDiTat+"'";
				oRpt.DataDefinition.FormulaFields["TreDiTat"].Text="'"+TreDiTat+"'";
				oRpt.DataDefinition.FormulaFields["TreCanNang"].Text="'"+TreCanNang+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanVaoKhoaT"].Text="'"+ChanDoanVaoKhoaT+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanVaoKhoaN"].Text="'"+ChanDoanVaoKhoaN+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanVaoKhoaM"].Text="'"+ChanDoanVaoKhoaM+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanVaoKhoaGiaiDoan"].Text="'"+ChanDoanVaoKhoaGiaiDoan+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanRaVienBenhChinhT"].Text="'"+ChanDoanRaVienBenhChinhT+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanRaVienBenhChinhN"].Text="'"+ChanDoanRaVienBenhChinhN+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanRaVienBenhChinhM"].Text="'"+ChanDoanRaVienBenhChinhM+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanRaVienBenhChinhGiaiDoan"].Text="'"+ChanDoanRaVienBenhChinhGiaiDoan+"'";
				oRpt.DataDefinition.FormulaFields["Giamdoc"].Text="'"+m.Giamdoc+"'";
				Report.ReportSource=oRpt;
			}
			catch (Exception e)
			{
				MessageBox.Show("The following error was discovered: '"+e.Message+"'. It was occured in '"+e.StackTrace+"'","Report Viewer :"+ReportFile,MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}		

		private void PreviewReport()
		{
			try
			{
				oRpt=new ReportDocument();
				oRpt.Load("..//..//..//report//"+ReportFile,OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(ds);
                oRpt.DataDefinition.FormulaFields["SoYTe"].Text = "'" + m.Syte.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["BenhVien"].Text = "'" + m.Tenbv.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["TenBenhAn"].Text = "'" + msg.Replace("'", "''") + "'";
                if (ReportFile.Trim().ToLower() == "rpt_ttravien_kp.rpt")
                {
                    oRpt.DataDefinition.FormulaFields["treem"].Text = m.iTreem6tuoi.ToString();
                    foreach (CrystalDecisions.CrystalReports.Engine.Section section in oRpt.ReportDefinition.Sections)
                    {
                        // In each section we need to loop through all the reporting objects
                        foreach (CrystalDecisions.CrystalReports.Engine.ReportObject reportObject in section.ReportObjects)
                        {
                            if (reportObject.Kind == ReportObjectKind.SubreportObject)
                            {
                                SubreportObject subReport = (SubreportObject)reportObject;
                                ReportDocument subDocument = subReport.OpenSubreport(subReport.SubreportName);

                                subDocument.SetDataSource(ds);

                            }
                        }
                    }
                }
				Report.ReportSource=oRpt;
			}
			catch (Exception e)
			{
				MessageBox.Show ("The following error was discovered: '"+e.Message+"'. It was occured in '"+e.StackTrace+"'", "Report Viewer",MessageBoxButtons.OK, MessageBoxIcon.Error);				
			}
		}		

		private void Report145()
		{
			try
			{
				oRpt=new ReportDocument();
				oRpt.Load("..//..//..//report//"+ReportFile,OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(ds);
                oRpt.DataDefinition.FormulaFields["SoYTe"].Text = "'" + m.Syte.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["BenhVien"].Text = "'" + m.Tenbv.Replace("'", "''") + "'";
				oRpt.DataDefinition.FormulaFields["TenBenhAn"].Text="'"+msg+"'";
                oRpt.DataDefinition.FormulaFields["d01"].Text = "'" + d01.ToString().Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["d02"].Text = "'" + d02.ToString().Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["d03"].Text = "'" + d03.ToString().Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["d04"].Text = "'" + d04.ToString().Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["d05"].Text = "'" + d05.ToString().Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["d06"].Text = "'" + d06.ToString().Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["d07"].Text = "'" + d07.ToString().Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["d08"].Text = "'" + d08.ToString().Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["d09"].Text = "'" + d09.ToString().Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["d10"].Text = "'" + d10.ToString().Replace("'", "''") + "'";
//				oRpt.PrintOptions.PaperSize=PaperSize.PaperA4;
//				oRpt.PrintOptions.PaperOrientation=PaperOrientation.Landscape;
				Report.ReportSource=oRpt;
			}
			catch (Exception e)
			{
				MessageBox.Show ("The following error was discovered: '"+e.Message+"'. It was occured in '"+e.StackTrace+"'", "Report Viewer",MessageBoxButtons.OK, MessageBoxIcon.Error);				
			}
		}		

		private void Bia()
		{
			try
			{
				oRpt=new ReportDocument();
				oRpt.Load("..//..//..//report//"+ReportFile,OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(ds);
                oRpt.DataDefinition.FormulaFields["SoYTe"].Text = "'" + m.Syte.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["BenhVien"].Text = "'" + m.Tenbv.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["c1"].Text = "'" + c1.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["c2"].Text = "'" + c2.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["c3"].Text = "'" + c3.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["c4"].Text = "'" + c4.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["c5"].Text = "'" + c5.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["c6"].Text = "'" + c6.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["Giamdoc"].Text = "'" + m.Giamdoc.Replace("'", "''") + "'";
				Report.ReportSource=oRpt;
			}
			catch (Exception e)
			{
				MessageBox.Show ("The following error was discovered: '"+e.Message+"'. It was occured in '"+e.StackTrace+"'", "Report Viewer",MessageBoxButtons.OK, MessageBoxIcon.Error);				
			}
		}

        private void icd10()
        {
            try
            {
                oRpt = new ReportDocument();
                oRpt.Load("..//..//..//report//" + ReportFile, OpenReportMethod.OpenReportByTempCopy);
                oRpt.SetDataSource(ds);
                oRpt.DataDefinition.FormulaFields["v_syt"].Text = "'" + m.Syte.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["v_bv"].Text = "'" + m.Tenbv.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + c1.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + c2.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + c3.Replace("'", "''") + "'";
                Report.ReportSource = oRpt;
            }
            catch (Exception e)
            {
                MessageBox.Show("The following error was discovered: '" + e.Message + "'. It was occured in '" + e.StackTrace + "'", "Report Viewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		private void Bienlai()
		{
			try
			{
				oRpt=new ReportDocument();
				oRpt.Load("..//..//..//report//"+ReportFile,OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(ds);
				if (c1!="")
				{
					oRpt.DataDefinition.FormulaFields["s_nguoithu"].Text="'"+c1.Replace("'","''")+"'";
					oRpt.DataDefinition.FormulaFields["s_sovaovien"].Text="'"+c2.Replace("'","''")+"'";
				}
				//oRpt.PrintOptions.PaperSize=PaperSize.PaperA4;
				//oRpt.PrintOptions.PaperOrientation=PaperOrientation.Landscape;
				Report.ReportSource=oRpt;
			}
			catch (Exception e)
			{
				MessageBox.Show ("The following error was discovered: '"+e.Message+"'. It was occured in '"+e.StackTrace+"'", "Report Viewer",MessageBoxButtons.OK, MessageBoxIcon.Error);				
			}
		}		

		private void frmReport_Closed(object sender, System.EventArgs e)
		{
			System.Environment.CurrentDirectory=this.Tag.ToString();
		}	

		private void Baohiem()
		{
			try
			{
				string phieulinh="d_phieulanh_yc.rpt,d_phieulanh_yc_dg.rpt,d_phieulanh.rpt,d_phieulanh_dg.rpt,d_pldoc.rpt";
				oRpt=new ReportDocument();
				oRpt.Load("..//..//..//report//"+ReportFile,OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(dt);
                oRpt.DataDefinition.FormulaFields["soyte"].Text = "'" + m.Syte.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["benhvien"].Text = "'" + m.Tenbv.Replace("'", "''") + "'";
				oRpt.DataDefinition.FormulaFields["c1"].Text="'"+c1.Replace("'","''")+"'";
                oRpt.DataDefinition.FormulaFields["c2"].Text = "'" + c2.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["c3"].Text = "'" + c3.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["c4"].Text = "'" + c4.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["c5"].Text = "'" + c5.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["c6"].Text = "'" + c6.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["c7"].Text = "'" + c7.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["c8"].Text = "'" + c8.Replace("'", "''") + "'";
                oRpt.DataDefinition.FormulaFields["c9"].Text = "'" + c9.Replace("'", "''").Replace("\r\n"," ") + "'";
                oRpt.DataDefinition.FormulaFields["c10"].Text = "'" + c10.Replace("'", "''") + "'";
				oRpt.DataDefinition.FormulaFields["giamdoc"].Text="";
				oRpt.DataDefinition.FormulaFields["phutrach"].Text="";
				oRpt.DataDefinition.FormulaFields["thongke"].Text="";
				oRpt.DataDefinition.FormulaFields["ketoan"].Text="";
				oRpt.DataDefinition.FormulaFields["thukho"].Text="";
				if (phieulinh.IndexOf(ReportFile+",")!=-1)
				{
					oRpt.DataDefinition.FormulaFields["l_soluong"].Text=i_soluong_le.ToString();
					oRpt.DataDefinition.FormulaFields["l_dongia"].Text=i_dongia_le.ToString();
					oRpt.DataDefinition.FormulaFields["l_thanhtien"].Text=i_thanhtien_le.ToString();
				}
				Report.ReportSource=oRpt;
			}
			catch (Exception e)
			{
				MessageBox.Show ("The following error was discovered: '"+e.Message+"'. It was occured in '"+e.StackTrace+"'", "Report Viewer",MessageBoxButtons.OK, MessageBoxIcon.Error);				
			}
		}

        private void butKetthuc_Click(object sender, System.EventArgs e)
        {
            bPrinter = false;

            if (Report != null)
            {
                oRpt.Close();
                oRpt.Dispose();
                Report.Dispose();
            }
            try
            {
                m.close(); this.Close();
            }
            catch
            {
            }
        }

		private void butIn_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			bPrinter=true;
			try
			{
				oRpt.PrintToPrinter(Convert.ToInt16(banin.Value),false,Convert.ToInt16(tu.Value),Convert.ToInt16(den.Value));
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
			Cursor=Cursors.Default;
            if (Report != null)
            {
                oRpt.Close();
                oRpt.Dispose();
                Report.Dispose();
            }
			m.close();this.Close();
		}

		private void frmReport_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
                case Keys.F5: butPdf_Click(sender, e); break;
				case Keys.F9: if (butIn.Enabled) butIn_Click(sender,e);break;
				case Keys.F7: butExcel_Click(sender,e);break;
				case Keys.F10: butKetthuc_Click(sender,e);break;
			}
		}

		private void banin_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butExcel_Click(object sender, System.EventArgs e)
		{
			d.check_process_Excel();
			string tenfile=(b_baohiem)?d.Export_Excel(dt,ReportFile.Substring(0,ReportFile.Length-4)):d.Export_Excel(ds,ReportFile.Substring(0,ReportFile.Length-4));
			oxl=new Excel.Application();
            owb = (Excel._Workbook)(oxl.Workbooks.Open(tenfile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
			osheet=(Excel._Worksheet)owb.ActiveSheet;
			oxl.ActiveWindow.DisplayGridlines=true;
			oxl.ActiveWindow.DisplayZeros=false;
            try
            {
                osheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                osheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;
                osheet.PageSetup.LeftMargin = 20;
                osheet.PageSetup.RightMargin = 20;
                osheet.PageSetup.TopMargin = 30;
                osheet.PageSetup.CenterFooter = "Trang : &P/&N";
            }
            catch { }			
			oxl.Visible=true;
		}

        private void butPdf_Click(object sender, EventArgs e)
        {
            string tenfile = ReportFile.ToLower().Replace(".rpt","");
            tenfile=ExportPath + tenfile + ".pdf";
            crDiskFileDestinationOptions = new DiskFileDestinationOptions();
            crExportOptions = oRpt.ExportOptions;
            crDiskFileDestinationOptions.DiskFileName = tenfile;
            crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
            crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            oRpt.Export();
            try
            {
                string filerun = "AcroRd32.exe", arg = tenfile;
                if (System.IO.File.Exists(arg))
                {
                    run f = new run(filerun, arg, true);
                    f.Launch();
                }
            }
            catch
            {
                MessageBox.Show("Tập tin :" + tenfile);
            }
        }
	}
}