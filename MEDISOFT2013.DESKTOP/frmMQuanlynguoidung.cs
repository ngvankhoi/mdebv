using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MEDISOFT2011.DESKTOP
{
    public partial class frmMQuanlynguoidung : Form
    {
        public LibVP.AccessData v;
        Medisoft.Language lan = new Medisoft.Language();
        public frmMQuanlynguoidung()
        {
            v = new LibVP.AccessData();
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            f_PrepareDB();
         }
        private void frmMQuanlynguoidung_Load(object sender, EventArgs e)
        {
            //f_Load_TreeMenu(treeBenhnhan, v.get_data("select * from medibv.m_menuitem"));
            //f_Load_TreeMenu(treeVienphi, v.get_data("select * from medibv.v_menuitem"));
            //f_Load_TreeMenu(treeDuoc, v.get_data("select * from medibv.d_menuitem"));
            //f_Load_TreeMenu(treeXetnghiem, v.get_data("select * from medibv.xn_menuitem"));
            //f_Load_TreeMenu(treeCDHA, v.get_data("select * from medibv.cdha_menuitem"));
            //f_Load_TreeMenu(treeNhansu, v.get_data("select * from medibv.ns_menuitem"));
            //f_Load_TreeMenu(treeBaocao, v.get_data("select * from medibv.rp_menuitem"));
            //f_Load_TreeMenu(treeCT, v.get_data("select * from medibv.ct_menuitem"));
            f_Load_DG();
        }
        private void f_PrepareDB()
        {
            f_CreateDBMenu("m~v~d~xn~cdha~ns~rp~ct");
            try
            {
                if (v.get_data("select * from medibv.mdlogin where 1=0").Tables[0].Rows.Count > 0)
                {
                    string aok = "";
                }
            }
            catch
            {
                v.execute_data("CREATE TABLE medibv.mdlogin(id numeric(10,0) NOT NULL DEFAULT 0,userid character varying(20),password_ character varying(10),hoten text,ngaysinh character varying(10),gioitinh numeric(1,0) NOT NULL DEFAULT 0,diachi text,dtnha text,dtcoquan text,dtdidong text,email text,admin_ numeric(1,0) NOT NULL DEFAULT 0,id_m numeric(10,0) NOT NULL DEFAULT 0,id_v numeric(10,0) NOT NULL DEFAULT 0,id_d numeric(10,0) NOT NULL DEFAULT 0,id_xn numeric(10,0) NOT NULL DEFAULT 0,id_cdha numeric(10,0) NOT NULL DEFAULT 0,id_ns numeric(10,0) NOT NULL DEFAULT 0,id_rp numeric(10,0) NOT NULL DEFAULT 0,id_ct numeric(10,0) NOT NULL DEFAULT 0,CONSTRAINT pk_mdlogin PRIMARY KEY (id) USING INDEX TABLESPACE medi_index);");
                v.execute_data("ALTER TABLE medibv.mdlogin OWNER TO medisoft;");

                v.execute_data("CREATE TABLE medibv.mdlogin(id numeric(10,0) NOT NULL DEFAULT 0,userid character varying(20),password_ character varying(10),hoten text,ngaysinh character varying(10),gioitinh numeric(1,0) NOT NULL DEFAULT 0,diachi text,dtnha text,dtcoquan text,dtdidong text,email text,admin_ numeric(1,0) NOT NULL DEFAULT 0,id_m numeric(10,0) NOT NULL DEFAULT 0,id_v numeric(10,0) NOT NULL DEFAULT 0,id_d numeric(10,0) NOT NULL DEFAULT 0,id_xn numeric(10,0) NOT NULL DEFAULT 0,id_cdha numeric(10,0) NOT NULL DEFAULT 0,id_ns numeric(10,0) NOT NULL DEFAULT 0,id_rp numeric(10,0) NOT NULL DEFAULT 0,id_ct numeric(10,0) NOT NULL DEFAULT 0,CONSTRAINT pk_mdlogin PRIMARY KEY (id) USING INDEX TABLESPACE medi_index);");
                v.execute_data("ALTER TABLE medibv.mdlogin OWNER TO medisoft;");
            }
            f_SyncDB();
        }
        private void f_CreateDBMenu(string v_prefix_delimiter)
        {
            foreach (string aprefix in v_prefix_delimiter.Split('~'))
            {
                if (aprefix != "")
                {
                    try
                    {
                        if (v.get_data("select * from medibv." + aprefix + "_menuitem where 1=0").Tables[0].Rows.Count > 0)
                        {
                            string aok = "";
                        }
                    }
                    catch
                    {
                        v.execute_data("CREATE TABLE medibv." + aprefix + "_menuitem(id character varying(5) NOT NULL,id_goc character varying(5),stt numeric(5,0) DEFAULT 0,id_menu character varying(5),ten text,CONSTRAINT pk_" + aprefix + "_menuitem PRIMARY KEY (id));");
                        v.execute_data("ALTER TABLE medibv." + aprefix + "_menuitem OWNER TO medisoft;");

                        v.execute_data("CREATE TABLE medibv." + aprefix + "_menuitems(id numeric(5,0) NOT NULL,stt numeric(5,0),ten text,loai numeric(3,0) DEFAULT 0,tenloai text,CONSTRAINT pk_" + aprefix + "_menuitems PRIMARY KEY (id) USING INDEX TABLESPACE medi_index);");
                        v.execute_data("ALTER TABLE medibv." + aprefix + "_menuitems OWNER TO medisoft;");

                        v.execute_data("CREATE TABLE medibv." + aprefix + "_menuitem(id character varying(5) NOT NULL,id_goc character varying(5),stt numeric(5,0) DEFAULT 0,id_menu character varying(5),ten text,CONSTRAINT pk_" + aprefix + "_menuitem PRIMARY KEY (id));");
                        v.execute_data("ALTER TABLE medibv." + aprefix + "_menuitem OWNER TO medisoft;");

                        v.execute_data("CREATE TABLE medibv." + aprefix + "_menuitems(id numeric(5,0) NOT NULL,stt numeric(5,0),ten text,loai numeric(3,0) DEFAULT 0,tenloai text,CONSTRAINT pk_" + aprefix + "_menuitems PRIMARY KEY (id) USING INDEX TABLESPACE medi_index);");
                        v.execute_data("ALTER TABLE medibv." + aprefix + "_menuitems OWNER TO medisoft;");
                    }
                }
            }
        }
        private string f_Max_ID()
        {
            string atmp = "";
            try
            {
                atmp = decimal.Parse(v.get_data("select max(id)+1 as id from medibv.mdlogin").Tables[0].Rows[0][0].ToString()).ToString();
            }
            catch
            {
                atmp = "1";
            }
            return atmp;
        }
        private void f_SyncDB()
        {
            try
            {
                string user_new = "";
                for (int i = 0; i < 1; i++)
                {
                    if (i == 0) user_new = "medibv";
                    if (i == 1) user_new = "medibv";
                    string atmp = "";
                    //dlogin
                    atmp = f_Max_ID();
                    v.execute_data("drop sequence temp_seq;");
                    v.execute_data("create temp sequence temp_seq start " + atmp + ";insert into " + user_new + ".mdlogin(id,userid,password_,hoten,ngaysinh,gioitinh,diachi,dtnha,dtcoquan,dtdidong,email,admin_,id_m,id_v,id_d,id_xn,id_cdha,id_ns,id_rp,id_ct) select nextval('temp_seq') as id,userid as userid,password_ as password_,hoten as hoten,'' as ngaysinh,0 as gioitinh,'' as diachi,'' as dtnha,'' as dtcoquan,'' as dtdidong,'' as email,0 as admin_,id as id_m,0 as id_v,0 as id_d,0 as id_xn,0 as id_cdha,0 as id_ns,0 as id_rp,0 as id_ct from " + user_new + ".dlogin where id not in (select id_m from " + user_new + ".mdlogin);");
                    //v_dlogin
                    atmp = f_Max_ID();
                    v.execute_data("drop sequence temp_seq;");
                    v.execute_data("create temp sequence temp_seq start " + atmp + ";insert into " + user_new + ".mdlogin(id,userid,password_,hoten,ngaysinh,gioitinh,diachi,dtnha,dtcoquan,dtdidong,email,admin_,id_m,id_v,id_d,id_xn,id_cdha,id_ns,id_rp,id_ct) select nextval('temp_seq') as id,userid as userid,password_ as password_,hoten as hoten,'' as ngaysinh,0 as gioitinh,'' as diachi,'' as dtnha,'' as dtcoquan,'' as dtdidong,'' as email,0 as admin_,0 as id_m,id as id_v,0 as id_d,0 as id_xn,0 as id_cdha,0 as id_ns,0 as id_rp,0 as id_ct from " + user_new + ".v_dlogin where id not in (select id_v from " + user_new + ".mdlogin);");
                    //d_dlogin
                    atmp = f_Max_ID();
                    v.execute_data("drop sequence temp_seq;");
                    v.execute_data("create temp sequence temp_seq start " + atmp + ";insert into " + user_new + ".mdlogin(id,userid,password_,hoten,ngaysinh,gioitinh,diachi,dtnha,dtcoquan,dtdidong,email,admin_,id_m,id_v,id_d,id_xn,id_cdha,id_ns,id_rp,id_ct) select nextval('temp_seq') as id,userid as userid,password_ as password_,hoten as hoten,'' as ngaysinh,0 as gioitinh,'' as diachi,'' as dtnha,'' as dtcoquan,'' as dtdidong,'' as email,admin as admin_,0 as id_m,0 as id_v,id as id_d,0 as id_xn,0 as id_cdha,0 as id_ns,0 as id_rp,0 as id_ct from " + user_new + ".d_dlogin where id not in (select id_d from " + user_new + ".mdlogin);");
                    //xn_dlogin
                    atmp = f_Max_ID();
                    v.execute_data("drop sequence temp_seq;");
                    v.execute_data("create temp sequence temp_seq start " + atmp + ";insert into " + user_new + ".mdlogin(id,userid,password_,hoten,ngaysinh,gioitinh,diachi,dtnha,dtcoquan,dtdidong,email,admin_,id_m,id_v,id_d,id_xn,id_cdha,id_ns,id_rp,id_ct) select nextval('temp_seq') as id,userid as userid,password_ as password_,hoten as hoten,'' as ngaysinh,0 as gioitinh,'' as diachi,'' as dtnha,'' as dtcoquan,'' as dtdidong,'' as email,0 as admin_,0 as id_m,0 as id_v,0 as id_d,id as id_xn,0 as id_cdha,0 as id_ns,0 as id_rp,0 as id_ct from " + user_new + ".xn_dlogin where id not in (select id_xn from " + user_new + ".mdlogin);");
                    //cdha_dlogin
                    atmp = f_Max_ID();
                    v.execute_data("drop sequence temp_seq;");
                    v.execute_data("create temp sequence temp_seq start " + atmp + ";insert into " + user_new + ".mdlogin(id,userid,password_,hoten,ngaysinh,gioitinh,diachi,dtnha,dtcoquan,dtdidong,email,admin_,id_m,id_v,id_d,id_xn,id_cdha,id_ns,id_rp,id_ct) select nextval('temp_seq') as id,userid as userid,password_ as password_,hoten as hoten,'' as ngaysinh,0 as gioitinh,'' as diachi,'' as dtnha,'' as dtcoquan,'' as dtdidong,'' as email,0 as admin_,0 as id_m,0 as id_v,0 as id_d,0 as id_xn,id as id_cdha,0 as id_ns,0 as id_rp,0 as id_ct from " + user_new + ".cdha_dlogin where id not in (select id_cdha from " + user_new + ".mdlogin);");
                    //nhansu.pwhuman
                    atmp = f_Max_ID();
                    v.execute_data("drop sequence temp_seq;");
                    v.execute_data("create temp sequence temp_seq start " + atmp + ";insert into " + user_new + ".mdlogin(id,userid,password_,hoten,ngaysinh,gioitinh,diachi,dtnha,dtcoquan,dtdidong,email,admin_,id_m,id_v,id_d,id_xn,id_cdha,id_ns,id_rp,id_ct) select nextval('temp_seq') as id,username as userid,pass as password_,ten as hoten,'' as ngaysinh,0 as gioitinh,'' as diachi,'' as dtnha,'' as dtcoquan,'' as dtdidong,'' as email,0 as admin_,0 as id_m,0 as id_v,0 as id_d,0 as id_xn,0 as id_cdha,id as id_ns,0 as id_rp,0 as id_ct from nhansu.pwhuman where id not in (select id_ns from " + user_new + ".mdlogin);");
                    //bc_dlogin
                    atmp = f_Max_ID();
                    v.execute_data("drop sequence temp_seq;");
                    v.execute_data("create temp sequence temp_seq start " + atmp + ";insert into " + user_new + ".mdlogin(id,userid,password_,hoten,ngaysinh,gioitinh,diachi,dtnha,dtcoquan,dtdidong,email,admin_,id_m,id_v,id_d,id_xn,id_cdha,id_ns,id_rp,id_ct) select nextval('temp_seq') as id,userid as userid,password_ as password_,hoten as hoten,'' as ngaysinh,0 as gioitinh,'' as diachi,'' as dtnha,'' as dtcoquan,'' as dtdidong,'' as email,0 as admin_,0 as id_m,0 as id_v,0 as id_d,0 as id_xn,0 as id_cdha,0 as id_ns,id as id_rp,0 as id_ct from " + user_new + ".bc_dlogin where id not in (select id_rp from " + user_new + ".mdlogin);");
                    //ct_dlogin
                    atmp = f_Max_ID();
                    v.execute_data("drop sequence temp_seq;");
                    v.execute_data("create temp sequence temp_seq start " + atmp + ";insert into " + user_new + ".mdlogin(id,userid,password_,hoten,ngaysinh,gioitinh,diachi,dtnha,dtcoquan,dtdidong,email,admin_,id_m,id_v,id_d,id_xn,id_cdha,id_ns,id_rp,id_ct) select nextval('temp_seq') as id,userid as userid,password_ as password_,hoten as hoten,'' as ngaysinh,0 as gioitinh,'' as diachi,'' as dtnha,'' as dtcoquan,'' as dtdidong,'' as email,0 as admin_,0 as id_m,0 as id_v,0 as id_d,0 as id_xn,0 as id_cdha,0 as id_ns,0 as id_rp,id as id_ct from " + user_new + ".ct_dlogin where id not in (select id_ct from " + user_new + ".mdlogin);");
                }
                //---------------------------------------
                //string user_new = "";
                for (int i = 0; i < 1; i++)
                {
                    if (i == 0) user_new = "medibv";
                    if (i == 1) user_new = "medibv";
                    string atmp = "";
                    //dlogin
                    v.execute_data("insert into " + user_new + ".mdlogin(id,userid,password_,hoten,ngaysinh,gioitinh,diachi,dtnha,dtcoquan,dtdidong,email,admin_,id_m,id_v,id_d,id_xn,id_cdha,id_ns,id_rp,id_ct) select id,userid as userid,password_ as password_,hoten as hoten,'' as ngaysinh,0 as gioitinh,'' as diachi,'' as dtnha,'' as dtcoquan,'' as dtdidong,'' as email,0 as admin_,id as id_m,0 as id_v,0 as id_d,0 as id_xn,0 as id_cdha,0 as id_ns,0 as id_rp,0 as id_ct from " + user_new + ".dlogin where id not in (select id_m from " + user_new + ".mdlogin);");
                    //v_dlogin
                    v.execute_data("insert into " + user_new + ".mdlogin(id,userid,password_,hoten,ngaysinh,gioitinh,diachi,dtnha,dtcoquan,dtdidong,email,admin_,id_m,id_v,id_d,id_xn,id_cdha,id_ns,id_rp,id_ct) select id,userid as userid,password_ as password_,hoten as hoten,'' as ngaysinh,0 as gioitinh,'' as diachi,'' as dtnha,'' as dtcoquan,'' as dtdidong,'' as email,0 as admin_,0 as id_m,id as id_v,0 as id_d,0 as id_xn,0 as id_cdha,0 as id_ns,0 as id_rp,0 as id_ct from " + user_new + ".v_dlogin where id not in (select id_v from " + user_new + ".mdlogin);");
                    //d_dlogin
                    v.execute_data("insert into " + user_new + ".mdlogin(id,userid,password_,hoten,ngaysinh,gioitinh,diachi,dtnha,dtcoquan,dtdidong,email,admin_,id_m,id_v,id_d,id_xn,id_cdha,id_ns,id_rp,id_ct) select id,userid as userid,password_ as password_,hoten as hoten,'' as ngaysinh,0 as gioitinh,'' as diachi,'' as dtnha,'' as dtcoquan,'' as dtdidong,'' as email,admin as admin_,0 as id_m,0 as id_v,id as id_d,0 as id_xn,0 as id_cdha,0 as id_ns,0 as id_rp,0 as id_ct from " + user_new + ".d_dlogin where id not in (select id_d from " + user_new + ".mdlogin);");
                    //xn_dlogin
                    v.execute_data("insert into " + user_new + ".mdlogin(id,userid,password_,hoten,ngaysinh,gioitinh,diachi,dtnha,dtcoquan,dtdidong,email,admin_,id_m,id_v,id_d,id_xn,id_cdha,id_ns,id_rp,id_ct) select id,userid as userid,password_ as password_,hoten as hoten,'' as ngaysinh,0 as gioitinh,'' as diachi,'' as dtnha,'' as dtcoquan,'' as dtdidong,'' as email,0 as admin_,0 as id_m,0 as id_v,0 as id_d,id as id_xn,0 as id_cdha,0 as id_ns,0 as id_rp,0 as id_ct from " + user_new + ".xn_dlogin where id not in (select id_xn from " + user_new + ".mdlogin);");
                    //cdha_dlogin
                    v.execute_data("insert into " + user_new + ".mdlogin(id,userid,password_,hoten,ngaysinh,gioitinh,diachi,dtnha,dtcoquan,dtdidong,email,admin_,id_m,id_v,id_d,id_xn,id_cdha,id_ns,id_rp,id_ct) select id,userid as userid,password_ as password_,hoten as hoten,'' as ngaysinh,0 as gioitinh,'' as diachi,'' as dtnha,'' as dtcoquan,'' as dtdidong,'' as email,0 as admin_,0 as id_m,0 as id_v,0 as id_d,0 as id_xn,id as id_cdha,0 as id_ns,0 as id_rp,0 as id_ct from " + user_new + ".cdha_dlogin where id not in (select id_cdha from " + user_new + ".mdlogin);");
                    //nhansu.pwhuman
                    v.execute_data("insert into " + user_new + ".mdlogin(id,userid,password_,hoten,ngaysinh,gioitinh,diachi,dtnha,dtcoquan,dtdidong,email,admin_,id_m,id_v,id_d,id_xn,id_cdha,id_ns,id_rp,id_ct) select id,username as userid,pass as password_,ten as hoten,'' as ngaysinh,0 as gioitinh,'' as diachi,'' as dtnha,'' as dtcoquan,'' as dtdidong,'' as email,0 as admin_,0 as id_m,0 as id_v,0 as id_d,0 as id_xn,0 as id_cdha,id as id_ns,0 as id_rp,0 as id_ct from nhansu.pwhuman where id not in (select id_ns from " + user_new + ".mdlogin);");
                    //bc_dlogin
                    v.execute_data("insert into " + user_new + ".mdlogin(id,userid,password_,hoten,ngaysinh,gioitinh,diachi,dtnha,dtcoquan,dtdidong,email,admin_,id_m,id_v,id_d,id_xn,id_cdha,id_ns,id_rp,id_ct) select id,userid as userid,password_ as password_,hoten as hoten,'' as ngaysinh,0 as gioitinh,'' as diachi,'' as dtnha,'' as dtcoquan,'' as dtdidong,'' as email,0 as admin_,0 as id_m,0 as id_v,0 as id_d,0 as id_xn,0 as id_cdha,0 as id_ns,id as id_rp,0 as id_ct from " + user_new + ".bc_dlogin where id not in (select id_rp from " + user_new + ".mdlogin);");
                    //ct_dlogin
                    v.execute_data("insert into " + user_new + ".mdlogin(id,userid,password_,hoten,ngaysinh,gioitinh,diachi,dtnha,dtcoquan,dtdidong,email,admin_,id_m,id_v,id_d,id_xn,id_cdha,id_ns,id_rp,id_ct) select id,userid as userid,password_ as password_,hoten as hoten,'' as ngaysinh,0 as gioitinh,'' as diachi,'' as dtnha,'' as dtcoquan,'' as dtdidong,'' as email,0 as admin_,0 as id_m,0 as id_v,0 as id_d,0 as id_xn,0 as id_cdha,0 as id_ns,0 as id_rp,id as id_ct from " + user_new + ".ct_dlogin where id not in (select id_ct from " + user_new + ".mdlogin);");
                }


            }
            catch
            {
            }
        }
        private void f_JoinUser()
        {
            try
            {
                if (dgDSNhanvien.SelectedRows.Count > 1)
                {
                    string aid = "0";
                    string aid_m = "0";
                    string aid_v = "0";
                    string aid_d = "0";
                    string aid_xn = "0";
                    string aid_cdha = "0";
                    string aid_ns = "0";
                    string aid_rp = "0";
                    string aid_ct = "0";

                    for (int i = 0; i < dgDSNhanvien.SelectedRows.Count; i++)
                    {
                        if (aid == "0")
                        {
                            aid = dgDSNhanvien.SelectedRows[i].Cells["Column_id"].Value.ToString();
                        }
                        if (aid_m == "0")
                        {
                            aid_m = dgDSNhanvien.SelectedRows[i].Cells["Column_id_m"].Value.ToString();
                        }
                        if (aid_v == "0")
                        {
                            aid_v = dgDSNhanvien.SelectedRows[i].Cells["Column_id_v"].Value.ToString();
                        }
                        if (aid_d == "0")
                        {
                            aid_d = dgDSNhanvien.SelectedRows[i].Cells["Column_id_d"].Value.ToString();
                        }
                        if (aid_xn == "0")
                        {
                            aid_xn = dgDSNhanvien.SelectedRows[i].Cells["Column_id_xn"].Value.ToString();
                        }
                        if (aid_cdha == "0")
                        {
                            aid_cdha = dgDSNhanvien.SelectedRows[i].Cells["Column_id_cdha"].Value.ToString();
                        }
                        if (aid_ns == "0")
                        {
                            aid_ns = dgDSNhanvien.SelectedRows[i].Cells["Column_id_ns"].Value.ToString();
                        }
                        if (aid_rp == "0")
                        {
                            aid_rp = dgDSNhanvien.SelectedRows[i].Cells["Column_id_rp"].Value.ToString();
                        }
                        if (aid_ct == "0")
                        {
                            aid_ct = dgDSNhanvien.SelectedRows[i].Cells["Column_id_ct"].Value.ToString();
                        }
                    }
                    v.execute_data("update medibv.mdlogin set id_m=" + aid_m + ",id_v=" + aid_v + ",id_d=" + aid_d + ",id_xn=" + aid_xn + ",id_cdha=" + aid_cdha + ",id_ns=" + aid_ns + ",id_rp=" + aid_rp + ",id_ct=" + aid_ct + " where id=" + aid);
                    v.execute_data("update medibv.mdlogin set id_m=" + aid_m + ",id_v=" + aid_v + ",id_d=" + aid_d + ",id_xn=" + aid_xn + ",id_cdha=" + aid_cdha + ",id_ns=" + aid_ns + ",id_rp=" + aid_rp + ",id_ct=" + aid_ct + " where id=" + aid);
                    //for (int i = 1; i < dgDSNhanvien.SelectedRows.Count; i++)
                    //{
                    //    aid = dgDSNhanvien.SelectedRows[i].Cells["Column_id"].Value.ToString();
                    //    v.execute_data("delete from medibv.mdlogin where id="+aid);
                    //    v.execute_data("delete from medibv.mdlogin where id=" + aid);
                    //}
                }
            }
            catch
            {
            }
            f_Load_DG();
        }

        private void f_Load_DG()
        {
            try
            {
                DataSet ads = v.get_data("select a.id,a.userid,a.hoten,a.ngaysinh,b.ten as gioitinh,a.diachi,a.dtnha,a.dtcoquan,"+
                " a.dtdidong,a.email,a.admin_,a.id_m,a.id_v,a.id_d,a.id_xn,a.id_cdha,a.id_ns,a.id_rp,a.id_ct from medibv.mdlogin a "+
                " left join medibv.dmphai b on a.gioitinh=b.ma where a.id>= 1 order by a.hoten asc");
                dgDSNhanvien.AutoGenerateColumns = false;
                dgDSNhanvien.DataMember = ads.Tables[0].TableName;
                dgDSNhanvien.DataSource = ads.Tables[0];
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage3);
                tabControl1.TabPages.Remove(tabPage4);
                tabControl1.TabPages.Remove(tabPage5);
                tabControl1.TabPages.Remove(tabPage6);
                tabControl1.TabPages.Remove(tabPage7);
                tabControl1.TabPages.Remove(tabPage8);
                tabControl1.TabPages.Remove(tabPage9);
            }
            catch
            {
            }
        }
        private void f_Load_TreeMenu(TreeView v_tree, DataSet v_ds)
        {
            v_tree.Nodes.Clear();
            try
            {
                TreeNode anode, anode1;
                anode1 = new TreeNode("Chức năng");
                anode1.Tag = "menuChucnang";
                anode1.Name = "menuChucnang";
                v_tree.Nodes.Add(anode1);
                foreach (DataRow r in v_ds.Tables[0].Select("id_goc='-1'", "id"))
                {
                    anode = new TreeNode(r["ten"].ToString());
                    anode.Tag = r["id_menu"].ToString();
                    anode.ForeColor = Color.Black;
                    if (v_ds.Tables[0].Select("id_goc='" + anode.Tag.ToString()+"'", "stt").Length > 0)
                    {
                        f_Add_Node(anode, v_ds);
                    }
                    anode1.Nodes.Add(anode);
                }
                v_tree.ExpandAll();
                v_tree.SelectedNode = anode1;
            }
            catch
            {
            }
        }
        private void f_Add_Node(TreeNode v_node, DataSet v_ds)
        {
            try
            {
                TreeNode anode;
                foreach (DataRow r in v_ds.Tables[0].Select("id_goc='" + v_node.Tag.ToString()+"'", "stt"))
                {
                    anode = new TreeNode(r["ten"].ToString());
                    anode.Tag = r["id_menu"].ToString();
                    anode.ForeColor = Color.Black;
                    if (v_ds.Tables[0].Select("id_goc='" + anode.Tag.ToString()+"'", "stt").Length > 0)
                    {
                        f_Add_Node(anode,v_ds);
                    }
                    v_node.Nodes.Add(anode);
                }
            }
            catch
            {
            }
        }

        private void f_FindTree(TreeView v_tree, string v_text)
        {
            v_text = v_text.ToLower();
            try
            {
                foreach (TreeNode anode in v_tree.Nodes)
                {
                     f_FindTreeNode(anode, v_text);
                }
            }
            catch
            {
            }
        }
        private void f_FindTreeNode(TreeNode v_node, string v_text)
        {
            try
            {
                v_node.BackColor = (v_node.Text.ToLower().IndexOf(v_text) >= 0 && v_text!="" ? Color.Yellow : Color.Transparent);
                foreach (TreeNode anode in v_node.Nodes)
                {
                    f_FindTreeNode(anode, v_text);
                }
            }
            catch
            {
            }
        }

        private void f_FindDG(string v_filter)
        {
            try
            {
                string afilter = "";
                if (v_filter != "")
                {
                    afilter = "hoten like '%" + v_filter + "%' or userid like '%" + v_filter + "%' or gioitinh like '%" + v_filter + "%' or ngaysinh like '%" + v_filter + "%' or diachi like '%" + v_filter + "%'";
                }
                CurrencyManager cm = (CurrencyManager)(BindingContext[dgDSNhanvien.DataSource, dgDSNhanvien.DataMember]);
                DataView dv = (DataView)(cm.List);
                dv.RowFilter = afilter;
            }
            catch(Exception ex)
            {

            }
        }
        private void f_Filter()
        {
            try
            {
                string afilter = "";
                if (txtFilter.Text != "Tìm kiếm")
                {
                    afilter = txtFilter.Text;
                }
                switch (tabControl1.SelectedTab.Name)
                {
                    case "tabPage1":
                        f_FindDG(afilter);
                        break;
                    case "tabPage2":
                        f_FindTree(treeBenhnhan, afilter);
                        break;
                    case "tabPage3":
                        f_FindTree(treeVienphi, afilter);
                        break;
                    case "tabPage4":
                        f_FindTree(treeDuoc, afilter);
                        break;
                    case "tabPage5":
                        f_FindTree(treeXetnghiem, afilter);
                        break;
                    case "tabPage6":
                        f_FindTree(treeCDHA, afilter);
                        break;
                    case "tabPage7":
                        f_FindTree(treeNhansu, afilter);
                        break;
                    case "tabPage8":
                        f_FindTree(treeBaocao, afilter);
                        break;
                }
            }
            catch
            {
            }
        }

        private string f_Get_Right(TreeView v_tree)
        {
            string art = "";
            try
            {
                foreach (TreeNode anode in v_tree.Nodes)
                {
                    art = art.Trim('+');
                    if (art != "")
                    {
                        art += "+";
                    }
                    art += f_Get_Right_Node(anode);
                }
            }
            catch
            {
            }
            art = art.Trim('+');
            art += "+";
            return art;
        }
        private string f_Get_Right_Node(TreeNode v_node)
        {
            string art = "";
            try
            {
                if (v_node.Tag.ToString() != "" && v_node.Nodes.Count == 0 && v_node.Checked==true)
                {
                    if (art != "")
                    {
                        art += "+";
                    }
                    art += v_node.Tag.ToString();
                }
                foreach (TreeNode anode in v_node.Nodes)
                {
                    art = art.Trim('+');
                    if (art != "")
                    {
                        art += "+";
                    }
                    art += f_Get_Right_Node(anode);
                }
            }
            catch
            {
            }
            return art;
        }

        private string f_Get_Right_NS(TreeView v_tree)
        {
            string art = "";
            try
            {
                foreach (TreeNode anode in v_tree.Nodes)
                {
                    art = art.Trim('+');
                    if (art != "")
                    {
                        art += "+";
                    }
                    art += f_Get_Right_Node_NS(anode);
                }
            }
            catch
            {
            }
            art = art.Trim('+');
            art += "+";
            return art;
        }
        private string f_Get_Right_Node_NS(TreeNode v_node)
        {
            string art = "";
            try
            {
                if (v_node.Tag.ToString() != "" && v_node.Checked == true)
                {
                    if (art != "")
                    {
                        art += "+";
                    }
                    art += v_node.Tag.ToString();
                }
                foreach (TreeNode anode in v_node.Nodes)
                {
                    art = art.Trim('+');
                    if (art != "")
                    {
                        art += "+";
                    }
                    art += f_Get_Right_Node_NS(anode);
                }
            }
            catch
            {
            }
            return art;
        }

        private string f_Get_ID()
        {
            string art = "";
            try
            {
                art = dgDSNhanvien["Column_id", dgDSNhanvien.CurrentCell.RowIndex].Value.ToString();
            }
            catch
            {
                art = "0";
            }
            return art;
        }

        private void f_Set_Right(TreeView v_tree, string v_right)
        {
            try
            {
                foreach (TreeNode anode in v_tree.Nodes)
                {
                    f_Set_Right_Node(anode, v_right);
                }
            }
            catch
            {
            }
        }
        private string f_Set_Right_Node(TreeNode v_node, string v_right)
        {
            string art = "";
            try
            {
                v_node.Checked = (v_right.IndexOf("+" + v_node.Tag.ToString() + "+") >= 0);
                foreach (TreeNode anode in v_node.Nodes)
                {
                    f_Set_Right_Node(anode, v_right);
                }
            }
            catch
            {
            }
            return art;
        }
        private void f_Load_Right()
        {
            string aid = f_Get_ID();
            try
            {
                foreach (DataRow r in v.get_data("select right_ from medibv.dlogin where id in (select id_m from medibv.mdlogin where id=" + aid + ")").Tables[0].Rows)
                {
                    f_Set_Right(treeBenhnhan, "+" + r["right_"].ToString() + "+");
                }
            }
            catch
            {
            }

            try
            {
                foreach (DataRow r in v.get_data("select right_ from medibv.v_dlogin where id in (select id_v from medibv.mdlogin where id=" + aid + ")").Tables[0].Rows)
                {
                    f_Set_Right(treeVienphi, "+" + r["right_"].ToString() + "+");
                }
            }
            catch
            {
            }

            try
            {
                foreach (DataRow r in v.get_data("select right_ from medibv.d_dlogin where id in (select id_d from medibv.mdlogin where id=" + aid + ")").Tables[0].Rows)
                {
                    f_Set_Right(treeDuoc, "+" + r["right_"].ToString() + "+");
                }
            }
            catch
            {
            }

            try
            {
                foreach (DataRow r in v.get_data("select right_ from medibv.xn_dlogin where id in (select id_xn from medibv.mdlogin where id=" + aid + ")").Tables[0].Rows)
                {
                    f_Set_Right(treeXetnghiem, "+" + r["right_"].ToString() + "+");
                }
            }
            catch
            {
            }
            try
            {
                foreach (DataRow r in v.get_data("select right_ from medibv.cdha_dlogin where id in (select id_cdha from medibv.mdlogin where id=" + aid + ")").Tables[0].Rows)
                {
                    f_Set_Right(treeCDHA, "+" + r["right_"].ToString() + "+");
                }
            }
            catch
            {
            }
            try
            {
                foreach (DataRow r in v.get_data("select right_ from medibv.bc_dlogin where id in (select id_rp from medibv.mdlogin where id=" + aid + ")").Tables[0].Rows)
                {
                    f_Set_Right(treeBaocao, "+" + r["right_"].ToString() + "+");
                }
            }
            catch
            {
            }

            try
            {
                foreach (DataRow r in v.get_data("select _right as right_ from nhansu.pwhuman where id in (select id_ns from medibv.mdlogin where id=" + aid + ")").Tables[0].Rows)
                {
                    f_Set_Right(treeNhansu, "+" + r["right_"].ToString() + "+");
                }
            }
            catch
            {
            }

            try
            {
                foreach (DataRow r in v.get_data("select right_ from medibv.ct_dlogin where id in (select id_ct from medibv.mdlogin where id=" + aid + ")").Tables[0].Rows)
                {
                    f_Set_Right(treeCT, "+" + r["right_"].ToString() + "+");
                }
            }
            catch
            {
            }

        }

        private void f_Save()
        {
            try
            {
                string aright = "";
                string aid = f_Get_ID();
                if (aid == "")
                {
                    MessageBox.Show(this, "Chọn nhân viên từ danh sách trước", this.Name);
                    tabControl1.SelectedTab = tabPage1;
                    return;
                }
                switch (tabControl1.SelectedTab.Name)
                {
                    case "tabPage1":
                        break;
                    case "tabPage2":
                        aright = f_Get_Right(treeBenhnhan);
                        //MessageBox.Show(aright);
                        v.execute_data("update medibv.dlogin set right_='" + aright + "' where id in (select id_m from medibv.mdlogin where id=" + aid + ")");
                        v.execute_data("update medibv.dlogin set right_='" + aright + "' where id in (select id_m from medibv.mdlogin where id=" + aid + ")");
                        break;
                    case "tabPage3":
                        aright = f_Get_Right(treeVienphi);
                        v.execute_data("update medibv.v_dlogin set right_='" + aright + "' where id in (select id_v from medibv.mdlogin where id=" + aid + ")");
                        v.execute_data("update medibv.v_dlogin set right_='" + aright + "' where id in (select id_v from medibv.mdlogin where id=" + aid + ")");
                        break;
                    case "tabPage4":
                        aright = f_Get_Right(treeDuoc);
                        v.execute_data("update medibv.d_dlogin set right_='" + aright + "' where id in (select id_d from medibv.mdlogin where id=" + aid + ")");
                        v.execute_data("update medibv.d_dlogin set right_='" + aright + "' where id in (select id_d from medibv.mdlogin where id=" + aid + ")");
                        break;
                    case "tabPage5":
                        aright = f_Get_Right(treeXetnghiem);
                        v.execute_data("update medibv.xn_dlogin set right_='" + aright + "' where id in (select id_xn from medibv.mdlogin where id=" + aid + ")");
                        v.execute_data("update medibv.xn_dlogin set right_='" + aright + "' where id in (select id_xn from medibv.mdlogin where id=" + aid + ")");
                        break;
                    case "tabPage6":
                        aright = f_Get_Right(treeCDHA);
                        v.execute_data("update medibv.cdha_dlogin set right_='" + aright + "' where id in (select id_cdha from medibv.mdlogin where id=" + aid + ")");
                        v.execute_data("update medibv.cdha_dlogin set right_='" + aright + "' where id in (select id_cdha from medibv.mdlogin where id=" + aid + ")");
                        break;
                    case "tabPage7":
                        aright = f_Get_Right_NS(treeNhansu);
                        v.execute_data("update nhansu.pwhuman set _right='" + aright + "' where id in (select id_ns from medibv.mdlogin where id=" + aid + ")");
                        v.execute_data("update nhansu.pwhuman set _right='" + aright + "' where id in (select id_ns from medibv.mdlogin where id=" + aid + ")");
                        break;
                    case "tabPage8":
                        aright = f_Get_Right(treeBaocao);
                        v.execute_data("update medibv.bc_dlogin set right_='" + aright + "' where id in (select id_rp from medibv.mdlogin where id=" + aid + ")");
                        v.execute_data("update medibv.bc_dlogin set right_='" + aright + "' where id in (select id_rp from medibv.mdlogin where id=" + aid + ")");
                        break;
                    case "tabPage9":
                        aright = f_Get_Right(treeCT);
                        v.execute_data("update medibv.ct_dlogin set right_='" + aright + "' where id in (select id_ct from medibv.mdlogin where id=" + aid + ")");
                        v.execute_data("update medibv.ct_dlogin set right_='" + aright + "' where id in (select id_ct from medibv.mdlogin where id=" + aid + ")");
                        break;
                }
            }
            catch
            {
            }
        }

        private void f_AutoSaveCheck(CheckBox v_check)
        {
            try
            {
                chkBNSave.Checked = v_check.Checked;
                chkVPSave.Checked = v_check.Checked;
                chkDSave.Checked = v_check.Checked;
                chkXNSave.Checked = v_check.Checked;
                chkCDHASave.Checked = v_check.Checked;
                chkNSSave.Checked = v_check.Checked;
                chkBCSave.Checked = v_check.Checked;
                chkCTSave.Checked = v_check.Checked;
            }
            catch
            {
            }
        }

        private void butDSThem_Click(object sender, EventArgs e)
        {
            frmMThongtinnguoidung af = new frmMThongtinnguoidung(true,"");
            af.ShowDialog();
        }

        private void butDSSua_Click(object sender, EventArgs e)
        {
            frmMThongtinnguoidung af = new frmMThongtinnguoidung(false,f_Get_ID());
            af.ShowDialog();
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeBenhnhan_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                e.Node.ForeColor = e.Node.Checked ? Color.Blue : Color.Black;
                foreach (TreeNode anode in e.Node.Nodes)
                {
                    anode.Checked = e.Node.Checked;
                    anode.ForeColor = anode.Checked ? Color.Blue : Color.Black;
                }
                if (e.Action.ToString() != "Unknown")
                {
                    if (chkBNSave.Checked)
                    {
                        f_Save();
                    }
                }
            }
            catch
            {
            }
        }

        private void txtFilter_Enter(object sender, EventArgs e)
        {
            if (txtFilter.Text == "Tìm kiếm")
            {
                txtFilter.Text = "";
            }
            f_Filter();
        }

        private void txtFilter_Leave(object sender, EventArgs e)
        {
            if (txtFilter.Text == "")
            {
                txtFilter.Text = "Tìm kiếm";
            }
            f_Filter();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            f_Filter();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_Filter();
        }

        private void butBNSave_Click(object sender, EventArgs e)
        {
            f_Save();
        }

        private void chkBNSave_CheckedChanged(object sender, EventArgs e)
        {
            f_AutoSaveCheck((CheckBox)(sender));
        }

        private void butDSJoin_Click(object sender, EventArgs e)
        {
            f_JoinUser();
            f_Load_DG();
        }

        private void dgDSNhanvien_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                string art = "";
                int ai=dgDSNhanvien.CurrentCell.RowIndex;
                //art += "Họ và tên:";
                art += dgDSNhanvien["Column_hoten", ai].Value.ToString();
                art += " (";
                art += dgDSNhanvien["Column_userid", ai].Value.ToString();
                art += ")";
                lbHead.Text = art;
                f_Load_Right();
            }
            catch
            {
                //lbHead.Text = ex.ToString();
            }
        }

        private void dgDSNhanvien_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                butDSJoin.Enabled = dgDSNhanvien.SelectedRows.Count > 1;
            }
            catch
            {
                butDSJoin.Enabled = false;
            }
        }

        private void butDSRefresh_Click(object sender, EventArgs e)
        {
            f_Load_DG();
        }
    }
}