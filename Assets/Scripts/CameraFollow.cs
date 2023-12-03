using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    [SerializeField] float delay;
    [SerializeField] Transform followTarget;
    [SerializeField] Camera mainCamera;
    [SerializeField] Vector3 offset;
    [SerializeField] Vector3 curVelocity;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPos = followTarget.position + offset;
        mainCamera.transform.position = Vector3.SmoothDamp(transform.position, targetPos,ref curVelocity,delay);
    }
}
