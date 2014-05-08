using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Drawing.Printing;
using System.Data;
using System.Xml;
using LibVP;

namespace Vienphi
{
	public class frmPrint : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		public bool m_bienlainoitru_inchitiet = false;
		private LibVP.AccessData m_v;
		

		private string m_userid="";
		private string m_tendangnhap="";

		private string m_sql="";
		private DataSet m_ds=new DataSet();

		private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
		private System.ComponentModel.Container components = null;
		
		public frmPrint(LibVP.AccessData v_v)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
			m_v = v_v;
			m_userid = "";
			
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="v_userid">dlogin.id.ToString()</param>
		public frmPrint(string v_userid, LibVP.AccessData v_v)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m_v = v_v;
			m_bienlainoitru_inchitiet=m_v.s_bienlainoitru_inchitiet;
			m_userid = v_userid;
			
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrint));
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.DisplayStatusBar = false;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(792, 573);
            this.crystalReportViewer1.TabIndex = 85;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // frmPrint
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.crystalReportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmPrint";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrint_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmPrint_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrint_KeyDown);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmPrint_Load(object sender, System.EventArgs e)
		{
			this.Tag=System.Environment.CurrentDirectory.ToString();
			try
			{
				this.TopMost=true;
			}
			catch
			{
			}
		}
		private bool f_insotienchitiettronghoadonthutructiep()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.ReadXml("..\\..\\option\\v_option_insotienchitiet_thutructiep.xml");
				return (ads.Tables[0].Rows[0][0].ToString().Trim()=="1");
			}
			catch
			{
				return false;
			}
		}
		private bool f_intungaydenngay_thutructiep()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.ReadXml("..\\..\\option\\v_option_intungaydenngay_thutructiep.xml");
				return (ads.Tables[0].Rows[0][0].ToString().Trim()=="1");
			}
			catch
			{
				return false;
			}
		}
		private DataSet f_get_Solienkhambenh()
		{
			DataSet ads = new DataSet();
			try
			{
				ads.Tables.Clear();
				ads.ReadXml("...//...//option//v_solienkhambenh.xml");
			}
			catch
			{
				ads.Tables.Clear();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("Ten");
				ads.Tables[0].Rows.Add(new string [] {lan.Change_language_MessageText(
"Liên 1: Giao cho bệnh nhân")});
				ads.WriteXml("...//...//option//v_solienkhambenh.xml",XmlWriteMode.WriteSchema);
			}
			if(ads.Tables.Count<=0)
			{
				ads.Tables.Clear();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("Ten");
				ads.Tables[0].Rows.Add(new string [] {lan.Change_language_MessageText(
"Liên 1: Giao cho bệnh nhân")});
				ads.WriteXml("...//...//option//v_solienkhambenh.xml",XmlWriteMode.WriteSchema);
			}
			return ads;
		}
		private DataSet f_get_Solienkhambenh_thuong()
		{
			DataSet ads = new DataSet();
			try
			{
				ads.Tables.Clear();
				ads.ReadXml("...//...//option//v_solienkhambenh_thuong.xml");
			}
			catch
			{
				ads.Tables.Clear();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("Ten");
				ads.Tables[0].Rows.Add(new string [] {lan.Change_language_MessageText(
"Liên 1: Giao cho bệnh nhân")});
				ads.WriteXml("...//...//option//v_solienkhambenh_thuong.xml",XmlWriteMode.WriteSchema);
			}
			if(ads.Tables.Count<=0)
			{
				ads.Tables.Clear();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("Ten");
				ads.Tables[0].Rows.Add(new string [] {lan.Change_language_MessageText(
"Liên 1: Giao cho bệnh nhân")});
				ads.WriteXml("...//...//option//v_solienkhambenh_thuong.xml",XmlWriteMode.WriteSchema);
			}
			return ads;
		}
		private DataSet f_get_Solienkhambenh_tichkexetnghiem()
		{
			DataSet ads = new DataSet();
			try
			{
				ads.Tables.Clear();
				ads.ReadXml("...//...//option//v_solienkhambenh_tichkexetnghiem.xml");
			}
			catch
			{
				ads.Tables.Clear();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("Ten");
				ads.Tables[0].Rows.Add(new string [] {"Liên 1: Giao cho bệnh nhân"});
				ads.WriteXml("...//...//option//v_solienkhambenh_tichkexetnghiem.xml",XmlWriteMode.WriteSchema);
			}
			if(ads.Tables.Count<=0)
			{
				ads.Tables.Clear();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("Ten");
				ads.Tables[0].Rows.Add(new string [] {lan.Change_language_MessageText(
"Liên 1: Giao cho bệnh nhân")});
				ads.WriteXml("...//...//option//v_solienkhambenh_tichkexetnghiem.xml",XmlWriteMode.WriteSchema);
			}
			return ads;
		}
		private DataSet f_get_Soliennoitru()
		{
			DataSet ads = new DataSet();
			try
			{
				ads.Tables.Clear();
				ads.ReadXml("...//...//option//v_soliennoitru.xml");
			}
			catch
			{
				ads.Tables.Clear();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("Ten");
				ads.Tables[0].Rows.Add(new string [] {lan.Change_language_MessageText(
"Liên 1: Giao cho bệnh nhân")});
				ads.WriteXml("...//...//option//v_soliennoitru.xml",XmlWriteMode.WriteSchema);
			}
			if(ads.Tables.Count<=0)
			{
				ads.Tables.Clear();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("Ten");
				ads.Tables[0].Rows.Add(new string [] {lan.Change_language_MessageText(
"Liên 1: Giao cho bệnh nhân")});
				ads.WriteXml("...//...//option//v_soliennoitru.xml",XmlWriteMode.WriteSchema);
			}
			return ads;
		}
		private DataSet f_get_Soliennoitru_dacthu()
		{
			DataSet ads = new DataSet();
			try
			{
				ads.Tables.Clear();
				ads.ReadXml("...//...//option//v_soliennoitru_dacthu.xml");
			}
			catch
			{
				ads.Tables.Clear();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("Ten");
				ads.Tables[0].Rows.Add(new string [] {lan.Change_language_MessageText(
"Liên 1: Giao cho bệnh nhân")});
				ads.WriteXml("...//...//option//v_soliennoitru_dacthu.xml",XmlWriteMode.WriteSchema);
			}
			if(ads.Tables.Count<=0)
			{
				ads.Tables.Clear();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("Ten");
				ads.Tables[0].Rows.Add(new string [] {lan.Change_language_MessageText(
"Liên 1: Giao cho bệnh nhân")});
				ads.WriteXml("...//...//option//v_soliennoitru_dacthu.xml",XmlWriteMode.WriteSchema);
			}
			return ads;
		}
		private DataSet f_get_Soliennoitru_thuchi()
		{
			DataSet ads = new DataSet();
			try
			{
				ads.Tables.Clear();
				ads.ReadXml("...//...//option//v_soliennoitru_thuchi.xml");
			}
			catch
			{
				ads.Tables.Clear();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("Ten");
				ads.Tables[0].Rows.Add(new string [] {lan.Change_language_MessageText(
"Liên 1: Giao cho bệnh nhân")});
				ads.WriteXml("...//...//option//v_soliennoitru_thuchi.xml",XmlWriteMode.WriteSchema);
			}
			if(ads.Tables.Count<=0)
			{
				ads.Tables.Clear();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("Ten");
				ads.Tables[0].Rows.Add(new string [] {lan.Change_language_MessageText(
"Liên 1: Giao cho bệnh nhân")});
				ads.WriteXml("...//...//option//v_soliennoitru_thuchi.xml",XmlWriteMode.WriteSchema);
			}
			return ads;
		}
		private DataSet f_get_Soliennoitru_chitamung()
		{
			DataSet ads = new DataSet();
			try
			{
				ads.Tables.Clear();
				ads.ReadXml("...//...//option//v_soliennoitru_chitamung.xml");
			}
			catch
			{
				ads.Tables.Clear();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("Ten");
				ads.Tables[0].Rows.Add(new string [] {lan.Change_language_MessageText(
"Liên 1: Giao cho bệnh nhân")});
				ads.WriteXml("...//...//option//v_soliennoitru_chitamung.xml",XmlWriteMode.WriteSchema);
			}
			if(ads.Tables.Count<=0)
			{
				ads.Tables.Clear();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("Ten");
				ads.Tables[0].Rows.Add(new string [] {lan.Change_language_MessageText(
"Liên 1: Giao cho bệnh nhân")});
				ads.WriteXml("...//...//option//v_soliennoitru_chitamung.xml",XmlWriteMode.WriteSchema);
			}
			return ads;
		}
		private DataSet f_get_Soliennoitru_thuong()
		{
			DataSet ads = new DataSet();
			try
			{
				ads.Tables.Clear();
				ads.ReadXml("...//...//option//v_soliennoitru_thuong.xml");
			}
			catch
			{
				ads.Tables.Clear();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("Ten");
				ads.Tables[0].Rows.Add(new string [] {lan.Change_language_MessageText(
"Liên 1: Giao cho bệnh nhân")});
				ads.WriteXml("...//...//option//v_soliennoitru_thuong.xml",XmlWriteMode.WriteSchema);
			}
			return ads;
		}
		private DataSet f_get_Solienngoaitru()
		{
			DataSet ads = new DataSet();
			try
			{
				ads.Tables.Clear();
				ads.ReadXml("...//...//option//v_solienngoaitru.xml");
			}
			catch
			
			{
				ads.Tables.Clear();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("Ten");
				ads.Tables[0].Rows.Add(new string [] {lan.Change_language_MessageText(
"Liên 1: Giao cho bệnh nhân")});
				ads.WriteXml("...//...//option//v_solienngoaitru.xml",XmlWriteMode.WriteSchema);
			}
			if(ads.Tables.Count<=0)
			{
				ads.Tables.Clear();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("Ten");
				ads.Tables[0].Rows.Add(new string [] {lan.Change_language_MessageText(
"Liên 1: Giao cho bệnh nhân")});
				ads.WriteXml("...//...//option//v_solienngoaitru.xml",XmlWriteMode.WriteSchema);
			}
			return ads;
		}
		private DataSet f_get_Solienngoaitru_thuong()
		{
			DataSet ads = new DataSet();
			try
			{
				ads.Tables.Clear();
				ads.ReadXml("...//...//option//v_solienngoaitru_thuong.xml");
			}
			catch
			
			{
				ads.Tables.Clear();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("Ten");
				ads.Tables[0].Rows.Add(new string [] {lan.Change_language_MessageText(
"Liên 1: Giao cho bệnh nhân")});
				ads.WriteXml("...//...//option//v_solienngoaitru_thuong.xml",XmlWriteMode.WriteSchema);
			}
			if(ads.Tables.Count<=0)
			{
				ads.Tables.Clear();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("Ten");
				ads.Tables[0].Rows.Add(new string [] {lan.Change_language_MessageText(
"Liên 1: Giao cho bệnh nhân")});
				ads.WriteXml("...//...//option//v_solienngoaitru_thuong.xml",XmlWriteMode.WriteSchema);
			}
			return ads;
		}
		private DataSet f_get_Solienphieuchi()
		{
			DataSet ads = new DataSet();
			try
			{
				ads.Tables.Clear();
				ads.ReadXml("...//...//option//v_solienphieuchi.xml");
			}
			catch
			{
				ads.Tables.Clear();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("Ten");
				ads.Tables[0].Rows.Add(new string[] {lan.Change_language_MessageText(
"Liên 1: Giao cho bệnh nhân")});
				ads.WriteXml("...//...//option//v_solienphieuchi.xml",XmlWriteMode.WriteSchema);
			}
			if(ads.Tables.Count<=0)
			{
				ads.Tables.Clear();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("Ten");
				ads.Tables[0].Rows.Add(new string[] {lan.Change_language_MessageText(
"Liên 1: Giao cho bệnh nhân")});
				ads.WriteXml("...//...//option//v_solienphieuchi.xml",XmlWriteMode.WriteSchema);
			}
			return ads;
		}
		private DataSet f_get_Solientamung()
		{
			DataSet ads = new DataSet();
			try
			{
				ads.Tables.Clear();
				ads.ReadXml("...//...//option//v_solientamung.xml");
			}
			catch
			{
				ads.Tables.Clear();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("Ten");
				ads.Tables[0].Rows.Add(new string [] {lan.Change_language_MessageText(
"Liên 1: Giao cho bệnh nhân")});
				ads.WriteXml("...//...//option//v_solientamung.xml",XmlWriteMode.WriteSchema);
			}
			if(ads.Tables.Count<=0)
			{
				ads.Tables.Clear();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("Ten");
				ads.Tables[0].Rows.Add(new string [] {lan.Change_language_MessageText(
"Liên 1: Giao cho bệnh nhân")});
				ads.WriteXml("...//...//option//v_solientamung.xml",XmlWriteMode.WriteSchema);
			}
			return ads;
		}
		private string f_GetNgay(string v_ngay)
		{
			try
			{
				return lan.Change_language_MessageText(
"Ngày")+" " + v_ngay.Substring(0,2) + " "+lan.Change_language_MessageText(
"tháng")+" " + v_ngay.Substring(3,2) + " "+lan.Change_language_MessageText(
"năm")+" " + v_ngay.Substring(6);
			}
			catch
			{
				return "";
			}
		}
		private DataSet f_Cursor_BienlaiKB()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.Tables.Add("BienLaiTamUng");
				ads.Tables[0].Columns.Add("syt");
				ads.Tables[0].Columns.Add("bv");
				ads.Tables[0].Columns.Add("diachibv");
				ads.Tables[0].Columns.Add("tongcucthue");
				ads.Tables[0].Columns.Add("cucthue");
				ads.Tables[0].Columns.Add("masothue");
				ads.Tables[0].Columns.Add("mauso");
				ads.Tables[0].Columns.Add("quyenso");
				ads.Tables[0].Columns.Add("sobienlai");
				ads.Tables[0].Columns.Add("ngayin");
				ads.Tables[0].Columns.Add("nguoiin");
				ads.Tables[0].Columns.Add("ghichu");
				ads.Tables[0].Columns.Add("sovaovien");
				ads.Tables[0].Columns.Add("lien");
				ads.Tables[0].Columns.Add("mabn");
				ads.Tables[0].Columns.Add("hoten");
				ads.Tables[0].Columns.Add("ngaysinh");
				ads.Tables[0].Columns.Add("gioitinh");
				ads.Tables[0].Columns.Add("khoa");
				ads.Tables[0].Columns.Add("diachi");
				ads.Tables[0].Columns.Add("lydo");
				ads.Tables[0].Columns.Add("sotien");
				ads.Tables[0].Columns.Add("chutien");
				ads.Tables[0].Columns.Add("nguoithu");
				ads.Tables[0].Columns.Add("diengiai");
				return ads;
			}
			catch
			{
				return null;
			}
		}
		private string f_get_tungaydenngay_giuong(string v_mmyy_only, string v_id, string v_mavp)
		{
			try
			{
				string atmp="";
				if(v_mmyy_only=="")
				{
					v_mmyy_only = DateTime.Now.Year.ToString().Substring(2);
				}
				foreach(DataRow r in m_v.get_data_mmyy(v_mmyy_only,"select to_char(min(ngay),'dd/mm/yyyy') minngay, to_char(max(ngay),'dd/mm/yyyy') maxngay from v_giuong where to_char(id)='"+v_id+"' and to_char(mavp)='"+v_mavp+"' group by id, mavp").Tables[0].Rows)
				{
					if(r["minngay"].ToString()==r["maxngay"].ToString())
					{
						atmp=r["minngay"].ToString();
					}
					else
					{
						atmp=r["minngay"].ToString()+" -> "+r["maxngay"].ToString();
					}
					break;
				}
				if(atmp!="") atmp=" ("+atmp+")";
				return atmp;
			}
			catch
			{
				return "";
			}
		}
		public void f_Print_BienlaiKB(bool v_dir, string v_id, string v_mmyy_only)
		{
			string acur=System.Environment.CurrentDirectory;
			try
			{
				bool ainsotienchitiet=f_insotienchitiettronghoadonthutructiep();
				bool aintungaydenngay=f_intungaydenngay_thutructiep();
				bool agiabangdongiacongvattu=m_v.sys_dongiacongvattu;
				try
				{
					string aReport ="v_bienlaithuvienphi.rpt";
					this.Text=lan.Change_language_MessageText(
"In biên lai thu viện phí trực tiếp (")+aReport+")";
                    m_sql = "select  k.tenkp, l.tenkp as tenkpct, a.id, aa.sovaovien, a.sobienlai, b.soluong, b.dongia, b.mien, aaa.sotien as tongmien, b.thieu, b.vattu, b.madoituong, a.mabn, a.hoten, a.namsinh as ngaysinh, b.mavp, c.ten as tenvp, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa, a.diachi, d.sonha, d.thon, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso, a.lanin+1 as lanin from medibvmmyy.v_vienphill a left join medibvmmyy.tiepdon aa on a.mabn=aa.mabn and a.maql=aa.maql left join medibvmmyy.v_mienngtru aaa on a.id=aaa.id left join medibvmmyy.v_vienphict b on a.id=b.id left join (select id, ten from medibv.v_giavp union select id, ten||' '|| hamluong as ten from medibv.d_dmbd) as c on b.mavp=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on a.quyenso=i.id left join medibv.v_dlogin j on a.userid=j.id left join medibv.btdkp_bv k on a.makp=k.makp left join medibv.btdkp_bv l on b.makp=l.makp where a.id=" + v_id + " order by b.stt";
                    if (v_mmyy_only == "")
					{
						v_mmyy_only=DateTime.Now.Year.ToString().Substring(2);
					}
					m_ds = m_v.get_data_mmyy(v_mmyy_only,m_sql);

					if(m_ds.Tables[0].Rows.Count<=0)
					{
						MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí <")+v_id+">",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
						return;
					}
				
					string asyt="",abv="",angayin="",anguoiin="",aghichu="",ahoten="", angaysinh="", agioitinh="", akhoa="",adiachi="", alydo="", alydobh="",asotien="", achutien="", anguoithu="", amasothue="",amauso="",aquyenso="",asobienlai="",acucthue="",atongcuc="",adiachibv="",amabn="", adiengiai="", akhoact="";
					asyt = m_v.Syte;
					abv = m_v.Tenbv;
					adiachibv = m_v.s_diachi;
					atongcuc = lan.Change_language_MessageText("TỔNG CỤC THUẾ");
					acucthue = lan.Change_language_MessageText("CỤC THUẾ");
					amasothue=m_v.s_masothue;
					amauso=m_v.s_maubienlai;
					aquyenso=m_ds.Tables[0].Rows[0]["quyenso"].ToString();;
					asobienlai=m_ds.Tables[0].Rows[0]["sobienlai"].ToString();
					angayin=m_ds.Tables[0].Rows[0]["ngaythu"].ToString();
					anguoiin=m_tendangnhap;
					aghichu = lan.Change_language_MessageText(
"(In lần ")+m_ds.Tables[0].Rows[0]["lanin"].ToString()+")";
					amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();
					ahoten=m_ds.Tables[0].Rows[0]["hoten"].ToString();
					angaysinh=m_ds.Tables[0].Rows[0]["ngaysinh"].ToString();
					agioitinh=m_ds.Tables[0].Rows[0]["gioitinh"].ToString();
					akhoa=m_ds.Tables[0].Rows[0]["tenkp"].ToString().Trim();;
					akhoact=m_ds.Tables[0].Rows[0]["tenkpct"].ToString().Trim();
					adiachi=m_ds.Tables[0].Rows[0]["sonha"].ToString().Trim() + " "+ m_ds.Tables[0].Rows[0]["thon"].ToString().Trim();
					adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenpxa"].ToString();
					adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenquan"].ToString();
					adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tentt"].ToString();
					adiachi=adiachi.Trim().Trim(',').Trim();
					if(adiachi.Trim()=="")
					{
						adiachi=m_ds.Tables[0].Rows[0]["diachi"].ToString().Trim();
					}
					alydo="";
					asotien="";
					achutien="";
					anguoithu=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
					decimal athucthu=0, atongtien=0, atongmien=0, atongmien1=0, atongthieu=0, atongbhyt=0, asoluong=0, adongia=0, amien=0, athieu=0, abhyt=0, avattu=0;

					try
					{
						atongmien1 = decimal.Parse(m_ds.Tables[0].Rows[0]["tongmien"].ToString());
					}
					catch
					{
						atongmien1=0;
					}
				
					for(int i=0;i<m_ds.Tables[0].Rows.Count;i++)
					{
						if(akhoact.IndexOf(m_ds.Tables[0].Rows[i]["tenkpct"].ToString().Trim())<0)
						{
							akhoact=akhoact.Trim().Trim(',')+", "+m_ds.Tables[0].Rows[i]["tenkpct"].ToString().Trim();
						}
						try
						{
							asoluong = decimal.Parse(m_ds.Tables[0].Rows[i]["soluong"].ToString());
						}
						catch
						{
							asoluong=0;
						}

						try
						{
							adongia = decimal.Parse(m_ds.Tables[0].Rows[i]["dongia"].ToString());
						}
						catch
						{
							adongia=0;
						}

						try
						{
							amien = decimal.Parse(m_ds.Tables[0].Rows[i]["mien"].ToString());
						}
						catch
						{
							amien=0;
						}
					
						try
						{
							athieu = decimal.Parse(m_ds.Tables[0].Rows[i]["thieu"].ToString());
						}
						catch
						{
							athieu=0;
						}
						try
						{
							avattu = decimal.Parse(m_ds.Tables[0].Rows[i]["vattu"].ToString());
						}
						catch
						{
							avattu=0;
						}
						abhyt=0;
						if(m_ds.Tables[0].Rows[i]["madoituong"].ToString()=="1")
						{
							abhyt=amien;
							amien=0;
							alydobh=alydobh.Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[i]["tenvp"].ToString();
							if(asoluong>1)
							{
								alydobh=alydobh + " (" + asoluong.ToString()+")";
							}
							if(ainsotienchitiet)
							{
								alydobh=alydobh+" ["+(asoluong*adongia-amien-athieu).ToString("###,###,##0.##")+"]";
							}

							if(aintungaydenngay)
							{
								alydobh+=" "+f_get_tungaydenngay_giuong(v_mmyy_only,v_id,m_ds.Tables[0].Rows[i]["mavp"].ToString());
							}
							alydobh=alydobh.Trim();
						}
						else
						{
							alydo=alydo.Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[i]["tenvp"].ToString();
							if(asoluong>1)
							{
								alydo=alydo + " (" + asoluong.ToString()+")";
							}
							if(ainsotienchitiet)
							{
								alydo=alydo+" ["+(asoluong*adongia-amien-athieu).ToString("###,###,##0.##")+"]";
							}
							if(aintungaydenngay)
							{
								alydo+=" "+f_get_tungaydenngay_giuong(v_mmyy_only,v_id,m_ds.Tables[0].Rows[i]["mavp"].ToString());
							}
							alydo=alydo.Trim();
						}
					
						if(agiabangdongiacongvattu)
						{
							adongia+=avattu;
						}

						atongtien = atongtien + asoluong * adongia;
						atongmien = atongmien + amien;
						atongthieu = atongthieu + athieu;
						atongbhyt = atongbhyt + abhyt;
					}
					akhoact=akhoact.Trim().Trim(',');
					if(akhoact!="")
					{
						akhoa=akhoact;
					}

					if(atongmien==0)
					{
						atongmien=atongmien1;
					}

					//MessageBox.Show(atongtien.ToString()+"-"+ atongmien.ToString()+"-"+atongmien1.ToString()+"-"+atongthieu.ToString());
				
					athucthu = atongtien - atongmien - atongbhyt - atongthieu;

					try
					{
						athucthu = decimal.Parse(decimal.Parse(athucthu.ToString()).ToString());
					}
					catch//(Exception exx)
					{
						//MessageBox.Show(exx.ToString());
					}
					asotien = athucthu.ToString();
					achutien = m_v.Doiso_Unicode(athucthu.ToString());
					if(achutien=="")
					{
						achutien=lan.Change_language_MessageText("không đồng");
					}

					alydo=alydo.Trim().Trim(',');
					alydobh=alydobh.Trim().Trim(',');
					if(alydobh!="")
					{
						alydo=alydo+ lan.Change_language_MessageText(", BHYT(") + alydobh + ")";
					}
					alydo=alydo.Trim().Trim(',');
					alydo=alydo.Trim();

					if((atongmien1>0)||(atongthieu>0)||(atongbhyt>0))
					{
						adiengiai=
lan.Change_language_MessageText("Ghi chú: - Tổng chi phí:")+" " + atongtien.ToString("###,###,###.##")+
lan.Change_language_MessageText("đ");
						if(atongbhyt>0)
						{
							adiengiai=adiengiai+" "+
lan.Change_language_MessageText("- BHYT trả:")+" " + atongbhyt.ToString("###,###,###.##")+
lan.Change_language_MessageText("đ");
						}
						if(atongmien>0)
						{
							adiengiai=adiengiai+" "+
lan.Change_language_MessageText("- Miễn:")+" " + atongmien.ToString("###,###,###.##")+
lan.Change_language_MessageText("đ");
						}
						if(atongthieu>0)
						{
							adiengiai=adiengiai+" "+
lan.Change_language_MessageText("- Bệnh nhân nợ:")+" " + atongthieu.ToString("###,###,###.##")+
lan.Change_language_MessageText("đ");
						}
					}
					DataSet ads = f_Cursor_BienlaiKB();
					DataSet adslien = f_get_Solienkhambenh();
					for(int i=0;i<adslien.Tables[0].Rows.Count;i++)
					{
						DataRow r = ads.Tables[0].NewRow();
						r["syt"]=asyt;
						r["bv"]=abv;
						r["diachibv"]=adiachibv;
						r["tongcucthue"]=atongcuc;
						r["cucthue"]=acucthue;
						r["masothue"]=amasothue;
						r["mauso"]=amauso;
						r["quyenso"]=aquyenso;
						r["sobienlai"]=asobienlai;
						r["ngayin"]=angayin;
						r["nguoiin"]=anguoiin;
						r["ghichu"]=aghichu;
						r["lien"]=adslien.Tables[0].Rows[i][0].ToString().Trim();
						r["mabn"]=amabn;
						r["hoten"]=ahoten;
						r["ngaysinh"]=angaysinh;
						r["gioitinh"]=agioitinh;
						r["khoa"]=akhoa;
						r["diachi"]=adiachi;
						r["lydo"]=alydo;
						r["sotien"]=asotien;
						r["chutien"]=achutien;
						r["nguoithu"]=anguoithu;
						r["diengiai"]=adiengiai;
						ads.Tables[0].Rows.Add(r);
					}
				
					//ads.WriteXml("..\\..\\DataReport\\v_bienlaithuvienphi.xml",XmlWriteMode.WriteSchema);
					//return;
					ReportDocument cMain=new ReportDocument();
					cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
					cMain.SetDataSource(ads);
					//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
					//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

					if(!v_dir)
					{
						this.crystalReportViewer1.ReportSource=cMain;
						this.WindowState=FormWindowState.Maximized;
						this.ShowDialog(this.Parent);
					}
					else
					{
						cMain.PrintToPrinter(1,false,0,0);
					}
                    m_v.execute_data_mmyy(v_mmyy_only, "update medibvmmyy.v_vienphill set lanin=nvl(lanin,0)+1 where to_char(id)='" + v_id + "'");
                    cMain.Close(); cMain.Dispose();
				}
				catch(Exception ex)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiểm tra lại máy in.")+"\n" + ex.ToString(),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
			}
			catch
			{
			}
			finally
			{
				System.Environment.CurrentDirectory=acur;
			}
		}
		public void f_Print_BienlaiKB_Dacthu(bool v_dir, string v_id, string v_mmyy_only)
		{
			bool ainsotienchitiet=f_insotienchitiettronghoadonthutructiep();
			bool aintungaydenngay=f_intungaydenngay_thutructiep();
			bool agiabangdongiacongvattu=m_v.sys_dongiacongvattu;
			try
			{
				string aReport ="v_bienlaithuvienphi_dacthu.rpt";
				this.Text="In biên lai thu viện phí trực tiếp ("+aReport+")";
                m_sql = "select  k.tenkp, l.tenkp as tenkpct, a.id, aa.sovaovien, a.sobienlai, b.soluong, b.dongia, b.mien, aaa.sotien as tongmien, b.thieu, b.vattu, b.madoituong, a.mabn, a.hoten, a.namsinh as ngaysinh, b.mavp, c.ten as tenvp, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa, a.diachi, d.sonha, d.thon, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso, a.lanin+1 as lanin from medibvmmyy.v_vienphill a left join medibvmmyy.tiepdon aa on a.mabn=aa.mabn and a.maql=aa.maql left join medibvmmyy.v_mienngtru aaa on a.id=aaa.id left join medibvmmyy.v_vienphict b on a.id=b.id left join (select id, ten from medibv.v_giavp union select id, ten||' '|| hamluong as ten from medibv.d_dmbd) as c on b.mavp=c.id left join medibv.btdbn d on a.mabn=d.mabn left join medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on a.quyenso=i.id left join medibv.v_dlogin j on a.userid=j.id left join medibv.btdkp_bv k on a.makp=k.makp left join medibv.btdkp_bv l on b.makp=l.makp where a.id=" + v_id + " order by b.stt";
                if (v_mmyy_only == "")
				{
					v_mmyy_only=DateTime.Now.Year.ToString().Substring(2);
				}
				m_ds = m_v.get_data_mmyy(v_mmyy_only,m_sql);

				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí <")+v_id+">",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="",ahoten="", angaysinh="", agioitinh="", akhoa="",adiachi="", alydo="", alydobh="",asotien="", achutien="", anguoithu="", amasothue="",amauso="",aquyenso="",asobienlai="",acucthue="",atongcuc="",adiachibv="",amabn="", adiengiai="", akhoact="";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				adiachibv = m_v.s_diachi;
				atongcuc = 
lan.Change_language_MessageText("TỔNG CỤC THUẾ");
				acucthue = 
lan.Change_language_MessageText("CỤC THUẾ");
				amasothue=m_v.s_masothue;
				amauso=m_v.s_maubienlai;
				aquyenso=m_ds.Tables[0].Rows[0]["quyenso"].ToString();;
				asobienlai=m_ds.Tables[0].Rows[0]["sobienlai"].ToString();
				angayin=m_ds.Tables[0].Rows[0]["ngaythu"].ToString();
				anguoiin=m_tendangnhap;
				aghichu = 
lan.Change_language_MessageText("(In lần")+" "+m_ds.Tables[0].Rows[0]["lanin"].ToString()+")";
				amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();
				ahoten=m_ds.Tables[0].Rows[0]["hoten"].ToString();
				angaysinh=m_ds.Tables[0].Rows[0]["ngaysinh"].ToString();
				agioitinh=m_ds.Tables[0].Rows[0]["gioitinh"].ToString();
				akhoa=m_ds.Tables[0].Rows[0]["tenkp"].ToString().Trim();;
				akhoact=m_ds.Tables[0].Rows[0]["tenkpct"].ToString().Trim();
				adiachi=m_ds.Tables[0].Rows[0]["sonha"].ToString().Trim() + " "+ m_ds.Tables[0].Rows[0]["thon"].ToString().Trim();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenpxa"].ToString();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenquan"].ToString();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tentt"].ToString();
				adiachi=adiachi.Trim().Trim(',').Trim();
				if(adiachi.Trim()=="")
				{
					adiachi=m_ds.Tables[0].Rows[0]["diachi"].ToString().Trim();
				}
				alydo="";
				asotien="";
				achutien="";
				anguoithu=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				decimal athucthu=0, atongtien=0, atongmien=0, atongmien1=0, atongthieu=0, atongbhyt=0, asoluong=0, adongia=0, amien=0, athieu=0, abhyt=0,avattu=0;

				try
				{
					atongmien1 = decimal.Parse(m_ds.Tables[0].Rows[0]["tongmien"].ToString());
				}
				catch
				{
					atongmien1=0;
				}
				
				for(int i=0;i<m_ds.Tables[0].Rows.Count;i++)
				{
					if(akhoact.IndexOf(m_ds.Tables[0].Rows[i]["tenkpct"].ToString().Trim())<0)
					{
						akhoact=akhoact.Trim().Trim(',')+", "+m_ds.Tables[0].Rows[i]["tenkpct"].ToString().Trim();
					}
					try
					{
						asoluong = decimal.Parse(m_ds.Tables[0].Rows[i]["soluong"].ToString());
					}
					catch
					{
						asoluong=0;
					}

					try
					{
						adongia = decimal.Parse(m_ds.Tables[0].Rows[i]["dongia"].ToString());
					}
					catch
					{
						adongia=0;
					}

					try
					{
						amien = decimal.Parse(m_ds.Tables[0].Rows[i]["mien"].ToString());
					}
					catch
					{
						amien=0;
					}
					
					try
					{
						athieu = decimal.Parse(m_ds.Tables[0].Rows[i]["thieu"].ToString());
					}
					catch
					{
						athieu=0;
					}
					try
					{
						avattu = decimal.Parse(m_ds.Tables[0].Rows[i]["vattu"].ToString());
					}
					catch
					{
						avattu=0;
					}
					abhyt=0;
					if(m_ds.Tables[0].Rows[i]["madoituong"].ToString()=="1")
					{
						abhyt=amien;
						amien=0;
						alydobh=alydobh.Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[i]["tenvp"].ToString();
						if(asoluong>1)
						{
							alydobh=alydobh + " (" + asoluong.ToString()+")";
						}
						if(ainsotienchitiet)
						{
							alydobh=alydobh+" ["+(asoluong*adongia-amien-athieu).ToString("###,###,##0.##")+"]";
						}

						if(aintungaydenngay)
						{
							alydobh+=" "+f_get_tungaydenngay_giuong(v_mmyy_only,v_id,m_ds.Tables[0].Rows[i]["mavp"].ToString());
						}
						alydobh=alydobh.Trim();
					}
					else
					{
						alydo=alydo.Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[i]["tenvp"].ToString();
						if(asoluong>1)
						{
							alydo=alydo + " (" + asoluong.ToString()+")";
						}
						if(ainsotienchitiet)
						{
							alydo=alydo+" ["+(asoluong*adongia-amien-athieu).ToString("###,###,##0.##")+"]";
						}
						if(aintungaydenngay)
						{
							alydo+=" "+f_get_tungaydenngay_giuong(v_mmyy_only,v_id,m_ds.Tables[0].Rows[i]["mavp"].ToString());
						}
						alydo=alydo.Trim();
					}
					if(agiabangdongiacongvattu)
					{
						adongia+=avattu;
					}

					atongtien = atongtien + asoluong * adongia;
					atongmien = atongmien + amien;
					atongthieu = atongthieu + athieu;
					atongbhyt = atongbhyt + abhyt;
				}
				akhoact=akhoact.Trim().Trim(',');
				if(akhoact!="")
				{
					akhoa=akhoact;
				}

				if(atongmien==0)
				{
					atongmien=atongmien1;
				}

				//MessageBox.Show(atongtien.ToString()+"-"+ atongmien.ToString()+"-"+atongmien1.ToString()+"-"+atongthieu.ToString());
				
				athucthu = atongtien - atongmien - atongbhyt - atongthieu;

				try
				{
					athucthu = decimal.Parse(decimal.Parse(athucthu.ToString()).ToString());
				}
				catch//(Exception exx)
				{
					//MessageBox.Show(exx.ToString());
				}
				asotien = athucthu.ToString();
				achutien = m_v.Doiso_Unicode(athucthu.ToString());
				if(achutien=="")
				{
					achutien=lan.Change_language_MessageText("không đồng");
				}

				alydo=alydo.Trim().Trim(',');
				alydobh=alydobh.Trim().Trim(',');
				if(alydobh!="")
				{
					alydo=alydo+ lan.Change_language_MessageText(", BHYT(") + alydobh + ")";
				}
				alydo=alydo.Trim().Trim(',');
				alydo=alydo.Trim();

				if((atongmien1>0)||(atongthieu>0)||(atongbhyt>0))
				{
					adiengiai=
lan.Change_language_MessageText("Ghi chú: - Tổng chi phí:")+" " + atongtien.ToString("###,###,###.##")+
lan.Change_language_MessageText("đ");
					if(atongbhyt>0)
					{
						adiengiai=adiengiai+" "+
lan.Change_language_MessageText("- BHYT trả:")+" " + atongbhyt.ToString("###,###,###.##")+
lan.Change_language_MessageText("đ");
					}
					if(atongmien>0)
					{
						adiengiai=adiengiai+" "+
lan.Change_language_MessageText("- Miễn:")+" " + atongmien.ToString("###,###,###.##")+
lan.Change_language_MessageText("đ");
					}
					if(atongthieu>0)
					{
						adiengiai=adiengiai+" "+
lan.Change_language_MessageText("- Bệnh nhân nợ:")+" " + atongthieu.ToString("###,###,###.##")+
lan.Change_language_MessageText("đ");
					}
				}
				DataSet ads = f_Cursor_BienlaiKB();
				DataSet adslien = f_get_Solienkhambenh();
				for(int i=0;i<adslien.Tables[0].Rows.Count;i++)
				{
					DataRow r = ads.Tables[0].NewRow();
					r["syt"]=asyt;
					r["bv"]=abv;
					r["diachibv"]=adiachibv;
					r["tongcucthue"]=atongcuc;
					r["cucthue"]=acucthue;
					r["masothue"]=amasothue;
					r["mauso"]=amauso;
					r["quyenso"]=aquyenso;
					r["sobienlai"]=asobienlai;
					r["ngayin"]=angayin;
					r["nguoiin"]=anguoiin;
					r["ghichu"]=aghichu;
					r["lien"]=adslien.Tables[0].Rows[i][0].ToString().Trim();
					r["mabn"]=amabn;
					r["hoten"]=ahoten;
					r["ngaysinh"]=angaysinh;
					r["gioitinh"]=agioitinh;
					r["khoa"]=akhoa;
					r["diachi"]=adiachi;
					r["lydo"]=alydo;
					r["sotien"]=asotien;
					r["chutien"]=achutien;
					r["nguoithu"]=anguoithu;
					r["diengiai"]=adiengiai;
					ads.Tables[0].Rows.Add(r);
				}
				
				//ads.WriteXml("..\\..\\DataReport\\v_bienlaithuvienphi.xml",XmlWriteMode.WriteSchema);
				//return;
				ReportDocument cMain=new ReportDocument();
				try
				{
					cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				}
				catch
				{
					System.IO.File.Copy("..\\..\\..\\report\\"+aReport.Replace("_dacthu",""),"..\\..\\..\\report\\"+aReport,false);
					cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				}
				cMain.SetDataSource(ads);
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
                m_v.execute_data_mmyy(v_mmyy_only, "update medibvmmyy.v_vienphill set lanin=nvl(lanin,0)+1 where to_char(id)='" + v_id + "'");
                cMain.Close(); cMain.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_BienlaiKB_Suatan(bool v_dir, string v_id, string v_mmyy_only)
		{
			bool ainsotienchitiet=f_insotienchitiettronghoadonthutructiep();
			bool aintungaydenngay=f_intungaydenngay_thutructiep();
			bool agiabangdongiacongvattu=m_v.sys_dongiacongvattu;
			try
			{
				string aReport ="v_bienlaithuvienphi_suatan.rpt";
				this.Text="In biên lai thu viện phí trực tiếp ("+aReport+")";
				m_sql = "select  k.tenkp, nvl(l.tenkp,'') tenkpct, a.id, aa.sovaovien, a.sobienlai, nvl(b.soluong,0) soluong, nvl(b.dongia,0) dongia, nvl(b.mien,0) mien, nvl(aaa.sotien,0) tongmien, nvl(b.thieu,0) thieu, nvl(b.vattu,0) vattu, b.madoituong, d.mabn, d.hoten, decode(d.ngaysinh,null,nvl(d.namsinh,a.namsinh),to_char(d.ngaysinh,'dd/mm/yyyy')) ngaysinh, b.mavp, c.ten tenvp, e.ten gioitinh,  f.tentt, g.tenquan,h.tenpxa, a.diachi, d.sonha, d.thon, to_char(a.ngay,'dd/mm/yyyy') ngaythu, j.hoten nguoithu, i.sohieu quyenso, nvl(a.lanin,0)+1 lanin from v_vienphill a, tiepdon aa, v_mienngtru aaa, v_vienphict b,(select id, ten from v_giavp union select id, trim(ten||' '|| hamluong) ten from d_dmbd) c, btdbn d, dmphai e, btdtt f, btdquan g, btdpxa h, v_quyenso i, medibv.v_dlogin j, btdkp_bv k, btdkp_bv l where a.id=b.id(+) and a.maql=aa.maql(+) and a.id=aaa.id(+) and a.mabn=d.mabn(+) and b.mavp=c.id(+) and a.makp=k.makp(+) and d.phai=e.ma(+) and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.quyenso = i.id(+) and a.userid=j.id(+) and b.makp=l.makp(+) and to_char(a.id)='"+v_id+"' order by b.stt";
				if(v_mmyy_only=="")
				{
					v_mmyy_only=DateTime.Now.Year.ToString().Substring(2);
				}
				m_ds = m_v.get_data_mmyy(v_mmyy_only,m_sql);

				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí <")+v_id+">",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="",ahoten="", angaysinh="", agioitinh="", akhoa="",adiachi="", alydo="", alydobh="",asotien="", achutien="", anguoithu="", amasothue="",amauso="",aquyenso="",asobienlai="",acucthue="",atongcuc="",adiachibv="",amabn="", adiengiai="", akhoact="";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				adiachibv = m_v.s_diachi;
				atongcuc = 
lan.Change_language_MessageText("TỔNG CỤC THUẾ");
				acucthue = 
lan.Change_language_MessageText("CỤC THUẾ");
				amasothue=m_v.s_masothue;
				amauso=m_v.s_maubienlai;
				aquyenso=m_ds.Tables[0].Rows[0]["quyenso"].ToString();;
				asobienlai=m_ds.Tables[0].Rows[0]["sobienlai"].ToString();
				angayin=m_ds.Tables[0].Rows[0]["ngaythu"].ToString();
				anguoiin=m_tendangnhap;
				aghichu = 
lan.Change_language_MessageText("(In lần")+" "+m_ds.Tables[0].Rows[0]["lanin"].ToString()+")";
				amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();
				ahoten=m_ds.Tables[0].Rows[0]["hoten"].ToString();
				angaysinh=m_ds.Tables[0].Rows[0]["ngaysinh"].ToString();
				agioitinh=m_ds.Tables[0].Rows[0]["gioitinh"].ToString();
				akhoa=m_ds.Tables[0].Rows[0]["tenkp"].ToString().Trim();;
				akhoact=m_ds.Tables[0].Rows[0]["tenkpct"].ToString().Trim();
				adiachi=m_ds.Tables[0].Rows[0]["sonha"].ToString().Trim() + " "+ m_ds.Tables[0].Rows[0]["thon"].ToString().Trim();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenpxa"].ToString();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenquan"].ToString();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tentt"].ToString();
				adiachi=adiachi.Trim().Trim(',').Trim();
				if(adiachi.Trim()=="")
				{
					adiachi=m_ds.Tables[0].Rows[0]["diachi"].ToString().Trim();
				}
				alydo="";
				asotien="";
				achutien="";
				anguoithu=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				decimal athucthu=0, atongtien=0, atongmien=0, atongmien1=0, atongthieu=0, atongbhyt=0, asoluong=0, adongia=0, amien=0, athieu=0, abhyt=0, avattu=0;

				try
				{
					atongmien1 = decimal.Parse(m_ds.Tables[0].Rows[0]["tongmien"].ToString());
				}
				catch
				{
					atongmien1=0;
				}
				
				for(int i=0;i<m_ds.Tables[0].Rows.Count;i++)
				{
					if(akhoact.IndexOf(m_ds.Tables[0].Rows[i]["tenkpct"].ToString().Trim())<0)
					{
						akhoact=akhoact.Trim().Trim(',')+", "+m_ds.Tables[0].Rows[i]["tenkpct"].ToString().Trim();
					}
					try
					{
						asoluong = decimal.Parse(m_ds.Tables[0].Rows[i]["soluong"].ToString());
					}
					catch
					{
						asoluong=0;
					}

					try
					{
						adongia = decimal.Parse(m_ds.Tables[0].Rows[i]["dongia"].ToString());
					}
					catch
					{
						adongia=0;
					}

					try
					{
						amien = decimal.Parse(m_ds.Tables[0].Rows[i]["mien"].ToString());
					}
					catch
					{
						amien=0;
					}
					
					try
					{
						athieu = decimal.Parse(m_ds.Tables[0].Rows[i]["thieu"].ToString());
					}
					catch
					{
						athieu=0;
					}
					try
					{
						avattu = decimal.Parse(m_ds.Tables[0].Rows[i]["vattu"].ToString());
					}
					catch
					{
						avattu=0;
					}
					abhyt=0;
					if(m_ds.Tables[0].Rows[i]["madoituong"].ToString()=="1")
					{
						abhyt=amien;
						amien=0;
						alydobh=alydobh.Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[i]["tenvp"].ToString();
						if(asoluong>1)
						{
							alydobh=alydobh + " (" + asoluong.ToString()+")";
						}
						if(ainsotienchitiet)
						{
							alydobh=alydobh+" ["+(asoluong*adongia-amien-athieu).ToString("###,###,##0.##")+"]";
						}

						if(aintungaydenngay)
						{
							alydobh+=" "+f_get_tungaydenngay_giuong(v_mmyy_only,v_id,m_ds.Tables[0].Rows[i]["mavp"].ToString());
						}
						alydobh=alydobh.Trim();
					}
					else
					{
						alydo=alydo.Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[i]["tenvp"].ToString();
						if(asoluong>1)
						{
							alydo=alydo + " (" + asoluong.ToString()+")";
						}
						if(ainsotienchitiet)
						{
							alydo=alydo+" ["+(asoluong*adongia-amien-athieu).ToString("###,###,##0.##")+"]";
						}
						if(aintungaydenngay)
						{
							alydo+=" "+f_get_tungaydenngay_giuong(v_mmyy_only,v_id,m_ds.Tables[0].Rows[i]["mavp"].ToString());
						}
						alydo=alydo.Trim();
					}
					if(agiabangdongiacongvattu)
					{
						adongia+=avattu;
					}

					atongtien = atongtien + asoluong * adongia;
					atongmien = atongmien + amien;
					atongthieu = atongthieu + athieu;
					atongbhyt = atongbhyt + abhyt;
				}
				akhoact=akhoact.Trim().Trim(',');
				if(akhoact!="")
				{
					akhoa=akhoact;
				}

				if(atongmien==0)
				{
					atongmien=atongmien1;
				}

				//MessageBox.Show(atongtien.ToString()+"-"+ atongmien.ToString()+"-"+atongmien1.ToString()+"-"+atongthieu.ToString());
				
				athucthu = atongtien - atongmien - atongbhyt - atongthieu;

				try
				{
					athucthu = decimal.Parse(decimal.Parse(athucthu.ToString()).ToString());
				}
				catch//(Exception exx)
				{
					//MessageBox.Show(exx.ToString());
				}
				asotien = athucthu.ToString();
				achutien = m_v.Doiso_Unicode(athucthu.ToString());
				if(achutien=="")
				{
					achutien=lan.Change_language_MessageText("Không đồng");
				}

				alydo=alydo.Trim().Trim(',');
				alydobh=alydobh.Trim().Trim(',');
				if(alydobh!="")
				{
					alydo=alydo+ lan.Change_language_MessageText(", BHYT(") + alydobh + ")";
				}
				alydo=alydo.Trim().Trim(',');
				alydo=alydo.Trim();

				if((atongmien1>0)||(atongthieu>0)||(atongbhyt>0))
				{
					adiengiai=lan.Change_language_MessageText(
"Ghi chú: - Tổng chi phí:")+" " + atongtien.ToString("###,###,###.##")+
lan.Change_language_MessageText("đ");
					if(atongbhyt>0)
					{
						adiengiai=adiengiai+" "+lan.Change_language_MessageText(
"- BHYT trả:")+" " + atongbhyt.ToString("###,###,###.##")+
lan.Change_language_MessageText("đ");
					}
					if(atongmien>0)
					{
						adiengiai=adiengiai+" "+lan.Change_language_MessageText(
"- Miễn:")+" " + atongmien.ToString("###,###,###.##")+
lan.Change_language_MessageText("đ");
					}
					if(atongthieu>0)
					{
						adiengiai=adiengiai+" "+lan.Change_language_MessageText(
"- Bệnh nhân nợ:")+" " + atongthieu.ToString("###,###,###.##")+
lan.Change_language_MessageText("đ");
					}
				}
				DataSet ads = f_Cursor_BienlaiKB();
				DataSet adslien = f_get_Solienkhambenh();
				for(int i=0;i<adslien.Tables[0].Rows.Count;i++)
				{
					DataRow r = ads.Tables[0].NewRow();
					r["syt"]=asyt;
					r["bv"]=abv;
					r["diachibv"]=adiachibv;
					r["tongcucthue"]=atongcuc;
					r["cucthue"]=acucthue;
					r["masothue"]=amasothue;
					r["mauso"]=amauso;
					r["quyenso"]=aquyenso;
					r["sobienlai"]=asobienlai;
					r["ngayin"]=angayin;
					r["nguoiin"]=anguoiin;
					r["ghichu"]=aghichu;
					r["lien"]=adslien.Tables[0].Rows[i][0].ToString().Trim();
					r["mabn"]=amabn;
					r["hoten"]=ahoten;
					r["ngaysinh"]=angaysinh;
					r["gioitinh"]=agioitinh;
					r["khoa"]=akhoa;
					r["diachi"]=adiachi;
					r["lydo"]=alydo;
					r["sotien"]=asotien;
					r["chutien"]=achutien;
					r["nguoithu"]=anguoithu;
					r["diengiai"]=adiengiai;
					ads.Tables[0].Rows.Add(r);
				}
				
				//ads.WriteXml("..\\..\\DataReport\\v_bienlaithuvienphi.xml",XmlWriteMode.WriteSchema);
				//return;
				ReportDocument cMain=new ReportDocument();
				try
				{
					cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				}
				catch
				{
					System.IO.File.Copy("..\\..\\..\\report\\"+aReport.Replace("_suatan",""),"..\\..\\..\\report\\"+aReport,false);
					cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				}

				cMain.SetDataSource(ads);
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
                m_v.execute_data_mmyy(v_mmyy_only, "update medibvmmyy.v_vienphill set lanin=nvl(lanin,0)+1 where to_char(id)='" + v_id + "'");
                cMain.Close(); cMain.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_BienlaiKB_Giuongyeucau(bool v_dir, string v_id, string v_mmyy_only)
		{
			bool ainsotienchitiet=f_insotienchitiettronghoadonthutructiep();
			bool aintungaydenngay=f_intungaydenngay_thutructiep();
			bool agiabangdongiacongvattu=m_v.sys_dongiacongvattu;
			try
			{
				string aReport ="v_bienlaithuvienphi_giuongyeucau.rpt";
				this.Text=lan.Change_language_MessageText(
"In biên lai thu viện phí trực tiếp (")+aReport+")";
				m_sql = "select  k.tenkp, nvl(l.tenkp,'') tenkpct, a.id, aa.sovaovien, a.sobienlai, nvl(b.soluong,0) soluong, nvl(b.dongia,0) dongia, nvl(b.mien,0) mien, nvl(aaa.sotien,0) tongmien, nvl(b.thieu,0) thieu, nvl(b.vattu,0) vattu, b.madoituong, d.mabn, d.hoten, decode(d.ngaysinh,null,nvl(d.namsinh,a.namsinh),to_char(d.ngaysinh,'dd/mm/yyyy')) ngaysinh, b.mavp, c.ten tenvp, e.ten gioitinh,  f.tentt, g.tenquan,h.tenpxa, a.diachi, d.sonha, d.thon, to_char(a.ngay,'dd/mm/yyyy') ngaythu, j.hoten nguoithu, i.sohieu quyenso, nvl(a.lanin,0)+1 lanin from v_vienphill a, tiepdon aa, v_mienngtru aaa, v_vienphict b,(select id, ten from v_giavp union select id, trim(ten||' '|| hamluong) ten from d_dmbd) c, btdbn d, dmphai e, btdtt f, btdquan g, btdpxa h, v_quyenso i, medibv.v_dlogin j, btdkp_bv k, btdkp_bv l where a.id=b.id(+) and a.maql=aa.maql(+) and a.id=aaa.id(+) and a.mabn=d.mabn(+) and b.mavp=c.id(+) and a.makp=k.makp(+) and d.phai=e.ma(+) and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.quyenso = i.id(+) and a.userid=j.id(+) and b.makp=l.makp(+) and to_char(a.id)='"+v_id+"' order by b.stt";
				if(v_mmyy_only=="")
				{
					v_mmyy_only=DateTime.Now.Year.ToString().Substring(2);
				}
				m_ds = m_v.get_data_mmyy(v_mmyy_only,m_sql);

				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí <")+v_id+">",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="",ahoten="", angaysinh="", agioitinh="", akhoa="",adiachi="", alydo="", alydobh="",asotien="", achutien="", anguoithu="", amasothue="",amauso="",aquyenso="",asobienlai="",acucthue="",atongcuc="",adiachibv="",amabn="", adiengiai="", akhoact="";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				adiachibv = m_v.s_diachi;
				atongcuc = lan.Change_language_MessageText(
"TỔNG CỤC THUẾ");
				acucthue = lan.Change_language_MessageText(
"CỤC THUẾ");
				amasothue=m_v.s_masothue;
				amauso=m_v.s_maubienlai;
				aquyenso=m_ds.Tables[0].Rows[0]["quyenso"].ToString();;
				asobienlai=m_ds.Tables[0].Rows[0]["sobienlai"].ToString();
				angayin=m_ds.Tables[0].Rows[0]["ngaythu"].ToString();
				anguoiin=m_tendangnhap;
				aghichu = "(In lần "+m_ds.Tables[0].Rows[0]["lanin"].ToString()+")";
				amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();
				ahoten=m_ds.Tables[0].Rows[0]["hoten"].ToString();
				angaysinh=m_ds.Tables[0].Rows[0]["ngaysinh"].ToString();
				agioitinh=m_ds.Tables[0].Rows[0]["gioitinh"].ToString();
				akhoa=m_ds.Tables[0].Rows[0]["tenkp"].ToString().Trim();;
				akhoact=m_ds.Tables[0].Rows[0]["tenkpct"].ToString().Trim();
				adiachi=m_ds.Tables[0].Rows[0]["sonha"].ToString().Trim() + " "+ m_ds.Tables[0].Rows[0]["thon"].ToString().Trim();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenpxa"].ToString();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenquan"].ToString();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tentt"].ToString();
				adiachi=adiachi.Trim().Trim(',').Trim();
				if(adiachi.Trim()=="")
				{
					adiachi=m_ds.Tables[0].Rows[0]["diachi"].ToString().Trim();
				}
				alydo="";
				asotien="";
				achutien="";
				anguoithu=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				decimal athucthu=0, atongtien=0, atongmien=0, atongmien1=0, atongthieu=0, atongbhyt=0, asoluong=0, adongia=0, amien=0, athieu=0, abhyt=0,avattu=0;

				try
				{
					atongmien1 = decimal.Parse(m_ds.Tables[0].Rows[0]["tongmien"].ToString());
				}
				catch
				{
					atongmien1=0;
				}
				
				for(int i=0;i<m_ds.Tables[0].Rows.Count;i++)
				{
					if(akhoact.IndexOf(m_ds.Tables[0].Rows[i]["tenkpct"].ToString().Trim())<0)
					{
						akhoact=akhoact.Trim().Trim(',')+", "+m_ds.Tables[0].Rows[i]["tenkpct"].ToString().Trim();
					}
					try
					{
						asoluong = decimal.Parse(m_ds.Tables[0].Rows[i]["soluong"].ToString());
					}
					catch
					{
						asoluong=0;
					}

					try
					{
						adongia = decimal.Parse(m_ds.Tables[0].Rows[i]["dongia"].ToString());
					}
					catch
					{
						adongia=0;
					}

					try
					{
						amien = decimal.Parse(m_ds.Tables[0].Rows[i]["mien"].ToString());
					}
					catch
					{
						amien=0;
					}
					
					try
					{
						athieu = decimal.Parse(m_ds.Tables[0].Rows[i]["thieu"].ToString());
					}
					catch
					{
						athieu=0;
					}
					try
					{
						avattu = decimal.Parse(m_ds.Tables[0].Rows[i]["vattu"].ToString());
					}
					catch
					{
						avattu=0;
					}
					abhyt=0;
					if(m_ds.Tables[0].Rows[i]["madoituong"].ToString()=="1")
					{
						abhyt=amien;
						amien=0;
						alydobh=alydobh.Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[i]["tenvp"].ToString();
						if(asoluong>1)
						{
							alydobh=alydobh + " (" + asoluong.ToString()+")";
						}
						if(ainsotienchitiet)
						{
							alydobh=alydobh+" ["+(asoluong*adongia-amien-athieu).ToString("###,###,##0.##")+"]";
						}

						if(aintungaydenngay)
						{
							alydobh+=" "+f_get_tungaydenngay_giuong(v_mmyy_only,v_id,m_ds.Tables[0].Rows[i]["mavp"].ToString());
						}
						alydobh=alydobh.Trim();
					}
					else
					{
						alydo=alydo.Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[i]["tenvp"].ToString();
						if(asoluong>1)
						{
							alydo=alydo + " (" + asoluong.ToString()+")";
						}
						if(ainsotienchitiet)
						{
							alydo=alydo+" ["+(asoluong*adongia-amien-athieu).ToString("###,###,##0.##")+"]";
						}
						if(aintungaydenngay)
						{
							alydo+=" "+f_get_tungaydenngay_giuong(v_mmyy_only,v_id,m_ds.Tables[0].Rows[i]["mavp"].ToString());
						}
						alydo=alydo.Trim();
					}
					if(agiabangdongiacongvattu)
					{
						adongia+=avattu;
					}
					atongtien = atongtien + asoluong * adongia;
					atongmien = atongmien + amien;
					atongthieu = atongthieu + athieu;
					atongbhyt = atongbhyt + abhyt;
				}
				akhoact=akhoact.Trim().Trim(',');
				if(akhoact!="")
				{
					akhoa=akhoact;
				}

				if(atongmien==0)
				{
					atongmien=atongmien1;
				}

				//MessageBox.Show(atongtien.ToString()+"-"+ atongmien.ToString()+"-"+atongmien1.ToString()+"-"+atongthieu.ToString());
				
				athucthu = atongtien - atongmien - atongbhyt - atongthieu;

				try
				{
					athucthu = decimal.Parse(decimal.Parse(athucthu.ToString()).ToString());
				}
				catch//(Exception exx)
				{
					//MessageBox.Show(exx.ToString());
				}
				asotien = athucthu.ToString();
				achutien = m_v.Doiso_Unicode(athucthu.ToString());
				if(achutien=="")
				{
					achutien=lan.Change_language_MessageText("Không đồng");
				}

				alydo=alydo.Trim().Trim(',');
				alydobh=alydobh.Trim().Trim(',');
				if(alydobh!="")
				{
					alydo=alydo+ lan.Change_language_MessageText(", BHYT(") + alydobh + ")";
				}
				alydo=alydo.Trim().Trim(',');
				alydo=alydo.Trim();

				if((atongmien1>0)||(atongthieu>0)||(atongbhyt>0))
				{
					adiengiai=
lan.Change_language_MessageText("Ghi chú: - Tổng chi phí:")+" " + atongtien.ToString("###,###,###.##")+
lan.Change_language_MessageText("đ");
					if(atongbhyt>0)
					{
						adiengiai=adiengiai+" "+
lan.Change_language_MessageText("- BHYT trả:")+" " + atongbhyt.ToString("###,###,###.##")+
lan.Change_language_MessageText("đ");
					}
					if(atongmien>0)
					{
						adiengiai=adiengiai+" "+
lan.Change_language_MessageText("- Miễn:")+" " + atongmien.ToString("###,###,###.##")+
lan.Change_language_MessageText("đ");
					}
					if(atongthieu>0)
					{
						adiengiai=adiengiai+" "+
lan.Change_language_MessageText("- Bệnh nhân nợ:")+" " + atongthieu.ToString("###,###,###.##")+
lan.Change_language_MessageText("đ");
					}
				}
				DataSet ads = f_Cursor_BienlaiKB();
				DataSet adslien = f_get_Solienkhambenh();
				for(int i=0;i<adslien.Tables[0].Rows.Count;i++)
				{
					DataRow r = ads.Tables[0].NewRow();
					r["syt"]=asyt;
					r["bv"]=abv;
					r["diachibv"]=adiachibv;
					r["tongcucthue"]=atongcuc;
					r["cucthue"]=acucthue;
					r["masothue"]=amasothue;
					r["mauso"]=amauso;
					r["quyenso"]=aquyenso;
					r["sobienlai"]=asobienlai;
					r["ngayin"]=angayin;
					r["nguoiin"]=anguoiin;
					r["ghichu"]=aghichu;
					r["lien"]=adslien.Tables[0].Rows[i][0].ToString().Trim();
					r["mabn"]=amabn;
					r["hoten"]=ahoten;
					r["ngaysinh"]=angaysinh;
					r["gioitinh"]=agioitinh;
					r["khoa"]=akhoa;
					r["diachi"]=adiachi;
					r["lydo"]=alydo;
					r["sotien"]=asotien;
					r["chutien"]=achutien;
					r["nguoithu"]=anguoithu;
					r["diengiai"]=adiengiai;
					ads.Tables[0].Rows.Add(r);
				}
				
				//ads.WriteXml("..\\..\\DataReport\\v_bienlaithuvienphi.xml",XmlWriteMode.WriteSchema);
				//return;
				ReportDocument cMain=new ReportDocument();
				try
				{
					cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				}
				catch
				{
					System.IO.File.Copy("..\\..\\..\\report\\"+aReport.Replace("_giuongyeucau",""),"..\\..\\..\\report\\"+aReport,false);
					cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				}
				cMain.SetDataSource(ads);
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
                m_v.execute_data_mmyy(v_mmyy_only, "update medibvmmyy.v_vienphill set lanin=nvl(lanin,0)+1 where to_char(id)='" + v_id + "'");
                cMain.Close(); cMain.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_BienlaiKB_Tichkexetnghiem(bool v_dir, string v_id, string v_mmyy_only)
		{
			bool ainsotienchitiet=f_insotienchitiettronghoadonthutructiep();
			bool aintungaydenngay=f_intungaydenngay_thutructiep();
			bool agiabangdongiacongvattu=m_v.sys_dongiacongvattu;
			try
			{
				string aReport ="v_bienlaithuvienphi_tichkexetnghiem.rpt";
				this.Text=lan.Change_language_MessageText(
"In biên lai thu viện phí trực tiếp (")+aReport+")";
				m_sql = "select  k.tenkp, nvl(l.tenkp,'') tenkpct, a.id, aa.sovaovien, a.sobienlai, nvl(b.soluong,0) soluong, nvl(b.dongia,0) dongia, nvl(b.mien,0) mien, nvl(aaa.sotien,0) tongmien, nvl(b.thieu,0) thieu, nvl(b.vattu,0) vattu, b.madoituong, d.mabn, d.hoten, decode(d.ngaysinh,null,nvl(d.namsinh,a.namsinh),to_char(d.ngaysinh,'dd/mm/yyyy')) ngaysinh, b.mavp, c.ten tenvp, e.ten gioitinh,  f.tentt, g.tenquan,h.tenpxa, a.diachi, d.sonha, d.thon, to_char(a.ngay,'dd/mm/yyyy') ngaythu, j.hoten nguoithu, i.sohieu quyenso, aaaa.sothe, to_char(aaaa.denngay,'dd/mm/yyyy') denngay, nvl(a.lanin,0)+1 lanin from v_vienphill a, tiepdon aa, v_mienngtru aaa, bhyt aaaa, v_vienphict b,(select id, ten from v_giavp union select id, trim(ten||' '|| hamluong) ten from d_dmbd) c, btdbn d, dmphai e, btdtt f, btdquan g, btdpxa h, v_quyenso i, medibv.v_dlogin j, btdkp_bv k, btdkp_bv l where a.id=b.id(+) and a.maql=aa.maql(+) and a.id=aaa.id(+) and a.mabn=aaaa.mabn(+) and a.maql=aaaa.maql(+) and a.mabn=d.mabn(+) and b.mavp=c.id(+) and a.makp=k.makp(+) and d.phai=e.ma(+) and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.quyenso = i.id(+) and a.userid=j.id(+) and b.makp=l.makp(+) and to_char(a.id)='"+v_id+"' order by b.stt";
				if(v_mmyy_only=="")
				{
					v_mmyy_only=DateTime.Now.Year.ToString().Substring(2);
				}
				m_ds = m_v.get_data_mmyy(v_mmyy_only,m_sql);

				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy chứng  từ thu viện phí <")+v_id+">",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="",ahoten="", angaysinh="", agioitinh="", akhoa="",adiachi="", alydo="", alydobh="",asotien="", achutien="", anguoithu="", amasothue="",amauso="",aquyenso="",asobienlai="",acucthue="",atongcuc="",adiachibv="",amabn="", adiengiai="", akhoact="";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				adiachibv = m_v.s_diachi;
				atongcuc = lan.Change_language_MessageText(
"TỔNG CỤC THUẾ");
				acucthue = lan.Change_language_MessageText(
"CỤC THUẾ");
				amasothue=m_v.s_masothue;
				amauso=m_v.s_maubienlai;
				aquyenso=m_ds.Tables[0].Rows[0]["quyenso"].ToString();;
				asobienlai=m_ds.Tables[0].Rows[0]["sobienlai"].ToString();
				angayin=m_ds.Tables[0].Rows[0]["ngaythu"].ToString();
				anguoiin=m_tendangnhap;
				aghichu = "(In lần "+m_ds.Tables[0].Rows[0]["lanin"].ToString()+")";
				amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();
				ahoten=m_ds.Tables[0].Rows[0]["hoten"].ToString();
				angaysinh=m_ds.Tables[0].Rows[0]["ngaysinh"].ToString();
				agioitinh=m_ds.Tables[0].Rows[0]["gioitinh"].ToString();
				akhoa=m_ds.Tables[0].Rows[0]["tenkp"].ToString().Trim();;
				akhoact=m_ds.Tables[0].Rows[0]["tenkpct"].ToString().Trim();
				adiachi=m_ds.Tables[0].Rows[0]["sonha"].ToString().Trim() + " "+ m_ds.Tables[0].Rows[0]["thon"].ToString().Trim();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenpxa"].ToString();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenquan"].ToString();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tentt"].ToString();
				adiachi=adiachi.Trim().Trim(',').Trim();
				adiengiai=m_ds.Tables[0].Rows[0]["sothe"].ToString()+":"+m_ds.Tables[0].Rows[0]["denngay"].ToString();
				if(adiachi.Trim()=="")
				{
					adiachi=m_ds.Tables[0].Rows[0]["diachi"].ToString().Trim();
				}
				alydo="";
				asotien="";
				achutien="";
				anguoithu=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				decimal athucthu=0, atongtien=0, atongmien=0, atongmien1=0, atongthieu=0, atongbhyt=0, asoluong=0, adongia=0, amien=0, athieu=0, abhyt=0,avattu=0;

				try
				{
					atongmien1 = decimal.Parse(m_ds.Tables[0].Rows[0]["tongmien"].ToString());
				}
				catch
				{
					atongmien1=0;
				}
				
				for(int i=0;i<m_ds.Tables[0].Rows.Count;i++)
				{
					if(akhoact.IndexOf(m_ds.Tables[0].Rows[i]["tenkpct"].ToString().Trim())<0)
					{
						akhoact=akhoact.Trim().Trim(',')+", "+m_ds.Tables[0].Rows[i]["tenkpct"].ToString().Trim();
					}
					try
					{
						asoluong = decimal.Parse(m_ds.Tables[0].Rows[i]["soluong"].ToString());
					}
					catch
					{
						asoluong=0;
					}

					try
					{
						adongia = decimal.Parse(m_ds.Tables[0].Rows[i]["dongia"].ToString());
					}
					catch
					{
						adongia=0;
					}

					try
					{
						amien = decimal.Parse(m_ds.Tables[0].Rows[i]["mien"].ToString());
					}
					catch
					{
						amien=0;
					}
					
					try
					{
						athieu = decimal.Parse(m_ds.Tables[0].Rows[i]["thieu"].ToString());
					}
					catch
					{
						athieu=0;
					}
					try
					{
						avattu = decimal.Parse(m_ds.Tables[0].Rows[i]["vattu"].ToString());
					}
					catch
					{
						avattu=0;
					}
					abhyt=0;
					if(m_ds.Tables[0].Rows[i]["madoituong"].ToString()=="1")
					{
						abhyt=amien;
						amien=0;
						alydobh=alydobh.Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[i]["tenvp"].ToString();
						if(asoluong>1)
						{
							alydobh=alydobh + " (" + asoluong.ToString()+")";
						}
						if(ainsotienchitiet)
						{
							alydobh=alydobh+" ["+(asoluong*adongia-amien-athieu).ToString("###,###,##0.##")+"]";
						}

						if(aintungaydenngay)
						{
							alydobh+=" "+f_get_tungaydenngay_giuong(v_mmyy_only,v_id,m_ds.Tables[0].Rows[i]["mavp"].ToString());
						}
						alydobh=alydobh.Trim();
					}
					else
					{
						alydo=alydo.Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[i]["tenvp"].ToString();
						if(asoluong>1)
						{
							alydo=alydo + " (" + asoluong.ToString()+")";
						}
						if(ainsotienchitiet)
						{
							alydo=alydo+" ["+(asoluong*adongia-amien-athieu).ToString("###,###,##0.##")+"]";
						}
						if(aintungaydenngay)
						{
							alydo+=" "+f_get_tungaydenngay_giuong(v_mmyy_only,v_id,m_ds.Tables[0].Rows[i]["mavp"].ToString());
						}
						alydo=alydo.Trim();
					}
					if(agiabangdongiacongvattu)
					{
						adongia+=avattu;
					}
					atongtien = atongtien + asoluong * adongia;
					atongmien = atongmien + amien;
					atongthieu = atongthieu + athieu;
					atongbhyt = atongbhyt + abhyt;
				}
				akhoact=akhoact.Trim().Trim(',');
				if(akhoact!="")
				{
					akhoa=akhoact;
				}

				if(atongmien==0)
				{
					atongmien=atongmien1;
				}

				//MessageBox.Show(atongtien.ToString()+"-"+ atongmien.ToString()+"-"+atongmien1.ToString()+"-"+atongthieu.ToString());
				
				athucthu = atongtien - atongmien - atongbhyt - atongthieu;

				try
				{
					athucthu = decimal.Parse(decimal.Parse(athucthu.ToString()).ToString());
				}
				catch//(Exception exx)
				{
					//MessageBox.Show(exx.ToString());
				}
				asotien = athucthu.ToString();
				achutien = m_v.Doiso_Unicode(athucthu.ToString());
				if(achutien=="")
				{
					achutien=lan.Change_language_MessageText("Không đồng");
				}

				alydo=alydo.Trim().Trim(',');
				alydobh=alydobh.Trim().Trim(',');
				if(alydobh!="")
				{
					alydo=alydo+ lan.Change_language_MessageText(
", BHYT(") + alydobh + ")";
				}
				alydo=alydo.Trim().Trim(',');
				alydo=alydo.Trim();

				if((atongmien1>0)||(atongthieu>0)||(atongbhyt>0))
				{
					/*
					adiengiai="Ghi chú: - Tổng chi phí: " + atongtien.ToString("###,###,###.##")+"đ";
					if(atongbhyt>0)
					{
						adiengiai=adiengiai+" - BHYT trả: " + atongbhyt.ToString("###,###,###.##")+"đ";
					}
					if(atongmien>0)
					{
						adiengiai=adiengiai+" - Miễn: " + atongmien.ToString("###,###,###.##")+"đ";
					}
					if(atongthieu>0)
					{
						adiengiai=adiengiai+" - Bệnh nhân nợ: " + atongthieu.ToString("###,###,###.##")+"đ";
					}
					*/
				}
				DataSet ads = f_Cursor_BienlaiKB();
				DataSet adslien = f_get_Solienkhambenh_tichkexetnghiem();
				for(int i=0;i<adslien.Tables[0].Rows.Count;i++)
				{
					DataRow r = ads.Tables[0].NewRow();
					r["syt"]=asyt;
					r["bv"]=abv;
					r["diachibv"]=adiachibv;
					r["tongcucthue"]=atongcuc;
					r["cucthue"]=acucthue;
					r["masothue"]=amasothue;
					r["mauso"]=amauso;
					r["quyenso"]=aquyenso;
					r["sobienlai"]=asobienlai;
					r["ngayin"]=angayin;
					r["nguoiin"]=anguoiin;
					r["ghichu"]=aghichu;
					r["lien"]=adslien.Tables[0].Rows[i][0].ToString().Trim();
					r["mabn"]=amabn;
					r["hoten"]=ahoten;
					r["ngaysinh"]=angaysinh;
					r["gioitinh"]=agioitinh;
					r["khoa"]=akhoa;
					r["diachi"]=adiachi;
					r["lydo"]=alydo;
					r["sotien"]=asotien;
					r["chutien"]=achutien;
					r["nguoithu"]=anguoithu;
					r["diengiai"]=adiengiai;
					ads.Tables[0].Rows.Add(r);
				}
				try
				{
				}
				catch
				{
				}
				//ads.WriteXml("..\\..\\DataReport\\v_bienlaithuvienphi.xml",XmlWriteMode.WriteSchema);
				//return;
				ReportDocument cMain=new ReportDocument();
				try
				{
					cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				}
				catch
				{
					System.IO.File.Copy("..\\..\\..\\report\\"+aReport.Replace("_tichkexetnghiem",""),"..\\..\\..\\report\\"+aReport,false);
					cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				}
				cMain.SetDataSource(ads);
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
                m_v.execute_data_mmyy(v_mmyy_only, "update medibvmmyy.v_vienphill set lanin=nvl(lanin,0)+1 where to_char(id)='" + v_id + "'");
                cMain.Close(); cMain.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_ChiphiKB(bool v_dir, string v_id, string v_mmyy_only)
		{
			try
			{
				this.Text="Bảng kê chi phí điều trị ngoại trú (v_thanhtoantructiep.rpt)";
				string aReport ="v_thanhtoantructiep.rpt";

				m_sql = "select a.id, a.mabn, d.hoten, d.namsinh, f.tentt tinh, g.tenquan quan,h.tenpxa xa, d.sonha, d.thon, n.ten gioitinh, nvl(l.sothe,'. . . . . . . . . . . . . . . . . .') mabhyt, nvl(to_char(l.denngay,'dd/mm/yyyy'),'. . . . . . . . . . . . . . . . . .') giatriden, e.tenkp, to_char(a.ngay,'dd/mm/yyyy') ngay, i.id id_vp, j.id id_loai, k.ma id_nhom, i.ten tenvp, j.ten tenloaivp, k.ten tennhomvp, i.stt sttvp, j.stt sttloaivp, k.stt sttnhomvp, i.dvt, nvl(b.soluong,0) soluong, nvl(b.dongia,0) dongia, (nvl(b.soluong,0)*nvl(b.dongia,0)) sotien, decode(b.madoituong,1,nvl(b.mien,0),0) bhtra, nvl(b.mien,0) mien, nvl(b.thieu,0) thieu, nvl(c.sotien,0) tongmien, b.madoituong, m.hoten nguoithu from v_vienphill a, v_vienphict b, v_mienngtru c, btdbn d, btdkp_bv e, btdtt f, btdquan g, btdpxa h, (select id, stt, ten, dvt, id_loai from v_giavp union select id, rownum stt, trim(ten||' '|| hamluong) ten, dang dvt, 0 id_loai from d_dmbd) i, (select id, id_nhom, stt, ten from v_loaivp union all select 0 id, 0 id_nhom, 1 stt, null ten from dual) j, (select ma, ten, stt from v_nhomvp union all select 0 ma, null ten, 1 stt from dual) k, bhyt l, medibv.v_dlogin m, dmphai n where a.id=b.id and a.id=c.id(+) and a.mabn=d.mabn(+) and d.phai=n.ma(+) and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.makp=e.makp(+) and a.userid=m.id(+) and b.mavp=i.id(+) and i.id_loai = j.id(+) and j.id_nhom=k.ma(+) and a.maql=l.maql(+) and to_char(a.id)='"+v_id+"'";
				if(v_mmyy_only=="")
				{
                    m_ds = m_v.get_data_mmyy(m_sql, m_v.DateToString("dd/MM/yyyy", DateTime.Now), m_v.DateToString("dd/MM/yyyy", DateTime.Now), true);
				}
				else
				{
                    m_ds = m_v.get_data_mmyy(v_mmyy_only, m_sql);
				}
				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy chứng  từ thanh toán ra viện ngoại trú <")+v_id+">",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				
				string asyt="",abv="",angayin="", anguoiin="",aghichu="";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				
				angayin=f_GetNgay(m_ds.Tables[0].Rows[0]["ngay"].ToString());
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(m_ds);
				cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
				cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
				cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
                cMain.Close(); cMain.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_ChiphiKBCT(bool v_dir, string v_id, string v_mmyy_only)
		{
			try
			{
				this.Text=lan.Change_language_MessageText(
                "Bảng kê chi phí điều trị ngoại trú (v_thanhtoantructiep_chitiet.rpt)");
				string aReport ="v_thanhtoantructiep_chitiet.rpt";
				m_sql = "select a.id, a.mabn, d.hoten, d.namsinh, f.tentt tinh, g.tenquan quan,h.tenpxa xa, d.sonha, d.thon, n.ten gioitinh, nvl(l.sothe,'. . . . . . . . . . . . . . . . . .') mabhyt, nvl(to_char(l.denngay,'dd/mm/yyyy'),'. . . . . . . . . . . . . . . . . .') giatriden, e.tenkp, to_char(a.ngay,'dd/mm/yyyy') ngay, i.id id_vp, j.id id_loai, k.ma id_nhom, i.ten tenvp, j.ten tenloaivp, k.ten tennhomvp, i.stt sttvp, j.stt sttloaivp, k.stt sttnhomvp, i.dvt, nvl(b.soluong,0) soluong, nvl(b.dongia,0) dongia, (nvl(b.soluong,0)*nvl(b.dongia,0)) sotien, decode(b.madoituong,1,nvl(b.mien,0),0) bhtra, nvl(b.mien,0) mien, nvl(b.thieu,0) thieu, nvl(c.sotien,0) tongmien, b.madoituong, m.hoten nguoithu from v_vienphill a, v_vienphict b, v_mienngtru c, btdbn d, btdkp_bv e, btdtt f, btdquan g, btdpxa h, (select id, stt, ten, dvt, id_loai from v_giavp union select id, rownum stt, trim(ten||' '|| hamluong) ten, dang dvt, 0 id_loai from d_dmbd) i, (select id, id_nhom, stt, ten from v_loaivp union all select 0 id, 0 id_nhom, 1 stt, null ten from dual) j, (select ma, ten, stt from v_nhomvp union all select 0 ma, null ten, 1 stt from dual) k, bhyt l, medibv.v_dlogin m, dmphai n where a.id=b.id and a.id=c.id(+) and a.mabn=d.mabn(+) and d.phai=n.ma(+) and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.makp=e.makp(+) and a.userid=m.id(+) and b.mavp=i.id(+) and i.id_loai = j.id(+) and j.id_nhom=k.ma(+) and a.maql=l.maql(+) and to_char(a.id)='"+v_id+"'";
				if(v_mmyy_only=="")
				{
                    m_ds = m_v.get_data_mmyy(m_sql, m_v.DateToString("dd/MM/yyyy", DateTime.Now), m_v.DateToString("dd/MM/yyyy", DateTime.Now), true);
				}
				else
				{
					m_ds = m_v.get_data_mmyy(v_mmyy_only,m_sql);
				}
				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy chứng  từ thanh toán ra viện ngoại trú <")+v_id+">",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				string asyt="",abv="",angayin="",anguoiin="",aghichu="";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				
				angayin=f_GetNgay(m_ds.Tables[0].Rows[0]["ngay"].ToString());
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(m_ds);
				cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
				cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
				cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
                cMain.Close(); cMain.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		private DataSet f_Cursor_BienlaiTU()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.Tables.Add("BienLaiTamUng");
				ads.Tables[0].Columns.Add("syt");
				ads.Tables[0].Columns.Add("bv");
				ads.Tables[0].Columns.Add("diachibv");
				ads.Tables[0].Columns.Add("tongcucthue");
				ads.Tables[0].Columns.Add("cucthue");
				ads.Tables[0].Columns.Add("masothue");
				ads.Tables[0].Columns.Add("mauso");
				ads.Tables[0].Columns.Add("quyenso");
				ads.Tables[0].Columns.Add("sobienlai");
				ads.Tables[0].Columns.Add("ngayin");
				ads.Tables[0].Columns.Add("nguoiin");
				ads.Tables[0].Columns.Add("ghichu");
				ads.Tables[0].Columns.Add("lien");
				ads.Tables[0].Columns.Add("mabn");
				ads.Tables[0].Columns.Add("hoten");
				ads.Tables[0].Columns.Add("ngaysinh");
				ads.Tables[0].Columns.Add("gioitinh");
				ads.Tables[0].Columns.Add("khoa");
				ads.Tables[0].Columns.Add("diachi");
				ads.Tables[0].Columns.Add("lydo");
				ads.Tables[0].Columns.Add("sotien");
				ads.Tables[0].Columns.Add("chutien");
				ads.Tables[0].Columns.Add("nguoithu");
				ads.Tables[0].Columns.Add("lanin");//binh
				return ads;
			}
			catch
			{
				return null;
			}
		}
		private string f_get_lydotamung(string v_id, string v_mmyy_only)
		{
			string r="", sql;
			bool ab = m_v.sys_insotienchitiet_tamung;
			try
			{
				DataSet ads = new DataSet();
				string aloaivp=m_v.sys_tamungchitiettheo_1loai_2nhom=="1"?"v_loaivp":"(select ma id,ten from v_nhomvp)";
				sql="select a.sotien,b.ten from v_tamungct a, v_loaivp b where a.loaivp=b.id and to_char(a.id)='"+v_id+"'";

				if(v_mmyy_only=="")
				{
					ads = m_v.get_data_bc(DateTime.Now,DateTime.Now,sql);
				}
				else
				{
					ads = m_v.get_data_mmyy(v_mmyy_only,sql);
				}
				foreach(DataRow r1 in ads.Tables[0].Rows)
				{
					r=r.Trim().Trim(',').Trim()+", "+r1["ten"].ToString();
					if(ab) r=r+":"+decimal.Parse(r1["sotien"].ToString()).ToString("###,###,###");
				}
				r=r.Trim().Trim(',').Trim();
				r=r.Trim().Trim('-').Trim();
				if(r=="")
				{
					r=lan.Change_language_MessageText(
"Tạm ứng nhập viện");
				}
				else
				{
					r=r.Trim(',').Trim();
				}
			}
			catch//(Exception ex)
			{
				//MessageBox.Show(ex.ToString());
				r=lan.Change_language_MessageText("Thu tiền tạm ứng");
			}
			string s_dot=f_dot_tamung(v_id,v_mmyy_only);
			if(s_dot!="")r+=" ("+s_dot+")";
			return r;
		}
		public void f_Print_BienlaiTU(bool v_dir, string v_id, string v_mmyy_only)
		{
			try
			{
				this.Text=lan.Change_language_MessageText("In biên lai thu tạm ứng (v_bienlaitamung.rpt)");
				string aReport ="v_bienlaitamung.rpt";

                m_sql = "select  a.id, a.mabn, a.sobienlai, a.sotien, to_char(a.ngay,'dd/mm/yyyy') as ngay, b.tenkp, d.mabn, d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso, a.lanin+1 as lanin from medibvmmyy.v_tamung a left join medibv.btdkp_bv b on a.makp=b.makp left join medibv.btdbn d on a.mabn=d.mabn left join medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on a.quyenso=i.id left join medibv.v_dlogin j on a.userid=j.id where a.id=" + v_id + "";
                if (v_mmyy_only == "")
				{
                    m_ds = m_v.get_data_mmyy(m_sql, m_v.DateToString("dd/MM/yyyy", DateTime.Now), m_v.DateToString("dd/MM/yyyy", DateTime.Now), true);
				}
				else
				{
					m_ds = m_v.get_data_mmyy(v_mmyy_only,m_sql);
				}
				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy chứng  từ thu tạm ứng <")+v_id+">",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				string asyt="",abv="",angayin="",anguoiin="",aghichu="",ahoten="", angaysinh="", agioitinh="", akhoa="",adiachi="", alydo="",asotien="", achutien="", anguoithu="", amasothue="",amauso="",aquyenso="",asobienlai="",acucthue="",atongcuc="",adiachibv="",amabn="",alanin="1";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				
				angayin=m_ds.Tables[0].Rows[0]["ngay"].ToString();
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";
				ahoten=m_ds.Tables[0].Rows[0]["hoten"].ToString();
				angaysinh=m_ds.Tables[0].Rows[0]["ngaysinh"].ToString();
				agioitinh=m_ds.Tables[0].Rows[0]["gioitinh"].ToString();
				akhoa=m_ds.Tables[0].Rows[0]["tenkp"].ToString().Trim();;
				adiachi=m_ds.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenquan"].ToString();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tentt"].ToString();
				adiachi=adiachi.Trim().Trim(',').Trim();
				alydo=f_get_lydotamung(v_id,v_mmyy_only);//"Thu tiền tạm ứng";
				alanin=m_ds.Tables[0].Rows[0]["lanin"].ToString();
				asotien=m_ds.Tables[0].Rows[0]["sotien"].ToString();
				achutien="";
				anguoithu=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				amasothue=m_v.s_masothue;
				amauso=m_v.s_maubienlai;
				aquyenso=m_ds.Tables[0].Rows[0]["quyenso"].ToString();;
				asobienlai=m_ds.Tables[0].Rows[0]["sobienlai"].ToString();
				acucthue=lan.Change_language_MessageText(
"CỤC THUẾ");
				atongcuc=lan.Change_language_MessageText(
"TỔNG CỤC THUẾ");
				adiachibv=m_v.s_diachi;
				amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();

				asotien = decimal.Parse(asotien.ToString()).ToString("#########");// + lan.Change_language_MessageText("đồng");
				achutien = m_v.Doiso_Unicode(asotien.Replace(",",""));

				DataSet ads = f_Cursor_BienlaiTU();
				DataSet adslien = f_get_Solientamung();
				for(int i=0;i<adslien.Tables[0].Rows.Count;i++)
				{
					DataRow r = ads.Tables[0].NewRow();
					r["syt"]=asyt;
					r["bv"]=abv;
					r["diachibv"]=adiachibv;
					r["tongcucthue"]=atongcuc;
					r["cucthue"]=acucthue;
					r["masothue"]=amasothue;
					r["mauso"]=amauso;
					r["quyenso"]=aquyenso;
					r["sobienlai"]=asobienlai;
					r["ngayin"]=angayin;
					r["nguoiin"]=anguoiin;
					r["ghichu"]=aghichu;
					r["lien"]=adslien.Tables[0].Rows[i][0].ToString().Trim();
					r["mabn"]=amabn;
					r["hoten"]=ahoten;
					r["ngaysinh"]=angaysinh;
					r["gioitinh"]=agioitinh;
					r["khoa"]=akhoa;
					r["diachi"]=adiachi;
					r["lydo"]=alydo;
					r["sotien"]=asotien;
					r["chutien"]=achutien;
					r["nguoithu"]=anguoithu;
					r["lanin"]=alanin;
					ads.Tables[0].Rows.Add(r);
				}
				//ads.WriteXml("v_bienlaitamung.xml",XmlWriteMode.WriteSchema);
				ReportDocument cMain=new ReportDocument();
				cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(ads);
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
                m_v.execute_data_mmyy(v_mmyy_only, "update medibvmmyy.v_tamung set lanin=nvl(lanin,0)+1 where to_char(id)='" + v_id + "'");
                cMain.Close(); cMain.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		private DataSet f_Cursor_BienlaiNT()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.Tables.Add("BienLaiTamUng");
				ads.Tables[0].Columns.Add("syt");
				ads.Tables[0].Columns.Add("bv");
				ads.Tables[0].Columns.Add("diachibv");
				ads.Tables[0].Columns.Add("tongcucthue");
				ads.Tables[0].Columns.Add("cucthue");
				ads.Tables[0].Columns.Add("masothue");
				ads.Tables[0].Columns.Add("mauso");
				ads.Tables[0].Columns.Add("quyenso");
				ads.Tables[0].Columns.Add("sobienlai");
				ads.Tables[0].Columns.Add("ngayin");
				ads.Tables[0].Columns.Add("nguoiin");
				ads.Tables[0].Columns.Add("ghichu");
				ads.Tables[0].Columns.Add("lien");
				ads.Tables[0].Columns.Add("mabn");
				ads.Tables[0].Columns.Add("hoten");
				ads.Tables[0].Columns.Add("ngaysinh");
				ads.Tables[0].Columns.Add("gioitinh");
				ads.Tables[0].Columns.Add("khoa");
				ads.Tables[0].Columns.Add("diachi");
				ads.Tables[0].Columns.Add("lydo");
				ads.Tables[0].Columns.Add("sotien");
				ads.Tables[0].Columns.Add("chutien");
				ads.Tables[0].Columns.Add("tongcp");
				ads.Tables[0].Columns.Add("tamung");
				ads.Tables[0].Columns.Add("bhyt");
				ads.Tables[0].Columns.Add("mien");
				ads.Tables[0].Columns.Add("lydomien");
				ads.Tables[0].Columns.Add("nguoithu");
				return ads;
			}
			catch
			{
				return null;
			}
		}
		public void f_Print_PhieuChi(bool v_dir, string v_id, string v_mmyy_only)
		{
			try
			{
				this.Text=lan.Change_language_MessageText(
"Phiếu chi tiền viện phí (v_phieuchi.rpt)");
				string aReport ="v_phieuchi.rpt";

				m_sql = "select a.id, a.mabn, a.sobienlai, a.ghichu, nvl(a.sotien,0) sotien, to_char(a.ngay,'dd/mm/yyyy') ngay, d.mabn, d.hoten, decode(d.ngaysinh,null,d.namsinh,to_char(d.ngaysinh,'dd/mm/yyyy')) ngaysinh, e.ten gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') ngaythu, j.hoten nguoithu, i.sohieu quyenso from v_hoantra a, btdbn d, dmphai e, btdtt f, btdquan g, btdpxa h, v_quyenso i, medibv.v_dlogin j where a.mabn=d.mabn and d.phai=e.ma and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.quyenso = i.id and a.userid=j.id(+) and to_char(a.id)='"+v_id+"'";
				if(v_mmyy_only=="")
				{
					m_ds = m_v.get_data_bc(DateTime.Now,DateTime.Now,m_sql);
				}
				else
				{
					m_ds = m_v.get_data_mmyy(v_mmyy_only,m_sql);
				}
				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy hoá đơn hoàn trả <")+v_id+">",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				//m_ds.WriteXml("..\\v_rptBienlaiKB.xml",XmlWriteMode.WriteSchema);
				//return;
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="",ahoten="", angaysinh="", agioitinh="", akhoa="",adiachi="", alydo="",asotien="", achutien="", achutientu="", anguoithu="", amasothue="",amauso="",aquyenso="",asobienlai="",acucthue="",atongcuc="",adiachibv="",amabn="", atongcp="", atamung="", abhyt="",amien="", alydomien="";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				
				angayin=f_GetNgay(m_ds.Tables[0].Rows[0]["ngay"].ToString());
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";
				ahoten=m_ds.Tables[0].Rows[0]["hoten"].ToString();
				angaysinh=m_ds.Tables[0].Rows[0]["ngaysinh"].ToString();
				agioitinh=m_ds.Tables[0].Rows[0]["gioitinh"].ToString();
				akhoa="";
				adiachi=m_ds.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenquan"].ToString();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText(
"Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tentt"].ToString();
				adiachi=adiachi.Trim().Trim(',').Trim();
				alydo=m_ds.Tables[0].Rows[0]["ghichu"].ToString();
				asotien=m_ds.Tables[0].Rows[0]["sotien"].ToString();
				atongcp=m_ds.Tables[0].Rows[0]["sotien"].ToString();
				atamung=m_ds.Tables[0].Rows[0]["sotien"].ToString();
				abhyt=m_ds.Tables[0].Rows[0]["sotien"].ToString();
				amien=m_ds.Tables[0].Rows[0]["sotien"].ToString();
				alydomien="";//m_ds.Tables[0].Rows[0]["lydomien"].ToString();
				achutien="";
				anguoithu=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				amasothue=m_v.s_masothue;
				amauso=m_v.s_maubienlai;
				aquyenso=m_ds.Tables[0].Rows[0]["quyenso"].ToString();;
				asobienlai=m_ds.Tables[0].Rows[0]["sobienlai"].ToString();
				acucthue=lan.Change_language_MessageText(
"CỤC THUẾ");
				atongcuc=lan.Change_language_MessageText(
"TỔNG CỤC THUẾ");
				adiachibv=m_v.s_diachi;
				amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();
				
				try
				{
					atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,###.##").PadRight(20,'.');
					atongcp=atongcp.Substring(0,atongcp.IndexOf("."));
				}
				catch
				{
					atongcp="0";
				}
				if(atongcp=="") atongcp="0";
				achutien = m_v.Doiso_Unicode(atongcp.Replace(",",""));
				atongcp = atongcp+lan.Change_language_MessageText(
"đồng");

				try
				{
					atamung = decimal.Parse(atamung.ToString()).ToString("###,###,###.##").PadRight(20,'.');
					atamung=atamung.Substring(0,atamung.IndexOf("."));
				}
				catch
				{
					atamung="0";
				}
				//MessageBox.Show(atamung.Replace(",",""));
				if(atamung=="") atamung="0";
				achutientu = m_v.Doiso_Unicode(atamung.Replace(",",""));

				asotien = decimal.Parse(asotien.ToString()).ToString("###,###,###").Length>0?decimal.Parse(asotien.ToString()).ToString("###,###,###")+lan.Change_language_MessageText("đồng"): lan.Change_language_MessageText("0đồng");
				atamung = decimal.Parse(atamung.ToString()).ToString("###,###,###").Length>0?decimal.Parse(atamung.ToString()).ToString("###,###,###")+lan.Change_language_MessageText("đồng"): lan.Change_language_MessageText("0đồng");
				abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,###").Length>0?decimal.Parse(abhyt.ToString()).ToString("###,###,###")+lan.Change_language_MessageText("đồng"): lan.Change_language_MessageText("0đồng");
				amien = decimal.Parse(amien.ToString()).ToString("###,###,###").Length>0?decimal.Parse(amien.ToString()).ToString("###,###,###")+lan.Change_language_MessageText("đồng"): lan.Change_language_MessageText("0đồng");

				DataSet ads = f_Cursor_BienlaiNT();
				DataSet adslien = f_get_Solienphieuchi();
				for(int i=0;i<adslien.Tables[0].Rows.Count;i++)
				{
					DataRow r = ads.Tables[0].NewRow();
					r["syt"]=asyt;
					r["bv"]=abv;
					r["diachibv"]=adiachibv;
					r["tongcucthue"]=atongcuc;
					r["cucthue"]=acucthue;
					r["masothue"]=amasothue;
					r["mauso"]=amauso;
					r["quyenso"]=aquyenso;
					r["sobienlai"]=asobienlai;
					r["ngayin"]=angayin;
					r["nguoiin"]=anguoiin;
					r["ghichu"]=aghichu;
					r["lien"]=adslien.Tables[0].Rows[i][0].ToString();
					r["mabn"]=amabn;
					r["hoten"]=ahoten;
					r["ngaysinh"]=angaysinh;
					r["gioitinh"]=agioitinh;
					r["khoa"]=akhoa;
					r["diachi"]=adiachi;
					r["lydo"]=alydo;
					r["sotien"]=asotien;
					r["chutien"]=achutien;
					r["tongcp"]=atongcp;
					r["tamung"]=atamung;
					r["bhyt"]=abhyt;
					r["mien"]=amien;
					r["lydomien"]=alydomien;
					r["nguoithu"]=anguoithu;
					ads.Tables[0].Rows.Add(r);
				}
				//ads.WriteXml("..\\..\\datareport\\v_bienlaithuvienphint.xml",XmlWriteMode.WriteSchema);
				//return;

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(ads);
				cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				aReport ="v_phieuchi.rpt";
				cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(ads);
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
                cMain.Close(); cMain.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}

		private string f_get_lydo_noitru(string v_id, string v_mmyy_only)
		{
			try
			{
				DataSet ads = new DataSet();
				string alydo="";
				if(!m_bienlainoitru_inchitiet)
				{
					if(v_mmyy_only=="")
					{
						ads= m_v.get_data_bc(DateTime.Now,DateTime.Now,"select c.id, c.ten from v_ttrvct a, (select id, id_loai from v_giavp union all select id, 0 id_loai from d_dmbd) b, (select id, ten from v_loaivp union all select 0 id, null ten from dual) c where a.mavp=b.id and b.id_loai=c.id(+) and to_char(a.id)='"+v_id+"' group by c.id, c.ten");
					}
					else
					{
						ads= m_v.get_data_mmyy(v_mmyy_only,"select c.id, c.ten from v_ttrvct a, (select id, id_loai from v_giavp union all select id, 0 id_loai from d_dmbd) b, (select id, ten from v_loaivp union all select 0 id, null ten from dual) c where a.mavp=b.id and b.id_loai=c.id(+) and to_char(a.id)='"+v_id+"' group by c.id, c.ten");
					}
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						if(ads.Tables[0].Rows[i]["id"].ToString().Trim()=="0")
						{
							ads.Tables[0].Rows[i]["ten"]=lan.Change_language_MessageText(
"Thuốc");
						}
						alydo=alydo.Trim().Trim(',')+ ", " + ads.Tables[0].Rows[i]["ten"].ToString();
					}
				}
				else
				{
					int ancol=0;
					if(v_mmyy_only=="")
					{
						ads= m_v.get_data_bc(DateTime.Now,DateTime.Now,"select c.id, c.ten from v_ttrvct a, (select id, id_loai from v_giavp union all select id, 0 id_loai from d_dmbd) b, (select id, ten from v_loaivp union all select 0 id, null ten from dual) c where a.mavp=b.id and b.id_loai=c.id(+) and to_char(a.id)='"+v_id+"' group by c.id, c.ten");
					}
					else
					{
						ads= m_v.get_data_mmyy(v_mmyy_only,"select c.id, c.ten from v_ttrvct a, (select id, id_loai from v_giavp union all select id, 0 id_loai from d_dmbd) b, (select id, ten from v_loaivp union all select 0 id, null ten from dual) c where a.mavp=b.id and b.id_loai=c.id(+) and to_char(a.id)='"+v_id+"' group by c.id, c.ten");
					}
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						if(ads.Tables[0].Rows[i]["id"].ToString().Trim()=="0")
						{
							ads.Tables[0].Rows[i]["ten"]=lan.Change_language_MessageText(
"Thuốc");
						}
						if(alydo!="" && ancol>0)
						{
							alydo +="\t";
						}
						alydo += ads.Tables[0].Rows[i]["ten"].ToString().Trim();
						alydo += ":";
						ancol++;
						if(ancol>=3)
						{
							ancol=0;
							alydo += "\n";
						}
					}
				}
				alydo=alydo.Trim().Trim(',');
				alydo=alydo.Trim();
				return alydo;
			}
			catch//(Exception ex)
			{
				//MessageBox.Show(ex.ToString());
				return "";
			}
		}
		public void f_Print_BienlaiNT(bool v_dir, string v_id, string v_mmyy_only)
		{
			try
			{
				this.Text=lan.Change_language_MessageText(
                "In biên lai thu viện phí nội trú (v_bienlaithuvienphint.rpt)");
				string aReport ="v_bienlaithuvienphint.rpt";

                string sql = "select a.id, b.mabn, a.sobienlai, a.sotien as tongcp, (a.sotien-a.bhyt-a.mien-a.thieu) as sotien , a.tamung, a.mien, a.thieu, a.bhyt , to_char(a.ngay,'dd/mm/yyyy') as ngay, c.tenkp, d.mabn, d.hoten, d.namsinh as ngaysinh, e.ten as gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') as ngaythu, j.hoten as nguoithu, i.sohieu as quyenso, l.ten as lydomien, a.lanin+1 as lanin from medibvmmyy.v_ttrvll a left join medibvmmyy.v_ttrvds b on a.id=b.id left join medibv.btdkp_bv c on a.makp=c.makp left join medibv.btdbn d on b.mabn=d.mabn left join medibv.dmphai e on d.phai=e.ma left join medibv.btdtt f on d.matt=f.matt left join medibv.btdquan g on d.maqu=g.maqu left join medibv.btdpxa h on d.maphuongxa=h.maphuongxa left join medibv.v_quyenso i on a.quyenso=i.id left join medibv.v_dlogin j on a.userid=j.id left join medibvmmyy.v_miennoitru k on a.id=k.id left join medibv.v_lydomien l on k.lydo=l.id where a.id=" + v_id + "";
                if (v_mmyy_only == "")
				{
					m_ds = m_v.get_data_bc(DateTime.Now,DateTime.Now,m_sql);
				}
				else
				{
					m_ds = m_v.get_data_mmyy(v_mmyy_only,m_sql);
				}
				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy biên lai thu viện phí nội trú <")+v_id+">",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				//m_ds.WriteXml("..\\v_rptBienlaiKB.xml",XmlWriteMode.WriteSchema);
				//return;
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="",ahoten="", angaysinh="", agioitinh="", akhoa="",adiachi="", alydo="",asotien="", achutien="", achutientu="", anguoithu="", amasothue="",amauso="",aquyenso="",asobienlai="",acucthue="",atongcuc="",adiachibv="",amabn="", atongcp="", atamung="", abhyt="",amien="",athieu="", alydomien="", alydomien1="";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				
				angayin=m_ds.Tables[0].Rows[0]["ngay"].ToString();
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";
				ahoten=m_ds.Tables[0].Rows[0]["hoten"].ToString();
				angaysinh=m_ds.Tables[0].Rows[0]["ngaysinh"].ToString();
				agioitinh=m_ds.Tables[0].Rows[0]["gioitinh"].ToString();
				akhoa=m_ds.Tables[0].Rows[0]["tenkp"].ToString().Trim();;
				adiachi=m_ds.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
				adiachi=adiachi.Trim().Replace(
lan.Change_language_MessageText("Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenquan"].ToString();
				adiachi=adiachi.Trim().Replace(
lan.Change_language_MessageText("Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tentt"].ToString();
				adiachi=adiachi.Trim().Trim(',').Trim();
				alydo=f_get_lydo_noitru(v_id,v_mmyy_only);//"Thanh toán ra viện bệnh nhân ngoại trú";
				asotien=m_ds.Tables[0].Rows[0]["sotien"].ToString();
				atongcp=m_ds.Tables[0].Rows[0]["tongcp"].ToString();
				atamung=m_ds.Tables[0].Rows[0]["tamung"].ToString();
				abhyt=m_ds.Tables[0].Rows[0]["bhyt"].ToString();
				amien=m_ds.Tables[0].Rows[0]["mien"].ToString();
				athieu=m_ds.Tables[0].Rows[0]["thieu"].ToString();
				alydomien1=m_ds.Tables[0].Rows[0]["lydomien"].ToString();
				achutien="";
				anguoithu=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				amasothue=m_v.s_masothue;
				amauso=m_v.s_maubienlai;
				aquyenso=m_ds.Tables[0].Rows[0]["quyenso"].ToString();;
				asobienlai=m_ds.Tables[0].Rows[0]["sobienlai"].ToString();
				acucthue=
lan.Change_language_MessageText("CỤC THUẾ");
				atongcuc=
lan.Change_language_MessageText("TỔNG CỤC THUẾ");
				adiachibv=m_v.s_diachi;
				amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();
				string atmp="";
				try
				{
					atmp = decimal.Parse(asotien.ToString()).ToString("###,###,##0");
				}
				catch
				{
					atmp="0";
				}

				if(atmp=="") atmp="0";
				
				achutien = m_v.Doiso_Unicode(atmp.Replace(",",""));
				if(achutien=="")
				{
					achutien=lan.Change_language_MessageText("không đồng");
				}
				
				try
				{
					atmp = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###").PadRight(20,'.');
					atmp=atmp.Substring(0,atmp.IndexOf("."));
				}
				catch
				{
					atmp="0";
				}
				//MessageBox.Show(atamung.Replace(",",""));
				if(atmp=="") atmp="0";
				achutientu = m_v.Doiso_Unicode(atmp.Replace(",",""));
				if(achutientu=="")
				{
					achutientu=lan.Change_language_MessageText("Không đồng");
				}

				asotien = decimal.Parse(asotien.ToString()).ToString("###,###,##0.###");
				atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,##0.###");
				atamung = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###");
				abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,##0.###");
				amien = decimal.Parse(amien.ToString()).ToString("###,###,##0.###");
				athieu = decimal.Parse(athieu.ToString()).ToString("###,###,##0.###");
				
				atmp=
lan.Change_language_MessageText("- Tổng chi phí:")+" " + atongcp;
				if(atamung!="0")
				{
					atmp = atmp+ "\n"+
lan.Change_language_MessageText("- Tạm ứng:")+" " + atamung;
				}
				if(abhyt!="0")
				{
					atmp = atmp+ "\n"+
lan.Change_language_MessageText("- BHYT trả:")+" " + abhyt;
				}
				if(amien!="0")
				{
					atmp = atmp+ "\n"+
lan.Change_language_MessageText("- Miễn:")+" " + amien;
				}
				if(athieu!="0")
				{
					atmp = atmp+ "\n"+
lan.Change_language_MessageText("- Thiếu:")+" " + athieu;
				}
				if(alydomien1!="")
				{
					atmp+=" ("+alydomien1+")";
				}
				decimal ahoan=decimal.Parse(atongcp)-decimal.Parse(atamung)-decimal.Parse(abhyt)-decimal.Parse(amien)-decimal.Parse(athieu);
				if(ahoan<0)
				{
					atmp = atmp+ "\n"+
lan.Change_language_MessageText("- Hoàn lại:")+" " + (-1*ahoan).ToString("###,###,###.###");
				}
				else
				{
					atmp = atmp+ "\n"+
lan.Change_language_MessageText("- Thu thêm:")+" " + ahoan.ToString("###,###,###.###");
				}
				alydomien=atmp;

				DataSet ads = f_Cursor_BienlaiNT();
				DataSet adslien = f_get_Soliennoitru();
				for(int i=0;i<adslien.Tables[0].Rows.Count;i++)
				{
					DataRow r = ads.Tables[0].NewRow();
					r["syt"]=asyt;
					r["bv"]=abv;
					r["diachibv"]=adiachibv;
					r["tongcucthue"]=atongcuc;
					r["cucthue"]=acucthue;
					r["masothue"]=amasothue;
					r["mauso"]=amauso;
					r["quyenso"]=aquyenso;
					r["sobienlai"]=asobienlai;
					r["ngayin"]=angayin;
					r["nguoiin"]=anguoiin;
					r["ghichu"]=aghichu;
					r["lien"]=adslien.Tables[0].Rows[i][0].ToString().Trim();
					r["mabn"]=amabn;
					r["hoten"]=ahoten;
					r["ngaysinh"]=angaysinh;
					r["gioitinh"]=agioitinh;
					r["khoa"]=akhoa;
					r["diachi"]=adiachi;
					r["lydo"]=alydo;
					r["sotien"]=asotien;
					r["chutien"]=achutien;
					r["tongcp"]=atongcp;
					r["tamung"]=atamung;
					r["bhyt"]=abhyt;
					r["mien"]=amien;
					r["lydomien"]=alydomien;
					r["nguoithu"]=anguoithu;
					ads.Tables[0].Rows.Add(r);
				}
				//ads.WriteXml("..\\..\\datareport\\v_bienlaithuvienphint.xml",XmlWriteMode.WriteSchema);
				//return;

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(ads);
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
                m_v.execute_data_mmyy(v_mmyy_only, "update medibvmmyy.v_ttrvll set lanin=nvl(lanin,0)+1 where to_char(id)='" + v_id + "'");
                cMain.Close(); cMain.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_BienlaiNT_Dacthu(bool v_dir, string v_id, string v_mmyy_only)
		{
			try
			{
				string aReport ="v_bienlaithuvienphint_dacthu.rpt";
				this.Text=
lan.Change_language_MessageText("In biên lai thu viện phí nội trú (")+aReport+")";

				m_sql = "select a.id, b.mabn, a.sobienlai, nvl(a.sotien,0) tongcp, (nvl(a.sotien,0)-nvl(a.bhyt,0)-nvl(a.mien,0)-nvl(a.thieu,0)) sotien , nvl(a.tamung,0) tamung, nvl(a.mien,0) mien, nvl(a.thieu,0) thieu, nvl(a.bhyt,0) bhyt , to_char(a.ngay,'dd/mm/yyyy') ngay, c.tenkp, d.mabn, d.hoten, decode(d.ngaysinh,null,d.namsinh,to_char(d.ngaysinh,'dd/mm/yyyy')) ngaysinh, e.ten gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') ngaythu, j.hoten nguoithu, i.sohieu quyenso, l.ten lydomien, nvl(a.lanin,0)+1 lanin from v_ttrvll a, v_ttrvds b, btdkp_bv c, btdbn d, dmphai e, btdtt f, btdquan g, btdpxa h, v_quyenso i, medibv.v_dlogin j, v_miennoitru k, v_lydomien l where b.id=a.id and a.makp=c.makp(+) and b.mabn=d.mabn and d.phai=e.ma and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.quyenso = i.id and a.userid=j.id(+) and b.id=k.id(+) and k.lydo=l.id(+) and to_char(a.id)='"+v_id+"'";
				if(v_mmyy_only=="")
				{
					m_ds = m_v.get_data_bc(DateTime.Now,DateTime.Now,m_sql);
				}
				else
				{
					m_ds = m_v.get_data_mmyy(v_mmyy_only,m_sql);
				}
				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy biên lai thu viện phí nội trú <")+v_id+">",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				//m_ds.WriteXml("..\\v_rptBienlaiKB.xml",XmlWriteMode.WriteSchema);
				//return;
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="",ahoten="", angaysinh="", agioitinh="", akhoa="",adiachi="", alydo="",asotien="", achutien="", achutientu="", anguoithu="", amasothue="",amauso="",aquyenso="",asobienlai="",acucthue="",atongcuc="",adiachibv="",amabn="", atongcp="", atamung="", abhyt="",amien="",athieu="", alydomien="", alydomien1="";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				
				angayin=m_ds.Tables[0].Rows[0]["ngay"].ToString();
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";
				ahoten=m_ds.Tables[0].Rows[0]["hoten"].ToString();
				angaysinh=m_ds.Tables[0].Rows[0]["ngaysinh"].ToString();
				agioitinh=m_ds.Tables[0].Rows[0]["gioitinh"].ToString();
				akhoa=m_ds.Tables[0].Rows[0]["tenkp"].ToString().Trim();;
				adiachi=m_ds.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
				adiachi=adiachi.Trim().Replace(
lan.Change_language_MessageText("Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenquan"].ToString();
				adiachi=adiachi.Trim().Replace(
lan.Change_language_MessageText("Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tentt"].ToString();
				adiachi=adiachi.Trim().Trim(',').Trim();
				alydo=f_get_lydo_noitru(v_id,v_mmyy_only);//"Thanh toán ra viện bệnh nhân ngoại trú";
				asotien=m_ds.Tables[0].Rows[0]["sotien"].ToString();
				atongcp=m_ds.Tables[0].Rows[0]["tongcp"].ToString();
				atamung=m_ds.Tables[0].Rows[0]["tamung"].ToString();
				abhyt=m_ds.Tables[0].Rows[0]["bhyt"].ToString();
				amien=m_ds.Tables[0].Rows[0]["mien"].ToString();
				athieu=m_ds.Tables[0].Rows[0]["thieu"].ToString();
				alydomien1=m_ds.Tables[0].Rows[0]["lydomien"].ToString();
				achutien="";
				anguoithu=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				amasothue=m_v.s_masothue;
				amauso=m_v.s_maubienlai;
				aquyenso=m_ds.Tables[0].Rows[0]["quyenso"].ToString();;
				asobienlai=m_ds.Tables[0].Rows[0]["sobienlai"].ToString();
				acucthue=
lan.Change_language_MessageText("CỤC THUẾ");
				atongcuc=
lan.Change_language_MessageText("TỔNG CỤC THUẾ");
				adiachibv=m_v.s_diachi;
				amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();
				string atmp="";
				try
				{
					atmp = decimal.Parse(asotien.ToString()).ToString("###,###,##0");
				}
				catch
				{
					atmp="0";
				}

				if(atmp=="") atmp="0";
				
				achutien = m_v.Doiso_Unicode(atmp.Replace(",",""));
				if(achutien=="")
				{
					achutien=lan.Change_language_MessageText("không đồng");
				}
				
				try
				{
					atmp = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###").PadRight(20,'.');
					atmp=atmp.Substring(0,atmp.IndexOf("."));
				}
				catch
				{
					atmp="0";
				}
				//MessageBox.Show(atamung.Replace(",",""));
				if(atmp=="") atmp="0";
				achutientu = m_v.Doiso_Unicode(atmp.Replace(",",""));
				if(achutientu=="")
				{
					achutientu=lan.Change_language_MessageText("Không đồng");
				}

				asotien = decimal.Parse(asotien.ToString()).ToString("###,###,##0.###");
				atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,##0.###");
				atamung = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###");
				abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,##0.###");
				amien = decimal.Parse(amien.ToString()).ToString("###,###,##0.###");
				athieu = decimal.Parse(athieu.ToString()).ToString("###,###,##0.###");
				
				atmp=
lan.Change_language_MessageText("- Tổng chi phí:")+" " + atongcp;
				if(atamung!="0")
				{
					atmp = atmp+ "\n"+
lan.Change_language_MessageText("- Tạm ứng:")+" " + atamung;
				}
				if(abhyt!="0")
				{
					atmp = atmp+ "\n"+
lan.Change_language_MessageText("- BHYT trả:")+" " + abhyt;
				}
				if(amien!="0")
				{
					atmp = atmp+ "\n"+
lan.Change_language_MessageText("- Miễn:")+" " + amien;
				}
				if(athieu!="0")
				{
					atmp = atmp+ "\n"+
lan.Change_language_MessageText("- Thiếu:")+" " + athieu;
				}
				if(alydomien1!="")
				{
					atmp+=" ("+alydomien1+")";
				}
				decimal ahoan=decimal.Parse(atongcp)-decimal.Parse(atamung)-decimal.Parse(abhyt)-decimal.Parse(amien)-decimal.Parse(athieu);
				if(ahoan<0)
				{
					atmp = atmp+ "\n"+
lan.Change_language_MessageText("- Hoàn lại:")+" " + (-1*ahoan).ToString("###,###,###.###");
				}
				else
				{
					atmp = atmp+ "\n"+
lan.Change_language_MessageText("- Thu thêm:")+" " + ahoan.ToString("###,###,###.###");
				}
				alydomien=atmp;

				DataSet ads = f_Cursor_BienlaiNT();
				DataSet adslien = f_get_Soliennoitru_dacthu();
				for(int i=0;i<adslien.Tables[0].Rows.Count;i++)
				{
					DataRow r = ads.Tables[0].NewRow();
					r["syt"]=asyt;
					r["bv"]=abv;
					r["diachibv"]=adiachibv;
					r["tongcucthue"]=atongcuc;
					r["cucthue"]=acucthue;
					r["masothue"]=amasothue;
					r["mauso"]=amauso;
					r["quyenso"]=aquyenso;
					r["sobienlai"]=asobienlai;
					r["ngayin"]=angayin;
					r["nguoiin"]=anguoiin;
					r["ghichu"]=aghichu;
					r["lien"]=adslien.Tables[0].Rows[i][0].ToString().Trim();
					r["mabn"]=amabn;
					r["hoten"]=ahoten;
					r["ngaysinh"]=angaysinh;
					r["gioitinh"]=agioitinh;
					r["khoa"]=akhoa;
					r["diachi"]=adiachi;
					r["lydo"]=alydo;
					r["sotien"]=asotien;
					r["chutien"]=achutien;
					r["tongcp"]=atongcp;
					r["tamung"]=atamung;
					r["bhyt"]=abhyt;
					r["mien"]=amien;
					r["lydomien"]=alydomien;
					r["nguoithu"]=anguoithu;
					ads.Tables[0].Rows.Add(r);
				}
				//ads.WriteXml("..\\..\\datareport\\v_bienlaithuvienphint.xml",XmlWriteMode.WriteSchema);
				//return;

				ReportDocument cMain=new ReportDocument();
				try
				{
					cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				}
				catch
				{
					System.IO.File.Copy("..\\..\\..\\report\\"+aReport.Replace("_dacthu",""),"..\\..\\..\\report\\"+aReport,false);
					cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				}
				cMain.SetDataSource(ads);
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
                m_v.execute_data_mmyy(v_mmyy_only, "update medibvmmyy.v_ttrvll set lanin=nvl(lanin,0)+1 where to_char(id)='" + v_id + "'");
                cMain.Close(); cMain.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_BienlaiNT_Thuchi(bool v_dir, string v_id, string v_mmyy_only)
		{
			try
			{
				this.Text="In biên lai thu - chi viện phí nội trú (v_bienlaithuvienphint_thuchi.rpt)";
				string aReport ="v_bienlaithuvienphint_thuchi.rpt";

				m_sql = "select a.id, b.mabn, a.sobienlai, nvl(a.sotien,0) tongcp, (nvl(a.sotien,0)-nvl(a.bhyt,0)-nvl(a.mien,0)-nvl(a.thieu,0)) sotien , nvl(a.tamung,0) tamung, nvl(a.mien,0) mien, nvl(a.thieu,0) thieu, nvl(a.bhyt,0) bhyt , to_char(a.ngay,'dd/mm/yyyy') ngay, c.tenkp, d.mabn, d.hoten, decode(d.ngaysinh,null,d.namsinh,to_char(d.ngaysinh,'dd/mm/yyyy')) ngaysinh, e.ten gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') ngaythu, j.hoten nguoithu, i.sohieu quyenso, l.ten lydomien, nvl(a.lanin,0)+1 lanin from v_ttrvll a, v_ttrvds b, btdkp_bv c, btdbn d, dmphai e, btdtt f, btdquan g, btdpxa h, v_quyenso i, medibv.v_dlogin j, v_miennoitru k, v_lydomien l where b.id=a.id and a.makp=c.makp(+) and b.mabn=d.mabn and d.phai=e.ma and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.quyenso = i.id and a.userid=j.id(+) and b.id=k.id(+) and k.lydo=l.id(+) and to_char(a.id)='"+v_id+"'";
				if(v_mmyy_only=="")
				{
					m_ds = m_v.get_data_bc(DateTime.Now,DateTime.Now,m_sql);
				}
				else
				{
					m_ds = m_v.get_data_mmyy(v_mmyy_only,m_sql);
				}
				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy biên lai thu viện phí nội trú <")+v_id+">",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				//m_ds.WriteXml("..\\v_rptBienlaiKB.xml",XmlWriteMode.WriteSchema);
				//return;
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="",ahoten="", angaysinh="", agioitinh="", akhoa="",adiachi="", alydo="",asotien="", achutien="", achutientu="", anguoithu="", amasothue="",amauso="",aquyenso="",asobienlai="",acucthue="",atongcuc="",adiachibv="",amabn="", atongcp="", atamung="", abhyt="",amien="",athieu="", alydomien="",alydomien1="";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				
				angayin=m_ds.Tables[0].Rows[0]["ngay"].ToString();
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";
				ahoten=m_ds.Tables[0].Rows[0]["hoten"].ToString();
				angaysinh=m_ds.Tables[0].Rows[0]["ngaysinh"].ToString();
				agioitinh=m_ds.Tables[0].Rows[0]["gioitinh"].ToString();
				akhoa=m_ds.Tables[0].Rows[0]["tenkp"].ToString().Trim();;
				adiachi=m_ds.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
				adiachi=adiachi.Trim().Replace(
lan.Change_language_MessageText("Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenquan"].ToString();
				adiachi=adiachi.Trim().Replace(
lan.Change_language_MessageText("Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tentt"].ToString();
				adiachi=adiachi.Trim().Trim(',').Trim();
				alydo=f_get_lydo_noitru(v_id,v_mmyy_only);//"Thanh toán ra viện bệnh nhân ngoại trú";
				asotien=m_ds.Tables[0].Rows[0]["sotien"].ToString();
				atongcp=m_ds.Tables[0].Rows[0]["tongcp"].ToString();
				atamung=m_ds.Tables[0].Rows[0]["tamung"].ToString();
				abhyt=m_ds.Tables[0].Rows[0]["bhyt"].ToString();
				amien=m_ds.Tables[0].Rows[0]["mien"].ToString();
				athieu=m_ds.Tables[0].Rows[0]["thieu"].ToString();
				alydomien1=m_ds.Tables[0].Rows[0]["lydomien"].ToString();
				achutien="";
				anguoithu=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				amasothue=m_v.s_masothue;
				amauso=m_v.s_maubienlai;
				aquyenso=m_ds.Tables[0].Rows[0]["quyenso"].ToString();;
				asobienlai=m_ds.Tables[0].Rows[0]["sobienlai"].ToString();
				acucthue=
lan.Change_language_MessageText("CỤC THUẾ");
				atongcuc=
lan.Change_language_MessageText("TỔNG CỤC THUẾ");
				adiachibv=m_v.s_diachi;
				amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();
				string atmp="";
				try
				{
					atmp = decimal.Parse(asotien.ToString()).ToString("###,###,##0.###").PadRight(20,'.');
					atmp=atmp.Substring(0,atmp.IndexOf("."));
				}
				catch
				{
					atmp="0";
				}

				if(atmp=="") atmp="0";
				
				achutien = m_v.Doiso_Unicode(atmp.Replace(",",""));
				if(achutien=="")
				{
					achutien=lan.Change_language_MessageText("không đồng");
				}
				
				try
				{
					atmp = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###").PadRight(20,'.');
					atmp=atmp.Substring(0,atmp.IndexOf("."));
				}
				catch
				{
					atmp="0";
				}
				//MessageBox.Show(atamung.Replace(",",""));
				if(atmp=="") atmp="0";
				achutientu = m_v.Doiso_Unicode(atmp.Replace(",",""));
				if(achutientu=="")
				{
					achutientu=lan.Change_language_MessageText("không đồng");
				}

				asotien = decimal.Parse(asotien.ToString()).ToString("###,###,##0.###");
				atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,##0.###");
				atamung = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###");
				abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,##0.###");
				amien = decimal.Parse(amien.ToString()).ToString("###,###,##0.###");
				athieu = decimal.Parse(athieu.ToString()).ToString("###,###,##0.###");
				
				atmp=
lan.Change_language_MessageText("- Tổng chi phí:")+" " + atongcp;
				if(atamung!="0")
				{
					atmp = atmp+ 
lan.Change_language_MessageText("\n")+
lan.Change_language_MessageText("- Tạm ứng:")+" " + atamung;
				}
				if(abhyt!="0")
				{
					atmp = atmp+ "\n"+
lan.Change_language_MessageText("- BHYT trả:")+" " + abhyt;
				}
				if(amien!="0")
				{
					atmp = atmp+ "\n"+
lan.Change_language_MessageText("- Miễn:")+" " + amien;
				}
				if(athieu!="0")
				{
					atmp = atmp+ "\n"+
lan.Change_language_MessageText("- Thiếu:")+" " + athieu;
				}
				if(alydomien1!="")
				{
					atmp+=" ("+alydomien1+")";
				}
				decimal ahoan=decimal.Parse(atongcp)-decimal.Parse(atamung)-decimal.Parse(abhyt)-decimal.Parse(amien)-decimal.Parse(athieu);
				if(ahoan<0)
				{
					atmp = atmp+ "\n"+
lan.Change_language_MessageText("- Hoàn lại:")+" " + (-1*ahoan).ToString("###,###,###.###");
				}
				else
				{
					atmp = atmp+ "\n+"+
lan.Change_language_MessageText("- Thu thêm:")+" " + ahoan.ToString("###,###,###.###");
				}
				alydomien=atmp;

				DataSet ads = f_Cursor_BienlaiNT();
				DataSet adslien = f_get_Soliennoitru_thuchi();
				for(int i=0;i<adslien.Tables[0].Rows.Count;i++)
				{
					DataRow r = ads.Tables[0].NewRow();
					r["syt"]=asyt;
					r["bv"]=abv;
					r["diachibv"]=adiachibv;
					r["tongcucthue"]=atongcuc;
					r["cucthue"]=acucthue;
					r["masothue"]=amasothue;
					r["mauso"]=amauso;
					r["quyenso"]=aquyenso;
					r["sobienlai"]=asobienlai;
					r["ngayin"]=angayin;
					r["nguoiin"]=anguoiin;
					r["ghichu"]=aghichu;
					r["lien"]=adslien.Tables[0].Rows[i][0].ToString().Trim();
					r["mabn"]=amabn;
					r["hoten"]=ahoten;
					r["ngaysinh"]=angaysinh;
					r["gioitinh"]=agioitinh;
					r["khoa"]=akhoa;
					r["diachi"]=adiachi;
					r["lydo"]=alydo;
					r["sotien"]=asotien;
					r["chutien"]=achutien;
					r["tongcp"]=atongcp;
					r["tamung"]=atamung;
					r["bhyt"]=abhyt;
					r["mien"]=amien;
					r["lydomien"]=alydomien;
					r["nguoithu"]=anguoithu;
					ads.Tables[0].Rows.Add(r);
				}
				//ads.WriteXml("..\\..\\datareport\\v_bienlaithuvienphint.xml",XmlWriteMode.WriteSchema);
				//return;

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(ads);
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
                m_v.execute_data_mmyy(v_mmyy_only, "update medibvmmyy.v_ttrvll set lanin=nvl(lanin,0)+1 where to_char(id)='" + v_id + "'");
                cMain.Close(); cMain.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}

		//linh 19/05/2006
		public void f_Print_BienlaiNT_Mien(bool v_dir, string v_id, string v_mmyy_only)
		{
			try
			{
				this.Text=
lan.Change_language_MessageText("In biên lai thu - chi viện phí nội trú (v_bienlaithuvienphint_mien.rpt)");
				string aReport ="v_bienlaithuvienphint_mien.rpt";

				m_sql = "select a.id, b.mabn, a.sobienlai, nvl(a.sotien,0) tongcp, (nvl(a.sotien,0)-nvl(a.bhyt,0)-nvl(a.mien,0)-nvl(a.thieu,0)) sotien , nvl(a.tamung,0) tamung, nvl(a.mien,0) mien, nvl(a.thieu,0) thieu, nvl(a.bhyt,0) bhyt , to_char(a.ngay,'dd/mm/yyyy') ngay, c.tenkp, d.mabn, d.hoten, decode(d.ngaysinh,null,d.namsinh,to_char(d.ngaysinh,'dd/mm/yyyy')) ngaysinh, e.ten gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') ngaythu, j.hoten nguoithu, i.sohieu quyenso, l.ten lydomien, nvl(a.lanin,0)+1 lanin from v_ttrvll a, v_ttrvds b, btdkp_bv c, btdbn d, dmphai e, btdtt f, btdquan g, btdpxa h, v_quyenso i, medibv.v_dlogin j, v_miennoitru k, v_lydomien l where b.id=a.id and a.makp=c.makp(+) and b.mabn=d.mabn and d.phai=e.ma and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.quyenso = i.id and a.userid=j.id(+) and b.id=k.id(+) and k.lydo=l.id(+) and to_char(a.id)='"+v_id+"'";
				if(v_mmyy_only=="")
				{
					m_ds = m_v.get_data_bc(DateTime.Now,DateTime.Now,m_sql);
				}
				else
				{
					m_ds = m_v.get_data_mmyy(v_mmyy_only,m_sql);
				}
				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy biên lai thu viện phí nội trú <")+v_id+">",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				//m_ds.WriteXml("..\\v_rptBienlaiKB.xml",XmlWriteMode.WriteSchema);
				//return;
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="",ahoten="", angaysinh="", agioitinh="", akhoa="",adiachi="", alydo="",asotien="", achutien="", achutientu="", anguoithu="", amasothue="",amauso="",aquyenso="",asobienlai="",acucthue="",atongcuc="",adiachibv="",amabn="", atongcp="", atamung="", abhyt="",amien="",athieu="", alydomien="",alydomien1="";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				
				angayin=m_ds.Tables[0].Rows[0]["ngay"].ToString();
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";
				ahoten=m_ds.Tables[0].Rows[0]["hoten"].ToString();
				angaysinh=m_ds.Tables[0].Rows[0]["ngaysinh"].ToString();
				agioitinh=m_ds.Tables[0].Rows[0]["gioitinh"].ToString();
				akhoa=m_ds.Tables[0].Rows[0]["tenkp"].ToString().Trim();;
				adiachi=m_ds.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenquan"].ToString();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tentt"].ToString();
				adiachi=adiachi.Trim().Trim(',').Trim();
				alydo=f_get_lydo_noitru(v_id,v_mmyy_only);//"Thanh toán ra viện bệnh nhân ngoại trú";
				asotien=m_ds.Tables[0].Rows[0]["sotien"].ToString();
				atongcp=m_ds.Tables[0].Rows[0]["tongcp"].ToString();
				atamung=m_ds.Tables[0].Rows[0]["tamung"].ToString();
				abhyt=m_ds.Tables[0].Rows[0]["bhyt"].ToString();
				amien=m_ds.Tables[0].Rows[0]["mien"].ToString();
				athieu=m_ds.Tables[0].Rows[0]["thieu"].ToString();
				alydomien1=m_ds.Tables[0].Rows[0]["lydomien"].ToString();
				achutien="";
				anguoithu=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				amasothue=m_v.s_masothue;
				amauso=m_v.s_maubienlai;
				aquyenso=m_ds.Tables[0].Rows[0]["quyenso"].ToString();;
				asobienlai=m_ds.Tables[0].Rows[0]["sobienlai"].ToString();
				acucthue=lan.Change_language_MessageText("CỤC THUẾ");
				atongcuc=lan.Change_language_MessageText("TỔNG CỤC THUẾ");
				adiachibv=m_v.s_diachi;
				amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();
				string atmp="";
				try
				{
					atmp = decimal.Parse(asotien.ToString()).ToString("###,###,##0.###").PadRight(20,'.');
					atmp=atmp.Substring(0,atmp.IndexOf("."));
				}
				catch
				{
					atmp="0";
				}

				if(atmp=="") atmp="0";
				
				achutien = m_v.Doiso_Unicode(atmp.Replace(",",""));
				if(achutien=="")
				{
					achutien=lan.Change_language_MessageText("không đồng");
				}
				
				try
				{
					atmp = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###").PadRight(20,'.');
					atmp=atmp.Substring(0,atmp.IndexOf("."));
				}
				catch
				{
					atmp="0";
				}
				//MessageBox.Show(atamung.Replace(",",""));
				if(atmp=="") atmp="0";
				achutientu = m_v.Doiso_Unicode(atmp.Replace(",",""));
				if(achutientu=="")
				{
					achutientu=lan.Change_language_MessageText("Không đồng");
				}

				asotien = decimal.Parse(asotien.ToString()).ToString("###,###,##0.###");
				atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,##0.###");
				atamung = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###");
				abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,##0.###");
				amien = decimal.Parse(amien.ToString()).ToString("###,###,##0.###");
				athieu = decimal.Parse(athieu.ToString()).ToString("###,###,##0.###");
				
				atmp="- Tổng chi phí: " + atongcp;
				if(atamung!="0")
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("- Tạm ứng:")+" " + atamung;
				}
				if(abhyt!="0")
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("- BHYT trả:")+" " + abhyt;
				}
				if(amien!="0")
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("- Miễn:")+" " + amien;
				}
				if(athieu!="0")
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("- Thiếu:")+" " + athieu;
				}
				if(alydomien1!="")
				{
					atmp+=" ("+alydomien1+")";
				}
				decimal ahoan=decimal.Parse(atongcp)-decimal.Parse(atamung)-decimal.Parse(abhyt)-decimal.Parse(amien)-decimal.Parse(athieu);
				if(ahoan<0)
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("- Hoàn lại:")+" " + (-1*ahoan).ToString("###,###,###.###");
				}
				else
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("-Thu thêm:")+" " + ahoan.ToString("###,###,###.###");
				}
				alydomien=atmp;

				DataSet ads = f_Cursor_BienlaiNT();
				DataSet adslien = f_get_Soliennoitru_thuchi();
				for(int i=0;i<adslien.Tables[0].Rows.Count;i++)
				{
					DataRow r = ads.Tables[0].NewRow();
					r["syt"]=asyt;
					r["bv"]=abv;
					r["diachibv"]=adiachibv;
					r["tongcucthue"]=atongcuc;
					r["cucthue"]=acucthue;
					r["masothue"]=amasothue;
					r["mauso"]=amauso;
					r["quyenso"]=aquyenso;
					r["sobienlai"]=asobienlai;
					r["ngayin"]=angayin;
					r["nguoiin"]=anguoiin;
					r["ghichu"]=aghichu;
					r["lien"]=adslien.Tables[0].Rows[i][0].ToString().Trim();
					r["mabn"]=amabn;
					r["hoten"]=ahoten;
					r["ngaysinh"]=angaysinh;
					r["gioitinh"]=agioitinh;
					r["khoa"]=akhoa;
					r["diachi"]=adiachi;
					r["lydo"]=alydo;
					r["sotien"]=asotien;
					r["chutien"]=achutien;
					r["tongcp"]=atongcp;
					r["tamung"]=atamung;
					r["bhyt"]=abhyt;
					r["mien"]=amien;
					r["lydomien"]=alydomien;
					r["nguoithu"]=anguoithu;
					ads.Tables[0].Rows.Add(r);
				}
				//ads.WriteXml("..\\..\\datareport\\v_bienlaithuvienphint.xml",XmlWriteMode.WriteSchema);
				//return;

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(ads);
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
                m_v.execute_data_mmyy(v_mmyy_only, "update medibvmmyy.v_ttrvll set lanin=nvl(lanin,0)+1 where to_char(id)='" + v_id + "'");
                cMain.Close(); cMain.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_BienlaiNT_Thuchi_mien(bool v_dir, string v_id, string v_mmyy_only)
		{
			try
			{
				this.Text="In biên lai thu - chi viện phí nội trú (v_bienlaithuvienphint_thuchi.rpt)";
				string aReport ="v_bienlaithuvienphint_thuchi.rpt";

				m_sql = "select a.id, b.mabn, a.sobienlai, nvl(a.sotien,0) tongcp, (nvl(a.sotien,0)-nvl(a.bhyt,0)-nvl(a.mien,0)-nvl(a.thieu,0)) sotien , nvl(a.tamung,0) tamung, nvl(a.mien,0) mien,nvl(a.thieu,0) thieu,nvl(a.bhyt,0) bhyt , to_char(a.ngay,'dd/mm/yyyy') ngay, c.tenkp, d.mabn, d.hoten, decode(d.ngaysinh,null,d.namsinh,to_char(d.ngaysinh,'dd/mm/yyyy')) ngaysinh, e.ten gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') ngaythu, j.hoten nguoithu, i.sohieu quyenso, l.ten lydomien, nvl(a.lanin,0)+1 lanin from v_ttrvll a, v_ttrvds b, btdkp_bv c, btdbn d, dmphai e, btdtt f, btdquan g, btdpxa h, v_quyenso i, medibv.v_dlogin j, v_miennoitru k, v_lydomien l where b.id=a.id and a.makp=c.makp(+) and b.mabn=d.mabn and d.phai=e.ma and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.quyenso = i.id and a.userid=j.id(+) and b.id=k.id(+) and k.lydo=l.id(+) and to_char(a.id)='"+v_id+"'";
				if(v_mmyy_only=="")
				{
					m_ds = m_v.get_data_bc(DateTime.Now,DateTime.Now,m_sql);
				}
				else
				{
					m_ds = m_v.get_data_mmyy(v_mmyy_only,m_sql);
				}
				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy biên lai thu viện phí nội trú <")+v_id+">",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				//m_ds.WriteXml("..\\v_rptBienlaiKB.xml",XmlWriteMode.WriteSchema);
				//return;
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="",ahoten="", angaysinh="", agioitinh="", akhoa="",adiachi="", alydo="",asotien="", achutien="", achutientu="", anguoithu="", amasothue="",amauso="",aquyenso="",asobienlai="",acucthue="",atongcuc="",adiachibv="",amabn="", atongcp="", atamung="", abhyt="",amien="",athieu="", alydomien="",alydomien1="";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				
				angayin=m_ds.Tables[0].Rows[0]["ngay"].ToString();
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";
				ahoten=m_ds.Tables[0].Rows[0]["hoten"].ToString();
				angaysinh=m_ds.Tables[0].Rows[0]["ngaysinh"].ToString();
				agioitinh=m_ds.Tables[0].Rows[0]["gioitinh"].ToString();
				akhoa=m_ds.Tables[0].Rows[0]["tenkp"].ToString().Trim();;
				adiachi=m_ds.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenquan"].ToString();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tentt"].ToString();
				adiachi=adiachi.Trim().Trim(',').Trim();
				alydo=f_get_lydo_noitru(v_id,v_mmyy_only);//"Thanh toán ra viện bệnh nhân ngoại trú";
				asotien=m_ds.Tables[0].Rows[0]["sotien"].ToString();
				atongcp=m_ds.Tables[0].Rows[0]["tongcp"].ToString();
				atamung=m_ds.Tables[0].Rows[0]["tamung"].ToString();
				abhyt=m_ds.Tables[0].Rows[0]["bhyt"].ToString();
				amien=m_ds.Tables[0].Rows[0]["mien"].ToString();
				athieu=m_ds.Tables[0].Rows[0]["thieu"].ToString();
				alydomien1=m_ds.Tables[0].Rows[0]["lydomien"].ToString();
				achutien="";
				anguoithu=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				amasothue=m_v.s_masothue;
				amauso=m_v.s_maubienlai;
				aquyenso=m_ds.Tables[0].Rows[0]["quyenso"].ToString();;
				asobienlai=m_ds.Tables[0].Rows[0]["sobienlai"].ToString();
				acucthue=lan.Change_language_MessageText("CỤC THUẾ");
				atongcuc=lan.Change_language_MessageText("TỔNG CỤC THUẾ");
				adiachibv=m_v.s_diachi;
				amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();
				string atmp="";
				try
				{
					atmp = decimal.Parse(asotien.ToString()).ToString("###,###,##0.###").PadRight(20,'.');
					atmp=atmp.Substring(0,atmp.IndexOf("."));
				}
				catch
				{
					atmp="0";
				}

				if(atmp=="") atmp="0";
				
				achutien = m_v.Doiso_Unicode(atmp.Replace(",",""));
				if(achutien=="")
				{
					achutien=lan.Change_language_MessageText("không đồng");
				}
				
				try
				{
					atmp = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###").PadRight(20,'.');
					atmp=atmp.Substring(0,atmp.IndexOf("."));
				}
				catch
				{
					atmp="0";
				}
				//MessageBox.Show(atamung.Replace(",",""));
				if(atmp=="") atmp="0";
				achutientu = m_v.Doiso_Unicode(atmp.Replace(",",""));
				if(achutientu=="")
				{
					achutientu=lan.Change_language_MessageText("Không đồng");
				}

				asotien = decimal.Parse(asotien.ToString()).ToString("###,###,##0.###");
				atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,##0.###");
				atamung = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###");
				abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,##0.###");
				amien = decimal.Parse(amien.ToString()).ToString("###,###,##0.###");
				athieu = decimal.Parse(athieu.ToString()).ToString("###,###,##0.###");
				
				atmp="- Tổng chi phí: " + atongcp;
				if(atamung!="0")
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("- Tạm ứng:")+" " + atamung;
				}
				if(abhyt!="0")
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("- BHYT trả:")+" " + abhyt;
				}
				if(amien!="0")
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("- Miễn:")+" " + amien;
				}
				if(athieu!="0")
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("- Thiếu:")+" " + athieu;
				}
				if(alydomien1!="")
				{
					atmp+=" ("+alydomien1+")";
				}
				decimal ahoan=decimal.Parse(atongcp)-decimal.Parse(atamung)-decimal.Parse(abhyt)-decimal.Parse(amien)-decimal.Parse(athieu);
				if(ahoan<0)
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("- Hoàn lại:")+" " + (-1*ahoan).ToString("###,###,###.###");
				}
				else
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("-Thu thêm:")+" " + ahoan.ToString("###,###,###.###");
				}
				alydomien=atmp;

				DataSet ads = f_Cursor_BienlaiNT();
				DataSet adslien = f_get_Soliennoitru_thuchi();
				for(int i=0;i<adslien.Tables[0].Rows.Count;i++)
				{
					DataRow r = ads.Tables[0].NewRow();
					r["syt"]=asyt;
					r["bv"]=abv;
					r["diachibv"]=adiachibv;
					r["tongcucthue"]=atongcuc;
					r["cucthue"]=acucthue;
					r["masothue"]=amasothue;
					r["mauso"]=amauso;
					r["quyenso"]=aquyenso;
					r["sobienlai"]=asobienlai;
					r["ngayin"]=angayin;
					r["nguoiin"]=anguoiin;
					r["ghichu"]=aghichu;
					r["lien"]=adslien.Tables[0].Rows[i][0].ToString().Trim();
					r["mabn"]=amabn;
					r["hoten"]=ahoten;
					r["ngaysinh"]=angaysinh;
					r["gioitinh"]=agioitinh;
					r["khoa"]=akhoa;
					r["diachi"]=adiachi;
					r["lydo"]=alydo;
					r["sotien"]=asotien;
					r["chutien"]=achutien;
					r["tongcp"]=atongcp;
					r["tamung"]=atamung;
					r["bhyt"]=abhyt;
					r["mien"]=amien;
					//linh 
					r["lydomien"]=alydomien1;
					//end linh
					r["nguoithu"]=anguoithu;
					ads.Tables[0].Rows.Add(r);
				}
				//ads.WriteXml("..\\..\\datareport\\v_bienlaithuvienphint.xml",XmlWriteMode.WriteSchema);
				//return;
				if(decimal.Parse(asotien)!=0)
				{
					ReportDocument cMain=new ReportDocument();
					cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
					cMain.SetDataSource(ads);
					if(!v_dir)
					{
						this.crystalReportViewer1.ReportSource=cMain;
						this.WindowState=FormWindowState.Maximized;
						this.ShowDialog(this.Parent);
					}
					else
					{
						cMain.PrintToPrinter(1,false,0,0);
					}
                    cMain.Close(); cMain.Dispose();
				}
				if(decimal.Parse(amien)!=0)
				{
					ReportDocument cMain1=new ReportDocument();
					cMain1.Load("..\\..\\..\\report\\v_bienlaithuvienphint_mien.rpt", OpenReportMethod.OpenReportByTempCopy);
					cMain1.SetDataSource(ads);
					if(!v_dir)
					{
						this.crystalReportViewer1.ReportSource=cMain1;
						this.WindowState=FormWindowState.Maximized;
						this.ShowDialog(this.Parent);
					}
					else
					{
						cMain1.PrintToPrinter(1,false,0,0);
					}
                    cMain1.Close(); cMain1.Dispose();
				}
                m_v.execute_data_mmyy(v_mmyy_only, "update medibvmmyy.v_ttrvll set lanin=nvl(lanin,0)+1 where to_char(id)='" + v_id + "'");
                
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		//end linh
		public void f_Print_BienlaiNT_Chitamung(bool v_dir, string v_id, string v_mmyy_only)
		{
			try
			{
				this.Text="In biên lai chi tạm ứng (v_bienlaithuvienphint_chitamung.rpt)";
				string aReport ="v_bienlaithuvienphint_chitamung.rpt";

				m_sql = "select a.id, b.mabn, a.sobienlai, nvl(a.sotien,0) tongcp, (nvl(a.sotien,0)-nvl(a.bhyt,0)-nvl(a.mien,0)-nvl(a.thieu,0)) sotien , nvl(a.tamung,0) tamung, nvl(a.mien,0) mien, nvl(a.thieu,0) thieu, nvl(a.bhyt,0) bhyt , to_char(a.ngay,'dd/mm/yyyy') ngay, c.tenkp, d.mabn, d.hoten, decode(d.ngaysinh,null,d.namsinh,to_char(d.ngaysinh,'dd/mm/yyyy')) ngaysinh, e.ten gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') ngaythu, j.hoten nguoithu, i.sohieu quyenso, l.ten lydomien, nvl(a.lanin,0)+1 lanin from v_ttrvll a, v_ttrvds b, btdkp_bv c, btdbn d, dmphai e, btdtt f, btdquan g, btdpxa h, v_quyenso i, medibv.v_dlogin j, v_miennoitru k, v_lydomien l where b.id=a.id and a.makp=c.makp(+) and b.mabn=d.mabn and d.phai=e.ma and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.quyenso = i.id and a.userid=j.id(+) and b.id=k.id(+) and k.lydo=l.id(+) and to_char(a.id)='"+v_id+"'";
				if(v_mmyy_only=="")
				{
					m_ds = m_v.get_data_bc(DateTime.Now,DateTime.Now,m_sql);
				}
				else
				{
					m_ds = m_v.get_data_mmyy(v_mmyy_only,m_sql);
				}
				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy biên lai thu viện phí nội trú <")+v_id+">",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				//m_ds.WriteXml("..\\v_rptBienlaiKB.xml",XmlWriteMode.WriteSchema);
				//return;
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="",ahoten="", angaysinh="", agioitinh="", akhoa="",adiachi="", alydo="",asotien="", achutien="", achutientu="", anguoithu="", amasothue="",amauso="",aquyenso="",asobienlai="",acucthue="",atongcuc="",adiachibv="",amabn="", atongcp="", atamung="", abhyt="",amien="",athieu="", alydomien="",alydomien1="";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				
				angayin=m_ds.Tables[0].Rows[0]["ngay"].ToString();
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";
				ahoten=m_ds.Tables[0].Rows[0]["hoten"].ToString();
				angaysinh=m_ds.Tables[0].Rows[0]["ngaysinh"].ToString();
				agioitinh=m_ds.Tables[0].Rows[0]["gioitinh"].ToString();
				akhoa=m_ds.Tables[0].Rows[0]["tenkp"].ToString().Trim();;
				adiachi=m_ds.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenquan"].ToString();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tentt"].ToString();
				adiachi=adiachi.Trim().Trim(',').Trim();
				alydo=f_get_lydo_noitru(v_id,v_mmyy_only);//"Thanh toán ra viện bệnh nhân ngoại trú";
				asotien=m_ds.Tables[0].Rows[0]["sotien"].ToString();
				atongcp=m_ds.Tables[0].Rows[0]["tongcp"].ToString();
				atamung=m_ds.Tables[0].Rows[0]["tamung"].ToString();
				abhyt=m_ds.Tables[0].Rows[0]["bhyt"].ToString();
				amien=m_ds.Tables[0].Rows[0]["mien"].ToString();
				athieu=m_ds.Tables[0].Rows[0]["thieu"].ToString();
				alydomien1=m_ds.Tables[0].Rows[0]["lydomien"].ToString();
				achutien="";
				anguoithu=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				amasothue=m_v.s_masothue;
				amauso=m_v.s_maubienlai;
				aquyenso=m_ds.Tables[0].Rows[0]["quyenso"].ToString();;
				asobienlai=m_ds.Tables[0].Rows[0]["sobienlai"].ToString();
				acucthue=lan.Change_language_MessageText("CỤC THUẾ");
				atongcuc=lan.Change_language_MessageText("TỔNG CỤC THUẾ");
				adiachibv=m_v.s_diachi;
				amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();
				string atmp="";
				try
				{
					atmp = decimal.Parse(asotien.ToString()).ToString("###,###,##0.###").PadRight(20,'.');
					atmp=atmp.Substring(0,atmp.IndexOf("."));
				}
				catch
				{
					atmp="0";
				}

				if(atmp=="") atmp="0";
				
				achutien = m_v.Doiso_Unicode(atmp.Replace(",",""));
				if(achutien=="")
				{
					achutien=lan.Change_language_MessageText("không đồng");
				}
				
				try
				{
					atmp = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###").PadRight(20,'.');
					atmp=atmp.Substring(0,atmp.IndexOf("."));
				}
				catch
				{
					atmp="0";
				}
				//MessageBox.Show(atamung.Replace(",",""));
				if(atmp=="") atmp="0";
				achutientu = m_v.Doiso_Unicode(atmp.Replace(",",""));
				if(achutientu=="")
				{
					achutientu=lan.Change_language_MessageText("Không đồng");
				}

				asotien = decimal.Parse(asotien.ToString()).ToString("###,###,##0.###");
				atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,##0.###");
				atamung = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###");
				abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,##0.###");
				amien = decimal.Parse(amien.ToString()).ToString("###,###,##0.###");
				athieu = decimal.Parse(athieu.ToString()).ToString("###,###,##0.###");
				
				atmp="- Tổng chi phí: " + atongcp;
				if(atamung!="0")
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("- Tạm ứng:")+" " + atamung;
				}
				if(abhyt!="0")
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("- BHYT trả:")+" " + abhyt;
				}
				if(amien!="0")
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("- Miễn:")+" " + amien;
				}
				if(athieu!="0")
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("- Thiếu:")+" " + athieu;
				}
				if(alydomien1!="")
				{
					atmp+=" ("+alydomien1+")";
				}
				decimal ahoan=decimal.Parse(atongcp)-decimal.Parse(atamung)-decimal.Parse(abhyt)-decimal.Parse(amien)-decimal.Parse(athieu);
				if(ahoan<0)
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("- Hoàn lại:")+" " + (-1*ahoan).ToString("###,###,###.###");
				}
				else
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("-Thu thêm:")+" " + ahoan.ToString("###,###,###.###");
				}
				alydomien=atmp;

				DataSet ads = f_Cursor_BienlaiNT();
				DataSet adslien = f_get_Soliennoitru_chitamung();
				for(int i=0;i<adslien.Tables[0].Rows.Count;i++)
				{
					DataRow r = ads.Tables[0].NewRow();
					r["syt"]=asyt;
					r["bv"]=abv;
					r["diachibv"]=adiachibv;
					r["tongcucthue"]=atongcuc;
					r["cucthue"]=acucthue;
					r["masothue"]=amasothue;
					r["mauso"]=amauso;
					r["quyenso"]=aquyenso;
					r["sobienlai"]=asobienlai;
					r["ngayin"]=angayin;
					r["nguoiin"]=anguoiin;
					r["ghichu"]=aghichu;
					r["lien"]=adslien.Tables[0].Rows[i][0].ToString().Trim();
					r["mabn"]=amabn;
					r["hoten"]=ahoten;
					r["ngaysinh"]=angaysinh;
					r["gioitinh"]=agioitinh;
					r["khoa"]=akhoa;
					r["diachi"]=adiachi;
					r["lydo"]=alydo;
					r["sotien"]=asotien;
					r["chutien"]=achutien;
					r["tongcp"]=atongcp;
					r["tamung"]=atamung;
					r["bhyt"]=abhyt;
					r["mien"]=amien;
					r["lydomien"]=alydomien;
					r["nguoithu"]=anguoithu;
					ads.Tables[0].Rows.Add(r);
				}
				//ads.WriteXml("..\\..\\datareport\\v_bienlaithuvienphint.xml",XmlWriteMode.WriteSchema);
				//return;

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(ads);
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
                m_v.execute_data_mmyy(v_mmyy_only, "update medibvmmyy.v_ttrvll set lanin=nvl(lanin,0)+1 where to_char(id)='" + v_id + "'");
                cMain.Close(); cMain.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_ChiphiTTRVNoitru(bool v_dir, string v_id, string v_mmyy_only)
		{
			try
			{
				string aReport ="v_thanhtoanravien.rpt";

				m_sql = "select a.id, a.mabn, d.hoten, d.namsinh, dd.hoten_bo, dd.hoten_me, f.tentt tinh, g.tenquan quan,h.tenpxa xa, d.sonha, d.thon, n.ten gioitinh, nvl(l.sothe,'. . . . . . . . . . . . . . ') mabhyt, nvl(to_char(l.denngay,'dd/mm/yyyy'),'. . . . . . . . . . . . . . ') giatriden, ll.mabv, ll.tenbv, cc.sohieu, b.sobienlai, e.tenkp, a.maicd, a.chandoan,  to_char(b.ngay,'dd/mm/yyyy') ngay, to_char(a.ngayvao,'dd/mm/yyyy') ngayvao, to_char(a.ngayra,'dd/mm/yyyy') ngayra, nvl(ngayra-ngayvao,1) songay, a.giuong, i.id id_vp, j.id id_loai, k.ma id_nhom, i.ten tenvp, j.ten tenloaivp, k.ten tennhomvp, i.stt sttvp, j.stt sttloaivp, k.stt sttnhomvp, i.dvt, nvl(c.soluong,0) soluong, nvl(c.dongia,0) dongia, (nvl(c.soluong,0)*nvl(c.dongia,0)) sotien, nvl(b.sotien,0) tongcp, nvl(b.bhyt,0) bhyt , nvl(b.tamung,0) tamung, nvl(b.mien,0) mien, nvl(b.thieu,0) thieu, (nvl(b.sotien,0)-nvl(b.bhyt,0)-nvl(b.mien,0)-nvl(b.tamung,0)-nvl(b.thieu,0)) bntra , c.madoituong, m.hoten nguoithu from v_ttrvds a, v_ttrvll b, v_ttrvct c, v_quyenso cc, btdbn d, hcnhi dd, btdkp_bv e, btdtt f, btdquan g, btdpxa h, (select g1.id, g1.stt, g1.ten, g1.dvt, g1.id_loai,g2.id_nhom from v_giavp g1, v_loaivp g2 where g1.id_loai=g2.id(+) union select d1.id, rownum stt, trim(d1.ten||'['||trim(d1.tenhc)||'] '||d1.hamluong) ten, d1.dang dvt, 0 id_loai, nvl(d2.nhomvp,0) id_nhom from d_dmbd d1, d_dmnhom d2 where d1.manhom=d2.id(+)) i, (select id, id_nhom, stt, ten from v_loaivp union all select 0 id, 0 id_nhom, 1 stt, null ten from dual) j, (select ma, ten, stt from v_nhomvp union all select 0 ma, null ten, 1 stt from dual) k, bhyt l, dstt ll, medibv.v_dlogin m, dmphai n where a.id=b.id(+) and a.id=c.id(+) and a.mabn=d.mabn(+) and d.phai=n.ma(+) and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and b.makp=e.makp(+) and b.userid=m.id(+) and c.mavp=i.id(+) and i.id_loai = j.id(+) and i.id_nhom=k.ma(+) and a.maql=l.maql(+) and l.mabv=ll.mabv(+) and b.quyenso=cc.id(+) and d.mabn=dd.mabn(+) and to_char(a.id)='"+v_id+"'";
				if(v_mmyy_only=="")
				{
					m_ds = m_v.get_data_bc(DateTime.Now,DateTime.Now,m_sql);
				}
				else
				{
					m_ds = m_v.get_data_mmyy(v_mmyy_only,m_sql);
				}
				//MessageBox.Show(m_sql);
				//m_ds.WriteXml("..\\..\\Datareport\\v_thanhtoanravien.xml",XmlWriteMode.WriteSchema);
				//return;

				aReport =f_get_report_inchiphi(m_ds.Tables[0].Rows[0]["madoituong"].ToString());
				if(!System.IO.File.Exists("..\\..\\..\\Report\\"+aReport.Trim()))
				{
					aReport ="v_thanhtoanravien.rpt";
				}

				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy chứng  từ thu chi thanh toán ra viện <")+v_id+">",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				
				this.Text="Phiếu thanh toán ra viện bệnh nhân nội trú ("+aReport+")";
				string asyt="",abv="",angayin="",anguoiin="",aghichu="";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				
				angayin=f_GetNgay(m_ds.Tables[0].Rows[0]["ngay"].ToString());
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(m_ds);
				cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
				cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
				cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
                cMain.Close(); cMain.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		private string f_get_report_inchiphi(string v_madoituong)
		{
			string r="";
			try
			{
				r = m_v.get_data("select reportname from doituong where to_char(madoituong)='"+v_madoituong+"'").Tables[0].Rows[0][0].ToString();
			}
			catch
			{
				m_v.execute_data("alter table doituong add reportname varchar2(50)");
				r="";
			}
			return r;
		}
		public void f_Print_ChiphiTTRVNoitruCT(bool v_dir, string v_id, string v_mmyy_only)
		{
			try
			{
				string aReport ="v_thanhtoanravien_chitiet.rpt";

				m_sql = "select a.id, a.mabn, d.hoten, d.namsinh, dd.hoten_bo, dd.hoten_me, f.tentt tinh, g.tenquan quan,h.tenpxa xa, d.sonha, d.thon, n.ten gioitinh, nvl(l.sothe,'. . . . . . . . . . . . . . ') mabhyt, nvl(to_char(l.denngay,'dd/mm/yyyy'),'. . . . . . . . . . . . . . ') giatriden, ll.mabv, ll.tenbv, cc.sohieu, b.sobienlai, e.tenkp, a.maicd, a.chandoan,  to_char(b.ngay,'dd/mm/yyyy') ngay, to_char(a.ngayvao,'dd/mm/yyyy') ngayvao, to_char(a.ngayra,'dd/mm/yyyy') ngayra, nvl(ngayra-ngayvao,1) songay, a.giuong, i.id id_vp, j.id id_loai, k.ma id_nhom, i.ten tenvp, j.ten tenloaivp, k.ten tennhomvp, i.stt sttvp, j.stt sttloaivp, k.stt sttnhomvp, i.dvt, nvl(c.soluong,0) soluong, nvl(c.dongia,0) dongia, (nvl(c.soluong,0)*nvl(c.dongia,0)) sotien, nvl(b.sotien,0) tongcp, nvl(b.bhyt,0) bhyt , nvl(b.tamung,0) tamung, nvl(b.mien,0) mien, nvl(b.thieu,0) thieu, (nvl(b.sotien,0)-nvl(b.bhyt,0)-nvl(b.mien,0)-nvl(b.thieu,0)-nvl(b.tamung,0)) bntra , c.madoituong, m.hoten nguoithu from v_ttrvds a, v_ttrvll b, v_ttrvct c, v_quyenso cc, btdbn d, hcnhi dd, btdkp_bv e, btdtt f, btdquan g, btdpxa h, (select g1.id, g1.stt, g1.ten, g1.dvt, g1.id_loai,g2.id_nhom from v_giavp g1, v_loaivp g2 where g1.id_loai=g2.id(+) union select d1.id, rownum stt, trim(d1.ten||'['||trim(d1.tenhc)||'] '||d1.hamluong) ten, d1.dang dvt, 0 id_loai, nvl(d2.nhomvp,0) id_nhom from d_dmbd d1, d_dmnhom d2 where d1.manhom=d2.id(+)) i, (select id, id_nhom, stt, ten from v_loaivp union all select 0 id, 0 id_nhom, 1 stt, null ten from dual) j, (select ma, ten, stt from v_nhomvp union all select 0 ma, null ten, 1 stt from dual) k, bhyt l, dstt ll, medibv.v_dlogin m, dmphai n where a.id=b.id(+) and a.id=c.id(+) and a.mabn=d.mabn(+) and d.phai=n.ma(+) and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and b.makp=e.makp(+) and b.userid=m.id(+) and c.mavp=i.id(+) and i.id_loai = j.id(+) and i.id_nhom=k.ma(+) and a.maql=l.maql(+) and l.mabv=ll.mabv(+) and b.quyenso=cc.id(+) and d.mabn=dd.mabn(+) and to_char(a.id)='"+v_id+"'";
				if(v_mmyy_only=="")
				{
					m_ds = m_v.get_data_bc(DateTime.Now,DateTime.Now,m_sql);
				}
				else
				{
					m_ds = m_v.get_data_mmyy(v_mmyy_only,m_sql);
				}
				//MessageBox.Show(m_sql+m_ds.Tables[0].Rows.Count.ToString());
				//m_ds.WriteXml("..\\..\\Datareport\\v_thanhtoanravien.xml",XmlWriteMode.WriteSchema);
				//return;

				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy chứng  từ thu chi thanh toán ra viện <")+v_id+">",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				aReport =f_get_report_inchiphi(m_ds.Tables[0].Rows[0]["madoituong"].ToString());
				if(!System.IO.File.Exists("..\\..\\..\\Report\\"+aReport.Trim()))
				{
					aReport ="v_thanhtoanravien_chitiet.rpt";
				}
				
				this.Text="Phiếu thanh toán ra viện bệnh nhân nội trú ("+aReport+")";
				string asyt="",abv="",angayin="",anguoiin="",aghichu="";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				
				angayin=f_GetNgay(m_ds.Tables[0].Rows[0]["ngay"].ToString());
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(m_ds);
				cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
				cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
				cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.Text=this.Text.Trim()+" ("+aReport+")";
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
                cMain.Close(); cMain.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		private void f_Sum_ttrv(DataSet v_ds, string v_mabn, string v_maql, string v_done, string v_madoituong)
		{
			try
			{
				string adoituong_giadv=m_v.s_doituong_giadv;
				string sql="",aexp="";
				DataSet adsgia = new DataSet();
				sql="select a.id,a.stt,a.ten,a.dang,a.hamluong, c.ma id_nhomvp, c.stt sttnhomvp, c.ten tennhomvp from d_dmbd a, d_dmnhom b, v_nhomvp c where a.manhom=b.id and b.nhomvp=c.ma(+)";
				sql+="union all select a.id,a.stt,a.ten,a.dvt dang, null hamluong, c.ma id_nhomvp, c.stt sttnhomvp, c.ten tennhomvp from v_giavp a, v_loaivp b, v_nhomvp c where a.id_loai=b.id(+) and b.id_nhom=c.ma(+)";
				adsgia = m_v.get_data(sql);
				
				DataSet ads = v_ds.Copy();
				v_ds.Tables[0].Rows.Clear();
				if(v_madoituong!="") aexp="madoituong in ("+v_madoituong+")";
				//Thuốc
				foreach(DataRow r1 in m_v.get_d_tienthuoc(v_mabn,v_maql,"",v_done).Tables[0].Select(aexp))
				{
					try
					{
						v_ds.Tables[0].Rows.Add(ads.Tables[0].Rows[0].ItemArray);
						v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["ngay"]=r1["ngaynhap"].ToString();
						v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["soluong"]=r1["soluong"].ToString();
						v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["madoituong"]=r1["madoituong"].ToString();
						if(adoituong_giadv.IndexOf(r1["madoituong"].ToString().Trim()+",")>=0)
						{
							v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["dongia"]=decimal.Parse(decimal.Parse(r1["giaban"].ToString()).ToString("###,###,##0.###"));
						}
						else
						{
							v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["dongia"]=decimal.Parse((decimal.Parse(r1["sotien"].ToString())/decimal.Parse(r1["soluong"].ToString())).ToString("###,###,##0.###"));
						}
						v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["sotien"]=decimal.Parse(v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["soluong"].ToString())*decimal.Parse(v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["dongia"].ToString());

						DataRow r2 = adsgia.Tables[0].Select("id="+r1["mabd"].ToString())[0];

						v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["id_vp"]=r2["id"].ToString();
						v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["id_loai"]=r2["id_nhomvp"].ToString();
						v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["id_nhom"]=r2["id_nhomvp"].ToString();
						v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["tenvp"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString();
						v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["dvt"]=r2["dang"].ToString();
						v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["tenloaivp"]=r2["tennhomvp"].ToString();
						v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["tennhomvp"]=r2["tennhomvp"].ToString();
					}
					catch
					{
					}
				}
				//VPKhoa
				foreach(DataRow r1 in m_v.get_v_vpkhoa(v_mabn,v_maql,"",v_done).Tables[0].Select(aexp))
				{
					try
					{
						v_ds.Tables[0].Rows.Add(ads.Tables[0].Rows[0].ItemArray);
						v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["ngay"]=r1["ngaynhap"].ToString();
						v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["soluong"]=r1["soluong"].ToString();
						v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["dongia"]=decimal.Parse(decimal.Parse(r1["dongia"].ToString()).ToString("###,###,##0.###"));
						v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["sotien"]=decimal.Parse(v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["soluong"].ToString())*decimal.Parse(v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["dongia"].ToString());
						v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["madoituong"]=r1["madoituong"].ToString();

						DataRow r2 = adsgia.Tables[0].Select("id="+r1["mavp"].ToString())[0];

						v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["id_vp"]=r2["id"].ToString();
						v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["id_loai"]=r2["id_nhomvp"].ToString();
						v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["id_nhom"]=r2["id_nhomvp"].ToString();
						v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["tenvp"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString();
						v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["dvt"]=r2["dang"].ToString();
						v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["tenloaivp"]=r2["tennhomvp"].ToString();
						v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["tennhomvp"]=r2["tennhomvp"].ToString();
					}
					catch
					{
					}
				}
				
				try
				{
					foreach(DataRow r2 in m_v.get_v_tamung(v_mabn,v_maql,"","0","0").Tables[0].Rows)
					{
						foreach(DataRow r3 in v_ds.Tables[0].Select("madoituong="+r2["madoituong"].ToString()))
						{
							r3["tamung"]=decimal.Parse(r3["tamung"].ToString())+decimal.Parse(r2["sotien"].ToString());
						}
					}
				}
				catch
				{
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		public void f_Print_TTRV(bool v_dir, string v_mabn, string v_maql, string v_loai, string v_done, string v_madoituong, string v_mmyy_only)
		{
			string aReport ="v_thanhtoanravien_chitiet.rpt";
			try
			{
				this.Text=lan.Change_language_MessageText("Phiếu thanh toán ra viện bệnh nhân nội trú");

				m_sql = "select 0 id, a.mabn, a.hoten, a.namsinh, d.hoten_bo, d.hoten_me, f.tentt tinh, g.tenquan quan,h.tenpxa xa, a.sonha, a.thon, k.ten gioitinh, nvl(i.sothe,'. . . . . . . . . . . . . . ') mabhyt, nvl(to_char(i.denngay,'dd/mm/yyyy'),'. . . . . . . . . . . . . . ') giatriden, j.mabv, j.tenbv, '' sohieu, 0 sobienlai, e.tenkp, c.maicd, c.chandoan,  '' ngay, to_char(b.ngay,'dd/mm/yyyy hh24:mi') ngayvao, to_char(c.ngay,'dd/mm/yyyy hh24:mi') ngayra, decode(nvl(to_date(c.ngay,'dd/mm/yy')-to_date(b.ngay,'dd/mm/yy'),1),0,1) songay, '' giuong, 0 id_vp, 0 id_loai, 0 id_nhom, '' tenvp, '' tenloaivp, '' tennhomvp, 0 sttvp, 0 sttloaivp, 0 sttnhomvp, null dvt, 0 soluong, 0  dongia, 0 sotien, 0 tongcp, 0 bhyt , 0 tamung, 0 mien, 0 bntra , 0 madoituong, '' nguoithu from btdbn a, benhandt b, xuatvien c, hcnhi d, btdkp_bv e, btdtt f, btdquan g, btdpxa h, bhyt i, dstt j, dmphai k where a.mabn=b.mabn and a.mabn=d.mabn(+) and b.maql=c.maql(+) and a.phai=k.ma(+) and a.matt=f.matt(+) and a.maqu=g.maqu(+) and a.maphuongxa=h.maphuongxa(+) and c.makp=e.makp(+) and b.maql=i.maql(+) and i.mabv=j.mabv(+) and a.mabn='"+v_mabn+"' and to_char(b.maql)='"+v_maql+"'";
				if(v_mmyy_only=="")
				{
					m_ds = m_v.get_data_bc(DateTime.Now,DateTime.Now,m_sql);
				}
				else
				{
					m_ds = m_v.get_data_mmyy(v_mmyy_only,m_sql);
				}
				f_Sum_ttrv(m_ds,v_mabn,v_maql,v_done,v_madoituong);
				//MessageBox.Show(m_sql+m_ds.Tables[0].Rows.Count.ToString());
				//m_ds.WriteXml("..\\..\\Datareport\\v_thanhtoanravien.xml",XmlWriteMode.WriteSchema);
				//return;

				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không có số liệu <mabn: ")+v_mabn+", maql: "+v_maql+">",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				DataSet ads1=m_v.get_v_tamung(v_mabn,v_maql,"","0","0");
				ads1.Tables[0].TableName="TableTU";
				m_ds.Tables.Add(ads1.Tables[0].Copy());
				//m_ds.WriteXml("..\\..\\Datareport\\v_thanhtoanravien.xml",XmlWriteMode.WriteSchema);
				
				//aReport =f_get_report_inchiphi(m_ds.Tables[0].Rows[0]["madoituong"].ToString());
				//if(!System.IO.File.Exists("..\\..\\..\\Report\\"+aReport.Trim()))
				//{
				//	aReport ="v_thanhtoanravien_chitiet.rpt";
				//}
				switch (v_loai)
				{
					case "2"://ttrvtreem
						aReport ="v_thanhtoanravien_chitiet_treem.rpt";
						break;
					case "3"://ttrvbhyt
						aReport ="v_thanhtoanravien_chitiet_bhyt.rpt";
						break;
					case "4"://cong khai thuoc
						aReport ="v_thanhtoanravien_chitiet_thuoc.rpt";
						break;
					case "1"://ttrv
					default:
						aReport ="v_thanhtoanravien_chitiet.rpt";
						break;
				}
				if(!System.IO.File.Exists("..\\..\\..\\report\\"+aReport))
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy Report: ")+aReport,m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Warning);
					aReport ="v_thanhtoanravien_chitiet.rpt";
				}
				string asyt="",abv="",angayin="",anguoiin="",aghichu="";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				
				angayin=f_GetNgay(m_ds.Tables[0].Rows[0]["ngay"].ToString());
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(m_ds);
				cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
				cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
				cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.Text=this.Text.Trim()+" ("+aReport+")";
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
                cMain.Close(); cMain.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString()+"\n"+aReport,m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_BienlaiNT_Thuong(bool v_dir, string v_id, string v_mmyy_only)
		{
			try
			{
				this.Text="In biên lai thu viện phí nội trú (v_bienlaithuvienphint_thuong.rpt)";
				string aReport ="v_bienlaithuvienphint_thuong.rpt";

				m_sql = "select a.id, b.mabn, a.sobienlai, nvl(a.sotien,0) tongcp, (nvl(a.sotien,0)-nvl(a.bhyt,0)-nvl(a.mien,0)-nvl(a.thieu,0)) sotien , nvl(a.tamung,0) tamung, nvl(a.mien,0) mien, nvl(a.bhyt,0) bhyt, nvl(a.thieu,0) thieu, to_char(a.ngay,'dd/mm/yyyy') ngay, c.tenkp, d.mabn, d.hoten, decode(d.ngaysinh,null,d.namsinh,to_char(d.ngaysinh,'dd/mm/yyyy')) ngaysinh, e.ten gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') ngaythu, j.hoten nguoithu, i.sohieu quyenso from v_ttrvll a, v_ttrvds b, btdkp_bv c, btdbn d, dmphai e, btdtt f, btdquan g, btdpxa h, v_quyenso i, medibv.v_dlogin j where b.id=a.id and a.makp=c.makp(+) and b.mabn=d.mabn and d.phai=e.ma and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.quyenso = i.id and a.userid=j.id(+) and to_char(a.id)='"+v_id+"'";
				if(v_mmyy_only=="")
				{
					m_ds = m_v.get_data_bc(DateTime.Now,DateTime.Now,m_sql);
				}
				else
				{
					m_ds = m_v.get_data_mmyy(v_mmyy_only,m_sql);
				}
				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy biên lai thu viện phí nội trú <")+v_id+">",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				//m_ds.WriteXml("..\\v_rptBienlaiKB.xml",XmlWriteMode.WriteSchema);
				//return;
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="",ahoten="", angaysinh="", agioitinh="", akhoa="",adiachi="", alydo="",asotien="", achutien="", achutientu="", anguoithu="", amasothue="",amauso="",aquyenso="",asobienlai="",acucthue="",atongcuc="",adiachibv="",amabn="", atongcp="", atamung="", abhyt="",amien="",athieu="", alydomien="";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				
				angayin=m_ds.Tables[0].Rows[0]["ngay"].ToString();
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";
				ahoten=m_ds.Tables[0].Rows[0]["hoten"].ToString();
				angaysinh=m_ds.Tables[0].Rows[0]["ngaysinh"].ToString();
				agioitinh=m_ds.Tables[0].Rows[0]["gioitinh"].ToString();
				akhoa=m_ds.Tables[0].Rows[0]["tenkp"].ToString().Trim();;
				adiachi=m_ds.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenquan"].ToString();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tentt"].ToString();
				adiachi=adiachi.Trim().Trim(',').Trim();
				alydo=f_get_lydo_noitru(v_id,v_mmyy_only);//"Thanh toán ra viện bệnh nhân ngoại trú";
				asotien=m_ds.Tables[0].Rows[0]["sotien"].ToString();
				atongcp=m_ds.Tables[0].Rows[0]["tongcp"].ToString();
				atamung=m_ds.Tables[0].Rows[0]["tamung"].ToString();
				abhyt=m_ds.Tables[0].Rows[0]["bhyt"].ToString();
				amien=m_ds.Tables[0].Rows[0]["mien"].ToString();
				athieu=m_ds.Tables[0].Rows[0]["thieu"].ToString();
				alydomien="";//m_ds.Tables[0].Rows[0]["lydomien"].ToString();
				achutien="";
				anguoithu=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				amasothue=m_v.s_masothue;
				amauso=m_v.s_maubienlai;
				aquyenso=m_ds.Tables[0].Rows[0]["quyenso"].ToString();;
				asobienlai=m_ds.Tables[0].Rows[0]["sobienlai"].ToString();
				acucthue=lan.Change_language_MessageText("CỤC THUẾ");
				atongcuc=lan.Change_language_MessageText("TỔNG CỤC THUẾ");
				adiachibv=m_v.s_diachi;
				amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();
				string atmp="";
				try
				{
					atmp = decimal.Parse(asotien.ToString()).ToString("###,###,##0.###").PadRight(20,'.');
					atmp=atmp.Substring(0,atmp.IndexOf("."));
				}
				catch
				{
					atmp="0";
				}

				if(atmp=="") atmp="0";
				
				achutien = m_v.Doiso_Unicode(atmp.Replace(",",""));
				if(achutien=="")
				{
					achutien=lan.Change_language_MessageText("không đồng");
				}
				
				try
				{
					atmp = decimal.Parse(atmp.ToString()).ToString("###,###,##0.###").PadRight(20,'.');
					atmp=atmp.Substring(0,atmp.IndexOf("."));
				}
				catch
				{
					atmp="0";
				}
				//MessageBox.Show(atamung.Replace(",",""));
				if(atmp=="") atmp="0";
				achutientu = m_v.Doiso_Unicode(atmp.Replace(",",""));
				if(achutientu=="")
				{
					achutientu=lan.Change_language_MessageText("Không đồng");
				}

				asotien = decimal.Parse(asotien.ToString()).ToString("###,###,##0.###").Length>0?decimal.Parse(asotien.ToString()).ToString("###,###,##0.###")+lan.Change_language_MessageText("đồng"): lan.Change_language_MessageText("0đồng");
				atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,##0.###").Length>0?decimal.Parse(atongcp.ToString()).ToString("###,###,##0.###")+lan.Change_language_MessageText("đồng"): lan.Change_language_MessageText("0đồng");
				atamung = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###").Length>0?decimal.Parse(atamung.ToString()).ToString("###,###,##0.###")+lan.Change_language_MessageText("đồng"): lan.Change_language_MessageText("0đồng");
				abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,##0.###").Length>0?decimal.Parse(abhyt.ToString()).ToString("###,###,##0.###")+lan.Change_language_MessageText("đồng"): lan.Change_language_MessageText("0đồng");
				amien = decimal.Parse(amien.ToString()).ToString("###,###,##0.###").Length>0?decimal.Parse(amien.ToString()).ToString("###,###,##0.###")+lan.Change_language_MessageText("đồng"): lan.Change_language_MessageText("0đồng");
				athieu = decimal.Parse(athieu.ToString()).ToString("###,###,##0.###").Length>0?decimal.Parse(athieu.ToString()).ToString("###,###,##0.###")+lan.Change_language_MessageText("đồng"): lan.Change_language_MessageText("0đồng");
				
				atmp="- Tổng chi phí: " + atongcp;
				if(atamung!=lan.Change_language_MessageText("0đồng"))
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("- Tạm ứng:")+" " + atamung;
				}
				if(abhyt!=lan.Change_language_MessageText("0đồng"))
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("- BHYT trả:")+" " + abhyt;
				}
				if(amien!=lan.Change_language_MessageText("0đồng"))
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("- Miễn:")+" " + amien;
				}
				if(athieu!="")
				{
					atmp = atmp+ "- Thiếu: " + athieu;
				}
				if(alydomien!="")
				{
					atmp = atmp+ "- Lý do miễn: " + alydomien;
				}
				alydomien=atmp;

				DataSet ads = f_Cursor_BienlaiNT();
				DataSet adslien = f_get_Soliennoitru_thuong();
				for(int i=0;i<adslien.Tables[0].Rows.Count;i++)
				{
					DataRow r = ads.Tables[0].NewRow();
					r["syt"]=asyt;
					r["bv"]=abv;
					r["diachibv"]=adiachibv;
					r["tongcucthue"]=atongcuc;
					r["cucthue"]=acucthue;
					r["masothue"]=amasothue;
					r["mauso"]=amauso;
					r["quyenso"]=aquyenso;
					r["sobienlai"]=asobienlai;
					r["ngayin"]=angayin;
					r["nguoiin"]=anguoiin;
					r["ghichu"]=aghichu;
					r["lien"]=adslien.Tables[0].Rows[i][0].ToString().Trim();
					r["mabn"]=amabn;
					r["hoten"]=ahoten;
					r["ngaysinh"]=angaysinh;
					r["gioitinh"]=agioitinh;
					r["khoa"]=akhoa;
					r["diachi"]=adiachi;
					r["lydo"]=alydo;
					r["sotien"]=asotien;
					r["chutien"]=achutien;
					r["tongcp"]=atongcp;
					r["tamung"]=atamung;
					r["bhyt"]=abhyt;
					r["mien"]=amien;
					r["lydomien"]=alydomien;
					r["nguoithu"]=anguoithu;
					ads.Tables[0].Rows.Add(r);
				}
				//ads.WriteXml("..\\..\\datareport\\v_bienlaithuvienphint.xml",XmlWriteMode.WriteSchema);
				//return;

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(ads);
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
                cMain.Close(); cMain.Dispose();
//				if(atamung!=lan.Change_language_MessageText("0đồng"))
//				{
//					foreach(DataRow r in ads.Tables[0].Rows)
//					{
//						r["chutien"]=achutientu;
//						r["lydo"]="Hoàn trả tiền tạm ứng";
//					}
//					aReport ="v_phieuchi.rpt";
//					cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
//					cMain.SetDataSource(ads);
//					//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
//					//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 
//
//					if(!v_dir)
//					{
//						this.crystalReportViewer1.ReportSource=cMain;
//						this.WindowState=FormWindowState.Maximized;
//						this.ShowDialog(this.Parent);
//					}
//					else
//					{
//						cMain.PrintToPrinter(1,false,0,0);
//					}
//				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		private string f_get_lydo_ngoaitru(string v_id, string v_mmyy_only)
		{
			try
			{
				DataSet ads = new DataSet();
				decimal asoluong=0;
				string alydo="",alydobh="";
				if(v_mmyy_only=="")
				{
					ads= m_v.get_data_bc(DateTime.Now,DateTime.Now,"select a.mavp, a.madoituong, sum(a.soluong) soluong, b.ten from v_ttrvct a, (select id, ten from v_giavp union all select id, ten||' '||hamluong ten from d_dmbd) b where a.mavp=b.id and to_char(a.id)='"+v_id+"' group by a.mavp,a.madoituong,b.ten");
				}
				else
				{
					ads= m_v.get_data_mmyy(v_mmyy_only,"select a.mavp, a.madoituong, sum(a.soluong) soluong, b.ten from v_ttrvct a, (select id, ten from v_giavp union all select id, ten||' '||hamluong ten from d_dmbd) b where a.mavp=b.id and to_char(a.id)='"+v_id+"' group by a.mavp,a.madoituong,b.ten");
				}
				for(int i=0;i<ads.Tables[0].Rows.Count;i++)
				{
					try
					{
						asoluong = decimal.Parse(ads.Tables[0].Rows[i]["soluong"].ToString());
					}
					catch
					{
						asoluong=0;
					}

					if(ads.Tables[0].Rows[i]["madoituong"].ToString()=="1")
					{
						alydobh=alydobh.Trim().Trim(',')+ ", " + ads.Tables[0].Rows[i]["ten"].ToString();
						if(asoluong>1)
						{
							alydobh=alydobh + " (" + asoluong.ToString()+")";
						}
					}
					else
					{
						alydo=alydo.Trim().Trim(',')+ ", " + ads.Tables[0].Rows[i]["ten"].ToString();
						if(asoluong>1)
						{
							alydo=alydo + " (" + asoluong.ToString()+")";
						}
					}
				}
				alydo=alydo.Trim().Trim(',');
				alydobh=alydobh.Trim().Trim(',');
				if(alydobh!="")
				{
					alydo=alydo+ lan.Change_language_MessageText(", BHYT(") + alydobh + ")";
				}
				alydo=alydo.Trim().Trim(',');
				alydo=alydo.Trim();
				return alydo;
			}
			catch//(Exception ex)
			{
				//MessageBox.Show(ex.ToString());
				return "";
			}
		}
		public void f_Print_BienlaiNgoaitru(bool v_dir, string v_id, string v_mmyy_only)
		{
			try
			{
				this.Text=lan.Change_language_MessageText("In biên lai thu viện phí ngoại trú (v_bienlaithuvienphingoaitru.rpt)");
				string aReport ="v_bienlaithuvienphingoaitru.rpt";

				m_sql = "select a.id, b.mabn, a.sobienlai, nvl(a.sotien,0) tongcp, (nvl(a.sotien,0)-nvl(a.bhyt,0)-nvl(a.mien,0)) sotien , nvl(a.tamung,0) tamung, nvl(a.mien,0) mien, nvl(a.bhyt,0) bhyt , to_char(a.ngay,'dd/mm/yyyy') ngay, c.tenkp, d.mabn, d.hoten, decode(d.ngaysinh,null,d.namsinh,to_char(d.ngaysinh,'dd/mm/yyyy')) ngaysinh, e.ten gioitinh,  f.tentt, g.tenquan,h.tenpxa, to_char(a.ngay,'dd/mm/yyyy') ngaythu, j.hoten nguoithu, i.sohieu quyenso from v_ttrvll a, v_ttrvds b, btdkp_bv c, btdbn d, dmphai e, btdtt f, btdquan g, btdpxa h, v_quyenso i, medibv.v_dlogin j where b.id=a.id and a.makp=c.makp(+) and b.mabn=d.mabn and d.phai=e.ma and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and a.quyenso = i.id and a.userid=j.id(+) and to_char(a.id)='"+v_id+"'";
				if(v_mmyy_only=="")
				{
					m_ds = m_v.get_data_bc(DateTime.Now,DateTime.Now,m_sql);
				}
				else
				{
					m_ds = m_v.get_data_mmyy(v_mmyy_only,m_sql);
				}
				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy biên lai thu viện phí<")+v_id+">",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				//m_ds.WriteXml("..\\v_rptBienlaiKB.xml",XmlWriteMode.WriteSchema);
				//return;
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="",ahoten="", angaysinh="", agioitinh="", akhoa="",adiachi="", alydo="",asotien="", achutien="", achutientu="", anguoithu="", amasothue="",amauso="",aquyenso="",asobienlai="",acucthue="",atongcuc="",adiachibv="",amabn="", atongcp="", atamung="", abhyt="",amien="", alydomien="";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				
				angayin=m_ds.Tables[0].Rows[0]["ngay"].ToString();
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";
				ahoten=m_ds.Tables[0].Rows[0]["hoten"].ToString();
				angaysinh=m_ds.Tables[0].Rows[0]["ngaysinh"].ToString();
				agioitinh=m_ds.Tables[0].Rows[0]["gioitinh"].ToString();
				akhoa=m_ds.Tables[0].Rows[0]["tenkp"].ToString().Trim();;
				adiachi=m_ds.Tables[0].Rows[0]["tenpxa"].ToString().Trim();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tenquan"].ToString();
				adiachi=adiachi.Trim().Replace(lan.Change_language_MessageText("Không xác định"),"").Trim().Trim(',')+ ", " + m_ds.Tables[0].Rows[0]["tentt"].ToString();
				adiachi=adiachi.Trim().Trim(',').Trim();
				alydo=f_get_lydo_ngoaitru(v_id,v_mmyy_only);//"Thanh toán ra viện bệnh nhân ngoại trú";
				asotien=m_ds.Tables[0].Rows[0]["sotien"].ToString();
				atongcp=m_ds.Tables[0].Rows[0]["tongcp"].ToString();
				atamung=m_ds.Tables[0].Rows[0]["tamung"].ToString();
				abhyt=m_ds.Tables[0].Rows[0]["bhyt"].ToString();
				amien=m_ds.Tables[0].Rows[0]["mien"].ToString();
				alydomien="";//m_ds.Tables[0].Rows[0]["lydomien"].ToString();
				achutien="";
				anguoithu=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				amasothue=m_v.s_masothue;
				amauso=m_v.s_maubienlai;
				aquyenso=m_ds.Tables[0].Rows[0]["quyenso"].ToString();;
				asobienlai=m_ds.Tables[0].Rows[0]["sobienlai"].ToString();
				acucthue=lan.Change_language_MessageText("CỤC THUẾ");
				atongcuc=lan.Change_language_MessageText("TỔNG CỤC THUẾ");
				adiachibv=m_v.s_diachi;
				amabn=m_ds.Tables[0].Rows[0]["mabn"].ToString();
				string atmp="";
				try
				{
					atmp = decimal.Parse(asotien.ToString()).ToString("###,###,##0.##").PadRight(20,'.');
					atmp=atmp.Substring(0,atmp.IndexOf("."));
				}
				catch
				{
					atmp="0";
				}

				if(atmp=="") atmp="0";
				
				achutien = m_v.Doiso_Unicode(atmp.Replace(",",""));

				if(achutien=="")
				{
					achutien=lan.Change_language_MessageText("không đồng");
				}
				
				try
				{
					atmp = decimal.Parse(atamung.ToString()).ToString("###,###,##0.##").PadRight(20,'.');
					atmp=atmp.Substring(0,atmp.IndexOf("."));
				}
				catch
				{
					atmp="0";
				}
				//MessageBox.Show(atamung.Replace(",",""));
				if(atmp=="") atmp="0";
				achutientu = m_v.Doiso_Unicode(atmp.Replace(",",""));
				if(achutientu=="")
				{
					achutientu=lan.Change_language_MessageText("Không đồng");
				}

				asotien = decimal.Parse(asotien.ToString()).ToString("###,###,##0.###").Length>0?decimal.Parse(asotien.ToString()).ToString(): "0";
				atongcp = decimal.Parse(atongcp.ToString()).ToString("###,###,##0.###").Length>0?decimal.Parse(atongcp.ToString()).ToString(): "0";
				atamung = decimal.Parse(atamung.ToString()).ToString("###,###,##0.###").Length>0?decimal.Parse(atamung.ToString()).ToString(): "0";
				abhyt = decimal.Parse(abhyt.ToString()).ToString("###,###,##0.###").Length>0?decimal.Parse(abhyt.ToString()).ToString(): "0";
				amien = decimal.Parse(amien.ToString()).ToString("###,###,##0.###").Length>0?decimal.Parse(amien.ToString()).ToString(): "0";
				
				atmp=lan.Change_language_MessageText("- Tổng chi phí: ") + atongcp;
				if(atamung!=lan.Change_language_MessageText("0đồng"))
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("- Tạm ứng:")+" " + atamung;
				}
				if(abhyt!=lan.Change_language_MessageText("0đồng"))
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("- BHYT trả:")+" " + abhyt;
				}
				if(amien!=lan.Change_language_MessageText("0đồng"))
				{
					atmp = atmp+ "\n"+lan.Change_language_MessageText("- Miễn:")+" " + amien;
				}
				if(alydomien!="")
				{
					atmp = atmp+ "- Lý do miễn: " + alydomien;
				}
				alydomien=atmp;

				DataSet ads = f_Cursor_BienlaiNT();
				DataSet adslien = f_get_Solienngoaitru();
				for(int i=0;i<adslien.Tables[0].Rows.Count;i++)
				{
					DataRow r = ads.Tables[0].NewRow();
					r["syt"]=asyt;
					r["bv"]=abv;
					r["diachibv"]=adiachibv;
					r["tongcucthue"]=atongcuc;
					r["cucthue"]=acucthue;
					r["masothue"]=amasothue;
					r["mauso"]=amauso;
					r["quyenso"]=aquyenso;
					r["sobienlai"]=asobienlai;
					r["ngayin"]=angayin;
					r["nguoiin"]=anguoiin;
					r["ghichu"]=aghichu;
					r["lien"]=adslien.Tables[0].Rows[i][0].ToString();
					r["mabn"]=amabn;
					r["hoten"]=ahoten;
					r["ngaysinh"]=angaysinh;
					r["gioitinh"]=agioitinh;
					r["khoa"]=akhoa;
					r["diachi"]=adiachi;
					r["lydo"]=alydo;
					r["sotien"]=asotien;
					r["chutien"]=achutien;
					r["tongcp"]=atongcp;
					r["tamung"]=atamung;
					r["bhyt"]=abhyt;
					r["mien"]=amien;
					r["lydomien"]=alydomien;
					r["nguoithu"]=anguoithu;
					ads.Tables[0].Rows.Add(r);
				}
				//ads.WriteXml("..\\..\\datareport\\v_bienlaithuvienphint.xml",XmlWriteMode.WriteSchema);
				//return;

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(ads);
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
                cMain.Close(); cMain.Dispose();
//				if(atamung!=lan.Change_language_MessageText("0đồng"))
//				{
//					foreach(DataRow r in ads.Tables[0].Rows)
//					{
//						r["chutien"]=achutientu;
//						r["lydo"]="Hoàn trả tiền tạm ứng";
//					}
//					aReport ="v_phieuchi.rpt";
//					cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
//					cMain.SetDataSource(ads);
//					cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
//					cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 
//
//					if(!v_dir)
//					{
//						this.crystalReportViewer1.ReportSource=cMain;
//						this.WindowState=FormWindowState.Maximized;
//						this.ShowDialog(this.Parent);
//					}
//					else
//					{
//						cMain.PrintToPrinter(1,false,0,0);
//					}
//				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_ChiphiTTRVNgoaitru(bool v_dir, string v_id, string v_mmyy_only)
		{
			try
			{
				this.Text=lan.Change_language_MessageText("Phiếu thanh toán ra viện bệnh nhân ngoại trú (v_thanhtoanravienngoaitru.rpt)");
				string aReport ="v_thanhtoanravienngoaitru.rpt";

				m_sql = "select a.id, a.mabn, d.hoten, d.namsinh, dd.hoten_bo, dd.hoten_me, f.tentt tinh, g.tenquan quan,h.tenpxa xa, d.sonha, d.thon, n.ten gioitinh, nvl(l.sothe,'. . . . . . . . . . . . . . ') mabhyt, nvl(to_char(l.denngay,'dd/mm/yyyy'),'. . . . . . . . . . . . . . ') giatriden, ll.mabv, ll.tenbv, cc.sohieu, b.sobienlai, e.tenkp, a.maicd, a.chandoan,  to_char(b.ngay,'dd/mm/yyyy') ngay, to_char(a.ngayvao,'dd/mm/yyyy') ngayvao, to_char(a.ngayra,'dd/mm/yyyy') ngayra, nvl(ngayra-ngayvao,1) songay, a.giuong, i.id id_vp, j.id id_loai, k.ma id_nhom, i.ten tenvp, j.ten tenloaivp, k.ten tennhomvp, i.stt sttvp, j.stt sttloaivp, k.stt sttnhomvp, i.dvt, nvl(c.soluong,0) soluong, nvl(c.dongia,0) dongia, (nvl(c.soluong,0)*nvl(c.dongia,0)) sotien, nvl(b.sotien,0) tongcp, nvl(b.bhyt,0) bhyt , nvl(b.tamung,0) tamung, nvl(b.mien,0) mien, (nvl(b.sotien,0)-nvl(b.bhyt,0)-nvl(b.mien,0)-nvl(b.tamung,0)) bntra , c.madoituong, m.hoten nguoithu from v_ttrvds a, v_ttrvll b, v_ttrvct c, v_quyenso cc, btdbn d, hcnhi dd, btdkp_bv e, btdtt f, btdquan g, btdpxa h, (select g1.id, g1.stt, g1.ten, g1.dvt, g1.id_loai,g2.id_nhom from v_giavp g1, v_loaivp g2 where g1.id_loai=g2.id(+) union select d1.id, rownum stt, trim(d1.ten||'['||trim(d1.tenhc)||'] '||d1.hamluong) ten, d1.dang dvt, 0 id_loai, nvl(d2.nhomvp,0) id_nhom from d_dmbd d1, d_dmnhom d2 where d1.manhom=d2.id(+)) i, (select id, id_nhom, stt, ten from v_loaivp union all select 0 id, 0 id_nhom, 1 stt, null ten from dual) j, (select ma, ten, stt from v_nhomvp union all select 0 ma, null ten, 1 stt from dual) k, bhyt l, dstt ll, medibv.v_dlogin m, dmphai n where a.id=b.id(+) and a.id=c.id(+) and a.mabn=d.mabn(+) and d.phai=n.ma(+) and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and b.makp=e.makp(+) and b.userid=m.id(+) and c.mavp=i.id(+) and i.id_loai = j.id(+) and i.id_nhom=k.ma(+) and a.maql=l.maql(+) and l.mabv=ll.mabv(+) and b.quyenso=cc.id(+) and d.mabn=dd.mabn(+) and to_char(a.id)='"+v_id+"'";
				if(v_mmyy_only=="")
				{
					m_ds = m_v.get_data_bc(DateTime.Now,DateTime.Now,m_sql);
				}
				else
				{
					m_ds = m_v.get_data_mmyy(v_mmyy_only,m_sql);
				}
				//MessageBox.Show(m_sql);
				//m_ds.WriteXml("..\\..\\Datareport\\v_thanhtoanravienngoaitru.xml",XmlWriteMode.WriteSchema);
				//return;
				aReport =f_get_report_inchiphi(m_ds.Tables[0].Rows[0]["madoituong"].ToString());
				if(!System.IO.File.Exists("..\\..\\..\\Report\\"+aReport.Trim()))
				{
					aReport ="v_thanhtoanravienngoaitru.rpt";
				}

				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy chứng  từ thu chi thanh toán ra viện <")+v_id+">",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				
				string asyt="",abv="",angayin="",anguoiin="",aghichu="";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				
				angayin=f_GetNgay(m_ds.Tables[0].Rows[0]["ngay"].ToString());
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(m_ds);
				cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
				cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
				cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
                cMain.Close(); cMain.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		public void f_Print_ChiphiTTRVNgoaitruCT(bool v_dir, string v_id, string v_mmyy_only)
		{
			try
			{
				this.Text=lan.Change_language_MessageText("Phiếu thanh toán ra viện bệnh nhân ngoại trú v_thanhtoanravienngoaitru_chitiet.rpt");
				string aReport ="v_thanhtoanravienngoaitru_chitiet.rpt";

				m_sql = "select a.id, a.mabn, d.hoten, d.namsinh, dd.hoten_bo, dd.hoten_me, f.tentt tinh, g.tenquan quan,h.tenpxa xa, d.sonha, d.thon, n.ten gioitinh, nvl(l.sothe,'. . . . . . . . . . . . . . ') mabhyt, nvl(to_char(l.denngay,'dd/mm/yyyy'),'. . . . . . . . . . . . . . ') giatriden, ll.mabv, ll.tenbv, cc.sohieu, b.sobienlai, e.tenkp, a.maicd, a.chandoan,  to_char(b.ngay,'dd/mm/yyyy') ngay, to_char(a.ngayvao,'dd/mm/yyyy') ngayvao, to_char(a.ngayra,'dd/mm/yyyy') ngayra, nvl(ngayra-ngayvao,1) songay, a.giuong, i.id id_vp, j.id id_loai, k.ma id_nhom, i.ten tenvp, j.ten tenloaivp, k.ten tennhomvp, i.stt sttvp, j.stt sttloaivp, k.stt sttnhomvp, i.dvt, nvl(c.soluong,0) soluong, nvl(c.dongia,0) dongia, (nvl(c.soluong,0)*nvl(c.dongia,0)) sotien, nvl(b.sotien,0) tongcp, nvl(b.bhyt,0) bhyt , nvl(b.tamung,0) tamung, nvl(b.mien,0) mien, (nvl(b.sotien,0)-nvl(b.bhyt,0)-nvl(b.mien,0)-nvl(b.tamung,0)) bntra , c.madoituong, m.hoten nguoithu from v_ttrvds a, v_ttrvll b, v_ttrvct c, v_quyenso cc, btdbn d, hcnhi dd, btdkp_bv e, btdtt f, btdquan g, btdpxa h, (select g1.id, g1.stt, g1.ten, g1.dvt, g1.id_loai,g2.id_nhom from v_giavp g1, v_loaivp g2 where g1.id_loai=g2.id(+) union select d1.id, rownum stt, trim(d1.ten||'['||trim(d1.tenhc)||'] '||d1.hamluong) ten, d1.dang dvt, 0 id_loai, nvl(d2.nhomvp,0) id_nhom from d_dmbd d1, d_dmnhom d2 where d1.manhom=d2.id(+)) i, (select id, id_nhom, stt, ten from v_loaivp union all select 0 id, 0 id_nhom, 1 stt, null ten from dual) j, (select ma, ten, stt from v_nhomvp union all select 0 ma, null ten, 1 stt from dual) k, bhyt l, dstt ll, medibv.v_dlogin m, dmphai n where a.id=b.id(+) and a.id=c.id(+) and a.mabn=d.mabn(+) and d.phai=n.ma(+) and d.matt=f.matt(+) and d.maqu=g.maqu(+) and d.maphuongxa=h.maphuongxa(+) and b.makp=e.makp(+) and b.userid=m.id(+) and c.mavp=i.id(+) and i.id_loai = j.id(+) and i.id_nhom=k.ma(+) and a.maql=l.maql(+) and l.mabv=ll.mabv(+) and b.quyenso=cc.id(+) and d.mabn=dd.mabn(+) and to_char(a.id)='"+v_id+"'";
				if(v_mmyy_only=="")
				{
					m_ds = m_v.get_data_bc(DateTime.Now,DateTime.Now,m_sql);
				}
				else
				{
					m_ds = m_v.get_data_mmyy(v_mmyy_only,m_sql);
				}
				//MessageBox.Show(m_sql);
				//m_ds.WriteXml("..\\..\\Datareport\\v_thanhtoanravienngoaitru.xml",XmlWriteMode.WriteSchema);
				//return;

				if(m_ds.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không tìm thấy chứng  từ thu chi thanh toán ra viện ngoại trú <")+v_id+">",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				
				aReport =f_get_report_inchiphi(m_ds.Tables[0].Rows[0]["madoituong"].ToString());
				if(!System.IO.File.Exists("..\\..\\..\\Report\\"+aReport.Trim()))
				{
					aReport ="v_thanhtoanravienngoaitru_chitiet.rpt";
				}

				string asyt="",abv="",angayin="",anguoiin="",aghichu="";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				
				angayin=f_GetNgay(m_ds.Tables[0].Rows[0]["ngay"].ToString());
				anguoiin=m_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aghichu = "";

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..\\..\\..\\report\\"+aReport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(m_ds);
				cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
				cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
				cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA5; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 

				if(!v_dir)
				{
					this.crystalReportViewer1.ReportSource=cMain;
					this.WindowState=FormWindowState.Maximized;
					this.ShowDialog(this.Parent);
				}
				else
				{
					cMain.PrintToPrinter(1,false,0,0);
				}
                cMain.Close(); cMain.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Lỗi máy in. Đề nghị kiển tra lại máy in.\n\n") + ex.ToString(),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		private void frmPrint_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Escape)
				{
					this.Close();
				}
			}
			catch
			{
			}
		}

		private void frmPrint_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			System.Environment.CurrentDirectory=this.Tag.ToString();
		}
		#region  Binh_thutamung_dot
		private string f_dot_tamung(string v_id, string v_mmyy_only)
		{
			string r="", sql;
			bool ab = m_v.sys_insotienchitiet_tamung;
			try
			{
				DataSet ads = new DataSet();
				sql="select id, rownum dot from v_tamung where maql in (select maql from v_tamung where id="+ v_id+") order by ngay asc";

				if(v_mmyy_only=="")
				{
					ads = m_v.get_data_bc(DateTime.Now,DateTime.Now,sql);
				}
				else
				{
					ads = m_v.get_data_mmyy(v_mmyy_only,sql);
				}
				foreach(DataRow r1 in ads.Tables[0].Select("id="+v_id))
				{					
					r="Đợt "+r1["dot"].ToString();
				}				
				if(r=="")
				{
					r="Đợt 1";
				}
				else
				{
					r=r.Trim();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
				r="Đợt 1";
			}
			return r;
		}		
		#endregion
	}
}
