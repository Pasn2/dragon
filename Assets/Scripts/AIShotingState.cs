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
        
        float playerDistance = Vector3.Distance(agent.transform.position,agent.playerTransform.position);
       
        if(playerDistance > agent.agentConfig.maxShootingDistance * agent.agentConfig.maxShootingDistance)
        {
            
            agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
            return;
        }
        if(playerDistance <= agent.agentConfig.maxShootingDistance)
        {
            
            weaponIk.SetTargetTransform(agent.playerTransform); 
            
            
            agent.stateMachine.ChangeState(AiStateId.Idle);
        }
        
        
        
    }
    

    
}
