/*
 *  GameTimer
 *  The game timer class, each level will have a timer on screen, the player need to survive until the time is finished
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    // Config params
    [Tooltip("Level timer in seconds")]
    [SerializeField] float levelTime = 10f;

    // Variables
    bool triggeredLevelFinished = false;

    // Update is called once per frame
    void Update()
    {
        // if the lvl is over do nothing
        if (triggeredLevelFinished) return;

        // update the on screen slider of the timer
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        // if the timer is finished turn on the lvl finished flag
        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if(timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
