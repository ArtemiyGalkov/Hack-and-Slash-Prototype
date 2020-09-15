using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public Player Player;
    
    public Inventory Inventory;
    public Parameters Parameters;

    public void UpdateCharacteristics()
    {
        Player.Characteristics.MaxHp = Parameters.MaxHp;
        Player.Characteristics.MaxMp = Parameters.MaxMp;
        Player.Characteristics.Armor = Parameters.Armor;
        Player.Characteristics.AttackSpeed = Parameters.AttackSpeed;
        Player.Characteristics.PhysDamageModificator = Parameters.PhysDamageModificator;
        Player.Characteristics.MagDamageModificator = Parameters.MagDamageMNodificator;
        Player.Characteristics.MoveSpeed = Parameters.MoveSpeed;

        Player.UpdateCharacteristics();
    }

    public string GetGender()
    {
        if (Player.Gender)
        {
            return "Male";
        }
        return "Female";
    }
}
