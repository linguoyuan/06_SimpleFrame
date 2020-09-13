using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgReceiveTest : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake");
    }

    void Start()
    {
        Debug.Log("Start");
        SubMsgMgr.Single.AddListener(MsgEvent.EVENT_Test, TestBtnReceive);
        SubMsgMgr.Single.AddListener(MsgEvent.EVENT_Test, TestBtnReceive2);
        SubMsgMgr.Single.AddListener(MsgEvent.EVENT_ConfigInitDone, ConfigDone);
    }

    private void TestBtnReceive(object[] obj)
    {
        Debug.Log("接收者1收到了消息：");
        for (int i = 0; i < obj.Length; i++)
        {
            Debug.Log(obj[i]);
        }
    }

    private void TestBtnReceive2(object[] obj)
    {
        Debug.Log("接收者2收到了消息：");
        for (int i = 0; i < obj.Length; i++)
        {
            Debug.Log(obj[i]);
        }
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy");

        //由于程序退出时脚本对象时随机销毁的，这里的事件注销要注意在程序退出提前注销，在OnDestroy时退出是有可能报错的
        //SubMsgMgr.Single.RemoveListener(MsgEvent.EVENT_Test, TestBtnReceive);
        //SubMsgMgr.Single.RemoveListener(MsgEvent.EVENT_Test, TestBtnReceive2);
        //SubMsgMgr.Single.RemoveListener(MsgEvent.EVENT_ConfigInitDone, ConfigDone);
    }

    private void ConfigDone(object[] obj)
    {
        Debug.Log("配置数据加载完毕");
        Debug.Log("食物数量：" + ConfigMgr.Single.colorFoodList.Count);
    }
}
