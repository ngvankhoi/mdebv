using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibVP;

namespace Vienphi
{
    public partial class frmGiatrongoinhom : Form
    {
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private AccessData m_v;

        private DataTable dt = new DataTable();
        private DataTable dtgia = new DataTable();
        private DataTable dtnhom = new DataTable();

        private string v_userid = "", sql,s_nhom;       
        
        private decimal l_id;
        private decimal st;
        private TableLayoutPanel m_table;

        public frmGiatrongoinhom(LibVP.AccessData v_v,string s_userid)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m_v = v_v;
            v_userid = s_userid;
        }

        private void frmGiatrongoinhom_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            sql = "select b.id_nhom as id,a.ten,a.trongoi,a.matat as ma from medibv.v_nhomvp a,medibv.v_loaivp b where a.ma=b.id_nhom";            
            sql += " and a.trongoi is not null";
            sql += " group by b.id_nhom,a.ten,a.trongoi,a.matat";
            dt = m_v.get_data(sql).Tables[0];
            tennhom.DisplayMember = "TEN";
            tennhom.ValueMember = "ID";
            tennhom.DataSource = dt;
            if (tennhom.Items.Count > 0)
            {
                tennhom.SelectedIndex = 0;
                matat.Text = dt.Rows[tennhom.SelectedIndex]["ma"].ToString();
            }
            bhyt.DisplayMember = "CHITRA";
            bhyt.ValueMember = "CHITRA";
            bhyt.DataSource = m_v.get_data("select * from medibv.d_dmbhyt order by stt").Tables[0];            
            load_gia();
            butBoqua_Click(null, null);
        }

        private void load_gia()
        {
            if (tennhom.SelectedIndex == -1) return;
            matat.Text = dt.Rows[tennhom.SelectedIndex]["ma"].ToString();
            sql = "select a.id,a.stt,a.ma,a.ten,a.gia_th,a.bhyt,dvt,id_loai from medibv.v_giavp a,medibv.v_loaivp b where a.id_loai=b.id";
            sql += " and b.id_nhom=" + int.Parse(tennhom.SelectedValue.ToString());
            sql += " order by a.stt";
            dtgia = m_v.get_data(sql).Tables[0];
            dgGia.DataSource = dtgia;
            s_nhom = dt.Rows[tennhom.SelectedIndex]["trongoi"].ToString();
            if (s_nhom != "")
            {
                sql = "select * from medibv.v_nhomvp where ma in (" + s_nhom.Substring(0, s_nhom.Length - 1) + ")";
                sql += " order by stt";
                dtnhom = m_v.get_data(sql).Tables[0];              
                f_Load_PChitiet();
                load_mavp();
            }
        }

        private void tennhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == tennhom) load_gia();
        }

        private void matat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void matat_Validated(object sender, EventArgs e)
        {
            try
            {
                DataRow r = m_v.getrowbyid(dt, "ma='" + matat.Text + "'");
                if (r != null)
                {
                    tennhom.SelectedValue = r["id"].ToString();
                    load_gia();
                }
                else tennhom.SelectedIndex = -1;
            }
            catch { tennhom.SelectedIndex = -1; }
        }

        private void tennhom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tennhom.SelectedIndex == -1 && tennhom.Items.Count > 0) tennhom.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }
      
        private void load_mavp()
        {
            try
            {                
                DataRowView rr = (DataRowView)(dgGia.CurrentRow.DataBoundItem);
                l_id = decimal.Parse(rr["id"].ToString());

                DataRow r = m_v.getrowbyid(dtgia, "id=" + l_id);
                if (r != null)
                {
                    stt.Value = decimal.Parse(r["stt"].ToString());
                    ma.Text = r["ma"].ToString();
                    ten.Text = r["ten"].ToString();
                    dvt.Text = r["dvt"].ToString();
                    txtidloai.Text = r["id_loai"].ToString();
                    st = decimal.Parse(r["gia_th"].ToString());
                    gia.Text = st.ToString("###,###,###,##0");
                    bhyt.SelectedValue = r["bhyt"].ToString();
                    DataTable tmp = m_v.get_data("select * from medibv.v_trongoi where id=" + l_id + " order by stt").Tables[0];
                    DataRow r1;
                    foreach (Control c in p.Controls)
                    {
                        if (c.Name.IndexOf("tbma_") == 0)
                        {
                            r1 = m_v.getrowbyid(tmp, "id_nhom=" + int.Parse(c.Name.Replace("tbma_", "")));
                            if (r1 != null)
                            {
                                st = decimal.Parse(r1["sotien"].ToString());
                                c.Text = st.ToString("###,###,###,##0");
                            }
                            else c.Text = "";
                        }                            
                    }
                    f_Tinhtien();
                }
            }
            catch { }
        }

        private void f_Load_PChitiet()
        {
            try
            {
                p.Controls.Clear();
                Label alb;               
                TextBox atb;

                m_table = new TableLayoutPanel();
                m_table.Name = "tableLayoutPanel_01";
                m_table.Text = "?";
                m_table.AutoScroll = true;
                m_table.BorderStyle = BorderStyle.None;
                m_table.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
              //  m_table.BackColor = Color.Honeydew;

                m_table.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                m_table.AutoSize = true;

                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
                m_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
                
                int ai = 0, arow = 0, acol = 0;
                foreach (DataRow r in dtnhom.Rows)
                {
                    ai++;
                    m_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));

                    alb = new Label();
                    alb.Name = "lbma_" + r["ma"].ToString();
                    alb.Text = r["ten"].ToString().Trim() + ":";                                        
                    alb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    alb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
                    alb.TextAlign = ContentAlignment.MiddleRight;
                    alb.Width = 110;
                    alb.Left = 1;
                    m_table.Controls.Add(alb, acol, arow);

                    atb = new TextBox();
                    atb.Name = "tbma_" + r["ma"].ToString();
                    atb.Text = "";
                    atb.Enabled = false;
                    atb.BackColor = Color.White;
                    atb.Width = 90;

                    atb.Leave += new System.EventHandler(this.f_Control_Leave);
                    atb.Enter += new System.EventHandler(this.f_Control_Enter);
                    atb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_Control_KeyDown);
                    atb.Validated += new System.EventHandler(this.txt_Validated);
                    atb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.f_Control_Keypress);

                    atb.ReadOnly = false;
                    atb.TextAlign = HorizontalAlignment.Right;
                    m_table.Controls.Add(atb, acol + 1, arow);                                      
                    arow++;
                }
                m_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
                alb = new Label();
                alb.Name = "_blank";
                alb.Text = "";
                alb.AutoSize = false;
                alb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                alb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom)));
                alb.TextAlign = ContentAlignment.MiddleRight;
                m_table.Controls.Add(alb, 0, ai);

                p.Controls.Add(m_table);               
                m_table.BringToFront();
            }
            catch
            {
            }
            finally
            {
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
                    if (atb == p.Controls[p.Controls.Count - 2])
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
        private void f_Control_Keypress(object sender, System.EventArgs e)
        {
            decimal asotien = 0, asotienct = 0;
            foreach (Control c in p.Controls)
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
                    asotien += asotienct;

                    if (asotien > decimal.Parse(gia.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Số tiền phân bổ không được lớn hơn")+"  " + gia.Text + ".", m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        c.Text = "";
                        return;
                    }
                }
            }
        }
        private void ena_object(bool ena)
        {
            matat.Enabled = !ena;
            tennhom.Enabled = !ena;
            dgGia.Enabled = !ena;
            gia.Enabled = ena;
            stt.Enabled = ena;
            ma.Enabled = ena;
            ten.Enabled = ena;
            txtPhanbo.Enabled = false;
            bhyt.Enabled = ena;
            butMoi.Enabled = !ena;
            butSua.Enabled = !ena;
            butLuu.Enabled = ena;
            butBoqua.Enabled = ena;
            butXoa.Enabled = !ena;
            butKetthuc.Enabled = !ena;
            foreach (Control c in p.Controls)
                if (c.Name.IndexOf("tbma_") == 0)
                {
                    TextBox atb = (TextBox)(c);
                    atb.Enabled = ena;
                }
        }

        private void emp_text()
        {
            stt.Value = m_v.get_stt(dtgia, "stt");
            ma.Text = "";
            ten.Text = "";
            gia.Text = "";
            if (bhyt.Items.Count > 0) bhyt.SelectedIndex = 0;
            foreach (Control c in p.Controls)
            {
                if (c.Name.IndexOf("tbma_") == 0)
                {
                        c.Text = "";
                }
            }
                
        }

        private void butMoi_Click(object sender, EventArgs e)
        {
            ena_object(true);
            emp_text();
            ma.Text = matat.Text + stt.Value.ToString().Trim();
            l_id = 0;
            stt.Focus();
        }

        private void butSua_Click(object sender, EventArgs e)
        {
            ena_object(true);
            stt.Focus();
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            int i = 1;
            l_id = (l_id == 0) ? decimal.Parse(m_v.get_id_v_giavp.ToString()) : l_id;
            m_v.execute_data("delete from medibv.v_trongoi where id_loai=0 and id_gia=0 and id=" + l_id);
            decimal asotienct = 0;
            foreach (Control c in p.Controls)
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
                    m_v.upd_trongoi(l_id, i++, decimal.Parse(c.Name.Replace("tbma_", "")), 0, 0, asotienct);
                }                
            }
          //  i = tennhom.SelectedIndex;
          //  st = (gia.Text != "") ? decimal.Parse(gia.Text) : 0;            
           // m_v.upd_v_giavp(l_id, decimal.Parse(txtidloai.Text.Trim()), decimal.Parse(stt.Value.ToString()), ma.Text, ten.Text, dvt.Text, st, st, st, st, st, 0, 0, 0, 0, 0, decimal.Parse(bhyt.SelectedValue.ToString()), 0, 0, 0, 0, 1, 0, 0, "", 0, decimal.Parse(v_userid), 0, st, 0, 0);
            m_v.execute_data("update medibv.v_giavp set loaitrongoi=1 where id=" + l_id);
            ena_object(false);
            butMoi.Focus();
            load_gia();
        }

        private void butXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView r = (DataRowView)(dgGia.CurrentRow.DataBoundItem);
                l_id = decimal.Parse(r["id"].ToString());
                if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"), m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    m_v.execute_data("delete from medibv.v_giavp where id=" + l_id);
                    m_v.execute_data("delete from medibv.v_trongoi where id=" + l_id);
                    load_gia();
                }
            }
            catch { }
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            ena_object(false);
        }

        private void ma_Validated(object sender, EventArgs e)
        {
            if (l_id == 0)
            {
                DataRow r = m_v.getrowbyid(dtgia, "ma='" + ma.Text + "'");
                if (r != null)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Mã số đã nhập !"), m_v.s_AppName);
                    ma.Focus();
                    return;
                }
            }
        }

        private void stt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void ma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void ten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void bhyt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgGia_Click(object sender, EventArgs e)
        {
            load_mavp();
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
                foreach (Control c in p.Controls)
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
                txtPhanbo.Text = asotien.ToString("###,###,##0");
            }
            catch
            {
                gia.Text = "0";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CurrencyManager mc = (CurrencyManager)BindingContext[dgGia.DataSource, dgGia.DataMember];
                DataView dv = (DataView)mc.List;
                dv.RowFilter = "ten like '%" + textBox1.Text.Trim() + "%'";
            }
            catch
            {
            }
        }
    }
}