using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
public class PerksManager : MonoBehaviour
{
    [SerializeField] PerkCards[] perkCards;
    [SerializeField] PerkScriptableObject[] perkSO;
    [SerializeField] InputActionAsset inputActions;
    [SerializeField] ReadOnlyArray<InputActionAsset> allBindings {get;}
    [SerializeField] DragonBreathe dragonBreathe;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(inputActions.FindActionMap("Ability").actions.Count);
        dragonBreathe.SetBinding(inputActions.FindActionMap("Ability").FindAction("Main Ability"));
        
        for (int i = 0; i < inputActions.FindActionMap("Ability").actions.Count; i++)
        {
            
            print(inputActions.FindActionMap("Ability").FindAction("Ability " + i).GetBindingDisplayString());
            if(perkCards[i] == null) break;
            SetPerks(perkCards[i],perkSO[i],inputActions.FindActionMap("Ability").FindAction("Ability " + i).GetBindingDisplayString());
        }
    }

    void SetPerks(PerkCards currentPerk,PerkScriptableObject perkScriptable,string perkKeyBind)
    {
        currentPerk.SetCard(perkScriptable,perkKeyBind);
    }
    
}
