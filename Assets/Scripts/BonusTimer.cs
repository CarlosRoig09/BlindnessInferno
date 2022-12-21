using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusTimer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;
    /*private ProjectileSizeScript projectileSizeScript;
    private GameObject _bonus;*/

    void Start()
    {
        //TimerOn = true;
        /*_bonus = GameObject.Find("Bonus");
        projectileSizeScript = _bonus.GetComponent<ProjectileSizeScript>();*/
    }

    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                TimeLeft = 0;
                TimerOn = false;
                //projectileSizeScript.OnCollect = 0;
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
    }
}
