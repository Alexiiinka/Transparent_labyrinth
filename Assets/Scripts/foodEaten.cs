using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodEaten : MonoBehaviour
{
    [SerializeField] Sprite fishSkeleton;
    bool eaten = false;
    levelManager lvManagerSc;
    // Start is called before the first frame update
    void Start()
    {
        lvManagerSc = GameObject.Find("Manager").GetComponent<levelManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !eaten)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = fishSkeleton;   
            transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            eaten = true;
            gameObject.GetComponent<Animator>().enabled = false;
            lvManagerSc.fishAlreadyEaten += 1;
            lvManagerSc.t_fishToEat.text = "Living fish: " + (lvManagerSc.fishToBeEaten - lvManagerSc.fishAlreadyEaten).ToString();
        }
    }
}
