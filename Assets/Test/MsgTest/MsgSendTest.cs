using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgSendTest : MonoBehaviour
{

    void Start()
    {
        GameObject.Find("Button").GetComponent<Button>().onClick.AddListener(TestBtn);
        ConfigMgr.Single.InitConfigData();
    }

    void TestBtn()
    {
        SubMsgMgr.Single.DispatchMsg(MsgEvent.EVENT_Test, "参数1：1", "参数2：2");
    }
}
