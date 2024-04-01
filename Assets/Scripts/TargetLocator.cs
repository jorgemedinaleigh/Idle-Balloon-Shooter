using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform cannon;
    [SerializeField] private Transform tipOfGun;
    [SerializeField] public TowerStats towerStats;

    Transform target;
    float nextFire;

    void Awake()
    {
        nextFire = towerStats.fireRate;   
    }

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        cannon.LookAt(target);

        if(targetDistance <= towerStats.fireRange) 
        {
            Shoot();
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

    void Shoot()
    {
        if(Time.time >= nextFire)
        {
            nextFire = Time.time + towerStats.fireRate;
            GameObject bulletInstance = Instantiate(towerStats.bullet, tipOfGun.position, Quaternion.identity);
            var rb = bulletInstance.GetComponent<Rigidbody>();
            rb.AddForce(target.transform.position.normalized * towerStats.bulletSpeed);
        }
    }

}
