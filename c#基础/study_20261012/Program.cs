using System;
using System.Net.NetworkInformation;
namespace study_20261012
{
    class Program
    {

        //在这里写函数
        static void Sayhello()
        {
            Console.WriteLine("hello");
        }

        static int cmp(int a,int b)
        {
            if(a>b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        static double[] circul(double r)
        {
            double pi = 3.14;
            double S = pi * r * r;
            double L = 2 * pi * r;
            return new double[] { S, L };
        }

        static void Main(String[] args)
        {
            #region 函数
            //函数写在哪
            //1.class语句中
            //2.struct语句中

            //基本语法
            //修饰符 返回值类型 函数名(参数列表)
            //{
            //    函数体
            //    return 返回值;(有返回值才返回)
            //}
            Sayhello();

            //练习
            int mmax = cmp(10, 5);
            Console.Write(mmax);
            double r = Double.Parse(Console.ReadLine());
            double[] results = circul(r);
            Console.WriteLine("面积: {0}, 周长: {1}", results[0], results[1]);

            #endregion
        }
    }
}