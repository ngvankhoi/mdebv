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
	/// Summary description for frmDMICD10.
	/// </summary>
	public class frmDMICD10 : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		public string mICD="";
		public string mTen="";
		private bool b_chon;
		private string user,s_table,sql="",s_mavp="",s_icd10="";
		private AccessData m;
		private BaseFormat mFormat=new BaseFormat();
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtICD;
		private System.Windows.Forms.TextBox txtTen;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btChon;
        private Button butKetthuc;
        private Button butChidinh;
        private Button butThuoc;
        private System.ComponentModel.IContainer components;

        DataTable dtDichvu = new DataTable();

		public frmDMICD10(AccessData acc,string table,string vICD, string vTen,bool chon)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            s_table = table; m = acc; b_chon = chon; mICD = vICD; mTen = vTen; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMICD10));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtICD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btChon = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butChidinh = new System.Windows.Forms.Button();
            this.butThuoc = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.txtTen);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtICD);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.panel1.Size = new System.Drawing.Size(686, 27);
            this.panel1.TabIndex = 0;
            // 
            // txtTen
            // 
            this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtTen.Location = new System.Drawing.Point(216, 2);
            this.txtTen.MaxLength = 50;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(470, 21);
            this.txtTen.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtTen, "Nhập vào tên bệnh cần tìm và có kết quả ngay tức khắc");
            this.txtTen.TextChanged += new System.EventHandler(this.txtICD_TextChanged);
            this.txtTen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtICD_KeyDown);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(104, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 22);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tên bệnh tiếng việt:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtICD
            // 
            this.txtICD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtICD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtICD.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtICD.Location = new System.Drawing.Point(40, 2);
            this.txtICD.MaxLength = 7;
            this.txtICD.Name = "txtICD";
            this.txtICD.Size = new System.Drawing.Size(64, 21);
            this.txtICD.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtICD, "Nhập vào mã số ICD10 và có kết quả ngay tức khắc");
            this.txtICD.TextChanged += new System.EventHandler(this.txtICD_TextChanged);
            this.txtICD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtICD_KeyDown);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "ICD:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGrid1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(227)))));
            this.dataGrid1.CaptionForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGrid1.CaptionVisible = false;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(5, 30);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.Size = new System.Drawing.Size(686, 311);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.TabStop = false;
            this.toolTip1.SetToolTip(this.dataGrid1, "Double Click để chọn bệnh hiện hành");
            this.dataGrid1.DoubleClick += new System.EventHandler(this.dataGrid1_DoubleClick);
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // btChon
            // 
            this.btChon.AllowDrop = true;
            this.btChon.BackColor = System.Drawing.Color.Transparent;
            this.btChon.Cursor = System.Windows.Forms.Cursors.Default;
            this.btChon.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btChon.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btChon.Image = ((System.Drawing.Image)(resources.GetObject("btChon.Image")));
            this.btChon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btChon.Location = new System.Drawing.Point(18, 362);
            this.btChon.Name = "btChon";
            this.btChon.Size = new System.Drawing.Size(77, 25);
            this.btChon.TabIndex = 2;
            this.btChon.Text = "      Chọn";
            this.toolTip1.SetToolTip(this.btChon, "Chọn bệnh hiện hành từ danh sách trên");
            this.btChon.UseVisualStyleBackColor = false;
            this.btChon.Click += new System.EventHandler(this.btChon_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(611, 362);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(77, 25);
            this.butKetthuc.TabIndex = 13;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butChidinh
            // 
            this.butChidinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butChidinh.Image = ((System.Drawing.Image)(resources.GetObject("butChidinh.Image")));
            this.butChidinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChidinh.Location = new System.Drawing.Point(343, 362);
            this.butChidinh.Name = "butChidinh";
            this.butChidinh.Size = new System.Drawing.Size(133, 25);
            this.butChidinh.TabIndex = 14;
            this.butChidinh.Text = "    Chỉ định được dùng";
            this.butChidinh.UseVisualStyleBackColor = true;
            this.butChidinh.Visible = false;
            this.butChidinh.Click += new System.EventHandler(this.butChidinh_Click);
            // 
            // butThuoc
            // 
            this.butThuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butThuoc.Image = ((System.Drawing.Image)(resources.GetObject("butThuoc.Image")));
            this.butThuoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThuoc.Location = new System.Drawing.Point(477, 362);
            this.butThuoc.Name = "butThuoc";
            this.butThuoc.Size = new System.Drawing.Size(133, 25);
            this.butThuoc.TabIndex = 15;
            this.butThuoc.Text = "   Thuốc được dùng";
            this.butThuoc.UseVisualStyleBackColor = true;
            this.butThuoc.Visible = false;
            this.butThuoc.Click += new System.EventHandler(this.butThuoc_Click);
            // 
            // frmDMICD10
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(696, 405);
            this.Controls.Add(this.butThuoc);
            this.Controls.Add(this.butChidinh);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.btChon);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(692, 416);
            this.Name = "frmDMICD10";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Danh mục ICD10";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDMICD10_KeyDown);
            this.Load += new System.EventHandler(this.frmDMICD10_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		private void f_Chon()
		{
			try
			{
				mICD=dataGrid1[dataGrid1.CurrentRowIndex,0].ToString();
				mTen=dataGrid1[dataGrid1.CurrentRowIndex,1].ToString();
				m.close();this.Close();
			}
			catch
			{
				mICD="";
				mTen="";
			}
		}

		private void btChon_Click(object sender, System.EventArgs e)
		{
			f_Chon();
		}

		private void frmDMICD10_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			btChon.Visible=b_chon;
            try
            {
                mFormat.f_LoadDG(dataGrid1, m.get_data("select CICD10,VVIET from " + user + "." + s_table), new string[] { "Mã ICD", "Tên bệnh tiếng việt                                                                                    .", "Tên bệnh tiếng anh" }, new string[] {"CICD10", "VVIET" });
                mFormat.f_ResizeDG(dataGrid1);
            }
            catch { }
            lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString() + "_" + dataGrid1.Name.ToString());
            lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString() + "_" + dataGrid1.Name.ToString());
            
			txtICD.Text=mICD;
			txtTen.Text=mTen;
            //sql = "select b.id_nhom,c.ten nhom,a.id_loai,b.ten loai,a.id, a.ten from " + m.user + ".v_giavp a, " + m.user + ".v_loaivp b," + m.user + ".v_nhomvp c where a.id_loai=b.id and b.id_nhom in(1,2) and b.id_nhom=c.ma order by c.ten,b.ten,a.ten";
            //dtDichvu = m.get_data(sql).Tables[0];
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				mICD=dataGrid1[dataGrid1.CurrentRowIndex,0].ToString();
				mTen=dataGrid1[dataGrid1.CurrentRowIndex,1].ToString();
			}
			catch{}
		}

		private void dataGrid1_DoubleClick(object sender, System.EventArgs e)
		{
			f_Chon();
		}
		private void txtICD_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				try
				{
					dataGrid1.UnSelect(dataGrid1.CurrentRowIndex);
				}
				catch{}
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource, dataGrid1.DataMember];
				DataView dv= (DataView)cm.List;
				dv.AllowNew=false;
				dv.AllowDelete=false;
				if(sender.Equals(txtICD))
					dv.RowFilter = "CICD10 LIKE '%"+ txtICD.Text.Trim() + "%'";
				else
					dv.RowFilter = " VVIET LIKE '%"+ txtTen.Text.Trim() + "%'";
				dataGrid1.Select(dataGrid1.CurrentRowIndex);
			}
			catch{}
		}
		private void txtICD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
