using System.Drawing;

namespace wsm.Puzzle
{
  public interface ILoadImageModel
  {
    void SubscribeImageListChanged(EventDelegate listener);
    void SubscribeStart(EventDelegate listener);
    void SubscribeFinish(EventDelegate listener);

    Image LoadImage();
    void SetImageName(string name);
    string[] GetImageNames();
  }
}
