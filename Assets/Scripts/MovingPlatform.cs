using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All the platforms must be the childs of this one. 
public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private PlatformScriptableObject _plSO;

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
        transform.position = new Vector3(transform.position.x + -6*Time.deltaTime, transform.position.y, transform.position.z);
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
