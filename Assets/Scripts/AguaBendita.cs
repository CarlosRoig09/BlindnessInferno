using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaBendita : MonoBehaviour
{
    private ControlDeath _controlDeath;
    private GameObject _character;

    void Start()
    {
        _character = GameObject.Find("Character");
        _controlDeath = _character.GetComponent<ControlDeath>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Agua Bendita tocada!!");
            _controlDeath.life = Life.Death;
        }
    }
}
