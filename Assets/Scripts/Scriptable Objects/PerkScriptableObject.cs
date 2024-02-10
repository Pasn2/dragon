using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Perk")]
public class PerkScriptableObject : ScriptableObject
{
    [SerializeField] string perkName;
    [SerializeField] Sprite perkImage;
    [SerializeField] float perkDelay;
    [SerializeField] GameObject perk;
    public string GetName(){
        return perkName;
    } 
    public Sprite GetSprite(){
        return perkImage;
    } 
    public float GetDelay()
    {
        return perkDelay;
    }
    public GameObject GetPerk()
    {
        return perk;
    }
}
