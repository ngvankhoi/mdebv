using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Drawing.Printing;
using LibVP;


namespace Vienphi
{
    public partial class frmGiavp_luu : Form
    {
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

        private string m_menu_id = "menu_C_1_1_Giavp";
        private LibVP.AccessData m_v;        
        private LibMedi.AccessData m=new LibMedi.AccessData();
        private string m_userid = "",m_id_loai="",m_id="",sql,user;
        private int itable;
        private bool bKhoan;
        private DataSet dsgia = new DataSet();
        public frmGiavp_luu(LibVP.AccessData v_v, string v_userid)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

            m_v = v_v; 
            m_userid = v_userid;
            m_v.f_SetEvent(this);
        }

        private void frmQuanlynguoidung_Load(object sender, EventArgs e)
        {
            bKhoan=m.bKhoan_vtth;user=m.user;
            itable = m_v.tableid("", "v_giavp_luu");
            f_Load_DG();
            f_Load_Tree();            
            f_Enable(true);
            this.WindowState = FormWindowState.Maximized;
            this.Refresh();
        }
        private void f_Load_DG()
        {
            try
            {
               // Application.DoEvents();
                sql = "select a.id,a.stt,a.ma,a.ten,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,gia_ksk,a.vattu_th,";
                sql += " a.vattu_bh,a.vattu_dv,a.vattu_nn,a.vattu_cs,vattu_ksk,case when a.bhyt is null then 0 else a.bhyt end as bhyt,";               
                sql+=" a.locthe,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud, ";
                sql+=" hide,a.readonly,a.kythuat, a.kythuat as kythuatcu, ";
                sql += " a.bhyt as bhytcu, a.gia_th as gia_thucu, a.gia_bh as gia_bhcu, a.gia_dv as gia_dvcu ";
                sql+=" from medibv.v_giavp_luu a left join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_loaibn c on a.loaibn=c.id ";
                sql+=" left join medibv.v_nhomvp d on b.id_nhom=d.ma left join medibv.v_nhombhyt e on d.idnhombhyt=e.id ";
                sql+=" order by a.stt,a.ten, a.ngayud desc";
                dsgia = m_v.get_data(sql);          
                AddGridTableStyle(dsgia);
                txtTim_TextChanged(null, null);
            }
            catch
            {
               
            }
        }
        private void AddGridTableStyle(DataSet v_ds)
        {
            try
            {
                if (DataGrid1.TableStyles.Count <= 0)
                {
                    DataGrid1.TableStyles.Clear();
                    DataGrid1.AllowSorting = true;
              
                    DataGridColoredTextBoxColumn TextCol;                    
                    delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
                    DataGridTableStyle ts = new DataGridTableStyle();
                    ts.MappingName = v_ds.Tables[0].TableName;
                    ts.AlternatingBackColor = Color.LightYellow;
                    ts.BackColor = Color.White;
                    ts.ForeColor = Color.MidnightBlue;
                    ts.GridLineColor = Color.RoyalBlue;
                    ts.HeaderBackColor = SystemColors.Control;
                    ts.HeaderForeColor = Color.Black;
                    ts.SelectionBackColor = Color.Teal;
                    ts.SelectionForeColor = Color.PaleGreen;

                    ts.ReadOnly = false;
                    ts.RowHeaderWidth = 16;
                    ts.AllowSorting = true;
                    ts.PreferredRowHeight = 20;

                    //0
                    TextCol = new DataGridColoredTextBoxColumn(de, 0);
                    TextCol.MappingName = "id";
                    TextCol.HeaderText = "ID";
                    TextCol.Width = 43;
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //1
                    TextCol = new DataGridColoredTextBoxColumn(de, 1);
                    TextCol.MappingName = "stt";
                    TextCol.HeaderText = "Stt";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Left;
                    TextCol.Width = 40;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //2
                    TextCol = new DataGridColoredTextBoxColumn(de, 2);
                    TextCol.MappingName = "ma";
                    TextCol.HeaderText = "Mã số";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Left;
                    TextCol.Width = 60;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //3
                    TextCol = new DataGridColoredTextBoxColumn(de, 3);
                    TextCol.MappingName = "ten";
                    TextCol.HeaderText = "Nội dung";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Left;
                    TextCol.Width = 180;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //4
                    TextCol = new DataGridColoredTextBoxColumn(de, 4);
                    TextCol.MappingName = "dvt";
                    TextCol.HeaderText = "ĐVT";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Left;
                    TextCol.Width = 49;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //5
                    TextCol = new DataGridColoredTextBoxColumn(de, 5);
                    TextCol.MappingName = "gia_th";
                    TextCol.HeaderText = "Đơn giá";
                    TextCol.ReadOnly = false;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 84;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //6
                    TextCol = new DataGridColoredTextBoxColumn(de, 6);
                    TextCol.MappingName = "gia_bh";
                    TextCol.HeaderText = "Giá BHYT";
                    TextCol.ReadOnly = false;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 70;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //7
                    TextCol = new DataGridColoredTextBoxColumn(de, 7);
                    TextCol.MappingName = "gia_dv";
                    TextCol.HeaderText = "Giá DV";
                    TextCol.ReadOnly = false;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 70;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //8
                    TextCol = new DataGridColoredTextBoxColumn(de, 8);
                    TextCol.MappingName = "gia_nn";
                    TextCol.HeaderText = "Giá NN";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 70;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //9
                    TextCol = new DataGridColoredTextBoxColumn(de, 9);
                    TextCol.MappingName = "gia_cs";
                    TextCol.HeaderText = "";// "Giá CS";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 0;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //10
                    TextCol = new DataGridColoredTextBoxColumn(de, 10);
                    TextCol.MappingName = "gia_ksk";
                    TextCol.HeaderText = "";// "Giá KSK";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 0;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //11                 
                    TextCol = new DataGridColoredTextBoxColumn(de, 11);
                    TextCol.MappingName = "vattu_th";
                    TextCol.HeaderText = "";// "Vật tư";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 0 ;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //12
                    TextCol = new DataGridColoredTextBoxColumn(de, 12);
                    TextCol.MappingName = "vattu_bh";
                    TextCol.HeaderText = "";// "Vật tư BHYT";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 0;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //13
                    TextCol = new DataGridColoredTextBoxColumn(de, 13);
                    TextCol.MappingName = "vattu_dv";
                    TextCol.HeaderText = "";// "Vật tư DV";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 0;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //14
                    TextCol = new DataGridColoredTextBoxColumn(de, 14);
                    TextCol.MappingName = "vattu_nn";
                    TextCol.HeaderText = "";// "Vật tư NN";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 0;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //15
                    TextCol = new DataGridColoredTextBoxColumn(de, 15);
                    TextCol.MappingName = "vattu_cs";
                    TextCol.HeaderText = "";// "Vật tư CS";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 0;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //16
                    TextCol = new DataGridColoredTextBoxColumn(de, 16);
                    TextCol.MappingName = "vattu_ksk";
                    TextCol.HeaderText = ""; //"Vật tư KSK";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 0;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //17
                    TextCol = new DataGridColoredTextBoxColumn(de, 17);
                    TextCol.MappingName = "bhyt";
                    TextCol.HeaderText = "BHYT Trả";
                    TextCol.ReadOnly = false;
                    TextCol.Alignment = HorizontalAlignment.Center;
                    TextCol.Width = 72;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //18
                    TextCol = new DataGridColoredTextBoxColumn(de, 18);
                    TextCol.MappingName = "ten_loaivp";
                    TextCol.HeaderText = "";// "Loại viện phí";
                    TextCol.NullText = "";
                    TextCol.ReadOnly = true;
                    TextCol.Width = 0;
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //19
                    TextCol = new DataGridColoredTextBoxColumn(de, 19);
                    TextCol.MappingName = "ten_nhomvp";
                    TextCol.HeaderText = "";// "Nhóm viện phí";
                    TextCol.NullText = "";
                    TextCol.ReadOnly = true;
                    TextCol.Width = 0;
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //20
                    TextCol = new DataGridColoredTextBoxColumn(de,20);
                    TextCol.MappingName = "ten_nhombhyt";
                    TextCol.HeaderText = "Nhóm VP BHYT";
                    TextCol.NullText = "";
                    TextCol.ReadOnly = true;
                    TextCol.Width = 102;
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //21
                    TextCol = new DataGridColoredTextBoxColumn(de, 21);
                    TextCol.MappingName = "ten_loaibn";
                    TextCol.HeaderText = "";// "Loại bệnh nhân";
                    TextCol.NullText = "";
                    TextCol.ReadOnly = true;
                    TextCol.Width = 0;
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //22
                    TextCol = new DataGridColoredTextBoxColumn(de, 22);
                    TextCol.MappingName = "theobs";
                    TextCol.HeaderText = "";// "Thu theo Bác sĩ";
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "0";
                    TextCol.Alignment = HorizontalAlignment.Center;
                    TextCol.Width = 0;
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //23
                    TextCol = new DataGridColoredTextBoxColumn(de, 23);
                    TextCol.MappingName = "trongoi";
                    TextCol.HeaderText = "";// "Trọn gói";
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "0";
                    TextCol.Alignment = HorizontalAlignment.Center;
                    TextCol.Width = 0;
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //24
                    TextCol = new DataGridColoredTextBoxColumn(de, 24);
                    TextCol.MappingName = "loaitrongoi";
                    TextCol.HeaderText = "";// "Loại trọn gói";
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "0";
                    TextCol.Alignment = HorizontalAlignment.Center;
                    TextCol.Width = 90;
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //25
                    TextCol = new DataGridColoredTextBoxColumn(de, 25);
                    TextCol.MappingName = "chenhlech";
                    TextCol.HeaderText = "Tính chênh lệch BHYT";
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "0";
                    TextCol.Alignment = HorizontalAlignment.Center;
                    TextCol.Width = 120;
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //26
                    TextCol = new DataGridColoredTextBoxColumn(de, 26);
                    TextCol.MappingName = "thuong";
                    TextCol.HeaderText = "";// "In hoá đơn thường";
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "0";
                    TextCol.Alignment = HorizontalAlignment.Center;
                    TextCol.Width = 100;
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //27
                    TextCol = new DataGridColoredTextBoxColumn(de, 27);
                    TextCol.MappingName = "ndm";
                    TextCol.HeaderText = "";// "Miễn ngoài danh mục";
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "0";
                    TextCol.Alignment = HorizontalAlignment.Center;
                    TextCol.Width = 0;
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //28
                    TextCol = new DataGridColoredTextBoxColumn(de, 28);
                    TextCol.MappingName = "locthe";
                    TextCol.HeaderText = "";// "Lọc thẻ";
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "0";
                    TextCol.Alignment = HorizontalAlignment.Center;
                    TextCol.Width = 100;
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //29                    
                    TextCol = new DataGridColoredTextBoxColumn(de, 29);
                    TextCol.MappingName = "tylekhuyenmai";
                    TextCol.HeaderText = "";// "Tỷ lệ khuyến mãi";
                    TextCol.Width = 0;
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);              
                    //30
                    TextCol = new DataGridColoredTextBoxColumn(de, 30);
                    TextCol.MappingName = "hide";
                    TextCol.HeaderText = "Không dùng";
                    TextCol.Width = 80;
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //31
                    TextCol = new DataGridColoredTextBoxColumn(de, 31);
                    TextCol.MappingName = "readonly";
                    TextCol.HeaderText = "Read only";
                    TextCol.Width = 80;
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);  
                    //32
                    TextCol = new DataGridColoredTextBoxColumn(de, 0);
                    TextCol.MappingName = "ngayud";
                    TextCol.HeaderText = "Ngày cập nhật";
                    TextCol.NullText = "";
                    TextCol.ReadOnly = true;
                    TextCol.Width = 102;
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //33
                    TextCol = new DataGridColoredTextBoxColumn(de, 0);
                    TextCol.MappingName = "id_loai";
                    TextCol.HeaderText = "id_loai";
                    TextCol.NullText = "";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Center;
                    TextCol.Width = 0;
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //34
                    TextCol = new DataGridColoredTextBoxColumn(de, 0);
                    TextCol.MappingName = "id_nhom";
                    TextCol.HeaderText = "id_nhom";
                    TextCol.Width = 0;
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //35
                    TextCol = new DataGridColoredTextBoxColumn(de, 0);
                    TextCol.MappingName = "loaibn";
                    TextCol.HeaderText = "loaibn";
                    TextCol.Width = 0;
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //36
                    TextCol = new DataGridColoredTextBoxColumn(de, 0);
                    TextCol.MappingName = "blank";
                    TextCol.HeaderText = "";
                    TextCol.Width = 0;
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //37
                    TextCol = new DataGridColoredTextBoxColumn(de, 0);
                    TextCol.MappingName = "kythuat";
                    TextCol.HeaderText = "Kỹ thuật cao";
                    TextCol.Width = 60;
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);

