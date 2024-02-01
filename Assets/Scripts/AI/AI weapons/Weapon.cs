using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] public WeaponScriptableObject weaponScriptable;
    [SerializeField] bool canUse = true;
    private Animator curanim;
    public WeaponType GetWeaponType => weaponScriptable.weaponType;
    public void Use(Transform shotPos,float distance,Animator weaponAnimator)
    {
        if(canUse)
        {
            Debug.LogWarning("USE WEAPON WORKS");
            weaponAnimator.SetTrigger("Shoot");
            canUse = false;
            StartCoroutine(delay(weaponScriptable.delayBeforeAttack,weaponAnimator));
            
            GameObject projectlie =Instantiate(weaponScriptable.weaponProjectlie,shotPos.position,shotPos.rotation) ;
            projectlie.GetComponent<Projectlie>().SetDamage(weaponScriptable.damage);
            Debug.DrawRay(shotPos.position,transform.forward * 10,Color.black,Mathf.Infinity);
            projectlie.GetComponent<Rigidbody>().AddForce(shotPos.forward * distance,ForceMode.Impulse);
            
        }
    }
    
    
    IEnumerator delay(float delayTime,Animator settrigger)
    {
        yield return new WaitForSeconds(delayTime);
        canUse = true;
        settrigger.ResetTrigger("Shoot");
    }
    

    
}
