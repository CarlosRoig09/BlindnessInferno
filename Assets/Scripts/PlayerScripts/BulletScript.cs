using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector2 screenBounds;
    private float bulletHeight;
    private float bulletWeight;
    public bool BulletSizeStatus;
    private float proyectileDamage;
    private ControlScore _controlScore;
    private int _score;

    public SpecialEnemySO _specialEnemySO;
    public BasicEnemySO _basicEnemySO;
    public AtackEnemySO _atakEnemySO;
    public FlyEnemySO _flyEnemySO;


    public float ProyectileDamage
    {
        set { proyectileDamage = value; }
    }


    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        bulletHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        bulletWeight = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        BulletSizeStatus = false;
        _controlScore = GameObject.Find("Character").GetComponent<ControlScore>();
    }
    void Update()
    {
        if (transform.position.y >= ((screenBounds.y) - bulletHeight) || transform.position.y <=(screenBounds.y*-1) || transform.position.x >= ((screenBounds.x) - bulletWeight))
        {
            //Destruir objecto
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Character")
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                switch (collision.gameObject.name)
                {
                    case "Enemy":
                        _score = _basicEnemySO.score;
                        break;
                    case "AtackEnemy":
                        _score = _atakEnemySO.score;
                        break;
                    case "FlyEnemy":
                        _score = _flyEnemySO.score;
                        break;
                    case "EspecialE":
                        _score = _specialEnemySO.score;
                        break;
                    default:
                        break;

                }
                Debug.Log(collision.gameObject.name);
                _controlScore.ScorePlus(_score);
                Destroy(collision.gameObject);
            }
                
            if (collision.gameObject.CompareTag("EnemyBossHitPoint"))
            {
                gameObject.GetComponentInParent<ControlBossFaces>().GetDamaged(proyectileDamage);
            }
            //Destroy(collision.gameObject);
            Destroy(gameObject);
        }
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
