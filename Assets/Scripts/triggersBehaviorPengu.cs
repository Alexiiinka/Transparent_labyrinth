using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggersBehaviorPengu : MonoBehaviour
{

    [SerializeField] Sprite lavaOn, lavaOff;
    [SerializeField] Camera mainCam, secondCam; 

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("lavaTag"))
        {
            col.GetComponent<SpriteRenderer>().sprite = lavaOn;
            secondCam.enabled = true;
            mainCam.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("lavaTag"))
        {
            col.GetComponent<SpriteRenderer>().sprite = lavaOff;
            mainCam.enabled = true;
            secondCam.enabled = false;
        }
    }
}
