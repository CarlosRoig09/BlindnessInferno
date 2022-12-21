using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectileSizeScript : MonoBehaviour
{
    /*private BulletScript _bulletScript;
    private GameObject _bullet;
    private Shooting _shootingScript;
    private GameObject _player;*/
    private BonusTimer projectileSizeBonusTime;
    private GameObject _bonus;

    public delegate void CollectAction(int i);
    public static event CollectAction OnCollectAction;

    void Start()
    {
        _bonus = GameObject.Find("BonusTimer");
        projectileSizeBonusTime = _bonus.GetComponent<BonusTimer>();

        projectileSizeBonusTime.TimerOn = true;
        Debug.Log("estoy aqui");
        OnCollectAction(1);
    }

    void Update()
    {
        Debug.Log("HOLA 1");
        if (projectileSizeBonusTime.TimeLeft == 0)
        {
            Debug.Log("HOLA 2");
            OnCollectAction(-1);
            Destroy(gameObject);
        }
    }
}
