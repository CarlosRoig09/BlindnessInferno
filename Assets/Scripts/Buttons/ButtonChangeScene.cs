using UnityEngine;
using UnityEngine.SceneManagement;

//Classe que funciona como un boton que cambia de escena.
public class ButtonChangeScene : GenericButton
{
    private ChangeSceneTransition _panel;
    //La escena a la cual debe cambiar al pulsar el boton.
    [SerializeField]
    private string _scene;

    protected override void TaskOnClick()
    {
        _panel = GameObject.Find("TransitionStart").GetComponent<ChangeSceneTransition>();
        _panel.LoadScene(_scene);
    }

}
