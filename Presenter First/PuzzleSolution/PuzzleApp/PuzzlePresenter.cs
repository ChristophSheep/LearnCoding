using System.Drawing;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace

namespace org.Puzzle
{
    public class PuzzlePresenter
    {
        private IPuzzleModel m_model;

        private IPuzzleView m_view;

        public PuzzlePresenter(IPuzzleModel model, IPuzzleView view)
        {
            m_model = model;

            m_view = view;

            m_model.SubscribeUpdateImages(PutImagesIntoView);

            m_view.SubscribeMoveRequest(MoveRequest);

            m_view.SubscribeLoadImageRequest(RequestLoadImage);
        }

        private void RequestLoadImage()
        {
            m_model.LoadImageRequest();
        }

        private void PutImagesIntoView()
        {
            m_view.SetImages(m_model.GetImages());
        }

        private void MoveRequest(Point point)
        {
            m_model.MoveRequest(point);
        }
    }
}
