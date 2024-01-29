using System.Collections;
using System.Collections.Generic;
using Assets.SimpleLocalization.Scripts;
using UnityEngine;

public class LanguageChange : MonoBehaviour
{
    private void Awake() {
        LocalizationManager.Read();
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.C))
        {
            LocalizationManager.Language = "English";
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            LocalizationManager.Language = "Polish";

        }
    }
}
