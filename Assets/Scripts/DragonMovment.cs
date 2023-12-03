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
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
    // Update is called once per frame
    void Update()
    {
        dir = new Vector3(Input.GetAxis("Vertical"), 0.0f, Input.GetAxis("Horizontal"));
        IsGrounded = Physics.CheckSphere(groundCheckSphere.position,groundCheckSphereradius,groundLayer);
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
		
		//Get the Screen position of the mouse
		Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
		
		//Get the angle between the points
		float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

		//Ta Daaa
		transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle));
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
