using UnityEngine;
using UnityEngine.UI;
public class ControlDeath : MonoBehaviour
{
    private Vector2 screenBounds;
    private float playerHeight;
    private float playerWeight;

    //Meter un empty object al punto de salida y usarlo aqui
    private Vector2 puntoSalida;
    //Meter un texto pa mostrar distancia
    [SerializeField]
    private Text distanciaText;
    private float _playerSpeed;
    private float distancia;


    void Start()
    {
        puntoSalida = transform.position; 
        //Mido la camara
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //Mido la altura del personaje
        playerHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        //Mido la amplitud del personaje
        playerWeight = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        _playerSpeed = gameObject.GetComponent<WalkingScript>().speed;

    }
    void Update()
    {
        //Calculo la distancia usando el punto de salida y sumandole la posicion del personaje.
        // distancia += (transform.position.x-puntoSalida.x);
        distancia += _playerSpeed * Time.deltaTime;
        //Meter resultado en texto:
        distanciaText.text = "Distancia: " + distancia.ToString("F2") + " Mts.";

        //Si la posicion de y es mas peke q la del escenario y la altura del jugador o si la posicion de x es mas peke o igual a lo mismo pero en x.
        if (transform.position.y <= ((screenBounds.y * -1) - playerHeight) || transform.position.x <= ((screenBounds.x * -1) - playerWeight))
            {
            //Destruir objecto
            Destroy(gameObject);
        }
    }
}