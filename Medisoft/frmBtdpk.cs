using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
namespace Medisoft
{
	/// <summary>
	/// Summary description for frmDm.
	/// </summary>
	public class frmBtdpk : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
        private int itable, i_userid;
		private DataTable dt=new DataTable();
		private DataTable dtkp=new DataTable();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.TextBox ma;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox mavp;
		private System.Windows.Forms.Button butMavp;
        private string s_loaivp = "", s_mucvp = "", user, s_loaicd = "", s_muccd = "";
		private System.Windows.Forms.CheckedListBox maba;
		private System.Windows.Forms.Label label5;
		private DataTable dtba=new DataTable();
		private System.Windows.Forms.TextBox viettat;
        private bool bMoi_cu;
        private ComboBox mavptk;
        private Label label6;
        private Button butMacd;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmBtdpk(AccessData acc,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            i_userid = userid; m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBtdpk));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ma = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.mavp = new System.Windows.Forms.ComboBox();
            this.butMavp = new System.Windows.Forms.Button();
            this.maba = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.viettat = new System.Windows.Forms.TextBox();
            this.mavptk = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.butMacd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(8, -15);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 454);
            this.dataGrid1.TabIndex = 19;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(604, 494);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 12;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-6, 445);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 21;
            this.label1.Text = "Viết tắt :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ma
            // 
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(48, 392);
            this.ma.MaxLength = 2;
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(24, 21);
            this.ma.TabIndex = 0;
            this.ma.Validated += new System.EventHandler(this.ma_Validated);
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(91, 445);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Phòng khám :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(168, 445);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(160, 21);
            this.ten.TabIndex = 1;
            this.ten.Validated += new System.EventHandler(this.ten_Validated);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(309, 444);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 23);
            this.label3.TabIndex = 25;
            this.label3.Text = "Theo bộ :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Enabled = false;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(383, 445);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(246, 21);
            this.makp.TabIndex = 2;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(57, 494);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(60, 25);
            this.butMoi.TabIndex = 8;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(118, 494);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(60, 25);
            this.butSua.TabIndex = 9;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(179, 494);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(60, 25);
            this.butLuu.TabIndex = 6;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(240, 494);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 7;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(301, 494);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(60, 25);
            this.butHuy.TabIndex = 10;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-22, 468);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 26;
            this.label4.Text = "Khám :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mavp
            // 
            this.mavp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mavp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mavp.Enabled = false;
            this.mavp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavp.Location = new System.Drawing.Point(40, 468);
            this.mavp.Name = "mavp";
            this.mavp.Size = new System.Drawing.Size(288, 21);
            this.mavp.TabIndex = 3;
            this.mavp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavp_KeyDown);
            // 
            // butMavp
            // 
            this.butMavp.Enabled = false;
            this.butMavp.Image = ((System.Drawing.Image)(resources.GetObject("butMavp.Image")));
            this.butMavp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMavp.Location = new System.Drawing.Point(362, 494);
            this.butMavp.Name = "butMavp";
            this.butMavp.Size = new System.Drawing.Size(120, 25);
            this.butMavp.TabIndex = 11;
            this.butMavp.Text = "    &Giới hạn viện phí";
            this.butMavp.Click += new System.EventHandler(this.butMavp_Click);
            // 
            // maba
            // 
            this.maba.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maba.CheckOnClick = true;
            this.maba.Enabled = false;
            this.maba.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maba.Location = new System.Drawing.Point(679, 445);
            this.maba.Name = "maba";
            this.maba.Size = new System.Drawing.Size(110, 84);
            this.maba.TabIndex = 5;
            this.maba.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maba_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(630, 444);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 23);
            this.label5.TabIndex = 28;
            this.label5.Text = "Bệnh án :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // viettat
            // 
            this.viettat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.viettat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.viettat.Enabled = false;
            this.viettat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viettat.Location = new System.Drawing.Point(40, 445);
            this.viettat.MaxLength = 8;
            this.viettat.Name = "viettat";
            this.viettat.Size = new System.Drawing.Size(56, 21);
            this.viettat.TabIndex = 0;
            this.viettat.Validated += new System.EventHandler(this.viettat_Validated);
            this.viettat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // mavptk
            // 
            this.mavptk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mavptk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mavptk.Enabled = false;
            this.mavptk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavptk.Location = new System.Drawing.Point(383, 468);
            this.mavptk.Name = "mavptk";
            this.mavptk.Size = new System.Drawing.Size(294, 21);
            this.mavptk.TabIndex = 4;
            this.mavptk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavptk_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(322, 468);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 30;
            this.label6.Text = "Tái khám :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butMacd
            // 
            this.butMacd.Enabled = false;
            this.butMacd.Image = ((System.Drawing.Image)(resources.GetObject("butMacd.Image")));
            this.butMacd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMacd.Location = new System.Drawing.Point(483, 494);
            this.butMacd.Name = "butMacd";
            this.butMacd.Size = new System.Drawing.Size(120, 25);
            this.butMacd.TabIndex = 32;
            this.butMacd.Text = "    &Giới hạn chỉ định";
            this.butMacd.Click += new System.EventHandler(this.butMacd_Click);
            // 
            // frmBtdpk
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butMacd);
            this.Controls.Add(this.mavp);
            this.Controls.Add(this.mavptk);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.viettat);
            this.Controls.Add(this.maba);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.butMavp);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.ma);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBtdpk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục phòng khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBtdpk_KeyDown);
            this.Load += new System.EventHandler(this.frmBtdpk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmBtdpk_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            bMoi_cu = m.bMoi_cu;
            user = m.user; itable = m.tableid("", "btdkp_bv");
			dtba=m.get_data("select * from "+user+".dmbenhan where loaiba=2 order by maba").Tables[0];
			maba.DataSource=dtba;
            maba.ValueMember = "MABA";
            maba.DisplayMember = "TENVT";

            mavp.DisplayMember="TEN";
			mavp.ValueMember="ID";
            mavp.DataSource = m.get_data("select a.* from " + user + ".v_giavp a," + user + ".v_loaivp b where a.id_loai=b.id order by b.stt,a.stt").Tables[0];

            mavptk.DisplayMember = "TEN";
            mavptk.ValueMember = "ID";
            mavptk.DataSource = m.get_data("select a.* from " + user + ".v_giavp a," + user + ".v_loaivp b where a.id_loai=b.id order by b.stt,a.stt").Tables[0];

			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
            makp.DataSource = m.get_data("select * from " + user + ".btdkp where makp<>'01' order by makp").Tables[0];
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

			ref_text();
		}

		private void load_grid()
		{
            dt = m.get_data("select a.makp,a.tenkp,b.tenkp as tenkpbo,a.makpbo,c.ten as tenvp,a.mavp,a.loaivp,a.mucvp,a.maba,a.viettat,d.ten as tenvptk,a.mavptk,a.loaicd,a.muccd from " + user + ".btdkp_bv a inner join " + user + ".btdkp b on a.makpbo=b.makp left join " + user + ".v_giavp c on a.mavp=c.id left join " + user + ".v_giavp d on a.mavptk=d.id where a.loai=1 order by a.makp").Tables[0];
			dataGrid1.DataSource=dt;
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dt.TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=10;
						
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "makp";
			TextCol.HeaderText = "Mã";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "viettat";
			TextCol.HeaderText = "Viết tắt";
			TextCol.Width = 70;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenkp";
			TextCol.HeaderText = "Phòng khám";
			TextCol.Width = 200;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenkpbo";
			TextCol.HeaderText = "Khoa theo bộ";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "makpbo";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenvp";
			TextCol.HeaderText = "Khám bệnh";
			TextCol.Width = 140;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "mavp";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "loaivp";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "mucvp";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "maba";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenvptk";
            TextCol.HeaderText = "Tái khám";
            TextCol.Width = 140;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "mavptk";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "loaicd";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "muccd";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void ma_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (makp.SelectedIndex==-1) makp.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void ena_object(bool ena)
		{
			maba.Enabled=ena;
			mavp.Enabled=ena;
            if (bMoi_cu) mavptk.Enabled = ena;
			viettat.Enabled=ena;
			ten.Enabled=ena;
			makp.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butMavp.Enabled=ena;
            butMacd.Enabled = ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
            dataGrid1.Enabled = !ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			int i=1;
            dtkp = m.get_data("select * from " + user + ".btdkp_bv order by makp").Tables[0];
			DataRow r;
			for(i=1;i<100;i++)
			{
				r=m.getrowbyid(dtkp,"makp='"+i.ToString().PadLeft(2,'0')+"'");
				if (r==null) break;
			}
			ma.Text=i.ToString().PadLeft(2,'0');
			viettat.Text=ma.Text;
            s_loaivp = ""; s_mucvp = ""; ten.Text = ""; s_loaicd = ""; s_muccd = "";
			for(i=0;i<maba.Items.Count;i++) maba.SetItemCheckState(i,CheckState.Unchecked);
			ena_object(true);
			viettat.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			ma.Enabled=false;
			ten.Focus();
		}

		private bool kiemtra()
		{
			if (viettat.Text=="")
			{
				viettat.Focus();
				return false;
			}
            if (ten.Text == "")
            {
                ten.Focus();
                return false;
            }
            else
            {
                ten.Text = ten.Text.Replace("(", "[");
                ten.Text = ten.Text.Replace(")", "]");
            }
			if (makp.SelectedIndex==-1)
			{
				makp.Focus();
				return false;
			}
			if (mavp.SelectedIndex==-1)
			{
				mavp.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return ;
			string s_maba="";
			for(int i=0;i<maba.Items.Count;i++)
				if (maba.GetItemChecked(i)) s_maba+=dtba.Rows[i]["maba"].ToString().Trim()+",";
			if (s_maba!="") s_maba=s_maba.Substring(0,s_maba.Length-1);
			if (!m.upd_btdkp_bv("btdkp_bv",ma.Text,ten.Text,0,0,makp.SelectedValue.ToString(),s_maba,1,int.Parse(mavp.SelectedValue.ToString()),s_loaivp,s_mucvp,viettat.Text,s_loaicd,s_muccd))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin phòng khám !"));
				return;
			}
            if (bMoi_cu) m.execute_data("update " + user + ".btdkp_bv set mavptk=" + int.Parse(mavptk.SelectedValue.ToString()) + " where makp='" + ma.Text + "'");
            if (m.get_data("select * from " + user + ".btdkp_bv where makp='" + ma.Text + "'").Tables[0].Rows.Count != 0)
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", ma.Text + "^" + ten.Text + "^" + "0" + "^" + "0" + "^" + makp.SelectedValue.ToString() + "^" + s_maba + "^" + "1" + "^" + mavp.SelectedValue.ToString() + "^" + s_loaivp + "^" + s_mucvp + "^" + viettat.Text);
            }
            else m.upd_eve_tables(itable, i_userid, "ins");
			m.upd_btdkp_bv("btdkp_add",ma.Text,ten.Text,0,0,makp.SelectedValue.ToString(),s_maba,1,int.Parse(mavp.SelectedValue.ToString()),s_loaivp,s_mucvp,viettat.Text,s_loaicd,s_muccd);
            if (bMoi_cu) m.execute_data("update " + user + ".btdkp_add set mavptk=" + int.Parse(mavptk.SelectedValue.ToString()) + " where makp='" + ma.Text + "'");
			m.upd_dm01(int.Parse(ma.Text.ToString())+51,"-",ten.Text,"C",1,int.Parse(makp.SelectedValue.ToString())+12);
			load_grid();
			ena_object(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (ma.Text=="01")
			{
				MessageBox.Show(lan.Change_language_MessageText("Không được hủy mã này !"),LibMedi.AccessData.Msg);
				return;
			}
            if (m.get_data("select * from " + user + ".benhandt where makp='" + ma.Text + "'").Tables[0].Rows.Count != 0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Phòng khám đã sử dụng không thể huỷ !"),LibMedi.AccessData.Msg);
				return;
			}
            if (m.get_data("select * from " + user + ".bieu_01 where ma-51=" + int.Parse(ma.Text)).Tables[0].Rows.Count != 0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Khoa đã sử dụng không thể huỷ !"),LibMedi.AccessData.Msg);
				return;
			}
            if (m.get_data("select * from " + user + ".bieu_02 where ma=" + int.Parse(ma.Text)).Tables[0].Rows.Count != 0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Phòng khám đã sử dụng không thể huỷ !"),LibMedi.AccessData.Msg);
				return;
			}
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                m.upd_eve_tables(itable, i_userid, "del");
                m.upd_eve_upd_del(itable, i_userid, "del", m.fields(user + ".btdkp_bv", "makp='" + ma.Text + "'"));
                m.execute_data("delete from " + user + ".btdkp_bv where makp='" + ma.Text + "'");
                m.execute_data("delete from " + user + ".btdkp_add where makp='" + ma.Text + "'");
                m.execute_data("delete from " + user + ".dm_01 where ma-51=" + int.Parse(ma.Text.ToString()));
				load_grid();
			}
		}

		private void ma_Validated(object sender, System.EventArgs e)
		{
			try
			{
                if (m.get_data("select * from " + user + ".btdkp_bv where makp='" + ma.Text + "'").Tables[0].Rows.Count != 0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Mã này đã có !"));
					ma.Focus();
					return;
				}
			}
			catch{}
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				ma.Text=dataGrid1[i,0].ToString();
				viettat.Text=dataGrid1[i,1].ToString();
				ten.Text=dataGrid1[i,2].ToString();
				makp.SelectedValue=dataGrid1[i,4].ToString();
				mavp.SelectedValue=dataGrid1[i,6].ToString();
				s_loaivp=dataGrid1[i,7].ToString();
				s_mucvp=dataGrid1[i,8].ToString();
				string s_maba=dataGrid1[i,9].ToString()+",";
				for(int j=0;j<maba.Items.Count;j++)
					if (s_maba.IndexOf(dtba.Rows[j]["maba"].ToString()+",")!=-1) maba.SetItemCheckState(j,CheckState.Checked);
					else maba.SetItemCheckState(j,CheckState.Unchecked);
                mavptk.SelectedValue = dataGrid1[i, 11].ToString();
                s_loaicd = dataGrid1[i,12].ToString();
                s_muccd = dataGrid1[i, 13].ToString();
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void ten_Validated(object sender, System.EventArgs e)
		{
			ten.Text=m.Caps(ten.Text);
		}

		private void frmBtdpk_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void mavp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (mavp.SelectedIndex==-1) mavp.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void butMavp_Click(object sender, System.EventArgs e)
		{
			frmChonvp f=new frmChonvp(m,s_loaivp,s_mucvp);
			f.ShowDialog();
            if (f.bOk)
			{
				s_loaivp=f.s_loaivp;s_mucvp=f.s_mucvp;
			}
		}

		private void maba_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void viettat_Validated(object sender, System.EventArgs e)
		{
            if (m.get_data("select * from " + user + ".btdkp_bv where viettat='" + viettat.Text + "'").Tables[0].Rows.Count != 0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã này đã có !"));
				viettat.Focus();
				return;
			}
		}

        private void mavptk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (mavptk.SelectedIndex == -1) mavptk.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void butMacd_Click(object sender, EventArgs e)
        {
            frmChonvp f = new frmChonvp(m, s_loaicd, s_muccd);
            f.ShowDialog();
            if (f.bOk)
            {
                s_loaicd = f.s_loaivp; s_muccd = f.s_mucvp;
            }
        }
	}
}
