using System;
using AsYetUnnamed;
using System.Windows.Forms;
using System.Data;
namespace LibList
{
	/// <summary>
	/// Summary description for List
	/// </summary>
	public class List : MultiColumnListBox
	{
		private TextBox textbox=null;
		private TextBox textbox1=null;
		private Control con=null;
		public List(int x,int y,int w,int h)
		{
			//
			// TODO: Add constructor logic here
			//
			this.Location=new System.Drawing.Point(x,y);
			this.Width=w;
			this.Height=h;
			init();
		}
		public List(int w,int h)
		{
			this.Width=w;
			this.Height=h;
			init();
		}
		public List()
		{
			this.Location=new System.Drawing.Point(0,0);
			this.Width=0;
			this.Height=0;
			init();
		}
		private void init()
		{
			this.MatchBufferTimeOut = 1000;
			this.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
			//this.TextIndex = -1;
			//this.TextMember = null;
			//this.ValueIndex = -1;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
			this.Visible=false;
			this.SelectedIndex=-1;
			this.SelectionMode=SelectionMode.One;
		}
		public void SetLocation(int x,int y)
		{
			this.Location=new System.Drawing.Point(x,y);
		}
		public void SetDimension(int w,int h)
		{
			this.Width=w;
			this.Height=h;
		}
		public void BrowseToText(TextBox text)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.Location=new System.Drawing.Point(text.Location.X,text.Location.Y + text.Height+3);
				this.Size=new System.Drawing.Size(text.Width,text.Height*5);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=0;
				this.ColumnWidths[1]=this.Width;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}

