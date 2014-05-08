using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibMedi;

namespace Medisoft
{
    public partial class frmDsksk : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private AccessData m;
        private string user,sql;
        private DataSet ds = new DataSet();
        public frmDsksk(AccessData acc)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc;
        }   

        private void frmDsksk_Load(object sender, EventArgs e)
        {
            user = m.user;
            sql = "select a.*,to_char(a.ngay,'dd/mm/yyyy') as ngayhd,to_char(a.ngayud,'mmyy') as mmyy from " + user + ".ct_doan a order by a.id desc ";
            ds = m.get_data(sql);
            cmbten.DisplayMember = "ten";
            cmbten.ValueMember = "id";
            cmbten.DataSource = ds.Tables[0];
            donvi.DisplayMember = "ten";
            donvi.ValueMember = "id";
            load_donvi();
        }

        private void load_donvi()
        {
            if (cmbten.SelectedIndex != -1)
            {
                sql = "select * from " + user + ".ct_donvi where iddoan=" + decimal.Parse(cmbten.SelectedValue.ToString()) + " order by stt";
                donvi.DataSource = m.get_data(sql).Tables[0];
                donvi.SelectedIndex = -1;
            }
        }
        private void tim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void tim_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == tim) RefreshChildren(tim.Text);
        }

        private void tim_Enter(object sender, EventArgs e)
        {
            tim.Text = "";
        }

        private void RefreshChildren(string text)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[cmbten.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "ten like '%" + text.Trim() + "%' or sohd like '%" + text + "%'";
            }
            catch {}
            load_donvi();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            if (cmbten.SelectedIndex == -1)
            {
                cmbten.Focus();
                return;
            }
            string xxx=user+ds.Tables[0].Rows[cmbten.SelectedIndex]["mmyy"].ToString();
            sql = "select a.mabn,a.hoten,a.namsinh,case when a.phai=1 then 'Nữ' else 'Nam' end as phai,";
            sql += "to_char(b.ngay,'dd/mm/yyyy') as ngay,c.ten as donvi,b.ketluan,e.ten as loai,d.hoten as tenbs ";
            sql += " from " + xxx + ".ct_btdbn a inner join " + xxx + ".ct_ketqua b on a.mabn=b.mabn ";
            sql += " inner join " + user + ".ct_donvi c on a.iddonvi=c.id ";
            sql += " left join " + user + ".dmbs d on b.mabs=d.ma ";
            sql += " inner join " + user + ".ct_loai e on b.loai=e.id ";
            sql += " where c.iddoan=" + decimal.Parse(cmbten.SelectedValue.ToString());
            if (donvi.SelectedIndex != -1) sql += " and c.id=" + decimal.Parse(donvi.SelectedValue.ToString());
            sql += " order by c.stt,a.stt";
            DataSet dsxml = m.get_data(sql);
            if (dsxml.Tables[0].Rows.Count > 0)
            {
                dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml, cmbten.Text, "rptDsksk.rpt");
                f.ShowDialog();
            }
            else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), LibMedi.AccessData.Msg);
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            m.close();this.Close();
        }

        private void cmbten_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cmbten) load_donvi();
        }
   }
}