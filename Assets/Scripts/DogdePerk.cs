using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogdePerk :MonoBehaviour, IPerk 
{
    [SerializeField] float dogeVelocity;
    [SerializeField]DragonMovement playerMovment;
    
    public void UsePerk()
    {
        Debug.Log("USE PERK");
        playerMovment = GameObject.FindGameObjectWithTag("Player").GetComponent<DragonMovement>();
        Rigidbody rb = playerMovment.gameObject.GetComponent<Rigidbody>();
        Debug.Log("Rigidbody" + rb.name);
        rb.AddForce( new Vector3(playerMovment.GetDirectionVector2().x, 0, playerMovment.GetDirectionVector2().y) * dogeVelocity,ForceMode.VelocityChange);

        Debug.Log("direction" + new Vector3(playerMovment.GetDirectionVector2().x,0,playerMovment.GetDirectionVector2().y) * dogeVelocity);
    }
    
    
}
