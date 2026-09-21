using System;
namespace study_20260921
{
    class Program
    {
        static void Main(String[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("中文测试");

            #region 异常捕获
            //异常捕获的作用：当程序出现异常时，程序不会崩溃，而是会执行catch中的代码
            try
            {
                //希望进行异常捕获的代码
                //可以放进try中
                //try中代码出现异常时，程序会跳转到catch中执行
                Console.WriteLine("请输入数字");
                string sstr = Console.ReadLine();
                int i = int.Parse(sstr);
            }
            catch (Exception ex)//通过Exception类的对象ex来获取异常信息
            {
                //当try中代码出现异常时，catch中的代码会执行
                Console.WriteLine("请输入合法内容");
                Console.WriteLine(ex.Message);
            }
            //可选部分
            finally
            {
                //无论是否出现异常，finally中的代码都会执行
                //最后执行
                Console.WriteLine("执行完毕");
            }
            #endregion

            #region 算术运行算符
            //赋值符号：=
            //算术运算符：+ - * / %
            //优先级：* / % > + -
            //自增减运算符：++ --
            #endregion

            #region 字符串拼接
            //用+号进行字符串拼接
            string str = "123";
            str += "456";
            Console.WriteLine(str);

            //string.Format("带拼接的内容"+内容一，内容二，...)
            string str2 = string.Format("我是{0}，我今年{1}岁，我要{2}", "st", "21", "好好学习C#");
            Console.WriteLine(str2);

            #endregion

            #region 条件运算符
            //比较两个变量或常量大小
            //类型：> < >= <= == !=
            //比较的结果返回的是一个bool类型的值

            #endregion

            #region 逻辑运算符
            //对两个bool类型的值进行逻辑运算
            //类型：!：逻辑非 &&：逻辑与 ||：逻辑或

            //逻辑运算符短路规则：当第一个条件已经可以判断出结果时，第二个条件不会再进行判断

            #endregion

            #region 位运算符
            //位与：& 位或：| 位异或：^ 位非：~ 左移：<< 右移：>>
            #endregion

            #region 三目运算符
            // ? : 形式：条件 ? 条件成立时的值 : 条件不成立时的值

            #endregion

            //练习题，输入两个数比较大小
            try
            {
                Console.WriteLine("请输入a的值");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine("请输入b的值");
                int b = int.Parse(Console.ReadLine());
                string ans = a > b ? "a大于b" : "a不大于b";
                
                Console.WriteLine(ans);
            }
            catch
            {
                Console.WriteLine("请输入数字");
            }
        }
    }
}