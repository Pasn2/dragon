using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IWeapon
{
    void UseDistanceWeapon(Vector3 _dir,float _dis);
    void UseMeleeeWeapon();
}
