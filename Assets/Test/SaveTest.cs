using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveTest : MonoBehaviour
{
    void Start()
    {
        GameModel model = new GameModel
        {
            Life = 5,
            Score = 0
        };
        string path = Path.Combine(Application.persistentDataPath, "GameModel.json");
        SaverMgr.Single.SaveData(path, model);

        SaverMgr.Single.LoadData(path, GetModelData);

    }

    private void GetModelData(GameModel obj)
    {
        Debug.Log("Life:" + obj.Life);
        Debug.Log("Score:" + obj.Score);
    }
}
