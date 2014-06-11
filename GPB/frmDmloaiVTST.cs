using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace XN
{
	/// <summary>
	/// Summary description for frmDmloaiVTST.
	/// </summary>
	public class frmDmloaiVTST : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dgLoaivtst;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label LBMa;
		private System.Windows.Forms.Label label1;
		private System.Data.DataSet ds;
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private string user,sql;
		private System.Windows.Forms.TextBox tenloai;
		private System.Windows.Forms.Button bntLuu;
		private System.Windows.Forms.Button bntSua;
		private System.Windows.Forms.Button bntKethuc;
		private System.Windows.Forms.Button bntHuy;
		private System.Windows.Forms.Button bntBoqua;
		private System.Windows.Forms.Button bntThem;
		private MaskedTextBox.MaskedTextBox maloai;
        private gpblib.AccessData k = new gpblib.AccessData();
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDmloaiVTST()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDmloaiVTST));
            this.dgLoaivtst = new System.Windows.Forms.DataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.maloai = new MaskedTextBox.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bntLuu = new System.Windows.Forms.Button();
            this.bntSua = new System.Windows.Forms.Button();
            this.bntKethuc = new System.Windows.Forms.Button();
            this.bntHuy = new System.Windows.Forms.Button();
            this.bntBoqua = new System.Windows.Forms.Button();
            this.tenloai = new System.Windows.Forms.TextBox();
            this.bntThem = new System.Windows.Forms.Button();
            this.LBMa = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgLoaivtst)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgLoaivtst
            // 
            this.dgLoaivtst.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dgLoaivtst.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgLoaivtst.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgLoaivtst.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgLoaivtst.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dgLoaivtst.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgLoaivtst.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dgLoaivtst.CaptionVisible = false;
            this.dgLoaivtst.DataMember = "";
            this.dgLoaivtst.FlatMode = true;
            this.dgLoaivtst.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgLoaivtst.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dgLoaivtst.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dgLoaivtst.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgLoaivtst.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dgLoaivtst.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dgLoaivtst.LinkColor = System.Drawing.Color.Teal;
            this.dgLoaivtst.Location = new System.Drawing.Point(5, 4);
            this.dgLoaivtst.Name = "dgLoaivtst";
            this.dgLoaivtst.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dgLoaivtst.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dgLoaivtst.ReadOnly = true;
            this.dgLoaivtst.RowHeaderWidth = 10;
            this.dgLoaivtst.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dgLoaivtst.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dgLoaivtst.Size = new System.Drawing.Size(582, 276);
            this.dgLoaivtst.TabIndex = 33;
            this.dgLoaivtst.CurrentCellChanged += new System.EventHandler(this.dgLoaivtst_CurrentCellChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.maloai);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bntLuu);
            this.panel1.Controls.Add(this.bntSua);
            this.panel1.Controls.Add(this.bntKethuc);
            this.panel1.Controls.Add(this.bntHuy);
            this.panel1.Controls.Add(this.bntBoqua);
            this.panel1.Controls.Add(this.tenloai);
            this.panel1.Controls.Add(this.bntThem);
            this.panel1.Controls.Add(this.LBMa);
            this.panel1.Location = new System.Drawing.Point(4, 283);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 72);
            this.panel1.TabIndex = 34;
            // 
            // maloai
            // 
            this.maloai.BackColor = System.Drawing.Color.White;
            this.maloai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maloai.Location = new System.Drawing.Point(64, 8);
            this.maloai.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maloai.MaxLength = 2;
            this.maloai.Name = "maloai";
            this.maloai.Size = new System.Drawing.Size(48, 21);
            this.maloai.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Tên";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bntLuu
            // 
            this.bntLuu.Enabled = false;
            this.bntLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntLuu.Image = ((System.Drawing.Image)(resources.GetObject("bntLuu.Image")));
            this.bntLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntLuu.Location = new System.Drawing.Point(229, 40);
            this.bntLuu.Name = "bntLuu";
            this.bntLuu.Size = new System.Drawing.Size(60, 25);
            this.bntLuu.TabIndex = 5;
            this.bntLuu.Text = "    Lưu";
            this.bntLuu.Click += new System.EventHandler(this.buttonLuu_Click);
            // 
            // bntSua
            // 
            this.bntSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntSua.Image = ((System.Drawing.Image)(resources.GetObject("bntSua.Image")));
            this.bntSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntSua.Location = new System.Drawing.Point(167, 40);
            this.bntSua.Name = "bntSua";
            this.bntSua.Size = new System.Drawing.Size(60, 25);
            this.bntSua.TabIndex = 14;
            this.bntSua.Text = "    Sửa";
            this.bntSua.Click += new System.EventHandler(this.buttonSua_Click);
            // 
            // bntKethuc
            // 
            this.bntKethuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntKethuc.Image = ((System.Drawing.Image)(resources.GetObject("bntKethuc.Image")));
            this.bntKethuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntKethuc.Location = new System.Drawing.Point(415, 40);
            this.bntKethuc.Name = "bntKethuc";
            this.bntKethuc.Size = new System.Drawing.Size(68, 25);
            this.bntKethuc.TabIndex = 18;
            this.bntKethuc.Text = "Kết thúc";
            this.bntKethuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntKethuc.Click += new System.EventHandler(this.buttonKetthuc_Click);
            // 
            // bntHuy
            // 
            this.bntHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntHuy.Image = ((System.Drawing.Image)(resources.GetObject("bntHuy.Image")));
            this.bntHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntHuy.Location = new System.Drawing.Point(353, 40);
            this.bntHuy.Name = "bntHuy";
            this.bntHuy.Size = new System.Drawing.Size(60, 25);
            this.bntHuy.TabIndex = 17;
            this.bntHuy.Text = "    Hủy";
            this.bntHuy.Click += new System.EventHandler(this.buttonHuy_Click);
            // 
            // bntBoqua
            // 
            this.bntBoqua.Enabled = false;
            this.bntBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntBoqua.Image = ((System.Drawing.Image)(resources.GetObject("bntBoqua.Image")));
            this.bntBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntBoqua.Location = new System.Drawing.Point(291, 40);
            this.bntBoqua.Name = "bntBoqua";
            this.bntBoqua.Size = new System.Drawing.Size(60, 25);
            this.bntBoqua.TabIndex = 16;
            this.bntBoqua.Text = "Bỏ qua";
            this.bntBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntBoqua.Click += new System.EventHandler(this.buttonBoqua_Click);
            // 
            // tenloai
            // 
            this.tenloai.BackColor = System.Drawing.Color.White;
            this.tenloai.Enabled = false;
            this.tenloai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenloai.Location = new System.Drawing.Point(160, 8);
            this.tenloai.Name = "tenloai";
            this.tenloai.Size = new System.Drawing.Size(408, 21);
            this.tenloai.TabIndex = 2;
            // 
            // bntThem
            // 
            this.bntThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntThem.Image = ((System.Drawing.Image)(resources.GetObject("bntThem.Image")));
            this.bntThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntThem.Location = new System.Drawing.Point(105, 40);
            this.bntThem.Name = "bntThem";
            this.bntThem.Size = new System.Drawing.Size(60, 25);
            this.bntThem.TabIndex = 0;
            this.bntThem.Text = "Thêm ";
            this.bntThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntThem.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // LBMa
            // 
            this.LBMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBMa.Location = new System.Drawing.Point(11, 12);
            this.LBMa.Name = "LBMa";
            this.LBMa.Size = new System.Drawing.Size(48, 16);
            this.LBMa.TabIndex = 10;
            this.LBMa.Text = "Mã loại:";
            this.LBMa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmDmloaiVTST
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(592, 357);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgLoaivtst);
            this.Font = new System.Drawing.Font("Arial", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDmloaiVTST";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục loại vị trí sinh thiết";
            this.Load += new System.EventHandler(this.frmDmloaiVTST_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLoaivtst)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmDmloaiVTST_Load(object sender, System.EventArgs e)
		{
            user = k.user;
			loadGrid();
			AddGrid();
			ena_object(true);
			ena_text(false);
		}

		private void loadGrid()
		{
			sql="select * from "+user+".gpb_loaivtst order by ma";
			ds=m.get_data(sql);
			dgLoaivtst.DataSource=ds.Tables[0];
		}

		public void AddGrid()
		{
			DataGridTableStyle tbs = new DataGridTableStyle();
			tbs.MappingName=ds.Tables[0].TableName;
			tbs.AlternatingBackColor = Color.Beige;
			tbs.BackColor = Color.GhostWhite;
			tbs.ForeColor = Color.MidnightBlue;
			tbs.GridLineColor = Color.RoyalBlue;
			tbs.HeaderBackColor = Color.MidnightBlue;
			tbs.HeaderForeColor = Color.Yellow;
			tbs.SelectionBackColor = Color.Teal;
			tbs.SelectionForeColor = Color.PaleGreen;
			tbs.ReadOnly=true;

			DataGridTextBoxColumn textCol=new DataGridTextBoxColumn();
			textCol.MappingName="ma";
			textCol.HeaderText="Mã loại VTST";
			textCol.Width=200;
			tbs.GridColumnStyles.Add(textCol);
			dgLoaivtst.TableStyles.Add(tbs);

			textCol=new DataGridTextBoxColumn();
			textCol.MappingName="ten";
			textCol.HeaderText="Tên loại VTST";
			textCol.Width=345;
			tbs.GridColumnStyles.Add(textCol);
			dgLoaivtst.TableStyles.Add(tbs);
		}

		private void ena_text(bool ena)
		{
			maloai.Enabled=ena;
			tenloai.Enabled=ena;
		}

		private void ena_object(bool ena)
		{			
			bntThem.Enabled=ena;
			bntSua.Enabled=ena;
			bntLuu.Enabled=!ena;
			bntBoqua.Enabled=!ena;
			bntHuy.Enabled=ena;
			bntKethuc.Enabled=ena;
		}

		private void buttonThem_Click(object sender, System.EventArgs e)
		{
			ena_text(true);
			ena_object(false);
			maloai.Enabled=false;
			tenloai.Clear();
            maloai.Text = Convert.ToString(int.Parse(m.get_data("select decode(max(ma),null,'00',max(ma)) as ma from " + user + ".gpb_loaivtst").Tables[0].Rows[0][0].ToString()) + 1).PadLeft(2, '0');
			tenloai.Focus();
		}

		private void buttonSua_Click(object sender, System.EventArgs e)
		{
			ena_text(true);
			ena_object(false);
			maloai.Enabled=false;
			tenloai.Focus();
		}

		private bool kiemtra()
		{
			if(maloai.Text=="" ||maloai.Text.Length!=2)
			{
				MessageBox.Show("Nhập mã loại vị trí sinh thiết!",LibMedi.AccessData.Msg);
				maloai.Focus();
				return false;				
			}
			if(tenloai.Text=="")
			{
				MessageBox.Show("Nhập tên vị trí sinh thiết!",LibMedi.AccessData.Msg);
				tenloai.Focus();
				return false;				
			}
			return true;
		}

		private void buttonLuu_Click(object sender, System.EventArgs e)
		{
			if(kiemtra())
			{
				if(!k.updgpb_loaivtst(maloai.Text.Trim(),tenloai.Text.Trim()))
				{
					MessageBox.Show("Cập nhật không thành công!",LibMedi.AccessData.Msg);
					return;
				}
				loadGrid();
			}
			ena_text(false);
			ena_object(true);
		}

		private void buttonBoqua_Click(object sender, System.EventArgs e)
		{
			ena_text(false);
			ena_object(true);
			bntThem.Focus();
		}

		private void buttonHuy_Click(object sender, System.EventArgs e)
		{
			if(MessageBox.Show("Hủy thông tin loại vị trí sinh thiết này!",LibMedi.AccessData.Msg,MessageBoxButtons.YesNo)==DialogResult.Yes)
			{
                k.execute_data("delete from " + user + ".gpb_loaivtst where ma='" + maloai.Text.Trim() + "'");
				loadGrid();
			}
		}

		private void buttonKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void dgLoaivtst_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if(dgLoaivtst.CurrentRowIndex!=-1)
			{
				maloai.Text=dgLoaivtst[dgLoaivtst.CurrentRowIndex,0].ToString();
				tenloai.Text=dgLoaivtst[dgLoaivtst.CurrentRowIndex,1].ToString();
			}
		}
	}
}
