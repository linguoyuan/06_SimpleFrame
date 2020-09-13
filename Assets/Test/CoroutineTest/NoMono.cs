using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMono
{
    public void Test()
    {
        CoroutineMgr.Single.ExecuteOnce(MyEnumeratorTest());
    }

    IEnumerator MyEnumeratorTest()
    {
        Debug.Log("使用了无mono的脚本启动了协程");
        yield return null;
    }
}

