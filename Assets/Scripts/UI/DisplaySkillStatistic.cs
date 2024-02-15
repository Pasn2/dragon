using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Assets.SimpleLocalization.Scripts;
public class DisplaySkillStatistic : MonoBehaviour
{
    [SerializeField] LocalizedText skillNameTextTranslation;
    [SerializeField] LocalizedText skillDescryptionTextTranslation;
    public static DisplaySkillStatistic instance;
    private void Awake() {
        // Ensure there is only one instance
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Start() {
        skillNameTextTranslation = GameObject.Find("SkillName").GetComponent<LocalizedText>();
        skillDescryptionTextTranslation = GameObject.Find("SkillDescryption").GetComponent<LocalizedText>();
    }
    public void DisplayStatistic(string _skillTagName, string _skillTagDescryption)
    {
        skillNameTextTranslation.LocalizationKey = _skillTagName;
        skillDescryptionTextTranslation.LocalizationKey = _skillTagDescryption;
    }
    
}
