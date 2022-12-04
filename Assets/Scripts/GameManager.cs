using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : Singelton<GameManager>
{
    public enum Escenas
    {
        StartScreen,
        GameScreen,
        GameOverScreen
    }
   // private Escenas _scene;
    private ControlDeath _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Character").GetComponent<ControlDeath>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.Life == Life.Death)
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

  /*  void ChangeScene()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "GameScene":
                _scene = Escenas.GameScreen;
                break;
            case "GameOver":
                _scene = Escenas.GameOverScreen;
                break;
            case "Menu":
                _scene = Escenas.StartScreen;
                break;
            default:
                break;
        }
    }*/
}
