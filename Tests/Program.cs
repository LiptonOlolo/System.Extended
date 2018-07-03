﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Attributes");
            Test test = new Test(0, 0);
            Console.WriteLine(test.GetAttribute<DescriptionAttribute>(null, GetAttributeType.Class).Description);
            Console.WriteLine(test.GetAttribute<DescriptionAttribute>(nameof(Test.A), GetAttributeType.Property).Description);
            Console.WriteLine(test.GetAttribute<DescriptionAttribute>(nameof(Test.B), GetAttributeType.Property).Description);
            Console.WriteLine(test.GetAttribute<DescriptionAttribute>(nameof(Test.Foo), GetAttributeType.Method).Description);
            Console.WriteLine(test.GetAttribute<DescriptionAttribute>(nameof(Test.a), GetAttributeType.Field).Description);
            Console.WriteLine();

            Console.WriteLine("Byte");
            Console.WriteLine(string.Join(" ", Guid.NewGuid().ToByteArray().GetHash(MD5.Create())));
            Console.WriteLine();

            Console.WriteLine("String");
            Console.WriteLine("".IsEmpty() ? "Строка пустая" : "Строка не пустая");
            Console.WriteLine("Hello, world!".IsMatch(".") ? "Строка соответствует паттерну" : "Строка не соответствует паттерну");
            Console.WriteLine($"md5(\"Hello, World!\") = {"\"Hello, World\"".GetStringHash(MD5.Create())}");
            Console.WriteLine("md5(\"Hello, World!\") = " + string.Join(" ", "\"Hello, World\"".GetHash(MD5.Create())));
            Console.WriteLine();

            Console.WriteLine("Linq");
            int local = 0;
            LinqExtenstion.CreateMany<Test>(5, 0, 0) //5 Test с A = 0 & B = 0
                          .Pipe(x => { x.A += ++local; x.B++; }) //Добавляем +1 значение св-вам A & B
                          .ForEach(x => Console.WriteLine($"A = {x.A}, B = {x.B}")); //ForEach используется без .ToList() (!)

            Enumerable.Range(0, 5).Append(666).ForEach(x => Console.WriteLine(x)); //Добавить объект в последовательность

            LinqExtenstion.CreateMany<Test>(4, 0, 0)
                          .Pipe(x => x.A++) //Каждому св-ву A прибавляем +1
                          .ForEach(x => Console.WriteLine(x.A));

            IEnumerable<int> oneInt = LinqExtenstion.Create(10); //Создаем последовательность из 1 объекта

            Console.ReadKey();
        }
    }

    [Description("Test class")]
    class Test
    {
        public Test(int a, int b)
        {
            A = a;
            B = b;
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
