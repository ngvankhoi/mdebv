using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using LibMedi;
using LibDuoc;

namespace dllvpkhoa_chidinh
{
    public class frmGoiDichvu : Form
    {
        private DataSet m_ds_danhsach = null;
        private Brush alertBackBrush;
        private Font alertFont;
        private Brush alertTextBrush;
        private string Bienlaichiuthue_gia,s_table="";
        private bool bNew, bLocthan, bLocdichvu,bChidinh_loaivp,bNgayhienhanh_thuoc_chidinh=false, bChuky, bAdminInlaiphieuchidinh = false, bAdminInlaidonthuoc = false, bChidinh_thutienlien, bTiemchung = false, bChidinh_exp_txt, bChenhlech_doituong, bBienlaichiuthue, afterCurrentCellChanged, bUpdate_chidinh, bSophieu_chidinh=false;
        private Button butHuy;
        private Button butIn;
        private Button butKetthuc;
        private Button butLuu;
        private Button butThem;
        private string chandoan;
        private int checkCol = 0;
        private decimal chiphi;
        private ToolStripMenuItem chkInphieu;
        private ToolStripMenuItem chkXML;
        private string cl_cholam = "";
        private int cl_doituong = 3;
        private decimal cl_tyle = 0M;
        private Container components = null;
        private Brush currentRowBackBrush;
        private Font currentRowFont;
        private LibDuoc.AccessData d = new LibDuoc.AccessData();
        private DataGrid dataGrid1;
        private DataGrid dataGrid2;
        private Brush disabledBackBrush;
        private Brush disabledTextBrush;
        private DataSet ds = new DataSet();
        private DataSet ds_bnmien = new DataSet();
        private DataTable dsdm;
        private DataTable dt = new DataTable();
        private DataTable dtthe = new DataTable();
        private DataTable dtdt = new DataTable();
        private DataTable dtdtvp = new DataTable();
        private DataTable dtmuc = new DataTable();
        private DataTable dtnguon = new DataTable();
        private string f_soluong;
        private FileStream fstr;
        private int i_nhom,i_traituyen=0;
        private int i_tunguyen;
        private int i_userid;
        private decimal idchidinh;
        private byte[] image;
        private decimal l_duyet;
        private decimal l_id;
        private decimal l_idchaythan;
        private decimal l_idchidinh;
        private decimal l_idkhoa;
        private decimal l_idlocthan;
        private decimal l_maql;
        private decimal l_mavaovien;
        private decimal l_mavp = 0L;
        private Language lan = new Language();
        private int loai;
        private int loaiba;
        private LibMedi.AccessData m = new LibMedi.AccessData();
        private string mabs;
        private int madoituong;
        private string maicd;
        private string makho;
        private int makhoa;
        private int makp;
        public string mamau;
        private string manguon;
        private string mapt;
        private string matrai;
        private string mmyy;
        private string ngay;
        private CurrencyManager objStudentCM;
        private int phieu;
        private string s_chenhlech = "";
        private string s_mabn;
        private string ngayvv = "";
        private string sMakp_chidinh_tamung;
        private string sothe;
        private decimal Sotien_chidinh_tamung;
        private string sql;
        private string sys_nhom_bienlai_dichvu;
        private decimal tamung;
        private decimal Tamung_min;
        private string Tamung_min_makp;
        private System.Windows.Forms.TextBox textBox111 = new TextBox();
        private TextBox tim;
        private TextBox timkiem;
        private DataTable tmp = new DataTable();
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private TreeView treeView1;
        private DataGridTableStyle ts;
        private Bogotiengviet tv = new Bogotiengviet();
        private string user;
        private LibVienphi.AccessData v = new LibVienphi.AccessData();
        private int v1 = 4;
        private Label label1;
        private NumericUpDown txtSoluong;
        private Button butMoi;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem mnDefault_sl;
        private int v2 = 2;
        private TreeView treeLan;
        private Button butSua;
        private Button butBoqua;
        bool bThehethan = false;
        private Button butcauhoitc;
        private decimal m_soluong_default = 1;
        // Methods
        public frmGoiDichvu(int nhom, int _makp, string _ngay, int _loai, int _phieu, string _mmyy, string _makho, string _manguon, decimal duyet,
            string mabn, decimal mavaovien, decimal maql, decimal idkhoa, int userid, decimal idduoc, int _makhoa, string _ngayvv, string _mapt, string _mamau, 
            bool _bNew, decimal idlocthan, int _madoituong, string _matrai, decimal _idchidinh, string _sothe, string _maicd, string _chandoan, string _mabs,
            int _loaiba, bool update_chidinh, bool locthan, decimal _idchaythan)
        {
            this.InitializeComponent();
            this.user = this.d.user;
            m_ds_danhsach = m.get_data("select 0 as id, 0 as idduoc, '' as ten from dual").Clone();
            this.lan.Read_Language_to_Xml(base.Name.ToString(), this);
            this.lan.Changelanguage_to_English(base.Name.ToString(), this);
            this.i_nhom = nhom;
            this.makho = _makho;
            this.manguon = _manguon;
            this.s_mabn = mabn;
            this.l_maql = maql;
            this.l_idkhoa = idkhoa;
            this.l_mavaovien = mavaovien;
            this.madoituong = _madoituong;
            this.makp = _makp;
            this.loai = _loai;
            this.phieu = _phieu;
            this.ngay = _ngay;
            this.mmyy = _mmyy;
            this.l_duyet = duyet;
            this.l_id = idduoc;
            this.mapt = _mapt;
            this.l_idchidinh = _idchidinh;
            this.i_userid = userid;
            this.makhoa = _makhoa;
            this.ngayvv = _ngayvv;
            this.mamau = _mamau;
            this.bNew = _bNew;
            this.l_idlocthan = idlocthan;
            this.matrai = _matrai;
            this.sothe = _sothe;
            this.maicd = _maicd;
            this.chandoan = _chandoan;
            this.mabs = _mabs;
            this.loaiba = _loaiba;
            this.bUpdate_chidinh = update_chidinh;
            this.bLocthan = locthan;
            this.l_idchaythan = _idchaythan;
            try
            {
                m_soluong_default = decimal.Parse(m.get_data("select giatri from " + user + ".v_optionform where userid=" + i_userid + " and loai=0 and ma='frmGoiDichvu_soluong_default'").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                m_soluong_default = 1;
            }
            if (m_soluong_default < 1)
            {
                m_soluong_default = 1;
            }
        }

        //Khuong 15/07/2011: co nut cau hoi sang loc tiem chung
        public frmGoiDichvu(int nhom, int _makp, string _ngay, int _loai, int _phieu, string _mmyy, string _makho, string _manguon, decimal duyet,
            string mabn, decimal mavaovien, decimal maql, decimal idkhoa, int userid, decimal idduoc, int _makhoa, string _ngayvv, string _mapt, string _mamau,
            bool _bNew, decimal idlocthan, int _madoituong, string _matrai, decimal _idchidinh, string _sothe, string _maicd, string _chandoan, string _mabs,
            int _loaiba, bool update_chidinh, bool locthan, decimal _idchaythan,int _tiemchung,string _table)
        {
            this.InitializeComponent();
            this.user = this.d.user;
            m_ds_danhsach = m.get_data("select 0 as id, 0 as idduoc, '' as ten from dual").Clone();
            this.lan.Read_Language_to_Xml(base.Name.ToString(), this);
            this.lan.Changelanguage_to_English(base.Name.ToString(), this);
            this.i_nhom = nhom;
            this.makho = _makho;
            this.manguon = _manguon;
            this.s_mabn = mabn;
            this.l_maql = maql;
            this.l_idkhoa = idkhoa;
            this.l_mavaovien = mavaovien;
            this.madoituong = _madoituong;
            this.makp = _makp;
            this.loai = _loai;
            this.phieu = _phieu;
            this.ngay = _ngay;
            this.mmyy = _mmyy;
            this.l_duyet = duyet;
            this.l_id = idduoc;
            this.mapt = _mapt;
            this.l_idchidinh = _idchidinh;
            this.i_userid = userid;
            this.makhoa = _makhoa;
            this.ngayvv = _ngayvv;
            this.mamau = _mamau;
            this.bNew = _bNew;
            this.l_idlocthan = idlocthan;
            this.matrai = _matrai;
            this.sothe = _sothe;
            this.maicd = _maicd;
            bTiemchung = _tiemchung==1;
            this.chandoan = _chandoan;
            this.mabs = _mabs;
            this.loaiba = _loaiba;
            this.bUpdate_chidinh = update_chidinh;
            this.bLocthan = locthan;
            s_table = _table;
            this.l_idchaythan = _idchaythan;
            try
            {
                m_soluong_default = decimal.Parse(m.get_data("select giatri from " + user + ".v_optionform where userid=" + i_userid + " and loai=0 and ma='frmGoiDichvu_soluong_default'").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                m_soluong_default = 1;
            }
            if (m_soluong_default < 1)
            {
                m_soluong_default = 1;
            }
        }
        //End Khuong 15/07/2011
        public frmGoiDichvu(int nhom, int _makp, string _ngay, int _loai, int _phieu, string _mmyy, string _makho, string _manguon, decimal duyet,
            string mabn, decimal mavaovien, decimal maql, decimal idkhoa, int userid, decimal idduoc, int _makhoa, string _ngayvv, string _mapt, string _mamau,
            bool _bNew, decimal idlocthan, int _madoituong, string _matrai, decimal _idchidinh, string _sothe, string _maicd, string _chandoan, string _mabs,
            int _loaiba, bool update_chidinh, bool locthan, decimal _idchaythan,bool _hethandung)
        {
            this.InitializeComponent();
            this.user = this.d.user;
            m_ds_danhsach = m.get_data("select 0 as id, 0 as idduoc, '' as ten from dual").Clone();
            this.lan.Read_Language_to_Xml(base.Name.ToString(), this);
            this.lan.Changelanguage_to_English(base.Name.ToString(), this);
            this.i_nhom = nhom;
            this.makho = _makho;
            this.manguon = _manguon;
            this.s_mabn = mabn;
            this.l_maql = maql;
            this.l_idkhoa = idkhoa;
            this.l_mavaovien = mavaovien;
            this.madoituong = _madoituong;
            this.makp = _makp;
            this.loai = _loai;
            this.phieu = _phieu;
            this.ngay = _ngay;
            this.mmyy = _mmyy;
            this.l_duyet = duyet;
            this.l_id = idduoc;
            this.mapt = _mapt;
            this.l_idchidinh = _idchidinh;
            this.i_userid = userid;
            this.makhoa = _makhoa;
            this.ngayvv = _ngayvv;
            this.mamau = _mamau;
            this.bNew = _bNew;
            this.l_idlocthan = idlocthan;
            this.matrai = _matrai;
            this.sothe = _sothe;
            this.maicd = _maicd;
            this.chandoan = _chandoan;
            this.mabs = _mabs;
            this.loaiba = _loaiba;
            this.bUpdate_chidinh = update_chidinh;
            this.bLocthan = locthan;
            this.l_idchaythan = _idchaythan;
            try
            {
                m_soluong_default = decimal.Parse(m.get_data("select giatri from " + user + ".v_optionform where userid=" + i_userid + " and loai=0 and ma='frmGoiDichvu_soluong_default'").Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                m_soluong_default = 1;
            }
            if (m_soluong_default < 1)
            {
                m_soluong_default = 1;
            }
            bThehethan = _hethandung;
        }
        #region design
        private void AddGridTableStyle()
        {
            DataGridTableStyle table = new DataGridTableStyle();
            table.MappingName = this.dsdm.TableName;
            table.AlternatingBackColor = System.Drawing.Color.Beige;
            table.BackColor = System.Drawing.Color.GhostWhite;
            table.ForeColor = System.Drawing.Color.MidnightBlue;
            table.GridLineColor = System.Drawing.Color.RoyalBlue;
            table.HeaderBackColor = System.Drawing.Color.MidnightBlue;
            table.HeaderForeColor = System.Drawing.Color.Lavender;
            table.SelectionBackColor = System.Drawing.Color.FromArgb(0, 0xff, 0xff);
            table.SelectionForeColor = System.Drawing.Color.PaleGreen;
            table.RowHeaderWidth = 5;
            FormattableBooleanColumn column = new FormattableBooleanColumn();
            column.MappingName = "chon";
            column.HeaderText = "Chọn";
            column.Width = 30;
            column.AllowNull = false;
            column.SetCellFormat += new FormatCellEventHandler(this.SetCellFormat);
            column.BoolValueChanged += new BoolValueChangedEventHandler(this.BoolValueChanged);
            table.GridColumnStyles.Add(column);
            this.dataGrid1.TableStyles.Add(table);
            FormattableTextBoxColumn column2 = new FormattableTextBoxColumn();
            column2.MappingName = "tennguon";
            column2.HeaderText = "Nguồn";
            column2.Width = 60;
            column2.ReadOnly = true;
            column2.SetCellFormat += new FormatCellEventHandler(this.SetCellFormat);
            table.GridColumnStyles.Add(column2);
            this.dataGrid1.TableStyles.Add(table);
            column2 = new FormattableTextBoxColumn();
            column2.MappingName = "ma";
            column2.HeaderText = "Mã số";
            column2.Width = 50;
            column2.ReadOnly = true;
            column2.SetCellFormat += new FormatCellEventHandler(this.SetCellFormat);
            table.GridColumnStyles.Add(column2);
            this.dataGrid1.TableStyles.Add(table);
            column2 = new FormattableTextBoxColumn();
            column2.MappingName = "ten";
            column2.HeaderText = "Tên";
            column2.Width = 280;
            column2.ReadOnly = true;
            column2.SetCellFormat += new FormatCellEventHandler(this.SetCellFormat);
            table.GridColumnStyles.Add(column2);
            this.dataGrid1.TableStyles.Add(table);
            column2 = new FormattableTextBoxColumn();
            column2.MappingName = "dang";
            column2.HeaderText = "ĐVT";
            column2.Width = 50;
            column2.ReadOnly = true;
            column2.SetCellFormat += new FormatCellEventHandler(this.SetCellFormat);
            table.GridColumnStyles.Add(column2);
            this.dataGrid1.TableStyles.Add(table);
            column2 = new FormattableTextBoxColumn();
            column2.MappingName = "soluong";
            column2.HeaderText = "Số lượng";
            column2.Width = 50;
            column2.ReadOnly = true;
            column2.SetCellFormat += new FormatCellEventHandler(this.SetCellFormat);
            table.GridColumnStyles.Add(column2);
            this.dataGrid1.TableStyles.Add(table);
        }

        private void AddGridTableStyle1()
        {
            try
            {
                
                this.ts = new DataGridTableStyle();
                int num = (int)(Graphics.FromHwnd(base.Handle).MeasureString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", this.Font).Width / 26f);
                this.objStudentCM = (CurrencyManager)this.BindingContext[this.ds.Tables[0]];
                this.ts.MappingName = this.ds.Tables[0].TableName;
                this.ts.AlternatingBackColor = System.Drawing.Color.Beige;
                this.ts.BackColor = System.Drawing.Color.GhostWhite;
                this.ts.ForeColor = System.Drawing.Color.MidnightBlue;
                this.ts.GridLineColor = System.Drawing.Color.RoyalBlue;
                this.ts.HeaderBackColor = System.Drawing.Color.MidnightBlue;
                
                this.ts.HeaderForeColor = System.Drawing.Color.Lavender;
                this.ts.SelectionBackColor = System.Drawing.Color.Teal;
                this.ts.SelectionForeColor = System.Drawing.Color.PaleGreen;
                this.ts.RowHeaderWidth = 10;
                this.ts.ReadOnly = false;
                this.ts.GridColumnStyles.Add(new DataGridTextBoxColumn(this.objStudentCM.GetItemProperties()["mabd"]));
                this.ts.GridColumnStyles[0].MappingName = "mabd";
                this.ts.GridColumnStyles[0].HeaderText = "";
                this.ts.GridColumnStyles[0].Width = 0;
                this.ts.ReadOnly = true;
                this.ts.GridColumnStyles[0].Alignment = HorizontalAlignment.Left;
                this.ts.GridColumnStyles[0].NullText = string.Empty;
                this.ts.GridColumnStyles.Add(new DataGridComboBoxColumn(this.dtnguon, 1, 1,true));
                this.ts.GridColumnStyles[1].MappingName = "nguon";
               
                this.ts.GridColumnStyles[1].HeaderText = "Nguồn";
                this.ts.GridColumnStyles[1].Width = 60;
                this.ts.GridColumnStyles[1].Alignment = HorizontalAlignment.Left;
                this.ts.GridColumnStyles[1].NullText = string.Empty;
                this.dataGrid2.CaptionText = string.Empty;
                this.ts.GridColumnStyles.Add(new DataGridComboBoxColumn(this.dtdt, 1, 1));
                this.ts.GridColumnStyles[2].MappingName = "doituong";
                this.ts.GridColumnStyles[2].HeaderText = "Đối tượng";
                this.ts.GridColumnStyles[2].Width = 80;
                this.ts.GridColumnStyles[2].Alignment = HorizontalAlignment.Left;
                this.ts.GridColumnStyles[2].NullText = string.Empty;
                this.dataGrid2.CaptionText = string.Empty;
                this.ts.GridColumnStyles.Add(new DataGridTextBoxColumn(this.objStudentCM.GetItemProperties()["ten"]));
                this.ts.GridColumnStyles[3].MappingName = "ten";
                this.ts.GridColumnStyles[3].HeaderText = "Tên thuốc";
                this.ts.GridColumnStyles[3].Width = 270;
                this.ts.ReadOnly = true;
                this.ts.GridColumnStyles[3].Alignment = HorizontalAlignment.Left;
                this.ts.GridColumnStyles[3].NullText = string.Empty;
                this.ts.GridColumnStyles.Add(new DataGridTextBoxColumn(this.objStudentCM.GetItemProperties()["dang"]));
                this.ts.GridColumnStyles[4].MappingName = "dang";
                this.ts.GridColumnStyles[4].HeaderText = "ĐVT";
                this.ts.GridColumnStyles[4].Width = 50;
                this.ts.ReadOnly = true;
                this.ts.GridColumnStyles[4].Alignment = HorizontalAlignment.Left;
                this.ts.GridColumnStyles[4].NullText = string.Empty;
                this.ts.GridColumnStyles.Add(new DataGridTextBoxColumn(this.objStudentCM.GetItemProperties()["soluong"]));
                this.ts.GridColumnStyles[5].MappingName = "soluong";
                this.ts.GridColumnStyles[5].HeaderText = "Số lượng";
                this.ts.GridColumnStyles[5].Width = 50;
                this.ts.ReadOnly = false;
                this.ts.GridColumnStyles[5].Alignment = HorizontalAlignment.Right;
                this.ts.GridColumnStyles[5].NullText = string.Empty;
                this.dataGrid2.DataSource = this.ds;
                this.dataGrid2.DataMember = this.ds.Tables[0].TableName;
                this.dataGrid2.TableStyles.Add(this.ts);

                CurrencyManager manager = (CurrencyManager)this.BindingContext[this.dataGrid2.DataSource, this.dataGrid2.DataMember];
                DataView list = (DataView)manager.List;
                list.AllowNew = false;
            }
            catch (Exception exx){ }
        }

        private void BoolValueChanged(object sender, BoolValueChangedEventArgs e)
        {
            this.dataGrid1.EndEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"], e.Row, false);
            this.RefreshRow(e.Row);
            this.dataGrid1.BeginEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"], e.Row);
        }
        #endregion
        public frmGoiDichvu() { this.InitializeComponent(); }
        private void butIn_Click(object sender, EventArgs e)
        {
            string s_tgtrakq = "", s_giongay = "";
            if (bAdminInlaidonthuoc || bAdminInlaiphieuchidinh)
            {
                if (!m.bAdminHethong(i_userid) && ngay.Substring(0, 10) != m.ngayhienhanh_server.Substring(0, 10))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bạn không có quyền in lại chỉ định của ngày trước !"), LibMedi.AccessData.Msg);
                    return;
                }
            }
            if (m.bInchidinh_dien )
            {
                DLLPrintchidinh.frmPrintchidinh f1 = new DLLPrintchidinh.frmPrintchidinh();
                f1.f_Print_Chidinh(false, s_mabn, l_maql.ToString(), "", ngay.Substring(0, 10),"");
                return;
            }
            string sophieu = "";
            if (bSophieu_chidinh)
                sophieu = "CD" + ngay.Substring(8, 2) + ngay.Substring(3, 2) + ngay.Substring(0, 2) + m.get_sophieucls(m.mmyy(ngay), s_mabn, l_mavaovien, ngay.Substring(0, 10), 1, 0).ToString().PadLeft(4, '0');
            sql = "select ";
            if (bChidinh_loaivp) sql += "e.ten as nhomvp,";
            else sql += "f.ten as nhomvp,";
            sql += " e.ten as tenloaivp, e.stt as sttloai, f.ten as tennhomvp, f.stt as sttnhom, ";
            sql += "a.mabn,g.hoten,";
            sql += int.Parse(ngay.Substring(6, 4)) + "-to_number(g.namsinh,'0000') as tuoi,";
            sql += "trim(g.sonha)||' '||trim(g.thon)||' '||trim(j.tenpxa)||','||trim(i.tenquan)||','||trim(h.tentt) as diachi,";
            sql += "case when g.phai=0 then 'Nam' else 'Nữ' end as phai,d.tenkp,b.ten,b.dvt,a.soluong,";
            if (s_table == "xxx.tiepdon") sql += "a.chandoan,'' as maicd,";
            else sql += "coalesce(a.chandoan,c.chandoan) as chandoan,c.maicd,";
            if (l_idkhoa == 0) sql += "'' as giuong,";
            else sql += "c.giuong,";
            sql += " m.ten as tinhtrang,n.ten as thuchien,";
            sql += " case when x.sothe is null then x1.sothe else x.sothe end as sothe,";
            sql += " case when x.tungay is null then to_char(x1.tungay,'dd/mm/yyyy')  else to_char(x.tungay,'dd/mm/yyyy') end as tungay,";
            sql += " case when x.denngay is null then to_char(x1.denngay,'dd/mm/yyyy')  else to_char(x.denngay,'dd/mm/yyyy') end as denngay,";
            sql += " case when y.tenbv is null then y1.tenbv else y.tenbv end as noigioithieu,";
            if (s_table == "xxx.tiepdon") sql += "'' as tenbs,a.mabs";
            else sql += "p.hoten as tenbs,a.mabs";
            sql += ", a.madoituong,z.doituong,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.mavp,b.chenhlech,b.gia_th,b.gia_bh,b.gia_dv,b.gia_cs,b.gia_nn,b.gia_ksk,a.ghichu";
            sql += ", a.loaiba, case when x.traituyen is null then (case when x1.traituyen is null then 0 else x1.traituyen end) else x.traituyen end traituyen ";
            sql += ", case when (lh.tuoivao is null) then '0000' else lh.tuoivao end as tuoivao, lh.cholam,b.giaycamdoan,d1.tennn,d2.dantoc,g.cholam noilamviec ";//,a.chandoansobo
            sql += ",substr(b.tgtrakq,1,2) thoigiantrakq,substr(b.tgtrakq,4,1) giongay";
            sql += " from xxx.v_chidinh a inner join " + user + ".v_giavp b on a.mavp=b.id ";
            if (l_idkhoa == 0) sql += " left join " + s_table + " c on a.maql=c.maql ";
            else sql += " left join " + s_table + " c on a.idkhoa=c.id ";
            sql += " inner join " + user + ".btdkp_bv d on a.makp=d.makp ";
            sql += " inner join " + user + ".v_loaivp e on b.id_loai=e.id ";
            sql += " inner join " + user + ".v_nhomvp f on e.id_nhom=f.ma ";
            sql += " inner join " + user + ".btdbn g on a.mabn=g.mabn ";
            sql += " inner join " + user + ".btdtt h on g.matt=h.matt ";
            sql += " inner join " + user + ".btdquan i on g.maqu=i.maqu ";
            sql += " inner join " + user + ".btdpxa j on g.maphuongxa=j.maphuongxa ";
            sql += " left join " + user + ".dmtinhtrang m on a.tinhtrang=m.id ";
            sql += " left join " + user + ".dmthuchien n on a.thuchien=n.id ";
            if (s_table != "xxx.tiepdon") sql += " left join " + user + ".dmbs p on a.mabs=p.ma ";
            sql += " left join xxx.bhyt x on a.maql=x.maql ";
            sql += " left join " + user + ".bhyt x1 on a.maql=x1.maql ";
            sql += " left join " + user + ".dmnoicapbhyt y on x.mabv=y.mabv";
            sql += " left join " + user + ".dmnoicapbhyt y1 on x1.mabv=y1.mabv";
            sql += " inner join " + user + ".doituong z on a.madoituong=z.madoituong ";
            sql += " left join xxx.lienhe lh on a.maql=lh.maql";
            sql += " left join " + user + ".btdnn_bv d1 on g.mann=d1.mann ";
            sql += " left join " + user + ".btddt d2 on g.madantoc=d2.madantoc ";
            //sql += " where a.mabn='" + s_mabn + "' and a.hide=0 and to_char(a.ngay,'dd/mm/yyyy')='" + ngay.Substring(0, 10) + "'";
            //if (l_mavaovien != 0 && loaiba == 3) sql += " and a.mavaovien=" + l_mavaovien;
            //else sql += " and a.maql=" + l_maql;
            //if (l_idkhoa != 0) sql += " and a.idkhoa=" + l_idkhoa;
            // if (s_id != "") sql += " and a.id in (" + s_id.Substring(0, s_id.Length - 1) + ")";
            // if (chkIntheodot.Checked == false) sql += " and a.thuchien>0";
            sql += " where a.id="+l_idcd.ToString();
            sql += " order by a.ngay,";
            if (bChidinh_loaivp) sql += "e.ten,";
            else sql += "f.ten,";
            sql += "b.ten";
            DataSet dstmp = m.get_data_nam(m.mmyy(ngay), sql);

            if (dstmp.Tables[0].Rows.Count > 0)
            {
                if (madoituong == 1 && dstmp.Tables[0].Select("chenhlech=1").Length > 0)
                {
                    foreach (DataRow r1 in dstmp.Tables[0].Select("chenhlech=1 and madoituong=" + i_tunguyen, "mabn,ngay,mavp"))
                        if (r1[m.field_gia(i_tunguyen.ToString())].ToString() != r1["gia_bh"].ToString())
                            m.delrec(dstmp.Tables[0], "mabn='" + r1["mabn"].ToString() + "' and mavp=" + int.Parse(r1["mavp"].ToString()) + " and ngay='" + r1["ngay"].ToString() + "' and madoituong=" + i_tunguyen);
                    dstmp.AcceptChanges();
                }
                if (bChuky)
                {
                    DataColumn dc = new DataColumn("Image", typeof(byte[]));
                    dstmp.Tables[0].Columns.Add(dc);
                    foreach (DataRow r in dstmp.Tables[0].Rows)
                    {
                        if (File.Exists("..//..//..//chuky//" + r["mabs"].ToString() + ".bmp"))
                        {
                            fstr = new FileStream("..//..//..//chuky//" + r["mabs"].ToString() + ".bmp", FileMode.Open, FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                            r["Image"] = image;
                        }
                    }
                }
                dstmp.Tables[0].Columns.Add("sophieu");
                if (bSophieu_chidinh)
                    foreach (DataRow r in dstmp.Tables[0].Rows) r["sophieu"] = sophieu;
                //if (chitiet)
                //{
                //    DataSet dst = new DataSet();
                //    dst = dstmp.Copy();
                //    dstmp.Clear();
                //    decimal sl = 0, n = 0;
                //    DataRow r;
                //    foreach (DataRow r1 in dst.Tables[0].Rows)
                //    {
                //        sl = decimal.Parse(r1["soluong"].ToString());
                //        n = sl;
                //        for (int i = 0; i < Convert.ToInt16(n); i++)
                //        {
                //            r = dstmp.Tables[0].NewRow();
                //            for (int j = 0; j < dst.Tables[0].Columns.Count; j++)
                //                r[j] = r1[j].ToString();
                //            r["soluong"] = Math.Min(sl, 1);
                //            r["ngay"] = m.DateToString("dd/MM/yyyy", m.StringToDate(r1["ngay"].ToString().Substring(0, 10)).AddDays(i));
                //            dstmp.Tables[0].Rows.Add(r);
                //            sl -= 1;
                //        }
                //    }
                //}
                string s_cdkemtheo = m.f_get_cdkemtheo(ngay, l_maql, 4);
                if (s_cdkemtheo.Trim().Trim(',') != "")
                {
                    foreach (DataRow dr in dstmp.Tables[0].Rows)
                    {
                        dr["chandoan"] += ((dr["chandoan"].ToString().Trim() == "") ? "" : ", ") + s_cdkemtheo;
                    }
                }
                if (chkXML.Checked)
                {
                    if (!System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
                    dstmp.WriteXml("..//xml//chidinh.xml", XmlWriteMode.WriteSchema);
                }

                dllReportM.frmReport f = new dllReportM.frmReport(m, dstmp, ngay.Substring(0, 10), "rptChidinhcls.rpt");
                    f.ShowDialog();
                
                //else
                //    print.Printer(m, dstmp, tenfile, ngay.Substring(0, 10), 1);
            }
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.m.close();
            base.Close();
        }
        private void load_danhsach_chidinh()
        {
            try
            {
                string strsql = "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngay,b.ten||' ('||a.soluong||' '||b.dvt||')' tenvp,a.soluong,a.idduoc,a.id,a.mavp from " + m.user + mmyy +".v_chidinh a," + m.user + ".v_giavp b where a.mavp=b.id and a.maql=" + l_maql.ToString() + " and a.idduoc>0";
                DataSet dschidinh = m.get_data(strsql);
                treeLan.Nodes.Clear();
                foreach (DataRow r in dschidinh.Tables[0].Rows)
                {
                    string strNgay = r["ngay"].ToString();
                    TreeNode anode = new TreeNode(strNgay);
                    anode.Tag = r["id"].ToString() + "^" + r["idduoc"].ToString() + "^" + r["mavp"].ToString();
                    TreeNode anodenew=new TreeNode(r["tenvp"].ToString());
                    anodenew.Tag = r["id"].ToString() + "^" + r["idduoc"].ToString() + "^" + r["mavp"].ToString();
                    anode.Nodes.Add(anodenew);
                    treeLan.Nodes.Add(anode);
                }
            }
            catch (Exception exx)
            {
            }
        }
        bool test()
        {
            if (((l_idchidinh != 0L) && bUpdate_chidinh) && (v.get_data("select * from " + user + m.mmyy(ngay) + ".v_chidinh where (paid=1 or done=1 or idttrv<>0) and hide=0 and idchidinh=" + l_idchidinh).Tables[0].Rows.Count > 0))
            {
                MessageBox.Show(lan.Change_language_MessageText("Thông tin đã xử lý không cho phép thay đổi ?"), LibMedi.AccessData.Msg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (l_id != 0L)
            {
                string s_sql = "select a.id from " + user + mmyy + ".d_duyet a," + user + mmyy + ".d_xtutrucll b where a.id=b.idduyet and b.id=" + l_id + " and a.done=2";
                if (m.get_data(s_sql).Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Kho đã duyệt thuốc & vật tư không cho phép thay đổi?"), LibMedi.AccessData.Msg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            string str = "";
            int num = 1;
            foreach (DataRow row3 in ds.Tables[0].Select("soluong>0"))
            {
                DataRow row = m.getrowbyid(dtdt, "doituong='" + row3["doituong"].ToString() + "'");
                if (row != null)
                {
                    DataRow row2 = m.getrowbyid(dtnguon, "ten='" + row3["nguon"].ToString() + "'");
                    if (row2 != null)
                    {
                        row3["madoituong"] = row["madoituong"].ToString();
                        row3["manguon"] = row2["id"].ToString();
                    }
                }
                ds.AcceptChanges();
                int i_madoituong_dv = int.Parse(row3["madoituong"].ToString());
                if (i_madoituong_dv == 1)
                {
                    if (madoituong != 1)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này không phải đối tượng BHYT."), "Medisoft 2009", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (bThehethan)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Thẻ BHYT bệnh nhân này hết hạn dùng."), "Medisoft 2009", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                string s_exp = "manguon=" + int.Parse(row3["manguon"].ToString()) + " and id=" + int.Parse(row3["mabd"].ToString());
                row = m.getrowbyid(dsdm, s_exp);
                if (row == null)
                {
                    str = str + row3["ten"].ToString().Trim() + " " + row3["dang"].ToString().Trim() + "\n";
                }
                else
                {
                    if (decimal.Parse(row["soluong"].ToString()) < decimal.Parse(row3["soluong"].ToString()))
                    {
                        str = str + row3["ten"].ToString().Trim() + " " + row3["dang"].ToString().Trim() + "\n";
                    }
                    row3["makho"] = row["makho"].ToString();
                    //row3["stt"] = num++;
                }
            }
            if (str != "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Những mặt hàng sau không đủ tồn :") + "\n" + str, "Medisoft 2009", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                butLuu.Enabled = true;
                dataGrid2.Focus();
                return false;
            }
            return true;
        }

        decimal idduoc=0;
        private void butLuu_Click(object sender, EventArgs e)
        {
            if (!test()) return;//loaiba=2,3,
            //if (!kiemtra()) return;
            DataRow r;
            //
           // string a_sql = "";
           // a_sql = "select id,id_nhom,id_loai,id_gia as mabd,sotien,stt,soluong*1 soluong,madoituong from medibv.v_trongoi where id_loai=-999 and id=" +str;
           //DataTable dtct = new DataTable();
            decimal l_idvpkhoa = 0;
           // ds.Tables[0] = d.get_data(a_sql).Tables[0];
           // dtct.AcceptChanges();
            try
            {
                ds.Tables[0].Columns.Add("stt");
            }
            catch { }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["soluong"] = decimal.Parse(ds.Tables[0].Rows[i]["soluong"].ToString()) * txtSoluong.Value;
                ds.Tables[0].Rows[i]["stt"] = i+1;
                
            }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    string s = "";
                    foreach (DataRow rbd in ds.Tables[0].Rows)
                    {
                        if (d.get_tutrucct_dutru(mmyy, makp, int.Parse(makho.Trim(',').Split(',')[0]), 1, int.Parse(rbd["mabd"].ToString()), 0, i_nhom).Rows.Count == 0)
                        {
                            DataRow drbd = d.getrowbyid(ds.Tables[0], "id=" + rbd["mabd"].ToString());
                            s += drbd["ten"].ToString() + ",";
                        }
                    }
                    if (s != "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Những thuốc này: (") + s.Trim(',') + lan.Change_language_MessageText(") đã hết trong tủ trực"));
                        return;
                    }
                    if (bNew)
                        l_id = d.get_id_xuatsd;
                    DataTable tmp = new DataTable();
                    bool bFound = false;

                    if (!bNew)
                    {
                        sql = "select * from " + user + mmyy + ".d_tienthuoc where mabn='" + s_mabn + "' and mavaovien=" + l_mavaovien + " and maql=" + l_maql;
                        sql += " and idkhoa=" + l_idkhoa + " and id=" + l_id;
                        sql += " and to_char(ngay,'dd/mm/yyyy')='" + ngay.Substring(0, 10) + "'";
                        sql += " and done=1 and makp=" + makp;
                        tmp = m.get_data(sql).Tables[0];
                        bFound = true;
                        foreach (DataRow r1 in d.get_data("select a.*,b.manguon,b.giaban,b.giamua,a.soluong*b.giamua as sotien,b.gianovat,c.gia_bh from " + user + mmyy + ".d_thucxuat a," + user + mmyy + ".d_theodoi b," + user + ".d_dmbd c where a.sttt=b.id and b.mabd=c.id and a.id=" + l_id).Tables[0].Rows)
                        {
                            d.upd_tonkhoct_thucxuat(d.delete, mmyy, makp, loai, 1, decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()));
                            d.upd_theodoicongno(d.delete, s_mabn, l_mavaovien, l_maql, l_idkhoa, int.Parse(r1["madoituong"].ToString()), decimal.Parse(r1["sotien"].ToString()), "thuoc");
                            d.upd_tienthuoc(d.delete, mmyy, l_id, s_mabn, l_mavaovien, l_maql, l_idkhoa, ngay, makp, loai, int.Parse(r1["madoituong"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["gianovat"].ToString()), 0, decimal.Parse(r1["gia_bh"].ToString()),"");
                        }
                        d.execute_data("delete from " + user + mmyy + ".d_xuatsdct where id=" + l_id);
                        d.execute_data("delete from " + user + mmyy + ".d_thucxuat where id=" + l_id);
                        this.d.execute_data("delete from " + user + mmyy + ".d_xtutrucct where id=" + this.l_id.ToString());
                        this.d.execute_data("delete from " + user + mmyy + ".d_xtutrucll where id=" + this.l_id.ToString());
                    }

                }
                if (l_duyet == 0)
                {
                    
                        DataTable dtd = d.get_data("select id from " + user + mmyy + ".d_duyet where nhom=" + i_nhom + " and to_char(ngay,'dd/mm/yyyy')='" + ngay.Substring(0,10) + "'" + " and loai=" + loai + " and phieu=" + phieu + " and makhoa=" + makp).Tables[0];
                        if (dtd.Rows.Count != 0) l_duyet = decimal.Parse(dtd.Rows[0][0].ToString());
                        else l_duyet = d.get_id_duyet;
                    
                    if (l_duyet == 0) l_duyet = d.get_id_duyet;
                    d.upd_duyet(mmyy, l_duyet, i_nhom, ngay, loai, phieu, makp, 0, i_userid, makhoa,0);//gam 09/09/2011
                    foreach (DataRow r1 in m.get_data("select * from " + user + ".d_dmkho where id in (" + makho.Trim(',') + ")").Tables[0].Rows)
                        d.upd_duyetkho(mmyy, l_duyet, int.Parse(r1["id"].ToString()), 0);
                }
                else d.upd_duyet(mmyy, l_duyet, i_nhom, ngay, loai, phieu, makp, 0, i_userid, makhoa,0);//gam 09/09/2011
                if (!d.upd_xtutrucll(mmyy, l_id, l_duyet, s_mabn, l_mavaovien, l_maql, l_idkhoa, ngay, 0))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"));
                    return;
                }
                d.execute_data("update " + user + mmyy + ".d_xtutrucll set traituyen=" + i_traituyen + " where id=" + l_id);
               
                int stt = 1;
                foreach (DataRow r1 in ds.Tables[0].Rows)
                {
                   
                  
                    d.upd_xtutrucct(mmyy, l_id, stt,
                        (int.Parse(r1["madoituong"].ToString()) == 0) ? 5 : int.Parse(r1["madoituong"].ToString()), int.Parse(makho.Trim(',').Split(',')[0]),//int.Parse(r1["makho"].ToString()) 
                        int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString())*txtSoluong.Value, 0,
                        "", 1, 
                        0, 1,
                        0);
                    d.execute_data("update " + user  + mmyy + ".d_xtutrucll set traituyen=" + i_traituyen + " where id=" + l_id);
                    stt++;
                }
                //d.updrec_dutrull(dtll, l_id, mabn.Text, l_mavaovien, l_maql, l_idkhoa, hoten.Text, mabs.Text, "",
                //    ngay, 0, 0, "0", 0, 0, "", "", "", 0, 1, ngay);
                #region xuatsd
          
                idduoc = l_id;
                if (!d.upd_xuatsdll(mmyy, l_id, i_nhom, s_mabn, l_mavaovien, l_maql, l_idkhoa, ngay, loai, phieu, makp, i_userid, l_id, 1, makhoa, 0, 0, "", ngay,0,""))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin phiếu lĩnh !"), d.Msg);
                    return;
                }
                d.execute_data("update " + user + mmyy + ".d_xuatsdll set traituyen=" + i_traituyen + " where id=" + l_id);
                //
                try { ds.Tables[0].Columns.Remove("makho"); ds.Tables[0].Columns.Remove("manguon"); }
                catch { }
                DataColumn dc1 = new DataColumn("makho", typeof(string)); dc1.DefaultValue = makho.Trim(',');
                ds.Tables[0].Columns.Add(dc1);
                DataColumn dc2 = new DataColumn("manguon", typeof(string)); dc2.DefaultValue = 1;
                ds.Tables[0].Columns.Add(dc2);
                ds.Tables[0].AcceptChanges();
                d.get_xuatsdct_cstt(mmyy, ds.Tables[0].Select("soluong>0"), makp, // and idvpkhoa=0
                    makhoa, 0, l_id, s_mabn, l_mavaovien, l_maql, l_idkhoa, loai, 1, ngay, i_nhom, ngay, i_traituyen,mabs);
                //if (bFound)
                //{
                //    sql = "delete from " + user + mmyy + ".d_tienthuoc where mabn='" + s_mabn+ "' and mavaovien=" + l_mavaovien + " and maql=" + l_maql;
                //    sql += " and idkhoa=" + l_idkhoa + " and id=" + l_id;
                //    sql += " and to_char(ngay,'dd/mm/yyyy')='" + ngay.Substring(0,10) + "'";
                //    sql += " and done=1 and makp=" + makhoa + " and soluong=0";
                //    d.execute_data(sql);
                //    foreach (DataRow r1 in tmp.Rows)
                //    {
                //        sql = "update " + user + mmyy + ".d_tienthuoc set done=" + int.Parse(r1["done"].ToString()) + ",idttrv=" + decimal.Parse(r1["idttrv"].ToString());
                //        sql += " where mabn='" + s_mabn + "' and mavaovien=" + l_mavaovien + " and maql=" + l_maql;
                //        sql += " and idkhoa=" + l_idkhoa;
                //        sql += " and to_char(ngay,'dd/mm/yyyy')='" + ngay.Substring(0,10) + "' and makp=" + int.Parse(r1["makp"].ToString());
                //        sql += " and id=" + l_id;
                //        sql += " and madoituong=" + int.Parse(r1["madoituong"].ToString());
                //        sql += " and mabd=" + decimal.Parse(r1["mabd"].ToString());
                //        sql += " and done=0";
                //        d.execute_data(sql);
                //    }
                //}
                if (d.get_data("select * from " + user + mmyy + ".d_xuatsdct where id=" + l_id).Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin phiếu lĩnh chi tiết !"), d.Msg);
                    return;
                }
                decimal gia = 0;
                stt = 1;
                foreach (DataRow r1 in ds.Tables[0].Select("soluong>0"))
                {
                    gia = d.get_dongia(mmyy, makp, int.Parse(r1["mabd"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["madoituong"].ToString()));
                    //r = d.getrowbyid(dtdmbd, "id=" + int.Parse(r1["mabd"].ToString()));

                    v.upd_vpkhoa(l_idvpkhoa, s_mabn, l_mavaovien, l_maql, l_idkhoa, ngay, matrai, int.Parse(r1["madoituong"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()) * txtSoluong.Value, gia, 0, i_userid, 0);
                    d.upd_theodoicongno(d.insert, s_mabn, l_mavaovien, l_maql, l_idkhoa, int.Parse(r1["madoituong"].ToString()), Math.Round(decimal.Parse(r1["soluong"].ToString()) * txtSoluong.Value * gia, 3), "vienphi");
                    d.execute_data("update " + user + mmyy + ".d_xtutrucct set idvpkhoa=" + l_idvpkhoa + " where id=" + l_id + " and stt=" + stt);
                    stt++;
                }
                #endregion
                
                butMoi.Focus();
                //
            
           
            //DataRow[] dr = dt.Select("trongoi=1 and id=" + int.Parse(mavp.Text));
            //if (!bLocdichvu && madoituong.SelectedValue.ToString() == "1")
            //{
            //    sql = "id=" + decimal.Parse(mavp.Text) + " and bhyt<>0";
            //    if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Trim().Substring(v1, v2) + "%' or locthe like '%" + sothe.Text.Substring(0, 2) + ",%')";
            //    if (m.getrowbyid(dt, sql) == null)
            //    {
            //        madoituong.SelectedValue = 2;
            //        madoituong.Update();
            //    }
            //}
            decimal st = 0;
            string fie = "gia_th";
         
            int _madt = madoituong;
            //if (dr.Length > 0)
            //{
            //    sql = "select a.* from " + user + ".v_trongoi a left join " + user + ".v_giavp b on a.id_gia=b.id ";
            //    sql += " where  a.id=" + int.Parse(str);
            //    if (madoituong== 1 ) sql += " and b.bhyt>0";
            //    sql += " order by a.stt";

            upd_data(int.Parse(str), txtSoluong.Value, _madt, 0, 0);
            //}
            //else upd_data(int.Parse(str), 1, _madt, 0, 0);
           // getTong();
                    load_danhsach_chidinh();
            load_grid();
            butThem.Enabled = dataGrid1.Enabled = dataGrid2.Enabled = butLuu.Enabled = false;
        }

        decimal d_dongia, d_vattu;
        int i_loaitrongoi = 0;
        private void upd_detail(bool chenhlech, int i_mavp, decimal d_soluong, decimal dongia, int idtrongoi)
        {
            string ngaycd = "";

            string s_ngaygiohienhanh = m.ngayhienhanh_server;
            if (bNgayhienhanh_thuoc_chidinh)
            {
                ngaycd = s_ngaygiohienhanh;
            }
            else
            {
                ngaycd = ngay + s_ngaygiohienhanh.Substring(10, 6);
            }
            string gia, giavt;
            decimal tygia, dg_giam = 0, vt_giam = 0;
            decimal id_cha = 0;
            DataRow r = m.getrowbyid(dt, "id=" + i_mavp);
            if (r != null)
            {
                if (chenhlech)
                {
                    gia = m.field_gia(madoituong.ToString());
                    giavt = "vattu_" + gia.Substring(4).Trim();
                    tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                    d_dongia = decimal.Parse(r[gia].ToString()) * tygia - decimal.Parse(r["gia_bh"].ToString());
                    d_vattu = decimal.Parse(r[giavt].ToString()) * tygia - decimal.Parse(r["vattu_bh"].ToString());
                    if (cl_tyle != 0 && cl_cholam != "")
                    {
                        string scholam = m.get_cholam(s_mabn).ToString().Trim().ToLower();
                        if (cl_cholam.IndexOf(scholam) != -1 && scholam != "")
                        {
                            dg_giam = d_dongia * (cl_tyle / 100);
                            vt_giam = d_vattu * (cl_tyle / 100);
                            d_dongia -= dg_giam;
                            d_vattu -= vt_giam;
                        }
                    }
                }
                else
                {
                    gia = m.field_gia(madoituong.ToString());
                    giavt = "vattu_" + gia.Substring(4).Trim();
                    tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                    d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
                    d_vattu = decimal.Parse(r[giavt].ToString()) * tygia;
                }

                int itable = m.tableid(mmyy, "v_chidinh");
                if (l_idcd == 0)
                {
                    l_idcd = v.get_id_chidinh;
                    m.upd_eve_tables(ngay, itable, i_userid, "ins");
                }
                else
                {
                    m.upd_eve_tables(ngay, itable, i_userid, "upd");
                    m.upd_eve_upd_del(ngay, itable, i_userid, "upd", l_idcd.ToString() + "^" + s_mabn + "^" + l_mavaovien.ToString() + "^" + l_maql.ToString() + "^" + l_idkhoa.ToString() + "^" + ngay + "^" + loai.ToString() + "^" + makp + "^" + madoituong + "^" + i_mavp.ToString() + "^" + d_soluong.ToString() + "^" + d_dongia.ToString() + "^" + d_vattu.ToString() + "^" + i_userid.ToString() + "^" + 1 + "^" + 1);
                }
                if (!v.upd_chidinh(l_idcd, s_mabn, l_mavaovien, l_maql, l_idkhoa, ngaycd, loai, matrai, madoituong, i_mavp, d_soluong, (dongia != 0) ? dongia : d_dongia, (dongia != 0) ? 0 : d_vattu, i_userid, 1, 1, l_idchidinh, (maicd == "" && chandoan != "") ? "U00" : maicd, chandoan, mabs, loaiba, ""))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chỉ định !"), LibMedi.AccessData.Msg);
                    return;
                }
                id_cha = decimal.Parse(l_idcd.ToString());
                //Dong
                f_bnmien(i_mavp);
                if (ds_bnmien.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow ddr in ds_bnmien.Tables[0].Rows)
                    {
                        foreach (DataRow ddr1 in m.get_data(" select mavp,done,idchidinh,dongia from " + user + mmyy + ".v_chidinh where mavaovien=" + l_mavaovien + " and mabn='" + s_mabn + "' and idchidinh=" + l_idchidinh + " ").Tables[0].Rows)
                        {
                            m.execute_data(" update " + user + mmyy + ".v_chidinh set tylegiam=" + int.Parse(ddr["tylemien"].ToString()) + ",stgiam=" + ddr["tylemien"].ToString() + "*" + ddr1["dongia"].ToString() + "/100 where maql=" + l_maql + " and idchidinh=" + l_idchidinh + " and mavp=" + ddr1["mavp"].ToString());
                        }
                    }
                }
                //end Dong
                m.execute_data("update " + m.user + mmyy + ".v_chidinh set idduoc=" + idduoc + " where id=" + l_idcd);
                if (chenhlech)
                {
                    if (!bNew) m.execute_data("delete from " + user + mmyy + ".v_chidinh where paid=0 and hide=1 and maql=" + l_maql + " and idkhoa=" + l_idkhoa + " and mavp=" + i_mavp + " and to_char(ngay,'dd/mm/yyyy')='" + ngay.Substring(0, 10) + "'");
                    m.execute_data("update " + user +mmyy + ".v_chidinh set done=1,hide=1 where done=0 and id=" + l_idcd);
                }
                if (idtrongoi != 0) m.execute_data("update " + user + mmyy + ".v_chidinh set idtrongoi=" + idtrongoi + " where id=" + l_idcd);
                m.execute_data("update " + user + mmyy + ".v_chidinh set traituyen=" + i_traituyen + " where id =" + l_idcd);
                if (bChidinh_exp_txt) m.exp_chidinh(mmyy, l_idcd.ToString(), "0");
                m.execute_data("update " + user + mmyy + ".v_chidinh set traituyen=" + i_traituyen + " where id=" + l_idcd);
                //m.updrec_chidinh(ds.Tables[0], l_id, ngay, makp, , int.Parse(madoituong.SelectedValue.ToString()), madoituong.Text, i_mavp, r["ten"].ToString(), r["dvt"].ToString(), d_soluong, (dongia != 0) ? dongia : d_dongia, (dongia != 0) ? 0 : d_vattu, 0, 0, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), r["ma"].ToString(), (s_maicd == "" && chandoan.Text != "") ? "U00" : s_maicd, chandoan.Text, mabs.Text, i_loaiba, ghichu.Text, 0, 0, "");
                //DataRow[] dr = ds.Tables[0].Select("id=" + l_id);
                //if (dr.Length > 0)
                //{
                //    dr[0]["chon"] = true;
                //    if (chenhlech && dr[0]["done"].ToString() == "0") dr[0]["done"] = 1;
                //}
                if (dg_giam != 0)
                {
                    l_id = v.get_id_chidinh;
                    v.upd_chidinh(l_id, s_mabn, l_mavaovien, l_maql, l_idkhoa, ngaycd, loai, matrai, cl_doituong, i_mavp, d_soluong, dg_giam, vt_giam, i_userid, 1, 1, l_idchidinh, (maicd == "" && chandoan != "") ? "U00" : maicd, chandoan, mabs, loaiba, "");
                    m.execute_data("update " + user + mmyy + ".v_chidinh set done=0,hide=1,traituyen=" + i_traituyen + " where done=0 and id=" + l_id);
                    //m.updrec_chidinh(ds.Tables[0], l_id, ngay, makp, s_tenkp, cl_doituong, cl_tendoituong, i_mavp, r["ten"].ToString(), r["dvt"].ToString(), d_soluong, dg_giam, vt_giam, 0, 0, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), r["ma"].ToString(), (s_maicd == "" && chandoan.Text != "") ? "U00" : s_maicd, chandoan.Text, mabs.Text, i_loaiba, ghichu.Text, 0, 0, "");
                }
                if (bNew)
                {
                    sql = "select a.id_gia,a.soluong,b.id,b.ten,b.ma,b.dvt,a.madoituong,b.loaitrongoi from " + user + ".v_trongoi a," + user + ".v_giavp b where a.id_gia=b.id and a.id=" + i_mavp + " and a.id_loai<>'-999'";
                    DataRow r11;
                    DataTable dttam = new DataTable();
                    i_loaitrongoi = int.Parse(m.get_data("select loaitrongoi from " + m.user + ".v_giavp where id=" + i_mavp.ToString()).Tables[0].Rows[0][0].ToString());
                    dttam = m.get_data(sql).Tables[0];
                    foreach (DataRow dr1 in dttam.Rows)
                    {
                        l_idcd = v.get_id_chidinh;
                        if (!v.upd_chidinh(l_idcd, s_mabn, l_mavaovien, l_maql, l_idkhoa, ngaycd, loai, matrai, int.Parse(dr1["madoituong"].ToString()), int.Parse(dr1["id_gia"].ToString()), (int)decimal.Parse(dr1["soluong"].ToString()) * d_soluong, 0, 0, i_userid, 1, 1, 0, (maicd == "" && chandoan != "") ? "U00" : maicd, chandoan, mabs, loaiba, ""))
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chỉ định !"), LibMedi.AccessData.Msg);
                            return;
                        }
                        sql = "update " + user + mmyy + ".v_chidinh set ";
                        if (i_loaitrongoi == 1) sql += "paid=1,";
                        sql += "id_goi=" + id_cha + " where id=" + l_idcd;
                        m.execute_data(sql);
                        //r = m.getrowbyid(dt, "id=" + int.Parse(dr1["id_gia"].ToString()));
                        r11 = m.getrowbyid(dttam, "id=" + int.Parse(dr1["id_gia"].ToString()));
                        //m.updrec_chidinh(ds.Tables[0], l_id, ngay, makp, s_tenkp, cl_doituong, cl_tendoituong, int.Parse(dr1["id_gia"].ToString()), r11["ten"].ToString(), r11["dvt"].ToString(), decimal.Parse(dr1["soluong"].ToString()), 0, 0, 0, 0, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), r11["ma"].ToString(), (s_maicd == "" && chandoan.Text != "") ? "U00" : s_maicd, chandoan.Text, mabs.Text, i_loaiba, ghichu.Text, 0, 0, "");
                    }
                }
            }

        }

