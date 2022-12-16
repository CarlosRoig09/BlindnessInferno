using UnityEngine;

public class Enemy : MovingPlatform
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
            DestroyObject();
    }
}
