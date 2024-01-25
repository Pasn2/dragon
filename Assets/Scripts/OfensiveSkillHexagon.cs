using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfensiveSkillHexagon : MonoBehaviour, ExpHexagon 
{
    [SerializeField] private ExpTreeScriptableObject expTreeScriptable;
    [SerializeField] bool isUnlocked;
    [SerializeField] bool canBeBuy;
    [SerializeField] private Image skillIcon;
    [SerializeField] GameObject[] nextSkillsTree;
    [SerializeField] Image blockedImage;
    
    private void Start() {
        
        SetStartUpUIElement();
    }

    public void CheckAmountSkillPoints()
    {
        PlayerSkills playerSkills = PlayerSkills.playerSkills;
        if(playerSkills.GetCurrentSkillPoints() >= expTreeScriptable.GetRequestSkillPoints() && !canBeBuy)
        {
            playerSkills.SetCurrentSkillPoints(-expTreeScriptable.GetRequestSkillPoints());
            UnlockSkill();
        }
    }
    public void UnlockSkill()
    {
        isUnlocked = true;
        blockedImage.gameObject.SetActive(false);
        foreach (GameObject skillHex in nextSkillsTree)
        {
            if(skillHex.TryGetComponent<ExpHexagon>(out ExpHexagon hex))
            {
                hex.ChangeVisiblityAndAcces();

            }
            break;
            
        }
        
    }
    public void SetStartUpUIElement()
    {
        skillIcon.sprite = expTreeScriptable.GetSpriteIcon();
        ChangeVisiblityAndAcces();
         
    }

    

    

    public void DisplayData()
    {
        DisplaySkillStatistic.instance.DisplayStatistic(expTreeScriptable.GetExpSkillName(),expTreeScriptable.GetSkillNameDescription());
        
    }

    public void ChangeVisiblityAndAcces()
    {
        print(gameObject.name);
        Image backImage = gameObject.GetComponent<Image>();
        Image[] restImage = gameObject.GetComponentsInChildren<Image>();
        if(!isUnlocked)
        {
            canBeBuy = true;
            backImage.color =  new Color(backImage.color.r, backImage.color.g, backImage.color.b, 0.3f);
            foreach (Image image in restImage)
            {
                image.color = new Color(backImage.color.r, backImage.color.g, backImage.color.b, 0.3f);
            }
        }
        else
        {
            canBeBuy = false;
            backImage.color =  new Color(backImage.color.r, backImage.color.g, backImage.color.b, 1f);
            foreach (Image image in restImage)
            {
                image.color = new Color(backImage.color.r, backImage.color.g, backImage.color.b, 0.3f);
            }
        }
        
    }
}
