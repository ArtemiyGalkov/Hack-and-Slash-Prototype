using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hitbox : MonoBehaviour
{
    Attack curAction;

    public event OnHit onCollision;

    public Attack Action
    {
        get
        {
            return curAction;
        }
        set
        {
            if (curAction != null)
                curAction.Hitbox = null;
            curAction = value;
            curAction.Hitbox = this;
        }
    }

    private void FixedUpdate()
    {
        GameObject.Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Unit>(out Unit unit))
        {
            if (curAction.targetAllies && unit.AgroId == curAction.Attacker.AgroId)
            {
                onCollision?.Invoke(unit);
            }

            if (curAction.targetEnemies && unit.AgroId != curAction.Attacker.AgroId)
            {
                onCollision?.Invoke(unit);
            }
        }
    }
}
