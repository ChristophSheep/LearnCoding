using System.Drawing;

namespace org.Puzzle
{
	public interface IPuzzleModel 
	{
    void SubscribeUpdateImages(EventDelegate listener);

    void MoveRequest(Point point);
	  void Initialize();
	  void LoadImageRequest();

    Image[][] GetImages();
  }
}
