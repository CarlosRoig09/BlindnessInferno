using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAttack : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Collider2D cll2D;
    [SerializeField]
    private Transform _playerTransform;
    public ArmPosition _aP;
    private float _speed;
    [SerializeField]
    private LayerMask groundLayer;
    private Vector3 _initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        cll2D = gameObject.GetComponent<Collider2D>();
        cll2D.enabled = false;
        _aP = ArmPosition.Stay;
    }

    private void Update()
    {
        if (_aP == ArmPosition.Attack)
            if (transform.position.x - _playerTransform.position.x < 10)
            {
                _rb.velocity = new Vector3(0, 0);
                Elevate(_speed * -1);
            }

        if (Physics2D.Raycast(transform.position, Vector2.down, 0.65f, groundLayer.value))
        {
            _aP = ArmPosition.Elevate;
            Debug.Log("touch ground");
        }

        if (_aP == ArmPosition.Elevate)
        {
            Elevate(_speed);
            if (transform.position.y >= _initialPosition.y)
            {
                Move(_speed);
                if (transform.position.x >= _initialPosition.x)
                    _rb.velocity = new Vector3(0, 0);
            }
        }
    }

    public void Attack(float speed)
    {
        _initialPosition = transform.position;
        Move(speed*-1);
        _speed = speed;
        _aP = ArmPosition.Attack;
    }

    private void Move(float speed)
    {
        _rb.velocity = new Vector3(speed*Time.deltaTime, _rb.velocity.y);
    }

    private void Elevate(float speed)
    {
        _rb.velocity = new Vector3(_rb.velocity.x, speed*Time.deltaTime);
    }
}
