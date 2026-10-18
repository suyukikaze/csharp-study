using System;
namespace study_20261018
{

    struct Student
    {
        //变量
        //结构体中声明的变量不能初始化
        //可以包含别的结构体，但是不能包含自己的结构体
        public string name;
        public int age;
        //在结构体中的方法不需要加static
        public void Show()
        {
            Console.WriteLine("姓名：" + name + " 年龄：" + age);
        }
    }
    class Pprogram
    {
        static int Sum(int a, int b)
        {
            return a + b;
        }
        //参数数量不同
        static int Sum(int a, int b, int c)
        {
            return a + b + c;
        }
        //数量相同，类型不同
        static double Sum(double a, double b)
        {
            return a + b;
        }
        //数量相同，顺序不同
        static double Sum(int a, double b)
        {
            return a + b;
        }

        //ref和out
        static int Sum(ref int a, ref int b)
        {
            return a + b;
        }


        static int Cul(int n)
        {
            if (n == 1 || n==0)
            {
                return 1;
            }
            else return n * Cul(n - 1);
        }
        static void Main(String[] args)
        {
            #region 函数重载
            //函数重载是指在同一个类(class 或 struct)中，允许存在一个以上的同名函数，只要它们的参数个数或者参数类型不同即可。
            //作用：函数重载可以让程序员使用相同的函数名来处理不同类型的数据，从而提高代码的可读性和可维护性。

            Sum(1, 2);
            Sum(1, 2, 3);
            Sum(1.0, 2.0);
            Sum(1, 2.0);
            int x = 1;
            int y = 2;
            Sum(ref x, ref y);
            #endregion

            #region 递归函数
            //递归函数是指在函数体内调用函数自身的函数。

            //例题
            //1.求阶乘
            Console.WriteLine(Cul(5));
            #endregion

            #region 结构体
            //概念：结构体是值类型，结构体可以包含数据成员和函数成员，结构体可以实现接口，但不能继承自其他类或结构体。
            //基本语法：结构体一般写于namespace中，结构体的定义使用struct关键字，结构体的成员可以是字段、属性、方法、事件、索引器等。
            //结构体的使用
            Student s1;
            //访问修饰符：public：共有的可以被外部使用    private：私有的不能被外界使用
            s1.age = 21;
            s1.name = "suyukikaze";
            s1.Show();
            #endregion
        }
    }
}