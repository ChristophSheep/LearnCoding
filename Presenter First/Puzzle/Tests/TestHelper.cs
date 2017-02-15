using System;
using NMock.Constraints;
using NUnit.Framework;

namespace wsm.Puzzle.Tests
{
  public class Fred
  {
    public int updates;

    public void Update()
    {
      ++updates;
    }
  }

  public class StringFred : Fred
  {
    public string lastString;

    public void StringCatcher(string data)
    {
      ++updates;
      lastString = data;
    }
  }

  public abstract class TestHelper
  {
    protected void AssertFredUpdates(Fred fred, int count)
    {
      Assert.AreEqual(count, fred.updates);
      fred.updates = 0;
    }

    protected string[] SArray(params string[] s)
    {
      return s;
    }

    protected IsListEqual SAA(string[][] o)
    {
      return new IsListEqual(o);
    }

    protected IsListEqual ILE(object[] s)
    {
      return new IsListEqual(s);
    }

    public void AssertArraysEqual(Array c1, Array c2)
    {
      Assert.AreEqual(c1.Length, c2.Length);
      for (int i = 0; i < c1.Length; i++)
      {
        Assert.AreEqual(c1.GetValue(i), c2.GetValue(i));
      }
    }
  }
}