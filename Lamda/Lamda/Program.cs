using System;

/*
Lamda
anonymous methodを作る為使用
①式形式
args => 式
②文形式
(args) => {
    文1,
    文2,
    ...
}
*/

namespace Lamda
{
    class Program
    {
        //anonymous methodはdelegateで!!
        delegate int Calculate(int a, int b);
        delegate string Concatenate(string[] args);

        static void Main(string[] args)
        {
            //anonymous methodのLamda式を生成
            Calculate calc = (a, b) => a + b;
            Console.WriteLine($"{3} + {4} : {calc(3,4)}");

            //anonymous methodのLamda文を生成
            Concatenate concat =
                (arr) =>
                {
                    string result = "";
                    foreach (string s in arr)
                    {
                        result += s;
                    }
                    return result;
                };
            Console.WriteLine(concat(args));

        }
    }
}
