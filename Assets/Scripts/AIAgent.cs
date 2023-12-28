using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAgent : MonoBehaviour
{
    public AiStateMachine stateMachine;
    [SerializeField] AiStateId initialStage;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new AiStateMachine(this);
        stateMachine.ChangeState(initialStage);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }
}
