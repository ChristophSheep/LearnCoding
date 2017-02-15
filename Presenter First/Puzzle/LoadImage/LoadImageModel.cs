using System.Drawing;

namespace wsm.Puzzle
{
  public class LoadImageModel : EventSender, ILoadImageModel
  {
    private string m_imageName;
    public event EventDelegate ImageListChangedEvent;
    public event EventDelegate StartEvent;
    public event EventDelegate FinishEvent;

    public void SubscribeImageListChanged(EventDelegate listener)
    {
      ImageListChangedEvent += listener;
    }

    public void SubscribeStart(EventDelegate listener)
    {
      StartEvent += listener;
    }

    public void SubscribeFinish(EventDelegate listener)
    {
      FinishEvent += listener;
    }

    public Image LoadImage()
    {
      FireEvent(ImageListChangedEvent);
      FireEvent(StartEvent);

      if (m_imageName.Equals("Carl"))
      {
        return Image.FromFile("../../Images/ce.bmp");
      }
      else if (m_imageName.Equals("USS Enterprise"))
      {
        return Image.FromFile("../../Images/USS Enterprise.jpg");
      }
      return Image.FromFile("../../Images/Numbered.jpg");
    }

    public void SetImageName(string name)
    {
      m_imageName = name;
      FireEvent(FinishEvent);
    }

    public string[] GetImageNames()
    {
      return new string[] {"Carl", "USS Enterprise", "Geeks"};
    }
  }
}