using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretWeapon : MonoBehaviour
{
    public float lookDistance = 15f;
    public float rotationSpeed = 5f;

    private Transform player;
    public Transform turret;

    private TurretController turretController;

    
    void Start()
    {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        turretController = GetComponent<TurretController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!turretController.control)
            return;


        if (Vector3.Distance(transform.position, player.position) > lookDistance)
            return;

        Vector3 pos = player.position - turret.position;
        pos.y = 0;

        Quaternion toRotation = Quaternion.LookRotation(pos);

        turret.rotation = Quaternion.Lerp(turret.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
}
