namespace wsm.Puzzle
{
  public interface ILoadImageView
  {
    void SubscribeLoadCommand(EventDelegate listener);

    void Start();
    void Close();
    void SetImageList(string[] images);
    string GetSelectedImage();
  }
}
