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
	/// Summary description for frmChonkho.
	/// </summary>
	public class frmMultikhoa : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown mm;
		private System.Windows.Forms.NumericUpDown yyyy;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private int i_nhom,i_userid;
		private string s_makho,mmyy,s_tenkho,s_makp,user;
		private System.Windows.Forms.CheckedListBox makho;
		private DataTable dtkho=new DataTable();
		private DataTable dtmakp=new DataTable();
		private System.Windows.Forms.CheckedListBox makp;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMultikhoa(AccessData acc,int nhom,string kho,string makp,string mmyy,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
			i_userid=userid;
			s_makho=kho;
			s_makp=makp;
			mm.Value=decimal.Parse(mmyy.Substring(0,2));
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMultikhoa));
            this.label1 = new System.Windows.Forms.Label();
            this.mm = new System.Windows.Forms.NumericUpDown();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.butOk = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.makho = new System.Windows.Forms.CheckedListBox();
            this.makp = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(205, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tháng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mm
            // 
            this.mm.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mm.Location = new System.Drawing.Point(253, 8);
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
            this.mm.TabIndex = 1;
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
            this.yyyy.Location = new System.Drawing.Point(329, 8);
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
            this.yyyy.Size = new System.Drawing.Size(52, 22);
            this.yyyy.TabIndex = 2;
            this.yyyy.Value = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.yyyy_KeyDown);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(293, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Năm :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butOk
            // 
            this.butOk.Image = global::Duoc.Properties.Resources.ok;
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(125, 241);
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
            this.butKetthuc.Location = new System.Drawing.Point(194, 241);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 5;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // makho
            // 
            this.makho.CheckOnClick = true;
            this.makho.Location = new System.Drawing.Point(213, 34);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(168, 199);
            this.makho.TabIndex = 3;
            // 
            // makp
            // 
            this.makp.CheckOnClick = true;
            this.makp.Location = new System.Drawing.Point(8, 3);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(200, 229);
            this.makp.TabIndex = 0;
            // 
            // frmMultikhoa
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(386, 279);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.mm);
            this.Controls.Add(this.yyyy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMultikhoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn khoa";
            this.Load += new System.EventHandler(this.frmMultikhoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmMultikhoa_Load(object sender, System.EventArgs e)
		{
            user = d.user;
			string sql="select * from "+user+".d_dmkho where hide=0 and nhom="+i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			dtkho=d.get_data(sql).Tables[0];
			makho.DataSource=dtkho;
            makho.DisplayMember = "TEN";
            makho.ValueMember = "ID";

			sql="select * from "+user+".d_duockp where nhom like '%"+i_nhom.ToString()+",%'";
			if (s_makp!="") sql+=" and id in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=" order by stt";
			dtmakp=d.get_data(sql).Tables[0];
            makp.DataSource=dtmakp;
            makp.DisplayMember = "TEN";
            makp.ValueMember = "ID";
		}

		private void mm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) SendKeys.Send("{Tab}");
		}

		private void yyyy_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) SendKeys.Send("{Tab}{F4}");
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			mmyy=mm.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			if (!d.bMmyy(mmyy))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Số liệu tháng")+" "+mmyy.Substring(0,2)+" "+
lan.Change_language_MessageText("năm 20")+mmyy.Substring(2)+" "+
lan.Change_language_MessageText("chưa tạo !"),d.Msg);
				mm.Focus();
				return;
			}
			if (d.bKhoaso(i_nhom,mmyy))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Số liệu tháng")+" "+mmyy.Substring(0,2)+" "+
lan.Change_language_MessageText("năm")+" "+mmyy.Substring(2,2)+"\n"+
lan.Change_language_MessageText("Đã khóa không có phép thay đổi !"),d.Msg);
				return;
			}
			if (makp.CheckedItems.Count==0) for(int i=0;i<makp.Items.Count;i++) makp.SetItemCheckState(i,CheckState.Checked);
			if (makho.CheckedItems.Count==0) for(int i=0;i<makho.Items.Count;i++) makho.SetItemCheckState(i,CheckState.Checked);
			s_tenkho="";
			for(int i=0;i<makp.Items.Count;i++) if (makp.GetItemChecked(i)) s_tenkho+=dtmakp.Rows[i]["ten"].ToString()+";";
			if (MessageBox.Show(
lan.Change_language_MessageText("Bạn có đồng ý kiểm tra lại tồn đầu")+"\n"+s_tenkho+"\n"+
lan.Change_language_MessageText("Tháng")+" "+mmyy.Substring(0,2)+" "+
lan.Change_language_MessageText("năm")+" "+mmyy.Substring(2,2),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
			{
				Cursor=Cursors.WaitCursor;
				string mmyyt=d.Mmyy_truoc(mmyy);
				if (!d.bKhoaso(i_nhom,mmyyt)) d.upd_tonkho(i_nhom,mmyyt);
                //string tenfile = "..\\..\\..\\xml\\tutruc" + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().PadLeft(4, '0') + "_" + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + "_" + mmyy + "_" + i_nhom.ToString().Trim() + ".xml";
                //d.get_data("select a.* from " + user + mmyy + ".d_tutrucct a," + user + ".d_dmkho b where a.makho=b.id and b.nhom=" + i_nhom).WriteXml(tenfile, XmlWriteMode.WriteSchema);
				for(int i=0;i<makp.Items.Count;i++)
				{
					if (makp.GetItemChecked(i))
						for(int j=0;j<makho.Items.Count;j++)
							if (makho.GetItemChecked(j)) d.upd_kiemtratutrucdau(mmyy,int.Parse(dtmakp.Rows[i]["id"].ToString()),int.Parse(dtkho.Rows[j]["id"].ToString()),i_userid);
				}
				d.upd_tonkho(mmyy,i_nhom,2);
				d.execute_data("delete from "+user+mmyy+".d_tonkhoct where tondau=0 and slnhap=0 and slxuat=0");
				d.execute_data("delete from "+user+mmyy+".d_tonkhoth where tondau=0 and slnhap=0 and slxuat=0");
				Cursor=Cursors.Default;
				MessageBox.Show(
lan.Change_language_MessageText("Đã kiểm tra lại tồn đầu")+ "\n"+s_tenkho,d.Msg);
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}
	}
}
