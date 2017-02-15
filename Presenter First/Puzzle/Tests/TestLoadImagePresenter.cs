using NMock;
using NMock.Constraints;

namespace wsm.Puzzle.Tests
{
  using NUnit.Framework;

  [TestFixture]
  public class TestLoadImagePresenter
  {
    private ILoadImageModel model;
    private DynamicMock modelMock;
    private ILoadImageView view;
    private DynamicMock viewMock;
    private SavedTypeOf loadCommandConstraint;
    private SavedTypeOf imageListChangedConstraint;
    private SavedTypeOf startConstraint;
    private SavedTypeOf finishConstraint;

    [SetUp]
    public void SetUp()
    {
      modelMock = new DynamicMock(typeof (ILoadImageModel));
      modelMock.Strict = true;
      model = modelMock.MockInstance as ILoadImageModel;

      imageListChangedConstraint = new SavedTypeOf(typeof (EventDelegate));
      modelMock.Expect("SubscribeImageListChanged", imageListChangedConstraint);

      startConstraint = new SavedTypeOf(typeof (EventDelegate));
      modelMock.Expect("SubscribeStart", startConstraint);

      finishConstraint = new SavedTypeOf(typeof (EventDelegate));
      modelMock.Expect("SubscribeFinish", finishConstraint);

      viewMock = new DynamicMock(typeof (ILoadImageView));
      viewMock.Strict = true;
      view = viewMock.MockInstance as ILoadImageView;

      loadCommandConstraint = new SavedTypeOf(typeof (EventDelegate));
      viewMock.Expect("SubscribeLoadCommand", loadCommandConstraint);

      new LoadImagePresenter(model, view);
    }

    [TearDown]
    public void TearDown()
    {
      modelMock.Verify();
      viewMock.Verify();
    }

    //
    // Helpers
    //

    //
    // Tests
    //
    [Test]
    public void test_LoadImageCommand_fromView()
    {
      viewMock.ExpectAndReturn("GetSelectedImage", "image", 1, 1);
      modelMock.Expect("SetImageName", "image", 1, 1);

      EventDelegate trigger = loadCommandConstraint.GetInstance as EventDelegate;
      trigger();
    }

    [Test]
    public void test_ListOfImagesChanged_inModel()
    {
      string[] images = new string[] {"one", "two", "three"};

      modelMock.ExpectAndReturn("GetImageNames", images);
      viewMock.Expect("SetImageList", new IsListEqual(images));

      EventDelegate trigger = imageListChangedConstraint.GetInstance as EventDelegate;
      trigger();
    }

    [Test]
    public void test_Start_fromModel()
    {
      viewMock.Expect("Start");

      EventDelegate trigger = startConstraint.GetInstance as EventDelegate;
      trigger();
    }

    [Test]
    public void test_Finish()
    {
      viewMock.Expect("Close");

      EventDelegate trigger = finishConstraint.GetInstance as EventDelegate;
      trigger();
    }
  }
}
