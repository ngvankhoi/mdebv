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
    public partial class frmLphanloai : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private AccessData m;
        private DataTable dt = new DataTable();
        private int loai;
        public string ret = "";
        public frmLphanloai(AccessData acc,int _loai)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

            m = acc; loai = _loai; if (m.bBogo) tv.GanBogo(this, textBox111);
        }

        private void frmLphanloai_Load(object sender, EventArgs e)
        {
            DataTable dt = m.get_data("select ma,ten from " + m.user + ".cls_phanloai where loai="+loai+" and length(ma)=11 order by ma").Tables[0];
            treeView1.Nodes.Clear();
            TreeNode n1 = new TreeNode(), n2 = new TreeNode(), n3 = new TreeNode();//, n4 = new TreeNode();
            string m1 = "", m2 = "", m3 = "";
            foreach (DataRow r in dt.Rows)
            {
                if (m1 != r["ma"].ToString().Substring(0, 2))
                {
                    m1 = r["ma"].ToString().Substring(0, 2);
                    m2 = ""; m3 = "";
                    n1 = treeView1.Nodes.Add(r["ma"].ToString() + " " + r["ten"].ToString());
                }
                if (m2 != r["ma"].ToString().Substring(3, 2))
                {
                    m2 = r["ma"].ToString().Substring(3, 2);
                    m3 = "";
                    n2 = n1.Nodes.Add(r["ma"].ToString() + " " + r["ten"].ToString());
                }
                if (m3 != r["ma"].ToString().Substring(6, 2))
                {
                    m3 = r["ma"].ToString().Substring(6, 2);
                    n3 = n2.Nodes.Add(r["ma"].ToString() + " " + r["ten"].ToString());
                }
                //n4 = n3.Nodes.Add(r["ma"].ToString() + " " + r["ten"].ToString());
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
            {
                try
                {
                    string s = e.Node.FullPath.Trim();
                    int i1 = s.IndexOf("//"), i2 = s.LastIndexOf("//");
                    //if (i1 != -1) ret = s.Substring(i1 + 1, 11);
                    if (i2 != -1) ret += s.Substring(i2 + 1, 11);
                    m.close();this.Close();
                }
                catch { }
            }
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            m.close();this.Close();
        }
    }
}