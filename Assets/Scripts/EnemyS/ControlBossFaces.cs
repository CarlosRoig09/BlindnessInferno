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
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _currentFase = BossFase.StartBossFase1;
        _Arms = GameObject.Find("Arms");
        _Arms.SetActive(false);
        _collider = gameObject.GetComponent<Collider2D>();
        _anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentFase)
        {
            case BossFase.StartBossFase1:
                MoveBoss(_rightCamera.position);
                LifeForFace(BossEnemySO.LifeFirstFace, BossFase.BossFase1);
                break;
            case BossFase.BossFase1:
                ComproveIfFaseEnd(_currentLife);
                break;
            case BossFase.StartBossFase2:
                _collider.enabled = false;
                MoveBoss(_centerCamera.position);
                LifeForFace(BossEnemySO.LifeSecondFace, BossFase.BossFase2);
                _Arms.SetActive(true);
                break;
            case BossFase.BossFase2:
                ComproveIfFaseEnd(_currentLife);
                break;
            case BossFase.StartBossFase3:
                _collider.enabled = true;
                MoveBoss(_leftCamera.position);
                transform.localScale = new Vector3(5.095526f, 5.095526f);
                LifeForFace(BossEnemySO.LifeThirtFace, BossFase.BossFase3);
                break;
            case BossFase.BossFase3:
                transform.localScale = new Vector3(0.5f,0.5f);
                ComproveIfFaseEnd(_currentLife);
                break;
            case BossFase.Death:
                Destroy(gameObject);
                break;
        }
    }

    void MoveBoss(Vector3 newPosition)
    {
        transform.parent.position = new Vector3 (newPosition.x, transform.parent.position.y);
        _anim.SetBool("Start", true);
    }

    void ComproveIfFaseEnd(float life)
    {
        _anim.SetBool("Start", false);
        _anim.SetBool("Hit", false);
        _anim.SetBool("End", false);
        if (life <= 0&&OnEndFace!=null)
        {
             OnEndFace();
            _anim.SetBool("End", true);
        }
    }
    void LifeForFace(float newLife, BossFase BF)
    {
        _currentLife = newLife;
        _currentFase = BF;
    }

    public void ChangeFace()
    {
        switch (_currentFase)
        {
            case BossFase.BossFase1:
                _currentFase = BossFase.StartBossFase2;
                break;
            case BossFase.BossFase2:
                _currentFase = BossFase.StartBossFase3;
                break;
            case BossFase.BossFase3:
                _currentFase = BossFase.Death;
                break;
        }
    }
    public void GetDamaged(float damage)
    {
        _anim.SetBool("Hit", true);
        _currentLife -= damage;
    }
}
