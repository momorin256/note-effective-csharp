public class Chapter2
{
  public static void ObjectInitializer()
  {
    var d = new Derived();
  }

  public class C
  {
    public C(string s)
    {
      Console.WriteLine(s);
    }
  }

  public class Base
  {
    public Base()
    {
      Console.WriteLine("Base");
    }

    static Base()
    {
      Console.WriteLine("static Base");
    }

    private C _s2 = new C("s2");

    private C _c3 = new C("c3");
    private C _c4 = new C("c4");
  }

  public class Derived : Base
  {
    public Derived()
    {
      Console.WriteLine("Derived");
    }

    static Derived()
    {
      Console.WriteLine("static Derived");
    }

    private static C _s1 = new C("s1");

    private C _c1 = new C("c1");
    private C _c2 = new C("c2");
  }
}
