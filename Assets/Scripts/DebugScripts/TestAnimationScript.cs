using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public enum AnimParaMeterType
{
    Bool,Trigger
}
public class TestAnimationScript : MonoBehaviour
{
    [SerializeField] Animator curAnim;
    [SerializeField] AnimParaMeterType animParaMeterType;
    [SerializeField] string animId;
    [SerializeField] KeyCode key;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key))
        {
            switch(animParaMeterType)
            {
                case AnimParaMeterType.Trigger:
                    curAnim.SetTrigger(animId);
                break;
                case AnimParaMeterType.Bool:
                    curAnim.SetBool(animId,!curAnim.GetBool(animId));
                break;
            }
        }
    }
}
