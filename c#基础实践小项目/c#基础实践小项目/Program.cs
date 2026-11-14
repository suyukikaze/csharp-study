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

            SceneType NowSceneType = SceneType.Begin;
            while (true)
            {
                switch (NowSceneType)
                {
                    case SceneType.Begin:
                        //开始场景
                        Console.Clear();
                        BeginorEndScene(w,h, ref NowSceneType);
                        break;
                    case SceneType.Game:
                        //游戏场景
                        Console.Clear();
                        GameScene(w,h, ref NowSceneType);
                        break;
                    case SceneType.End:
                        //结束场景
                        Console.Clear();
                        BeginorEndScene(w, h, ref NowSceneType);
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

        #region 开始场景实现+结束场景实现
        static void BeginorEndScene(int w,int h,ref SceneType NowScene)
        {
            int NowSelIndex = 0;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(NowScene == SceneType.Begin ? (w / 2 - 3):(w/2-4), 8);
            Console.Write(NowScene==SceneType.Begin?"飞行棋":"游戏结束");
            bool isQuit = false;
            while (true)
            {
               
                Console.SetCursorPosition(NowScene == SceneType.Begin ? w / 2 - 4:w/2-5, 13);
                Console.ForegroundColor = NowSelIndex == 0 ? ConsoleColor.Red: ConsoleColor.White;
                Console.Write(NowScene == SceneType.Begin ? "开始游戏":"回到主菜单");
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
                            NowScene = NowScene == SceneType.Begin ? SceneType.Game:SceneType.Begin;
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
        static void GameScene(int w, int h, ref SceneType NowScene)
        {
            //绘制不变的信息
            DrawWall(w,h);
            //绘制地图
            Map map = new Map(14, 3, 80);
            map.Draw();
            //绘制玩家信息
            Player player = new Player(0, PlayerType.Player);
            Player computer = new Player(1, PlayerType.Computer);
            DrawPlayer(player, computer, map);

            bool isGameOver = false;    
            //游戏场景循环
            while (true)
            {
                //之后的游戏逻辑

                //玩家扔色子逻辑
                //检测输入
                Console.ReadKey(true);
                //扔色子的逻辑
                isGameOver = ThrowDice(w, h, ref player, ref computer, map);
                //绘制地图
                map.Draw();
                //绘制玩家
                DrawPlayer(player, computer, map);
                //判断是否结束游戏
                if(isGameOver)
                {
                    Console.ReadKey(true);
                    NowScene = SceneType.End;
                    break;
                }

                //电脑扔色子逻辑
                //检测输入
                Console.ReadKey(true);
                //扔色子的逻辑
                isGameOver = ThrowDice(w, h, ref computer, ref player, map);
                //绘制地图
                map.Draw();
                //绘制玩家
                DrawPlayer(player, computer, map);
                //判断是否结束游戏
                if (isGameOver)
                {
                    Console.ReadKey(true);
                    NowScene = SceneType.End;
                    break;
                }
            }
        }
        #endregion

        #region 结束场景实现
        //参考开始场景实现的代码
        #endregion

        #region 绘制不变的信息
        static void DrawWall(int w,int h)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for(int i = 0; i < w; i+=2)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
                Console.SetCursorPosition(i, h - 6);
                Console.Write("■");
                Console.SetCursorPosition(i, h - 1);
                Console.Write("■");
                Console.SetCursorPosition(i, h - 11);
                Console.Write("■");
            }

            for(int i = 0; i < h; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
                Console.SetCursorPosition(w - 2, i);
                Console.Write("■"); 
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(2, h - 10);
            Console.Write("▢：普通格子");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(2, h - 9);
            Console.Write("⇵：暂停一回合不动");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(26, h - 9);
            Console.Write("●：炸弹，倒退五格");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(2, h - 8);
            Console.Write("¤：时空隧道，随机倒退，暂停，换位置");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(2, h - 7);
            Console.Write("★：玩家");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(12, h - 7);
            Console.Write("▲：电脑");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(22, h - 7);
            Console.Write("※：玩家和电脑重合");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(2, h - 5);
            Console.Write("按任意键开始扔色子");
        }
        #endregion

        #region 绘制玩家
        static void DrawPlayer(Player player, Player computer, Map map)
        {
            //重合的时候
            if (player.nowIndex == computer.nowIndex)
            {
                Grid grid = map.grids[player.nowIndex];
                Console.SetCursorPosition(grid.pos.x, grid.pos.y);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("※");
            }
            //不重合的时候
            else
            {
                player.Draw(map);
                computer.Draw(map);
            }
        }
        #endregion

        #region 扔色子的函数

        static void CleanPlayerInfo(int w, int h)
        {
            Console.SetCursorPosition(2, h - 5);
            Console.Write("                                  ");
            Console.SetCursorPosition(2, h - 4);
            Console.Write("                                  ");
            Console.SetCursorPosition(2, h - 3);
            Console.Write("                                  ");
            Console.SetCursorPosition(2, h - 2);
            Console.Write("                                  ");
        }
        static bool ThrowDice(int w,int h,ref Player p, ref Player p2, Map map)
        {
            //擦之前的内容
            CleanPlayerInfo(w, h);

            Console.ForegroundColor=(p.type==PlayerType.Player)?ConsoleColor.Cyan:ConsoleColor.Magenta;

            if (p.isStop)
            {
                Console.SetCursorPosition(2, h - 5);
                Console.Write("处于暂停状态，{0}需要暂停一回合", p.type==PlayerType.Player?"你":"电脑");
                Console.SetCursorPosition(2, h - 4);
                Console.Write("请按任意键让{0}开始扔色子", p.type == PlayerType.Player ? "你" : "电脑");
                p.isStop = false;
                return false;
            }

            Random r = new Random();
            int num = r.Next(1, 7);
            p.nowIndex += num;

            //打印仍的点数
            Console.SetCursorPosition(2, h - 5);
            Console.Write("{0}扔出的点数为{1},", p.type == PlayerType.Player ? "你" : "电脑", num);

            if (p.nowIndex >= map.grids.Length - 1)
            {
                p.nowIndex = map.grids.Length - 1;

                if (p.type == PlayerType.Player)
                {
                    Console.SetCursorPosition(2, h - 4);
                    Console.Write("恭喜你率先到达了终点");
                }
                else
                {
                    Console.SetCursorPosition(2, h - 4);
                    Console.Write("很遗憾电脑率先到达了终点");
                }
                Console.SetCursorPosition(2, h - 3);
                Console.Write("请按任意键结束游戏");
                return true;
            }
            else
            {
                Grid grid = map.grids[p.nowIndex];
                switch (grid.type)
                {
                    case GridType.Normal:
                        Console.SetCursorPosition(2, h - 4);
                        Console.Write("{0}到达了普通格子", p.type == PlayerType.Player ? "你" : "电脑");
                        Console.SetCursorPosition(2, h - 3);
                        Console.Write("请按任意键让{0}开始扔色子", p.type == PlayerType.Player ? "你" : "电脑");
                        break;
                    case GridType.Bomb:
                        p.nowIndex -= 5;
                        if (p.nowIndex < 0)
                            p.nowIndex = 0;
                        Console.SetCursorPosition(2, h - 4);
                        Console.Write("{0}踩到了炸弹，退后5格", p.type == PlayerType.Player ? "你" : "电脑");
                        Console.SetCursorPosition(2, h - 3);
                        Console.Write("请按任意键让{0}开始扔色子", p.type == PlayerType.Player ? "你" : "电脑");
                        break;
                    case GridType.Stop:
                        p.isStop = true;
                        // 暂停一回合
                        Console.SetCursorPosition(2, h - 4);
                        Console.Write("{0}到达了停止格子，需要暂停一回合", p.type == PlayerType.Player ? "你" : "电脑");
                        Console.SetCursorPosition(2, h - 3);
                        Console.Write("请按任意键让{0}开始扔色子", p.type == PlayerType.Player ? "你" : "电脑");
                        break;
                    case GridType.Tunnel:
                        // 随机倒退，暂停，换位置
                        Console.SetCursorPosition(2, h - 4);
                        Console.Write("{0}到达了时空隧道", p.type == PlayerType.Player ? "你" : "电脑");
                        num = r.Next(1, 91);
                        if(num <= 30)
                        {
                            p.nowIndex -= 5;
                            if (p.nowIndex < 0)
                                p.nowIndex = 0;
                            Console.SetCursorPosition(2, h - 3);
                            Console.Write("{0}触发炸弹，退后5格", p.type == PlayerType.Player ? "你" : "电脑");
                        }
                        else if(num <= 60)
                        {
                            p.isStop = true;
                            Console.SetCursorPosition(2, h - 3);
                            Console.Write("{0}触发暂停一回合", p.type == PlayerType.Player ? "你" : "电脑");
                        }
                        else
                        {
                            int temp = p.nowIndex;
                            p.nowIndex = p2.nowIndex;
                            p2.nowIndex = temp;
                            Console.SetCursorPosition(2, h - 3);
                            Console.Write("{0}触发换位置", p.type == PlayerType.Player ? "你" : "电脑");
                        }
                        Console.SetCursorPosition(2, h - 2);
                        Console.Write("请按任意键让{0}开始扔色子", p.type == PlayerType.Player ? "你" : "电脑");
                        break;
                }
            }
                //默认没有结束
            return false;
        }
        #endregion

    }
    enum SceneType
    {
        Begin,
        Game,
        End
    }

    enum GridType
    {
        Normal,
        Bomb,
        Stop,
        Tunnel
    }
    //位置信息结构体
    struct Vector2
    {
        public int x, y;
        public Vector2(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    #region 格子结构体
    struct Grid
    {
        public GridType type;
        public Vector2 pos;
        //初始化构造函数
        public Grid(int x,int y,GridType type)
        {
            this.pos = new Vector2(x, y);
            this.type = type;
        }
        public void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            switch (type)
            {
                case GridType.Normal:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("▢");
                    break;
                case GridType.Bomb:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("●");
                    break;
                case GridType.Stop:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("⇵");
                    break;
                case GridType.Tunnel:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("¤");
                    break;
            }
        }
    }
    #endregion

    #region 地图结构体
    struct Map
    {
        public Grid[] grids;
        public Map(int x,int y,int num)
        {

            //设置类型
            grids = new Grid[num];

            //用于位置改变计数
            int indexx = 0;
            int indexy = 0;
            int step = 2;

            Random r = new Random();
            int randomnum;
            for (int i = 0; i < num; i++)
            {
                randomnum = r.Next(0, 101);

                if (randomnum < 85 || i == 0 || i == num - 1)
                {
                    grids[i].type = GridType.Normal;
                }
                else if (randomnum >= 85 && randomnum < 90)
                {
                    grids[i].type = GridType.Bomb;
                }
                else if (randomnum >= 90 && randomnum < 95)
                {
                    grids[i].type = GridType.Stop;
                }
                else
                {
                    grids[i].type = GridType.Tunnel;
                }

                //设置位置
                grids[i].pos = new Vector2(x, y);
                if (indexx == 10)
                {
                    y++;
                    indexy++;
                    if (indexy == 2)
                    {
                        indexx = 0;
                        indexy = 0;
                        step = -step;
                    }
                }
                else
                {
                    x += step;
                    indexx++;
                }
            }
        }

        public void Draw()
        {
            for(int i = 0; i < grids.Length; i++)
            {
                grids[i].Draw();
            }
        }
    }
    #endregion

    enum PlayerType
    {
        Player,
        Computer
    }

    struct Player
    {
        public PlayerType type;
        public int nowIndex;
        public bool isStop;
        public Player(int index, PlayerType type)
        {
            this.nowIndex = index;
            this.type = type;
            this.isStop = false;
        }
        public void Draw(Map mapInfo)
        {
            //从传入的地图中得到格子信息
            Grid grid = mapInfo.grids[nowIndex];
            //设置位置
            Console.SetCursorPosition(grid.pos.x, grid.pos.y);
            // 绘制玩家
            switch(type)
            {
                case PlayerType.Player:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("★");
                    break;
                case PlayerType.Computer:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("▲");
                    break;
            }

        }
    }
}