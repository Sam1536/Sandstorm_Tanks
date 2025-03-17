using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{

    public CanvaMainGame canvaMain;

    public float life = 100f;

    [Header("Damage")]
    public float minDamage = 10f;
    public float maxDamage = 20f;

    private TankController tankController;


    private void Start()
    {
        ChangeHealthBar();
    }

    private void ChangeHealthBar()
    {
        canvaMain.HealthValue(life / 100);
    }

    private void SetDamage()
    {
        life -= Random.Range(minDamage, maxDamage);

        ChangeHealthBar();

        if (life <= 0)
        {
            GetComponent<TankController>().control = false;
            canvaMain.ShowGameOver();
        }
           
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            SetDamage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Health"))
        {
            SetHealth(other.gameObject.GetComponent<BoxLife>().GetHealth());
        }
    }

    private void SetHealth(float amount)
    {
        if (life == 100)
            return;

        if(life + amount > 100)
        {
            life = 100;
        }
        else
        {
            life += amount;
        }

        ChangeHealthBar();
    }
}
