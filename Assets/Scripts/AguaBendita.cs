using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaBendita : MonoBehaviour
{
    private ControlDeath _controlDeath;
    private GameObject _character;
    //private GameObject BubleParticleSystem;
    

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
            //_controlDeath.life = Life.Death;
            //var emission = ParticleSystem.emission;
            //emission.rate = 70.0f;

            ParticleSystem ps = GameObject.Find("BubleParticleSystem").GetComponent<ParticleSystem>();
            //ps.Play();
            ps.ParticleSystem.emission.rate = 70.0f;

        }
    }
}
