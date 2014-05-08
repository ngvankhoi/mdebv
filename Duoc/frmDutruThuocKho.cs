﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibDuoc;
namespace Duoc
{
    public partial class frmDutruThuocKho : Form
    {
        int i_id_chinhanh = 0;
        private Language lan = new Language();
        private string format_soluong;
        private int i_nhom;
        private string s_ngay;
        private DateTime d_ngay;
        private AccessData d;
        private string user,usermmyy;
        private DataTable dtct;
        private string s_makho, s_tenkho,sql,s_mmyy;
        private decimal l_id = 0;
        private int i_manguon,i_userid;
        private bool bNew = false;
        public frmDutruThuocKho(AccessData acc, string s_ngay,string _makho,string _tenkho,int manguon,int nhom,string mmyy,DateTime _ngay,int _userid,int _id_chinhanh)
        {
            InitializeComponent();
            this.s_ngay = s_ngay;
            this.d = acc;
            s_makho = _makho;
            s_tenkho = _tenkho;
            i_manguon = manguon;
            i_nhom = nhom;
            s_mmyy = mmyy;
            d_ngay = _ngay;
            i_userid = _userid;
            i_id_chinhanh = _id_chinhanh;
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
            

            TextCol1 = new DataGridColoredTextBoxColumn(de, 1);
            TextCol1.MappingName = "mabd";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            

            TextCol1 = new DataGridColoredTextBoxColumn(de, 2);
            TextCol1.MappingName = "ma";
            TextCol1.HeaderText = "Mã";
            TextCol1.Width = 60;
            ts.GridColumnStyles.Add(TextCol1);
            

            TextCol1 = new DataGridColoredTextBoxColumn(de, 3);
            TextCol1.MappingName = "ten";
            TextCol1.HeaderText = "Tên thuốc - hàm lượng";
            TextCol1.Width = 200;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            

            TextCol1 = new DataGridColoredTextBoxColumn(de, 4);
            TextCol1.MappingName = "donvi";
            TextCol1.HeaderText = "Đóng gói";
            TextCol1.Width = 60;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            

            TextCol1 = new DataGridColoredTextBoxColumn(de, 5);
            TextCol1.MappingName = "dang";
            TextCol1.HeaderText = "ĐVT";
            TextCol1.Width = 40;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            

            TextCol1 = new DataGridColoredTextBoxColumn(de, 6);
            TextCol1.MappingName = "tenhang";
            TextCol1.HeaderText = "Hãng SX";
            TextCol1.Width = 100;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            

            TextCol1 = new DataGridColoredTextBoxColumn(de,7);
            TextCol1.MappingName = "nhacc";
            TextCol1.HeaderText = "Nhà cung cấp";
            TextCol1.Width = 200;
            TextCol1.ReadOnly = true;
            TextCol1.NullText = "";
            ts.GridColumnStyles.Add(TextCol1);
            

            TextCol1 = new DataGridColoredTextBoxColumn(de, 8);
            TextCol1.MappingName = "xuat10";
            TextCol1.HeaderText = "Sử dụng(-10)";
            TextCol1.Width = 75;
            TextCol1.ReadOnly = true;
            TextCol1.Format = format_soluong;
            TextCol1.NullText = "0";
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            

            TextCol1 = new DataGridColoredTextBoxColumn(de, 9);
            TextCol1.MappingName = "xuat30";
            TextCol1.HeaderText = "Sử dụng(-30)";
            TextCol1.Width = 75;
            TextCol1.ReadOnly = true;
            TextCol1.NullText = "0";
            TextCol1.Format = format_soluong;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            

            TextCol1 = new DataGridColoredTextBoxColumn(de, 10);
            TextCol1.MappingName = "slton";
            TextCol1.HeaderText = "Tồn";
            TextCol1.Width = 60;
            TextCol1.ReadOnly = true;
            TextCol1.NullText = "0";
            TextCol1.Format = format_soluong;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            

            TextCol1 = new DataGridColoredTextBoxColumn(de, 11);
            TextCol1.MappingName = "slgoiy";
            TextCol1.HeaderText = "SL gợi ý";
            TextCol1.Width = 60;
            TextCol1.ReadOnly = true;
            TextCol1.NullText = "0";
            TextCol1.Format = format_soluong;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            

            TextCol1 = new DataGridColoredTextBoxColumn(de, 12);
            TextCol1.MappingName = "soluong";
            TextCol1.HeaderText = "Dự trù ";
            TextCol1.Width = 60;
            TextCol1.NullText = "0.0";
            TextCol1.Format = format_soluong;
            //TextCol1.ReadOnly = bDutru_Readonly;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            

            TextCol1 = new DataGridColoredTextBoxColumn(de, 13);
            TextCol1.MappingName = "lydo";
            TextCol1.HeaderText = "Lý do";
            TextCol1.Width = 60;
            TextCol1.NullText = "";
            //TextCol1.ReadOnly = !bDutru_Readonly;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            

            TextCol1 = new DataGridColoredTextBoxColumn(de, 14);
            TextCol1.MappingName = "id";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Clear();
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
            if (dataGrid1[row, 13].ToString().Trim() != "") return Color.Red;
            return Color.Black;
        }
        #endregion
        private void frmDutruThuocKho_Load(object sender, EventArgs e)
        {
            user = d.user;
            usermmyy = user + s_mmyy;
            format_soluong = d.format_soluong(i_nhom);
            ngaysp.Text = s_ngay;
            txtTitle.Text = s_tenkho;
            cmbSophieu.DisplayMember="SOPHIEU";
            cmbSophieu.ValueMember="ID";
            load_grid(true);
            AddGridTableStyle();
            load_phieu();
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
                sql = "select distinct b.ma,b.id as mabd1 ,trim(b.ten)||' '||b.hamluong as ten,b.dang,c.stt as sttnhom,c.ten as tennhom,d.ten as tenhang,";
                sql += "b.sltoithieu, b.tenhc,a.*,a.soluong as slcu,f.sophieu,b.hamluong,k.ten tennuoc ";
                sql += " from " + user + ".d_dutrukhoct a inner join " + user + ".d_dutrukholl f on a.id=f.id inner join " + user + ".d_dmbd b on a.mabd=b.id inner join " +
                    user + ".d_dmnhom c on b.manhom=c.id inner join " + user + ".d_dmhang d on b.mahang=d.id inner join " +
                    user + ".d_dmkho e on e.id=f.makho inner join " + user + ".d_dmnuoc k on b.manuoc=k.id left join "+user+".d_dmnx l on b.madv=l.id ";
                sql += " where f.nhom=" + i_nhom;
                sql += " and to_char(f.ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                if (i_manguon != -1) sql += " and a.manguon=" + i_manguon;
                if (s_makho != "") sql += " and f.makho=" + s_makho;
                sql += " and a.id=" + l_id;
                if (!butLuu.Enabled) sql += " and a.soluong >0 ";
                sql += " order by c.stt,b.ma";
                dtct = d.get_data(sql).Tables[0];
            }
            else
            {
                sql = "select distinct b.ma,b.id as mabd1 ,trim(b.ten)||' '||b.hamluong as ten,b.dang,c.stt as sttnhom,c.ten as tennhom,d.ten as tenhang,";
                sql += "b.sltoithieu, b.tenhc ";
                sql += " from " + user + ".d_dmbd b," + user + ".d_dmnhom c," + user + ".d_dmhang d," + user + ".d_dmkho e ";
                sql += " where b.manhom=c.id and b.mahang=d.id and e.nhom=" + i_nhom;
                if (s_makho != "") sql += " and e.id=" + s_makho;
                sql += " order by c.stt,b.ma";
                dtct = d.get_data(sql).Tables[0];
                DataTable tmp = d.get_data("select a.*,a.soluong as slcu from " + user + ".d_dutrukhoct a where 1=0").Tables[0];
                for(int i=0;i<tmp.Columns.Count;i++)
                {
                    try
                    {
                        dtct.Columns.Add(tmp.Columns[i].ColumnName, Type.GetType(tmp.Columns[i].DataType.ToString()));
                    }
                    catch { }
                }
                if (!bNew)// xet truong hop sua
                {
                    sql = " select a.*,a.soluong as slcu from " + user + ".d_dutrukhoct a," + user + ".d_dutrukholl b where a.id=b.id and b.id=" + l_id;
                    if (s_ngay != "") sql += " and to_char(b.ngay,'dd/mm/yyyy')='" + s_ngay+"'";
                    sql += " and b.nhom=" + i_nhom;
                    if (s_makho != "") sql += " and b.makho='" + s_makho + "'";
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
                else
                {
                    get_tonkho();//hien
                    get_nhap_den_ngay(s_ngay, s_makho);
                    get_xuat_den_ngay(s_ngay, s_makho);
                    get_xuat(s_mmyy, d_ngay.AddDays(-10).ToString("dd/MM/yyyy"), d_ngay.ToString("dd/MM/yyyy"), "xuat10");
                    get_xuat(s_mmyy, d_ngay.AddDays(-30).ToString("dd/MM/yyyy"), d_ngay.ToString("dd/MM/yyyy"), "xuat30");
                    get_slgoiy();
                }
            }
            dataGrid1.DataSource = dtct;
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
            DataView dv = (DataView)cm.List;
            dv.AllowDelete = false;
            dv.AllowNew = false;
        }
        /// <summary>
        /// Load những phiếu được nhập trong ngày.
        /// </summary>
        private void load_phieu()
        {
            cmbSophieu.DataSource = d.get_data("select * from " + user + ".d_dutrukholl where to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "' and makho='"+s_makho+"' order by to_char(ngay,'dd/mm/yyyy') desc").Tables[0];
        }
        /// <summary>
        /// tồn kho chi tiết.
        /// </summary>
        private void get_tonkho()
        {
            if (!d.bMmyy(s_mmyy)) return;
            sql = "select a.makho,a.mabd,sum(a.tondau) as ton from " + usermmyy + ".d_tonkhoth a," + user + ".d_dmbd b," + user + ".d_dmnhom c";
            sql += " where a.mabd=b.id and b.manhom=c.id ";
            if (s_makho != "") sql += " and a.makho in (" + s_makho + ")";
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
            sql += " from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d  where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=1 ";
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
            if (s_makho != "") sql += " and a.khox in (" + s_makho + ") ";

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
            if (s_makho != "") sql += " and b.makho in (" + s_makho + ") ";
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
            if (s_makho != "") sql += " and b.makho in (" + s_makho + ") ";
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
            if (s_makho != "") sql += " and b.makho in (" + s_makho + ") ";
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
            if (s_makho != "") sql += " and b.makho in (" + s_makho + ") ";
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
            if (s_makho != "") sql += " and b.makho in (" + s_makho + ") ";
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
                butChuyen.Enabled = true;
                switch (d.bPhieudachuyen(l_id, decimal.Parse(cmbSophieu.Text)))
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
                        butChuyen.Enabled = false;
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
            cmbSophieu_SelectedIndexChanged(null, null);
            if (butChuyen.Enabled)
            {
                if (butChuyen.ForeColor == Color.Blue)
                {
                    if (MessageBox.Show(lan.Change_language_MessageText("Phiếu này đã được chuyển.\n Bạn có muốn khôi phục lại trạng tháng chưa chuyển để sửa không ?"), d.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }   
                }
                butChuyen.FlatStyle = FlatStyle.Standard;
                bNew = false;
                sophieu.Text = cmbSophieu.Text;
                load_grid(false);
                EnableOject(true);
            }
            else
            {
                MessageBox.Show(lan.Change_language_MessageText("Phiếu này đã được duyệt."), d.Msg);
            }
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            l_id = 0;
            //load_grid(true);
            //cmbSophieu.BringToFront();
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
                    sophieu.Text = d.i_Chinhanh_hientai.ToString() + DateTime.Now.Year.ToString().Substring(2) + DateTime.Now.Month.ToString().PadLeft(2, '0') + d.get_capid((int)LibMedi.IDThongSo.ID_SoPhieuDuTruMuaTaiKhoDuoc);
                }
                if (d.upd_dutrukholl(l_id, i_nhom, decimal.Parse(sophieu.Text.Trim()), s_ngay, s_makho, 0, i_userid))
                {
                    dtct.AcceptChanges();
                    int stt=1;
                    string exp = "true";
                    if (!bNew) exp = "soluong<>slcu";
                    foreach (DataRow row in dtct.Select(exp))    
                    {
                        d.upd_dutrukhoct(l_id, stt++, int.Parse(row["mabd1"].ToString()), decimal.Parse((row["slton"].ToString() == "" || row["slton"] == null) ? "0" : row["slton"].ToString()),
                            decimal.Parse((row["xuat10"].ToString() == "" || row["xuat10"] == null) ? "0" : row["xuat10"].ToString()), decimal.Parse((row["xuat30"].ToString() == "" || row["xuat30"] == null) ? "0" : row["xuat30"].ToString()),
                            decimal.Parse((row["slgoiy"].ToString() == "" || row["slgoiy"] == null) ? "0" : row["slgoiy"].ToString()), decimal.Parse((row["soluong"].ToString() == "" || row["soluong"] == null)? "0" : row["soluong"].ToString()),
                            row["dang"].ToString(), row["nhacc"].ToString(), i_manguon.ToString(), row["lydo"].ToString());
                        if (!bNew) row["slcu"] = row["soluong"].ToString();

                    }
                }
                else
                {
                    MessageBox.Show(lan.Change_language_MessageText("Cập nhật số phiếu không thành công !"), d.Msg);
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
            cmbSophieu_SelectedIndexChanged(null, null);
            if (l_id != 0 && cmbSophieu.Text.Trim() != "")
            {
                if (!butChuyen.Enabled)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Số phiếu " + cmbSophieu.Text + " đã được duyệt không thể hủy !"), d.Msg);
                    return;
                }
                if (butChuyen.ForeColor == Color.Red)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Số phiếu " + cmbSophieu.Text + " đã được chuyển không thể hủy !"), d.Msg);
                    return;
                }
                if (MessageBox.Show(lan.Change_language_MessageText("Bạn muốn xóa phiếu " + cmbSophieu.Text + " ?"), d.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        d.del_d_dutrukho(l_id, decimal.Parse(cmbSophieu.Text.Trim()));
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
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
                DataView dv = (DataView)cm.List;
                DataSet ds = new DataSet();
                ds.Tables.Add(dv.Table.Copy());
                if (chkXem.Checked) ds.WriteXml("..//..//dataxml//d_dutrukho.xml", XmlWriteMode.WriteSchema);
                frmReport f = new frmReport(d, ds,i_userid, d.f_getten_chinhanh(i_id_chinhanh), "d_dutrukhothuoc.rpt");
                f.ShowDialog();
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
                int i_row = dataGrid1.CurrentCell.RowNumber-1;
                if (decimal.Parse(dataGrid1[i_row, 12].ToString()) > decimal.Parse(dataGrid1[i_row, 11].ToString()))
                {
                    if (dataGrid1[i_row, 13].ToString() == "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Số lượng lớn hơn số lượng gợi ý, Bạn phải nhập lý do !"), d.Msg);
                        dataGrid1.CurrentCell = new DataGridCell(i_row, 13);
                        return;
                    }
                }
            }
            catch
            { }
        }

        private void butXoa_Click(object sender, EventArgs e)
        {

        }

        private void butChuyen_Click(object sender, EventArgs e)
        {
            cmbSophieu_SelectedIndexChanged(null, null);
            if (cmbSophieu.Enabled)
            {
                if (l_id != 0 && cmbSophieu.Text.Trim() != "")
                {
                    if (butChuyen.ForeColor == Color.Black)
                    {
                        d.execute_data("update " + user + ".d_dutrukholl set done=1 where id=" + l_id + " and sophieu=" + cmbSophieu.Text);
                        butChuyen.ForeColor = Color.Red;
                        butChuyen.FlatStyle = FlatStyle.Flat;
                    }
                    else if (butChuyen.ForeColor == Color.Red)
                    {
                        d.execute_data("update " + user + ".d_dutrukholl set done=0 where id=" + l_id + " and sophieu=" + cmbSophieu.Text);
                        butChuyen.ForeColor = Color.Black;
                        butChuyen.FlatStyle = FlatStyle.Standard;
                    }
                }
            }
            else
            {
                MessageBox.Show("Phiếu đã được duyệt", d.Msg);
            }
        }
        
    }
}