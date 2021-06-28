using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float enemyspeed = 3f;
    public int health = 6;
    private Transform playerPosition;
    public GameObject explosion;
    public Transform foot;
    public LayerMask layerGround;
    private bool isOnFloor = false;
    public float collisionRadius = 0.25f;

    void Start()
    {

        playerPosition = GameObject.FindWithTag("Player").GetComponent<Transform>();


    }


    void Update()
    {
        if (transform.position.x < playerPosition.position.x)
        {
            transform.right = Vector2.left;
        }

        else
        {
            transform.right = Vector2.right;
        }

        transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, enemyspeed * Time.deltaTime);

        if (health <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
        {
            health -= damage;
        }

    void GroundCheck()
    {
        isOnFloor = Physics2D.OverlapCircle(foot.position, collisionRadius, layerGround);
    }

}

