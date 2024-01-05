using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHealth : MonoBehaviour
{
    [SerializeField] string tagName;
    [SerializeField] float maxHealth;
    [SerializeField] float currentHealth;
    private void Awake() {
        currentHealth = maxHealth;
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.transform.tag == tagName)
        {
            Destroy(other.gameObject);
            Damage(other.gameObject.GetComponent<Projectlie>().GetDamage());
        }
    }
    public void Damage(float _damage)
    {
        if(currentHealth <= 0)
        {
            Die();
            return;
        }
        currentHealth -= _damage;
        
    }
    public void Health(float _health)
    {
        if(currentHealth >= maxHealth) return;
        currentHealth += _health;
        
    }
    void Die()
    {
        //To be done
        Debug.LogWarning("I am dead rn");
    }
}
