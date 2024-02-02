using UnityEngine;
using UnityEngine.InputSystem;


public class DragonMovement : MonoBehaviour
{
    [SerializeField] Transform orientation;
    [SerializeField] Transform player;
    [SerializeField] Transform playerObj;
    [SerializeField] Rigidbody rb;
    [SerializeField] float rotationSpeed;
    [SerializeField] Vector2 direction;
    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update() 
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x,player.position.y,transform.position.z);
        orientation.forward = viewDir.normalized;
        Vector3 inpdir = orientation.forward * direction.y + orientation.right * direction.x;
        if(inpdir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward,inpdir.normalized, Time.deltaTime * rotationSpeed);
        }
    }
    public void GetDir(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }
}


