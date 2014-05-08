using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using LibDuoc;
using System.Data;
using System.IO;
//
namespace Duoc
{
	/// <summary>
	/// Summary description for frminctgs.
	/// </summary>
	public class frminctgs : System.Windows.Forms.Form
	{
	Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		AccessData d=new AccessData();
		string s_makho, s_mmyy,s_tu, s_den, s_yy,s_kho,sql;
        int i_nhomkho, i_userid=0;
		DataTable dtdmkho;
		DataSet ds;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox No;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.TextBox Co;
		private System.Windows.Forms.NumericUpDown tu;
		private System.Windows.Forms.NumericUpDown den;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown yyyy;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckedListBox kho;
		private System.Windows.Forms.CheckBox checkBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frminctgs(int nhomkho,string makho,string mmyy, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			i_nhomkho=nhomkho;
			s_makho=makho;
			s_mmyy=mmyy;
            i_userid = _userid;
			//
			tu.Value=decimal.Parse(mmyy.Substring(0,2));
			den.Value=tu.Value;
			yyyy.Value=decimal.Parse("20"+mmyy.Substring(2,2));
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frminctgs));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.No = new System.Windows.Forms.TextBox();
            this.Co = new System.Windows.Forms.TextBox();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.tu = new System.Windows.Forms.NumericUpDown();
            this.den = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nợ :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(152, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Có :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // No
            // 
            this.No.Location = new System.Drawing.Point(64, 32);
            this.No.Name = "No";
            this.No.Size = new System.Drawing.Size(72, 21);
            this.No.TabIndex = 3;
            this.No.KeyDown += new System.Windows.Forms.KeyEventHandler(this.No_KeyDown);
            // 
            // Co
            // 
            this.Co.Location = new System.Drawing.Point(200, 32);
            this.Co.Name = "Co";
            this.Co.Size = new System.Drawing.Size(72, 21);
            this.Co.TabIndex = 4;
            this.Co.KeyDown += new System.Windows.Forms.KeyEventHandler(this.No_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(76, 288);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 8;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(146, 288);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 9;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(64, 8);
            this.tu.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.tu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(38, 21);
            this.tu.TabIndex = 0;
            this.tu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.No_KeyDown);
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(144, 8);
            this.den.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.den.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(38, 21);
            this.den.TabIndex = 1;
            this.den.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.No_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(112, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 23);
            this.label4.TabIndex = 30;
            this.label4.Text = "đến : ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(224, 8);
            this.yyyy.Maximum = new decimal(new int[] {
            3004,
            0,
            0,
            0});
            this.yyyy.Minimum = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.Name = "yyyy";
            this.yyyy.Size = new System.Drawing.Size(48, 21);
            this.yyyy.TabIndex = 2;
            this.yyyy.Value = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.No_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(188, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 23);
            this.label5.TabIndex = 27;
            this.label5.Text = "năm :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(-7, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 23);
            this.label6.TabIndex = 25;
            this.label6.Text = "Từ tháng :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kho
            // 
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(8, 56);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(264, 196);
            this.kho.TabIndex = 7;
            // 
            // checkBox1
            // 
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(8, 256);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(264, 24);
            this.checkBox1.TabIndex = 31;
            this.checkBox1.Text = "Chọn tất cả các kho";
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // frminctgs
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(280, 321);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.den);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.yyyy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.Co);
            this.Controls.Add(this.No);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frminctgs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In chứng từ ghi sổ theo tài khoản";
            this.Load += new System.EventHandler(this.frminctgs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void No_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode.ToString()=="Enter")
			{
				SendKeys.Send("{Tab}");
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			s_tu=tu.Value.ToString().PadLeft(2,'0');
			s_den=den.Value.ToString().PadLeft(2,'0');
			s_yy=yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			//
			s_kho="";
			for(int i=0;i<kho.Items.Count;i++)
				if (kho.GetItemChecked(i)) s_kho+=dtdmkho.Rows[i]["id"].ToString()+",";			
			s_kho=(s_kho!="")?s_kho.Substring(0,s_kho.Length-1):s_makho;
			//
			load_ctughiso(No.Text,Co.Text,s_kho);
			string s_mg="Từ tháng "+tu.Value.ToString().PadLeft(2,'0')+" đến tháng "+den.Value.ToString().PadLeft(2,'0')+" năm "+yyyy.Value.ToString();
			if(tu.Value==den.Value)s_mg="Tháng "+tu.Value.ToString().PadLeft(2,'0')+" năm "+yyyy.Value.ToString();
			frmReport f=new frmReport(d,ds.Tables[0],i_userid,"d_ctghiso.rpt",s_mg,"","","","","","","","","");
			f.ShowDialog();
		}

		private void load_ctughiso(string s_no, string s_co, string s_makho)
		{
			ds=new DataSet();
			int j=0;
			for(int i=int.Parse(s_tu);i<=int.Parse(s_den);i++)
			{
				if (d.bMmyy(i.ToString().PadLeft(2,'0')+s_yy))
				{
					sql="select a.soct, a.mmyy, a.ngay, a.userid, c.ten tenkho, d.ten tenkp, (decode(b.makho,19,'1','0')||nvl(b.no,'a')||nvl(b.co,'b')) tk, b.* ";
					sql+=" from d_ctghisoll a, d_ctghisoct b,"+d.user+".d_dmkho c,"+d.user+".d_duockp d ";
					sql+=" where a.id=b.id and b.makho=c.id(+) and b.makp=d.id(+) ";
					sql+=" and a.nhom="+i_nhomkho;
					if(s_makho!="")sql+=" and b.makho in ("+s_makho+")";
					if(s_no!="")sql+=" and b.no like '"+s_no+"%'";
					if(s_co!="")sql+=" and b.co like '"+s_co+"%'";
					sql+=" and substr(a.mmyy,3,2)='"+s_yy+"' and substr(a.mmyy,1,2) between '"+s_tu+"' and '"+s_den+"'";
					if (j!=0) ds.Merge(d.get_data(sql));
					else ds=d.get_data(sql);
					j++;
				}
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}
		private void Load_kho()
		{
			string s_sql="select * from d_dmkho where nhom="+i_nhomkho;
			s_sql+=(s_makho!="")?" and id in ("+s_makho+")":"";
			s_sql+=" order by stt";
			dtdmkho=d.get_data(s_sql).Tables[0];
			kho.DisplayMember="TEN";
			kho.ValueMember="ID";
			kho.DataSource=dtdmkho;
		}

		private void frminctgs_Load(object sender, System.EventArgs e)
		{
			Load_kho();
		}

		private void checkBox1_Click(object sender, System.EventArgs e)
		{
			if(checkBox1.Checked==true)
			{
				for(int i=0;i<dtdmkho.Rows.Count;i++)
					kho.SetItemCheckState(i,CheckState.Checked);
			}
			else
			{
				for(int i=0;i<dtdmkho.Rows.Count;i++)
					kho.SetItemCheckState(i,CheckState.Unchecked);
			}
		}
	}
}
