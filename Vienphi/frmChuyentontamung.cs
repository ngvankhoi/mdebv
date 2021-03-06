using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmChuyentontamung : Form
    {
        private LibVP.AccessData m_v ;
        private Language lanque = new Language();
        public frmChuyentontamung( LibVP.AccessData m_vv)
        {
            InitializeComponent();
            m_v = m_vv;
        }

        private void frmChuyentontamung_Load(object sender, EventArgs e)
        {
            if (DateTime.Now.Month == 1)
            {
                txtTuYYYY.Value = DateTime.Now.Year - 1;
                txtTuMM.Value = 12;
            }
            else
            {
                txtTuYYYY.Value = DateTime.Now.Year;
                txtTuMM.Value = DateTime.Now.Month - 1;
            }
            txtDenYYYY.Value = txtTuYYYY.Value;
            txtDenMM.Value = DateTime.Now.Month;
        }

        private bool kiemTra()//gam 12/09/2011
        {
            if (txtTuYYYY.Value > txtDenYYYY.Value)
            {
                MessageBox.Show(lanque.Change_language_MessageText("Năm chuyển tồn không hợp lệ."));
                txtTuYYYY.Focus();
                return false;
            }
            else if (txtTuMM.Value >= txtDenMM.Value && txtTuYYYY.Value == txtDenYYYY.Value)//Thuy 04.01.2012
            {
                MessageBox.Show(lanque.Change_language_MessageText("Tháng chuyển tồn không hợp lệ."));
                txtTuMM.Focus();
                return false;
            }
            return true;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            // chuyển tồn từ tháng được chọn sang tháng hiện tại
           // string angay1 = txtTN.Text;
            //string athang1 = angay1.Substring(3, 2);
           // string anam = m_v.s_curyyyy;
            if (!kiemTra()) return;
            string ammyy1 = txtTuMM.Value.ToString().PadLeft(2,'0') + txtTuYYYY.Value.ToString().Substring(2, 2);
            string ammyy = txtDenMM.Value.ToString().PadLeft(2, '0') + txtDenYYYY.Value.ToString().Substring(2, 2);
            DataSet ds = new DataSet();
            string sql = "", sql1 = "";

            Object ob = MessageBox.Show("Bạn có muốn chuyển tồn tháng " + txtTuMM.Value.ToString() + " năm " + txtTuYYYY.Value.ToString(), LibVP.AccessData.Msg, MessageBoxButtons.YesNo);
            if ((txtTuMM.Value == txtDenMM.Value) && (txtDenYYYY.Value == txtTuYYYY.Value))
            {
                MessageBox.Show("Chuyển số liệu thành công !");
            }
            else
            {

                if (ob.ToString() == "Yes")
                {
                    if (m_v.bMmyy(ammyy1))//gam 12/09/2011
                    {
                        sql1 = "select * from medibv" + ammyy1 + ".v_tontamung";
                    }
                    else { MessageBox.Show(lanque.Change_language_MessageText("Số liệu tháng " + ammyy1.Substring(0, 2) + " năm "+ammyy1.Substring(2,2)+" chưa tạo số liệu")); return; }
                    try
                    {
                        ds = m_v.get_data(sql1);
                    }
                    catch { ds = null; }
                    if (!m_v.bMmyy(ammyy))//gam 12/09/2011
                    {
                        MessageBox.Show(lanque.Change_language_MessageText("Số liệu tháng " + ammyy.Substring(0, 2) + " năm " + ammyy.Substring(2, 2) + " chưa tạo số liệu")); return;
                    }
                   
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        // kiểm tra nếu tháng này không có bảng v_tontamung thì insert từ bảng v_tamung

                        sql = "insert into medibv" + ammyy + ".v_tontamung (id,mabn,mavaovien,maql,idkhoa,quyenso,sobienlai,ngay,loai,makp,madoituong,sotien,ketoan,done,lanin,loaibn,idttrv,datru,userid,ngayud,ngaytra) ";
                        sql += "select id,mabn,mavaovien,maql,idkhoa,quyenso,sobienlai,ngay,loai,makp,madoituong,sotien,ketoan,done,lanin,loaibn,idttrv,datru,userid,ngayud,ngaytra from medibv" + ammyy1 + ".v_tamung a where a.done=0 and a.id not in (select id from medibv" + ammyy + ".v_tontamung) ";


                    }
                    else
                    {
                        // nếu có bảng v_tontamung nhưng không có dữ liệu thì insert từ bảng v_tamung
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            sql = "insert into medibv" + ammyy + ".v_tontamung (id,mabn,mavaovien,maql,idkhoa,quyenso,sobienlai,ngay,loai,makp,madoituong,sotien,ketoan,done,lanin,loaibn,idttrv,datru,userid,ngayud,ngaytra) ";
                            sql += "select id,mabn,mavaovien,maql,idkhoa,quyenso,sobienlai,ngay,loai,makp,madoituong,sotien,ketoan,done,lanin,loaibn,idttrv,datru,userid,ngayud,ngaytra  from medibv" + ammyy1 + ".v_tamung a where a.done=0 and a.id not in (select id from medibv" + ammyy + ".v_tontamung) ";
                        }
                        // bảng v_tontamung có data thì insert từ v_tontamung và v_tamung
                        else
                        {

                            sql = "insert into medibv" + ammyy + ".v_tontamung (id,mabn,mavaovien,maql,idkhoa,quyenso,sobienlai,ngay,loai,makp,madoituong,sotien,ketoan,done,lanin,loaibn,idttrv,datru,userid,ngayud,ngaytra) ";
                            sql += "select id,mabn,mavaovien,maql,idkhoa,quyenso,sobienlai,ngay,loai,makp,madoituong,sotien,ketoan,done,lanin,loaibn,idttrv,datru,userid,ngayud,ngaytra  from medibv" + ammyy1 + ".v_tontamung a where a.done=0 and a.id not in (select id from medibv" + ammyy + ".v_tontamung) ";
                            sql += "union all select id,mabn,mavaovien,maql,idkhoa,quyenso,sobienlai,ngay,loai,makp,madoituong,sotien,ketoan,done,lanin,loaibn,idttrv,datru,userid,ngayud,ngaytra  from medibv" + ammyy1 + ".v_tamung a where a.done=0 and a.id not in (select id from medibv" + ammyy + ".v_tontamung) ";
                        }
                    }
                    try
                    {
                        m_v.execute_data(sql);
                    }
                    catch { MessageBox.Show("Chuyển số liệu không thành công !"); }
                    MessageBox.Show("Chuyển số liệu thành công !");
                }
                else
                {
                    //MessageBox.Show("Yeu cau khong chuyen da chap nhan");
                }
            }// end if((txtTuMM.Value == txtDenMM.Value) && (txtDenYYYY.Value == txtTuYYYY.Value))
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}