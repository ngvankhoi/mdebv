using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibMedi;
namespace dllBaocao_BYT
{
    public partial class frmTaosolieu : Form
    {
        private AccessData m;
        private DataSet ds = new DataSet();
        private DataTable dt;
        string sql = "";
        string xxx = "medibv";
        public frmTaosolieu(AccessData acc)
        {
            InitializeComponent();
            m = acc;
        }
      
        private void btnTao_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            m = new AccessData();
            xxx = "medibv";
            dt = m.get_data("Select * from " + xxx + ".DMCOSO where TUYEN IN (1,2,3)").Tables[0];
            //			//load xml
            if (System.IO.File.Exists("..\\..\\..\\xml\\dm_11.xml"))
            {
                ds.ReadXml("..\\..\\..\\xml\\dm_11.xml");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    m.upd_DM11(int.Parse(row["ma"].ToString()), row["stt"].ToString(), row["ten"].ToString(), row["icd10"].ToString());
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy file dm_11.xml !", LibMedi.AccessData.Msg);
                return;
            }
            kh_bieu01();
            kh_bieu02();
            bieu11();
            kh_bieu15();
            dmloaicosoyte();
            //			kh_bieu030();
            kh_bieu031();
            kh_bieu032();
            kh_bieu04();
            kh_bieu05();
            kh_bieu06();
            kh_bieu07();
            kh_bieu08();
            kh_bieu09();
            kh_bieu10();
            kh_bieu11();
            kh_bieu121();
            kh_bieu122();
            kh_bieu13();
            kh_bieu141();
            kh_bieu142();
            kh_bieu143();
            dt_bieu11();
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Xong!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #region bieu 04
        private void kh_bieu04()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_04(ma numeric(2) NOT NULL ,stt varchar(2),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,c17 numeric(7) DEFAULT 0,c18 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_04 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_04 OWNER TO medisoft;";
            m.execute_data(sql);
            // bieu
            sql = "CREATE TABLE " + xxx + ".khbieu_04(id numeric(8) NOT NULL DEFAULT 0,ma numeric(2) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,c17 numeric(7) DEFAULT 0,c18 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_04 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_04 OWNER TO medisoft;";
            m.execute_data(sql);
            //INSERT KHDM_04
            m.upd_danhmuc(0, "A", "Tổng số", "khdm_04");//Tổng số
            m.upd_danhmuc(1, "1", "Tiến sỹ Y", "khdm_04");//Tiến sỹ Y
            m.upd_danhmuc(2, "2", "Thạc sỹ Y", "khdm_04");//Thạc sỹ Y
            m.upd_danhmuc(3, "3", "Chuyên khoa II", "khdm_04");//Chuyên khoa II
            m.upd_danhmuc(4, "4", "Chuyên khoa I", "khdm_04");
            m.upd_danhmuc(5, "5", "Bác sỹ", "khdm_04");
            m.upd_danhmuc(6, "6", "Tiến sỹ Dược", "khdm_04");
            m.upd_danhmuc(7, "7", "Thạc sỹ Dược", "khdm_04");
            m.upd_danhmuc(8, "8", "Chuyên khoa II Dược", "khdm_04");
            m.upd_danhmuc(9, "9", "Chuyên khoa I Dược", "khdm_04");
            m.upd_danhmuc(10, "10", "Dược sỹ đại học", "khdm_04");
            m.upd_danhmuc(11, "11", "Thạc sỹ y tế Công cộng", "khdm_04");
            m.upd_danhmuc(12, "12", "Đại học y tế Công cộng", "khdm_04");
            m.upd_danhmuc(13, "13", "Cao đẳng y tế Công cộng", "khdm_04");
            m.upd_danhmuc(14, "14", "Y sỹ", "khdm_04");
            m.upd_danhmuc(15, " ", "Trong đó: Y sỹ sản nhi", "khdm_04");
            m.upd_danhmuc(16, "15", "KTV y đại học", "khdm_04");
            m.upd_danhmuc(17, "16", "KTV y cao đẳng", "khdm_04");
            m.upd_danhmuc(18, "17", "KTV y trung học", "khdm_04");
            m.upd_danhmuc(19, "18", "KTV y sơ học", "khdm_04");
            m.upd_danhmuc(20, "19", "Dược sỹ/KTV TH Dược", "khdm_04");
            m.upd_danhmuc(21, "20", "Dược tá", "khdm_04");
            m.upd_danhmuc(22, "21", "ĐD (y tá) đại học", "khdm_04");
            m.upd_danhmuc(23, "22", "ĐD (y tá) cao đẳng", "khdm_04");
            m.upd_danhmuc(24, "23", "ĐD (y tá) trung học", "khdm_04");
            m.upd_danhmuc(25, "24", "ĐD (y tá) sơ học", "khdm_04");
            m.upd_danhmuc(26, "25", "Hộ sinh Đại học", "khdm_04");
            m.upd_danhmuc(27, "26", "Hộ sinh Cao đẳng", "khdm_04");
            m.upd_danhmuc(28, "27", "Hộ sinh Trung học", "khdm_04");
            m.upd_danhmuc(29, "28", "Hộ sinh Sơ học", "khdm_04");
            m.upd_danhmuc(30, "29", "Lương y/ Lương dược", "khdm_04");
            m.upd_danhmuc(31, "30", "Đại học ngành khác", "khdm_04");
            m.upd_danhmuc(32, "31", "Cán bộ khác", "khdm_04");

            //CREATE TABLE KHDM_04_DK
            sql = "create table "+xxx+".khdm_04_dk(MA varchar(3), TEN Text, DK Text, constraint PK_khdm_04_dk primary key(ma)) with OIDS;ALTER TABLE " + xxx + ".khdm_04_dk OWNER TO medisoft;";
            m.execute_data(sql);
            //INSERT KHDM_04
            m.upd_danhmuc_dk("C03", "<Tổng số>", "C03>=0", "khdm_04_dk");
            m.upd_danhmuc_dk("C04", "<Số Nữ>", "C04<=C03", "khdm_04_dk");
            m.upd_danhmuc_dk("C05", "<Tổng số/QLNN/Tuyến quận(huyện)>", "C05+C07+..+C19<=C03", "khdm_04_dk");
            m.upd_danhmuc_dk("C06", "<Số Nữ/QLNN/Tuyến quận(huyện)>", "C04<=C03", "khdm_04_dk");
            m.upd_danhmuc_dk("C07", "<Tổng số/Phòng bệnh/Tuyến quận(huyện)>", "C05+C07+..+C19<=C03", "khdm_04_dk");
            m.upd_danhmuc_dk("C08", "<Số Nữ/Phòng bệnh/Tuyến quận(huyện)>", "C08<=C07", "khdm_04_dk");
            m.upd_danhmuc_dk("C09", "<Tổng số/Chữa bệnh/Tuyến quận(huyện)>", "C05+C07+..+C19<=C03", "khdm_04_dk");
            m.upd_danhmuc_dk("C10", "<Số Nữ/Chữa bệnh/Tuyến quận(huyện)>", "C10<=C09", "khdm_04_dk");
            m.upd_danhmuc_dk("C11", "<Tổng số/Trung tâm dân số/Tuyến quận(huyện)>", "C05+C07+..+C19<=C03", "khdm_04_dk");
            m.upd_danhmuc_dk("C12", "<Số Nữ/Trung tâm dân số/Tuyến quận(huyện)>", "C12<=C10", "khdm_04_dk");
            m.upd_danhmuc_dk("C13", "<Tổng số/Trạm Y tế/Tuyến xã(phường)>", "C05+C07+..+C19<=C03", "khdm_04_dk");
            m.upd_danhmuc_dk("C14", "<Số Nữ/Trạm Y tế/Tuyến xã(phường)>", "C14<=C13", "khdm_04_dk");
            m.upd_danhmuc_dk("C15", "<Tổng số/Thôn bản/Tuyến xã(phường)>", "C05+C07+..+C19<=C03", "khdm_04_dk");
            m.upd_danhmuc_dk("C16", "<Số Nữ/Thôn bản/Tuyến xã(phường)>", "C16<=C15", "khdm_04_dk");
            m.upd_danhmuc_dk("C17", "<Tổng số/Phòng khám/Tư nhân>", "C05+C07+..+C19<=C03", "khdm_04_dk");
            m.upd_danhmuc_dk("C18", "<Số Nữ/Phòng khám/Tư nhân>", "C18<=C17", "khdm_04_dk");
            m.upd_danhmuc_dk("C19", "<Tổng số/Cơ sở khác/Tư nhân>", "C05+C07+..+C19<=C03", "khdm_04_dk");
            m.upd_danhmuc_dk("C20", "<Số Nữ/Cơ sở khác/Tư nhân>", "C20<=C19", "khdm_04_dk");

        }
        #endregion
        #region khe hoach bieu 05
        void kh_bieu05()
        {
            m.execute_data("alter table " + xxx + ".dmcoso modify  ma numeric(5)");
            m.upd_dmtuyen(3, "Tư nhân");

            sql = "CREATE TABLE " + xxx + ".khdm_05(ma numeric(2) NOT NULL ,stt varchar(2),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,c17 numeric(7) DEFAULT 0,c18 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_05 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_05 OWNER TO medisoft;";
            m.execute_data(sql);
            // bieu
            sql = "CREATE TABLE " + xxx + ".khbieu_05(id numeric(8) NOT NULL DEFAULT 0,ma numeric(2) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,c17 numeric(7) DEFAULT 0,c18 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_05 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_05 OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc(-1, "A", "Cơ sở y tế công", "khdm_05");
            m.upd_danhmuc(150, "B", "Tư nhân", "khdm_05");
            sql = "Create table " + xxx + ".KHDM_05_DK (MA varchar(3) primary key , TEN Text,DK Text) with OIDS;ALTER TABLE " + xxx + ".khdm_05_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Phụ nữ có thai/Tổng số", "C03>=0", "khdm_05_dk");
            m.upd_danhmuc_dk("C04", "Phụ nữ có thai/trong đó vị thành niên", "(C04<=C03)", "khdm_05_dk");
            m.upd_danhmuc_dk("C05", "Tổng số lần khám thai", "C05>=0", "khdm_05_dk");
            m.upd_danhmuc_dk("C06", "Số đẻ được quản lý thai", "C06>=0", "khdm_05_dk");
            m.upd_danhmuc_dk("C07", "Số phụ nữ đẻ được tiêm đủ UV", "C07>=0", "khdm_05_dk");
            m.upd_danhmuc_dk("C08", "Phụ nữ đẻ/Tổng số PN đẻ", "(C08>=0)", "khdm_05_dk");
            m.upd_danhmuc_dk("C09", "Phụ nữ đẻ/Trong đó/Khám >=3 lần trong 3 kỳ", "(C09<=C08 AND C09+..+C14 <=C08)", "khdm_05_dk");
            m.upd_danhmuc_dk("C10", "Phụ nữ đẻ/Trong đó/ FX-GH", "(C10<=C08 AND C09+..+C14 <=C08))", "khdm_05_dk");
            m.upd_danhmuc_dk("C11", "Phụ nữ đẻ/Trong đó/Mổ lấy thai", "(C11<=C08 AND C09+..+C14 <=C08)", "khdm_05_dk");
            m.upd_danhmuc_dk("C12", "Phụ nữ đẻ/Trong đó/Đẻ con thứ 3 trở lên", "(C12<=C08 AND C09+..+C14 <=C08)", "khdm_05_dk");
            m.upd_danhmuc_dk("C13", "Phụ nữ đẻ/Trong đó/Đẻ do cán bộ y tế đỡ", "(C13<=C08 AND C09+..+C14 <=C08)", "khdm_05_dk");
            m.upd_danhmuc_dk("C14", "Phụ nữ đẻ/Trong đó/Đẻ tại cở sở y tế", "(C14<=C08 AND C09+..+C14 <=C08))", "khdm_05_dk");
            m.upd_danhmuc_dk("C15", "Bá mẹ và trẻ SS được chăm sóc sau sinh/Tổng số", "(C15>=0)", "khdm_05_dk");
            m.upd_danhmuc_dk("C16", "Bá mẹ và trẻ SS được chăm sóc sau sinh/Trong đó tuần đầu", "(C16<=C15)", "khdm_05_dk");
            foreach (DataRow row in dt.Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KHDM_05");
            }
            m.sort_stt05("KHDM_05");
        }
        #endregion
        #region ke hoach bieu 06
        void kh_bieu06()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_06(ma numeric(5) NOT NULL ,stt varchar(5),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_06 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_06 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_06(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_06 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_06 OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc(-1, "A", "Cơ sở y tế công", "khdm_06");
            m.upd_danhmuc(150, "B", "Cơ sở y tế tư", "khdm_06");
            sql = "Create table " + xxx + ".KHDM_06_DK (MA varchar(3) primary key , TEN Text,DK Text) with OIDS;ALTER TABLE " + xxx + ".khdm_06_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Băng huyết/ Mắc", "C03>=0", "khdm_06_dk");
            m.upd_danhmuc_dk("C04", "Băng huyết/ Chết", "C03<=C04", "khdm_06_dk");
            m.upd_danhmuc_dk("C05", "Sản giật/ Mắc", "C05>=0", "khdm_06_dk");
            m.upd_danhmuc_dk("C06", "Sản giật/ Chết", "C06<=C05", "khdm_06_dk");
            m.upd_danhmuc_dk("C07", "Uốn ván SS/ Mắc", "C07>=0", "khdm_06_dk");
            m.upd_danhmuc_dk("C08", "Uốn ván SS/ Chết", "C08<=C07", "khdm_06_dk");
            m.upd_danhmuc_dk("C09", "Vở tử cung/ Mắc", "C09>=0", "khdm_06_dk");
            m.upd_danhmuc_dk("C10", "Vở tử cung/ Chết", "C10<=C09", "khdm_06_dk");
            m.upd_danhmuc_dk("C11", "Nhiễm tử cung/ Mắc", "C11>=0", "khdm_06_dk");
            m.upd_danhmuc_dk("C12", "Nhiễm tử cung/ Mắc", "C12<=C11", "khdm_06_dk");
            foreach (DataRow row in dt.Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KHDM_06");
            }
            m.sort_stt05("KHDM_06");
        }
        #endregion
        #region ke hoach bieu 07
        void kh_bieu07()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_07(ma numeric(5) NOT NULL ,stt varchar(5),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_07 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_07 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_07(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_07 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_07 OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc(-1, "A", "Cơ sở y tế công", "khdm_07");
            m.upd_danhmuc(150, "B", "Cơ sở y tế tư", "khdm_07");
            sql = "Create table " + xxx + ".KHDM_07_DK (MA varchar(3) primary key , TEN Text,DK Text) with OIDS;ALTER TABLE " + xxx + ".KHDM_07_DK OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Tổng số phụ nữ >=15", "C03>=0", "khdm_07_dk");
            m.upd_danhmuc_dk("C04", "Tổng số lượt khám phụ khoa", "C04 >=0", "khdm_07_dk");
            m.upd_danhmuc_dk("C05", "Tổng số lượt chữa phụ khoa", "C05>=0", "khdm_07_dk");
            m.upd_danhmuc_dk("C06", "Phá thai/ Số phá thai theo tuần/ <=7 tuần ", "C06>=0", "khdm_07_dk");
            m.upd_danhmuc_dk("C07", "Phá thai/ Số phá thai theo tuần/ Trên 7 tuần đến <=12 tuần", "C07>=0", "khdm_07_dk");
            m.upd_danhmuc_dk("C08", "Phá thai/ Số phá thai theo tuần/ >12 tuần", "C08>=0", "khdm_07_dk");
            m.upd_danhmuc_dk("C09", "Phá thai/ Trong đó vị thàn niên", "C09>=0 AND C09 <= C06+C07+c08 ", "khdm_07_dk");
            m.upd_danhmuc_dk("C10", "Tai biến di nạo phá thai/ Số mắc", "C10 >=0", "khdm_07_dk");
            m.upd_danhmuc_dk("C11", "Tai biến di nạo phá thai/ Số chết", "C11 <= C10", "khdm_07_dk");
            foreach (DataRow row in dt.Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KHDM_07");
            }
            m.sort_stt05("KHDM_07");
        }
        #endregion
        #region ke hoach bieu 08
        void kh_bieu08()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_08(ma numeric(5) NOT NULL ,stt varchar(5),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_08 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_08 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_08(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_08 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_08 OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc(-1, "A", "Cơ sở y tế công", "khdm_08");
            m.upd_danhmuc(150, "B", "Cơ sở y tế tư", "khdm_08");
            sql = "Create table " + xxx + ".KHDM_08_DK (MA varchar(3) primary key , TEN Text,DK Text) with OIDS;ALTER TABLE " + xxx + ".khdm_08_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Tổng số người mới thực hiện BPTT", "C04+C05+C06+C07+c08+C09 <= C03", "khdm_08_dk");
            m.upd_danhmuc_dk("C04", "Tổng số người mới thực hiện BPTT/ Trong đó : số đặt dụng cụ tử cung ", "C04+C05+C06+C07+c08+C09 <= C03", "khdm_08_dk");
            m.upd_danhmuc_dk("C05", "Tổng số người mới thực hiện BPTT/ Trong đó /Thuốc tránh thai : Thuốc viên ", "C04+C05+C06+C07+c08+C09 <= C03", "khdm_08_dk");
            m.upd_danhmuc_dk("C06", "Tổng số người mới thực hiện BPTT/ Trong đó /Thuốc tránh thai : thuốc tiêm ", "C04+C05+C06+C07+c08+C09 <= C03", "khdm_08_dk");
            m.upd_danhmuc_dk("C07", "Tổng số người mới thực hiện BPTT/ Trong đó /Thuốc tránh thai : Thuốc cấy", "C04+C05+C06+C07+c08+C09 <= C03", "khdm_08_dk");
            m.upd_danhmuc_dk("C08", "Tổng số người mới thực hiện BPTT/ Trong đó : bao cao su", "C04+C05+C06+C07+c08+C09 <= C03", "khdm_08_dk");
            m.upd_danhmuc_dk("C09", "Tổng số người mới thực hiện BPTT/ Triệt sản mới : Tổng số", "C04+C05+C06+C07+c08+C09 <= C03", "khdm_08_dk");
            m.upd_danhmuc_dk("C10", "Tổng số người mới thực hiện BPTT/ Triệt sản mới : Nữ", "C10 <= C09", "khdm_08_dk");
            m.upd_danhmuc_dk("C11", "Tai biến do thực hiện KHHGD: Số mắc", "C11 <= C03", "khdm_08_dk");
            m.upd_danhmuc_dk("C12", "Tai biến do thực hiện KHHGD: Số chết", "C12 <= C11", "khdm_08_dk");
            foreach (DataRow row in dt.Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KHDM_08");
            }
            m.sort_stt05("KHDM_08");
        }
        #endregion
        #region ke hoach bieu 09
        void kh_bieu09()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_09(ma numeric(5) NOT NULL ,stt varchar(5),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_09 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_09 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_09(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_09 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_09 OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc(-1, "A", "Cơ sở y tế công", "khdm_09");
            m.upd_danhmuc(150, "B", "Tư nhân", "khdm_09");
            sql = "Create table " + xxx + ".KHDM_09_DK (MA varchar(3) primary key , TEN Text,DK Text) with OIDS;ALTER TABLE " + xxx + ".khdm_09_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Số trẻ đẻ ra sống: Tổng số", "C03>=0", "khdm_09_dk");
            m.upd_danhmuc_dk("C04", "Số trẻ đẻ ra sống: Trong đó nữ ", "C04 <= C03", "khdm_09_dk");
            m.upd_danhmuc_dk("C05", "Số trẻ được cân : Tổng số", "C05 >=0", "khdm_09_dk");
            m.upd_danhmuc_dk("C06", "Số trẻ được cân : Trong đó <2500g", "C06 <= C05", "khdm_09_dk");
            m.upd_danhmuc_dk("C07", "Chết thai nhi và chết trẻ em: Chết thai nhi từ 22 tuần đến khi đẻ", "C07>=0", "khdm_09_dk");
            m.upd_danhmuc_dk("C08", "Chết thai nhi và chết trẻ em: Số chết <7 ngày", "C08>=0", "khdm_09_dk");
            m.upd_danhmuc_dk("C09", "Chết thai nhi và chết trẻ em: Số chết sơ sinh (<=28 ngày)", "C09>=0", "khdm_09_dk");
            m.upd_danhmuc_dk("C10", "Tỷ lệ SDD trẻ em <5 tuổi(cân/tuổi)", "C10>=0", "khdm_09_dk");
            foreach (DataRow row in dt.Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KHDM_09");
            }
            m.sort_stt05("KHDM_09");
        }
        #endregion
        #region Biểu 10 vụ kế hoạch
        private void kh_bieu10()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_10(ma varchar(7) NOT NULL ,stt varchar(5),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_10 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_10 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_10(id numeric(8) NOT NULL DEFAULT 0,ma varchar(7) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_10 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_10 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "Create table " + xxx + ".KHDM_10_DK (MA varchar(3) , TEN Text,DK Text) with OIDS;ALTER TABLE " + xxx + ".khdm_10_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Số trẻ em <1 tuổi", "(C03>0)", "khdm_10_dk");
            m.upd_danhmuc_dk("C04", "Số trẻ TCĐĐ 7 loại vắc xin", "(C04>0)", "khdm_10_dk");
            m.upd_danhmuc_dk("C05", "Số trẻ TCĐĐ 7 loại vắc xin/Trong đó:BCG", "(C05+..+C09 <= C04)", "khdm_10_dk");
            m.upd_danhmuc_dk("C06", "Số trẻ TCĐĐ 7 loại vắc xin/Trong đó:DPT", "(C05+..+C09 <= C04)", "khdm_10_dk");
            m.upd_danhmuc_dk("C07", "Số trẻ TCĐĐ 7 loại vắc xin/Trong đó:OPV", "(C05+..+C09 <= C04)", "khdm_10_dk");
            m.upd_danhmuc_dk("C08", "Số trẻ TCĐĐ 7 loại vắc xin/Trong đó:Viêm gan B", "(C05+..+C09 <= C04)", "khdm_10_dk");
            m.upd_danhmuc_dk("C09", "Số trẻ TCĐĐ 7 loại vắc xin/Trong đó:Sởi", "(C05+..+C09 <= C04)", "khdm_10_dk");
            m.upd_danhmuc_dk("C10", "Viêm não nhật bản", "(C10>0)", "khdm_10_dk");
            m.upd_danhmuc_dk("C11", "Tả", "(C11>0)", "khdm_10_dk");
            m.upd_danhmuc_dk("C12", "Thương hàn", "(C12>0)", "khdm_10_dk");
            m.upd_danhmuc_dk("C13", "Số phụ nữ có thai được ưu tiên UV2+", "(C13>0)", "khdm_10_dk");
            sql = "select a.maphuongxa as ma,a.tenpxa from " + xxx + ".btdpxa a," + xxx + ".btdtt b," + xxx + ".btdquan c where a.maqu=c.maqu and b.matt=c.matt and b.matt ='" + m.Mabv.Substring(0, 3) + "'";
            int stt = 1;
            m.execute_data("delete from khdm_10");
            foreach (DataRow row in m.get_data(sql).Tables[0].Rows)
            {
                if (row["ma"].ToString().Substring(5, 2) != "00")
                {
                    m.upd_danhmuc(row["ma"].ToString(), stt.ToString(), row["tenpxa"].ToString(), "khdm_10");
                    stt++;
                }
            }

        }
        #endregion
        #region kh bieu 11
        #region ke hoach bieu 11
        void kh_bieu11()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_11(ma numeric(5) NOT NULL ,stt varchar(5),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,c17 numeric(7) DEFAULT 0,c18 numeric(7) DEFAULT 0,c19 numeric(7) DEFAULT 0,c20 numeric(7) DEFAULT 0,c21 numeric(7) DEFAULT 0,c22 numeric(7) DEFAULT 0,c23 numeric(7) DEFAULT 0,c24 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_11 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_11 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_11(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,c17 numeric(7) DEFAULT 0,c18 numeric(7) DEFAULT 0,c19 numeric(7) DEFAULT 0,c20 numeric(7) DEFAULT 0,c21 numeric(7) DEFAULT 0,c22 numeric(7) DEFAULT 0,c23 numeric(7) DEFAULT 0,c24 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_11 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_11 OWNER TO medisoft;";
            m.execute_data(sql);
            m.execute_data("delete from khdm_11");
            m.upd_danhmuc(-1, "A", "Tổng số", "khdm_11");
            sql = "Create table " + xxx + ".KHDM_11_DK (MA varchar(3) primary key , TEN Text,DK Text)with OIDS;ALTER TABLE " + xxx + ".khdm_11_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Sởi:Mắc", "C03>=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C04", "Sởi:Chết", "C04 <= C03", "khdm_11_dk");
            m.upd_danhmuc_dk("C05", "Ho gà:Mắc", "C05 >=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C06", "Ho gà:Chết", "C06 <= C05", "khdm_11_dk");
            m.upd_danhmuc_dk("C07", "LMC:Mắc", "C07>=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C08", "LMC:Chết", "C08<= C07", "khdm_11_dk");
            m.upd_danhmuc_dk("C09", "Bạch hầu:Mắc", "C09>=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C10", "Bạch hầu:Chết", "C10<=C09", "khdm_11_dk");
            m.upd_danhmuc_dk("C11", "UVSS:Mắc", "C11>=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C12", "UVSS:Chết", "C12<=C11", "khdm_11_dk");
            m.upd_danhmuc_dk("C13", "UV Khác:Mắc", "C13>=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C14", "UV Khác:Chết", "C14<=C13", "khdm_11_dk");
            m.upd_danhmuc_dk("C15", "Lao màng não:Mắc", "C15>=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C16", "Lao màng não:Chết", "C16<=C15", "khdm_11_dk");
            m.upd_danhmuc_dk("C17", "Lao khác:Mắc", "C17>=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C18", "Lao khác:Chết", "C18<=C17", "khdm_11_dk");
            m.upd_danhmuc_dk("C19", "Viêm gan virus:Mắc", "C19>=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C20", "Viêm gan virus:Chết", "C20<=C19", "khdm_11_dk");
            m.upd_danhmuc_dk("C21", "Viêm não virus:Mắc", "C21>=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C22", "Viêm não virus:Chết", "C22<=C21", "khdm_11_dk");
            m.upd_danhmuc_dk("C23", "Tả:Mắc", "C23>=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C24", "Tả:Chết", "C24<=C23", "khdm_11_dk");
            m.upd_danhmuc_dk("C25", "Thương hàn:Mắc", "C25>=0", "khdm_11_dk");
            m.upd_danhmuc_dk("C26", "Thương hàn:Chết", "C26<=C25", "khdm_11_dk");

            foreach (DataRow row in m.get_data("Select * from " + xxx + ".DMCOSO order by ma").Tables[0].Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KHDM_11");

            }
            m.sort_danhmuc("KHDM_11");
        }
        #endregion
        #endregion
        #region ke hoach bieu 121
        void kh_bieu121()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_121(ma numeric(5) NOT NULL ,stt varchar(5),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_121 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_121 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_121(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_121 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_121 OWNER TO medisoft;";
            m.execute_data(sql);
            m.execute_data("delete from khdm_121");
            m.upd_danhmuc(-1, "A", "Cơ sở y tế nhà nước", "khdm_121");
            m.upd_danhmuc(150, "B", "Cơ sở y tế tư nhân", "khdm_121");
            sql = "Create table " + xxx + ".khdm_121_dk (MA varchar(3) primary key , TEN Text,DK Text)with OIDS;ALTER TABLE " + xxx + ".khdm_121_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Số lần khám:Tổng số", "C03>=0", "khdm_121_dk");
            m.upd_danhmuc_dk("C04", "Số lần khám/trong đó:YHCT", "C04<=C03", "khdm_121_dk");
            m.upd_danhmuc_dk("C05", "Số lần khám/Trong đó:TE<6 tuổi", "C04<=C03 ", "khdm_121_dk");
            m.upd_danhmuc_dk("C06", "Khám dự phòng", "C06>=0", "khdm_121_dk");
            m.upd_danhmuc_dk("C07", "Số lượt điều trị nội trú:Tổng số", "C07>=0", "khdm_121_dk");
            m.upd_danhmuc_dk("C08", "Số lượt điều trị nội trú/trong đó:YHCT", "C08 <=C07", "khdm_121_dk");
            m.upd_danhmuc_dk("C09", "Số lượt điều trị nội trú/Trong đó:TE<6 tuổi", "C09 <=C07", "khdm_121_dk");
            m.upd_danhmuc_dk("C10", "Tổng số ngày điều trị", "C10 >=C07", "khdm_121_dk");
            foreach (DataRow row in dt.Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KHDM_121");
            }
            m.sort_stt05("KHDM_121");
        }
        #endregion
        #region ke hoach bieu 122
        void kh_bieu122()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_122(ma numeric(5) NOT NULL ,stt varchar(5),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_122 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_122 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_122(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_122 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_122 OWNER TO medisoft;";
            m.execute_data(sql);
            m.execute_data("delete from khdm_122");
            m.upd_danhmuc(-1, "A", "Cơ sở y tế nhà nước", "khdm_122");
            m.upd_danhmuc(150, "B", "Cơ sở y tế tư nhân", "khdm_122");
            sql = "Create table " + xxx + ".khdm_122_dk (MA varchar(3) primary key , TEN Text,DK Text)with OIDS;ALTER TABLE " + xxx + ".khdm_122_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Số lần điều trị ngoại trú:Tổng số", "C03>=0", "khdm_122_dk");
            m.upd_danhmuc_dk("C04", "Số lần điều trị ngoại trú/trong đó:YHCT", "C04 <= C03", "khdm_122_dk");
            m.upd_danhmuc_dk("C05", "Số lần điều trị ngoại trú/Trong đó:TE<6 tuổi", "C05 <= C03 ", "khdm_122_dk");
            m.upd_danhmuc_dk("C06", "Số bệnh nhân chết tại cơ sở y tế:Tổng số", "C06>=0", "khdm_122_dk");
            m.upd_danhmuc_dk("C07", "Số bệnh nhân chết tại cơ sở y tế/trong đó:Trẻ em < 1 tuổi", "C07 >=0 AND C07+c08 <= C06", "khdm_122_dk");
            m.upd_danhmuc_dk("C08", "Số bệnh nhân chết tại cơ sở y tế/trong đó:Trẻ em < 5 tuổi", "C08>=0  AND C07+C08 <=C06", "khdm_122_dk");
            m.upd_danhmuc_dk("C09", "Số lần xét nghiệm", "C09>=0", "khdm_122_dk");
            m.upd_danhmuc_dk("C10", "Số lần chụp X quang", "C10 >=0", "khdm_122_dk");
            m.upd_danhmuc_dk("C11", "Số lần siêu âm", "C11 >=0", "khdm_122_dk");
            m.upd_danhmuc_dk("C12", "Tổng số phẫu thuật", "C12 >=0", "khdm_122_dk");
            foreach (DataRow row in dt.Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KHDM_122");
            }
            m.sort_stt05("KHDM_122");
        }
        #endregion
        #region ke hoach bieu 13
        #region khb 03
        void kh_bieu131()
        {
            foreach (DataRow row in m.get_data("select ma,ten from " + xxx + ".dmcoso where tuyen in (1,2)").Tables[0].Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KH_DM_131");
            }
            m.sort_stt("kh_dm_131");
        }
        #endregion
        #region khb 03
        void kh_bieu132()
        {
            foreach (DataRow row in m.get_data("select ma,ten from " + xxx + ".dmcoso where tuyen in (1,2)").Tables[0].Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KH_DM_132");
            }
            m.sort_stt("kh_dm_132");
        }
        #endregion
        #region khb 03
        void kh_bieu133()
        {
            foreach (DataRow row in m.get_data("select ma,ten from " + xxx + ".dmcoso where tuyen in (1,2)").Tables[0].Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KH_DM_133");
            }
            m.sort_stt("kh_dm_133");
        }
        #endregion
        void kh_bieu13()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_13(ma numeric(5) NOT NULL ,stt varchar(5),ten text,soluong numeric(7) default 0 ,ghichu text,CONSTRAINT pk_khdm_13 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_13 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_13(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,soluong numeric(7) DEFAULT 0,ghichu text,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_13 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_13 OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc(1, "I", "Phòng chống lao", "khdm_13");
            m.upd_danhmuc(2, "1", "Tổng số bệnh nhân thu nhận", "khdm_13");
            m.upd_danhmuc(3, "2", "Số bệnh nhân lao phổi AFB(+)", "khdm_13");
            m.upd_danhmuc(4, " ", "Trong đó:- Mới", "khdm_13");
            m.upd_danhmuc(5, " ", "         - Tái phát", "khdm_13");
            m.upd_danhmuc(6, " ", "         - Thất bại", "khdm_13");
            m.upd_danhmuc(7, " ", "         - Điều trị lại", "khdm_13");
            m.upd_danhmuc(8, "3", "Lao phổi AFB(-)", "khdm_13");
            m.upd_danhmuc(9, "4", "Bệnh nhân lao ngoài phổi", "khdm_13");
            m.upd_danhmuc(10, "5", "Khác", "khdm_13");
            m.upd_danhmuc(11, "6", "Kết quả điều trị Lao phổi AFB(+) mới", "khdm_13");
            m.upd_danhmuc(12, " ", "Trong đó:- Điều trị thành công", "khdm_13");
            m.upd_danhmuc(13, " ", "         - Số chết", "khdm_13");
            m.upd_danhmuc(14, "II", "Phòng chống sốt rét", "khdm_13");
            m.upd_danhmuc(15, "1", "Số bệnh nhân được xét nghiệm sốt rét", "khdm_13");
            m.upd_danhmuc(16, " ", "Trong đó:- Số có KSTSR", "khdm_13");
            m.upd_danhmuc(17, "2", "Tổng số bệnh nhân SR", "khdm_13");
            m.upd_danhmuc(18, " ", "- Số BNSR được xét nghiệm", "khdm_13");
            m.upd_danhmuc(19, " ", "- Số bệnh nhân ngoại tỉnh", "khdm_13");
            m.upd_danhmuc(20, "3", "Số bệnh nhân sốt rét thường", "khdm_13");
            m.upd_danhmuc(21, "3.1", "Số bệnh nhân sốt rét lâm sàng", "khdm_13");
            m.upd_danhmuc(22, " ", "Trong đó: - trẻ em <5 tuổi", "khdm_13");
            m.upd_danhmuc(23, " ", "          - trẻ em từ 5-14 tuổi", "khdm_13");
            m.upd_danhmuc(24, " ", "          - phụ nữ có thai", "khdm_13");
            m.upd_danhmuc(25, "3.2", "Số BNSR có KST", "khdm_13");
            m.upd_danhmuc(26, " ", "Trong đó: - trẻ em <5 tuổi", "khdm_13");
            m.upd_danhmuc(27, " ", "          - trẻ em từ 5-14 tuổi", "khdm_13");
            m.upd_danhmuc(28, " ", "          - Phụ nữ có thai", "khdm_13");
            m.upd_danhmuc(29, "4", "Số bệnh nhân SRAT ", "khdm_13");
            m.upd_danhmuc(30, " ", "Trong đó: - trẻ em <5 tuổi", "khdm_13");
            m.upd_danhmuc(31, " ", "          - trẻ em từ 5-14 tuổi", "khdm_13");
            m.upd_danhmuc(32, " ", "          - phụ nữ có thai", "khdm_13");
            m.upd_danhmuc(33, " ", "- Số BNSRAT có KST", "khdm_13");
            m.upd_danhmuc(34, "5", "Số bệnh nhân chết sốt rét", "khdm_13");
            m.upd_danhmuc(35, " ", "Trong đó: - trẻ em <5 tuổi", "khdm_13");
            m.upd_danhmuc(36, " ", "          - trẻ em từ 5-14 tuổi", "khdm_13");
            m.upd_danhmuc(37, " ", "          - phụ nữ có thai", "khdm_13");
            m.upd_danhmuc(38, "6", "Số vụ sốt rét", "khdm_13");
            m.upd_danhmuc(39, "III", "Phòng chống HIV/AIDS", "khdm_13");
            m.upd_danhmuc(40, "1", "Số hiện mắc HIV", "khdm_13");
            m.upd_danhmuc(41, " ", "Trong đó:- Nữ", "khdm_13");
            m.upd_danhmuc(42, " ", "         - Mới phát hiện HIV", "khdm_13");
            m.upd_danhmuc(43, "2", "Số hiện mắc AIDS", "khdm_13");
            m.upd_danhmuc(44, " ", "Trong đó:- Nữ", "khdm_13");
            m.upd_danhmuc(45, " ", "         - Mới chuyển sang AIDS", "khdm_13");
            m.upd_danhmuc(46, "3", "Số chết do bị AIDS", "khdm_13");
            m.upd_danhmuc(47, "IV", "Sức khỏe tâm thần", "khdm_13");
            m.upd_danhmuc(48, "1", "Số hiện mắc mắc động kinh", "khdm_13");
            m.upd_danhmuc(49, " ", "Số được quản lý", "khdm_13");
            m.upd_danhmuc(50, " ", "Trong đó: Số mới phát hiện", "khdm_13");
            m.upd_danhmuc(51, " ", "          Số đang điều trị ", "khdm_13");
            m.upd_danhmuc(52, " ", "          Số tử vong", "khdm_13");
            m.upd_danhmuc(53, "2", "Số hiện mắc TTPL", "khdm_13");
            m.upd_danhmuc(54, " ", "Số được quản lý", "khdm_13");
            m.upd_danhmuc(55, " ", "Trong đó: Số mới phát hiện", "khdm_13");
            m.upd_danhmuc(56, " ", "          Số đang điều trị ", "khdm_13");
            m.upd_danhmuc(57, " ", "          Số tử vong", "khdm_13");
            m.upd_danhmuc(58, "3", "Số hiện mắc trầm cảm", "khdm_13");
            m.upd_danhmuc(59, " ", "Số được quản lý", "khdm_13");
            m.upd_danhmuc(60, " ", "Trong đó: Số mới phát hiện", "khdm_13");
            m.upd_danhmuc(61, " ", "          Số đang điều trị ", "khdm_13");
            m.upd_danhmuc(62, " ", "          Số tử vong", "khdm_13");
            m.upd_danhmuc(63, "V", "Phòng chống hoa liễu", "khdm_13");
            m.upd_danhmuc(64, "1", "Số bệnh nhân lậu mới phát hiện trong kỳ", "khdm_13");
            m.upd_danhmuc(65, " ", "trong đó: Lậu mắt trẻ sơ sinh", "khdm_13");
            m.upd_danhmuc(66, "2", "Số bệnh giang mai mới phát hiện", "khdm_13");
            m.upd_danhmuc(67, " ", "trong đó: giang mai bẩm sinh", "khdm_13");
            m.upd_danhmuc(68, "VI", "Phòng chống bệnh phong", "khdm_13");
            m.upd_danhmuc(69, "1", "Số bệnh hiện mắc bệnh phong", "khdm_13");
            m.upd_danhmuc(70, " ", "trong đó: Số bệnh nhân mới phát hiện", "khdm_13");
            m.upd_danhmuc(71, "2", "Số bênh nhân phong mới bị tàn tật độ II", "khdm_13");
            //
            sql = "Create table " + xxx + ".KHDM_13_DK (MA varchar(3) primary key , TEN Text,DK Text) with OIDS;ALTER TABLE " + xxx + ".khdm_13_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Số lượng", "soluong >=0", "khdm_13_dk");

        }
        #endregion
        #region ke hoach bieu 14.1
        void kh_bieu141()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_141(ma numeric(5) NOT NULL ,stt varchar(5),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,c17 numeric(7) DEFAULT 0,c18 numeric(7) DEFAULT 0,c19 numeric(7) DEFAULT 0,c20 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_141 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_141 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_141(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,c17 numeric(7) DEFAULT 0,c18 numeric(7) DEFAULT 0,c19 numeric(7) DEFAULT 0,c20 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_141 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_141 OWNER TO medisoft;";
            m.execute_data(sql);
            m.execute_data("delete from " + xxx + ".khdm_141");
            m.upd_danhmuc(-1, "A", "Tổng số", "khdm_141");
            sql = "Create table " + xxx + ".KHDM_141_DK (MA varchar(3) primary key , TEN Text,DK Text) with OIDS;ALTER TABLE " + xxx + ".khdm_141_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Phảy khuẩn tả:Mắc", "C03>=0", "khdm_141_dk");
            m.upd_danhmuc_dk("C04", "Phảy khuẩn tả:Chết", "C04 <= C03", "khdm_141_dk");
            m.upd_danhmuc_dk("C05", "Thương hàn:Mắc", "C05 >=0", "khdm_141_dk");
            m.upd_danhmuc_dk("C06", "Thương hàn:Chết", "C06 <= C05", "khdm_141_dk");
            m.upd_danhmuc_dk("C07", "Ly trực trùng:Mắc", "C07>=0", "khdm_141_dk");
            m.upd_danhmuc_dk("C08", "Ly trực trùng:Chết", "C08<= C07", "khdm_141_dk");
            m.upd_danhmuc_dk("C09", "Lỵ A mip:Mắc", "C09>=0", "khdm_141_dk");
            m.upd_danhmuc_dk("C10", "Lỵ A mip:Chết", "C10<=C09", "khdm_141_dk");
            m.upd_danhmuc_dk("C11", "Hội chứng lỵ:Mắc", "C11>=0", "khdm_141_dk");
            m.upd_danhmuc_dk("C12", "Hội chứng lỵ:Chết", "C12<=C11", "khdm_141_dk");
            m.upd_danhmuc_dk("C13", "Tiêu chảy:Mắc", "C13>=0", "khdm_141_dk");
            m.upd_danhmuc_dk("C14", "Tiêu chảy:Chết", "C14<=C13", "khdm_141_dk");
            m.upd_danhmuc_dk("C15", "Viêm não virus:Mắc", "C15>=0", "khdm_141_dk");
            m.upd_danhmuc_dk("C16", "Viêm não virus:Chết", "C16<=C15", "khdm_141_dk");
            m.upd_danhmuc_dk("C17", "Sốt xuất huyết:Mắc", "C17>=0", "khdm_141_dk");
            m.upd_danhmuc_dk("C18", "Sốt xuất huyết:Chết", "C18<=C17", "khdm_141_dk");
            m.upd_danhmuc_dk("C19", "B.Chân - tay - miêng:Mắc", "C19>=0", "khdm_141_dk");
            m.upd_danhmuc_dk("C20", "B. Chân - tay - miệng:Chết", "C20<=C19", "khdm_141_dk");
            m.upd_danhmuc_dk("C21", "Viêm gan Virus:Mắc", "C21>=0", "khdm_141_dk");
            m.upd_danhmuc_dk("C22", "Viêm gan Virus:Chết", "C22<=C21", "khdm_141_dk");
            foreach (DataRow row in m.get_data("Select * from " + xxx + ".DMCOSO order by ma").Tables[0].Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KHDM_141");
            }
            m.sort_danhmuc("KHDM_141");
        }
        #endregion
        #region ke hoach bieu 14.2
        void kh_bieu142()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_142(ma numeric(5) NOT NULL ,stt varchar(5),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,c17 numeric(7) DEFAULT 0,c18 numeric(7) DEFAULT 0,c19 numeric(7) DEFAULT 0,c20 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_142 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_142 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_142(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,c17 numeric(7) DEFAULT 0,c18 numeric(7) DEFAULT 0,c19 numeric(7) DEFAULT 0,c20 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_142 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_142 OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc(-1, "A", "Tổng số", "khdm_142");
            sql = "Create table " + xxx + ".KHDM_142_DK (MA varchar(3) primary key , TEN Text,DK Text) with OIDS;ALTER TABLE " + xxx + ".khdm_142_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Dại và nghi dại:Mắc", "C03>=0", "khdm_142_dk");
            m.upd_danhmuc_dk("C04", "Dại và nghi dại:Chết", "C04 <= C03", "khdm_142_dk");
            m.upd_danhmuc_dk("C05", "Viêm màng não mô cầu:Mắc", "C05 >=0", "khdm_142_dk");
            m.upd_danhmuc_dk("C06", "Viêm màng não mô cầu:Chết", "C06 <= C05", "khdm_142_dk");
            m.upd_danhmuc_dk("C07", "Thủy đậu:Mắc", "C07>=0", "khdm_142_dk");
            m.upd_danhmuc_dk("C08", "Thủy đậu:Chết", "C08<= C07", "khdm_142_dk");
            m.upd_danhmuc_dk("C09", "Uốn ván:Mắc", "C09>=0", "khdm_142_dk");
            m.upd_danhmuc_dk("C10", "Uốn ván:Chết", "C10<=C09", "khdm_142_dk");
            m.upd_danhmuc_dk("C11", "Quai bị :Mắc", "C11>=0", "khdm_142_dk");
            m.upd_danhmuc_dk("C12", "Quai bị :Chết", "C12<=C11", "khdm_142_dk");
            m.upd_danhmuc_dk("C13", "Viêm đường hô hấp trên:Mắc", "C13>=0", "khdm_142_dk");
            m.upd_danhmuc_dk("C14", "Viêm đường hô hấp trên:Chết", "C14<=C13", "khdm_142_dk");
            m.upd_danhmuc_dk("C15", "Viêm phế quản:Mắc", "C15>=0", "khdm_142_dk");
            m.upd_danhmuc_dk("C16", "Viêm phế quản:Chết", "C16<=C15", "khdm_142_dk");
            m.upd_danhmuc_dk("C17", "Viêm phổi:Mắc", "C17>=0", "khdm_142_dk");
            m.upd_danhmuc_dk("C18", "Viêm phổi:Chết", "C18<=C17", "khdm_142_dk");
            m.upd_danhmuc_dk("C19", "Cúm A(H5N1):Mắc", "C19>=0", "khdm_142_dk");
            m.upd_danhmuc_dk("C20", "Cúm A(H5N1):Chết", "C20<=C19", "khdm_142_dk");
            m.upd_danhmuc_dk("C21", "Cúm A(H1N1):Mắc", "C21>=0", "khdm_142_dk");
            m.upd_danhmuc_dk("C22", "Cúm A(H1N1)", "C22<=C21", "khdm_142_dk");
            foreach (DataRow row in m.get_data("Select * from " + xxx + ".DMCOSO order by ma").Tables[0].Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KHDM_142");
            }
            m.sort_danhmuc("KHDM_142");
        }
        #endregion
        #region ke hoach bieu 14.3
        void kh_bieu143()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_143(ma numeric(5) NOT NULL ,stt varchar(5),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_143 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_143 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_143(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0,c16 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_143 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_143 OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc(-1, "A", "Tổng số", "khdm_143");
            sql = "Create table " + xxx + ".KHDM_143_DK (MA varchar(3) primary key , TEN Text,DK Text) with OIDS;ALTER TABLE " + xxx + ".khdm_143_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Dịch hạch:Mắc", "C03>=0", "khdm_143_dk");
            m.upd_danhmuc_dk("C04", "Dịch hạch:Chết", "C04 <= C03", "khdm_143_dk");
            m.upd_danhmuc_dk("C05", "Lepto:Mắc", "C05 >=0", "khdm_143_dk");
            m.upd_danhmuc_dk("C06", "Lepto:Chết", "C06 <= C05", "khdm_143_dk");
            m.upd_danhmuc_dk("C07", "Tai nạn, ngộ độc chấn thương các loại/Tự tử:Mắc", "C07>=0", "khdm_143_dk");
            m.upd_danhmuc_dk("C08", "Tai nạn, ngộ độc chấn thương các loại/Tự tử:Chết", "C08<= C07", "khdm_143_dk");
            m.upd_danhmuc_dk("C09", "Tai nạn, ngộ độc chấn thương các loại/Ngộ độc thực phẩm:Mắc", "C09>=0", "khdm_143_dk");
            m.upd_danhmuc_dk("C10", "Tai nạn, ngộ độc chấn thương các loại/Ngộ độc thực phẩm:Chết", "C10<=C09", "khdm_143_dk");
            m.upd_danhmuc_dk("C11", "Tai nạn, ngộ độc chấn thương các loại/TNGT:Mắc", "C11>=0", "khdm_143_dk");
            m.upd_danhmuc_dk("C12", "Tai nạn, ngộ độc chấn thương các loại/TNGT:Chết", "C12<=C11", "khdm_143_dk");
            m.upd_danhmuc_dk("C13", "Tai nạn, ngộ độc chấn thương các loại/TN LĐ:Mắc", "C13>=0", "khdm_143_dk");
            m.upd_danhmuc_dk("C14", "Tai nạn, ngộ độc chấn thương các loại/TN LĐ:Chết", "C14<=C13", "khdm_143_dk");
            m.upd_danhmuc_dk("C15", "Tai nạn, ngộ độc chấn thương các loại/NĐ h.chất:Mắc", "C15>=0", "khdm_143_dk");
            m.upd_danhmuc_dk("C16", "Tai nạn, ngộ độc chấn thương các loại/NĐ h.chất", "C16<=C15", "khdm_143_dk");
            m.upd_danhmuc_dk("C17", "Tai nạn, ngộ độc chấn thương các loại/TN khác:Mắc", "C17>=0", "khdm_143_dk");
            m.upd_danhmuc_dk("C18", "Tai nạn, ngộ độc chấn thương các loại/TN khác:Chết", "C18<=C17", "khdm_143_dk");
            foreach (DataRow row in m.get_data("Select * from " + xxx + ".DMCOSO order by ma").Tables[0].Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KHDM_143");
            }
            m.sort_danhmuc("KHDM_143");
        }
        #endregion
        #region khb 14.4
        void kh_bieu144()
        {
            foreach (DataRow row in m.get_data("select ma,ten from " + xxx + ".dmcoso where tuyen in (1,2)").Tables[0].Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KH_DM_144");
            }
            m.sort_stt("kh_dm_144");
        }
        #endregion
        #region bieu 03.1 vu ke hoach
        private void kh_bieu031()
        {
            sql = "CREATE TABLE " + xxx + ".khdm_031(ma numeric(3) NOT NULL ,stt varchar(2),ten text,sttt numeric(4) default 0,idloaics numeric(4) default 0,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_031 PRIMARY KEY (ma)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_031 OWNER TO medisoft;";
            m.execute_data(sql);
            sql = "CREATE TABLE " + xxx + ".khbieu_031(id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_031 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_031 OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_dmkhbieu_03();
            sql = "Create table " + xxx + ".KHDM_031_DK (MA varchar(3) primary key , TEN text,DK Text) with oids;ALTER TABLE " + xxx + ".khdm_031_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Bệnh viện/Cơ sở", "(C03>0)", "khdm_031_dk");
            m.upd_danhmuc_dk("C04", "Bệnh viện/Giương bệnh/ kế hoạch", "(C04>0)", "khdm_031_dk");
            m.upd_danhmuc_dk("C05", "Bệnh viện/Giường bệnh/ thực kê", "(C05>0)", "khdm_031_dk");
            m.upd_danhmuc_dk("C06", "Phòng khám/Cơ sở", "(C06>0)", "khdm_031_dk");
            m.upd_danhmuc_dk("C07", "Phòng khám/Giường bệnh", "(C07>0)", "khdm_031_dk");
            m.upd_danhmuc_dk("C08", "Nhà hộ sinh/Cơ sở", "(C08>0)", "khdm_031_dk");
            m.upd_danhmuc_dk("C09", "Nhà hộ sinh/Giường bệnh", "(C09>0)", "khdm_031_dk");
            m.upd_danhmuc_dk("C10", "Trạm y tế/Cơ sở", "(C10>0)", "khdm_031_dk");
            m.upd_danhmuc_dk("C11", "Trạm y tế/Giường bệnh", "(C11>0)", "khdm_031_dk");
            m.upd_danhmuc_dk("C12", "Cơ sở khác/Cơ sở", "(C12>0)", "khdm_031_dk");
            m.upd_danhmuc_dk("C13", "Cơ sở khác/Giường bệnh", "(C13>0)", "khdm_031_dk");

        }
        #endregion
        #region Biểu 3.2 vụ kế hoạch
        private void kh_bieu032()
        {    // danh muc
            sql = "CREATE TABLE " + xxx + ".khdm_032(ma varchar(8) NOT NULL ,stt varchar(10),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_032 PRIMARY KEY (ma,stt)) WITH OIDS;ALTER TABLE " + xxx + ".khdm_032 OWNER TO medisoft;";
            m.execute_data(sql);
            // bieu
            sql = "CREATE TABLE " + xxx + ".khbieu_032(id numeric(8) NOT NULL DEFAULT 0,ma varchar(8) NOT NULL ,ngay timestamp without time zone,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0,ngayud timestamp without time zone DEFAULT now(),CONSTRAINT pk_khbieu_032 PRIMARY KEY (id, ma)) WITH OIDS;ALTER TABLE " + xxx + ".khbieu_032 OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc("0", "0", "Tổng số", "khdm_032");
            sql = "select a.maphuongxa as ma,a.tenpxa from " + xxx + ".btdpxa a," + xxx + ".btdtt b," + xxx + ".btdquan c where a.maqu=c.maqu and b.matt=c.matt and b.matt ='" + m.Mabv.Substring(0, 3) + "'";
            int stt = 1;
            foreach (DataRow row in m.get_data(sql).Tables[0].Rows)
            {
                if (row["ma"].ToString().Substring(5, 2) != "00")
                {
                    m.upd_danhmuc(row["ma"].ToString(), stt.ToString(), row["tenpxa"].ToString(), "khdm_032");
                    stt++;
                }
            }
            sql = "Create table " + xxx + ".KHDM_032_DK (MA varchar(3) , TEN Text,DK Text) with oids;ALTER TABLE " + xxx + ".khdm_032_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Trạm y tế/Tổ YHCT", "(C03>0)", "khdm_032_dk");
            m.upd_danhmuc_dk("C04", "Trạm y tế/Bác Sỹ", "(C04>0)", "khdm_032_dk");
            m.upd_danhmuc_dk("C05", "Trạm y tế/ NHS-YSSN", "(C05>0)", "khdm_032_dk");
            m.upd_danhmuc_dk("C06", "Trạm đạt chuẩn quốc gia", "(C06>0)", "khdm_032_dk");
            m.upd_danhmuc_dk("C07", "Số bản thôn có nhân viên y tế", "(C07>0)", "khdm_032_dk");

        }
        
        #endregion
        #region danh mục loại cơ sở y tế
        private void dmloaicosoyte()
        {
            string sql = "CREATE TABLE " + xxx + ".DMLOAICOSO ";
            sql += " ( ID numeric(5) default 0 , STT numeric(5) default 0 , ";
            sql += "TEN text,Constraint PK_DMLOAICOSO primary key(id,stt))with oids;ALTER TABLE " + xxx + ".DMLOAICOSO OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_dmloaics(0, 0, "Không xác định", "DMLOAICOSO");
            m.upd_dmloaics(1, 1, "Thuộc lĩnh vực y tế quản lý", "DMLOAICOSO");
            m.upd_dmloaics(2, 2, "Y tế các ngành", "DMLOAICOSO");
            m.upd_dmloaics(3, 3, "Y tế tư nhân", "DMLOAICOSO");
            m.execute_data("ALTER TABLE "+xxx+".DMCOSO ADD IDLOAICOSO numeric(5) default 0 ");
            m.execute_data("update " + xxx + ".DMCOSO set IDLOAICOSO = 0 where IDLOAICOSO is null");

        }
        #endregion
        #region ke hoach bieu 02
        private void kh_bieu02()
        {
            sql = "CREATE TABLE " + xxx + ".khbieu_02" +
                   "(" +
                     "id numeric(8) NOT NULL DEFAULT 0,ma numeric(3) NOT NULL ,ngay timestamp without time zone," +
                     "c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0," +
                     "c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0," +
                     "c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0," +
                     "c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0," +
                     "c16 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0," +
                     "ngayud timestamp without time zone DEFAULT now()," +
                     "CONSTRAINT pk_khbieu_02 PRIMARY KEY (id, ma)" +
                   ") WITH OIDS;ALTER TABLE " + xxx + ".khbieu_02 OWNER TO medisoft;";
            m.execute_data(sql);
            // danh muc
            sql = "CREATE TABLE " + xxx + ".khdm_02" +
            "(" +
              "ma numeric(7) NOT NULL ,stt varchar(3),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0," +
              "c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0," +
              "c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0," +
              "c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0," +
              "c16 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_02 PRIMARY KEY (ma)" +
            ") WITH OIDS;ALTER TABLE " + xxx + ".khdm_02 OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc(-1, "A", "Tổng số", "khdm_02");
            foreach (DataRow row in m.get_data("select ma,ten from " + xxx + ".dmcoso where tuyen in (1,2)").Tables[0].Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), " ", row["ten"].ToString(), "KHDM_02");
            }
            m.sort_stt02("KHDM_02");
            // dk
            sql = "Create Table " + xxx + ".KHDM_02_DK ";
            sql += "(";
            sql += "MA varchar(3) NOT NULL , TEN text, DK text,CONSTRAINT pk_khdm_02_dk PRIMARY KEY (ma)";
            sql += ")WITH OIDS;ALTER TABLE " + xxx + ".khdm_02_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "<TỔNG SỐ THU (Đơn vị tính : Nghìn đồng)/Tổng số>", "C03>0", "khdm_02_dk");
            m.upd_danhmuc_dk("C04", "<TỔNG SỐ THU (Đơn vị tính : Nghìn đồng)/Từ ngân sách/Trung ương>", "C04+…+C09<=C03", "khdm_02_dk");
            m.upd_danhmuc_dk("C05", "<TỔNG SỐ THU (Đơn vị tính : Nghìn đồng)/Từ ngân sách/Địa phương>", "C04+…+C09<=C03", "khdm_02_dk");
            m.upd_danhmuc_dk("C06", "<TỔNG SỐ THU (Đơn vị tính : Nghìn đồng)/Thu từ BHYT>", " C04+…+C09<=C03", "khdm_02_dk");
            m.upd_danhmuc_dk("C07", "<TỔNG SỐ THU (Đơn vị tính : Nghìn đồng)/Viện phí>", "C04+…+C09<=C03", "khdm_02_dk");
            m.upd_danhmuc_dk("C08", "<TỔNG SỐ THU (Đơn vị tính : Nghìn đồng)/Viện trợ>", "C04+…+C09<=C03", "khdm_02_dk");
            m.upd_danhmuc_dk("C09", "<TỔNG SỐ THU (Đơn vị tính : Nghìn đồng)/Khác", "C04+…+C09<=C03", "khdm_02_dk");
            m.upd_danhmuc_dk("C10", "<TỔNG SỐ CHI (Đơn vị tính : Nghìn đồng)/ Tổng Số>", "C10 > 0", "khdm_02_dk");
            m.upd_danhmuc_dk("C11", "<TỔNG SỐ CHI (Đơn vị tính : Nghìn đồng)/Tổng số chi thường xuyên/Giáo dục và đào tạo>", "C11+..+C18<= C10", "khdm_02_dk");
            m.upd_danhmuc_dk("C12", "<TỔNG SỐ CHI (Đơn vị tính : Nghìn đồng)/Tổng số chi thường xuyên/Phòng bệnh>", "C11+..+C18<= C10", "khdm_02_dk");
            m.upd_danhmuc_dk("C13", "<TỔNG SỐ CHI (Đơn vị tính : Nghìn đồng)/Tổng số chi thường xuyên/Chữa bệnh>", "C11+..+C18<= C10", "khdm_02_dk");
            m.upd_danhmuc_dk("C14", "<TỔNG SỐ CHI (Đơn vị tính : Nghìn đồng)/Tổng số chi thường xuyên/DS & KHHGD", "C11+..+C18<= C10", "khdm_02_dk");
            m.upd_danhmuc_dk("C15", "<TỔNG SỐ CHI (Đơn vị tính : Nghìn đồng)/Tổng số chi thường xuyên/Quản lý nhà nước>", "C11+..+C18<= C10", "khdm_02_dk");
            m.upd_danhmuc_dk("C16", "<TỔNG SỐ CHI (Đơn vị tính : Nghìn đồng)/Tổng số chi thường xuyên/Chương trình y tế QG>", "C11+..+C18<= C10", "khdm_02_dk");
            m.upd_danhmuc_dk("C17", "<TỔNG SỐ CHI (Đơn vị tính : Nghìn đồng)/Tổng số chi thường xuyên/Khác>", "C11+..+C18<= C10", "khdm_02_dk");
            m.upd_danhmuc_dk("C18", "<TỔNG SỐ CHI (Đơn vị tính : Nghìn đồng)/Đầu tư phát triển>", "C11+..+C118<= C10", "khdm_02_dk");

        }
        #endregion
        #region khb 03
        void kh_bieu030()
        {
            foreach (DataRow row in m.get_data("select ma,ten from " + xxx + ".dmcoso where tuyen in (1,2)").Tables[0].Rows)
            {
                m.upd_danhmuc(int.Parse(row["ma"].ToString()), "", row["ten"].ToString(), "KH_DM_03");
            }
            m.sort_danhmuc("kh_dm_03");
        }
        #endregion
        #region ke hoach bieu 01
        private void kh_bieu01()
        {
            // bieu 01
            sql = "CREATE TABLE " + xxx + ".khbieu_01" +
                     "(" +
                       "id numeric(8) NOT NULL DEFAULT 0,ma varchar(7) NOT NULL ,ngay timestamp without time zone," +
                       "c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0," +
                       "c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0," +
                       "c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,c12 numeric(7) DEFAULT 0," +
                       "c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0," +
                       "c16 numeric(7) DEFAULT 0,userid numeric(5) DEFAULT 0," +
                       "ngayud timestamp without time zone DEFAULT now()," +
                       "CONSTRAINT pk_khbieu_01 PRIMARY KEY (id, ma)" +
                     ") " +
                     "WITH OIDS;ALTER TABLE " + xxx + ".khbieu_01 OWNER TO medisoft;";
            m.execute_data(sql);
            // Danh muc
            sql = "CREATE TABLE " + xxx + ".khdm_01" +
            "(" +
              "ma varchar(7) NOT NULL ,stt varchar(2),ten text,c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0," +
              "c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0," +
              "c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0," +
              "c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,c15 numeric(7) DEFAULT 0," +
              "c16 numeric(7) DEFAULT 0,CONSTRAINT pk_khdm_01 PRIMARY KEY (ma)" +
            ") " +
            "WITH OIDS;ALTER TABLE " + xxx + ".khdm_01 OWNER TO medisoft;";
            m.execute_data(sql);
            m.execute_data("delete from " + xxx + ".khdm_01");
            m.upd_danhmuc("0", "A", "Tổng số", "khdm_01");
            int i = 1;
            foreach (DataRow r in m.get_data("Select * from "+xxx+".btdpxa where maqu='" + m.Maqu + "' and maphuongxa<>'" + m.Maqu + "00'").Tables[0].Rows)
            {
                m.upd_danhmuc(r["maphuongxa"].ToString(), i.ToString(), r["tenpxa"].ToString(), "khdm_01");
                i++;
            }
            //							
            // KE HOACH DANH MUC DIEU KIEN
            sql = "Create Table " + xxx + ".KHDM_01_DK ";
            sql += "(";
            sql += "MA varchar(3) NOT NULL , TEN text, DK text,CONSTRAINT pk_khdm_01_dk PRIMARY KEY (ma)";
            sql += ")WITH OIDS;ALTER TABLE " + xxx + ".khdm_01_dk OWNER TO medisoft;";
            m.execute_data(sql);
            m.upd_danhmuc_dk("C03", "Đơn vị hành chính/ Phân loại xã", "C03 >=0", "khdm_01_dk");
            m.upd_danhmuc_dk("C04", "Đơn vị hành chính/ Số bản thôn", "C04 >=0", "khdm_01_dk");
            m.upd_danhmuc_dk("C05", "Dân số 1/7", "C05 >=0", "khdm_01_dk");
            m.upd_danhmuc_dk("C06", "Dân số 1/7 / Trong đó nữ", "C06+C07+c08+C09 <= C05", "khdm_01_dk");
            m.upd_danhmuc_dk("C07", "Dân số 1/7/ Trong đó trẻ em <5 tuổi", "C06+C07+c08+C09 <= C05", "khdm_01_dk");
            m.upd_danhmuc_dk("C08", "Dân số 1/7/ Trong đó trẻ em <6 tuổi", "C06+C07+c08+C09 <= C05", "khdm_01_dk");
            m.upd_danhmuc_dk("C09", "Dân số 1/7/ Trong đó trẻ em <15 tuổi", "C06+C07+c08+C09 <= C05", "khdm_01_dk");
            m.upd_danhmuc_dk("C10", "Trẻ em đẻ ra sống/ Tổng số", "C10 <= C07", "khdm_01_dk");
            m.upd_danhmuc_dk("C11", "Trẻ em đẻ ra sống/ Trong đó nữ", "C11 <= C10", "khdm_01_dk");
            m.upd_danhmuc_dk("C12", "Số chết/Tổng số", "C12 <= C07", "khdm_01_dk");
            m.upd_danhmuc_dk("C13", "Số chết / Trong đó nữ", "C13 <= C12", "khdm_01_dk");
            m.upd_danhmuc_dk("C14", "Số chết/ Trong đó/ <1 tuổi/ tổng số", "C14+C16+C18 <= C12", "khdm_01_dk");
            m.upd_danhmuc_dk("C15", "Số chết/ Trong đó/ <1 tuổi/ trong đó nữ", "C15 <= C14", "khdm_01_dk");
            m.upd_danhmuc_dk("C16", "Số chết/ Trong đó/ <5 tuổi/ tổng số", "C14+c16+c18 <= c12", "khdm_01_dk");
            m.upd_danhmuc_dk("C17", "Số chết/ Trong đó/ <5 tuổi/ trong đó nữ ", "C17 <= C16", "khdm_01_dk");
            m.upd_danhmuc_dk("C18", "Số chết/ Trong đó/ Chết mẹ", "C14+c16+c18 <= c12", "khdm_01_dk");
        }
        #endregion
        private void bieu11()
        {
            m.upd_danhmuc_dk("C01", "<Tại khoa khám bệnh/Tổng số>", "(C01>=MAX(C02,C03,C04)", "DM_11_DK");
            m.upd_danhmuc_dk("C02", "<Tại khoa khám bệnh/Trong đó Nữ>", "(C02<=C01)", "DM_11_DK");
            m.upd_danhmuc_dk("C03", "<Tại khoa khám bệnh/Trong đó TE<15 tuổi>", "(C03<=C01)", "DM_11_DK");
            m.upd_danhmuc_dk("C04", "<Tại khoa khám bệnh/trong đó Số tử vong>", "(C04<=C01)", "DM_11_DK");
            m.upd_danhmuc_dk("C05", "<Điều trị nội trú/Tổng số/Mắc/Tổng số  >", "(C05>=MAX(C07,C09,C11))", "DM_11_DK");
            m.upd_danhmuc_dk("C06", "<Điều trị nội trú/Tổng số/Mắc / trong đó Nữ >", "(C06<= C05)", "DM_11_DK");
            m.upd_danhmuc_dk("C07", "<Điều trị nội trú/Tổng số/Số tử vong/ Tổng số  >", "(C07<=C05)", "DM_11_DK");
            m.upd_danhmuc_dk("C08", "<Điều trị nội trú/Tổng số/Số tử vong / trong đó Nữ >", "(C08<=C07)", "DM_11_DK");
            m.upd_danhmuc_dk("C09", "<Điều trị nội trú/Trong đó TE<15 tuổi /Mắc/ Tổng số >", "(C09<=C05)", "DM_11_DK");
            m.upd_danhmuc_dk("C10", "<Điều trị nội trú/Trong đó TE<15 tuổi /Mắc/ TE<5 tuổi >", "(C10<=C09)", "DM_11_DK");
            m.upd_danhmuc_dk("C11", "<Điều trị nội trú/Trong đó TE<15 tuổi /Số tử vong/ Tổng số >", "(C11<=C09 AND C11<=C07)", "DM_11_DK");
            m.upd_danhmuc_dk("C12", "<Điều trị nội trú/Trong đó TE<15 tuổi /Số tử vong/ <5 tuổi >", "(C12<=C11)", "DM_11_DK");
        }
        private void kh_bieu15()
        {
            sql = "CREATE TABLE " + xxx + ".khbieu_15" +
                     "(" +
                       "id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone," +
                       "c01 numeric(7) DEFAULT 0,c02 numeric(7) DEFAULT 0,c03 numeric(7) DEFAULT 0,c04 numeric(7) DEFAULT 0," +
                       "c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0,c08 numeric(7) DEFAULT 0," +
                       "c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0,C12 decimal(7) default 0," +
                       "userid numeric(5) DEFAULT 0," +
                       "ngayud timestamp without time zone DEFAULT now()," +
                       "CONSTRAINT pk_khbieu_15 PRIMARY KEY (id, ma)" +
                     ") " +
                     "WITH OIDS;ALTER TABLE " + xxx + ".khbieu_15 OWNER TO medisoft;";
            m.execute_data(sql);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region ThanhCuong
        private void dt_bieu11()
        {
            sql = "CREATE TABLE " + xxx + ".dtbieu_11" +
                     "(" +
                       "id numeric(8) NOT NULL DEFAULT 0,ma numeric(5) NOT NULL ,ngay timestamp without time zone," +
                       "c04 numeric(7) DEFAULT 0,c05 numeric(7) DEFAULT 0,c06 numeric(7) DEFAULT 0,c07 numeric(7) DEFAULT 0," +
                       "c08 numeric(7) DEFAULT 0,c09 numeric(7) DEFAULT 0,c10 numeric(7) DEFAULT 0,c11 numeric(7) DEFAULT 0," +
                       "c12 numeric(7) DEFAULT 0,c13 numeric(7) DEFAULT 0,c14 numeric(7) DEFAULT 0,C15 decimal(7) default 0," +
                       "userid numeric(5) DEFAULT 0," +
                       "ngayud timestamp without time zone DEFAULT now()," +
                       "CONSTRAINT pk_dtbieu_11 PRIMARY KEY (id, ma)" +
                     ") " +
                     "WITH OIDS;ALTER TABLE " + xxx + ".dtbieu_11 OWNER TO medisoft;";
            m.execute_data(sql);

        }
        #endregion
    }
}