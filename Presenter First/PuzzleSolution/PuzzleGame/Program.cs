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

            new LoadImagePresenter(loadImageModel, loadImageView);

            var view = new PuzzleForm();

            IPuzzleModel model = new PuzzleModel(loadImageModel, new ImageCutter());

            new PuzzlePresenter(model, view);

            model.Initialize();

            Application.Run(view);
        }
    }
}
