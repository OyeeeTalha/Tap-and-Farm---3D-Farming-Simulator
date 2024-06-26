using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuSceneChange : MonoBehaviour
{
    // Start is called before the first frame update

    public string sceneToLoad;

    public GameObject StartMenutoDisable;
    public GameObject SettingtoEnable;

    [SerializeField] GameObject fadeout;
    public void scenechange()
    {
        fadeout.SetActive(true);
        Invoke("waitMainSceneLoad", 1);
    }

    public void CloseGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void waitMainSceneLoad()
    {
        SceneManager.LoadScene(sceneToLoad);
    }



    public void SwitchMenus()
    {
        if (StartMenutoDisable != null)
            StartMenutoDisable.SetActive(false);

        if (SettingtoEnable != null)
            SettingtoEnable.SetActive(true);
    }

    public void Back()
    {
        if (StartMenutoDisable != null)
            StartMenutoDisable.SetActive(true);

        if (SettingtoEnable != null)
            SettingtoEnable.SetActive(false);
    }
}
