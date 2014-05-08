using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vienphi
{
    public partial class frmTrongoi_KP : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private LibVP.AccessData m_v;
        private DataSet ds_kp, adskp;
        private string v_id_trongoi, sql = "", s_id_gia_goc = "";
        private frmChongoi_kp m_frmchongoi_kp;
        private int itable;

        public frmTrongoi_KP(LibVP.AccessData v_v,string v_id_gia,string id_gia_goc)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);


            m_v = v_v;
            v_id_trongoi = v_id_gia;
            s_id_gia_goc = id_gia_goc;
        }
   
        private void frmTrongoi_KP_Load(object sender, EventArgs e)
        {
            itable = m_v.tableid("", "v_trongoipk");
            f_Load_Grid();
        }
        private void f_Load_Grid()
        {
            try
            {
                adskp = m_v.get_data("select makp,tenkp from medibv.btdkp_bv where loai=1 order by makp");
                sql = "select a.id as id_trongoi,a.makp,tenkp,sotien,stt,idgiavp from medibv.v_trongoipk a inner join medibv.btdkp_bv b on a.makp=b.makp where a.id='" + v_id_trongoi + "' and a.idgiavp='" + s_id_gia_goc + "'";
                ds_kp = m_v.get_data(sql);
                dataGridView1.DataSource = ds_kp.Tables[0];

                m_frmchongoi_kp = new frmChongoi_kp(m_v);
                m_frmchongoi_kp.ShowInTaskbar = false;
                f_Tinhtien();
            }
            catch
            {
                MessageBox.Show(lan.Change_language_MessageText("Vào tiện ích tạo lại số liệu tháng năm."), m_v.s_AppName);
            }
        }
        private void f_Tinhtien()
        {
            try
            {
                decimal atmp = 0, asotien = 0;
                foreach (DataRow r in ds_kp.Tables[0].Rows)
                {
                    try
                    {
                        atmp = decimal.Parse(r["sotien"].ToString());
                    }
                    catch
                    {
                        atmp = 0;
                    }
                    if (atmp < 0)
                    {
                        atmp = 0;
                    }
                    r["sotien"] = atmp;
                    asotien += atmp;
                }
                lbSotien.Text = lan.Change_language_MessageText("Cộng giá trọn gói:") + " " + asotien.ToString("###,###,##0.##") + " đồng";
            }
            catch
            {
                lbSotien.Text = lan.Change_language_MessageText("Cộng giá trọn gói: 0 đồng");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStrip_KP_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_frmchongoi_kp.ShowDialog(this) == DialogResult.OK)
                {
                    if (m_frmchongoi_kp.s_makp != "")
                    {
                        Add(m_frmchongoi_kp.s_makp);
                    }
                }
            }
            catch
            { 
            }
        }
        private void Add(string v_makp)
        {
            try
            {
                DataRow r1;
                int stt = 1;
                foreach (string atmp in v_makp.Split(','))
                {
                    if (ds_kp.Tables[0].Select("makp=" + atmp).Length <= 0)
                    {
                        foreach (DataRow r in adskp.Tables[0].Select("makp=" + atmp))
                        {
                            r1 = ds_kp.Tables[0].NewRow();
                            r1["id_trongoi"] = s_id_gia_goc;
                            r1["makp"] = r["makp"].ToString();
                            r1["tenkp"] = r["tenkp"].ToString();
                            r1["sotien"] = 0;
                            r1["stt"] = stt;
                            ds_kp.Tables[0].Rows.Add(r1.ItemArray);
                            stt++;
                        }
                    }
                }
            }
            catch
            { 
            }
            f_Tinhtien();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                f_Tinhtien();
            }
            catch
            {
            }
        }
        private void butLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ads = ds_kp;
                int n = ads.Tables[0].Rows.Count;
                if (n > 0)
                {
                    if (MessageBox.Show(this, lan.Change_language_MessageText("Đồng ý cập nhật chi tiết gói viện phí khoa phòng(") + n.ToString() + " Mục)?", m_v.s_AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        butLuu.Enabled = false;
                        ttStatus.Text = lan.Change_language_MessageText("Đang cập nhật, xin chờ ...!");
                        decimal  aid = 0, asotien = 0,astt = 1;
                        string amakp = "";
                        try
                        {
                            aid = decimal.Parse(s_id_gia_goc);
                        }
                        catch
                        {
                            aid = 0;
                        }
                        if (aid == 0)
                        {
                            MessageBox.Show(this, lan.Change_language_MessageText("Chưa chọn giá viện phí!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        m_v.execute_data("delete from medibv.v_trongoipk where id=" + aid.ToString());
                        foreach (DataRow r in ads.Tables[0].Rows)
                        {                            
                            try
                            {
                                asotien = decimal.Parse(r["sotien"].ToString());
                            }
                            catch
                            {
                                asotien = 0;
                            }
                            try
                            {
                                amakp = r["makp"].ToString();
                            }
                            catch
                            {
                                amakp = "0";
                            }                           
                            try
                            {
                                ttStatus.Text = lan.Change_language_MessageText("Đang cập nhật:") + " " + astt.ToString() + "/" + n.ToString() + " !";
                                m_v.upd_v_trongoipk(decimal.Parse(v_id_trongoi), amakp, asotien, astt, aid);
                            }
                            catch
                            {
                            }
                            astt++;
                        }                       
                        ttStatus.Text = lan.Change_language_MessageText("Cập nhật xong!");
                        f_Load_Grid();
                        butLuu.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            f_Load_Grid();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {

                ds_kp.Tables[0].Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                f_Tinhtien();
            }
            catch
            { 
            }
        }
    }
}