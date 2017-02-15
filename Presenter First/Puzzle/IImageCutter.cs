using System.Drawing;

namespace wsm.Puzzle
{
  public interface IImageCutter
  {
    Image[][] CutImage(Image image);
  }
}
