using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiIdleState : AIState
{
    public void Enter(AIAgent agent)
    {
       
    }

    public void Exit(AIAgent agent)
    {
        
    }

    public AiStateId GetId()
    {
        return AiStateId.Idle;
    }

    public void Update(AIAgent agent)
    {
        Vector3 playerdir = agent.playerTransform.position - agent.transform.position;
        if(playerdir.magnitude > agent.agentConfig.maxSightDistance) return;
        Vector3 agentdir = agent.transform.forward;
        playerdir.Normalize();
        float dotProduct = Vector3.Dot(playerdir, agentdir);
        if(dotProduct > 0)
        {
            agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
        }
    }

    
}
