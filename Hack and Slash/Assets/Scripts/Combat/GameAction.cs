using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnHit(Unit unit);

public class GameAction
{
    public bool targetEnemies;
    public bool targetAllies;

    public GameAction()
    {        
    }
}
