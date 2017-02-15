using System;
using System.Windows.Forms;

namespace ExampleCode
{
	/// <summary>
	/// Summary description for HumbleMain.
	/// </summary>
	public class HumbleMain
	{
    [STAThread]
    static void Main() 
    {
      HumbleDialog view = new HumbleDialog();
      HumbleModel model = new HumbleModel(view);
      view.SetModel(model);

      model.Initialize();

      Application.Run(view);
    }

  }
}
