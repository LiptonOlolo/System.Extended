# System.Extended

```C#
[Description("Test class")]
class Test
{
    public Test()
    {
    }

    [Description("A property")]
    public int A { get; set; }

    [Description("B property")]
    public int B { get; set; }

    [Description("Foo method")]
    public void Foo()
    {

    }

    [Description("a field")]
    public int a;
}

Test test = new Test();
test.GetAttribute<DescriptionAttribute>(null, GetAttributeType.Class).Description;
test.GetAttribute<DescriptionAttribute>(nameof(Test.A), GetAttributeType.Property).Description;
test.GetAttribute<DescriptionAttribute>(nameof(Test.B), GetAttributeType.Property).Description;
test.GetAttribute<DescriptionAttribute>(nameof(Test.Foo), GetAttributeType.Method).Description;
test.GetAttribute<DescriptionAttribute>(nameof(Test.a), GetAttributeType.Field).Description;

Guid.NewGuid().ToByteArray().GetHash(MD5.Create()).Join(" ");

"".IsEmpty() ? "Строка пустая" : "Строка не пустая";
"Hello, world!".IsMatch(".") ? "Строка соответствует паттерну" : "Строка не соответствует паттерну";
$"md5(\"Hello, World!\") = {"\"Hello, World\"".GetStringHash(MD5.Create())}");
"md5(\"Hello, World!\") = " + string.Join(" ", "\"Hello, World\"".GetHash(MD5.Create()));

Enumerable.Range(0, 5).Append(666).ForEach(Console.WriteLine); //Добавить объект в последовательность
IEnumerable<int> oneInt = LinqExtenstion.Create(10); //Создаем последовательность из 1 объекта

oneInt.IsEmpty(); //Проверка на наличие элементов.
List<int> list = null;
list.IsNullOrEmpty(); //Проверка на null или наличие элементов.
Enumerable.Range(0, 10).Shuffle().Join(",")); //Сортировка в случайном порядке, объединение всей последовательности в одну.
Enumerable.Range(0, 10).Chunk(2).ForEach(x => Console.WriteLine(x.Join(","))); //Генерируем последовательность от 0 до 9, разбиваем на 4 части по 3 эл-та (IEnumerable<IEnumerable<int>>).
Enumerable.Range(0, 10).TakeSkip(1, 1).ForEach(Console.WriteLine); //Берем 1 элемент, после него пропускаем 1 элемент и так до конца последовательности (в данном примере получается каждый 2-ой элемент).
```
