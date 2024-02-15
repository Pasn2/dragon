using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIExpManager : MonoBehaviour
{
    [SerializeField] SelectedSkills[] selectedUIObjects;
    [SerializeField] UIPerksManager perksManager;
    // Start is called before the first frame update
    void Start()
    {
        SetCurrentPerks();
    }
    public void SetCurrentPerks()
    {
        PerkScriptableObject[] currentPerks = perksManager.GetCurrentPerksScriptableObjects();
        for (int i = 0; i < currentPerks.Length; i++)
        {
            selectedUIObjects[i].SetStartUpUIElement(currentPerks[i].GetSprite());
            selectedUIObjects[i].SetDisplayData(currentPerks[i].GetNameTag(),currentPerks[i].GetDescryptionTag());
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
