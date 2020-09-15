using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public Character Character;

    public Weapon Weapon;
    public Weapon Offhand;

    public Equipment Head;
    public Equipment Body;
    public Equipment Hands;
    public Equipment Legs;
    public Equipment Feet;

    public List<Item> Items = new List<Item>();

    public void InitializeEquipment()
    {
        if (Head != null)
            ChangeArmor(Head);
        else
            Equipment.EquipDefaultItem(this, EquipmentTypes.Head);

        if (Body != null)
            ChangeArmor(Body);
        else
            Equipment.EquipDefaultItem(this, EquipmentTypes.Body);

        if (Hands != null)
            ChangeArmor(Hands);
        else
            Equipment.EquipDefaultItem(this, EquipmentTypes.Hands);

        if (Legs != null)
            ChangeArmor(Legs);
        else
            Equipment.EquipDefaultItem(this, EquipmentTypes.Legs);

        if (Feet != null)
            ChangeArmor(Feet);
        else
            Equipment.EquipDefaultItem(this, EquipmentTypes.Feet);
    }

    public void ChangeWeapon(Weapon weapon)
    {
        if (GetEquipmentSlot(weapon.Type) != null)
            Items.Add(GetEquipmentSlot(weapon.Type));

        Items.Remove(weapon);

        Weapon.ChangeWeapon(Character, weapon);
        Weapon = weapon;
        //Character.Player.Weapon = weapon;
    }

    public void ChangeArmor(Equipment equipment)
    {
        if (GetEquipmentSlot(equipment.Type) != null)
            Items.Add(GetEquipmentSlot(equipment.Type));

        Items.Remove(equipment);

        EquipmentTypes _type = equipment.Type;

        //string type = Equipment.DefineEquipType(_type);

        Equipment slot = GetEquipmentSlot(_type);

        Equipment.UnequipItem(this, _type);
        Equipment.EquipItem(this, equipment);

        SetEquipment(equipment);
    }

    public void Unequip(EquipmentTypes type)
    {
        Items.Add(GetEquipmentSlot(type));

        /*EquipmentTypes _type = equipment.Type;

        Equipment slot = GetEquipmentSlot(_type);*/

        Equipment.UnequipItem(this, type);

        Equipment.EquipDefaultItem(Character.Inventory, type);

        ResetEquipment(type);
    }


    public void ResetArmor(Armor armor)
    {
        Character.Parameters.baseArmor -= armor.Props.Armor;
        Character.UpdateCharacteristics();
    }

    public void SetArmor(Armor armor)
    {
        Character.Parameters.baseArmor += armor.Props.Armor;
        Character.UpdateCharacteristics();
    }

    void SetEquipment(Equipment equipment)
    {
        switch (equipment.Type)
        {
            case EquipmentTypes.Head:
                {
                    Head = equipment;
                    return;
                }
            case EquipmentTypes.Body:
                {
                    Body = equipment;
                    return;
                }
            case EquipmentTypes.Hands:
                {
                    Hands = equipment;
                    return;
                }
            case EquipmentTypes.Legs:
                {
                    Legs = equipment;
                    return;
                }
            case EquipmentTypes.Feet:
                {
                    Feet = equipment;
                    return;
                }
            case EquipmentTypes.Weapon:
                {
                    Weapon = (Weapon)equipment;
                    return;
                }
            case EquipmentTypes.Offhand:
                {
                    Offhand = (Weapon)equipment;
                    return;
                }
        }
    }

    void ResetEquipment(EquipmentTypes type)
    {
        switch (type)
        {
            case EquipmentTypes.Head:
                {
                    Head = null;
                    return;
                }
            case EquipmentTypes.Body:
                {
                    Body = null;
                    return;
                }
            case EquipmentTypes.Hands:
                {
                    Hands = null;
                    return;
                }
            case EquipmentTypes.Legs:
                {
                    Legs = null;
                    return;
                }
            case EquipmentTypes.Feet:
                {
                    Feet = null;
                    return;
                }
            case EquipmentTypes.Weapon:
                {
                    Weapon = null;
                    return;
                }
            case EquipmentTypes.Offhand:
                {
                    Offhand = null;
                    return;
                }
        }
    }

    public Equipment GetEquipmentSlot(EquipmentTypes type)
    {
        switch (type)
        {
            case EquipmentTypes.Head:
                {
                    return this.Head;
                }
            case EquipmentTypes.Body:
                {
                    return this.Body;
                }
            case EquipmentTypes.Hands:
                {
                    return this.Hands;
                }
            case EquipmentTypes.Legs:
                {
                    return this.Legs;
                }
            case EquipmentTypes.Feet:
                {
                    return this.Feet;
                }
            case EquipmentTypes.Weapon:
                {
                    return this.Weapon;
                }
            case EquipmentTypes.Offhand:
                {
                    return this.Offhand;
                }
        }

        return null;
    }
}
