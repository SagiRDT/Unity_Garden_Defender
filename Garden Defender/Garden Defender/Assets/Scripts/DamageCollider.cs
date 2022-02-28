/*
 *  DamageCollider
 *  A collider that will destroy the objs that collide with it and reduce the player hp
 *  This will be places at the end of the field and any attacker that passes all the player defences will 
 *  reduce the player hp.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    // Destroy the obj that collide with the collider and reduce the player hp (if the player hp reaches 0 the game is over)
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        FindObjectOfType<LivesDisplay>().TakeLife();
        Destroy(otherCollider.gameObject);
    }
}
