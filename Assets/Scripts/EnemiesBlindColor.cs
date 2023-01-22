using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBlindColor : MonoBehaviour
{
    private BlindColorTest _blindColorTest;
    private GameObject _blindColor;

    private Renderer rend;
    [SerializeField]
    private Color colorLevel1 = Color.white;
    [SerializeField]
    private Color colorLevel2 = Color.white;
    [SerializeField]
    private Color colorLevel3 = Color.white;
    void Start()
    {
        _blindColor = GameObject.Find("Main Camera");
        _blindColorTest = _blindColor.GetComponent<BlindColorTest>();
    }

    void Update()
    {
        rend = GetComponent<Renderer>();
        if (_blindColorTest.Nivel == Niveles.Nivel1)
        {
            rend.material.color = colorLevel1;
        }
        else if (_blindColorTest.Nivel == Niveles.Nivel2)
        {
            rend.material.color = colorLevel2;
        }else if (_blindColorTest.Nivel == Niveles.Nivel3)
        {
            rend.material.color = colorLevel3;
        }
    }
}
