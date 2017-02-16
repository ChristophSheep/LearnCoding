using System;
using System.Windows.Forms;

namespace org.Puzzle
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            ILoadImageModel loadImageModel = new LoadImageModel();
            ILoadImageView loadImageView = new LoadImageDialog();

            var loadImagePresenter = new LoadImagePresenter(loadImageModel, loadImageView);

            IImageCutter imageCutter = new ImageCutter();

            var view = new PuzzleForm();

            IPuzzleModel model = new PuzzleModel(loadImageModel, imageCutter);
            var puzzlePresenter = new PuzzlePresenter(model, view);

            model.Initialize();

            Application.Run(view);
        }
    }
}
