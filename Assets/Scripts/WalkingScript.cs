using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingScript : MonoBehaviour
{
    public float initialspeed = 0.5f, jumpVelocity, jumpWaitTime;
    public float speed;
    public Rigidbody2D rb;
    public KeyCode jumpkey;
    [SerializeField]
    private float _maxSpeed;
    private float _maxPosition;
    private float _initPos;
    [SerializeField]
    private float _timeToMaxSpeed;
    private float _acceleration;
    //public LayerMask ground;
    //public Collider2D footCollider;
    private void Start()
    {
        _maxPosition = 0;
        _initPos = transform.position.x;
        _acceleration = (_maxSpeed - initialspeed)/_timeToMaxSpeed;
    }
    /*private bool isGrounded;
    private float jumpWaitTimer;*/
    private void FixedUpdate()
    {
        if (transform.position.x < _maxPosition)
        {
            speed = Mathf.Sqrt(2 * _acceleration * (transform.position.x - _initPos) + Mathf.Pow(initialspeed, 2));
            rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
        }
        else rb.velocity = new Vector2(0, rb.velocity.y);
    }
    void Update()
    {
        Debug.Log(speed);
        //isGrounded = footCollider.IsTouchingLayers(ground);


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
