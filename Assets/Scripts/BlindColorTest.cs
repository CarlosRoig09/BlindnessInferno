using System;
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
    NivelBoss1,
    NivelBoss2,
    NivelBoss3,
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
    private float _numRayo;
    private float _diositoInstancia;
    public float DistanciaMax
    {
        get => _distanciaMax;
        set => _distanciaMax = value;
    }

    public GameObject rayo;
    private BossFase _currentFase;
    public GameObject diosito;
    private bool _diositoNoCuenta;
    // Start is called before the first frame update
    void Start()
    {

        _colorBlind = Camera.main.GetComponent<Colorblind>();
        _distance = GameObject.Find("Kilomiters").GetComponent<Kilomiters>().Distancia;
        _colorBlind.Type = 1;
        _count = 1780f;
        _numRayo = 0;
        _diositoNoCuenta = true;
        _diositoInstancia = 0;

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
                _numRayo = 0;
                Nivel = Niveles.Nivel1;
                _colorBlind.Type = 1;
            }
            else if (_count >= 500f && _count < 600f)
            {
                Nivel = Niveles.TransNivel1;
                if (_count >= 550f)
                {
                    _colorBlind.Type = 2;
                    if (_numRayo == 0)
                        StartCoroutine(ChargeRayo(3f));

                }

            }
            else if (_count >= 600f && _count < 1100f)
            {
                _numRayo = 0;
                Nivel = Niveles.Nivel2;
                _colorBlind.Type = 2;

            }
            else if (_count >= 1100f && _count < 1200f)
            {
                Nivel = Niveles.TransNivel2;
                if (_count >= 1150f)
                {
                    _colorBlind.Type = 3;
                    if (_numRayo == 0)
                        StartCoroutine(ChargeRayo(3f));

                }

            }
            else if (_count >= 1200f && _count < 1700f)
            {
                _numRayo = 0;
                Nivel = Niveles.Nivel3;
                _colorBlind.Type = 3;
            }
            else if (_count >= 1700f && _count < 1800f)
            {
                Nivel = Niveles.TransNivel3;
                if (_count >= 1750f)
                {
                    _colorBlind.Type = 3;
                    if (_numRayo == 0)
                        StartCoroutine(ChargeRayo(3f));

                }

            }
            else if (_count >= 1700f && _count < 2200f)
            {
                _numRayo = 0;
                if(_diositoInstancia==0)
                {
                   diosito=Instantiate(diosito);
                    _diositoNoCuenta = false;
                    _diositoInstancia = 1;
                }

                switch (_currentFase)
                {
                    case BossFase.StartBossFase1:
                        Nivel = Niveles.NivelBoss1;
                        _colorBlind.Type = 1;
                        break;
                    case BossFase.BossFase1:
                        Nivel = Niveles.NivelBoss1;
                        _colorBlind.Type = 1;
                        break;
                    case BossFase.StartBossFase2:
                        Nivel = Niveles.NivelBoss2;
                        _colorBlind.Type = 2;
                        break;
                    case BossFase.BossFase2:
                        Nivel = Niveles.NivelBoss2;
                        _colorBlind.Type = 2;
                        break;
                    case BossFase.StartBossFase3:
                        Nivel = Niveles.NivelBoss3;
                        _colorBlind.Type = 3;
                        break;
                    case BossFase.BossFase3:
                        Nivel = Niveles.NivelBoss3;
                        _colorBlind.Type = 3;
                        break;
                    case BossFase.Death:
                        _diositoNoCuenta = true;
                        _count = 2200f;
                        _diositoInstancia = 0;
                        break;

                }
            
            }
            else if (_count >= 2200f && _count < 2300f)
            {
                Nivel = Niveles.TransNivelBoss;
                if (_count >= 2250f)
                {
                    _colorBlind.Type = 1;
                    if (_numRayo == 0)
                        StartCoroutine(ChargeRayo(3f));

                }

            }
            else _count = 0;
        }
        if (_diositoNoCuenta == true)
        {
            _count += 10 * Time.deltaTime;
        }
        
        //Debug.Log(_count);
    }

    public IEnumerator ChargeRayo(float time)
    {
       rayo=Instantiate(rayo, gameObject.transform.position, Quaternion.identity);
        _numRayo = 1;
        yield return new WaitForSeconds(time);
        Destroy(rayo);
    }
}