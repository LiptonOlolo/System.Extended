using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            //string a = File.ReadAllText("D:\\test.txt");

            Console.WriteLine("Attributes");
            Test test = new Test();
            Console.WriteLine(test.GetAttribute<DescriptionAttribute>(null, GetAttributeType.Class).Description);
            Console.WriteLine(test.GetAttribute<DescriptionAttribute>(nameof(Test.A), GetAttributeType.Property).Description);
            Console.WriteLine(test.GetAttribute<DescriptionAttribute>(nameof(Test.B), GetAttributeType.Property).Description);
            Console.WriteLine(test.GetAttribute<DescriptionAttribute>(nameof(Test.Foo), GetAttributeType.Method).Description);
            Console.WriteLine(test.GetAttribute<DescriptionAttribute>(nameof(Test.a), GetAttributeType.Field).Description);
            Console.WriteLine();

            Console.WriteLine("Byte");
            Console.WriteLine(Guid.NewGuid().ToByteArray().GetHash(MD5.Create()).Join(" "));
            Console.WriteLine();

            Console.WriteLine("String");
            Console.WriteLine("".IsEmpty() ? "Строка пустая" : "Строка не пустая");
            Console.WriteLine("Hello, world!".IsMatch(".") ? "Строка соответствует паттерну" : "Строка не соответствует паттерну");
            Console.WriteLine($"md5(\"Hello, World!\") = {"\"Hello, World\"".GetStringHash(MD5.Create())}");
            Console.WriteLine("md5(\"Hello, World!\") = " + string.Join(" ", "\"Hello, World\"".GetHash(MD5.Create())));
            Console.WriteLine();

            Console.WriteLine("Linq");
            Enumerable.Range(0, 5).Append(666).ForEach(Console.WriteLine); //Добавить объект в последовательность

            IEnumerable<int> oneInt = LinqExtenstion.Create(10); //Создаем последовательность из 1 объекта

            Console.WriteLine(oneInt.IsEmpty()); //Проверка на наличие элементов.
            List<int> list = null;
            Console.WriteLine(list.IsNullOrEmpty()); //Проверка на null или наличие элементов.
            Console.WriteLine(Enumerable.Range(0, 10).Shuffle().Join(",")); //Сортировка в случайном порядке, объединение всей последовательности в одну (новый метод Join).
            Enumerable.Range(0, 10).Chunk(2).ForEach(x => Console.WriteLine(x.Join(","))); //Генерируем последовательность от 0 до 9, разбиваем на 4 части по 3 эл-та (int[][]).
            Enumerable.Range(0, 10).TakeSkip(1, 1).ForEach(Console.WriteLine); //Берем 1 элемент, после него пропускаем 1 элемент и так до конца последовательности (в данном примере получается каждый 2-ой элемент).

            Console.ReadKey();
        }
    }

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
}
