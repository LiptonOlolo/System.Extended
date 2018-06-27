# System.Extended

### LinqExtended
Объявим тестовый класс, содержащий 2 числа:
```C#
class Test
{
    public Test(int a, int b)
    {
        A = a;
        B = b;
    }

    public int A { get; set; }

    public int B { get; set; }
}
```

Объявим массив массивов:
```C#
Test[][] tests = new Test[][]
{
    new Test[] {
        new Test(2, 2),
        new Test(2, 3)
    },
    new Test[] {
        new Test(3, 3),
        new Test(3, 4)
    }
};
```

Чтобы получить сумму всех A + B в стандартном Linq прийдется написать:
```C#
tests.Sum(x => x.Sum(u => u.A + u.B));
```
А с LinqExtended:
```C#
tests.SelectMany(x => x.A + x.B).Sum();
```

Или, например, необходимо получить 1 последовательность из всего массива:
System.Linq:
```C#
tests.SelectMany(x => x.Select(u => u));
```

LinqExtended:
```C#
tests.SelectMany();
```

Получим значения всех полей А:
System.Linq:
```C#
tests.SelectMany(x => x.Select(u => u.A));
```

LinqExtended:
```C#
tests.SelectMany(x => x.A);
```

### StringExtended
Объявим текстовую переменную:
```C#
string git = "hub";
```

Проверим, является ли строка пустой, подходит ли под регулярное выражение:
```C#
Console.WriteLine(git.IsEmpty()); // => False
Console.WriteLine(git.IsMatch(".")); // => True
```

Получим хэш строки в текстовом виде, алгоритм: MD5:
```C#
Console.WriteLine(git.GetStringHash(MD5.Create())); // => 5261539CAB7DE0487B6B41415ACC7F61
```

### AttribyteExtended
Опишем тестовый класс:
```C#
[Description("Hello")]
class Test
{
    [Description("field description")]
    public string test;

    [Description("Git")]
    public string Git { get; set; }

    [Description("Hub")]
    public void Hub()
    {

    }
}
```

Создадим экземпляр класса и получим все атрибуты класса:
```C#
Test test = new Test();
var classDescription = test.GetAttribute<DescriptionAttribute>(null, GetAttributeType.Class);
var fieldDescription = test.GetAttribute<DescriptionAttribute>(nameof(Test.test), GetAttributeType.Field);
var propDescription = test.GetAttribute<DescriptionAttribute>(nameof(Test.Git), GetAttributeType.Property);
var methodDescription = test.GetAttribute<DescriptionAttribute>(nameof(Test.Hub), GetAttributeType.Method);

Console.WriteLine($"{classDescription.Description} {propDescription.Description}{methodDescription.Description}");
Console.WriteLine(fieldDescription.Description);
```

Вывод в консоль: 
Hello GitHub
field description
