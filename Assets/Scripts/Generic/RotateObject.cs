using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{

    public float rotationVelocity = 120f;

    public Vector3 orientation;

    void FixedUpdate()
    {
        transform.Rotate(orientation * rotationVelocity * Time.deltaTime);
    }
}
