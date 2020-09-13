using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgReceiveTest : MonoBehaviour
{
    private void Awake()
    {
        SubMsgMgr.Single.AddListener(MsgEvent.EVENT_Test, TestBtnReceive);
        SubMsgMgr.Single.AddListener(MsgEvent.EVENT_Test, TestBtnReceive2);
    }

    void Start()
    {

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

    private void OnDestroy()
    {
        SubMsgMgr.Single.RemoveListener(MsgEvent.EVENT_Test, TestBtnReceive);
        SubMsgMgr.Single.RemoveListener(MsgEvent.EVENT_Test, TestBtnReceive2);
    }

}
