using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/new Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField] public WeaponType weaponType;
    [SerializeField] public int damage;
    
    [SerializeField] public float delayBeforeAttack;
    [SerializeField] public GameObject weaponProjectlie;
    
}
