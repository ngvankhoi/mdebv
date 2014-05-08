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

namespace dllVuKeHoach
{
	/// <summary>
	/// Summary description for Freport.
	/// </summary>
	public class frmReport : System.Windows.Forms.Form
	{
		Language lan = new Language();
		ReportDocument oRpt;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		public bool bPrinter=false, bdone_trv=true;
		private LibMedi.AccessData m=new LibMedi.AccessData();	
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private string msg,ReportFile;
		private DataSet ds=new DataSet();
		private System.Data.DataTable dt=new System.Data.DataTable();
		private CrystalDecisions.Windows.Forms.CrystalReportViewer Report;
		private int d01,d02,d03,d04,d05,d06,d07,d08,d09,d10;
		private int i_nhom=1,i_soluong_le=0,i_dongia_le=0,i_thanhtien_le=0;
		private string c1,c2,c3,c4,c5,c6,c7,c8,c9,c10;
		private bool b_145=false,b_benhan=false,b_benhan1=false,b_bienlai=false,b_baohiem=false,bDoc=false,bia=false;
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
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.NumericUpDown den;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown tu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butExcel;
		private System.Windows.Forms.Button butPdf;
		private string ExportPath;
		ExportOptions crExportOptions;
		DiskFileDestinationOptions crDiskFileDestinationOptions;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmReport(LibMedi.AccessData acc,System.Data.DataTable ta,string report,string s1,string s2,string s3,string s4,string s5,string s6,string s7,string s8,string s9,string s10)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;dt=ta;c1=s1;c2=s2;
			c3=s3;c4=s4;c5=s5;c6=s6;
			c7=s7;c8=s8;c9=s9;c10=s10;
			b_baohiem=true;
			ReportFile=report;
			this.Text=report;
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

