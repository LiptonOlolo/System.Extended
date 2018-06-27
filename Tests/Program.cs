using System;
using System.Linq;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
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


            var res1 = tests.SelectMany(x => x.A);

            foreach (var item in res1)
            {
                Console.WriteLine(item);
            }
        }
    }

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
}
