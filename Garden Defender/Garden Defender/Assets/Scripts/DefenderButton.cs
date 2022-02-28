/*
 *  DefenderButton
 *  A button to choose the next defender the player spawn to add to the screen
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    // Config params
    [SerializeField] Defender defenderPrefab;

    private void Start()
    {
        LabelButtonsWithCosts();    
    }

    // Init the cost text with the cost of the defender
    private void LabelButtonsWithCosts()
    {
        Text costText = GetComponentInChildren<Text>();
        if(!costText)
        {
            //Debug.LogError(name + " has no cost text!");
        }
        else
        {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }

    // When the button is pressed marked it as selected and set the selected defender to the defender of the button that was clicked
    private void OnMouseDown()
    {
        resetAllButtonsToGray();
        GetComponent<SpriteRenderer>().color = Color.white;

        // Set the defender that the defender spawner will spawn to be the defender of the button that was clicked
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }

    // Reset all the buttons to gray (unselected)
    private void resetAllButtonsToGray()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(51, 51, 51, 255);
        }
    }

}
