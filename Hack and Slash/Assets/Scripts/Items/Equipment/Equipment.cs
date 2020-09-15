using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentTypes
{
    Head,
    Body,
    Hands,
    Legs,
    Feet,
    Weapon,
    Offhand
}

public class Equipment : Item
{
    //public SkinnedMeshRenderer Mesh;
    public string MeshName;
    public EquipmentTypes Type;

    //public virtual EquipmentProps Props { get; set; }

    public EquipmentProps props;

    public Equipment(string name, EquipmentTypes type, int id, string meshName) : base(name, id)
    {
        Type = type;
        //Debug.Log($"Equipment/{DefineEquipType(type)}/{meshName}");
        //Mesh = ((GameObject)Resources.Load($"Equipment/{DefineEquipType(type)}/{meshName}")).GetComponent<SkinnedMeshRenderer>();
        MeshName = meshName;
    }

    public static void EquipItem(Inventory inventory, Equipment equipment)
    {
        if (equipment is Armor)
        {
            inventory.SetArmor((Armor)equipment);
        }
        
        SkinnedMeshRenderer newMesh = MonoBehaviour.Instantiate<SkinnedMeshRenderer>(Equipment.GetMesh(equipment, ActionManager.Manager.Player.Character));
        var targetMesh = inventory.Character.Player.transform.Find("Eyes").GetComponent<SkinnedMeshRenderer>();

        newMesh.transform.parent = targetMesh.transform;

        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;

        if (newMesh.TryGetComponent<ShowBody>(out ShowBody show))
        {
            SkinnedMeshRenderer bodyMesh = MonoBehaviour.Instantiate<SkinnedMeshRenderer>(Equipment.GetMesh(Data.GetDefaultItem(equipment.Type), ActionManager.Manager.Player.Character));
            targetMesh = newMesh;

            bodyMesh.transform.parent = targetMesh.transform;

            bodyMesh.bones = targetMesh.bones;
            bodyMesh.rootBone = targetMesh.rootBone;
        }
    }

    public static void UnequipItem(Inventory inventory, EquipmentTypes type)
    {
        if (inventory.GetEquipmentSlot(type) is Armor)
        {
            inventory.ResetArmor((Armor)inventory.GetEquipmentSlot(type));
        }

        /*Debug.Log(inventory.Character.Player.gameObject.transform.Find("Eyes").gameObject.name);
        Debug.Log(type);
        Debug.Log(Helper.FindEquipmentOfType<SkinnedMeshRenderer>(inventory.Character.Player.gameObject.transform.Find("Eyes").gameObject, type).gameObject.name);*/
        //GameObject.Destroy(Helper.FindEquipmentOfType<SkinnedMeshRenderer>(inventory.Character.Player.gameObject.transform.Find("Eyes").gameObject, type).gameObject);
        GameObject.Destroy(Helper.FindComponentInChildWithTag<SkinnedMeshRenderer>(inventory.Character.Player.gameObject.transform.Find("Eyes").gameObject, Equipment.DefineEquipType(type)).gameObject);
    }

    public static void EquipDefaultItem(Inventory inventory, EquipmentTypes type)
    {
        if ((int)type > 4)
        {
            return;
        }

        Equipment equipment = Data.GetDefaultItem(type);

        Equipment.EquipItem(inventory, equipment);
    }

    /*public static void Disarm(Inventory inventory)
    {
        
    }*/

    public static string DefineEquipType(EquipmentTypes _type)
    {
        string type = "";

        switch (_type)
        {
            case EquipmentTypes.Head:
                {
                    type = "Head";
                    break;
                }
            case EquipmentTypes.Body:
                {
                    type = "Body";
                    break;
                }
            case EquipmentTypes.Hands:
                {
                    type = "Hands";
                    break;
                }
            case EquipmentTypes.Legs:
                {
                    type = "Legs";
                    break;
                }
            case EquipmentTypes.Feet:
                {
                    type = "Feet";
                    break;
                }
            case EquipmentTypes.Weapon:
                {
                    type = "Weapon";
                    break;
                }
            case EquipmentTypes.Offhand:
                {
                    type = "Offhand";
                    break;
                }
        }

        return type;
    }
    public static SkinnedMeshRenderer GetMesh(Equipment equipment, Character character)
    {
        if (equipment is Armor)
        {
            Debug.Log($"Equipment/Meshes/{character.GetGender()}/{DefineEquipType(equipment.Type)}/{equipment.MeshName}");
            SkinnedMeshRenderer mesh = ((GameObject)Resources.Load($"Equipment/Meshes/{character.GetGender()}/{DefineEquipType(equipment.Type)}/{equipment.MeshName}")).GetComponent<SkinnedMeshRenderer>();
            return mesh;
        }
        if (equipment is Weapon)
        {
            SkinnedMeshRenderer mesh = ((GameObject)Resources.Load($"Equipment/Weapon/{equipment.MeshName}")).GetComponent<SkinnedMeshRenderer>();
            return mesh;
        }
        return null;
        //SkinnedMeshRenderer newMesh = MonoBehaviour.Instantiate<SkinnedMeshRenderer>(equipment.Mesh);
    }
}
