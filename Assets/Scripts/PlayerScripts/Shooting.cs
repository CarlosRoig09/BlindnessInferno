using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;
    public float projectileSpeed = 50;
    [SerializeField]
    private float _countdown;
    private float _count;
    public float _bulletSize = 1;

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
            projectileClone.transform.localScale = new Vector3(projectile.transform.localScale.x *_bulletSize, projectile.transform.localScale.y * _bulletSize, 1);
            projectileClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * projectileSpeed;
            _count = 0;
        }
        _count += Time.deltaTime;
    }

    private void OnEnable()
    {
        ProjectileSizeScript.OnCollectAction += ChangeBulletSize;
    }

    private void OnDisable()
    {
        ProjectileSizeScript.OnCollectAction -= ChangeBulletSize;
    }

    public void ChangeBulletSize(int i)
    {
        Debug.Log("balas mas grandes");
        _bulletSize += i;
        if (_bulletSize == 0)
        {
            _bulletSize = 0.324f;
        }
    }
}
