using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretWeapon : MonoBehaviour
{
    #region Variables
    public float lookDistance = 15f;
    public float rotationSpeed = 5f;

    private Transform player;
    public Transform turret;

    private TurretController turretController;

    [Space(15)]
    [Header("Dados do Bullet/Shot")]
    public Transform shotPosition;
    public GameObject bulletPrefab;
    public float reloadTime = .9f;
    public float shotForce = 120f;


    [Space(15)]
    public AudioSource audioSource;


    private bool canShot = true;
    #endregion


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

        Shot();
        TurretRotation();
       
    }


    private void TurretRotation()
    {
        if (Vector3.Distance(transform.position, player.position) > lookDistance)
            return;

        Vector3 pos = player.position - turret.position;
        pos.y = 0;

        Quaternion toRotation = Quaternion.LookRotation(pos);

        turret.rotation = Quaternion.Lerp(turret.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }

    private void Shot()
    {
        if (!canShot)
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
