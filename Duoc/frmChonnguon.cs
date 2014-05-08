using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmChonnguon.
	/// </summary>
	public class frmChonnguon : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private int i_nhom;
		private string user;
		public int i_manguon=-1,iLanthu=1;
		public string tennguon,s_makho="";
        private ComboBox manguon;
        private Label label3;
        private Label label1;
        private NumericUpDown lanthu;
        private CheckedListBox kho;
        private Label label2;
        private DataTable dtkho = new DataTable();
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChonnguon(AccessData acc,int nhom, string makho)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
            s_makho = makho;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonnguon));
            this.butOk = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lanthu = new System.Windows.Forms.NumericUpDown();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lanthu)).BeginInit();
            this.SuspendLayout();
            // 
            // butOk
            // 
            this.butOk.Image = global::Duoc.Properties.Resources.ok;
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(85, 208);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 4;
            this.butOk.Text = "Đồng ý";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(154, 208);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 5;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // manguon
            // 
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(64, 34);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(224, 21);
            this.manguon.TabIndex = 3;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manguon_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nguồn :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lần thứ :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lanthu
            // 
            this.lanthu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lanthu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lanthu.Location = new System.Drawing.Point(64, 10);
            this.lanthu.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.lanthu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lanthu.Name = "lanthu";
            this.lanthu.Size = new System.Drawing.Size(224, 21);
            this.lanthu.TabIndex = 1;
            this.lanthu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lanthu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manguon_KeyDown);
            // 
            // kho
            // 
            this.kho.CheckOnClick = true;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(64, 57);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(224, 132);
            this.kho.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Kho :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmChonnguon
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(291, 245);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.lanthu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChonnguon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn nguồn";
            this.Load += new System.EventHandler(this.frmChonnguon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lanthu)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmChonnguon_Load(object sender, System.EventArgs e)
		{
            user = d.user;
            manguon.DisplayMember = "TEN";
            manguon.ValueMember = "ID";
            if (d.bQuanlynguon(i_nhom))
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where nhom=" + i_nhom + " order by stt").Tables[0];
            else
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];

            manguon.SelectedIndex = -1;

            //

            string asql = "select id, ten from " + user + ".d_dmkho where dutru=1 and nhom=" + i_nhom;
            if (s_makho.Trim().Trim(',') != "") asql += " and id in(" + s_makho.Trim().Trim(',') + ")";

            dtkho = d.get_data(asql).Tables[0];
            kho.DataSource = dtkho;
            kho.DisplayMember = "TEN";
            kho.ValueMember = "ID";
            //
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
            i_manguon = (manguon.SelectedIndex!=-1)?int.Parse(manguon.SelectedValue.ToString()):-1;
            tennguon = (manguon.SelectedIndex != -1) ? manguon.Text : "";
            iLanthu = Int16.Parse(lanthu.Value.ToString());
            s_makho = "";
            //
            for (int i = 0; i < kho.Items.Count; i++)
            {
                if (kho.GetItemChecked(i))
                {
                    s_makho += dtkho.Rows[i]["id"].ToString() + ",";
                }
            }
            //
			d.close();this.Close();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			tennguon="~";
			d.close();this.Close();
		}

        private void manguon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab) SendKeys.Send("{Tab}");
        }
	}
}
