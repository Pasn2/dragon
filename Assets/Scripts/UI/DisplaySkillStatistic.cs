using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DisplaySkillStatistic : MonoBehaviour
{
    [SerializeField] TMP_Text skillNameText;
    [SerializeField] TMP_Text skillDescryptionText;
    [SerializeField] Button equipBtn;
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
        skillNameText = GameObject.Find("SkillName").GetComponent<TMP_Text>();
        skillDescryptionText = GameObject.Find("SkillDescryption").GetComponent<TMP_Text>();
    }
    public void DisplayStatistic(string _skillName, string _skillDescryption)
    {
        skillNameText.text = _skillName;
        skillDescryptionText.text = _skillDescryption;
    }
    public void CheckButton(bool canUseBtn)
    {
        switch(canUseBtn)
        {
            case true:
                equipBtn.gameObject.SetActive(true);
            break;
            case false:
                equipBtn.gameObject.SetActive(false);
            break;
        }
    }
}
