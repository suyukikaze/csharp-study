using System;
namespace 控制台相关知识
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            //1.清空
            Console.Clear();
            //2.设置控制台大小
            //注意：先设置窗口大小，再设置缓冲区大小
            //缓冲区大小不能小于窗口大小，否则会报错
            Console.SetWindowSize(100, 50);
            Console.SetBufferSize(100, 500);
            //3.设置光标
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("Hello");
            //4.设置颜色
            //文字颜色
            Console.ForegroundColor = ConsoleColor.Red;
            //背景颜色
            Console.BackgroundColor = ConsoleColor.White;
            //重置背景颜色后需要clear才能生效
            Console.Clear();

            //5.光标显隐
            Console.CursorVisible = false;
            //6.关闭控制台
            Environment.Exit(0);

            //随机数
            Random r = new Random(); //创建随机数对象
            int i = r.Next(); //生成一个随机数
            Console.WriteLine(i);
            i = r.Next(100); //生成一个0-99的随机数
            Console.WriteLine(i);
            i = r.Next(5, 100); //生成一个5-99的随机数
            Console.WriteLine(i);



            //练习
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            int x = 0, y = 0;
            Console.CursorVisible = false; 
            while (true)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine("▬");
                char c = Console.ReadKey(true).KeyChar;
                //擦除上一个位置
                Console.SetCursorPosition(x, y);
                Console.WriteLine(" ");

                if(c=='e')
                {
                    break;
                }

                switch (c)
                {
                    case 'w':
                    case 'W':
                        y-=1;
                        if (y < 0)
                        {
                            y = 0;
                        }
                        break;
                    case 's':
                    case 'S':
                        y+=1;
                        if(y > Console.WindowHeight - 1)
                        {
                            y = Console.WindowHeight - 1;
                        }
                        break;
                    case 'a':
                    case 'A':
                        x-=2;
                        if (x < 0)
                        {
                            x = 0;
                        }
                        break;
                    case 'd':
                    case 'D':
                        x+=2;
                        if (x > Console.BufferWidth - 2)
                        {
                            x = Console.BufferWidth - 2;
                        }
                        break;
                }
            }
        }
    }
}