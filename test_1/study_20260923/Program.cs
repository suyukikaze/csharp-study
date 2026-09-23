using System;

namespace study_20260921
{
    public class  Program
    {
        static void Main(String[] args)
        {

            #region if语句
            //if语句的作用：根据条件的真假来执行不同的代码
            //格式和c++一样

            //习题
            try
            {
                Console.WriteLine("请输入今天看视频的时间");
                int time = int.Parse(Console.ReadLine());
                if (time >= 60)
                {
                    Console.WriteLine("今天看视频花了" + time + "分钟，恭喜你离成功又近了一步");
                }
                else
                {
                    Console.WriteLine("你hi需要努力啊");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("请输入合法内容");
                Console.WriteLine(ex.Message);
            
            }

            #endregion

            #region switch语句
            //switch语句的作用：根据条件的真假来执行不同的代码
            int i = int.Parse(Console.ReadLine());
            switch (i)
            {
                case 1:
                    Console.WriteLine("今天是星期一");
                    break;
                case 2:
                    Console.WriteLine("今天是星期二");
                    break;
                case 3:
                    Console.WriteLine("今天是星期三");
                    break;
                case 4:
                    Console.WriteLine("今天是星期四");
                    break;
                case 5:
                    Console.WriteLine("今天是星期五");
                    break;
                case 6:
                    Console.WriteLine("今天是星期六");
                    break;
                case 7:
                    Console.WriteLine("今天是星期日");
                    break;
                default:
                    Console.WriteLine("请输入合法内容");
                    break;
            }
            #endregion

            #region while循环
            //while循环的作用：根据条件的真假来重复执行代码
            int j = 0;
            while (j < 5)
            {
                Console.WriteLine("这是第" + (j + 1) + "次循环");
                j++;
            }


            #endregion

            #region dowhile循环
            //dowhile循环的作用：根据条件的真假来重复执行代码
            //dowhile循环的特点：先执行一次循环体，再判断条件是否成立
            #endregion

            #region for循环
            //for循环的作用：根据条件的真假来重复执行代码
            //for循环的特点：先判断条件是否成立，再执行循环体
            for (int ii = 0; ii < 5; ii++)
            {
                Console.WriteLine("这是第" + (ii + 1) + "次循环");
            }
            #endregion



        }
    }
}