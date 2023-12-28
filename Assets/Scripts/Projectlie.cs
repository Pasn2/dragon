using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectlie : MonoBehaviour
{
    [SerializeField] float _damage;
    public float GetDamage() => _damage;
    public float SetDamage(float damage) => _damage = damage;
    
    
}
