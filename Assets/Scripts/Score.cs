using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public float finalScore;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        finalScore += Time.deltaTime;
        scoreText.text = "SCORE: " + score.ToString();
       score = Mathf.RoundToInt(finalScore);
    }
}
