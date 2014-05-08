using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class frmKhaibaomaytram : Form
    {
        DAL.Client m_server;
        DAL.Accessdata macc;
        List<DAL.Client> list;
        DataSet dsxml ;
        int i_khoang_cach_ngay;
        bool bNew = false;
        string mmyy = DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2, 2);
        public frmKhaibaomaytram( DAL.Client server,List<DAL.Client> listClient)
        {
            InitializeComponent();
            m_server = server;
            list = listClient;
        }
        public frmKhaibaomaytram(List<DAL.Client> listClient,DataSet _dsxml,int _khoang_cach_ngay)
        {
            InitializeComponent();
            list = listClient;
            dsxml = _dsxml;
            i_khoang_cach_ngay = _khoang_cach_ngay;
        }
        private void Init()
        {
            //if (!System.IO.File.Exists("..//..//..//xml//upd_table.xml"))
            //{
            //    MessageBox.Show("Không tìm thấy file table.xml", "System");
            //    return;
            //}
            //dsxml.ReadXml("..//..//..//xml//upd_table.xml", XmlReadMode.ReadSchema);

            //if (list.Count > 0)
            //{
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        clientUI1.RemoveMay(list[i].ID);
            //    }
            //}
        }
        private void frmKhaibaomaytram_Load(object sender, EventArgs e)
        {
            load_combobox();
            clientUI1.emptyText();
            clientUI1.Init();
            Init();
            ena_obj(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {            
            //Xóa dblink 
            DAL.Client f_client = clientUI1.Client;
            //
            if (macc == null) macc = new DAL.Accessdata();
            if (bNew)
            {
                bool bFound = macc.TimClient_TheoSTT(f_client.STT);
                if (bFound)
                {
                    MessageBox.Show("STT Máy này đã tồn tại, chọn lại STT máy");
                    return;
                }
            }
            //
            f_client.XoaDBLink();
            // Nếu tạo thành công dblink thì lưu xuống database link
            if (!f_client.TaoDBLink())
            {
                UI.Thongbao.Message("MC001");
                return;
            }
            //Lưu thông tin máy trạm lên server trung tâm.
            f_client.ImagePath = @txtPath.Text;
            f_client.ImagePath_BN = @txtPathBN.Text;
            f_client.ImagePath_Chungtu = txtPath_chungtu.Text;
            if (!DAL.Manager.LuuClient(f_client))
            {
                UI.Thongbao.Message("MC002");
                return;
            }
            //
            //
            // tạo các function liên quan đến máy trạm
            //string schema = "", table = "", field = "", key = "";
            //DAL.Accessdata acc = new DAL.Accessdata();
            //foreach (System.Data.DataRow row in dsxml.Tables[0].Rows)
            //{
            //    schema = row["schema"].ToString();
            //    schema = schema.Replace("xxx", mmyy);
            //    table = row["tablename"].ToString();
            //    field = row["field"].ToString();
            //    key = row["key"].ToString();
            //    acc.CreateFunction(m_server, f_client, schema, table, field, key);
            //}
            //try
            //{
            //    using (DAL.Accessdata acc = new DAL.Accessdata())
            //    {
            //        DateTime tn = DateTime.Now.AddDays(-(double)i_khoang_cach_ngay);
            //        DateTime dn = DateTime.Now.AddDays((double)i_khoang_cach_ngay);
            //        for (int j = tn.Year; j <= dn.Year; j++)
            //        {
            //            for (int i = tn.Month; i <= dn.Month; i++)
            //            {
            //                string mmyy = i.ToString().PadLeft(2, '0') + j.ToString().Substring(2, 2);
            //                foreach (DataRow row in dsxml.Tables[0].Rows)
            //                {
            //                    acc.CreateFunction(f_client, row["schema_name"].ToString().Replace("xxx", mmyy), row["table_name"].ToString());
            //                }
            //            }
            //        }
            //    }
            //}
            //catch { }
            //this.Close();
            MessageBox.Show("Lưu thành công.");
            clientUI1.emptyText();
            //
            load_combobox();
            //
            Empty_text();
            ena_obj(false);
            butMoi.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void image_Click(object sender, EventArgs e)
        {
            try
            {
                string cur_Path = Environment.CurrentDirectory;
                if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    txtPath.Text = folderBrowserDialog1.SelectedPath;
                }
                Environment.CurrentDirectory = cur_Path;
            }
            catch { }
        }

        private void butImageBN_Click(object sender, EventArgs e)
        {
            try
            {
                string cur_Path = Environment.CurrentDirectory;
                if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    txtPathBN.Text = folderBrowserDialog1.SelectedPath;
                }
                Environment.CurrentDirectory = cur_Path;
            }
            catch { }
        }

        private void butMoi_Click(object sender, EventArgs e)
        {
            bNew = true;
            Empty_text();
            ena_obj(true);

        }

        private void ena_obj(bool ena)
        {
            cmbMayTram.Enabled = !ena;
            butMoi.Enabled = !ena;
            butSua.Enabled = !ena;
            butBoqua.Enabled = ena;
            btnLuu.Enabled = ena;
            butHuy.Enabled = !ena;           
            //
            clientUI1.Enable = ena;
            //
            image.Enabled = ena;
            txtPath.Enabled = ena;
            butImageBN.Enabled = ena;
            butDirHinhCtu.Enabled = ena;
            txtPathBN.Enabled = ena;
            txtPath_chungtu.Enabled = ena;
            //
        }

        private void butHuy_Click(object sender, EventArgs e)
        {
            if (cmbMayTram.SelectedIndex < 0)
            {
                MessageBox.Show("Đề nghị chọn máy.");
                cmbMayTram.Focus();
                return;
            }
            int iID = int.Parse(cmbMayTram.SelectedValue.ToString());
            macc.DeleteClient(iID);
            load_combobox();
            ena_obj(false);
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            ena_obj(false);
        }

        private void load_combobox()
        {            
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(decimal));
            dt.Columns.Add("name", typeof(string));
            //
            string exp = "";
            DataRow dr;
            DAL.Accessdata m = new DAL.Accessdata();                
            //
            list = DAL.Manager.listClient();
            for (int i = 0; i < list.Count; i++)
            {
                DAL.Client client = list[i];
                exp = "id=" + client.ID.ToString();
                dr = m.getrowbyid(dt, exp);
                if (dr == null)
                {
                    dr = dt.NewRow();
                    dr["id"] = client.ID;
                    dr["name"] = client.DatabaseName + " [" + client.Host + "]";
                    dt.Rows.Add(dr);
                }
            }
            dt.AcceptChanges();
            //            
            //
            cmbMayTram.DataSource = dt;
            cmbMayTram.DisplayMember = "name";
            cmbMayTram.ValueMember = "id";            
            //
        }

        private void Empty_text()
        {
            clientUI1.emptyText();
            clientUI1.Init();
            txtPath.Text="";
            txtPathBN.Text="";
            txtPath_chungtu.Text = "";
        }

        private void cmbMayTram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cmbMayTram || sender == null)
            {
                if (cmbMayTram.SelectedIndex < 0) return;
                int i_IDMaytram = int.Parse(cmbMayTram.SelectedValue.ToString());
                if (macc == null) macc = new DAL.Accessdata();
                DAL.Client c_client = macc.TimClient(i_IDMaytram);
                clientUI1.Client = c_client;
                txtPath.Text = c_client.ImagePath;
                txtPathBN.Text  = c_client.ImagePath_BN;
                txtPath_chungtu.Text = c_client.ImagePath_Chungtu;
            }
        }

        private void butSua_Click(object sender, EventArgs e)
        {
            if (cmbMayTram.SelectedIndex < 0)
            {
                MessageBox.Show("Đề nghị chọn máy.");
                cmbMayTram.Focus();
                return;
            }
            bNew = false;
            ena_obj(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cur_Path = Environment.CurrentDirectory;
                if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    txtPath_chungtu.Text = folderBrowserDialog1.SelectedPath;
                }
                Environment.CurrentDirectory = cur_Path;
            }
            catch { }
        }
    }
}