using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoterBoss : MonoBehaviour
{
    public BulletBoss bulletBoss;
    public float fireRate = 5f;
    public Transform spawnBullet;
    [SerializeField]
    private bool canShoot = true;
    

    public void Start()
    {
      

    }

    void Update()
    {
        StartCoroutine(SpawnBullet());
    }
    IEnumerator SpawnBullet()
    {
        canShoot = false;
        Instantiate(bulletBoss, spawnBullet.position, transform.rotation);
        

        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
