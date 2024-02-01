using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float currentHealth;
    private float damageSplit;
    bool hasArmor;
    [SerializeField] private HumanoidHealthSystemScriptableObject humanoidHealthScriptableObj;
    [SerializeField] ParticleSystem currentFireParticle;
    AiStateMachine aiState;
    [SerializeField]bool IsBurning = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = humanoidHealthScriptableObj.GetHealth();
        damageSplit = humanoidHealthScriptableObj.GetDamageSplit();
        hasArmor = humanoidHealthScriptableObj.GetIsHasArmor();
        GameObject fireObject = Instantiate(humanoidHealthScriptableObj.GetFireParticle(),transform.position,Quaternion.Euler(new Vector3(-90,0,0))).gameObject;
        fireObject.transform.parent = transform;
        fireObject.transform.localScale = new Vector3(0.6f,0.6f,0.6f);
        currentFireParticle = fireObject.GetComponent<ParticleSystem>();
        print(currentFireParticle.name);
        currentFireParticle.Stop();
        
    }
    public bool GetIsBurning()
    {
        return IsBurning;
    }
    
    private void OnParticleCollision(GameObject other) {
        Debug.Log(other.tag);
        if(other.tag == "Fire")
        {
            currentFireParticle.Play();
            print(currentFireParticle.name + "DARAS");
            aiState = GetComponent<AIAgent>().stateMachine;
            Debug.Log("IsOnfire");
            aiState.ChangeState(AiStateId.Burn);
            if(!IsBurning)
            {
                StartCoroutine(BurnTime(4));
                InvokeRepeating("Burning",0,1f);
                IsBurning = true;
            }
        }
    }

    void Burning()
    {
        AddDamage(humanoidHealthScriptableObj.GetDamageFromFire());
    }

    IEnumerator BurnTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        CancelInvoke();
        currentFireParticle.Stop();
        IsBurning = false;
    }

    public void AddDamage(float damage)
    {
        
        print("GivenDamage" + damage);
        switch(hasArmor)
        {
            case true:
                Damage(CalculateDamageWithArmor(damage));
                
                print(CalculateDamageWithArmor(damage) + "CALCULATED");
            break;
            case false:
                Damage(damage);
            break;
        }
        currentHealth -= damage;
        if(isHealthEqualsZero())
        {
            ExperienceAdd exp = this.gameObject.AddComponent<ExperienceAdd>();
            exp.AddExp(humanoidHealthScriptableObj.GetExpToAdd());
            Destroy(gameObject);

        }

        
    }

    void Damage(float _damage)
    {
        currentHealth -= _damage;
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
