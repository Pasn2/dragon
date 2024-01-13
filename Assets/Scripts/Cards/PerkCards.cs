using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class PerkCards : MonoBehaviour
{
    [SerializeField] TMP_Text keyBindngText;
    [SerializeField] Image currentPerkImage;
    
    
    [SerializeField] InputActionAsset inputActions;
    [SerializeField] string abilityName;
    PerkScriptableObject curPerk;
    [SerializeField]float timer;
    [SerializeField]bool canUsePerk = true;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if(inputActions.FindAction(abilityName).ReadValue<float>() > 0)
        {
            InvokePerk();
        }
        if(!canUsePerk)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                canUsePerk = true;
            }
        }
    }
    public void SetCardDisplay(PerkScriptableObject perkScriptable,string keyName)
    {
        curPerk = perkScriptable;
        currentPerkImage.sprite = perkScriptable.perkImage;
        keyBindngText.text = keyName;
    }
    public void InvokePerk()
    {
        if(canUsePerk)
        {
            timer = curPerk.perkDelay;
        print("Perk Invoked2");
            canUsePerk = false;
            return;
        }
        print("Perk Invoked");
        
    }
}
