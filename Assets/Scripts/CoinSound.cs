using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSound : MonoBehaviour
{

    public AudioSource coin;
    public bool sound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sound = Player.pickUpCoin;
        if(sound)
        {
            coin.Play();
        }
        
    }
}
