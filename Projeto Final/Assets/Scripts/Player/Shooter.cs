using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Bullet bullet; 
    public float fireRate = 0.3f; 
    public Transform spawnBullet; 
    [SerializeField]
    private bool canShoot = true;
    public AudioSource audioSource; 
    public AudioClip shootClip; 

    public void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
        
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && canShoot) 
        {
            StartCoroutine(SpawnBullet());
        }
    }
    IEnumerator SpawnBullet() 
    {
        canShoot = false; 
        Instantiate(bullet, spawnBullet.position, transform.rotation);
        audioSource.PlayOneShot(shootClip); 

        yield return new WaitForSeconds(fireRate); 
        canShoot = true; 
    }
}
