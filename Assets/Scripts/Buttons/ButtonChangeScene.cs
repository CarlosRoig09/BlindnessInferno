using UnityEngine;
using UnityEngine.SceneManagement;

//Classe que funciona como un boton que cambia de escena.
public class ButtonChangeScene : GenericButton
{
    //La escena a la cual debe cambiar al pulsar el boton.
    [SerializeField]
    private string _scene;

    protected override void TaskOnClick()
    {
        SceneManager.LoadScene(_scene, LoadSceneMode.Single);
    }

}
