using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Duoc
{
    public partial class frmChuyenDuocbenhvien : Form
    {
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        DataTable dtmedisoft = new DataTable();
        DataTable dtbenhvien = new DataTable();
        DataTable dtdm = new DataTable();
        int nhomkhoTTB = -1;
        public frmChuyenDuocbenhvien()
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
        }
        LibDuoc.AccessData m = new LibDuoc.AccessData();
        private void butTao_Click(object sender, EventArgs e)
        {
            m.execute_data("create table " + user + ".anhxa(ma_medisoft numeric(7) ,ma_benhvien numeric(7),loai varchar(50),constraint pk_anhxa primary key(ma_medisoft,ma_benhvien,loai))");
            m.execute_data("alter table " + user + ".anhxa modify (ma_benhvien numeric(7),ma_medisoft numeric(7))");
            dtdm = m.get_data("select * from " + user + ".anhxa where loai='" + cboSolieu.Tag.ToString() + "'").Tables[0];
        }
        string user = "medibv";
        private void cboSolieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveControl == cboSolieu || sender==null)
            {
                string table_medisoft = "dm_06", table_benhvien = "d_nhombo";
                cboNhomkho.Visible = false;
                switch (cboSolieu.SelectedIndex)
                {
                    case 0://duoc benh vien
                        table_medisoft = "dm_07";
                        table_benhvien = "d_nhombo";
                        cboSolieu.Tag = "bieu_07";
                        dtbenhvien = m.get_data("select id,ten from " + user + "." + table_benhvien + " order by ten").Tables[0];
                        break;
                    case 1://can lam sang
                        table_medisoft = "dm_06";
                        table_benhvien = "v_loaivp";
                        cboSolieu.Tag = "bieu_06";
                        dtbenhvien = m.get_data("select id,ten from " + user + "." + table_benhvien + " order by ten").Tables[0];
                        break;
                    case 3://Hoạt động tài chính
                        table_medisoft = "dm_101";
                        table_benhvien = "";
                        cboSolieu.Tag = "bieu_101";
                        dtbenhvien = m.get_data("select 0 id,'Tổng cộng' ten from dual union all select 1 id,'BN' ten from dual union all select 2 id,'BHYT' ten from dual union all select 3 id,'Viện phí' ten from dual").Tables[0];
                        break;
                    case 4://Hoạt động tài chính 10.2.1 thu vien phí + BHYT
                        table_medisoft = "dm_1021";
                        table_benhvien = "v_loaivp";
                        cboSolieu.Tag = "bieu_1021";
                        dtbenhvien = m.get_data("select id,ten from " + user + "." + table_benhvien + " union all select -id,ten from " + user + ".d_nhombo").Tables[0];
                        break;
                    case 5://Hoạt động tài chính 10.2.2 các khoản chi
                        table_medisoft = "dm_1022";
                        table_benhvien = "d_nhombo";
                        cboSolieu.Tag = "bieu_1022";
                        dtbenhvien = m.get_data("select id,ten from " + user + "." + table_benhvien + " order by ten").Tables[0];
                        break;
                    case 6://Hoạt động tài chính 10.3 các khoản không thu được
                        table_medisoft = "dm_103";
                        table_benhvien = "doituong";
                        cboSolieu.Tag = "bieu_103";
                        dtbenhvien = m.get_data("select madoituong as id,doituong as ten from " + user + "." + table_benhvien + " order by doituong").Tables[0];
                        break;
                    default://trang thiet bi
                        cboNhomkho.Visible = true;
                        cboNhomkho.Enabled = false;
                        cboNhomkho.SelectedValue = nhomkhoTTB;
                        table_medisoft = "dm_08";
                        table_benhvien = "d_dmbd";
                        if (nhomkhoTTB == -1)
                        {
                            dtmedisoft = m.get_data("select ma as id,ten from " + user + "." + table_medisoft + " order by ma").Tables[0];
                            lstNhomMedisoft.DataSource = dtmedisoft;
                            MessageBox.Show(lan.Change_language_MessageText("Vui lòng chọn lại nhóm kho trang thiết bị."));
                            cboNhomkho.Enabled = true;
                            cboNhomkho.Focus();
                            SendKeys.Send("{F4}");
                            return;
                        }
                        dtbenhvien = m.get_data("select id,ten from " + user + "." + table_benhvien + " where nhom=" + nhomkhoTTB + " order by ten").Tables[0];
                        cboSolieu.Tag = "bieu_08";
                        break;
                }
                dtmedisoft = m.get_data("select ma as id,ten from " + user + "." + table_medisoft + " order by ma").Tables[0];
                lstNhomMedisoft.DataSource = dtmedisoft;
                chkNhomBV.DataSource = dtbenhvien;
                chkNhomBV.ValueMember = "ID";
                chkNhomBV.DisplayMember = "TEN";
                try
                {
                    dtdm = m.get_data("select * from " + user + ".anhxa where loai='" + cboSolieu.Tag.ToString() + "'").Tables[0];
                }
                catch
                {
                    butTao_Click(null, null);
                }
            }
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            if (cboNhomkho.Visible && cboNhomkho.Enabled)
            {
                if (cboNhomkho.Items.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhóm kho chưa được khai trong chương trình dược"));
                    return;
                }
                if (cboNhomkho.SelectedIndex==-1)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Vui lòng chọn nhóm kho trang thiết bị"));
                    cboNhomkho.Focus();
                    SendKeys.Send("{F4}");
                    return;
                }
                m.upd_thongso((int)LibDuoc.AccessData.id_thongso.ID_NhomKhoTTB, cboNhomkho.SelectedValue.ToString());
                nhomkhoTTB = int.Parse(cboNhomkho.SelectedValue.ToString());
                cboNhomkho.Enabled = false;
            }
            string strMamedisoft = lstNhomMedisoft.SelectedValue.ToString();
            m.execute_data("delete from " + user + ".anhxa where ma_medisoft=" + strMamedisoft + " and loai='" + cboSolieu.Tag.ToString() + "'");
            string strMabenhvien = "";
            for (int i = 0; i < chkNhomBV.Items.Count; i++)
            {
                if (chkNhomBV.GetItemChecked(i))
                {
                    strMabenhvien = dtbenhvien.Rows[i]["id"].ToString();
                    m.upd_anhxa(int.Parse(strMamedisoft), int.Parse(strMabenhvien), cboSolieu.Tag.ToString());
                }
            }
            dtdm = m.get_data("select * from " + user + ".anhxa where loai='" + cboSolieu.Tag.ToString() + "'").Tables[0];
        }

        private void frmChuyenDuocbenhvien_Load(object sender, EventArgs e)
        {
            user = m.user;
            txtTungay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            txtDenngay.Value = txtTungay.Value;
            lstNhomMedisoft.ValueMember = "ID";
            lstNhomMedisoft.DisplayMember = "TEN";
            cboNhomkho.ValueMember = "ID";
            cboNhomkho.DisplayMember = "TEN";
            cboNhomkho.DataSource = m.get_data("select id,ten from " + user + ".d_dmnhomkho order by ten").Tables[0];
            nhomkhoTTB = m.NhomTTB;
            cboSolieu.SelectedIndex = 0;
            cboSolieu_SelectedIndexChanged(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstNhomMedisoft_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveControl == lstNhomMedisoft)
            {
                for (int i = 0; i < chkNhomBV.Items.Count; i++)
                {
                    chkNhomBV.SetItemChecked(i, false);
                }
                string strMamedisoft = lstNhomMedisoft.SelectedValue.ToString();
                DataRow[] r = dtdm.Select("ma_medisoft=" + strMamedisoft);
                for (int j = 0; j < r.Length; j++)
                {
                    string strMabenhvien = r[j]["ma_benhvien"].ToString();
                    for (int i = 0; i < chkNhomBV.Items.Count; i++)
                    {
                        if (dtbenhvien.Rows[i]["id"].ToString() == strMabenhvien)
                        {
                            chkNhomBV.SetItemChecked(i, true);
                        }
                    }
                }
            }
        }

        private void butChuyen_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(txtTungay.Value,txtDenngay.Value) > 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Vui lòng chọn lại ngày"));
                txtTungay.Focus();
                SendKeys.Send("{F4}");
                return;
            }
            Cursor = Cursors.WaitCursor;
            switch (cboSolieu.SelectedIndex)
            {
                case 0:
                    chuyen_bieu07(txtTungay.Text, txtDenngay.Text);
                    break;
                case 1:
                    chuyen_bieu06(txtTungay.Text, txtDenngay.Text);
                    break;
                case 3:
                    chuyen_bieu101(txtTungay.Text, txtDenngay.Text);
                    break;
                case 4:
                    chuyen_bieu1021(txtTungay.Text, txtDenngay.Text);
                    break;
                case 5:
                    chuyen_bieu1022(txtTungay.Text, txtDenngay.Text);
                    break;
                case 6:
                    chuyen_bieu103(txtTungay.Text, txtDenngay.Text);
                    break;
                default:
                    chuyen_bieu08(txtTungay.Text, txtDenngay.Text);
                    break;
            }
            Cursor = Cursors.Default;
        }
        void chuyen_bieu06(string tungay, string denngay)
        {
            DateTime dt1 = m.StringToDate(tungay).AddDays(-m.iNgaykiemke);
            DateTime dt2 = m.StringToDate(denngay).AddDays(m.iNgaykiemke);
            string sql = "", strInsert = "insert into " + user + ".bieu_06(id,ma,ngay,userid,c01,c02) select to_number(replace(ngay,'/','')) as id,ma,";
            strInsert += " to_date(ngay,'dd/mm/yyyy') as ngay,-1 as userid,sum(c01) as c01,sum(c02) as c02 from ( ";
            while (DateTime.Compare(dt1, dt2.AddMonths(1)) < 0)
            {
                string mmyy = dt1.Month.ToString().PadLeft(2, '0') + dt1.Year.ToString().Substring(2);
                if (m.bMmyy(mmyy))
                {
                    string usermmyy = user + mmyy;
                    sql += sql == "" ? "" : " union all ";
                    //sql += "select 0 id,e.ma_medisoft as ma,to_char(a.ngay,'dd/mm/yyyy') as ngay,sum(b.solan) as c01,sum(decode(a.loaibn,1,solan,0)) as c02 ";
                    sql += "select 0 id,e.ma_medisoft as ma,to_char(a.ngay,'dd/mm/yyyy') as ngay,sum(b.solan) as c01,sum((case a.loaibn=1 then solan else 0 end)) as c02 ";
                    sql += "from " + usermmyy + ".cdha_bnll a inner join " + usermmyy + ".cdha_bnct b on a.id=b.id inner join ";
                    sql += user + ".cdha_kythuat d on b.makt=d.id inner join "+user+".v_giavp c on d.idvp=c.id inner join " + user + ".anhxa e on c.id_loai=e.ma_benhvien ";
                    sql += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy')";
                    sql += " and e.loai='bieu_06' group by e.ma_medisoft,to_char(a.ngay,'dd/mm/yyyy')";
                    sql += " union all ";
                    //sql += "select distinct a.id,e.ma_medisoft as ma,to_char(a.ngay,'dd/mm/yyyy') as ngay,d.tieuban as c01,decode(a.loaibn,1,d.tieuban,0) as c02 ";
                    sql += "select distinct a.id,e.ma_medisoft as ma,to_char(a.ngay,'dd/mm/yyyy') as ngay,d.tieuban as c01,(case when a.loaibn=1 then d.tieuban else 0 end) as c02 ";
                    sql += "from " + usermmyy + ".xn_phieu a inner join " + usermmyy + ".xn_ketqua b on a.id=b.id inner join " + user + ".xn_bv_chitiet e on b.id_ten=e.id inner join ";
                    sql += user + ".xn_bv_ten d on e.id_bv_ten=d.id inner join " + user + ".v_giavp c on d.id_vienphi=c.id inner join " + user + ".anhxa e on c.id_loai=e.ma_benhvien ";
                    sql += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy')";
                    sql += " and e.loai='bieu_06'";
                }
                dt1 = dt1.AddMonths(1);
            }
            if (sql == "") return;
            strInsert += sql + ") group by to_number(replace(ngay,'/','')),ma,to_date(ngay,'dd/mm/yyyy')";
            m.execute_data("delete from " + user + ".bieu_06 where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy') and userid=-1");
            m.execute_data(strInsert);
        }
        void chuyen_bieu07(string tungay, string denngay)
        {
            DateTime dt1 = m.StringToDate(tungay).AddDays(-m.iNgaykiemke);
            DateTime dt2 = m.StringToDate(denngay).AddDays(m.iNgaykiemke);
            string sql = "",strInsert="insert into "+user+".bieu_07(id,ma,ngay,soluong,userid) select to_number(replace(ngay,'/','')) as id,ma,";
            strInsert+=" to_date(ngay,'dd/mm/yyyy') as ngay,case when ma<9 then sum(soluong) else sum(soluong*round((dongia/1000),2)) end as soluong,-1 as userid from ( ";
            while (DateTime.Compare(dt1, dt2.AddMonths(1)) < 0)
            {
                string mmyy = dt1.Month.ToString().PadLeft(2, '0') + dt1.Year.ToString().Substring(2);
                if (m.bMmyy(mmyy))
                {
                    string usermmyy = user + mmyy;
                    sql += sql == "" ? "" : " union all ";
                    //sql += "select nvl(e.ma_medisoft,26) as ma,to_char(a.ngay,'dd/mm/yyyy') as ngay,sum(decode(a.loai,3,-b.soluong,b.soluong)) soluong,";
                    sql += "select nvl(e.ma_medisoft,26) as ma,to_char(a.ngay,'dd/mm/yyyy') as ngay,sum((case when a.loai=3 then -b.soluong else b.soluong end)) soluong,";
                    sql += "c.giamua dongia from " + usermmyy + ".d_xuatsdll a inner join " + usermmyy + ".d_xuatsdct b on a.id=b.id inner join ";
                    sql += usermmyy + ".d_theodoi c on b.sttt=c.id inner join " + user + ".d_dmbd d on b.mabd=d.id left join "+user+".anhxa e on d.nhombo=e.ma_benhvien ";
                    sql += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy')";
                    sql += " and e.loai='bieu_07' group by nvl(e.ma_medisoft,26),to_char(a.ngay,'dd/mm/yyyy'),c.giamua";
                    sql += " union all ";
                    sql += "select nvl(e.ma_medisoft,26) as ma,to_char(a.ngay,'dd/mm/yyyy') as ngay,sum(b.soluong) soluong,c.giamua dongia ";
                    sql += " from " + usermmyy + ".d_xuatll a inner join " + usermmyy + ".d_xuatct b on a.id=b.id inner join ";
                    sql += usermmyy + ".d_theodoi c on b.sttt=c.id inner join " + user + ".d_dmbd d on b.mabd=d.id left join " + user + ".anhxa e on d.nhombo=e.ma_benhvien ";
                    sql += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy')";
                    sql += " and e.loai='bieu_07' and a.loai='XK' group by nvl(e.ma_medisoft,26),to_char(a.ngay,'dd/mm/yyyy'),c.giamua";
                    sql += " union all ";
                    sql += "select nvl(e.ma_medisoft,26) as ma,to_char(a.ngay,'dd/mm/yyyy') as ngay,sum(b.soluong) soluong,c.giamua dongia ";
                    sql += " from " + usermmyy + ".bhytkb a inner join " + usermmyy + ".bhytthuoc b on a.id=b.id inner join ";
                    sql += usermmyy + ".d_theodoi c on b.sttt=c.id inner join " + user + ".d_dmbd d on b.mabd=d.id left join " + user + ".anhxa e on d.nhombo=e.ma_benhvien ";
                    sql += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy')";
                    sql += " and e.loai='bieu_07' group by nvl(e.ma_medisoft,26),to_char(a.ngay,'dd/mm/yyyy'),c.giamua";
                    sql += " union all ";
                    sql += "select nvl(e.ma_medisoft,26) as ma,to_char(a.ngay,'dd/mm/yyyy') as ngay,sum(b.soluong) soluong,c.giamua dongia ";
                    sql += " from " + usermmyy + ".d_ngtrull a inner join " + usermmyy + ".d_ngtruct b on a.id=b.id inner join ";
                    sql += usermmyy + ".d_theodoi c on b.sttt=c.id inner join " + user + ".d_dmbd d on b.mabd=d.id left join " + user + ".anhxa e on d.nhombo=e.ma_benhvien ";
                    sql += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy')";
                    sql += " and e.loai='bieu_07' group by nvl(e.ma_medisoft,26),to_char(a.ngay,'dd/mm/yyyy'),c.giamua";
                }
                dt1 = dt1.AddMonths(1);
            }
            if (sql == "") return;
            strInsert += sql + ")b07 group by to_number(replace(ngay,'/','')),ma,to_date(ngay,'dd/mm/yyyy')";
            m.execute_data("delete from " + user + ".bieu_07 where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy') and userid=-1");
            m.execute_data(strInsert);
        }
        void chuyen_bieu08(string tungay, string denngay)
        {
            return;
            DateTime dt1 = m.StringToDate(tungay).AddDays(-m.iNgaykiemke);
            DateTime dt2 = m.StringToDate(denngay).AddDays(m.iNgaykiemke);
            string sql = "", strInsert = "insert into " + user + ".bieu_08(id,ma,ngay,soluong,userid) select to_number(replace(ngay,'/','')) as id,ma,";
            strInsert += " to_date(ngay,'dd/mm/yyyy') as ngay,case when ma<9 then sum(soluong) else sum(soluong*round((dongia/1000),2)) end as soluong,-1 as userid from ( ";
            while (DateTime.Compare(dt1, dt2.AddMonths(1)) < 0)
            {
                string mmyy = dt1.Month.ToString().PadLeft(2, '0') + dt1.Year.ToString().Substring(2);
                if (m.bMmyy(mmyy))
                {
                    string usermmyy = user + mmyy;
                    sql += sql == "" ? "" : " union all ";
                    //sql += "select nvl(e.ma_medisoft,26) as ma,to_char(a.ngay,'dd/mm/yyyy') as ngay,sum(decode(a.loai,3,-b.soluong,b.soluong)) soluong,";
                    sql += "select nvl(e.ma_medisoft,26) as ma,to_char(a.ngay,'dd/mm/yyyy') as ngay,sum((case when a.loai=3 then -b.soluong else b.soluong end)) soluong,";
                    sql += "c.giamua dongia from " + usermmyy + ".d_xuatsdll a inner join " + usermmyy + ".d_xuatsdct b on a.id=b.id inner join ";
                    sql += usermmyy + ".d_theodoi c on b.sttt=c.id inner join " + user + ".d_dmbd d on b.mabd=d.id left join " + user + ".anhxa e on d.nhombo=e.ma_benhvien ";
                    sql += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy')";
                    sql += " and e.loai='bieu_08' group by nvl(e.ma_medisoft,26),to_char(a.ngay,'dd/mm/yyyy'),c.giamua";
                    sql += " union all ";
                    sql += "select nvl(e.ma_medisoft,26) as ma,to_char(a.ngay,'dd/mm/yyyy') as ngay,sum(b.soluong) soluong,c.giamua dongia ";
                    sql += " from " + usermmyy + ".d_xuatll a inner join " + usermmyy + ".d_xuatct b on a.id=b.id inner join ";
                    sql += usermmyy + ".d_theodoi c on b.sttt=c.id inner join " + user + ".d_dmbd d on b.mabd=d.id left join " + user + ".anhxa e on d.nhombo=e.ma_benhvien ";
                    sql += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy')";
                    sql += " and e.loai='bieu_08' and a.loai='XK' group by nvl(e.ma_medisoft,26),to_char(a.ngay,'dd/mm/yyyy'),c.giamua";
                    sql += " union all ";
                    sql += "select nvl(e.ma_medisoft,26) as ma,to_char(a.ngay,'dd/mm/yyyy') as ngay,sum(b.soluong) soluong,c.giamua dongia ";
                    sql += " from " + usermmyy + ".bhytkb a inner join " + usermmyy + ".bhytthuoc b on a.id=b.id inner join ";
                    sql += usermmyy + ".d_theodoi c on b.sttt=c.id inner join " + user + ".d_dmbd d on b.mabd=d.id left join " + user + ".anhxa e on d.nhombo=e.ma_benhvien ";
                    sql += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy')";
                    sql += " and e.loai='bieu_08' group by nvl(e.ma_medisoft,26),to_char(a.ngay,'dd/mm/yyyy'),c.giamua";
                    sql += " union all ";
                    sql += "select nvl(e.ma_medisoft,26) as ma,to_char(a.ngay,'dd/mm/yyyy') as ngay,sum(b.soluong) soluong,c.giamua dongia ";
                    sql += " from " + usermmyy + ".d_ngtrull a inner join " + usermmyy + ".d_ngtruct b on a.id=b.id inner join ";
                    sql += usermmyy + ".d_theodoi c on b.sttt=c.id inner join " + user + ".d_dmbd d on b.mabd=d.id left join " + user + ".anhxa e on d.nhombo=e.ma_benhvien ";
                    sql += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy')";
                    sql += " and e.loai='bieu_08' and a.loai='XK' group by nvl(e.ma_medisoft,26),to_char(a.ngay,'dd/mm/yyyy'),c.giamua";
                }
                dt1 = dt1.AddMonths(1);
            }
            if (sql == "") return;
            strInsert += sql + ") group by to_number(replace(ngay,'/','')),ma,to_date(ngay,'dd/mm/yyyy')";
            m.execute_data("delete from " + user + ".bieu_08 where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy') and userid=-1");
            m.execute_data(strInsert);
        }
        void chuyen_bieu101(string tungay, string denngay)
        {
            string mavp = "", mabhyt = "", matongcong = "", matongthu = "";
            foreach (DataRow r in m.get_data("select a.ma,b.ma_benhvien from " + user + ".dm_101 a inner join " + user + ".anhxa b on a.ma=b.ma_medisoft where b.loai='bieu_101' and ma_benhvien in(0,1,2,3)").Tables[0].Rows)
            {
                if (r["ma_benhvien"].ToString() == "1") mavp = r["ma"].ToString().Trim();
                else if (r["ma_benhvien"].ToString() == "3") matongcong = r["ma"].ToString().Trim();
                else if (r["ma_benhvien"].ToString() == "0") matongthu = r["ma"].ToString().Trim();
                else mabhyt = r["ma"].ToString().Trim();
                if (mavp != "" && mabhyt != "" && matongcong != "" && matongthu != "") break;
            }
            if (mavp == "" && mabhyt == "" && matongcong == "" && matongthu == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Thông tin khai báo chưa chính xác."));
                Cursor = Cursors.Default;
                return;
            }
            DateTime dt1 = m.StringToDate(tungay).AddDays(-m.iNgaykiemke);
            DateTime dt2 = m.StringToDate(denngay).AddDays(m.iNgaykiemke);
            string sql = "", strInsert = "insert into " + user + ".bieu_101(id,ma,ngay,sotien,userid)";
            strInsert = " select to_number(replace(ngay,'/','')) as id," + mavp + " as ma,ngay,sum(sotien)/1000 as sotien,-1 as userid from ( ";
            while (DateTime.Compare(dt1, dt2.AddMonths(1)) < 0)
            {
                string mmyy = dt1.Month.ToString().PadLeft(2, '0') + dt1.Year.ToString().Substring(2);
                if (m.bMmyy(mmyy))
                {
                    string usermmyy = user + mmyy;
                    sql += sql == "" ? "" : " union all ";
                    sql += "select to_char(a.ngay,'dd/mm/yyyy') as ngay,sum(b.soluong*round(b.dongia,2)) sotien";
                    sql += " from " + usermmyy + ".v_vienphill a inner join " + usermmyy + ".v_vienphict b on a.id=b.id inner join ";
                    sql += "(select id from " + user + ".v_giavp union all select id from " + user + ".d_dmbd) c on b.mavp=c.id inner join " + user + ".doituong d on b.madoituong=d.madoituong ";
                    sql += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy')";
                    sql += " and d.mien=0 and b.madoituong<>5 group by to_char(a.ngay,'dd/mm/yyyy')";
                    sql += " union all ";
                    sql += "select to_char(a.ngay,'dd/mm/yyyy') as ngay,sum(b.soluong*round(b.dongia,2)) sotien";
                    sql += " from " + usermmyy + ".v_ttrvll a inner join " + usermmyy + ".v_ttrvct b on a.id=b.id inner join ";
                    sql += "(select id from " + user + ".v_giavp union all select id from " + user + ".d_dmbd) c on b.mavp=c.id inner join " + user + ".doituong d on b.madoituong=d.madoituong ";
                    sql += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy')";
                    sql += " and d.mien=0 and b.madoituong<>5 group by to_char(a.ngay,'dd/mm/yyyy')";
                }
                dt1 = dt1.AddMonths(1);
            }
            if (sql == "") return;
            strInsert += sql + ") group by to_number(replace(ngay,'/','')),ngay";
            m.execute_data("delete from " + user + ".bieu_101 where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy') and userid=-1");
            foreach (DataRow r in m.get_data(strInsert).Tables[0].Rows)
            {
                m.upd_bieu101(decimal.Parse(r["id"].ToString()), int.Parse(mavp), r["ngay"].ToString(), decimal.Parse(r["sotien"].ToString()), -1);
                m.upd_bieu101(decimal.Parse(r["id"].ToString()), int.Parse(matongcong), r["ngay"].ToString(), decimal.Parse(r["sotien"].ToString()), -1);
                m.upd_bieu101(decimal.Parse(r["id"].ToString()), int.Parse(matongthu), r["ngay"].ToString(), decimal.Parse(r["sotien"].ToString()), -1);
            }
            //bhyt
            dt1 = m.StringToDate(tungay).AddDays(-m.iNgaykiemke);
            dt2 = m.StringToDate(denngay).AddDays(m.iNgaykiemke);
            sql = "";
            strInsert = "select to_number(replace(ngay,'/','')) as id," + mavp + " as ma,ngay,sum(sotien)/1000 as sotien,sum(bhyt)/1000 as bhyt,-1 as userid from ( ";
            while (DateTime.Compare(dt1, dt2.AddMonths(1)) < 0)
            {
                string mmyy = dt1.Month.ToString().PadLeft(2, '0') + dt1.Year.ToString().Substring(2);
                if (m.bMmyy(mmyy))
                {
                    string usermmyy = user + mmyy;
                    sql += sql == "" ? "" : " union all ";
                    sql += "select to_char(a.ngay,'dd/mm/yyyy') as ngay,sum(b.soluong*round(b.dongia,2)) as sotien,sum(bhyttra) as bhyt";
                    sql += " from " + usermmyy + ".v_ttrvll a inner join " + usermmyy + ".v_ttrvct b on a.id=b.id inner join ";
                    sql += "(select id from " + user + ".v_giavp union all select id from " + user + ".d_dmbd) c on b.mavp=c.id inner join " + user + ".doituong d on b.madoituong=d.madoituong ";
                    sql += " inner join " + usermmyy + ".v_ttrvbhyt f on a.id=f.id where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy')";
                    sql += " and b.madoituong=1 group by to_char(a.ngay,'dd/mm/yyyy')";
                }
                dt1 = dt1.AddMonths(1);
            }
            if (sql == "") return;
            strInsert += sql + ") group by to_number(replace(ngay,'/','')),ngay";
            foreach (DataRow r in m.get_data(strInsert).Tables[0].Rows)
            {
                decimal dSotien = decimal.Parse(r["sotien"].ToString());
                decimal dBhyt = decimal.Parse(r["bhyt"].ToString());
                decimal dvp = dSotien - dBhyt;
                m.upd_bieu101(decimal.Parse(r["id"].ToString()), int.Parse(mabhyt), r["ngay"].ToString(), dBhyt, -1);
                m.upd_bieu101(decimal.Parse(r["id"].ToString()), int.Parse(mavp), r["ngay"].ToString(), dvp, -1);
                m.upd_bieu101(decimal.Parse(r["id"].ToString()), int.Parse(matongcong), r["ngay"].ToString(), dSotien, -1);
                m.upd_bieu101(decimal.Parse(r["id"].ToString()), int.Parse(matongthu), r["ngay"].ToString(), dSotien, -1);
            }
        }
        void chuyen_bieu1021(string tungay, string denngay)
        {
            DateTime dt1 = m.StringToDate(tungay).AddDays(-m.iNgaykiemke);
            DateTime dt2 = m.StringToDate(denngay).AddDays(m.iNgaykiemke);
            string sql = "", strInsert = "insert into " + user + ".bieu_1021(id,ma,ngay,vienphi,bhyt,userid)";
            strInsert += " select to_number(replace(ngay,'/','')) as id, ma,to_date(ngay,'dd/mm/yyyy') as ngay,sum(vienphi)/1000 as vienphi,sum(bhyt)/1000 as bhyt, -1 as userid from ( ";
            while (DateTime.Compare(dt1, dt2.AddMonths(1)) < 0)
            {
                string mmyy = dt1.Month.ToString().PadLeft(2, '0') + dt1.Year.ToString().Substring(2);
                if (m.bMmyy(mmyy))
                {
                    string usermmyy = user + mmyy;
                    sql += sql == "" ? "" : " union all ";
                    sql += "select to_char(a.ngay,'dd/mm/yyyy') as ngay,to_number(nvl(e.ma_medisoft,-1)) as ma,sum(b.soluong*round(b.dongia,2)) vienphi,0 bhyt";
                    sql += " from " + usermmyy + ".v_vienphill a inner join " + usermmyy + ".v_vienphict b on a.id=b.id inner join ";
                    sql += "(select x.id,x.id_loai from " + user + ".v_giavp x union all select id,-nhombo as id_loai from " + user + ".d_dmbd) c on b.mavp=c.id inner join " + user + ".doituong d on b.madoituong=d.madoituong ";
                    sql += " inner join " + user + ".anhxa e on c.id_loai=e.ma_benhvien ";
                    sql += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy')";
                    sql += " and d.mien=0 and b.madoituong<>5 and e.loai='bieu_1021' group by to_char(a.ngay,'dd/mm/yyyy'),to_number(nvl(e.ma_medisoft,-1))";
                    sql += " union all ";
                    sql += "select to_char(a.ngay,'dd/mm/yyyy') as ngay,to_number(nvl(e.ma_medisoft,-1)) as ma,sum(b.soluong*round(b.dongia,2)) vienphi,0 bhyt";
                    sql += " from " + usermmyy + ".v_ttrvll a inner join " + usermmyy + ".v_ttrvct b on a.id=b.id inner join ";
                    sql += "(select x.id,x.id_loai from " + user + ".v_giavp x union all select id,-nhombo as id_loai from " + user + ".d_dmbd) c on b.mavp=c.id inner join " + user + ".doituong d on b.madoituong=d.madoituong ";
                    sql += " inner join " + user + ".anhxa e on c.id_loai=e.ma_benhvien ";
                    sql += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy')";
                    sql += " and d.mien=0 and b.madoituong<>5 and e.loai='bieu_1021' group by to_char(a.ngay,'dd/mm/yyyy'),to_number(nvl(e.ma_medisoft,-1))";
                    sql += " union all ";
                    sql += "select to_char(a.ngay,'dd/mm/yyyy') as ngay,to_number(nvl(e.ma_medisoft,-1)) as ma,sum(b.soluong*round(b.dongia,2)-b.bhyttra) vienphi,sum(b.bhyttra) bhyt";
                    sql += " from " + usermmyy + ".v_ttrvll a inner join " + usermmyy + ".v_ttrvct b on a.id=b.id inner join ";
                    sql += "(select x.id,x.id_loai from " + user + ".v_giavp x union all select id,-nhombo as id_loai from " + user + ".d_dmbd) c on b.mavp=c.id inner join " + user + ".doituong d on b.madoituong=d.madoituong ";
                    sql += " inner join " + user + ".anhxa e on c.id_loai=e.ma_benhvien ";
                    sql += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy')";
                    sql += " and b.madoituong=1 and e.loai='bieu_1021' group by to_char(a.ngay,'dd/mm/yyyy'),to_number(nvl(e.ma_medisoft,-1))";
                }
                dt1 = dt1.AddMonths(1);
            }
            if (sql == "") return;
            strInsert += sql + ") group by to_number(replace(ngay,'/','')),ma,to_date(ngay,'dd/mm/yyyy')";
            m.execute_data("delete from " + user + ".bieu_1021 where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy') and userid=-1");
            m.execute_data(strInsert);
        }
        void chuyen_bieu1022(string tungay, string denngay)
        {
            DateTime dt1 = m.StringToDate(tungay).AddDays(-m.iNgaykiemke);
            DateTime dt2 = m.StringToDate(denngay).AddDays(m.iNgaykiemke);
            string sql = "", strInsert = "insert into " + user + ".bieu_1022(id,ma,ngay,sotien,userid)";
            strInsert += " select to_number(replace(ngay,'/','')) as id, ma,to_date(ngay,'dd/mm/yyyy') as ngay,sum(sotien)/1000 as sotien, -1 as userid from ( ";
            while (DateTime.Compare(dt1, dt2.AddMonths(1)) < 0)
            {
                string mmyy = dt1.Month.ToString().PadLeft(2, '0') + dt1.Year.ToString().Substring(2);
                if (m.bMmyy(mmyy))
                {
                    string usermmyy = user + mmyy;
                    sql += sql == "" ? "" : " union all ";
                    sql += "select to_char(a.ngaysp,'dd/mm/yyyy') as ngay,to_number(nvl(e.ma_medisoft,-1)) as ma,sum(b.soluong*round(b.dongia,2)) sotien";
                    sql += " from " + usermmyy + ".d_nhapll a inner join " + usermmyy + ".d_nhapct b on a.id=b.id inner join ";
                    sql += "(select id,nhombo from " + user + ".d_dmbd) c on b.mabd=c.id ";
                    sql += " inner join " + user + ".anhxa e on c.nhombo=e.ma_benhvien ";
                    sql += " where to_date(to_char(a.ngaysp,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy')";
                    sql += " and e.loai='bieu_1022' group by to_char(a.ngaysp,'dd/mm/yyyy'),to_number(nvl(e.ma_medisoft,-1))";
                }
                dt1 = dt1.AddMonths(1);
            }
            if (sql == "") return;
            strInsert += sql + ") group by to_number(replace(ngay,'/','')),ma,to_date(ngay,'dd/mm/yyyy')";
            m.execute_data("delete from " + user + ".bieu_1022 where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy') and userid=-1");
            m.execute_data(strInsert);
        }
        void chuyen_bieu103(string tungay, string denngay)
        {
            DateTime dt1 = m.StringToDate(tungay).AddDays(-m.iNgaykiemke);
            DateTime dt2 = m.StringToDate(denngay).AddDays(m.iNgaykiemke);
            string sql = "", strInsert = "insert into " + user + ".bieu_103(id,ma,ngay,vienphi,bhyt,userid)";
            strInsert += " select to_number(replace(ngay,'/','')) as id, ma,to_date(ngay,'dd/mm/yyyy') as ngay,sum(vienphi)/1000 as vienphi,sum(bhyt)/1000 as bhyt, -1 as userid from ( ";
            while (DateTime.Compare(dt1, dt2.AddMonths(1)) < 0)
            {
                string mmyy = dt1.Month.ToString().PadLeft(2, '0') + dt1.Year.ToString().Substring(2);
                if (m.bMmyy(mmyy))
                {
                    string usermmyy = user + mmyy;
                    sql += sql == "" ? "" : " union all ";
                    sql += "select to_char(a.ngay,'dd/mm/yyyy') as ngay,to_number(nvl(e.ma_medisoft,-1)) as ma,sum(b.soluong*round(b.dongia,2)) vienphi,0 bhyt";
                    sql += " from " + usermmyy + ".v_vienphill a inner join " + usermmyy + ".v_vienphict b on a.id=b.id inner join ";
                    sql += "(select x.id,x.id_loai from " + user + ".v_giavp x union all select id,-nhombo as id_loai from " + user + ".d_dmbd) c on b.mavp=c.id ";
                    sql += " inner join " + user + ".anhxa e on b.madoituong=e.ma_benhvien ";
                    sql += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy')";
                    sql += " and d.mien=0 and b.madoituong<>5 and e.loai='bieu_103' group by to_char(a.ngay,'dd/mm/yyyy'),to_number(nvl(e.ma_medisoft,-1))";
                    sql += " union all ";
                    sql += "select to_char(a.ngay,'dd/mm/yyyy') as ngay,to_number(nvl(e.ma_medisoft,-1)) as ma,sum(b.soluong*round(b.dongia,2)) vienphi,0 bhyt";
                    sql += " from " + usermmyy + ".v_ttrvll a inner join " + usermmyy + ".v_ttrvct b on a.id=b.id inner join ";
                    sql += "(select x.id,x.id_loai from " + user + ".v_giavp x union all select id,-nhombo as id_loai from " + user + ".d_dmbd) c on b.mavp=c.id ";
                    sql += " inner join " + user + ".anhxa e on b.madoituong=e.ma_benhvien ";
                    sql += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy')";
                    sql += " and d.mien=0 and b.madoituong<>5 and e.loai='bieu_103' group by to_char(a.ngay,'dd/mm/yyyy'),to_number(nvl(e.ma_medisoft,-1))";
                }
                dt1 = dt1.AddMonths(1);
            }
            if (sql == "") return;
            strInsert += sql + ") group by to_number(replace(ngay,'/','')),ma,to_date(ngay,'dd/mm/yyyy')";
            m.execute_data("delete from " + user + ".bieu_103 where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tungay + "','dd/mm/yyyy') and to_date('" + denngay + "','dd/mm/yyyy') and userid=-1");
            m.execute_data(strInsert);
        }

        private void frmChuyenDuocbenhvien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                butTao.Enabled = !butTao.Enabled;
                butLuu.Enabled = !butLuu.Enabled;
                cboNhomkho.Enabled = true;
            }
            else
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
        }

        private void cboNhomkho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveControl == cboNhomkho)
            {
                try
                {
                    nhomkhoTTB = int.Parse(cboNhomkho.SelectedValue.ToString());
                    dtbenhvien = m.get_data("select id,ten||' ('||dang||')' as ten from d_dmbd where nhom=" + nhomkhoTTB + " order by ten,dang").Tables[0];
                    chkNhomBV.DataSource = dtbenhvien;
                    chkNhomBV.ValueMember = "ID";
                    chkNhomBV.DisplayMember = "TEN";
                }
                catch { }
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ActiveControl == chkAll)
            {
                for (int i = 0; i < chkNhomBV.Items.Count; i++)
                {
                    chkNhomBV.SetItemChecked(i, chkAll.Checked);
                }
            }
        }
    }
}