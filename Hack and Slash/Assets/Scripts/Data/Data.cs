using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Data
{
    public static List<Weapon> Weapons = new List<Weapon>();

    public static List<Armor> Armor = new List<Armor>();

    public static List<GameObject> Units = new List<GameObject>();

    static List<NonPlayableCharacter> NPC = new List<NonPlayableCharacter>();

    static Data()
    {
        InitializeData();
    }

    public static void InitializeData()
    {
        InitializeItems();
        InitializeNPC();
    }

    public static void InitializeItems()
    {
        foreach (GameObject equipment in Resources.LoadAll("Equipment/Weapon"))
        {
            WeaponModel model = equipment.gameObject.GetComponent<WeaponModel>();
            //Debug.Log($"{model.name}, {model.type}, {model.id}, {equipment.name}, {model.HitboxName}, {model.MovesetName}");
            Weapons.Add(new Weapon(model.name, model.type, model.id, new WeaponProps(model.Damage, model.BaseAttackSpeed), equipment.name, model.HitboxName, model.MovesetName));
        }
        foreach (TextAsset text in Resources.LoadAll<TextAsset>("Equipment/ArmorModels/Head"))
        {
            //Debug.Log(text.text);
            ArmorModel model = (ArmorModel)JsonUtility.FromJson<ArmorModel>(text.text);
            //Debug.Log($"{model.Name}, {model.Type}, {model.Id}, {model.MeshName}, {model.Gender}");
            Armor.Add(new Armor(model.Name, (EquipmentTypes) Enum.Parse(typeof(EquipmentTypes), model.Type), model.Id, new ArmorProps(model.Armor), model.MeshName));
        }
        foreach (TextAsset text in Resources.LoadAll<TextAsset>("Equipment/ArmorModels/Body"))
        {
            ArmorModel model = (ArmorModel)JsonUtility.FromJson<ArmorModel>(text.text);
            Armor.Add(new Armor(model.Name, (EquipmentTypes)Enum.Parse(typeof(EquipmentTypes), model.Type), model.Id, new ArmorProps(model.Armor), model.MeshName));
        }
        foreach (TextAsset text in Resources.LoadAll<TextAsset>("Equipment/ArmorModels/Legs"))
        {
            ArmorModel model = (ArmorModel)JsonUtility.FromJson<ArmorModel>(text.text);
            Armor.Add(new Armor(model.Name, (EquipmentTypes)Enum.Parse(typeof(EquipmentTypes), model.Type), model.Id, new ArmorProps(model.Armor), model.MeshName));
        }
        foreach (TextAsset text in Resources.LoadAll<TextAsset>("Equipment/ArmorModels/Feet"))
        {
            ArmorModel model = (ArmorModel)JsonUtility.FromJson<ArmorModel>(text.text);
            Armor.Add(new Armor(model.Name, (EquipmentTypes)Enum.Parse(typeof(EquipmentTypes), model.Type), model.Id, new ArmorProps(model.Armor), model.MeshName));
        }
        foreach (TextAsset text in Resources.LoadAll<TextAsset>("Equipment/ArmorModels/Hands"))
        {
            ArmorModel model = (ArmorModel)JsonUtility.FromJson<ArmorModel>(text.text);
            Armor.Add(new Armor(model.Name, (EquipmentTypes)Enum.Parse(typeof(EquipmentTypes), model.Type), model.Id, new ArmorProps(model.Armor), model.MeshName));
        }
    }

    public static void InitializeNPC()
    {
        foreach (GameObject enemy in Resources.LoadAll("NPC/Enemies"))
        {
            Units.Add(enemy);
        }
        foreach (TextAsset text in Resources.LoadAll<TextAsset>("NPC/UnitModels"))
        {
            UnitModel model = UnitModelLoader.LoadUnit(text.text);
            NonPlayableCharacter character = new NonPlayableCharacter(model.Name, model.Characteristics, Data.GetWeapon(model.WeaponName), Data.GetUnit(model.UnitName));
            //Debug.Log(character.Unit.Weapon.Name);
            NPC.Add(character);
        }
    }


    public static Weapon GetWeapon(int id)
    {
        return Weapons.First(w => w.Id == id).Clone<Weapon>();
    }
    public static Weapon GetWeapon(string name)
    {
        return Weapons.First(e => e.Name == name).Clone<Weapon>();
    }
    public static Equipment GetArmor(int id)
    {
        return Armor.First(e => e.Id == id).Clone<Equipment>();
    }
    public static Equipment GetArmor(string name)
    {
        return Armor.First(e => e.Name == name).Clone<Equipment>();
    }
    public static Equipment GetDefaultItem(EquipmentTypes type)
    {
        return Armor.First(e => e.Name == Equipment.DefineEquipType(type)).Clone<Equipment>();
    }
    static Unit GetUnit(string name)
    {
        return Units.First(e => e.GetComponent<Bot>().Name == name).GetComponent<Bot>();
    }

    public static GameObject GetNPC(string name)
    {
        return NPC.First(e => e.Name == name).Unit.gameObject;
    }
}
