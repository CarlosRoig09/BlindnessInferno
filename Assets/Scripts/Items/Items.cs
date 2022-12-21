using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Items : MovingPlatform
{

    public string name;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Effecto(collision);
            Destroy(gameObject);

        }
    }
    protected abstract void Effecto(Collider2D collision);
}
