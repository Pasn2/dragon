using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
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
    [SerializeField] float wingTime;
    [SerializeField] float curTime;
    [SerializeField] float jumptForce;
    [SerializeField] float currentChangeFlyTime;
    [SerializeField] bool isGrounded;
    [SerializeField] Transform groundCheckTransform;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] bool isEvalute;
    [SerializeField] AnimationCurve increasingCurveY;
    [SerializeField] AnimationCurve fallingCurveY;
    private AnimationCurve currentAnimationCurve;
    
    // Start is called before the first frame update
    
    private void Start() {
        curTime = wingTime;
        
    }
    // Update is called once per frame
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(groundCheckTransform.position,groundCheckRadius);
    }
    private void Update() {
        ChangeFly(currentAnimationCurve);
        
    }
    void ChangeFly(AnimationCurve curve)
    {
        if (isEvalute)
                {
                    currentChangeFlyTime += Time.deltaTime;

                    rb.velocity = new Vector3(0, jumptForce *  curve.Evaluate(currentChangeFlyTime), 0);

                    // Assuming curveY is not empty
                    float lastKeyframeTime = curve.keys[curve.length - 1].time;
                    
                    if (lastKeyframeTime <= currentChangeFlyTime)
                    {
                        rb.velocity = Vector3.zero;
                        isEvalute = false;
                        // Perform actions when the animation reaches its end
                        rb.constraints = RigidbodyConstraints.FreezePositionY;
                    }
                }
    }
    void changeAnimation(int id)
    {
        switch(id)
        {
            case 0:
                currentAnimationCurve = increasingCurveY;
            break;
            case 1:
                currentAnimationCurve =  fallingCurveY;
            break;
        }
       
        
    }
    void FixedUpdate()
    {
        
        isGrounded = Physics.CheckSphere(groundCheckTransform.position,groundCheckRadius,groundLayerMask);
        
        if(directions.magnitude != 0)
        {
            
            curTime -= Time.deltaTime;
            if(curTime <= 0)
            {
                
                curSpeed = rb.velocity.magnitude;
                if(curSpeed >= maxSpeed)
                {
                    
                    curSpeed = maxSpeed;
                    return;
                }
                
                rb.AddForce(directions.y * transform.forward * accelerationForce,ForceMode.Acceleration);
                curTime = wingTime;
            }
            
            
        }
        
        
    }
    public void ChangeFly(InputAction.CallbackContext callback)
    {
        print("D");
        if(callback.started && isGrounded)
        {
            currentChangeFlyTime = 0;
            changeAnimation(0);
            isEvalute = true;
            
            
        }
        else if(callback.started && !isGrounded)
        {
            rb.constraints = RigidbodyConstraints.None;
            print(callback + "EEW");
            currentChangeFlyTime = 0;
            changeAnimation(1);
            isEvalute = true;
        }
        
        
        
    }
    public void GetDirections(InputAction.CallbackContext callbackContext)
    {
        directions = callbackContext.ReadValue<Vector2>();
    }
}
