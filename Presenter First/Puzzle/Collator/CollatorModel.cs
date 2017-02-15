using System;

namespace Collator
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class CollatorModel : ICollatorModel
	{
	  private readonly IBucketDefinerModel m_bucketDefiner;

	  public CollatorModel(IBucketDefinerModel bucketDefiner)
		{
		  m_bucketDefiner = bucketDefiner;
		}

	  public void Collate()
	  {
	    IBucket[] buckets = m_bucketDefiner.GetBuckets();
      if (buckets == null)
      {
        throw new ApplicationException("Couldn't get buckets");
      }
	  }
	}
}
