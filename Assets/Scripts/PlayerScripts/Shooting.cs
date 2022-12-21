using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;
    public float projectileSpeed = 50;
    [SerializeField]
    private float _countdown;
    private float _count;

    Vector2 lookDirection;
    float lookAngle;
    private void Start()
    {
        _count = _countdown;
    }
    void Update()
    {
         lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, Mathf.Abs(lookDirection.x)) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (Input.GetMouseButtonDown(0)&&_count>=_countdown)
        {
            GameObject projectileClone = Instantiate(projectile);
            projectileClone.transform.position = firePoint.position;
             projectileClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            projectileClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * projectileSpeed;
            _count = 0;
        }
        _count += Time.deltaTime;
    }
}
