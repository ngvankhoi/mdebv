using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibMedi;

namespace Medisoft
{
    public partial class frmTaouser : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private AccessData m;
        private CreateTableMMYY CrTa;
        private AlterTableMMYY AlTa;
        private int i_userid;
        bool b_taomoi = false;
        public frmTaouser(AccessData acc,int userid)
        {
            InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; i_userid = userid;
        }

        private void mm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void frmTaouser_Load(object sender, EventArgs e)
        {
            yyyy.Maximum = DateTime.Now.Year + 1;
            yyyy.Minimum = 2000;// DateTime.Now.Year - 1;
            tu.Value = DateTime.Now.Month;
            den.Value = tu.Value;
            yyyy.Value = DateTime.Now.Year; 
            den.Enabled = !b_taomoi;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            m.close();this.Close();
        }
        //Thuy
        private void butOk_Click(object sender, EventArgs e)
        {
            FormAsynTask frm = new FormAsynTask();
            frm.ProcessName = "Tạo cấu trúc dữ liệu tháng mới";
            frm.DoWork += new FormAsynTask.DoWorkProcess(frm_DoWork);
            frm.DoWorkCompleted += new FormAsynTask.WorkerComplete(frm_DoWorkCompleted);
            butOk.Enabled = false;
            butCancel.Enabled = false;
            Cursor = Cursors.WaitCursor;
            frm.btn_cancel.Enabled = false;
            frm.Owner = this;
            frm.Show();
            DoWorkParam agr = new DoWorkParam();
            agr.m = m;
            agr.tu = tu.Value;
            agr.den = den.Value;
            agr.user_id = i_userid;
            frm.StartProcess(agr);
        }
        class DoWorkParam
        {
            public AccessData m ;
            public decimal tu, den;
            public int user_id;
        }
       
