using UnityEngine;
public enum FlyingEnemyMovement
{
    Up,
    Down,
    Attack,
}
public class FlyingEnemy : MonoBehaviour
{
    private Transform _playerTransform;
    private Vector3 _targetPosition;
    private Vector3 _attackDirection;
    [SerializeField]
    private float _flyingSpeed;
    [SerializeField]
    private float _attackSpeed;
    [SerializeField]
    private float _timeBeforeAttack;
    private float _countTimeBA;
    [SerializeField]
    private float _timeChangeDirection;
    private float _countTimeCD;
    private Rigidbody2D _rb;
    private FlyingEnemyMovement _fEM;
    // Start is called before the first frame update
    void Start()
    {
        _countTimeBA = _timeBeforeAttack;
        _countTimeCD = 0;
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _playerTransform = GameObject.Find("Character").GetComponent<Transform>();
        transform.position = new Vector3(transform.position.x, transform.position.y + 1f);
        _fEM = FlyingEnemyMovement.Up;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_fEM)
        {
            case FlyingEnemyMovement.Up:
                LinearMovement(_flyingSpeed, FlyingEnemyMovement.Down);
                DetectPlayer();
                break;
            case FlyingEnemyMovement.Down:
                LinearMovement(_flyingSpeed * -1, FlyingEnemyMovement.Up);
                DetectPlayer();
                break;
            case FlyingEnemyMovement.Attack:
                Attack();
                break;
        }
    }

    void LinearMovement(float speed, FlyingEnemyMovement flyingEnemyMovement)
    {
        _rb.velocity = new Vector3(_rb.velocity.x, speed*Time.deltaTime);
        if (_timeChangeDirection <= _countTimeCD)
        {
            _countTimeBA -= 1;
            _fEM = flyingEnemyMovement;
            _countTimeCD = 0;
       }
        else _countTimeCD += Time.deltaTime;
    }

    void DetectPlayer()
    {
        if (Physics2D.Raycast(transform.position, _targetPosition, 0.000001f, 7))
        {
            _rb.velocity = new Vector3(0, 0);
            _fEM = FlyingEnemyMovement.Attack;
            _targetPosition = _playerTransform.position;
            _attackDirection = _playerTransform.position - transform.position;
        }
    }

    void Attack()
    {
        if (transform.position.x > _targetPosition.x)
            _rb.velocity = _attackSpeed * Time.deltaTime * _attackDirection.normalized;
        else
            _rb.velocity = _attackSpeed * Time.deltaTime * new Vector3(_attackDirection.normalized.x, _attackDirection.normalized.y*-0.2f);
    }
}
