using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExperienceAdd : MonoBehaviour
{
    
    public void AddExp(float _addedExp)
    {
        ExperienceManager.instance.AddExp(_addedExp);
    }
}
