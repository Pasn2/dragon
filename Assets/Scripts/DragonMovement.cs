using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
public class DragonMovement : MonoBehaviour
{
    [SerializeField] DragonStatisticScriptableObject dragonStatistic;
    [SerializeField] PlayerInput movementAction;
    [SerializeField] Rigidbody rb;
    [SerializeField] LandingShockwave shockwave;
    [SerializeField] Transform groundCheckTransform;
    [SerializeField] float curSpeed;
    [SerializeField] Vector3 directions;
    
    [SerializeField] float curTime;
    
    [SerializeField] float currentChangeFlyTime;
    [SerializeField] bool isGrounded;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] bool isEvalute;
    private AnimationCurve currentAnimationCurve;
    float altitudeDirection;
    [SerializeField]float curAltitude;
    
    
    
    private void Start()
    {
        curTime = dragonStatistic.wingTime;
        shockwave.SetLandingParameters(dragonStatistic.shockwaveDistance,dragonStatistic.shockwaveForce,dragonStatistic.shockwaveMultiplier);
        
    }
    
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(groundCheckTransform.position,groundCheckRadius);
        Gizmos.DrawRay(transform.position,-Vector3.up * dragonStatistic.maxAltitude);
    }
    private void Update() {
        
        ChangeFly(currentAnimationCurve);
        CurrentAltitude();
        curSpeed = Vector3.Magnitude(rb.velocity);
        
        
    }
    float CurrentAltitude()
    {
        Ray ray = new Ray(transform.position,-Vector3.up * dragonStatistic.maxAltitude);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,groundLayerMask))
        {
            
            curAltitude = Vector3.Distance(transform.position,hit.point);
            
            return curAltitude;
        }
        return curAltitude;
    }
     bool CanChangeAltitude()
    {
        
        
            
            if(CurrentAltitude() < dragonStatistic.maxAltitude)
            {
                
                return true;
            }
            
            
            return false;
        
        
    }
    private void OnCollisionEnter(Collision other) {
        print(other.gameObject.name + "NAMEODB");
        if(curSpeed > 20)
        {
            print(other.gameObject.name + "NAMEODB2333333333");
            Shockwave();
        }
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
                print(curve.Evaluate(currentChangeFlyTime) + "DAW");
                
                        // Perform actions when the animation reaches its end
                        
            }
        }
    }
    void Shockwave()
    {
        Debug.Log("DUPPS23");

        shockwave.LandingShockWave();
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
    void ApplyForceWhenInAir(float altitude)
    {
        
    }
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheckTransform.position,groundCheckRadius,groundLayerMask);

        
        if(directions.magnitude != 0)
        {
        StraightMovment();

        }
        
        
        if(curAltitude != 0)
        {
            if(!isGrounded)
            {
                CanChangeAltitude();
            }
            if(isGrounded )
            {
                
            }
            
        }
        if(altitudeDirection != 0)
        {
        
            rb.AddForce(transform.up * altitudeDirection * dragonStatistic.altidudeGrain);
        }
        
        
    }
    
    void StraightMovment()
    {
        rb.velocity = transform.forward * directions.y * dragonStatistic.accelerationForce + transform.right * directions.x * dragonStatistic.accelerationForce ;

            
        
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
