using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibMedi;
using ConvertFont;

namespace Medisoft
{
    public partial class frmChuyenkq : Form
    {
        Language lan = new Language();
        private AccessData m;
        private ConvertFont.MyClass cvf = new ConvertFont.MyClass();
        private string user,sql,file_ct2003,s_cls;
        private DataTable dtbs = new DataTable();
        private DataTable dtloai = new DataTable();
        public frmChuyenkq(AccessData acc,string cls)
        {
            InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; s_cls = cls;
        }

        private void frmChuyenkq_Load(object sender, EventArgs e)
        {
            user = m.user;
            dtbs = m.get_data("select * from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
            sql = "select * from " + user + ".cls_loai";
            if (s_cls != "") sql += " where id in (" + s_cls.Substring(0, s_cls.Length - 1) + ")";
            sql += " order by id";
            dtloai = m.get_data(sql).Tables[0];
            loai.DisplayMember = "TEN";
            loai.ValueMember = "ID";
            loai.DataSource = dtloai;
            tu.Text = m.ngayhienhanh_server.Substring(0, 10);
        }

        private void tu_Validated(object sender, EventArgs e)
        {
            if (tu.Text == "") return;
            tu.Text = tu.Text.Trim();
            if (tu.Text.Length == 6) tu.Text = tu.Text + DateTime.Now.Year.ToString();
            if (!m.bNgay(tu.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"), LibMedi.AccessData.Msg);
                tu.Focus();
                return;
            }
            tu.Text = m.Ktngaygio(tu.Text, 10);
        }

        private void loai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void butFind_Click(object sender, EventArgs e)
        {
            if (tu.Text == "" || loai.SelectedIndex == -1)
            {
                if (tu.Text == "") tu.Focus();
                else loai.Focus();
                return;
            }
            Cursor = Cursors.WaitCursor;
            file_ct2003 = dtloai.Rows[loai.SelectedIndex]["path_access"].ToString().Trim();
            if (file_ct2003 != "")
            {
                sql = "select id,format(timestart,'dd/MM/yyyy') as ngay,ketqua,bs_kham,canquang from bnhan where format(timestart,'dd/MM/yyyy')='"+tu.Text+"'";
                string _mabs = "";
                long id=0;
                DataRow r1;
                DataTable dt = m.get_data_acc(sql, file_ct2003).Tables[0];
                foreach (DataRow r in dt.Select("ketqua<>''"))
                {
                    r1 = m.getrowbyid(dtbs, "hoten='" + cvf.Vni_Uni(r["bs_kham"].ToString()) + "'");
                    _mabs = (r1 == null) ? "" : r1["ma"].ToString();
                    m.upd_cls_ketqua(r["ngay"].ToString(), r["id"].ToString(), int.Parse(loai.SelectedValue.ToString()), cvf.Vni_Uni(r["ketqua"].ToString()), _mabs);
                }
                //can quang
                foreach (DataRow r in dt.Select("canquang='010'"))
                {
                    id = m.get_id_cls_ketqua(m.mmyy(r["ngay"].ToString()), int.Parse(loai.SelectedValue.ToString()), r["id"].ToString());
                    if (id!=0) m.upd_cls_motact(r["ngay"].ToString(), id, (r["canquang"].ToString() == "010") ? 1 : 0);
                }
            }
            Cursor = Cursors.Default;
            MessageBox.Show(lan.Change_language_MessageText("Đã chuyển xong !"), LibMedi.AccessData.Msg);
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}