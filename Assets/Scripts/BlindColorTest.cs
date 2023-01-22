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
    private SoundManagerScript _soundManager;
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
        _soundManager=GameObject.Find("Sound").GetComponent<SoundManagerScript>();
        _soundManager.PlaySound("Vsdemon");
        _colorBlind = Camera.main.GetComponent<Colorblind>();
        _distance = GameObject.Find("Kilomiters").GetComponent<Kilomiters>().Distancia;
        _colorBlind.Type = 1;
        _count = 0;
        _numRayo = 0;
        _diositoNoCuenta = true;
        _diositoInstancia = 0;

    }

    // Update is called once per frame
    void Update()
    {
        _distance = GameObject.Find("Kilomiters").GetComponent<Kilomiters>().Distancia;
        _colorBlind = Camera.main.GetComponent<Colorblind>();
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
            else if (_count >= 500f && _count < 575f)
            {
               
                Nivel = Niveles.TransNivel1;
                if (_count >= 537f)
                {
                    _colorBlind.Type = 2;
                    if (_numRayo == 0)
                        _soundManager.PlaySound("GodOfBlaze");
                    //      StartCoroutine(ChargeRayo(3f));

                }

            }
            else if (_count >= 575f && _count < 1075f)
            {
                _numRayo = 0;
                Nivel = Niveles.Nivel2;
                _colorBlind.Type = 2;

            }
            else if (_count >= 1075f && _count < 1150f)
            {
                Nivel = Niveles.TransNivel2;
                if (_count >= 1112f)
                {
                    _colorBlind.Type = 3;
                    if (_numRayo == 0)
                        _soundManager.PlaySound("DragonSlayer");
                    //     StartCoroutine(ChargeRayo(3f));

                }

            }
            else if (_count >= 1150f && _count < 1650f)
            {
                _numRayo = 0;
                Nivel = Niveles.Nivel3;
                _colorBlind.Type = 3;
            }
            else if (_count >= 1650f && _count < 1725f)
            {
                
                Nivel = Niveles.TransNivel3;
                if (_count >= 1687f)
                {
                    _colorBlind.Type = 3;
                     if (_numRayo == 0)
                        _soundManager.PlaySound("RequiemDiesIraeWolfgangAmadeusMozart");
                    //  StartCoroutine(ChargeRayo(3f));

                }

            }
            else if (_count >= 1725f && _count < 2225f)
            {
               
                Nivel = Niveles.NivelBoss1;
                if (_count >= 1800)
                {
                    _numRayo = 0;
                    if (_diositoInstancia == 0)
                    {
                        diosito = Instantiate(diosito);
                        _diositoNoCuenta = false;
                        _diositoInstancia = 1;
                    }
                    _currentFase = GameObject.Find("Dios_Boss").GetComponent<ControlBossFaces>().CurrentFase;

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
                            _count = 2225f;
                            _diositoInstancia = 0;
                            break;

                }
                }
              

            }
            else if (_count >= 2225f && _count < 2300f)
            {
                
                Nivel = Niveles.TransNivelBoss;
                if (_count >= 2262f)
                {
                    _colorBlind.Type = 1;
                    if (_numRayo == 0)
                        _soundManager.PlaySound("Vsdemon");
                    //   StartCoroutine(ChargeRayo(3f));

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