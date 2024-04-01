using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] float range = 15f;

    Transform target;

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);

        if(targetDistance < range) 
        {

        }
    }

    void FindClosestTarget()
    {
        BubbleController[] bubbles = FindObjectsByType<BubbleController>(FindObjectsSortMode.None);

        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(BubbleController bubble in bubbles) 
        {
            float targetDistance = Vector3.Distance(transform.position, bubble.transform.position);

            if(targetDistance < maxDistance) 
            {
                closestTarget = bubble.transform;
                maxDistance = targetDistance;
            }

            target = closestTarget;
        }
    }

}
