using System.Collections;
using UnityEngine;

public class ArmAttack : MonoBehaviour, IEnemyWeapon
{
    private Rigidbody2D _rb;
    private Collider2D cll2D;
    [SerializeField]
    private Transform _playerTransform;
    public ArmPosition _aP;
    private float _speed;
    private ControlBossFaces _parentCBF;

    private Transform _firstGodPosition;
    [SerializeField]
    private LayerMask groundLayer;
    public float Life;
    private float _damage;
    [SerializeField]
    private Transform _initPos;
    // Start is called before the first frame update
    void Start()
    {
        cll2D = gameObject.GetComponent<Collider2D>();
        //cll2D.enabled = false;
        _aP = ArmPosition.Stay;
        _firstGodPosition = GameObject.Find("FirstGodPosition").transform;
    }
    private void Update()
    {
        if(_aP == ArmPosition.Stay)
        {
            _rb.velocity = new Vector2(Camera.main.GetComponentInParent<MoveCamara>()._rb.velocity.x,0);
        }
        if (_aP == ArmPosition.Attack)
        {
            if (_firstGodPosition.position.x - transform.position.x < 0.8f)
            {
                _rb.velocity = new  Vector3(Camera.main.GetComponentInParent<MoveCamara>()._rb.velocity.x, 0);
                if (Physics2D.Raycast(transform.position, Vector2.down))
                {
                    cll2D.enabled = true;
                    _rb.gravityScale = 0.5f;
                    _aP= ArmPosition.Fall;  
                }
            }   
        }
        if (_aP == ArmPosition.Fall)
        {
            if (Physics2D.Raycast(transform.position, Vector2.down, 0.65f, groundLayer.value) || transform.position.y <= -3f)
            {
                _rb.velocity = new Vector3(0, 0);
                _rb.gravityScale = 0;
                StartCoroutine(WaitTime(1f));
                Debug.Log("touch ground");
            }
        }

        if (_aP == ArmPosition.Elevate)
        {
            if (_speed < 0)
                _speed *= -1;
            Elevate(_speed);
            if (transform.position.y >= _initPos.position.y)
            {
                cll2D.enabled = false;
                var proximityToInitialPos = _initPos.position.x - transform.position.x;
                Move(new Vector3(proximityToInitialPos, 0).normalized.x*_speed);
               /* if (proximityToInitialPos < 0)
                    proximityToInitialPos *= -1;*/
                if (proximityToInitialPos<=0.5f)
                {
                    Debug.Log("He vuelto");
                    _rb.velocity = new Vector3(Camera.main.GetComponentInParent<MoveCamara>()._rb.velocity.x, 0);
                    _aP = ArmPosition.AttackEnd;
                }
            }
        }
    }

    public void Attack(float speed)
    {
        Debug.Log("Attack");
        _speed = speed;
        Move(_speed);
        _aP = ArmPosition.Attack;
    }

    private void Move(float speed)
    {
        _rb.velocity = new Vector3(speed*Time.deltaTime + Camera.main.GetComponentInParent<MoveCamara>()._rb.velocity.x, 0);
    }

    private void Elevate(float speed)
    {
        _rb.velocity = new Vector3(Camera.main.GetComponentInParent<MoveCamara>()._rb.velocity.x, speed*Time.fixedDeltaTime);
    }

    private void OnEnable()
    {
        _parentCBF = GameObject.Find("Dios_Boss").GetComponent<ControlBossFaces>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector3(Camera.main.GetComponentInParent<MoveCamara>()._rb.velocity.x, 0);
        _damage = _parentCBF.CurrentLife / 2;
    }

    private IEnumerator WaitTime(float time)
    {
        yield return new WaitForSeconds(time);
        _aP = ArmPosition.Elevate;
    }

    public void DamageBoss(float damage)
    {
        Life=- damage;
        if (Life <= 0)
             _parentCBF.GetDamaged(_damage);
    }
}
