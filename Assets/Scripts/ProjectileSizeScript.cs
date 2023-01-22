using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectileSizeScript : MonoBehaviour
{
    private BonusTimer projectileSizeBonusTime;
    private GameObject _bonus;

    public delegate void CollectAction(int i);
    public static event CollectAction OnCollectAction;

    void Start()
    {
        _bonus = GameObject.Find("BonusTimer");
        projectileSizeBonusTime = _bonus.GetComponent<BonusTimer>();

        if (projectileSizeBonusTime.TimerOn == true)
        {
            projectileSizeBonusTime.TimeLeft += 5;
        }

        projectileSizeBonusTime.TimerOn = true;
        OnCollectAction(1);

        
    }

    void Update()
    {
        if (projectileSizeBonusTime.TimeLeft == 0)
        {
            OnCollectAction(-1);
            Destroy(gameObject);
            projectileSizeBonusTime.TimeLeft = 5;
        }
    }
}
