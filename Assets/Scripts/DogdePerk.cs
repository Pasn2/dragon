using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogdePerk : MonoBehaviour , IPerk
{
    [SerializeField] float dogeSpeed;
    public void UsePerk()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        
    }
    
    
}
