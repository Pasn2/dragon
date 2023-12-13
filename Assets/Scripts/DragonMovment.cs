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
    [SerializeField] float detectGroundRangeRaycast;
    [SerializeField] float rotSpeed = 3;
    [SerializeField] GameObject headGameObject;
    [SerializeField] float maxheadRot;
    [SerializeField] LookToMouse lookTo;
    float currentMass;
    bool isFly;
    const float gravity = 9.81f;
    // Start is called before the first frame update
    void Start()
    {
        currentMass = rb.mass;
    }
    
    // Update is called once per frame
    void Update()
    {
        dir = new Vector3(Input.GetAxis("Vertical"), 0.0f, Input.GetAxis("Horizontal"));
        IsGrounded = Physics.CheckSphere(groundCheckSphere.position,groundCheckSphereradius,groundLayer);
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
		//Vector3 direction = positionOnScreen - headGameObject.transform.position;
		//Get the Screen position of the mouse
		//Save current x rotation
        lookTo.AngleToRotateBody(gameObject.transform);
        if(isFly)
        {
            transform.position += transform.forward * dir.x * speed * Time.deltaTime + transform.right * dir.z * speed* Time.deltaTime ;
        }
        if(IsGrounded)
        {
            Vector3 horizontalVelocity = transform.forward * dir.x * speed + transform.right * dir.z * speed;
        rb.velocity = new Vector3(horizontalVelocity.x, rb.velocity.y, horizontalVelocity.z);
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
    
    void ChangeMovment()
    {
        isFly = true;
    }
    private void ChangeToFly()
    {
        rb.AddForce((Vector3.up + dir) * 20,ForceMode.Impulse);
       StartCoroutine(ChangeFlight());
        
    }
    IEnumerator ChangeFlight()
    {
        yield return new WaitForSeconds(2);
        print("StopMoving");
        rb.velocity = Vector3.zero;
        ChangeMovment();
        transform.position += transform.forward * dir.x * speed + transform.right * dir.z * speed;
        
        rb.useGravity = false;
    }
    void Fly()
    {
        RaycastHit hit ;
        if(!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, detectGroundRangeRaycast, groundLayer))
        {
            rb.velocity  = new Vector3(0,0,0);
        }
    }
    private void ChangeToGround()
    {
        rb.useGravity = true;
        rb.AddForce((Vector3.down + dir) * 10,ForceMode.Impulse);
        
    }
}
