using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmCongnoMabn.
	/// </summary>
	public class frmCongnoMabn : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lThuaThieu;
		private System.Windows.Forms.TextBox tamung;
		private System.Windows.Forms.TextBox thuoc;
		private System.Windows.Forms.TextBox vienphi;
		private System.Windows.Forms.TextBox chiphi;
		private System.Windows.Forms.TextBox thuathieu;
		private System.Windows.Forms.Button butExit;
		private System.Windows.Forms.Panel panel1;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibMedi.AccessData m;
		private decimal maql;
		private string mabn,tu,den;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCongnoMabn(LibMedi.AccessData acc,string _mabn,decimal _maql,string _tu,string _den)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            m = acc; mabn = _mabn; maql = _maql; tu = _tu.Substring(0, 10); den = _den.Substring(0, 10);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCongnoMabn));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lThuaThieu = new System.Windows.Forms.Label();
            this.tamung = new System.Windows.Forms.TextBox();
            this.thuoc = new System.Windows.Forms.TextBox();
            this.vienphi = new System.Windows.Forms.TextBox();
            this.chiphi = new System.Windows.Forms.TextBox();
            this.thuathieu = new System.Windows.Forms.TextBox();
            this.butExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tạm ứng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Thuốc :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Viện phí :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Chi phí :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lThuaThieu
            // 
            this.lThuaThieu.Location = new System.Drawing.Point(24, 111);
            this.lThuaThieu.Name = "lThuaThieu";
            this.lThuaThieu.Size = new System.Drawing.Size(56, 23);
            this.lThuaThieu.TabIndex = 8;
            this.lThuaThieu.Text = "Thừa :";
            this.lThuaThieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tamung
            // 
            this.tamung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tamung.Enabled = false;
            this.tamung.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tamung.Location = new System.Drawing.Point(88, 7);
            this.tamung.Name = "tamung";
            this.tamung.Size = new System.Drawing.Size(104, 23);
            this.tamung.TabIndex = 1;
            this.tamung.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // thuoc
            // 
            this.thuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thuoc.Enabled = false;
            this.thuoc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thuoc.Location = new System.Drawing.Point(88, 31);
            this.thuoc.Name = "thuoc";
            this.thuoc.Size = new System.Drawing.Size(104, 23);
            this.thuoc.TabIndex = 3;
            this.thuoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // vienphi
            // 
            this.vienphi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.vienphi.Enabled = false;
            this.vienphi.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vienphi.Location = new System.Drawing.Point(88, 55);
            this.vienphi.Name = "vienphi";
            this.vienphi.Size = new System.Drawing.Size(104, 23);
            this.vienphi.TabIndex = 5;
            this.vienphi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chiphi
            // 
            this.chiphi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chiphi.Enabled = false;
            this.chiphi.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chiphi.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chiphi.Location = new System.Drawing.Point(88, 79);
            this.chiphi.Name = "chiphi";
            this.chiphi.Size = new System.Drawing.Size(104, 23);
            this.chiphi.TabIndex = 7;
            this.chiphi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // thuathieu
            // 
            this.thuathieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thuathieu.Enabled = false;
            this.thuathieu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thuathieu.ForeColor = System.Drawing.Color.Red;
            this.thuathieu.Location = new System.Drawing.Point(88, 111);
            this.thuathieu.Name = "thuathieu";
            this.thuathieu.Size = new System.Drawing.Size(104, 23);
            this.thuathieu.TabIndex = 9;
            this.thuathieu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // butExit
            // 
            this.butExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butExit.Location = new System.Drawing.Point(78, 144);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(70, 25);
            this.butExit.TabIndex = 10;
            this.butExit.Text = "&Kết thúc";
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(32, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 1);
            this.panel1.TabIndex = 11;
            // 
            // frmCongnoMabn
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.butExit;
            this.ClientSize = new System.Drawing.Size(208, 181);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.thuathieu);
            this.Controls.Add(this.chiphi);
            this.Controls.Add(this.vienphi);
            this.Controls.Add(this.thuoc);
            this.Controls.Add(this.tamung);
            this.Controls.Add(this.lThuaThieu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCongnoMabn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Công nợ";
            this.Load += new System.EventHandler(this.frmCongnoMabn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmCongnoMabn_Load(object sender, System.EventArgs e)
		{
			decimal _tamung=m.get_tamung(mabn,maql,tu,den,"",0);
			decimal _thuoc=d.get_thuoc(maql,tu,den,"",0,true);
			decimal _vienphi=m.get_vienphi(maql,tu,den,"",0,true);
			decimal _sotien=_thuoc+_vienphi;
			decimal _conlai=_sotien-_tamung;
			tamung.Text=_tamung.ToString("###,###,###,##0");
			thuoc.Text=_thuoc.ToString("###,###,###,##0");
			vienphi.Text=_vienphi.ToString("###,###,###,##0");
			chiphi.Text=_sotien.ToString("###,###,###,##0");
			lThuaThieu.Text=(_conlai<0)?"Thừa :":"Thiếu :";
			_conlai=Math.Abs(_conlai);
			thuathieu.Text=_conlai.ToString("###,###,###,##0");
		}

		private void butExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
