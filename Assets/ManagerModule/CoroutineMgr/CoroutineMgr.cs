﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineMgr : MonoSingleton<CoroutineMgr>
{

	private Dictionary<int, CoroutineController> _controllersDic;

	public CoroutineMgr()
	{
		_controllersDic = new Dictionary<int, CoroutineController>();
	}

	public int Execute(IEnumerator routine,bool autoStart = true)
	{
		CoroutineController controller = new CoroutineController(this,routine);

		_controllersDic.Add(controller.ID,controller);
		if (autoStart)
			StartExecute(controller.ID);
		
		return controller.ID;
	}
	
	public void ExecuteOnce(IEnumerator routine)
	{
		CoroutineController controller = new CoroutineController(this,routine);
		controller.Start();
	}

	public void Restart(int id)
	{
		var controller = GetController(id);
		
		if(controller != null)
			controller.ReStart();
	}

	public void StartExecute(int id)
	{
		var controller = GetController(id);
		
		if(controller != null)
			controller.Start();
	}
	
	public void Pause(int id)
	{
		var controller = GetController(id);
		
		if(controller != null)
			controller.Pause();
	}
	
	public void Stop(int id)
	{
		var controller = GetController(id);
		
		if(controller != null)
			controller.Stop();
	}
	
	public void Continue(int id)
	{
		var controller = GetController(id);
		
		if(controller != null)
			controller.Continue();
	}

	private CoroutineController GetController(int id)
	{
		if (_controllersDic.ContainsKey(id))
		{
			return _controllersDic[id];
		}
		else
		{
			Debug.LogError("当前id不存在，id:"+id);
			return null;
		}
	}
}
