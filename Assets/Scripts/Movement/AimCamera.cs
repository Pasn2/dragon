using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCamera : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    private void Update() {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray , out RaycastHit raycastHit))
        {
            transform.position = raycastHit.point;
        }
    }
}
