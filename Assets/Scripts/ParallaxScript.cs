using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    [SerializeField] private Vector2 moveSpeed;
    private Vector2 offset;
    private Material material;
    private float x, y;
    public bool MovingUpParallax;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        offset = moveSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }

    void FixedUpdate()
    {
        if (MovingUpParallax)
        {
            x = transform.localPosition.x;
            y = transform.localPosition.y;
            transform.localPosition = new Vector3(x, y - 0.01f, 0);
        }
    }
}
