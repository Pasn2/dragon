using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
    public Transform playerTransform;
    public AiStateMachine stateMachine;
    [SerializeField] AiStateId initialStage;
    public NavMeshAgent agent;
    public AiAgentConfig agentConfig;
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        stateMachine = new AiStateMachine(this);
        stateMachine.RegisterState(new AiChasePlayerState());
        stateMachine.RegisterState(new AiIdleState());
        stateMachine.ChangeState(initialStage);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
        if(agent.hasPath)
        {
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }
        else{
            animator.SetFloat("Speed", 0);
        }
    }
}
