/*
 *  Attacker
 *  The main class for the attckers (enemies)
 *  Handle the attcker main functionality
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    // Cached component references
    GameObject currentTarget;
    Animator animator;

    // Variables
    float currentSpeed = 1f;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    // let the level controller know that the attacker was destroyed (the level controller holds the number
    // of attckers per lvl and will finish the level if all the attckers are destoyed)
    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if(levelController != null) levelController.AttackerKilled();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    public void SetMovementSpeed(float speed){ currentSpeed = speed; }

    // Handle the attcker attack, play the attack animation and set the attacker target to the target we got as param
    public void Attack(GameObject target)
    {
        animator.SetBool("isAttacking", true);
        currentTarget = target;
    }

    // Deal damage to the current target of the attacker
    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) return;

        Health health = currentTarget.GetComponent<Health>();
        if(health)
        {
            health.DealDamage(damage);
        }
    }

    // Update the animation of the attacker
    private void UpdateAnimationState()
    {
        // if the attacker dont got a target then cancel his attack animation
        if(!currentTarget) animator.SetBool("isAttacking", false);
    }

}
