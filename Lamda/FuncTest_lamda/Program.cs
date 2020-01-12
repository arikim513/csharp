using System;

/*
delegateを別途宣言せずに使用できる。(MSの解決策！)
Func 結果を返すmethod参照
     Func<args,.....,out result> 必ず最後のargs(out result)!!一つがリターン値
Action 結果を返さないmethod参照
*/
namespace FuncTest_lamda
{
    class Program
    {
        static void Main(string[] args)
        {
            //最後のargsは必ずリターン値
            Func<int> func1 = () => 10;
            Console.WriteLine($"func1(): {func1()}");

            Func<int,int> func2 = (x) => x*2;
            Console.WriteLine($"func2(4): {func2(4)}");

            Func<double, double, double> func3 = (x,y) => x/y;
            Console.WriteLine($"func3(22,7): {func3(22,7)}");
        }
    }
}
