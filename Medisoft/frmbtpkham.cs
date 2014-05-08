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
	public class frmbtpkham : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butIn;
		private Export exp=new Export();
		private AccessData m;
		private DataSet ds=new DataSet();
		private DataTable dtkp=new DataTable();
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.CheckedListBox makp;
		private System.Windows.Forms.CheckBox time;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmbtpkham(AccessData acc)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmbtpkham));
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
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(-2, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(148, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(176, 7);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(133, 193);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIn
            // 
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(61, 193);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 5;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // makp
            // 
            this.makp.CheckOnClick = true;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(64, 31);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(192, 132);
            this.makp.TabIndex = 4;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // time
            // 
            this.time.ForeColor = System.Drawing.SystemColors.ControlText;
            this.time.Location = new System.Drawing.Point(64, 170);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(199, 16);
            this.time.TabIndex = 88;
            this.time.Text = "checkBox1";
            // 
            // frmbtpkham
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(264, 237);
            this.Controls.Add(this.time);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmbtpkham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tình hình bệnh tật tại phòng khám";
            this.Load += new System.EventHandler(this.frmbtpkham_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			string s_makp="";
			if (makp.SelectedItems.Count>0)
				for(int i=0;i<makp.Items.Count;i++) if (makp.GetItemChecked(i)) s_makp+=dtkp.Rows[i]["makp"].ToString()+",";
			s_makp=(s_makp!="")?s_makp.Substring(0,s_makp.Length-1):"";
			ds=exp.get_btpkham(tu.Text,den.Text,s_makp,time.Checked);
			if (ds.Tables[0].Rows.Count>0)
			{
				m.delrec(ds.Tables[0],"loai=1");
				DataTable dt=exp.get_btpkham_nguoi(tu.Text,den.Text,s_makp,time.Checked).Tables[0];
				int i01,i02,i03,i04,i05,i06;
				i01=dt.Select("c01>0").Length;
				i02=dt.Select("c02>0").Length;
				i03=dt.Select("c03>0").Length;
				i04=dt.Select("c04>0").Length;
				i05=dt.Select("c05>0").Length;
				i06=dt.Select("c06>0").Length;
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds,(tu.Text==den.Text)?
lan.Change_language_MessageText("Ngày")+" "+tu.Text:
lan.Change_language_MessageText("Từ ngày")+" "+tu.Text+" "+
lan.Change_language_MessageText("đến")+" "+den.Text,"rptbtpkham.rpt",i01,i02,i03,i04,i05,i06,0,0,0,0);
				f.ShowDialog();
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),AccessData.Msg);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void frmbtpkham_Load(object sender, System.EventArgs e)
		{
			time.Text=lan.Change_language_MessageText("Giờ báo cáo ")+" "+m.sGiobaocao;
            dtkp = m.get_data("select makp,tenkp from " + m.user + ".btdkp_bv where loai=1 order by makp").Tables[0];
            makp.DataSource = dtkp;
            makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
		}
	}
}
