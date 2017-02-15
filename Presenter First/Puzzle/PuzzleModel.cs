using System;
using System.Drawing;

namespace wsm.Puzzle
{
  public class PuzzleModel : EventSender, IPuzzleModel
  {
    private readonly IImageCutter m_imageCutter;
    private readonly ILoadImageModel m_imageLoader;
    private Image[][] m_images;
    private Point m_blankLocation;
    private event EventDelegate UpdateImagesEvent;

    public PuzzleModel(ILoadImageModel imageLoader, IImageCutter imageCutter)
    {
      m_imageCutter = imageCutter;
      m_imageLoader = imageLoader;
    }

    public void SubscribeUpdateImages(EventDelegate listener)
    {
      UpdateImagesEvent += listener;
    }

    public void MoveRequest(Point point)
    {
      int distance = Math.Abs(point.X - m_blankLocation.X) + Math.Abs(point.Y - m_blankLocation.Y);
      if (distance == 1)
      {
        DoMove(point);
        FireEvent(UpdateImagesEvent);
      }
    }

    public Image[][] GetImages()
    {
      return m_images;
    }

    public void Initialize()
    {
      SetImages(m_imageCutter.CutImage(Image.FromFile("../../Images/ce.bmp")));
    }

    public void LoadImageRequest()
    {
      Image image = m_imageLoader.LoadImage();
      Image[][] pieces = m_imageCutter.CutImage(image);
      SetImages(pieces);
    }

    private void SetImages(Image[][] images)
    {
      m_blankLocation = new Point(0,0);
      m_images = images;
      DoMove(new Point(1, 0));
      DoMove(new Point(1, 1));
      DoMove(new Point(2, 1));
      DoMove(new Point(2, 2));
      DoMove(new Point(1, 2));
      DoMove(new Point(0, 2));
      DoMove(new Point(0, 1));
      DoMove(new Point(0, 0));
      FireEvent(UpdateImagesEvent);
    }
 
    private void DoMove(Point point)
    {
      Image blank = m_images[m_blankLocation.X][m_blankLocation.Y];
      m_images[m_blankLocation.X][m_blankLocation.Y] = m_images[point.X][point.Y];
      m_images[point.X][point.Y] = blank;
      m_blankLocation = point;
    }
  }
}