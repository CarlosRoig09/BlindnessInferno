using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wilberforce;

public class BlindColorTest : MonoBehaviour
{
    private Colorblind _colorBlind;

    private float _distance;
    // Start is called before the first frame update
    void Start()
    {
        _colorBlind = Camera.main.GetComponent<Colorblind>();
        _distance = GameObject.Find("Kilomiters").GetComponent<Kilomiters>().Distancia;
        _colorBlind.Type = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _distance = GameObject.Find("Kilomiters").GetComponent<Kilomiters>().Distancia;
        if (_distance >= 5f && _distance < 300f)
        {
            _colorBlind.Type = 1;
        }
        else if (_distance >= 300f && _distance < 600f)
        {
            _colorBlind.Type = 2;

        }
        else if (_distance >= 600f)
        {
            _colorBlind.Type = 3;

        }

        Debug.Log(_colorBlind.Type);
        Debug.Log(_distance);

    }
}
