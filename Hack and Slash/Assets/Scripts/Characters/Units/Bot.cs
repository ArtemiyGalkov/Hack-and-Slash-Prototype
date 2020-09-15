using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : Unit
{
    public GameObject Player;

    public NonPlayableCharacter Character;

    public override Weapon Weapon
    {
        get
        {
            return Character.Weapon;
        }
    }

    void Update()
    {
        Logic();
    }

    public virtual void Start()
    {
        //Character = new NonPlayableCharacter(new UnitCharacteristics(0,0,0,0,0,0,0), Data.GetWeapon(0), this);
        UpdateCharacteristics();
        Status = new Status();
    }

    public void Logic()
    {
        if (Vector3.Distance(gameObject.transform.position, Player.transform.position) > AttackDistance)
        {
            if (!inMovement && !inAttack)
                StartMoving();
        }
        else
        {
            if (inMovement)
            {
                StopMoving(true);
            }
            else
            {
                EnemyAttack();
            }
        }

        if (inMovement)
        {
            MoveTowards(Player.transform.position);
        }
    }
    
    public void EnemyAttack()
    {
        if (!inAttack)
        {
            RotateTowardsPoint(Player.transform.position);
            Attack();
        }
    }

    public override void Hit()
    {
        Attack attack = new Attack(this);
    }

    public override void Hit(Unit unit)
    {
        unit.ReceiveDamage(Weapon.CountHitDamage(this, unit));
    }
}
