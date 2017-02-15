using System.Drawing;

namespace wsm.Puzzle
{
	public class PuzzlePresenter
	{
		private IPuzzleModel m_model;
		private IPuzzleView m_view;

		public PuzzlePresenter(IPuzzleModel model, IPuzzleView view)
		{
			m_model = model;
			m_view = view;

      m_model.SubscribeUpdateImages(new EventDelegate(PutImagesIntoView));

      m_view.SubscribeMoveRequest(new PointDelegate(MoveRequest));
      m_view.SubscribeLoadImageRequest(new EventDelegate(RequestLoadImage));
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