		public frmReport(LibMedi.AccessData acc,DataSet dset,string mMsg,string report,bool doc,int done)
		{
			InitializeComponent();
			m=acc;
			ds=dset;
			msg=mMsg;
			ReportFile=report;
			bDoc=doc;
			this.Text=report;
			Report.ShowPrintButton=done==0;
			butIn.Enabled=done==0;
			Report.ShowExportButton=done==0;
			butPdf.Enabled=done==0;
			bdone_trv=done==0;
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

		public frmReport(LibMedi.AccessData acc,DataSet dset,string mMsg,string report,bool doc, bool bShowprint)
		{
			InitializeComponent();
			m=acc;
			ds=dset;
			msg=mMsg;
			ReportFile=report;
			bDoc=doc;
			Report.ShowPrintButton=bShowprint;
			Report.ShowExportButton=bShowprint;
			bdone_trv=bShowprint;
			this.Text=report;
		}

		public frmReport(LibMedi.AccessData acc,DataSet dset,string mMsg,string report,int i01,int i02,int i03,int i04,int i05,int i06,int i07,int i08,int i09,int i10)
		{
			InitializeComponent();
			m=acc;
			ds=dset;
			msg=mMsg;
			d01=i01;
			d02=i02;
			d03=i03;
			d04=i04;
			d05=i05;
			d06=i06;
			d07=i07;
			d08=i08;
			d09=i09;
			d10=i10;
			b_145=true;
			ReportFile=report;
			this.Text=report;
		}

		public frmReport(LibMedi.AccessData acc,DataSet dset,string report,string s1,string s2,string s3,string s4,string s5,string s6)
		{
			InitializeComponent();
			m=acc;
			ds=dset;
			c1=s1;
			c2=s2;
			c3=s3;
			c4=s4;
			c5=s5;
			c6=s6;
			bia=true;
			ReportFile=report;
			this.Text=report;
		}

		public frmReport(LibMedi.AccessData acc,DataSet dset,string report,string mabenhan,string khoa,string giuong,string soluutru,string mayt,string hoten,string ngaysinh,string tuoi,string gioitinh,string tennghenghiep,string manghenghiep,string tendantoc,string madantoc,string tenngoaikieu,string mangoaikieu,
			string sonha,string thonpho,string xaphuong,string tenquanhuyen,string maquanhuyen,string tentinhthanh,string matinhthanh,string cholam,string madoituong,string ngaybhyt,string sothebhyt,string quanhe,string dienthoai,string thoigianbibong,string ngayvaovien,string tructiepvao,string noigioithieu,string lanvaovien,
			string vaokhoa,
			string ngayvaokhoa,string songaydieutrivaokhoa,string chuyenkhoa1,string ngaychuyenkhoa1,string songaydieutrichuyenkhoa1,string chuyenkhoa2,string ngaychuyenkhoa2,string songaydieutrichuyenkhoa2,string chuyenkhoa3,string ngaychuyenkhoa3,string songaydieutrichuyenkhoa3,string chuyenvien,
			string chuyenden,string ngayravien,string tinhtranglucravien,string tongngaydieutri,string chandoannoichuyen,
			string icdchandoannoichuyen,string chandoankhoakhambenhcapcuu,string icdchandoankhoakhambenhcapcuu,string chandoanvaokhoa,string icdchandoanvaokhoa,string cothuthuat,string cophauthuat,string chandoanravienbenhchinh,
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
		//ThanhCuong
		public frmReport(LibMedi.AccessData acc,DataSet dset,string report,string khoa,string giuong,string mayt,string hoten,string ngaysinh,string tuoi,string gioitinh,string tennghenghiep,string manghenghiep,string tendantoc,string madantoc,string tenngoaikieu,string mangoaikieu,
			string sonha,string thonpho,string xaphuong,string tenquanhuyen,string maquanhuyen,string tentinhthanh,string matinhthanh,string cholam,string madoituong,string ngaybhyt,string sothebhyt,string quanhe,string dienthoai,string ngayvaovien,string tructiepvao,string noigioithieu,string lanvaovien,
			string vaokhoa,string chandoannoichuyen,string icdchandoannoichuyen,string chandoankhoakhambenhcapcuu,string icdchandoankhoakhambenhcapcuu,string cothuthuat,string cophauthuat,string chandoanravienbenhchinh,
			string icdchandoanravienbenhchinh,string chandoanravienbenhkemtheo,string icdchandoanravienbenhkemtheo,string cotaibien,string cobienchung,string ketquadieutri,string giaiphaubenh,string ngaytuvong,string cokiemsoattucung,string chandoanravienbenhchinhgiaidoan,bool aa)
		{
			InitializeComponent();
			m=acc;
			ds=dset;
			ReportFile=report;
			b_benhan=true;
			b_benhan1=aa;
			Khoa=khoa;Giuong=giuong;MaYT=mayt;HoTen=hoten;NgaySinh=ngaysinh;Tuoi=tuoi;GioiTinh=gioitinh;TenNgheNghiep=tennghenghiep;MaNgheNghiep=manghenghiep;TenDanToc=tendantoc;MaDanToc=madantoc;TenNgoaiKieu=tenngoaikieu;MaNgoaiKieu=mangoaikieu;
			SoNha=sonha;ThonPho=thonpho;XaPhuong=xaphuong;TenQuanHuyen=tenquanhuyen;MaQuanHuyen=maquanhuyen;TenTinhThanh=tentinhthanh;MaTinhThanh=matinhthanh;ChoLam=cholam;MaDoiTuong=madoituong;NgayBHYT=ngaybhyt;SoTheBHYT=sothebhyt;QuanHe=quanhe;DienThoai=dienthoai;NgayVaoVien=ngayvaovien;TrucTiepVao=tructiepvao;
			NoiGioiThieu=noigioithieu;LanVaoVien=lanvaovien;VaoKhoa=vaokhoa;ChanDoanNoiChuyen=chandoannoichuyen;ICDChanDoanNoiChuyen=icdchandoannoichuyen;ChanDoanKhoaKhamBenhCapCuu=chandoankhoakhambenhcapcuu;ICDChanDoanKhoaKhamBenhCapCuu=icdchandoankhoakhambenhcapcuu;
			CoThuThuat=cothuthuat;CoPhauThuat=cophauthuat;ChanDoanRaVienBenhChinh=chandoanravienbenhchinh;ICDChanDoanRaVienBenhChinh=icdchandoanravienbenhchinh;ChanDoanRaVienBenhKemTheo=chandoanravienbenhkemtheo;ICDChanDoanRaVienBenhKemTheo=icdchandoanravienbenhkemtheo;CoTaiBien=cotaibien;CoBienChung=cobienchung;KetQuaDieuTri=ketquadieutri;GiaiPhauBenh=giaiphaubenh;NgayTuVong=ngaytuvong;
			CoKiemSoatTuCung=cokiemsoattucung;ChanDoanRaVienBenhChinhGiaiDoan=chandoanravienbenhchinhgiaidoan;
			this.Text=report;
		}
		//
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmReport));
			this.Report = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.banin = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.butKetthuc = new System.Windows.Forms.Button();
			this.butIn = new System.Windows.Forms.Button();
			this.den = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.tu = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.butExcel = new System.Windows.Forms.Button();
			this.butPdf = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.banin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
			this.SuspendLayout();
			// 
			// Report
			// 
			this.Report.ActiveViewIndex = -1;
			this.Report.DisplayGroupTree = false;
			this.Report.Location = new System.Drawing.Point(0, 5);
			this.Report.Name = "Report";
			this.Report.ReportSource = null;
			this.Report.Size = new System.Drawing.Size(305, 100);
			this.Report.TabIndex = 9;
			// 
			// banin
			// 
			this.banin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.banin.Location = new System.Drawing.Point(374, 5);
			this.banin.Minimum = new System.Decimal(new int[] {
																  1,
																  0,
																  0,
																  0});
			this.banin.Name = "banin";
			this.banin.Size = new System.Drawing.Size(34, 21);
			this.banin.TabIndex = 1;
			this.banin.Value = new System.Decimal(new int[] {
																1,
																0,
																0,
																0});
			this.banin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.banin_KeyDown);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(306, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "&Số bản in :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// butKetthuc
			// 
			this.butKetthuc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.butKetthuc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(755, 4);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(72, 23);
			this.butKetthuc.TabIndex = 8;
			this.butKetthuc.Text = "Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// butIn
			// 
			this.butIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butIn.Image = ((System.Drawing.Bitmap)(resources.GetObject("butIn.Image")));
			this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butIn.Location = new System.Drawing.Point(581, 4);
			this.butIn.Name = "butIn";
			this.butIn.Size = new System.Drawing.Size(51, 23);
			this.butIn.TabIndex = 6;
			this.butIn.Text = "      In";
			this.butIn.Click += new System.EventHandler(this.butIn_Click);
			// 
			// den
			// 
			this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.den.Location = new System.Drawing.Point(535, 5);
			this.den.Name = "den";
			this.den.Size = new System.Drawing.Size(44, 21);
			this.den.TabIndex = 5;
			this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.banin_KeyDown);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(505, 5);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "đến :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tu
			// 
			this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tu.Location = new System.Drawing.Point(458, 5);
			this.tu.Name = "tu";
			this.tu.Size = new System.Drawing.Size(45, 21);
			this.tu.TabIndex = 3;
			this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.banin_KeyDown);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(403, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Từ trang :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// butExcel
			// 
			this.butExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butExcel.Image = ((System.Drawing.Bitmap)(resources.GetObject("butExcel.Image")));
			this.butExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butExcel.Location = new System.Drawing.Point(635, 4);
			this.butExcel.Name = "butExcel";
			this.butExcel.Size = new System.Drawing.Size(60, 23);
			this.butExcel.TabIndex = 7;
			this.butExcel.Text = "      Excel";
			this.butExcel.Click += new System.EventHandler(this.butExcel_Click);
			// 
			// butPdf
			// 
			this.butPdf.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butPdf.Image = ((System.Drawing.Bitmap)(resources.GetObject("butPdf.Image")));
			this.butPdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butPdf.Location = new System.Drawing.Point(697, 4);
			this.butPdf.Name = "butPdf";
			this.butPdf.Size = new System.Drawing.Size(55, 23);
			this.butPdf.TabIndex = 10;
			this.butPdf.Text = "      PDF";
			this.butPdf.Click += new System.EventHandler(this.butPdf_Click);
			// 
			// frmReport
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.butKetthuc;
			this.ClientSize = new System.Drawing.Size(1016, 713);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.butPdf,
																		  this.butExcel,
																		  this.den,
																		  this.tu,
																		  this.banin,
																		  this.label3,
																		  this.label2,
																		  this.label1,
																		  this.butKetthuc,
																		  this.butIn,
																		  this.Report});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "frmReport";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Medisoft";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReport_KeyDown);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmReport_Closing);
			this.Load += new System.EventHandler(this.frmReport_Load);
			this.Closed += new System.EventHandler(this.frmReport_Closed);
			((System.ComponentModel.ISupportInitialize)(this.banin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmReport_Load(object sender, System.EventArgs e)
		{
			this.Report.Size = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width,Screen.PrimaryScreen.WorkingArea.Height);
			this.Size= new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width,Screen.PrimaryScreen.WorkingArea.Height);
			GC.Collect();
			i_soluong_le=d.d_soluong_le(i_nhom);
			i_dongia_le=d.d_dongia_le(i_nhom);
			i_thanhtien_le=d.d_thanhtien_le(i_nhom);
			this.Tag=System.Environment.CurrentDirectory.ToString();
			string dir = System.IO.Directory.GetCurrentDirectory();
			Report.ShowPrintButton=bdone_trv && (m.bHienthi_BieutuongMayin || ReportFile.IndexOf("d_phieulanh")<0);
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
			if (b_baohiem) Baohiem();
			else if (b_bienlai) Bienlai();
			else if (ds==null || bia) Bia();
			else if (b_145) Report145();
			else if (b_benhan) 
			{
				if(b_benhan1) Benhan1();//ThanhCuong-10062011
				else Benhan();
			}
			else PreviewReport();
		}

		private void Benhan()
		{
			try
			{
				oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\"+ReportFile+".rpt",OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(ds);
				oRpt.DataDefinition.FormulaFields["SoYTe"].Text="'"+m.Syte.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["BenhVien"].Text="'"+m.Tenbv.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["MaBenhAn"].Text="'"+MaBenhAn.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["Khoa"].Text="'"+Khoa.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["Giuong"].Text="'"+Giuong.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["SoLuuTru"].Text="'"+SoLuuTru.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["MaYT"].Text="'"+MaYT.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["HoTen"].Text="'"+HoTen.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NgaySinh"].Text="'"+NgaySinh.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["Tuoi"].Text="'"+Tuoi.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["GioiTinh"].Text="'"+GioiTinh.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TenNgheNghiep"].Text="'"+TenNgheNghiep.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["MaNgheNghiep"].Text="'"+MaNgheNghiep.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TenDanToc"].Text="'"+TenDanToc.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["MaDanToc"].Text="'"+MaDanToc.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TenNgoaiKieu"].Text="'"+TenNgoaiKieu.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["MaNgoaiKieu"].Text="'"+MaNgoaiKieu.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["SoNha"].Text="'"+SoNha.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ThonPho"].Text="'"+ThonPho.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["XaPhuong"].Text="'"+XaPhuong.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TenQuanHuyen"].Text="'"+TenQuanHuyen.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["MaQuanHuyen"].Text="'"+MaQuanHuyen.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TenTinhThanh"].Text="'"+TenTinhThanh.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["MaTinhThanh"].Text="'"+MaTinhThanh.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChoLam"].Text="'"+ChoLam.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["MaDoiTuong"].Text="'"+MaDoiTuong.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NgayBHYT"].Text="'"+NgayBHYT.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["SoTheBHYT"].Text="'"+SoTheBHYT.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["QuanHe"].Text="'"+QuanHe.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["DienThoai"].Text="'"+DienThoai.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ThoiGianBiBong"].Text="'"+ThoiGianBiBong.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NgayVaoVien"].Text="'"+NgayVaoVien.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TrucTiepVao"].Text="'"+TrucTiepVao.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NoiGioiThieu"].Text="'"+NoiGioiThieu.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["LanVaoVien"].Text="'"+LanVaoVien.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["VaoKhoa"].Text="'"+VaoKhoa.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NgayVaoKhoa"].Text="'"+NgayVaoKhoa.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["SoNgayDieuTriVaoKhoa"].Text="'"+SoNgayDieuTriVaoKhoa.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChuyenKhoa1"].Text="'"+ChuyenKhoa1.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NgayChuyenKhoa1"].Text="'"+NgayChuyenKhoa1.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["SoNgayDieuTriChuyenKhoa1"].Text="'"+SoNgayDieuTriChuyenKhoa1.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChuyenKhoa2"].Text="'"+ChuyenKhoa2.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NgayChuyenKhoa2"].Text="'"+NgayChuyenKhoa2+"'";
				oRpt.DataDefinition.FormulaFields["SoNgayDieuTriChuyenKhoa2"].Text="'"+SoNgayDieuTriChuyenKhoa2.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChuyenKhoa3"].Text="'"+ChuyenKhoa3.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NgayChuyenKhoa3"].Text="'"+NgayChuyenKhoa3.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["SoNgayDieuTriChuyenKhoa3"].Text="'"+SoNgayDieuTriChuyenKhoa3.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChuyenVien"].Text="'"+ChuyenVien.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChuyenDen"].Text="'"+ChuyenDen.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NgayRaVien"].Text="'"+NgayRaVien.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TinhTrangLucRaVien"].Text="'"+TinhTrangLucRaVien.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TongNgayDieuTri"].Text="'"+TongNgayDieuTri.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanNoiChuyen"].Text="'"+ChanDoanNoiChuyen.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ICDChanDoanNoiChuyen"].Text="'"+ICDChanDoanNoiChuyen+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanKhoaKhamBenhCapCuu"].Text="'"+ChanDoanKhoaKhamBenhCapCuu.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ICDChanDoanKhoaKhamBenhCapCuu"].Text="'"+ICDChanDoanKhoaKhamBenhCapCuu.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanVaoKhoa"].Text="'"+ChanDoanVaoKhoa.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ICDChanDoanVaoKhoa"].Text="'"+ICDChanDoanVaoKhoa.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["CoThuThuat"].Text="'"+CoThuThuat.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["CoPhauThuat"].Text="'"+CoPhauThuat.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanRaVienBenhChinh"].Text="'"+ChanDoanRaVienBenhChinh.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ICDChanDoanRaVienBenhChinh"].Text="'"+ICDChanDoanRaVienBenhChinh.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanRaVienBenhKemTheo"].Text="'"+ChanDoanRaVienBenhKemTheo.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ICDChanDoanRaVienBenhKemTheo"].Text="'"+ICDChanDoanRaVienBenhKemTheo.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["CoTaiBien"].Text="'"+CoTaiBien.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["CoBienChung"].Text="'"+CoBienChung.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["KetQuaDieuTri"].Text="'"+KetQuaDieuTri.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["GiaiPhauBenh"].Text="'"+GiaiPhauBenh.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NgayTuVong"].Text="'"+NgayTuVong.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TinhTrangTuVong"].Text="'"+TinhTrangTuVong.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ThoiDiemTuVong"].Text="'"+ThoiDiemTuVong.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NguyenNhanTuVong"].Text="'"+NguyenNhanTuVong.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ICDNguyenNhanTuVong"].Text="'"+ICDNguyenNhanTuVong.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["CoKhamNghiemTuThi"].Text="'"+CoKhamNghiemTuThi.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanTuThi"].Text="'"+ChanDoanTuThi.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ICDChanDoanTuThi"].Text="'"+ICDChanDoanTuThi.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NguyenNhanTaiBienBienChung"].Text="'"+NguyenNhanTaiBienBienChung.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TongSoNgayDieuTriSauPhauThuat"].Text="'"+TongSoNgayDieuTriSauPhauThuat.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TongSoLanPhauThuat"].Text="'"+TongSoLanPhauThuat.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanRaVienBenhChinhNguyenNhan"].Text="'"+ChanDoanRaVienBenhChinhNguyenNhan.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ICDChanDoanRaVienBenhChinhNguyenNhan"].Text="'"+ICDChanDoanRaVienBenhChinhNguyenNhan.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanTruocPhauThuat"].Text="'"+ChanDoanTruocPhauThuat.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ICDChanDoanTruocPhauThuat"].Text="'"+ICDChanDoanTruocPhauThuat.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanSauPhauThuat"].Text="'"+ChanDoanSauPhauThuat.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ICDChanDoanSauPhauThuat"].Text="'"+ICDChanDoanSauPhauThuat.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TinhTrangPhauThuat"].Text="'"+TinhTrangPhauThuat.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TrinhDoVanHoa"].Text="'"+TrinhDoVanHoa.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["HoTenBo"].Text="'"+HoTenBo.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NgheNghiepBo"].Text="'"+NgheNghiepBo.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TrinhDoVanHoaBo"].Text="'"+TrinhDoVanHoaBo.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["HoTenMe"].Text="'"+HoTenMe.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NgheNghiepMe"].Text="'"+NgheNghiepMe.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TrinhDoVanHoaMe"].Text="'"+TrinhDoVanHoaMe.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NgaySinhMe"].Text="'"+NgaySinhMe.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["MaNgheNghiepMe"].Text="'"+MaNgheNghiepMe.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["DeLanMay"].Text="'"+DeLanMay.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NgaySinhBo"].Text="'"+NgaySinhBo.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["MaNgheNghiepBo"].Text="'"+MaNgheNghiepBo.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NhomMauMe"].Text="'"+NhomMauMe.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TienThai"].Text="'"+TienThai.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NgayDe"].Text="'"+NgayDe.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NgoiThai"].Text="'"+NgoiThai.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["CachThucDe"].Text="'"+CachThucDe.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["CoKiemSoatTuCung"].Text="'"+CoKiemSoatTuCung.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["KiemSoatTuCung"].Text="'"+KiemSoatTuCung.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["PhuongPhapPhauThuat"].Text="'"+PhuongPhapPhauThuat.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["LoaiThai"].Text="'"+LoaiThai.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["GioiTinhTre"].Text="'"+GioiTinhTre.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TreConSong"].Text="'"+TreConSong.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TreCoDiTat"].Text="'"+TreCoDiTat.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TreDiTat"].Text="'"+TreDiTat.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TreCanNang"].Text="'"+TreCanNang.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanVaoKhoaT"].Text="'"+ChanDoanVaoKhoaT.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanVaoKhoaN"].Text="'"+ChanDoanVaoKhoaN.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanVaoKhoaM"].Text="'"+ChanDoanVaoKhoaM.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanVaoKhoaGiaiDoan"].Text="'"+ChanDoanVaoKhoaGiaiDoan.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanRaVienBenhChinhT"].Text="'"+ChanDoanRaVienBenhChinhT.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanRaVienBenhChinhN"].Text="'"+ChanDoanRaVienBenhChinhN.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanRaVienBenhChinhM"].Text="'"+ChanDoanRaVienBenhChinhM.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanRaVienBenhChinhGiaiDoan"].Text="'"+ChanDoanRaVienBenhChinhGiaiDoan.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["Giamdoc"].Text="'"+m.Giamdoc.Trim().Replace("'","''")+"'";
				Report.ReportSource=oRpt;

			}
			catch (Exception e)
			{
				MessageBox.Show("The following error was discovered: '"+e.Message+"'. It was occured in '"+e.StackTrace+"'","Report Viewer :"+ReportFile,MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}		

		//ThanhCuong-10062011
		private void Benhan1()
		{
			try
			{
				oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\"+ReportFile+".rpt",OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(ds);
				oRpt.DataDefinition.FormulaFields["SoYTe"].Text="'"+m.Syte.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["BenhVien"].Text="'"+m.Tenbv.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["Khoa"].Text="'"+Khoa.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["Giuong"].Text="'"+Giuong.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["MaYT"].Text="'"+MaYT.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["HoTen"].Text="'"+HoTen.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NgaySinh"].Text="'"+NgaySinh.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["Tuoi"].Text="'"+Tuoi.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["GioiTinh"].Text="'"+GioiTinh.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TenNgheNghiep"].Text="'"+TenNgheNghiep.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["MaNgheNghiep"].Text="'"+MaNgheNghiep.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TenDanToc"].Text="'"+TenDanToc.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["MaDanToc"].Text="'"+MaDanToc.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TenNgoaiKieu"].Text="'"+TenNgoaiKieu.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["MaNgoaiKieu"].Text="'"+MaNgoaiKieu.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["SoNha"].Text="'"+SoNha.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ThonPho"].Text="'"+ThonPho.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["XaPhuong"].Text="'"+XaPhuong.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TenQuanHuyen"].Text="'"+TenQuanHuyen.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["MaQuanHuyen"].Text="'"+MaQuanHuyen.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TenTinhThanh"].Text="'"+TenTinhThanh.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["MaTinhThanh"].Text="'"+MaTinhThanh.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChoLam"].Text="'"+ChoLam.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["MaDoiTuong"].Text="'"+MaDoiTuong.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NgayBHYT"].Text="'"+NgayBHYT.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["SoTheBHYT"].Text="'"+SoTheBHYT.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["QuanHe"].Text="'"+QuanHe.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["DienThoai"].Text="'"+DienThoai.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NgayVaoVien"].Text="'"+NgayVaoVien.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TrucTiepVao"].Text="'"+TrucTiepVao.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NoiGioiThieu"].Text="'"+NoiGioiThieu.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["LanVaoVien"].Text="'"+LanVaoVien.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["VaoKhoa"].Text="'"+VaoKhoa.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanNoiChuyen"].Text="'"+ChanDoanNoiChuyen.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ICDChanDoanNoiChuyen"].Text="'"+ICDChanDoanNoiChuyen+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanKhoaKhamBenhCapCuu"].Text="'"+ChanDoanKhoaKhamBenhCapCuu.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ICDChanDoanKhoaKhamBenhCapCuu"].Text="'"+ICDChanDoanKhoaKhamBenhCapCuu.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["CoThuThuat"].Text="'"+CoThuThuat.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["CoPhauThuat"].Text="'"+CoPhauThuat.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanRaVienBenhChinh"].Text="'"+ChanDoanRaVienBenhChinh.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ICDChanDoanRaVienBenhChinh"].Text="'"+ICDChanDoanRaVienBenhChinh.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanRaVienBenhKemTheo"].Text="'"+ChanDoanRaVienBenhKemTheo.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ICDChanDoanRaVienBenhKemTheo"].Text="'"+ICDChanDoanRaVienBenhKemTheo.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["CoTaiBien"].Text="'"+CoTaiBien.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["CoBienChung"].Text="'"+CoBienChung.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["KetQuaDieuTri"].Text="'"+KetQuaDieuTri.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["GiaiPhauBenh"].Text="'"+GiaiPhauBenh.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["NgayTuVong"].Text="'"+NgayTuVong.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["CoKiemSoatTuCung"].Text="'"+CoKiemSoatTuCung.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["ChanDoanRaVienBenhChinhGiaiDoan"].Text="'"+ChanDoanRaVienBenhChinhGiaiDoan.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["Giamdoc"].Text="'"+m.Giamdoc.Trim().Replace("'","''")+"'";
				Report.ReportSource=oRpt;

			}
			catch (Exception e)
			{
				MessageBox.Show("The following error was discovered: '"+e.Message+"'. It was occured in '"+e.StackTrace+"'","Report Viewer :"+ReportFile,MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}		

		//
		private void PreviewReport()
		{
			try
			{
				oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\"+ReportFile,OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(ds);
				oRpt.DataDefinition.FormulaFields["SoYTe"].Text="'"+m.Syte.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["BenhVien"].Text="'"+m.Tenbv.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TenBenhAn"].Text="'"+msg.Trim().Replace("'","''")+"'";
				if (ReportFile.Trim().ToLower()=="rpt_ttravien_kp.rpt") oRpt.DataDefinition.FormulaFields["treem"].Text=m.iTreem6tuoi.ToString();
//				oRpt.PrintOptions.PaperSize=PaperSize.PaperA4;
//				if (bDoc) oRpt.PrintOptions.PaperOrientation=PaperOrientation.Portrait;
//				else oRpt.PrintOptions.PaperOrientation=PaperOrientation.Landscape;
				//
				try
				{
					if(ReportFile.ToLower().IndexOf("d_donthuoc")==0)
					{
						foreach (CrystalDecisions.CrystalReports.Engine.Section section in oRpt.ReportDefinition.Sections)
						{
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
				}
				catch{}
				//
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
				oRpt.Load("..\\..\\..\\report\\"+ReportFile,OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(ds);
				oRpt.DataDefinition.FormulaFields["SoYTe"].Text="'"+m.Syte.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["BenhVien"].Text="'"+m.Tenbv.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["TenBenhAn"].Text="'"+msg.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["d01"].Text="'"+d01.ToString().Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["d02"].Text="'"+d02.ToString().Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["d03"].Text="'"+d03.ToString().Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["d04"].Text="'"+d04.ToString().Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["d05"].Text="'"+d05.ToString().Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["d06"].Text="'"+d06.ToString().Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["d07"].Text="'"+d07.ToString().Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["d08"].Text="'"+d08.ToString().Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["d09"].Text="'"+d09.ToString().Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["d10"].Text="'"+d10.ToString().Trim().Replace("'","''")+"'";
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
				oRpt.Load("..\\..\\..\\report\\"+ReportFile,OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(ds);
				oRpt.DataDefinition.FormulaFields["c1"].Text="'"+c1.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["c2"].Text="'"+c2.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["c3"].Text="'"+c3.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["c4"].Text="'"+c4.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["c5"].Text="'"+c5.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["c6"].Text="'"+c6.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["Giamdoc"].Text="'"+m.Giamdoc.Trim().Replace("'","''")+"'";
//				oRpt.PrintOptions.PaperSize=PaperSize.PaperA4;
//				oRpt.PrintOptions.PaperOrientation=PaperOrientation.Landscape;
				Report.ReportSource=oRpt;
			}
			catch (Exception e)
			{
				MessageBox.Show ("The following error was discovered: '"+e.Message+"'. It was occured in '"+e.StackTrace+"'", "Report Viewer",MessageBoxButtons.OK, MessageBoxIcon.Error);				
			}
		}

		private void Bienlai()
		{
			try
			{
				oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\"+ReportFile,OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(ds);
				if (c1!="")
				{
					oRpt.DataDefinition.FormulaFields["s_nguoithu"].Text="'"+c1.Trim().Replace("'","''")+"'";
					oRpt.DataDefinition.FormulaFields["s_sovaovien"].Text="'"+c2.Trim().Replace("'","''")+"'";
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
				string phieulinh="d_phieulanh_yc.rpt,d_phieulanh_yc_dg.rpt,d_phieulanh.rpt,d_phieulanh_dg.rpt,d_pldoc.rpt,d_cstt_khoa.rpt";
				oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\"+ReportFile,OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(dt);
				oRpt.DataDefinition.FormulaFields["soyte"].Text="'"+m.Syte.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["benhvien"].Text="'"+m.Tenbv.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["c1"].Text="'"+c1.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["c2"].Text="'"+c2.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["c3"].Text="'"+c3.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["c4"].Text="'"+c4.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["c5"].Text="'"+c5.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["c6"].Text="'"+c6.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["c7"].Text="'"+c7.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["c8"].Text="'"+c8.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["c9"].Text="'"+c9.Trim().Replace("'","''")+"'";
				oRpt.DataDefinition.FormulaFields["c10"].Text="'"+c10.Trim().Replace("'","''")+"'";
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
				try
				{
					if(ReportFile.ToLower().IndexOf("d_donthuoc")==0)
					{
						foreach (CrystalDecisions.CrystalReports.Engine.Section section in oRpt.ReportDefinition.Sections)
						{
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
				}
				catch{}
				Report.ReportSource=oRpt;
			}
			catch (Exception e)
			{
				MessageBox.Show ("The following error was discovered: '"+e.Message+"'. It was occured in '"+e.StackTrace+"'", "Report Viewer",MessageBoxButtons.OK, MessageBoxIcon.Error);				
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			bPrinter=false;
			System.GC.Collect();
			this.Close();
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			bPrinter=true;
			try
			{
				oRpt.PrintToPrinter(Convert.ToInt16(banin.Value),false,Convert.ToInt16(tu.Value),Convert.ToInt16(den.Value));
				oRpt.Close(); oRpt.Dispose();
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
			Cursor=Cursors.Default;
			System.GC.Collect();
			this.Close();
		}

		private void frmReport_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F5: butPdf_Click(sender, e); break;
				case Keys.F9: if(butIn.Enabled) butIn_Click(sender,e);break;
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
			owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
			osheet=(Excel._Worksheet)owb.ActiveSheet;
			oxl.ActiveWindow.DisplayGridlines=true;
			oxl.ActiveWindow.DisplayZeros=false;
			osheet.PageSetup.Orientation=XlPageOrientation.xlLandscape;
			osheet.PageSetup.PaperSize=XlPaperSize.xlPaperA4;
			osheet.PageSetup.LeftMargin=20;
			osheet.PageSetup.RightMargin=20;
			osheet.PageSetup.TopMargin=30;
			osheet.PageSetup.CenterFooter="Trang : &P/&N";
			oxl.Visible=true;
		}

		private void butPdf_Click(object sender, System.EventArgs e)
		{
			string tenfile = ReportFile.ToLower().Replace(".rpt", "");
			tenfile = ExportPath + tenfile + ".pdf";
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

		private void frmReport_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			oRpt.Dispose();
			System.GC.Collect();
		}
	}
}