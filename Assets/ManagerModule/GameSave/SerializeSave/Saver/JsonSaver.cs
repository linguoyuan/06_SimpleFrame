using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System;

public class JsonSaver : ISaver
{
    public void LoadData(string path, Action<GameModel> complete)
    {
        if (File.Exists(path))
        {
            //创建一个StreamReader，用来读取流
            StreamReader sr = new StreamReader(path);
            //将读取到的流赋值给jsonStr
            string jsonStr = sr.ReadToEnd();
            //关闭
            sr.Close();

            //将字符串jsonStr转换为Save对象
            GameModel model = JsonMapper.ToObject<GameModel>(jsonStr);
            complete(model);
        }
        else
        {
           Debug.Log("存档文件不存在");
        }
    }

    public void SaveData(string path, GameModel model)
    {
        string saveJsonStr = "";
        //利用JsonMapper将save对象转换为Json格式的字符串
        if (model != null)
        {
            saveJsonStr = JsonMapper.ToJson(model);
        }
        else
        {
            Debug.Log("model 不能为空");
        }

        //将这个字符串写入到文件中
        //创建一个StreamWriter，并将字符串写入文件中
        StreamWriter sw = new StreamWriter(path);
        sw.Write(saveJsonStr);
        //关闭StreamWriter
        sw.Close();
    }


    /// <summary>
    /// 这里采用JSONObject这个Json解析类更为方便
    /// </summary>
    /// <param name="path"></param>
    /// <param name="jSONObject"></param>
    public void SaveConfigToJson(string path, string saveJsonStr)
    {
        if (!File.Exists(path))
        {
            Debug.Log("文件不存在，创建文件");
            File.Create(path).Dispose();
            //File.Create(path);这里如果直接写，同时连续保存两个文件时会报错system.IO sharing violation on path。文件句柄需要先关闭才能下一个。
        }
        else
        {
            Debug.Log("文件存在");
        }
        //将这个字符串写入到文件中
        //创建一个StreamWriter，并将字符串写入文件中
        StreamWriter sw = new StreamWriter(path);
        sw.Write(saveJsonStr);
        //关闭StreamWriter
        sw.Close();
        Debug.Log("保存成功");
    }
}
