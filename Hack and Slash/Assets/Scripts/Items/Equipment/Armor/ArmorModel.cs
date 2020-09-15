using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
class ArmorModel
{
    public string Type;
    public int Id;
    public string Name;
    public int Armor;
    public string MeshName;
    public int Gender;

    public ArmorModel() { }

    public ArmorModel(string type, int id, string name, int armor, string meshName)
    {
        Type = type;
        Id = id;
        Name = name;
        Armor = armor;
        MeshName = meshName;
    }
}
