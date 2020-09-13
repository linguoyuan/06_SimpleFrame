using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class LoadMgr : NormalSingleton<LoadMgr>,ILoader
{
	[SerializeField]
	private ILoader _loader;

	public LoadMgr()
	{
		//_loader  = new ResourceLoader();
		_loader  = new AddrLoader();
	}

	public GameObject LoadPrefab(string path, Transform parent = null)
	{
		return _loader.LoadPrefab(path, parent);
	}

	public void LoadConfig(string path, Action<object> complete)
	{
		_loader.LoadConfig(path,complete);
	}

	public void Load<T>(string path, Action<Object> complete) where T : Object
	{
		_loader.Load<T>(path, complete);
	}

	public T[] LoadAll<T>(string path) where T : Object
	{
		return _loader.LoadAll<T>(path);
	}
}
