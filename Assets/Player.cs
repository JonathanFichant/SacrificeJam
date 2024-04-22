using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Characters
{
    [SerializeField]
    private float jumpForce = 8f;
    [SerializeField]
    private float speed = 5f;
    private GameObject secondWeapon;
    [SerializeField]
    private float fallThreshold;
    private Rigidbody2D rb;
    [SerializeField]
    private bool isGrounded = false;
    private float airFrictionForce = 2f;
    private float fallSpeed;
    private GameObject checkpoint;
    private float hpMax = 20;


    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        checkpoint = GameObject.Find("checkpoint");
    }
    private void FixedUpdate()
    {
        
    }

    void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        if (rb.velocity.y < 0)
        {
            fallSpeed = rb.velocity.y;
        }

        if (Physics2D.OverlapBox(transform.position + Vector3.down * 0.5f, new Vector2(1, 0.1f), 0f, LayerMask.GetMask("Ground"))&& !isGrounded)
        {
           
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (fallSpeed < -fallThreshold)
            {
                Hit(5, collision.gameObject);
            }
            isGrounded = true;
            fallSpeed = 0;
        }
        else if(collision.gameObject.CompareTag("Mob"))
        {
            
        }
    }

    private void Hit(float damage, GameObject SourceHit)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Death(SourceHit);
        }
    }

    private void Death(GameObject SourceHit)
    {
        switch (SourceHit.tag)
        {
            case "Ground":
                jumpForce = 14f;
                fallThreshold = 30f;
                break;

            case "Fire":

                break;

            default:
                Debug.Log("Default");
                break;
        }
        ResetGame();
    }


    private void ResetGame()
    {
        hp = hpMax;
        transform.position = checkpoint.transform.position;

    }


}
