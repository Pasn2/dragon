using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    [SerializeField] float currentSkillPoints;
    [SerializeField] public static PlayerSkills playerSkills;
    //Delete SigletonPattern its for testing right now
    private void Awake() {
        // Ensure there is only one instance
        if (playerSkills != null && playerSkills != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            playerSkills = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public float GetCurrentSkillPoints()
    {
        return currentSkillPoints;
    }
    public float SetCurrentSkillPoints(float _changedValue)
    {
        return currentSkillPoints += _changedValue;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
