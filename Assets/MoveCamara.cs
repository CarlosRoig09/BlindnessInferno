using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamara : MonoBehaviour
{
    [SerializeField]
    private PlayerData _playerData;
    public Rigidbody2D _rb;
    public float _speed;
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _speed = _playerData.speed;
        Movement();
    }

    protected void Movement()
    {
        _rb.velocity = new Vector2(_speed * Time.fixedDeltaTime, _rb.velocity.y);
    }
}
