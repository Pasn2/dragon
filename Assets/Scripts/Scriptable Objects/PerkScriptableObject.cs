using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Perk")]
public class PerkScriptableObject : ScriptableObject
{
    [SerializeField] string perkName;
    [SerializeField] string perkDescryption;
    [SerializeField] Sprite perkImage;
    [SerializeField] float perkDelay;
    [SerializeField]private float skillPoins = 0;
    [SerializeField] GameObject perk;
    [SerializeField]private SkillType skillType;
    
    public string GetName(){
        return perkName;
    }
    public string GetDescryption()
    {
        return perkDescryption;
    } 
    public Sprite GetSprite(){
        return perkImage;
    } 
    public float GetDelay()
    {
        return perkDelay;
    }
    public float GetRequestSkillPoints()
    {
        return skillPoins;
    }
    public GameObject GetPerk()
    {
        return perk;
    }
    public SkillType GetSkillType()
    {
        return skillType;
    }

    
}
