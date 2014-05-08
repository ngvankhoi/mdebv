using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
//using LibMedi;
//using LibVienphi;
//using LibDuoc;
//using doiso;
using dichso;
//using Medisoft_Image;

namespace Medisoft
{
	/// <summary>
	/// Summary description for Dang ki kham benh.
	/// </summary>
	public class frmTiepdon : frmDkkb_chung
	{
        private System.ComponentModel.IContainer components = null;

        public frmTiepdon(LibMedi.AccessData _acc, string _makp, string _hoten, int _userid, int _sohieu, int _loai, string _madoituong, int _khudieutri, int _chinhanh)
		{
			InitializeComponent();
            base.acc = _acc;
            base.KhuDieuTri = _khudieutri;
            base.MaKhoaPhong = _makp;
            base.HoTenUser = _hoten;
            base.UserID = _userid;
            base.SoHieu = _sohieu;
            base.Loai = _loai;
            base.MaDoiTuong = _madoituong;
            base.init();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
        ///
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTiepdon));
            ((System.ComponentModel.ISupportInitialize)(this.dtv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dthinh)).BeginInit();
            this.phanhchinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).BeginInit();
            this.pdienthoai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBarcode)).BeginInit();
            this.pgoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sonhay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            this.pmien.SuspendLayout();
            this.dausinhton.SuspendLayout();
            this.khamthai.SuspendLayout();
            this.pnmakp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.pvaovien.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.LineColor = System.Drawing.Color.Black;
            // 
            // butLuu
            // 
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // frmTiepdon
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(874, 573);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTiepdon";
            this.Load += new System.EventHandler(this.frmTiepdon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dthinh)).EndInit();
            this.phanhchinh.ResumeLayout(false);
            this.phanhchinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).EndInit();
            this.pdienthoai.ResumeLayout(false);
            this.pdienthoai.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBarcode)).EndInit();
            this.pgoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sonhay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            this.pmien.ResumeLayout(false);
            this.dausinhton.ResumeLayout(false);
            this.dausinhton.PerformLayout();
            this.khamthai.ResumeLayout(false);
            this.khamthai.PerformLayout();
            this.pnmakp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.pvaovien.ResumeLayout(false);
            this.pvaovien.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void frmTiepdon_Load(object sender, EventArgs e)
        {
            base.load_form();

        }

        private void butLuu_Click(object sender, EventArgs e)
        {

        }
	}
}
