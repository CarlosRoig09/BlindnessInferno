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

    private BlindColorTest _blindColorTest;
    private GameObject _blindColor;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
    private void Start()
    {
        _sky = GameObject.Find("Sky3");
        _blindColor = GameObject.Find("Main Camera");
        _blindColorTest = _blindColor.GetComponent<BlindColorTest>();
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

        
        if (_sky.transform.localPosition.y < -2.5f)//Tope por arriba
        {
            MovingUpParallax = false;
            y += 0.01f;
            VerticalParallaxSpeed = 0.01f;
        }
        else if (_sky.transform.localPosition.y > 7.8f)//Tope por abajo
        {
            MovingUpParallax = false;
            y -= 0.01f;
            VerticalParallaxSpeed = -0.01f;
        }

        switch (_blindColorTest.Nivel)
        {
            case Niveles.Nivel1:
                MovingUpParallax = false;
                break;
            case Niveles.TransNivel1:
                MovingUpParallax = true;
                if (_sky.transform.localPosition.y < 0f)
                {
                    MovingUpParallax = false;
                }
                break;
            case Niveles.Nivel2:
                MovingUpParallax = false;
                break;
            case Niveles.TransNivel2:
                MovingUpParallax = true;
                if (_sky.transform.localPosition.y < -3f)
                {
                    MovingUpParallax = false;
                }
                break;
            case Niveles.Nivel3:
                MovingUpParallax = false;
                break;
            case Niveles.TransNivel3:
                //MovingUpParallax = true;
                break;
            case Niveles.NivelBoss1:
                MovingUpParallax = false;
                break;
            case Niveles.NivelBoss2:
                MovingUpParallax = false;
                break;
            case Niveles.NivelBoss3:
                MovingUpParallax = false;
                break;
            case Niveles.TransNivelBoss:
                MovingUpParallax = true;
                if (_sky.transform.localPosition.y > 7.8f)
                {
                    MovingUpParallax = false;
                    y -= 0.01f;
                    VerticalParallaxSpeed = -0.01f;
                }
                break;
            default:
                break;
        }

        if (MovingUpParallax)
        {
            transform.localPosition = new Vector3(x, y + VerticalParallaxSpeed, 0);
        }
    }
}
