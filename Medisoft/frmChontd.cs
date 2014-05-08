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
	/// Summary description for frmChontd.
	/// </summary>
	public class frmChontd : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butOK;
		private System.Windows.Forms.Button butCancel;
		public DataTable dt=new DataTable();
		private DataSet dsgia=new DataSet();
		private string sql,user,ngay;
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

		public frmChontd(AccessData acc,string _ngay)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

            m = acc; ngay = _ngay; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChontd));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.butOK = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(2, -2);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.ShowToolTips = true;
            this.tabControl.Size = new System.Drawing.Size(790, 490);
            this.tabControl.TabIndex = 0;
            // 
            // butOK
            // 
            this.butOK.Image = ((System.Drawing.Image)(resources.GetObject("butOK.Image")));
            this.butOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOK.Location = new System.Drawing.Point(333, 492);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(70, 25);
            this.butOK.TabIndex = 1;
            this.butOK.Text = "Đồng ý";
            this.butOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butCancel
            // 
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(403, 492);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 2;
            this.butCancel.Text = "Bỏ qua";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // frmChontd
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(794, 527);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChontd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn thực đơn";
            this.Load += new System.EventHandler(this.frmChontd_Load);
            this.ResumeLayout(false);

		}
					#endregion
			
		private void frmChontd_Load(object sender, System.EventArgs e)
		{
            user = m.user;
            string stime = "'" + m.f_ngay + "'";
            sql = "select to_char(ngay,'dd/mm/yyyy') as ngay from " + user + ".di_dmtdngay ";
            sql += " where " + m.for_ngay("ngay", stime) + "<= to_date('" + ngay + "'," + stime + ")";
            sql += " order by ngay desc";
            DataTable tmp = m.get_data(sql).Tables[0];
            if (tmp.Rows.Count > 0) ngay = tmp.Rows[0]["ngay"].ToString();
            else ngay = "xx/xx/xxxx";
            sql = "select a.id,a.stt,a.idchedoan,a.idgioan,a.ma,a.ten,b.dongia ";
            sql+=" from " + user + ".di_dmthucdon a," + user + ".di_dmtdngay b where a.id=b.id and to_char(b.ngay,'dd/mm/yyyy')='" + ngay + "' order by a.stt";
            dsgia = m.get_data(sql);
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
            sql = "select distinct a.* from " + user + ".di_dmchedoan a," + user + ".di_dmthucdon b,"+user+".di_dmtdngay c ";
            sql += " where a.id=b.idchedoan and b.id=c.id and to_char(c.ngay,'dd/mm/yyyy')='" + ngay + "'";
			sql+=" order by a.stt";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				tab=new TabPage();
				int t=0,l=0,j=0;
				tab.Text=r["ten"].ToString().Trim();
				tabControl.TabPages.Add(tab);
                sql = "select a.* from " + user + ".di_dmthucdon a,"+user+".di_dmtdngay b ";
                sql+=" where a.id=b.id and a.idchedoan=" + int.Parse(r["id"].ToString());
                sql += " and to_char(b.ngay,'dd/mm/yyyy')='" + ngay + "'";
				sql+=" order by stt";
				foreach(DataRow r1 in m.get_data(sql).Tables[0].Rows)
				{
					if (j%15==0 && j!=0)
					{
						t=0;
						l+=405;
					}
					Addchkbox(r1["ten"].ToString(),r1["id"].ToString(),t,l,new EventHandler(chkEvent));
					t+=30;
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
				m.reprec(dt,"mavp="+int.Parse(r["id"].ToString()),int.Parse(r["id"].ToString()),r["ten"].ToString(),"",0,0,1);
		}

		public void Addchkbox(string text,string name,int t,int l,EventHandler onClickEvent)
		{
			chk chkClick=new chk(name,onClickEvent);
			chkbox=new CheckBox();
			//tooltip=new ToolTip();
			chkbox.Text=text.Trim();
			chkbox.Name=name;
			chkbox.Top=t;
			chkbox.Left=l;
			chkbox.Size = new System.Drawing.Size(400, 30);
			chkbox.Click+=onClickEvent;
			chkbox.Tag=chkClick;
			tab.Controls.Add(chkbox);
			//tooltip.SetToolTip(chkbox,(gia_th==gia_bh)?gia_th:gia_th+"\n"+gia_bh);
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
