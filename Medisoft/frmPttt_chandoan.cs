using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//Khuong 16/12/2011
namespace Medisoft
{
    public partial class frmPttt_chandoan : Form
    {
        LibMedi.AccessData m;
        string sql = "",user="",maicdCu="",chandoanCu="";
     
        int userid = 0,loai=0;
        DataTable dtIcd10=new DataTable();
        public DataTable dt = new DataTable();
      
        DataTable dt_save = new DataTable();
       
        Language lan = new Language();

        public frmPttt_chandoan(LibMedi.AccessData _m,string _maicd,string _chandoan,int _userid,int _loai,DataTable _dt,DataTable _dticd)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = _m;
        
            maicdCu = _maicd;
            chandoanCu = _chandoan;
            userid = _userid;
            loai=_loai;
            dt = _dt.Copy();
            
            dtIcd10 = _dticd;
        }

        private void frmPttt_chandoan_Load(object sender, EventArgs e)
        {
            

            txtmaicdchinh.Text=maicdCu;
            txtChandoanchinh.Text=chandoanCu;
            user=m.user;
            dt_save = dt.Copy();
            
            load_grid();
            
			listICD.DisplayMember="CICD10";
			listICD.ValueMember="VVIET";
			listICD.DataSource=dtIcd10;

            dataGridView1_CellContentClick(null, null);
            if (loai == 0)
                this.Text = lan.Change_language_MessageText("Chẩn đoán trước phẫu thuật/thủ thuật");
            else if(loai==1)
                this.Text = lan.Change_language_MessageText("Chẩn đoán sau phẫu thuật/thủ thuật");
            else if (loai == 99)
            {
                this.Text = lan.Change_language_MessageText("Phương pháp phẫu thuật/thủ thuật");

                dataGridView1.Columns[0].HeaderText = lan.Change_language_MessageText("Mã PT/TT");
                dataGridView1.Columns[1].HeaderText = lan.Change_language_MessageText("Tên Phẫu thuật/Thủ thuật");
               
                label1.Text = lan.Change_language_MessageText("Phương pháp");
                label2.Text = lan.Change_language_MessageText("Phương pháp");
                dataGridView1.Refresh();
            }
            txtMaicd.Focus();
        }

        private void load_grid()
        {
//          dt = m.get_data("select maicd,chandoan,userid from " + user + ".pttt_chandoan where id=" + id.ToString() + " and loai=" + loai).Tables[0];
            dt = dt_save.Copy();
            
            dataGridView1.DataSource = dt;
            dataGridView1.AutoGenerateColumns = true;
            
        }

        private void txtMaicd_Validated(object sender, EventArgs e)
        {
            
            if (loai != 99)
            {
                if (txtMaicd.Text == "") txtChandoan.Text = "";
                else txtChandoan.Text = m.get_vviet(txtMaicd.Text).Trim();
                if (txtChandoan.Text == "" && txtMaicd.Text != "")
                {
                    dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", txtMaicd.Text, txtChandoan.Text, true);
                    f.ShowDialog();
                    if (f.mICD != "")
                    {
                        txtChandoan.Text = f.mTen;
                        txtMaicd.Text = f.mICD;
                    }
                }
            }
            else
            {
                if (txtMaicd.Text == "") txtChandoan.Text = "";
                else
                {
                    try
                    {
                        txtChandoan.Text = m.getrowbyid(dtIcd10, "cicd10='" + txtMaicd.Text.Trim() + "'")["vviet"].ToString();
                    }
                    catch
                    {
                        txtChandoan.Text = "";
                    }
                }
            }
        }

        private void txtChandoan_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl==txtChandoan)
			{
				
					Filt_ICD(txtChandoan.Text);
					listICD.BrowseToICD10(txtChandoan,txtMaicd,butMoi,txtMaicd.Location.X,txtMaicd.Location.Y+txtMaicd.Height,txtMaicd.Width+txtChandoan.Width+2,txtMaicd.Height);
				
			}
        }
        private void Filt_ICD(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listICD.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="vviet like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

        private void txtChandoan_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listICD.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listICD.Visible) listICD.Focus();
				else SendKeys.Send("{Tab}{Home}");
			}	
        }

        private void butKetthuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butMoi_Click(object sender, EventArgs e)
        {
            if (txtMaicd.Text.Trim() != "" && txtChandoan.Text.Trim() != "" && m.getrowbyid(dtIcd10, "cicd10='" + txtMaicd.Text.Trim() + "'") != null && txtMaicd.Text.Trim() != txtmaicdchinh.Text.Trim())
            {
                updrec(dt);
               
                txtMaicd.Text = "";
                txtChandoan.Text = "";
                if (ActiveControl == butMoi)
                    txtMaicd.Focus();
            }
        }

        private void updrec(DataTable dttmp)
        {
            string exp = "maicd='" + txtMaicd.Text + "'";
                DataRow r = m.getrowbyid(dttmp, exp);
                if (r == null)
                {
                    DataRow nrow = dttmp.NewRow();
                    nrow["maicd"] = txtMaicd.Text;
                    nrow["chandoan"] = txtChandoan.Text;
                    nrow["userid"] = userid;
                    dttmp.Rows.Add(nrow);
                }
                else
                {
                    DataRow[] dr = dttmp.Select(exp);
                    dr[0]["maicd"] = txtMaicd.Text;
                    dr[0]["chandoan"] = txtChandoan.Text;
                    dr[0]["userid"] = userid;
                }
        }

        private void butXoa_Click(object sender, EventArgs e)
        {
            
            m.delrec(dt, "maicd='" + txtMaicd.Text + "'");
            if (dt.Rows.Count == 0)
            {
                txtChandoan.Text = "";
                txtMaicd.Text = "";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void ref_text()
        {
            try
            {
                int i = dataGridView1.CurrentCell.RowIndex;
                txtMaicd.Text = dataGridView1["maicd",i].Value.ToString();
                txtChandoan.Text = dataGridView1["chandoan", i].Value.ToString();
            }
            catch {
                txtMaicd.Text = "";
                txtChandoan.Text = "";
            }
        }

        private void butLuu_Click(object sender, EventArgs e)
        {
            butMoi_Click(null, null);
            dt.AcceptChanges();
            
            MessageBox.Show(lan.Change_language_MessageText("Lưu thành công!"),LibMedi.AccessData.Msg);
            this.Close();
            //foreach (DataRow r in dtxoa.Rows)
            //{ 
            //    m.execute_data("delete "+user+".pttt_chandoan where id="+id.ToString()+" and maicd='"+r["maicd"].ToString()+"'");
            //}
            //foreach (DataRow r in dt.GetChanges().Rows)
            //{
            //    m.upd_pttt_chandoan(id, r["maicd"].ToString(), r["chandoan"].ToString(), userid);
            //}
        }

        private void butBoqua_Click(object sender, EventArgs e)
        {
            load_grid();
        }

        private void txtMaicd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}{Home}");
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            ref_text();
        }

    }
}