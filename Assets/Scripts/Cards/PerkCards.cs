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
    [SerializeField]PerkScriptableObject curPerk;
    [SerializeField] GameObject perkStartPos;
    [SerializeField]bool canUsePerk = true;

    void Update()
    {
        
        if(inputActions.FindAction(abilityName).ReadValue<float>() > 0)
        {
            if(canUsePerk)
            {
                StartCoroutine(Delay(curPerk.GetDelay()));
                canUsePerk = false;
            }
            
        }
        
    }
    IEnumerator Delay(float delay)
    {
        Debug.Log("Delay Invoked");
        StartPerk();
        yield return new WaitForSeconds(delay);
        canUsePerk = true;
    }
    public void SetCardDisplay(PerkScriptableObject perkScriptable,string keyName)
    {
        curPerk = perkScriptable;
        print(perkScriptable.GetSprite() + "SPRIUTE" + gameObject.name);
        currentPerkImage.sprite = perkScriptable.GetSprite();
        keyBindngText.text = keyName;
    }
    public void StartPerk()
    {
        if (curPerk != null)
        {
            GameObject game = Instantiate(curPerk.GetPerk(), transform.position, transform.rotation);
            
            if (game != null)
            {
                print(game.name + "GAMEDAREW");
                game.transform.parent = perkStartPos.transform;

                IPerk perkComponent = game.GetComponent<IPerk>();
                Debug.Log(perkComponent + "BABAHASAN");
                if (perkComponent != null)
                {
                    Debug.Log(perkComponent + "BABAHASAN233");
                    perkComponent.UsePerk();
                }
                else
                {
                    Debug.LogError("IPerk component not found on the instantiated object.");
                }
            }
            else
            {
                Debug.LogError("Instantiation of perk object failed.");
            }
        }
        else
        {
            Debug.LogError("curPerk is not assigned.");
        }
    }
}
