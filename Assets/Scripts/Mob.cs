using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : Characters
{
    private GameObject player;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        
    }

    private void Death()
    {
        Destroy(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Attack(weapon, player);
        }
    }

    //private void Hit(float damage)
}
