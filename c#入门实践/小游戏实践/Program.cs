using System;
namespace 小游戏实践 
{ 
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            #region 1 控制台基础设置
            //光标不可见
            Console.CursorVisible = false; ;
            //设置控制台大小
            int w = 60, h = 40;
            Console.SetWindowSize(w, h);
            Console.SetBufferSize(w, h);
            #endregion

            #region 2 多个场景
            int nowSceneID = 1;
            string End = "";
            while (true)
            {
                switch (nowSceneID)
                {
                    case 1:
                        #region 3 开始场景
                        Console.Clear();
                        Console.SetCursorPosition(w / 2 - 7, 8);
                        Console.Write("和风沐雪大冒险");

                        int nowSelIndex = 0;
                        while (true)
                        {
                            bool isQuitWhile = false;
                            
                            Console.SetCursorPosition(w / 2 - 4, 13);
                            Console.ForegroundColor = nowSelIndex == 0 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.Write("开始游戏");
                            Console.SetCursorPosition(w / 2 - 4, 15);
                            Console.ForegroundColor = nowSelIndex == 1 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.Write("退出游戏");
                            char input = Console.ReadKey(true).KeyChar;
                            switch (input)
                            {
                                case 'W':
                                case 'w':
                                    nowSelIndex--;
                                    if (nowSelIndex < 0)
                                    {
                                        nowSelIndex = 1;
                                    }
                                    break;
                                case 'S':
                                case 's':
                                    nowSelIndex++;
                                    if (nowSelIndex > 1)
                                    {
                                        nowSelIndex = 0;
                                    }
                                    break;
                                case 'J':
                                case 'j':
                                    if (nowSelIndex == 1)
                                    {
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        nowSceneID = 2;
                                        isQuitWhile = true;
                                    }
                                    break;
                            }

                            if (isQuitWhile)
                            {
                                break;
                            }
                        }
                        #endregion
                        break;
                    case 2:
                        #region 游戏场景
                        Console.Clear();

                        #region 1 绘制边框
                        Console.ForegroundColor = ConsoleColor.Red;
                        for(int i = 0; i < w; i+=2)
                        {
                            Console.SetCursorPosition(i, 0);
                            Console.Write("■");
                            Console.SetCursorPosition(i, h - 1);
                            Console.Write("■");
                            Console.SetCursorPosition(i, h - 6);
                            Console.Write("■");
                        }
                        for(int i = 0; i < h; i++)
                        {
                            Console.SetCursorPosition(0, i);
                            Console.Write("■");
                            Console.SetCursorPosition(w - 2, i);
                            Console.Write("■");
                        }
                        #endregion

                        #region 2 角色数据
                        int BossX = 24;
                        int BossY = 15;
                        int BossAtkMin = 7;
                        int BossAtkMax = 13;
                        int BossHp = 100;
                        ConsoleColor BossColor = ConsoleColor.Green;
                        string BossICon = "■";

                        int playerX = 4;
                        int playerY = 5;
                        int playerAtkMin = 8;
                        int playerAtkMax = 12;
                        int playerHp = 100;
                        string playerIcon = "★";
                        ConsoleColor playerColor = ConsoleColor.Yellow;
                        char playerInput;
                        bool isFight = false;
                        bool isOver = false;

                        int princessX = 24;
                        int princessY = 5;
                        ConsoleColor princesscolor = ConsoleColor.Blue;
                        string princessIcon = "♀";
                        #endregion

                        while (true)
                        {

                            if (isOver)
                            {
                                break;
                            }

                            if (BossHp > 0)
                            {
                                Console.SetCursorPosition(BossX, BossY);
                                Console.ForegroundColor = BossColor;
                                Console.Write(BossICon);
                            }

                            else
                            {
                                #region 公主相关
                                Console.ForegroundColor = princesscolor;
                                Console.SetCursorPosition(princessX, princessY);
                                Console.Write(princessIcon);

                                #endregion

                            }

                            #region 主角逻辑
                            Console.SetCursorPosition(playerX, playerY);
                            Console.ForegroundColor = playerColor;
                            Console.Write(playerIcon);
                            playerInput = Console.ReadKey(true).KeyChar;
                            if (isFight)
                            {
                                #region 战斗逻辑
                                if (playerInput == 'J' || playerInput == 'j')
                                {
                                    if (playerHp <= 0)
                                    {
                                        End = "营救失败";
                                        nowSceneID = 3;
                                        break;
                                    }
                                    else if (BossHp <= 0)
                                    {
                                        Console.SetCursorPosition(BossX, BossY);
                                        Console.Write("  ");
                                        isFight = false;
                                    }

                                    Random r = new Random();
                                    int PlayerAtk = r.Next(playerAtkMin, playerAtkMax + 1);
                                    BossHp -= PlayerAtk;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.SetCursorPosition(2, h - 4);
                                    Console.Write("                                          ");
                                    Console.SetCursorPosition(2, h - 4);
                                    Console.Write("你对Boss造成了{0}点伤害，Boss剩余血量：{1}", PlayerAtk, BossHp);
                                    if (BossHp > 0)
                                    {
                                        int BossAtk = r.Next(BossAtkMin, BossAtkMax + 1);
                                        playerHp -= BossAtk;
                                        // 先显示本次伤害，让玩家看到自己的血量变化
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.SetCursorPosition(2, h - 3);
                                        Console.Write("                                        ");
                                        Console.SetCursorPosition(2, h - 3);
                                        Console.Write("Boss对你造成了{0}点伤害，你剩余血量：{1}", BossAtk, playerHp);
                                        if (playerHp <= 0)
                                        {
                                            // 被击败：提示后停顿，等玩家按键再进入失败结算
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.SetCursorPosition(2, h - 5);
                                            Console.Write("                                        ");
                                            Console.SetCursorPosition(2, h - 5);
                                            Console.Write("很遗憾，你被Boss击败了！按任意键继续");
                                            Console.ReadKey(true);
                                            End = "营救失败";
                                            nowSceneID = 3;
                                            isOver = true;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.SetCursorPosition(2, h - 3);
                                        Console.Write("                                        ");
                                        Console.SetCursorPosition(2, h - 4);
                                        Console.Write("                                        ");
                                        Console.SetCursorPosition(2, h - 5);
                                        Console.Write("                                        ");
                                        Console.SetCursorPosition(2, h - 5);
                                        Console.Write("你击败了Boss!,快去营救公主");
                                        Console.SetCursorPosition(2, h - 4);
                                        Console.Write("前往公主身边按J键继续");
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                #region 移动逻辑
                                //擦除上一个位置
                                Console.SetCursorPosition(playerX, playerY);
                                Console.Write("  ");
                                //改变位置
                                switch (playerInput)
                                {
                                    case 'w':
                                    case 'W':
                                        playerY--;
                                        if (playerY < 1)
                                            playerY = 1;
                                        if (playerX == BossX && playerY == BossY && BossHp > 0)
                                        {
                                            playerY++;
                                        }
                                        else if (playerX == princessX && playerY == princessY && BossHp <= 0)
                                        {
                                            playerY++;
                                        }
                                        break;
                                    case 's':
                                    case 'S':
                                        playerY++;
                                        if (playerY >= h - 7)
                                        {
                                            playerY = h - 7;
                                        }
                                        if (playerX == BossX && playerY == BossY && BossHp > 0)
                                        {
                                            playerY--;
                                        }
                                        else if (playerX == princessX && playerY == princessY && BossHp <= 0)
                                        {
                                            playerY--;
                                        }
                                        break;
                                    case 'a':
                                    case 'A':
                                        playerX -= 2;
                                        if (playerX < 2)
                                        {
                                            playerX = 2;
                                        }
                                        if (playerX == BossX && playerY == BossY && BossHp > 0)
                                        {
                                            playerX += 2;
                                        }
                                        else if (playerX == princessX && playerY == princessY && BossHp <= 0)
                                        {
                                            playerX += 2;
                                        }
                                        break;
                                    case 'd':
                                    case 'D':
                                        playerX += 2;
                                        if (playerX >= w - 4)
                                        {
                                            playerX = w - 4;
                                        }
                                        if (playerX == BossX && playerY == BossY && BossHp > 0)
                                        {
                                            playerX -= 2;
                                        }
                                        else if (playerX == princessX && playerY == princessY && BossHp <= 0)
                                        {
                                            playerX -= 2;
                                        }
                                        break;
                                    case 'j':
                                    case 'J':
                                        if (BossHp > 0 && (playerX == BossX && playerY == BossY - 1
                                            || playerX == BossX && playerY == BossY + 1
                                            || playerX == BossX - 2 && playerY == BossY
                                            || playerX == BossX + 2 && playerY == BossY))
                                        {
                                            isFight = true;
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.SetCursorPosition(2, h - 5);
                                            Console.Write("按J继续战斗");
                                            Console.SetCursorPosition(2, h - 4);
                                            Console.Write("主角当前的血量为{0}", playerHp);
                                            Console.SetCursorPosition(2, h - 3);
                                            Console.Write("Boss当前的血量为{0}", BossHp);

                                        }
                                        else if(BossHp<=0&&(playerX==princessX&&playerY==princessY-1
                                            || playerX==princessX&&playerY==princessY+1
                                            || playerX==princessX-2&&playerY==princessY
                                            || playerX==princessX+2&&playerY==princessY))
                                        {
                                            nowSceneID = 3;
                                            End= "营救成功"; 
                                            isOver = true;
                                            break;
                                        }
                                        break;
                                }
                                #endregion
                            }
                            #endregion
                        }

                        #endregion
                        break;
                    case 3:
                        Console.Clear();
                        #region 结束场景
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(w / 2 - 4, 5);
                        Console.Write("GameOver");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(w / 2 - 4, 7);
                        Console.Write(End);

                        int nowSelEndIndex = 0;
                        while (true)
                        {
                            bool isQuitWhile = false;

                            Console.SetCursorPosition(w / 2 - 6, 12);
                            Console.ForegroundColor = nowSelEndIndex == 0 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.Write("回到开始界面");
                            Console.SetCursorPosition(w / 2 - 4, 15);
                            Console.ForegroundColor = nowSelEndIndex == 1 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.Write("退出游戏");
                            char input = Console.ReadKey(true).KeyChar;
                            switch (input)
                            {
                                case 'W':
                                case 'w':
                                    nowSelEndIndex--;
                                    if (nowSelEndIndex < 0)
                                    {
                                        nowSelEndIndex = 1;
                                    }
                                    break;
                                case 'S':
                                case 's':
                                    nowSelEndIndex++;
                                    if (nowSelEndIndex > 1)
                                    {
                                        nowSelEndIndex = 0;
                                    }
                                    break;
                                case 'J':
                                case 'j':
                                    if (nowSelEndIndex == 1)
                                    {
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        nowSceneID = 1;
                                        isQuitWhile = true;
                                    }
                                    break;
                            }

                            if (isQuitWhile)
                            {
                                break;
                            }
                        }
                        #endregion
                        break;
                }
            }
            #endregion

        }
    }
}