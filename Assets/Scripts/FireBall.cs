using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour , IPerk
{
    Rigidbody rb;
    [SerializeField] float startForce;
    [SerializeField] float detectRadius;
    public void DestroyPerk()
    {
        throw new System.NotImplementedException();
    }

    public void UsePerk()
    {
        rb = transform.GetComponent<Rigidbody>();
        
        transform.parent = null;
        Debug.DrawLine(transform.position,transform.forward * startForce,Color.blue,Mathf.Infinity);
        rb.AddForce(transform.forward * startForce,ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision other) {
        Debug.Log("FIREBAL COLLIDE");
        ExplodeOnHit();

    }
    void ExplodeOnHit()
    {
        Collider[] coliders = Physics.OverlapSphere(transform.position,detectRadius);
        foreach(Collider curColider in coliders)
        {
            if(curColider.tag == "Player") return;
            if (curColider.TryGetComponent<HealthSystem>(out HealthSystem NPChealthSystem))
            {
                NPChealthSystem.Damage(10);
                return;
            }
            
        }
        print("DESTROYED");
        Destroy(this.gameObject);
    }

    
}
