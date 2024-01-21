using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBurnState : AIState
{
    [SerializeField] GameObject burnEffect;
    Vector3 currentPointToMove;
    float stopdistance = 3f;
    
    [SerializeField]float burningTime = 4;
    [SerializeField] HealthSystem health;
    public void Enter(AIAgent agent)
    {
        health = agent.GetComponent<HealthSystem>();
            CheckForRandomPoint(agent); 
        if(health.GetIsBurning())
        {
        }
        
        
    }

    public void Exit(AIAgent agent)
    {
        
    }
    void CheckForRandomPoint(AIAgent agent)
    {
        if(health.GetIsBurning())
        {
            Vector3 point;
            
            if(SetRandomPointToGo(agent.transform.position,agent.agentConfig.maxBurnEscapeDistance,out point))
            {
                currentPointToMove = point;
                Debug.Log(currentPointToMove + "CUR POINT");
                agent.agent.SetDestination(point);
            }
        }
        else
        {
            agent.stateMachine.ChangeState(AiStateId.Idle);
        }
        
    }
    
    public AiStateId GetId()
    {
        return AiStateId.Burn;
    }

    public void Update(AIAgent agent)
    {
        float distance = Vector3.Distance(agent.transform.position,currentPointToMove);
        if(distance < stopdistance && health.GetIsBurning())
        {
        Debug.Log(distance + "DISTANCE ");
            CheckForRandomPoint(agent);
        }
        
        
    }
    private bool SetRandomPointToGo(Vector3 center, float range, out Vector3 result)
    {
        Debug.Log("SetRandomPointToGo");
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        Debug.Log(randomPoint + "RANDOMPOINT");
        if(NavMesh.SamplePosition(randomPoint,out hit , 1, NavMesh.AllAreas))
        {
            result = hit.position;
            Debug.Log(result + "RESULT");
            return true;
        }
        result = Vector3.zero;
        return false;
    }
    
}
