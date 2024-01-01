using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiStateMachine : MonoBehaviour
{
    AIState[] states;
    [SerializeField] AIAgent agent;
    [SerializeField] AiStateId currentState;
    public AiStateMachine(AIAgent agent)
    {
        this.agent = agent;
        int numStates = System.Enum.GetNames(typeof(AiStateId)).Length;
        states = new AIState[numStates];
    }
    
    public void RegisterState(AIState state)
    {
        int index = (int)state.GetId();
        states[index] = state;
    }
    public AIState GetState(AiStateId stateId)
    {
        int index = (int)stateId;
        return states[index];
    }
    public void Update()
    {
        GetState(currentState)?.Update(agent);
    }
    public void ChangeState(AiStateId newState)
    {
        
        GetState(currentState)?.Exit(agent);
        Debug.LogWarning(currentState + "!");
        currentState = newState;
        Debug.LogWarning(currentState + "@");
        GetState(currentState)?.Enter(agent);
    }
}
