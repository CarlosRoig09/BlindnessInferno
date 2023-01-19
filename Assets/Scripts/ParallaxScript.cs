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
    private GameObject _sky;
    public float VerticalParallaxSpeed;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
    private void Start()
    {
        _sky = GameObject.Find("Sky3");
    }

    private void Update()
    {
        offset = moveSpeed * Time.deltaTime /** gameObject.GetComponentInParent<MoveCamara>().Speed/200*/;
        material.mainTextureOffset += offset;
    }

    void FixedUpdate()
    {
        x = transform.localPosition.x;
        y = transform.localPosition.y;

        //-3.19008f
        //0.8899164f
        if (_sky.transform.localPosition.y < -2.5f)
        {
            MovingUpParallax = false;
            y += 0.01f;
            VerticalParallaxSpeed = 0.01f;
            MovingUpParallax = true;
        }
        else if (_sky.transform.localPosition.y > 7.8f)
        {
            MovingUpParallax = false;
            y -= 0.01f;
            VerticalParallaxSpeed = -0.01f;
            MovingUpParallax = true;
        }

        if (MovingUpParallax)
        {
            transform.localPosition = new Vector3(x, y + VerticalParallaxSpeed, 0);
        }
    }
}
