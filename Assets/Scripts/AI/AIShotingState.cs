using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIShotingState : AIState
{
    public float maxSightDistance = 1;
    public WeaponIK weaponIk;
    public void Enter(AIAgent agent)
    {
        weaponIk = agent.GetComponent<WeaponIK>();
                Debug.Log("Changing");

    }

    public void Exit(AIAgent agent)
    {
        
    }

    public AiStateId GetId()
    {
        return AiStateId.Shooting;
    }

    public void Update(AIAgent agent)
    {
        
        if(agent.playerTransform == null) return;
        
        float playerDistance = Vector3.Distance(agent.transform.position,agent.playerTransform.position);
       
        if(playerDistance > agent.agentConfig.maxAttackDistance * agent.agentConfig.maxAttackDistance)
        {
            Debug.Log("Not in distance");
            agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
            return;
        }
        if(playerDistance <= agent.agentConfig.maxAttackDistance)
        {
            Debug.Log("AI in dragon gun range");
            weaponIk.SetTargetTransform(agent.playerTransform); 
            agent.agent.SetDestination(agent.transform.position);
            
            agent.playerTransform = null;
            return;
        }
        
        
        
    }
    

    
}
