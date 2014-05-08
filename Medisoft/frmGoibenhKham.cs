using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Medisoft
{
    public partial class frmGoibenhKham : Form
{
    // Fields
    private int b1;
    private int b2;
    private int b3;
    private int b4;
   // private IContainer components = null;
    private DataSet ds = new DataSet();
    private int g1;
    private int g2;
    private int g3;
    private int g4;
    private int i_h;
    private int i_w;
    private int i_x;
    private int i_y;
    //private Label label1;
    //private Label label2;
    //private Label lblsotutu;
    //private Panel panel1;
    //private Panel panel2;
    //private Panel panel3;
    private int r1;
    private int r2;
    private int r3;
    private int r4;
    private int s2;
    private int s3;
    private int s4;

    // Methods
    public frmGoibenhKham()
    {
        this.InitializeComponent();
    }

    //protected override void Dispose(bool disposing)
    //{
    //    if (disposing && (this.components != null))
    //    {
    //        this.components.Dispose();
    //    }
    //    base.Dispose(disposing);
    //}

    private void frmGoibenhnhan_Load(object sender, System.EventArgs e)
    {
        this.ds.ReadXml(@"..\..\..\xml\mauLCDpk.xml");
        this.r1 = int.Parse(this.ds.Tables[0].Rows[0]["r1"].ToString());
        this.g1 = int.Parse(this.ds.Tables[0].Rows[0]["g1"].ToString());
        this.b1 = int.Parse(this.ds.Tables[0].Rows[0]["b1"].ToString());
        this.r2 = int.Parse(this.ds.Tables[0].Rows[0]["r2"].ToString());
        this.g2 = int.Parse(this.ds.Tables[0].Rows[0]["g2"].ToString());
        this.b2 = int.Parse(this.ds.Tables[0].Rows[0]["b2"].ToString());
        this.r3 = int.Parse(this.ds.Tables[0].Rows[0]["r3"].ToString());
        this.g3 = int.Parse(this.ds.Tables[0].Rows[0]["g3"].ToString());
        this.b3 = int.Parse(this.ds.Tables[0].Rows[0]["b3"].ToString());
        this.r4 = int.Parse(this.ds.Tables[0].Rows[0]["r4"].ToString());
        this.g4 = int.Parse(this.ds.Tables[0].Rows[0]["g4"].ToString());
        this.b4 = int.Parse(this.ds.Tables[0].Rows[0]["b4"].ToString());
        this.i_w = int.Parse(this.ds.Tables[0].Rows[0]["w"].ToString());
        this.i_h = int.Parse(this.ds.Tables[0].Rows[0]["h"].ToString());
        this.i_x = int.Parse(this.ds.Tables[0].Rows[0]["x"].ToString());
        this.i_y = int.Parse(this.ds.Tables[0].Rows[0]["y"].ToString());
        this.s2 = int.Parse(this.ds.Tables[0].Rows[0]["s2"].ToString());
        this.s3 = int.Parse(this.ds.Tables[0].Rows[0]["s3"].ToString());
        this.s4 = int.Parse(this.ds.Tables[0].Rows[0]["s4"].ToString());
        this.BackColor = System.Drawing.Color.FromArgb(this.r1, this.g1, this.b1);
        base.Location = new Point(this.i_x, this.i_y);
        base.ClientSize = new Size(this.i_w, this.i_h);
        this.lblsotutu.ForeColor = System.Drawing.Color.FromArgb(this.r2, this.g2, this.b2);
        this.label1.Font = new Font("Microsoft Sans Serif", (float) this.s3, FontStyle.Bold, GraphicsUnit.Point, 0);
        this.label1.Text = this.ds.Tables[0].Rows[0]["nd3"].ToString();
        this.label1.ForeColor = System.Drawing.Color.FromArgb(this.r3, this.g3, this.b3);
        this.label2.Font = new Font("Microsoft Sans Serif", (float) this.s4, FontStyle.Bold, GraphicsUnit.Point, 0);
        this.label2.Text = this.ds.Tables[0].Rows[0]["nd4"].ToString();
        this.label2.ForeColor = System.Drawing.Color.FromArgb(this.r4, this.g4, this.b4);
    }

    //private void InitializeComponent()
    //{
    //    this.panel1 = new Panel();
    //    this.label1 = new Label();
    //    this.panel2 = new Panel();
    //    this.lblsotutu = new Label();
    //    this.panel3 = new Panel();
    //    this.label2 = new Label();
    //    this.panel1.SuspendLayout();
    //    this.panel2.SuspendLayout();
    //    this.panel3.SuspendLayout();
    //    base.SuspendLayout();
    //    this.panel1.Controls.Add(this.label1);
    //    this.panel1.Dock = DockStyle.Top;
    //    this.panel1.Location = new Point(0, 0);
    //    this.panel1.Name = "panel1";
    //    this.panel1.Size = new System.Drawing.Size(0x318, 0x72);
    //    this.panel1.TabIndex = 1;
    //    this.label1.Dock = DockStyle.Top;
    //    this.label1.Font = new Font("Microsoft Sans Serif", 72f, FontStyle.Bold, GraphicsUnit.Point, 0);
    //    this.label1.ForeColor = System.Drawing.Color.Red;
    //    this.label1.Location = new Point(0, 0);
    //    this.label1.Name = "label1";
    //    this.label1.Size = new System.Drawing.Size(0x318, 0x72);
    //    this.label1.TabIndex = 1;
    //    this.label1.Text = "MỜI BỆNH NH\x00c2N GIỬ SỐ THỨ TỰ";
    //    this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
    //    this.panel2.Controls.Add(this.lblsotutu);
    //    this.panel2.Dock = DockStyle.Fill;
    //    this.panel2.Location = new Point(0, 0x72);
    //    this.panel2.Name = "panel2";
    //    this.panel2.Size = new System.Drawing.Size(0x318, 0xe3);
    //    this.panel2.TabIndex = 2;
    //    this.lblsotutu.Dock = DockStyle.Fill;
    //    this.lblsotutu.Font = new Font("Microsoft Sans Serif", 159.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
    //    this.lblsotutu.ForeColor = SystemColors.ActiveCaption;
    //    this.lblsotutu.Location = new Point(0, 0);
    //    this.lblsotutu.Name = "lblsotutu";
    //    this.lblsotutu.Size = new System.Drawing.Size(0x318, 0xe3);
    //    this.lblsotutu.TabIndex = 0;
    //    this.lblsotutu.Text = "STT";
    //    this.lblsotutu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
    //    this.panel3.Controls.Add(this.label2);
    //    this.panel3.Dock = DockStyle.Bottom;
    //    this.panel3.Location = new Point(0, 0x155);
    //    this.panel3.Name = "panel3";
    //    this.panel3.Size = new System.Drawing.Size(0x318, 0xe8);
    //    this.panel3.TabIndex = 3;
    //    this.label2.Dock = DockStyle.Bottom;
    //    this.label2.Font = new Font("Microsoft Sans Serif", 72f, FontStyle.Bold, GraphicsUnit.Point, 0);
    //    this.label2.ForeColor = System.Drawing.Color.Red;
    //    this.label2.Location = new Point(0, 0);
    //    this.label2.Name = "label2";
    //    this.label2.Size = new System.Drawing.Size(0x318, 0xe8);
    //    this.label2.TabIndex = 1;
    //    this.label2.Text = "V\x00c0O QUẦY ĐĂNG K\x00dd KH\x00c1M";
    //    this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
    //    base.AutoScaleDimensions = new SizeF(6f, 13f);
    //    base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    //    this.BackColor = System.Drawing.Color.Black;
    //    base.ClientSize = new Size(0x318, 0x23d);
    //    base.ControlBox = false;
    //    base.Controls.Add(this.panel2);
    //    base.Controls.Add(this.panel3);
    //    base.Controls.Add(this.panel1);
    //    base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
    //    base.MaximizeBox = false;
    //    base.MinimizeBox = false;
    //    base.Name = "frmGoibenh";
    //    base.ShowInTaskbar = false;
    //    base.StartPosition = FormStartPosition.CenterScreen;
    //    this.Text = "Gọi bệnh nhân vào lấy mầu";
    //    base.Load += new EventHandler(this.frmGoibenhnhan_Load);
    //    this.panel1.ResumeLayout(false);
    //    this.panel2.ResumeLayout(false);
    //    this.panel3.ResumeLayout(false);
    //    base.ResumeLayout(false);
    //}

    // Properties
    public string s_sohienthi
    {
        set
        {
            this.lblsotutu.Font = new Font("Microsoft Sans Serif", (float) this.s2, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblsotutu.Text = value.ToUpper();
            this.lblsotutu.Update();
        }
    }

    public int sets
    {
        set
        {
            this.s2 = value;
        }
    }
}

 
//Collapse Methods
 

}