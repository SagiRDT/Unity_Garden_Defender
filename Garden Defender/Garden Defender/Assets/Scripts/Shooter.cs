/*
 *  Shooter
 *  The shooter class makes any objs that holds it shot a projectile
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // consts
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    // Config params
    [SerializeField] GameObject gun = null;
    [SerializeField] Projectile projectile = null;

    // Cached component references
    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;

    private void Start()
    {
        animator = GetComponent<Animator>();
        CreateProjectileParent();
        SetLaneSpawner();    
    }

    private void Update()
    {
        // if theres an attacker in the defender lane make the defender shot
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    // create a projectile parent
    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    // Get the attackers spawner that is in the lane of the shooter
    private void SetLaneSpawner()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in attackerSpawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }

    }

    // Check if theres an attacker in the shooter lane
    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0) return false;

        return true;
    }

    // Shoot the projectile
    public void Fire()
    {
        Projectile newProjectile = Instantiate(projectile, gun.transform.position, transform.rotation) as Projectile;
        newProjectile.transform.parent = projectileParent.transform;
    }

}
