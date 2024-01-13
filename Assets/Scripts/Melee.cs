using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] WeaponScriptableObject weaponScriptable;
    [SerializeField] LayerMask playerLayer;
    
    public void UseMelee()
    {
        RaycastHit hit;
       Collider[] colliders = Physics.OverlapSphere(transform.position,weaponScriptable.weaponRange,playerLayer);
       if(Physics.SphereCast(transform.position,weaponScriptable.weaponRange,transform.position,out hit,playerLayer))
       {
            hit.transform.GetComponent<DragonHealth>().Damage(weaponScriptable.damage);
       }
        
    }
}
