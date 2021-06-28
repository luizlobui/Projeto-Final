using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoterEnemy : MonoBehaviour
{
    public BulletEnemy bulletEnemy;
    public float fireRate = 0.3f;
    public Transform spawnBullet;
    [SerializeField]
    private bool canShoot = true;
    //public AudioSource audioSource;
   // public AudioClip shootClip;

    public void Start()
    {
        //audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        StartCoroutine(SpawnBullet());
    }
    IEnumerator SpawnBullet()
    {
        canShoot = false;
        Instantiate(bulletEnemy, spawnBullet.position, transform.rotation);
        //audioSource.PlayOneShot(shootClip);

        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
