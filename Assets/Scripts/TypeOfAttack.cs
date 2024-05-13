using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeOfAttack : MonoBehaviour
{
    // tag weapon
    protected string allegiance;
    protected float damage;
    protected string type;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public virtual string GetAllegiance()
    {
        return allegiance;
    }

    public virtual float GetDamage()
    {
        return damage;
    }

    public virtual string GetType()
    {
        return type;
    }
}
