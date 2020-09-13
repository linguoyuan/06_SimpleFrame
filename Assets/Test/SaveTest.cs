using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveTest : MonoBehaviour
{
    void Start()
    {
        //测试1
        //JsonModelSave();
        StartCoroutine(Test2());
    }

    private IEnumerator Test2()
    {
        //测试2,注意如果是在用安卓平台下要用Application.persistentDataPath，因为后面存文件欧阳那个到了File类
        string path = Path.Combine(Application.persistentDataPath, "UserConfig.json");
        SaverMgr.Single.SaveConfigToJson(path, CreateJson());
        yield return new WaitForSeconds(2);

        string path2 = Path.Combine(Application.persistentDataPath, "UserConfig2.json");
        SaverMgr.Single.SaveConfigToJson(path2, CreateJson2());
    }

    private void JsonModelSave()
    {
        GameModel model = new GameModel
        {
            Life = 5,
            Score = 0
        };
        string path = Path.Combine(Application.persistentDataPath, "GameModel.json");
        SaverMgr.Single.SaveData(path, model);

        SaverMgr.Single.LoadData(path, GetModelData);
    }

    private void GetModelData(GameModel obj)
    {
        Debug.Log("Life:" + obj.Life);
        Debug.Log("Score:" + obj.Score);
    }

    private string CreateJson()
    {
        JSONObject jObject = new JSONObject();
        jObject.AddField("key1", "value1");
        jObject.AddField("key2", false);
        jObject.AddField("key3", 1);
        jObject.AddField("key3", 0.1f);
        //Debug.Log(jObject.ToString());
        return jObject.ToString();
    }

    //Json嵌套
    private string CreateJson2()
    {
        JSONObject jObject = new JSONObject();
        jObject.AddField("key1", "value1");

        JSONObject arrayObject = new JSONObject();
        arrayObject.AddField("key_1", false);
        arrayObject.AddField("key_2", 1);
        arrayObject.AddField("key_3", 0.1f);
        jObject.AddField("key2", arrayObject);

        Debug.Log(jObject.ToString());
        return jObject.ToString();
    }
}
