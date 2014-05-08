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
	/// Summary description for frmRtieusu.
	/// </summary>
	public class frmRtieusu : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox theo;
		private System.Windows.Forms.CheckedListBox noidung;
		private string user,xxx,sql;
		private AccessData m;
		private DataTable dt=new DataTable();
		private DataSet ds=new DataSet();
		private System.Windows.Forms.Button butCancel;
		private System.Windows.Forms.Button butOk;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmRtieusu(AccessData acc)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRtieusu));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.theo = new System.Windows.Forms.ComboBox();
            this.noidung = new System.Windows.Forms.CheckedListBox();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(130, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(48, 6);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 0;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(162, 6);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(232, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Thông tin :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // theo
            // 
            this.theo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.theo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theo.Items.AddRange(new object[] {
            "Đăng ký khám bệnh",
            "Phòng khám",
            "Ngoại trú",
            "Phòng lưu",
            "Nhận bệnh",
            "Nhập khoa"});
            this.theo.Location = new System.Drawing.Point(296, 6);
            this.theo.Name = "theo";
            this.theo.Size = new System.Drawing.Size(112, 21);
            this.theo.TabIndex = 2;
            this.theo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.theo_KeyDown);
            // 
            // noidung
            // 
            this.noidung.CheckOnClick = true;
            this.noidung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noidung.Location = new System.Drawing.Point(48, 29);
            this.noidung.Name = "noidung";
            this.noidung.Size = new System.Drawing.Size(360, 244);
            this.noidung.TabIndex = 8;
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(210, 284);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 4;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(140, 284);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 3;
            this.butOk.Text = "     In";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // frmRtieusu
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(416, 325);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.den);
            this.Controls.Add(this.noidung);
            this.Controls.Add(this.theo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRtieusu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo tiểu sử người bệnh";
            this.Load += new System.EventHandler(this.frmRtieusu_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}	

		private void theo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (theo.SelectedIndex==-1) theo.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void frmRtieusu_Load(object sender, System.EventArgs e)
		{
			user=m.user;
			dt=m.get_data("select * from "+user+".dmtheodoi order by stt").Tables[0];
			noidung.DataSource=dt;
			noidung.ValueMember="TEN";
			noidung.ValueMember="ID";
			ds=m.get_data("select stt,id,ten,0 as c01,0 as c02,0 as c03,0 as c04,0 as c05,0 as c06,0 as c07 from "+user+".dmtheodoi where id=-1");
			theo.SelectedIndex=0;
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			ds.Clear();
			string table="",cont="";
            string stime = "'" + m.f_ngay + "'";
			switch (theo.SelectedIndex)
			{
				case 0: table="xxx.tiepdon";cont=" and a.maql<>0";break;
				case 1: table="xxx.benhanpk";cont=" and a.mangtr=0";break;
				case 2: table=user+".benhanngtr";cont=" and a.maql<>0";break;
				case 3: table="xxx.benhancc";cont=" and a.maql<>0";break;
				case 4: table=user+".benhandt";cont=" and a.maql<>0";break;
				case 5: table=user+".nhapkhoa";cont=" and a.maba<20";break;
			}
			int nam=int.Parse(tu.Text.Substring(6,4));
			string matt=m.Mabv.Substring(0,3);
			sql="select c.noidung,case when b.phai=1 then 1 else 0 end as c02,";
			sql+="case when "+nam+"-to_number(b.namsinh)<6 then 1 else 0 end as c03,";
			sql+="case when "+nam+"-to_number(b.namsinh)<15 then 1 else 0 end as c04,";
			sql+="case when "+nam+"-to_number(b.namsinh)>60 then 1 else 0 end as c05,";
			sql+="case when b.matt='"+matt+"' then 1 else 0 end as c06,";
			sql+="case when b.matt='"+matt+"' then 0 else 1 end as c07";
			sql+=" from "+table+" a,"+user+".btdbn b,"+user+".theodoitsu c ";
			sql+=" where a.mabn=b.mabn and a.mabn=c.mabn ";
            sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			sql+=cont;
			DataTable tmp;
			DataRow r1,r2;
			DataRow [] dr;
			if (theo.SelectedIndex<2) tmp=m.get_data_mmyy(sql,tu.Text,den.Text,false).Tables[0];
			else tmp=m.get_data(sql).Tables[0];
			if (noidung.CheckedItems.Count==0) 
				for(int i=0;i<noidung.Items.Count;i++) noidung.SetItemCheckState(i,CheckState.Checked);
			for(int i=0;i<noidung.Items.Count;i++)
				if (noidung.GetItemChecked(i))
				{
					foreach(DataRow r in tmp.Select("noidung like '%"+dt.Rows[i]["id"].ToString().PadLeft(3,'0')+"+%'"))
					{
						sql="id="+int.Parse(dt.Rows[i]["id"].ToString());
						r1=m.getrowbyid(ds.Tables[0],sql);
						if (r1==null)
						{
							r2=ds.Tables[0].NewRow();
							r2["stt"]=dt.Rows[i]["stt"].ToString();
							r2["id"]=dt.Rows[i]["id"].ToString();
							r2["ten"]=dt.Rows[i]["ten"].ToString();
							r2["c01"]=1;
							r2["c02"]=r["c02"].ToString();
							r2["c03"]=r["c03"].ToString();
							r2["c04"]=r["c04"].ToString();
							r2["c05"]=r["c05"].ToString();
							r2["c06"]=r["c06"].ToString();
							r2["c07"]=r["c07"].ToString();
							ds.Tables[0].Rows.Add(r2);
						}
						else
						{
							dr=ds.Tables[0].Select(sql);
							if (dr.Length>0)
							{
								dr[0]["c01"]=decimal.Parse(dr[0]["c01"].ToString())+1;
								dr[0]["c02"]=decimal.Parse(dr[0]["c02"].ToString())+decimal.Parse(r["c02"].ToString());
								dr[0]["c03"]=decimal.Parse(dr[0]["c03"].ToString())+decimal.Parse(r["c03"].ToString());
								dr[0]["c04"]=decimal.Parse(dr[0]["c04"].ToString())+decimal.Parse(r["c04"].ToString());
								dr[0]["c05"]=decimal.Parse(dr[0]["c05"].ToString())+decimal.Parse(r["c05"].ToString());
								dr[0]["c06"]=decimal.Parse(dr[0]["c06"].ToString())+decimal.Parse(r["c06"].ToString());
								dr[0]["c07"]=decimal.Parse(dr[0]["c07"].ToString())+decimal.Parse(r["c07"].ToString());
							}
						}
					}
				}
            if (ds.Tables[0].Rows.Count == 0) MessageBox.Show(lan.Change_language_MessageText(lan.Change_language_MessageText("Không có số liệu !")), LibMedi.AccessData.Msg);
			else
			{
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds,theo.Text+","+((tu.Text==den.Text)?"Ngày "+tu.Text:"Từ ngày "+tu.Text+" đến "+den.Text),"rptTieusu.rpt",0,0,0,0,0,0,0,0,0,0);
				f.ShowDialog();
			}
		}

	}
}
