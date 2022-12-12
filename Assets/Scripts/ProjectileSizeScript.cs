using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectileSizeScript : MovingPlatform
{
    private BulletScript _bulletScript;
    private GameObject _bullet;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            /*_bullet = Resources.Load("Prefabs/Proyectile") as GameObject;
            _bulletScript = _bullet.GetComponent<BulletScript>();
            _bulletScript.IncrementProjectileSize();
            //Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/GameObject.prefab", typeof(GameObject));
            //timer += Time.deltaTime;

            if (_bulletScript.BulletSizeStatus)
            {
                _bulletScript.DecrementProjectileSize();
            }*/
            DestroyObject();
        }

    }
}
