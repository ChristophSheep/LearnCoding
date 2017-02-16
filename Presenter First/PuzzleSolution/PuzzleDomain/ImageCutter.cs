using System.Drawing;
// ReSharper disable CheckNamespace

namespace org.Puzzle
{
    public class ImageCutter : IImageCutter
    {
        public Image[][] CutImage(Image image)
        {
            var destRect = new Rectangle(0, 0, 100, 100);
            var pieces = new Image[3][];

            pieces[0] = new Image[3];
            pieces[1] = new Image[3];
            pieces[2] = new Image[3];

            var sourceWidth = image.Width / 3;
            var sourceHeight = image.Height / 3;

            for (var x = 0; x < 3; x++)
            {
                for (var y = 0; y < 3; y++)
                {
                    Image piece = new Bitmap(100, 100);
                    var graphics = Graphics.FromImage(piece);
                    graphics.DrawImage(image, destRect, x*sourceWidth, y*sourceHeight, sourceWidth, sourceHeight,
                        GraphicsUnit.Pixel);

                    pieces[x][y] = piece;
                }
            }

            pieces[0][0] = Image.FromFile("../../Images/blank.bmp");

            return pieces;
        }
    }
}
