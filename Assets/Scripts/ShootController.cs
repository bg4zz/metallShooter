using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public float damage = 21;
    public float fireRate = 1;
    public float force = 155;
    public float range = 15;

    public ParticleSystem muzzleFlash;
    public Transform bulletSpawn;
    public AudioClip shootSFX;
    public AudioSource shootAudioSource;
    public GameObject hitEffect;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        shootAudioSource.PlayOneShot(shootSFX);
        //Instantiate(muzzleFlash, bulletSpawn.position, bulletSpawn.rotation);
        muzzleFlash.Play();

        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log("PIW PAW" + hit.collider);

            GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2f);

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * force);
            }
        }
    }
}
