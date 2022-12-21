using UnityEngine;
using UnityEngine.UI;

public class Kilomiters : MonoBehaviour

{
    //Meter un texto pa mostrar distancia
    private Text distanciaText;
    private float _playerSpeed;
    private float distancia;
    public float Distancia
    {
        get=>distancia;
        set=>distancia = value;
    }
    // Start is called before the first frame update
    void Start()
    {
        distanciaText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Calculo la distancia usando el punto de salida y sumandole la posicion del personaje.
        Distancia += _playerSpeed * Time.deltaTime;
        //Meter resultado en texto:
        distanciaText.text = "Distancia: " + Distancia.ToString("F2") + " Mts.";
    }
}
