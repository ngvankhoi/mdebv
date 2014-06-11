using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace XN
{
	/// <summary>
	/// Summary description for frmKhaibaoviettat.
	/// </summary>
	public class frmKhaibaoviettat : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private MaskedTextBox.MaskedTextBox maloai;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bntLuu;
		private System.Windows.Forms.Button bntSua;
		private System.Windows.Forms.Button bntKethuc;
		private System.Windows.Forms.Button bntHuy;
		private System.Windows.Forms.Button bntBoqua;
		private System.Windows.Forms.TextBox tenloai;
		private System.Windows.Forms.Button bntThem;
		private System.Windows.Forms.Label LBMa;
		private System.Windows.Forms.DataGrid dgViettat;
		private System.Data.DataSet ds;
		private string sql="";
		private int s_id;
		private LibMedi.AccessData m =new LibMedi.AccessData();
//		private bool bUpdate;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmKhaibaoviettat()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmKhaibaoviettat));
			this.dgViettat = new System.Windows.Forms.DataGrid();
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
			((System.ComponentModel.ISupportInitialize)(this.dgViettat)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgViettat
			// 
			this.dgViettat.AlternatingBackColor = System.Drawing.Color.Lavender;
			this.dgViettat.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dgViettat.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgViettat.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgViettat.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dgViettat.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgViettat.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.dgViettat.CaptionVisible = false;
			this.dgViettat.DataMember = "";
			this.dgViettat.FlatMode = true;
			this.dgViettat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgViettat.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dgViettat.GridLineColor = System.Drawing.Color.Gainsboro;
			this.dgViettat.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dgViettat.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.dgViettat.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
			this.dgViettat.LinkColor = System.Drawing.Color.Teal;
			this.dgViettat.Location = new System.Drawing.Point(4, 4);
			this.dgViettat.Name = "dgViettat";
			this.dgViettat.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.dgViettat.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.dgViettat.PreferredColumnWidth = 20;
			this.dgViettat.ReadOnly = true;
			this.dgViettat.RowHeaderWidth = 10;
			this.dgViettat.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.dgViettat.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dgViettat.Size = new System.Drawing.Size(588, 276);
			this.dgViettat.TabIndex = 0;
			this.dgViettat.CurrentCellChanged += new System.EventHandler(this.dgViettat_CurrentCellChanged);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.maloai,
																				 this.label1,
																				 this.bntLuu,
																				 this.bntSua,
																				 this.bntKethuc,
																				 this.bntHuy,
																				 this.bntBoqua,
																				 this.tenloai,
																				 this.bntThem,
																				 this.LBMa});
			this.panel1.Location = new System.Drawing.Point(4, 284);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(588, 96);
			this.panel1.TabIndex = 1;
			// 
			// maloai
			// 
			this.maloai.AutoSize = false;
			this.maloai.BackColor = System.Drawing.SystemColors.HighlightText;
			this.maloai.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.maloai.Location = new System.Drawing.Point(67, 8);
			this.maloai.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.maloai.MaxLength = 20000;
			this.maloai.Name = "maloai";
			this.maloai.Size = new System.Drawing.Size(80, 21);
			this.maloai.TabIndex = 0;
			this.maloai.Text = "";
			this.maloai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maloai_KeyDown);
			this.maloai.Validated += new System.EventHandler(this.maloai_Validated);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(144, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 16);
			this.label1.TabIndex = 9;
			this.label1.Text = "Tên";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// bntLuu
			// 
			this.bntLuu.Enabled = false;
			this.bntLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("bntLuu.Image")));
			this.bntLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bntLuu.Location = new System.Drawing.Point(229, 40);
			this.bntLuu.Name = "bntLuu";
			this.bntLuu.Size = new System.Drawing.Size(60, 25);
			this.bntLuu.TabIndex = 4;
			this.bntLuu.Text = "     Lưu";
			this.bntLuu.Click += new System.EventHandler(this.bntLuu_Click);
			// 
			// bntSua
			// 
			this.bntSua.Image = ((System.Drawing.Bitmap)(resources.GetObject("bntSua.Image")));
			this.bntSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bntSua.Location = new System.Drawing.Point(167, 40);
			this.bntSua.Name = "bntSua";
			this.bntSua.Size = new System.Drawing.Size(60, 25);
			this.bntSua.TabIndex = 3;
			this.bntSua.Text = "     Sửa";
			this.bntSua.Click += new System.EventHandler(this.bntSua_Click);
			// 
			// bntKethuc
			// 
			this.bntKethuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("bntKethuc.Image")));
			this.bntKethuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bntKethuc.Location = new System.Drawing.Point(415, 40);
			this.bntKethuc.Name = "bntKethuc";
			this.bntKethuc.Size = new System.Drawing.Size(68, 25);
			this.bntKethuc.TabIndex = 7;
			this.bntKethuc.Text = "Kết thúc";
			this.bntKethuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bntKethuc.Click += new System.EventHandler(this.bntKethuc_Click);
			// 
			// bntHuy
			// 
			this.bntHuy.Image = ((System.Drawing.Bitmap)(resources.GetObject("bntHuy.Image")));
			this.bntHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bntHuy.Location = new System.Drawing.Point(353, 40);
			this.bntHuy.Name = "bntHuy";
			this.bntHuy.Size = new System.Drawing.Size(60, 25);
			this.bntHuy.TabIndex = 6;
			this.bntHuy.Text = "    Hủy";
			this.bntHuy.Click += new System.EventHandler(this.bntHuy_Click);
			// 
			// bntBoqua
			// 
			this.bntBoqua.Enabled = false;
			this.bntBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("bntBoqua.Image")));
			this.bntBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bntBoqua.Location = new System.Drawing.Point(291, 40);
			this.bntBoqua.Name = "bntBoqua";
			this.bntBoqua.Size = new System.Drawing.Size(60, 25);
			this.bntBoqua.TabIndex = 5;
			this.bntBoqua.Text = "Bỏ qua";
			this.bntBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bntBoqua.Click += new System.EventHandler(this.bntBoqua_Click);
			// 
			// tenloai
			// 
			this.tenloai.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tenloai.Enabled = false;
			this.tenloai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenloai.Location = new System.Drawing.Point(176, 8);
			this.tenloai.Name = "tenloai";
			this.tenloai.Size = new System.Drawing.Size(392, 21);
			this.tenloai.TabIndex = 1;
			this.tenloai.Text = "";
			this.tenloai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maloai_KeyDown);
			// 
			// bntThem
			// 
			this.bntThem.Image = ((System.Drawing.Bitmap)(resources.GetObject("bntThem.Image")));
			this.bntThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bntThem.Location = new System.Drawing.Point(105, 40);
			this.bntThem.Name = "bntThem";
			this.bntThem.Size = new System.Drawing.Size(60, 25);
			this.bntThem.TabIndex = 2;
			this.bntThem.Text = "Thêm ";
			this.bntThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bntThem.Click += new System.EventHandler(this.bntThem_Click);
			// 
			// LBMa
			// 
			this.LBMa.Location = new System.Drawing.Point(4, 12);
			this.LBMa.Name = "LBMa";
			this.LBMa.Size = new System.Drawing.Size(59, 16);
			this.LBMa.TabIndex = 8;
			this.LBMa.Text = "Mã viết tắt";
			this.LBMa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmKhaibaoviettat
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 357);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel1,
																		  this.dgViettat});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmKhaibaoviettat";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Danh mục viết tắt";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmKhaibaoviettat_Closing);
			this.Load += new System.EventHandler(this.frmKhaibaoviettat_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgViettat)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmKhaibaoviettat_Load(object sender, System.EventArgs e)
		{
			loadGrid();
			AddGrid();
			ena_object(true);
			ena_text(false);
		}

		private void loadGrid()
		{
//			sql="select * from btdvt order by matat";
//			ds=m.get_data(sql);
			ds=new System.Data.DataSet();
			ds.ReadXml(@"..\\..\\..\\xml\\dmviettat.xml",System.Data.XmlReadMode.Auto);
			dgViettat.DataSource=ds.Tables[0];
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
			textCol.MappingName="id";
			textCol.HeaderText="Số thứ tự";
			textCol.Width=40;
			tbs.GridColumnStyles.Add(textCol);
			dgViettat.TableStyles.Add(tbs);
			//dgViettat.Visible[

			textCol=new DataGridTextBoxColumn();
			textCol.MappingName="matat";
			textCol.HeaderText="Mã viết tắt";
			textCol.Width=150;
			tbs.GridColumnStyles.Add(textCol);
			dgViettat.TableStyles.Add(tbs);

			textCol=new DataGridTextBoxColumn();
			textCol.MappingName="daydu";
			textCol.HeaderText="Tên đầy đủ";
			textCol.Width=350;
			tbs.GridColumnStyles.Add(textCol);
			dgViettat.TableStyles.Add(tbs);
		}

		private void clear_text()
		{
			maloai.Clear();
			tenloai.Clear();
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

		private void bntThem_Click(object sender, System.EventArgs e)
		{
//			bUpdate=true;
			clear_text();
			ena_text(true);
			ena_object(false);
			s_id=ds.Tables[0].Rows.Count+1;
			maloai.Focus();
		}

		private void bntSua_Click(object sender, System.EventArgs e)
		{
//			bUpdate=false;
			ena_text(true);
			ena_object(false);
			maloai.Enabled=false;
			tenloai.Focus();
		}

		private void bntLuu_Click(object sender, System.EventArgs e)
		{
			sql="id="+s_id+"";
			System.Data.DataRow r=m.getrowbyid(ds.Tables[0],sql);
			if(r==null)
			{
				System.Data.DataRow dr=ds.Tables[0].NewRow();
				dr["id"]=s_id;
				dr["matat"]=maloai.Text.Trim();
				dr["daydu"]=tenloai.Text.Trim();
				ds.Tables[0].Rows.Add(dr);
			}
			else
			{
				r["matat"]=maloai.Text.Trim();
				r["daydu"]=tenloai.Text.Trim();
			}
			dgViettat.DataSource=ds.Tables[0];
			ena_text(false);
			ena_object(true);
			bntThem.Focus();
		}

		private void bntBoqua_Click(object sender, System.EventArgs e)
		{
			ena_text(false);
			ena_object(true);
			bntKethuc.Focus();
		}

		private void bntHuy_Click(object sender, System.EventArgs e)
		{
			if(dgViettat.CurrentRowIndex!=-1 && dgViettat.CurrentRowIndex<ds.Tables[0].Rows.Count)
			{
				int ind=dgViettat.CurrentRowIndex;
				ds.Tables[0].Rows.RemoveAt(ind);
				dgViettat.DataSource=ds.Tables[0];
			}
		}

		private void bntKethuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void dgViettat_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if(dgViettat.CurrentRowIndex!=-1)
			{
				s_id=int.Parse(dgViettat[dgViettat.CurrentRowIndex,0].ToString());
				maloai.Text=dgViettat[dgViettat.CurrentRowIndex,1].ToString();
				tenloai.Text=dgViettat[dgViettat.CurrentRowIndex,2].ToString();
			}
		}

		private void frmKhaibaoviettat_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			ds.WriteXml(@"..\\..\\..\\xml\\dmviettat.xml",System.Data.XmlWriteMode.WriteSchema);
		}

		private void maloai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void maloai_Validated(object sender, System.EventArgs e)
		{
			string s_mavt=maloai.Text.Trim();
			if(ds.Tables[0].Select("matat='"+s_mavt+"'").Length>0 && s_mavt!="")
			{
				MessageBox.Show("Đã tồn tại mã viết tắt này!",LibMedi.AccessData.Msg);
				maloai.Clear();
				maloai.Focus();
				return;
			}		
		}
	}
}
