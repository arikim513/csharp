using System;

/*
delegateを別途宣言せずに使用できる。(MSの解決策！)
Func 結果を返すmethod参照
     Func<args,.....,out result> 必ず最後のargs(out result)!!一つがリターン値
Action 結果を返さないmethod参照
*/
namespace AcionTest_lamda
{
    class Program
    {
        static void Main(string[] args)
        {
            Action act1 = () => Console.WriteLine("Action()");
            act1();

            int result = 0;
            Action<int> act2 = (x) => result = x*x;
            act2(3); 
            Console.WriteLine($"result:{result}");

            Action<double, double> act3 = (x, y) =>
            {
                double pi = x / y;
                Console.WriteLine($"Action<T1,T2>({x},{y}):{pi}");
            };
            act3(22.0, 7.0);
        }
    }
}
