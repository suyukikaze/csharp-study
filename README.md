# csharp-study

C# 学习记录仓库。每学完一个知识点／小项目就提交一次，用来积累进度、复盘问题。

## 环境

| 项目 | 版本 |
| --- | --- |
| .NET SDK | 10.0 (`net10.0`) |
| 解决方案格式 | `.slnx`（Visual Studio 2022 17.10+ / `dotnet` CLI 支持） |
| 语言特性 | 启用 `ImplicitUsings` 与 `Nullable`（见各 `.csproj`） |

验证环境：

```powershell
dotnet --version
```

## 目录结构

```
csharp-study/
├─ c#入门/                        # 基础练习
│  ├─ test_1.slnx                 # 解决方案文件（含下列项目）
│  ├─ test_1/                     # 项目 1：Hello World 起步
│  │  ├─ Program.cs               # 入口代码
│  │  └─ test_1.csproj            # 项目文件（net10.0）
│  ├─ study_20260920/             # 项目 2：2026-09-20 学习
│  │  ├─ Program.cs               # 常量 / 转义 / 类型转换
│  │  └─ study_20260920.csproj    # 项目文件（net10.0）
│  ├─ study_20260921/             # 项目 3：2026-09-21 学习
│  │  ├─ Program.cs               # 异常捕获 / 运算符
│  │  └─ study_20260921.csproj    # 项目文件（net10.0）
│  └─ study_20260923/             # 项目 4：2026-09-23 学习
│     ├─ Program.cs               # 条件语句 / 循环
│     └─ study_20260923.csproj    # 项目文件（net10.0）
├─ c#入门实践/                     # 动手实践
│  ├─ c#入门实践.slnx              # 解决方案文件（含下列项目）
│  ├─ c#入门实践/                   # 练习脚手架（Hello World）
│  │  ├─ Program.cs
│  │  └─ c#入门实践.csproj
│  └─ 控制台相关知识/                # 项目 5：2026-09-24 学习
│     ├─ Program.cs               # 控制台 API / 随机数 / 移动小游戏
│     └─ 控制台相关知识.csproj
├─ .gitignore                     # 忽略 bin/ obj/ .vs/ 等构建产物
└─ README.md
```

## 怎么运行

```powershell
cd "c#入门"
dotnet run --project test_1
```

输出：

```
Hello, World!
```

想跑当天最新的学习项目：

```powershell
cd "c#入门实践"
dotnet run --project 控制台相关知识
```

> 提示：`控制台相关知识` 是动手实践项目，会直接操作控制台（改窗口大小、颜色、光标），**必须在真实终端里运行**，用管道/重定向输入会报错。
>
> ⚠️ 注意：`Program.cs` 第 31 行有 `Environment.Exit(0)`，程序执行到那里就直接退出了，**后面的 `Random` 随机数部分和 WASD 移动小游戏都不会执行**。要做后面的练习，需要先把这一行注释掉。
>
> `study_20260923` 需要输入两次——先输「今天看视频的时间」（分钟），再输一个数字给 `switch` 判断星期（1-7，其他值走 `default`）。
>
> `study_20260921` 的异常捕获练习和比较大小练习同样需要手动输入，直接回车或输入非数字会走进 `catch`，属正常现象。
>
> 目录名带 `#`，在终端里记得用引号包起来（`cd "c#入门实践"`），否则 `#` 后面的内容可能被当成注释。

## 学习记录

| 日期 | 项目 | 内容 |
| --- | --- | --- |
| 2026-09-20 | `study_20260920` | 常量 `const`、转义字符（`\n` `\t` `\"` `\\` `\b` `\a`）、`@` 取消转义、隐式转换规则、显式转换（括号强转 / `Parse` / `Convert` / `ToString`），做完成绩录入练习 |
| 2026-09-21 | `study_20260921` | 异常捕获 `try` / `catch` / `finally`、算术运算符与优先级、自增减 `++` `--`、字符串拼接（`+` / `string.Format`）、条件运算符、逻辑运算符（`!` `&&` `\|\|` 及短路规则）、位运算符、三目运算符，做完比较大小练习 |
| 2026-09-23 | `study_20260923` | 条件语句 `if` / `else`、`switch` / `case` / `default` / `break`，循环 `while`、`do-while`（特点：先执行一次再判断）、`for`，做完「看视频时长」练习 |
| 2026-09-24 | `控制台相关知识` | 控制台 API：`Console.Clear`、`SetWindowSize` / `SetBufferSize`（先窗口后缓冲区）、`SetCursorPosition`、`ForegroundColor` / `BackgroundColor`、`CursorVisible`、`Environment.Exit`；`Random` 随机数（`Next()` / `Next(max)` / `Next(min, max)`）；用 `Console.ReadKey(true)` + `while` + `switch` 做了 WASD 移动小游戏 |

> 注：`Program.cs` 里已经学过的小节用 `#region` 分段、以注释保留，方便日后回看当时的理解。

## 怎么新增一个练习项目

每个知识点建一个独立项目，互不干扰：

```powershell
# 1. 新建控制台项目（例如练变量与类型）
dotnet new console -o practice_02_types

# 2. 把练习代码写进 practice_02_types/Program.cs

# 3. 单独运行
dotnet run --project practice_02_types
```

想把新项目加进解决方案，编辑 `c#入门/test_1.slnx` 即可：

```xml
<Solution>
  <Project Path="test_1/test_1.csproj" />
  <Project Path="../practice_02_types/practice_02_types.csproj" />
</Solution>
```

## 学习完怎么上传（日常流程）

每次学完，在 `c#_study` 目录下执行这三步：

```powershell
git add .
git commit -m "学习：变量与数据类型练习"
git push
```

## 提交信息建议

用「类型: 内容」的格式，方便以后翻记录：

| 前缀 | 用途 | 例子 |
| --- | --- | --- |
| `学习:` | 新增练习或笔记 | `学习: 完成面向对象继承练习` |
| `修复:` | 修正代码或笔记错误 | `修复: 循环边界写错导致数组越界` |
| `笔记:` | 纯文字笔记整理 | `笔记: 补充装箱拆箱的理解` |
| `重构:` | 优化已有代码 | `重构: 把重复逻辑抽成方法` |

## 备注

`bin/`、`obj/`、`.vs/` 这些是编译和 IDE 缓存，已被 `.gitignore` 忽略，不会上传到仓库；换台电脑 `git clone` 后 `dotnet build` 就能重新生成。
