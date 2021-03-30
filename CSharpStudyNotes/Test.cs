using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpStudyNotes
{
    class OtherSomeClass<T1, T2, T3, T4>
        where T3 : ICloneable
        where T4 : IComparable
    {
        //T1 FirstValue;
        //T2 SecondtValue;
        //声明泛型方法
        public void PrintData(T1 t1, T2 t2)
        {
            ///t1 = 5;
            Console.WriteLine("t2={0}", t2);

        }
    }

    class ProgramSomeClass
    {
        static void Main()
        {
            var first = new OtherSomeClass<int, string, ICloneable, IComparable>();
            var second = new OtherSomeClass<int, long, ICloneable, IComparable>();
            first.PrintData(25, "请打印我");
        }
    }
}
