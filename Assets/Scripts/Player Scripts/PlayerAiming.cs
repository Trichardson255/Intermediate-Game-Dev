using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Input.mousePosition, Vector3.up);
    }
}