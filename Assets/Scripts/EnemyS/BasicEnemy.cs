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
    private EnemyMovement _eM;
    private bool _onFloor;
    private float _jumpCounter;
    private float _movementCounter;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _eM = EnemyMovement.Left;
        _jumpCounter = _bESO.WaitjumpTime;
    }
    // Update is called once per frame
    void Update()
    {
        switch (_eM)
        {
            case EnemyMovement.Right:
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
        _rb.velocity = new Vector3(_rb.velocity.x, _bESO.jumpSpeed*Time.deltaTime);
        StartCoroutine(WaitTime(_bESO.jumTimeDuration, EnemyMovement.Float));
    }
    void LinearMovement(float speed, EnemyMovement enemyMovement)
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.65f, groundLayer.value))
        {
            Debug.Log("Ground");
            _rb.velocity = new Vector3(speed * Time.fixedDeltaTime, _rb.velocity.y);
            StartCoroutine(WaitTime(_bESO.changeDirectionTimer, enemyMovement));
        }
    }



    void Float()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, 0);
        _rb.gravityScale = 0;
        StartCoroutine(WaitTime(_bESO.floatTime, EnemyMovement.Left));
    }

    private IEnumerator WaitTime(float timer, EnemyMovement enemyMovement)
    {
        yield return new WaitForSeconds(timer);
        WaitTimeMethods(enemyMovement);
    }

    private void WaitTimeMethods(EnemyMovement enemyMovement)
    {
        switch (enemyMovement)
        {
            case EnemyMovement.Right:
            case EnemyMovement.Left:
                _jumpCounter -= 1;
                if(_jumpCounter<=0)
                {
                    _jumpCounter = _bESO.WaitjumpTime;
                    _eM = EnemyMovement.Jump;
                }
            break;
            case EnemyMovement.Jump:
            case EnemyMovement.Float:
                _rb.gravityScale = 1;
                _eM = enemyMovement;
                break;
        }
    }
}
