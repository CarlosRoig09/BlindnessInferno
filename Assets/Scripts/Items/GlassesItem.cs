using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wilberforce;

public class GlassesItem : Items
{
    private Colorblind _colorBlind;
    private BlindColorTest _distanciaMax;
    private float _distance;
    

    void Start()
    {
        _colorBlind = Camera.main.GetComponent<Colorblind>();
        _distanciaMax=Camera.main.GetComponent<BlindColorTest>();
       base.Start();
    }

    protected override void Effecto(Collider2D collision)
    {
        _colorBlind.Type = 0;
        _distance = GameObject.Find("Kilomiters").GetComponent<Kilomiters>().Distancia;
        _distanciaMax.DistanciaMax=_distance+30f;
    }

  
}
