using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankWeapon : MonoBehaviour
{
    private TankController tankController;

    public AudioSource shotSound;
    public ParticleSystem shotParticle;
    public Transform shotPoint;
    public GameObject shotBullet;


    [Space(10)]
    public float reloadTime = .4f;
    public float shotForce = 120f;

    private bool canShot = true;


    private void Start()
    {
        tankController = this.GetComponent<TankController>();
    }



    // Update is called once per frame
    void Update()
    {

        if (!tankController.control | !canShot)
            return;

        if (Input.GetMouseButton(0))
        {
            Shot();
        }
    }

    void Shot()
    {
        GameObject go = Instantiate(shotBullet, shotPoint.transform.position, shotPoint.rotation);
        go.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shotForce, ForceMode.Impulse);

        shotSound.Play();
        shotParticle.Play();

        Destroy(go, 5f);

        canShot = false;

        StartCoroutine(Reload());

    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        canShot = true;

    }
}
