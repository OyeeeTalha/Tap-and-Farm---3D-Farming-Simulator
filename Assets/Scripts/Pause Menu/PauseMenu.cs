using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public GameObject pauseMenu;

    public GameObject _exitMenu;

    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume game time
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseMenu.SetActive(true);
        _exitMenu.SetActive(false);

        Time.timeScale = 0f; // Stop game time
        isPaused = true;
    }

    public void Save()
    {
        // Save game logic goes here
    }

    public void Settings()
    {
        // Settings logic goes here
    }

    public void ExitMenu()
    {
        Debug.Log("Called");
        if(isPaused)
        {
            _exitMenu.SetActive(true);
            pauseMenu.SetActive(false);
        }

    }

    public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
