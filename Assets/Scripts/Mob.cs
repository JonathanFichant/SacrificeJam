using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : Characters
{
    private GameObject player;
    [SerializeField]
    private float offsetX, rangeDetection;

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
            
        }
    }

    private void Chase()
    {

    }

    //private void Hit(float damage)
}
