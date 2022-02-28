/*
 *  Gravestone
 *  Handle the gravestone functionality
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        /* the graves stone does nothing when some1 collides it, only blocks its path
        
        Attacker attacker = otherCollider.GetComponent<Attacker>();

        if(attacker)
        {
            // if we want to add a gravestone animation when attacker collides it do it here
        }

        */
    }

}
