using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Collider2D _cd2D;
    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _cd2D = gameObject.GetComponent<Collider2D>();
    }
    public void Falling()
    {
        _rb.constraints = RigidbodyConstraints2D.None;
        _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
            _cd2D.enabled = false;
    }
}
