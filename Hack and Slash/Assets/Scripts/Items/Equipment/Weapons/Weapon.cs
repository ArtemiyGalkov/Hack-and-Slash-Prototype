using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Equipment
{
    public Hitbox Hitbox;
    public MoveSet MoveSet;
    //public string MoveSetType;

    public Weapon(string name, EquipmentTypes type, int id, WeaponProps _props, string meshName, string hitboxType, string movesetType) : base(name, type, id, meshName)
    {
        Hitbox = ((GameObject)Resources.Load($"Equipment/Hitboxes/{hitboxType}")).GetComponent<Hitbox>();
        //Mesh = ((GameObject)Resources.Load($"Equipment/Weapons/Meshes/{meshName}")).GetComponent<SkinnedMeshRenderer>();
        MoveSet = new MoveSet();
        //MoveSet.AnimatorOverride = (AnimatorOverrideController)Resources.Load($"Equipment/MoveSets/Female/{movesetType}");
        MoveSet.MovesetType = movesetType;
        props = _props;
    }

    public WeaponProps Props 
    { 
        get => base.props as WeaponProps; 
        set => base.props = value; 
    }

    public static void ChangeWeapon(Character character, Weapon weapon)
    {
        if (weapon == null)
            return;

        ChangeWeaponMoveSet(character, weapon);
        ChangeWeaponMesh(character, weapon);
    }
    public static void ChangeWeaponMoveSet(Character character, Weapon weapon)
    {
        character.Player.GetComponent<Animator>().runtimeAnimatorController = Weapon.GetMoveset(character, weapon); ;
    }
    public static AnimatorOverrideController GetMoveset(Character character, Weapon weapon)
    {
        AnimatorOverrideController moveset = (AnimatorOverrideController)Resources.Load($"Equipment/MoveSets/{character.GetGender()}/{weapon.MoveSet.MovesetType}");
        return moveset;
    }
    public static void ChangeWeaponMesh(Character character, Weapon weapon)
    {
        if (character.Inventory.Weapon != null)
            GameObject.Destroy(Helper.FindEquipmentOfType<SkinnedMeshRenderer>(character.Player.gameObject.transform.Find("Eyes").gameObject, weapon.Type).gameObject);

        character.Inventory.Weapon = null;
        
        EquipItem(character.Inventory, weapon);
    }

    public static int CountHitDamage(Unit attacker, Unit defender)
    {
        float damage = (float)(attacker.Weapon.Props.Damage * attacker.Characteristics.PhysDamageModificator);


        if (defender.Characteristics.Armor < 1)
            return (int)damage;

        float ArmorToDamage = (float)defender.Characteristics.Armor / damage;

        float reduction = Mathf.Pow(ArmorToDamage, 1.0f / 3.0f);

        /*Debug.Log($"{attacker.Weapon.Props.Damage} * {attacker.Characteristics.PhysDamageModificator} = {damage}");
        Debug.Log($"({defender.Characteristics.Armor} / {damage})^1/3 = {reduction}");
        Debug.Log($"{damage} / {reduction} = {(int)(damage / reduction)}");*/

        if (reduction <= 1)
            return (int)damage;


        return (int)(damage / reduction);
    }
}
