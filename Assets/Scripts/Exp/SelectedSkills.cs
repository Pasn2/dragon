using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Image))]
public class SelectedSkills : MonoBehaviour ,ExpHexagonDisplay
{
    [SerializeField] Image imagetoView;
    protected string skillName;
    protected string skillDescryption;
    private void Awake() {
        imagetoView = GetComponent<Image>();
    }
    public void DisplayData()
    {
        DisplaySkillStatistic.instance.DisplayStatistic(skillName,skillDescryption);
    }

    public void SetStartUpUIElement(Sprite _image)
    {
        imagetoView.sprite = _image;
    }
    public void SetDisplayData(string _name,string _desc)
    {
        skillName = _name;
        skillDescryption = _desc;
    }
    
}
