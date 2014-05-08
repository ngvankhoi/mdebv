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
	/// Summary description for frmChonvp.
	/// </summary>
	public class frmChonvp : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.CheckedListBox loai;
		private System.Windows.Forms.CheckedListBox mavp;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butCancel;
		private AccessData m;
		private DataTable dt=new DataTable();
		private DataTable dtloai=new DataTable();
		private DataTable dtmavp=new DataTable();
		private DataColumn dc;
        public bool bOk = false;
		public string user,s_loaivp,s_mucvp;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChonvp(AccessData acc,string loai,string ma)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			s_loaivp=loai;s_mucvp=ma;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonvp));
            this.loai = new System.Windows.Forms.CheckedListBox();
            this.mavp = new System.Windows.Forms.CheckedListBox();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loai
            // 
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(4, 8);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(276, 356);
            this.loai.TabIndex = 0;
            this.loai.SelectedIndexChanged += new System.EventHandler(this.loai_SelectedIndexChanged);
            // 
            // mavp
            // 
            this.mavp.CheckOnClick = true;
            this.mavp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavp.Location = new System.Drawing.Point(282, 24);
            this.mavp.Name = "mavp";
            this.mavp.Size = new System.Drawing.Size(393, 340);
            this.mavp.TabIndex = 1;
            this.mavp.SelectedIndexChanged += new System.EventHandler(this.mavp_SelectedIndexChanged);
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(271, 371);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 2;
            this.butOk.Text = "     Đồng ý";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(342, 371);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 3;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(288, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "ĐÁNH DẤU NHỮNG MỤC KHÔNG CHỌN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // frmChonvp
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(682, 407);
            this.Controls.Add(this.mavp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.loai);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChonvp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn mục viện phí khoa/phòng sử dụng";
            this.Load += new System.EventHandler(this.frmChonvp_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmChonvp_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			dc=new DataColumn();
			dc.DataType=System.Type.GetType("System.Decimal");
			dc.ColumnName="ma";
			dt.Columns.Add(dc);

            int j = 0;
            while (j < s_mucvp.Length)
            {
                updrec(decimal.Parse(s_mucvp.Substring(j, 7)));
                j += 8;
            }

            dtloai = m.get_data("select * from " + user + ".v_loaivp order by stt").Tables[0];
			loai.DataSource=dtloai;
            loai.DisplayMember = "TEN";
            loai.ValueMember = "ID";
			
			for(int i=0;i<dtloai.Rows.Count;i++)
				if (s_loaivp.IndexOf(dtloai.Rows[i]["id"].ToString().Trim().PadLeft(3,'0')+",")!=-1) loai.SetItemCheckState(i,CheckState.Checked);
			if (loai.Items.Count>0)	load_mavp(long.Parse(loai.SelectedValue.ToString()));
		}

		private void load_mavp(long id)
		{
            dtmavp = m.get_data("select * from " + user + ".v_giavp where id_loai=" + id + " order by stt").Tables[0];
			mavp.DataSource=dtmavp;
            mavp.DisplayMember = "TEN";
            mavp.ValueMember = "ID";
			if (s_mucvp!="") ref_mavp();
		}

		private void loai_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==loai && loai.Items.Count>0)
			{
				get_mavp();
				load_mavp(long.Parse(loai.SelectedValue.ToString()));
			}
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			s_loaivp="";s_mucvp="";
			m.close();this.Close();
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
            bOk = true;
			s_mucvp="";
			s_loaivp="";
			get_mavp();
			for(int i=0;i<loai.Items.Count;i++) if (loai.GetItemChecked(i)) s_loaivp+=dtloai.Rows[i]["id"].ToString().Trim().PadLeft(3,'0')+",";
			m.close();this.Close();
		}

		private void updrec(decimal ma)
		{
			DataRow r=m.getrowbyid(dt,"ma="+ma);
			if (r==null)
			{
				DataRow nrow=dt.NewRow();
				nrow["ma"]=ma;
				dt.Rows.Add (nrow);
			}
		}

		private void ref_mavp()
		{
			for(int i=0;i<dtmavp.Rows.Count;i++)
				if (s_mucvp.IndexOf(dtmavp.Rows[i]["id"].ToString().Trim().PadLeft(7,'0')+",")!=-1) mavp.SetItemCheckState(i,CheckState.Checked);
		}

		private void get_mavp()
		{
			for(int i=0;i<mavp.Items.Count;i++)
			{
				if (mavp.GetItemChecked(i)) updrec(decimal.Parse(dtmavp.Rows[i]["id"].ToString()));
				else m.delrec(dt,"ma="+decimal.Parse(dtmavp.Rows[i]["id"].ToString()));
			}
			if (dt.Rows.Count>0) s_mucvp="";
			foreach(DataRow r in dt.Rows) s_mucvp+=r["ma"].ToString().Trim().PadLeft(7,'0')+",";
		}

		private void mavp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mavp)
				if (!mavp.GetItemChecked(mavp.SelectedIndex))
				{
					m.delrec(dt,"ma="+int.Parse(mavp.SelectedValue.ToString()));
					s_mucvp="";
					foreach(DataRow r in dt.Rows) s_mucvp+=r["ma"].ToString().Trim().PadLeft(7,'0')+",";
				}
		}
	}
}
