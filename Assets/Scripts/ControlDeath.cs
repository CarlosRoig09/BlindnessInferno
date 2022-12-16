using UnityEngine;
public enum Life
{
    Alive,
    Death
}
public class ControlDeath : MonoBehaviour
{
    private Vector2 screenBounds;
    private float playerHeight;
    private float playerWeight;
    private Life _life;
    public Life Life
    {
        get => _life;
    }
    void Start()
    {
        _life = Life.Alive;
        //Mido la camara
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //Mido la altura del personaje
        playerHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        //Mido la amplitud del personaje
        playerWeight = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;

    }
    void Update()
    {
        //Si la posicion de y es mas peke q la del escenario y la altura del jugador o si la posicion de x es mas peke o igual a lo mismo pero en x.
        if (transform.position.y <= ((screenBounds.y * -1) - playerHeight) || transform.position.x <= ((screenBounds.x * -1) - playerWeight))
            {
            _life = Life.Death;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            _life = Life.Death;
    }
}