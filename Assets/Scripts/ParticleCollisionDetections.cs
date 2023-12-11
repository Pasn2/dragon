using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Events;

public class ParticleCollisionDetections : MonoBehaviour
{
    public UnityEvent onColide;
    private void OnParticleCollision(GameObject other) 
    {
        print("D");
        if(other.tag == "Enemy")
        {
            onColide.Invoke();
        }
        
    }
}
