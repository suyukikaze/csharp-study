using System;
namespace study_20261022
{
    class Program {
        static void Main(String[] args)
        {
            #region 冒泡排序
            Random r = new Random();
            int[] arr = new int[10];
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(0, 101);
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            for (int i = 0; i < arr.Length; i++)
            { 
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            //每一轮都可以找出一个最大的排在最后面
            #endregion

            #region 选择排序
            int[] brr = new int[10];
            for (int i = 0; i < brr.Length; i++)
            {
                brr[i] = r.Next(0, 101);
                Console.Write(brr[i] + " ");
            }
            Console.WriteLine();
            int index = 0;
            for(int i = 0; i < brr.Length; i++)
            {
                index = 0;
                for(int j = 1; j < brr.Length - i; j++)
                {
                    if (brr[index] < brr[j])
                    {
                        index = j;
                    }

                }
                if (index != brr.Length - 1 - i)
                {
                    int temp = brr[index];
                    brr[index] = brr[brr.Length-1-i];
                    brr[brr.Length-1-i] = temp;
                }
            }
            for (int i = 0; i < brr.Length; i++)
            {
                Console.Write(brr[i] + " ");
            }
            Console.WriteLine();
            #endregion
        }
    }
}