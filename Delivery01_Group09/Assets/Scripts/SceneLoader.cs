using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update

    private bool _gameplayScene = false;

    void Start()
    {
        //SceneManager.LoadScene("Title");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Cambio de escena");
    }

    public void OnEnterGameplayScene()
    {

        if (!_gameplayScene)
        {

            SceneManager.LoadScene("Gameplay");

            _gameplayScene = true;
        }
    }

    public void EnterExitScene() //ejecutar al morir
    {
        SceneManager.LoadScene("Ending");
    }

}
