public class Chapter3
{
  public class Person : IComparable<Person>, IComparable
  {
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }

    public int CompareTo(Person? other)
    {
      try
      {

      }
      catch (Exception e) when (System.Diagnostics.Debugger.IsAttached)
      {

      }
      return this.Name.CompareTo(other);
    }

    int IComparable.CompareTo(object? obj)
    {
      var p = obj as Person;
      if (p == null)
      {
        throw new ArgumentException();
      }
      return this.CompareTo(p);
    }

    public static bool operator <(Person? l, Person? r) => l?.CompareTo(r) < 0;
    public static bool operator >(Person? l, Person? r) => l?.CompareTo(r) > 0;
    public static bool operator <=(Person? l, Person? r) => l?.CompareTo(r) <= 0;
    public static bool operator >=(Person? l, Person? r) => l?.CompareTo(r) >= 0;

    public class AgeComparer : IComparer<Person>
    {
      public int Compare(Person? x, Person? y)
      {
        if (x == null && y == null)
        {
          return 0;
        }
        if (x == null)
        {
          return 1;
        }
        return x.Age.CompareTo(y?.Age);
      }
    }

    public static Comparison<Person> CompByAge = (x, y) => x.Age.CompareTo(y);

    private static Lazy<AgeComparer> LazyAgeComparer { get; }
      = new Lazy<AgeComparer>(() => new AgeComparer());
    public static IComparer<Person> AgeComp
    {
      get => LazyAgeComparer.Value;
    }
  }

  public void Sort()
  {
    var l = new List<Person> {
      new Person { Name = "Chica" },
      new Person { Name = "Alice" },
      new Person { Name = "Bob" },
    };

    l.Sort();
    l.Sort(Person.CompByAge);
    l.Sort(Person.AgeComp);
    l.Sort((x, y) => x.Age.CompareTo(y.Age));
    var orderBy = l.OrderBy(p => p, Person.AgeComp);
    Console.WriteLine($"Sort: {string.Join(",", l)}");
  }
}
