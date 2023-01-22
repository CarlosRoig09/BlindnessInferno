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
    private float proyectileDamage;
    private float _initialDamage;
    [SerializeField]
    private float _countdown;
    private float _count;
    public float _bulletSize = 1;
    [SerializeField]
    private Animator _anim;

    Vector2 lookDirection;
    float lookAngle;

    private void Start()
    {
        _count = _countdown;
        _initialDamage = proyectileDamage;
    }
    void Update()
    {
         lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, Mathf.Abs(lookDirection.x)) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (Input.GetMouseButton(0)&&_count>=_countdown)
        {
            _anim.SetBool("Attak", true);
            SpawnProyectile();
        }
       else _count += Time.deltaTime;
    }

    public void EndAttack()
    {
        _anim.SetBool("Attak", false);
    }

    public void SpawnProyectile()
    {
        if (_count >= _countdown)
        {
            GameObject projectileClone = Instantiate(projectile);
            projectileClone.transform.position = firePoint.position;
            projectileClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
            projectileClone.transform.localScale = new Vector3(projectile.transform.localScale.x * _bulletSize, projectile.transform.localScale.y * _bulletSize, 1);
            projectileClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * projectileSpeed;
            projectileClone.GetComponent<BulletScript>().ProyectileDamage = proyectileDamage;
            _count = 0;
        }
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
        if (_bulletSize <= 2)
        {
            if (_bulletSize == 2 && i == -1)
            {
                _bulletSize += i;
            }else if (_bulletSize == 1 && i == 1)
            {
                _bulletSize += i;
            }
        }

        Debug.Log("BULLET SIZE: " + _bulletSize);

        if (_bulletSize == 2)
        {
            proyectileDamage*= 2;
        }else if (_bulletSize == 1)

        {

            proyectileDamage = _initialDamage;

        }
    }
}
