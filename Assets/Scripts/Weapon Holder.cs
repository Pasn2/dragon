using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    
    // Start is called before the first frame update
    public void UseWeapon(Vector3 _dir,float _dis)
    {
        print("Is using");
        weapon.UseWeapon(_dir,_dis);
    }
    public void EquipWeapon()
    {
        switch(weapon.GetWeaponType)
        {
            case WeaponType.DistanceWeapon:
                //print("it's a distance weapon!");
            break;
            case WeaponType.MeleeWeapon:

                //print("it's a melee weapon!");
            break;
        }
    }
    
}
