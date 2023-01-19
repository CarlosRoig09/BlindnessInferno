using System.Collections;
using UnityEngine;
public enum EnemyMovement
{
    Right,
    Left,
    Jump,
    Float
}
public class BasicEnemy : MonoBehaviour
{
    private Rigidbody2D _rb;
    public BasicEnemySO _bESO;
    protected EnemyMovement eM;
    private float _jumpCounter;
    private float _jumpDurationCounter;
    private float _movementCounter;
    public LayerMask groundLayer;
    // Start is called before the first frame update
   protected virtual void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        eM = EnemyMovement.Left;
        _jumpCounter = _bESO.WaitjumpTime;
        _movementCounter = 0;
        _jumpDurationCounter = 0;
    }
    // Update is called once per frame
    protected virtual void  Update()
    {
        //if(gameObject.name == "Enemy") Debug.Log("" + eM + " state " + _rb.gravityScale + " gravityScale");
        switch (eM)
        {
            case EnemyMovement.Right:
                if (Physics2D.Raycast(transform.position, Vector2.down, 0.65f, groundLayer) && _rb.gravityScale > 0)
                    _rb.gravityScale = 0;
                LinearMovement(_bESO.speed, EnemyMovement.Left);
                break;
            case EnemyMovement.Left:
                LinearMovement(_bESO.speed * -1, EnemyMovement.Right);
                break;
            case EnemyMovement.Jump:
                Jump();
                break;
            case EnemyMovement.Float:
                Float();
                break;
        }

   }
    void Jump()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, _bESO.jumpSpeed*Time.fixedDeltaTime);
        if (_bESO.jumTimeDuration <= _jumpDurationCounter)
        {
            _jumpDurationCounter = 0;
            eM = EnemyMovement.Float;
        }
        else _jumpDurationCounter += Time.deltaTime;
    }
    void LinearMovement(float speed, EnemyMovement enemyMovement)
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.65f, groundLayer.value))
        {
            _rb.velocity = new Vector3(speed * Time.fixedDeltaTime, 0);
            if (_bESO.changeDirectionTimer <= _movementCounter)
            {
                eM = enemyMovement;
                _jumpCounter -= 1;
                if (_jumpCounter <= 0)
                {
                    _jumpCounter = _bESO.WaitjumpTime;
                    _rb.velocity = new Vector3(0, 0);
                    eM = EnemyMovement.Jump;
                }
                _movementCounter = 0;
            }
            else _movementCounter += Time.deltaTime;
        }
    }



    void Float()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, 0);
        _rb.gravityScale = 0;
        StartCoroutine(WaitTime(_bESO.floatTime, EnemyMovement.Right));
    }

    private IEnumerator WaitTime(float timer, EnemyMovement enemyMovement)
    {
        yield return new WaitForSeconds(timer);
        _rb.gravityScale = 1;
        eM = enemyMovement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.layer);
        if(collision.gameObject.layer == 6)
        {
            _rb.gravityScale = 0;
        }
    }
}
