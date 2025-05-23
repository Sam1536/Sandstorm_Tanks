using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TankTurret), typeof(TankHealth), typeof(TankWeapon))]
public class TankController : MonoBehaviour
{
    public float moveSpeed = 5.0f, rotationSpeed = 4.0f;

    public AudioSource audioSource;
    private TankHealth tankHealth;
    private CanvaMainGame canvaMainGame;

    [HideInInspector]
    public  bool control = true;



    private void Start()
    {
        tankHealth = GetComponent<TankHealth>(); 
    }

    void Update()
    {
        if (!control && tankHealth.life <= 0)
        {  
            audioSource.enabled = false;
            return;
        }

        MoveTank();
    }


    private void MoveTank()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        
        Vector3 moveDirection = new Vector3(hInput, 0, vInput);
        moveDirection.Normalize();

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        if (moveDirection != Vector3.zero) // NOVO
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop(); // Para o som quando o tanque n�o se move
            return; 
        }


       // if (moveDirection == Vector3.zero) ANTIGO
        {
           // audioSource.Play();
            //Debug.Log(audioSource + "audio");
           
        }
           

        Quaternion rotation = Quaternion.LookRotation(moveDirection, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
