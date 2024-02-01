using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum AltitudeChangeCurves{
    FlyUp,Landing
}
public class AltitudeMovement : MonoBehaviour
{
    private float altitudeDirection;
    [SerializeField] AnimationCurve[] altitudeChangeCurves;
    [SerializeField] Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeFly(InputAction.CallbackContext callback)
    {
        
        if(callback.started )
        {
            rb.AddForce(Vector3.up * 100);
            
        }
        
        
        
        
    }
    /*void changeAnimation(int id)
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
    */
    public void GetAltitudeDirection(InputAction.CallbackContext callback)
    {
        altitudeDirection = callback.ReadValue<float>();
        return;
    }
    

}
