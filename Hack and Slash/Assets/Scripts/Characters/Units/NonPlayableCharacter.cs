using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayableCharacter
{
    public string Name;
    public UnitCharacteristics Characteristics;
    public Weapon Weapon;

    public Bot Unit;

    public NonPlayableCharacter(string name, UnitCharacteristics characteristics, Weapon weapon, Unit unit)
    {
        Name = name;
        Characteristics = characteristics;
        Weapon = weapon;
        Unit = (Bot)unit;
        Unit.Characteristics = Characteristics;
        Unit.Character = this;

        //Unit.UpdateCharacteristics();
    }
    /*public NonPlayableCharacter(UnitCharacteristics characteristics, Weapon weapon, string unitName)
    {
        Characteristics = characteristics;
        Weapon = weapon;
        Unit = (Bot)Data.GetUnit(unitName);
        Unit.Characteristics = Characteristics;
    }*/
}
