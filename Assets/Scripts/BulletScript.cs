using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector2 screenBounds;
    private float bulletHeight;
    private float bulletWeight;


    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        bulletHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        bulletWeight = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }
    void Update()
    {
        if (transform.position.y >= ((screenBounds.y) - bulletHeight) || transform.position.y <=(screenBounds.y*-1) || transform.position.x >= ((screenBounds.x) - bulletWeight))
        {
            //Destruir objecto
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "Character")
        {
            //Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
