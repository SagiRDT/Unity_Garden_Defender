/*
 *  LevelController
 *  The level controller is handling all the level functionality
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Config params
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLabel = null;
    [SerializeField] GameObject loseLabel = null;

    // Variables
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    // Handle a spawning of an attacker - Rise the number of attackers in the level
    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    // Handle a death of an attacker - Decrease the number of attackers and if no attackers left check the win condition
    public void AttackerKilled()
    {
        numberOfAttackers--;

        if(numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    // Handle the win condition - load the victory message, play a sound and load the next scene
    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    // Handle lost condition - load the losing message and freeze the game
    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    // Mark the level timer as finished and stop spawning attackers
    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    // Stop spawning attckers in all the spawners
    private void StopSpawners()
    {
        AttackerSpawner[] spawnersArray = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in spawnersArray)
        {
            spawner.StopSpawning();
        }
    }

}
