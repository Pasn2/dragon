using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
public class UIPerksManager : MonoBehaviour
{
    [SerializeField] UIPerkCards[] perkCards;
    [SerializeField] PerkScriptableObject[] perkSO;
    [SerializeField] InputActionAsset inputActions;
    
    [SerializeField] DragonBreathe dragonBreathe;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(inputActions.FindActionMap("Ability").actions.Count);
       // dragonBreathe.SetBinding(inputActions.FindActionMap("Ability").FindAction("Main Ability"));
        
        for (int i = 0; i < inputActions.FindActionMap("Ability").actions.Count; i++)
        {
            
            if(perkCards[i] == null) break;
            
            SetPerks(perkCards[i],perkSO[i],inputActions.FindActionMap("Ability").FindAction("Ability " + i).GetBindingDisplayString());
        }
    }

    void SetPerks(UIPerkCards currentPerk,PerkScriptableObject perkScriptable,string perkKeyBind)
    {
        currentPerk.SetCardDisplay(perkScriptable,perkKeyBind);
    }
    
}
