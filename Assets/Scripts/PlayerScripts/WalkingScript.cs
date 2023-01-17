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
    private Transform _maxPosition;
    private float _initPos;
    [SerializeField]
    private float _acceleration;
    private bool _secondJump;
    public LayerMask groundLayer;
    [SerializeField]
    private Transform firstGodPosition;
    [SerializeField]
    private Rigidbody2D _cameraRB2D;
    //public LayerMask ground;
    //public Collider2D footCollider;
    private void Start()
    {
        _secondJump = false;
        _initPos = firstGodPosition.position.x;
    }
    /*private bool isGrounded;
    private float jumpWaitTimer;*/
    private void FixedUpdate()
    {
        if (transform.position.x < _maxPosition.position.x)
        {
            _playerData.speed = Mathf.Sqrt(2 * _acceleration * (transform.position.x - _initPos) + Mathf.Pow(initialspeed, 2));
            _initPos = transform.position.x;
            rb.velocity = new Vector2(_playerData.speed * Time.fixedDeltaTime + _cameraRB2D.velocity.x, rb.velocity.y);
        }
        else
          rb.velocity = new Vector2(_cameraRB2D.velocity.x, rb.velocity.y);
    }
    void Update()
    {
        //Debug.Log(speed);
        //isGrounded = footCollider.IsTouchingLayers(ground);


        if (Input.GetKeyDown(jumpkey))
        {
            if (_secondJump || IsGrounded())
            {
                _secondJump = IsGrounded();
                Jump();
            }
        }
        var platform = Physics2D.Raycast(transform.position, Vector2.down, 0.65f, groundLayer.value);
        if (platform.collider != null)
        {
            if (platform.collider.gameObject.CompareTag("Fallable") && Input.GetKeyUp(KeyCode.DownArrow))
                FallPlatform(platform.collider.gameObject);
            if (platform.collider.gameObject.CompareTag("Fall"))
            {
                FallingPlatform(platform.collider.gameObject);
            }
               
            //Debug.Log(transform.position);
        }

        void Jump()
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity * Time.fixedDeltaTime);
        }

        void FallPlatform(GameObject gameObject)
        {
            if (gameObject.TryGetComponent<FallablePlatform>(out FallablePlatform f))
                f.PlatformHability();
        }

        void FallingPlatform(GameObject gameObject)
        {
            if (gameObject.TryGetComponent<FallingPlatform>(out FallingPlatform f))
                f.Falling();
        }

       

        bool IsGrounded()
        {
            if (Physics2D.Raycast(transform.position, Vector2.down, 0.65f, groundLayer.value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}

