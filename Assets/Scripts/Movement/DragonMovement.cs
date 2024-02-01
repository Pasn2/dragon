using UnityEngine;
using UnityEngine.InputSystem;

public static class Helpers 
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}
public class DragonMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private float turnSpeed = 360;
    
    private Vector3 input;

    private void Update() {
        
        Look();
    }

    private void FixedUpdate() {
        Move();
    }

    

    private void Look() {
        if (input == Vector3.zero) return;

        var rot = Quaternion.LookRotation(input.ToIso(), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
    }

    private void Move() {
        rb.MovePosition(transform.position + transform.forward * input.normalized.magnitude * speed * Time.deltaTime);
    }
    public void GetDirectionsFromInputs(InputAction.CallbackContext callbackContext)
    {
        
        input = new Vector3(callbackContext.ReadValue<Vector2>().x,0,callbackContext.ReadValue<Vector2>().y);
    }    

    void Shockwave()
    {
        Debug.Log("DUPPS23");
    

        //shockwave.LandingShockWave();
        
    }
}


