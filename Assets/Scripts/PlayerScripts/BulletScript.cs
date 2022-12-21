using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector2 screenBounds;
    private float bulletHeight;
    private float bulletWeight;
    public bool BulletSizeStatus;


    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        bulletHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        bulletWeight = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        BulletSizeStatus = false;
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
            if (collision.gameObject.tag == "Enemy")
                Destroy(collision.gameObject);
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