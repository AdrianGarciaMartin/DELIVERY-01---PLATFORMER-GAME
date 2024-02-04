using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    //public float _playerLifes;

    private SceneLoader _sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        //_sceneLoader = GetComponent<SceneLoader>(); 

        _sceneLoader = new SceneLoader();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "DeathObject") //nombre sujeto a cambios
        {
            _sceneLoader.EnterExitScene();
        }
    }
}
