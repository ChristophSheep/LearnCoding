using System;
using NMock;

namespace Collator
{
  using NUnit.Framework;

  [TestFixture]
  public class TestCollatorModel
  {
    private CollatorModel model;
    private IBucketDefinerModel bucketDefiner;
    private DynamicMock bucketDefinerMock;

    [SetUp]
    public void SetUp()
    {
      bucketDefinerMock = new DynamicMock(typeof (IBucketDefinerModel));
      bucketDefinerMock.Strict = true;
      bucketDefiner = bucketDefinerMock.MockInstance as IBucketDefinerModel;

      model = new CollatorModel(bucketDefiner);
    }

    [TearDown]
    public void TearDown()
    {
      bucketDefinerMock.Verify();
    }

    //
    // Helpers
    //

    //
    // Tests
    //
    [Test]
    public void test_Collate()
    {
      IBucket[] buckets = new IBucket[4];
      bucketDefinerMock.ExpectAndReturn("GetBuckets", buckets);

      model.Collate();
    }

    [Test]
    [ExpectedException(typeof (ApplicationException))]
    public void test_Collate_CouldntGetBuckets()
    {
      bucketDefinerMock.ExpectAndReturn("GetBuckets", null);

      model.Collate();
    }
  }
}
