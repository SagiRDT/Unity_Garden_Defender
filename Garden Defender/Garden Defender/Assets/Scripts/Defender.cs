/*
 *  Defender
 *  The main class for the defender (the player allies)
 *  Handle the defender main functionality
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    // Config params
    [SerializeField] int starCost = 100;

    public int GetStarCost() { return starCost; }

    // Add stars to the player - will be used in defender that should add income to the player
    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }

}
