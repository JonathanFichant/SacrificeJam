using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Characters
{
    [SerializeField]
    private float jumpForce = 8f;
    private GameObject secondWeapon;
    private float airFrictionForce = 2f;
    private GameObject checkpoint;
    [SerializeField]
    private float hpMax = 20;


    protected override void Start()
    {
        base.Start();
        checkpoint = GameObject.Find("checkpoint");
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

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
    }

    public override void Death(string sourceHit)
    {
        switch (sourceHit)
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
