using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIExpManager : MonoBehaviour
{
    [SerializeField] Image[] selectedUIObjects;
    [SerializeField] UIPerksManager perksManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetCurrentPerks()
    {
        PerkScriptableObject[] currentPerks = perksManager.GetCurrentPerksScriptableObjects();
        for (int i = 0; i < currentPerks.Length; i++)
        {
            selectedUIObjects[i].sprite = currentPerks[i].GetSprite();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
