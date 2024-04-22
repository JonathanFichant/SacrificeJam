using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private bool projectile;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public float GetDamage()
    {
        return damage;
    }
}
