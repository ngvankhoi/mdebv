using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibDuoc;


namespace Duoc
{
    public partial class frmDutrungay : Form
    {
        private AccessData d;
        private int i_nhom, i_manguon, i_lanthu;
        bool bNam,bDutru_Readonly=false;
        int i_duyet = 0;
        private string s_mmyy, user, xxx, sql,makho, format_soluong, s_manhom, s_mmyyt, xxxt, s_tennguon, s_makho, s_dutrunam;
        private DateTime m_ngay = DateTime.Now;
        private DataTable dtkho,dt;
        private DataSet dsxml,ds;
        private DataColumn dc;
        private DataRow r1,r2,r3;
        private DataRow[] dr;
        private string field_duyet = "d1";
        private string field_dutru = "l1";
        private string s_idchinhanh;
        private int i_userid;
        Language lan;
        private string s_dblink;
        public frmDutrungay(AccessData acc, int nhom, string mmyy, string _manhom, int _manguon, string _tennguon, int lanthu, string makho,DateTime _ngay,int duyet,int userid)
        {
            InitializeComponent();
            d = acc;
            i_nhom = nhom;
            s_mmyy = mmyy;
            s_manhom = _manhom;
            i_manguon = _manguon;
            s_tennguon = _tennguon;
            i_lanthu = lanthu;
            s_makho = makho;
            m_ngay = _ngay;
            i_duyet=duyet;
            i_userid = userid;
            Init();
        }

        private void Init()
        {
            if (d.bQuanly_Theo_Chinhanh)
            {
                s_dblink = d.getDBLink();
                
            }
            dtkho = new DataTable();
            dsxml = new DataSet();
            ds = new DataSet();
            lan = new Language();
            s_idchinhanh = d.i_Chinhanh_hientai.ToString();
            switch (i_duyet)
            {
                case 0:
                    field_dutru = "l1";
                    bDutru_Readonly = false;
                    field_duyet = "d1";
                    break;
                case 1:
                    field_dutru = "l1";
                    bDutru_Readonly = true;
                    field_duyet = "d1";
                    this.Text = "Chi nhánh duyệt dự trù mua thuốc ";
                    butChuyen.Visible = d.bQuanly_Theo_Chinhanh;
                    break;
                case 2:
                    field_dutru = "d1";
                    bDutru_Readonly = true;
                    butChuyen.Visible = false;
                    field_duyet = "d2";
                    this.Text = "Trung tâm duyệt dự trù mua thuốc";
                    break;
            }
            if (i_duyet != 2)
            {
                treeView1.Visible = false;
                songay.Visible = false;
            }
        }

        private void frmDutrungay_Load(object sender, EventArgs e)
        {
            user = d.user;
            s_mmyyt = s_mmyy;
            xxxt = user + s_mmyy;
            xxx  = user + s_mmyy;
            tieude.Text = "Ngày " + m_ngay.ToString("dd/MM/yyyy") + " dự trù lần thứ " + i_lanthu.ToString() + " số liệu tháng " + s_mmyy; 
            format_soluong = d.format_soluong(i_nhom);
            // load dm kho
            dtkho = d.get_data("select * from " + user + ".d_dmkho where nhom=" + i_nhom + " and dutru=1" + (s_makho.Trim().Trim(',') != "" ? (" and id in(" + s_makho.Trim().Trim(',') + ")") : "") + " order by stt").Tables[0];
            // load nha cung cap
            sql = "select a.*,b.stt as sttnhom,b.ten as tennhom,c.ten as tenhang,d.ten as nhacc ";
            sql += " from " + user + ".d_dmbd a inner join ";
            if (i_nhom == 1) sql += " " + user + ".d_dmnhom b on a.manhom=b.id ";
            else sql += " " + user + ".d_dmloai b on a.maloai=b.id ";
            sql += " inner join " + user + ".d_dmhang c on a.mahang=c.id left join " + user + ".d_dmnx d on a.madv=d.id ";
            sql += " where  a.hide=0 and a.nhom=" + i_nhom;
            if (s_dutrunam != "" && s_dutrunam !=null) sql += " and b.nhomin in (" + s_dutrunam + ")";
            dt = d.get_data(sql).Tables[0];
            load_Grid(true);
            dataGrid1.ReadOnly = false;
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource, dataGrid1.DataMember];
            DataView dv = (DataView)cm.List;
            dv.AllowNew = false;
            AddGridTableStyle();
           if(i_duyet==2) load_treeView();
         }

        private void load_treeView()
        {
            sql ="select distinct a.ten,a.id,b.mmyy,b.nhom,b.lan,to_char(b.ngay,'dd/mm/yyyy') as ngay ";
            sql +=" from "+user+".dmchinhanh a, "+user+".d_dutrungay b where a.id = b.idchinhanh and b.daduyet = 2 and b.d1>0 ";
            sql += " and to_date(to_char(b.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + m_ngay.AddDays((double)(-1 * songay.Value)).ToString("dd/MM/yyyy") + "','dd/mm/yyyy') and to_date('" + m_ngay.AddDays((double)(songay.Value)).ToString("dd/MM/yyyy") + "','dd/mm/yyyy')";
            DataTable tmp = d.get_data(sql).Tables[0];
            // add node chinh
            TreeNode node;
            foreach (DataRow row in tmp.Rows)
            {
                node = new TreeNode(row["ten"].ToString() + " lần thứ " + row["lan"].ToString() + "(" + row["ngay"].ToString() + ")");
                node.Tag = row["id"].ToString() + "," + row["mmyy"].ToString() + "," + row["nhom"].ToString() + "," + row["lan"].ToString() + "," + row["ngay"].ToString();
                treeView1.Nodes.Add(node);
                node.Nodes.Add(" ");
            }
        }

