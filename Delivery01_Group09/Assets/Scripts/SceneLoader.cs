using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    private bool _gameplayScene = false;

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnEnterGameplayScene()
    {

        SceneManager.LoadScene("Gameplay");

    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void EnterExitScene() 
    {
        SceneManager.LoadScene("Ending");
    }

}
