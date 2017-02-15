namespace wsm.Puzzle
{
	public class EventSender
	{
    protected void FireEvent(EventDelegate e)
    {
      EventDelegate copy = e;
      if (copy != null)
      {
        copy();
      }
    }
	}
}
