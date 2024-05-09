using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Characters : MonoBehaviour
{
    [SerializeField]
    protected float hp;
    [SerializeField]
    protected GameObject weapon;
    protected float damage;

    protected virtual void Start()
    {
        damage = GetComponent<Weapon>().GetDamage();
    }

    void Update()
    {

    }

    public virtual void Attack(GameObject weaponUse, GameObject target)
    {
        Characters scriptTarget = target.GetComponent<Characters>();
        scriptTarget.TakeDamage(damage, weaponUse);
    }

    public virtual void TakeDamage(float damage, GameObject SourceHit)
    {
        hp -= damage;
    }
}
