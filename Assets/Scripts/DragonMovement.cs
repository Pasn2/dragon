using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class DragonMovement : MonoBehaviour
{
    [SerializeField] float curSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float accelerationForce;
    [SerializeField] Rigidbody rb;
    [SerializeField] PlayerInput movementAction;
    [SerializeField] Vector2 directions;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void FixedUpdate()
    {
        curSpeed = rb.velocity.magnitude;
        if(curSpeed >= maxSpeed)
        {
            curSpeed = maxSpeed;
            return;
        }
        rb.AddForce(directions.y * transform.forward * accelerationForce,ForceMode.Acceleration);
        
    }
    public void GetDirections(InputAction.CallbackContext callbackContext)
    {
        directions = callbackContext.ReadValue<Vector2>();
    }
}
