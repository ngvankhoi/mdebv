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
	/// Summary description for frmSlkhambenh.
	/// </summary>
	public class frmthngtr : System.Windows.Forms.Form
	{
		Language lan = new Language();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butIn;
		private Export exp=new Export();
		private AccessData m;
		private string s_makp;
		private DataSet ds=new DataSet();
		private DataTable dtkp=new DataTable();
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.CheckedListBox makp;
		private System.Windows.Forms.CheckBox time;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmthngtr(AccessData acc,string kp)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;s_makp=kp;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmthngtr));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tu = new System.Windows.Forms.DateTimePicker();
			this.den = new System.Windows.Forms.DateTimePicker();
			this.butKetthuc = new System.Windows.Forms.Button();
			this.butIn = new System.Windows.Forms.Button();
			this.makp = new System.Windows.Forms.CheckedListBox();
			this.time = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label1.Location = new System.Drawing.Point(-10, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Từ ngày ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label2.Location = new System.Drawing.Point(144, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(24, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "đến ";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tu
			// 
			this.tu.CustomFormat = "dd/MM/yyyy";
			this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.tu.Location = new System.Drawing.Point(64, 7);
			this.tu.Name = "tu";
			this.tu.Size = new System.Drawing.Size(80, 21);
			this.tu.TabIndex = 1;
			this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
			// 
			// den
			// 
			this.den.CustomFormat = "dd/MM/yyyy";
			this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.den.Location = new System.Drawing.Point(176, 7);
			this.den.Name = "den";
			this.den.Size = new System.Drawing.Size(80, 21);
			this.den.TabIndex = 3;
			this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
			// 
			// butKetthuc
			// 
			this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(134, 193);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(75, 28);
			this.butKetthuc.TabIndex = 6;
			this.butKetthuc.Text = "&Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// butIn
			// 
			this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butIn.Image = ((System.Drawing.Bitmap)(resources.GetObject("butIn.Image")));
			this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butIn.Location = new System.Drawing.Point(56, 193);
			this.butIn.Name = "butIn";
			this.butIn.Size = new System.Drawing.Size(75, 28);
			this.butIn.TabIndex = 5;
			this.butIn.Text = "     &In";
			this.butIn.Click += new System.EventHandler(this.butIn_Click);
			// 
			// makp
			// 
			this.makp.CheckOnClick = true;
			this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.makp.Location = new System.Drawing.Point(64, 31);
			this.makp.Name = "makp";
			this.makp.Size = new System.Drawing.Size(192, 132);
			this.makp.TabIndex = 4;
			this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
			// 
			// time
			// 
			this.time.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.time.Location = new System.Drawing.Point(64, 170);
			this.time.Name = "time";
			this.time.Size = new System.Drawing.Size(216, 16);
			this.time.TabIndex = 88;
			this.time.Text = "checkBox1";
			// 
			// frmthngtr
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(264, 237);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.time,
																		  this.makp,
																		  this.butKetthuc,
																		  this.butIn,
																		  this.den,
																		  this.tu,
																		  this.label2,
																		  this.label1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmthngtr";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Báo cáo tổng hợp ngoại trú";
			this.Load += new System.EventHandler(this.frmthngtr_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			s_makp="'";
			if (makp.CheckedItems.Count==0) 
				for(int i=0;i<makp.Items.Count;i++) makp.SetItemCheckState(i,CheckState.Checked);
			for(int i=0;i<makp.Items.Count;i++) 
				if (makp.GetItemChecked(i)) s_makp+=dtkp.Rows[i]["makp"].ToString()+"','";
			s_makp=(s_makp!="")?s_makp.Substring(0,s_makp.Length-2):"";
			ds=exp.get_thngtru(tu.Text,den.Text,s_makp,time.Checked);
			if (ds.Tables[0].Rows.Count>0)
			{
				frmReport f=new frmReport(m,ds,(tu.Text==den.Text)?"Ngày "+tu.Text:"Từ ngày "+tu.Text+" đến "+den.Text,"rptthngtr.rpt",0,0,0,0,0,0,0,0,0,0);
				f.ShowDialog();
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmthngtr_Load(object sender, System.EventArgs e)
		{
			time.Text=lan.Change_language_MessageText("Giờ báo cáo ")+" "+m.sGiobaocao;
			string sql="select * from btdkp_bv where makp<>'01' and (maba like '%20%'";
			sql+=" or maba like '%21%'";
			sql+=" or maba like '%22%'";
			sql+=" or maba like '%23%')";
			if (s_makp!="" )
			{
				string s=s_makp.Replace(",","','");
				sql+=" and makp in ('"+s.Substring(0,s.Length-3)+"')";
			}
			sql+=" order by loai,makp";
			dtkp=m.get_data(sql).Tables[0];
			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
			makp.DataSource=dtkp;
		}
	}
}
