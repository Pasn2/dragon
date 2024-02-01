using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HumanBone
{
    public HumanBodyBones bone;
    public float weight = 1;
}
public class WeaponIK : MonoBehaviour
{
    public Transform targetTransform;
    public Transform aimTransfrom;
    public Weapon currentWeapon;
    [SerializeField] float iterations = 10;
    [Range(0,1)]
    [SerializeField] float weight = 1;
    [SerializeField]private float angleLimit = 90;
    [SerializeField]private float distanceLimit = 1.5f;
    public HumanBone[] humanBones;
    public bool isTargeted;
    Transform[] boneTransforms;
    [SerializeField] float distance;
    [SerializeField] Animator weaponholdingAnimator;
    // Start is called before the first frame update
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        boneTransforms = new Transform[humanBones.Length];
        for (int i = 0; i < boneTransforms.Length; i++)
        {
            boneTransforms[i] = animator.GetBoneTransform(humanBones[i].bone);
        }
    }
    Vector3 GetTargetPosition()
    {
        
        Vector3 aimDirection = aimTransfrom.forward;
        Vector3 targetDirection = targetTransform.position - aimTransfrom.position;
        float blendOut = 0.0f;
        float targetAngle = Vector3.Angle(targetDirection,aimDirection);
        if(targetAngle > angleLimit)
        {
            blendOut += (targetAngle - angleLimit) / 50f;

        }
        float targetDistance = targetDirection.magnitude;
        if(targetDistance < distanceLimit)
        {
            blendOut += distanceLimit - targetDistance;
        }
        Vector3 direction = Vector3.Slerp(targetDirection,aimDirection,blendOut);
        return aimTransfrom.position + direction;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        
        if(targetTransform == null) return;
        

            
        Vector3 targetPosition = GetTargetPosition();
        for (int i = 0; i < iterations; i++)
        {
            for (int b = 0; b < boneTransforms.Length; b++)
            {
                Transform bone = boneTransforms[b];
                float boneWeight = humanBones[b].weight * weight;
                AimAtTarget(bone, targetPosition,boneWeight);
                
            }
            
        }
    }
    public void SetTargetTransform(Transform _targetTransform)
    {
        targetTransform = _targetTransform;
    }
    public void SetAimTransfrom(Transform _aimTransform)
    {
        aimTransfrom = _aimTransform;
    }
    private void AimAtTarget(Transform _bone,Vector3 _targetPosition,float weight)
    {
        Vector3 aimDirection = aimTransfrom.forward;
        Vector3 targetDirection = _targetPosition - aimTransfrom.position;
        Quaternion aimToward = Quaternion.FromToRotation(aimDirection,targetDirection);
        Quaternion blenderRotation = Quaternion.Slerp(Quaternion.identity,aimToward,weight);
        _bone.rotation = blenderRotation * _bone.rotation;
        Debug.DrawRay(targetDirection,aimDirection * distance,Color.black);
        float distanceToTarget = Vector3.Distance(aimTransfrom.position,_targetPosition) * 10;
       
        currentWeapon.Use(aimTransfrom,distanceToTarget,weaponholdingAnimator);
        
        
    }
    
}
