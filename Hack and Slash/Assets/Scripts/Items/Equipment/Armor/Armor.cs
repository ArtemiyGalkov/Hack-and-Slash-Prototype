using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Equipment
{
    public ArmorProps Props
    {
        get => base.props as ArmorProps;
        set => base.props = value;
    }

    public Armor(string name, EquipmentTypes type, int id, ArmorProps _props, string meshName) : base(name, type, id, meshName)
    {
        props = _props;
    }
}
