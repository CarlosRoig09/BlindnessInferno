using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProyectile : Enemy
{
    private Rigidbody2D _rb2D;
    public float Velocity;
    // Start is called before the first frame update
    void Start()
    {
        _rb2D = gameObject.GetComponent<Rigidbody2D>();
        Score = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        _rb2D.velocity = new Vector3 (-1*Velocity * Time.fixedDeltaTime, _rb2D.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy"))
            Destroy(gameObject);
        
    }
}
