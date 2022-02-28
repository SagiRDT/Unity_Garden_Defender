/*
 *  StarDisplay
 *  The on screen display of the player stars
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    // Config params
    [SerializeField] int stars = 150;

    // Cached component references
    Text starText;
        
    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    // Update the star text
    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public bool HaveEnoughStars(int amount) { return (stars >= amount); }

    // Add stars to the text
    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    // Decrease stars from the text (only if we have enough to spend)
    public void SpendStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }
    }

}
