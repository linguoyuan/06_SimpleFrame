using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

public class AddrLoader : ILoader
{
    public async void Load<T>(string path, Action<Object> complete) where T : UnityEngine.Object
    {
        T obj = await Addressables.LoadAssetAsync<T>(path).Task;
        complete(obj);
    }

    /// <summary>
    /// 这种形式通常用于已经命名了标签的资产
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
    public T[] LoadAll<T>(string path) where T : UnityEngine.Object
    {
        throw new NotImplementedException();
    }

    public async void LoadConfig(string path, Action<object> complete)
    {
        object obj = await Addressables.LoadAssetAsync<object>(path).Task;
        complete(obj);
    }

    /// <summary>
    /// 加载并实例化
    /// </summary>
    /// <param name="path"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public GameObject LoadPrefab(string path, Transform parent = null)
    {
        GameObject temp = Addressables.InstantiateAsync(path, parent).Result;
        return temp;
    }
}
