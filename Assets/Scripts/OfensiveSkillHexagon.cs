using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfensiveSkillHexagon : MonoBehaviour, ExpHexagon 
{
    [SerializeField] private ExpTreeScriptableObject expTreeScriptable;
    [SerializeField] bool isUnlocked;
    [SerializeField] private Image skillIcon;
    
    private void Start() {
        skillIcon = this.gameObject.GetComponent<Image>();
        SetStartUpUIElement();
    }

    public void CheckAmountSkillPoints()
    {
        PlayerSkills playerSkills = PlayerSkills.playerSkills;
        if(playerSkills.GetCurrentSkillPoints() >= expTreeScriptable.GetRequestSkillPoints())
        {
            playerSkills.SetCurrentSkillPoints(-expTreeScriptable.GetRequestSkillPoints());
            UnlockSkill();
        }
    }

    public void SetStartUpUIElement()
    {
        skillIcon.sprite = expTreeScriptable.GetSpriteIcon();
    }

    public void UnlockSkill()
    {
        isUnlocked = true;
        throw new System.NotImplementedException();
    }

    

    public void DisplayData()
    {
        DisplaySkillStatistic.instance.DisplayStatistic(expTreeScriptable.GetExpSkillName(),expTreeScriptable.GetSkillNameDescription());
        
    }
}
