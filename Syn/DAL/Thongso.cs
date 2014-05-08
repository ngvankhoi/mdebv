using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DAL
{
    public class Thongso
    {
        private Accessdata a = new Accessdata();
        string sql = "";
        public Thongso()
        {
            sql = "select * from "+a.User+".syn_thongso where 1=0";
            try
            {
              DataTable temp=  a.get_data(sql).Tables[0];
            }
            catch
            {
                sql = "CREATE TABLE "+a.User+".syn_thongso(ten varchar2(100), giatri varchar2(3))";
                a.execute_data(sql);
            }
        }
        /// <summary>
        /// chuong trinh tu dong cap nhat sau
        /// </summary>
        /// <returns></returns>
        public int ThoigianTudongCapnhat
        {
            get
            {
                try
                {
                    return int.Parse(a.get_data("select giatri from " + a.User + ".syn_thongso where ten='t1'").Tables[0].Rows[0]["giatri"].ToString());
                }
                catch
                {
                    return 5;
                }
            }
            set 
            {
                a.upd_thongso("t1", value.ToString());
            }
        }

        public int Giobatdau
        {
            get
            {
                try
                {
                    return int.Parse(a.get_data("select giatri from " + a.User + ".syn_thongso where ten='t2'").Tables[0].Rows[0]["giatri"].ToString());
                }
                catch
                {
                    return 18;
                }
            }
            set
            {
                a.upd_thongso("t2", value.ToString());
            }
        }

        public int Phutbatdau
        {
            get
            {
                try
                {
                    return int.Parse(a.get_data("select giatri from " + a.User + ".syn_thongso where ten='t3'").Tables[0].Rows[0]["giatri"].ToString());
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                a.upd_thongso("t3", value.ToString());
            }
        }

        public int Khoang_cach_ngay_dong_bo
        {
            get
            {
                try
                {
                    return int.Parse(a.get_data("select giatri from " + a.User + ".syn_thongso where ten='t4'").Tables[0].Rows[0]["giatri"].ToString());
                }
                catch
                {
                    return 3;
                }
            }
            set
            {
                a.upd_thongso("t4", value.ToString());
            }
        }
    }
}
