using System.Collections;
using UnityEngine;
public enum Life
{
    Alive,
    Death
}
public class ControlDeath : MonoBehaviour
{
    private WalkingScript _walk;
    public Life life;
    public float MaxPlayerLife;
    public float PlayerLife;
    private bool _invencible;
    public Life Life
    {
        get => life;
        set => life = value;
    }
    void Start()
    {
        _invencible = false;
        life = Life.Alive;
        //Mido la camara
        _walk = gameObject.GetComponent<WalkingScript>();
     
    }
    void Update()
    {
    
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Enemy")||collision.gameObject.CompareTag("EnemyBossHitPoint"))&&!_invencible)
        {
            //PlayerLife--;
            SubstractLife();
            _walk.StopMomentum = true;
            _invencible = true;
            StartCoroutine(StartMomentum(0.5f));
            if (PlayerLife == 0)
            {
                life = Life.Death;
            }
        }
    }
    private IEnumerator StartMomentum(float Time)
    {
        yield return new WaitForSeconds(Time);
        _invencible = false;
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