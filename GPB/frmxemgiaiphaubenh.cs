using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using gpblib;
using System.Data;

namespace XN
{
	/// <summary>
	/// Summary description for frmxemgiaiphaubenh.
	/// </summary>
	public class frmxemgiaiphaubenh : System.Windows.Forms.Form
	{
		// khai báo 
		//private   b a  = new AccessData();
		private gpblib.AccessData b = new AccessData();
		private string m_mabn ;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lbldiathe;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ListView lstvnhuondb;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label lblvithe;
		private System.Windows.Forms.Label lblketluan;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label lblbanluan;
		private System.Windows.Forms.ColumnHeader ppnhuom;
		private System.Windows.Forms.ColumnHeader DT;
		private System.Windows.Forms.ColumnHeader CD;
		private System.Windows.Forms.ColumnHeader TL;
		private System.Windows.Forms.ColumnHeader GHICHU;
		private System.Windows.Forms.ColumnHeader STT;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TreeView treeViewAll;
		private System.Windows.Forms.Label lblhotenbn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblvtst;
		private System.Windows.Forms.Label lblNgaynhan;
		private System.Windows.Forms.Label lblngaytra;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lblcdls;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmxemgiaiphaubenh(string mabn )
		{
			InitializeComponent();
			this.m_mabn= mabn;
	
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmxemgiaiphaubenh));
			this.label6 = new System.Windows.Forms.Label();
			this.lbldiathe = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lstvnhuondb = new System.Windows.Forms.ListView();
			this.STT = new System.Windows.Forms.ColumnHeader();
			this.ppnhuom = new System.Windows.Forms.ColumnHeader();
			this.DT = new System.Windows.Forms.ColumnHeader();
			this.CD = new System.Windows.Forms.ColumnHeader();
			this.TL = new System.Windows.Forms.ColumnHeader();
			this.GHICHU = new System.Windows.Forms.ColumnHeader();
			this.label10 = new System.Windows.Forms.Label();
			this.lblvithe = new System.Windows.Forms.Label();
			this.lblketluan = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.lblbanluan = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.treeViewAll = new System.Windows.Forms.TreeView();
			this.lblhotenbn = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lblvtst = new System.Windows.Forms.Label();
			this.lblNgaynhan = new System.Windows.Forms.Label();
			this.lblngaytra = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.lblcdls = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.Blue;
			this.label6.Location = new System.Drawing.Point(8, 136);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(128, 16);
			this.label6.TabIndex = 0;
			this.label6.Text = "ĐẠI THỂ";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbldiathe
			// 
			this.lbldiathe.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lbldiathe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbldiathe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbldiathe.ForeColor = System.Drawing.Color.Black;
			this.lbldiathe.Location = new System.Drawing.Point(8, 152);
			this.lbldiathe.Name = "lbldiathe";
			this.lbldiathe.Size = new System.Drawing.Size(696, 48);
			this.lbldiathe.TabIndex = 0;
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.ForeColor = System.Drawing.Color.Blue;
			this.label8.Location = new System.Drawing.Point(8, 200);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(96, 24);
			this.label8.TabIndex = 0;
			this.label8.Text = "NHUỘM ĐẶC BIỆT";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lstvnhuondb
			// 
			this.lstvnhuondb.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.STT,
																						  this.ppnhuom,
																						  this.DT,
																						  this.CD,
																						  this.TL,
																						  this.GHICHU});
			this.lstvnhuondb.ForeColor = System.Drawing.Color.Black;
			this.lstvnhuondb.FullRowSelect = true;
			this.lstvnhuondb.GridLines = true;
			this.lstvnhuondb.Location = new System.Drawing.Point(8, 224);
			this.lstvnhuondb.Name = "lstvnhuondb";
			this.lstvnhuondb.Size = new System.Drawing.Size(696, 80);
			this.lstvnhuondb.TabIndex = 4;
			this.lstvnhuondb.View = System.Windows.Forms.View.Details;
			// 
			// STT
			// 
			this.STT.Text = "STT";
			this.STT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ppnhuom
			// 
			this.ppnhuom.Text = "PHƯƠNG PHÁP NHUỘM";
			this.ppnhuom.Width = 256;
			// 
			// DT
			// 
			this.DT.Text = "DƯƠNG TÍNH";
			this.DT.Width = 83;
			// 
			// CD
			// 
			this.CD.Text = "CƯỜNG ĐỘ";
			this.CD.Width = 78;
			// 
			// TL
			// 
			this.TL.Text = "TỶ LỆ ";
			this.TL.Width = 46;
			// 
			// GHICHU
			// 
			this.GHICHU.Text = "GHI CHÚ";
			this.GHICHU.Width = 418;
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label10.ForeColor = System.Drawing.Color.Blue;
			this.label10.Location = new System.Drawing.Point(8, 304);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(128, 24);
			this.label10.TabIndex = 0;
			this.label10.Text = "VI THỂ";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblvithe
			// 
			this.lblvithe.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblvithe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblvithe.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblvithe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblvithe.ForeColor = System.Drawing.Color.Black;
			this.lblvithe.Location = new System.Drawing.Point(8, 328);
			this.lblvithe.Name = "lblvithe";
			this.lblvithe.Size = new System.Drawing.Size(696, 48);
			this.lblvithe.TabIndex = 0;
			// 
			// lblketluan
			// 
			this.lblketluan.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblketluan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblketluan.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblketluan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblketluan.ForeColor = System.Drawing.Color.Black;
			this.lblketluan.Location = new System.Drawing.Point(8, 400);
			this.lblketluan.Name = "lblketluan";
			this.lblketluan.Size = new System.Drawing.Size(696, 48);
			this.lblketluan.TabIndex = 0;
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label13.ForeColor = System.Drawing.Color.Blue;
			this.label13.Location = new System.Drawing.Point(8, 376);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(128, 24);
			this.label13.TabIndex = 0;
			this.label13.Text = "KẾT LUẬN";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label14
			// 
			this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label14.ForeColor = System.Drawing.Color.Blue;
			this.label14.Location = new System.Drawing.Point(8, 448);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(128, 24);
			this.label14.TabIndex = 0;
			this.label14.Text = "BÀN LUẬN";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblbanluan
			// 
			this.lblbanluan.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblbanluan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblbanluan.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblbanluan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblbanluan.ForeColor = System.Drawing.Color.Black;
			this.lblbanluan.Location = new System.Drawing.Point(8, 472);
			this.lblbanluan.Name = "lblbanluan";
			this.lblbanluan.Size = new System.Drawing.Size(696, 48);
			this.lblbanluan.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.button1,
																				 this.label2,
																				 this.treeViewAll,
																				 this.lblhotenbn,
																				 this.label1,
																				 this.label3,
																				 this.label4,
																				 this.label5,
																				 this.lblvtst,
																				 this.lblNgaynhan,
																				 this.lblngaytra,
																				 this.label9,
																				 this.lblcdls});
			this.panel1.Location = new System.Drawing.Point(8, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(696, 136);
			this.panel1.TabIndex = 5;
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Location = new System.Drawing.Point(584, 48);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 48);
			this.button1.TabIndex = 18;
			this.button1.Text = "&Kết thúc";
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.Blue;
			this.label2.Location = new System.Drawing.Point(16, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 16);
			this.label2.TabIndex = 17;
			this.label2.Text = "Các lần giải phẩu";
			// 
			// treeViewAll
			// 
			this.treeViewAll.BackColor = System.Drawing.SystemColors.ControlLight;
			this.treeViewAll.ImageIndex = -1;
			this.treeViewAll.Location = new System.Drawing.Point(16, 16);
			this.treeViewAll.Name = "treeViewAll";
			this.treeViewAll.SelectedImageIndex = -1;
			this.treeViewAll.Size = new System.Drawing.Size(136, 112);
			this.treeViewAll.TabIndex = 16;
			// 
			// lblhotenbn
			// 
			this.lblhotenbn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblhotenbn.ForeColor = System.Drawing.Color.Black;
			this.lblhotenbn.Location = new System.Drawing.Point(296, 16);
			this.lblhotenbn.Name = "lblhotenbn";
			this.lblhotenbn.Size = new System.Drawing.Size(264, 16);
			this.lblhotenbn.TabIndex = 15;
			this.lblhotenbn.Text = "label2";
			this.lblhotenbn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Blue;
			this.label1.Location = new System.Drawing.Point(192, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 10;
			this.label1.Text = "XEM GIẢI PHẨU:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Blue;
			this.label3.Location = new System.Drawing.Point(160, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "VỊ TRÍ SINH THIẾT:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.Blue;
			this.label4.Location = new System.Drawing.Point(160, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(128, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "NGÀY NHẬN:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.Blue;
			this.label5.Location = new System.Drawing.Point(160, 64);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(128, 16);
			this.label5.TabIndex = 9;
			this.label5.Text = "NGÀY TRẢ:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblvtst
			// 
			this.lblvtst.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblvtst.ForeColor = System.Drawing.Color.Black;
			this.lblvtst.Location = new System.Drawing.Point(296, 88);
			this.lblvtst.Name = "lblvtst";
			this.lblvtst.Size = new System.Drawing.Size(264, 16);
			this.lblvtst.TabIndex = 14;
			this.lblvtst.Text = "label2";
			this.lblvtst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblNgaynhan
			// 
			this.lblNgaynhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNgaynhan.ForeColor = System.Drawing.Color.Black;
			this.lblNgaynhan.Location = new System.Drawing.Point(296, 40);
			this.lblNgaynhan.Name = "lblNgaynhan";
			this.lblNgaynhan.Size = new System.Drawing.Size(264, 16);
			this.lblNgaynhan.TabIndex = 11;
			this.lblNgaynhan.Text = "label2";
			this.lblNgaynhan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblngaytra
			// 
			this.lblngaytra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblngaytra.ForeColor = System.Drawing.Color.Black;
			this.lblngaytra.Location = new System.Drawing.Point(296, 64);
			this.lblngaytra.Name = "lblngaytra";
			this.lblngaytra.Size = new System.Drawing.Size(264, 16);
			this.lblngaytra.TabIndex = 12;
			this.lblngaytra.Text = "label2";
			this.lblngaytra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label9.ForeColor = System.Drawing.Color.Blue;
			this.label9.Location = new System.Drawing.Point(160, 112);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(128, 16);
			this.label9.TabIndex = 8;
			this.label9.Text = "CHẨN ĐOÁN LÂM SÀN:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblcdls
			// 
			this.lblcdls.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblcdls.ForeColor = System.Drawing.Color.Black;
			this.lblcdls.Location = new System.Drawing.Point(296, 112);
			this.lblcdls.Name = "lblcdls";
			this.lblcdls.Size = new System.Drawing.Size(264, 16);
			this.lblcdls.TabIndex = 13;
			this.lblcdls.Text = "label2";
			this.lblcdls.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmxemgiaiphaubenh
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(712, 525);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel1,
																		  this.lstvnhuondb,
																		  this.label6,
																		  this.lbldiathe,
																		  this.label8,
																		  this.label10,
																		  this.lblvithe,
																		  this.lblketluan,
																		  this.label13,
																		  this.label14,
																		  this.lblbanluan});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmxemgiaiphaubenh";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Xem giải phẩu bệnh";
			this.Load += new System.EventHandler(this.frmxemgiaiphaubenh_Load_1);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmxemgiaiphaubenh_Load(object sender, System.EventArgs e)
		{
			
		}
		
		private void loadTree (string mabenhnhan )
		{
			
			string sql = "Select a.*,b.*   From "+b.user+".GPB_PXN a, "+b.user+".GPB_BTD  and SoHS ='"+mabenhnhan+"'" ;
			DataSet Ds= b.get_data(sql);
			nodePXN node;
			foreach (DataRow rr in Ds.Tables[0].Rows)
			{
				node = new nodePXN(rr);
				treeViewAll.Nodes.Add(node);				
			}
			treeViewAll.Enabled= true;
		}

		private void frmxemgiaiphaubenh_Load_1(object sender, System.EventArgs e)
		{
			loadTree(m_mabn);
		}
	}
}
