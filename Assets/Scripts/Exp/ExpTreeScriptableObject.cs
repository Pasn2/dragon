using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PerkTreeStats",menuName = "ScriptableObjects/new PerkTreeStats")]
public class ExpTreeScriptableObject : ScriptableObject
{
    [SerializeField]private float skillPoins = 0;
    [SerializeField]private string skillName;
    [SerializeField]private string skillDescription;
    [SerializeField]private Sprite skillIcon;
    [SerializeField]private SkillType skillType;
    [SerializeField] private GameObject skillGO;
    

    public float GetRequestSkillPoints()
    {
        return skillPoins;
    }
    
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

    public SkillType GetSkillType()
    {
        return skillType;
    }

    public GameObject GetSKillGameObject()
    {
        return skillGO;
    }
}