        private void upd_data(int i_mavp, decimal d_soluong, int i_madt, decimal dongia, int idtrongoi)
        {
            if (bNew)
            {
            sql = "select to_char(a.ngay,'dd/mm/yyyy') as ngay,b.ten from xxx.v_chidinh a," + user + ".v_giavp b where a.mavp=b.id and a.mavaovien=" + l_mavaovien + " and mabn='" + s_mabn + "' and a.mavp=" + i_mavp + " and a.id<>" + l_id + " and a.madoituong=" + i_madt;
            DataTable tmp = d.get_data_mmyy(sql, ngay, ngay, 30).Tables[0];
            if (tmp.Rows.Count > 0)
                if (MessageBox.Show(tmp.Rows[0]["ten"].ToString().Trim() + lan.Change_language_MessageText(" đã nhập ngày ") + tmp.Rows[0]["ngay"].ToString() + lan.Change_language_MessageText("\nBạn đồng ý nhập tiếp không ?"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
        }
            bool bCont = false;
            string fie = "gia_bh";
            int s_doituong_chenhlech = (i_madt == i_tunguyen || i_madt == madoituong) ? madoituong : i_madt;//binh 050109
            DataRow r = m.getrowbyid(dtdt, "madoituong=" + s_doituong_chenhlech);//binh 050109
            //if (r != null) { fie = r["field_gia"].ToString(); bCont = r["chenhlech"].ToString() == "1"; }
            //else 
            bCont = false;
            r = m.getrowbyid(dt, "id=" + i_mavp);
            if (r != null)
            {
                if (bChenhlech_doituong) bCont = bCont && s_chenhlech.IndexOf(madoituong.ToString().Trim() + ",") != -1;
                else bCont = bCont && s_chenhlech.IndexOf(i_madt.ToString().Trim() + ",") != -1;
                //bCont = bCont && s_chenhlech.IndexOf(i_madt.ToString().Trim() + ",") != -1
                //        && r["chenhlech"].ToString().Trim() == "1" 
                //        && decimal.Parse(r[m.field_gia(i_tunguyen.ToString())].ToString()) > decimal.Parse(r[fie].ToString());
                bCont = bCont && r["chenhlech"].ToString().Trim() == "1"
                        && decimal.Parse(r[m.field_gia(i_tunguyen.ToString())].ToString()) > decimal.Parse(r[fie].ToString());
                if (!bChidinh_thutienlien) bCont = bCont && loaiba == 3;
                if (bChenhlech_doituong) bCont = bCont && (i_madt == i_tunguyen);
                if (madoituong == 1) bCont = bCont && (decimal.Parse(r["bhyt"].ToString()) > 0);
                if (bCont)
                {
                    madoituong = madoituong;
                    //madoituong.Update();
                    upd_detail(false, i_mavp, d_soluong, dongia, idtrongoi);
                    l_id = 0;
                    //madoituong.SelectedValue = i_tunguyen.ToString();
                   // madoituong.Update();
                    upd_detail(true, i_mavp, d_soluong, dongia, idtrongoi);
                }
                else
                {
                    //madoituong.SelectedValue = i_madt.ToString();
                   // madoituong.Update();
                    upd_detail(false, i_mavp, d_soluong, dongia, idtrongoi);
                }
                //if (bTinnhan) netsend(r["computer"].ToString());
                //if (bTinnhan_sound) m.upd_tinnhan((bChidinh_ngtru_vienphi) ? r["computervp"].ToString() : r["computer"].ToString(), (bChidinh_ngtru_vienphi) ? "vienphi" : "cls", 1);
            }
        }

        #region code cu
        //this.butLuu.Enabled = false; 
            
        //    this.ds.AcceptChanges();
        //    if (l_id == 0)
        //    {
        //        l_id=d.get_id_xuatsd;
        //    }
        //    if (!this.bNew)
        //    {
        //        string str2 = this.user + this.mmyy;
        //        foreach (DataRow row3 in this.d.get_data(string.Concat(new object[] { "select a.*,b.manguon,b.giaban,b.giamua,a.soluong*b.giamua as sotien,b.gianovat from ", str2, ".d_thucxuat a,", str2, ".d_theodoi b where a.sttt=b.id and a.id=", this.l_id })).Tables[0].Rows)
        //        {
        //            this.d.upd_tonkhoct_thucxuat(this.d.delete, this.mmyy, this.makp, this.loai, 1, decimal.Parse(row3["sttt"].ToString()), int.Parse(row3["makho"].ToString()), int.Parse(row3["manguon"].ToString()), int.Parse(row3["mabd"].ToString()), decimal.Parse(row3["soluong"].ToString()));
        //            this.d.upd_theodoicongno(this.d.delete, this.s_mabn, this.l_mavaovien, this.l_maql, this.l_idkhoa, int.Parse(row3["madoituong"].ToString()), decimal.Parse(row3["sotien"].ToString()), "thuoc");
        //            //this.d.upd_tienthuoc(this.d.delete, this.mmyy, this.l_id, this.s_mabn, this.l_mavaovien, this.l_maql, this.l_idkhoa, this.ngay, this.makhoa, this.loai, int.Parse(row3["madoituong"].ToString()), int.Parse(row3["mabd"].ToString()), decimal.Parse(row3["soluong"].ToString()), decimal.Parse(row3["giaban"].ToString()), decimal.Parse(row3["giamua"].ToString()), decimal.Parse(row3["gianovat"].ToString()));
        //        }
        //        this.d.execute_data("delete from " + str2 + ".d_xuatsdct where id=" + this.l_id.ToString());
        //        this.d.execute_data("delete from " + str2 + ".d_thucxuat where id=" + this.l_id.ToString());
        //        this.d.execute_data("delete from " + str2 + ".d_xtutrucct where id=" + this.l_id.ToString());
        //        this.d.execute_data("delete from " + str2 + ".d_xtutrucll where id=" + this.l_id.ToString());
        //    }
        //    //linh
        //    if (l_duyet == 0)
        //    {
        //        l_duyet = d.get_id_duyet;
        //        d.upd_duyet(mmyy, l_duyet, i_nhom, ngay, loai, phieu, makp, 0, i_userid, makhoa);
        //    }
        //    foreach (DataRow r1 in m.get_data("select * from " + user + ".d_dmkho where id in (" + makho.Trim(',') + ")").Tables[0].Rows)
        //        d.upd_duyetkho(mmyy, l_duyet, int.Parse(r1["id"].ToString()), 0);
        //    if (!d.upd_xtutrucll(this.mmyy, this.l_id, this.l_duyet, this.s_mabn, this.l_mavaovien, this.l_maql, this.l_idkhoa, ngay, 1M))
        //    {
        //        return;
        //    }
        //    this.d.upd_dausinhton(this.mmyy, this.l_id, this.l_idkhoa, this.l_id, this.ngay,mabs,"", 0M, 0M, "", 0M, 0, "", "", "",s_mabn);
        //    int stt = 1;
        //    foreach (DataRow row3 in this.ds.Tables[0].Select("soluong>0"))
        //    {
        //        this.d.upd_xtutrucct(this.mmyy, this.l_id, (decimal)stt, int.Parse(row3["madoituong"].ToString()), int.Parse(row3["makho"].ToString()), int.Parse(row3["mabd"].ToString()), decimal.Parse(row3["soluong"].ToString()), 0M, "", int.Parse(row3["manguon"].ToString()), 0L, 1M, 1M);
        //        stt++;
        //    }
        //    this.d.upd_xuatsdll(this.mmyy, this.l_id, this.i_nhom, this.s_mabn, this.l_mavaovien, this.l_maql, this.l_idkhoa, this.ngay, this.loai, this.phieu, this.makp, this.i_userid, this.l_id, 1, this.makhoa, 0, 0, this.l_mavp.ToString(), this.ngay);
        //    this.d.get_xuatsdct_cstt(this.mmyy, this.ds.Tables[0].Select("soluong>0"), this.makp, this.makhoa, 0, this.l_id, this.s_mabn, this.l_mavaovien, this.l_maql, this.l_idkhoa, this.loai, 1, this.ngay, this.i_nhom, this.ngay,i_traituyen);
        //    if (bNew)
        //    {
        //        string dich = "";
        //        DataRow row = this.m.getrowbyid(this.tmp, "id='" + this.mamau + "'");
        //        if (row != null)
        //        {
        //            if ((int.Parse(row["id"].ToString()) != 0))
        //            {
        //                this.upd_chidinh(int.Parse(row["id"].ToString()));
        //            }
        //            dich = row["ten"].ToString();
        //        }
        //        //if (this.bLocthan || (this.l_idchaythan != 0L))
        //        //{
        //        //    if (this.l_idchaythan != 0L)
        //        //    {
        //        //        this.m.execute_data("update lichthan set done=1 where id=" + this.l_idchaythan);
        //        //    }
        //        //    else
        //        //    {
        //        //        this.m.upd_benhanthan(this.ngayvv, this.l_idlocthan, dich, this.l_id, this.l_idchidinh, this.mamau);
        //        //    }
        //        //}
        //    }
        //    this.butKetthuc.Focus();
        //    load_danhsach_chidinh();
        //    butMoi.Enabled = true;
        //    butSua.Enabled = true;
        //    treeView1.Enabled = false;
        //    treeLan.Enabled = true;
        #endregion 

        private void butThem_Click(object sender, EventArgs e)
        {
            if (this.dsdm.Select("chon=true").Length > 0)
            {
                int num = 5;
                if ((this.m.getrowbyid(this.dtdt, "madoituong=5") == null) && (this.dtdt.Rows.Count > 0))
                {
                    num = int.Parse(this.dtdt.Rows[0]["madoituong"].ToString());
                }
                foreach (DataRow row4 in this.dsdm.Select("chon=true"))
                {
                    try
                    {
                        //string exp = "mabd=" + int.Parse(row4["id"].ToString()) + " and madoituong=" + num.ToString();
                        //if (this.m.getrowbyid(this.ds.Tables[0], exp) == null)
                        //{
                            DataRow row = this.ds.Tables[0].NewRow();
                            row["makho"] = 0;
                            row["manguon"] = this.dtnguon.Rows[0]["id"].ToString();
                            row["nguon"] = this.dtnguon.Rows[0]["ten"].ToString();
                            row["madoituong"] = num.ToString();
                            DataRow row3 = this.m.getrowbyid(this.dtdt, "madoituong=" + num);
                            if (row3 != null)
                            {
                                row["doituong"] = row3["doituong"].ToString();
                            }
                            row["mabd"] = row4["id"].ToString();
                            row["ma"] = row4["ma"].ToString();
                            row["ten"] = row4["ten"].ToString();
                            row["dang"] = row4["dang"].ToString();
                            row["soluong"] = 1;
                            this.ds.Tables[0].Rows.Add(row);
                        //}
                    }
                    catch (Exception ex)
                    { string s = ex.ToString(); }
                }
                foreach (DataRow row5 in this.dsdm.Rows)
                {
                    row5["chon"] = false;
                }
            }
            this.butLuu.Enabled = true;
            this.butLuu.Focus();
        }

        private void chkInphieu_Click(object sender, EventArgs e)
        {
            this.m.writeXml("thongso", "goithanincls", this.chkInphieu.Checked ? "1" : "0");
        }

        private void ClearBackColor1()
        {
            TreeNodeCollection nodes = this.treeView1.Nodes;
            foreach (TreeNode node in nodes)
            {
                this.ClearRecursive1(node);
            }
        }

        private void ClearRecursive1(TreeNode treeNode)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.BackColor = SystemColors.Info;
                this.ClearRecursive1(node);
            }
        }

        private void dataGrid1_Click(object sender, EventArgs e)
        {
            //Point position = this.dataGrid1.PointToClient(Control.MousePosition);
            //DataGrid.HitTestInfo info = this.dataGrid1.HitTest(position);
            //BindingManagerBase base2 = this.BindingContext[this.dataGrid1.DataSource, this.dataGrid1.DataMember];
            //if (((this.afterCurrentCellChanged && (info.Row < base2.Count)) && (info.Type == DataGrid.HitTestType.Cell)) && (info.Column == this.checkCol))
            //{
            //    this.dataGrid1[info.Row, this.checkCol] = !((bool)this.dataGrid1[info.Row, this.checkCol]);
            //    this.RefreshRow(info.Row);
            //}
            //this.afterCurrentCellChanged = false;
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            if ((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, this.checkCol])
            {
                this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, this.checkCol);
            }
            this.afterCurrentCellChanged = true;
        }

