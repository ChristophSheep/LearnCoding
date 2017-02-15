using System.Drawing;

namespace wsm.Puzzle
{
	public class ImageCutter : IImageCutter
	{
	  public Image[][] CutImage(Image image)
	  {
      Rectangle destRect = new Rectangle(0, 0, 100, 100);
      Image[][] pieces = new Image[3][];
      pieces[0] = new Image[3];
      pieces[1] = new Image[3];
      pieces[2] = new Image[3];

      int sourceWidth = image.Width / 3;
      int sourceHeight = image.Height / 3;

      for (int x = 0; x < 3; x++)
	    {
        for (int y = 0; y < 3; y++)
	      {
          Image piece = new Bitmap(100,100);
          Graphics graphics = Graphics.FromImage(piece);
          graphics.DrawImage(image, destRect, x*sourceWidth, y*sourceHeight, sourceWidth, sourceHeight, GraphicsUnit.Pixel);
          pieces[x][y] = piece;
	      }
	    }
      pieces[0][0] = Image.FromFile("../../Images/blank.bmp");
      return pieces;
	  }
	}
}
