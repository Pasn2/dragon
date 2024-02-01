using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogdePerk :MonoBehaviour, IPerk 
{
    [SerializeField] float dogeVelocity;
    [SerializeField]DragonMovement playerMovment;

    public void DestroyPerk()
    {
        Destroy(this.gameObject);
    }

    public void UsePerk()
    {
        Debug.Log("USE PERK");
        playerMovment = GameObject.FindGameObjectWithTag("Player").GetComponent<DragonMovement>();
        Rigidbody rb = playerMovment.gameObject.GetComponent<Rigidbody>();
        Debug.Log("Rigidbody" + rb.name);
        //rb.AddForce(new Vector3(playerMovment.GetDirectionVector2().y * dogeVelocity,rb.velocity.y,playerMovment.GetDirectionVector2().x * dogeVelocity),ForceMode.VelocityChange);
        //rb.AddForce( transform.forward * playerMovment.GetDirectionVector2().y * dogeVelocity + transform.right * playerMovment.GetDirectionVector2().x * dogeVelocity,ForceMode.VelocityChange);
        Destroy(this);
        Debug.Log("direction" + transform.forward * dogeVelocity);
    }
    
    
}
