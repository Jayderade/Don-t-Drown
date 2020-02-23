using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;    
    public int score;
    public float finalScore;
    public int coin;
    public bool collect;


    // Start is called before the first frame update
    void Start()
    {
        coin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        collect = Player.pickUpCoin;
        
        if(Player.died)
        {
            score = score + 0;
            
        }

        if(collect)
        {
            coin += 5;
        }
        finalScore += 4 * Time.deltaTime;
        scoreText.text = score.ToString("D6");
        if (!Player.died)
        {
            
            score = Mathf.RoundToInt(finalScore) + coin;
        }
        else
        {
            score = score + 0;
        }
       
        
    }
}
