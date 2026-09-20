using System;

namespace study_20260920
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("中文测试");

            #region 常量
            //const

            //const int i = 10;
            //1.必须初始化
            //2.值不能改变
            //Console.WriteLine(i);
            //// i = 10; // This will cause a compile error
            //int j = 20;
            //Console.ReadKey();
            //Console.WriteLine(j);
            //string str = "hahaha";
            //str = Console.ReadLine();
            //Console.WriteLine(str);

            #endregion

            #region 转义字符
            //作用：在字符串中表示一些特殊的字符
            //写法：\+特殊字符
            //string str = "hello\"world";
            //Console.WriteLine(str);
            ////换行 /n
            ////斜杠 //
            ////制表符 /t
            ////反斜杠 /\
            ////光标退格 /b
            ////警告音 /a
            //str = "/a";
            //Console.WriteLine(str);

            ////取消转义字符的作用：@+字符串
            //string str2 = @"hello/world";
            //Console.WriteLine(str2);


            #endregion

            #region 隐式转换

            #region 相同大类型之间的转换
            //大范围装小范围
            //特殊：demical没有办法用隐式转换的方法去变成float和double类型
            //特殊类型之间不存在隐式转换
            #endregion

            #region 不同大类型之间的转换
            //无符号不能装有符号
            //有符号可以装小范围的无符号.

            //浮点数可以装载任何类型的整数
            //整数不能装浮点数
            //double—》float—》long—》int—》short—》byte
            //decimal—》long—》int—》short—》byte

            //char类型可以转换成整形或浮点型，转换成char字符所代表的ASCII码值


            #endregion

            #endregion

            #region 显式转换

            #region 括号强转
            //将高精度强制转换为低精度类型

            //short s = 1;
            //int i = 1;
            //s = (short)i;

            //int i2 = -1;
            //uint ui2 = 1;
            //ui2 = (uint)i2;
            //Console.WriteLine(ui2);
            //i2 = (int)1.24f;
            //Console.WriteLine(i2);
            //括号强转可能会出现数据丢失，溢出，精度丢失


            #endregion

            #region Parse法

            ////将字符串转换为对应的类型
            //string str = "123";
            //int i = int.Parse(str);
            //Console.WriteLine(i);
            ////转换的类型必须是字符串所表示的类型，否则会报错
            ////范围也必须是对应的范围，否则会报错

            #endregion

            #region Convert法

            ////更准确的将各个类型之间进行转化
            ////Convert.To目标类型（变量或常量）
            //int ii = Convert.ToInt32("123");
            //Console.WriteLine(ii);

            //ii = Convert.ToInt32(1.24f);
            //Console.WriteLine(ii);
            ////精度更高，会进行四舍五入

            //ii = Convert.ToInt32(true);
            //Console.WriteLine(ii);
            ////可以把bool类型转换为int类型，true为1，false为0


            #endregion

            #region 其他类型转String

            ////变量.ToString()
            //string s1;
            //s1 = 123.ToString();
            //Console.WriteLine(s1);
            //s1 = true.ToString();
            //Console.WriteLine(s1);


            #endregion

            #region 练习题
            Console.WriteLine("请输入你的姓名");
            string name = Console.ReadLine();
            Console.WriteLine("请输入语文成绩");
            int yuwen = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("你的语文成绩是"+yuwen);
            Console.WriteLine("请输入数学成绩");
            int shuxue = int.Parse(Console.ReadLine());
            Console.WriteLine("你的数学成绩是"+shuxue);
            Console.WriteLine("请输入英语成绩");
            int yingyu = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("你的英语成绩是"+yingyu);

            #endregion

            #endregion

        }
    }
}