using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class JsonCreateSample : MonoBehaviour
{
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

    //Json嵌套----JSONObject
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

    //构建Json------litjson
    private string LitJsonCreateJson()
    {
        JsonData jsonData = new JsonData();
        jsonData["keyA"] = "a";
        jsonData["keyB"] = "b";
        jsonData["keyC"] = "c";
        Debug.Log("5:" + jsonData.ToJson());
        return jsonData.ToJson();
    }

    //Json嵌套Json------litjson
    private string LitJsonCreateJsonJson()
    {
        JsonData jsonData = new JsonData();
        jsonData["keyA"] = "a";
        jsonData["keyB"] = "b";
        jsonData["keyC"] = "c";

        JsonData jsonFather = new JsonData();
        jsonFather["fatherKey"] = jsonData;

        Debug.Log("6:" + jsonFather.ToJson());
        return jsonFather.ToJson();
    }

    //Json嵌套数组-------用litjson方式构造，暂时不清楚用JSONObject如何构造数组
    private string CreateJson3()
    {
        JsonData jsondata = new JsonData();
        jsondata["Array"] = new JsonData();
        jsondata["Array"].SetJsonType(JsonType.Array);
        jsondata["Array"].Add(0);//第一种方式添加数组内容
        jsondata["Array"][0] = "a";
        jsondata["Array"].Add(1);
        jsondata["Array"][1] = "b";
        jsondata["Array"].Add(2);
        jsondata["Array"][2] = "c";

        jsondata["Array"].Add("d");//第二种方式添加
        jsondata["Array"].Add("e");
        jsondata["Array"].Add("f");
        string json = jsondata.ToJson();
        Debug.Log(json);
        return json;
    }

    //数组嵌套Json------litjson
    private string CreateJson4()
    {
        JsonData jsonData = new JsonData();
        jsonData.SetJsonType(JsonType.Array);
        JsonData jsonA = new JsonData();
        jsonA["keyA"] = "a";
        jsonA["keyB"] = "b";
        jsonA["keyC"] = "c";
        jsonData.Add(jsonA);
        string json = jsonData.ToJson();
        Debug.Log(json);
        return json;
    }
}