        class DoWorkCompleteParam
        {
            public int errocode = 0;// 0:success 1: error
            public string ErrMes = "Success";
           // public AccessData m;
            //public decimal tu, den;
        }
        void frm_DoWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            butOk.Enabled = true;
            butCancel.Enabled = true;
            Cursor = Cursors.Default;
            DoWorkCompleteParam rs = (DoWorkCompleteParam)e.Result;
            ((Form)sender).Close();
            if (rs.errocode == 0)
            {
                //if (s != "") MessageBox.Show(lan.Change_language_MessageText("Những tháng sau chưa tạo số liệu :")+"\n" + s,LibMedi.AccessData.Msg);
                MessageBox.Show(lan.Change_language_MessageText("Xong !"), LibMedi.AccessData.Msg);
            }
            else
            {
                MessageBox.Show(rs.ErrMes, LibMedi.AccessData.Msg);
            }
            
        }

        void frm_DoWork(BackgroundWorker sender, DoWorkEventArgs e)
        {
            DoWorkParam arg = (DoWorkParam)e.Argument;
            DoWorkCompleteParam result = new DoWorkCompleteParam();
            e.Result = result;
            string mmyy = "";//, s = "", sql = "";
            string s_user = arg.m.user, xxx = "";
            #region old
            //if (i_userid == 0)
            //{
            //    CreateTable ct = new CreateTable();
            //    try
            //    {
            //        ct.Create_table();
            //        MessageBox.Show(lan.Change_language_MessageText("Create table ok!"), LibMedi.AccessData.Msg);
            //    }
            //    catch { }
            //    try
            //    {
            //        ct.Create_table_mmyy(tu.Value.ToString().PadLeft(2, '0') + yyyy.Value.ToString().Substring(2));
            //        MessageBox.Show(lan.Change_language_MessageText("Create table mmyy ok!"), LibMedi.AccessData.Msg);
            //    }
            //    catch { }
            //}
            //m.Tao_Table(tu.Value.ToString().PadLeft(2, '0') + yyyy.Value.ToString().Substring(2));//linh 09072012
            //m.Tao_Partition();
            //if (b_taomoi)
            //{
            //    m.tao_schema(tu.Value.ToString().PadLeft(2, '0') + yyyy.Value.ToString().Substring(2), i_userid);
            //}
            //else
            //{
            //    for (int i = Convert.ToInt16(tu.Value); i <= Convert.ToInt16(den.Value); i++)
            //    {
            //        mmyy = i.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
            //        m.Tao_Partition(mmyy);
            //        if (m.bMmyy(mmyy))
            //        {
            //            //m.f_tangid_medibv_mmyy(mmyy);
            //            //linh 31052012
            //            //if(txtfile.Visible==false)
            //            m.f_capnhat_db_danhmuc("medisoft.exe");
            //            m.modify_schema(mmyy, i_userid);
            //            //else
            //            //  7  m.modify_schema(mmyy, i_userid,txtfile.Text);
            //            //
            //            xxx = s_user + mmyy;
            //            sql = "update " + xxx + ".d_xuatsdct set gia_bh=(select max(gia_bh) as gia_bh from " + s_user + ".d_dmbd  where " + xxx + ".d_xuatsdct.mabd=" + s_user + ".d_dmbd.id) where gia_bh=0 and mabd in(select id from " + s_user + ".d_dmbd and gia_bh>0) ";
            //            m.execute_data(sql);
            //            sql = "update " + xxx + ".d_thucxuat set gia_bh=(select max(gia_bh) as gia_bh from " + s_user + ".d_dmbd  where " + xxx + ".d_thucxuat.mabd=" + s_user + ".d_dmbd.id) where gia_bh=0 and mabd in(select id from " + s_user + ".d_dmbd and gia_bh>0) ";
            //            m.execute_data(sql);
            //            sql = "update " + xxx + ".d_tienthuoc set gia_bh=(select max(gia_bh) as gia_bh from " + s_user + ".d_dmbd  where " + xxx + ".d_tienthuoc.mabd=" + s_user + ".d_dmbd.id) where gia_bh=0 and mabd in(select id from " + s_user + ".d_dmbd and gia_bh>0) ";
            //            m.execute_data(sql);
            //            sql = "CREATE TABLE " + s_user + ".dmloaict";
            //            sql += "(";
            //            sql += "id numeric(3) NOT NULL,";
            //            sql += "stt numeric(3),";
            //            sql += "ten text,";
            //            sql += "userid numeric(5),";
            //            sql += "ngayud timestamp without time zone DEFAULT now(),";
            //            sql += "chuyendi text DEFAULT '000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000'::text,";
            //            sql += "CONSTRAINT pk_dmloaict PRIMARY KEY (id)";
            //            sql += ")";
            //            sql += "WITH (OIDS=TRUE);";
            //            sql += "ALTER TABLE " + s_user + ".dmloaict OWNER TO medisoft;\n";
            //            m.execute_data(sql);
            //            sql = "CREATE TABLE " + s_user + ".hachungtu";
            //            sql += "(";
            //            sql += "mabn character varying(10) NOT NULL,";
            //            sql += "mavaovien numeric(21) NOT NULL,";
            //            sql += "id_loaict numeric(3) NOT NULL,";
            //            sql += "duongdan text,";
            //            sql += "userid numeric(7),";
            //            sql += "ngayud timestamp without time zone DEFAULT now(),";
            //            sql += "chuyendi text DEFAULT '000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000'::text,";
            //            sql += "CONSTRAINT pk_hachungtu PRIMARY KEY (mabn, mavaovien, id_loaict),";
            //            sql += "CONSTRAINT fk_hachungtu_dmloaict FOREIGN KEY (id_loaict) ";
            //            sql += "REFERENCES " + s_user + ".dmloaict (id) MATCH SIMPLE ";
            //            sql += "ON UPDATE NO ACTION ON DELETE NO ACTION ";
            //            sql += ")";
            //            sql += "WITH (OIDS=TRUE);";
            //            sql += "ALTER TABLE " + s_user + ".hachungtu OWNER TO medisoft;\n";
            //            m.execute_data(sql);
            //            #region cao vu 13/03/2013
            //            m.execute("alter table " + xxx + ".tttiepdon add mabsgioithieu varchar2(4) default '0'");
            //            m.execute("alter table " + xxx + ".tttiepdon add manvsale varchar2(4) default '0'");
            //            m.execute("alter table " + xxx + ".tttiepdon add idvung numeric(3) default 0");

            //            m.execute("create table " + s_user + ".dmvungsale"
            //                        + "(id numeric(3) not null,"
            //                        + "ten varchar2(254),"
            //                        + "constraint pk_dmvungsale primary key(id));");
            //            m.execute("insert into " + s_user + ".dmvungsale(id,ten) values('0','KXD');");
            //            m.execute("alter table " + s_user + ".dmbschidinh drop column id;");
            //            m.execute("alter table " + s_user + ".dmbschidinh add column id  serial;");
            //            m.execute("alter table " + s_user + ".dmbschidinh add constraint pk_dmbschidinh primary key(id);");
            //            m.execute("alter table " + s_user + ".dmbschidinh add mabs varchar2(4);");
            //            m.execute("alter table " + s_user + ".dmbschidinh add mabv varchar2(10) default '0';");
            //            m.execute("insert into " + s_user + ".tenvien(mabv,tenbv) values('0','KXD');");
            //            m.execute("alter table " + s_user + ".dmbschidinh add constraint fk_dmbschidinh_tenvien foreign key(mabv)"
            //                       + " references " + s_user + ".tenvien(mabv);");
            //            m.execute("alter table " + s_user + ".dmbschidinh add manv varchar2(4) default '0';");
            //            m.execute("alter table " + s_user + ".dmbschidinh add constraint fk_dmbschidinh_dmbs foreign key(manv)"
            //                       + " references " + s_user + ".dmbs(ma); ");
            //            m.execute("alter table " + s_user + ".dmbschidinh add idvung number(3) default 0;");
            //            m.execute("alter table " + s_user + ".dmbschidinh add constraint fk_dmbschidinh_dmvungsale foreign key(idvung)"
            //                       + " references " + s_user + ".dmvungsale(idvung);");
            //            //
            //            sql = "CREATE TABLE medibv.thuchienylenh (id numeric(22) NOT NULL DEFAULT 0, ngay timestamp(3) ";
            //            sql += "without time zone DEFAULT now(), manv character varying(4), mach numeric(3) default 0,nhietdo ";
            //            sql += "numeric default 0, huyetap character varying(10), nhiptho numeric(3) default 0,  dienbien text, thuchien ";
            //            sql += "text, chuyendi varchar(300) default lpad('0',300,'0'), makp varchar(3), userid int default 0, CONSTRAINT ";
            //            sql += "pk_thuchienylenh PRIMARY KEY (id)) WITH (OIDS=FALSE);";
            //            m.execute_data(sql);
            //            sql = "alter table "+xxx+".v_tamungcd add column no numeric(1) default 0;";
            //            m.execute_data(sql);
            //            #endregion
            //        }
            //        else s += mmyy.Substring(0, 2) + "/20" + mmyy.Substring(2, 2) + ";";
            //    }
            //}
            //f_capnhat_datinhchenhlech();
            //f_capnhat_ngayylenh();//
            //f_capnhat_xuatvien_paid();//
            //m.CapNhat_dk_VuKeHoach();
            ////Thuy 02.06.2012
            //m.modify_schema();
            ////end 02.06.2012
            #endregion
            CrTa = new CreateTableMMYY(arg.m);
            AlTa = new AlterTableMMYY(arg.m);
            
            for (int i = Convert.ToInt16(arg.tu); i <= Convert.ToInt16(arg.den); i++)
            {
                sender.ReportProgress(0);
                mmyy = i.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
                xxx = s_user + mmyy;
                if (mmyy.IndexOf("/") != -1)
                {
                    result.errocode = 1;
                    result.ErrMes = "Tháng / năm " + mmyy + " không hợp lệ !";
                    return;
                }
                if (arg.m.bMmyy(mmyy))
                {
                    //update lấy từ Bác đưa lần 1
                   // AlTa.AlterTable_MMYY(xxx);
                    AlTa.AlterTable_MMYY_Asyn(xxx, sender);
                    //Update lấy từ Bác lần 2
                    //AlTa.AlterTable_MMYY1(xxx, s_user);
                    //AlTa.AlterTable_MMYY2(xxx, s_user);
                    //Alter thêm từ ngày 27/09/2013
                  //  AlTa.Altertable_MMYY3(xxx, s_user);
                    AlTa.Altertable_MMYY3_Asyn(xxx, s_user, sender);
                }
                else
                {
                    sender.ReportProgress(0,"Chuẩn bị tạo schema "+xxx+"....");                    
                    sender.ReportProgress(5, "Tạo schema " + xxx + "....");
                    CrTa.CreateTable_MMYY_Asyn (xxx,sender);
                    //cap nhat cac file bo sung sau: binh 081113
                   // sender.ReportProgress(60, "Cập nhật Schema gốc...");
                    AlTa.Altertable_MMYY3_Asyn(xxx, s_user,sender);
                    arg.m.upd_table(mmyy, arg.user_id);
                    //                    
                }
                sender.ReportProgress(90, "Cập nhật function "+mmyy+"....");
                arg.m.tao_function(mmyy);
                sender.ReportProgress(99);
            }
        }

        private void frmTaouser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Alt && e.Shift && e.Control)
                txtfile.Visible = !txtfile.Visible;
        }

        private void f_capnhat_ngayylenh()
        {
            string asql = " update xxx.d_xuatsdct a set ngayylenh=(select ngayylenh from xxx.d_xuatsdll b where a.id=b.id) where ngayylenh is null and id in(select id from xxx.d_xuatsdll)";
            string mmyy = "", s = "";
            for (int i = Convert.ToInt16(tu.Value); i <= Convert.ToInt16(den.Value); i++)
            {
                mmyy = i.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
                if (m.bMmyy(mmyy))
                {
                    string tmp_sql = asql.Replace("xxx.", m.user + mmyy + ".");
                    m.execute_data(tmp_sql);
                }
                else s += mmyy.Substring(0, 2) + "/20" + mmyy.Substring(2, 2) + ";";
            }
        }
        private void f_capnhat_datinhchenhlech()
        {
            bool blnChenhlech = m.bChidinh_thutienlien;
            string mmyy = "", s = "";
            string asql = " update xxx.v_chidinh a set dachenhlech=1 where dachenhlech=0 ";
            if (blnChenhlech == false) asql += " and mavp in(select id from" + m.user + ".v_giavp where chenhlenh=0)";

            string asql1 = " update xxx.v_vpkhoa a set dachenhlech=" + (blnChenhlech ? "1" : "0") + " where dachenhlech=0 ";
            if (blnChenhlech == false) asql1 += " and mavp in(select id from" + m.user + ".v_giavp where chenhlenh=0)";

            for (int i = Convert.ToInt16(tu.Value); i <= Convert.ToInt16(den.Value); i++)
            {
                mmyy = i.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
                if (m.bMmyy(mmyy))
                {
                    string tmp_sql = asql.Replace("xxx.", m.user + mmyy + ".");
                    m.execute_data(tmp_sql);
                    tmp_sql = asql1.Replace("xxx.", m.user + mmyy + ".");
                    m.execute_data(tmp_sql);
                }
                else s += mmyy.Substring(0, 2) + "/20" + mmyy.Substring(2, 2) + ";";
            }

        }
        private void f_capnhat_xuatvien_paid()
        {
            string yymmdd=DateTime.Now.Year.ToString().Substring(2,2)+"0101";
            int i_yy=int.Parse(DateTime.Now.Year.ToString());
            int i_mm=int.Parse(DateTime.Now.Month.ToString());
            int i_dd=int.Parse(DateTime.Now.Day.ToString());
            string s_user=m.user, s_mmyy="";
            if(i_mm==1)
            {
                yymmdd=i_yy.ToString().Substring(2,2)+i_mm.ToString().PadLeft(2,'0')+i_dd.ToString().PadLeft(2,'0');
            }

            string asql = " update " + s_user + ".xuatvien set paid=1 where to_char(ngay,'yymmdd')<'" + yymmdd + "' AND PAID=0 ";
            m.execute_data(asql);
            for(int i=1;i<=12;i++)
            {
                s_mmyy=i.ToString().PadLeft(2,'0')+i_yy.ToString().Substring(2,2);
                if (m.bMmyy(s_mmyy))
                {
                    asql = " update " + s_user + ".xuatvien set paid=1 where maql in(select maql from " + s_user + s_mmyy + ".v_ttrvds) and paid=0 ";
                    m.execute_data(asql);
                }
            }
        }

        private void tu_ValueChanged(object sender, EventArgs e)
        {
            if (ActiveControl == tu)
            {
                if (b_taomoi) { den.Value = tu.Value; }
            }
        }
        public bool Taomoi
        {
            set { b_taomoi = value; }
        }
    }
}