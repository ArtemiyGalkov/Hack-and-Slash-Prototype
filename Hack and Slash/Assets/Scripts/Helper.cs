using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    public static T FindComponentInChildWithTag<T>(this GameObject parent, string tag) where T : Component
    {
        Transform t = parent.transform;
        foreach (Transform tr in t)
        {
            if (tr.tag == tag)
            {
                return tr.GetComponent<T>();
            }
        }
        return null;
    }
    public static T FindEquipmentOfType<T>(this GameObject parent, EquipmentTypes type) where T : Component
    {
        Transform t = parent.transform;
        foreach (Transform tr in t)
        {
            if (tr.TryGetComponent<EquipmentModel>(out EquipmentModel equip))
                if (equip.type == type)
                {
                    return tr.GetComponent<T>();
                }
        }
        return null;
    }
}
