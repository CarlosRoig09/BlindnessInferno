using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _distanceRight;
    [SerializeField]
    private float _distanceLeft;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ControlSpeed();
        Movement();
    }

    private void Movement()
    {
        transform.position = new Vector3(transform.position.x + _speed*Time.deltaTime, transform.position.y);
    }
    private void ControlSpeed()
    {
        if (transform.position.x >= _distanceRight||transform.position.x<=_distanceLeft)
            _speed *= -1;
    }
}
