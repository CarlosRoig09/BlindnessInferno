using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBonusScript : MovingPlatform
{
    private ControlDeath _controlDeathScript;
    private GameObject _player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _player = GameObject.Find("Character");
            _controlDeathScript = _player.GetComponent<ControlDeath>();
            
            if (_controlDeathScript.PlayerLife < 5)
            {
                _controlDeathScript.AddLife();
            }
            DestroyObject();
        }
            
    }
}
