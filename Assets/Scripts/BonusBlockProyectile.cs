using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlockProyectile : MovingPlatform
{
    public GameObject Bonus;
    public GameObject Timer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            /*GameObject timerStarted = Instantiate(Timer);
            timerStarted.transform.position = new Vector3(0, 0, 0);*/

            GameObject bonusObtained = Instantiate(Bonus);
            bonusObtained.transform.position = new Vector3 (0,0,0);
            Destroy(gameObject);
        }
    }
}
