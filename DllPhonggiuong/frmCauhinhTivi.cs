using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DllPhonggiuong
{
	public class frmCauhinhTivi : System.Windows.Forms.Form
	{
		private DataSet dsxml=new DataSet();
		private LibMedi.AccessData m;
        private string s_user = "";
		private PinkieControls.ButtonXP butLuu;
		private PinkieControls.ButtonXP butKetthuc;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown c01;
		private System.Windows.Forms.CheckBox c02;
		private System.Windows.Forms.NumericUpDown c03;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox c04;
		private System.Windows.Forms.CheckBox c05;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox c06;
		private System.ComponentModel.Container components = null;

		public frmCauhinhTivi(LibMedi.AccessData acc)
		{
			InitializeComponent();
			this.m=acc;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCauhinhTivi));
			this.butLuu = new PinkieControls.ButtonXP();
			this.butKetthuc = new PinkieControls.ButtonXP();
			this.panel1 = new System.Windows.Forms.Panel();
			this.c06 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.c04 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.c03 = new System.Windows.Forms.NumericUpDown();
			this.c02 = new System.Windows.Forms.CheckBox();
			this.c01 = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.c05 = new System.Windows.Forms.CheckBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.c03)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.c01)).BeginInit();
			this.SuspendLayout();
			// 
			// butLuu
			// 
			this.butLuu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.butLuu.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butLuu.DefaultScheme = true;
			this.butLuu.DialogResult = System.Windows.Forms.DialogResult.None;
			this.butLuu.Hint = "";
			this.butLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("butLuu.Image")));
			this.butLuu.Location = new System.Drawing.Point(109, 108);
			this.butLuu.Name = "butLuu";
			this.butLuu.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.butLuu.Size = new System.Drawing.Size(79, 33);
			this.butLuu.TabIndex = 7;
			this.butLuu.Text = "&Đồng ý";
			this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
			// 
			// butKetthuc
			// 
			this.butKetthuc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butKetthuc.DefaultScheme = true;
			this.butKetthuc.DialogResult = System.Windows.Forms.DialogResult.None;
			this.butKetthuc.Hint = "";
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.Location = new System.Drawing.Point(189, 108);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.butKetthuc.Size = new System.Drawing.Size(88, 33);
			this.butKetthuc.TabIndex = 8;
			this.butKetthuc.Text = "&Kết thúc";
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.c06,
																				 this.label1,
																				 this.c04,
																				 this.label4,
																				 this.c03,
																				 this.c02,
																				 this.c01,
																				 this.butKetthuc,
																				 this.butLuu,
																				 this.label3,
																				 this.label2,
																				 this.c05});
			this.panel1.Location = new System.Drawing.Point(1, 1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(385, 159);
			this.panel1.TabIndex = 9;
			// 
			// c06
			// 
			this.c06.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.c06.Location = new System.Drawing.Point(96, 54);
			this.c06.Name = "c06";
			this.c06.Size = new System.Drawing.Size(224, 21);
			this.c06.TabIndex = 20;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 57);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 19;
			this.label1.Text = "Chọn khoa :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// c04
			// 
			this.c04.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.c04.Location = new System.Drawing.Point(56, 8);
			this.c04.Name = "c04";
			this.c04.Size = new System.Drawing.Size(325, 20);
			this.c04.TabIndex = 17;
			this.c04.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 11);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 16;
			this.label4.Text = "Tiêu đề :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// c03
			// 
			this.c03.Enabled = false;
			this.c03.Location = new System.Drawing.Point(227, 77);
			this.c03.Name = "c03";
			this.c03.Size = new System.Drawing.Size(54, 20);
			this.c03.TabIndex = 13;
			this.c03.Value = new System.Decimal(new int[] {
															  20,
															  0,
															  0,
															  0});
			// 
			// c02
			// 
			this.c02.Location = new System.Drawing.Point(38, 77);
			this.c02.Name = "c02";
			this.c02.Size = new System.Drawing.Size(232, 16);
			this.c02.TabIndex = 12;
			this.c02.Text = "Kiểm tra tình trạng giường bệnh :";
			this.c02.CheckedChanged += new System.EventHandler(this.c02_CheckedChanged);
			// 
			// c01
			// 
			this.c01.Enabled = false;
			this.c01.Location = new System.Drawing.Point(227, 31);
			this.c01.Name = "c01";
			this.c01.Size = new System.Drawing.Size(54, 20);
			this.c01.TabIndex = 10;
			this.c01.Value = new System.Decimal(new int[] {
															  10,
															  0,
															  0,
															  0});
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(283, 77);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 16);
			this.label3.TabIndex = 15;
			this.label3.Text = "( phút )";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(283, 34);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 14;
			this.label2.Text = "( phút )";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// c05
			// 
			this.c05.Location = new System.Drawing.Point(38, 35);
			this.c05.Name = "c05";
			this.c05.Size = new System.Drawing.Size(232, 16);
			this.c05.TabIndex = 18;
			this.c05.Text = "Thời gian chuyển đổi khoa phòng :";
			this.c05.CheckedChanged += new System.EventHandler(this.c05_CheckedChanged);
			// 
			// frmCauhinhTivi
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.RoyalBlue;
			this.ClientSize = new System.Drawing.Size(388, 161);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmCauhinhTivi";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cấu hình thông số";
			this.Load += new System.EventHandler(this.frmCauhinhTivi_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.c03)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.c01)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			DataRow r=dsxml.Tables[0].Rows[0];
			foreach(Control ctr in panel1.Controls)
			{
				if(ctr.GetType()!=typeof(Label))
				{
					switch(ctr.GetType().ToString())
					{
						case "System.Windows.Forms.CheckBox": CheckBox chk=(CheckBox)ctr; 
							r[ctr.Name]=(chk.Checked)?1:0;
							break;
						case "System.Windows.Forms.NumericUpDown": NumericUpDown num=(NumericUpDown)ctr;
							r[ctr.Name]=num.Value;
							break;
						case "System.Windows.Forms.TextBox": TextBox txt=(TextBox)ctr;
							r[ctr.Name]=txt.Text;
							break;
						case "System.Windows.Forms.ComboBox": ComboBox cbo=(ComboBox)ctr;
							r[ctr.Name]=(cbo.Visible&&cbo.SelectedIndex!=-1)?cbo.SelectedValue.ToString():"";
							break;
					}
				}
			}
			dsxml.AcceptChanges();
			dsxml.WriteXml(@"..\..\..\xml\g_thongso.xml");
			frmExportTivi fi=new frmExportTivi(m);
			fi.Show();
			fi.TopMost=true;
			this.Close();
		}

		private void frmCauhinhTivi_Load(object sender, System.EventArgs e)
		{
            s_user = m.user;
			c06.DisplayMember="TENKP";
			c06.ValueMember="MAKP";
            c06.DataSource = m.get_data("select distinct b.makp,a.tenkp from " + s_user + ".btdkp_bv a," + s_user + ".dmphong b where a.makp=b.makp and b.dichvu=1 order by b.makp").Tables[0];
			bool ret=false;
			if(System.IO.File.Exists(@"..\..\..\xml\g_thongso.xml"))
			{
				dsxml.ReadXml(@"..\..\..\xml\g_thongso.xml");
				if(dsxml.Tables[0].Columns.Count==6) ret=true;
			}
			if(!ret)
			{
				dsxml=m.get_data("select 0 c01,0 c02,0 c03,'Tieu de' c04,0 c05,0 c06 from dual");
				dsxml.WriteXml(@"..\..\..\xml\g_thongso.xml");
			}
			foreach(Control ctr in panel1.Controls)
			{
				if(ctr.GetType()!=typeof(Label))
				{
					switch(ctr.GetType().ToString())
					{
						case "System.Windows.Forms.CheckBox": CheckBox chk=(CheckBox)ctr; 
							chk.Checked=int.Parse(dsxml.Tables[0].Rows[0][ctr.Name].ToString())==1;
							break;
						case "System.Windows.Forms.NumericUpDown": NumericUpDown num=(NumericUpDown)ctr;
							num.Value=decimal.Parse(dsxml.Tables[0].Rows[0][ctr.Name].ToString());
							break;
						case "System.Windows.Forms.TextBox": TextBox txt=(TextBox)ctr;
							txt.Text=dsxml.Tables[0].Rows[0][ctr.Name].ToString();
							break;
						case "System.Windows.Forms.ComboBox": ComboBox cbo=(ComboBox)ctr;
							cbo.SelectedValue=dsxml.Tables[0].Rows[0][ctr.Name].ToString();
							break;
					}
				}
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void c05_CheckedChanged(object sender, System.EventArgs e)
		{
			c01.Enabled=c05.Checked;
			c06.Enabled=!c05.Checked;
		}

		private void c02_CheckedChanged(object sender, System.EventArgs e)
		{
			c03.Enabled=c02.Checked;
		}
	}
}
