using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float damage, range;

    public enum TypeOfWeapon { Fire, Electric, Water, Poison };
    [SerializeField]
    private TypeOfWeapon typeOfWeapon; //mettre enum ici pour choisir le type

    [SerializeField]
    private bool projectile;

    [SerializeField]
    private bool randomType = false;



    void Start()
    {
        if (randomType)
        {
            typeOfWeapon = (TypeOfWeapon)Random.Range(0, System.Enum.GetValues(typeof(TypeOfWeapon)).Length);
        }
    }

    void Update()
    {
        
    }

    public float GetDamage()
    {
        return damage;
    }

    public void Attack()
    {
        //lance le projectile ou attaque dans un cone proche

        if (projectile)
        {
            // recupere la direction, boolean right left
            // instancie un prefab projectile
            // attribue l'allégeance au projectile, vérifie si le lanceur est le joueur ou non
            // recupere le type et les damages
            // speed du projectile ?
        }
    }
}
