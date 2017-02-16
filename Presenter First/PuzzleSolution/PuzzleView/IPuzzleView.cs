using System.Drawing;

namespace org.Puzzle
{
	public interface IPuzzleView
	{
	  void SubscribeMoveRequest(PointDelegate listener);
    void SubscribeLoadImageRequest(EventDelegate listener);

	  void SetImages(Image[][] images);
	}
}
