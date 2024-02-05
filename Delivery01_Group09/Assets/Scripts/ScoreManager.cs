using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text _scoreText; 

    public static int _points;

    //private void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}

    void Start()
    {
        //_scoreText = GetComponent<Text>();
        _points = 0;
    }

    public void AddPoints(int pointsNumber)
    {
        _points += pointsNumber;
        Debug.Log(_points);
    }

    public int GetPoints() //ni idea de si va a funcionar, tengo que conseguir pasar esta variable para que se muestre en la pantalla de muerte
    {
        return _points;
    }

    void Update()
    {
        Debug.Log(_points);

        if (_points <= 9)
        {
            _scoreText.text = "SCORE: 0" + _points.ToString();
        }
        else
        {
            _scoreText.text = "SCORE: " + _points.ToString();
        }
        
    }
}
