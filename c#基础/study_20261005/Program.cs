using System;

namespace study_20261005
{

    //就是这里
    enum E_MonsterType
    {
        Normal,
        Boss,
        Elite,
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region 枚举
            //语法： enum E_枚举名 : 基础类型 { 枚举值1, 枚举值2, ... }
            //在哪里声明：一般在namespace里
            //不能再函数语句块声明

            //枚举的使用
            E_MonsterType monsterType = E_MonsterType.Boss;
            if (monsterType == E_MonsterType.Boss)
            {
                Console.WriteLine("这是一个Boss怪物");
            }
            else if (monsterType == E_MonsterType.Elite)
            {
                Console.WriteLine("这是一个精英怪物");
            }
            else
            {
                Console.WriteLine("这是一个普通怪物");
            }

            //枚举和switch天生一对
            switch (monsterType)
            {
                case E_MonsterType.Boss:
                    Console.WriteLine("这是一个Boss怪物");
                    break;
                case E_MonsterType.Elite:
                    Console.WriteLine("这是一个精英怪物");
                    break;
                default:
                    Console.WriteLine("这是一个普通怪物");
                    break;
            }

            //枚举的类型转化
            int monsterTypeValue = (int)monsterType;
            Console.WriteLine(monsterTypeValue);
            string monsterTypeName = monsterType.ToString();
            Console.WriteLine(monsterTypeName);
            //string转枚举
            E_MonsterType monsterType2 = (E_MonsterType)Enum.Parse(typeof(E_MonsterType), "Boss");
            Console.WriteLine(monsterType2);
            #endregion

            #region 数组

            //声明
            int[] arr1;
            int[] arr2 = new int[5];
            int[] arr3 = new int[5] { 1, 2, 3, 4, 5 };
            int[] arr4 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] arr5 = { 1, 2, 3, 4, 5 };//感觉这个最方便

            //增加数据的元素
            //数组的长度是固定的，不能直接增加元素
            //但是可以通过创建一个新的数组来实现增加元素的效果
            int[] temp = new int[6];
            for(int i=0;i<arr5.Length;i++)
            {
                temp[i] = arr5[i];
            }
            arr5 = temp;
            Console.WriteLine("*****************************************");
            for(int i=0;i<arr5.Length;i++)
            {
                Console.WriteLine(arr5[i]);
            }

            //删除数组的元素
            //数组的长度是固定的，不能直接删除元素
            //但是可以通过创建一个新的数组来实现删除元素的效果
            int[] temp2 = new int[arr5.Length - 1];
            for(int i=0;i<temp2.Length;i++)
            {
                temp2[i] = arr5[i];
            }
            arr5 = temp2;
            Console.WriteLine("*****************************************");
            for (int i = 0; i < arr5.Length; i++)
            {
                Console.WriteLine(arr5[i]);
            }

            //查找数组中的元素
            for (int i = 0; i < arr5.Length; i++)
            {
                if (arr5[i] == 3)
                {
                    Console.WriteLine("找到了3");
                    break;
                }
            }

            #endregion
        }
    }
}