        private void dataGrid1_Navigate(object sender, NavigateEventArgs ne)
        {
            try
            {
                this.m.delrec(this.ds.Tables[0], "mabd=" + decimal.Parse(this.dataGrid2[this.dataGrid2.CurrentCell.RowNumber, 0].ToString()));
            }
            catch
            {
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                if (this.disabledBackBrush != null)
                {
                    this.disabledBackBrush.Dispose();
                    this.disabledTextBrush.Dispose();
                    this.alertBackBrush.Dispose();
                    this.alertFont.Dispose();
                    this.alertTextBrush.Dispose();
                    this.currentRowFont.Dispose();
                    this.currentRowBackBrush.Dispose();
                }
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FindByText1()
        {
            TreeNodeCollection nodes = this.treeView1.Nodes;
            foreach (TreeNode node in nodes)
            {
                this.FindRecursive1(node);
            }
        }

        private void FindRecursive1(TreeNode treeNode)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                if (node.Text.ToLower().IndexOf(this.timkiem.Text.ToLower().Trim()) != -1)
                {
                    node.BackColor = System.Drawing.Color.Yellow;
                }
                this.FindRecursive1(node);
            }
        }

        private void frmGoiDichvu_Load(object sender, EventArgs e)
        {
            mmyy = m.mmyy(ngay);
            butcauhoitc.Visible = bTiemchung;
            bNgayhienhanh_thuoc_chidinh = m.bNgayhienhanh_thuoc_chidinh;
            this.dtdt = this.m.get_data("select * from " + m.user + ".d_doituong order by madoituong").Tables[0];
            if (this.d.bQuanlynguon(this.i_nhom))
            {
                this.dtnguon = this.d.get_data(string.Concat(new object[] { "select * from ", m.user, ".d_dmnguon where nhom=", this.i_nhom, " order by stt" })).Tables[0];
            }
            else
            {
                this.dtnguon = this.d.get_data(string.Concat(new object[] { "select * from ", m.user, ".d_dmnguon where nhom=0 or nhom=", this.i_nhom, " order by stt" })).Tables[0];
            }
            //if (this.mapt != "")
            //{
            //    foreach (DataRow row in this.m.get_data("select mavp from " + this.user + ".dmpttt where mapt='" + this.mapt + "'").Tables[0].Rows)
            //    {
            //        this.l_mavp = decimal.Parse(row["mavp"].ToString());
            //    }
            //}
            this.s_chenhlech = "";
            foreach (DataRow row in this.m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + this.user + ".doituong a where chenhlech=1").Tables[0].Rows)
            {
                this.s_chenhlech = this.s_chenhlech + row["madoituong"].ToString().Trim() + ",";
            }
            this.bBienlaichiuthue = false;//this.m.bBienlaichiuthue;
            this.Bienlaichiuthue_gia = "";//this.m.Bienlaichiuthue_gia;
            this.sys_nhom_bienlai_dichvu = "";//this.m.sys_nhom_bienlai_dichvu;
            this.bChidinh_exp_txt = this.m.bChidinh_exp_txt;
            bAdminInlaidonthuoc = m.bAdminInlaidonthuoc;
            bSophieu_chidinh = m.bSophieu_chidinh;
            //bChidinh_loaivp = m.bChidinh_loaivp;
            bAdminInlaiphieuchidinh = m.bAdminInlaiphieuchidinh;
            this.bChidinh_loaivp = this.m.bChidinh_loaivp;
            this.bChidinh_thutienlien = this.m.bChidinh_thutienlien;
            this.bChenhlech_doituong = this.m.bChenhlech_doituong;
            this.cl_cholam = this.m.mien_chenhlech_cholam.Trim().ToLower();
            this.bChuky = this.m.bChuky;
            this.cl_tyle = this.m.mien_chenhlech;
            this.cl_doituong = this.m.mien_chenhlech_doituong;
            this.Tamung_min = this.m.Tamung_min;
            this.Tamung_min_makp = "";//this.m.Tamung_min_makp;
            //if ((this.Tamung_min != 0M) && ((this.Tamung_min_makp != "") && (this.Tamung_min_makp.IndexOf(this.matrai) == -1)))
            //{
            //    this.Tamung_min = 0M;
            //}
            this.Sotien_chidinh_tamung = 0;// this.m.Sotien_chidinh_tamung;
            this.sMakp_chidinh_tamung = "";//this.m.sMakp_chidinh_tamung;
            this.v1 = 4;
            this.v2 = 2;
            //string str = this.d.thetunguyen_vitri_ora(this.m.nhom_duoc);
            //if (str.Length == 3)
            //{
            //    this.v1 = int.Parse(str.Substring(0, 1)) - 1;
            //    this.v2 = int.Parse(str.Substring(2, 1));
            //}
            //this.i_tunguyen = this.m.iTunguyen;
            //this.bLocdichvu = this.m.bLocdichvu_doituong;

