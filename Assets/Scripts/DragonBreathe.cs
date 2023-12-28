using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBreathe : MonoBehaviour
{
    [SerializeField] GameObject spawnFire;
    [SerializeField] GameObject fireProjectile;
    ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
       GameObject fire = Instantiate(fireProjectile,spawnFire.transform.position,spawnFire.transform.rotation);
       fire.transform.parent = spawnFire.transform;
       fire.transform.localScale = new Vector3(1,1,1);
       
       particle = fire.GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        bool isPlay = Input.GetMouseButton(0);
        switch(isPlay)
        {
            case true:
            particle.Play();
            break;
            case false:
            particle.Stop();
            break;
        }
        
    }
    
    void SpawnFire()
    {

    }
}
