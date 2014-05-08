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
	/// Summary description for frmViewtd.
	/// </summary>
	public class frmViewtd : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        //lan.Read_Language_to_Xml(this.Name.ToString(),this);
        //lan.Changelanguage_to_English(this.Name.ToString(),this);tv.GanBogo(this, textBox111);
        //lan.Change_language_MessageText(
        //lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
        //lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker ngay;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.Button butKetthuc;
		private DataTable dt=new DataTable();
		private string sql,user,xxx,s_makp;
		private bool bClear=true;
		private AccessData m;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmViewtd(AccessData acc,string _makp)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(),this);
            lan.Changelanguage_to_English(this.Name.ToString(),this);

            m = acc; s_makp = _makp; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewtd));
            this.makp = new System.Windows.Forms.ComboBox();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ngay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butXem = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // makp
            // 
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(190, 5);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(171, 21);
            this.makp.TabIndex = 1;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // madoituong
            // 
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(424, 5);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(128, 21);
            this.madoituong.TabIndex = 2;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(360, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "Đối tượng :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngay
            // 
            this.ngay.CustomFormat = "dd/MM/yyyy";
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngay.Location = new System.Drawing.Point(40, 5);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(80, 21);
            this.ngay.TabIndex = 0;
            this.ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(104, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Phòng khám :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-20, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "Ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.dataGrid1.Size = new System.Drawing.Size(544, 328);
            this.dataGrid1.TabIndex = 5;
            // 
            // butXem
            // 
            this.butXem.Image = ((System.Drawing.Image)(resources.GetObject("butXem.Image")));
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(210, 344);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 3;
            this.butXem.Text = "    &Xem";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(281, 344);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 4;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // frmViewtd
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.butKetthuc;
            this.ClientSize = new System.Drawing.Size(562, 391);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmViewtd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin đăng ký khám bệnh";
            this.Load += new System.EventHandler(this.frmViewtd_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmViewtd_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmViewtd_Load(object sender, System.EventArgs e)
		{
			user=m.user;
			string sql="select * from "+user+".btdkp_bv where makp<>'01' and loai=1";
			if (s_makp!="" )
			{
				string s=s_makp.Replace(",","','");
				sql+=" and makp in ('"+s.Substring(0,s.Length-3)+"')";
			}
			sql+=" order by loai desc,makp";
			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
			makp.DataSource=m.get_data(sql).Tables[0];

			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
			madoituong.DataSource=m.get_data("select * from "+user+".doituong order by madoituong").Tables[0];		

			load_grid();
			AddGridTableStyle();
            lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
            lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
            // hien
            frmOutput f = new frmOutput(m, DateTime.Now.ToString("dd/MM/yyyy"));
            f.Show(this);
		}

		private void frmViewtd_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				makp.SelectedIndex=-1;
				madoituong.SelectedIndex=-1;
				bClear=false;
			}
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
			TextCol.MappingName = "tenkp";
			TextCol.HeaderText = "Phòng khám";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tongso";
			TextCol.HeaderText = "Tổng số";
			TextCol.Width = 90;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "chua";
			TextCol.HeaderText = "Chưa khám";
			TextCol.Width = 90;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dichvu";
			TextCol.HeaderText = "Đi làm dịch vụ";
			TextCol.Width = 90;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "xong";
			TextCol.HeaderText = "Đã khám";
			TextCol.Width = 90;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{
			load_grid();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void load_grid()
		{
			string mmyy=m.mmyy(ngay.Text);
			if (m.bMmyy(mmyy))
			{
				xxx=user+mmyy;
				sql="select b.tenkp,sum(1) as tongso,sum(case when a.done is null then 1 else 0 end) as chua,";
				sql+="sum(case when a.done='?' then 1 else 0 end) as dichvu,sum(case when a.done is not null then 1 else 0 end) as xong ";
				sql+=" from "+xxx+".tiepdon a,"+user+".btdkp_bv b where a.makp=b.makp and a.noitiepdon in (0,1,5) and b.loai=1";
				sql+=" and to_char(a.ngay,'dd/mm/yyyy')='"+ngay.Text+"'";
				if (makp.SelectedIndex!=-1) sql+=" and a.makp='"+makp.SelectedValue.ToString()+"'";
				if (madoituong.SelectedIndex!=-1) sql+=" and a.madoituong="+int.Parse(madoituong.SelectedValue.ToString());
				sql+=" group by b.tenkp order by b.tenkp";
				dt=m.get_data(sql).Tables[0];
				dataGrid1.DataSource=dt;
			}
		}

		private void ngay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}
	}
}
