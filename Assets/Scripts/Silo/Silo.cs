using UnityEngine;
using UnityEngine.UI;

public class Silo : MonoBehaviour
{
    public Image healthBar;
    private SiloController siloController;

    public GameObject siloDamage;

    private float health = 100f;

    // Start is called before the first frame update
    void Start()
    {
        siloController = transform.parent.GetComponentInParent<SiloController>();
        //Debug.Log(siloController.name);

        healthBar.fillAmount = health / 100f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            SetDamage();
        }
    }

    private void SetDamage()
    {
        health -= Random.Range(10f, 25f);
        healthBar.fillAmount = health / 100f;

        if(health <= 0)
        {
            siloController.SetDestroy();

            siloDamage.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}
