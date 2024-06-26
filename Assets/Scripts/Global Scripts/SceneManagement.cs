using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
    public string MarketScene;
    public string DemoScene;

    public GameObject fadeout;
    public void LoadMarket(){
        fadeout.SetActive(true);
        Invoke("waitMarketLoad", 1);
        Debug.Log("called");
    }

    public void LoadVillage(){
        fadeout.SetActive(true);
        Invoke("waitMainSceneLoad", 1);
        Debug.Log("called");
    }

    void waitMarketLoad()
    {
        Debug.Log("scene Loaded");
        SceneManager.LoadScene(MarketScene);
    }

    void waitMainSceneLoad()
    {
        SceneManager.LoadScene(DemoScene);
    }
}
