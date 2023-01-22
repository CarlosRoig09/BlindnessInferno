using UnityEngine;

//All the platforms must be the childs of this one. 
public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private PlatformScriptableObject _plSO;
    private WalkingScript _walkingScript;
    private float _speed;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _walkingScript = GameObject.Find("Character").GetComponent<WalkingScript>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        /*_speed = _walkingScript.speed*0.1f+2f;
        Movement();*/
    }

    protected void Movement()
    {
        transform.position = new Vector3(transform.position.x + _speed*Time.deltaTime*Vector2.left.x, transform.position.y, transform.position.z);
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
