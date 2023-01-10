using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakePlatform : PlatformControler
{
    private ShakeBehaviour _shake;
    private float _duracion;
    private float _fuerza;

    public override void PlatformHability()
    {
     
        _shake.StartShake(_duracion, _fuerza);
    }

    // Start is called before the first frame update
    void Start()
    {
        _shake = GameObject.Find("Main Camera").GetComponent<ShakeBehaviour>();
        _duracion = gameObject.GetComponent<SpriteRenderer>().bounds.size.x/8;
        _fuerza = 0.2f;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlatformHability();
        }
    }
}
