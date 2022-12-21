using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentPlatform : PlatformControler
{


    public override void PlatformHability()
    {
        for (float alpha = 1; alpha > -0.1; alpha -= 0.1f)
        {

            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);

        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlatformHability();
        }
    }

}
