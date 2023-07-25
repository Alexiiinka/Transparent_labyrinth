using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelManager : MonoBehaviour
{
    public int fishToBeEaten = 3;
    public int fishAlreadyEaten = 0;
    public bool gameFinished = false;
    public bool gameOn = true;
    [SerializeField] GameObject panelNextLvl;
    [SerializeField] ParticleSystem PsFish;
    public TMPro.TMP_Text t_fishToEat;

    void Start()
    {
        t_fishToEat.text = "Living fish: " + fishToBeEaten.ToString();
    }
    void Update()
    {

        if (fishAlreadyEaten == fishToBeEaten && gameOn)
        {
            //gameFinished = true;
            Debug.Log(PsFish.isPlaying);
            PsFish.Play();
            gameOn = false;
            panelNextLvl.SetActive(true);
        }
    }

    public void GameOn(bool boolean)
    {
        gameOn = boolean;
    }
}
