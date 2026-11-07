using System;
namespace CSharpBasic
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            int w = 50;
            int h = 30;
            ConsoleInit(w, h);

            SceneType SceneType = SceneType.Begin;
            while (true)
            {
                switch (SceneType)
                {
                    case SceneType.Begin:
                        //开始场景
                        Console.Clear();
                        BeginScene(w,h, ref SceneType);
                        break;
                    case SceneType.Game:
                        //游戏场景
                        Console.Clear();
                        GameScene();
                        break;
                    case SceneType.End:
                        //结束场景
                        Console.Clear();

                        break;
                }
            }
        }

        static void ConsoleInit(int w,int h)
        {

            Console.CursorVisible = false;
            Console.SetWindowSize(w, h);
            Console.SetBufferSize(w, h);
        }

        #region 开始场景实现
        static void BeginScene(int w,int h,ref SceneType NowScene)
        {
            int NowSelIndex = 0;
            Console.SetCursorPosition(w / 2 - 3, 8);
            Console.Write("飞行棋");
            bool isQuit = false;
            while (true)
            {
               
                Console.SetCursorPosition(w / 2 - 4, 13);
                Console.ForegroundColor = NowSelIndex == 0 ? ConsoleColor.Red: ConsoleColor.White;
                Console.Write("开始游戏");
                Console.SetCursorPosition(w / 2 - 4, 14);
                Console.ForegroundColor = NowSelIndex == 1 ? ConsoleColor.Red : ConsoleColor.White;
                Console.Write("结束游戏");
                switch (Console.ReadKey(true).Key)
                { 
                    case ConsoleKey.W:
                        NowSelIndex--;
                        if (NowSelIndex < 0)
                        {
                            NowSelIndex = 0;
                        }
                        break;
                    case ConsoleKey.S:
                        NowSelIndex++;
                        if (NowSelIndex > 1)
                        {
                            NowSelIndex = 1;

                        }
                        break;
                    case ConsoleKey.J:
                        if (NowSelIndex == 0)
                        {
                            NowScene = SceneType.Game;
                            isQuit = true;
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                        break;
                }
                if (isQuit)
                {
                    break;
                }
            }
        }
        #endregion

        #region 游戏场景实现
        static void GameScene()
        {

        }
        #endregion
    }
    enum SceneType
    {
        Begin,
        Game,
        End
    }
}