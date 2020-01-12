using System;

/*
delegateの使用目的
値ではなく、コード自体をargsで渡したい

delegateを利用したcallback実装手順
１．delegate宣言(methodのargsを一致させること)
２．delegateが参照するmethod宣言
３．delegate instance生成とdelegate呼出
*/
namespace Delegate
{
    //delegate宣言
    delegate int MyDelegate(int a, int b);

    class Calculator
    {
        //delegateが参照するmethod宣言
        public int Plus(int a, int b)
        {
            return a + b;
        }

        public int Minus(int a, int b)
        {
            return a - b;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Calculator Calc = new Calculator();
            MyDelegate Callback;

            //delegate instance生成とdelegate呼出
            Callback = new MyDelegate(Calc.Plus);
            Console.WriteLine(Callback(3,5));
            Callback = new MyDelegate(Calc.Minus);
            Console.WriteLine(Callback(7,3));
        }
    }
}
