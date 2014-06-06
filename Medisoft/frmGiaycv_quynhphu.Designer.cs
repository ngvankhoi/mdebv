using System.Windows.Forms;
namespace Medisoft
{
    partial class frmGiaycv_quynhphu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lydo.Visible = false;
            this.vanchuyen.Visible = false;
            // rab1
            rab1.Text = "Bệnh nhân đủ điều kiện chuyển tuyến";
            rab1.Location = new System.Drawing.Point(10, 1);
            rab1.Width = 300;
            rab1.Checked = true;
            rab1.CheckedChanged += new System.EventHandler(rab1_CheckedChanged);

            // rab2

            rab2.Text = "Theo yêu cầu của bệnh nhân";
            rab2.Location = new System.Drawing.Point(350, 1);
            rab2.Width = 300;
            rab2.Checked = false;
            rab2.CheckedChanged += new System.EventHandler(rab1_CheckedChanged);

            // rab11
            rab11.Text = "Xe cấp cứu 05";
            rab11.Location = new System.Drawing.Point(10, 1);
            rab11.Width = 120;
            rab11.Checked = true;
            rab11.CheckedChanged += new System.EventHandler(rab11_CheckedChanged);

            // rab12
            rab12.Text = "Xe cấp cứu bệnh viện";
            rab12.Location = new System.Drawing.Point(150, 1);
            rab12.Width = 150;
            rab12.Checked = false;
            rab12.CheckedChanged+=new System.EventHandler(rab11_CheckedChanged);

            // rab13
            rab13.Text = "Bệnh nhân tự túc";
            rab13.Location = new System.Drawing.Point(300, 1);
            rab13.Width = 150;
            rab13.Checked = false;
            rab13.Enabled = false;
            rab13.CheckedChanged += new System.EventHandler(rab11_CheckedChanged);

            //groupbox1
            groupbox1.Location = lydo.Location;
            groupbox1.Anchor = lydo.Anchor;
            groupbox1.Height = lydo.Height+3;
            groupbox1.Width = lydo.Width;
            groupbox1.Controls.Add(rab1);
            groupbox1.Controls.Add(rab2);
            groupbox1.BorderStyle = BorderStyle.None;
            this.Controls.Add(groupbox1);

            //groupbox2
            groupbox2.Location = vanchuyen.Location;
            groupbox2.Anchor = vanchuyen.Anchor;
            groupbox2.Height = vanchuyen.Height + 3;
            groupbox2.Width = vanchuyen.Width;
            groupbox2.Controls.Add(rab11);
            groupbox2.Controls.Add(rab12);
            groupbox2.Controls.Add(rab13);
            groupbox2.BorderStyle = BorderStyle.None;
            this.Controls.Add(groupbox2);
        }

        

        
        Panel groupbox1= new Panel();
        Panel groupbox2 = new Panel();
        RadioButton rab1 = new RadioButton();
        RadioButton rab2 = new RadioButton();
        RadioButton rab11 = new RadioButton();
        RadioButton rab12 = new RadioButton();
        RadioButton rab13 = new RadioButton();
        #endregion
    }
}
