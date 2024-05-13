using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Characters : MonoBehaviour
{
    [SerializeField]
    protected float hp, speed, fallThreshold;
    protected Weapon weapon;
    protected float damage;
    protected bool isGrounded = false;
    protected Rigidbody2D rb;
    [SerializeField]
    protected string allegiance = "neutral";
    protected float fallSpeed;
    protected float damageFall = 5;
    protected float startingJumpHeight;
    protected bool onJump = false;

    protected virtual void Start()
    {
        weapon = GetComponent<Weapon>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            fallSpeed = rb.velocity.y;
        }
    }

    protected virtual void Update()
    {
        if (!isGrounded )
        {
            //stocker la hauteur du saut pour la comparer au moment où on retouche le sol
        }
    }

    protected virtual void UseWeapon(Weapon weaponUsed)
    {
        weapon.Attack();        
    }


    //faire un raycast qui part sous le perso pour détecter le sol au lieu du collide

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            TypeOfAttack script = collision.gameObject.GetComponent<TypeOfAttack>();
            if (script != null)
            {
               if (allegiance != script.GetAllegiance())
               {  
                    TakeDamage(script.GetDamage(), script.GetType());
                    Destroy(collision.gameObject);
               }
            }
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            if (fallSpeed < -fallThreshold)
            {
                TakeDamage(damageFall, "Ground");
                isGrounded = true;
                fallSpeed = 0;
            }
        }
    }

    protected virtual void TakeDamage(float damage, string sourceHit)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Death(sourceHit);
        }
    }

    public virtual void Death(string sourceHit)
    {
        Destroy(gameObject);
        // override pour le player
    }
}
