using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnitModel
{
    public string Name;
    public UnitCharacteristics Characteristics;
    public string WeaponName;
    public string UnitName;

    public UnitModel(string name, UnitCharacteristics characteristics, string weaponName, string unitName)
    {
        Name = name;
        Characteristics = characteristics;
        WeaponName = weaponName;
        UnitName = unitName;
    }
}
