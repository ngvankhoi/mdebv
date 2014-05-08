﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;
using LibVienphi;
 
namespace Medisoft
{
	/// <summary>
	/// Summary description for frmRavien.
	/// </summary>
	public class frmChuyenpk_theochinhanh : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butTiep;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butExit;
		private DataSet ds=new DataSet();
		private DataSet dsngay=new DataSet();
		private DataTable dtkp_cnnguon=new DataTable();
        private DataTable dtkp_cndich = new DataTable();
        private LibMedi.AccessData m = new LibMedi.AccessData();
        private DataTable dtCNHienTai;
        private DataTable dtCNDich;
        private int i_IDChiNhanh = 0;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private DataRow r;
		private string user,s_makp,sql,dblschema ="";
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butSua;
		private CurrencyManager objStudentCM;
		private DataGridTableStyle ts;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox tenkp;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.Label lblso;
        private bool bInkhambenh, bDanhsach;
        private int loai = 2, i_userid = 0, i_sokham = 3;
        private int i_chinhanh = 0;
        private ComboBox cmbChiNhanhDich;
        private Label label2;
        private ComboBox cmbChiNhanhHienTai;
        private ComboBox cmbTenkp_hientai;
        private TextBox makp_hientai;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChuyenpk_theochinhanh(LibMedi.AccessData acc,string makp,int userid, int _chinhanh)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_makp = makp; i_userid = userid; if (m.bBogo) tv.GanBogo(this, textBox111);
            i_chinhanh = _chinhanh;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChuyenpk_theochinhanh));
            this.butTiep = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butSua = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tenkp = new System.Windows.Forms.ComboBox();
            this.makp = new System.Windows.Forms.TextBox();
            this.lblso = new System.Windows.Forms.Label();
            this.cmbChiNhanhDich = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbChiNhanhHienTai = new System.Windows.Forms.ComboBox();
            this.cmbTenkp_hientai = new System.Windows.Forms.ComboBox();
            this.makp_hientai = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // butTiep
            // 
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(236, 496);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(70, 25);
            this.butTiep.TabIndex = 5;
            this.butTiep.Text = "    &Tiếp";
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(306, 496);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 3;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(446, 496);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 4;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butExit
            // 
            this.butExit.Image = ((System.Drawing.Image)(resources.GetObject("butExit.Image")));
            this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExit.Location = new System.Drawing.Point(516, 496);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(70, 25);
            this.butExit.TabIndex = 6;
            this.butExit.Text = "&Kết thúc";
            this.butExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(8, 10);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 478);
            this.dataGrid1.TabIndex = 34;
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(376, 496);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 2;
            this.butSua.Text = "&Chuyển";
            this.butSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(384, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 35;
            this.label1.Text = "Phòng khám :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(505, 4);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(199, 21);
            this.tenkp.TabIndex = 1;
            this.tenkp.SelectedIndexChanged += new System.EventHandler(this.tenkp_SelectedIndexChanged);
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(463, 4);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(36, 21);
            this.makp.TabIndex = 0;
            this.makp.Validated += new System.EventHandler(this.makp_Validated);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // lblso
            // 
            this.lblso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblso.ForeColor = System.Drawing.Color.Red;
            this.lblso.Location = new System.Drawing.Point(720, 4);
            this.lblso.Name = "lblso";
            this.lblso.Size = new System.Drawing.Size(64, 23);
            this.lblso.TabIndex = 38;
            this.lblso.Text = "lblso";
            this.lblso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbChiNhanhDich
            // 
            this.cmbChiNhanhDich.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChiNhanhDich.FormattingEnabled = true;
            this.cmbChiNhanhDich.Location = new System.Drawing.Point(136, 4);
            this.cmbChiNhanhDich.Name = "cmbChiNhanhDich";
            this.cmbChiNhanhDich.Size = new System.Drawing.Size(199, 21);
            this.cmbChiNhanhDich.TabIndex = 39;
            this.cmbChiNhanhDich.SelectedIndexChanged += new System.EventHandler(this.cmbChiNhanhDich_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 23);
            this.label2.TabIndex = 40;
            this.label2.Text = "Chi nhánh chuyển đến:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbChiNhanhHienTai
            // 
            this.cmbChiNhanhHienTai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChiNhanhHienTai.Enabled = false;
            this.cmbChiNhanhHienTai.FormattingEnabled = true;
            this.cmbChiNhanhHienTai.Location = new System.Drawing.Point(297, 276);
            this.cmbChiNhanhHienTai.Name = "cmbChiNhanhHienTai";
            this.cmbChiNhanhHienTai.Size = new System.Drawing.Size(199, 21);
            this.cmbChiNhanhHienTai.TabIndex = 41;
            this.cmbChiNhanhHienTai.Visible = false;
            // 
            // cmbTenkp_hientai
            // 
            this.cmbTenkp_hientai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbTenkp_hientai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTenkp_hientai.Enabled = false;
            this.cmbTenkp_hientai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTenkp_hientai.Location = new System.Drawing.Point(516, 161);
            this.cmbTenkp_hientai.Name = "cmbTenkp_hientai";
            this.cmbTenkp_hientai.Size = new System.Drawing.Size(224, 21);
            this.cmbTenkp_hientai.TabIndex = 42;
            this.cmbTenkp_hientai.Visible = false;
            this.cmbTenkp_hientai.SelectedIndexChanged += new System.EventHandler(this.cmbTenkp_hientai_SelectedIndexChanged);
            this.cmbTenkp_hientai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTenkp_hientai_KeyDown);
            // 
            // makp_hientai
            // 
            this.makp_hientai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp_hientai.Enabled = false;
            this.makp_hientai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp_hientai.Location = new System.Drawing.Point(470, 161);
            this.makp_hientai.Name = "makp_hientai";
            this.makp_hientai.Size = new System.Drawing.Size(40, 21);
            this.makp_hientai.TabIndex = 43;
            this.makp_hientai.Visible = false;
            this.makp_hientai.Validated += new System.EventHandler(this.makp_hientai_Validated);
            // 
            // frmChuyenpk_theochinhanh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.makp_hientai);
            this.Controls.Add(this.cmbTenkp_hientai);
            this.Controls.Add(this.cmbChiNhanhHienTai);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbChiNhanhDich);
            this.Controls.Add(this.lblso);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butTiep);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChuyenpk_theochinhanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển phòng khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmChuyenpk_theochinhanh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void ena_but(bool ena)
		{
			makp.Enabled=!ena;
			tenkp.Enabled=!ena;
			butTiep.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butExit.Enabled=!ena;
		}

		private void butTiep_Click(object sender, System.EventArgs e)
		{
			ds.Clear();
			ena_but(true);
			makp.Focus();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
            string ngay=m.ngayhienhanh_server,xxx=user+m.mmyy(ngay);
            int itable = m.tableid(m.mmyy(ngay), "tiepdon");
            string sokham = "0"; ;
			foreach(DataRow r1 in ds.Tables[0].Select("tenkpcu<>tenkp"))
			{
				r=d.getrowbyid(dtkp_cnnguon,"tenkp='"+r1["tenkp"].ToString()+"'");
				if (r!=null)
				{
                    if (r1["done"].ToString().Trim() != "")
                    {
                        sql = "update " + xxx + ".benhanpk set makp='" + r["makp"].ToString() + "' where mavaovien=" + decimal.Parse(r1["mavaovien"].ToString()) + " and mabn= '" + r1["mabn"].ToString() + "' and makp= '" + r["makp"].ToString() + "'";
                        m.execute_data(sql);
                        sql = "update " + xxx + ".v_chidinh set makp='" + r["makp"].ToString() + "' where mavaovien=" + decimal.Parse(r1["mavaovien"].ToString()) + " and mabn= '" + r1["mabn"].ToString() + "' and makp= '" + r["makp"].ToString() + "'";
                        m.execute_data(sql);

                    }

					sql="update "+xxx+".tiepdon set makp='"+r["makp"].ToString()+"' where maql="+decimal.Parse(r1["maql"].ToString());
					m.execute_data(sql);
                    if (bInkhambenh)
                    {
                        sql = "update " + xxx + ".v_vienphill set makp='" + r["makp"].ToString() + "',makptd='"+makp.Text+"' where maql=" + decimal.Parse(r1["maql"].ToString());
                        sql += " and makp='" + makp.Text + "' and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + r1["ngay"].ToString() + "'";
                        sql += " and loaibn=" + loai;
                        m.execute_data(sql);
                    }
                    else if (bDanhsach)
                    {
                        sql = "update " + xxx + ".v_vienphill set makp='" + r["makp"].ToString() + "',makptd='" + makp.Text + "' where maql=" + decimal.Parse(r1["maql"].ToString());
                        sql += " and makp='" + makp.Text + "'";// and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + r1["ngay"].ToString() + "'";
                        sql += " and loaibn=0";// +loai;
                        m.execute_data(sql);

                        sql = "update " + xxx + ".v_chidinh set makp='" + r["makp"].ToString() + "' where maql=" + decimal.Parse(r1["maql"].ToString());
                        sql += " and makp='" + makp.Text + "' and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + r1["ngay"].ToString() + "'";
                        sql += " and loai=" + loai;
                        m.execute_data(sql);

                        sql = "update " + xxx + ".v_ttrvll set makp='" + r["makp"].ToString() + "' where id in(";
                        sql += " select id from " + xxx + ".v_ttrvds where maql=" + decimal.Parse(r1["maql"].ToString());
                        sql += ")";
                        sql += " and makp='" + makp.Text + "'";// and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + r1["ngay"].ToString() + "'";
                        sql += " and loaibn=0";// +loai;
                        m.execute_data(sql);

                        sql = "update " + xxx + ".v_ttrvct set makp='" + r["makp"].ToString() + "' where id in(";
                        sql += " select a.id from " + xxx + ".v_ttrvds a inner join " + xxx + ".v_ttrvll b on a.id=b.id where a.maql=" + decimal.Parse(r1["maql"].ToString()) + " and b.loaibn=0 ";
                        sql += ")";
                        sql += " and makp='" + makp.Text + "'";// and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + r1["ngay"].ToString() + "'";
                        //sql += " and loaibn=0";// +loai;
                        m.execute_data(sql);
                    }
                    m.upd_eve_tables(ngay, itable, i_userid, "upd");
                    m.upd_eve_upd_del(ngay, itable, i_userid, "upd", m.fields(xxx + ".tiepdon", "maql=" + decimal.Parse(r1["maql"].ToString())));
				}
                if (i_sokham!=3)
                {
                    sokham = m.get_sokham(ngay.Substring(0, 10), r["makp"].ToString(), i_sokham).ToString();
                    frmSott f = new frmSott("Số khám " + r["tenkp"].ToString().Trim() + ": " + sokham);
                    f.ShowDialog(this);
                }
			}
			ena_but(false);
			butSua.Enabled=true;
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_but(false);
			butSua.Enabled=true;
		}

		private void butExit_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void AddGridTableStyle()
		{
			int IntAvgCharWidth;
			ts = new DataGridTableStyle();
			IntAvgCharWidth=(int)(System.Drawing.Graphics.FromHwnd(this.Handle).MeasureString("ABCDEFGHIJKLMNOPQRSTUVWXYZ",this.Font).Width/26);
			objStudentCM = (System.Windows.Forms.CurrencyManager)this.BindingContext[ds.Tables[0]];
			ts.MappingName = ds.Tables[0].TableName;

			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["mabn"]));
			ts.GridColumnStyles[0].MappingName = "mabn";
			ts.GridColumnStyles[0].HeaderText = "Mã BN";
			ts.GridColumnStyles[0].Width=60;
			ts.ReadOnly=true;
			ts.GridColumnStyles[0].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[0].NullText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["sovaovien"]));
			ts.GridColumnStyles[1].MappingName = "sovaovien";
			ts.GridColumnStyles[1].HeaderText = "STT";
			ts.GridColumnStyles[1].Width=40;
			ts.ReadOnly=true;
			ts.GridColumnStyles[1].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[1].NullText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["hoten"]));
			ts.GridColumnStyles[2].MappingName = "hoten";
			ts.GridColumnStyles[2].HeaderText = "Họ và tên";
			ts.GridColumnStyles[2].Width=180;
			ts.ReadOnly=true;
			ts.GridColumnStyles[2].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[2].NullText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["namsinh"]));
			ts.GridColumnStyles[3].MappingName = "namsinh";
			ts.GridColumnStyles[3].HeaderText = "NS";
			ts.GridColumnStyles[3].Width=35;
			ts.ReadOnly=true;
			ts.GridColumnStyles[3].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[3].NullText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["diachi"]));
			ts.GridColumnStyles[4].MappingName = "diachi";
			ts.GridColumnStyles[4].HeaderText = "Địa chỉ";
			ts.GridColumnStyles[4].Width=170;
			ts.ReadOnly=true;
			ts.GridColumnStyles[4].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[4].NullText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["tenkpcu"]));
			ts.GridColumnStyles[5].MappingName = "tenkpcu";
			ts.GridColumnStyles[5].HeaderText = "Phòng khám";
			ts.GridColumnStyles[5].Width=100;
			ts.ReadOnly=true;
			ts.GridColumnStyles[5].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[5].NullText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridComboBoxColumn(dtkp_cnnguon,1,1));
			ts.GridColumnStyles[6].MappingName = "tenkp";
			ts.GridColumnStyles[6].HeaderText = "Chuyển phòng";
			ts.GridColumnStyles[6].Width=160;
			ts.GridColumnStyles[6].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[6].NullText = string.Empty;			
			dataGrid1.CaptionText = string.Empty;

			dataGrid1.DataSource = ds;
			dataGrid1.DataMember = ds.Tables[0].TableName;
			dataGrid1.TableStyles.Add(ts);
		}
	
		private void butSua_Click(object sender, System.EventArgs e)
		{
			load_data();
			objStudentCM = (System.Windows.Forms.CurrencyManager)this.BindingContext[ds.Tables[0]];
			ts.MappingName = ds.Tables[0].TableName;
			dataGrid1.DataSource = ds;
			dataGrid1.DataMember = ds.Tables[0].TableName;
			ena_but(true);
		}

		private void load_data()
		{
			sql="select a.mabn,a.maql,b.hoten,b.namsinh,a.sovaovien,";
			sql+="trim(b.sonha)||' '||trim(b.thon)||' '||trim(e.tenpxa)||','||trim(d.tenquan)||','||trim(c.tentt) as diachi,";
			sql+="f.tenkp as tenkpcu,f.tenkp,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.done,a.mavaovien ";
            sql += " from " + user + m.mmyy(m.ngayhienhanh_server.Substring(0, 10)) + ".tiepdon a," + user + ".btdbn b," + user + ".btdtt c," + user + ".btdquan d," + user + ".btdpxa e," + user + ".btdkp_bv f";
			sql+=" where a.mabn=b.mabn and b.matt=c.matt and b.maqu=d.maqu and b.maphuongxa=e.maphuongxa and a.makp=f.makp";
            sql += " and a.makp='" + makp.Text + "' and to_char(a.ngay,'dd/mm/yyyy')='" + m.ngayhienhanh_server.Substring(0, 10) + "'";
			sql+=" and a.done not in('x')"; //chỉ load những bn chưa khám xong
			sql+=" order by a.maql";
			ds=m.get_data(sql);
			lblso.Text=ds.Tables[0].Rows.Count.ToString();
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void makp_Validated(object sender, System.EventArgs e)
		{
			if (makp.Text!="")
			{
				DataRow r=m.getrowbyid(dtkp_cndich,"makp='"+makp.Text+"'");
				if (r!=null) tenkp.SelectedValue=makp.Text; 
			}
		}

		private void tenkp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (tenkp.SelectedIndex==-1 && tenkp.Items.Count>0)
				{
					tenkp.SelectedIndex=0;
					makp.Text=tenkp.SelectedValue.ToString();
				}
				SendKeys.Send("{Tab}");
			}
		}

		private void tenkp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (tenkp.Items.Count > 0) //this.ActiveControl==tenkp && 
                makp.Text=tenkp.SelectedValue.ToString();
		}
        public void LoadChiNhanh_hientai(int i_IDCN)
        {
            string asql = "select * from medibv.dmchinhanh where id= " + i_IDCN + " order by id ";
            dtCNHienTai = m.get_data(asql).Tables[0].Copy();
            cmbChiNhanhHienTai.DataSource = dtCNHienTai;
            cmbChiNhanhHienTai.DisplayMember = "TEN";
            cmbChiNhanhHienTai.ValueMember = "ID";
        }
        public void LoadChiNhanh_Dich(int i_IDCN_Nguon)
        {
            string asql = "select * from medibv.dmchinhanh where id >0 and id<>" + i_IDCN_Nguon + " order by id ";
            dtCNDich = m.get_data(asql).Tables[0].Copy();
            cmbChiNhanhDich.DataSource = dtCNDich;// ksk.get_data(asql).Tables[0];
            cmbChiNhanhDich.DisplayMember = "TEN";
            cmbChiNhanhDich.ValueMember = "ID";
        }
        private void frmChuyenpk_theochinhanh_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = m.user;

            LoadChiNhanh_hientai(i_chinhanh);
            LoadChiNhanh_Dich(i_chinhanh);
            cmbChiNhanhDich.SelectedIndex = 0;
            cmbChiNhanhHienTai.SelectedIndex = 0;
            Load_thongtin_khoaphongdich(cmbChiNhanhDich.SelectedIndex < 0 ? 0 : int.Parse(cmbChiNhanhDich.SelectedValue.ToString()));
            Load_thongtin_khoaphonghientai(i_chinhanh);
            tenkp.SelectedIndex = 0;
            cmbTenkp_hientai.SelectedIndex = 0;

            if (!m.bMmyy(m.Ngayhienhanh)) m.tao_schema(m.mmyy(m.Ngayhienhanh), 0);
			tenkp.DisplayMember="TENKP";
			tenkp.ValueMember="MAKP";
			sql="select * from "+user+".btdkp_bv where makp<>'01' and loai=1";
			if (s_makp!="" )
			{
				string s=s_makp.Replace(",","','");
				sql+=" and makp in ('"+s.Substring(0,s.Length-3)+"')";
			}
            if (i_chinhanh > 0) sql += " and chinhanh=" + i_chinhanh;
			sql+=" order by makp";
            //linh 5/12/THIS
			//dtkp_cnnguon=m.get_data(sql).Tables[0];
            sql = "select * from " + user + ".btdkp_bv where makp<>'01' and loai=1 ";
            if (i_chinhanh > 0) sql += " and chinhanh=" + i_chinhanh;
            sql += " order by tenkp";
            //dtkp_cnnguon = m.get_data(sql).Tables[0];
            //
            i_sokham = m.iSokham;
            //end linh
			//tenkp.DataSource=m.get_data(sql).Tables[0];
			if (tenkp.SelectedIndex!=-1) makp.Text=tenkp.SelectedValue.ToString();
			lblso.Text="";
			ds.ReadXml("..//..//..//xml//m_chuyenkham.xml");
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
            bInkhambenh = m.bIn_khambenh;
            bDanhsach = m.bDanhsach_cho;
            loai = v.iNgoaitru;
        }
        private void Load_thongtin_khoaphongdich(int i_idCN)
        {
            DataRow dr = m.getrowbyid(dtCNDich, "id=" + i_idCN);
            if (dr != null)
            {
                string asql = "select * from medibv.btdkp_bv where chinhanh="+dr["id"].ToString()+" order by makp ";
                dtkp_cndich = m.get_data(asql).Tables[0];
                tenkp.DataSource = dtkp_cndich;
                tenkp.DisplayMember = "TENKP";
                tenkp.ValueMember = "MAKP";
            }
        }
        private void Load_thongtin_khoaphonghientai(int i_idCN)
        {
            DataRow dr = m.getrowbyid(dtCNHienTai, "id=" + i_idCN);
            if (dr != null)
            {
                string asql = "select * from medibv.btdkp_bv where chinhanh=" + dr["id"].ToString() + " order by makp ";
                dtkp_cnnguon = m.get_data(asql).Tables[0];
                cmbTenkp_hientai.DataSource = dtkp_cnnguon;
                cmbTenkp_hientai.DisplayMember = "TENKP";
                cmbTenkp_hientai.ValueMember = "MAKP";
            }
        }

        private void cmbChiNhanhDich_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cmbChiNhanhDich || sender == null)
            {
                Load_thongtin_khoaphongdich(cmbChiNhanhDich.SelectedIndex < 0 ? 0 : int.Parse(cmbChiNhanhDich.SelectedValue.ToString()));
            }
        }

        private void makp_hientai_Validated(object sender, EventArgs e)
        {
            if (makp_hientai.Text != "")
			{
                DataRow r = m.getrowbyid(dtkp_cnnguon, "makp='" + makp_hientai.Text + "'");
                if (r != null) cmbTenkp_hientai.SelectedValue = makp_hientai.Text;
			}
        }

        private void cmbTenkp_hientai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTenkp_hientai.Items.Count > 0) //this.ActiveControl==tenkp && 
                makp_hientai.Text = cmbTenkp_hientai.SelectedValue.ToString();
        }

        private void cmbTenkp_hientai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (cmbTenkp_hientai.SelectedIndex == -1 && cmbTenkp_hientai.Items.Count > 0)
                {
                    cmbTenkp_hientai.SelectedIndex = 0;
                    makp_hientai.Text = cmbTenkp_hientai.SelectedValue.ToString();
                }
                SendKeys.Send("{Tab}");
            }
        }
	}
}