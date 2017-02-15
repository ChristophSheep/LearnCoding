using System.Drawing;

namespace wsm.Puzzle.Tests
{
  using NUnit.Framework;

  [TestFixture]
  public class TestLoadImageModel : TestHelper
  {
    private LoadImageModel model;
    private Fred listChangedFred;
    private Fred startFred;
    private Fred finishFred;

    [SetUp]
    public void SetUp()
    {
      model = new LoadImageModel();

      listChangedFred = new Fred();
      model.SubscribeImageListChanged(new EventDelegate(listChangedFred.Update));
      AssertFredUpdates(listChangedFred, 0);

      startFred = new Fred();
      model.SubscribeStart(new EventDelegate(startFred.Update));
      AssertFredUpdates(startFred, 0);

      finishFred = new Fred();
      model.SubscribeFinish(new EventDelegate(finishFred.Update));
      AssertFredUpdates(finishFred, 0);

    }

    [TearDown]
    public void TearDown()
    {
      AssertFredUpdates(finishFred, 0);
      AssertFredUpdates(listChangedFred, 0);
      AssertFredUpdates(startFred, 0);
    }

    //
    // Helpers
    //

    //
    // Tests
    //
    [Test]
    public void test_SetImageName_AndLoadImage()
    {
      model.SetImageName("USS Enterprise");
      AssertFredUpdates(finishFred, 1);
   
      Image expected = Image.FromFile("../../Images/USS Enterprise.jpg");

      Image got = model.LoadImage();
      AssertFredUpdates(startFred, 1);
      AssertFredUpdates(listChangedFred, 1);

      Assert.AreEqual(expected.Size, got.Size);
    }

    [Test]
    public void test_GetImageNames()
    {
      string[] expected = new string[] {"Carl", "USS Enterprise", "Geeks"};
      string[] got = model.GetImageNames();
      Assert.AreEqual(expected, got);
    }
  }
}
