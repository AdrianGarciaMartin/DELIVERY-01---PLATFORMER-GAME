using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Text scoreText;

    public static int points;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        points = 0;
    }

    // Update is called once per frame
    public void AddPoints(int pointsNumber)
    {
        points += pointsNumber;
        Debug.Log(points);
    }

    private void Update()
    {
        if (points <= 9)
        {
            scoreText.text = "SCORE: 0" + points.ToString();
        }
        else
        {
            scoreText.text = "SCORE: " + points.ToString();
        }
        
    }
}
