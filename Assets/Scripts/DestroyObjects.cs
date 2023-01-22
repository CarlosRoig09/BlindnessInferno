using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<ControlDeath>().Life = Life.Death;
        }
        else
        {
            if(collision.gameObject.layer==6||collision.CompareTag("Enemy")||collision.CompareTag("Bullet"))
             Destroy(collision.gameObject);
        }
    }
}
