using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusTimer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;

    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
                Debug.Log("BONUS TIME: " + TimeLeft);
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
