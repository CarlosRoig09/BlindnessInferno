using UnityEngine;
using UnityEngine.UI;

public class Kilomiters : MonoBehaviour

{
    //Meter un texto pa mostrar distancia
    private Text distanciaText;
    private float _playerSpeed;
    private float distancia;
    // Start is called before the first frame update
    void Start()
    {
        _playerSpeed = GameObject.Find("Character").GetComponent<WalkingScript>().speed;
        distanciaText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Calculo la distancia usando el punto de salida y sumandole la posicion del personaje.
        distancia += _playerSpeed * Time.deltaTime;
        //Meter resultado en texto:
        distanciaText.text = "Distancia: " + distancia.ToString("F2") + " Mts.";
    }
}
