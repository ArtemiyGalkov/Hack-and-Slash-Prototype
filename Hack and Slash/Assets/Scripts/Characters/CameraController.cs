using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform LookAt;

    private void Update()
    {
        gameObject.transform.position = new Vector3(LookAt.position.x, 10, LookAt.position.z - 8);
    }
}
