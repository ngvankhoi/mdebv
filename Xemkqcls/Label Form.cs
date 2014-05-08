using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace frmCanlamsan
{
	/// <summary>
	/// Summary description for LabelformType.
	/// </summary>
	public class LabelFormType : System.Windows.Forms.Form
	{
		public System.Windows.Forms.TextBox FontDisplay;
		public System.Windows.Forms.Button OK;
		public System.Windows.Forms.TextBox LineWidth;
		public System.Windows.Forms.GroupBox Tied;
		public System.Windows.Forms.RadioButton Control;
		public System.Windows.Forms.RadioButton ImageCell;
		public System.Windows.Forms.RadioButton ImageScale;
		public System.Windows.Forms.PictureBox BackColour;
		public System.Windows.Forms.PictureBox ForeColour;
		public System.Windows.Forms.GroupBox AlignmentGroup;
		public System.Windows.Forms.RadioButton Alignment_Right;
		public System.Windows.Forms.RadioButton Alignment_Centre;
		public System.Windows.Forms.RadioButton Alignment_Left;
		public System.Windows.Forms.GroupBox LabelTypeGroup;
		public System.Windows.Forms.RadioButton LabelType_Arrow;
		public System.Windows.Forms.RadioButton LabelType_Polygon;
		public System.Windows.Forms.RadioButton LabelType_Ellipse;
		public System.Windows.Forms.RadioButton LabelType_Rectangle;
		public System.Windows.Forms.RadioButton LabelType_PolyLine;
		public System.Windows.Forms.RadioButton LabelType_Line;
		public System.Windows.Forms.RadioButton LabelType_Text;
		public System.Windows.Forms.CheckBox Transparent;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.FontDialog FontDialog;
		internal System.Windows.Forms.ColorDialog ColorDialog;
		internal DicomObjects.doLabelType LabelType;
		internal DicomObjects.doLabelAlignment Alignment;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public LabelFormType()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
			this.FontDisplay = new System.Windows.Forms.TextBox();
			this.OK = new System.Windows.Forms.Button();
			this.LineWidth = new System.Windows.Forms.TextBox();
			this.Tied = new System.Windows.Forms.GroupBox();
			this.Control = new System.Windows.Forms.RadioButton();
			this.ImageCell = new System.Windows.Forms.RadioButton();
			this.ImageScale = new System.Windows.Forms.RadioButton();
			this.BackColour = new System.Windows.Forms.PictureBox();
			this.ForeColour = new System.Windows.Forms.PictureBox();
			this.AlignmentGroup = new System.Windows.Forms.GroupBox();
			this.Alignment_Right = new System.Windows.Forms.RadioButton();
			this.Alignment_Centre = new System.Windows.Forms.RadioButton();
			this.Alignment_Left = new System.Windows.Forms.RadioButton();
			this.LabelTypeGroup = new System.Windows.Forms.GroupBox();
			this.LabelType_Arrow = new System.Windows.Forms.RadioButton();
			this.LabelType_Polygon = new System.Windows.Forms.RadioButton();
			this.LabelType_Ellipse = new System.Windows.Forms.RadioButton();
			this.LabelType_Rectangle = new System.Windows.Forms.RadioButton();
			this.LabelType_PolyLine = new System.Windows.Forms.RadioButton();
			this.LabelType_Line = new System.Windows.Forms.RadioButton();
			this.LabelType_Text = new System.Windows.Forms.RadioButton();
			this.Transparent = new System.Windows.Forms.CheckBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.FontDialog = new System.Windows.Forms.FontDialog();
			this.ColorDialog = new System.Windows.Forms.ColorDialog();
			this.Tied.SuspendLayout();
			this.AlignmentGroup.SuspendLayout();
			this.LabelTypeGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// FontDisplay
			// 
			this.FontDisplay.AcceptsReturn = true;
			this.FontDisplay.AutoSize = false;
			this.FontDisplay.BackColor = System.Drawing.SystemColors.Window;
			this.FontDisplay.CausesValidation = false;
			this.FontDisplay.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.FontDisplay.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FontDisplay.ForeColor = System.Drawing.SystemColors.WindowText;
			this.FontDisplay.Location = new System.Drawing.Point(8, 200);
			this.FontDisplay.MaxLength = 0;
			this.FontDisplay.Name = "FontDisplay";
			this.FontDisplay.ReadOnly = true;
			this.FontDisplay.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.FontDisplay.Size = new System.Drawing.Size(201, 41);
			this.FontDisplay.TabIndex = 49;
			this.FontDisplay.Text = "Arial";
			this.FontDisplay.TextChanged += new System.EventHandler(this.FontDisplay_TextChanged);
			this.FontDisplay.DoubleClick += new System.EventHandler(this.FontDisplay_DoubleClick);
			// 
			// OK
			// 
			this.OK.BackColor = System.Drawing.SystemColors.Control;
			this.OK.Cursor = System.Windows.Forms.Cursors.Default;
			this.OK.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.OK.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OK.Location = new System.Drawing.Point(248, 216);
			this.OK.Name = "OK";
			this.OK.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OK.Size = new System.Drawing.Size(73, 25);
			this.OK.TabIndex = 48;
			this.OK.Text = "OK";
			this.OK.Click += new System.EventHandler(this.OK_Click);
			// 
			// LineWidth
			// 
			this.LineWidth.AcceptsReturn = true;
			this.LineWidth.AutoSize = false;
			this.LineWidth.BackColor = System.Drawing.SystemColors.Window;
			this.LineWidth.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.LineWidth.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LineWidth.ForeColor = System.Drawing.SystemColors.WindowText;
			this.LineWidth.Location = new System.Drawing.Point(184, 128);
			this.LineWidth.MaxLength = 0;
			this.LineWidth.Name = "LineWidth";
			this.LineWidth.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.LineWidth.Size = new System.Drawing.Size(25, 19);
			this.LineWidth.TabIndex = 46;
			this.LineWidth.Text = "1";
			// 
			// Tied
			// 
			this.Tied.BackColor = System.Drawing.SystemColors.Control;
			this.Tied.Controls.AddRange(new System.Windows.Forms.Control[] {
																			   this.Control,
																			   this.ImageCell,
																			   this.ImageScale});
			this.Tied.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Tied.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Tied.Location = new System.Drawing.Point(232, 128);
			this.Tied.Name = "Tied";
			this.Tied.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Tied.Size = new System.Drawing.Size(105, 73);
			this.Tied.TabIndex = 45;
			this.Tied.TabStop = false;
			this.Tied.Text = "Tied To";
			// 
			// Control
			// 
			this.Control.BackColor = System.Drawing.SystemColors.Control;
			this.Control.Cursor = System.Windows.Forms.Cursors.Default;
			this.Control.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Control.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Control.Location = new System.Drawing.Point(16, 48);
			this.Control.Name = "Control";
			this.Control.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Control.Size = new System.Drawing.Size(73, 17);
			this.Control.TabIndex = 23;
			this.Control.TabStop = true;
			this.Control.Text = "Control";
			// 
			// ImageCell
			// 
			this.ImageCell.BackColor = System.Drawing.SystemColors.Control;
			this.ImageCell.Cursor = System.Windows.Forms.Cursors.Default;
			this.ImageCell.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ImageCell.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ImageCell.Location = new System.Drawing.Point(16, 32);
			this.ImageCell.Name = "ImageCell";
			this.ImageCell.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ImageCell.Size = new System.Drawing.Size(80, 17);
			this.ImageCell.TabIndex = 22;
			this.ImageCell.TabStop = true;
			this.ImageCell.Text = "Image Cell";
			// 
			// ImageScale
			// 
			this.ImageScale.BackColor = System.Drawing.SystemColors.Control;
			this.ImageScale.Checked = true;
			this.ImageScale.Cursor = System.Windows.Forms.Cursors.Default;
			this.ImageScale.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ImageScale.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ImageScale.Location = new System.Drawing.Point(16, 16);
			this.ImageScale.Name = "ImageScale";
			this.ImageScale.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ImageScale.Size = new System.Drawing.Size(73, 17);
			this.ImageScale.TabIndex = 21;
			this.ImageScale.TabStop = true;
			this.ImageScale.Text = "Image";
			this.ImageScale.CheckedChanged += new System.EventHandler(this.ImageScale_CheckedChanged);
			// 
			// BackColour
			// 
			this.BackColour.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.BackColour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.BackColour.Cursor = System.Windows.Forms.Cursors.Default;
			this.BackColour.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BackColour.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BackColour.Location = new System.Drawing.Point(184, 152);
			this.BackColour.Name = "BackColour";
			this.BackColour.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.BackColour.Size = new System.Drawing.Size(25, 25);
			this.BackColour.TabIndex = 42;
			this.BackColour.TabStop = false;
			this.BackColour.Click += new System.EventHandler(this.BackColour_Click);
			// 
			// ForeColour
			// 
			this.ForeColour.BackColor = System.Drawing.Color.Red;
			this.ForeColour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ForeColour.Cursor = System.Windows.Forms.Cursors.Default;
			this.ForeColour.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ForeColour.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ForeColour.Location = new System.Drawing.Point(72, 152);
			this.ForeColour.Name = "ForeColour";
			this.ForeColour.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ForeColour.Size = new System.Drawing.Size(25, 25);
			this.ForeColour.TabIndex = 41;
			this.ForeColour.TabStop = false;
			this.ForeColour.Click += new System.EventHandler(this.ForeColour_Click);
			// 
			// AlignmentGroup
			// 
			this.AlignmentGroup.BackColor = System.Drawing.SystemColors.Control;
			this.AlignmentGroup.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.Alignment_Right,
																						 this.Alignment_Centre,
																						 this.Alignment_Left});
			this.AlignmentGroup.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AlignmentGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AlignmentGroup.Location = new System.Drawing.Point(232, 8);
			this.AlignmentGroup.Name = "AlignmentGroup";
			this.AlignmentGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.AlignmentGroup.Size = new System.Drawing.Size(105, 73);
			this.AlignmentGroup.TabIndex = 40;
			this.AlignmentGroup.TabStop = false;
			this.AlignmentGroup.Tag = "0";
			this.AlignmentGroup.Text = "Text Alignment";
			// 
			// Alignment_Right
			// 
			this.Alignment_Right.BackColor = System.Drawing.SystemColors.Control;
			this.Alignment_Right.Cursor = System.Windows.Forms.Cursors.Default;
			this.Alignment_Right.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Alignment_Right.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Alignment_Right.Location = new System.Drawing.Point(16, 48);
			this.Alignment_Right.Name = "Alignment_Right";
			this.Alignment_Right.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Alignment_Right.Size = new System.Drawing.Size(57, 17);
			this.Alignment_Right.TabIndex = 11;
			this.Alignment_Right.TabStop = true;
			this.Alignment_Right.Text = "Right";
			this.Alignment_Right.CheckedChanged += new System.EventHandler(this.Alignment_Right_CheckedChanged);
			// 
			// Alignment_Centre
			// 
			this.Alignment_Centre.BackColor = System.Drawing.SystemColors.Control;
			this.Alignment_Centre.Cursor = System.Windows.Forms.Cursors.Default;
			this.Alignment_Centre.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Alignment_Centre.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Alignment_Centre.Location = new System.Drawing.Point(16, 32);
			this.Alignment_Centre.Name = "Alignment_Centre";
			this.Alignment_Centre.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Alignment_Centre.Size = new System.Drawing.Size(57, 17);
			this.Alignment_Centre.TabIndex = 10;
			this.Alignment_Centre.TabStop = true;
			this.Alignment_Centre.Text = "Centre";
			this.Alignment_Centre.CheckedChanged += new System.EventHandler(this.Alignment_Centre_CheckedChanged);
			// 
			// Alignment_Left
			// 
			this.Alignment_Left.BackColor = System.Drawing.SystemColors.Control;
			this.Alignment_Left.Checked = true;
			this.Alignment_Left.Cursor = System.Windows.Forms.Cursors.Default;
			this.Alignment_Left.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Alignment_Left.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Alignment_Left.Location = new System.Drawing.Point(16, 16);
			this.Alignment_Left.Name = "Alignment_Left";
			this.Alignment_Left.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Alignment_Left.Size = new System.Drawing.Size(57, 17);
			this.Alignment_Left.TabIndex = 9;
			this.Alignment_Left.TabStop = true;
			this.Alignment_Left.Text = "Left";
			this.Alignment_Left.CheckedChanged += new System.EventHandler(this.Alignment_Left_CheckedChanged);
			// 
			// LabelTypeGroup
			// 
			this.LabelTypeGroup.BackColor = System.Drawing.SystemColors.Control;
			this.LabelTypeGroup.CausesValidation = false;
			this.LabelTypeGroup.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.LabelType_Arrow,
																						 this.LabelType_Polygon,
																						 this.LabelType_Ellipse,
																						 this.LabelType_Rectangle,
																						 this.LabelType_PolyLine,
																						 this.LabelType_Line,
																						 this.LabelType_Text});
			this.LabelTypeGroup.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LabelTypeGroup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LabelTypeGroup.Location = new System.Drawing.Point(8, 8);
			this.LabelTypeGroup.Name = "LabelTypeGroup";
			this.LabelTypeGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.LabelTypeGroup.Size = new System.Drawing.Size(209, 97);
			this.LabelTypeGroup.TabIndex = 39;
			this.LabelTypeGroup.TabStop = false;
			this.LabelTypeGroup.Tag = "0";
			this.LabelTypeGroup.Text = "Label Type";
			// 
			// LabelType_Arrow
			// 
			this.LabelType_Arrow.BackColor = System.Drawing.SystemColors.Control;
			this.LabelType_Arrow.Cursor = System.Windows.Forms.Cursors.Default;
			this.LabelType_Arrow.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LabelType_Arrow.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LabelType_Arrow.Location = new System.Drawing.Point(16, 64);
			this.LabelType_Arrow.Name = "LabelType_Arrow";
			this.LabelType_Arrow.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.LabelType_Arrow.Size = new System.Drawing.Size(73, 17);
			this.LabelType_Arrow.TabIndex = 25;
			this.LabelType_Arrow.TabStop = true;
			this.LabelType_Arrow.Tag = "10";
			this.LabelType_Arrow.Text = "Arrow";
			this.LabelType_Arrow.CheckedChanged += new System.EventHandler(this.LabelType_Arrow_CheckedChanged);
			// 
			// LabelType_Polygon
			// 
			this.LabelType_Polygon.BackColor = System.Drawing.SystemColors.Control;
			this.LabelType_Polygon.Cursor = System.Windows.Forms.Cursors.Default;
			this.LabelType_Polygon.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LabelType_Polygon.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LabelType_Polygon.Location = new System.Drawing.Point(120, 48);
			this.LabelType_Polygon.Name = "LabelType_Polygon";
			this.LabelType_Polygon.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.LabelType_Polygon.Size = new System.Drawing.Size(73, 17);
			this.LabelType_Polygon.TabIndex = 7;
			this.LabelType_Polygon.TabStop = true;
			this.LabelType_Polygon.Tag = "5";
			this.LabelType_Polygon.Text = "Polygon";
			this.LabelType_Polygon.CheckedChanged += new System.EventHandler(this.LabelType_Polygon_CheckedChanged);
			// 
			// LabelType_Ellipse
			// 
			this.LabelType_Ellipse.BackColor = System.Drawing.SystemColors.Control;
			this.LabelType_Ellipse.Cursor = System.Windows.Forms.Cursors.Default;
			this.LabelType_Ellipse.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LabelType_Ellipse.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LabelType_Ellipse.Location = new System.Drawing.Point(120, 32);
			this.LabelType_Ellipse.Name = "LabelType_Ellipse";
			this.LabelType_Ellipse.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.LabelType_Ellipse.Size = new System.Drawing.Size(73, 17);
			this.LabelType_Ellipse.TabIndex = 6;
			this.LabelType_Ellipse.TabStop = true;
			this.LabelType_Ellipse.Tag = "1";
			this.LabelType_Ellipse.Text = "Ellipse";
			this.LabelType_Ellipse.CheckedChanged += new System.EventHandler(this.LabelType_Ellipse_CheckedChanged);
			// 
			// LabelType_Rectangle
			// 
			this.LabelType_Rectangle.BackColor = System.Drawing.SystemColors.Control;
			this.LabelType_Rectangle.Cursor = System.Windows.Forms.Cursors.Default;
			this.LabelType_Rectangle.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LabelType_Rectangle.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LabelType_Rectangle.Location = new System.Drawing.Point(120, 16);
			this.LabelType_Rectangle.Name = "LabelType_Rectangle";
			this.LabelType_Rectangle.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.LabelType_Rectangle.Size = new System.Drawing.Size(73, 17);
			this.LabelType_Rectangle.TabIndex = 5;
			this.LabelType_Rectangle.TabStop = true;
			this.LabelType_Rectangle.Tag = "2";
			this.LabelType_Rectangle.Text = "Rectangle";
			this.LabelType_Rectangle.CheckedChanged += new System.EventHandler(this.LabelType_Rectangle_CheckedChanged);
			// 
			// LabelType_PolyLine
			// 
			this.LabelType_PolyLine.BackColor = System.Drawing.SystemColors.Control;
			this.LabelType_PolyLine.Cursor = System.Windows.Forms.Cursors.Default;
			this.LabelType_PolyLine.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LabelType_PolyLine.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LabelType_PolyLine.Location = new System.Drawing.Point(16, 48);
			this.LabelType_PolyLine.Name = "LabelType_PolyLine";
			this.LabelType_PolyLine.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.LabelType_PolyLine.Size = new System.Drawing.Size(73, 17);
			this.LabelType_PolyLine.TabIndex = 4;
			this.LabelType_PolyLine.TabStop = true;
			this.LabelType_PolyLine.Tag = "4";
			this.LabelType_PolyLine.Text = "PolyLine";
			this.LabelType_PolyLine.CheckedChanged += new System.EventHandler(this.LabelType_PolyLine_CheckedChanged);
			// 
			// LabelType_Line
			// 
			this.LabelType_Line.BackColor = System.Drawing.SystemColors.Control;
			this.LabelType_Line.Cursor = System.Windows.Forms.Cursors.Default;
			this.LabelType_Line.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LabelType_Line.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LabelType_Line.Location = new System.Drawing.Point(16, 32);
			this.LabelType_Line.Name = "LabelType_Line";
			this.LabelType_Line.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.LabelType_Line.Size = new System.Drawing.Size(73, 17);
			this.LabelType_Line.TabIndex = 3;
			this.LabelType_Line.TabStop = true;
			this.LabelType_Line.Tag = "3";
			this.LabelType_Line.Text = "Line";
			this.LabelType_Line.CheckedChanged += new System.EventHandler(this.LabelType_Line_CheckedChanged);
			// 
			// LabelType_Text
			// 
			this.LabelType_Text.BackColor = System.Drawing.SystemColors.Control;
			this.LabelType_Text.Checked = true;
			this.LabelType_Text.Cursor = System.Windows.Forms.Cursors.Default;
			this.LabelType_Text.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LabelType_Text.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LabelType_Text.Location = new System.Drawing.Point(16, 16);
			this.LabelType_Text.Name = "LabelType_Text";
			this.LabelType_Text.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.LabelType_Text.Size = new System.Drawing.Size(73, 17);
			this.LabelType_Text.TabIndex = 2;
			this.LabelType_Text.TabStop = true;
			this.LabelType_Text.Tag = "0";
			this.LabelType_Text.Text = "Text";
			this.LabelType_Text.CheckedChanged += new System.EventHandler(this.LabelType_Text_CheckedChanged);
			// 
			// Transparent
			// 
			this.Transparent.BackColor = System.Drawing.SystemColors.Control;
			this.Transparent.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.Transparent.Checked = true;
			this.Transparent.CheckState = System.Windows.Forms.CheckState.Checked;
			this.Transparent.Cursor = System.Windows.Forms.Cursors.Default;
			this.Transparent.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Transparent.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Transparent.Location = new System.Drawing.Point(8, 128);
			this.Transparent.Name = "Transparent";
			this.Transparent.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Transparent.Size = new System.Drawing.Size(89, 17);
			this.Transparent.TabIndex = 38;
			this.Transparent.Text = "Transparent";
			// 
			// Label4
			// 
			this.Label4.BackColor = System.Drawing.SystemColors.Control;
			this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label4.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label4.Location = new System.Drawing.Point(8, 184);
			this.Label4.Name = "Label4";
			this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label4.Size = new System.Drawing.Size(201, 17);
			this.Label4.TabIndex = 50;
			this.Label4.Text = "Click in the box below to change the font";
			// 
			// Label3
			// 
			this.Label3.BackColor = System.Drawing.SystemColors.Control;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label3.Location = new System.Drawing.Point(112, 128);
			this.Label3.Name = "Label3";
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.Size = new System.Drawing.Size(65, 17);
			this.Label3.TabIndex = 47;
			this.Label3.Text = "Line Width";
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// Label2
			// 
			this.Label2.BackColor = System.Drawing.SystemColors.Control;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label2.Location = new System.Drawing.Point(112, 160);
			this.Label2.Name = "Label2";
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.Size = new System.Drawing.Size(65, 17);
			this.Label2.TabIndex = 44;
			this.Label2.Text = "BackColour";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// Label1
			// 
			this.Label1.BackColor = System.Drawing.SystemColors.Control;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Location = new System.Drawing.Point(8, 160);
			this.Label1.Name = "Label1";
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.Size = new System.Drawing.Size(64, 17);
			this.Label1.TabIndex = 43;
			this.Label1.Text = "ForeColour";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// ColorDialog
			// 
			this.ColorDialog.AnyColor = true;
			this.ColorDialog.FullOpen = true;
			// 
			// LabelFormType
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(344, 253);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.FontDisplay,
																		  this.OK,
																		  this.LineWidth,
																		  this.Tied,
																		  this.BackColour,
																		  this.ForeColour,
																		  this.AlignmentGroup,
																		  this.LabelTypeGroup,
																		  this.Transparent,
																		  this.Label4,
																		  this.Label3,
																		  this.Label2,
																		  this.Label1});
			this.Name = "LabelFormType";
			this.Text = "Label Details";
			this.Load += new System.EventHandler(this.LabelformType_Load);
			this.Tied.ResumeLayout(false);
			this.AlignmentGroup.ResumeLayout(false);
			this.LabelTypeGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void ForeColour_Click(object sender, System.EventArgs e)
		{
			ColorDialog.Color = ForeColour.BackColor;
			if( ColorDialog.ShowDialog() == DialogResult.OK )
			{
				ForeColour.BackColor = ColorDialog.Color;
			}		
		}

		private void OK_Click(object sender, System.EventArgs e)
		{
			Hide();		
		}

		private void LabelformType_Load(object sender, System.EventArgs e)
		{
			LabelType = DicomObjects.doLabelType.doLabelText;		
		}

		private void LabelType_Text_CheckedChanged(object sender, System.EventArgs e)
		{
			if( LabelType_Text.Checked ) LabelType = DicomObjects.doLabelType.doLabelText;		
		}

		private void LabelType_Line_CheckedChanged(object sender, System.EventArgs e)
		{
			if( LabelType_Line.Checked ) LabelType = DicomObjects.doLabelType.doLabelLine;		
		}

		private void LabelType_PolyLine_CheckedChanged(object sender, System.EventArgs e)
		{
			if( LabelType_PolyLine.Checked ) LabelType = DicomObjects.doLabelType.doLabelPolyLine;		
		}

		private void LabelType_Arrow_CheckedChanged(object sender, System.EventArgs e)
		{
			if( LabelType_Arrow.Checked ) LabelType = DicomObjects.doLabelType.doLabelArrow;		
		}

		private void LabelType_Rectangle_CheckedChanged(object sender, System.EventArgs e)
		{
			if( LabelType_Rectangle.Checked ) LabelType = DicomObjects.doLabelType.doLabelRectangle;		
		}

		private void LabelType_Ellipse_CheckedChanged(object sender, System.EventArgs e)
		{
			if( LabelType_Ellipse.Checked ) LabelType = DicomObjects.doLabelType.doLabelEllipse;		
		}

		private void LabelType_Polygon_CheckedChanged(object sender, System.EventArgs e)
		{
			if( LabelType_Polygon.Checked ) LabelType = DicomObjects.doLabelType.doLabelPolygon;		
		}

		private void BackColour_Click(object sender, System.EventArgs e)
		{
			ColorDialog.Color = BackColour.BackColor;
			if( ColorDialog.ShowDialog() == DialogResult.OK )
			{
				BackColour.BackColor = ColorDialog.Color;
			}		
		}

		private void FontDisplay_DoubleClick(object sender, System.EventArgs e)
		{
			FontDialog.Font = FontDisplay.Font;
			if( FontDialog.ShowDialog() == DialogResult.OK )
			{
				FontDisplay.Font = FontDialog.Font;
			}		
		}

		private void Alignment_Left_CheckedChanged(object sender, System.EventArgs e)
		{
			if( Alignment_Left.Checked ) Alignment = DicomObjects.doLabelAlignment.doAlignLeft;		
		}

		private void Alignment_Centre_CheckedChanged(object sender, System.EventArgs e)
		{
			if (Alignment_Centre.Checked) Alignment = DicomObjects.doLabelAlignment.doAlignCentre;
		}

		private void Alignment_Right_CheckedChanged(object sender, System.EventArgs e)
		{
			if (Alignment_Right.Checked) Alignment = DicomObjects.doLabelAlignment.doAlignRight;
		}

		private void ImageScale_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void FontDisplay_TextChanged(object sender, System.EventArgs e)
		{
		
		}

	}

}
