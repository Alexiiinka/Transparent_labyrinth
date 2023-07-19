using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePenguin : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 2.0f, jumpHeight = 5.0f; //2,500 -translate
    Rigidbody2D playerRb;
    Transform groundCheck;
    float horizont, vertic;
    bool onGround = true;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float radiusGround;
    [SerializeField] Vector2 groundOffset;
    public Color gizmoColor = Color.red;
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + groundOffset, radiusGround, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere((Vector2)transform.position + groundOffset, radiusGround);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizont = Input.GetAxis("Horizontal");
        vertic = Input.GetAxis("Vertical");

        if (horizont > 0)
        {
            playerRb.velocity = new Vector2(speed, playerRb.velocity.y);
        }
        if (horizont < 0)
        {
            playerRb.velocity = new Vector2(-speed, playerRb.velocity.y);
        }
        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)
        && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {playerRb.velocity = new Vector2(0, playerRb.velocity.y);}

        if (vertic > 0 && onGround && (playerRb.velocity.y < 0.5f))
        {
            playerRb.AddForce(new Vector2(0,jumpHeight),ForceMode2D.Impulse);
            //onGround = false;
        }
    }

    void OnCollisionEnter2D (Collision2D collider)
    {
        if (collider.gameObject.CompareTag("snowTag") || collider.gameObject.CompareTag("lavaTag"))
        {
            //onGround = true;
        }
    }
}
