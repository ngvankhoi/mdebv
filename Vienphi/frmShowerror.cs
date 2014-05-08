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
    public partial class frmShowerror : Form
    {
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        public frmShowerror(string v_title, string v_message)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

            if (v_title != "")
            {
                lbTitle.Text = v_title;
            }
            txtError.Text = v_message;
        }

        private void frmShowerror_Load(object sender, EventArgs e)
        {
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog afo = new SaveFileDialog();
                afo.RestoreDirectory = true;
                afo.Filter = "Text File (*.txt)|*.txt";
                afo.Title = lan.Change_language_MessageText(
"Chọn nơi lưu dữ liệu kết xuất");
                afo.ShowDialog();
                if (afo.FileName != "")
                {
                    string afilename = afo.FileName;
                    if (afilename.ToLower().LastIndexOf(".txt") != afilename.Length - 4)
                    {
                        afilename = afilename + ".txt";
                    }
                    try
                    {
                        System.IO.StreamWriter ast = System.IO.File.AppendText(afilename);
                        ast.WriteLine(txtError.Text);
                        ast.WriteLine("");
                        ast.Close();
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }
    }
}