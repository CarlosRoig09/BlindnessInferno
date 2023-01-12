using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlockProyectile : MovingPlatform
{
    public GameObject Bonus;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject bonusObtained = Instantiate(Bonus);
            bonusObtained.transform.position = new Vector3 (0,0,0);
            Destroy(gameObject);
        }
    }
}
