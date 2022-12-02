using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingScript : MonoBehaviour
{
    public float speed = 0.5f, jumpVelocity, jumpWaitTime;
    public Rigidbody2D rb;
    public KeyCode jumpkey;
    private float _counter;
    [SerializeField]
    private float _timeSpeedUp;
    //public LayerMask ground;
    //public Collider2D footCollider;
    private void Start()
    {
        _counter = 0;
    }
    /*private bool isGrounded;
    private float jumpWaitTimer;*/
    void Update()
    {
        //isGrounded = footCollider.IsTouchingLayers(ground);
        if (transform.position.x < 0)
            speed += 0.1f * Time.deltaTime;
        
        else
        {
            speed = 1;
        }
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        

        if (Input.GetKeyDown(jumpkey))
        {
            /*if (isGrounded)
            {
                Jump();
            }*/
            Jump();
        }

        /*if (isGrounded || jumpWaitTimer > 0f)
        {
            jumpWaitTimer = jumpWaitTime;
        }
        else
        {
            if(jumpWaitTimer > 0f)
            {
                jumpWaitTimer -= Time.deltaTime;
            }
        }*/

        //Debug.Log(transform.position);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity * Time.fixedDeltaTime);
    } 
}
