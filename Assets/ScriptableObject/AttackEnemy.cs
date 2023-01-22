using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : Enemy
{
    private float _countProyectile;
    private AtackEnemySO atackEnemySO;
    private Rigidbody2D _rb;
    public BasicEnemySO _bESO;
    protected EnemyMovement eM;
    private float _jumpCounter;
    private float _jumpDurationCounter;
    private float _movementCounter;
    public LayerMask groundLayer;
    private Transform _playerTransform;
    private Animator _anim;
    private Collider2D _cll;
    void Start()
    {
        
        _rb = gameObject.GetComponent<Rigidbody2D>();
        eM = EnemyMovement.Left;
        _jumpCounter = _bESO.WaitjumpTime;
        _movementCounter = 0;
        _jumpDurationCounter = 0;
        atackEnemySO = (AtackEnemySO)_bESO;
        _countProyectile = 0;
        Score = 10;
        _playerTransform = GameObject.Find("Character").GetComponent<Transform>();
        _anim = GetComponent<Animator>();
        _cll= GetComponent<Collider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        switch (eM)
        {
            case EnemyMovement.Right:
                LinearMovement(_bESO.speed, EnemyMovement.Left);
                break;
            case EnemyMovement.Left:
                LinearMovement(_bESO.speed * -1, EnemyMovement.Right);
                break;
            case EnemyMovement.Jump:
                _anim.SetBool("Fly", true);
                Jump();
                break;
            case EnemyMovement.Float:
                Float();
                break;
            case EnemyMovement.Death:
                _rb.velocity = new Vector2(0, _bESO.speed * 15 * Time.deltaTime);
                break;
        }
            if (atackEnemySO.proyectileTimer <= _countProyectile && transform.position.x - _playerTransform.position.x < 13)
            {
                Shoot();
                _countProyectile = 0;
            }
            else
                _countProyectile += Time.deltaTime;
    }

    void Jump()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, _bESO.jumpSpeed * Time.fixedDeltaTime);
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

    void Shoot()
    {
        Instantiate(atackEnemySO.proyectile,new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _anim.SetBool("Fly", false);
            _rb.gravityScale = 0;
            _rb.velocity = new Vector3(0, 0);
        }
        if (collision.CompareTag("Bullet"))
        {
            _cll.enabled= false;
            eM = EnemyMovement.Death;
            _anim.SetBool("Die", true);
        }
    }
}
