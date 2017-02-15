using System.Drawing;
using NMock;
using NMock.Constraints;
using NUnit.Framework;

namespace wsm.Puzzle.Tests
{
	[TestFixture]
	public class TestPuzzlePresenter : TestHelper
	{
		private DynamicMock modelMock;
		private IPuzzleModel model;
		private DynamicMock viewMock;
		private IPuzzleView view;
	  private SavedTypeOf moveRequestConstraint;
	  private SavedTypeOf updateImagesConstraint;
	  private SavedTypeOf loadImageRequestConstraint;

	  [SetUp]
		public void SetUp()
		{
			modelMock = new DynamicMock(typeof (IPuzzleModel));
			modelMock.Strict = true;
			model = modelMock.MockInstance as IPuzzleModel;

      updateImagesConstraint = new SavedTypeOf(typeof (EventDelegate));
	    modelMock.Expect("SubscribeUpdateImages", updateImagesConstraint);

	    // Setup the view
			viewMock = new DynamicMock(typeof (IPuzzleView));
			viewMock.Strict = true;
			view = viewMock.MockInstance as IPuzzleView;

      moveRequestConstraint = new SavedTypeOf(typeof (PointDelegate));
		  viewMock.Expect("SubscribeMoveRequest", moveRequestConstraint);

      loadImageRequestConstraint = new SavedTypeOf(typeof (EventDelegate));
	    viewMock.Expect("SubscribeLoadImageRequest", loadImageRequestConstraint);

	    // create the presenter
			new PuzzlePresenter(model, view);
		}

		[TearDown]
		public void TearDown()
		{
			modelMock.Verify();
			viewMock.Verify();
		}

		//
		// TESTS
		//
	  [Test]
	  public void test_MoveRequest_fromView()
	  {
	    Point point = new Point(1, 2);
	    modelMock.Expect("MoveRequest", point);
	    PointDelegate trigger = moveRequestConstraint.GetInstance as PointDelegate;
	    trigger(point);
	  }

	  [Test]
	  public void test_UpdateImages_fromModel()
	  {
      Bitmap[][] images = new Bitmap[0][];
	    modelMock.ExpectAndReturn("GetImages", images);
	    viewMock.Expect("SetImages", ILE(images));

	    EventDelegate trigger = updateImagesConstraint.GetInstance as EventDelegate;
	    trigger();
	  }

	  [Test]
	  public void test_LoadImageRequested_fromView()
	  {
	    modelMock.Expect("LoadImageRequest");

	    EventDelegate trigger = loadImageRequestConstraint.GetInstance as EventDelegate;
	    trigger();
	  }
	}
}
