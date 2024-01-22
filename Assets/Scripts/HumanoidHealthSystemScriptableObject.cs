using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC_Health_System",menuName = "ScriptableObjects/new NPC Health System")]
public class HumanoidHealthSystemScriptableObject : ScriptableObject
{
    [SerializeField] private float baseHealth = 100;
    [SerializeField] private bool hasArmor = false;
    [SerializeField] private float armorDamageSplit = 0.4f;
    [SerializeField] private float damageFromFire;
    [SerializeField] private ParticleSystem fireParticle;
    public float GetHealth()
    {
        return baseHealth;
    }
    public bool GetIsHasArmor()
    {
        return hasArmor;
    }
    public float GetDamageSplit()
    {
        return armorDamageSplit;
    }
    public float GetDamageFromFire()
    {
        return damageFromFire;
    }
    public ParticleSystem GetFireParticle()
    {
        return fireParticle;
    }
    
}
