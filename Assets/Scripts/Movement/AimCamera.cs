using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCamera : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] LayerMask ignoreLayer;
    private void Start() {
        
    }
    private void Update() {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out RaycastHit raycastHit,Mathf.Infinity,ignoreLayer))
        {
            print(raycastHit.collider.name + "Name");
            print(raycastHit.collider.gameObject.layer.ToString() + "LAYER");
            transform.position = raycastHit.point;
            
        }
    }
}
