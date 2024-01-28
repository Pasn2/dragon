using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ButtonDoubleClickListener), typeof(Button))]
public class SkillHexagon : MonoBehaviour, ExpHexagon 
{
    [SerializeField] private ExpTreeScriptableObject expTreeScriptable;
    [SerializeField] bool isUnlocked;
    [SerializeField] bool canBeBuy;
    [SerializeField] private Image skillIcon;
    [SerializeField] GameObject[] nextSkillsTree;
    [SerializeField] Image blockedImage;
    
    private void Start() {
        
        print("FUNTION START " + gameObject.name);
        SetStartUpUIElement();
        if(!canBeBuy) return;
        
        print("IS CAN BE BUY: " + gameObject.name);
        ChangeValueInOtherSkills();
        ChangeVisiblityAndAcces();
    }

    public void CheckAmountSkillPoints()
    {
        PlayerSkills playerSkills = PlayerSkills.playerSkills;
        if(playerSkills.GetCurrentSkillPoints() >= expTreeScriptable.GetRequestSkillPoints() && canBeBuy && !isUnlocked)
        {
            playerSkills.SetCurrentSkillPoints(-expTreeScriptable.GetRequestSkillPoints());
            UnlockSkill();
        }
    }

    public void UnlockSkill()
    {
        print("DARAS");
        isUnlocked = true;
        ISkill skill = Instantiate(expTreeScriptable.GetSKillGameObject()).GetComponent<ISkill>();
        skill.UseSkill();
        print("SKILL UNLOCKED: " + gameObject.name);
        ChangeValueInOtherSkills();
        ChangeVisiblityAndAcces();
        
    }

    void ChangeValueInOtherSkills()
    {
        if(isUnlocked)
        {
            if(nextSkillsTree.Length == 0)
            {
                Debug.LogWarning("There is no next skills");
            }
            foreach (GameObject skillHex in nextSkillsTree)
            {
                if(skillHex.TryGetComponent<ExpHexagon>(out ExpHexagon hex))
                {
                    print("Succesful trygetcomponent " + gameObject.name);
                    hex.ChangeCanBuy();
                }
            }
            
        }
        
    }

    public void SetStartUpUIElement()
    {
        skillIcon.sprite = expTreeScriptable.GetSpriteIcon();
    }
    void ChangeBlockade()
    {
        print("I CHANGE THE BLOCKADE: " + gameObject.name);
        blockedImage.gameObject.SetActive(false);
        ChangeVisiblityAndAcces();
    }
    
    public void DisplayData()
    {
        DisplaySkillStatistic.instance.DisplayStatistic(expTreeScriptable.GetExpSkillName(),expTreeScriptable.GetSkillNameDescription());
    }

    public void ChangeVisiblityAndAcces()
    {
        print("I CHANGE MY VISIBLITY: " + gameObject.name);
        
        Image backImage = gameObject.GetComponent<Image>();
        Image[] restImage = gameObject.GetComponentsInChildren<Image>();
        if(!isUnlocked)
        {
            print("I AM NOT UNLOCKED : " + gameObject.name);
            
            backImage.color =  new Color(backImage.color.r, backImage.color.g, backImage.color.b, 0.3f);
            foreach (Image image in restImage)
            {
                image.color = new Color(backImage.color.r, backImage.color.g, backImage.color.b, 0.3f);
            }
        }
        else
        {
            print("I AM UNLOCKED : " + gameObject.name);
            backImage.color =  new Color(backImage.color.r, backImage.color.g, backImage.color.b, 1f);
            foreach (Image image in restImage)
            {
                image.color = new Color(backImage.color.r, backImage.color.g, backImage.color.b, 1f);
            }
        }
        
    }

    public void ChangeCanBuy()
    {
        print("I AM CHANGE CAN BE BUY AND REMOVE THE BLOCKADE : " + gameObject.name);
        canBeBuy = true;
        ChangeBlockade();
    }
}