namespace ExampleCode
{
	public class HumbleModel
	{
	  private readonly IHumbleView m_view;

	  public HumbleModel(IHumbleView view)
		{
		  m_view = view;
		}

    public void Initialize()
    {
      m_view.SetBaseSalary(35000);
      Calculate();
    }

    public void Calculate()
    {
      int salary = m_view.GetBaseSalary();
      if (salary < 10000)
      {
        m_view.SetTaxBracket("A bit");
      }
      else if (salary < 100000)
      {
        m_view.SetTaxBracket("A lot");
      }
      else
      {
        m_view.SetTaxBracket("None");
      }
    }
	}
}
