using UnityEngine;
using UnityEngine.UI;

public class Kilomiters : MonoBehaviour

{
    //Meter un texto pa mostrar distancia
    private Text distanciaText;
    public PlayerData playerData;
    private float distancia;
    private float _realDistance;
    public float Distancia
    {
        get=>_realDistance;
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
        distancia += playerData.speed * Time.deltaTime;
        _realDistance = distancia / 10;
        //Meter resultado en texto:
        distanciaText.text = _realDistance.ToString("F2") + " Kms.";
    }
}
