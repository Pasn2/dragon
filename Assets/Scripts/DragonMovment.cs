using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovment : MonoBehaviour
{
    [SerializeField] float maxAcceleration = 10;
    [SerializeField] float maxSpeed = 50;
    [SerializeField] float groundCheckSphereradius;
    [SerializeField] Transform groundCheckSphere;
    [SerializeField] bool IsGrounded;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Rigidbody rb;
    [SerializeField] Vector3 dir;
    [SerializeField] float speed;
    [SerializeField] float rotSpeed = 3;
    const float gravity = 9.81f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        dir = new Vector3(Input.GetAxis("Vertical"), 0.0f, Input.GetAxis("Horizontal"));
        IsGrounded = Physics.CheckSphere(groundCheckSphere.position,groundCheckSphereradius,groundLayer);
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
		
		//Get the Screen position of the mouse
		//Save current x rotation

        if(IsGrounded)
        {
            Vector3 horizontalVelocity = transform.forward * dir.x * speed + transform.right * dir.z * speed;
        rb.velocity = new Vector3(horizontalVelocity.x, rb.velocity.y, horizontalVelocity.z);
        }
        else
        {
            
        } 
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            ChangeToFly(); 
        }
        
        else if(Input.GetKeyDown(KeyCode.Space) && !IsGrounded)
        {
            ChangeToGround();
        }
        print(dir + "Not Normalize");
        
    }
    
    private void ChangeToFly()
    {
        rb.AddForce((Vector3.up + dir) * 20,ForceMode.Impulse);
        
        
    }
    private void ChangeToGround()
    {
        rb.AddForce((Vector3.down + dir) * 10,ForceMode.Impulse);
    }
}
