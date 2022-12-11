using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // CALLED BY BUTTON
    public void RestartGamePassed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    // CALLED BY BUTTON
    public void RestartGameFailed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    
}
