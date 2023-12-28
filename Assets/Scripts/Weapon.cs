using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour , IWeapon
{
    [SerializeField] WeaponScriptableObject weaponScriptable;
    [SerializeField] bool canUse;
    [SerializeField] float delayTime;
    public WeaponType GetWeaponType => weaponScriptable.weaponType;
    void Use(Vector3 dir,float distance)
    {
        print("daw" + dir);
        GameObject projectlie =Instantiate(weaponScriptable.weaponProjectlie,transform.position,Quaternion.identity) ;
        projectlie.GetComponent<Projectlie>().SetDamage(weaponScriptable.damage);
        Debug.DrawRay(transform.position,dir,Color.black,Mathf.Infinity);
        projectlie.GetComponent<Rigidbody>().AddForce(dir * 10,ForceMode.Impulse);
    }
    public void UseWeapon(Vector3 _dir,float _dis)
    {
        if(canUse)
        {
            
            canUse = false;
            Use(_dir,_dis);
            StartCoroutine(delay());
        }
    }
    
    IEnumerator delay()
    {
        yield return new WaitForSeconds(weaponScriptable.timeToNextAttack);
        canUse = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        delayTime = weaponScriptable.timeToNextAttack;
    }

    
}
