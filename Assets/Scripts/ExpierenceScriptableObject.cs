using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Exp",menuName = "ScriptableObjects/new Exp to add")]
public class ExpierenceScriptableObject : ScriptableObject
{
    [SerializeField] private float expToAdd;
    public float GetExpToAdd()
    {
        return expToAdd;
    }
}
