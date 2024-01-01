using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class AiChasePlayerState : AIState
{
    
    public float maxTime = 1;
    public float maxDistance = 1;
    float timer = 0;

    public void Enter(AIAgent agent)
    {
        Debug.Log("Changing 2");
        
    }

    public void Exit(AIAgent agent)
    {
        
    }

    public AiStateId GetId()
    {
        return AiStateId.ChasePlayer;
    }

    public void Update(AIAgent agent)
    {
        if(!agent.enabled) return;
        timer -= Time.deltaTime;
        if(!agent.agent.hasPath)
        {
            agent.agent.destination = agent.playerTransform.position;
        }
        if(timer < 0)
        {
            Vector3 direction = (agent.playerTransform.position - agent.agent.destination);
            direction.y = 0;
            if(direction.sqrMagnitude > agent.agentConfig.maxDistance * agent.agentConfig.maxDistance )
            {
                if(agent.agent.pathStatus != NavMeshPathStatus.PathPartial)
                {
                    agent.agent.destination = agent.playerTransform.position;
                }
            }
            if(direction.sqrMagnitude <= agent.agentConfig.maxShootingDistance * agent.agentConfig.maxShootingDistance)
            {
                Debug.LogWarning("DAW");
                 agent.stateMachine.ChangeState(AiStateId.Shooting);
                 
            }
            timer = agent.agentConfig.maxTime;
        }
    }

    
}
