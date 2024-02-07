using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCamera : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] LayerMask ignoreLayer;
    private void Start() {
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(),GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>());
    }
    private void Update() {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray , out RaycastHit raycastHit,ignoreLayer))
        {
            print(raycastHit.collider.name + "Name");
            transform.position = raycastHit.point;
            print(raycastHit.point);
        }
    }
}
