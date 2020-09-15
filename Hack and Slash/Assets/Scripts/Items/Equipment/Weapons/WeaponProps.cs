using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProps : EquipmentProps
{
    public float Damage;
    public float BaseAttackSpeed;

    public List<WeaponModificator> HitEffects = new List<WeaponModificator>();

    public WeaponProps(float damage, float baseAttackSpeed)
    {
        Damage = damage;
        BaseAttackSpeed = baseAttackSpeed;
    }
}
