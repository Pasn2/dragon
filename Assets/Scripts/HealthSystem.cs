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
        Damage(1);
    }
    void Damage(int damage)
    {
        _health -= damage;
        if(_health <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
