using System.Collections;
using UnityEngine;

public class ArmAttack : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Collider2D cll2D;
    [SerializeField]
    private Transform _playerTransform;
    private Rigidbody2D _fatherRB2D;
    public ArmPosition _aP;
    private float _speed;
    private Vector3 direction;
    private ControlBossFaces _parentCBF;
    [SerializeField]
    private LayerMask groundLayer;
    private Vector3 _initialPosition;
    [SerializeField]
    private Rigidbody2D _cameraRB2D;
    // Start is called before the first frame update
    void Start()
    {
        cll2D = gameObject.GetComponent<Collider2D>();
        //cll2D.enabled = false;
        _aP = ArmPosition.Stay;
    }

    private void Update()
    {
        if (_aP == ArmPosition.Attack)
        {
            if (transform.position.x > _playerTransform.position.x + 5)
            {
                _rb.gravityScale = 20;
            }

            if (Physics2D.Raycast(transform.position, Vector2.down, 0.65f, groundLayer.value))
            {
                _rb.velocity = new Vector3(_speed * Time.deltaTime, 0);
                _rb.gravityScale = 0;
                StartCoroutine(WaitTime(0.5f));
                Debug.Log("touch ground");
            }
        }

        if (_aP == ArmPosition.Elevate)
        {
            Elevate(_speed);
            if (transform.localPosition.y >= _initialPosition.y)
            {
                _rb.velocity = new Vector3(_speed*Time.deltaTime, 0);
                if (transform.localPosition.x <= _initialPosition.x)
                {
                    Debug.Log("He vuelto");
                    _rb.velocity = new Vector3(_cameraRB2D.velocity.x, 0);
                    _aP = ArmPosition.Stay;
                }
            }
        }
    }

    public void Attack(float speed)
    {
        _initialPosition = transform.localPosition;
        direction = new Vector3(_playerTransform.position.x - transform.position.x, transform.position.y);
        Move(speed*direction.normalized.x);
        _speed = speed;
        _aP = ArmPosition.Attack;
    }

    private void Move(float speed)
    {
        _rb.velocity = new Vector3(_cameraRB2D.velocity.x + speed*Time.deltaTime, _rb.velocity.y);
    }

    private void Elevate(float speed)
    {
        _rb.velocity = new Vector3(_cameraRB2D.velocity.x, speed*Time.deltaTime);
    }

    private void OnEnable()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector3(_cameraRB2D.velocity.x, 0);

    }

    private void OnDisable()
    {

    }

    private IEnumerator WaitTime(float time)
    {
        yield return new WaitForSeconds(time);
        _aP = ArmPosition.Elevate;
    }
}
