using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.SimpleLocalization.Scripts
{
	/// <summary>
	/// Localize text component.
	/// </summary>
    
    public class LocalizedText : MonoBehaviour
    {
        public string localizationKey;
        public string LocalizationKey{get
        {
            return localizationKey;
        }
        set
        {
            localizationKey = value;
            Localize();
        }}
        private TMP_Text Displaytext;
        public void Start()
        {
            if(TryGetComponent<TMP_Text>(out TMP_Text text))
            {
                Displaytext = text;
            }
            Localize();
            LocalizationManager.OnLocalizationChanged += Localize;
        }

        public void OnDestroy()
        {
            LocalizationManager.OnLocalizationChanged -= Localize;
        }

        private void Localize()
        {
            
            Displaytext.text = LocalizationManager.Localize(LocalizationKey);
            
        }
    }
}