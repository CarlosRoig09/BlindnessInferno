using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum HandState
{
    MoveByMouse,
    MoveByRotateAnim,
}
public class MoveAroundThePlayerByMousePController : MonoBehaviour
{
    [SerializeField]
    private float _nearThePlayer;
    private float _roationSpeed;
    public float RoationSpeed { set { _roationSpeed = value; } }
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        RotationZ(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.parent.transform.position);
    }

    void RotationZ(Vector3 vector)
    {
        float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y,angle);
        float xPosition = Mathf.Cos(Mathf.Deg2Rad * angle);
        float yPosition = Mathf.Sin(Mathf.Deg2Rad * angle);
        transform.localPosition = new Vector3( Mathf.Abs(xPosition)/_nearThePlayer, yPosition/_nearThePlayer, 0);
    }

    void RotateAround(Vector3 pointToRotate)
    {
        transform.RotateAround(pointToRotate, new Vector3(0, 0, 1), _roationSpeed * Time.fixedDeltaTime);
    }
}
