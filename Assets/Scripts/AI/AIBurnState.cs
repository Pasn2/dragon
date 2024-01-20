using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBurnState : AIState
{
    [SerializeField] GameObject burnEffect;
    Vector3 currentPointToMove;
    float stopdistance = 2f;
    public void Enter(AIAgent agent)
    {
        Vector3 point;
        if(SetRandomPointToGo(agent.transform.position,agent.agentConfig.maxBurnEscapeDistance,out point))
        {
            agent.agent.SetDestination(point);
        }
    }

    public void Exit(AIAgent agent)
    {
        
    }

    public AiStateId GetId()
    {
        return AiStateId.Burn;
    }

    public void Update(AIAgent agent)
    {
        float distance = Vector3.Distance(agent.transform.position,currentPointToMove);
        if(distance < stopdistance)
        {
            
        }
    }
    private bool SetRandomPointToGo(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if(NavMesh.SamplePosition(randomPoint,out hit , 1, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }
    
}