                    TextCol = new DataGridColoredTextBoxColumn(de, 0);
                    TextCol.MappingName = "giavtth";
                    TextCol.HeaderText = "ĐM VTTH";
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 100;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,###";
                    TextCol.ReadOnly = true;
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);

                    TextCol = new DataGridColoredTextBoxColumn(de, 0);
                    TextCol.MappingName = "vat";
                    TextCol.HeaderText = "Tr đó VAT";
                    TextCol.Alignment = HorizontalAlignment.Right;
                    TextCol.Width = 50;
                    TextCol.NullText = "";
                    TextCol.ReadOnly = true;
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                }
                DataGrid1.DataSource = v_ds.Tables[0];                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #region Datagrid Colored Collum
        public Color MyGetColorRowCol(int row, int col)
        {
            Color c = Color.Navy;
            switch (col.ToString())
            {
                case "0":
                    c = Color.Navy;
                    break;
                case "1":
                    c = Color.DimGray;
                    break;
                default:
                    c = Color.Navy;
                    break;
            }
            return c;
        }
        public delegate Color delegateGetColorRowCol(int row, int col);
        public class DataGridColoredTextBoxColumn : DataGridTextBoxColumn
        {
            private delegateGetColorRowCol _getColorRowCol;
            private int _column;
            public DataGridColoredTextBoxColumn(delegateGetColorRowCol getcolorRowCol, int column)
            {
                _getColorRowCol = getcolorRowCol;
                _column = column;
            }
            protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
            {
                try
                {
                    //foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
                    //backBrush = new SolidBrush(Color.GhostWhite);
                }
                catch { }
                finally
                {
                    base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
                }
            }
        }

        #endregion

        private void f_Load_DG1(string v_id)
        {
            try
            {
                if (m_id != "")
                {
                    sql = "select a.id,a.stt,a.ma,a.ten,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,gia_ksk,a.vattu_th,a.vattu_bh,a.vattu_dv,a.vattu_nn,a.vattu_cs,vattu_ksk,case when a.bhyt is null then 0 else a.bhyt end as bhyt,b.ten as ten_loaivp, d.ten as ten_nhomvp,e.ten as ten_nhombhyt, c.ten as ten_loaibn,case when a.theobs is null then 0 else a.theobs end as theobs, case when a.trongoi is null then 0 else a.trongoi end as trongoi, case when a.loaitrongoi is null then 0 else a.loaitrongoi end as loaitrongoi,case when a.chenhlech is null then 0 else a.chenhlech end as chenhlech,case when a.thuong is null then 0 else a.thuong end as thuong,case when a.ndm is null then 0 else a.ndm end as ndm,a.locthe,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,case when a.loaibn is null then 0 else a.loaibn end as loaibn,case when b.id is null then -999 else b.id end as id_loai,b.id_nhom,'' as blank,tylekhuyenmai,hide,a.readonly,a.kythuat,a.giavtth,a.vat, sothe from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_loaibn c on a.loaibn=c.id left join medibv.v_nhomvp d on b.id_nhom=d.ma left join medibv.v_nhombhyt e on d.idnhombhyt=e.id where a.id=" + m_id + " order by a.stt,a.ten";
                    CurrencyManager cm = (CurrencyManager)(BindingContext[DataGrid1.DataSource, DataGrid1.DataMember]);
                    DataView dv = (DataView)(cm.List);
                    foreach (DataRow r in m_v.get_data(sql).Tables[0].Rows)
                    {
                        if (dv.Table.Select("id=" + r["id"].ToString()).Length > 0)
                        {
                            DataRow r1 = dv.Table.Select("id=" + r["id"].ToString())[0];
                            for (int j = 0; j < dv.Table.Columns.Count; j++)
                            {
                                r1[j] = r[j];
                            }
                        }
                        else
                        {
                            dv.Table.Rows.Add(r.ItemArray);
                        }
                    }
                    txtTim_TextChanged(null, null);
                }
            }
            catch
            {
            }
        }

        private void f_Load_Tree()
        {
            try
            {       
                treeView1.Nodes.Clear();
                TreeNode anode, anode1;
                DataSet adsloai, adsnhom;
                string asort = "ten";
                if (toolStripMenuItem2.Checked)
                {
                    asort = "stt";
                }
                anode = new TreeNode("Tất cả");
                anode.Tag = "?:?";
                //anode.ImageIndex = 2;
                //anode.SelectedImageIndex = 2;
                treeView1.Nodes.Add(anode);

                adsnhom = m_v.f_get_v_nhomvp_frmgiavp();
                adsloai = m_v.f_get_v_loaivp_frmgiavp();
                foreach (DataRow r in adsnhom.Tables[0].Select("",asort))
                {
                    anode = new TreeNode(r["ten"].ToString());
                    anode.Tag = r["ma"].ToString() + ":?";
                    //anode.ImageIndex = 0;
                    //anode.SelectedImageIndex = 0;
                    treeView1.Nodes.Add(anode);
                    foreach (DataRow r1 in adsloai.Tables[0].Select("id_nhom=" + r["ma"].ToString(),asort))
                    {
                        anode1 = new TreeNode(r1["ten"].ToString());
                        anode1.Tag = r["ma"].ToString() + ":" + r1["id"].ToString();
                        //anode1.ImageIndex = 1;
                        //anode1.SelectedImageIndex = 1;
                        anode.Nodes.Add(anode1);
                    }
                }

                if (adsnhom.Tables[0].Select("ma=-1").Length < 0)
                {
                    DataRow ar = adsnhom.Tables[0].NewRow();
                    ar["ma"] = -1;
                    ar["ten"] = "...";
                    ar["idnhombhyt"] = -1;
                    adsloai.Tables[0].Rows.InsertAt(ar, adsnhom.Tables[0].Rows.Count);
                }
                if (adsloai.Tables[0].Select("id=-1").Length < 0)
                {
                    DataRow ar1 = adsnhom.Tables[0].NewRow();
                    ar1["id"] = -1;
                    ar1["ten"] = "...";
                    ar1["id_nhom"] = -1;
                    adsloai.Tables[0].Rows.InsertAt(ar1,adsloai.Tables[0].Rows.Count);
                }
               
            }
            catch
            {
            }
        }        
        private void f_Filter()
        {
            try
            {
                string aft = "";
                if (txtTim.Text != "")
                {
                    aft = "(ma like '%" + txtTim.Text.Replace("'", "''") + "%' or ten like '%" + txtTim.Text.Replace("'", "''") + "%' or dvt like '%" + txtTim.Text.Replace("'", "''") + "%')";
                }
                try
                {
                    if (treeView1.SelectedNode.Tag.ToString().Split(':')[0] != "?" && treeView1.SelectedNode.Tag.ToString().Split(':')[0] != "-1")
                    {
                        if (aft != "")
                        {
                            aft += " and ";
                        }
                        aft += " id_nhom=" + treeView1.SelectedNode.Tag.ToString().Split(':')[0];
                    }
                    if (treeView1.SelectedNode.Tag.ToString().Split(':')[1] != "?" && treeView1.SelectedNode.Tag.ToString().Split(':')[1] != "-1")
                    {
                        if (aft != "")
                        {
                            aft += " and ";
                        }
                        aft += " id_loai=" + treeView1.SelectedNode.Tag.ToString().Split(':')[1];
                    }
                }
                catch
                {
                }

                //CurrencyManager cm = (CurrencyManager)(BindingContext[dataGridView1.DataSource, dataGridView1.DataMember]);
                CurrencyManager cm = (CurrencyManager)(BindingContext[DataGrid1.DataSource, DataGrid1.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
                lbTitle.Text = "Giá viện phí (" + dv.Table.Select(aft).Length.ToString() + "/" + dv.Table.Rows.Count.ToString() + ")";
            }
            catch
            {
                lbTitle.Text = "Giá viện phí";
            }
        }
        private void f_Moi()
        {
             string aquyenchitiet = m_v.f_get_v_phanquyen_chitiet(m_userid, m_menu_id);
             if (!m_v.f_quyenchitiet_them(aquyenchitiet))
            {
                MessageBox.Show(lan.Change_language_MessageText("Chưa được phân quyền thêm!"));
                return;
            }           
            try
            {                
                f_Enable(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        private void f_Load_Sua()
        {
            try
            {                
                CurrencyManager cm = (CurrencyManager)BindingContext[DataGrid1.DataSource, DataGrid1.DataMember];
                DataView dv = (DataView)cm.List;
                dv.AllowNew = false;
                dv.AllowDelete = false;
                dv.AllowEdit = false;              
                DataRow[] rs = dv.Table.Select("id=" + DataGrid1[DataGrid1.CurrentRowIndex, 0].ToString().Trim() + "");

                sql = "select a.id,a.stt,a.ma,a.ten,a.dvt,a.bhyt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,a.vattu_th,a.vattu_bh,a.vattu_dv,a.vattu_nn,a.vattu_cs,a.trongoi,a.loaitrongoi,a.loaibn,a.theobs,a.ndm,a.chenhlech,a.thuong,a.locthe,a.id_loai,b.id_nhom,c.idnhombhyt,a.tylekhuyenmai,a.gia_ksk,a.vattu_ksk,a.hide,a.kythuat,a.giavtth,a.vat, a.kcct from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma where a.id=" + rs[0]["id"].ToString();
                foreach (DataRow r in m_v.get_data(sql).Tables[0].Rows)
                {
                    m_id = r["id"].ToString();
                    m_id_loai = r["id_loai"].ToString();
                    
                    break;
                }
            }
            catch
            {
            }
        }

        private void f_load_GridView()
        {
            try
            {
                if (!butLuu.Enabled)
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[DataGrid1.DataSource, DataGrid1.DataMember];
                    DataView dv = (DataView)cm.List;
                    dv.AllowNew = false;
                    dv.AllowDelete = false;
                    dv.AllowEdit = false;
                    int i = DataGrid1.CurrentRowIndex;
                    DataRow[] rs = dv.Table.Select("id='" + DataGrid1[DataGrid1.CurrentRowIndex, 0].ToString().Trim() + "'");
                    if (rs.Length > 0)
                    {
                        m_id = rs[0]["id"].ToString();
                        m_id_loai = rs[0]["id_loai"].ToString();                        
                    }
                }
            }
            catch
            {
            }
        }
       
        private void f_Enable(bool v_bool)
        {
            butLuu.Enabled = v_bool;
            butXoa.Enabled = !v_bool && m_id != "";
        }
        private void butClose_Click(object sender, EventArgs e)
        {            
            this.Dispose();
        }
        private void butRefresh_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;           
            f_Load_DG();
            f_Load_Tree();
            Cursor = Cursors.Default;
        }
        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            f_Filter();
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            f_Filter();
            try
            {
                treeView1.SelectedNode.ForeColor = Color.Red;
                if (treeView1.SelectedNode.Parent != null)
                {
                    treeView1.SelectedNode.Parent.ForeColor = Color.Red;
                }
                if (treeView1.SelectedNode.Parent.Parent != null)
                {
                    treeView1.SelectedNode.Parent.Parent.ForeColor = Color.Red;
                }
            }
            catch
            {
            }
        }
        private void butSualoai_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode.Tag.ToString().Split(':')[1] == "?")
                {
                    frmNewnhomvp af = new frmNewnhomvp(m_v, treeView1.SelectedNode.Tag.ToString().Split(':')[1], treeView1.SelectedNode.Tag.ToString().Split(':')[0], m_userid);
                    af.ShowInTaskbar = false;
                    af.ShowDialog(this);
                    f_Load_Tree();
                }
                else
                {
                    frmNewloaivp af = new frmNewloaivp(m_v, treeView1.SelectedNode.Tag.ToString().Split(':')[1], treeView1.SelectedNode.Tag.ToString().Split(':')[0], m_userid);
                    af.ShowInTaskbar = false;
                    af.ShowDialog(this);
                    f_Load_Tree();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Chọn nội dung cần sửa từ danh sách!\nError: " + ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void butNewnhom_Click(object sender, EventArgs e)
        {
            try
            {
                frmNewnhomvp af = new frmNewnhomvp(m_v, "", "", m_userid);
                af.ShowInTaskbar = false;
                af.ShowDialog(this);
                f_Load_Tree();
            }
            catch
            {
            }
        }
        private void butNewloai_Click(object sender, EventArgs e)
        {
            try
            {
                string aid_nhom = "";
                try
                {
                    aid_nhom = treeView1.SelectedNode.Tag.ToString().Split(':')[1];
                }
                catch
                {
                    aid_nhom = "";
                }
                frmNewloaivp af = new frmNewloaivp(m_v, "", aid_nhom, m_userid);
                af.ShowInTaskbar = false;
                af.ShowDialog(this);
                f_Load_Tree();
            }
            catch
            {
            }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Checked = !toolStripMenuItem1.Checked;
            if (toolStripMenuItem1.Checked)
            {
                toolStripMenuItem2.Checked = false;
            }
            f_Load_Tree();
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            toolStripMenuItem2.Checked = !toolStripMenuItem2.Checked;
            if (toolStripMenuItem2.Checked)
            {
                toolStripMenuItem1.Checked = false;
            }
            f_Load_Tree();
        }
        private void butXoaloai_Click(object sender, EventArgs e)
        {
            try
            {
                string aid = "";
                if (treeView1.SelectedNode.Tag.ToString().Split(':')[1] == "?")
                {
                    aid = treeView1.SelectedNode.Tag.ToString().Split(':')[0];
                    if (m_v.dadung_v_nhomvp(aid) != 0)
                    {
                        MessageBox.Show(this, "Hệ thống không cho xoá nhóm viện phí này!\nLiên hệ với quản trị hệ thống khi có nhu cầu!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        if (MessageBox.Show(this, "Đồng ý xoá nhóm viện phí?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            if (!m_v.del_v_nhomvp(aid))
                            {
                                MessageBox.Show(this, "Hệ thống không cho xoá nhóm viện phí này!\nLiên hệ với quản trị hệ thống khi có nhu cầu!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                f_Load_Tree();
                            }
                        }
                }
                else
                {
                    aid = treeView1.SelectedNode.Tag.ToString().Split(':')[1];
                    if (m_v.dadung_v_loaivp(aid) != 0)
                    {
                        MessageBox.Show(this, "Hệ thống không cho xoá loại viện phí này!\nLiên hệ với quản trị hệ thống khi có nhu cầu!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        if (MessageBox.Show(this, "Đồng ý xoá loại viện phí?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            if (!m_v.del_v_loaivp(aid))
                            {
                                MessageBox.Show(this, "Hệ thống không cho xoá giá viện phí này!\nLiên hệ với quản trị hệ thống khi có nhu cầu!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                f_Load_Tree();
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Chọn nội dung cần sửa từ danh sách!\nError: " + ex.ToString(), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void butMedisoftcenter_Click(object sender, EventArgs e)
        {
            try
            {
                frmMedisoftcenterupdate af = new frmMedisoftcenterupdate(m_v, m_userid,"DMXN");
                af.TopMost = true;
                af.ShowDialog();
            }
            catch
            {
            }
        }
        private void butLocal_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog afo = new OpenFileDialog();
                afo.RestoreDirectory = true;
                afo.Filter = "Microsoft XML Document (*.XML)|*.xml";
                afo.Title = "Chọn file dữ liệu đã download từ Medisoft Center Update";
                afo.ShowDialog();
                if (afo.FileName != "")
                {
                    MessageBox.Show(this, "Cập nhật thành công!", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }
        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                treeView1.SelectedNode.ForeColor = Color.Black;
                if (treeView1.SelectedNode.Parent != null)
                {
                    treeView1.SelectedNode.Parent.ForeColor = Color.Black;
                }
                if (treeView1.SelectedNode.Parent.Parent != null)
                {
                    treeView1.SelectedNode.Parent.Parent.ForeColor = Color.Black;
                }
            }
            catch
            {
            }
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode.Tag.ToString().Split(':')[1] == "?")
                {
                    cmenu_Sua.Text = "Sữa nhóm: ";
                    menu_Xoaloai.Text = "Xoá nhóm: ";
                }
                else
                if (treeView1.SelectedNode.Tag.ToString().Split(':')[1] != "?")
                {
                    cmenu_Sua.Text = "Sữa loại: ";
                    menu_Xoaloai.Text = "Xoá loại: ";
                }
                cmenu_Sua.Text += "["+treeView1.SelectedNode.Text+"]";
                menu_Xoaloai.Text += "["+treeView1.SelectedNode.Text+"]";
            }
            catch
            {
            }
        }
        private void f_In()
        {
            try
            {
                string sql = "", aexp = "";
                if (treeView1.SelectedNode != null)
                {
                    if (treeView1.SelectedNode.Tag.ToString().Split(':')[0] != "?" && treeView1.SelectedNode.Tag.ToString().Split(':')[0] != "-1")
                    {
                        if (aexp != "")
                        {
                            aexp += " and ";
                        }
                        aexp += " c.ma=" + treeView1.SelectedNode.Tag.ToString().Split(':')[0];
                    }
                    if (treeView1.SelectedNode.Tag.ToString().Split(':')[1] != "?" && treeView1.SelectedNode.Tag.ToString().Split(':')[1] != "-1")
                    {
                        if (aexp != "")
                        {
                            aexp += " and ";
                        }
                        aexp += " b.id=" + treeView1.SelectedNode.Tag.ToString().Split(':')[1];
                    }
                }
                if (aexp != "")
                {
                    aexp = " where " + aexp;
                }
                sql = "select a.id, a.ma, a.ten, a.dvt, a.gia_th, a.gia_bh, a.gia_dv, a.gia_nn, a.bhyt, a.ndm, b.id as id_loai, b.stt as stt_loai, b.ten as ten_loai, c.ma as id_nhom, c.stt as stt_nhom, c.ten as ten_nhom,a.kythuat,a.giavtth,a.vat, a.hide, a.kcct from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma " + aexp + " order by c.stt, b.stt, a.stt";
                DataSet ads = m_v.get_data(sql);
                //ads.WriteXml("..//..//Datareport//v_banggiavp.xml",XmlWriteMode.WriteSchema);
                CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                crystalReportViewer1.ActiveViewIndex = -1;
                crystalReportViewer1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(239)), ((System.Byte)(239)), ((System.Byte)(239)));
                crystalReportViewer1.DisplayGroupTree = false;
                crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
                crystalReportViewer1.Name = "crystalReportViewer1";
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Size = new System.Drawing.Size(792, 573);
                crystalReportViewer1.TabIndex = 85;

                System.Windows.Forms.Form af = new System.Windows.Forms.Form();
                af.WindowState = FormWindowState.Maximized;
                af.Controls.Add(crystalReportViewer1);
                af.Text = "Bảng giá viện phí";
                crystalReportViewer1.BringToFront();
                crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;

                string areport = "", asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                areport = "v_2007_giavp.rpt";
                asyt = m_v.Syte;
                abv = m_v.Tenbv;
                angayin = "Ngày " + DateTime.Now.Day.ToString().PadLeft(2, '0') + " tháng " + DateTime.Now.Month.ToString().PadLeft(2, '0') + " năm " + DateTime.Now.Year.ToString();
                anguoiin = "";
                aghichu = "";

                ReportDocument cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + areport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + anguoiin + "'";
                cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + aghichu + "'";
                cMain.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                cMain.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                crystalReportViewer1.ReportSource = cMain;
                af.Text = "Giá viện phí (" + areport + ")";
                af.ShowDialog();
            }
            catch
            {
                MessageBox.Show(this, "Lỗi máy in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void butIn_Click(object sender, EventArgs e)
        {

            f_In();
        }
        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }
        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }
        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }
        private void butMoi_Click(object sender, EventArgs e)
        {
            f_Moi();
        }
        private void butXoa_Click(object sender, EventArgs e)
        {
            
        }
        private void butSua_Click(object sender, EventArgs e)
        {
        }
        private void butBoqua_Click(object sender, EventArgs e)
        {
           
        }
        

        
        private void txtSTT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtMa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

      

        private void txtGia_bh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

       

        

        private void DataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            f_load_GridView();
        }

        private void cbKythuatcao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)  SendKeys.Send("{Tab}{F4}");
        }


        private void txtTim_Enter(object sender, EventArgs e)
        {
            txtTim.Text = "";
        }

        private void vat_KeyPress(object sender, KeyPressEventArgs e)
        {
            m.MaskDecimal(e);
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            string aquyenchitiet = m_v.f_get_v_phanquyen_chitiet(m_userid, m_menu_id);
            if (!m_v.f_quyenchitiet_sua(aquyenchitiet))
            {
                MessageBox.Show(lan.Change_language_MessageText("Chưa được phân quyền sửa!"));
                return;
            }     
            string sexp = "bhyt<>bhytcu or gia_th<>gia_thcu or gia_bh<>gia_bhcu or gia_dv<>gia_dvcu";
            string sql = "";
            Cursor = Cursors.WaitCursor;
            foreach (DataRow dr in dsgia.Tables[0].Select(sexp,""))
            {
                sql = "update medibv.v_giavp_luu set bhyt=" + dr["bhyt"].ToString() + ", gia_th=" + dr["gia_th"].ToString() + ", gia_dv=" + dr["gia_dv"].ToString() + ", gia_bh=" + dr["gia_bh"].ToString();
                sql += " where id=" + dr["id"].ToString() + " and to_char(ngayud,'dd/mm/yyyy hh24:mi')='" + dr["ngayud"].ToString() + "'";

                m_v.execute_data(sql);
            }
            Cursor = Cursors.Default;
        }       
    }
}