using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TankTurret), typeof(TankHealth))]
public class TankController : MonoBehaviour
{
    public float moveSpeed = 5.0f, rotationSpeed = 4.0f;

    [HideInInspector]
    public  bool control = true;


    void Start()
    {
        
    }

   
    void Update()
    {
        if (!control)
            return;
        
        MoveTank();
    }


    private void MoveTank()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(hInput, 0, vInput);
        moveDirection.Normalize();

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        if(moveDirection == Vector3.zero)
            return;

        Quaternion rotation = Quaternion.LookRotation(moveDirection, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
