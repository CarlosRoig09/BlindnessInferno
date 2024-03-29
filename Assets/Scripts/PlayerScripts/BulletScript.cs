using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public bool BulletSizeStatus;
    private float proyectileDamage;
    private ControlScore _controlScore;
    private int _score;

    public SpecialEnemySO _specialEnemySO;
    public BasicEnemySO _basicEnemySO;
    public AtackEnemySO _atakEnemySO;
    public FlyEnemySO _flyEnemySO;
    private Animator _anim;
    private Rigidbody2D _rb;

    public float ProyectileDamage
    {
        set { proyectileDamage = value; }
    }


    void Start()
    {
       /* screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        bulletHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        bulletWeight = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;*/
       _anim= gameObject.GetComponent<Animator>();
        BulletSizeStatus = false;
        _controlScore = GameObject.Find("Character").GetComponent<ControlScore>();
        _rb = gameObject.GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        Destroy(gameObject, 8);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Character")
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
               _score= collision.gameObject.GetComponent<Enemy>().Score;
                _controlScore.ScorePlus(_score);
                Destroy(collision.gameObject, collision.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            }

            if (collision.gameObject.CompareTag("EnemyProyectile"))
            {
                _score = collision.gameObject.GetComponent<Enemy>().Score;
                _controlScore.ScorePlus(_score);
                Destroy(collision.gameObject);
            }
                
            if (collision.gameObject.CompareTag("EnemyBossHitPoint"))
            {
               collision.gameObject.GetComponentInParent<ControlBossFaces>().GetDamaged(proyectileDamage);
            }

            if (collision.gameObject.CompareTag("BossArms"))
            {
                collision.gameObject.GetComponent<ArmAttack>().DamageBoss(proyectileDamage);
            }
            if (collision.gameObject.CompareTag("Box"))
            {
                collision.gameObject.GetComponent<SupriseBox>().BreakAnimation();
            }
            //Destroy(collision.gameObject);
            _anim.SetBool("Explosion", true);
        }
    }

    public void StopMomentum()
    {
        _rb.velocity= Vector3.zero;
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }

    /*public void IncrementProjectileSize()
    {
        transform.localScale = new Vector3(1, 1, 1);
        BulletSizeStatus = true;
    }

    public void DecrementProjectileSize()
    {
        transform.localScale = new Vector3(0.324f, 0.397f, 1);
        BulletSizeStatus = false;
    }*/
}
