﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibDuoc;
namespace Medisoft
{
    public partial class frmDutrucstt : Form
    {
        private Language lan = new Language();
        private string format_soluong;
        private int i_nhom;
        private string s_ngay;
        //private DateTime d_ngay;
        private AccessData d;
        private string user, usermmyy;
        private DataTable dtct, dtphanloai, dtdmkho;
        private DataSet dsxml = new DataSet();
        private string s_tenkho, sql, s_mmyy, s_tenkhoa;
        int i_makho = 0, i_makp = 0, i_matutruc = 0;
        private decimal l_id = 0;
        private int i_manguon, i_userid;
        private bool bNew = false;
        public frmDutrucstt(AccessData acc, string _ngay, int _makho, string _tenkho, int manguon, int nhom, string mmyy, int _userid, int _makp, int _matutruc, string _tenkhoa)
        {
            InitializeComponent();
            this.s_ngay = _ngay;
            this.d = acc;
            i_makho = _makho;
            s_tenkho = _tenkho;
            i_manguon = manguon;
            i_nhom = nhom;
            s_mmyy = mmyy;
            //d_ngay = _ngay;
            i_userid = _userid;
            i_makp = _makp;
            i_matutruc = _matutruc;
            s_tenkhoa = _tenkhoa;
        }
        private void AddGridTableStyle()
        {
            DataGridColoredTextBoxColumn TextCol1;
            delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.RowHeaderWidth = 10;
            ts.MappingName = dtct.TableName;

            TextCol1 = new DataGridColoredTextBoxColumn(de, 0);
            TextCol1.MappingName = "tenhc";
            TextCol1.HeaderText = "Hoạt chất";
            TextCol1.Width = 120;
            TextCol1.NullText = string.Empty;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 1);
            TextCol1.MappingName = "mabd";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 2);
            TextCol1.MappingName = "ma";
            TextCol1.HeaderText = "Mã";
            TextCol1.Width = 60;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 3);
            TextCol1.MappingName = "ten";
            TextCol1.HeaderText = "Tên thuốc - hàm lượng";
            TextCol1.Width = 200;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 4);
            TextCol1.MappingName = "donvi";
            TextCol1.HeaderText = "Đóng gói";
            TextCol1.Width = 60;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 5);
            TextCol1.MappingName = "dang";
            TextCol1.HeaderText = "ĐVT";
            TextCol1.Width = 40;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 6);
            TextCol1.MappingName = "tenhang";
            TextCol1.HeaderText = "Hãng SX";
            TextCol1.Width = 100;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 7);
            TextCol1.MappingName = "nhacc";
            TextCol1.HeaderText = "Nhà cung cấp";
            TextCol1.Width = 200;
            TextCol1.ReadOnly = true;
            TextCol1.NullText = "";
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            //TextCol1 = new DataGridColoredTextBoxColumn(de, 8);
            //TextCol1.MappingName = "xuat10";
            //TextCol1.HeaderText = "Sử dụng(-10)";
            //TextCol1.Width = 75;
            //TextCol1.ReadOnly = true;
            //TextCol1.Format = format_soluong;
            //TextCol1.NullText = "0";
            //TextCol1.Alignment = HorizontalAlignment.Right;
            //ts.GridColumnStyles.Add(TextCol1);
            //dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 9);
            TextCol1.MappingName = "csduyet";
            TextCol1.HeaderText = "Cơ số quy định";
            TextCol1.Width = 75;
            TextCol1.ReadOnly = true;
            TextCol1.NullText = "0.00";
            TextCol1.Format = format_soluong;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 10);
            TextCol1.MappingName = "slton";
            TextCol1.HeaderText = "Tồn";
            TextCol1.Width = 60;
            TextCol1.ReadOnly = true;
            TextCol1.NullText = "0.00";
            TextCol1.Format = format_soluong;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            //TextCol1 = new DataGridColoredTextBoxColumn(de, 11);
            //TextCol1.MappingName = "slgoiy";
            //TextCol1.HeaderText = "SL gợi ý";
            //TextCol1.Width = 60;
            //TextCol1.ReadOnly = true;
            //TextCol1.NullText = "0";
            //TextCol1.Format = format_soluong;
            //TextCol1.Alignment = HorizontalAlignment.Right;
            //ts.GridColumnStyles.Add(TextCol1);
            //dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 12);
            TextCol1.MappingName = "soluong";
            TextCol1.HeaderText = "Dự trù ";
            TextCol1.Width = 60;
            TextCol1.NullText = "0.00";
            TextCol1.Format = format_soluong;
            //TextCol1.ReadOnly = bDutru_Readonly;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 13);
            TextCol1.MappingName = "lydo";
            TextCol1.HeaderText = "Ghi chú";
            TextCol1.Width = 60;
            TextCol1.NullText = "";
            //TextCol1.ReadOnly = !bDutru_Readonly;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 14);
            TextCol1.MappingName = "id";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);
        }
        #region delegate
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
                    foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
                    //backBrush = new SolidBrush(Color.GhostWhite);
                }

                catch { }
                finally
                {
                    base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
                }
            }
        }
        public Color MyGetColorRowCol(int row, int col)
        {
            // if (dataGrid1[row, 13].ToString().Trim() != "") return Color.Red;
            return Color.Black;
        }
        #endregion
        private void frmDutruThuocKho_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            user = d.user;
            usermmyy = user + s_mmyy;
            format_soluong = d.format_soluong(i_nhom);
            ngaysp.Text = s_ngay;
            txtTitle.Text = s_tenkho;
            txtKhoa.Text = s_tenkhoa;
            cmbSophieu.DisplayMember = "SOPHIEU";
            cmbSophieu.ValueMember = "ID";
            load_grid(true);
            AddGridTableStyle();
            load_phieu();
            this.WindowState = FormWindowState.Maximized;
        }
        private void load_grid()
        {
            d.get_nhap_denngay(ref dsxml, dtphanloai, dtdmkho, s_mmyy, s_ngay, i_nhom, false, false, false, true, i_makho.ToString(), "", "", i_manguon, "");
        }
        /// <summary>
        /// Load lên lưới các thông tin cần xem.
        /// </summary>
        /// <param name="edit"></param>
        private void load_grid(bool edit)
        {
            if (edit)
            {
                // load thuoc da du tru
                sql = "select distinct b.ma,b.id as mabd1 ,trim(b.ten)||' '||b.hamluong as ten,b.hamluong,g.ten as nsx,b.dang,c.stt as sttnhom,c.ten as tennhom,d.ten as tenhang,";
                sql += "b.sltoithieu, b.tenhc,a.*,a.soluong as slcu ";
                sql += " from " + user + ".d_dutrucsttct a," + user + ".d_dutrucsttll f," + user + ".d_dmbd b," + user + ".d_dmnhom c," + user + ".d_dmhang d," + user + ".d_dmkho e," + user + ".d_dmnx g ";
                sql += " where a.mabd=b.id and b.manhom=c.id and b.mahang=d.id and e.id=f.makho and a.id=f.id and g.id=b.madv and f.nhom=" + i_nhom;
                sql += " and a.id=" + l_id;
                sql += " and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                if (!butLuu.Enabled) sql += " and a.soluong >0 ";
                sql += " order by c.stt,b.ma";
                dtct = d.get_data(sql).Tables[0];
            }
            else
            {
                sql = "select distinct b.ma,b.id as mabd1 ,trim(b.ten)||' '||b.hamluong as ten,b.hamluong,g.ten as nsx,b.dang,c.stt as sttnhom,c.ten as tennhom,d.ten as tenhang,";
                sql += "b.sltoithieu, b.tenhc ";
                sql += " from " + user + ".d_cosotutruc a," + user + ".d_dmbd b," + user + ".d_dmnhom c," + user + ".d_dmhang d,"+user+".d_dmnx g ";
                sql += " where a.mabd=b.id and b.manhom=c.id and b.mahang=d.id and g.id=b.madv and a.makp=" + i_makp;
                sql += " order by c.stt,b.ma";
                dtct = d.get_data(sql).Tables[0];
                DataTable tmp = d.get_data("select a.*,a.soluong as slcu from " + user + ".d_dutrucsttct a where 1=0").Tables[0];
                for (int i = 0; i < tmp.Columns.Count; i++)
                {
                    try
                    {
                        dtct.Columns.Add(tmp.Columns[i].ColumnName, Type.GetType(tmp.Columns[i].DataType.ToString()));
                    }
                    catch { }
                }
                if (!bNew)// xet truong hop sua
                {
                    sql = " select a.*,a.soluong as slcu from " + user + ".d_dutrucsttct a," + user + ".d_dutrucsttll b where a.id=b.id ";
                    sql += " and b.nhom=" + i_nhom;
                    sql += " and a.id=" + l_id;
                    DataTable tmp1 = d.get_data(sql).Tables[0];
                    for (int i = 0; i < tmp1.Rows.Count; i++)
                    {
                        DataRow row = d.getrowbyid(dtct, "mabd1=" + tmp1.Rows[i]["mabd"].ToString());
                        if (row != null)
                        {
                            for (int j = 0; j < tmp1.Columns.Count; j++)
                            {
                                row[tmp1.Columns[j].ColumnName] = tmp1.Rows[i][tmp1.Columns[j].ColumnName].ToString();
                            }
                        }
                    }
                }
                //else
                {
                    get_tonkho();
                    get_nhap_den_ngay(s_ngay, i_makho.ToString());
                    get_xuat_den_ngay(s_ngay, i_makho.ToString());
                    get_cosotutruc();
                    //get_xuat(s_mmyy, d_ngay.AddDays(-10).ToString("dd/MM/yyyy"), d_ngay.ToString("dd/MM/yyyy"), "xuat10");
                    //get_xuat(s_mmyy, d_ngay.AddDays(-30).ToString("dd/MM/yyyy"), d_ngay.ToString("dd/MM/yyyy"), "xuat30");
                    //get_slgoiy();
                }
                foreach (DataRow row in dtct.Select("soluong<>slcu"))
                {
                    row["soluong"] = row["slcu"].ToString();
                }
            }
            dataGrid1.DataSource = dtct;
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
            DataView dv = (DataView)cm.List;
            dv.AllowDelete = false;
            dv.AllowNew = false;
        }
        #region bo
        //private void get_xuat_den_ngay(string s_ngay, string s_makho)
        //{
        //    string xxx = user + s_mmyy;
        //    if (!d.bMmyy(s_mmyy)) return;
        //    sql = "select b.mabd,d.manguon,sum(b.soluong) as soluong,0 as manhacc, null as tennhacc,b.makho ";
        //    sql += " from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b,medibv.d_dmbd c," + xxx + ".d_theodoi d ";
        //    sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.loai in(1,4) and a.nhom=1 and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_ngay + "','dd/mm/yyyy') ";
        //    sql += " and b.makho in (" + s_makho + ") and b.soluong>0 ";
        //    sql += " group by b.mabd,d.manguon,b.makho";
        //    sql += " union all ";
        //    sql += " select b.mabd,d.manguon,sum(b.soluong) as soluong, 0 as manhacc, null as tennhacc,b.makho ";
        //    sql += " from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucbucstt b,medibv.d_dmbd c," + xxx + ".d_theodoi d  ";
        //    sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.loai in(2) and a.nhom=1 and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_ngay + "','dd/mm/yyyy')  ";
        //    sql += " and b.makho in (" + s_makho + ") and b.soluong>0 ";
        //    sql += " group by b.mabd,d.manguon,b.makho ";
        //    sql += " union all ";
        //    sql += " select b.mabd,d.manguon,sum(b.soluong) as soluong, 0 as manhacc, null as tennhacc,a.khox as makho ";
        //    sql += " from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b,medibv.d_dmbd c," + xxx + ".d_theodoi d  ";
        //    sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=1 and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_ngay + "','dd/mm/yyyy')  ";
        //    sql += " and a.loai in ('BS','XK') and a.khox in (" + s_makho + ") and b.soluong>0 ";
        //    sql += " group by b.mabd,d.manguon,a.khox";
        //    sql += " union all ";
        //    sql += " select b.mabd, d.manguon,sum(b.soluong) as soluong, 0 as manhacc, null as tennhacc,b.makho ";
        //    sql += " from " + xxx + ".bhytkb a," + xxx + ".bhytthuoc b,medibv.d_dmbd c," + xxx + ".d_theodoi d  where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=1 ";
        //    sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_ngay + "','dd/mm/yyyy') and b.makho in (" + s_makho + ") and b.soluong>0 ";
        //    sql += " group by b.mabd,d.manguon,b.makho ";
        //    sql += " union all ";
        //    sql += " select b.mabd,d.manguon,sum(b.soluong) as soluong, 0 as manhacc, null as tennhacc,b.makho  ";
        //    sql += " from " + xxx + ".d_ngtrull a," + xxx + ".d_ngtruct b,medibv.d_dmbd c," + xxx + ".d_theodoi d  ";
        //    sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=1 and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_ngay + "','dd/mm/yyyy')  ";
        //    sql += " and b.makho in (" + s_makho + ") and b.soluong>0 ";
        //    sql += " group by b.mabd,d.manguon,b.makho";
        //    foreach (DataRow row in d.get_data(sql).Tables[0].Rows)
        //    {
        //        sql = "mabd1=" + int.Parse(row["mabd"].ToString());
        //        DataRow r1 = d.getrowbyid(dtct, sql);
        //        if (r1 != null)
        //        {
        //            DataRow[] dr = dtct.Select(sql);
        //            dr[0]["slton"] = decimal.Parse(dr[0]["slton"].ToString() == "" ? "0" : dr[0]["slton"].ToString()) - decimal.Parse(row["soluong"].ToString());
        //        }
        //    }
        //}
        //private void get_nhap_den_ngay(string s_ngay, string s_makho)
        //{
        //    string xxx = d.user + s_mmyy;
        //    if (!d.bMmyy(s_mmyy)) return;
        //    sql = "select b.mabd,a.manguon,sum(b.soluong) as soluong, 0 as manhacc, null as tennhacc,a.makho ";
        //    sql += " from " + xxx + ".d_nhapll a," + xxx + ".d_nhapct b,medibv.d_dmbd c ";
        //    sql += " where a.id=b.id and b.mabd=c.id and a.nhom=1  and b.soluong>0";
        //    sql += " and to_date(to_char(a.ngaysp,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + s_ngay + "','dd/mm/yyyy') ";
        //    sql += " and a.makho in (" + s_makho + ") ";
        //    sql += " group by b.mabd,a.manguon,a.makho";
        //    sql += " union all ";
        //    sql += " select b.mabd, d.manguon,sum(b.soluong) as soluong, 0 as manhacc, null as tennhacc,a.khon as makho ";
        //    sql += " from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, medibv.d_dmbd c," + xxx + ".d_theodoi d  ";
        //    sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=1 and a.loai in ('CK') and b.soluong>0 ";
        //    sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + s_ngay + "','dd/mm/yyyy') ";
        //    sql += " and a.khon in (" + s_makho + ") and a.khox not in (" + s_makho + ") ";
        //    sql += " group by b.mabd,d.manguon,a.khon ";
        //    foreach (DataRow row in d.get_data(sql).Tables[0].Rows)
        //    {
        //        sql = "mabd1=" + int.Parse(row["mabd"].ToString());
        //        DataRow r1 = d.getrowbyid(dtct, sql);
        //        if (r1 != null)
        //        {
        //            DataRow[] dr = dtct.Select(sql);
        //            dr[0]["slton"] = decimal.Parse(dr[0]["slton"].ToString() == "" ? "0" : dr[0]["slton"].ToString()) + decimal.Parse(row["soluong"].ToString());
        //        }
        //    }
        //}
