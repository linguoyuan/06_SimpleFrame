using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaver
{
    void LoadData(string path, Action<GameModel> complete);
    void SaveData(string path, GameModel model);
}
