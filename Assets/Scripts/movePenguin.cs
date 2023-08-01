using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePenguin : MonoBehaviour
{
    levelManager levelMgSc;
    [SerializeField] float speed = 2.0f, jumpHeight = 5.0f;
    Rigidbody2D playerRb;
    Transform groundCheck;
    float horizont, vertic;
    bool onGround = true;
    float goRightScale = 0.4f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float radiusGround;
    [SerializeField] Vector2 groundOffset;
    public Color gizmoColor = Color.red;
    Animator characterAnim;
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        goRightScale = transform.localScale.x;
        characterAnim = gameObject.GetComponent<Animator>();
        levelMgSc = GameObject.Find("Manager").GetComponent<levelManager>();
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

    void FixedUpdate()
    {
        if (levelMgSc.gameOn)
        {
            Move();
        }
        else
        {
            characterAnim.SetBool("running", false);
            playerRb.velocity = new Vector2(0, playerRb.velocity.y);
        }
    }

    void Move()
    {
        horizont = Input.GetAxis("Horizontal");
        vertic = Input.GetAxis("Vertical");
        characterAnim.SetBool("running", true);
        if (horizont > 0)
        {
            playerRb.velocity = new Vector2(speed, playerRb.velocity.y);
            transform.localScale = new Vector3(goRightScale, transform.localScale.y, transform.localScale.z);
        }
        if (horizont < 0)
        {
            playerRb.velocity = new Vector2(-speed, playerRb.velocity.y);
            transform.localScale = new Vector3(-goRightScale, transform.localScale.y, transform.localScale.z);
        }
        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)
        && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {   playerRb.velocity = new Vector2(0, playerRb.velocity.y);
            characterAnim.SetBool("running", false);
        }

        if (vertic > 0 && onGround && (playerRb.velocity.y < 0.5f))
        {
            playerRb.AddForce(new Vector2(0,jumpHeight),ForceMode2D.Impulse);
        }
    }
}
