using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmMiendoituong : Form
    {
        private Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v = LibVP.AccessData.GetImplement();
        
        private string v_userid = "";        
        private TableLayoutPanel m_table;

        public frmMiendoituong(string s_userid)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);


            v_userid = s_userid;
        }          
        private void frmMiendoituong_Load(object sender, EventArgs e)
        {
            txtSotien.Text = "0";
            txtSotienmien.Text = "0";

            f_Load_PChitiet();
            cbDoituong.DisplayMember = "doituong";
            cbDoituong.ValueMember = "madoituong";
            cbDoituong.DataSource = m_v.get_data("select madoituong,doituong from medibv.doituong order by madoituong").Tables[0];
        }

        private void f_Load_PChitiet()
        {
            try
            {
                pCT.Controls.Clear();
                Label alb;
                Label albphantram;
                TextBox atb;

                m_table = new TableLayoutPanel();
                m_table.Name = "tableLayoutPanel_01";
                m_table.Text = "?";
                m_table.AutoScroll = true;
                m_table.BorderStyle = BorderStyle.None;
                m_table.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
                m_table.BackColor = Color.Honeydew;

                m_table.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                m_table.AutoSize = true;

                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));

                DataSet ads = m_v.get_data("select a.id,a.viettat,a.ten from medibv.v_loaivp a order by a.ten");
                int ai = 0, arow = 0, acol = 0;
                foreach (DataRow r in ads.Tables[0].Rows)
                {
                    ai++;
                    m_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));

                    alb = new Label();
                    alb.Name = "lbma_" + r["id"].ToString();
                    alb.Text = (r["ten"].ToString().Length > 50 ? r["viettat"].ToString().Trim() : r["ten"].ToString().Trim()) + ":";
                    toolTip1.SetToolTip(alb, r["ten"].ToString().Trim());
                    alb.AutoSize = true;
                    alb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    alb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
                    alb.TextAlign = ContentAlignment.MiddleRight;
                    m_table.Controls.Add(alb, acol, arow);

                    atb = new TextBox();
                    atb.Name = "tbma_" + r["id"].ToString();
                    atb.Text = "";
                    atb.BackColor = Color.White;
                    atb.Width = 70;

                    atb.Leave += new System.EventHandler(this.f_Control_Leave);
                    atb.Enter += new System.EventHandler(this.f_Control_Enter);
                    atb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_Control_KeyDown);
                    atb.Validated += new System.EventHandler(this.txt_Validated);
                    atb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.f_Control_Keypress);

                    atb.ReadOnly = false;
                    atb.TextAlign = HorizontalAlignment.Right;
                    m_table.Controls.Add(atb, acol + 1, arow);

                    albphantram = new Label();
                    albphantram.Text = "%";
                    albphantram.AutoSize = true;
                    albphantram.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));                   
                    albphantram.TextAlign = ContentAlignment.MiddleCenter;
                    m_table.Controls.Add(albphantram, acol +2, arow);

                    arow++;
                }
                m_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
                alb = new Label();
                alb.Name = "_blank";
                alb.Text = "";
                alb.AutoSize = true;
                alb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                alb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom)));
                alb.TextAlign = ContentAlignment.MiddleRight;
                m_table.Controls.Add(alb, 0, ai);

                pCT.Controls.Add(m_table);
                m_table.Dock = DockStyle.Fill;
                m_table.BringToFront();
            }
            catch
            {
            }
            finally
            {
            }
        }
        private void f_Control_Keypress(object sender, System.EventArgs e)
        {
            foreach (Control c in m_table.Controls)
            {
                decimal asotien = 0;
                if (c.Name.IndexOf("tbma_") == 0)
                {
                    try
                    {
                        asotien = decimal.Parse(c.Text.Replace(",", ""));
                    }
                    catch
                    {
                        asotien = 0;
                    }
                    if (asotien < 0 || asotien > 100)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Vui lòng nhập từ 0->100"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        public void f_Control_Enter(object sender, System.EventArgs e)
        {
            try
            {
                System.Windows.Forms.Control c = (System.Windows.Forms.Control)(sender);
                c.BackColor = Color.LightYellow;

            }
            catch
            {
            }
        }
        public void f_Control_Leave(object sender, System.EventArgs e)
        {
            try
            {
                System.Windows.Forms.Control c = (System.Windows.Forms.Control)(sender);
                c.BackColor = Color.White;
            }
            catch
            {
            }
        }
        private void f_Control_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TextBox atb = (TextBox)(sender);
                    if (atb == m_table.Controls[m_table.Controls.Count - 2])
                    {
                        butLuu.Focus();
                    }
                    else
                    {
                        SendKeys.Send("{Tab}");
                    }
                }
            }
            catch
            {
            }
        }
        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txt_Validated(object sender, EventArgs e)
        {
            f_Tinhtien();
        }  
        private void f_Tinhtien()
        {
            try
            {
                decimal asotien = 0, asotienct = 0;
                foreach (Control c in m_table.Controls)
                {
                    if (c.Name.IndexOf("tbma_") == 0)
                    {
                        try
                        {
                            asotienct = decimal.Parse(c.Text.Replace(",", ""));
                        }
                        catch
                        {
                            asotienct = 0;
                        }
                        if (asotienct < 0)
                        {
                            asotienct = 0;
                        }
                        c.Text = asotienct.ToString("###,###,###");
                        asotien += asotienct;
                    }
                }
                txtSotien.Text = asotien.ToString("###,###,##0");
            }
            catch
            {
                txtSotien.Text = "0";
            }
        }
    
        private void f_Moi()
        {
            f_Clear_pTonghop();
            txtSotien.Text = "0";
            txtSotienmien.Text = "0";
        }
        private void f_Clear_pTonghop()
        {
            try
            {
                foreach (Control c in m_table.Controls)
                {
                    if (c.Name.IndexOf("tbma_") == 0)
                    {
                        c.Text = "";
                        c.BackColor = (c.Text != "") ? Color.LightYellow : Color.White;
                    }
                }
            }
            catch
            {
            }
        }

        private void butLuu_Click(object sender, EventArgs e)
        {            
            m_v.execute_data("delete from medibv.v_miendtloaivp where madoituong=" + cbDoituong.SelectedValue.ToString());
            decimal asotienct = 0,asotienmien=0;
            foreach (Control c in m_table.Controls)
            {
                if (c.Name.IndexOf("tbma_") == 0)
                {
                    try
                    {
                        asotienct = decimal.Parse(c.Text.Replace(",", ""));
                    }
                    catch
                    {
                        asotienct = 0;
                    }
                    if (asotienct > 0)
                    {
                        m_v.upd_v_miendtloaivp(decimal.Parse(cbDoituong.SelectedValue.ToString()), decimal.Parse(c.Name.Replace("tbma_", "")), asotienct, asotienmien, decimal.Parse(v_userid));
                    }
                }
            }
            MessageBox.Show(lan.Change_language_MessageText("Lưu thành công"), m_v.s_AppName);
        }

        private void cbDoituong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveControl == cbDoituong)
            {
                f_Moi();
                f_Load_Mien();
            }
        }
        private void f_Load_Mien()
        {
           
            DataSet ads_ct = new DataSet();
            ads_ct = m_v.get_data("select * from medibv.v_miendtloaivp where madoituong=" + cbDoituong.SelectedValue.ToString() + "");
            decimal asotienct = 0, atongtien = 0;
            foreach (DataRow r in ads_ct.Tables[0].Rows)
            {
                atongtien += decimal.Parse(ads_ct.Tables[0].Rows[0]["tyle"].ToString());
            }
            txtSotien.Text = atongtien.ToString("###,###,###");
            foreach (Control c in m_table.Controls)
            {
                if (c.Name.IndexOf("tbma_") == 0)
                {
                    try
                    {
                        asotienct = decimal.Parse(ads_ct.Tables[0].Select("idloaivp=" + c.Name.Replace("tbma_", ""))[0]["tyle"].ToString());
                    }
                    catch
                    {
                        asotienct = 0;
                    }
                    c.Text = asotienct.ToString("###,###,###");
                    TextBox atb = (TextBox)(c);                  
                }
            }

        }
        private void butBoqua_Click(object sender, EventArgs e)
        {
            f_Moi();
        }
    }
}