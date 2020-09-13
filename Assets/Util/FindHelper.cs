using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FindTools
{
    /// <summary>
    /// 通过递归调用，实现在root中递归查找名字等于name的子物体
    /// </summary>
    /// <param name="root"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Transform FindRecursively(this Transform root, string name)
    {
        if (root.name == name) { return root; }
        foreach (Transform child in root)
        {
            Transform t = FindRecursively(child, name);
            if (t != null)
            {
                return t;
            }
        }
        return null;
    }
    public static T FindRecursively<T>(this Transform root, string name) where T : MonoBehaviour
    {
        Transform t = root.transform.FindRecursively(name);
        if (t == null)
        {
            //Debug.LogError(string.Format("root{0}下没有子物体{1}", root.name, name));
            return null;
        }
        T t2 = t.GetComponent<T>();
        if (t2 == null)
        {
            //Debug.LogError(string.Format("root{0}下子物体{1}没有组件", root.name, name));
        }
        else
        {
            return t2;
        }
        return null;
    }

    /// <summary>
    /// 高效查找子物体（递归查找）,建议采用此种方式  
    /// </summary> 
    /// <param name="trans">父物体</param>
    /// <param name="goName">子物体的名称</param>
    /// <returns>找到的相应子物体</returns>
    public static Transform FindChild(Transform trans, string goName)
    {
        Transform child = trans.Find(goName);
        if (child != null)
            return child;

        Transform go = null;
        for (int i = 0; i < trans.childCount; i++)
        {
            child = trans.GetChild(i);
            go = FindChild(child, goName);
            if (go != null)
                return go;
        }
        return null;
    }

    /// <summary>
    /// 查找子物体组件（递归查找子物体组件）  where T : UnityEngine.Object
    /// </summary> 
    /// <param name="trans">父物体</param>
    /// <param name="goName">子物体的名称</param>
    /// <returns>找到的相应子物体</returns>
    public static T FindChild<T>(Transform trans, string goName) where T : UnityEngine.Object
    {
        Transform child = trans.Find(goName);
        if (child != null)
        {
            return child.GetComponent<T>();
        }

        Transform go = null;
        for (int i = 0; i < trans.childCount; i++)
        {
            child = trans.GetChild(i);
            go = FindChild(child, goName);
            if (go != null)
            {
                return go.GetComponent<T>();
            }
        }
        return null;
    }

    /// 方法一 使用随机抽取数组index中的数，填充在新的数组array中，使数组array中的数是随机的
    /// 方法一思路：用一个数组来保存索引号，先随机生成一个数组位置，然后把随机抽取到的位置的索引号取出来，
    ///             并把最后一个索引号复制到当前的数组位置，然后使随机数的上限减一，具体如：先把这100个数放在一个数组内，
    ///             每次随机取一个位置（第一次是1-100，第二次是1-99，...），将该位置的数用最后的数代替。
    /// <summary>
    /// 双数组产生不重复随机数
    /// </summary>
    public static int[] UseDoubleArrayToNonRepeatedRandom(int length, int minValue, int maxValue)
    {
        int seed = Guid.NewGuid().GetHashCode();
        System.Random radom = new System.Random(seed);
        int[] index = new int[length];
        for (int i = 0; i < length; i++)
        {
            index[i] = i + 1;
        }

        int[] array = new int[length]; // 用来保存随机生成的不重复的数 
        int site = length;             // 设置上限 
        int idx;                       // 获取index数组中索引为idx位置的数据，赋给结果数组array的j索引位置
        for (int j = 0; j < length; j++)
        {
            idx = radom.Next(0, site - 1);  // 生成随机索引数
            array[j] = index[idx];          // 在随机索引位置取出一个数，保存到结果数组 
            index[idx] = index[site - 1];   // 作废当前索引位置数据，并用数组的最后一个数据代替之
            site--;                         // 索引位置的上限减一（弃置最后一个数据）
        }
        return array;
    }

    /// <summary>
    /// 将一个数组内容乱序 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="itemArray"></param>
    /// <returns></returns>
    public static T[] GetDisruptedItems<T>(T[] itemArray)
    {
        //生成一个新数组：用于在之上计算和返回
        T[] temp;
        temp = new T[itemArray.Length];
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i] = itemArray[i];
        }

        //打乱数组中元素顺序
        int seed = Guid.NewGuid().GetHashCode();
        System.Random radom = new System.Random(seed);
        for (int i = 0; i < temp.Length; i++)
        {
            int x, y; T t;
            x = radom.Next(0, temp.Length);
            do
            {
                y = radom.Next(0, temp.Length);
            } while (y == x);

            t = temp[x];
            temp[x] = temp[y];
            temp[y] = t;
        }

        return temp;

    }
}

