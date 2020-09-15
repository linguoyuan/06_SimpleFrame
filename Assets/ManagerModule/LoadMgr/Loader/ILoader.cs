using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public interface ILoader
{
    GameObject LoadPrefab(string path, Transform parent = null);
    void LoadAsyncPrefab(string path, Action<GameObject> complete, Transform parent = null);
    void LoadConfig(string path, Action<object> complete);
    void Load<T>(string path, Action<Object> complete) where T : UnityEngine.Object;
    T[] LoadAll<T>(string path) where T : UnityEngine.Object;
}
