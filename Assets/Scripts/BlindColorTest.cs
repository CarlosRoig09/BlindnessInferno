using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wilberforce;


public enum Niveles
{
    Nivel1,
    TransNivel1,
    Nivel2,
    TransNivel2,
    Nivel3,
    TransNivel3,
    NivelBoss,
    TransNivelBoss
}
public class BlindColorTest : MonoBehaviour
{
    private Colorblind _colorBlind;
    private Niveles _nivel;
    public Niveles Nivel
    {
        get => _nivel;
        set => _nivel = value;
    }
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
            if (_count >= 0f && _count < 500f)
            {
                Nivel = Niveles.Nivel1;
                _colorBlind.Type = 1;
            }
            else if (_count >= 500f && _count < 600f)
            {
                Nivel = Niveles.TransNivel1;
                if (_count >= 550f)
                {
                    _colorBlind.Type = 2;

                }
               
            }
            else if (_count >= 650f && _count < 2000f)
            {
                Nivel = Niveles.Nivel2;
                _colorBlind.Type = 2;

            }
            else if (_count >= 2000f && _count < 3000f)
            {
                Nivel = Niveles.Nivel3;
                _colorBlind.Type = 3;
            }
            else _count = 0;
        }
        _count += 10*Time.deltaTime;
        //Debug.Log(_count);
    }

 

}
