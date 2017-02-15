using System.Drawing;
using System.Windows.Forms;

namespace wsm.Puzzle
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class PuzzleForm : Form, IPuzzleView
	{
    private System.Windows.Forms.PictureBox m_piece7;
    private System.Windows.Forms.PictureBox m_piece5;
    private System.Windows.Forms.PictureBox m_piece6;
    private System.Windows.Forms.PictureBox m_piece9;
    private System.Windows.Forms.PictureBox m_piece3;
    private System.Windows.Forms.PictureBox m_piece8;
    private System.Windows.Forms.PictureBox m_piece2;
    private System.Windows.Forms.PictureBox m_piece1;
    private System.Windows.Forms.PictureBox m_piece4;
    private System.Windows.Forms.Button m_loadImageButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

    private event PointDelegate MoveRequestEvent;
    private event EventDelegate LoadImageRequestEvent;
    
		public PuzzleForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
      m_piece1.Tag = new Point(0,0);
      m_piece2.Tag = new Point(1,0);
      m_piece3.Tag = new Point(2,0);
      m_piece4.Tag = new Point(0,1);
      m_piece5.Tag = new Point(1,1);
      m_piece6.Tag = new Point(2,1);
      m_piece7.Tag = new Point(0,2);
      m_piece8.Tag = new Point(1,2);
      m_piece9.Tag = new Point(2,2);
    }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
      this.m_piece7 = new System.Windows.Forms.PictureBox();
      this.m_piece5 = new System.Windows.Forms.PictureBox();
      this.m_piece6 = new System.Windows.Forms.PictureBox();
      this.m_piece9 = new System.Windows.Forms.PictureBox();
      this.m_piece3 = new System.Windows.Forms.PictureBox();
      this.m_piece8 = new System.Windows.Forms.PictureBox();
      this.m_piece2 = new System.Windows.Forms.PictureBox();
      this.m_piece1 = new System.Windows.Forms.PictureBox();
      this.m_piece4 = new System.Windows.Forms.PictureBox();
      this.m_loadImageButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // m_piece7
      // 
      this.m_piece7.Location = new System.Drawing.Point(8, 248);
      this.m_piece7.Name = "m_piece7";
      this.m_piece7.Size = new System.Drawing.Size(100, 100);
      this.m_piece7.TabIndex = 0;
      this.m_piece7.TabStop = false;
      this.m_piece7.Click += new System.EventHandler(this.PieceClick);
      // 
      // m_piece5
      // 
      this.m_piece5.Location = new System.Drawing.Point(108, 148);
      this.m_piece5.Name = "m_piece5";
      this.m_piece5.Size = new System.Drawing.Size(100, 100);
      this.m_piece5.TabIndex = 1;
      this.m_piece5.TabStop = false;
      this.m_piece5.Click += new System.EventHandler(this.PieceClick);
      // 
      // m_piece6
      // 
      this.m_piece6.Location = new System.Drawing.Point(208, 148);
      this.m_piece6.Name = "m_piece6";
      this.m_piece6.Size = new System.Drawing.Size(100, 100);
      this.m_piece6.TabIndex = 2;
      this.m_piece6.TabStop = false;
      this.m_piece6.Click += new System.EventHandler(this.PieceClick);
      // 
      // m_piece9
      // 
      this.m_piece9.Location = new System.Drawing.Point(208, 248);
      this.m_piece9.Name = "m_piece9";
      this.m_piece9.Size = new System.Drawing.Size(100, 100);
      this.m_piece9.TabIndex = 3;
      this.m_piece9.TabStop = false;
      this.m_piece9.Tag = "";
      this.m_piece9.Click += new System.EventHandler(this.PieceClick);
      // 
      // m_piece3
      // 
      this.m_piece3.Location = new System.Drawing.Point(208, 48);
      this.m_piece3.Name = "m_piece3";
      this.m_piece3.Size = new System.Drawing.Size(100, 100);
      this.m_piece3.TabIndex = 4;
      this.m_piece3.TabStop = false;
      this.m_piece3.Click += new System.EventHandler(this.PieceClick);
      // 
      // m_piece8
      // 
      this.m_piece8.Location = new System.Drawing.Point(108, 248);
      this.m_piece8.Name = "m_piece8";
      this.m_piece8.Size = new System.Drawing.Size(100, 100);
      this.m_piece8.TabIndex = 5;
      this.m_piece8.TabStop = false;
      this.m_piece8.Click += new System.EventHandler(this.PieceClick);
      // 
      // m_piece2
      // 
      this.m_piece2.Location = new System.Drawing.Point(108, 48);
      this.m_piece2.Name = "m_piece2";
      this.m_piece2.Size = new System.Drawing.Size(100, 100);
      this.m_piece2.TabIndex = 6;
      this.m_piece2.TabStop = false;
      this.m_piece2.Click += new System.EventHandler(this.PieceClick);
      // 
      // m_piece1
      // 
      this.m_piece1.Location = new System.Drawing.Point(8, 48);
      this.m_piece1.Name = "m_piece1";
      this.m_piece1.Size = new System.Drawing.Size(100, 100);
      this.m_piece1.TabIndex = 7;
      this.m_piece1.TabStop = false;
      this.m_piece1.Click += new System.EventHandler(this.PieceClick);
      // 
      // m_piece4
      // 
      this.m_piece4.Location = new System.Drawing.Point(8, 148);
      this.m_piece4.Name = "m_piece4";
      this.m_piece4.Size = new System.Drawing.Size(100, 100);
      this.m_piece4.TabIndex = 8;
      this.m_piece4.TabStop = false;
      this.m_piece4.Click += new System.EventHandler(this.PieceClick);
      // 
      // m_loadImageButton
      // 
      this.m_loadImageButton.Location = new System.Drawing.Point(8, 8);
      this.m_loadImageButton.Name = "m_loadImageButton";
      this.m_loadImageButton.TabIndex = 9;
      this.m_loadImageButton.Text = "Load Image";
      this.m_loadImageButton.Click += new System.EventHandler(this.m_loadImageButton_Click);
      // 
      // PuzzleForm
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(312, 350);
      this.Controls.Add(this.m_loadImageButton);
      this.Controls.Add(this.m_piece4);
      this.Controls.Add(this.m_piece1);
      this.Controls.Add(this.m_piece2);
      this.Controls.Add(this.m_piece8);
      this.Controls.Add(this.m_piece3);
      this.Controls.Add(this.m_piece9);
      this.Controls.Add(this.m_piece6);
      this.Controls.Add(this.m_piece5);
      this.Controls.Add(this.m_piece7);
      this.Name = "PuzzleForm";
      this.Text = "PF Puzzle";
      this.ResumeLayout(false);

    }
		#endregion

	  public void SubscribeMoveRequest(PointDelegate listener)
	  {
	    MoveRequestEvent += listener;
	  }

	  public void SubscribeLoadImageRequest(EventDelegate listener)
	  {
	    LoadImageRequestEvent += listener;
	  }

	  public void SetImages(Image[][] images)
	  {
      m_piece1.Image = images[0][0];
      m_piece2.Image = images[1][0];
      m_piece3.Image = images[2][0];
      m_piece4.Image = images[0][1];
      m_piece5.Image = images[1][1];
      m_piece6.Image = images[2][1];
      m_piece7.Image = images[0][2];
      m_piece8.Image = images[1][2];
      m_piece9.Image = images[2][2];
	  }

	  private void PieceClick(object sender, System.EventArgs e)
    {
      PictureBox piece = sender as PictureBox;
      if (MoveRequestEvent != null && piece != null)
      {
        MoveRequestEvent((Point)piece.Tag);
      }
    }

    private void m_loadImageButton_Click(object sender, System.EventArgs e)
    {
      if (LoadImageRequestEvent != null)
      {
        LoadImageRequestEvent();
      }
    }
	}
}
