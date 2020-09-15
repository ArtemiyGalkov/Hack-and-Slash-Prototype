using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : GameAction
{
    public Hitbox Hitbox;

    public Unit Attacker;

    public Attack(Unit attacker)
    {
        targetEnemies = true;
        targetAllies = false;
        Attacker = attacker;
        Hitbox = GameObject.Instantiate(Attacker.Weapon.Hitbox, Attacker.gameObject.transform);
        Hitbox.Action = this;
        Hitbox.onCollision += delegate (Unit target) { Attacker.Hit(target); };
    }
}
