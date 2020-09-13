using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

public class LoadTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Resources Loader测试
        // 测试1：注意Loader要设置为ResourceLoader，同时Resources文件夹下要有Bubble这个资源
        //LoadMgr.Single.LoadPrefab("Bubble1", this.transform);
        //测试2
        //string path2 = Path.Combine(Application.streamingAssetsPath, "TestJson/test2.json");
        //string path = Path.Combine(Application.streamingAssetsPath, "TestJson/test.json");
        //LoadMgr.Single.LoadConfig(path2, MyComplete);//如果test2很大，会先得到test
        //LoadMgr.Single.LoadConfig(path, MyComplete);

        //Addressesable测试
        //测试1：用地址加载
        //LoadMgr.Single.LoadPrefab("Assets/Prefabs/Bubble.prefab", this.transform);
        //测试2
        //GameObject obj = LoadMgr.Single.Load<GameObject>("Assets/Prefabs/Bubble.prefab");
        //Instantiate(obj, this.transform);
        //测试3----注意Addressable读取文件，文件不能放在StreamingAssets下
        //string path = "Assets/test.json";
        //LoadMgr.Single.LoadConfig2Async(path, AddrComplete);
        //LoadMgr.Single.LoadConfig(path, AddrComplete);
        //LoadConfig2Async(path);

        //测试4
        //LoadMgr.Single.Load<GameObject>("Assets/Prefabs/Bubble.prefab", AddrComplete2);

        //测试5
    }



    private void MyComplete(object obj)
    {
        if (obj != null)
        {
            String str = (String)(obj);
            Debug.Log(str);
        }
        else
        {
            Debug.Log("obj == null");
        }
    }

    private void AddrComplete(object obj)//addr方式有所不同
    {
        if (obj != null)
        {
            TextAsset temp = (TextAsset)(obj);
            String str = temp.text;
            Debug.Log(str);
        }
        else
        {
            Debug.Log("obj == null");
        }
    }

    private void AddrComplete2(Object obj)//addr方式有所不同
    {
        Debug.Log("11");
        if (obj != null)
        {
            GameObject.Instantiate(obj);
        }   
    }
}