//					txtICD.Text=dataGrid1[dataGrid1.CurrentRowIndex,0].ToString();
//					txtTen.Text=dataGrid1[dataGrid1.CurrentRowIndex,1].ToString();
//					btChon.Focus();
					SendKeys.Send("{Tab}");
				}
				if(e.KeyCode==Keys.Up)
				{
					if(dataGrid1.CurrentRowIndex>0)
					{
						dataGrid1.UnSelect(dataGrid1.CurrentRowIndex);
						dataGrid1.CurrentRowIndex=dataGrid1.CurrentRowIndex - 1;
						dataGrid1.Select(dataGrid1.CurrentRowIndex);
					}
					SendKeys.Send("{End}");
				}
				else
				if(e.KeyCode==Keys.Down)
				{
					dataGrid1.UnSelect(dataGrid1.CurrentRowIndex);
					dataGrid1.CurrentRowIndex=dataGrid1.CurrentRowIndex + 1;
					dataGrid1.Select(dataGrid1.CurrentRowIndex);
					SendKeys.Send("{End}");
				}
			}
			catch{}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void frmDMICD10_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

        private void butChidinh_Click(object sender, EventArgs e)
        {
            //DataTable dttam = new DataTable();
            //sql = "select mavp from "+m.user+".icd10_chidinh where maicd10='"+mICD+"'";
            //dttam = m.get_data(sql).Tables[0];
            //if (dttam.Rows.Count == 0)
            //    s_mavp = "";
            //else
            //    s_mavp = dttam.Rows[0]["mavp"].ToString().Trim(',');
            //frmChidinh_icd10 f = new frmChidinh_icd10(m,dtDichvu,mICD,s_mavp,mTen);
            //f.ShowInTaskbar = false;
            //f.ShowDialog();
        }

        private void butThuoc_Click(object sender, EventArgs e)
        {

        }
	}
}
