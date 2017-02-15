using System.Drawing;
using NMock;
using NMock.Constraints;
using NUnit.Framework;

namespace wsm.Puzzle.Tests
{
  [TestFixture]
  public class TestPuzzleModel : TestHelper
  {
    private PuzzleModel model;
    private Fred updateFred;
    private ILoadImageModel loader;
    private DynamicMock loaderMock;
    private IImageCutter cutter;
    private DynamicMock cutterMock;
    private Image[][] pieces;
    private Image piece0;
    private Image piece1;
    private Image piece2;
    private Image piece3;
    private Image piece4;
    private Image piece5;
    private Image piece6;
    private Image piece7;
    private Image piece8;

    [SetUp]
    public void SetUp()
    {
      loaderMock = new DynamicMock(typeof (ILoadImageModel));
      loaderMock.Strict = true;
      loader = loaderMock.MockInstance as ILoadImageModel;

      cutterMock = new DynamicMock(typeof (IImageCutter));
      cutterMock.Strict = true;
      cutter = cutterMock.MockInstance as IImageCutter;

      model = new PuzzleModel(loader, cutter);

      updateFred = new Fred();
      model.SubscribeUpdateImages(new EventDelegate(updateFred.Update));
      AssertFredUpdates(updateFred, 0);

      piece0 = new Bitmap(1,1);
      piece1 = new Bitmap(1,1);
      piece2 = new Bitmap(1,1);
      piece3 = new Bitmap(1,1);
      piece4 = new Bitmap(1,1);
      piece5 = new Bitmap(1,1);
      piece6 = new Bitmap(1,1);
      piece7 = new Bitmap(1,1);
      piece8 = new Bitmap(1,1);
      
      pieces = new Image[][]
        {
          new Image[] {piece0, piece1, piece2},
          new Image[] {piece3, piece4, piece5},
          new Image[] {piece6, piece7, piece8}
      };
    }

    [TearDown]
    public void TearDown()
    {
      AssertFredUpdates(updateFred, 0);
      loaderMock.Verify();
      cutterMock.Verify();
    }

    //
    // TESTS
    //
    [Test]
    public void test_Initialize()
    {
      cutterMock.ExpectAndReturn("CutImage", pieces, new IsTypeOf(typeof(Image)));
      model.Initialize();
      AssertFredUpdates(updateFred, 1);

      Image[][] got = model.GetImages();
      Assert.AreEqual(piece0, got[0][0]);
      Assert.AreEqual(piece4, got[1][0]);
      Assert.AreEqual(piece6, got[2][0]);
      Assert.AreEqual(piece3, got[0][1]);
      Assert.AreEqual(piece7, got[1][1]);
      Assert.AreEqual(piece8, got[2][1]);
      Assert.AreEqual(piece1, got[0][2]);
      Assert.AreEqual(piece2, got[1][2]);
      Assert.AreEqual(piece5, got[2][2]);
    }

    [Test]
    public void test_MoveRequest()
    {
      test_Initialize();

      Point point = new Point(0, 1);
      Image[][] images = model.GetImages();
      Image source = images[0][1];
      Image destination = images[0][0];

      model.MoveRequest(point);
      AssertFredUpdates(updateFred, 1);

      Assert.AreSame(source, images[0][0]);
      Assert.AreSame(destination, images[0][1]);
    }

    [Test]
    public void test_MoveRequest_TwoMoves()
    {
      test_MoveRequest();

      Point point = new Point(0, 0);
      Image[][] images = model.GetImages();
      Image source = images[0][0];
      Image destination = images[0][1];

      model.MoveRequest(point);
      AssertFredUpdates(updateFred, 1);

      Assert.AreSame(source, images[0][1]);
      Assert.AreSame(destination, images[0][0]);
    }

    [Test]
    public void test_MoveRequest_badMoveRefused()
    {
      test_Initialize();

      Point point = new Point(0, 0);
      Image[][] images = model.GetImages();
      Image source = images[0][1];
      Image destination = images[1][1];

      model.MoveRequest(point);
      AssertFredUpdates(updateFred, 0);

      Assert.AreSame(destination, images[1][1]);
      Assert.AreSame(source, images[0][1]);
    }

    [Test]
    public void test_GetImages()
    {
      // Tested elsewhere
      test_Initialize();
    }

    [Test]
    public void test_LoadImageRequest()
    {
      Image wholeImage = new Bitmap(1,1);
      Image piece1 = new Bitmap(1,1);
      Image piece2 = new Bitmap(1,1);
      Image piece3 = new Bitmap(1,1);
      Image piece4 = new Bitmap(1,1);
      Image piece5 = new Bitmap(1,1);
      Image piece6 = new Bitmap(1,1);
      Image piece7 = new Bitmap(1,1);
      Image piece8 = new Bitmap(1,1);
      Image piece9 = new Bitmap(1,1);

      Image[][] expectedPieces = new Image[][]
        {
          new Image[] {piece1, piece2, piece3},
          new Image[] {piece4, piece5, piece6},
          new Image[] {piece7, piece8, piece9}
        };

      loaderMock.ExpectAndReturn("LoadImage", wholeImage);
      cutterMock.ExpectAndReturn("CutImage", expectedPieces, wholeImage);

      model.LoadImageRequest();
      AssertFredUpdates(updateFred, 1);

      Image[][] gotPieces = model.GetImages();
      Assert.AreEqual(expectedPieces, gotPieces);
    }
  }
}