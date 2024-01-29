using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject WinObject;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<PlayerMovement>();

        if (player)
        {
            ShowWin();
            Destroy(gameObject);
        }
    }

    private void ShowWin()
    {
        WinObject.SetActive(true);
    }
}