        private void load_Grid( bool bChuaduyet)
        {
            // kiểm tra duyệt
            DataTable temp;
            switch (i_duyet)
            {
                case 0:
                    sql = "select dutru from " + user + ".d_dutrungay where mmyy='" + s_mmyy + "'";
                    sql += " and nhom =" + i_nhom + " and idchinhanh=" + d.i_Chinhanh_hientai;
                    sql += " and lan =" + i_lanthu + " and to_char(ngay,'dd/mm/yyyy')='" + m_ngay.ToString("dd/MM/yyyy") + "'";
                     temp = d.get_data(sql).Tables[0];
                    if (temp.Rows.Count > 0)
                    {
                        if (temp.Rows[0]["dutru"].ToString().Trim() == "1")// chi nhah da duyet
                        {
                            butChuyen.FlatStyle = FlatStyle.Flat;
                            butChuyen.ForeColor = Color.Red;
                            butLuu.Enabled = false;
                            butHuy.Enabled = false;
                            butMoi.Enabled = false;
                        }
                        else
                        {
                            if (temp.Rows[0]["dutru"].ToString().Trim() == "2")// da nhan chuyen
                            {
                                butChuyen.FlatStyle = FlatStyle.Flat;
                                butChuyen.ForeColor = Color.Blue;
                                butMoi.Enabled = false;
                                butHuy.Text = " Thu hồi";
                            }
                            else
                            {
                                butChuyen.FlatStyle = FlatStyle.Standard;
                                butChuyen.ForeColor = Color.Black;
                                butMoi.Enabled = true;
                                butHuy.Text = " Hủy";
                            }
                        }
                    }
                    break;
                case 1:// chi nhanh
                    butMoi.Enabled = false;
                    sql = "select daduyet from " + user + ".d_dutrungay where mmyy='" + s_mmyy + "'";
                    sql += " and nhom =" + i_nhom + " and idchinhanh=" + d.i_Chinhanh_hientai;
                    sql += " and lan =" + i_lanthu + " and to_char(ngay,'dd/mm/yyyy')='" + m_ngay.ToString("dd/MM/yyyy") + "'";
                     temp = d.get_data(sql).Tables[0];
                    if (temp.Rows.Count > 0)
                    {
                        if (temp.Rows[0]["daduyet"].ToString().Trim() == "1")// trung tam da duyet
                        {
                            butChuyen.FlatStyle = FlatStyle.Flat;
                            butChuyen.ForeColor = Color.Red;
                            butLuu.Enabled = false;
                            butHuy.Enabled = false;
                            butBoqua.Enabled = false;
                            
                        }
                        else
                        {
                            if (temp.Rows[0]["daduyet"].ToString().Trim() == "2")// da nhan chuyen
                            {
                                butChuyen.FlatStyle = FlatStyle.Flat;
                                butChuyen.ForeColor = Color.Blue;
                                butHuy.Text = " Thu hồi";
                            }
                            else
                            {
                                butChuyen.FlatStyle = FlatStyle.Standard;
                                butChuyen.ForeColor = Color.Black;
                              
                            }
                        }
                    }
                    break;
                case 2:
                    butMoi.Enabled = false;
                    butHuy.Text = " Thu hồi";
                    sql = "select daduyet from " + user + ".d_dutrungay where mmyy='" + s_mmyy + "'";
                    sql += " and nhom =" + i_nhom;//+ " and idchinhanh=" + d.i_Chinhanh_hientai;
                    sql += " and lan =" + i_lanthu + " and to_char(ngay,'dd/mm/yyyy')='" + m_ngay.ToString("dd/MM/yyyy") + "' and daduyet=1";
                     temp = d.get_data(sql).Tables[0];
                    if (temp.Rows.Count > 0)
                    {
                        if (temp.Rows[0]["daduyet"].ToString().Trim() == "1")// trung tam da duyet
                        {
                            butLuu.Enabled = false;
                            butHuy.Enabled = true;
                        }
                        else
                        {
                            butHuy.Enabled = false;
                            butLuu.Enabled = true;
                        }
                    }
                    else
                    {
                        butHuy.Enabled = false;
                        butLuu.Enabled = true;
                    }
                    break;
            }
            //
            sql = "select a.*,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.dang,c.stt as sttnhom,c.ten as tennhom,d.ten as tenhang,";
            sql += "b.sltoithieu, b.tenhc, a.l1 as sl_cu1, a.d1 as sl_cu2,a.d2 as sl_cu3,a.slgoiy,a.dutru,a.daduyet ";
            sql += " from " + user + ".d_dutrungay a," + user + ".d_dmbd b," + user + ".d_dmnhom c," + user + ".d_dmhang d,"+user+".d_dmkho e ";
            sql += " where a.mabd=b.id and b.manhom=c.id and b.mahang=d.id and e.nhom=a.nhom and a.nhom=" + i_nhom + " and a.mmyy='" + s_mmyy + "' and a.lan=" + i_lanthu;
            sql += " and to_char(ngay,'dd/mm/yyyy')='" + m_ngay.ToString("dd/MM/yyyy") + "'";
            if (s_dutrunam != "" && s_dutrunam !=null) sql += " and c.nhomin in (" + s_dutrunam + ")";
            if (i_manguon != -1) sql += " and a.manguon=" + i_manguon;
            if (i_duyet == 1) sql += " and a.dutru in(" + (bChuaduyet==true ? "1," : "" )+ "2) and a.l1 >0 ";
            else if (i_duyet == 2) sql += " and a.daduyet in(" + (bChuaduyet==true ? "1," : "") + "2) and a.d1 >0 ";
            if (s_idchinhanh != "") sql += " and a.idchinhanh=" + s_idchinhanh;
            if (s_makho != "") sql += " and e.id in ("+s_makho+")";
             sql += " and a.nhom in(" + i_nhom + ")";
            sql += " order by c.stt,b.ma";
            ds = d.get_data(sql);
            foreach (DataRow r in dtkho.Rows)
            {
                dc = new DataColumn();
                dc.ColumnName = "c" + r["id"].ToString().Trim();
                dc.DataType = Type.GetType("System.Decimal");
                dc.DefaultValue = 0;
                ds.Tables[0].Columns.Add(dc);
            }
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                r1 = d.getrowbyid(dt, "nhacc is not null and id=" + int.Parse(r["mabd"].ToString()));
                if (r1 != null)
                {
                    r["nhacc"] = r1["nhacc"].ToString();
                    r["donvi"] = r1["donvi"].ToString();
                }
            }
            dsxml = ds.Clone();
            // chỉ xét dự trù lần đầu.
            if (!bDutru_Readonly)
            {
                get_tonkho();
                // lấy số lượng xuất trong 10 ngày gần nhất
                get_xuat(s_mmyyt, m_ngay.AddDays(-10).ToString("dd/MM/yyyy"), m_ngay.ToString("dd/MM/yyyy"), "xuat10");
                // lấy số lượng xuất của bệnh
                get_xuat(s_mmyyt, m_ngay.AddDays(-30).ToString("dd/MM/yyyy"), m_ngay.ToString("dd/MM/yyyy"), "xuat30");

                get_nhap(s_mmyyt);
                get_slgoiy();
                dsxml = ds.Clone();
                decimal tondau = 0;
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    tondau = 0;
                    foreach (DataRow r4 in dtkho.Rows) tondau += decimal.Parse(r["c" + r4["id"].ToString().Trim()].ToString());
                    r["tc"] = tondau;
                }
            }
            dsxml.Merge(ds.Tables[0].Select("true"));
            dsxml.AcceptChanges();
            //if (dsxml == null) dsxml = ds.Clone();
            dataGrid1.DataSource = dsxml.Tables[0];
        }

        private void get_nhap(string s_mmyyt)
        {
            if (!d.bMmyy(s_mmyyt)) return;
            string xxxt = user + s_mmyyt;
            sql = "select a.makho,b.mabd,sum(b.soluong) as soluong from " + xxxt + ".d_nhapll a," + xxxt + ".d_nhapct b," + user + ".d_dmbd c," + user + ".d_dmnhom d";
            sql += " where a.id=b.id and b.mabd=c.id and c.manhom=d.id and a.loai='M' ";
            if(s_makho !="") sql += " and a.makho in (" + s_makho + ") ";
            if (s_dutrunam != "" && s_dutrunam !=null) sql += " and d.nhomin in (" + s_dutrunam + ")";
            if (i_manguon != -1) sql += " and a.manguon=" + i_manguon;
            sql += " group by a.makho,b.mabd";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                sql = "mabd=" + int.Parse(r["mabd"].ToString());
                r1 = d.getrowbyid(ds.Tables[0], sql);
                if (r1 == null)
                {
                    r2 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r2 != null)
                    {
                        r3 = ds.Tables[0].NewRow();
                        r3["mabd"] = r["mabd"].ToString();
                        r3["sttnhom"] = r2["sttnhom"].ToString();
                        r3["ma"] = r2["ma"].ToString();
                        r3["tenhc"] = r2["tenhc"].ToString();
                        r3["ten"] = r2["ten"].ToString().Trim() + " " + r2["hamluong"].ToString();
                        r3["dang"] = r2["dang"].ToString();
                        r3["tennhom"] = r2["tennhom"].ToString();
                        r3["tenhang"] = r2["tenhang"].ToString();
                        r3["k1"] = r["soluong"].ToString();
                       // foreach (DataRow r4 in dtkho.Rows) r3["c" + r4["id"].ToString().Trim()] = 0;
                        r3["xuat10"] = 0;
                        r3["xuat30"] = 0;
                        r3["l1"] = 0;
                        r3["d1"] = 0;
                        r3["l2"] = 0;
                        r3["d2"] = 0;
                        r3["tc"] = 0;
                        r3["nhacc"] = r2["nhacc"].ToString();
                        r3["donvi"] = r2["donvi"].ToString();
                        r3["sltoithieu"] = r2["sltoithieu"].ToString();
                        r3["sl_cu1"] = 0;
                        r3["sl_cu2"] = 0;
                        ds.Tables[0].Rows.Add(r3);
                    }
                }
                else
                {
                    dr = ds.Tables[0].Select(sql);
                    if (dr.Length > 0) dr[0]["k1"] = decimal.Parse(dr[0]["k1"].ToString()) + decimal.Parse(r["soluong"].ToString());
                    r2 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r2 != null)
                    {
                        if (r2["nhacc"].ToString() != "") dr[0]["nhacc"] = r2["nhacc"].ToString();
                        if (r2["donvi"].ToString() != "") dr[0]["donvi"] = r2["donvi"].ToString();
                    }
                }
            }
        }

        private void get_xuat(string s_mmyyt,string s_tu,string s_den,string field)
        {
            if (!d.bMmyy(s_mmyyt)) return;
            string xxxt = user + s_mmyyt;
            sql = "select a.khox as makho,b.mabd,sum(b.soluong) as soluong from " + xxxt + ".d_xuatll a," + xxxt + ".d_xuatct b," + xxxt + ".d_theodoi t";
            sql += " ," + user + ".d_dmbd c," + user + ".d_dmnhom d ";
            sql += " where a.id=b.id and a.loai='XK' and b.sttt=t.id ";
            if(s_makho !="") sql += " and a.khox in (" + s_makho + ") ";
            sql += " and b.mabd=c.id and c.manhom=d.id ";
            if (s_dutrunam != "" && s_dutrunam !=null) sql += " and d.nhomin in (" + s_dutrunam + ")";
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
            if (s_dutrunam != "" && s_dutrunam !=null) sql += " and d.nhomin in (" + s_dutrunam + ")";
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
            if (s_dutrunam != "" && s_dutrunam != null) sql += " and d.nhomin in (" + s_dutrunam + ")";
            if (i_manguon != -1) sql += " and t.manguon=" + i_manguon;
            if (s_den != "" && s_tu != "")
                sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy') ";
            sql += " group by b.makho,b.mabd";
            sql += " union all ";
            sql += "select b.makho,b.mabd,sum(b.soluong) as soluong from " + xxxt + ".d_xuatsdll a," + xxxt + ".d_thucxuat b," + xxxt + ".d_theodoi t";
            sql += " ," + user + ".d_dmbd c," + user + ".d_dmnhom d ";
            sql += " where a.id=b.id and a.loai in (1,4) and b.sttt=t.id ";
            if (s_makho != "") sql += " and b.makho in (" + s_makho + ") ";
            sql += " and b.mabd=c.id and c.manhom=d.id ";
            if (s_dutrunam != "" && s_dutrunam != null) sql += " and d.nhomin in (" + s_dutrunam + ")";
            if (i_manguon != -1) sql += " and t.manguon=" + i_manguon;
            if (s_den != "" && s_tu != "")
                sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy') ";
            sql += " group by b.makho,b.mabd";
            sql += " union all ";
            sql += "select b.makho,b.mabd,-sum(b.soluong) as soluong from " + xxxt + ".d_xuatsdll a," + xxxt + ".d_thucxuat b," + xxxt + ".d_theodoi t";
            sql += " ," + user + ".d_dmbd c," + user + ".d_dmnhom d ";
            sql += " where a.id=b.id and a.loai in (3) and b.sttt=t.id ";
            if (s_makho != "") sql += " and b.makho in (" + s_makho + ") ";
            sql += " and b.mabd=c.id and c.manhom=d.id ";
            if (s_dutrunam != "" && s_dutrunam != null ) sql += " and d.nhomin in (" + s_dutrunam + ")";
            if (i_manguon != -1) sql += " and t.manguon=" + i_manguon;
            if (s_den != "" && s_tu != "")
                sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy') ";
            sql += " group by b.makho,b.mabd";
            sql += " union all ";
            sql += "select b.makho,b.mabd,sum(b.soluong) as soluong from " + xxxt + ".d_xuatsdll a," + xxxt + ".d_thucbucstt b," + xxxt + ".d_theodoi t";
            sql += " ," + user + ".d_dmbd c," + user + ".d_dmnhom d ";
            sql += " where a.id=b.id and a.loai in (2) and b.sttt=t.id ";
            if(s_makho !="" )sql += " and b.makho in (" + s_makho + ") ";
            sql += " and b.mabd=c.id and c.manhom=d.id ";
            if (s_dutrunam != "" && s_dutrunam != null) sql += " and d.nhomin in (" + s_dutrunam + ")";
            if (i_manguon != -1) sql += " and t.manguon=" + i_manguon;
            if (s_den != "" && s_tu != "")
                sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy') ";
            sql += " group by b.makho,b.mabd";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                sql = "mabd=" + int.Parse(r["mabd"].ToString());
                r1 = d.getrowbyid(ds.Tables[0], sql);
                if (r1 == null)
                {
                    r2 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r2 != null)
                    {
                        r3 = ds.Tables[0].NewRow();
                        r3["mabd"] = r["mabd"].ToString();
                        r3["sttnhom"] = r2["sttnhom"].ToString();
                        r3["ma"] = r2["ma"].ToString();
                        r3["tenhc"] = r2["tenhc"].ToString();
                        r3["ten"] = r2["ten"].ToString().Trim() + " " + r2["hamluong"].ToString();
                        r3["dang"] = r2["dang"].ToString();
                        r3["tennhom"] = r2["tennhom"].ToString();
                        r3["tenhang"] = r2["tenhang"].ToString();
                        r3["k1"] = 0;
                       // foreach (DataRow r4 in dtkho.Rows) r3["c" + r4["id"].ToString().Trim()] = 0;
                        r3[field] = r["soluong"].ToString();
                        r3["l1"] = 0;
                        r3["d1"] = 0;
                        r3["l2"] = 0;
                        r3["d2"] = 0;
                        r3["tc"] = 0;
                        r3["nhacc"] = r2["nhacc"].ToString();
                        r3["donvi"] = r2["donvi"].ToString();
                        r3["sltoithieu"] = r2["sltoithieu"].ToString();
                        r3["sl_cu1"] = 0;
                        r3["sl_cu2"] = 0;
                        ds.Tables[0].Rows.Add(r3);
                    }
                }
                else
                {
                    dr = ds.Tables[0].Select(sql);
                    if (dr.Length > 0) dr[0][field] = decimal.Parse(dr[0][field].ToString()) + decimal.Parse(r["soluong"].ToString());
                    r2 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r2 != null)
                    {
                        if (r2["nhacc"].ToString() != "") dr[0]["nhacc"] = r2["nhacc"].ToString();
                        if (r2["donvi"].ToString() != "") dr[0]["donvi"] = r2["donvi"].ToString();
                    }
                }
            }
        }

        private void get_tonkho()
        {
            if (!d.bMmyy(s_mmyyt)) return;
            sql = "select a.makho,a.mabd,sum(a.tondau+a.slnhap-a.slxuat) as ton from " + xxxt + ".d_tonkhoth a," + user + ".d_dmbd b," + user + ".d_dmnhom c";
            sql += " where a.mabd=b.id and b.manhom=c.id ";
            if(s_makho !="") sql += " and a.makho in (" + s_makho + ")";
            if (i_manguon != -1) sql += " and a.manguon=" + i_manguon;
            if (s_dutrunam != "" && s_dutrunam !=null) sql += " and c.nhomin in (" + s_dutrunam + ")";
            sql += " group by a.makho,a.mabd";
            string kho = "k1";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                kho = index(r["makho"].ToString());
                sql = "mabd=" + int.Parse(r["mabd"].ToString());
                r1 = d.getrowbyid(ds.Tables[0], sql);
                if (r1 == null)
                {
                    r2 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r2 != null)
                    {
                        r3 = ds.Tables[0].NewRow();
                        r3["mabd"] = r["mabd"].ToString();
                        r3["sttnhom"] = r2["sttnhom"].ToString();
                        r3["ma"] = r2["ma"].ToString();
                        r3["tenhc"] = r2["tenhc"].ToString();
                        r3["ten"] = r2["ten"].ToString().Trim() + " " + r2["hamluong"].ToString();
                        r3["dang"] = r2["dang"].ToString();
                        r3["tennhom"] = r2["tennhom"].ToString();
                        r3["tenhang"] = r2["tenhang"].ToString();
                        r3["k1"] = 0;
                        //foreach (DataRow r4 in dtkho.Rows) r3["c" + r4["id"].ToString().Trim()] = 0;
                        r3["xuat10"] = 0;
                        r3["xuat30"] = 0;
                        r3["l1"] = 0;
                        r3["d1"] = 0;
                        r3["l2"] = 0;
                        r3["d2"] = 0;
                        r3[kho] = r["ton"].ToString();
                        r3["tc"] = r["ton"].ToString();
                        r3["slgoiy"] = 0;
                        r3["nhacc"] = r2["nhacc"].ToString();
                        r3["donvi"] = r2["donvi"].ToString();
                        r3["sltoithieu"] = r2["sltoithieu"].ToString();
                        r3["sl_cu1"] = 0;
                        r3["sl_cu2"] = 0;
                        ds.Tables[0].Rows.Add(r3);
                    }
                }
                else
                {
                    dr = ds.Tables[0].Select(sql);
                    if (dr.Length > 0)
                    {
                        dr[0][kho] = decimal.Parse(dr[0][kho].ToString()) + decimal.Parse(r["ton"].ToString());
                        dr[0]["tc"] = decimal.Parse(dr[0]["tc"].ToString()) + decimal.Parse(r["ton"].ToString());
                        r2 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                        if (r2 != null)
                        {
                            if (r2["nhacc"].ToString() != "") dr[0]["nhacc"] = r2["nhacc"].ToString();
                            if (r2["donvi"].ToString() != "") dr[0]["donvi"] = r2["donvi"].ToString();
                        }
                    }
                }
            }
        }
        private void get_slgoiy()
        {
            foreach(DataRow r in ds.Tables[0].Rows)
            {
                decimal ts = decimal.Parse(r["tc"].ToString()) - decimal.Parse(r["xuat10"].ToString());
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
        private string index(string kho)
        {
            return "c" + kho.Trim();
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
            ts.MappingName = dsxml.Tables[0].TableName;

            TextCol1 = new DataGridColoredTextBoxColumn(de, 0);
            TextCol1.MappingName = "tenhc";
            TextCol1.HeaderText = "Hoạt chất";
            TextCol1.Width = 120;
            TextCol1.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 1);
            TextCol1.MappingName = "mabd";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 2);
            TextCol1.MappingName = "ten";
            TextCol1.HeaderText = "Tên thuốc - hàm lượng";
            TextCol1.Width = 200;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 3);
            TextCol1.MappingName = "donvi";
            TextCol1.HeaderText = "Đóng gói";
            TextCol1.Width = 60;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 4);
            TextCol1.MappingName = "dang";
            TextCol1.HeaderText = "ĐVT";
            TextCol1.Width = 40;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 5);
            TextCol1.MappingName = "tenhang";
            TextCol1.HeaderText = "Hãng SX";
            TextCol1.Width = 100;
            TextCol1.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 6);
            TextCol1.MappingName = "k1";
            TextCol1.HeaderText = "Nhập mới";
            TextCol1.Width = 60;
            TextCol1.ReadOnly = true;
            TextCol1.Format = format_soluong;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            int j = 7;// 6;
            string fie = "k1";
            foreach (DataRow r in dtkho.Rows)
            {
                fie = "c" + r["id"].ToString().Trim();
                TextCol1 = new DataGridColoredTextBoxColumn(de, j);
                TextCol1.MappingName = fie;
                TextCol1.HeaderText = r["ten"].ToString().Trim();
                TextCol1.Width = 60;
                TextCol1.ReadOnly = true;
                TextCol1.Format = format_soluong;
                TextCol1.Alignment = HorizontalAlignment.Right;
                ts.GridColumnStyles.Add(TextCol1);
                dataGrid1.TableStyles.Add(ts);
                j++;
            }

            TextCol1 = new DataGridColoredTextBoxColumn(de, j + 1);
            TextCol1.MappingName = "xuat10";
            TextCol1.HeaderText = "Sử dụng(-10)";
            TextCol1.Width = 75;
            TextCol1.ReadOnly = true;
            TextCol1.Format = format_soluong;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, j + 2);
            TextCol1.MappingName = "xuat30";
            TextCol1.HeaderText = "Sử dụng(-30)";
            TextCol1.Width = 75;
            TextCol1.ReadOnly = true;
            TextCol1.Format = format_soluong;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, j + 3);
            TextCol1.MappingName = "tc";
            TextCol1.HeaderText = "Tổng số";
            TextCol1.Width = 60;
            TextCol1.ReadOnly = true;
            TextCol1.Format = format_soluong;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, j + 4);
            TextCol1.MappingName = "slgoiy";
            TextCol1.HeaderText = "SL gợi ý";
            TextCol1.Width = 60;
            TextCol1.ReadOnly = true;
            TextCol1.Format = format_soluong;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, j + 5);
            TextCol1.MappingName = field_dutru;
            TextCol1.HeaderText = "Dự trù " + i_lanthu.ToString();
            TextCol1.Width = 60;
            TextCol1.Format = format_soluong;
            TextCol1.ReadOnly = bDutru_Readonly;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, j + 6);
            TextCol1.MappingName = field_duyet;
            TextCol1.HeaderText = "Duyệt " + i_lanthu.ToString();
            TextCol1.Width = 60;
            TextCol1.Format = format_soluong;
            TextCol1.ReadOnly = !bDutru_Readonly;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, j + 7);
            TextCol1.MappingName = "nhacc";
            TextCol1.HeaderText = "Nhà cung cấp";
            TextCol1.Width = 200;
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
            return Color.Black;
        }
        #endregion

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            //Cursor = Cursors.WaitCursor;
            dsxml.AcceptChanges();
            bool success = true;
            switch (i_duyet)
            {
                case 0:
                    if (butChuyen.ForeColor == Color.Red)
                    {
                        MessageBox.Show("Số liệu đã được duyệt, Bạn không có quyền thay đổi !", "Dược");
                        dsxml.RejectChanges();
                        return;
                    }
                    if (butChuyen.ForeColor == Color.Blue)
                    {
                        MessageBox.Show("Số liệu đã được chuyển, Bạn không thể thay đổi !", "Dược");
                        dsxml.RejectChanges();
                        return;
                    }
                    foreach (DataRow r in dsxml.Tables[0].Select("l1<>sl_cu1", ""))//.Rows)
                    {
                        d.upd_d_dutrungay(i_nhom, s_mmyy, m_ngay.ToString("dd/MM/yyyy"), int.Parse(r["mabd"].ToString()), decimal.Parse(r["k1"].ToString().Trim() == "" ? "0" : r["k1"].ToString().Trim())
                            , decimal.Parse(r["tc"].ToString().Trim() == "" ? "0" : r["tc"].ToString().Trim()), decimal.Parse(r["xuat10"].ToString().Trim() == "" ? "0" : r["xuat10"].ToString().Trim())
                            , decimal.Parse(r["xuat30"].ToString().Trim() == "" ? "0" : r["xuat30"].ToString().Trim()), decimal.Parse(r["slgoiy"].ToString().Trim() == "" ? "0" : r["slgoiy"].ToString().Trim())
                            , decimal.Parse(r["l1"].ToString().Trim() == "" ? "0" : r["l1"].ToString().Trim()), decimal.Parse(r["d1"].ToString().Trim() == "" ? "0" : r["d1"].ToString().Trim())
                            , decimal.Parse(r["l2"].ToString().Trim() == "" ? "0" : r["l2"].ToString().Trim()), decimal.Parse(r["d2"].ToString().Trim() == "" ? "0" : r["d2"].ToString().Trim())
                            , int.Parse(r["dutru"].ToString().Trim() == "" ? "0" : r["dutru"].ToString().Trim()), int.Parse(r["daduyet"].ToString().Trim() == "" ? "0" : r["daduyet"].ToString().Trim()),
                            r["nhacc"].ToString(), r["donvi"].ToString(), i_lanthu, i_manguon, d.i_Chinhanh_hientai);
                        r["sl_cu1"] = r["l1"].ToString();
                    }
                    break;
                case 1:
                    if (butChuyen.ForeColor == Color.Red)
                    {
                        MessageBox.Show("Số liệu đã được duyệt, Bạn không có quyền thay đổi !", "Dược");
                        return;
                    }
                    if (butChuyen.ForeColor == Color.Blue)
                    {
                        MessageBox.Show("Số liệu đã được chuyển, Bạn không thể thay đổi !", "Dược");
                        return;
                    }
                    foreach (DataRow r in dsxml.Tables[0].Select("true", ""))//.Rows)
                    {
                        d.execute_data("update " + d.user + ".d_dutrungay set d1=" + decimal.Parse(r["d1"].ToString().Trim() == "" ? "0" : r["d1"].ToString().Trim()) + ",dutru= 1 where mmyy='" + s_mmyy + "' and mabd=" + int.Parse(r["mabd"].ToString()) + " and nhom=" + i_nhom + " and manguon=" + i_manguon + " and lan=" + i_lanthu +" and dutru= 2 ");
                        r["sl_cu2"] = r["d1"].ToString();
                    }
                    if (!d.upd_d_dutru_duyet(i_lanthu, s_mmyy, i_userid, i_nhom,"idchinhanh", d.i_Chinhanh_hientai, 1))
                    {
                        MessageBox.Show("Không lưu được thông tin duyệt thuốc !", "Dược");
                        success = false;
                    }
                    break;
                case 2:
                    foreach (DataRow r in dsxml.Tables[0].Select("true", ""))//.Rows)
                    {
                        d.execute_data("update " + d.user + ".d_dutrungay set d2=" + decimal.Parse(r["d2"].ToString().Trim() == "" ? "0" : r["d2"].ToString().Trim()) + ",daduyet= 1 where mmyy='" + s_mmyy + "' and mabd=" + int.Parse(r["mabd"].ToString()) + " and nhom=" + i_nhom + " and manguon=" + i_manguon + " and lan=" + i_lanthu + " and daduyet= 2 ");
                        r["sl_cu3"] = r["d2"].ToString();
                    }
                    if (!d.upd_d_dutru_duyet(i_lanthu, s_mmyy, i_userid, i_nhom,"idtrungtam", d.i_Chinhanh_hientai, 1))
                    {
                        MessageBox.Show("Không lưu được thông tin duyệt !", "Dược");
                        success = false;
                    }
                    load_treeView();
                    break;
            }
            if (success)
            {
                MessageBox.Show("Thông tin đã được lưu !", "Dược");
            }
            dsxml.AcceptChanges();
            enableObj(true);
            load_Grid(true);
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
            DataView dv = (DataView)cm.List;
            dv.AllowNew = false;
           // Cursor = Cursors.Default;
        }

        private void butHuy_Click(object sender, EventArgs e)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                switch(i_duyet)
                {
                    case 0:
                        if (butChuyen.ForeColor == Color.Blue)
                        {
                            if (MessageBox.Show(lan.Change_language_MessageText("Số liệu đã được chuyển, Bạn có muốn khôi phục lại trang thái chưa chuyển không ?"), "Dược", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                foreach (DataRow r in dsxml.Tables[0].Rows)//.Rows)
                                {
                                    d.execute_data("update " + d.user + ".d_dutrungay set dutru= 0 where mmyy='" + s_mmyy + "' and mabd=" + int.Parse(r["mabd"].ToString()) + " and nhom=" + i_nhom + " and manguon=" + i_manguon + " and lan=" + i_lanthu + " and dutru= 2 ");
                                }
                                enableObj(true);
                                load_Grid(true);
                                CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
                                DataView dv = (DataView)cm.List;
                                dv.AllowNew = false;
                            }
                            else
                                return;
                        }
                        if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"), d.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                int i_mabd = int.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber, 1].ToString());
                                d.execute_data("delete from " + user + ".d_dutrungay where mmyy='" + s_mmyy + "' and nhom=" + i_nhom + " and mabd=" + i_mabd + " and manguon=" + i_manguon + " and lan=" + i_lanthu + " and idchinhanh=" + d.i_Chinhanh_hientai);
                                d.delrec(dsxml.Tables[0], "mabd=" + i_mabd);
                                d.delrec(ds.Tables[0], "mabd=" + i_mabd);
                                dsxml.AcceptChanges();
                            }
                            catch { }
                        }
                        break;
                    case 1:
                        try
                        {
                            if (butChuyen.ForeColor == Color.Blue)
                            {
                                if (MessageBox.Show("Số liệu đã được chuyển, Bạn có muốn khôi phục trạng thái chưa chuyển không ?", "Dược", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    dsxml.AcceptChanges();
                                    foreach (DataRow r in dsxml.Tables[0].Rows)//.Rows)
                                    {
                                        d.execute_data("update " + d.user + ".d_dutrungay set daduyet= 0,d1=0 where mmyy='" + s_mmyy + "' and mabd=" + int.Parse(r["mabd"].ToString()) + " and nhom=" + i_nhom + " and manguon=" + i_manguon + " and lan=" + i_lanthu + " and daduyet= 2 ");
                                    }
                                }
                                enableObj(true);
                                load_Grid(true);
                                CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
                                DataView dv = (DataView)cm.List;
                                dv.AllowNew = false;
                            }
                        }
                        catch { }
                        break;
                    case 2:
                        try
                        {
                            if (MessageBox.Show(" Bạn có muốn thu hồi lại phiếu duyệt ?", "Dược", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                dsxml.AcceptChanges();
                                foreach (DataRow r in dsxml.Tables[0].Rows)//.Rows)
                                {
                                    d.execute_data("update " + d.user + ".d_dutrungay set daduyet= 2,d2=0 where mmyy='" + s_mmyy + "' and mabd=" + int.Parse(r["mabd"].ToString()) + " and nhom=" + i_nhom + " and manguon=" + i_manguon + " and lan=" + i_lanthu + " and daduyet= 1 ");
                                }
                                enableObj(true);
                                load_Grid(true);
                                load_treeView();
                                CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
                                DataView dv = (DataView)cm.List;
                                dv.AllowNew = false;
                            }

                        }
                        catch { }
                        break;
                }
            }
        }

        private void butMoi_Click(object sender, EventArgs e)
        {
            frmChonmabd f = new frmChonmabd(d, i_nhom, s_manhom, (bNam) ? s_dutrunam : "");
            f.ShowDialog(this);
            if (f.bOk)
            {
                if (f.dsdm.Tables[0].Select("chon=true").Length > 0)
                    foreach (DataRow r in f.dsdm.Tables[0].Select("chon=true"))
                    {
                        sql = "mabd=" + int.Parse(r["id"].ToString());
                        r1 = d.getrowbyid(ds.Tables[0], sql);
                        if (r1 == null)
                        {
                            r2 = d.getrowbyid(dt, "id=" + int.Parse(r["id"].ToString()));
                            if (r2 != null)
                            {
                                r3 = dsxml.Tables[0].NewRow();
                                r3["mabd"] = r["id"].ToString();
                                r3["sttnhom"] = r2["sttnhom"].ToString();
                                r3["ma"] = r2["ma"].ToString();
                                r3["ten"] = r2["ten"].ToString().Trim() + " " + r2["hamluong"].ToString();
                                r3["tenhc"] = r2["tenhc"].ToString().Trim();
                                r3["dang"] = r2["dang"].ToString();
                                r3["tennhom"] = r2["tennhom"].ToString();
                                r3["tenhang"] = r2["tenhang"].ToString();
                                r3["k1"] = 0;
                                //foreach (DataRow r4 in dtkho.Rows) r3["c" + r4["id"].ToString().Trim()] = 0;
                                r3["xuat10"] = 0;
                                r3["xuat30"] = 0;
                                r3["slgoiy"] = 0;
                                r3["l1"] = 0;
                                r3["d1"] = 0;
                                r3["l2"] = 0;
                                r3["d2"] = 0;
                                r3["tc"] = 0;
                                r3["nhacc"] = r2["nhacc"].ToString();
                                r3["donvi"] = r2["donvi"].ToString();
                                r3["sltoithieu"] = r2["sltoithieu"].ToString();
                                r3["sl_cu1"] = 0;
                                r3["sl_cu2"] = 0;
                                dsxml.Tables[0].Rows.Add(r3);
                            }
                        }
                    }
            }
        }

        private void butChuyen_Click(object sender, EventArgs e)
        {
            if (butChuyen.FlatStyle != FlatStyle.Flat)
            {
                butLuu_Click(sender, e);
                if (i_duyet == 0)
                {
                    foreach (DataRow r in dsxml.Tables[0].Rows)//.Rows)
                    {
                        d.execute_data("update " + d.user + ".d_dutrungay set dutru= 2 where mmyy='" + s_mmyy + "' and mabd=" + int.Parse(r["mabd"].ToString()) + " and nhom=" + i_nhom + " and manguon=" + i_manguon + " and lan=" + i_lanthu + " and dutru= 0 ");
                    }
                }
                else
                {
                    if (i_duyet == 1)
                    {
                        string dblink = d.getDBLink();
                        int i_chinhanh = d.i_Chinhanh_hientai;
                        if (dblink == null)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy server trung tâm để chuyển"), d.Msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        foreach (DataRow r in dsxml.Tables[0].Select("d1<>0"))//.Rows)
                        {
                            if (decimal.Parse(r["d1"].ToString().Trim() == "" ? "0" : r["d1"].ToString().Trim()) != 0)
                            {
                                if (!d.upd_d_dutrungay(i_nhom, s_mmyy, m_ngay.ToString("dd/MM/yyyy"), int.Parse(r["mabd"].ToString()), decimal.Parse(r["k1"].ToString().Trim() == "" ? "0" : r["k1"].ToString().Trim())
                                , decimal.Parse(r["tc"].ToString().Trim() == "" ? "0" : r["tc"].ToString().Trim()), decimal.Parse(r["xuat10"].ToString().Trim() == "" ? "0" : r["xuat10"].ToString().Trim())
                                , decimal.Parse(r["xuat30"].ToString().Trim() == "" ? "0" : r["xuat30"].ToString().Trim()), decimal.Parse(r["slgoiy"].ToString().Trim() == "" ? "0" : r["slgoiy"].ToString().Trim())
                                , decimal.Parse(r["l1"].ToString().Trim() == "" ? "0" : r["l1"].ToString().Trim()), decimal.Parse(r["d1"].ToString().Trim() == "" ? "0" : r["d1"].ToString().Trim())
                                , decimal.Parse(r["l2"].ToString().Trim() == "" ? "0" : r["l2"].ToString().Trim()), decimal.Parse(r["d2"].ToString().Trim() == "" ? "0" : r["d2"].ToString().Trim())
                                , int.Parse(r["dutru"].ToString().Trim() == "" ? "0" : r["dutru"].ToString().Trim()), 2,
                                r["nhacc"].ToString(), r["donvi"].ToString(), i_lanthu, i_manguon, i_chinhanh, dblink
                                ))
                                {
                                    MessageBox.Show(lan.Change_language_MessageText("Lưu không thành công"), d.Msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;

                                }
                            }
                        }
                        d.execute_data("update " + d.user + ".d_dutrungay set daduyet= 1 where mmyy='" + s_mmyy + "' and nhom=" + i_nhom + " and manguon=" + i_manguon + " and lan=" + i_lanthu + " and daduyet= 0 ");
                    }
                }
                enableObj(true);
                load_Grid(true);
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
                DataView dv = (DataView)cm.List;
                dv.AllowNew = false;
            }
        }
        private void enableObj(bool ena)
        {
            butMoi.Enabled = ena;
            butLuu.Enabled = ena;
            butHuy.Enabled = ena;
            butMoi.Enabled = ena;
        }

        private void txtTimkiem_Enter(object sender, EventArgs e)
        {
            txtTimkiem.BackColor = Color.PaleGoldenrod;
        }

        private void txtTimkiem_Leave(object sender, EventArgs e)
        {
            txtTimkiem.BackColor = Color.WhiteSmoke;
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            filter_bd(txtTimkiem.Text.Trim());
        }

        private void filter_bd(string p)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
            DataView dv = (DataView)cm.List;
            if (p == "")
            {
                dv.RowFilter = "";
            }
            else
            {
                dv.RowFilter = "ten like '%" + p + "%' or tenhc like '%" + p + "%'";
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Tag.ToString().Trim() != "")
                {
                    if (MessageBox.Show(lan.Change_language_MessageText("Bạn muốn duyệt thuốc:" + e.Node.Text +" ?"), d.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    string[] arr = e.Node.Tag.ToString().Trim().Split(',');
                    if (arr.Length > 0)
                    {
                        //sql = "select a.*,to_char(a.ngay,'dd/mm/yyyy') as ngaydt,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.dang,c.stt as sttnhom,c.ten as tennhom,d.ten as tenhang,";
                        //sql += "b.sltoithieu, b.tenhc, a.l1 as sl_cu1, a.d1 as sl_cu2,a.d2 as sl_cu3,a.slgoiy,a.dutru,a.daduyet ";
                        //if (i_duyet == 2) sql += ", e.ten as cn ";
                        //sql += " from " + user + ".d_dutrungay a," + user + ".d_dmbd b," + user + ".d_dmnhom c," + user + ".d_dmhang d";
                        //if (i_duyet == 2) sql += ", " + user + ".dmchinhanh e ";
                        //sql += " where a.mabd=b.id and b.manhom=c.id and b.mahang=d.id";
                        //if (i_manguon != -1) sql += " and a.manguon=" + i_manguon;
                        //if (i_duyet == 1) sql += " and a.dutru in(2) ";
                        //else if (i_duyet == 2) sql += " and a.daduyet in(2) and e.id = a.idchinhanh ";

                        s_idchinhanh = arr[0];
                        if (arr[1].Trim() != "") s_mmyy =  arr[1];
                        if (arr[2].Trim() != "") i_nhom = int.Parse(arr[2]);
                        if (arr[3].Trim() != "") i_lanthu = int.Parse(arr[3]);
                        if (arr[4].Trim() != "") m_ngay = new DateTime(int.Parse(arr[4].Substring(6, 4)), int.Parse(arr[4].Substring(3, 2)), int.Parse(arr[4].Substring(0, 2)));
                        load_Grid(false);
                        tieude.Text = "Ngày " + m_ngay.ToString("dd/MM/yyyy") + " dự trù lần thứ " + i_lanthu.ToString() + " số liệu tháng " + s_mmyy; 
                        CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
                        DataView dv = (DataView)cm.List;
                        dv.AllowNew = false;
                    }
                }
            }
            catch
            { }
            
        }

        private void songay_ValueChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            load_treeView();
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {

        }

        private void butIn_Click(object sender, EventArgs e)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
                DataView dv = (DataView)cm.List;
                DataSet ds = new DataSet();
                ds.Tables.Add(dv.Table.Copy());
                ds.Tables[0].Columns.Add("i_duyet", typeof(int)).DefaultValue = i_duyet;
                foreach (DataRow r in ds.Tables[0].Rows) r["i_duyet"] = i_duyet;
               if(chkXem.Checked) ds.WriteXml("..//..//dataxml//d_dutrungay.xml", XmlWriteMode.WriteSchema);
                frmReport f = new frmReport(d, ds, i_userid, "", "d_dutrungay.rpt");
                f.ShowDialog();
            }
            catch (Exception er)
            {
                MessageBox.Show(lan.Change_language_MessageText("Lỗi :") + er.Message, "d_dutrungay.rpt");
            }

        }
    }
}