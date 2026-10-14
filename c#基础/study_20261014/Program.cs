using System;
using System.Diagnostics;
namespace study_20261014
{
    class Program
    {
        static void tt(int a)
        {
            a = 3;
        }

        static void change(int[] arr)
        {
            arr[0] = 3;
        }

        //ref 的使用
        static void tt2(ref int a)
        {
            a = 3;
        }

        static void changearrref(ref int[] a)
        {
            a=new int[] { 99, 98, 97, 96 };
        }

        //out 的使用和 ref 几乎一样，区别是 out 不需要初始化，ref 必须初始化
        //but out 必须在函数内部赋值，ref 可以不赋值


        //变长参数关键字 params
        static int sum(params int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            Console.WriteLine("sum={0}", sum);
            return sum;
        }

        static void speak(string str="Hello, World!")
        {
            Console.WriteLine(str);
        }
        //每个参数都可以有默认值，但是如果有多个参数，必须从右往左依次赋值，不能跳过中间的参数
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World!");
            #region ref和out知识点
            //他们可以解决：在函数内部改变参数的值，函数外部也能改变
            int a = 1;
            tt(a);
            Console.WriteLine(a);
            //a的值不会改变，因为a是值类型，传递的是值的拷贝，函数内部改变的是拷贝的值，不会影响外部的a

            int[] arr = { 1, 2, 3, 4 };
            change(arr);
            Console.WriteLine(arr[0]);
            //arr的值会改变，因为arr是引用类型，传递的是地址，函数内部改变的是地址指向的值，会影响外部的arr

            tt2(ref a);
            Console.WriteLine(a);
            //a的值会改变，因为a是值类型，传递的是地址，函数内部改变的是地址指向的值，会影响外部的a

            int[] arr2 = { 1, 2, 3, 4 };
            changearrref(ref arr2);
            Console.WriteLine(arr2[0]);
            //arr2的值会改变，因为arr2是引用类型，传递的是地址，函数内部改变的是地址指向的值，会影响外部的arr2




            //感觉和c++里的取址符&的用法很像
            #endregion

            #region 变长参数和参数默认值
            //变长参数关键字 params
            //注意：params关键字后面的必为数组类型，且只能有一个params关键字，且必须放在参数列表的最后
            sum();
            sum(1, 2, 3, 4, 5, 88, 99, 66);
            //参数默认值：在函数声明时给参数一个默认值，如果调用函数时没有传递该参数，则使用默认值
            speak();
            speak("Hello, C#!");

            #endregion
        }
    }
}