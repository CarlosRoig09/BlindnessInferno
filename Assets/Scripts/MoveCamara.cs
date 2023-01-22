using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamara : MonoBehaviour
{
    [SerializeField]
    private PlayerData _playerData;
    public Rigidbody2D _rb;
    [SerializeField]
    private float _speedMultiplicator;
    public float SpeedMultiplicator
    {
        get => _speedMultiplicator;
        set => _speedMultiplicator = value;
    }
  /*  public float SpeedMultiplicator
    {

    }*/
    private float _speed;
    public float Speed
    {
        get => _speed;
    }
    // Start is called before the first frame update
    void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _speed = _playerData.speed*_speedMultiplicator;
        Movement();
    }

    protected void Movement()
    {
        _rb.velocity = new Vector2(_speed * Time.fixedDeltaTime, _rb.velocity.y);
    }
}
