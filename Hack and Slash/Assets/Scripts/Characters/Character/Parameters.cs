using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ParameterTypes
{
    baseHp,
    modHp,
    baseMp,
    modMp,
    baseArm,
    modArm,
    baseAS,
    modAS,
    physDmg,
    magDmg,
    moveBase,
    moveMod
}
public class Parameters
{
    public int MaxHp 
    {
        get
        {
            return (int)(baseHp * (100 + HpModificator) / 100);
        }
    }
    public int MaxMp
    {
        get
        {
            return (int)(baseMp * (100 + MpModificator) / 100);
        }
    }
    public int Armor
    {
        get
        {
            return (int)(baseArmor * (100 + ArmorModificator) / 100);
        }
    }
    public float AttackSpeed
    {
        get
        {
            return (baseAttackSpeed * (100 + attackSpeed) / 100);
        }
    }    
    public float PhysDamageModificator
    {
        get
        {
            return (100 + physDamageModificator) / 100;
        }
    }
    public float MagDamageMNodificator
    {
        get
        {
            return (100 + magDamageModificator) / 100;
        }
    }
    public float MoveSpeed
    {
        get
        {
            return moveSpeedBase * (100 + moveSpeedModificator) / 100;
        }
    }

    public float baseHp;
    public float HpModificator;

    public float baseMp;
    public float MpModificator;

    public float baseArmor;
    public float ArmorModificator;

    public float baseAttackSpeed;
    public float attackSpeed;

    //public float attackDamageIncrease;

    public float physDamageModificator;
    public float magDamageModificator;

    public float moveSpeedBase;
    public float moveSpeedModificator;

    public Parameters()
    {
        baseHp = 100;
        HpModificator = 0;

        baseMp = 0;
        MpModificator = 0;

        baseArmor = 0;
        ArmorModificator = 0;

        baseAttackSpeed = 1;
        attackSpeed = 0;

        physDamageModificator = 0;
        magDamageModificator = 0;

        moveSpeedBase = 5;
        moveSpeedModificator = 0;
    }

    public static void AddParametrModificator(Parameters Parameters, ParameterModificator modificator, bool Increase)
    {
        if (!Increase)
            modificator.Value *= -1;
        switch (modificator.Type)
        {
            case ParameterTypes.baseHp:
                {
                    Parameters.baseHp += modificator.Value;
                    break;
                }
            case ParameterTypes.modHp:
                {
                    Parameters.HpModificator += modificator.Value;
                    break;
                }
            case ParameterTypes.baseMp:
                {
                    Parameters.baseMp += modificator.Value;
                    break;
                }
            case ParameterTypes.modMp:
                {
                    Parameters.MpModificator += modificator.Value;
                    break;
                }
            case ParameterTypes.baseArm:
                {
                    Parameters.baseArmor += modificator.Value;
                    break;
                }
            case ParameterTypes.modArm:
                {
                    Parameters.ArmorModificator += modificator.Value;
                    break;
                }
            case ParameterTypes.baseAS:
                {
                    Parameters.baseAttackSpeed += modificator.Value;
                    break;
                }
            case ParameterTypes.modAS:
                {
                    Parameters.attackSpeed += modificator.Value;
                    break;
                }
            case ParameterTypes.physDmg:
                {
                    Parameters.physDamageModificator += modificator.Value;
                    break;
                }
            case ParameterTypes.magDmg:
                {
                    Parameters.magDamageModificator += modificator.Value;
                    break;
                }
            case ParameterTypes.moveBase:
                {
                    Parameters.moveSpeedBase += modificator.Value;
                    break;
                }
            case ParameterTypes.moveMod:
                {
                    Parameters.moveSpeedModificator += modificator.Value;
                    break;
                }
        }
    }
}
