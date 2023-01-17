using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossAwake : MonoBehaviour
{
    private float x;
    private float z;
    private float posDifference;
    public float awakenDistance;
    public float lightningDistance;
    private float rotationSpeed;
    private GameObject _character;
    public GameObject Lightning;
    private int _lightningCount = 0;
    private GameObject _awakenCross;


    void Start()
    {
        x = 0.0f;
        z = -90.0f;
        rotationSpeed = 50.0f;
        _character = GameObject.Find("Character");
        _awakenCross = GameObject.Find("AwakenCross");
    }

    void FixedUpdate()
    {
        posDifference = transform.localPosition.x - _character.transform.localPosition.x;

        if (posDifference < lightningDistance && _lightningCount == 0)
        {
            _lightningCount++;
            GameObject lightningSpawned = Instantiate(Lightning);
            lightningSpawned.transform.position = new Vector3(transform.localPosition.x, 1.25f, 0);
        }

        if (posDifference < awakenDistance)
        {
            z += Time.deltaTime * rotationSpeed;

            if (z > 0.0f)
            {
                z = 0.0f;
            }
            
            transform.localRotation = Quaternion.Euler(x, 0, z);
        }
    }
}
