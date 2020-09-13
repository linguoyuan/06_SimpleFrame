using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaverMgr : NormalSingleton<SaverMgr>, ISaver
{
    private ISaver _saver;

    public SaverMgr()
    {
        _saver = new JsonSaver();
    }

    public void LoadData(string path, Action<GameModel> complete)
    {
        _saver.LoadData(path, complete);
    }

    public void SaveData(string path, GameModel model)
    {
       _saver.SaveData(path, model);
    }
}
