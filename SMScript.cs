using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SMScript : MonoBehaviour
{
    public PlayerScript playerScript;
    public GameObject PauseMenu;
    public bool canEscape = true;

    private void Start()
    {
        playerScript = FindObjectOfType<PlayerScript>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canEscape == true)
        {
            if(playerScript.canMove == true)
            {
                playerScript.canMove = false;
                PauseGame();
            }
            
        }
    }

    public void ChangeSceneTo(string SceneToLoad)
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        playerScript.MouseVisual();
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        playerScript.canMove = true;
        PauseMenu.SetActive(false);
        playerScript.MouseVisual();
        Time.timeScale = 1;
    }

    public void ContinueTime()
    {
        Time.timeScale = 1;
    }
}
