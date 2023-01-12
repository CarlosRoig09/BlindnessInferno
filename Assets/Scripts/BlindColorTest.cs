using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wilberforce;

public class BlindColorTest : MonoBehaviour
{
    private Colorblind _colorBlind;

    private float _distance;
    private float _distanciaMax;
    private float _count;
    public float DistanciaMax
    {
        get=>_distanciaMax;
        set=>_distanciaMax = value;
    }
    // Start is called before the first frame update
    void Start()
    {
        _colorBlind = Camera.main.GetComponent<Colorblind>();
        _distance = GameObject.Find("Kilomiters").GetComponent<Kilomiters>().Distancia;
        _colorBlind.Type = 1;
        _count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _distance = GameObject.Find("Kilomiters").GetComponent<Kilomiters>().Distancia;
      

        if (_colorBlind.Type == 0 && _distance <= _distanciaMax)
        {
            _colorBlind.Type = 0;
        }
        else
        {
            if (_count >= 0f && _count < 300f)
            {
                _colorBlind.Type = 1;
            }
            else if (_count >= 300f && _count < 600f)
            {
                _colorBlind.Type = 2;

            }
            else if (_count >= 600f && _count < 900f)
            {
                _colorBlind.Type = 3;
            }
            else _count = 0;
        }
        _count += 10*Time.deltaTime;
        //Debug.Log(_count);
    }
}
