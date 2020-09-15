using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitModelLoader : MonoBehaviour
{
    public static UnitModel LoadUnit(string json)
    {
        UnitModel result = (UnitModel)JsonUtility.FromJson<UnitModel>(json);
        /*Debug.Log(result.UnitName);
        Debug.Log(result.Characteristics.Armor);*/
        return result;
    }
}
