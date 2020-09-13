using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMsgMgr : MonoSingleton<SubMsgMgr>,IMessageSystem
{
    private MessageSystem _msgSystem;
    public SubMsgMgr()
    {
        _msgSystem = new MessageSystem();
    }
    
	public void AddListener(int key, Action<object[]> callback)
	{
		_msgSystem.AddListener(key, callback);
	}

	public void RemoveListener(int key, Action<object[]> callback)
	{
		_msgSystem.RemoveListener(key, callback);
	}

	public void DispatchMsg(int key, params object[] args)
	{
		_msgSystem.DispatchMsg(key, args);
	}

	public void AddListener(string key, Action<object[]> callback)
	{
		_msgSystem.AddListener(key, callback);
	}

	public void RemoveListener(string key, Action<object[]> callback)
	{
		_msgSystem.RemoveListener(key, callback);
	}

	public void DispatchMsg(string key, params object[] args)
	{
		_msgSystem.DispatchMsg(key, args);
	}
}
