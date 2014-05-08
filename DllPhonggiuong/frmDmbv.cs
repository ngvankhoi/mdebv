using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using LibMedi;

namespace DllPhonggiuong
{
	public class frmDmbv : System.Windows.Forms.Form
	{
		Language lan = new Language();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox tenbv;
		private System.Windows.Forms.TextBox mabv;
		private AsYetUnnamed.MultiColumnListBox dmbv;
		private System.Windows.Forms.Button butChon;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		public string m_mabv,m_loaibv;
		private bool b_chon;
		private System.ComponentModel.Container components = null;

		public frmDmbv(AccessData acc,string s_mabv,string loaibv,bool chon)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;
			m_mabv=s_mabv;
			b_chon=chon;
			m_loaibv=loaibv;
		}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDmbv));
			this.label1 = new System.Windows.Forms.Label();
			this.tenbv = new System.Windows.Forms.ComboBox();
			this.mabv = new System.Windows.Forms.TextBox();
			this.dmbv = new AsYetUnnamed.MultiColumnListBox();
			this.butChon = new System.Windows.Forms.Button();
			this.butKetthuc = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(-2, 12);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Tỉnh/Thành phố :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tenbv
			// 
			this.tenbv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tenbv.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenbv.Location = new System.Drawing.Point(136, 12);
			this.tenbv.Name = "tenbv";
			this.tenbv.Size = new System.Drawing.Size(262, 22);
			this.tenbv.TabIndex = 2;
			this.tenbv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
			this.tenbv.SelectedIndexChanged += new System.EventHandler(this.tenbv_SelectedIndexChanged);
			// 
			// mabv
			// 
			this.mabv.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabv.Location = new System.Drawing.Point(102, 12);
			this.mabv.MaxLength = 3;
			this.mabv.Name = "mabv";
			this.mabv.Size = new System.Drawing.Size(32, 22);
			this.mabv.TabIndex = 1;
			this.mabv.Text = "";
			this.mabv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabv_KeyDown);
			this.mabv.Validated += new System.EventHandler(this.mabv_Validated);
			// 
			// dmbv
			// 
			this.dmbv.ColumnCount = 0;
			this.dmbv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dmbv.Location = new System.Drawing.Point(14, 40);
			this.dmbv.MatchBufferTimeOut = 1000;
			this.dmbv.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
			this.dmbv.Name = "dmbv";
			this.dmbv.Size = new System.Drawing.Size(384, 277);
			this.dmbv.TabIndex = 3;
			this.dmbv.TextIndex = -1;
			this.dmbv.TextMember = null;
			this.dmbv.ValueIndex = -1;
			this.dmbv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dmbv_KeyDown);
			// 
			// butChon
			// 
			this.butChon.Image = ((System.Drawing.Bitmap)(resources.GetObject("butChon.Image")));
			this.butChon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butChon.Location = new System.Drawing.Point(112, 329);
			this.butChon.Name = "butChon";
			this.butChon.Size = new System.Drawing.Size(88, 28);
			this.butChon.TabIndex = 4;
			this.butChon.Text = "   &Chọn ";
			this.butChon.Click += new System.EventHandler(this.butChon_Click);
			// 
			// butKetthuc
			// 
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(211, 329);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(85, 28);
			this.butKetthuc.TabIndex = 5;
			this.butKetthuc.Text = "&Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// frmDmbv
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(416, 373);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.butKetthuc,
																		  this.butChon,
																		  this.dmbv,
																		  this.mabv,
																		  this.tenbv,
																		  this.label1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmDmbv";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Danh mục bệnh viện";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDmbv_KeyDown);
			this.Load += new System.EventHandler(this.frmDmbv_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmDmbv_Load(object sender, System.EventArgs e)
		{
			tenbv.DisplayMember="TENTT";
			tenbv.ValueMember="MATT";
			tenbv.DataSource=m.get_data("select * from btdtt where matt<>'000' order by matt").Tables[0];
			m_mabv=(m_mabv!="" && m_mabv.Length>2)?m_mabv.Substring(0,3):m.Mabv.Substring(0,3);
			tenbv.SelectedValue=m_mabv;
			
			dmbv.DisplayMember="TENBV";
			dmbv.ValueMember="MABV";
			dmbv.ColumnWidths[0]=60;
			dmbv.ColumnWidths[1]=400;
			load_dmbv();
			butChon.Visible=b_chon;
			if (!b_chon) butKetthuc.Left=171;
		}

		private void load_dmbv()
		{
			try
			{
				if (m_loaibv=="3")
					dmbv.DataSource=m.get_data("select MABV,TENBV from tenvien where substr(maloai,1,1)='2' and matinh='"+tenbv.SelectedValue.ToString().Substring(0,3)+"'"+" and mabv<>'"+m.Mabv+"'"+" order by mabv").Tables[0];
				else
					dmbv.DataSource=m.get_data("select MABV,TENBV from tenvien where matinh='"+tenbv.SelectedValue.ToString().Substring(0,3)+"'"+" and mabv<>'"+m.Mabv+"'"+" order by mabv").Tables[0];
			}
			catch{}
		}

		private void mabv_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tenbv.SelectedValue=mabv.Text;
			}
			catch{}
		}

		private void mabv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void tenbv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenbv.SelectedIndex==-1) tenbv.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tenbv_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				mabv.Text=tenbv.SelectedValue.ToString();
				load_dmbv();
			}
			catch{}	
		}

		private void butChon_Click(object sender, System.EventArgs e)
		{
			m_mabv=dmbv.SelectedValue.ToString();
			this.Close();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m_mabv="";
			this.Close();
		}

		private void dmbv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) butChon_Click(null,null);
		}

		private void frmDmbv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}
	}
}
