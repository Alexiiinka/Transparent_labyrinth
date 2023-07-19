using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    public int fishToBeEaten = 3;
    public int fishAlreadyEaten = 0;
    public bool gameFinished = false;
    public bool gameOn = true;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (fishAlreadyEaten == fishToBeEaten)
        {
            gameFinished = true;
        }
    }

    public void GameOn(bool boolean)
    {
        gameOn = boolean;
    }
}
