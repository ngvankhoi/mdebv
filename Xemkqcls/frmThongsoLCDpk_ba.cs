using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace Medisoft
{
    public class frmThongsoLCDpk_ba : Form
    {
        // Fields
        private Button butCancel;
        private Button butOk;
        private NumericUpDown c286;
        private NumericUpDown c287;
        private NumericUpDown c288;
        private NumericUpDown c289;
        private IContainer components;
        private DataGrid dataGrid3;
        private DataGrid dataGrid4;
        private DataSet ds1 = new DataSet();
        private DataSet ds2 = new DataSet();
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label70;
        private Label label71;
        private Label label72;
        private Label label73;
        private Label label75;
        private Label label76;
        private Label label77;
        private Label label78;
        private Label label79;
        private Label label80;
        private Label lbC01;
        private HScrollBar lbC01_B;
        private HScrollBar lbC01_G;
        private Label lbC01_H;
        private HScrollBar lbC01_R;
        private Label lbC02;
        private HScrollBar lbC02_B;
        private HScrollBar lbC02_G;
        private Label lbC02_H;
        private HScrollBar lbC02_R;
        private TextBox lbC03;
        private HScrollBar lbC03_B;
        private HScrollBar lbC03_G;
        private Label lbC03_H;
        private HScrollBar lbC03_R;
        private TextBox lbC04;
        private HScrollBar lbC04_B;
        private HScrollBar lbC04_G;
        private Label lbC04_H;
        private HScrollBar lbC04_R;
        private LibMedi.AccessData m;
        private NumericUpDown size2;
        private NumericUpDown size3;
        private NumericUpDown c284;
        private Label label1;
        private NumericUpDown size4;

        // Methods
        public frmThongsoLCDpk_ba(LibMedi.AccessData acc)
        {
            this.InitializeComponent();
            this.m = acc;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.m.close();
            GC.Collect();
            base.Close();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            this.upd_tso();
            this.butCancel.Focus();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmThongsoLCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                this.butCancel_Click(sender, e);
            }
        }

        private void frmThongsoLCD_Load(object sender, EventArgs e)
        {
            this.ds1.ReadXml(@"..\..\..\xml\mauLCDpk.xml");
            this.lbC01_R.Value = int.Parse(this.ds1.Tables[0].Rows[0]["r1"].ToString());
            this.lbC01_G.Value = int.Parse(this.ds1.Tables[0].Rows[0]["g1"].ToString());
            this.lbC01_B.Value = int.Parse(this.ds1.Tables[0].Rows[0]["b1"].ToString());
            this.lbC02_R.Value = int.Parse(this.ds1.Tables[0].Rows[0]["r2"].ToString());
            this.lbC02_G.Value = int.Parse(this.ds1.Tables[0].Rows[0]["g2"].ToString());
            this.lbC02_B.Value = int.Parse(this.ds1.Tables[0].Rows[0]["b2"].ToString());
            this.lbC03_R.Value = int.Parse(this.ds1.Tables[0].Rows[0]["r3"].ToString());
            this.lbC03_G.Value = int.Parse(this.ds1.Tables[0].Rows[0]["g3"].ToString());
            this.lbC03_B.Value = int.Parse(this.ds1.Tables[0].Rows[0]["b3"].ToString());
            this.lbC04_R.Value = int.Parse(this.ds1.Tables[0].Rows[0]["r4"].ToString());
            this.lbC04_G.Value = int.Parse(this.ds1.Tables[0].Rows[0]["g4"].ToString());
            this.lbC04_B.Value = int.Parse(this.ds1.Tables[0].Rows[0]["b4"].ToString());
            this.c286.Value = decimal.Parse(this.ds1.Tables[0].Rows[0]["x"].ToString());
            this.c287.Value = decimal.Parse(this.ds1.Tables[0].Rows[0]["y"].ToString());
            this.c288.Value = decimal.Parse(this.ds1.Tables[0].Rows[0]["w"].ToString());
            this.c289.Value = decimal.Parse(this.ds1.Tables[0].Rows[0]["h"].ToString());
            this.size2.Value = decimal.Parse(this.ds1.Tables[0].Rows[0]["s2"].ToString());
            this.size3.Value = decimal.Parse(this.ds1.Tables[0].Rows[0]["s3"].ToString());
            this.size4.Value = decimal.Parse(this.ds1.Tables[0].Rows[0]["s4"].ToString());
            this.lbC03.Text = this.ds1.Tables[0].Rows[0]["nd3"].ToString();
            this.lbC04.Text = this.ds1.Tables[0].Rows[0]["nd4"].ToString();
            this.getcolor();

            //
            this.ds2.ReadXml(@"..\..\..\xml\mau.xml");
            lbC01_R.Value=int.Parse(ds2.Tables[0].Rows[0]["r1"].ToString());
            lbC01_G.Value=int.Parse(ds2.Tables[0].Rows[0]["g1"].ToString());
            lbC01_B.Value=int.Parse(ds2.Tables[0].Rows[0]["b1"].ToString());
            lbC02_R.Value=int.Parse(ds2.Tables[0].Rows[0]["r2"].ToString());
            lbC02_G.Value=int.Parse(ds2.Tables[0].Rows[0]["g2"].ToString());
            lbC02_B.Value=int.Parse(ds2.Tables[0].Rows[0]["b2"].ToString());
            c286.Value=decimal.Parse(ds2.Tables[0].Rows[0]["x"].ToString());
            c287.Value=decimal.Parse(ds2.Tables[0].Rows[0]["y"].ToString());
            c288.Value=decimal.Parse(ds2.Tables[0].Rows[0]["w"].ToString());
            c289.Value=decimal.Parse(ds2.Tables[0].Rows[0]["h"].ToString());
            //c290.Value=decimal.Parse(ds2.Tables[0].Rows[0]["s"].ToString());// bổ sung sau
            c284.Value=decimal.Parse(ds2.Tables[0].Rows[0]["delay"].ToString());
            ds2.WriteXml("..\\..\\..\\xml\\mau.xml");
            //
        }

        private void getcolor()
        {
            try
            {
                this.lbC01.BackColor = System.Drawing.Color.FromArgb(this.lbC01_R.Value, this.lbC01_G.Value, this.lbC01_B.Value);
                this.lbC02.BackColor = System.Drawing.Color.FromArgb(this.lbC01_R.Value, this.lbC01_G.Value, this.lbC01_B.Value);
                this.lbC03.BackColor = System.Drawing.Color.FromArgb(this.lbC01_R.Value, this.lbC01_G.Value, this.lbC01_B.Value);
                this.lbC04.BackColor = System.Drawing.Color.FromArgb(this.lbC01_R.Value, this.lbC01_G.Value, this.lbC01_B.Value);
                this.lbC01_H.BackColor = System.Drawing.Color.FromArgb(this.lbC01_R.Value, this.lbC01_G.Value, this.lbC01_B.Value);
                this.lbC02_H.BackColor = System.Drawing.Color.FromArgb(this.lbC01_R.Value, this.lbC01_G.Value, this.lbC01_B.Value);
                this.lbC03_H.BackColor = System.Drawing.Color.FromArgb(this.lbC01_R.Value, this.lbC01_G.Value, this.lbC01_B.Value);
                this.lbC04_H.BackColor = System.Drawing.Color.FromArgb(this.lbC01_R.Value, this.lbC01_G.Value, this.lbC01_B.Value);
                this.lbC01.ForeColor = System.Drawing.Color.FromArgb(this.lbC02_R.Value, this.lbC02_G.Value, this.lbC02_B.Value);
                this.lbC02.ForeColor = System.Drawing.Color.FromArgb(this.lbC02_R.Value, this.lbC02_G.Value, this.lbC02_B.Value);
                this.lbC03.ForeColor = System.Drawing.Color.FromArgb(this.lbC03_R.Value, this.lbC03_G.Value, this.lbC03_B.Value);
                this.lbC04.ForeColor = System.Drawing.Color.FromArgb(this.lbC04_R.Value, this.lbC04_G.Value, this.lbC04_B.Value);
                this.lbC01_H.ForeColor = System.Drawing.Color.FromArgb(this.lbC02_R.Value, this.lbC02_G.Value, this.lbC02_B.Value);
                this.lbC02_H.ForeColor = System.Drawing.Color.FromArgb(this.lbC02_R.Value, this.lbC02_G.Value, this.lbC02_B.Value);
                this.lbC03_H.ForeColor = System.Drawing.Color.FromArgb(this.lbC03_R.Value, this.lbC03_G.Value, this.lbC03_B.Value);
                this.lbC04_H.ForeColor = System.Drawing.Color.FromArgb(this.lbC04_R.Value, this.lbC04_G.Value, this.lbC04_B.Value);
                this.lbC01_H.Text = "(" + this.lbC01_R.Value.ToString() + ", " + this.lbC01_G.Value.ToString() + "," + this.lbC01_B.Value.ToString() + ")";
                this.lbC02_H.Text = "(" + this.lbC02_R.Value.ToString() + ", " + this.lbC02_G.Value.ToString() + "," + this.lbC02_B.Value.ToString() + ")";
                this.lbC03_H.Text = "(" + this.lbC03_R.Value.ToString() + ", " + this.lbC03_G.Value.ToString() + "," + this.lbC03_B.Value.ToString() + ")";
                this.lbC04_H.Text = "(" + this.lbC04_R.Value.ToString() + ", " + this.lbC04_G.Value.ToString() + "," + this.lbC04_B.Value.ToString() + ")";
            }
            catch
            {
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongsoLCDpk_ba));
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.dataGrid4 = new System.Windows.Forms.DataGrid();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.size2 = new System.Windows.Forms.NumericUpDown();
            this.lbC02_H = new System.Windows.Forms.Label();
            this.lbC01_H = new System.Windows.Forms.Label();
            this.lbC02_B = new System.Windows.Forms.HScrollBar();
            this.lbC02_G = new System.Windows.Forms.HScrollBar();
            this.lbC02_R = new System.Windows.Forms.HScrollBar();
            this.lbC01_B = new System.Windows.Forms.HScrollBar();
            this.lbC01_G = new System.Windows.Forms.HScrollBar();
            this.lbC02 = new System.Windows.Forms.Label();
            this.lbC01_R = new System.Windows.Forms.HScrollBar();
            this.lbC01 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.c287 = new System.Windows.Forms.NumericUpDown();
            this.label70 = new System.Windows.Forms.Label();
            this.c289 = new System.Windows.Forms.NumericUpDown();
            this.label71 = new System.Windows.Forms.Label();
            this.c288 = new System.Windows.Forms.NumericUpDown();
            this.label72 = new System.Windows.Forms.Label();
            this.c286 = new System.Windows.Forms.NumericUpDown();
            this.label73 = new System.Windows.Forms.Label();
            this.size3 = new System.Windows.Forms.NumericUpDown();
            this.lbC03_H = new System.Windows.Forms.Label();
            this.lbC03_B = new System.Windows.Forms.HScrollBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbC03_G = new System.Windows.Forms.HScrollBar();
            this.label4 = new System.Windows.Forms.Label();
            this.lbC03_R = new System.Windows.Forms.HScrollBar();
            this.lbC03 = new System.Windows.Forms.TextBox();
            this.size4 = new System.Windows.Forms.NumericUpDown();
            this.lbC04_H = new System.Windows.Forms.Label();
            this.lbC04_B = new System.Windows.Forms.HScrollBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbC04_G = new System.Windows.Forms.HScrollBar();
            this.label7 = new System.Windows.Forms.Label();
            this.lbC04_R = new System.Windows.Forms.HScrollBar();
            this.lbC04 = new System.Windows.Forms.TextBox();
            this.c284 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.size2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c287)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c289)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c288)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c286)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.size3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.size4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c284)).BeginInit();
            this.SuspendLayout();
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(168, 421);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 54;
            this.butOk.Text = "     &Lưu";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(241, 421);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 55;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // dataGrid4
            // 
            this.dataGrid4.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid4.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid4.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid4.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid4.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid4.CaptionText = "Giờ làm thêm";
            this.dataGrid4.DataMember = "";
            this.dataGrid4.FlatMode = true;
            this.dataGrid4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid4.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid4.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid4.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid4.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid4.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid4.Location = new System.Drawing.Point(840, 152);
            this.dataGrid4.Name = "dataGrid4";
            this.dataGrid4.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid4.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid4.ReadOnly = true;
            this.dataGrid4.RowHeaderWidth = 10;
            this.dataGrid4.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid4.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid4.Size = new System.Drawing.Size(104, 80);
            this.dataGrid4.TabIndex = 21;
            this.dataGrid4.Visible = false;
            // 
            // dataGrid3
            // 
            this.dataGrid3.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid3.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid3.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid3.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid3.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid3.CaptionText = "Giờ chấm công";
            this.dataGrid3.DataMember = "";
            this.dataGrid3.FlatMode = true;
            this.dataGrid3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid3.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid3.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid3.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid3.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid3.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid3.Location = new System.Drawing.Point(848, 64);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid3.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid3.ReadOnly = true;
            this.dataGrid3.RowHeaderWidth = 10;
            this.dataGrid3.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid3.Size = new System.Drawing.Size(104, 80);
            this.dataGrid3.TabIndex = 20;
            this.dataGrid3.Visible = false;
            // 
            // size2
            // 
            this.size2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.size2.Location = new System.Drawing.Point(478, 32);
            this.size2.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.size2.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.size2.Name = "size2";
            this.size2.Size = new System.Drawing.Size(51, 21);
            this.size2.TabIndex = 299;
            this.size2.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // lbC02_H
            // 
            this.lbC02_H.BackColor = System.Drawing.Color.Black;
            this.lbC02_H.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbC02_H.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbC02_H.ForeColor = System.Drawing.Color.White;
            this.lbC02_H.Location = new System.Drawing.Point(171, 134);
            this.lbC02_H.Name = "lbC02_H";
            this.lbC02_H.Size = new System.Drawing.Size(358, 23);
            this.lbC02_H.TabIndex = 297;
            this.lbC02_H.Text = "Màu 02:";
            this.lbC02_H.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbC01_H
            // 
            this.lbC01_H.BackColor = System.Drawing.Color.Black;
            this.lbC01_H.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbC01_H.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbC01_H.ForeColor = System.Drawing.Color.White;
            this.lbC01_H.Location = new System.Drawing.Point(12, 134);
            this.lbC01_H.Name = "lbC01_H";
            this.lbC01_H.Size = new System.Drawing.Size(152, 23);
            this.lbC01_H.TabIndex = 296;
            this.lbC01_H.Text = "Màu 01:";
            this.lbC01_H.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbC02_B
            // 
            this.lbC02_B.Location = new System.Drawing.Point(186, 107);
            this.lbC02_B.Maximum = 255;
            this.lbC02_B.Name = "lbC02_B";
            this.lbC02_B.Size = new System.Drawing.Size(343, 24);
            this.lbC02_B.TabIndex = 295;
            this.lbC02_B.ValueChanged += new System.EventHandler(this.lbC01_R_ValueChanged);
            // 
            // lbC02_G
            // 
            this.lbC02_G.Location = new System.Drawing.Point(186, 82);
            this.lbC02_G.Maximum = 255;
            this.lbC02_G.Name = "lbC02_G";
            this.lbC02_G.Size = new System.Drawing.Size(343, 24);
            this.lbC02_G.TabIndex = 294;
            this.lbC02_G.ValueChanged += new System.EventHandler(this.lbC01_R_ValueChanged);
            // 
            // lbC02_R
            // 
            this.lbC02_R.Location = new System.Drawing.Point(186, 56);
            this.lbC02_R.Maximum = 255;
            this.lbC02_R.Name = "lbC02_R";
            this.lbC02_R.Size = new System.Drawing.Size(343, 24);
            this.lbC02_R.TabIndex = 291;
            this.lbC02_R.ValueChanged += new System.EventHandler(this.lbC01_R_ValueChanged);
            // 
            // lbC01_B
            // 
            this.lbC01_B.Location = new System.Drawing.Point(28, 107);
            this.lbC01_B.Maximum = 255;
            this.lbC01_B.Name = "lbC01_B";
            this.lbC01_B.Size = new System.Drawing.Size(136, 24);
            this.lbC01_B.TabIndex = 289;
            this.lbC01_B.ValueChanged += new System.EventHandler(this.lbC01_R_ValueChanged);
            // 
            // lbC01_G
            // 
            this.lbC01_G.Location = new System.Drawing.Point(28, 82);
            this.lbC01_G.Maximum = 255;
            this.lbC01_G.Name = "lbC01_G";
            this.lbC01_G.Size = new System.Drawing.Size(136, 24);
            this.lbC01_G.TabIndex = 288;
            this.lbC01_G.ValueChanged += new System.EventHandler(this.lbC01_R_ValueChanged);
            // 
            // lbC02
            // 
            this.lbC02.BackColor = System.Drawing.Color.Black;
            this.lbC02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbC02.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbC02.ForeColor = System.Drawing.Color.White;
            this.lbC02.Location = new System.Drawing.Point(171, 31);
            this.lbC02.Name = "lbC02";
            this.lbC02.Size = new System.Drawing.Size(358, 23);
            this.lbC02.TabIndex = 287;
            this.lbC02.Text = "Màu chữ số thứ tự,Font Size :";
            this.lbC02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbC01_R
            // 
            this.lbC01_R.Location = new System.Drawing.Point(28, 56);
            this.lbC01_R.Maximum = 255;
            this.lbC01_R.Name = "lbC01_R";
            this.lbC01_R.Size = new System.Drawing.Size(136, 24);
            this.lbC01_R.TabIndex = 284;
            this.lbC01_R.ValueChanged += new System.EventHandler(this.lbC01_R_ValueChanged);
            // 
            // lbC01
            // 
            this.lbC01.BackColor = System.Drawing.Color.Black;
            this.lbC01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbC01.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbC01.ForeColor = System.Drawing.Color.White;
            this.lbC01.Location = new System.Drawing.Point(12, 31);
            this.lbC01.Name = "lbC01";
            this.lbC01.Size = new System.Drawing.Size(152, 23);
            this.lbC01.TabIndex = 282;
            this.lbC01.Text = "Màu nền";
            this.lbC01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.BackColor = System.Drawing.Color.Transparent;
            this.label75.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.ForeColor = System.Drawing.Color.Blue;
            this.label75.Location = new System.Drawing.Point(168, 113);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(15, 13);
            this.label75.TabIndex = 293;
            this.label75.Text = "B";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.BackColor = System.Drawing.Color.Transparent;
            this.label76.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.ForeColor = System.Drawing.Color.Lime;
            this.label76.Location = new System.Drawing.Point(168, 88);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(16, 13);
            this.label76.TabIndex = 292;
            this.label76.Text = "G";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.BackColor = System.Drawing.Color.Transparent;
            this.label77.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.ForeColor = System.Drawing.Color.Red;
            this.label77.Location = new System.Drawing.Point(168, 59);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(16, 13);
            this.label77.TabIndex = 290;
            this.label77.Text = "R";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.BackColor = System.Drawing.Color.Transparent;
            this.label78.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label78.ForeColor = System.Drawing.Color.Blue;
            this.label78.Location = new System.Drawing.Point(14, 113);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(15, 13);
            this.label78.TabIndex = 286;
            this.label78.Text = "B";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.BackColor = System.Drawing.Color.Transparent;
            this.label79.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label79.ForeColor = System.Drawing.Color.Lime;
            this.label79.Location = new System.Drawing.Point(14, 88);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(16, 13);
            this.label79.TabIndex = 285;
            this.label79.Text = "G";
            this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.BackColor = System.Drawing.Color.Transparent;
            this.label80.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label80.ForeColor = System.Drawing.Color.Red;
            this.label80.Location = new System.Drawing.Point(14, 59);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(16, 13);
            this.label80.TabIndex = 283;
            this.label80.Text = "R";
            this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c287
            // 
            this.c287.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c287.Location = new System.Drawing.Point(177, 4);
            this.c287.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.c287.Name = "c287";
            this.c287.Size = new System.Drawing.Size(50, 21);
            this.c287.TabIndex = 275;
            this.c287.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label70
            // 
            this.label70.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label70.Location = new System.Drawing.Point(112, 5);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(66, 18);
            this.label70.TabIndex = 274;
            this.label70.Text = "Tọa độ Y :";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c289
            // 
            this.c289.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c289.Location = new System.Drawing.Point(372, 4);
            this.c289.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.c289.Name = "c289";
            this.c289.Size = new System.Drawing.Size(51, 21);
            this.c289.TabIndex = 279;
            this.c289.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label71
            // 
            this.label71.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label71.Location = new System.Drawing.Point(316, 5);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(57, 18);
            this.label71.TabIndex = 278;
            this.label71.Text = "Height :";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c288
            // 
            this.c288.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c288.Location = new System.Drawing.Point(278, 4);
            this.c288.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.c288.Name = "c288";
            this.c288.Size = new System.Drawing.Size(50, 21);
            this.c288.TabIndex = 277;
            this.c288.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label72
            // 
            this.label72.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label72.Location = new System.Drawing.Point(230, 5);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(45, 18);
            this.label72.TabIndex = 276;
            this.label72.Text = "Width :";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c286
            // 
            this.c286.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c286.Location = new System.Drawing.Point(57, 4);
            this.c286.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.c286.Name = "c286";
            this.c286.Size = new System.Drawing.Size(64, 21);
            this.c286.TabIndex = 273;
            this.c286.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label73
            // 
            this.label73.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label73.Location = new System.Drawing.Point(-63, 5);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(121, 18);
            this.label73.TabIndex = 272;
            this.label73.Text = "Tọa độ X :";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // size3
            // 
            this.size3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.size3.Location = new System.Drawing.Point(478, 161);
            this.size3.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.size3.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.size3.Name = "size3";
            this.size3.Size = new System.Drawing.Size(51, 21);
            this.size3.TabIndex = 308;
            this.size3.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // lbC03_H
            // 
            this.lbC03_H.BackColor = System.Drawing.Color.Black;
            this.lbC03_H.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbC03_H.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbC03_H.ForeColor = System.Drawing.Color.White;
            this.lbC03_H.Location = new System.Drawing.Point(12, 265);
            this.lbC03_H.Name = "lbC03_H";
            this.lbC03_H.Size = new System.Drawing.Size(517, 23);
            this.lbC03_H.TabIndex = 307;
            this.lbC03_H.Text = "Màu 03:";
            this.lbC03_H.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbC03_B
            // 
            this.lbC03_B.Location = new System.Drawing.Point(27, 237);
            this.lbC03_B.Maximum = 255;
            this.lbC03_B.Name = "lbC03_B";
            this.lbC03_B.Size = new System.Drawing.Size(502, 24);
            this.lbC03_B.TabIndex = 306;
            this.lbC03_B.ValueChanged += new System.EventHandler(this.lbC01_R_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(9, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 304;
            this.label2.Text = "B";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(9, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 303;
            this.label3.Text = "G";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbC03_G
            // 
            this.lbC03_G.Location = new System.Drawing.Point(27, 212);
            this.lbC03_G.Maximum = 255;
            this.lbC03_G.Name = "lbC03_G";
            this.lbC03_G.Size = new System.Drawing.Size(502, 24);
            this.lbC03_G.TabIndex = 305;
            this.lbC03_G.ValueChanged += new System.EventHandler(this.lbC01_R_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(9, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 301;
            this.label4.Text = "R";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbC03_R
            // 
            this.lbC03_R.Location = new System.Drawing.Point(27, 186);
            this.lbC03_R.Maximum = 255;
            this.lbC03_R.Name = "lbC03_R";
            this.lbC03_R.Size = new System.Drawing.Size(502, 24);
            this.lbC03_R.TabIndex = 302;
            this.lbC03_R.ValueChanged += new System.EventHandler(this.lbC01_R_ValueChanged);
            // 
            // lbC03
            // 
            this.lbC03.BackColor = System.Drawing.Color.Black;
            this.lbC03.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbC03.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbC03.Location = new System.Drawing.Point(12, 160);
            this.lbC03.Name = "lbC03";
            this.lbC03.Size = new System.Drawing.Size(517, 22);
            this.lbC03.TabIndex = 309;
            this.lbC03.Text = "Mời";
            this.lbC03.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // size4
            // 
            this.size4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.size4.Location = new System.Drawing.Point(478, 291);
            this.size4.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.size4.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.size4.Name = "size4";
            this.size4.Size = new System.Drawing.Size(51, 21);
            this.size4.TabIndex = 317;
            this.size4.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // lbC04_H
            // 
            this.lbC04_H.BackColor = System.Drawing.Color.Black;
            this.lbC04_H.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbC04_H.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbC04_H.ForeColor = System.Drawing.Color.White;
            this.lbC04_H.Location = new System.Drawing.Point(12, 395);
            this.lbC04_H.Name = "lbC04_H";
            this.lbC04_H.Size = new System.Drawing.Size(517, 23);
            this.lbC04_H.TabIndex = 316;
            this.lbC04_H.Text = "Màu 04:";
            this.lbC04_H.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbC04_B
            // 
            this.lbC04_B.Location = new System.Drawing.Point(27, 367);
            this.lbC04_B.Maximum = 255;
            this.lbC04_B.Name = "lbC04_B";
            this.lbC04_B.Size = new System.Drawing.Size(502, 24);
            this.lbC04_B.TabIndex = 315;
            this.lbC04_B.ValueChanged += new System.EventHandler(this.lbC01_R_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(9, 373);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 313;
            this.label5.Text = "B";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Lime;
            this.label6.Location = new System.Drawing.Point(9, 348);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 312;
            this.label6.Text = "G";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbC04_G
            // 
            this.lbC04_G.Location = new System.Drawing.Point(27, 342);
            this.lbC04_G.Maximum = 255;
            this.lbC04_G.Name = "lbC04_G";
            this.lbC04_G.Size = new System.Drawing.Size(502, 24);
            this.lbC04_G.TabIndex = 314;
            this.lbC04_G.ValueChanged += new System.EventHandler(this.lbC01_R_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(9, 319);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 310;
            this.label7.Text = "R";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbC04_R
            // 
            this.lbC04_R.Location = new System.Drawing.Point(27, 316);
            this.lbC04_R.Maximum = 255;
            this.lbC04_R.Name = "lbC04_R";
            this.lbC04_R.Size = new System.Drawing.Size(502, 24);
            this.lbC04_R.TabIndex = 311;
            this.lbC04_R.ValueChanged += new System.EventHandler(this.lbC01_R_ValueChanged);
            // 
            // lbC04
            // 
            this.lbC04.BackColor = System.Drawing.Color.Black;
            this.lbC04.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbC04.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbC04.Location = new System.Drawing.Point(12, 290);
            this.lbC04.Name = "lbC04";
            this.lbC04.Size = new System.Drawing.Size(517, 22);
            this.lbC04.TabIndex = 318;
            this.lbC04.Text = "Vào quầy đăng ký khám";
            this.lbC04.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // c284
            // 
            this.c284.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c284.Location = new System.Drawing.Point(479, 5);
            this.c284.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.c284.Name = "c284";
            this.c284.Size = new System.Drawing.Size(50, 21);
            this.c284.TabIndex = 320;
            this.c284.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(431, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
            this.label1.TabIndex = 319;
            this.label1.Text = "Delay :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmThongsoLCDpk_ba
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(531, 456);
            this.Controls.Add(this.c284);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.size4);
            this.Controls.Add(this.lbC04_H);
            this.Controls.Add(this.lbC04_B);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbC04_G);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbC04_R);
            this.Controls.Add(this.lbC04);
            this.Controls.Add(this.size3);
            this.Controls.Add(this.lbC03_H);
            this.Controls.Add(this.lbC03_B);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbC03_G);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbC03_R);
            this.Controls.Add(this.size2);
            this.Controls.Add(this.lbC02_H);
            this.Controls.Add(this.lbC02_B);
            this.Controls.Add(this.label75);
            this.Controls.Add(this.label76);
            this.Controls.Add(this.lbC02_G);
            this.Controls.Add(this.label77);
            this.Controls.Add(this.label80);
            this.Controls.Add(this.lbC02_R);
            this.Controls.Add(this.lbC01_B);
            this.Controls.Add(this.lbC01_G);
            this.Controls.Add(this.lbC02);
            this.Controls.Add(this.lbC01_H);
            this.Controls.Add(this.lbC01_R);
            this.Controls.Add(this.label78);
            this.Controls.Add(this.lbC01);
            this.Controls.Add(this.label79);
            this.Controls.Add(this.c288);
            this.Controls.Add(this.c289);
            this.Controls.Add(this.label71);
            this.Controls.Add(this.c286);
            this.Controls.Add(this.label72);
            this.Controls.Add(this.c287);
            this.Controls.Add(this.label70);
            this.Controls.Add(this.label73);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.dataGrid3);
            this.Controls.Add(this.dataGrid4);
            this.Controls.Add(this.lbC03);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmThongsoLCDpk_ba";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khai báo thông số LCD phòng khám";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmThongsoLCD_KeyDown);
            this.Load += new System.EventHandler(this.frmThongsoLCD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.size2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c287)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c289)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c288)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c286)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.size3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.size4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c284)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void lbC01_R_ValueChanged(object sender, EventArgs e)
        {
            this.getcolor();
        }

        private void upd_tso()
        {
            this.ds1.Tables[0].Rows[0]["r1"] = this.lbC01_R.Value.ToString();
            this.ds1.Tables[0].Rows[0]["g1"] = this.lbC01_G.Value.ToString();
            this.ds1.Tables[0].Rows[0]["b1"] = this.lbC01_B.Value.ToString();
            this.ds1.Tables[0].Rows[0]["r2"] = this.lbC02_R.Value.ToString();
            this.ds1.Tables[0].Rows[0]["g2"] = this.lbC02_G.Value.ToString();
            this.ds1.Tables[0].Rows[0]["b2"] = this.lbC02_B.Value.ToString();
            this.ds1.Tables[0].Rows[0]["r3"] = this.lbC03_R.Value.ToString();
            this.ds1.Tables[0].Rows[0]["g3"] = this.lbC03_G.Value.ToString();
            this.ds1.Tables[0].Rows[0]["b3"] = this.lbC03_B.Value.ToString();
            this.ds1.Tables[0].Rows[0]["r4"] = this.lbC04_R.Value.ToString();
            this.ds1.Tables[0].Rows[0]["g4"] = this.lbC04_G.Value.ToString();
            this.ds1.Tables[0].Rows[0]["b4"] = this.lbC04_B.Value.ToString();
            this.ds1.Tables[0].Rows[0]["x"] = this.c286.Value;
            this.ds1.Tables[0].Rows[0]["y"] = this.c287.Value;
            this.ds1.Tables[0].Rows[0]["w"] = this.c288.Value;
            this.ds1.Tables[0].Rows[0]["h"] = this.c289.Value;
            this.ds1.Tables[0].Rows[0]["s2"] = this.size2.Value;
            this.ds1.Tables[0].Rows[0]["s3"] = this.size3.Value;
            this.ds1.Tables[0].Rows[0]["s4"] = this.size4.Value;
            this.ds1.Tables[0].Rows[0]["nd3"] = this.lbC03.Text;
            this.ds1.Tables[0].Rows[0]["nd4"] = this.lbC04.Text;
            this.ds1.WriteXml(@"..\..\..\xml\mauLCDpk.xml");

            //
            //ds2.Tables[0].Rows[0]["r1"] = lbC01_R.Value.ToString();
            //ds2.Tables[0].Rows[0]["g1"] = lbC01_G.Value.ToString();
            //ds2.Tables[0].Rows[0]["b1"] = lbC01_B.Value.ToString();
            //ds2.Tables[0].Rows[0]["r2"] = lbC02_R.Value.ToString();
            //ds2.Tables[0].Rows[0]["g2"] = lbC02_G.Value.ToString();
            //ds2.Tables[0].Rows[0]["b2"] = lbC02_B.Value.ToString();
            //ds2.Tables[0].Rows[0]["x"] = c286.Value;
            //ds2.Tables[0].Rows[0]["y"] = c287.Value;
            //ds2.Tables[0].Rows[0]["w"] = c288.Value;
            //ds2.Tables[0].Rows[0]["h"] = c289.Value;
            ////ds2.Tables[0].Rows[0]["s"] = c290.Value; //bổ sung sau
            ds2 = ds1.Copy();
            ds2.Tables[0].Rows[0]["delay"] = c284.Value;
            ds2.WriteXml("..\\..\\..\\xml\\mau.xml");
        }
    }
}