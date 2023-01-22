using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemy : Enemy
{
    private Animator _anim;
    private Rigidbody2D _rb;
    private Collider2D _cll;
    // Start is called before the first frame update
    void Start()
    {
        Score = 50;
        _anim = GetComponent<Animator>();
        _rb= GetComponent<Rigidbody2D>();
        _cll= GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            _rb.velocity = new Vector3(0, 1500 * Time.deltaTime);
            _anim.SetBool("Die", true);
            _cll.enabled = false;
        }
    }
}
