using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class DragonBreathe : MonoBehaviour
{
    [SerializeField] GameObject spawnFire;
    [SerializeField] GameObject fireProjectile;
    ParticleSystem particle;
    [SerializeField] InputAction binding;
    // Start is called before the first frame update
    void Start()
    {
       GameObject fire = Instantiate(fireProjectile,spawnFire.transform.position,spawnFire.transform.rotation);
       fire.transform.parent = spawnFire.transform;
       fire.transform.localScale = new Vector3(1,1,1);
       
       particle = fire.GetComponent<ParticleSystem>();

    }
    public InputAction GetBinding()
    {
        return binding;
    }
    public InputAction SetBinding(InputAction input)
    {
        binding = input;
        binding.Enable();
        return binding;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(binding == null) return;
        bool isPlay = binding.triggered;
        print(isPlay);
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
