using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All the platforms must be the childs of this one. 
public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    public float Speed
    {
        get => _speed;
        set
        {
            if (value > 0)
                value*=-1;
            if (value == 0)
                value = -2;
            _speed = value;
        }
    }
    // Start is called before the first frame update
   protected virtual void Start()
    {
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Movement();
    }

    protected void Movement()
    {
        transform.position = new Vector3(transform.position.x + _speed*Time.deltaTime, transform.position.y, transform.position.z);
       if (IsOutTheLimits())
            DestroyObject();
    }

    protected bool IsOutTheLimits()
    {
        return transform.position.x <= (Camera.main.transform.position.x - (2f * Camera.main.orthographicSize * Camera.main.aspect)) / 2 - transform.localScale.x;
    }

    protected void DestroyObject()
    {
        Destroy(gameObject);
    }
}
