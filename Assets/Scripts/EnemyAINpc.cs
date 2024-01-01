using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAINpc : MonoBehaviour
{
    [SerializeField] NavMeshAgent agentAi;
    [SerializeField] Transform playerTransform;
    [SerializeField] Animator animator;
    [SerializeField] float playerDetectRange;
    [SerializeField] float attackRange;
    [SerializeField] bool hasWeapon;
    
    [SerializeField] WeaponHolder weaponHolder;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agentAi = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        weaponHolder.EquipWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        bool isPlayerInDetectRange =  Vector3.Distance(playerTransform.transform.position, transform.position) < playerDetectRange;
        bool isPlayerInAttackRange =  Vector3.Distance(playerTransform.transform.position, transform.position) < attackRange;
        if(isPlayerInDetectRange)
        {
            agentAi.destination = playerTransform.position;
            
        }
        
        
        
    }
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position,playerDetectRange);
        Gizmos.DrawWireSphere(transform.position,attackRange);
    }
    
}
