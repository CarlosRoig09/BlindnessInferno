using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlockProyectile : MovingPlatform
{

    /*private BonusTimer projectileSizeBonusTime;
    private GameObject _bonus;

    public delegate void CollectAction(int i);
    public static event CollectAction OnCollectAction;*/

    public GameObject Bonus;

    /*void Start()
    {
        _bonus = GameObject.Find("BonusTimer");
        projectileSizeBonusTime = _bonus.GetComponent<BonusTimer>();
    }

    void Update()
    {
        Debug.Log("HOLA 1");
        if (projectileSizeBonusTime.TimeLeft == 0)
        {
            Debug.Log("HOLA 2");
            OnCollectAction(0);
        }
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CHoque");
        if (collision.gameObject.CompareTag("Player"))
        {
            /*projectileSizeBonusTime.TimerOn = true;
            Debug.Log("estoy aqui");
            OnCollectAction(1);*/
            GameObject bonusObtained = Instantiate(Bonus);
            bonusObtained.transform.position = new Vector3 (0,0,0);
            Destroy(gameObject);
            //SetActive

            /*if (projectileSizeBonusTime.TimeLeft == 0)
            {
                OnCollectAction(0);
            }*/
        }
    }
}