		public void BrowseToHC(TextBox text)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.Location=new System.Drawing.Point(text.Location.X,text.Location.Y + text.Height+3);
				this.Size=new System.Drawing.Size(text.Width,text.Height*5);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=0;
				this.ColumnWidths[1]=this.Width;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}
        public void BrowseToDmtk(TextBox text, TextBox text1, Control c, int x, int y, int w, int h, int cot)
        {
            this.textbox = text1;
            this.textbox1 = text;
            this.con = c;
            this.Location = new System.Drawing.Point(x, y + 3);
            this.Size = new System.Drawing.Size(w, h * 5);
            this.TabIndex = text.TabIndex;
            this.ColumnWidths[0] = cot;
            this.ColumnWidths[1] = this.Width - cot;
            this.Refresh();
            this.Invalidate();
            if (this.Visible == false && text.Focused)
            { this.Show(); this.BringToFront(); }
            this.SelectedIndex = this.FindString(text.Text, 0, 1);
        }
		public void BrowseToDanhmuc(TextBox text,Control c,int w)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.con=c;
				this.Location=new System.Drawing.Point(text.Location.X,text.Location.Y + text.Height+3);
				this.Size=new System.Drawing.Size(text.Width+w,text.Height*5);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=0;
				this.ColumnWidths[1]=this.Width;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}

		public void BrowseToText(TextBox text,TextBox text1,int x,int y,int w,int h)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.textbox1=text1;
				this.Location=new System.Drawing.Point(x,y+3);
				this.Size=new System.Drawing.Size(w,h*5);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=50;
				this.ColumnWidths[1]=330;
				this.ColumnWidths[2]=this.Width-380;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}
		public void BrowseToText(TextBox text,TextBox text1)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.textbox1=text1;
				this.Location=new System.Drawing.Point(text.Location.X,text.Location.Y + text.Height+3);
				this.Size=new System.Drawing.Size(text.Width,text.Height*5);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=50;
				this.ColumnWidths[1]=330;
				this.ColumnWidths[2]=this.Width-380;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}

		public void BrowseToText(TextBox text,TextBox text1,Control c)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.textbox1=text1;
				this.con=c;
				this.Location=new System.Drawing.Point(text.Location.X,text.Location.Y + text.Height+3);
				this.Size=new System.Drawing.Size(text.Width,text.Height*5);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=50;
				this.ColumnWidths[1]=350;
				this.ColumnWidths[2]=this.Width-400;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}

		public void BrowseToText(TextBox text,TextBox text1,Control c,int cot)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.textbox1=text1;
				this.con=c;
				this.Location=new System.Drawing.Point(text.Location.X,text.Location.Y + text.Height+3);
				this.Size=new System.Drawing.Size(text.Width,text.Height*5);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=50;
				this.ColumnWidths[1]=this.Width-130;
				this.ColumnWidths[2]=20;
				this.ColumnWidths[3]=20;
				this.ColumnWidths[4]=20;
				this.ColumnWidths[5]=20;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}

		public void BrowseToText(TextBox text,TextBox text1,Control c,int x,int y,int w,int h)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.textbox1=text1;
				this.con=c;
				this.Location=new System.Drawing.Point(x,y+3);
				this.Size=new System.Drawing.Size(w,h*5);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=50;
				this.ColumnWidths[1]=330;
				this.ColumnWidths[2]=this.Width-380;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}

        public void BrowseToDmttb(TextBox text, TextBox text1, Control c, int x, int y, int w, int h)
        {
            if (this.TabIndex != text.TabIndex)
            {
                this.textbox = text;
                this.textbox1 = text1;
                this.con = c;
                this.Location = new System.Drawing.Point(x, y + 3);
                this.Size = new System.Drawing.Size(w, h * 5);
                this.TabIndex = text.TabIndex;
                this.ColumnWidths[0] = 50;
                this.ColumnWidths[1] = 200;
                this.ColumnWidths[2] = 50;
                this.ColumnWidths[3] = 150;
                this.ColumnWidths[4] = 150;
                this.ColumnWidths[5] = this.Width - 600;
                this.Refresh();
                this.Invalidate();
            }
            if (this.Visible == false && text.Focused)
            { this.Show(); this.BringToFront(); }
            this.SelectedIndex = this.FindString(text.Text, 0, 1);
        }

		public void BrowseToDmbd(TextBox text,TextBox text1,Control c,int x,int y,int w,int h)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.textbox1=text1;
				this.con=c;
				this.Location=new System.Drawing.Point(x,y+3);
				this.Size=new System.Drawing.Size(w,h*5);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=50;
				this.ColumnWidths[1]=300;
				this.ColumnWidths[2]=300;
				this.ColumnWidths[3]=this.Width-650;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}
		public void BrowseToDmnx(TextBox text,TextBox text1,Control c)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.textbox1=text1;
				this.con=c;
				this.Location=new System.Drawing.Point(text.Location.X,text.Location.Y + text.Height+2);
				this.Size=new System.Drawing.Size(text.Width,text.Height*5);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=80;
				this.ColumnWidths[1]=this.Width-80;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}
		public void BrowseToDmnx(TextBox text,TextBox text1,Control c,int w)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.textbox1=text1;
				this.con=c;
				this.Location=new System.Drawing.Point(text.Location.X,text.Location.Y + text.Height+2);
				this.Size=new System.Drawing.Size(text.Width,text.Height*5);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=w;
				this.ColumnWidths[1]=this.Width-w;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}
		public void BrowseToDanhmuc(TextBox text,TextBox text1,Control c)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.textbox1=text1;
				this.con=c;
				this.Location=new System.Drawing.Point(text.Location.X,text.Location.Y + text.Height+2);
				this.Size=new System.Drawing.Size(text.Width,text.Height*5);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=0;
				this.ColumnWidths[1]=this.Width;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}
		public void BrowseToDanhmuc(TextBox text,TextBox text1,Control c,int w)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.textbox1=text1;
				this.con=c;
				this.Location=new System.Drawing.Point(text.Location.X,text.Location.Y + text.Height+2);
				this.Size=new System.Drawing.Size(text.Width,text.Height*5);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=w;
				this.ColumnWidths[1]=this.Width-w;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}
		public void BrowseToDanhmuc_ma(TextBox text,TextBox text1,Control c,int w)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.textbox1=text1;
				this.con=c;
				this.Location=new System.Drawing.Point(text.Location.X,text.Location.Y + text.Height+2);
				this.Size=new System.Drawing.Size(text.Width,text.Height*5);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=0;
				this.ColumnWidths[1]=this.Width-w;
				this.ColumnWidths[2]=w;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}
		public void BrowseToBtdkp(TextBox text,TextBox text1,Control c)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.textbox1=text1;
				this.con=c;
				this.Location=new System.Drawing.Point(text.Location.X,text.Location.Y + text.Height+2);
				this.Size=new System.Drawing.Size(text.Width,text.Height*5);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=0;
				this.ColumnWidths[1]=this.Width;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}
        public void BrowseToBtdkp(TextBox text, TextBox text1, Control c, int i_width)
        {
            if (this.TabIndex != text.TabIndex)
            {
                this.textbox = text;
                this.textbox1 = text1;
                this.con = c;
                this.Location = new System.Drawing.Point(text.Location.X, text.Location.Y + text.Height + 2);
                this.Size = new System.Drawing.Size((i_width < text.Width) ? text.Width : i_width, text.Height * 5);
                this.TabIndex = text.TabIndex;
                this.ColumnWidths[0] = 0;
                this.ColumnWidths[1] = this.Width;
                this.Refresh();
                this.Invalidate();
            }
            if (this.Visible == false && text.Focused)
            { this.Show(); this.BringToFront(); }
            this.SelectedIndex = this.FindString(text.Text, 0, 1);
        }

        public void BrowseToBtdkp(TextBox text, TextBox text1, Control c, int x, int y, int w, int h)
        {
            if (this.TabIndex != text.TabIndex)
            {
                this.textbox = text;
                this.textbox1 = text1;
                this.con = c;
                //this.Location = new System.Drawing.Point(text.Location.X, text.Location.Y + text.Height + 2);
                //this.Size = new System.Drawing.Size((i_width < text.Width) ? text.Width : i_width, text.Height * 5);
                this.Location = new System.Drawing.Point(x, y + 3);
                this.Size = new System.Drawing.Size(w, h * 5);
                this.TabIndex = text.TabIndex;
                this.ColumnWidths[0] = 0;
                this.ColumnWidths[1] = this.Width;
                this.Refresh();
                this.Invalidate();
            }
            if (this.Visible == false && text.Focused)
            { this.Show(); this.BringToFront(); }
            this.SelectedIndex = this.FindString(text.Text, 0, 1);
        }

		public void BrowseToTonkho(TextBox text,TextBox text1,Control c,int x,int y,int w,int h)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.textbox1=text1;
				this.con=c;
				this.Location=new System.Drawing.Point(x,y+3);
				this.Size=new System.Drawing.Size(w,h*5);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=50;
				this.ColumnWidths[1]=275;
				this.ColumnWidths[2]=275;
				this.ColumnWidths[3]=50;
				this.ColumnWidths[4]=this.Width-650;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}

        public void Tutrucct_taisan(TextBox text, TextBox text1, Control c, int x, int y, int w, int h)
        {
            if (this.TabIndex != text.TabIndex)
            {
                this.textbox = text;
                this.textbox1 = text1;
                this.con = c;
                this.Location = new System.Drawing.Point(x, y + 3);
                this.Size = new System.Drawing.Size(w, h * 4);
                this.TabIndex = text.TabIndex;
                this.ColumnWidths[0] = 0;
                this.ColumnWidths[1] = 100;
                this.ColumnWidths[2] = 50;
                this.ColumnWidths[3] = 175;
                this.ColumnWidths[4] = 85;
                this.ColumnWidths[5] = 90;
                this.ColumnWidths[6] = 50;
                this.ColumnWidths[7] = 100;
                this.ColumnWidths[8] = this.Width - 650;
                this.Refresh();
                this.Invalidate();
            }
            if (this.Visible == false && text.Focused)
            { this.Show(); this.BringToFront(); }
            this.SelectedIndex = this.FindString(text.Text, 0, 1);
        }

        public void BrowseToDmnx_ht(TextBox text, TextBox text1, Control c, int x, int w)
        {
            if (this.TabIndex != text.TabIndex)
            {
                this.textbox = text;
                this.textbox1 = text1;
                this.con = c;
                this.Location = new System.Drawing.Point(x, text.Location.Y + text.Height + 2);
                this.Size = new System.Drawing.Size(w, text.Height * 5);
                this.TabIndex = text.TabIndex;
                this.ColumnWidths[0] = 80;
                this.ColumnWidths[1] = w - 80;
                this.Refresh();
                this.Invalidate();
            }
            if (this.Visible == false && text.Focused)
            { this.Show(); this.BringToFront(); }
            this.SelectedIndex = this.FindString(text.Text, 0, 1);
        }

        public void Tonkhoct_ncc(TextBox text, TextBox text1, Control c, int x, int y, int w, int h)
        {
            if (this.TabIndex != text.TabIndex)
            {
                this.textbox = text;
                this.textbox1 = text1;
                this.con = c;
                this.Location = new System.Drawing.Point(x, y + 3);
                this.Size = new System.Drawing.Size(w, h * 4);
                this.TabIndex = text.TabIndex;
                this.ColumnWidths[0] = 0;
                this.ColumnWidths[1] = 100;
                this.ColumnWidths[2] = 50;
                this.ColumnWidths[3] = 175;
                this.ColumnWidths[4] = 65;
                this.ColumnWidths[5] = 50;
                this.ColumnWidths[6] = 90;
                this.ColumnWidths[7] = 100;
                this.ColumnWidths[8] = this.Width - 650;
                this.Refresh();
                this.Invalidate();
            }
            if (this.Visible == false && text.Focused)
            { this.Show(); this.BringToFront(); }
            this.SelectedIndex = this.FindString(text.Text, 0, 1);
        }

		public void BrowseToBieu11(TextBox text,TextBox text1,Control c,int x,int y,int w,int h)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.textbox1=text1;
				this.con=c;
				this.Location=new System.Drawing.Point(x,y);
				this.Size=new System.Drawing.Size(w,h*3);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=50;
				this.ColumnWidths[1]=this.Width-150;
				this.ColumnWidths[2]=100;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}

		public void BrowseToThon(TextBox text,TextBox text1,Control c)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.textbox1=text1;
				this.con=c;
				this.Location=new System.Drawing.Point(text.Location.X,text.Location.Y + text.Height+3);
				this.Size=new System.Drawing.Size(text.Width,text.Height*5);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=this.Width;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}

		public void BrowseToICD10(TextBox text,TextBox text1,Control c,int x,int y,int w,int h)
		{
			//			if(this.TabIndex != text.TabIndex)
			//			{	
			this.textbox=text;
			this.textbox1=text1;
			this.con=c;
			this.Location=new System.Drawing.Point(x,y+3);
			this.Size=new System.Drawing.Size(w,h*5);
			this.TabIndex=text.TabIndex;
			this.ColumnWidths[0]=50;
			this.ColumnWidths[1]=this.Width-50;
			this.Refresh();
			this.Invalidate();
			//			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
	}

		public void BrowseToPTTT(TextBox text,TextBox text1,Control c,int x,int y,int w,int h)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.textbox1=text1;
				this.con=c;
				this.Location=new System.Drawing.Point(x,y+3);
				this.Size=new System.Drawing.Size(w,h*5);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=80;
				this.ColumnWidths[1]=this.Width-80;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}

		public void BrowseToTonkhoct(TextBox text,TextBox text1,Control c,int x,int y,int w,int h)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.textbox1=text1;
				this.con=c;
				this.Location=new System.Drawing.Point(x,y+3);
				this.Size=new System.Drawing.Size(w,h*5);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=0;
				this.ColumnWidths[1]=50;
				this.ColumnWidths[2]=225;
				this.ColumnWidths[3]=225;
				this.ColumnWidths[4]=50;
				this.ColumnWidths[5]=100;
				this.ColumnWidths[6]=this.Width-650;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}

		public void Tonkhoct_xuatban(TextBox text,TextBox text1,Control c,int x,int y,int w,int h)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.textbox1=text1;
				this.con=c;
				this.Location=new System.Drawing.Point(x,y+3);
				this.Size=new System.Drawing.Size(w,h*4);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=0;
				this.ColumnWidths[1]=0;
				this.ColumnWidths[2]=100;
				this.ColumnWidths[3]=200;
				this.ColumnWidths[4]=0;
				this.ColumnWidths[5]=100;
				this.ColumnWidths[6]=0;
				this.ColumnWidths[7]=100;
				this.ColumnWidths[8]=this.Width-500;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}

		public void Tonkhoct(TextBox text,TextBox text1,Control c,int x,int y,int w,int h)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.textbox1=text1;
				this.con=c;
				this.Location=new System.Drawing.Point(x,y+3);
				this.Size=new System.Drawing.Size(w,h*4);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=0;
				this.ColumnWidths[1]=100;
				this.ColumnWidths[2]=50;
				this.ColumnWidths[3]=175;
				this.ColumnWidths[4]=175;
				this.ColumnWidths[5]=50;
				this.ColumnWidths[6]=100;
				this.ColumnWidths[7]=this.Width-650;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}

        public void Nhaan(TextBox text, TextBox text1, Control c, int x, int y, int w, int h)
        {
            if (this.TabIndex != text.TabIndex)
            {
                this.textbox = text;
                this.textbox1 = text1;
                this.con = c;
                this.Location = new System.Drawing.Point(x, y + 3);
                this.Size = new System.Drawing.Size(w, h * 4);
                this.TabIndex = text.TabIndex;
                this.ColumnWidths[0] = 0;
                this.ColumnWidths[1] = 70;
                this.ColumnWidths[2] = 80;
                this.ColumnWidths[3] = 200;
                this.ColumnWidths[4] = 180;
                this.ColumnWidths[5] = this.Width - 530;
                this.Refresh();
                this.Invalidate();
            }
            if (this.Visible == false && text.Focused)
            { this.Show(); this.BringToFront(); }
            this.SelectedIndex = this.FindString(text.Text, 0, 1);
        }

		public void Tonkhoctht(TextBox text,TextBox text1,Control c,int x,int y,int w,int h)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.textbox1=text1;
				this.con=c;
				this.Location=new System.Drawing.Point(x,y+3);
				this.Size=new System.Drawing.Size(w,h*4);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=0;
				this.ColumnWidths[1]=100;
				this.ColumnWidths[2]=50;
				this.ColumnWidths[3]=175;
				this.ColumnWidths[4]=175;
				this.ColumnWidths[5]=50;
				this.ColumnWidths[6]=80;
				this.ColumnWidths[7]=50;
				this.ColumnWidths[8]=this.Width-680;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}

        public void Tonkhohtra(TextBox text, TextBox text1, Control c, int x, int y, int w, int h)
        {
            if (this.TabIndex != text.TabIndex)
            {
                this.textbox = text;
                this.textbox1 = text1;
                this.con = c;
                this.Location = new System.Drawing.Point(x, y + 3);
                this.Size = new System.Drawing.Size(w, h * 4);
                this.TabIndex = text.TabIndex;
                this.ColumnWidths[0] = 0;
                this.ColumnWidths[1] = 50;
                this.ColumnWidths[2] = 175;
                this.ColumnWidths[3] = 50;
                this.ColumnWidths[4] = 80;
                this.ColumnWidths[5] = 50;
                this.ColumnWidths[6] = this.Width - 405;
                this.Refresh();
                this.Invalidate();
            }
            if (this.Visible == false && text.Focused)
            { this.Show(); this.BringToFront(); }
            this.SelectedIndex = this.FindString(text.Text, 0, 1);
        }

		public void BrowseToToathuoc(TextBox text,TextBox text1,Control c,int w)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.textbox1=text1;
				this.con=c;
				this.Location=new System.Drawing.Point(text.Location.X,text.Location.Y + text.Height+3);
				this.Size=new System.Drawing.Size(w,text.Height*5);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=0;
				this.ColumnWidths[1]=290;
				this.ColumnWidths[2]=290;
				this.ColumnWidths[3]=this.Width-580;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}

        public void List_ng(TextBox text, TextBox text1, Control c, int x, int y, int w, int h)
        {
            if (this.TabIndex != text.TabIndex)
            {
                this.textbox = text;
                this.textbox1 = text1;
                this.con = c;
                this.Location = new System.Drawing.Point(x, y + 3);
                this.Size = new System.Drawing.Size(w, h * 5);
                this.TabIndex = text.TabIndex;
                this.ColumnWidths[0] = 90;
                this.ColumnWidths[1] = 360;
                this.ColumnWidths[2] = 30;
                this.ColumnWidths[3] = 80;
                this.ColumnWidths[4] = 80;
                this.ColumnWidths[5] = 40;
                this.ColumnWidths[6] = this.Width - 680;
                this.Refresh();
                this.Invalidate();
            }
            if (this.Visible == false && text.Focused)
            { this.Show(); this.BringToFront(); }
            this.SelectedIndex = this.FindString(text.Text, 0, 1);
        }

		public void OtherList(TextBox text,TextBox text1,Control c,int x,int y,int w,int h)
		{
			if(this.TabIndex != text.TabIndex)
			{	
				this.textbox=text;
				this.textbox1=text1;
				this.con=c;
				this.Location=new System.Drawing.Point(x,y+3);
				this.Size=new System.Drawing.Size(w,h*5);
				this.TabIndex=text.TabIndex;
				this.ColumnWidths[0]=90;
				this.ColumnWidths[1]=260;
				this.ColumnWidths[2]=30;
				this.ColumnWidths[3]=60;
				this.ColumnWidths[4]=60;
				this.ColumnWidths[5]=this.Width-500;
				this.Refresh();
				this.Invalidate();
			}
			if(this.Visible==false && text.Focused) 
			{this.Show();this.BringToFront();}
			this.SelectedIndex=this.FindString(text.Text,0,1);
		}

        public void Browse_mavp(TextBox text, TextBox text1, Control c, int x, int y, int w, int h)
        {
            if (this.TabIndex != text.TabIndex)
            {
                this.textbox = text;
                this.textbox1 = text1;
                this.con = c;
                this.Location = new System.Drawing.Point(x, y + 3);
                this.Size = new System.Drawing.Size(w, h * 5);
                this.TabIndex = text.TabIndex;
                this.ColumnWidths[0] = 90;
                this.ColumnWidths[1] = this.Width - 90;
                this.Refresh();
                this.Invalidate();
            }
            if (this.Visible == false && text.Focused)
            { this.Show(); this.BringToFront(); }
            this.SelectedIndex = this.FindString(text.Text, 0, 1);
        }

		private void list_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab )
			{
				try
				{
					string t1=this.SelectedValue.ToString().Trim();
					string t2=this.Text.Trim();
					textbox.Text=t1;
					textbox1.Text=t2;
				}
				catch{}
				//this.SelectedIndex=-1;
				if(con!=null) con.Focus();
				else SendKeys.Send("{End}");
				this.Hide();
			}
			if(e.KeyCode==Keys.Escape )this.Hide();
		}
        //--linh
        public void BrowseToDanhmuc(TextBox text, TextBox text1, Control c, int x, int y, int w)
        {
            if (this.TabIndex != text.TabIndex)
            {
                this.textbox = text;
                this.textbox1 = text1;
                this.con = c;
                //this.Location=new System.Drawing.Point(text.Location.X,text.Location.Y + text.Height+2);
                this.Location = new System.Drawing.Point(x, y);
                this.Size = new System.Drawing.Size(text.Width, text.Height * 5);
                this.TabIndex = text.TabIndex;
                this.ColumnWidths[0] = w;
                this.ColumnWidths[1] = this.Width - w;
                this.Refresh();
                this.Invalidate();
            }
            if (this.Visible == false && text.Focused)
            { this.Show(); this.BringToFront(); }
            this.SelectedIndex = this.FindString(text.Text, 0, 1);
        }
        //end
        //--Thuy
        public void BrowseToDanhmuc_bschidinh(TextBox text, TextBox text1, Control c, int x, int y, int w)
        {
            this.textbox = text;
            this.textbox1 = text1;
            this.con = c;
            //this.Location=new System.Drawing.Point(text.Location.X,text.Location.Y + text.Height+2);
            this.Location = new System.Drawing.Point(x, y);
            this.Size = new System.Drawing.Size(w, text.Height * 5);
            this.TabIndex = text.TabIndex;
            this.ColumnWidths[0] = text.Width;
            this.ColumnWidths[1] = text1.Width-100;
            //this.ColumnWidths[1] = text1.Width;
            this.ColumnWidths[2] = 0;
            this.ColumnWidths[4] = 100;
            this.Refresh();
            this.Invalidate();
            if (this.Visible == false && text.Focused)
            { this.Show(); this.BringToFront(); }
            this.SelectedIndex = this.FindString(text.Text, 0, 1);
        }
        //end
	}
}
