/*
 *  Health
 *  Health class, objs that have this class have health points and will be destroyed if their health reaches zero
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Config params
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX = null;

    // Deal dmg to the obj that hold this health class, destroy it if the health reches zero
    public void DealDamage(float damage)
    {
        health -= damage;
        if( health <= 0 )
        {
            // play death animation and destroy the obj
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    // Death animation
    private void TriggerDeathVFX()
    {
        if (!deathVFX) return;
        GameObject deathVFXObjet = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObjet, 1f);
    }

}
