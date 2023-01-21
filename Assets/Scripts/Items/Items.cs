using UnityEngine;

public abstract class Items : MovingPlatform
{

    public string name;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Effecto(collision.collider);
            Destroy(gameObject);
        }
    }
    protected abstract void Effecto(Collider2D collision);
}
