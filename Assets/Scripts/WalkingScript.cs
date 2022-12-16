using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingScript : MonoBehaviour
{
    public float initialspeed = 0.5f, jumpVelocity, jumpWaitTime;
    [SerializeField]
    private PlayerData _playerData;
    //public float speed;
    public Rigidbody2D rb;
    public KeyCode jumpkey;
    [SerializeField]
    private float _maxSpeed;
    [SerializeField]
    private Transform _maxPosition;
    private float _initPos;
    [SerializeField]
    private float _timeToMaxSpeed;
    private float _acceleration;
    private bool _secondJump;
    //public LayerMask ground;
    //public Collider2D footCollider;
    private void Start()
    {
        _secondJump = false;
        _initPos = transform.position.x;
        _acceleration = (_maxSpeed - initialspeed) / _timeToMaxSpeed;
    }
    /*private bool isGrounded;
    private float jumpWaitTimer;*/
    private void FixedUpdate()
    {
        if (transform.position.x < _maxPosition.position.x)
        {
            _playerData.speed = Mathf.Sqrt(2 * _acceleration * (transform.position.x - _initPos) + Mathf.Pow(initialspeed, 2));
            rb.velocity = new Vector2(_playerData.speed * Time.fixedDeltaTime + Camera.main.GetComponent<MoveCamara>()._rb.velocity.x, rb.velocity.y);
        }
        else rb.velocity = new Vector2(Camera.main.GetComponent<MoveCamara>()._speed * Time.fixedDeltaTime, rb.velocity.y);

    }
    void Update()
    {
        //isGrounded = footCollider.IsTouchingLayers(ground);
        if (transform.position.x < 0 )
        {
            if(transform.position.x == -7.25)
            {
                speed = 1;
            }else if (transform.position.x == -5.49)
            {
                speed = 2;
            }else if (transform.position.x < -4.76)
            {
                speed = 3;
            }
            else if (transform.position.x < -7.25)
            {
                speed = 0.5f;
            }
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

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

        Debug.Log(transform.position);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity * Time.fixedDeltaTime);
    } 
}
