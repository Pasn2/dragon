using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class DragonBreathe : MonoBehaviour
{
    [SerializeField] GameObject spawnFire;
    [SerializeField] GameObject fireProjectile;
    ParticleSystem particle;
    [SerializeField] InputActionReference binding;
    [SerializeField] PlayerInput playerInput;
    public InputActionAsset inputActions;
     bool isPlay;
    // Start is called before the first frame update
    void Start()
    {
       GameObject fire = Instantiate(fireProjectile,spawnFire.transform.position,spawnFire.transform.rotation);
       fire.transform.parent = spawnFire.transform;
       fire.transform.localScale = new Vector3(1,1,1);
       
       particle = fire.GetComponent<ParticleSystem>();

    }
   private void OnEnable() {
    inputActions.Enable();
   }
   private void OnDisable() {
    inputActions.Disable();
   }
    
    // Update is called once per frame
    void Update()
    {
        if(binding == null) return;
        if(inputActions.FindAction("Main Ability").ReadValue<float>() > 0)
        {
            isPlay = true;
            
        }
        else
        {
            isPlay = false;

        }
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
