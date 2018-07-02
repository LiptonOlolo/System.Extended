# System.Extended

### LinqExtenstions
```C#
IEnumerable<Test> tests = LinqExtenstions.CreateMany<Test>(10); // => создаст коллекцию класса Test, создержащую 10 экземпляров класса Test (класс описан ниже).
IEnumerable<Test> testsWithCtor = LinqExtenstions.CreateMany<Test>(10, "Hello"); // => создаст коллекцию класса Test, создержащую 10 экземпляров класса Test, но при этом используя конструктор Test(string) (класс описан ниже).

tests.ForEach(x => Console.WriteLine(x.Git)); // => использование ForEach без .ToList()
```

Добавлен метод SelectMany для работы с массивами массивов, или IEnumerable<IEnumerable<T>>

### StringExtenstions
```C#
string git = "hub";

Console.WriteLine(git.IsEmpty()); // => False
Console.WriteLine(git.IsMatch(".")); // => True

Console.WriteLine(git.GetStringHash(MD5.Create())); // => 5261539CAB7DE0487B6B41415ACC7F61
```

### AttribyteExtenstions
Опишем тестовый класс:
```C#
[Description("Hello")]
class Test
{
    public Test(string git) { Git = git; }
    public Test() {}

    [Description("field description")]
    public string test;

    [Description("Git")]
    public string Git { get; set; }

    [Description("Hub")]
    public void Hub()
    {

    }
}

Test test = new Test();
var classDescription = test.GetAttribute<DescriptionAttribute>(null, GetAttributeType.Class);
var fieldDescription = test.GetAttribute<DescriptionAttribute>(nameof(Test.test), GetAttributeType.Field);
var propDescription = test.GetAttribute<DescriptionAttribute>(nameof(Test.Git), GetAttributeType.Property);
var methodDescription = test.GetAttribute<DescriptionAttribute>(nameof(Test.Hub), GetAttributeType.Method);

Console.WriteLine($"{classDescription.Description} {propDescription.Description}{methodDescription.Description}"); // => Hello GitHub
Console.WriteLine(fieldDescription.Description); // => field description
```
