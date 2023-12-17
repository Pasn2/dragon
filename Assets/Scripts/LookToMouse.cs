using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class LookToMouse : MonoBehaviour
{
    // drag in your player object here via the Inspector
    
    [SerializeField] float rotationSpeed = 5.0f;
    [SerializeField] float minRot,maxRot;
    // If possible already drag your camera in here via the Inspector
    [SerializeField] private Camera _camera;
    [SerializeField] Transform headTransform;
    
    private Plane plane;

    void Start()
    {
        // create a mathematical plane where the ground would be
        // e.g. laying flat in XZ axis and at Y=0
        // if your ground is placed differently you'ld have to adjust this here
        plane = new Plane(Vector3.up, Vector3.zero);

        // as a fallback use the main camera
        if(!_camera) _camera = Camera.main;
    }

    void Update()
    {
        // Only rotate player while mouse is pressed
        // change/remove this according to your needs
        
            //Create a ray from the Mouse position into the scene
        var ray = _camera.ScreenPointToRay(Input.mousePosition);

            // Use this ray to Raycast against the mathematical floor plane
            // "enter" will be a float holding the distance from the camera 
            // to the point where the ray hit the plane
        if (plane.Raycast(ray, out var enter))
        {
                //Get the 3D world point where the ray hit the plane
            var hitPoint = ray.GetPoint(enter);

                // project the player position onto the plane so you get the position
                // only in XZ and can directly compare it to the mouse ray hit
                // without any difference in the Y axis
            var playerPositionOnPlane = plane.ClosestPointOnPlane(transform.position);
            
                // now there are multiple options but you could simply rotate the player so it faces 
                // the same direction as the one from the playerPositionOnPlane -> hitPoint 
            Vector3 direction = hitPoint - playerPositionOnPlane;
            
                
           
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            Vector3 targetEulerAngles = targetRotation.eulerAngles;
            
            //print(targetEulerAngles + "targetEulerAngles");
            if (transform.localRotation.y < minRot || transform.localRotation.y > maxRot) {
    // If it exceeds, determine the direction to rotate
            float targetAngle = (transform.localRotation.y < minRot) ? maxRot : minRot;

            // Rotate towards the target angle without halting
            Quaternion targetRotationAngle = Quaternion.Euler(transform.localRotation.x, targetAngle, transform.localRotation.z);
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotationAngle, rotationSpeed * Time.deltaTime);
            } else {
                // If within the limits, perform the rotation as before
                transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
        
    }
    public void AngleToRotateBody(Transform bodytransform)
    {
        Vector3 vectorToTarget = bodytransform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        print(angle + "angle");
        Debug.DrawLine(transform.position,vectorToTarget,Color.cyan);
        //Quaternion q = Quaternion.AngleAxis(angle, Vector3.up);
        bodytransform.RotateAround(transform.position,Vector3.down,angle);
         // Change Vector3.forward to Vector3.up
        //bodytransform.rotation = Quaternion.Euler(bodytransform.rotation.y,vectorToTarget);
        
        

            // Smoothly interpolate towards the target rotation
        
    }
        
    
    
}
