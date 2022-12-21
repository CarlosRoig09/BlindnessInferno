using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBehaviour : MonoBehaviour
{
    private float tiempoPrueba; //0.2
    private float fuerzaPrueba;//0.5
    [SerializeField] private float cantidadRotacion = 0.3f;//0.3
    [SerializeField] private float cantidadFuerza = 0.5f; //1

    private float tiempoRestante, fuerzaShake, tiempo, rotacion;


    private Vector3 posIni;
    private bool shake;

    public ShakeBehaviour instance;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        shake = false;
    }

    private void LateUpdate()
    {
        {
            if (shake)
            {
                if (tiempoRestante > 0f)
                {
                    tiempoRestante -= Time.deltaTime;
                    float cantidadX = posIni.x + Random.Range(-cantidadFuerza, cantidadFuerza) * fuerzaShake;
                    float cantidadY = posIni.y + Random.Range(-cantidadFuerza, cantidadFuerza) * fuerzaShake;
                    cantidadX = Mathf.MoveTowards(cantidadX, posIni.x, tiempo * Time.deltaTime);
                    cantidadY = Mathf.MoveTowards(cantidadY, posIni.y, tiempo * Time.deltaTime);
                    transform.localPosition = new Vector3(cantidadX, cantidadY, posIni.z);
                    rotacion = Mathf.MoveTowards(rotacion, 0f, tiempo * cantidadRotacion * Time.deltaTime);
                    transform.localRotation = Quaternion.Euler(0f, 0f, rotacion * Random.Range(-1f, 1f));
                }
                else
                {
                    transform.localPosition = posIni;
                    shake = false;
                }

            }
        }
    }

    public void StartShake(float duracion, float fuerza)
    {
        posIni = transform.localPosition;
        shake = true;
        tiempoRestante = duracion;
        fuerzaShake = fuerza;
        tiempo = fuerza / duracion;
        rotacion = fuerza * cantidadRotacion;
    }

}
