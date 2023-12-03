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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dir = new Vector3(Input.GetAxis("Vertical"), 0.0f, Input.GetAxis("Horizontal"));
        IsGrounded = Physics.CheckSphere(groundCheckSphere.position,groundCheckSphereradius,groundLayer);
        
        print(rb.velocity.y);
        if(IsGrounded)
        {
            rb.velocity = new Vector3(dir.x * speed ,rb.velocity.y, -dir.z * speed);
        }
        else
        {
            
        } 
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            
            rb.AddForce((Vector3.up + dir) * 10,ForceMode.Impulse);
            
        }
        
        else if(Input.GetKeyDown(KeyCode.Space) && !IsGrounded)
        {
            ChangeToGround();
        }
        print(dir + "Not Normalize");
        dir.Normalize();
        print(dir);
        if(dir != Vector3.zero)
        {
            
            dir.z = -dir.z;
            Quaternion toRot = Quaternion.LookRotation(dir ,Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,toRot,rotSpeed * Time.deltaTime);
            
        }
        
    }
    private void ChangeToFly()
    {
        
        
        rb.drag = Mathf.Lerp(rb.drag, 100,5);
    }
    private void ChangeToGround()
    {
        rb.useGravity = true;
    }
}
