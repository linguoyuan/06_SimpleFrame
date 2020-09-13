/*
 * 这里所有的数据都只是作为示例，使用时按需设计
 * 这里采用消息事件的方式告诉外界配置数据加载好了 
 * 注意：Addressables加载的配置文件不能放在StreamingAssets文件夹目录
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public struct string3
{
    public string name;

    public string aduioPath;
    public string picPath;

    public string3(string _name, string _aduioPath, string _picPath)
    {
        name = _name;
        aduioPath = _aduioPath;
        picPath = "Assets" + _picPath;
    }
}

public class ConfigMgr : MonoSingleton<ConfigMgr>
{
    public List<string3> colorNames;
    //同一颜色索引
    public Dictionary<string, List<string>> colorFoodList;
    public List<string> numAudios;
    public void InitConfigData()
    {
        colorNames = new List<string3>();
        colorFoodList = new Dictionary<string, List<string>>();
        numAudios = new List<string>();
        Debug.Log("开始加载配置数据");
        GetBaseDataFromFile();
    }

    async void GetBaseDataFromFile()
    {
        //说明这里可以框架里的Loader去加载的，但是因为用Addressables方式，加载代码比较少，这里就直接写了
        TextAsset content = await Addressables.LoadAssetAsync<TextAsset>("Assets/ConfigData.json").Task;
        JSONObject js = JSONObject.Create(content.text);

        JSONObject nowFiled;
        //颜色
        nowFiled = js.GetField("color");
        for (int i = 0; i < nowFiled.list.Count; i++)
        {
            string3 _str3 = new string3(nowFiled.list[i].GetField("name").str, nowFiled.list[i].GetField("audio").str, nowFiled.list[i].GetField("pic").str);
            colorNames.Add(_str3);

            colorFoodList.Add(_str3.name, new List<string>());
        }
        //数字
        nowFiled = js.GetField("nums");
        for (int i = 0; i < nowFiled.list.Count; i++)
        {
            numAudios.Add(nowFiled.list[i].str);
        }


        //如果这里还有配置文件需要加载，在这里调用
        //最后一个加载完的配置文件分发加载完事件消息
        SubMsgMgr.Single.DispatchMsg(MsgEvent.EVENT_ConfigInitDone);
    }
}
