namespace ExampleCode
{
  public interface IHumbleView
  {
    void SetModel(HumbleModel model);

    void SetBaseSalary(int salary);
    void SetTaxBracket(string bracket);

    int GetBaseSalary();
    string GetTaxBracket();
  }
}
