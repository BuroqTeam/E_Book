using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTest : MonoBehaviour
{
    static readonly Vector3 lookAtZ = new Vector3(0, 0, 1);

    void Update()
    {
        transform.LookAt(transform.position + lookAtZ);
    }
}
