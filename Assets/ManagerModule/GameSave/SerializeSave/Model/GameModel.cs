using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : NormalSingleton<GameModel>
{ 
    public int Life { get; set; }
    public int Score { get; set; }
}
