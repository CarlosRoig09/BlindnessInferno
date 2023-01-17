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
    public Life life;
    public float MaxPlayerLife;
    public float PlayerLife;
    public Life Life
    {
        get => life;
        set => life = value;
    }
    void Start()
    {
        life = Life.Alive;
        //Mido la camara

    }
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")||collision.gameObject.CompareTag("EnemyBossHitPoint"))
        {
            //PlayerLife--;
            SubstractLife();
            if (PlayerLife == 0)
            {
                life = Life.Death;
            }
        }
    }

    public void SubstractLife()
    {
        PlayerLife--;
    }

    public void AddLife()
    {
        PlayerLife++;
    }
}