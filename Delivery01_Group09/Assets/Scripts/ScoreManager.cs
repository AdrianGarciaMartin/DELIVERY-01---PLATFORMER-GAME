using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text _scoreText; 

    public static int _points;


    void Start()
    {
        _points = 0;
    }

    public void AddPoints(int pointsNumber)
    {
        _points += pointsNumber;
        Debug.Log(_points);
    }

    public int GetPoints() 
    {
        return _points;
    }

    void Update()
    {
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
