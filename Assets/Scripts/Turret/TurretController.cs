using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TurretWeapon), typeof(TurretHealth))]
public class TurretController : MonoBehaviour
{
    [HideInInspector()]
    public bool control = true;

    public GameObject[] hiddenList;
    public GameObject[] activeList;


    

    // Update is called once per frame
    void Update()
    {
        

    }

    public void DestroyMe()
    {
        control = false;

        foreach(GameObject go in hiddenList)
        {
            go.SetActive(false);
        }
        
        foreach(GameObject go in activeList)
        {
            go.SetActive(true);
        }
    }
}
