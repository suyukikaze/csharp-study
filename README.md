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
├─ test_1/                     # 练习项目 1：Hello World 起步
│  ├─ test_1.slnx              # 解决方案文件
│  └─ test_1/
│     ├─ Program.cs            # 入口代码
│     └─ test_1.csproj         # 项目文件（net10.0）
├─ .gitignore                  # 忽略 bin/ obj/ .vs/ 等构建产物
└─ README.md
```

## 怎么运行

```powershell
cd test_1
dotnet run --project test_1
```

输出：

```
Hello, World!
```

## 怎么新增一个练习项目

每个知识点建一个独立项目，互不干扰：

```powershell
# 1. 新建控制台项目（例如练变量与类型）
dotnet new console -o practice_02_types

# 2. 把练习代码写进 practice_02_types/Program.cs

# 3. 单独运行
dotnet run --project practice_02_types
```

想把新项目加进解决方案，编辑 `test_1/test_1.slnx` 即可：

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
