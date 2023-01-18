using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlScore : MonoBehaviour
{
    private ControlDeath _controlDeathScript;
    private GameObject _player;
    private TMP_Text _totalscore;

    private void Start()
    {
        _player = GameObject.Find("Character");
        _controlDeathScript = _player.GetComponent<ControlDeath>();
        _totalscore = GameObject.Find("Score").gameObject.GetComponent<TMP_Text>();
    }
    private void Update()
    {
        _totalscore.text = GameManager.Instance.Score.ToString();
    }
    public void ScorePlus(int _score)
    {
        Debug.Log(_score);
        Debug.Log(_controlDeathScript.PlayerLife);
        _score = _score * (int)_controlDeathScript.PlayerLife;
        GameManager.Instance.Score += _score;
        Debug.Log(_score);
    }
}
