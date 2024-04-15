using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
        FindAimShoot();
    }

    void AimWeapon()
    {        
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(cannon.rotation, lookRotation, Time.deltaTime * towerStats.rotationSpeed).eulerAngles;
        cannon.rotation = Quaternion.Euler(rotation);
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
        }     
        
        if(closestTarget != null && maxDistance <= towerStats.fireRange)
        {
            target = closestTarget;
        }
        else
        {
            target = null;
        }
    }

    void Shoot()
    {
        if(Time.time >= nextFire)
        {
            nextFire = Time.time + towerStats.fireRate;
            GameObject projectileInstance = (GameObject)Instantiate(towerStats.projectile, tipOfGun.position, Quaternion.identity);
            BulletController bulletController = projectileInstance.GetComponent<BulletController>();
            bulletController.Seek(target);
        }
    }

    void FindAimShoot()
    {
        FindClosestTarget();
        if (target == null)
        {
            return;
        }
        AimWeapon();

        float targetDistance = Vector3.Distance(transform.position, target.position);

        if (targetDistance <= towerStats.fireRange)
        {
            Shoot();
        }
    }
}
