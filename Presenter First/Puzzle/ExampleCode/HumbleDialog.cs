using System;
using System.Windows.Forms;

namespace ExampleCode
{
	/// <summary>
	/// Summary description for HumbleDialog.
	/// </summary>
	public class HumbleDialog : Form, IHumbleView
	{
    private System.Windows.Forms.Button m_calculate;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox m_salary;
    private System.Windows.Forms.TextBox m_bracket;
    private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

	  private HumbleModel m_model;

	  public HumbleDialog()
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
      this.m_calculate = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.m_salary = new System.Windows.Forms.TextBox();
      this.m_bracket = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // m_calculate
      // 
      this.m_calculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.m_calculate.Location = new System.Drawing.Point(96, 136);
      this.m_calculate.Name = "m_calculate";
      this.m_calculate.Size = new System.Drawing.Size(112, 32);
      this.m_calculate.TabIndex = 0;
      this.m_calculate.Text = "Calculate";
      this.m_calculate.Click += new System.EventHandler(this.m_calculate_Click);
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label1.Location = new System.Drawing.Point(32, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(128, 23);
      this.label1.TabIndex = 1;
      this.label1.Text = "Base Salary";
      // 
      // m_salary
      // 
      this.m_salary.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.m_salary.Location = new System.Drawing.Point(176, 16);
      this.m_salary.Name = "m_salary";
      this.m_salary.Size = new System.Drawing.Size(128, 31);
      this.m_salary.TabIndex = 3;
      this.m_salary.Text = "textBox1";
      // 
      // m_bracket
      // 
      this.m_bracket.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.m_bracket.Location = new System.Drawing.Point(176, 80);
      this.m_bracket.Name = "m_bracket";
      this.m_bracket.Size = new System.Drawing.Size(128, 31);
      this.m_bracket.TabIndex = 4;
      this.m_bracket.Text = "textBox2";
      // 
      // label2
      // 
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label2.Location = new System.Drawing.Point(32, 88);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(128, 23);
      this.label2.TabIndex = 5;
      this.label2.Text = "Tax Bracket";
      // 
      // HumbleDialog
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(10, 24);
      this.ClientSize = new System.Drawing.Size(320, 198);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.m_bracket);
      this.Controls.Add(this.m_salary);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.m_calculate);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.Name = "HumbleDialog";
      this.Text = "HumbleDialog";
      this.ResumeLayout(false);

    }
		#endregion

	  public void SetModel(HumbleModel model)
	  {
	    m_model = model;
	  }

	  public void SetBaseSalary(int salary)
	  {
	    m_salary.Text = salary.ToString();
	  }

	  public void SetTaxBracket(string bracket)
	  {
      m_bracket.Text = bracket;
	  }

	  public int GetBaseSalary()
	  {
      return Int32.Parse(m_salary.Text);
	  }

	  public string GetTaxBracket()
	  {
      return m_bracket.Text;
	  }

    private void m_calculate_Click(object sender, System.EventArgs e)
    {
      m_model.Calculate();
    }
	}
}
