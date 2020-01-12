using System;
using System.Linq.Expressions;

namespace UsingExpressionTree
{
    class Program
    {
        //treeで表現したい式: 1*2+(x-y)
        static void Main(string[] args)
        {
            //Constant
            Expression const1 = Expression.Constant(1);
            Expression const2 = Expression.Constant(3);

            //Multiply
            Expression leftExp = Expression.Multiply(const1, const2);

            //Parameter(variable)
            Expression paramX = Expression.Parameter(typeof(int));
            Expression paramY = Expression.Parameter(typeof(int));

            //Subtract
            Expression rightExp = Expression.Subtract(paramX, paramY);

            //Add
            Expression exp = Expression.Add(leftExp, rightExp);

            //lamda
            Expression<Func<int, int, int>> expression =
                Expression<Func<int, int, int>>.Lambda<Func<int, int, int>>(
                        exp, new ParameterExpression[]{
                            (ParameterExpression)paramX,
                            (ParameterExpression)paramY});

            Func<int, int, int> func = expression.Compile();
            //x=7, y=8
            Console.WriteLine($"1*2+(7-8) = {func(7,8)}");
        }
    }
}