using System.Drawing;

namespace wsm.Puzzle
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
