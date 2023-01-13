using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossAwake : MonoBehaviour
{
    private float x;
    private float z;
    private float posDifference;
    public float awakenDistance;
    private float rotationSpeed;
    private GameObject _character;
    //public GameObject Lightning;


    void Start()
    {
        x = 0.0f;
        z = -90.0f;
        rotationSpeed = 50.0f;
        _character = GameObject.Find("Character");
    }

    void FixedUpdate()
    {
        posDifference = transform.localPosition.x - _character.transform.localPosition.x;

        if (posDifference < awakenDistance)
        {
            z += Time.deltaTime * rotationSpeed;

            if (z > 0.0f)
            {
                z = 0.0f;
            }

            /*GameObject lightningSpawned = Instantiate(Lightning);
            //lightningSpawned.transform.position = new Vector3(0, 0, 0);
            lightningSpawned.transform.position.x = transform.localPosition.x;*/

            transform.localRotation = Quaternion.Euler(x, 0, z);
        }
    }
}
