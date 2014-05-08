using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace dllDanhmucMedisoft
{
	/// <summary>
	/// Summary description for frmBtdtt.
	/// </summary>
	public class frmBtdpxa : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private MaskedTextBox.MaskedTextBox ma;
		private MaskedTextBox.MaskedTextBox ten;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
        private System.Windows.Forms.Button butHuy;
        private string user;
        private int i_userid, itable;
		private AccessData m;
		private DataSet ds=new DataSet();
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox matt;
		private System.Windows.Forms.Label label4;
		private MaskedTextBox.MaskedTextBox viettat;
		private System.Windows.Forms.ComboBox maqu;
        private System.Windows.Forms.Label label5;
        private CheckBox chkthanhthi;
        private Button butKetthuc;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmBtdpxa(AccessData acc,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; i_userid = userid; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBtdpxa));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ma = new MaskedTextBox.MaskedTextBox();
            this.ten = new MaskedTextBox.MaskedTextBox();
            this.butThem = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.matt = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.viettat = new MaskedTextBox.MaskedTextBox();
            this.maqu = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkthanhthi = new System.Windows.Forms.CheckBox();
            this.butKetthuc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dataGrid1.Location = new System.Drawing.Point(4, 11);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(583, 292);
            this.dataGrid1.TabIndex = 12;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(8, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mã :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(80, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ma
            // 
            this.ma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(44, 313);
            this.ma.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ma.MaxLength = 2;
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(40, 21);
            this.ma.TabIndex = 2;
            this.ma.Validated += new System.EventHandler(this.ma_Validated);
            // 
            // ten
            // 
            this.ten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(147, 313);
            this.ten.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(197, 21);
            this.ten.TabIndex = 3;
            this.ten.Validated += new System.EventHandler(this.ten_Validated);
            // 
            // butThem
            // 
            this.butThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(61, 344);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 8;
            this.butThem.Text = "&Thêm";
            this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(131, 344);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 9;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(201, 344);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 6;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(271, 344);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 7;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(341, 344);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 10;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-8, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tỉnh/thành phố :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // matt
            // 
            this.matt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(90, 4);
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(188, 21);
            this.matt.TabIndex = 0;
            this.matt.SelectedIndexChanged += new System.EventHandler(this.matt_SelectedIndexChanged);
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(344, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Viết tắt :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // viettat
            // 
            this.viettat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.viettat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.viettat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.viettat.Enabled = false;
            this.viettat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viettat.Location = new System.Drawing.Point(403, 312);
            this.viettat.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.viettat.Name = "viettat";
            this.viettat.Size = new System.Drawing.Size(88, 21);
            this.viettat.TabIndex = 4;
            this.viettat.Validated += new System.EventHandler(this.viettat_Validated);
            // 
            // maqu
            // 
            this.maqu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.maqu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.maqu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu.Location = new System.Drawing.Point(350, 4);
            this.maqu.Name = "maqu";
            this.maqu.Size = new System.Drawing.Size(237, 21);
            this.maqu.TabIndex = 1;
            this.maqu.SelectedIndexChanged += new System.EventHandler(this.maqu_SelectedIndexChanged);
            this.maqu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maqu_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(248, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Quận/huyện :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkthanhthi
            // 
            this.chkthanhthi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkthanhthi.AutoSize = true;
            this.chkthanhthi.Enabled = false;
            this.chkthanhthi.Location = new System.Drawing.Point(501, 315);
            this.chkthanhthi.Name = "chkthanhthi";
            this.chkthanhthi.Size = new System.Drawing.Size(75, 17);
            this.chkthanhthi.TabIndex = 13;
            this.chkthanhthi.Text = "Thành Thị";
            this.chkthanhthi.UseVisualStyleBackColor = true;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(410, 344);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 18;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // frmBtdpxa
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(589, 389);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.chkthanhthi);
            this.Controls.Add(this.matt);
            this.Controls.Add(this.maqu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.viettat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Name = "frmBtdpxa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục phường xã";
            this.Load += new System.EventHandler(this.frmBtdpxa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmBtdpxa_Load(object sender, System.EventArgs e)
		{
            user = m.user; itable = m.tableid("", "btdpxa");
			matt.DisplayMember="TENTT";
			matt.ValueMember="MATT";
			matt.DataSource=m.get_data("select * from "+user+".btdtt order by matt").Tables[0];
			try
			{
				matt.SelectedValue=m.Mabv.Substring(0,3);
			}
			catch{}
			maqu.DisplayMember="TENQUAN";
			maqu.ValueMember="MAQU";
			load_quan();
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

		}

		private void load_quan()
		{
			maqu.DataSource=m.get_data("select * from "+user+".btdquan where matt='"+matt.SelectedValue.ToString()+"'").Tables[0];
			maqu.SelectedValue=m.Maqu;
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
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
			ts.RowHeaderWidth=10;
						
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "maphuongxa";
			TextCol.HeaderText = "Mã";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenpxa";
			TextCol.HeaderText = "Tên";
			TextCol.Width = 297;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "viettat";
			TextCol.HeaderText = "Viết tắt";
			TextCol.Width = 90;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "thanhthi";
            TextCol.HeaderText = "Thành Thị";
            TextCol.Width = 50;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

		}

		private void load_grid()
		{
			if (maqu.SelectedIndex!=-1)
			{
                ds = m.get_data("select * from " + user + ".btdpxa where maqu='" + maqu.SelectedValue.ToString() + "'" + " order by maphuongxa");
				dataGrid1.DataSource=ds.Tables[0];
			}
		}

		private void ena_object(bool ena)
		{
			ma.Enabled=ena;
			ten.Enabled=ena;
			viettat.Enabled=ena;
            //chknongthon.Enabled = ena;
            chkthanhthi.Enabled = ena;
			butThem.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			ma.Text="";
			ten.Text="";
			viettat.Text="";
			ena_object(true);
			ma.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{	
			ena_object(true);
			ma.Enabled=false;
			ten.Focus();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (ma.Text=="" || ma.Text.Trim().Length!=2)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập mã !"),LibMedi.AccessData.Msg);
				ma.Focus();
				return;
			}
			if (ten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập tên !"),LibMedi.AccessData.Msg);
				ten.Focus();
				return;
			}
            if (m.get_data("select * from " + user + ".btdpxa where maphuongxa='" + maqu.SelectedValue.ToString()+ma.Text + "'").Tables[0].Rows.Count != 0)
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", maqu.SelectedValue.ToString() + "^" + maqu.SelectedValue.ToString() + ma.Text + "^" + ten.Text + "^" + viettat.Text);
            }
            else m.upd_eve_tables(itable, i_userid, "ins");
            m.upd_btdpxa("btdpxa", maqu.SelectedValue.ToString(), maqu.SelectedValue.ToString() + ma.Text, ten.Text, viettat.Text, chkthanhthi.Checked ? 1 : 0);
            //m.execute_data("update " + m.user + ".btdpxa set nongthon=" + (chknongthon.Checked ? "1" : "0")+" ,thanhthi="+ (chkthanhthi.Checked ? "1" : "0") + " where maphuongxa='" + ma.Text + "'");
            m.upd_btdpxa("btdpxa_add", maqu.SelectedValue.ToString(), maqu.SelectedValue.ToString() + ma.Text, ten.Text, viettat.Text, chkthanhthi.Checked ? 1 : 0);
			if (maqu.SelectedValue.ToString()==m.Maqu && m.Matuyen(m.Mabv)=="4")
			{
				m.upd_danhmuc(int.Parse(ma.Text),"1",ten.Text,"kh_dm_01");
				m.upd_danhmuc(int.Parse(ma.Text),"1",ten.Text,"kh_dm_02");
				m.upd_danhmuc(int.Parse(ma.Text),"1",ten.Text,"kh_dm_04");
				m.sort_stt();
			}
			load_grid();
			ena_object(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (m.get_data("select * from "+user+".btdbn where maphuongxa='"+maqu.SelectedValue.ToString()+ma.Text+"'").Tables[0].Rows.Count!=0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Mã phường xã đã sử dụng không thể huỷ !"),LibMedi.AccessData.Msg);
					return;
				}
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    m.upd_eve_tables(itable, i_userid, "del");
                    m.upd_eve_upd_del(itable, i_userid, "del", m.fields(user + ".btdpxa", "maphuongxa='" + maqu.SelectedValue.ToString() + ma.Text + "'"));
					m.execute_data("delete from "+user+".btdpxa where maphuongxa='"+maqu.SelectedValue.ToString()+ma.Text+"'");
					m.execute_data("delete from "+user+".btdpxa_add where maphuongxa='"+maqu.SelectedValue.ToString()+ma.Text+"'");
					if (maqu.SelectedValue.ToString()==m.Maqu && m.Matuyen(m.Mabv)=="4")
					{
						m.execute_data("delete from "+user+".kh_dm_01 where ma="+int.Parse(ma.Text));
						m.execute_data("delete from "+user+".kh_dm_02 where ma="+int.Parse(ma.Text));
						m.execute_data("delete from "+user+".kh_dm_04 where ma="+int.Parse(ma.Text));
					}
					load_grid();
				}
			}
			catch{}

		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();		
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				ma.Text=dataGrid1[i,0].ToString().Substring(5,2);
				ten.Text=dataGrid1[i,1].ToString();
				viettat.Text=dataGrid1[i,2].ToString();
                chkthanhthi.Checked  = dataGrid1[i, 3].ToString()=="1";

			}
			catch( Exception ex){}
		}

		private void ma_Validated(object sender, System.EventArgs e)
		{
			if (ma.Text!="")
			{
				DataRow r=m.getrowbyid(ds.Tables[0],"maphuongxa='"+maqu.SelectedValue.ToString()+ma.Text+"'");
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Mã này đã có !"),LibMedi.AccessData.Msg);
					ma.Focus();
					return;
				}
			}
		}

		private void ten_Validated(object sender, System.EventArgs e)
		{
			if (ten.Text!="") ten.Text=m.Caps(ten.Text);
		}

		private void matt_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				load_quan();
			}
			catch{}
		}

		private void matt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void maqu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
    			load_grid();
			}
			catch{}		
		}

		private void maqu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void viettat_Validated(object sender, System.EventArgs e)
		{

		}
        private void f_capnhat_db()
        {
            string user = m.user;
            string asql = "select nongthon from " + user + ".btdpxa where 1=2";
            DataSet lds = m.get_data(asql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                asql = "alter table " + user + ".btdpxa add nongthon number(1) default 0";

            }
        }
	}
}
