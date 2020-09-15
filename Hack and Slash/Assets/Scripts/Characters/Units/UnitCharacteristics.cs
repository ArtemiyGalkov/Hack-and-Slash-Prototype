using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnitCharacteristics
{
    public int MaxHp;
    public int MaxMp;
    public int Armor;
    public float AttackSpeed;
    public float PhysDamageModificator;
    public float MagDamageModificator;
    public float MoveSpeed;

    public UnitCharacteristics(int maxHp, int maxMp, int armor, float attackSpeed, float physDamageModificator, float magDamageMNodificator, float moveSpeed)
    {
        MaxHp = maxHp;
        MaxMp = maxMp;
        Armor = armor;
        AttackSpeed = attackSpeed;
        PhysDamageModificator = physDamageModificator;
        MagDamageModificator = magDamageMNodificator;
        MoveSpeed = moveSpeed;
    }
}
