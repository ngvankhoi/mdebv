using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using LibDuoc;
using System.Data;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmLogin.
	/// </summary>
	public class frmDoingay : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private AccessData d;
		private Wildgrape.Aqua.Controls.Button cmdOk;
		private Wildgrape.Aqua.Controls.Button cmdCancle;
		public string mMmyy,mNgay,user;
		private int i_nhom,i_userid;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker ngay;
		private System.Windows.Forms.NumericUpDown mm;
		private System.Windows.Forms.NumericUpDown yyyy;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDoingay(AccessData acc,string mmyy,int nhom,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
			i_userid=userid;
			mm.Value=decimal.Parse(mmyy.Substring(0,2));
			yyyy.Value=decimal.Parse("20"+mmyy.Substring(2,2));
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoingay));
            this.cmdOk = new Wildgrape.Aqua.Controls.Button();
            this.cmdCancle = new Wildgrape.Aqua.Controls.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ngay = new System.Windows.Forms.DateTimePicker();
            this.mm = new System.Windows.Forms.NumericUpDown();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOk
            // 
            this.cmdOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOk.Location = new System.Drawing.Point(22, 70);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.SizeToLabel = false;
            this.cmdOk.TabIndex = 5;
            this.cmdOk.Text = "Chọn";
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdCancle
            // 
            this.cmdCancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancle.Location = new System.Drawing.Point(102, 70);
            this.cmdCancle.Name = "cmdCancle";
            this.cmdCancle.SizeToLabel = false;
            this.cmdCancle.TabIndex = 6;
            this.cmdCancle.Text = "Kết thúc";
            this.cmdCancle.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ngày làm việc :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(3, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Số liệu tháng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(118, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Năm :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngay
            // 
            this.ngay.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.CustomFormat = "dd/MM/yyyy";
            this.ngay.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngay.Location = new System.Drawing.Point(84, 10);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(119, 22);
            this.ngay.TabIndex = 2;
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            this.ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // mm
            // 
            this.mm.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mm.Location = new System.Drawing.Point(84, 34);
            this.mm.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.mm.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.Name = "mm";
            this.mm.Size = new System.Drawing.Size(35, 22);
            this.mm.TabIndex = 3;
            this.mm.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mm_KeyDown);
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(153, 34);
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
            this.yyyy.Size = new System.Drawing.Size(50, 22);
            this.yyyy.TabIndex = 4;
            this.yyyy.Value = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.yyyy_KeyDown);
            // 
            // frmDoingay
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(214, 115);
            this.ControlBox = false;
            this.Controls.Add(this.mm);
            this.Controls.Add(this.yyyy);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdCancle);
            this.Controls.Add(this.cmdOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDoingay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi ngày";
            ((System.ComponentModel.ISupportInitialize)(this.mm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void cmdOk_Click(object sender, System.EventArgs e)
		{
            user = d.user;			
            //
            mMmyy = mm.Value.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
            string a_mmyy = d.mmyy(ngay.Text);
            if (mm.Enabled == false)
            {
                mm.Value = decimal.Parse(a_mmyy.Substring(0, 2));
                yyyy.Value = 2000 + decimal.Parse(a_mmyy.Substring(2, 2));
                this.Refresh();
                mMmyy = mm.Value.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
            }
            else if (a_mmyy != "" && mMmyy != a_mmyy && mm.Enabled)            
            {
                long l_ngaykk =Math.Min( d.iNgaykiemke,30);
                long l_songay = d.songay(d.StringToDate(ngay.Text), d.StringToDate("01/" + mMmyy.Substring(0, 2) + "/" + yyyy.Value.ToString()), 0);
                if (l_songay < 0) l_songay = l_songay * -1;
                if (l_songay < l_ngaykk)
                {
                    DialogResult dlg = MessageBox.Show("Ngày làm việc (" + ngay.Text + ") nhưng số liệu tháng lại là : " + mMmyy + ".\nKích YES lấy số liệu tháng : " + a_mmyy.Substring(0, 2) + "/20" + a_mmyy.Substring(2, 2) + "\n Kích NO lấy số liệu tháng: " + mMmyy.Substring(0, 2) + "/20" + mMmyy.Substring(2, 2), "Medisoft THIS", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dlg == DialogResult.Yes)
                    {
                        mm.Value = decimal.Parse(a_mmyy.Substring(0, 2));
                        yyyy.Value = 2000 + decimal.Parse(a_mmyy.Substring(2, 2));
                        this.Refresh();
                        mMmyy = mm.Value.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
                    }
                    else if (dlg == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                else
                {
                    mm.Value = decimal.Parse(a_mmyy.Substring(0, 2));
                    yyyy.Value = 2000 + decimal.Parse(a_mmyy.Substring(2, 2));
                    this.Refresh();
                    mMmyy = mm.Value.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
                }
            }
            //
			mNgay=ngay.Text;
			if (!d.bMmyy(mMmyy))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Số liệu tháng")+" "+mMmyy.Substring(0,2)+" "+
lan.Change_language_MessageText("năm 20")+mMmyy.Substring(2,2)+" "+
lan.Change_language_MessageText("chưa tạo !"),d.Msg);
				return;
			}
            d.Tao_view(mMmyy);
			d.close();this.Close();
		}
		
		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void ngay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void mm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void yyyy_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}



        private void ngay_Validated(object sender, EventArgs e)
        {
            string a_mmyy = d.mmyy(ngay.Text);
            if (a_mmyy != "")
            {
                mm.Value = decimal.Parse(a_mmyy.Substring(0, 2));
                yyyy.Value = 2000 + decimal.Parse(a_mmyy.Substring(2, 2));
            }
        }
	}
}
