using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss : MonoBehaviour
{
    public float speed = 0f;
    private Rigidbody2D rb;
    public int damage = 1;
    public GameObject playerColision;
    public GameObject player;
    private Personagem _personagem;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right * speed;
        _personagem = player.GetComponent<Personagem>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Colidiu com o jogador");
            other.gameObject.GetComponent<Personagem>().TakeDamage(damage);           
        }

        Destroy(gameObject, 0.1f);
    }

}
