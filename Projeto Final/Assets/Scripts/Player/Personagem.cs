using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{

    public int health = 15;
    public float speed = 3f; 
    private Vector2 direction = Vector2.zero; 
    private Rigidbody2D rb;
    public float jumpForce = 4f; 
    private bool isJump = false;
    public Transform foot; 
    public float collisionRadius = 0.25f; 
    public LayerMask layerGround; 
    [SerializeField]
    private bool isOnFloor = false;

    private Animator anim;
    private AudioSource audioSource;
    public AudioClip jumpAudio;
    public GameObject explosion;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
    }

    void Update() 
    {

        if (health <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        GroundCheck();

        if (Input.GetKeyDown(KeyCode.Space) && isOnFloor) 
        {
            isJump = true;
            audioSource.PlayOneShot(jumpAudio);
        }

        anim.SetBool("jumping", isOnFloor == false);
        anim.SetBool("shooting", Input.GetButton("Fire1"));
        anim.SetBool("running", Input.GetAxisRaw("Horizontal") != 0);


    }

    private void FixedUpdate() 

    {
        Move(Input.GetAxisRaw("Horizontal")); 
        if (isJump)
        {
            isJump = false; 
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
        }
    }

    void Move(float move)
    { 

        if (move > 0)
        {
            direction = Vector2.right; // =1
        }

        if (move < 0)
        {
            direction = Vector2.left; // =-1
        }

        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y); 

        if (move == 0) 
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        transform.right = direction; 
    }

    void GroundCheck() 
    {
        isOnFloor = Physics2D.OverlapCircle(foot.position, collisionRadius, layerGround); 
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        
    }

}
