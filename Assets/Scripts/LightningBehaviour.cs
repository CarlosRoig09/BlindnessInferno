using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBehaviour : PlatformControler
{
    private ShakeBehaviour _shake;
    private float _duracion;
    private float _fuerza;
    private GameObject _whiteScreen;

    public override void PlatformHability()
    {

        _shake.StartShake(_duracion, _fuerza);
    }

    void Start()
    {
        _whiteScreen = GameObject.Find("WhiteScreen");
        _whiteScreen.SetActive(false);
        _shake = GameObject.Find("Main Camera").GetComponent<ShakeBehaviour>();
        _duracion = gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 8;
        _fuerza = 0.2f;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fallable"))
        {
            PlatformHability();
            _whiteScreen.SetActive(true);
        }
    }

}
