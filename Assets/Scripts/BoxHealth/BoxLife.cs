using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLife : MonoBehaviour
{ 
    public AudioSource audioSource;

    public float healthAmount = 35f;

    public float destroyTime = 1f;


    public float GetHealth() 
    {
        audioSource.Play();

        Destroy(gameObject, destroyTime);
        return healthAmount;
    }
}
