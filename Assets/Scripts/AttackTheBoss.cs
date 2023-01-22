using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTheBoss : MonoBehaviour
{
    private Transform _boss;
    private Rigidbody2D _rb;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _damage;
    // Start is called before the first frame update
    void Start()
    {
        _boss = GameObject.Find("Boss(Clone)").GetComponent<Transform>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        var lookDirection = _boss.position - transform.position;
        var lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, lookAngle);
        _rb.velocity = _speed * Time.deltaTime * transform.right;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBoss"))
        {
            Debug.Log("I hit the boss yeah");
            collision.gameObject.GetComponent<ControlBossFaces>().GetDamaged(_damage);
            Destroy(gameObject);
        }
    }
}
