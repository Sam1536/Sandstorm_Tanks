using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    public Vector3  offSet = Vector3.up;

    public Transform target;

    public bool lookAt = true;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offSet, moveSpeed * Time.deltaTime);

        if (lookAt)
        {
            transform.LookAt(target.position);
        }
    }
}
