using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : BasicEnemy
{
    private float _countProyectile;
    private AtackEnemySO atackEnemySO;

    protected override void Start()
    {
        base.Start();
        atackEnemySO = (AtackEnemySO)_bESO;
        _countProyectile = 0;
      
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (eM == EnemyMovement.Float)
        {
            if (atackEnemySO.proyectileTimer <= _countProyectile)
            {
                Shoot();
                _countProyectile = 0;
            }
            else
                _countProyectile += Time.deltaTime;
        }
    }

    void Shoot()
    {
        Instantiate(atackEnemySO.proyectile,new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
    }
}
