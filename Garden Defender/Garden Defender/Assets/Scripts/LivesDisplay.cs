/*
 *  LivesDisplay
 *  The on screen display of the player lives
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    // Config params
    [SerializeField] float baseLives = 10;
    [SerializeField] int damage = 2;

    // Cached component references
    Text livesText;

    // Variables
    float lives;

    // Start is called before the first frame update
    void Start()
    {
        lives = baseLives - (PlayerPrefsController.GetDifficulty() * 2);
        livesText = GetComponent<Text>();
        UpdateDisplay();
        //Debug.Log("Diffuclty setting atm is: " + PlayerPrefsController.GetDifficulty());
    }

    // Update the lives display
    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    // Lower the lives of the player
    public void TakeLife()
    {
        lives -= damage;
        UpdateDisplay();

        if(lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }

}
