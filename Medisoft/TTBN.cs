using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Lib_LH;

namespace Medisoft
{
	public class TTBN : System.Windows.Forms.Form
	{		
        Language lan = new Language();
		Lib_LH.Access_Data k = new Lib_LH.Access_Data();
		
		private System.Windows.Forms.Button cmdKetthuc;
		string maql;
		private System.Windows.Forms.DataGrid DTG;
	
		private System.ComponentModel.Container components = null;

		public TTBN(System.Windows.Forms.Form frmlichhen,string id )
		{
			maql=id;
			InitializeComponent();
             lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TTBN));
			this.cmdKetthuc = new System.Windows.Forms.Button();
			this.DTG = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.DTG)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdKetthuc
			// 
			this.cmdKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdKetthuc.Image")));
			this.cmdKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdKetthuc.Location = new System.Drawing.Point(312, 232);
			this.cmdKetthuc.Name = "cmdKetthuc";
			this.cmdKetthuc.Size = new System.Drawing.Size(76, 32);
			this.cmdKetthuc.TabIndex = 58;
			this.cmdKetthuc.Text = "Kết thúc";
			this.cmdKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdKetthuc.Click += new System.EventHandler(this.cmdKetthuc_Click);
			// 
			// DTG
			// 
			this.DTG.AllowSorting = false;
			this.DTG.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
			this.DTG.BackColor = System.Drawing.Color.WhiteSmoke;
			this.DTG.BackgroundColor = System.Drawing.SystemColors.Control;
			this.DTG.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DTG.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.DTG.CaptionText = "Thông tin cuộc hẹn";
			this.DTG.CaptionVisible = false;
			this.DTG.DataMember = "";
			this.DTG.FlatMode = true;
			this.DTG.ForeColor = System.Drawing.Color.MidnightBlue;
			this.DTG.GridLineColor = System.Drawing.Color.RoyalBlue;
			this.DTG.HeaderBackColor = System.Drawing.Color.DarkSlateBlue;
			this.DTG.HeaderForeColor = System.Drawing.Color.Yellow;
			this.DTG.Location = new System.Drawing.Point(0, 20);
			this.DTG.Name = "DTG";
			this.DTG.ReadOnly = true;
			this.DTG.RowHeaderWidth = 20;
			this.DTG.SelectionBackColor = System.Drawing.Color.Red;
			this.DTG.SelectionForeColor = System.Drawing.Color.White;
			this.DTG.Size = new System.Drawing.Size(696, 204);
			this.DTG.TabIndex = 61;
			// 
			// TTBN
			// 
			this.AcceptButton = this.cmdKetthuc;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(696, 277);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.DTG,
																		  this.cmdKetthuc});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(704, 304);
			this.MinimizeBox = false;
			this.Name = "TTBN";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Thông tin chi tiết cuộc hẹn";
			this.Load += new System.EventHandler(this.TTBN_Load);
			((System.ComponentModel.ISupportInitialize)(this.DTG)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void TTBN_Load(object sender, System.EventArgs e)
		{
			try
			{				
				DataSet Dss = new DataSet();
				Dss=k.get_ttbn(Int32.Parse(maql.ToString()));		
				DTG.DataSource=Dss.Tables[0];
			}
			catch(Exception caught)
			{
				MessageBox.Show(caught.Message);
			}
			LoadGridStyle();
		}

		public void LoadGridStyle()
		{
			DataGridTableStyle tbs = new DataGridTableStyle();
			tbs.MappingName="LH_BENHNHAN";

			tbs.AlternatingBackColor = Color.Beige;
			tbs.BackColor = Color.GhostWhite;
			tbs.ForeColor = Color.MidnightBlue;
			tbs.GridLineColor = Color.RoyalBlue;
			tbs.HeaderBackColor = Color.DarkSlateBlue;
			tbs.HeaderForeColor = Color.Yellow;
			tbs.SelectionBackColor = Color.Teal;
			tbs.SelectionForeColor = Color.PaleGreen;
			tbs.ReadOnly=true;

			DataGridTextBoxColumn c0=new DataGridTextBoxColumn();
			c0.MappingName="HOTEN";
			c0.HeaderText="Họ Tên";
			c0.Width=120;
			c0.NullText="";			
			tbs.GridColumnStyles.Add(c0);

			DataGridTextBoxColumn c1=new DataGridTextBoxColumn();
			c1.MappingName="NAMSINH";
			c1.HeaderText="Năm Sinh";
			c1.NullText="";
			c1.Width=70;
			tbs.GridColumnStyles.Add(c1);

			DataGridTextBoxColumn c2=new DataGridTextBoxColumn();
			c2.MappingName="THON";
			c2.HeaderText="Thôn/Đường";
			c2.NullText="";
			c2.Width=140;
			tbs.GridColumnStyles.Add(c2);

			DataGridTextBoxColumn c3=new DataGridTextBoxColumn();
			c3.MappingName="DIACHI";
			c3.HeaderText="Địa Chỉ";
			c3.NullText="";
			c3.Width=250;			
			tbs.GridColumnStyles.Add(c3);
			
			DataGridTextBoxColumn c4=new DataGridTextBoxColumn();
			c4.MappingName="DTNHA";
			c4.HeaderText=" Điện Thoại";
			c4.NullText="";
			c4.Width=70;			
			tbs.GridColumnStyles.Add(c4);

			DataGridTextBoxColumn c5=new DataGridTextBoxColumn();
			c5.MappingName="NGAYKHAM";
			c5.HeaderText="Ngày Khám";
			c5.NullText="";
			c5.Width=70;			
			tbs.GridColumnStyles.Add(c5);

			DataGridTextBoxColumn c6=new DataGridTextBoxColumn();
			c6.MappingName="GIOKHAM";
			c6.HeaderText="Giờ Khám";
			c6.NullText="";
			c6.Width=70;			
			tbs.GridColumnStyles.Add(c6);

			DataGridTextBoxColumn c7=new DataGridTextBoxColumn();
			c7.MappingName="TENKP";
			c7.HeaderText="Khoa Phòng";
			c7.NullText="";
			c7.Width=90;			
			tbs.GridColumnStyles.Add(c7);

			DataGridTextBoxColumn c8=new DataGridTextBoxColumn();
			c8.MappingName="TENHK";
			c8.HeaderText="Lý Do";
			c8.NullText="";
			c8.Width=140;			
			tbs.GridColumnStyles.Add(c8);

			DataGridTextBoxColumn c9=new DataGridTextBoxColumn();
			c9.MappingName="HOTENBS";
			c9.HeaderText="Bác Sĩ";
			c9.NullText="";
			c9.Width=140;			
			tbs.GridColumnStyles.Add(c9);

			DataGridTextBoxColumn c10=new DataGridTextBoxColumn();
			c10.MappingName="GHICHU";
			c10.HeaderText="Ghi Chú";
			c10.NullText="";
			c10.Width=140;			
			tbs.GridColumnStyles.Add(c10);

			DataGridTextBoxColumn c11=new DataGridTextBoxColumn();
			c11.MappingName="STT";
			c11.HeaderText="Số TT";
			c11.NullText="";
			c11.Width=50;			
			tbs.GridColumnStyles.Add(c11);

			DataGridTextBoxColumn c12=new DataGridTextBoxColumn();
			c12.MappingName="MAQL";
			c12.HeaderText="MAQL";
			c12.NullText="";
			c12.Width=0;			
			tbs.GridColumnStyles.Add(c12);
			DTG.TableStyles.Add(tbs);
		}
	}
}
