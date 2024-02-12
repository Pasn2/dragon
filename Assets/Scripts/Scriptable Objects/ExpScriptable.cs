using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Experience",menuName = "ScriptableObjects/new Expierience")]
public class ExpScriptable : ScriptableObject
{
    [SerializeField] private float exp;
    public float GetExp()
    {
        return exp;
    }
}
