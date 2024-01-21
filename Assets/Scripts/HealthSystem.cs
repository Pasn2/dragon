using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float currentHealth;
    private float damageSplit;
    bool hasArmor;
    [SerializeField] private HumanoidHealthSystemScriptableObject humanoidHealthScriptableObj;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = humanoidHealthScriptableObj.GetHealth();
        damageSplit = humanoidHealthScriptableObj.GetDamageSplit();
        hasArmor = humanoidHealthScriptableObj.GetIsHasArmor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other) {
        Debug.Log(other.name);
        Damage(10);
    }
    public void Damage(float damage)
    {
        print("GivenDamage" + damage);
        switch(hasArmor)
        {
            case true:
                currentHealth -= CalculateDamageWithArmor(damage);
                print(CalculateDamageWithArmor(damage) + "CALCULATED");
            break;
            case false:
                currentHealth -= damage;
            break;
        }
        currentHealth -= damage;
        if(isHealthEqualsZero())
        {
            Destroy(gameObject);

        }

        
    }
    float CalculateDamageWithArmor(float damage)
    {
        float damageWithArmor = damage * damageSplit;
        return damageWithArmor;
    }
    bool isHealthEqualsZero()
    {
        if(currentHealth <= 0 )
        {
            return true;
        }
        return false;
    }
}
