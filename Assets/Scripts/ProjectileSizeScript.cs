using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectileSizeScript : MonoBehaviour
{
    private BulletScript _bulletScript;
    private GameObject _bullet;
    private Shooting _shootingScript;
    private GameObject _player;

    public delegate void CollectAction(int i);
    public static event CollectAction OnCollectAction;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CHoque");
        if (collision.gameObject.CompareTag("Player"))
        {
            _player = GameObject.Find("Character");
            _shootingScript = _player.GetComponent<Shooting>();
            //_shootingScript.ChangeSize.Invoke;
            //DestroyObject();
            Debug.Log("estoy aqui");
            OnCollectAction(1);
        }
    }
}
