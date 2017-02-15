namespace wsm.Puzzle
{
	public class Presenter
	{
	  private readonly IView m_view;
	  private readonly IModel m_model;

	  public Presenter(IModel model, IView view)
		{
		  m_view = view;
	    m_model = model;
		}
	}
}
