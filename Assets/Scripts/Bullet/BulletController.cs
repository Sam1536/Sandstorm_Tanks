using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public GameObject particlesSystem;

    private void OnCollisionEnter(Collision collision)
    {
       GameObject go = Instantiate(particlesSystem, transform.position, Quaternion.identity);

        Destroy(go, 2f);
        Destroy(this.gameObject);
    }

   
}
