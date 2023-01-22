using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShHit : MonoBehaviour
{
    private ShakeBehaviour _shake;
    private float _duracion;
    private float _fuerza;

    public  void CallShake()
    {

        _shake.StartShake(_duracion, _fuerza);
    }

    // Start is called before the first frame update
    void Start()
    {
        _shake = GameObject.Find("Main Camera").GetComponent<ShakeBehaviour>();
        _duracion = 0.75f;
        _fuerza = 0.2f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            CallShake();
        }
    }
}
