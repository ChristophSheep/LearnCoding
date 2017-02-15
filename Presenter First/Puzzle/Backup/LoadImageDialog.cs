namespace wsm.Puzzle
{
	/// <summary>
	/// Summary description for LoadImageDialog.
	/// </summary>
	public class LoadImageDialog : System.Windows.Forms.Form,  ILoadImageView
	{
    private System.Windows.Forms.ListBox m_imageList;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button m_loadImageButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

    private event EventDelegate LoadCommandEvent;

		public LoadImageDialog()
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
      this.m_imageList = new System.Windows.Forms.ListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.m_loadImageButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // m_imageList
      // 
      this.m_imageList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.m_imageList.ItemHeight = 25;
      this.m_imageList.Location = new System.Drawing.Point(8, 32);
      this.m_imageList.Name = "m_imageList";
      this.m_imageList.Size = new System.Drawing.Size(176, 104);
      this.m_imageList.TabIndex = 0;
      this.m_imageList.DoubleClick += new System.EventHandler(this.m_imageList_DoubleClick);
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label1.Location = new System.Drawing.Point(8, 8);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(184, 24);
      this.label1.TabIndex = 1;
      this.label1.Text = "Images Available";
      // 
      // m_loadImageButton
      // 
      this.m_loadImageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.m_loadImageButton.Location = new System.Drawing.Point(8, 144);
      this.m_loadImageButton.Name = "m_loadImageButton";
      this.m_loadImageButton.Size = new System.Drawing.Size(184, 23);
      this.m_loadImageButton.TabIndex = 2;
      this.m_loadImageButton.Text = "Load Image";
      this.m_loadImageButton.Click += new System.EventHandler(this.m_loadImageButton_Click);
      // 
      // LoadImageDialog
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(200, 174);
      this.ControlBox = false;
      this.Controls.Add(this.label1);
      this.Controls.Add(this.m_imageList);
      this.Controls.Add(this.m_loadImageButton);
      this.Name = "LoadImageDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Select Image";
      this.ResumeLayout(false);

    }
		#endregion

    private void m_loadImageButton_Click(object sender, System.EventArgs e)
    {
      FireLoadCommand();
    }

    private void m_imageList_DoubleClick(object sender, System.EventArgs e)
    {
      FireLoadCommand();
    }

    private void FireLoadCommand()
    {
      if (LoadCommandEvent != null)
      {
        LoadCommandEvent();
      }
    }

	  public void SubscribeLoadCommand(EventDelegate listener)
	  {
	    LoadCommandEvent += listener;
	  }

	  public void Start()
	  {
	    ShowDialog();
	  }

	  public void SetImageList(string[] images)
	  {
	    m_imageList.Items.Clear();
      m_imageList.Items.AddRange(images);
	  }

	  public string GetSelectedImage()
	  {
      return m_imageList.SelectedItem as string;
	  }
	}
}
