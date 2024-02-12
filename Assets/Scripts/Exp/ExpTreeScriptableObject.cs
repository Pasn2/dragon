using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PerkTreeStats",menuName = "ScriptableObjects/new PerkTreeStats")]
public class ExpTreeScriptableObject : ScriptableObject
{
    
    [SerializeField]private string skillName;
    [SerializeField]private string skillDescription;
    [SerializeField]private Sprite skillIcon;
    
    

    
    
    public string GetExpSkillName()
    {
        return skillName;
    }

    public string GetSkillNameDescription()
    {
        return skillDescription;
    }

    public Sprite GetSpriteIcon()
    {
        return skillIcon;
    }

    
}
