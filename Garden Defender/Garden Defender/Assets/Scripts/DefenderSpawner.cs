/*
 *  DefenderSpawner
 *  Handle the spawning of defenders
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    // consts
    const string DEFENDER_PARENT_NAME = "Defenders";

    // Cached component references
    Defender defender;
    GameObject defenderParent;

    private void Start()
    {
        CreateDefenderParent();
    }

    // Create a defender parent obj
    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if(!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    // On mouse click try to place a defender on screen
    private void OnMouseDown()
    {
        if(defender != null) AttemptToPlaceDefender(GetSqaureClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect){ defender = defenderToSelect; }

    // Try to place a defender on the grid in the pos we got as param
    private void AttemptToPlaceDefender(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();

        // if we have enough stars spawn the defender and spend the stars
        if(starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }

    }

    // Return the pos on the grid that the player clicked on
    private Vector2 GetSqaureClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    // Get a wolrd pos and return its grid pos values
    private Vector2 SnapToGrid(Vector2 rawWolrdPos)
    {
        float newX = Mathf.RoundToInt(rawWolrdPos.x);
        float newY = Mathf.RoundToInt(rawWolrdPos.y);

        return (new Vector2(newX, newY));
    }

    // Spawn a defender
    private void SpawnDefender(Vector2 worldPos)
    {
        Defender newDefender = Instantiate(defender, worldPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }

}