            //loai=1,2 luu the bhyt vao goc
            if (loaiba == 1 || loaiba == 2)
            {
                sql = "select sothe,traituyen from " + m.user + ".bhyt where maql=" + l_maql + " and mabn='" + s_mabn + "'";
            }
            else
            {
                sql = "select sothe,traituyen from " + m.user + mmyy + ".bhyt where maql=" + l_maql + " and mabn='" + s_mabn + "'";
            }
            dtthe = m.get_data(sql).Tables[0];
            if (dtthe.Rows.Count > 0)
            {
                sothe = dtthe.Rows[0]["sothe"].ToString();
                i_traituyen = int.Parse(dtthe.Rows[0]["traituyen"].ToString());
            }
            else
                i_traituyen = 0;

            this.dtdtvp = this.d.get_data("select a.*,to_char(madoituong) as madoituong1 from " + m.user + ".doituong a where sothe>0 and ngay>0 order by madoituong").Tables[0];
            this.sql = "select a.id,a.ten,a.ma,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.bhyt,a.vattu_th,a.vattu_bh,a.vattu_dv,";
            this.sql = this.sql + " a.vattu_nn,b.computer,b.computervp,a.trongoi,a.locthe,a.gia_cs,a.vattu_cs,a.chenhlech,a.gia_ksk,a.vattu_ksk,0 noithuchien,b.id_nhom ,a.thuong";
            this.sql = this.sql + " from " + m.user + ".v_giavp a," + m.user + ".v_loaivp b ";
            this.sql = this.sql + " where a.id_loai=b.id and a.hide=0";
            this.sql = this.sql + " and (a.loaibn=0 or a.loaibn=" + this.v.iNgoaitru + ")";
            this.sql = this.sql + " order by b.stt,a.stt";
            this.dt = this.m.get_data(this.sql).Tables[0];
            this.f_soluong = this.d.format_soluong(this.i_nhom);
            this.disabledBackBrush = new SolidBrush(Color.FromArgb(0xff, 0xff, 0xc0));
            this.disabledTextBrush = new SolidBrush(Color.FromArgb(0xff, 0, 0));
            this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
            this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
            this.alertTextBrush = new SolidBrush(Color.White);
            this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
            this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0, 0xff, 0xff));
            this.m.execute_data("delete from " + this.user + this.mmyy + ".d_xtutrucct where id=0");
            this.m.execute_data("delete from " + this.user + this.mmyy + ".d_xtutrucll where id=0");
            this.load_grid();
            this.AddGridTableStyle();
            //this.ds.ReadXml("..//..//..//xml//m_pttt_thuoc.xml");
            //this.AddGridTableStyle1();
            //this.dtmuc = this.m.get_data("select * from muc").Tables[0];
            this.load_treeview();
            this.load_chitiet();
            //this.chkInphieu.Checked = this.m.Thongso("goithanincls") == "1";
            ////linh
            load_danhsach_chidinh();
            butSua.Enabled = false;
            butMoi.Enabled = true;
            //try
            //{
            //    txtSoluong.Value = m_soluong_default;
            //}
            //catch (Exception ex)
            //{
            //    string s = ex.ToString();
            //    s = s.Trim();
            //}
            //butMoi_Click(null, null);
            load_treeview();
        }

        private string get_ngaygio(string ngay)
        {
            return (ngay.Substring(0, 10) + " " + this.m.ngayhienhanh_server.Substring(11));
        }
        #region design
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGoiDichvu));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tim = new System.Windows.Forms.TextBox();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.timkiem = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.chkInphieu = new System.Windows.Forms.ToolStripMenuItem();
            this.chkXML = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnDefault_sl = new System.Windows.Forms.ToolStripMenuItem();
            this.butHuy = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoluong = new System.Windows.Forms.NumericUpDown();
            this.butMoi = new System.Windows.Forms.Button();
            this.treeLan = new System.Windows.Forms.TreeView();
            this.butSua = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butcauhoitc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoluong)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(279, 285);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.Size = new System.Drawing.Size(568, 184);
            this.dataGrid1.TabIndex = 23;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataGrid1_Navigate);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(279, 477);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(571, 21);
            this.tim.TabIndex = 1;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(279, 3);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.RowHeaderWidth = 3;
            this.dataGrid2.Size = new System.Drawing.Size(568, 297);
            this.dataGrid2.TabIndex = 26;
            // 
            // timkiem
            // 
            this.timkiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.timkiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.timkiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timkiem.ForeColor = System.Drawing.Color.Red;
            this.timkiem.Location = new System.Drawing.Point(1, 22);
            this.timkiem.Name = "timkiem";
            this.timkiem.Size = new System.Drawing.Size(276, 21);
            this.timkiem.TabIndex = 53;
            this.timkiem.Text = "Tìm kiếm";
            this.timkiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timkiem.TextChanged += new System.EventHandler(this.timkiem_TextChanged);
            this.timkiem.Enter += new System.EventHandler(this.timkiem_Enter);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BackColor = System.Drawing.SystemColors.Info;
            this.treeView1.ItemHeight = 18;
            this.treeView1.Location = new System.Drawing.Point(0, 44);
            this.treeView1.Name = "treeView1";
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(277, 357);
            this.treeView1.TabIndex = 52;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(850, 22);
            this.toolStrip1.TabIndex = 54;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chkInphieu,
            this.chkXML,
            this.toolStripSeparator1,
            this.mnDefault_sl});
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(62, 19);
            this.toolStripDropDownButton1.Text = "Tiện ích";
            // 
            // chkInphieu
            // 
            this.chkInphieu.CheckOnClick = true;
            this.chkInphieu.Name = "chkInphieu";
            this.chkInphieu.Size = new System.Drawing.Size(292, 22);
            this.chkInphieu.Text = "In phiếu chỉ định";
            this.chkInphieu.Click += new System.EventHandler(this.chkInphieu_Click);
            // 
            // chkXML
            // 
            this.chkXML.CheckOnClick = true;
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(292, 22);
            this.chkXML.Text = "Xuất ra XML";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(289, 6);
            // 
            // mnDefault_sl
            // 
            this.mnDefault_sl.Name = "mnDefault_sl";
            this.mnDefault_sl.Size = new System.Drawing.Size(292, 22);
            this.mnDefault_sl.Text = "Đặt số lượng hiện tại làm giá trị mặc định";
            this.mnDefault_sl.Click += new System.EventHandler(this.mnDefault_sl_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(705, 506);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 275;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butThem
            // 
            this.butThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(355, 506);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 27;
            this.butThem.Text = "    &Thêm";
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(565, 506);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 2;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(775, 506);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(72, 25);
            this.butKetthuc.TabIndex = 4;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(635, 506);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 276;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, 506);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 277;
            this.label1.Text = "Số lượng:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSoluong
            // 
            this.txtSoluong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSoluong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoluong.Location = new System.Drawing.Point(70, 509);
            this.txtSoluong.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtSoluong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.Size = new System.Drawing.Size(43, 20);
            this.txtSoluong.TabIndex = 278;
            this.txtSoluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSoluong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSoluong.ValueChanged += new System.EventHandler(this.txtSoluong_ValueChanged);
            this.txtSoluong.Validated += new System.EventHandler(this.txtSoluong_Validated);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(285, 506);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 279;
            this.butMoi.Text = "   &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // treeLan
            // 
            this.treeLan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeLan.BackColor = System.Drawing.Color.Gainsboro;
            this.treeLan.Location = new System.Drawing.Point(0, 404);
            this.treeLan.Name = "treeLan";
            this.treeLan.Size = new System.Drawing.Size(277, 94);
            this.treeLan.TabIndex = 280;
            this.treeLan.DoubleClick += new System.EventHandler(this.treeLan_DoubleClick);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(425, 506);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 281;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(495, 506);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 282;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butcauhoitc
            // 
            this.butcauhoitc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butcauhoitc.Image = ((System.Drawing.Image)(resources.GetObject("butcauhoitc.Image")));
            this.butcauhoitc.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.butcauhoitc.Location = new System.Drawing.Point(116, 506);
            this.butcauhoitc.Name = "butcauhoitc";
            this.butcauhoitc.Size = new System.Drawing.Size(169, 25);
            this.butcauhoitc.TabIndex = 289;
            this.butcauhoitc.Text = "    &Câu hỏi sàng lọc tiêm chủng";
            this.butcauhoitc.UseVisualStyleBackColor = true;
            this.butcauhoitc.Click += new System.EventHandler(this.butcauhoitc_Click);
            // 
            // frmGoiDichvu
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(850, 536);
            this.Controls.Add(this.butcauhoitc);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.treeLan);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.txtSoluong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.timkiem);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butKetthuc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGoiDichvu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉ định gói dịch vụ";
            this.Load += new System.EventHandler(this.frmGoiDichvu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoluong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private void load_chitiet()
        {
            try
            {
                this.dataGrid2.DataSource = null;
                this.sql = "select 0 makho,0 manguon,'' nguon,b.madoituong,d.doituong,a.id mabd,a.ma,trim(a.ten)||' '||a.hamluong as ten,a.dang,c.ten as tenhang,b.soluong as soluong ";
                string sql = this.sql;
                this.sql = sql + " from " + m.user + ".d_dmbd a, " + m.user + ".v_trongoi b left join " + m.user + ".d_doituong d on b.madoituong=d.madoituong , " + m.user + ".d_dmhang c";
                //this.sql = this.sql + " inner join " + this.user + ".d_dmhang c on a.mahang=c.id ";
                //this.sql = this.sql + " left join " + this.user + ".d_doituong d on b.madoituong=d.madoituong ";
                //this.sql = this.sql + " inner join " + this.user + ".d_dmnguon e on b.manguon=e.id ";
                object obj2 = this.sql;
                this.sql += " where a.id=b.id_gia and a.mahang=c.id and b.id=" + str;
                this.ds = this.m.get_data(this.sql);
                //if (this.ds.Tables[0].Rows.Count == 0)
                //{
                //    this.sql = "select rownum as stt,0 as makho,b.manguon,e.ten as nguon,b.madoituong,d.doituong,b.mabd,a.ma,trim(a.ten)||' '||a.hamluong as ten,a.dang,c.ten as tenhang,b.soluong*" + txtSoluong.Value.ToString() + " as soluong ";
                //    sql = this.sql;
                //    this.sql = sql + " from " + this.user + ".d_dmbd a inner join " + this.user + ".pttt_thuoc b on a.id=b.mabd";
                //    this.sql = this.sql + " inner join " + this.user + ".d_dmhang c on a.mahang=c.id ";
                //    this.sql = this.sql + " left join " + this.user + ".d_doituong d on b.madoituong=d.madoituong ";
                //    this.sql = this.sql + " inner join " + this.user + ".d_dmnguon e on b.manguon=e.id ";
                //    this.sql = this.sql + " where b.ma='" + this.mamau + "' order by stt";
                //    this.ds = this.m.get_data(this.sql);
                //}
                this.objStudentCM = (CurrencyManager)this.BindingContext[this.ds.Tables[0]];
                //this.ts.MappingName = this.ds.Tables[0].TableName;
                this.dataGrid2.DataSource = this.ds;
                this.dataGrid2.DataMember = this.ds.Tables[0].TableName;
                AddGridTableStyle1();
            }
            catch { }
        }
        private void load_chitiet(decimal _id)
        {
            dataGrid2.DataSource = null;
            sql = "select rownum as stt,b.makho,b.manguon,e.ten as nguon,b.madoituong,d.doituong,b.mabd,a.ma,trim(a.ten)||' '||a.hamluong as ten,a.dang,c.ten as tenhang,b.slyeucau as soluong ";
            sql += " from " + user + ".d_dmbd a inner join " + user + mmyy + ".d_xtutrucct b on a.id=b.mabd";
            sql += " inner join " + user + ".d_dmhang c on a.mahang=c.id ";
            sql += " left join " + user + ".d_doituong d on b.madoituong=d.madoituong ";
            sql += " inner join " + user + ".d_dmnguon e on b.manguon=e.id ";
            sql += " where b.id=" + _id + " order by b.stt";
            ds = m.get_data(sql);
            if (ds.Tables[0].Rows.Count == 0)
            {
                sql = "select rownum as stt,0 as makho,b.manguon,e.ten as nguon,b.madoituong,d.doituong,b.mabd,a.ma,trim(a.ten)||' '||a.hamluong as ten,a.dang,c.ten as tenhang,b.soluong ";
                sql += " from " + user + ".d_dmbd a inner join " + user + ".pttt_thuoc b on a.id=b.mabd";
                sql += " inner join " + user + ".d_dmhang c on a.mahang=c.id ";
                sql += " left join " + user + ".d_doituong d on b.madoituong=d.madoituong ";
                sql += " inner join " + user + ".d_dmnguon e on b.manguon=e.id ";
                sql += " where b.ma='" + mamau + "' order by stt";
                ds = m.get_data(sql);
            }
            objStudentCM = (CurrencyManager)BindingContext[ds.Tables[0]];
            //ts.MappingName = ds.Tables[0].TableName;
            dataGrid2.DataSource = ds;
            dataGrid2.DataMember = ds.Tables[0].TableName;
            AddGridTableStyle1();
            CurrencyManager manager = (CurrencyManager)this.BindingContext[this.dataGrid2.DataSource, this.dataGrid2.DataMember];
            DataView list = (DataView)manager.List;
            list.AllowNew = false;
        }

        private void load_grid()
        {
            this.dsdm = new DataTable();
            this.dsdm = this.d.get_tutructh_dutru(this.mmyy, this.makp, this.makho, this.manguon, 0, this.i_nhom);
            this.dsdm.Columns.Add("Chon", typeof(bool));
            this.dataGrid1.DataSource = this.dsdm;
            CurrencyManager manager = (CurrencyManager)this.BindingContext[this.dataGrid1.DataSource, this.dataGrid1.DataMember];
            DataView list = (DataView)manager.List;
            list.AllowNew = false;
            foreach (DataRow row in this.dsdm.Rows)
            {
                row["chon"] = false;
            }
        }

        private void load_treeview()
        {
            DataRow current;
            try
            {
                this.treeView1.Nodes.Clear();
                //this.sql = "select rownum as stt,a.ma,a.mapt,a.ten,b.id_pttt as maloai,b.id_muc as mamuc,a.mavp";
                //this.sql = this.sql + " from pttt_mau a,dmpttt b";
                //this.sql = this.sql + " where a.mapt=b.mapt and a.matrai like '%" + this.matrai + "%'";
                //this.sql = this.sql + " order by b.id_pttt,b.id_muc,a.ma";
                sql = "select a.id,a.ten,a.id_loai,b.ten tenloai,b.id_nhom,c.ten tennhom from " + m.user + ".v_giavp a," + m.user + ".v_loaivp b," + m.user + ".v_nhomvp c where a.trongoi=1 and a.loaitrongoi=1 and a.id_loai=b.id and b.id_nhom=c.ma ";
                if (bTiemchung) sql += " and a.id in(select b.id from medibv.d_dmbd a,medibv.v_trongoi b where vacxin=1 and a.id=b.id_gia) ";
                sql+=" order by b.id_nhom,b.id,a.ten";
                this.tmp = this.m.get_data(this.sql).Tables[0];
                //if (this.tmp.Rows.Count == 0)
                //{
                //    this.sql = "select rownum as stt,a.ma,a.mapt,a.ten,b.id_pttt as maloai,b.id_muc as mamuc,a.mavp";
                //    this.sql = this.sql + " from pttt_mau a,dmpttt b";
                //    this.sql = this.sql + " where a.mapt=b.mapt ";
                //    this.sql = this.sql + " order by b.id_pttt,b.id_muc,a.ma";
                //    this.tmp = this.m.get_data(this.sql).Tables[0];
                //}
                int num = -1;
                int num2 = -1;
                string text = "";
                IEnumerator enumerator = this.tmp.Rows.GetEnumerator();
                {
                    while (enumerator.MoveNext())
                    {
                        current = (DataRow)enumerator.Current;
                        if (num != int.Parse(current["id_nhom"].ToString()))
                        {
                            num = int.Parse(current["id_nhom"].ToString());
                            TreeNode node = new TreeNode((current["tennhom"].ToString()));
                            node.Tag = "1_" + current["id_nhom"].ToString();
                            this.treeView1.Nodes.Add(node);
                            foreach (DataRow row3 in this.tmp.Select("id_nhom=" + num, "id_loai,ten"))
                            {
                                if (num2 != int.Parse(row3["id_loai"].ToString()))
                                {
                                    num2 = int.Parse(row3["id_loai"].ToString());
                                    DataRow row = this.m.getrowbyid(this.tmp, string.Concat(new object[] { "id_nhom=", num, " and id_loai=", num2 }));
                                    text = row["tenloai"].ToString();
                                    TreeNode node2 = new TreeNode(text);
                                    node2.Tag = "2_" + row3["id"].ToString();
                                    node.Nodes.Add(node2);
                                    foreach (DataRow row4 in this.tmp.Select(string.Concat(new object[] { "id_nhom=", num, " and id_loai=", num2 }), "id_loai,ten"))
                                    {
                                        TreeNode node3 = new TreeNode(row4["ten"].ToString());
                                        node3.Tag = row4["id"].ToString();
                                        node2.Nodes.Add(node3);
                                    }
                                }
                            }
                        }
                    }
                }
                this.treeView1.ExpandAll();
            }
            catch
            {
            }
            if (this.mamau != "")
            {
                current = this.m.getrowbyid(this.tmp, "id='" + this.mamau + "'");
                if (current != null)
                {
                    this.Text = current["ten"].ToString();
                }
            }
        }

        private void NodeTextSearch1()
        {
            this.ClearBackColor1();
            if (this.timkiem.Text.Trim().Length > 0)
            {
                this.FindByText1();
            }
        }

        private void prn(string tenfile, bool chitiet)
        {
            this.sql = "select a.mabn,a.id,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.makp,d.tenkp,a.madoituong,c.doituong,a.mavp,b.ten,b.dvt,a.soluong,a.dongia+a.vattu as dongia,a.soluong*(a.dongia+a.vattu) as sotien,a.maql,a.idkhoa,b.ma, ";
            this.sql = this.sql + "l.hoten,l.namsinh,case when l.phai=0 then 'Nam' else 'Nữ' end as phai,";
            this.sql = this.sql + "trim(l.sonha)||' '||trim(l.thon)||' '||trim(o.tenpxa)||','||trim(n.tenquan)||','||trim(m.tentt) as diachi,";
            this.sql = this.sql + "nvl(f.sothe,' ') as sothe,to_char(f.denngay,'dd/mm/yyyy') as denngay,nvl(h.tenbv,' ') as noigioithieu,";
            this.sql = this.sql + "nvl(i.tenbv,' ') as noicap,e.giuong as sogiuong,to_char(p.ngay,'dd/mm/yyyy') as ngayvao,";
            this.sql = this.sql + "e.maicd,nvl(a.chandoan,e.chandoan) as chandoan,";
            this.sql = this.sql + "k.stt as sttnhom,k.ten as nhom,j.stt as sttloai,j.ten as loai,";
            this.sql = this.sql + "a.mabs,q.hoten as tenbs,a.ghichu,b.stt,w0.hoten as tenuser,a.computer";
            string sql = this.sql;
            this.sql = sql + " from " + this.user + this.m.mmyy(this.ngay) + ".v_chidinh a inner join " + this.user + ".v_giavp b on a.mavp=b.id ";
            this.sql = this.sql + " inner join " + this.user + ".doituong c on a.madoituong=c.madoituong ";
            this.sql = this.sql + " inner join " + this.user + ".btdkp_bv d on a.makp=d.makp ";
            this.sql = this.sql + " inner join " + this.user + ".nhapkhoa e on a.idkhoa=e.id ";
            this.sql = this.sql + " left join " + this.user + ".bhyt f on a.maql=f.maql ";
            this.sql = this.sql + " left join " + this.user + ".noigioithieu g on a.maql=g.maql ";
            this.sql = this.sql + " left join " + this.user + ".tenvien h on g.mabv=h.mabv ";
            this.sql = this.sql + " left join " + this.user + ".dmnoicapbhyt i on f.mabv=i.mabv ";
            this.sql = this.sql + " inner join " + this.user + ".v_loaivp j on b.id_loai=j.id ";
            this.sql = this.sql + " inner join " + this.user + ".v_nhomvp k on j.id_nhom=k.ma ";
            this.sql = this.sql + " inner join " + this.user + ".btdbn l on a.mabn=l.mabn ";
            this.sql = this.sql + " inner join " + this.user + ".btdtt m on l.matt=m.matt ";
            this.sql = this.sql + " inner join " + this.user + ".btdquan n on l.maqu=n.maqu ";
            this.sql = this.sql + " inner join " + this.user + ".btdpxa o on l.maphuongxa=o.maphuongxa ";
            this.sql = this.sql + " inner join " + this.user + ".benhandt p on a.maql=p.maql ";
            this.sql = this.sql + " left join " + this.user + ".dmbs q on a.mabs=q.ma ";
            this.sql = this.sql + " left join " + this.user + ".dlogin w0 on a.userid=w0.id ";
            sql = this.sql;
            this.sql = sql + " where a.mabn='" + this.s_mabn + "' and a.hide=0 and to_char(a.ngay,'dd/mm/yyyy')='" + this.ngay.Substring(0, 10) + "'";
            this.sql = this.sql + " and a.idchidinh=" + this.l_idchidinh;
            this.sql = this.sql + " and (f.sudung is null or f.sudung=1)";
            if (this.bChidinh_loaivp)
            {
                this.sql = this.sql + " order by j.ten";
            }
            else
            {
                this.sql = this.sql + " order by k.ten";
            }
            this.sql = this.sql + ",b.ten";
            DataSet dset = this.v.get_data(this.sql);
            if (dset.Tables[0].Rows.Count > 0)
            {
                DataRow current;
                IEnumerator enumerator;
                if (((this.chiphi == 0M) && (this.tamung == 0M)) && (this.Tamung_min != 0M))
                {
                    this.thongbao(true);
                }
                dset.Tables[0].Columns.Add("chiphi", typeof(decimal));
                dset.Tables[0].Columns.Add("tamung", typeof(decimal));
                dset.Tables[0].Columns.Add("tamung_min", typeof(decimal));
                enumerator = dset.Tables[0].Rows.GetEnumerator();
                {
                    while (enumerator.MoveNext())
                    {
                        current = (DataRow)enumerator.Current;
                        current["chiphi"] = this.chiphi;
                        current["tamung"] = this.tamung;
                        current["tamung_min"] = this.Tamung_min;
                    }
                }
                if (this.bChuky)
                {
                    DataColumn column = new DataColumn("Image", typeof(byte[]));
                    dset.Tables[0].Columns.Add(column);
                    enumerator = dset.Tables[0].Rows.GetEnumerator();
                    {
                        while (enumerator.MoveNext())
                        {
                            current = (DataRow)enumerator.Current;
                            if (System.IO.File.Exists("..//..//..//chuky//" + current["mabs"].ToString() + ".bmp"))
                            {
                                this.fstr = new FileStream("..//..//..//chuky//" + current["mabs"].ToString() + ".bmp", FileMode.Open, FileAccess.Read);
                                this.image = new byte[this.fstr.Length];
                                this.fstr.Read(this.image, 0, Convert.ToInt32(this.fstr.Length));
                                this.fstr.Close();
                                current["Image"] = this.image;
                            }
                        }
                    }
                }
                if (chitiet)
                {
                    DataSet set2 = new DataSet();
                    set2 = dset.Copy();
                    dset.Clear();
                    decimal num = 0M;
                    decimal num2 = 0M;
                    foreach (DataRow row2 in set2.Tables[0].Rows)
                    {
                        num = decimal.Parse(row2["soluong"].ToString());
                        num2 = num;
                        for (int i = 0; i < Convert.ToInt16(num2); i++)
                        {
                            current = dset.Tables[0].NewRow();
                            for (int j = 0; j < set2.Tables[0].Columns.Count; j++)
                            {
                                current[j] = row2[j].ToString();
                            }
                            current["soluong"] = Math.Min(num, 1M);
                            current["sotien"] = decimal.Parse(current["soluong"].ToString()) * decimal.Parse(current["dongia"].ToString());
                            current["ngay"] = this.m.DateToString("dd/MM/yyyy", this.m.StringToDate(row2["ngay"].ToString().Substring(0, 10)).AddDays((double)i));
                            dset.Tables[0].Rows.Add(current);
                            num--;

                        }
                    }
                }
                if (this.chkXML.Checked)
                {
                    if (!System.IO.Directory.Exists("..//xml"))
                    {
                        System.IO.Directory.CreateDirectory("..//xml");
                    }
                    dset.WriteXml("..//xml//chidinh.xml", XmlWriteMode.WriteSchema);
                }
                new dllReportM.frmReport(this.m, dset, "", tenfile, true).ShowDialog();
            }
            else
            {
                MessageBox.Show(this.lan.Change_language_MessageText("Không có số liệu !"), "Medisoft");
            }
        }

        private void RefreshRow(int row)
        {
            Rectangle cellBounds = this.dataGrid1.GetCellBounds(row, 0);
            cellBounds = new Rectangle(cellBounds.Right, cellBounds.Top, this.dataGrid1.Width, cellBounds.Height);
            this.dataGrid1.Invalidate(cellBounds);
        }

        private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
        {
            try
            {
                bool flag = (e.Column != 0) ? ((bool)this.dataGrid1[e.Row, 0]) : ((bool)e.CurrentCellValue);
                if ((e.Column > 0) && ((bool)this.dataGrid1[e.Row, 0]))
                {
                    e.ForeBrush = this.disabledTextBrush;
                }
                else if ((e.Column > 0) && (e.Row == this.dataGrid1.CurrentRowIndex))
                {
                    e.BackBrush = this.currentRowBackBrush;
                    e.TextFont = this.currentRowFont;
                }
            }
            catch
            {
            }
        }

        private void thongbao(bool skip)
        {
            if (this.Tamung_min != 0M)
            {
                string str = "0";// this.m.get_chiphi_mabn(this.s_mabn, this.l_maql, this.loaiba, false, false);
                this.chiphi = decimal.Parse(str.Substring(0, str.IndexOf("~")));
                this.tamung = decimal.Parse(str.Substring(str.IndexOf("~") + 1));
                decimal num = this.chiphi - this.tamung;
                if (!((num <= this.Tamung_min) || skip))
                {
                    MessageBox.Show(((("Tổng chi phí :" + this.chiphi.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n") + "Tạm ứng      :" + this.tamung.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n") + "Còn thiếu    :" + num.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n\n") + "Yêu cầu người bệnh đóng tạm ứng !", "Medisoft");
                }
            }
        }

        private void tim_Enter(object sender, EventArgs e)
        {
            this.tim.Text = "";
        }

        private void tim_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Return) || (e.KeyCode == Keys.Tab))
            {
                this.dataGrid1.Focus();
            }
        }

        private void tim_TextChanged(object sender, EventArgs e)
        {
            if (base.ActiveControl == this.tim)
            {
                CurrencyManager manager = (CurrencyManager)this.BindingContext[this.dataGrid1.DataSource];
                DataView list = (DataView)manager.List;
                if (this.tim.Text != "")
                {
                    list.RowFilter = "ten like '%" + this.tim.Text.Trim() + "%' or ma like '%" + this.tim.Text.Trim() + "%'";
                }
                else
                {
                    list.RowFilter = "";
                }
            }
        }

        private void timkiem_Enter(object sender, EventArgs e)
        {
            this.timkiem.Text = "";
        }

        private void timkiem_TextChanged(object sender, EventArgs e)
        {
            this.NodeTextSearch1();
        }
        string str = "";
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                str = this.treeView1.SelectedNode.Tag.ToString();
                if ((str.Substring(0, 2) != "1_") && (str.Substring(0, 2) != "2_"))
                {
                    this.mamau = str;
                    this.Text = this.treeView1.SelectedNode.Text;
                    this.load_chitiet();
                    CurrencyManager manager = (CurrencyManager)this.BindingContext[this.dataGrid2.DataSource, this.dataGrid2.DataMember];
                    DataView list = (DataView)manager.List;
                    list.AllowNew = false;
                    bNew = true;
                }
            }
            catch(Exception exx)
            {
                str = "0";
            }
        }

        private void upd_chidinh(int mavp)
        {
            if (!this.bLocdichvu && (this.madoituong == 1))
            {
                this.sql = "id=" + mavp + " and bhyt<>0";
                if (this.sothe.Trim().Length > (this.v1 + this.v2))
                {
                    this.sql = this.sql + " and (locthe='' or locthe is null or locthe like '%" + this.sothe.Trim().Substring(this.v1, this.v2) + "%')";
                }
                if (this.m.getrowbyid(this.dt, this.sql) == null)
                {
                    this.madoituong = this.i_tunguyen;
                }
            }
            DataRow[] rowArray = this.dt.Select("trongoi=1 and id=" + mavp);
            int madoituong = this.madoituong;
            if (rowArray.Length > 0)
            {
                this.sql = "select a.* from " + this.user + ".v_trongoi a," + this.user + ".v_giavp b ";
                this.sql = this.sql + " where a.id_gia=b.id and a.id=" + mavp;
                if ((this.madoituong == 1) && this.bLocdichvu)
                {
                    this.sql = this.sql + " and b.bhyt>0";
                }
                this.sql = this.sql + " order by a.stt";
                foreach (DataRow row in this.v.get_data(this.sql).Tables[0].Rows)
                {
                    this.idchidinh = 0L;
                    if (this.bChidinh_thutienlien)
                    {
                        this.upd_data(int.Parse(row["id_gia"].ToString()), decimal.Parse(row["soluong"].ToString()) * txtSoluong.Value, (int.Parse(row["madoituong"].ToString()) == 0) ? madoituong : int.Parse(row["madoituong"].ToString()), decimal.Parse(row["sotien"].ToString()), int.Parse(row["id"].ToString()));
                    }
                    else
                    {
                        this.upd_data(int.Parse(row["id_gia"].ToString()), decimal.Parse(row["soluong"].ToString()) * txtSoluong.Value, madoituong);
                    }
                }
                if (this.idchidinh == 0L)
                {
                    if (this.bChidinh_thutienlien)
                    {
                        this.upd_data(mavp, txtSoluong.Value, madoituong, 0M, 0);
                    }
                    else
                    {
                        this.upd_data(mavp, txtSoluong.Value, madoituong);
                    }
                }
            }
            else if (this.bChidinh_thutienlien)
            {
                if (madoituong == 1)
                {
                    DataRow row2 = this.m.getrowbyid(this.dt, "id=" + mavp);
                    if ((row2 != null) && (decimal.Parse(row2["bhyt"].ToString()) == 0M))
                    {
                        if (row2["tachhd"].ToString() == "1")
                        {
                            madoituong = 2;
                        }
                        else
                        {
                            if (row2["thuong"].ToString() == "1")
                            {
                                madoituong = 2;
                            }
                            else
                            {
                                madoituong = this.i_tunguyen;
                            }
                        }
                    }
                }
                this.upd_data(mavp, txtSoluong.Value, madoituong, 0M, 0);
            }
            else
            {
                this.upd_data(mavp, txtSoluong.Value, madoituong);
            }
            this.thongbao(false);
            if (this.chkInphieu.Checked)
            {
                this.prn("rptChidinh.rpt", false);
            }
        }

        private void upd_data(int i_mavp, decimal d_soluong, int madoituong)
        {
            decimal num = 0M;
            decimal num2 = 0M;
            DataRow row = this.m.getrowbyid(this.dt, "id=" + i_mavp);
            if (row != null)
            {
                int num3 = this.m.tableid(this.m.mmyy(this.ngay), "v_chidinh");
                if (this.l_id == 0L)
                {
                    this.idchidinh = this.v.get_id_chidinh;
                    this.m.upd_eve_tables(this.ngay, num3, this.i_userid, "ins");
                }
                else
                {
                    this.m.upd_eve_tables(this.ngay, num3, this.i_userid, "upd");
                    this.m.upd_eve_upd_del(this.ngay, num3, this.i_userid, "upd", this.m.fields(this.user + this.m.mmyy(this.ngay) + ".v_chidinh", "id=" + this.idchidinh));
                }
                string str = this.m.field_gia(madoituong.ToString());
                string str2 = "vattu_" + str.Substring(4).Trim();
                decimal num4 = (str.IndexOf("_nn") != -1) ? this.m.dTygia : 1L;
                num = decimal.Parse(row[str].ToString()) * num4;
                num2 = decimal.Parse(row[str2].ToString()) * num4;
                //if (!this.v.upd_chidinh(false, this.idchidinh, this.s_mabn, this.l_mavaovien, this.l_maql, this.l_idkhoa, this.get_ngaygio(this.ngay), this.v.iNoitru, this.matrai, madoituong, i_mavp, d_soluong, num, num2, this.i_userid, 0, 0, this.l_idchidinh, this.maicd, this.chandoan, this.mabs, this.loaiba, "", ""))
                //{
                //    MessageBox.Show(this.lan.Change_language_MessageText("Không cập nhật được thông tin chỉ định !"), "Medisoft");
                //}
                //else if (this.bChidinh_exp_txt)
                //{
                //    this.m.exp_chidinh(this.m.mmyy(this.ngay), this.idchidinh.ToString(), "0");
                //}
            }
        }

        //private void upd_data(int i_mavp, decimal d_soluong, int i_madt, decimal dongia, int idtrongoi)
        //{
        //    bool bTinhchenhlech = false;
        //    string str = "gia_bh";
        //    DataRow row = this.m.getrowbyid(this.dtdtvp, "madoituong=" + (((i_madt == this.i_tunguyen) || (i_madt == this.madoituong)) ? this.madoituong : i_madt));
        //    if (row != null)
        //    {
        //        str = row["field_gia"].ToString();
        //    }
        //    row = this.m.getrowbyid(this.dt, "id=" + i_mavp);
        //    if (row != null)
        //    {
        //        bTinhchenhlech = ((this.s_chenhlech.IndexOf(this.madoituong.ToString().Trim() + ",") != -1) && (row["chenhlech"].ToString().Trim() == "1")) && (decimal.Parse(row[this.m.field_gia(this.i_tunguyen.ToString())].ToString()) > decimal.Parse(row[str].ToString()));
        //        if (this.bChenhlech_doituong)
        //        {
        //            bTinhchenhlech = bTinhchenhlech && (i_madt == this.i_tunguyen);
        //        }
        //        if (this.madoituong == 1)
        //        {
        //            bTinhchenhlech = bTinhchenhlech && (decimal.Parse(row["bhyt"].ToString()) > 0M);
        //        }
        //        if (bTinhchenhlech || ((row["chenhlech"].ToString() == "1") && (this.sys_nhom_bienlai_dichvu.IndexOf(row["id_nhom"].ToString().PadLeft(3, '0')) != -1)))
        //        {
        //                string field_gia = m.field_gia(madoituong.ToString());
        //                string field_dv = m.field_gia(i_tunguyen.ToString());
        //                if (decimal.Parse(row[field_dv].ToString()) - decimal.Parse(row[field_gia].ToString()) == 0)
        //                {
        //                    this.idchidinh = 0L;
        //                    int _madt = madoituong;
        //                    if (row["thuong"].ToString() == "1")
        //                    {
        //                        _madt = madoituong;
        //                    }
        //                    else
        //                    {
        //                        _madt = i_tunguyen;
        //                    }
        //                    this.upd_detail(false, i_mavp, d_soluong, dongia, idtrongoi, _madt);
        //                }
        //                else
        //                {
        //                    this.upd_detail(false, i_mavp, d_soluong, dongia, idtrongoi, this.madoituong);
        //                    this.idchidinh = 0L;
        //                    this.upd_detail(true, i_mavp, d_soluong, dongia, idtrongoi, this.i_tunguyen);
        //                }
        //        }
        //        else
        //        {
        //            if ((this.bBienlaichiuthue && (this.Bienlaichiuthue_gia != "")) && (i_madt != this.i_tunguyen))
        //            {
        //                if (dongia == 0M)
        //                {
        //                    dongia = decimal.Parse(row[str].ToString());
        //                }
        //                if ((dongia - decimal.Parse(row[this.Bienlaichiuthue_gia].ToString())) > 0M)
        //                {
        //                    i_madt = this.i_tunguyen;
        //                }
        //            }
        //            this.upd_detail(false, i_mavp, d_soluong, dongia, idtrongoi, i_madt);
        //        }
        //    }
        //}

        private void upd_detail(bool chenhlech, int i_mavp, decimal d_soluong, decimal dongia, int idtrongoi, int madt)
        {
            string s_giohienhanh = m.ngayhienhanh_server.Substring(10,6);
            decimal num2 = 0M;
            decimal num3 = 0M;
            decimal lan = 1M;
            DataRow row = this.m.getrowbyid(this.dt, "id=" + i_mavp);
            if (row != null)
            {
                string sfield_gia;
                string sfield_vtth;
                decimal dtygia;
                decimal ddongia;
                decimal dvtth;
                if (chenhlech)
                {
                    sfield_gia = this.m.field_gia(madt.ToString());
                    sfield_vtth = "vattu_" + sfield_gia.Substring(4).Trim();
                    dtygia = (sfield_gia.IndexOf("_nn") != -1) ? this.m.dTygia : 1L;
                    ddongia = (decimal.Parse(row[sfield_gia].ToString()) * dtygia) - decimal.Parse(row["gia_bh"].ToString());
                    dvtth = (decimal.Parse(row[sfield_vtth].ToString()) * dtygia) - decimal.Parse(row["vattu_bh"].ToString());
                    if ((this.cl_tyle != 0M) && (this.cl_cholam != ""))
                    {
                        string str3 = this.m.get_cholam(this.s_mabn).ToString().Trim().ToLower();
                        if ((this.cl_cholam.IndexOf(str3) != -1) && (str3 != ""))
                        {
                            num2 = ddongia * (this.cl_tyle / 100M);
                            num3 = dvtth * (this.cl_tyle / 100M);
                            ddongia -= num2;
                            dvtth -= num3;
                        }
                    }
                }
                else
                {
                    sfield_gia = this.m.field_gia(madt.ToString());
                    sfield_vtth = "vattu_" + sfield_gia.Substring(4).Trim();
                    dtygia = (sfield_gia.IndexOf("_nn") != -1) ? this.m.dTygia : 1L;
                    ddongia = decimal.Parse(row[sfield_gia].ToString()) * dtygia;
                    dvtth = decimal.Parse(row[sfield_vtth].ToString()) * dtygia;
                }
                decimal dthanhtien = d_soluong * (((dongia != 0M) ? dongia : ddongia) + ((dongia != 0M) ? 0M : dvtth));
                bool flag = ((madt.ToString() != "1") && (dthanhtien >= this.Sotien_chidinh_tamung)) && (this.sMakp_chidinh_tamung.IndexOf(this.matrai) != -1);
                decimal num8 = 0L;
                int num9 = this.m.tableid(this.m.mmyy(this.ngay), "v_chidinh");
                if (this.idchidinh == 0L)
                {
                    if (flag)
                    {
                        num8 = this.v.get_id_tamung;
                        this.sql = "select max(nvl(lan,0))+1 as lan from xxx.v_tamungcd where mabn='" + this.s_mabn + "'";
                        object sql = this.sql;
                        this.sql = string.Concat(new object[] { sql, " and mavaovien=", this.l_mavaovien, " and maql=", this.l_maql });
                        this.sql = this.sql + " and idkhoa=" + this.l_idkhoa;
                        //lan = this.m.get_lan_tamung(this.ngayvv, this.ngay, this.sql);
                    }
                    this.idchidinh = this.v.get_id_chidinh;
                    this.m.upd_eve_tables(this.ngay, num9, this.i_userid, "ins");
                }
                else
                {
                    this.m.upd_eve_tables(this.ngay, num9, this.i_userid, "upd");
                    this.m.upd_eve_upd_del(this.ngay, num9, this.i_userid, "upd", this.m.fields(this.user + this.m.mmyy(this.ngay) + ".v_chidinh", "id=" + this.idchidinh));
                    if (flag)
                    {
                        foreach (DataRow row2 in this.m.get_data(string.Concat(new object[] { "select lan from ", this.user, this.m.mmyy(this.ngay), ".v_tamungcd where idchidinh=", this.idchidinh })).Tables[0].Rows)
                        {
                            lan = decimal.Parse(row2["lan"].ToString());
                            num8 = decimal.Parse(row2["id"].ToString());
                        }
                    }
                }
                if (!this.v.upd_chidinh(this.idchidinh, this.s_mabn, this.l_mavaovien, this.l_maql, this.l_idkhoa, this.get_ngaygio(this.ngay+s_giohienhanh), this.v.iNoitru, this.matrai, madt, i_mavp, d_soluong, (dongia != 0M) ? dongia : ddongia, (dongia != 0M) ? 0M : dvtth, this.i_userid, 1, 1, (this.l_idchidinh == 0L) ? this.idchidinh : this.l_idchidinh, this.maicd, this.chandoan, this.mabs, this.loaiba, ""))
                {
                    MessageBox.Show(this.lan.Change_language_MessageText("Không cập nhật được thông tin chỉ định !"), "Medisoft");
                }
                else
                {
                    //linh
                    //try
                    //{
                    //    if (m_ds_danhsach.Tables[0].Select("id=" + idchidinh).Length <= 0)
                    //    {
                    //        DataRow rxx = m_ds_danhsach.Tables[0].NewRow();
                    //        rxx["id"] = idchidinh;
                    //        rxx["idduoc"] = l_id;
                    //        rxx["ten"] = m.get_data("select ten from " + user + ".v_giavp where id=" + i_mavp).Tables[0].Rows[0][0].ToString();
                    //        m_ds_danhsach.Tables[0].Rows.Add(rxx.ItemArray);
                    //    }
                    //}
                    //catch
                    //{
                    //}
                    //end
                    this.m.execute_data(string.Concat(new object[] { "update ", this.user, this.m.mmyy(this.ngay), ".v_chidinh set idduoc=" + l_id + " where id=", this.idchidinh }));
                    if (chenhlech)
                    {
                        this.m.execute_data(string.Concat(new object[] { "update ", this.user, this.m.mmyy(this.ngay), ".v_chidinh set done=1,hide=1 where done=0 and id=", this.idchidinh }));
                    }

                    f_bnmien(i_mavp);
                    if (ds_bnmien.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow ddr in ds_bnmien.Tables[0].Rows)
                        {
                            foreach (DataRow ddr1 in m.get_data(" select mavp,done,idchidinh,dongia from " + user + mmyy+ ".v_chidinh where mavaovien=" + l_mavaovien + " and mabn='" + s_mabn + "' and idchidinh=" + l_idchidinh + " ").Tables[0].Rows)
                            {
                                m.execute_data(" update " + user + mmyy + ".v_chidinh set tylegiam=" + int.Parse(ddr["tylemien"].ToString()) + ",stgiam=" + ddr["tylemien"].ToString() + "*" + ddr1["dongia"].ToString() + "/100 where maql=" + l_maql + " and idchidinh=" + l_idchidinh + " and mavp=" + ddr1["mavp"].ToString());
                            }
                        }
                    }
                    
                    //if (idtrongoi != 0)
                    //{
                    //    this.m.execute_data(string.Concat(new object[] { "update ", this.user, this.m.mmyy(this.ngay), ".v_chidinh set idtrongoi=", idtrongoi, " where id=", this.idchidinh }));
                    //}
                    if (this.bChidinh_exp_txt)
                    {
                        this.m.exp_chidinh(this.m.mmyy(this.ngay), this.idchidinh.ToString(), "0");
                    }
                    if (flag)
                    {
                        this.v.upd_tamungcd(num8, this.s_mabn, this.l_mavaovien, this.l_maql, this.l_idkhoa, this.ngay, this.v.iNoitru, this.loaiba, this.matrai, madt, row["ten"].ToString(), dthanhtien, this.i_userid);
                        this.v.execute_data(string.Concat(new object[] { "update ", this.user, this.v.mmyy(this.ngay), ".v_tamungcd set idchidinh=", this.idchidinh, " where id=", num8 }));
                    }
                    if (num2 != 0M)
                    {
                        this.idchidinh = this.v.get_id_chidinh;
                        this.v.upd_chidinh(this.idchidinh, this.s_mabn, this.l_mavaovien, this.l_maql, this.l_idkhoa, this.get_ngaygio(this.ngay + s_giohienhanh), this.v.iNoitru, this.matrai, this.cl_doituong, i_mavp, d_soluong, num2, num3, this.i_userid, 0, 0, this.l_idchidinh, this.maicd, this.chandoan, this.mabs, this.loaiba, "");
                        this.m.execute_data(string.Concat(new object[] { "update ", this.user, this.m.mmyy(this.ngay), ".v_chidinh set hide=1 where done=0 and id=", this.idchidinh }));//linh set done=0 where done=0???
                        this.m.execute_data(string.Concat(new object[] { "update ", this.user, this.m.mmyy(this.ngay), ".v_chidinh set idduoc=" + l_id + " where id=", this.idchidinh }));
                    }
                    if (bNew)
                    {
                        decimal id_cha = l_idchidinh;
                        sql = "select a.id_gia,a.soluong,b.id,b.ten,b.ma,b.dvt,a.madoituong,b.loaitrongoi from " + user + ".v_trongoi a," + user + ".v_giavp b where a.id_gia=b.id and a.id=" + i_mavp + " and a.id_loai<>'-999'";
                        DataRow r11;
                        DataTable dttam = new DataTable();
                        dttam = m.get_data(sql).Tables[0];
                        foreach (DataRow dr1 in dttam.Rows)
                        {
                            idchidinh = v.get_id_chidinh;
                            if (!v.upd_chidinh(idchidinh, s_mabn, l_mavaovien, l_maql, l_idkhoa, ngay+s_giohienhanh, this.v.iNoitru, matrai, int.Parse(dr1["madoituong"].ToString()), int.Parse(dr1["id_gia"].ToString()), (int)decimal.Parse(dr1["soluong"].ToString()), 0, 0, i_userid, 1, 1, 0, (maicd == "" && chandoan != "") ? "U00" : maicd, chandoan, mabs, loaiba, ""))
                            {
                                //MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chỉ định !"), LibMedi.AccessData.Msg);
                                return;
                            }
                            sql = "update " + user + mmyy + ".v_chidinh set ";
                            if (dr1["loaitrongoi"].ToString().Trim() == "1") sql += "paid=1,";
                            sql += "id_goi=" + id_cha + " where id=" + idchidinh;
                            m.execute_data(sql);
                            r11 = m.getrowbyid(dttam, "id=" + int.Parse(dr1["id_gia"].ToString()));
                        }
                    }
                }
            }
        }

        private void f_bnmien(int idvp)
        {
            foreach (DataRow r in m.get_data(" select id_loai from " + user + ".v_giavp where id=" + idvp).Tables[0].Rows)
            {
                sql = "select mabn,mavaovien,tyle as tylemien from " + user + ".tylemien_km a inner join medibv.v_nhommien b on a.id_nhommien=b.id where a.mabn='" + s_mabn + "' and a.mavaovien=" + l_mavaovien + " and b.loaivp like '%+" + r["id_loai"].ToString() + "+%' and b.sudung=1";
                sql += " union ";
                sql += " select mabn,mavaovien,tyle as tylemien from " + user + ".tylemien_mg a inner join medibv.v_nhommien b on a.id_nhommien=b.id where a.mabn='" + s_mabn + "' and a.mavaovien=" + l_mavaovien + " and b.loaivp like '%+" + r["id_loai"].ToString() + "+%' and b.sudung=1";
                sql += " union ";
                sql += " select mabn,mavaovien,tyle as tylemien  from " + user + ".tylemien_ud a inner join medibv.v_nhommien b on a.id_nhommien=b.id where a.mabn='" + s_mabn + "' and a.mavaovien=" + l_mavaovien + " and b.loaivp like '%+" + r["id_loai"].ToString() + "+%' and b.sudung=1";
                sql += " order by mabn";
                ds_bnmien = m.get_data(sql);
            }
        }

        private void butHuy_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string amabd = dataGrid2[dataGrid2.CurrentCell.RowNumber, 0].ToString();
            //    foreach (DataRow r in ds.Tables[0].Select("soluong>0 and mabd=" + amabd))
            //    {
            //        r["soluong"] = 0;
            //    }
            //}
            //catch
            //{
            //}
            try
            {
                if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy '" + treeLan.SelectedNode.Text + "' ?"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool dChenhlech = false;
                    DataTable dtct = new DataTable();

                    string xxx = m.user + mmyy;
                    dtct = m.get_data("select a.*,b.sttt from " + xxx + ".d_xtutrucct a," + xxx + ".d_thucxuat b where a.stt=b.stt and a.id=b.id and a.id=" + idduoc).Tables[0];
                    //xoa thuoc

                    int itable = m.tableid(mmyy, "d_thucxuat");
                    //foreach (DataRow r1 in d.get_data( "select a.*,b.manguon,b.giaban,b.giamua,a.soluong*b.giamua as sotien,b.gianovat from " + xxx + ".d_thucxuat a,"+xxx+".d_theodoi b where a.sttt=b.id and a.id=" + idduoc).Tables[0].Rows)
                    //{
                    //    d.upd_tonkhoct_thucxuat(d.delete,s_mmyy,i_makp,i_loai,1,decimal.Parse(r1["sttt"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()));
                    //    d.upd_theodoicongno(d.delete,s_mabn,l_mavaovien,l_maql,l_idkhoa,int.Parse(r1["madoituong"].ToString()),decimal.Parse(r1["sotien"].ToString()),"thuoc");
                    //    d.upd_tienthuoc(d.delete, s_mmyy, decimal.Parse(idduoc.ToString()), s_mabn, l_mavaovien, l_maql, l_idkhoa, s_ngay, i_makhoa, i_loai, int.Parse(r1["madoituong"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["gianovat"].ToString()),0);
                    //    m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    //    m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".d_thucxuat", "id=" + idduoc + " and stt=" + int.Parse(r1["stt"].ToString())));
                    //}

                    itable = m.tableid(mmyy, "d_xtutrucct");
                    //foreach (DataRow r1 in dtct.Rows)
                    //{
                    //    m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    //    m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".d_xtutrucct", "id=" + idduoc + " and stt=" + int.Parse(r1["stt"].ToString())));
                    //    d.execute_data("update " + xxx + ".d_tutrucct set slxuat=slxuat-(" + r1["slyeucau"].ToString() + ") where makp=" + drduoc["makp"].ToString() + " and makho=" + r1["makho"].ToString() + " and stt=" + r1["sttt"].ToString());
                    //    d.upd_tutructh(d.delete, s_mmyy, int.Parse(drduoc["makp"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["mabd"].ToString()), int.Parse(r1["manguon"].ToString()), decimal.Parse(r1["slyeucau"].ToString()), "slxuat");
                    //}
                    itable = m.tableid(mmyy, "d_xtutrucll");
                    m.upd_eve_tables(ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(ngay, itable, i_userid, "del", m.fields(xxx + ".d_xtutrucll", "id=" + idduoc));
                    itable = m.tableid(mmyy, "d_xuatsdll");
                    m.upd_eve_tables(ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(ngay, itable, i_userid, "del", m.fields(xxx + ".d_xuatsdll", "id=" + idduoc));
                    //d.execute_data("delete from " + xxx + ".d_xuatsdct where id=" + idduoc);
                    //d.execute_data("delete from " + xxx + ".d_thucxuat where id=" + idduoc);
                    //d.execute_data("delete from " + xxx + ".d_xuatsdll where id=" + idduoc);
                    //d.execute_data("delete from " + xxx + ".d_xtutrucct where id=" + idduoc);
                    //d.execute_data("delete from " + xxx + ".d_xtutrucll where id=" + idduoc);
                    foreach (DataRow r1 in d.get_data("select a.*,b.manguon,b.giaban,b.giamua,a.soluong*b.giamua as sotien,b.gianovat,c.gia_bh from " + user + mmyy + ".d_thucxuat a," + user + mmyy + ".d_theodoi b," + user + ".d_dmbd c where a.sttt=b.id and b.mabd=c.id and a.id=" + l_id).Tables[0].Rows)
                    {
                        d.upd_tonkhoct_thucxuat(d.delete, mmyy, makp, loai, 1, decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()));
                        d.upd_theodoicongno(d.delete, s_mabn, l_mavaovien, l_maql, l_idkhoa, int.Parse(r1["madoituong"].ToString()), decimal.Parse(r1["sotien"].ToString()), "thuoc");
                        d.upd_tienthuoc(d.delete, mmyy, l_id, s_mabn, l_mavaovien, l_maql, l_idkhoa, ngay, makp, loai, int.Parse(r1["madoituong"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["gianovat"].ToString()), 0, decimal.Parse(r1["gia_bh"].ToString()),"");
                    }
                    d.execute_data("delete from " + user + mmyy + ".d_xuatsdct where id=" + l_id);
                    d.execute_data("delete from " + user + mmyy + ".d_thucxuat where id=" + l_id);
                    d.execute_data("delete from " + user + mmyy + ".d_xtutrucct where id=" + this.l_id.ToString());
                    d.execute_data("delete from " + user + mmyy + ".d_xtutrucll where id=" + this.l_id.ToString());
                    //d.execute_data("delete from " + xxx + ".d_dausinhton where iddutru=" + l_id);
                    //end xoa thuoc
                    itable = m.tableid(mmyy, "v_chidinh");
                    m.upd_eve_tables(ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(ngay, itable, i_userid, "del", m.fields(user + mmyy + ".v_chidinh", "id=" + l_id));

                    //DataTable tmp1 = m.get_data("select * from " + user + mmyy + ".v_chidinh where id=" + l_idcd).Tables[0];
                    m.execute_data("delete from " + user + mmyy + ".v_chidinh where id=" + l_idcd);
                    m.execute_data("delete from " + user + mmyy + ".v_chidinh where id_goi=" + l_idcd);
                    //if (tmp.Rows.Count > 0)
                    //{
                    //    if (m.get_data("select id from " + user + ".v_giavp where chenhlech=1 and id=" + decimal.Parse(tmp1.Rows[0]["mavp"].ToString())).Tables[0].Rows.Count > 0)
                    //    {
                    //        sql = "delete from " + user + mmyy + ".v_chidinh where maql=" + l_maql + " and mavaovien=" + l_mavaovien;
                    //        sql += " and madoituong=" + i_tunguyen + " and userid=" + decimal.Parse(tmp1.Rows[0]["userid"].ToString());
                    //        sql += " and to_char(ngay,'dd/mm/yyyy')='" + s_ngaycd.Substring(0, 10) + "' and hide=1 and done=1 and mavp=" + decimal.Parse(tmp1.Rows[0]["mavp"].ToString());
                    //        sql += " and idchidinh=" + decimal.Parse(tmp1.Rows[0]["idchidinh"].ToString());
                    //        sql += " and idkhoa=" + decimal.Parse(tmp1.Rows[0]["idkhoa"].ToString());
                    //        sql += " and loai=" + decimal.Parse(tmp1.Rows[0]["loai"].ToString());
                    //        sql += " and makp='" + tmp1.Rows[0]["makp"].ToString() + "'";
                    //        m.execute_data(sql);
                    //        dChenhlech = true;
                    //    }
                    //}
                    load_grid();
                    load_danhsach_chidinh();
                    //ref_text();
                    //getTong();
                }
            }
            catch { }
        }

        private void txtSoluong_ValueChanged(object sender, EventArgs e)
        {
            load_chitiet();
        }

        private void txtSoluong_Validated(object sender, EventArgs e)
        {
            load_chitiet();
        }

        private void butMoi_Click(object sender, EventArgs e)
        {
            bNew = true;
            l_idcd = 0;
            mapt = "";
            l_mavp = 0;
            l_id = d.get_id_xuatsd;
            l_idchidinh = d.get_id_xuatsd;
            idchidinh = 0;
            txtSoluong.Value = m_soluong_default;
            ds.Clear();
            dataGrid2.DataSource = null;
            //load_chitiet();
            butLuu.Enabled = true;
            butHuy.Enabled = true;
            butThem.Enabled = true;
            dataGrid1.Enabled = true;
            dataGrid2.Enabled = true;
            butSua.Enabled = false;
            treeView1.Enabled = true;
            treeLan.Enabled = false;
        }

        private void mnDefault_sl_Click(object sender, EventArgs e)
        {
            try
            {
                m.execute_data("delete from " + user + ".v_optionform where userid=" + i_userid + " and loai=0 and ma='frmGoiDichvu_soluong_default'");
                m.execute_data("insert into " + user + ".v_optionform(userid,loai,ma,ten,giatri) values(" + i_userid + ",0,'frmGoiDichvu_soluong_default','frmGoiDichvu_soluong_default','" + txtSoluong.Value.ToString() + "')");

            }
            catch
            {
            }
        }
        decimal l_idcd = 0;
        private void treeLan_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node = treeLan.SelectedNode;
            if (node.Tag == null) return;
            string strid = node.Tag.ToString();
            string[] id = strid.Split('^');
            string idchidinh = id[0];
            string idduoc = id[1];
            str = id[2];
            butLuu.Enabled = false;
            butSua.Enabled = true;
            butMoi.Enabled = true;
            butThem.Enabled = false;
            dataGrid1.Enabled = false;
            dataGrid2.Enabled = false;
            treeView1.Enabled = false;
            l_id = decimal.Parse(idduoc);
            l_idcd = decimal.Parse(idchidinh);
            load_chitiet(l_id);
            bNew = false;
        }

        private void butSua_Click(object sender, EventArgs e)
        {
            if (ds == null || ds.Tables[0].Rows.Count == 0) return;
            bNew = false;
            butLuu.Enabled = true;
            butThem.Enabled = true;
            butMoi.Enabled = false;
            treeView1.Enabled = false;
            dataGrid1.Enabled = true;
            dataGrid2.Enabled = true;

        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            butMoi.Enabled = true;
            butSua.Enabled = true;
            butLuu.Enabled = false;
            treeLan.Enabled = true;
            treeView1.Enabled = false;
            butThem.Enabled = false;
            dataGrid1.Enabled = false;
            dataGrid2.Enabled = false;
        }

        private void butcauhoitc_Click(object sender, EventArgs e)
        {
            tiemchung.frmtc f = new tiemchung.frmtc("", s_mabn, l_mavaovien,i_userid);
            f.ShowInTaskbar = false;
            f.ShowDialog();
        }
    }
}