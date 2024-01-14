using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMeleeAtack : AIState
{
    MeleeAtack meleeAtack;
    public void Enter(AIAgent agent)
    {
        Debug.Log("Geting MeleeAttack");
        meleeAtack = agent.transform.GetComponent<MeleeAtack>();
        
    }

    public void Exit(AIAgent agent)
    {
        
    }

    public AiStateId GetId()
    {
        return AiStateId.MeleeAttack;
    }

    public void Update(AIAgent agent)
    {
        float distance = Vector3.Distance(agent.playerTransform.position, agent.transform.position);
        Debug.Log(distance);
        if(distance <= agent.agentConfig.maxAttackDistance)
        {
            
            Debug.Log("UPDATE chnage state");
            agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
            
        }
        else{
            meleeAtack.UseMeleeeWeapon();
            Debug.Log("UPDATE MELLE ATACK WORKS");
        }
        
        

    }

    
}
