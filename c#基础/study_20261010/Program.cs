using System;
namespace study_20261010
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 值类型和引用类型
            //引用类型：类、数组、String
            //值类型：int、float、double、decimal、bool、char、enum、struct
            //使用上的区别
            //值类型
            int a = 10;
            //引用类型
            int[] arr = { 1, 2, 3, 4 };

            int b = a;
            int[] arr2 = arr;
            Console.WriteLine("a={0},b={1}", a, b);
            Console.WriteLine("arr[0]={0},arr2[0]={1}", arr[0], arr2[0]);

            b = 20;
            arr2[0] = 5;
            Console.WriteLine("a={0},b={1}", a, b);
            Console.WriteLine("arr[0]={0},arr2[0]={1}", arr[0], arr2[0]);

            //值类型在相互赋值时，是把值拷贝给了对方，他变我不变
            //引用类型在相互赋值时，是把地址拷贝给了对方，让两者只想同一个值，他变我也变
            //string是一个特殊的引用类型，他不遵循他变我也变

            //为什么会有值类型和引用类型的区别？
            //值类型：存储在栈中，生命周期短，效率高
            //引用类型：存储在堆中，生命周期长，效率低
            arr2=new int[]{55 ,9,5,6,4 };
            Console.WriteLine("arr[0]={0},arr2[0]={1}", arr[0], arr2[0]);

            #endregion

            #region 特殊的引用类型string
            string str="123";
            string str2 = str;
            str2 = "321";
            Console.WriteLine("str={0},str2={1}", str, str2);
            #endregion

        }
    }
}