using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private bool projectile;

    public enum TypeOfWeapon { Fire, Electric, Water, Poison };
    [SerializeField]
    private TypeOfWeapon type;

    [SerializeField]
    private bool randomType = false;

    void Start()
    {
        if (randomType)
        {
            type =  (TypeOfWeapon)Random.Range(0,System.Enum.GetValues(typeof(TypeOfWeapon)).Length);
        }
    }

    void Update()
    {
        
    }

    public float GetDamage()
    {
        return damage;
    }
}
