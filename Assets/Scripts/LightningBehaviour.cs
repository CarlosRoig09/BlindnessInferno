using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBehaviour : PlatformControler
{
    private ShakeBehaviour _shake;
    private float _duracion;
    private float _fuerza;
    public GameObject WhiteScreen;
    private float count = 0;
    private float _whiteScreenX;
    private float _whiteScreenY;

    private bool _isFalled = false;

    public override void PlatformHability()
    {

        _shake.StartShake(_duracion, _fuerza);
    }

    void Start()
    {
        GameObject flashingLight = Instantiate(WhiteScreen);
        flashingLight.transform.position = new Vector3(0, 0, 0);

        WhiteScreen = GameObject.Find("WhiteScreen(Clone)");
        WhiteScreen.SetActive(false);
        _shake = GameObject.Find("Main Camera").GetComponent<ShakeBehaviour>();
        _duracion = gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 8;
        _fuerza = 0.2f;
        PlatformHability();
    }
    
    void Update()
    {
        _whiteScreenX = Camera.main.gameObject.transform.position.x;
        _whiteScreenY = Camera.main.gameObject.transform.position.y;

        WhiteScreen.transform.position = new Vector3(_whiteScreenX, _whiteScreenY, 0);
        count += 0.01f;
        //Debug.Log("COUNT: " + count);
        
        
        if (!_isFalled)
        {
            PlatformHability();
            _isFalled = true;
            
        }
        if (count < 2.5f && count > 1.9f)
        {
            WhiteScreen.SetActive(true);
        }else if (count > 12.9f)
        {
            WhiteScreen.SetActive(false);
        }
        WhiteScreen.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.001f);

    }
}
