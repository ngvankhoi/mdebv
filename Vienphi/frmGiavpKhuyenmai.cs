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
    public partial class frmGiavpKhuyenMai : Form
    {
        private string m_menu_id = "mnuKhaibaogiakhuyenmai";
        private LibVP.AccessData m_v;        
        private LibMedi.AccessData m=new LibMedi.AccessData();
        private string m_userid = "",m_id_loai="",m_id="",sql,user,sql1;
        private int itable;
        private DataSet ds = new DataSet();
        private DataSet ds1 = new DataSet();
        private int DG = 0;
        private bool bKhoan;

        public frmGiavpKhuyenMai(LibVP.AccessData v_v, string v_userid)
        {
            InitializeComponent();
            m_v = v_v; 
            m_userid = v_userid;
            m_v.f_SetEvent(this);
        }

        
        private void f_Load_DG()
        {
            string iddot;
            try
            {
               iddot = cbKM.ComboBox.SelectedValue.ToString();
            }
            catch 
            {
                iddot = "0";
            }
            try
            {
                

               // Application.DoEvents();
                sql = "select  a.id,a.stt,a.ma,a.ten,a.dvt,a.tylekhuyenmai,a.tylekhuyenmai_old, sum(a.sotienkm) as sotienkm,";
                sql += "a.gia_th, a.id_loai,a.ten_nhomvp,a.ten_loaivp,a.ngayud,a.id_nhom,sum(a.hide) as hide from (";
                sql += "select a.id,a.stt,a.ma,a.ten,a.dvt,a.tylekhuyenmai,a.tylekhuyenmai as tylekhuyenmai_old, 0 as sotienkm,";
                sql += "a.gia_th, case when b.id is null then -999 else b.id end as id_loai,c.ten as ten_nhomvp,b.ten as ten_loaivp,to_char(a.ngayud,'dd/mm/yyyy') as ngayud,b.id_nhom,0 as hide ";
                sql += "from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma union all ";
                sql += "select a.id,a.stt,a.ma,a.ten,a.dvt,a.tylekhuyenmai,a.tylekhuyenmai as tylekhuyenmai_old, d.sotienkhuyenmai as sotienkm,";
                sql += "a.gia_th, case when b.id is null then -999 else b.id end as id_loai,c.ten as ten_nhomvp,b.ten as ten_loaivp,to_char(a.ngayud,'dd/mm/yyyy') as ngayud,b.id_nhom,e.hide ";
                sql += "from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma inner join medibv.v_giavp_khuyenmai d on a.id=d.idvp ";
                sql += "inner join medibv.v_dot_khuyenmai e on d.iddot=e.id where e.hide=0 ) as a";
                sql += " group by a.id,a.stt,a.ma,a.ten,a.dvt,a.tylekhuyenmai,a.tylekhuyenmai_old,a.gia_th, a.id_loai,a.ten_nhomvp,a.ten_loaivp,a.ngayud,a.id_nhom";
                sql += " order by a.stt,a.ten";
                ds = m_v.get_data(sql);
                AddGridTableStyle(ds);
                txtTim_TextChanged(null, null);
                DataGrid1.ReadOnly = true;
                // load datagrid2
                sql1 = "select a.id,a.ma,a.ten tenvp,a.dvt,a.gia_th,b.sotienkhuyenmai,b.tylekhuyenmai,b.tylekhuyenmai as tylekhuyenmai_old,c.ten,to_char(c.id,'999999999') as iddot,c.hide from medibv.v_giavp a left join medibv.v_giavp_khuyenmai b on a.id=b.idvp inner join medibv.v_dot_khuyenmai c on c.id=b.iddot where b.iddot= " + iddot + " order by tenvp";
                
                ds1 = m_v.get_data(sql1);
                AddGrid2TableStyle(ds1);
                //txtTimKM_TextChanged(null, null);
                dataGrid2.ReadOnly = true;
            }
            catch
            {
               
            }
        }
        private void f_Load_DG2()
        {
            string iddot = txtIDKM.Text.Trim();
            sql1 = "select a.id,a.ma,a.ten tenvp,a.dvt,a.gia_th,b.sotienkhuyenmai,b.tylekhuyenmai,b.tylekhuyenmai as tylekhuyenmai_old,c.ten,to_char(c.id,'999999999') as iddot from medibv.v_giavp a left join medibv.v_giavp_khuyenmai b on a.id=b.idvp inner join medibv.v_dot_khuyenmai c on c.id=b.iddot where iddot=" + iddot + " order by tenvp";
            ds1 = m_v.get_data(sql1);
            dataGrid2.DataSource = ds1.Tables[0];
        }
        private void f_Load_DG1()
        {
            string iddot = txtTimKM.Text.Trim(); 
            
        }
        private void AddGrid2TableStyle(DataSet v_ds)
        {
            try
            {
                
                if (dataGrid2.TableStyles.Count <= 0)
                {
                    dataGrid2.TableStyles.Clear();
                    dataGrid2.AllowSorting = true;

                    DataGridTextBoxColumn TextCol;
                    //delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
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

                    ts.RowHeaderWidth = 16;
                    ts.AllowSorting = true;
                    ts.PreferredRowHeight = 20;
                    //0
                    TextCol = new DataGridTextBoxColumn();
                    TextCol.MappingName = "id";
                    TextCol.HeaderText = "ID";
                    TextCol.Width = 50;
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    dataGrid2.TableStyles.Add(ts);
                    //1
                    TextCol = new DataGridTextBoxColumn();
                    TextCol.MappingName = "ma";
                    TextCol.HeaderText = "Mã";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Left;
                    TextCol.Width = 80;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    dataGrid2.TableStyles.Add(ts);
                    //1
                    TextCol = new DataGridTextBoxColumn();
                    TextCol.MappingName = "tenvp";
                    TextCol.HeaderText = "Nội dung";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Left;
                    TextCol.Width = 450;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    dataGrid2.TableStyles.Add(ts);
                    //2
                    TextCol = new DataGridTextBoxColumn();
                    TextCol.MappingName = "dvt";
                    TextCol.HeaderText = "ĐVT";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Left;
                    TextCol.Width = 80;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    dataGrid2.TableStyles.Add(ts);
                    //3
                    TextCol = new DataGridTextBoxColumn();
                    TextCol.MappingName = "gia_th";
                    TextCol.HeaderText = "Đơn giá";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Left;
                    TextCol.Format = "###,###,##0.00";
                    TextCol.Width = 180;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    dataGrid2.TableStyles.Add(ts);
                    
                    //4
                    TextCol = new DataGridTextBoxColumn();
                    TextCol.MappingName = "tylekhuyenmai";
                    TextCol.HeaderText = "Tỉ lệ khuyến mãi ";
                    TextCol.ReadOnly = false;
                    TextCol.Alignment = HorizontalAlignment.Left;
                    TextCol.Format = "###,###,##0.00";
                    TextCol.Width = 100;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    dataGrid2.TableStyles.Add(ts);
                    //5
                    TextCol = new DataGridTextBoxColumn();
                    TextCol.MappingName = "sotienkhuyenmai";
                    TextCol.HeaderText = "Số tiền khuyến mãi";
                    TextCol.ReadOnly = false;
                    TextCol.Alignment = HorizontalAlignment.Left;
                    TextCol.Format = "###,###,##0.00";
                    TextCol.Width = 250;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    dataGrid2.TableStyles.Add(ts);
                    //6
                    //TextCol = new DataGridTextBoxColumn();
                    //TextCol.MappingName = "ten";
                    //TextCol.HeaderText = "Tên đợt";
                    //TextCol.ReadOnly = true;
                    //TextCol.Alignment = HorizontalAlignment.Left;
                    //TextCol.Width = 180;
                    //TextCol.NullText = "";
                    //ts.GridColumnStyles.Add(TextCol);
                    //dataGrid2.TableStyles.Add(ts);

                }
                dataGrid2.DataSource = v_ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
              
                    DataGridTextBoxColumn TextCol;                    
                    //delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
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

                    ts.RowHeaderWidth = 16;
                    ts.AllowSorting = true;
                    ts.PreferredRowHeight = 20;

                    //0
                    TextCol = new DataGridTextBoxColumn();
                    TextCol.MappingName = "id";
                    TextCol.HeaderText = "ID";
                    TextCol.Width = 43;
                    TextCol.ReadOnly = true;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //1
                    TextCol = new DataGridTextBoxColumn();
                    TextCol.MappingName = "stt";
                    TextCol.HeaderText = "Stt";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Left;
                    TextCol.Width = 30;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //2
                    TextCol = new DataGridTextBoxColumn();
                    TextCol.MappingName = "ma";
                    TextCol.HeaderText = "Mã số";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Left;
                    TextCol.Width = 75;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //3
                    TextCol = new DataGridTextBoxColumn();
                    TextCol.MappingName = "ten";
                    TextCol.HeaderText = "Nội dung";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Left;
                    TextCol.Width = 350;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //4
                    TextCol = new DataGridTextBoxColumn();
                    TextCol.MappingName = "dvt";
                    TextCol.HeaderText = "ĐVT";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Left;
                    TextCol.Width = 60;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //5
                    TextCol = new DataGridTextBoxColumn();
                    TextCol.MappingName = "gia_th";
                    TextCol.HeaderText = "Đơn giá";
                    TextCol.ReadOnly = true;
                    TextCol.Alignment = HorizontalAlignment.Left;
                    TextCol.Width = 90;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //6
                    ///new
                    TextCol = new DataGridTextBoxColumn();//(de, 31);
                    TextCol.MappingName = "tylekhuyenmai";
                    TextCol.HeaderText = "Tỷ lệ khuyến mãi";
                    TextCol.Format = "###,###,##0.00";
                    TextCol.Width = 100;
                    TextCol.ReadOnly = false;
                    TextCol.Alignment = HorizontalAlignment.Left;
                    TextCol.NullText = "";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);              
                    ///new 
                   
                    //7
                    TextCol = new DataGridTextBoxColumn();
                    TextCol.MappingName = "sotienkm";
                    TextCol.HeaderText = "Số tiền khuyến mãi";
                    TextCol.ReadOnly = false;
                    TextCol.Alignment = HorizontalAlignment.Left;
                    TextCol.Width = 100;
                    TextCol.NullText = "";
                    TextCol.Format = "###,###,##0.00";
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //8
                    TextCol = new DataGridTextBoxColumn();//(de, 20);
                    TextCol.MappingName = "ten_loaivp";
                    TextCol.HeaderText = "Loại viện phí";
                    TextCol.NullText = "";
                    TextCol.ReadOnly = true;
                    TextCol.Width = 150;
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //21
                    TextCol = new DataGridTextBoxColumn();//(de, 21);
                    TextCol.MappingName = "ten_nhomvp";
                    TextCol.HeaderText = "Nhóm viện phí";
                    TextCol.NullText = "";
                    TextCol.ReadOnly = true;
                    TextCol.Width = 125;
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    
                    //34
                    TextCol = new DataGridTextBoxColumn();//(de, 34);
                    TextCol.MappingName = "ngayud";
                    TextCol.HeaderText = "Ngày cập nhật";
                    TextCol.NullText = "";
                    TextCol.ReadOnly = true;
                    TextCol.Width = 90;
                    ts.GridColumnStyles.Add(TextCol);
                    DataGrid1.TableStyles.Add(ts);
                    //35
                                        
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

        //private void f_Load_DG1(string v_id)
        //{
        //    try
        //    {
        //        if (m_id != "")
        //        {
        //            sql = "select a.id,a.stt,a.ma,a.ten,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,gia_ksk,a.vattu_th,a.vattu_bh,a.vattu_dv,a.vattu_nn,a.vattu_cs,vattu_ksk,case when a.bhyt is null then 0 else a.bhyt end as bhyt,b.ten as ten_loaivp, d.ten as ten_nhomvp,e.ten as ten_nhombhyt, c.ten as ten_loaibn,case when a.theobs is null then 0 else a.theobs end as theobs, case when a.trongoi is null then 0 else a.trongoi end as trongoi, case when a.loaitrongoi is null then 0 else a.loaitrongoi end as loaitrongoi,case when a.chenhlech is null then 0 else a.chenhlech end as chenhlech,case when a.thuong is null then 0 else a.thuong end as thuong,case when a.ndm is null then 0 else a.ndm end as ndm,a.locthe,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,case when a.loaibn is null then 0 else a.loaibn end as loaibn,case when b.id is null then -999 else b.id end as id_loai,b.id_nhom,'' as blank,tylekhuyenmai,hide,a.readonly,a.kythuat,a.giavtth,a.vat,a.kcct, a.sothe, a.bhyt_tt from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_loaibn c on a.loaibn=c.id left join medibv.v_nhomvp d on b.id_nhom=d.ma left join medibv.v_nhombhyt e on d.idnhombhyt=e.id where a.id=" + m_id + " order by a.stt,a.ten";
        //            CurrencyManager cm = (CurrencyManager)(BindingContext[DataGrid1.DataSource, DataGrid1.DataMember]);
        //            DataView dv = (DataView)(cm.List);
        //            foreach (DataRow r in m_v.get_data(sql).Tables[0].Rows)
        //            {
        //                if (dv.Table.Select("id=" + r["id"].ToString()).Length > 0)
        //                {
        //                    DataRow r1 = dv.Table.Select("id=" + r["id"].ToString())[0];
        //                    for (int j = 0; j < dv.Table.Columns.Count; j++)
        //                    {
        //                        r1[j] = r[j];
        //                    }
        //                }
        //                else
        //                {
        //                    dv.Table.Rows.Add(r.ItemArray);
        //                }
        //            }
        //            txtTim_TextChanged(null, null);
        //        }
        //    }
        //    catch(Exception ex) 
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private void f_load_DG2()
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        ds = m_v.get_data("select iddot,idvp,tylekhuyenmai,sotienkhuyenmai,userid,ngayud from medibv.v_giavp_khuyenmai");
        //    }
        //    catch
        //    { }
        //}

        private void f_Load_CB()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = m_v.get_data("select id,ten,hide from medibv.v_dot_khuyenmai order by hide");
                cbKM.ComboBox.DisplayMember = "ten";
                cbKM.ComboBox.ValueMember = "id";
                cbKM.ComboBox.DataSource = ds.Tables[0];
                txtIDKM.Text = cbKM.ComboBox.SelectedValue.ToString();
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
                        //cbNhomvp.SelectedValue = treeView1.SelectedNode.Tag.ToString().Split(':')[0];
                        //cbNhomvp_SelectedIndexChanged(null, null);
                    }
                    if (treeView1.SelectedNode.Tag.ToString().Split(':')[1] != "?" && treeView1.SelectedNode.Tag.ToString().Split(':')[1] != "-1")
                    {
                        if (aft != "")
                        {
                            aft += " and ";
                        }
                        aft += " id_loai=" + treeView1.SelectedNode.Tag.ToString().Split(':')[1];
                        //cbLoaivp.SelectedValue = treeView1.SelectedNode.Tag.ToString().Split(':')[1];
                    }
                }
                catch
                {
                }

                //CurrencyManager cm = (CurrencyManager)(BindingContext[dataGridView1.DataSource, dataGridView1.DataMember]);
                CurrencyManager cm = (CurrencyManager)(BindingContext[DataGrid1.DataSource, DataGrid1.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
                lbTitle.Text = "Giá viện phí khuyến mãi (" + dv.Table.Select(aft).Length.ToString() + "/" + dv.Table.Rows.Count.ToString() + ")";
            }
            catch
            {
                lbTitle.Text = "Giá viện phí khuyến mãi";
            }
        }
        private bool f_Moi()
        {
             string aquyenchitiet = m_v.f_get_v_phanquyen_chitiet(m_userid, m_menu_id);
             if (!m_v.f_quyenchitiet_them(aquyenchitiet))
            {
                MessageBox.Show("Chưa được phân quyền thêm!");
                f_Enable(false);
                return false;
            }           
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[DataGrid1.DataSource, DataGrid1.DataMember];
                DataView dv = (DataView)cm.List;
                DataGrid1.ReadOnly = false;
                dv.AllowEdit = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return true;
        }
        //private string f_get_id_nhombhyt(string v_id_nhom)
        //{
        //    try
        //    {
        //        CurrencyManager cm = (CurrencyManager)(BindingContext[cbNhomvp.DataSource]);
        //        DataView dv = (DataView)(cm.List);
        //        return dv.Table.Select("ma=" + cbNhomvp.SelectedValue.ToString())[0]["idnhombhyt"].ToString();
        //    }
        //    catch
        //    {
        //        return "";
        //    }
        //}
        //private string f_get_ma_nhomvp(string v_id_loai)
        //{
        //    try
        //    {
        //        CurrencyManager cm = (CurrencyManager)(BindingContext[cbLoaivp.DataSource]);
        //        DataView dv = (DataView)(cm.List);
        //        return dv.Table.Select("id=" + cbLoaivp.SelectedValue.ToString())[0]["id_nhom"].ToString();
        //    }
        //    catch
        //    {
        //        return "";
        //    }
        //}
        private void f_Load_Sua()
        {
            try
            {                
                CurrencyManager cm = (CurrencyManager)BindingContext[DataGrid1.DataSource, DataGrid1.DataMember];
                DataView dv = (DataView)cm.List;
                dv.AllowNew = false;
                dv.AllowDelete = false;
                dv.AllowEdit = true;              
                DataRow[] rs = dv.Table.Select("id=" + DataGrid1[DataGrid1.CurrentRowIndex, 0].ToString().Trim() + "");

                sql = "select a.id,a.stt,a.ma,a.ten,a.dvt,a.bhyt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.gia_cs,a.vattu_th,a.vattu_bh,a.vattu_dv,a.vattu_nn,a.vattu_cs,a.trongoi,a.loaitrongoi,a.loaibn,a.theobs,a.ndm,a.chenhlech,a.thuong,a.locthe,a.id_loai,b.id_nhom,c.idnhombhyt,a.tylekhuyenmai,a.gia_ksk,a.vattu_ksk,a.hide,a.kythuat,a.giavtth,a.vat, a.kcct from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma where a.id=" + rs[0]["id"].ToString();
                foreach (DataRow r in m_v.get_data(sql).Tables[0].Rows)
                {
                    m_id = r["id"].ToString();
                    m_id_loai = r["id_loai"].ToString();
                    txtID.Text = r["id"].ToString();
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
                    dv.AllowEdit = true;
                    int i = DataGrid1.CurrentRowIndex;
                    DataRow[] rs = dv.Table.Select("id='" + DataGrid1[DataGrid1.CurrentRowIndex, 0].ToString().Trim() + "'");
                    if (rs.Length > 0)
                    {
                        m_id = rs[0]["id"].ToString();
                        m_id_loai = rs[0]["id_loai"].ToString();
                        txtID.Text = rs[0]["id"].ToString();
                   
                      
                    }
                }

            }
            catch
            {
            }
        }
       
        private void f_Enable(bool v_bool)
        {
            butMoi.Enabled = !v_bool;
            butLuu.Enabled = v_bool;
            butSua.Enabled = !v_bool;// && m_id != "";
            butXoa.Enabled = !v_bool;// && m_id != "";
            butBoqua.Enabled = true;

            txtID.Enabled = false;
         
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            Cursor=Cursors.WaitCursor;
            m_v.execute_data("update medibv.v_giavp set locthe=null where locthe=''");
            Cursor=Cursors.Default;
            this.Dispose();
        }
        private void butRefresh_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            m_v.execute_data("update medibv.v_giavp set locthe=null where locthe=''");
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
                frmDotKhuyenMai af = new frmDotKhuyenMai(m_v, m_userid);
                //frmNewnhomvp af = new frmNewnhomvp(m_v, "", "", m_userid);
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
            DG = 1;
            dataGrid2.ReadOnly = true;
            if (f_Moi())
            {
                f_Enable(true);
            }
        }
        private void butXoa_Click(object sender, EventArgs e)
        {
            string aquyenchitiet = m_v.f_get_v_phanquyen_chitiet(m_userid, m_menu_id);
            int irow = dataGrid2.CurrentCell.RowNumber;
            string siddot = cbKM.ComboBox.SelectedValue.ToString();
            string sidvp = "";
            try
            {
                sidvp = dataGrid2[irow, 0].ToString();
            }
            catch { }
            
            if (!m_v.f_quyenchitiet_xoa(aquyenchitiet))
            {
                MessageBox.Show("Chưa được phân quyền xóa!");
                f_Enable(false);
                return;
            }
            if (DG == 2)
            {
                try
                {

                    if ((m_v.get_data("select hide from medibv.v_dot_khuyenmai where id=" + siddot)).Tables[0].Rows[0][0].ToString() == "0")
                    {
                        m_v.execute_data("delete from medibv.v_giavp_khuyenmai where iddot = " + siddot + " and idvp=" + sidvp);
                        m_v.execute_data("update medibv.v_giavp set tylekhuyenmai=0 where id=" + sidvp);
                        f_Enable(false);
                        f_Load_DG();
                    }
                    else
                    {
                        MessageBox.Show("Không được phép xóa !");
                    }
                }
                catch { }
            }
            
        }
        private void butSua_Click(object sender, EventArgs e)
        {
            DG = 2;
            DataGrid1.ReadOnly = true;
            string aquyenchitiet = m_v.f_get_v_phanquyen_chitiet(m_userid, m_menu_id);
            if (!m_v.f_quyenchitiet_sua(aquyenchitiet))
            {
                MessageBox.Show("Chưa được phân quyền sửa!");
                f_Enable(false);
                return;
            }
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid2.DataSource, dataGrid2.DataMember];
                DataView dv = (DataView)cm.List;
                dataGrid2.ReadOnly = false;
                dv.AllowEdit = true;
                dv.AllowNew = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            f_Enable(true);
        }
        private void butBoqua_Click(object sender, EventArgs e)
        {
            try
            {
                f_Load_Sua();
                f_Enable(false);
                butMoi.Focus();
            }
            catch
            {
            }
        }

        private bool KiemTra( DataRow r)
        {
            decimal a = Decimal.Parse(r["tyle"].ToString());
            if (a < 0 || a > 100)
            {
                return false;
            }
            if (Decimal.Parse(r["sotienkm"].ToString()) > Decimal.Parse(r["gia_th"].ToString()))
            {
                return false;
                
            }
            return true;
        }
        private void butLuu_Click(object sender, EventArgs e)
        {
           //foreach(DataRow r in d.select (tylekhuyenmai<>tylekhu
            int updGiaVP = 0;
            try
            {
                updGiaVP = int.Parse((m_v.get_data("select hide from medibv.v_dot_khuyenmai where id=" + cbKM.ComboBox.SelectedValue)).Tables[0].Rows[0][0].ToString());
            }
            catch { }
            if (DG == 1)
            {
                ds.AcceptChanges();
                DataRow[] ra = ds.Tables[0].Select("tylekhuyenmai <> tylekhuyenmai_old");
                string iddot = txtIDKM.Text;
                
                
                foreach (DataRow r in ds.Tables[0].Select("tylekhuyenmai <> tylekhuyenmai_old"))
                {
                    if ( updGiaVP == 0)
                    {
                        upd_v_giavp_khuyenmai(iddot, r["id"].ToString(), r["tylekhuyenmai"].ToString(), r["sotienkm"].ToString(), m_userid, true);
                    }
                    else
                    {
                        upd_v_giavp_khuyenmai(iddot, r["id"].ToString(), r["tylekhuyenmai"].ToString(), r["sotienkm"].ToString(), m_userid, false);
                    }
                }
            }
            else if (DG == 2)
            {
                ds1.AcceptChanges();
                DataRow[] ra = ds1.Tables[0].Select("tylekhuyenmai <> tylekhuyenmai_old");
                string iddot = txtIDKM.Text;
                foreach (DataRow r in ds1.Tables[0].Select("tylekhuyenmai <> tylekhuyenmai_old"))
                {
                    if (updGiaVP == 0)
                    {
                        upd_v_giavp_khuyenmai(iddot, r["id"].ToString(), r["tylekhuyenmai"].ToString(), r["sotienkhuyenmai"].ToString(), m_userid, true);
                    }
                    else
                    {
                        upd_v_giavp_khuyenmai(iddot, r["id"].ToString(), r["tylekhuyenmai"].ToString(), r["sotienkhuyenmai"].ToString(), m_userid, false);
                    }
                }
            }
            f_Load_DG();
            ds.AcceptChanges();
            txtTim_TextChanged(null, null);
            f_Enable(false);

        }
        private void upd_v_giavp_khuyenmai( string iddot,string idvp, string tile, string sotien,string userid,bool updGiaVP )
        {
            DataSet ds1 = m_v.get_data("select * from medibv.v_giavp_khuyenmai where iddot="+iddot+" and idvp="+idvp);
            if (ds1.Tables[0].Rows.Count == 0)
            {
                try
                {
                    m_v.execute_data("insert into medibv.v_giavp_khuyenmai values (" + iddot + "," + idvp + "," + tile + "," + sotien + "," + userid + ",to_date('" + m_v.s_curddmmyy + "','ddmmyy'))");
                    if (updGiaVP)
                    {
                        m_v.execute_data("update medibv.v_giavp set tylekhuyenmai = " + tile + " where id=" + idvp);
                    }
                }
                catch { }
            }
            else
            {
                m_v.execute_data("update medibv.v_giavp_khuyenmai set tylekhuyenmai=" + tile + ", sotienkhuyenmai=" + sotien + " where iddot=" + iddot + " and idvp=" + idvp);
                if (updGiaVP)
                {
                    m_v.execute_data("update medibv.v_giavp set tylekhuyenmai = " + tile + " where id=" + idvp );
                }
            }
            
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

        private void txtGia_dv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtGia_nn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtBHYT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)  SendKeys.Send("{Tab}{F4}");
        }

        

        private void txtVattu_bh_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Enter)  SendKeys.Send("{Tab}");
        }

        private void txtVattu_dv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtVattu_nn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkTrongoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)  SendKeys.Send("{Tab}{F4}");
        }

        private void cbNhombhyt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)  SendKeys.Send("{Tab}{F4}");
        }

        private void cbNhomvp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)   SendKeys.Send("{Tab}{F4}");
        }

        private void cbLoaivp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)   SendKeys.Send("{Tab}{F4}");
        }

        private void cbLoaibn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkTheobs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkNDM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkReadonly_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");// butLuu.Focus();
                }
            }
            catch
            {
            }
        }

        private void chkChenhlech_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkThuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

   

        private void txtGia_cs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtVattu_cs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtLocthe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

      

 
 

        private void DataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            DG = 1;
            f_load_GridView();
          
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;

            if (msg.Msg == WM_KEYDOWN)
            {
                try
                {
                    string id = int.Parse(txtIDKM.Text).ToString();
                    cbKM.ComboBox.SelectedValue = id;
                }
                catch { }
                if (keyData == Keys.Enter)
                {


                    // decimal tile = decimal.Parse(ds.Tables[0].Rows[DataGrid1.CurrentCell.RowNumber][5].ToString());


                    //decimal dongia = decimal.Parse(ds.Tables[0].Rows[DataGrid1.CurrentCell.RowNumber][8].ToString());

                    if (DataGrid1.CurrentCell.ColumnNumber == 6)
                    {

                        ds.AcceptChanges();
                        DataGrid1.Refresh();
                        int ir = DataGrid1.CurrentCell.RowNumber;
                        int ic = DataGrid1.CurrentCell.ColumnNumber;
                        decimal dongia = decimal.Parse(DataGrid1[ir, 5].ToString());
                        decimal dcell = decimal.Parse(DataGrid1[ir, ic].ToString());
                        decimal tile = decimal.Parse(DataGrid1[ir, 6].ToString());
                        if (dongia == 0)
                        {
                            DataGrid1[ir, ic] = 0;
                            return false;
                        }

                        if (!kt_TiLe(tile))
                        {
                            DataGrid1[ir, ic] = 0;
                            DataGrid1.CurrentCell = new DataGridCell(DataGrid1.CurrentCell.RowNumber, DataGrid1.CurrentCell.ColumnNumber);
                            return false;
                        }
                        else
                        {
                            DataGrid1[DataGrid1.CurrentCell.RowNumber, 7] = TinhTienKm(tile, dongia);
                            DataGrid1.CurrentCell = new DataGridCell(DataGrid1.CurrentCell.RowNumber, 7);
                        }

                    }
                    if (DataGrid1.CurrentCell.ColumnNumber == 7)
                    {
                        ds.AcceptChanges();
                        DataGrid1.Refresh();
                        try
                        {
                            int ir = DataGrid1.CurrentCell.RowNumber;
                            int ic = DataGrid1.CurrentCell.ColumnNumber;
                            decimal dongia = decimal.Parse(DataGrid1[ir, 5].ToString());
                            decimal dcell = decimal.Parse(DataGrid1[ir, ic].ToString());
                            decimal tile = decimal.Parse(DataGrid1[ir, 6].ToString());
                            if (dongia == 0)
                            {
                                DataGrid1[ir, ic] = 0;
                                return false;
                            }
                            if (dcell > dongia || dcell < 0)
                            {
                                return false;
                            }
                            else
                            {
                                DataGrid1[DataGrid1.CurrentCell.RowNumber, 6] = (dcell / dongia) * 100;
                            }
                        }
                        catch { }

                    }
                    //xử lý cho datagrid2

                    if (dataGrid2.CurrentCell.ColumnNumber == 5)
                    {

                        ds1.AcceptChanges();
                        dataGrid2.Refresh();
                        int ir = dataGrid2.CurrentCell.RowNumber;
                        int ic = dataGrid2.CurrentCell.ColumnNumber;
                        decimal dongia = 0, dcell = 0, tile = 0;
                        try
                        {
                            dongia = decimal.Parse(dataGrid2[ir, 4].ToString());
                            dcell = decimal.Parse(dataGrid2[ir, ic].ToString());
                            tile = decimal.Parse(dataGrid2[ir, 5].ToString());
                        }
                        catch 
                        {
                            cbKM_SelectedIndexChanged(null, null);
                            //ds1.Reset();
                            //dataGrid2[ir, 5] = 0;
                            //dataGrid2[ir, 6] = 0;
                        }
                        if (dongia == 0)
                        {
                            DataGrid1[ir, ic] = 0;
                            return false;
                        }
                        if (!kt_TiLe(tile))
                        {
                            dataGrid2[ir, ic] = 0;
                            dataGrid2.CurrentCell = new DataGridCell(dataGrid2.CurrentCell.RowNumber, dataGrid2.CurrentCell.ColumnNumber);
                            return false;
                        }
                        else
                        {
                            dataGrid2[dataGrid2.CurrentCell.RowNumber, 6] = TinhTienKm(tile, dongia);
                            dataGrid2.CurrentCell = new DataGridCell(DataGrid1.CurrentCell.RowNumber, 6);
                        }

                    }
                    if (dataGrid2.CurrentCell.ColumnNumber == 6)
                    {
                        ds1.AcceptChanges();
                        dataGrid2.Refresh();
                        try
                        {
                            int ir = dataGrid2.CurrentCell.RowNumber;
                            int ic = dataGrid2.CurrentCell.ColumnNumber;
                            decimal dongia = decimal.Parse(dataGrid2[ir, 4].ToString());
                            decimal dcell = decimal.Parse(dataGrid2[ir, ic].ToString());
                            decimal tile = decimal.Parse(dataGrid2[ir, 5].ToString());
                            if (dongia == 0)
                            {
                                DataGrid1[ir, ic] = 0;
                                return false;
                            }
                            if (dcell > dongia || dcell < 0)
                            {
                                return false;
                            }
                            else
                            {
                                dataGrid2[dataGrid2.CurrentCell.RowNumber, 5] = (dcell / dongia) * 100;
                            }
                        }
                        catch { }

                    }


                    // end datagrid2

                    return true;   //disable the following delete function
                }

               
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private bool kt_TiLe( decimal tile)
        {
            if (tile < 0 || tile > 100)
            {
                return false;
            }
            return true;
        }

        private decimal TinhTienKm( decimal tile , decimal dongia)
        {
            return (dongia * (tile / 100));
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

        private void txtsothe_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter) butLuu.Focus();// SendKeys.Send("{Tab}{F4}");
            }
            catch { }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void cbKM_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIDKM.Text = cbKM.ComboBox.SelectedValue.ToString();
            txtTimKM.Text = "";
            f_Load_DG2();
        }

        private void DataGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)// SendKeys.Send("{Tab}{F4}");
                {
                    SendKeys.Send("{Tab}");
                    
                }
            }
            catch { }
        }

        private void DataGrid1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void frmGiavpKhuyenMai_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void txtTimKM_TextChanged(object sender, EventArgs e)
        {
            string iddot = txtIDKM.Text;
            try
            {
                string aft = "";
                if (txtTimKM.Text != "")
                {
                    aft = "(ma like '%" + txtTimKM.Text.Replace("'", "''") + "%' or tenvp like '%" + txtTimKM.Text.Replace("'", "''") + "%' )";
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[dataGrid2.DataSource, dataGrid2.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = aft;
                lbTitle.Text = "Giá viện phí khuyến mãi (" + dv.Table.Select(aft).Length.ToString() + "/" + dv.Table.Rows.Count.ToString() + ")";
            }
            catch
            {
                lbTitle.Text = "Giá viện phí khuyến mãi";
            }
        }

        private void dataGrid2_CurrentCellChanged(object sender, EventArgs e)
        {
            DG = 2;
        }

        private void frmGiavpKhuyenMai_Load(object sender, EventArgs e)
        {
            bKhoan = m.bKhoan_vtth; user = m.user;
            itable = m_v.tableid("", "v_giavp");
            this.DataGrid1.KeyDown += new KeyEventHandler(this.DataGrid1_KeyDown);
            f_Load_CB();
            f_Load_DG();
            f_Load_Tree();
            f_Enable(false);
            this.WindowState = FormWindowState.Maximized;
            this.Refresh();
            if ((m_v.get_data("select * from medibv.v_dot_khuyenmai")).Tables[0].Rows.Count == 0)
            {
                 toolStripLabel4_Click(sender,e);
            }
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            frmDotKhuyenMai af = new frmDotKhuyenMai(m_v,m_userid);
            af.ShowInTaskbar = false;
            af.ShowDialog(this);
            f_Load_DG();
            f_Load_CB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f_In(cbKM.ComboBox.SelectedValue.ToString());
        }
        private void f_In(string iddot)
        {
            try
            {
                DataSet ads = new DataSet();
                string sql = "";
                sql = "select a.ten as tendot,a.tungay,a.denngay,a.tugio,a.dengio,a.hide,c.ten as tenvp,b.tylekhuyenmai,b.sotienkhuyenmai from medibv.v_dot_khuyenmai a inner join medibv.v_giavp_khuyenmai b on a.id=b.iddot inner join medibv.v_giavp c on b.idvp=c.id where a.id="+iddot+" order by c.ten";
                ads = m_v.get_data(sql);
                //ads.WriteXml("..//..//Datareport//v_dotkm.xml", XmlWriteMode.WriteSchema);
                //return;

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
                crystalReportViewer1.BringToFront();
                crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;

                string areport = "v_2007_giavpkm.rpt";
                ReportDocument cMain = new ReportDocument();
                cMain.Load("..\\..\\..\\report\\" + areport, OpenReportMethod.OpenReportByTempCopy);
                cMain.SetDataSource(ads);
                cMain.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                cMain.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                crystalReportViewer1.ReportSource = cMain;
                af.Text = "Giá viện phí khuyến mãi";
                af.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtIDKM_Click(object sender, EventArgs e)
        {
            
        }

        private void txtIDKM_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

       
       
    }
}