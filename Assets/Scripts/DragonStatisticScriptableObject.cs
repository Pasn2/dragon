using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon")]
public class DragonStatisticScriptableObject : ScriptableObject
{
    public float maxSpeed;
    public float accelerationForce;
    public float wingTime;
    public float jumptForce;
    public float altidudeGrain;
    public AnimationCurve increasingCurveY;
    public AnimationCurve fallingCurveY;
    public float maxAltitude;
}
