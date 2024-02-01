using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Perk")]
public class PerkScriptableObject : ScriptableObject
{
    public string perkName;
    public Sprite perkImage;
    public float perkDelay;
    public GameObject perk;
}
