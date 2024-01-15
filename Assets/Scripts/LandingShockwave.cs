using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingShockwave : MonoBehaviour
{
    private float shockwaveDistance;
    private float shockwaveForce;
    private float multiplier;
    float gizmosFloat;
    public void SetLandingParameters(float _distance,float _force,float _multiplier)
    {
        shockwaveDistance = _distance;
        shockwaveForce = _force;
        multiplier = _multiplier;
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,shockwaveDistance);
    }
    public void LandingShockWave()
    {
        Debug.Log("DUPPS");
        Collider[] colliders = Physics.OverlapSphere(transform.position, shockwaveDistance);

            foreach (Collider collider in colliders)
            {
                if(collider.tag == "Player") return;
                if(collider.transform.TryGetComponent<HealthSystem>(out HealthSystem health))
                {
                    float distance = Vector3.Distance(transform.position, collider.transform.position);
                    float givenDamage = (shockwaveDistance / distance) * multiplier;
                    
                    health.Damage((int)givenDamage);
                }
            }
    }
}
