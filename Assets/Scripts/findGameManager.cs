using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class findGameManager : MonoBehaviour
{
    gameManager gameMgSc;
    AudioSource audioSrc;
    void Start()
    {
        gameMgSc = GameObject.Find("GameManager").GetComponent<gameManager>();
        audioSrc = GameObject.Find("GameManager").GetComponent<AudioSource>();
        gameObject.GetComponent<Slider>().value = gameMgSc.volumeValue;
    }

    public void ChangeVolume()
    {
        audioSrc.volume = gameObject.GetComponent<Slider>().value;
        gameMgSc.volumeValue = gameObject.GetComponent<Slider>().value;
    }
}
