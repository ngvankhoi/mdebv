using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class frmThongso : Form
    {
        DataSet ds;
        public frmThongso()
        {
            InitializeComponent();
        }

        private void frmThongso_Load(object sender, EventArgs e)
        {
            
            loadthongso();
            load_tooltip();//
        }

        /// <summary>
        /// Load thong tin da duoc khai bao
        /// </summary>
        private void loadthongso()
        {
            try
            {
                using (DAL.Accessdata acc = new DAL.Accessdata())
                {
                    int i_IDChiNhanh = acc.i_ChiNhanhHienTai;
                    bool bTrungtam = acc.ChiNhanhTrungTam;
                    if (bTrungtam)
                    {
                        t9.Enabled = t7.Enabled = t8.Enabled = true;
                    }
                    else
                    {
                        t9.Enabled =t7.Enabled=t8.Enabled = false;
                        t9.Checked = false;
                    }
                    //
                    ds = acc.get_data("select * from " + acc.User + ".syn_thongso");
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        switch (row["id"].ToString())
                        {
                            case "1":// thời gian đồng bộ liên tục
                                t1.Value = decimal.Parse(row["giatri"].ToString());
                                break;
                            case "2":// số máy sử dụng tối đa
                                t2.Value = decimal.Parse(row["giatri"].ToString());
                                break;
                            case "3":// khởi động cùng windown
                                t3.Checked = row["giatri"].ToString() == "1";
                                break;
                            case "4":// giờ đồng bộ cuối ngay
                                t4.Text = row["giatri"].ToString();
                                break;
                            case "5":// phút đồng bộ cuối ngày.
                                t5.Text = row["giatri"].ToString();
                                break;
                            case "6":// khoảng cách ngày đồng bộ.
                                t6.Value = decimal.Parse(row["giatri"].ToString());
                                break;
                            case "7":// Gio gui mail tu dong
                                t7.Text = row["giatri"].ToString();
                                break;
                            case "8":// Phut gui mail tu dong
                                t8.Text = row["giatri"].ToString();
                                break;
                            case "9":// Co gui mail tu dong khong
                                t9.Checked = row["giatri"].ToString() == "1";
                                break;
                            case "10":
                                try
                                {
                                    t10.Value = decimal.Parse(row["giatri"].ToString());
                                }
                                catch { t10.Value = 10; }
                                break;
                            case "11":// Co gui mail tu dong khong
                                t11.Checked = row["giatri"].ToString() == "1";
                                break;
                            case "12":// Co gui mail tu dong khong
                                t12.Checked = row["giatri"].ToString() == "1";
                                break;


                            case "17":// dong bo hinh BN
                                t17.Checked = row["giatri"].ToString() == "1";
                                break;
                            case "13":// Gio dong bo hinh BN
                                t13.Text = row["giatri"].ToString();
                                break;
                            case "14":// Phut dong bo hinh BN
                                t14.Text = row["giatri"].ToString();
                                break;
                            case "18":// dong bo hinh cdha
                                t18.Checked = row["giatri"].ToString() == "1";
                                break;
                            case "15":// Gio dong bo hinh cdha
                                t15.Text = row["giatri"].ToString();
                                break;
                            case "16":// Phut dong bo hinh cdha
                                t16.Text = row["giatri"].ToString();
                                break;
                            case "19":// dong bo hinh cdha
                                t19.Checked = row["giatri"].ToString() == "1";
                                break;
                            case "20":// Gio dong bo hinh cdha
                                t20.Text = row["giatri"].ToString();
                                break;
                            case "21":// Phut dong bo hinh cdha
                                t21.Text = row["giatri"].ToString();
                                break;
                            case "22":// dong bo hinh cdha
                                t22.Checked = row["giatri"].ToString() == "1";
                                break;
                            default: break;
                        }
                    }

                }
                
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Synchronize");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                using (DAL.Accessdata acc = new DAL.Accessdata())
                {
                    acc.upd_thongso(1, t1.Value.ToString());
                    acc.upd_thongso(2, t2.Value.ToString());
                    acc.upd_thongso(3, (t3.Checked ? "1" : "0"));
                    acc.upd_thongso(4, t4.Text.PadLeft(2, '0'));
                    acc.upd_thongso(5, t5.Text.PadLeft(2, '0'));
                    acc.upd_thongso(6, t6.Value.ToString());
                    acc.upd_thongso(7, t7.Text.ToString());
                    acc.upd_thongso(8, t8.Text.ToString());
                    acc.upd_thongso(9, (t9.Checked ? "1" : "0"));
                    acc.upd_thongso(10, t10.Value.ToString());
                    acc.upd_thongso(11, (t11.Checked ? "1" : "0"));
                    acc.upd_thongso(12, (t12.Checked ? "1" : "0"));

                    acc.upd_thongso(17, (t17.Checked ? "1" : "0"));//dong bo Hinh BN
                    acc.upd_thongso(13, t13.Text.ToString());
                    acc.upd_thongso(14, t14.Text.ToString());
                    

                    
                    acc.upd_thongso(18, (t18.Checked ? "1" : "0"));//dong bo Hinh CDHA
                    acc.upd_thongso(15, t15.Text.ToString());
                    acc.upd_thongso(16, t16.Text.ToString());

                    acc.upd_thongso(19, (t19.Checked ? "1" : "0"));//dong bo Hinh chung tu
                    acc.upd_thongso(20, t20.Text.ToString());
                    acc.upd_thongso(21, t21.Text.ToString());

                    acc.upd_thongso(22, (t22.Checked ? "1" : "0"));//dong bo Hinh chung tu
                }
            }
            catch { }
            Cursor = Cursors.Default;
            MessageBox.Show("Đã cập nhật xong.");
        }

        private void numtgian_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void c1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void chktgian_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void numSomay_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtHH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void load_tooltip()
        {
            ToolTip tip = new ToolTip();
            DataSet dstooltip = new DataSet();
            foreach (Control c in this.Controls)
            {
                switch (c.GetType().ToString())
                {
                    case "System.Windows.Forms.Panel":
                    case "System.Windows.Forms.GroupBox":
                        foreach (Control c2 in c.Controls)
                        {
                            tip.SetToolTip(c2, "[" + c2.Name + "] " + c2.Text);
                        }
                        break;
                    case "System.Windows.Forms.TabControl":
                        TabControl tabclt = (TabControl)c;
                        foreach (TabPage tab in tabclt.TabPages)
                        {
                            foreach (Control c3 in tab.Controls)
                            {
                                tip.SetToolTip(c3, "[" + c3.Name + "] " + c3.Text);
                            }
                        }
                        break;
                    default:

                        tip.SetToolTip(c, "[" + c.Name + "] " + c.Text);
                        break;
                }
            }
        }
    }
}