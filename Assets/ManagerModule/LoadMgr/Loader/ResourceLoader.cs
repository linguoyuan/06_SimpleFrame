using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Object = UnityEngine.Object;

public class ResourceLoader : ILoader
{

    public GameObject LoadPrefab(string path,Transform parent = null)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        GameObject temp = Object.Instantiate(prefab, parent);
        return temp;
    }

    public void Load<T>(string path, Action<Object> complete) where T : Object
    {
        T obj = Resources.Load<T>(path);
        if (obj == null)
        {
            Debug.LogError("未找到对应资源，路径："+path);
        }
        else
        {
            if (complete != null)
            {
                complete(obj);
            }           
        }       
    }

    public T[] LoadAll<T>(string path) where T : Object
    {
        T[] sprites = Resources.LoadAll<T>(path);
        if (sprites == null || sprites.Length == 0)
        {
            Debug.LogError("当前路径下未找到对应资源，路径："+path);
            return null;
        }
        else
        {
            return sprites;
        }
    }

    public void LoadConfig(string path, Action<object> complete)
    {
        CoroutineMgr.Single.ExecuteOnce(Config(path,complete));
    }

    private IEnumerator Config(string path, Action<string> complete)
    {
        if(Application.platform != RuntimePlatform.Android)
            path = "file://" + path;

        UnityWebRequest request = UnityWebRequest.Get(path);
        yield return request.SendWebRequest();

        if (request.error != null)
        {
            Debug.LogError("加载配置错误，路径为："+path);
            yield break;
        }
        Debug.Log("文件加载成功，路径为：" + path);
        if (request.isDone)
        {
            complete(request.downloadHandler.text);
        }               
    }

    public void LoadAsyncPrefab(string path, Action<GameObject> complete, Transform parent = null)
    {
        throw new NotImplementedException();
    }
}
