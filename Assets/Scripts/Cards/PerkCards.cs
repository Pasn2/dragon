using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PerkCards : MonoBehaviour
{
    [SerializeField] TMP_Text keyBindngText;
    [SerializeField] Image currentPerkImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetCard(PerkScriptableObject perkScriptable,string keyName)
    {
        currentPerkImage.sprite = perkScriptable.perkImage;
        keyBindngText.text = keyName;
    }
    public void InvokePerk()
    {
        print("Perk Invoked");
    }
}
