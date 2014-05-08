using System;
using System.Windows.Forms;
using System.Resources;
//using Ketoan.Access.Profiles;
namespace MEDISOFT2011.DESKTOP
{
    public class proNhapkho:Profile
    {
        public proNhapkho(Form _frm)
        {
            base.frmBase = _frm;
        }
       
        public override void LoadProfile(string sNgonngu)
        {
            ResourceManager res = new ResourceManager(@"MEDISOFT2011.DESKTOP.Language." + base.frmBase.Name + sNgonngu, GetType().Assembly);

            foreach (Control c in base.frmBase.Controls)
            {
                GetAllControl(c, res);
            }
            base.frmBase.Text = res.GetString("Title");
           
        }

        private void GetAllControl(Control M, ResourceManager res)
        {
            string sType = M.GetType().ToString().ToLower();
            if (sType.IndexOf("textbox") > -1 ||
                           sType.IndexOf("system.windows.forms.label") > -1 ||
                           sType.IndexOf("system.windows.forms.checkbox") > -1 ||
                           sType.IndexOf("button") > -1 ||
                           sType.IndexOf("checkbox") > -1 ||
                           sType.IndexOf("combobox") > -1)
            {

                string sMsg = res.GetString(M.Name);
                M.Text = sMsg;

            }
            else if (sType.IndexOf("datagridview") > -1)
            {
                System.Windows.Forms.DataGridView data = (DataGridView)M;
                foreach (System.Windows.Forms.DataGridViewTextBoxColumn dgcol in data.Columns)
                {
                    string sMsg = res.GetString(dgcol.Name);
                    M.Text = sMsg;
                }

            }
            else if (sType.IndexOf("system.windows.forms.linklabel") > -1)
            {
                System.Windows.Forms.LinkLabel data = (System.Windows.Forms.LinkLabel)M;

                

            }
            else if (sType.IndexOf("system.windows.forms.tabcontrol") > -1)
            {
                System.Windows.Forms.TabControl TAB = (System.Windows.Forms.TabControl)M;
                foreach (System.Windows.Forms.TabPage tabpage in TAB.Controls)
                {

                    string sMsg = res.GetString(tabpage.Name);
                    M.Text = sMsg;
                    foreach (Control col in tabpage.Controls)
                        GetAllControl(col, res);
                }
            }
            else if (sType.IndexOf("system.windows.forms.panel") > -1)
            {
                System.Windows.Forms.Panel panel = (System.Windows.Forms.Panel)M;
                foreach (Control m in panel.Controls)
                    GetAllControl(m, res);
            }

            else if (sType.IndexOf("system.windows.forms.groupbox") > -1)
            {
                System.Windows.Forms.GroupBox p = (System.Windows.Forms.GroupBox)M;
                string sMsg = res.GetString(M.Name);
                M.Text = sMsg;
                foreach (Control m in p.Controls)
                    GetAllControl(m, res);
            }
        }
    }
}
