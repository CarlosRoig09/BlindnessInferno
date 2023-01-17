using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlataformTransition : PlatformControler
{
    private Rigidbody2D _rb;
   
    private Rigidbody2D[] _rbChild;
    public float _speed;
    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    
        _rbChild =gameObject.GetComponentsInChildren<Rigidbody2D>();
        
    }

    private void Update()
    {
        PlatformHability();

    }

    public override void PlatformHability()
    {
        _rb.constraints = RigidbodyConstraints2D.None;
        _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        foreach (var _rbebe in _rbChild)
        {
            _rbebe.constraints = RigidbodyConstraints2D.None;
            _rbebe.constraints = RigidbodyConstraints2D.FreezePositionX;
            _rbebe.constraints = RigidbodyConstraints2D.FreezeRotation;
            _rbebe.velocity = new Vector2(_rbebe.velocity.x,  _speed* _rbebe.velocity.y);
           // Debug.Log(_rbebe.name);
        }
      
    }
}
