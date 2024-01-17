using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class UIPerkCards : MonoBehaviour
{
    [SerializeField] TMP_Text keyBindngText;
    [SerializeField] Image currentPerkImage;
    [SerializeField] InputActionAsset inputActions;
    [SerializeField]private string abilityName;
    PerkScriptableObject curPerk;
    [SerializeField]float timer;
    [SerializeField]bool canUsePerk = true;

    void Update()
    {
        
        if(inputActions.FindAction(abilityName).ReadValue<float>() > 0)
        {
            StartCoroutine(Delay(curPerk.perkDelay));
        }
        
    }
    IEnumerator Delay(float delay)
    {
        StartPerk();
        yield return new WaitForSeconds(delay);
        canUsePerk = true;
    }
    public void SetCardDisplay(PerkScriptableObject perkScriptable,string keyName)
    {
        curPerk = perkScriptable;
        currentPerkImage.sprite = perkScriptable.perkImage;
        keyBindngText.text = keyName;
    }
    public void StartPerk()
    {
        GameObject game = Instantiate(curPerk.perk,transform.position,Quaternion.identity);
        game.transform.parent = this.transform;
        game.GetComponent<IPerk>().UsePerk();
        
    }
}
