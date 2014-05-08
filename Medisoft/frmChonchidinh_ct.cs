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
	/// Summary description for frmChonchidinh_ct.
	/// </summary>
	public class frmChonchidinh_ct : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butOK;
		private System.Windows.Forms.Button butCancel;
		public DataTable dt=new DataTable();
		private DataSet dsgia=new DataSet();
		private string sql,user;
		private DataColumn dc;
		private AccessData m;
		private CheckBox chkbox;
		private	TabPage tab;
		private ToolTip tooltip;
		private System.Windows.Forms.TabControl tabControl;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChonchidinh_ct(AccessData acc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonchidinh_ct));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.butOK = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(1, -2);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.ShowToolTips = true;
            this.tabControl.Size = new System.Drawing.Size(792, 508);
            this.tabControl.TabIndex = 0;
            // 
            // butOK
            // 
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOK.Location = new System.Drawing.Point(308, 505);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(88, 25);
            this.butOK.TabIndex = 1;
            this.butOK.Text = "Đồng ý";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(398, 505);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(84, 25);
            this.butCancel.TabIndex = 2;
            this.butCancel.Text = "Bỏ qua";
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // frmChonchidinh_ct
            // 
            this.AcceptButton = this.butOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(794, 536);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChonchidinh_ct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn dịch vụ";
            this.Load += new System.EventHandler(this.frmChonchidinh_ct_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmChonchidinh_ct_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			dsgia=m.get_data("select * from "+user+".ct_giavp");
			taotable();
			load();
		}

		private void taotable()
		{
			dc=new DataColumn();
			dc.DataType=System.Type.GetType("System.Decimal");
			dc.ColumnName="mavp";
			dt.Columns.Add(dc);
			dc=new DataColumn();
			dc.DataType=System.Type.GetType("System.String");
			dc.ColumnName="ten";
			dt.Columns.Add(dc);
			dc=new DataColumn();
			dc.DataType=System.Type.GetType("System.String");
			dc.ColumnName="dvt";
			dt.Columns.Add(dc);
			dc=new DataColumn();
			dc.DataType=System.Type.GetType("System.Decimal");
			dc.ColumnName="dongia";
			dt.Columns.Add(dc);
			dc=new DataColumn();
			dc.DataType=System.Type.GetType("System.Decimal");
			dc.ColumnName="vattu";
			dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Decimal");
            dc.ColumnName = "soluong";
            dt.Columns.Add(dc);
		}

		private void butOK_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			dt.Clear();
			m.close();this.Close();
		}

		private void load()
		{
			sql="select distinct a.* from "+user+".ct_loaivp a,"+user+".ct_giavp b where a.id=b.id_loai";
			sql+=" order by a.stt";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				tab=new TabPage();
				int t=0,l=0,j=0;
				tab.Text=r["ten"].ToString().Trim();
				tabControl.TabPages.Add(tab);
				sql="select * from "+user+".ct_giavp where id_loai="+int.Parse(r["id"].ToString());
				sql+=" order by stt";
				foreach(DataRow r1 in m.get_data(sql).Tables[0].Rows)
				{
					if (j%14==0 && j!=0)
					{
						t=0;
						l+=275;
					}
					Addchkbox(r1["ten"].ToString(),r1["id"].ToString(),t,l,r1["gia_nv"].ToString(),r1["gia_ngv"].ToString(),new EventHandler(chkEvent));
					t+=32;
					j++;
				}
				tab.AutoScroll=true;
			}
		}

		public void chkEvent(object sender, EventArgs e)
		{
			Control ctrl=(Control)sender;
			chk c=ctrl.Tag as chk;
			DataRow r=m.getrowbyid(dsgia.Tables[0],"id="+int.Parse(c.index.ToString()));
			if (r!=null)
				m.reprec(dt,"mavp="+int.Parse(r["id"].ToString()),int.Parse(r["id"].ToString()),r["ten"].ToString(),r["dvt"].ToString(),decimal.Parse(r["gia_nv"].ToString()),decimal.Parse(r["gia_ngv"].ToString()),1);
            r = m.getrowbyid(dt, "mavp=" + int.Parse(c.index.ToString()));
            ctrl.ForeColor = (r != null) ? Color.Red : Color.Black;
		}

		public void Addchkbox(string text,string name,int t,int l,string gia_nv,string gia_ngv,EventHandler onClickEvent)
		{
			chk chkClick=new chk(name,onClickEvent);
			chkbox=new CheckBox();
			tooltip=new ToolTip();
			chkbox.Text=text;
			chkbox.Name=name;
			chkbox.Top=t;
			chkbox.Left=l;
            chkbox.Size = new System.Drawing.Size(270, 32);
            chkbox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			chkbox.Click+=onClickEvent;
			chkbox.Tag=chkClick;
			tab.Controls.Add(chkbox);
			tooltip.SetToolTip(chkbox,(gia_nv==gia_ngv)?gia_nv:gia_ngv+"\n"+gia_ngv);
		}

		public class chk : CheckBox
		{
			public string index;
			public string Index
			{
				get
				{
					return index;
				}
			}
			public chk(string index,EventHandler onClickEvent)
			{
				this.index=index;
				Click+=onClickEvent;
			}
		}
	}
}
