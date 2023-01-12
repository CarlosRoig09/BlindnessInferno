using UnityEngine;

public class BookScript : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField]
    private float _timeChangeDirection;
    private float _countTimeCD;
    [SerializeField]
    private float _speed;
    private ControlBossFaces _parentCBF;
    private EnemyMovement _eM;
    // Start is called before the first frame update
    void Start()
    {
        _eM = EnemyMovement.Right;
        _countTimeCD = 0;
        _rb = gameObject.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(6, 6);
        _parentCBF = transform.parent.GetComponent<ControlBossFaces>();
        _parentCBF.OnEndFace += Death;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_eM)
        {
            case EnemyMovement.Right:
                LinearMovement(_speed, EnemyMovement.Left);
                break;
            case EnemyMovement.Left:
                LinearMovement(_speed * -1, EnemyMovement.Right);
                break;
        }
    }

    void LinearMovement(float speed, EnemyMovement enemyMovement)
    {
        _rb.velocity = new Vector3(_rb.velocity.x, speed * Time.fixedDeltaTime);
        if (_timeChangeDirection <= _countTimeCD)
        {
            _eM = enemyMovement;
            _countTimeCD = 0;
        }
        else _countTimeCD += Time.deltaTime;
    }
   private void Death()
    {
        Destroy(gameObject);
    }
    private void OnDisable()
    {
        _parentCBF.OnEndFace -= Death;
    }
}
