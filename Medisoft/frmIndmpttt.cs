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
	/// Summary description for frmIcd10.
	/// </summary>
	public class frmIndmpttt : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butKetthuc;
		private DataSet ds=new DataSet();
		private AccessData m;
		private string user,sql,s_mapt,s_muc;
		private DataTable dtmuc=new DataTable();
		private System.Windows.Forms.ComboBox loai;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.CheckedListBox muc;
		private System.Windows.Forms.CheckedListBox pttt;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmIndmpttt(AccessData acc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIndmpttt));
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.loai = new System.Windows.Forms.ComboBox();
            this.muc = new System.Windows.Forms.CheckedListBox();
            this.pttt = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(263, 352);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(89, 25);
            this.butIn.TabIndex = 13;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(353, 352);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(89, 25);
            this.butKetthuc.TabIndex = 16;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // loai
            // 
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(8, 9);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(160, 21);
            this.loai.TabIndex = 1;
            this.loai.SelectedIndexChanged += new System.EventHandler(this.loai_SelectedIndexChanged);
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
            // 
            // muc
            // 
            this.muc.CheckOnClick = true;
            this.muc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.muc.Location = new System.Drawing.Point(8, 33);
            this.muc.Name = "muc";
            this.muc.Size = new System.Drawing.Size(160, 340);
            this.muc.TabIndex = 17;
            this.muc.SelectedIndexChanged += new System.EventHandler(this.muc_SelectedIndexChanged);
            // 
            // pttt
            // 
            this.pttt.CheckOnClick = true;
            this.pttt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pttt.Location = new System.Drawing.Point(171, 7);
            this.pttt.Name = "pttt";
            this.pttt.Size = new System.Drawing.Size(525, 340);
            this.pttt.TabIndex = 18;
            // 
            // frmIndmpttt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(704, 389);
            this.Controls.Add(this.pttt);
            this.Controls.Add(this.muc);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butKetthuc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIndmpttt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In danh mục phẫu thuật - thủ thuật";
            this.Load += new System.EventHandler(this.frmIndmpttt_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmIndmpttt_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			loai.DisplayMember="TEN";
			loai.ValueMember="MA";
            loai.DataSource = m.get_data("select * from " + user + ".phanloaipttt order by ma").Tables[0];
			load_muc();
			load_grid();
		}

		private void load_muc()
		{
            dtmuc = m.get_data("select * from " + user + ".muc where id_pttt=" + loai.SelectedIndex + " order by id_muc").Tables[0];
			muc.DataSource=dtmuc;
            muc.DisplayMember = "TEN";
            muc.ValueMember = "MA";
		}

		private void load_grid()
		{
			s_mapt="'";
			if (muc.SelectedItems.Count>0) for(int i=0;i<muc.Items.Count;i++) if (muc.GetItemChecked(i)) s_mapt+=dtmuc.Rows[i]["ma"].ToString()+"','";
            sql = "select b.ten,a.mapt,a.mapttt,a.noi_dung,nullif(a.dacbiet,' ') as dacbiet,nullif(a.loai1,' ') as loai1,nullif(a.loai2,' ') as loai2,nullif(a.loai3,' ') as loai3,a.loaipt,a.id_pttt,a.id_muc from " + user + ".dmpttt a," + user + ".muc b";
			sql+=" where substr(a.mapt,1,3)=b.ma ";
			if (s_mapt.Length>1) sql+="and substr(a.mapt,1,3) in ("+s_mapt.Substring(0,s_mapt.Length-2)+")";
			sql+=" order by a.id_muc,a.mapt";
			ds=m.get_data(sql);
			pttt.DataSource=ds.Tables[0];
            pttt.DisplayMember = "NOI_DUNG";
            pttt.ValueMember = "MAPT";
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();		
		}

		private void loai_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==loai)
			{
				load_muc();
				load_grid();
			}
		}

		private void loai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");			
		}

		private void muc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void muc_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==muc) load_grid();
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			frmReport f;
			if (pttt.Items.Count>0)
			{
				s_muc="'";
				s_mapt="'";
				if (pttt.SelectedItems.Count>0) for(int i=0;i<pttt.Items.Count;i++) if (pttt.GetItemChecked(i)) s_mapt+=ds.Tables[0].Rows[i]["mapt"].ToString()+"','";
				if (muc.SelectedItems.Count>0) for(int i=0;i<muc.Items.Count;i++) if (muc.GetItemChecked(i)) s_muc+=dtmuc.Rows[i]["ma"].ToString()+"','";
                sql = "select b.ten,a.mapt,a.mapttt,a.noi_dung,nullif(a.dacbiet,' ') as dacbiet,nullif(a.loai1,' ') as loai1,nullif(a.loai2,' ') as loai2,nullif(a.loai3,' ') as loai3,a.loaipt,a.id_pttt,a.id_muc from " + user + ".dmpttt a," + user + ".muc b";
				sql+=" where substr(a.mapt,1,3)=b.ma ";
				if (s_muc.Length>1) sql+=" and substr(a.mapt,1,3) in ("+s_muc.Substring(0,s_muc.Length-2)+")"; 
				if (s_mapt.Length>1) sql+=" and a.mapt in ("+s_mapt.Substring(0,s_mapt.Length-2)+")"; 
				sql+=" order by a.id_muc,a.mapt";
				f=new frmReport(m,m.get_data(sql),"DANH MỤC "+loai.Text.ToUpper(),"indmpttt.rpt");
			}
			else f=new frmReport(m,ds,"DANH MỤC "+loai.Text.ToUpper(),"indmpttt.rpt");
			f.ShowDialog(this);
		}
	}
}
