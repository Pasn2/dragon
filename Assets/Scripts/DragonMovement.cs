using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;
public class DragonMovement : MonoBehaviour
{
    [SerializeField] DragonStatisticScriptableObject dragonStatistic;
    [SerializeField] PlayerInput movementAction;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform groundCheckTransform;
    [SerializeField] float curSpeed;
    [SerializeField] Vector2 directions;
    
    [SerializeField] float curTime;
    
    [SerializeField] float currentChangeFlyTime;
    [SerializeField] bool isGrounded;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] bool isEvalute;
    private AnimationCurve currentAnimationCurve;
    float altitudeDirection;
    float curAltitude;
    
    // Start is called before the first frame update
    
    private void Start() {
        curTime = dragonStatistic.wingTime;
        
    }
    // Update is called once per frame
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(groundCheckTransform.position,groundCheckRadius);
        Gizmos.DrawRay(transform.position,-Vector3.up * dragonStatistic.maxAltitude);
    }
    private void Update() {
        
        ChangeFly(currentAnimationCurve);
        
    }
     bool CanChangeAltitude()
    {
        Ray ray = new Ray(transform.position,-Vector3.up * dragonStatistic.maxAltitude);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,groundLayerMask))
        {
            float distance = Mathf.Abs(transform.position.y - hit.transform.position.y);
            print(distance + "altitude: " );
            if(distance < dragonStatistic.maxAltitude)
            {
                print(distance + "altitude: 23123" );
                return true;
            }
            print(distance + "waaltitude: 23123" );
            return false;
        }
        print("Dara");
        return false;
    }
    void ChangeFly(AnimationCurve curve)
    {
        if (isEvalute)
                {
                    currentChangeFlyTime += Time.deltaTime;

                    rb.velocity = new Vector3(rb.velocity.x, dragonStatistic.jumptForce *  curve.Evaluate(currentChangeFlyTime), rb.velocity.z);

                    // Assuming curveY is not empty
                    float lastKeyframeTime = curve.keys[curve.length - 1].time;
                    
                    if (lastKeyframeTime <= currentChangeFlyTime)
                    {
                        rb.velocity = Vector3.zero;
                        isEvalute = false;
                        // Perform actions when the animation reaches its end
                        
                    }
                }
    }
    void changeAnimation(int id)
    {
        switch(id)
        {
            case 0:
                currentAnimationCurve = dragonStatistic.increasingCurveY;
            break;
            case 1:
                currentAnimationCurve =  dragonStatistic.fallingCurveY;
            break;
        }
       
        
    }
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheckTransform.position,groundCheckRadius,groundLayerMask);
       
        if(directions.magnitude != 0)
        {
            StraightMovment();
        }
        print(curSpeed + "speed");
        if(curSpeed != 0)
        {
            if(!isGrounded && CanChangeAltitude())
            {
                AltitudeMovment();
            }
        }
        
        
    }
    void AltitudeMovment()
    {
        rb.velocity += transform.up * dragonStatistic.altidudeGrain * altitudeDirection * Time.deltaTime;
    }
    void StraightMovment()
    {
        curTime -= Time.deltaTime;
            if(curTime <= 0)
            {
                curSpeed = rb.velocity.magnitude;
                if(curSpeed >= dragonStatistic.maxSpeed)
                {
                    
                    curSpeed = dragonStatistic.maxSpeed;
                    return;
                }   
                
                rb.AddForce(directions.y * transform.forward * dragonStatistic.accelerationForce,ForceMode.Acceleration);
                curTime = dragonStatistic.wingTime;
            }   
    }
    public void GetAltitudeDirection(InputAction.CallbackContext callback)
    {
        altitudeDirection = callback.ReadValue<float>();
        return;
    }
    public void ChangeFly(InputAction.CallbackContext callback)
    {
        
        if(callback.started && isGrounded)
        {
            currentChangeFlyTime = 0;
            changeAnimation(0);
            isEvalute = true;
            
            
        }
        else if(callback.started && !isGrounded)
        {
            
            
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