#endregion
        private void get_cosotutruc()
        {
            sql = "select * from " + user + ".d_cosotutruc ";
            sql += " where nhom='" + i_nhom + "'";
            sql += " and makp=" + i_matutruc + "";
            foreach (DataRow row in d.get_data(sql).Tables[0].Rows)
            {
                DataRow r = d.getrowbyid(dtct, "mabd1=" + row["mabd"].ToString());
                if (r != null)
                {
                    r["csduyet"] = decimal.Parse(row["soluong"].ToString());
                }
            }
        }
        /// <summary>
        /// Load những phiếu được nhập trong ngày.
        /// </summary>
        private void load_phieu()
        {
            cmbSophieu.DataSource = d.get_data("select * from " + user + ".d_dutrucsttll where to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "'" +
                " and makho=" + i_makho + " and makp=" + i_makp + "and matutruc=" + i_matutruc + " order by to_char(ngay,'dd/mm/yyyy') desc").Tables[0];
        }
        /// <summary>
        /// tồn kho chi tiết.
        /// </summary>
        private void get_tonkho()
        {
            if (!d.bMmyy(s_mmyy)) return;
            sql = "select a.makho,a.mabd,sum(a.tondau) as ton from " + usermmyy + ".d_tutructh a";
            sql += " where a.makp=" + i_matutruc;
            sql += " and a.makho=" + i_makho;
            if (i_manguon != -1) sql += " and a.manguon=" + i_manguon;
            sql += " group by a.makho,a.mabd";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                sql = "mabd1=" + int.Parse(r["mabd"].ToString());
                DataRow r1 = d.getrowbyid(dtct, sql);
                if (r1 != null)
                {
                    DataRow[] dr = dtct.Select(sql);
                    dr[0]["slton"] = decimal.Parse(dr[0]["slton"].ToString() == "" ? "0" : dr[0]["slton"].ToString()) + decimal.Parse(r["ton"].ToString());
                }
            }
        }
        private void get_xuat_den_ngay(string s_ngay, string s_makho)
        {
            string xxx = user + s_mmyy;
            if (!d.bMmyy(s_mmyy)) return;
            sql = "select b.mabd,d.manguon,sum(b.soluong) as soluong,0 as manhacc, null as tennhacc,b.makho ";
            sql += " from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.loai in(1,4) and a.nhom=1 and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_ngay + "','dd/mm/yyyy') ";
            sql += " and b.makho in (" + s_makho + ") and b.soluong>0 ";
            sql += " group by b.mabd,d.manguon,b.makho";
            sql += " union all ";
            sql += " select b.mabd,d.manguon,sum(b.soluong) as soluong, 0 as manhacc, null as tennhacc,b.makho ";
            sql += " from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucbucstt b," + user + ".d_dmbd c," + xxx + ".d_theodoi d  ";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.loai in(2) and a.nhom=1 and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_ngay + "','dd/mm/yyyy')  ";
            sql += " and b.makho in (" + s_makho + ") and b.soluong>0 ";
            sql += " group by b.mabd,d.manguon,b.makho ";
            sql += " union all ";
            sql += " select b.mabd,d.manguon,sum(b.soluong) as soluong, 0 as manhacc, null as tennhacc,a.khox as makho ";
            sql += " from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + user + ".d_dmbd c," + xxx + ".d_theodoi d  ";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=1 and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_ngay + "','dd/mm/yyyy')  ";
            sql += " and a.loai in ('BS','XK') and a.khox in (" + s_makho + ") and b.soluong>0 ";
            sql += " group by b.mabd,d.manguon,a.khox";
            sql += " union all ";
            sql += " select b.mabd, d.manguon,sum(b.soluong) as soluong, 0 as manhacc, null as tennhacc,b.makho ";
            sql += " from " + xxx + ".bhytkb a," + xxx + ".bhytthuoc b," + user + ".d_dmbd c," + xxx + ".d_theodoi d  where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=1 ";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_ngay + "','dd/mm/yyyy') and b.makho in (" + s_makho + ") and b.soluong>0 ";
            sql += " group by b.mabd,d.manguon,b.makho ";
            sql += " union all ";
            sql += " select b.mabd,d.manguon,sum(b.soluong) as soluong, 0 as manhacc, null as tennhacc,b.makho  ";
            sql += " from " + xxx + ".d_ngtrull a," + xxx + ".d_ngtruct b," + user + ".d_dmbd c," + xxx + ".d_theodoi d  ";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=1 and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_ngay + "','dd/mm/yyyy')  ";
            sql += " and b.makho in (" + s_makho + ") and b.soluong>0 ";
            sql += " group by b.mabd,d.manguon,b.makho";
            foreach (DataRow row in d.get_data(sql).Tables[0].Rows)
            {
                sql = "mabd1=" + int.Parse(row["mabd"].ToString());
                DataRow r1 = d.getrowbyid(dtct, sql);
                if (r1 != null)
                {
                    DataRow[] dr = dtct.Select(sql);
                    dr[0]["slton"] = decimal.Parse(dr[0]["slton"].ToString() == "" ? "0" : dr[0]["slton"].ToString()) - decimal.Parse(row["soluong"].ToString());
                }
            }
        }
        private void get_nhap_den_ngay(string s_ngay, string s_makho)
        {
            string xxx = d.user + s_mmyy;
            if (!d.bMmyy(s_mmyy)) return;
            sql = "select b.mabd,a.manguon,sum(b.soluong) as soluong, 0 as manhacc, null as tennhacc,a.makho ";
            sql += " from " + xxx + ".d_nhapll a," + xxx + ".d_nhapct b," + user + ".d_dmbd c ";
            sql += " where a.id=b.id and b.mabd=c.id and a.nhom=1  and b.soluong>0";
            sql += " and to_date(to_char(a.ngaysp,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + s_ngay + "','dd/mm/yyyy') ";
            sql += " and a.makho in (" + s_makho + ") ";
            sql += " group by b.mabd,a.manguon,a.makho";
            sql += " union all ";
            sql += " select b.mabd, d.manguon,sum(b.soluong) as soluong, 0 as manhacc, null as tennhacc,a.khon as makho ";
            sql += " from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d  ";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=1 and a.loai in ('CK') and b.soluong>0 ";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + s_ngay + "','dd/mm/yyyy') ";
            sql += " and a.khon in (" + s_makho + ") and a.khox not in (" + s_makho + ") ";
            sql += " group by b.mabd,d.manguon,a.khon ";
            foreach (DataRow row in d.get_data(sql).Tables[0].Rows)
            {
                sql = "mabd1=" + int.Parse(row["mabd"].ToString());
                DataRow r1 = d.getrowbyid(dtct, sql);
                if (r1 != null)
                {
                    DataRow[] dr = dtct.Select(sql);
                    dr[0]["slton"] = decimal.Parse(dr[0]["slton"].ToString() == "" ? "0" : dr[0]["slton"].ToString()) + decimal.Parse(row["soluong"].ToString());
                }
            }
            sql = " select b.mabd, d.manguon,sum(b.soluong) as soluong,0 as manhacc, null as tennhacc,a.khon as makho ";
            sql += " from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, " + user + ".d_dmbd c," + user + "0711.d_theodoi d  where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=1 ";
            sql += " and a.loai in ('TH','HT') and b.soluong>0 and a.khon in (" + s_makho + ") ";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + s_ngay + "','dd/mm/yyyy')";
            sql += " group by b.mabd,d.manguon,a.khon";
            foreach (DataRow row in d.get_data(sql).Tables[0].Rows)
            {
                sql = "mabd1=" + int.Parse(row["mabd"].ToString());
                DataRow r1 = d.getrowbyid(dtct, sql);
                if (r1 != null)
                {
                    DataRow[] dr = dtct.Select(sql);
                    dr[0]["slton"] = decimal.Parse(dr[0]["slton"].ToString() == "" ? "0" : dr[0]["slton"].ToString()) + decimal.Parse(row["soluong"].ToString());
                }
            }
        }
        /// <summary>
        /// Lấy số lượng xuất theo ngày.
        /// </summary>
        /// <param name="s_mmyyt"></param>
        /// <param name="s_tu"></param>
        /// <param name="s_den"></param>
        /// <param name="field"></param>
        private void get_xuat(string s_mmyyt, string s_tu, string s_den, string field)
        {
            if (!d.bMmyy(s_mmyyt)) return;
            string xxxt = user + s_mmyyt;
            sql = "select a.khox as makho,b.mabd,sum(b.soluong) as soluong from " + xxxt + ".d_xuatll a," + xxxt + ".d_xuatct b," + xxxt + ".d_theodoi t";
            sql += " ," + user + ".d_dmbd c," + user + ".d_dmnhom d ";
            sql += " where a.id=b.id and a.loai='XK' and b.sttt=t.id ";
            sql += " and a.khox in (" + i_makho.ToString() + ") ";

            sql += " and b.mabd=c.id and c.manhom=d.id ";
            // if (s_dutrunam != "" && s_dutrunam != null) sql += " and d.nhomin in (" + s_dutrunam + ")";
            if (i_manguon != -1) sql += " and t.manguon=" + i_manguon;
            if (s_den != "" && s_tu != "")
                sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy') ";
            sql += " group by a.khox,b.mabd";
            sql += " union all ";
            sql += "select b.makho,b.mabd,sum(b.soluong) as soluong from " + xxxt + ".d_ngtrull a," + xxxt + ".d_ngtruct b," + xxxt + ".d_theodoi t";
            sql += " ," + user + ".d_dmbd c," + user + ".d_dmnhom d ";
            sql += " where a.id=b.id and b.sttt=t.id ";
            sql += " and b.makho in (" + i_makho + ") ";
            sql += " and b.mabd=c.id and c.manhom=d.id ";
            // if (s_dutrunam != "" && s_dutrunam != null) sql += " and d.nhomin in (" + s_dutrunam + ")";
            if (i_manguon != -1) sql += " and t.manguon=" + i_manguon;
            if (s_den != "" && s_tu != "")
                sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy') ";
            sql += " group by b.makho,b.mabd";
            sql += " union all ";
            sql += "select b.makho,b.mabd,sum(b.soluong) as soluong from " + xxxt + ".bhytkb a," + xxxt + ".bhytthuoc b," + xxxt + ".d_theodoi t";
            sql += " ," + user + ".d_dmbd c," + user + ".d_dmnhom d ";
            sql += " where a.id=b.id and b.sttt=t.id ";
            sql += " and b.makho in (" + i_makho + ") ";
            sql += " and b.mabd=c.id and c.manhom=d.id ";
            //if (s_dutrunam != "" && s_dutrunam != null) sql += " and d.nhomin in (" + s_dutrunam + ")";
            if (i_manguon != -1) sql += " and t.manguon=" + i_manguon;
            if (s_den != "" && s_tu != "")
                sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy') ";
            sql += " group by b.makho,b.mabd";
            sql += " union all ";
            // Lấy số lượng dự trù thuốc của bệnh nhân nội trú.
            sql += "select b.makho,b.mabd,sum(b.soluong) as soluong from " + xxxt + ".d_xuatsdll a," + xxxt + ".d_thucxuat b," + xxxt + ".d_theodoi t";
            sql += " ," + user + ".d_dmbd c," + user + ".d_dmnhom d ";
            sql += " where a.id=b.id and a.loai in (1,4) and b.sttt=t.id ";
            sql += " and b.makho in (" + i_makho + ") ";
            sql += " and b.mabd=c.id and c.manhom=d.id ";
            //if (s_dutrunam != "" && s_dutrunam != null) sql += " and d.nhomin in (" + s_dutrunam + ")";
            if (i_manguon != -1) sql += " and t.manguon=" + i_manguon;
            if (s_den != "" && s_tu != "")
                sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy') ";
            sql += " group by b.makho,b.mabd";
            sql += " union all ";
            // Lấy số lượng hoàn trả.
            sql += "select b.makho,b.mabd,-sum(b.soluong) as soluong from " + xxxt + ".d_xuatsdll a," + xxxt + ".d_thucxuat b," + xxxt + ".d_theodoi t";
            sql += " ," + user + ".d_dmbd c," + user + ".d_dmnhom d ";
            sql += " where a.id=b.id and a.loai in (3) and b.sttt=t.id ";
            sql += " and b.makho in (" + i_makho + ") ";
            sql += " and b.mabd=c.id and c.manhom=d.id ";
            //if (s_dutrunam != "" && s_dutrunam != null) sql += " and d.nhomin in (" + s_dutrunam + ")";
            if (i_manguon != -1) sql += " and t.manguon=" + i_manguon;
            if (s_den != "" && s_tu != "")
                sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy') ";
            sql += " group by b.makho,b.mabd";
            sql += " union all ";
            // Lấy số lượng xuất cho tủ trực.
            sql += "select b.makho,b.mabd,sum(b.soluong) as soluong from " + xxxt + ".d_xuatsdll a," + xxxt + ".d_thucbucstt b," + xxxt + ".d_theodoi t";
            sql += " ," + user + ".d_dmbd c," + user + ".d_dmnhom d ";
            sql += " where a.id=b.id and a.loai in (2) and b.sttt=t.id ";
            sql += " and b.makho in (" + i_makho + ") ";
            sql += " and b.mabd=c.id and c.manhom=d.id ";
            // if (s_dutrunam != "" && s_dutrunam != null) sql += " and d.nhomin in (" + s_dutrunam + ")";
            if (i_manguon != -1) sql += " and t.manguon=" + i_manguon;
            if (s_den != "" && s_tu != "")
                sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy') ";
            sql += " group by b.makho,b.mabd";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                sql = "mabd1=" + int.Parse(r["mabd"].ToString());
                DataRow r1 = d.getrowbyid(dtct, sql);
                if (r1 != null)
                {
                    DataRow[] dr = dtct.Select(sql);
                    if (dr.Length > 0)
                        dr[0][field] = decimal.Parse(dr[0][field].ToString() == "" ? "0" : dr[0][field].ToString()) + decimal.Parse(r["soluong"].ToString());
                }
            }
        }
        private void get_slgoiy()
        {
            foreach (DataRow r in dtct.Rows)
            {
                decimal ts = decimal.Parse(r["slton"].ToString() == "" ? "0" : r["slton"].ToString()) - decimal.Parse(r["xuat10"].ToString() == "" ? "0" : r["xuat10"].ToString());
                if (ts < 0)
                {
                    r["slgoiy"] = Math.Round(ts * (-1), 0);
                }
                else
                {
                    r["slgoiy"] = 0;
                }

            }
        }
        private void EnableOject(bool ena)
        {
            butMoi.Enabled = !ena;
            butSua.Enabled = !ena;
            // butXoa.Enabled = !ena;
            butHuy.Enabled = !ena;
            butIn.Enabled = !ena;
            cmbSophieu.Visible = !ena;
            sophieu.Visible = ena;
            butLuu.Enabled = ena;
            butBoqua.Enabled = ena;
        }
        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butMoi_Click(object sender, EventArgs e)
        {
            l_id = 0;
            bNew = true;
            load_grid(false);
            EnableOject(true);
        }

        private void cmbSophieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                l_id = decimal.Parse(cmbSophieu.SelectedValue.ToString());
                load_grid(true);
                switch (d.bPhieudachuyencstt(l_id, decimal.Parse(cmbSophieu.Text)))
                {
                    case 0:
                        butChuyen.FlatStyle = FlatStyle.Standard;
                        butChuyen.ForeColor = Color.Black;
                        break;
                    case 1:
                        butChuyen.ForeColor = Color.Red;
                        butChuyen.FlatStyle = FlatStyle.Flat;
                        break;
                    case 2:
                        butChuyen.FlatStyle = FlatStyle.Flat;
                        butChuyen.ForeColor = Color.Blue;
                        break;
                }
            }
            catch
            {
                l_id = 0;
            }
        }

        private void butSua_Click(object sender, EventArgs e)
        {
            if (butChuyen.ForeColor == Color.Blue || butChuyen.ForeColor == Color.Black)
            {
                if (butChuyen.ForeColor == Color.Blue)
                {
                    if (MessageBox.Show(lan.Change_language_MessageText("Phiếu này đã được chuyển.\n Bạn có muốn khôi phục lại trạng tháng chưa chuyển để sửa không ?"), d.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                bNew = false;
                sophieu.Text = cmbSophieu.Text;
                //sophieu.BringToFront();
                load_grid(false);
                EnableOject(true);
            }
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            l_id = 0;
            //load_grid(true);
            //cmbSophieu.BringToFront();
            dataGrid1.DataSource = null;
            EnableOject(false);
            cmbSophieu_SelectedIndexChanged(null, null);
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (bNew)
                {
                    l_id = d.getidyymmddhhmiss_stt_computer;
                    sophieu.Text = d.i_Chinhanh_hientai.ToString() + d.StringToDate(s_ngay).ToString("yyMM") + d.get_capid((int)LibMedi.IDThongSo.ID_SoPhieuDuTruTuTrucKhoaPhong).ToString().PadLeft(6, '0');// d.getyymmdd();
                }
                if (d.upd_dutrucsttll(l_id, i_nhom, sophieu.Text.Trim(), s_ngay, i_makho, "", i_matutruc, i_makp, 0, i_userid))
                {
                    dtct.AcceptChanges();
                    int stt = 1;
                    string exp = "true";
                    if (!bNew) exp = "soluong<>slcu";
                    foreach (DataRow row in dtct.Select(exp))
                    {
                        d.upd_dutrucsttct(l_id, stt++, int.Parse(row["mabd1"].ToString()), decimal.Parse((row["slton"].ToString() == "" || row["slton"] == null) ? "0" : row["slton"].ToString()),
                            decimal.Parse((row["csduyet"].ToString() == "" || row["csduyet"] == null) ? "0" : row["csduyet"].ToString()), decimal.Parse((row["soluong"].ToString() == "" || row["soluong"] == null) ? "0" : row["soluong"].ToString()),
                            row["dang"].ToString(), row["nhacc"].ToString(), row["manguon"].ToString(), row["lydo"].ToString());
                        if (!bNew) row["slcu"] = row["soluong"].ToString();

                    }
                }
                else
                {
                    MessageBox.Show(lan.Change_language_MessageText("Cập nhật số phiếu không thành công !"), d.Msg);
                    return;
                }
                load_phieu();
                load_grid(true);
                butBoqua_Click(null, null);
            }
            catch
            { }
        }

        private void butHuy_Click(object sender, EventArgs e)
        {
            if (l_id != 0 && cmbSophieu.Text.Trim() != "")
            {
                if (MessageBox.Show(lan.Change_language_MessageText("Bạn muốn xóa phiếu " + cmbSophieu.Text + " ?"), d.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (butChuyen.ForeColor == Color.Red)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Số phiếu " + cmbSophieu.Text + " đã được duyệt không thể hủy !"), d.Msg);
                            return;
                        }
                        d.del_d_dutrucstt(l_id, decimal.Parse(cmbSophieu.Text.Trim()), s_ngay);
                        load_grid(true);
                        load_phieu();
                    }
                    catch
                    { }
                }
            }
        }

        private void timkiem_TextChanged(object sender, EventArgs e)
        {
            if (timkiem.Text.Trim() != "Tìm kiếm")
            {
                filter(timkiem.Text);
            }
        }

        private void filter(string exp)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
            DataView dv = (DataView)cm.List;
            if (exp.Trim() == "")
            {
                dv.RowFilter = "";
            }
            else
            {
                dv.RowFilter = "ten like '%" + exp + "%' or ma like '%" + exp + "%' ";
            }
        }
        private void timkiem_Enter(object sender, EventArgs e)
        {
            timkiem.BackColor = Color.PaleGoldenrod;
            timkiem.Text = "";
        }

        private void timkiem_Leave(object sender, EventArgs e)
        {
            timkiem.BackColor = Color.WhiteSmoke;
            timkiem.Text = "Tìm kiếm";
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (l_id != 0 && cmbSophieu.Text.Trim() != "")
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
                    DataView dv = (DataView)cm.List;
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dv.Table.Copy());
                    sql = "select * from " + user + ".d_nhomkhoa where makp like '%" + i_makp + "%'";
                    string s_bophan = "";
                    foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                    {
                        s_bophan = r["ten"].ToString();
                        break;
                    }
                    if (chkXem.Checked) ds.WriteXml("..//..//dataxml//d_dutrucsttkhoa.xml", XmlWriteMode.WriteSchema);
                    frmReport f = new frmReport(new LibMedi.AccessData(), ds, "d_dutrucstt_kp.rpt", d.TenChiNhanhHienTai, s_bophan, txtTitle.Text.ToUpper(), cmbSophieu.Text, ngaysp.Text, txtKhoa.Text.ToUpper());
                    f.ShowDialog();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(lan.Change_language_MessageText("Lỗi :") + er.Message, "d_dutrungay.rpt");
            }

        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                //int i_row = dataGrid1.CurrentCell.RowNumber-1;
                //if (decimal.Parse(dataGrid1[i_row, 12].ToString()) > decimal.Parse(dataGrid1[i_row, 11].ToString()))
                //{
                //    if (dataGrid1[i_row, 13].ToString() == "")
                //    {
                //        MessageBox.Show(lan.Change_language_MessageText("Số lượng lớn hơn số lượng gợi ý, Bạn phải nhập lý do !"), d.Msg);
                //        dataGrid1.CurrentCell = new DataGridCell(i_row, 13);
                //        return;
                //    }
                //}
            }
            catch
            { }
        }

        private void butXoa_Click(object sender, EventArgs e)
        {

        }

        private void butChuyen_Click(object sender, EventArgs e)
        {
            if (butChuyen.ForeColor == Color.Black)
            {
                if (l_id != 0 && cmbSophieu.Text.Trim() != "")
                {
                    d.execute_data("update " + user + ".d_dutrucsttll set done=2 where id=" + l_id + " and sophieu=" + cmbSophieu.Text);
                }
            }
        }
        //
    }
}