using System;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using System.Data;

namespace Medisoft
{
	/// <summary>
	/// Summary description for ColorComboBox.
	/// </summary>
	public class ColorComboBox : System.Windows.Forms.ComboBox
	{
		private bool bHideText;
		private SolidBrush blackBrush; 
		private SolidBrush whiteBrush;
		private DataSet ds=new DataSet();
		/// <summary>
		/// Get the selected color from the combo box
		/// </summary>
		public Color SelectedColor
		{
			get
			{
				return this.BackColor;
			}
			set
			{
				this.BackColor = value;
			}
		}

		public ColorComboBox()
		{
			//
			// TODO: Add constructor logic here
			//
			blackBrush = new SolidBrush(Color.Black);
			whiteBrush = new SolidBrush(Color.White);
			ds.ReadXml("..//..//..//xml//m_doituong.xml");
			this.DataSource=ds.Tables[0];
			this.DisplayMember="DOITUONG";
			this.ValueMember="MADOITUONG";
			this.DrawMode = DrawMode.OwnerDrawFixed;
			this.DrawItem += new DrawItemEventHandler( OnDrawItem );
			this.SelectedIndexChanged += new System.EventHandler( OnSelectedIndexChanged );
			this.DropDown += new System.EventHandler( OnDropDown );
			bHideText = true;
		}

		public ColorComboBox( bool hideText ) : this()
		{
			bHideText = hideText;
		}

		private void OnDrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			if (e.Index!=-1)
			{
				Graphics grfx = e.Graphics;
				Color brushColor = (ds.Tables[0].Rows[e.Index]["trasau"].ToString()=="0")?Color.White:Color.FromArgb(0,255,255);
				SolidBrush brush = new SolidBrush( brushColor );
				grfx.FillRectangle( brush, e.Bounds );
				if( bHideText == false )
				{
					grfx.DrawString(ds.Tables[0].Rows[e.Index]["doituong"].ToString(), e.Font, blackBrush, e.Bounds );
					this.SelectionStart = 0;
					this.SelectionLength = 0;
				}
				else 
				{
					grfx.DrawString(ds.Tables[0].Rows[e.Index]["doituong"].ToString(), e.Font,new SolidBrush((ds.Tables[0].Rows[e.Index]["trasau"].ToString()=="1")?Color.FromArgb(255,255,192):Color.White), e.Bounds );
				}
			}
		}

		private void OnSelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.SelectedIndex!=-1)
			{
				this.BackColor = (ds.Tables[0].Rows[this.SelectedIndex]["trasau"].ToString()=="0")?Color.White:Color.FromArgb(0,255,255);
				if( bHideText == true )
				{
					this.ForeColor = this.BackColor;
					this.SelectionStart = 0;
					this.SelectionLength = 0;
				}
			}
		}

		private void OnDropDown(object sender, System.EventArgs e)
		{
			if (this.SelectedIndex!=-1)
			{
				this.BackColor = (ds.Tables[0].Rows[this.SelectedIndex]["trasau"].ToString()=="0")?Color.White:Color.FromArgb(0,255,255);
				if( bHideText == true )
				{
					this.ForeColor = this.BackColor;
					this.SelectionStart = 0;
					this.SelectionLength = 0;
				}
			}
		}	
	}
}
