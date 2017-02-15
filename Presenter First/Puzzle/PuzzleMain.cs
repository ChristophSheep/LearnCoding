using System;
using System.Windows.Forms;

namespace wsm.Puzzle
{
	/// <summary>
	/// Summary description for PuzzleMain.
	/// </summary>
	public class PuzzleMain
	{
    [STAThread]
    static void Main() 
    {
      ILoadImageModel loadImageModel = new LoadImageModel();
      ILoadImageView loadImageView = new LoadImageDialog();
      new LoadImagePresenter(loadImageModel, loadImageView);

      IImageCutter imageCutter = new ImageCutter();

      PuzzleForm view = new PuzzleForm();
      IPuzzleModel model = new PuzzleModel(loadImageModel, imageCutter);
      new PuzzlePresenter(model, view);

      model.Initialize();

      Application.Run(view);
    }

  }
}
