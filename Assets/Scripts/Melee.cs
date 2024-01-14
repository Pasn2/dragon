using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] WeaponScriptableObject weaponScriptable;
    bool canMelee = true;
    
    public void UseMelee()
    {
        Debug.Log("MELEE ATTASCKT");
        
       if(canMelee)
       {
        StartCoroutine(DelayToNextAttack());
            Collider[] colliders = Physics.OverlapSphere(transform.position, weaponScriptable.weaponRange);

            foreach (Collider collider in colliders)
            {
            // Check if the collider belongs to a GameObject with the "Player" tag
                if (collider.CompareTag("Player"))
                {
                    Debug.Log(collider.name + " HIT");
                
                // Assuming DragonHealth has a Damage method
                    collider.GetComponent<DragonHealth>().Damage(weaponScriptable.damage);
                }
            }
       }
       
        
    }
    IEnumerator DelayToNextAttack()
    {
        canMelee = false;
        yield return new WaitForSeconds(weaponScriptable.delayBeforeAttack);
        canMelee = true;
    }
}
