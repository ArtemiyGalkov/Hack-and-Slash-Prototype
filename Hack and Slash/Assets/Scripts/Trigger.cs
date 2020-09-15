using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
    }
}
