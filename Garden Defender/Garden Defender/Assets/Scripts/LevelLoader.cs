/*
 *  LevelLoader
 *  Handling the level loader functionality
 *  The level loader is responsible to load the scenes (the next level, game over, etc..)
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Config params
    [SerializeField] int timeToWait = 4;

    // Cached component references
    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    // Wait timeTowait secs before loading the new scene
    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    // Load the main menu
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    // Load the options
    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options Screen");
    }

    // Restart the scene
    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    // Load the next scene
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    // Load game over
    public void LoadYouLose()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    // Load victory
    public void LoadYouWin()
    {
        SceneManager.LoadScene("Win Screen");
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
    }

}
