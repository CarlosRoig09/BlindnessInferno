using UnityEngine;
using UnityEngine.SceneManagement;


    public enum Escenas
    {
        StartScreen,
        GameScreen,
        GameOverScreen
    }
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Game Manager is NULL");
            }
            return _instance;
        }
    }
   // private Escenas _scene;
    private ControlDeath _player;
    public ControlDeath Player
    {
        get => _player;
        set => _player = value;
    }
    private int _score;
    private Escenas _scene;
    public int Score
    {
        get => _score;
        set => _score = value;
    }
    private void Awake()
    {
        if (_instance != null)
            Destroy(gameObject);
        else
        {
            Debug.Log("ManagerCreated");
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        ChangeScene();
        if (_scene == Escenas.GameScreen)
        {
            _player = GameObject.Find("Character").GetComponent<ControlDeath>();
            _player.life = Life.Alive;
            _score = 0;
            Debug.Log("start");
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChangeScene();
        if (_scene == Escenas.GameScreen)
        {
            if (_player.Life == Life.Death)
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
        
    }

    void ChangeScene()
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
    }
}
