using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private SceneLoader _sceneLoader;

    void Start()
    {
        _sceneLoader = new SceneLoader();
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "DeathObject") 
        {
            _sceneLoader.EnterExitScene();
        }
    }
}
