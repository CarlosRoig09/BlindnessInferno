using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//Boton de la pantalla de inicio que lleva al menu. Por lo tanto gestiona que se cumplan los requisitos del nombre. No vacío y mayor que dos.
public class GoToMenu : ButtonChangeScene
{
    private string _player;
    private GameObject _popUp;
    // Start is called before the first frame update
    // Update is called once per frame

    protected override void Start()
    {
        base.Start();
        //Oculta el Pop-Up
        _popUp = GameObject.Find("Pop-Up");
        _popUp.SetActive(false);
    }
    protected override void TaskOnClick()
    {
        //Busca el nombre del jugador dentro del GameObject persistente para confirmar que no esta vació o es mayor que dos.
        _player = GameObject.Find("PlayerName").GetComponent<TMP_Text>().text;
                      
    if (_player.Length>3)
        base.TaskOnClick();
        else
        {
            //Muestra el pop-up
            _popUp.SetActive(true);
            //Funcion que se encarga de hacer esperar 1.5 segundos antes de desaparecer el pop.up. 
            StartCoroutine(CloseAfterTime(1.5f));
        }              
    }

    public IEnumerator CloseAfterTime(float t)
    {
        yield return new WaitForSeconds(t);
        _popUp.SetActive(false);
    }
}
