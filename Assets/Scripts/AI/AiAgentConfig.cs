using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AiAgentConfig : ScriptableObject
{
    public float maxTime;
    public float maxDistance;
    public float maxSightDistance;
    public AIType aiType;
    public float maxAttackDistance;
    public float maxBurnEscapeDistance;
}
