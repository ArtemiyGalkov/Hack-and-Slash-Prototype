using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnWeaponHit(Unit attacker, Unit target, float value);

public class WeaponModificator
{
    public string Name;
    public float Value;
    public OnWeaponHit Effect;

    public WeaponModificator(string name, float value, OnWeaponHit effect)
    {
        Name = name;
        Value = value;
        Effect = effect;
    }

    public void Invoke(Unit attacker, Unit target)
    {
        Effect.Invoke(attacker, target, Value);
    }
}

public static class WeaponModificators
{
    public static void ExtraDamage(Unit attacker, Unit target, float value)
    {
        target.ReceiveDamage((int)value);
    }
}
