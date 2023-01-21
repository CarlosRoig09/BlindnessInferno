using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public enum BossFase
{
    StartBossFase1,
    BossFase1,
    StartBossFase2,
    BossFase2,
    StartBossFase3,
    BossFase3,
    Death
}
public class ControlBossFaces : MonoBehaviour
{
    private float _currentLife;
    public float CurrentLife
    {
        get => _currentLife;
    }
    private BossFase _currentFase;
 
    private Collider2D _collider;
    [SerializeField]
    private BossEnemySO BossEnemySO;
    public delegate void EndFace();
    public event EndFace OnEndFace;
    [SerializeField]
    private Transform _centerCamera;
    [SerializeField]
    private Transform _rightCamera;
    [SerializeField]
    private Transform _leftCamera;
    private GameObject _Arms;
    // Start is called before the first frame update
    void Start()
    {
        _currentFase = BossFase.StartBossFase1;
        _Arms = GameObject.Find("Arms");
        _Arms.SetActive(false);
        _collider = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentFase)
        {
            case BossFase.StartBossFase1:
                MoveBoss(_rightCamera.position);
                LifeForFace(BossEnemySO.LifeFirstFace, BossFase.BossFase1);
                transform.localScale = new Vector3(9.88271f, 9.88271f);
                break;
            case BossFase.BossFase1:
                ComproveIfFaseEnd(BossFase.StartBossFase2, _currentLife);
                break;
            case BossFase.StartBossFase2:
                _collider.enabled = false;
                MoveBoss(_centerCamera.position);
                LifeForFace(BossEnemySO.LifeSecondFace, BossFase.BossFase2);
                _Arms.SetActive(true);
                break;
            case BossFase.BossFase2:
                ComproveIfFaseEnd(BossFase.StartBossFase3, _currentLife);
                break;
            case BossFase.StartBossFase3:
                _collider.enabled = true;
                MoveBoss(_leftCamera.position);
                transform.localScale = new Vector3(5.095526f, 5.095526f);
                LifeForFace(BossEnemySO.LifeThirtFace, BossFase.BossFase3);
                break;
            case BossFase.BossFase3:
                transform.localScale = new Vector3(0.5f,0.5f);
                ComproveIfFaseEnd(BossFase.Death, _currentLife);
                break;
            case BossFase.Death:
                Destroy(gameObject);
                break;
        }
    }

    void MoveBoss(Vector3 newPosition)
    {
        transform.parent.position = new Vector3 (newPosition.x, transform.parent.position.y);
    }

    void ComproveIfFaseEnd(BossFase BF, float life)
    {
        if (life <= 0)
        {
            _currentFase = BF;
            OnEndFace();
        }
    }
    void LifeForFace(float newLife, BossFase BF)
    {
        _currentLife = newLife;
        _currentFase = BF;
    }
    public void GetDamaged(float damage)
    {
        _currentLife -= damage;
    }
}
