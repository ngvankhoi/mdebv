using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LTCControl
{
    public partial class LTCDateTimePicker : UserControl
    {
        public LTCDateTimePicker()
        {
            InitializeComponent();
            //f_load_default();
        }
        private void f_load_default()
        {
            try
            {
                txtQuy.Minimum = 1;
                txtQuy.Maximum = 4;
                txtQuy.Value = f_get_quy(DateTime.Now);

                txtNam.Minimum = decimal.Parse(DateTime.Now.Year.ToString()) - 20;
                txtNam.Maximum = decimal.Parse(DateTime.Now.Year.ToString()) + 1;
                txtNam.Update();
                txtNam.Refresh();
                txtNam.Value = decimal.Parse(DateTime.Now.Year.ToString());

                txtTuthang.Minimum = 1;
                txtTuthang.Maximum = 12;
                txtTuthang.Value = (decimal) (DateTime.Now.Month);

                txtDenthang.Minimum = 1;
                txtDenthang.Maximum = 12;
                txtDenthang.Value = DateTime.Now.Month;

                txtTunam.Minimum = DateTime.Now.Year - 20;
                txtTunam.Maximum = DateTime.Now.Year + 1;
                txtTunam.Value = DateTime.Now.Year;

                txtDennam.Minimum = DateTime.Now.Year - 20;
                txtDennam.Maximum = DateTime.Now.Year + 1;
                txtDennam.Value = DateTime.Now.Year;

                txtTungay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                txtDenngay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                cbLuyke.SelectedIndex = 3;


            }
            catch(Exception ex)
            {
            }
        }

        private decimal f_get_quy(DateTime v_dt)
        {
            decimal aquy = 1;
            switch (v_dt.Month.ToString())
            {
                case "1":
                case "2":
                case "3":
                    aquy = 1;
                    break;
                case "4":
                case "5":
                case "6":
                    aquy = 2;
                    break;
                case "7":
                case "8":
                case "9":
                    aquy = 3;
                    break;
                case "10":
                case "11":
                case "12":
                    aquy = 4;
                    break;
                default:
                    aquy = 1;
                    break;
            }
            return aquy;
        }
        private void f_tinhngay_quy()
        {
            try
            {
                if (txtQuy.Value.ToString() == "")
                {
                    txtQuy.Value = 1;
                }
                switch (txtQuy.Value.ToString())
                {
                    case "1":
                        txtTungay.Value = new DateTime(int.Parse(txtNam.Value.ToString()), 1, 1);
                        txtDenngay.Value = new DateTime(int.Parse(txtNam.Value.ToString()), 3, DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()),3));
                        break;
                    case "2":
                        txtTungay.Value = new DateTime(int.Parse(txtNam.Value.ToString()), 4, 1);
                        txtDenngay.Value = new DateTime(int.Parse(txtNam.Value.ToString()), 6, DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()), 6));
                        break;
                    case "3":
                        txtTungay.Value = new DateTime(int.Parse(txtNam.Value.ToString()), 7, 1);
                        txtDenngay.Value = new DateTime(int.Parse(txtNam.Value.ToString()), 9, DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()), 9));
                        break;
                    case "4":
                        txtTungay.Value = new DateTime(int.Parse(txtNam.Value.ToString()), 10, 1);
                        txtDenngay.Value = new DateTime(int.Parse(txtNam.Value.ToString()), 12, DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()), 12));
                        break;
                }
            }
            catch
            {
            }
            if (txtDenngay.Value < txtTungay.Value)
            {
                txtDenngay.Value = txtTungay.Value;
            }
            txtTuthang.Value = decimal.Parse(txtTungay.Value.Month.ToString());
            txtDenthang.Value = decimal.Parse(txtDenngay.Value.Month.ToString());

            f_tinhngay_luyke();
        }
        private void f_tinhngay_thang(string v_index)
        {
            try
            {
                txtTungay.Value = new DateTime(int.Parse(txtTunam.Value.ToString()), int.Parse(txtTuthang.Value.ToString()), 1);
                txtDenngay.Value = new DateTime(int.Parse(txtDennam.Value.ToString()), int.Parse(txtDenthang.Value.ToString()), DateTime.DaysInMonth(int.Parse(txtDennam.Value.ToString()),int.Parse(txtDenthang.Value.ToString())));
            }
            catch
            {
            }
            if (txtDenngay.Value < txtTungay.Value)
            {
                if (v_index == "1")
                {
                    txtTungay.Value = txtDenngay.Value;
                }
                else
                {
                    txtDenngay.Value = txtTungay.Value;
                }
            } 
            f_tinhngay_ngay();
        }
        private void f_tinhngay_ngay()
        {
            try
            {
                if (txtDenngay.Value < txtTungay.Value)
                {
                    txtDenngay.Value = txtTungay.Value;
                }
                txtTuthang.Value = decimal.Parse(txtTungay.Value.Month.ToString());
                txtTunam.Value = decimal.Parse(txtTungay.Value.Year.ToString());
                
                txtDenthang.Value = decimal.Parse(txtDenngay.Value.Month.ToString());
                txtDennam.Value = decimal.Parse(txtDenngay.Value.Year.ToString());
                
                txtQuy.Value = decimal.Parse(f_get_quy(txtDenngay.Value).ToString());
                txtNam.Value = decimal.Parse(txtDenngay.Value.Year.ToString());
            }
            catch
            {
            }
            f_tinhngay_luyke();
        }
        private void f_tinhngay_luyke()
        {
            try
            {
                string atn = "";
                switch (cbLuyke.SelectedIndex.ToString())
                {
                    case "0"://Nam
                        atn = "01/01/" + txtDenngay.Value.Year.ToString();
                        break;
                    case "1"://Quy
                        switch (f_get_quy(txtDenngay.Value).ToString())
                        {
                            case "1":
                                atn = "01/01/" + txtDenngay.Value.Year.ToString();
                                break;
                            case "2":
                                atn = "01/04/" + txtDenngay.Value.Year.ToString();
                                break;
                            case "3":
                                atn = "01/07/" + txtDenngay.Value.Year.ToString();
                                break;
                            case "4":
                                atn = "01/09/" + txtDenngay.Value.Year.ToString();
                                break;
                        }
                        break;
                    case "2"://Thang
                        atn = "01/" + txtDenngay.Value.Month + "/" + txtDenngay.Value.Year.ToString();
                        break;
                    default://Khong tính
                        atn = "01/" + txtDenngay.Value.Month + "/" + txtDenngay.Value.Year.ToString();
                        break;
                }
                if (cbLuyke.SelectedIndex == 3)
                {
                    txtLuyke.Text = "";
                }
                else
                {
                    txtLuyke.Text = atn + " - " + txtDenngay.Text;
                }
            }
            catch
            {
            }
        }


        private void LTCDateTimePicker_Load(object sender, EventArgs e)
        {
            f_load_default();
            f_tinhngay_luyke();
        }

        private void cbLuyke_Validated(object sender, EventArgs e)
        {
            f_tinhngay_luyke();
        }

        private void LTCDateTimePicker_Leave(object sender, EventArgs e)
        {
            f_tinhngay_luyke();
        }

        private void txtControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void txtControl_Enter(object sender, EventArgs e)
        {
            try
            {
                Control ac = (Control)(sender);
                ac.BackColor = Color.Yellow;
            }
            catch
            {
            }
        }
        private void txtControl_Leave(object sender, EventArgs e)
        {
            try
            {
                Control ac = (Control)(sender);
                ac.BackColor = Color.White;
            }
            catch
            {
            }
        }
        private void txtQuy_Validated(object sender, EventArgs e)
        {
            f_tinhngay_quy();
        }

        private void txtTuthang_Validated(object sender, EventArgs e)
        {
            f_tinhngay_thang("0");
        }
        private void txtDenthang_Validated(object sender, EventArgs e)
        {
            f_tinhngay_thang("1");
        }
        private void txtTungay_Validated(object sender, EventArgs e)
        {
            f_tinhngay_ngay();
        }
        private void txtTungay_ValueChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txtTungay)
            {
                if (txtTungay.Value > txtDenngay.Value)
                {
                    txtDenngay.Value = txtTungay.Value;
                }
            }
        }
        private void txtDenngay_ValueChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txtDenngay)
            {
                if (txtTungay.Value > txtDenngay.Value)
                {
                    txtTungay.Value = txtDenngay.Value;
                }
            }
        }
        private void txtQuy_ValueChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txtQuy)
            {
                f_tinhngay_quy();
            }
        }
        private void txtNam_ValueChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txtNam && txtNam != null)
            {
                f_tinhngay_quy();
            }
        }
        private void cbLuyke_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_tinhngay_luyke();
        }

        private void txtDenthang_Click(object sender, EventArgs e)
        {
            txtDenthang_Validated(null, null);
        }

        private void txtDennam_Click(object sender, EventArgs e)
        {
            txtDenthang_Validated(null, null);
        }

        private void txtTuthang_Click(object sender, EventArgs e)
        {
            txtTuthang_Validated(null, null);
        }

        private void txtTunam_Click(object sender, EventArgs e)
        {
            txtTuthang_Validated(null, null);
        }
    }
}
