using System.Drawing;

namespace wsm.Puzzle
{
	public interface IPuzzleView
	{
	  void SubscribeMoveRequest(PointDelegate listener);
    void SubscribeLoadImageRequest(EventDelegate listener);

	  void SetImages(Image[][] images);
	}
}
