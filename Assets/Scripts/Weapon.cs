using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] public WeaponScriptableObject weaponScriptable;
    [SerializeField] bool canUse;
    
    public WeaponType GetWeaponType => weaponScriptable.weaponType;
    public void Use(Vector3 dir,float distance,Animator weaponAnimator)
    {
        if(canUse)
        {
            weaponAnimator.SetBool("Has Weapon",true);
            canUse = false;
            StartCoroutine(delay(weaponScriptable.delayBeforeAttack));
            Debug.LogWarning("USE WEAPON WORKS");
            GameObject projectlie =Instantiate(weaponScriptable.weaponProjectlie,transform.position,Quaternion.identity) ;
            projectlie.GetComponent<Projectlie>().SetDamage(weaponScriptable.damage);
            Debug.DrawRay(transform.position,dir,Color.black,Mathf.Infinity);
            projectlie.GetComponent<Rigidbody>().AddForce(dir * 10,ForceMode.Impulse);
            weaponAnimator.SetBool("Has Weapon",false);
        }
    }
    
    
    IEnumerator delay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        canUse = true;
    }
    

    
}
