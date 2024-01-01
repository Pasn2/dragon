using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AiWeapon : MonoBehaviour
{
    [SerializeField] WeaponIK weapon;
    [SerializeField] Transform curTarget;
    
    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponent<WeaponIK>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Transform GetTarget(Transform changeTransform)
    {
        return curTarget = changeTransform;
    }
}
