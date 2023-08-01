using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showSign : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D collider)
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    void OnTriggerExit2D (Collider2D collider)
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
