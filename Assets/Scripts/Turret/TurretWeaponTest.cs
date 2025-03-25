using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretWeaponTest : MonoBehaviour
{
    #region Variables
    public float lookDistance = 15f;
    public float rotationSpeed = 5f;

    private Transform player;
    public Transform turret;
    private TankHealth tankHealth; // Referência para a vida do tanque

    private TurretController turretController;

    [Space(15)]
    [Header("Dados do Bullet/Shot")]
    public Transform shotPosition;
    public GameObject bulletPrefab;
    public float reloadTime = .9f;
    public float shotForce = 120f;


    [Space(15)]
    public AudioSource audioSource;


    public bool canShot = true;
    public bool inArea = false;

    #endregion

    void Start()
    {
        if (!player)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj)
            {
                player = playerObj.transform;
                tankHealth = playerObj.GetComponent<TankHealth>(); // Pega o componente de vida do tanque
            }
        }

        turretController = GetComponent<TurretController>();
    }

    void Update()
    {
        if (!turretController.control)
            return;

        // Verifica se o tanque está morto
        if (tankHealth != null && tankHealth.life <= 0)
        {
            inArea = false; // Para a rotação da torre
            return;
        }

        CheckArea();
        Shot();
        TurretRotation();
    }

    private void TurretRotation()
    {
        if (!inArea)
            return;

        Vector3 pos = player.position - turret.position;
        pos.y = 0;

        Quaternion toRotation = Quaternion.LookRotation(pos);
        turret.rotation = Quaternion.Lerp(turret.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }

    private void CheckArea()
    {
        if (Vector3.Distance(transform.position, player.position) > lookDistance)
        {
            inArea = false;
            return;
        }

        inArea = true;
    }

    public void Shot()
    {
        // Adiciona a verificação para garantir que o tanque ainda está vivo
        if (!inArea || !canShot || (tankHealth != null && tankHealth.life <= 0))
            return;

        GameObject go = Instantiate(bulletPrefab, shotPosition.position, shotPosition.rotation);
        go.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shotForce, ForceMode.Impulse);
        Destroy(go, 3f);

        canShot = false;
        StartCoroutine(Reload());
        audioSource.Play();
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        canShot = true;
    }
}


