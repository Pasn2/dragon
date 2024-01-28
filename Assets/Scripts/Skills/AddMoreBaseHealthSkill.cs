using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoreBaseHealthSkill : MonoBehaviour,  ISkill
{
    [SerializeField] float percentAmountHealthToAdd;

    

    public void UseSkill()
    {
        DragonHealth dragonObject = GameObject.FindGameObjectWithTag("Player").GetComponent<DragonHealth>();
        dragonObject.SetNewPercentBaseHealth( percentAmountHealthToAdd);
        DestroySkill();
        
    }

    public void DestroySkill()
    {
        Destroy(this.gameObject);
    }
}
