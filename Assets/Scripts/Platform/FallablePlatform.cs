using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallablePlatform : PlatformControler
{
    private Collider2D _collider2D;
    // Start is called before the first frame update
    void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }
    public override void PlatformHability()
    {
        _collider2D.enabled = false;
        StartCoroutine(ColliderActivation(0.5f));
    }

    private IEnumerator ColliderActivation(float timer)
    {
        yield return new WaitForSeconds(timer);
        _collider2D.enabled = true;
    }
}
