using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBlindColor : MonoBehaviour
{
    private BlindColorTest _blindColorTest;
    private GameObject _blindColor;

    private Renderer rend;
    [SerializeField]
    private Color colorLevel1;
    [SerializeField]
    private Color colorLevel2;
    [SerializeField]
    private Color colorLevel3;
    void Start()
    {
        _blindColor = GameObject.Find("Main Camera");
        _blindColorTest = _blindColor.GetComponent<BlindColorTest>();
    }

    void Update()
    {
        rend = GetComponent<Renderer>();
        if (_blindColorTest.Nivel == Niveles.Nivel1||_blindColorTest.Nivel == Niveles.NivelBoss1)
        {
            rend.material.color = colorLevel1;
        }
        else if (_blindColorTest.Nivel == Niveles.Nivel2 || _blindColorTest.Nivel == Niveles.NivelBoss2)
        {
            rend.material.color = colorLevel2;
        }
        else if (_blindColorTest.Nivel == Niveles.Nivel3 || _blindColorTest.Nivel == Niveles.NivelBoss3)
        {
            rend.material.color = colorLevel3;
        }
    }
}
