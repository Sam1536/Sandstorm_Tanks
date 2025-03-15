using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretHealth : MonoBehaviour
{

    public float life = 100f;
    
    public float minDamage = 15f;
    public float maxDamage = 30f;

    public Image healthBar;

    private TurretController turretController;
    

    // Start is called before the first frame update
    void Start()
    {
        ChangerHealthBar();
        
        turretController = GetComponent<TurretController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!turretController.control)
            return;

        
    }


    private void ChangerHealthBar()
    {
        healthBar.fillAmount = life / 100;

    }

    private void SetDamage()
    {
        ChangerHealthBar();

        life -= Random.Range(minDamage, maxDamage);

        if(life <= 0)
        {
            turretController.DestroyMe();
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            SetDamage();
            //Debug.Log("PEGOU");
        }
    }
}
