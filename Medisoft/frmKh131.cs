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
	/// Summary description for frmBieu01.
	/// </summary>
	public class frmKh131 : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker ngay;
		private System.Windows.Forms.ComboBox cmbNgay;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		private string s_userid,sql;
		private int i_userid,i_mabv,i_tong,i_col,i_row=0,i_ma;
		private decimal l_id=0;
		private DataSet ds=new DataSet();
		private System.Windows.Forms.DataGrid dataGrid1;
		private DataTable dt=new DataTable();
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.TextBox dk;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butHuy;
		private bool bPhatsinh;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmKh131(AccessData acc,string hoten,int userid,int mabv)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			s_userid=hoten;
			i_userid=userid;
			i_mabv=mabv;
			this.Text+="//"+s_userid;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        public frmKh131(string hoten, int userid, int mabv)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = new AccessData();
            s_userid = hoten;
            i_userid = userid;
            i_mabv = mabv;
            this.Text += "//" + s_userid;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKh131));
            this.label1 = new System.Windows.Forms.Label();
            this.ngay = new System.Windows.Forms.DateTimePicker();
            this.cmbNgay = new System.Windows.Forms.ComboBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.ten = new System.Windows.Forms.TextBox();
            this.dk = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butHuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngay
            // 
            this.ngay.CustomFormat = "dd/MM/yyyy";
            this.ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngay.Location = new System.Drawing.Point(40, 4);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(88, 20);
            this.ngay.TabIndex = 1;
            this.ngay.Visible = false;
            this.ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // cmbNgay
            // 
            this.cmbNgay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNgay.Location = new System.Drawing.Point(40, 4);
            this.cmbNgay.Name = "cmbNgay";
            this.cmbNgay.Size = new System.Drawing.Size(88, 21);
            this.cmbNgay.TabIndex = 2;
            this.cmbNgay.SelectedIndexChanged += new System.EventHandler(this.cmbNgay_SelectedIndexChanged);
            this.cmbNgay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbNgay_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(149, 500);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(82, 25);
            this.butMoi.TabIndex = 6;
            this.butMoi.Text = "   &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(231, 500);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(82, 25);
            this.butSua.TabIndex = 7;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(313, 500);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(82, 25);
            this.butLuu.TabIndex = 4;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(395, 500);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(82, 25);
            this.butBoqua.TabIndex = 5;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(559, 500);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(88, 25);
            this.butKetthuc.TabIndex = 9;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 10);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 485);
            this.dataGrid1.TabIndex = 3;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataGrid1_Navigate);
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(130, 4);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(422, 21);
            this.ten.TabIndex = 42;
            // 
            // dk
            // 
            this.dk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dk.Enabled = false;
            this.dk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dk.Location = new System.Drawing.Point(568, 4);
            this.dk.Name = "dk";
            this.dk.Size = new System.Drawing.Size(216, 21);
            this.dk.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(556, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(8, 23);
            this.label2.TabIndex = 44;
            this.label2.Text = "=";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(477, 500);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(82, 25);
            this.butHuy.TabIndex = 8;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // frmKh131
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dk);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.cmbNgay);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKh131";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biểu 13.1//Thực hiện công tác phòng bệnh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmKh131_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmKh131_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			bPhatsinh=m.bSolieu;
			cmbNgay.DisplayMember="NGAY";
			cmbNgay.ValueMember="ID";
			load_ngay();
			dt=m.get_data("select * from "+m.user+".kh_dm_131_dk").Tables[0];
			load_grid(false);
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			dataGrid1.Visible=false;
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

			dataGrid1.Visible=true;
			dataGrid1.ReadOnly=true;
		}
		
		private void load_grid(bool dm)
		{
			if (dm)	ds=m.get_data("select * from "+m.user+".kh_dm_131 order by ma");
			else load_data();
			dataGrid1.DataSource=ds.Tables[0];
		}

		private void load_data()
		{
			if (bPhatsinh)
			{
				sql="select a.*,b.stt,b.ten from "+m.user+".kh_bieu_131 a,"+m.user+".kh_dm_131 b where a.ma=b.ma and a.id="+l_id+" order by a.ma";
				ds=m.get_data(sql);
			}
			else
			{
				load_value(false);
			}
		}

		private void load_value(bool load)
		{
			ds=m.get_data("select * from "+m.user+".kh_dm_131 order by ma");
			DataRow[] dr;
			foreach(DataRow r in m.get_data("select * from "+m.user+".kh_bieu_131 where id="+l_id).Tables[0].Rows)
			{
				dr=ds.Tables[0].Select("ma="+int.Parse(r["ma"].ToString()));
				if (dr!=null)
				{
					dr[0]["c01"]=r["c01"].ToString();
					dr[0]["c02"]=r["c02"].ToString();
					dr[0]["c03"]=r["c03"].ToString();
					dr[0]["c04"]=r["c04"].ToString();
					dr[0]["c05"]=r["c05"].ToString();
					dr[0]["c06"]=r["c06"].ToString();
					dr[0]["c07"]=r["c07"].ToString();
					dr[0]["c08"]=r["c08"].ToString();
					dr[0]["c09"]=r["c09"].ToString();
					dr[0]["c10"]=r["c10"].ToString();
					dr[0]["c11"]=r["c11"].ToString();
					dr[0]["c12"]=r["c12"].ToString();
					dr[0]["c13"]=r["c13"].ToString();
					dr[0]["c14"]=r["c14"].ToString();
					dr[0]["c15"]=r["c15"].ToString();
					dr[0]["c16"]=r["c16"].ToString();
					dr[0]["c17"]=r["c17"].ToString();
					dr[0]["c18"]=r["c18"].ToString();
					dr[0]["c19"]=r["c19"].ToString();
					dr[0]["c20"]=r["c20"].ToString();
					dr[0]["c21"]=r["c21"].ToString();
					dr[0]["c22"]=r["c22"].ToString();
					dr[0]["c23"]=r["c23"].ToString();
				}
			}
			if (load) dataGrid1.DataSource=ds.Tables[0];
		}

		private void load_ngay()
		{
			cmbNgay.DataSource=m.get_data("select ID,to_char(ngay,'dd/mm/yyyy') as NGAY from "+m.user+".kh_bieu_131 group by id,ngay order by ngay").Tables[0];
		}

		private void ena_object(bool ena)
		{
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butKetthuc.Enabled=!ena;
			butHuy.Enabled=!ena;
			dataGrid1.ReadOnly=!ena;
			ngay.Visible=ena;
			cmbNgay.Visible=!ena;
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			l_id=m.get_capid(39);
			load_grid(true);
			ena_object(true);
			ngay.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (cmbNgay.Items.Count==0) return;
			try
			{
				l_id=decimal.Parse(cmbNgay.SelectedValue.ToString());
				int dd=int.Parse(cmbNgay.Text.Substring(0,2));
				int mm=int.Parse(cmbNgay.Text.Substring(3,2));
				int yyyy=int.Parse(cmbNgay.Text.Substring(6,4));
				ngay.Value=new DateTime(yyyy,mm,dd,0,0,0);
				load_value(true);
				ena_object(true);
				dataGrid1.Focus();
			}
			catch{}
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (ds.HasChanges()) Tongcong();
				if (ds.HasChanges())
				{
					m.execute_data("delete from "+m.user+".kh_bieu_131 where id="+l_id);
					string exp="c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11+c12+c13+c14+c15+c16+c17+c18+c19+c20+c21+c22+c23>0";
					DataRow[] r=ds.Tables[0].Select(exp);
					Int16 iRec=Convert.ToInt16(r.Length);
					for(Int16 i=0;i<iRec;i++)
					{
                        //ThanhCuong 25/02/2012
                        m.upd_kh131(l_id, int.Parse(r[i]["ma"].ToString()), ngay.Text, int.Parse(r[i]["c01"].ToString()),
                            int.Parse(r[i]["c02"].ToString()), int.Parse(r[i]["c03"].ToString()), int.Parse(r[i]["c04"].ToString()),
                            int.Parse(r[i]["c05"].ToString()), int.Parse(r[i]["c06"].ToString()), int.Parse(r[i]["c07"].ToString()),
                            int.Parse(r[i]["c08"].ToString()), int.Parse(r[i]["c09"].ToString()), int.Parse(r[i]["c10"].ToString()),
                            int.Parse(r[i]["c11"].ToString()), int.Parse(r[i]["c12"].ToString()), int.Parse(r[i]["c13"].ToString()),
                            int.Parse(r[i]["c14"].ToString()), int.Parse(r[i]["c15"].ToString()), int.Parse(r[i]["c16"].ToString()),
                            int.Parse(r[i]["c17"].ToString()), int.Parse(r[i]["c18"].ToString()), int.Parse(r[i]["c19"].ToString()),
                            int.Parse(r[i]["c20"].ToString()), int.Parse(r[i]["c21"].ToString()), int.Parse(r[i]["c22"].ToString()),
                            int.Parse(r[i]["c23"].ToString()), i_userid, r[i]["c24"].ToString());
                        //
					}
				}
				ena_object(false);
				decimal id=l_id;
				load_ngay();
				cmbNgay.SelectedValue=id.ToString();
				l_id=id;
			}
			catch{}
			load_grid(false);
			butMoi.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
			try
			{
				l_id=decimal.Parse(cmbNgay.SelectedValue.ToString());
			}
			catch{l_id=0;}
			load_grid(false);
			butMoi.Focus();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (cmbNgay.Items.Count==0) return;
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				l_id=decimal.Parse(cmbNgay.SelectedValue.ToString());
				m.execute_data("delete from "+m.user+".kh_bieu_131 where id="+l_id);
				load_ngay();
				load_grid(false);
			}
		}

		private void cmbNgay_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				l_id=decimal.Parse(cmbNgay.SelectedValue.ToString());
				load_grid(false);
			}
			catch{l_id=0;}
		}

		private void ngay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void AddGridTableStyle()
		{
			DataGridColoredTextBoxColumn TextCol1;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=10;
			ts.MappingName = ds.Tables[0].TableName;
			ts.AllowSorting=false;
			
			TextCol1=new DataGridColoredTextBoxColumn(de, 0);
			TextCol1.MappingName = "ma";
			TextCol1.HeaderText = "ma";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 1);
			TextCol1.MappingName = "stt";
			TextCol1.HeaderText = "STT";
			TextCol1.Width = 24;
			TextCol1.ReadOnly=true;
			TextCol1.Alignment=HorizontalAlignment.Center;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 2);
			TextCol1.MappingName = "ten";
			TextCol1.HeaderText = "Cơ sở, trạm y tế thuộc TTYT huyện";
			TextCol1.Width = 190;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 3);
			TextCol1.MappingName = "C01";
			TextCol1.HeaderText = "C01";
			TextCol1.Width = 39;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 4);
			TextCol1.MappingName = "C02";
			TextCol1.HeaderText = "C02";
			TextCol1.Width = 39;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 5);
			TextCol1.MappingName = "C03";
			TextCol1.HeaderText = "C03";
			TextCol1.Width = 39;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 6);
			TextCol1.MappingName = "C04";
			TextCol1.HeaderText = "C04";
			TextCol1.Width = 39;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 7);
			TextCol1.MappingName = "C05";
			TextCol1.HeaderText = "C05";
			TextCol1.Width = 39;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 8);
			TextCol1.MappingName = "C06";
			TextCol1.HeaderText = "C06";
			TextCol1.Width = 39;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 9);
			TextCol1.MappingName = "C07";
			TextCol1.HeaderText = "C07";
			TextCol1.Width = 39;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 10);
			TextCol1.MappingName = "C08";
			TextCol1.HeaderText = "C08";
			TextCol1.Width = 39;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 11);
			TextCol1.MappingName = "C09";
			TextCol1.HeaderText = "C09";
			TextCol1.Width = 39;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 12);
			TextCol1.MappingName = "C10";
			TextCol1.HeaderText = "C10";
			TextCol1.Width = 39;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 13);
			TextCol1.MappingName = "C11";
			TextCol1.HeaderText = "C11";
			TextCol1.Width = 39;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 14);
			TextCol1.MappingName = "C12";
			TextCol1.HeaderText = "C12";
			TextCol1.Width = 39;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 15);
			TextCol1.MappingName = "C13";
			TextCol1.HeaderText = "C13";
			TextCol1.Width = 39;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 16);
			TextCol1.MappingName = "C14";
			TextCol1.HeaderText = "C14";
			TextCol1.Width = 39;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 17);
			TextCol1.MappingName = "C15";
			TextCol1.HeaderText = "C15";
			TextCol1.Width = 39;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 18);
			TextCol1.MappingName = "C16";
			TextCol1.HeaderText = "C16";
			TextCol1.Width = 39;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 19);
			TextCol1.MappingName = "C17";
			TextCol1.HeaderText = "C17";
			TextCol1.Width = 39;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 20);
			TextCol1.MappingName = "C18";
			TextCol1.HeaderText = "C18";
			TextCol1.Width = 39;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 21);
			TextCol1.MappingName = "C19";
			TextCol1.HeaderText = "C19";
			TextCol1.Width = 39;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 22);
			TextCol1.MappingName = "C20";
			TextCol1.HeaderText = "C20";
			TextCol1.Width = 39;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 23);
			TextCol1.MappingName = "C21";
			TextCol1.HeaderText = "C22";
			TextCol1.Width = 39;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 24);
			TextCol1.MappingName = "C22";
			TextCol1.HeaderText = "C22";
			TextCol1.Width = 39;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 25);
			TextCol1.MappingName = "C23";
			TextCol1.HeaderText = "C23";
			TextCol1.Width = 39;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			string s="ABC";
			Color c = Color.Black;
			if (s.IndexOf(this.dataGrid1[row,1].ToString().Trim())!=-1)
			{
				c=Color.Red;
				i_tong=row;
			}
			if (row==i_tong) c=Color.Red;
			return c;
		}
		public delegate Color delegateGetColorRowCol(int row, int col);
		public class DataGridColoredTextBoxColumn : DataGridTextBoxColumn
		{
			private delegateGetColorRowCol _getColorRowCol;
			private int _column;
			public DataGridColoredTextBoxColumn(delegateGetColorRowCol getcolorRowCol, int column)
			{
				_getColorRowCol = getcolorRowCol;
				_column = column;
			}
			protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
			{
				try
				{
					foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
					//backBrush = new SolidBrush(Color.GhostWhite);
				}
			
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}
		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			i_col=dataGrid1.CurrentCell.ColumnNumber-2;
			//i_row=dataGrid1.CurrentCell.RowNumber;
			DataRow r1=m.getrowbyid(dt,"ma='"+"C"+i_col.ToString().PadLeft(2,'0')+"'");
			if (r1!=null)
			{
				ten.Text=r1[1].ToString();
				dk.Text=r1[2].ToString();
			}
			else
			{
				ten.Text="";
				dk.Text="";
			}
			if (butMoi.Enabled) return;
			Decimal l_tong=0;
			string exp="ma>=51",stt="C";
			try
			{
				i_col=dataGrid1.CurrentCell.ColumnNumber;
				//i_row=dataGrid1.CurrentCell.RowNumber;
				i_ma=int.Parse(dataGrid1[i_row,0].ToString());
				if (i_col<3) return;
				exp="ma>=51";stt="C";
				if ((i_ma>=1 && i_ma<=50) || (dataGrid1[i_row,1].ToString()=="B"))
				{
					exp="ma>=1 and ma<=49";
					stt="B";
				}
				DataRow[] r=ds.Tables[0].Select(exp);
				Int16 iRec=Convert.ToInt16(r.Length);
				for(Int16 i=0;i<iRec;i++) l_tong+=Decimal.Parse(r[i][i_col].ToString());
				m.updrec_05(ds.Tables[0],stt,i_col,l_tong);
				if (i_col>=4 && i_col<=6 && dataGrid1[i_row,i_col].ToString()!="")
				{
					if (decimal.Parse(dataGrid1[i_row,4].ToString())+decimal.Parse(dataGrid1[i_row,5].ToString())+decimal.Parse(dataGrid1[i_row,6].ToString())>decimal.Parse(dataGrid1[i_row,3].ToString()))
					{
						MessageBox.Show(lan.Change_language_MessageText("Số liệu không hợp lệ !"),LibMedi.AccessData.Msg);
						dataGrid1[i_row,i_col]=0;
					}
				}
				else if (i_col>=9 && i_col<=10 && dataGrid1[i_row,i_col].ToString()!="")
				{
					if (decimal.Parse(dataGrid1[i_row,9].ToString())+decimal.Parse(dataGrid1[i_row,10].ToString())>decimal.Parse(dataGrid1[i_row,8].ToString()))
					{
						MessageBox.Show(lan.Change_language_MessageText("Số liệu không hợp lệ !"),LibMedi.AccessData.Msg);
						dataGrid1[i_row,i_col]=0;
					}
				}
				else if (i_col>=16 && i_col<=17 && dataGrid1[i_row,i_col].ToString()!="")
				{
					if (decimal.Parse(dataGrid1[i_row,16].ToString())+decimal.Parse(dataGrid1[i_row,17].ToString())>decimal.Parse(dataGrid1[i_row,15].ToString()))
					{
						MessageBox.Show(lan.Change_language_MessageText("Số liệu không hợp lệ !"),LibMedi.AccessData.Msg);
						dataGrid1[i_row,i_col]=0;
					}
				}
				else if (i_col>=19 && i_col<=20 && dataGrid1[i_row,i_col].ToString()!="")
				{
					if (decimal.Parse(dataGrid1[i_row,19].ToString())+decimal.Parse(dataGrid1[i_row,20].ToString())>decimal.Parse(dataGrid1[i_row,18].ToString()))
					{
						MessageBox.Show(lan.Change_language_MessageText("Số liệu không hợp lệ !"),LibMedi.AccessData.Msg);
						dataGrid1[i_row,i_col]=0;
					}
				}
				else if (i_col==23 && dataGrid1[i_row,i_col].ToString()!="")
				{
					if (decimal.Parse(dataGrid1[i_row,23].ToString())>decimal.Parse(dataGrid1[i_row,22].ToString()))
					{
						MessageBox.Show(lan.Change_language_MessageText("Số liệu không hợp lệ !"),LibMedi.AccessData.Msg);
						dataGrid1[i_row,i_col]=0;
					}
				}
				i_row=dataGrid1.CurrentRowIndex;
			}
			catch
			{
				try
				{
					exp="ma>=51";stt="C";
					DataRow[] r=ds.Tables[0].Select(exp);
					Int16 iRec=Convert.ToInt16(r.Length);
					for(Int16 i=0;i<iRec;i++) l_tong+=Decimal.Parse(r[i][i_col].ToString());
					m.updrec_05(ds.Tables[0],stt,i_col,l_tong);
					i_row=dataGrid1.CurrentRowIndex;
				}
				catch{}
			}
		}

		private void cmbNgay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) butMoi.Focus();
		}

		private void Tongcong()
		{
			for(int k=3;k<ds.Tables[0].Columns.Count;k++)
			{
				sum("ma>=1 and ma<=49","B",k);
				sum("ma>=51","C",k);
			}
		}
		
		private void sum(string exp,string stt,int k)
		{
			DataRow[] r;
			Int16 iRec;
			decimal l_tong=0;
			r=ds.Tables[0].Select(exp);
			iRec=Convert.ToInt16(r.Length);
			for(Int16 i=0;i<iRec;i++) l_tong+=decimal.Parse(r[i][k].ToString());
			m.updrec_05(ds.Tables[0],stt,k,l_tong);
		}

        private void dataGrid1_Navigate(object sender, NavigateEventArgs ne)
        {

        }
	}
}
