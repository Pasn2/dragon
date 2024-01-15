using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int _health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other) {
        Debug.Log(other.name);
        Damage(1);
    }
    public void Damage(int damage)
    {
        print("Damaged");
        _health -= damage;
        if(_health <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
