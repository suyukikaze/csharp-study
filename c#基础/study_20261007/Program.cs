using System;
namespace study_20261007
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 二维数组

            int[,] arr1 = new int[3, 4];
            int[,] arr2 = new int[3, 3] { {1, 2, 3}, {4, 5, 6}, {7, 8, 9} };
            //得到多少行
            int rowCount = arr2.GetLength(0);
            //得到多少列
            int colCount = arr2.GetLength(1);
            Console.WriteLine("行数：{0}，列数：{1}", rowCount, colCount);
            //遍历二维数组
            for(int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    Console.Write(arr2[i, j] + " ");
                }
                Console.WriteLine();
            }

            //增加，删除，查找和一维数组类似

            #endregion

            #region 交错数组
            //概念：交错数组是数组的数组，里面的每个元素都是一个数组
            int[][] arr = new int[3][] { new int[3] { 1, 2, 3 }, 
                                         new int[2] { 4, 5 },
                                         new int[4] { 6, 7, 8, 9 } };
            //获取行数
            int rowCount2 = arr.GetLength(0);
            //交错数组没有"列数"的概念，因为每行长度可以不同
            //这里取的是第0行的长度，仅仅作为一个示例
            int firstRowLength = arr[0].Length;
            Console.WriteLine("行数：{0}，第0行的长度：{1}", rowCount2, firstRowLength);
            //遍历交错数组
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }
            //增加，删除，查找和一维数组类似

            //印证：交错数组每行的长度可以不同
            int maxRowLength = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.WriteLine("第{0}行的长度为：{1}", i, arr[i].Length);
                if (arr[i].Length > maxRowLength)
                {
                    maxRowLength = arr[i].Length;
                }
            }
            Console.WriteLine("最长的行长：{0}", maxRowLength);
            #endregion

        }
    }
}