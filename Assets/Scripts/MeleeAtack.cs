using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAtack : MonoBehaviour , IWeapon

{
    [SerializeField] Melee melee;
    public void UseDistanceWeapon(Vector3 _dir, float _dis)
    {
       
    }

    public void UseMeleeeWeapon()
    {
        melee.UseMelee();
    }

    
}
