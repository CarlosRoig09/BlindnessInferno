using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum Nivel
{
    Nivel1,
    TransNivel1,
    Nivel2,
    TransNivel2,
    Nivel3,
    TransNivel3,
    NivelBoss,
    TransNivelBoss
}

public class GeneratePlatformController : MonoBehaviour
{
    private Vector3 _initPosition;
    private PlatformScriptableObject[] _plSO;

    [SerializeField]
    private PlatformScriptableObject[] _plSONivel1;

    private float _counter;
    private int _num;
    [SerializeField]
    private Rigidbody2D _cameraRB;
    [SerializeField]
    private AlPamPamYAlPiumPium _enemySpawn;

    private Nivel _nivel;

    // Start is called before the first frame update
    void Start()
    {
        _nivel = Nivel.Nivel1;
        _plSO = _plSONivel1;
        _num = RandomMethods.ReturnARandomObject(_plSO, 0);
        _counter = _plSO[_num].PlatgormWaitTimer;
        _enemySpawn = gameObject.GetComponent<AlPamPamYAlPiumPium>();
    }

    // Update is called once per frame
    private void Update()
    {
        _enemySpawn = gameObject.GetComponent<AlPamPamYAlPiumPium>();
        if (_plSO[_num].PlatgormWaitTimer / _cameraRB.velocity.x <= _counter)
        {
            GeneratePlatform();
        }
        else
            _counter += Time.deltaTime;
    }

    private void GeneratePlatform()
    {
        switch (_nivel)
        {
            case Nivel.Nivel1:
                _plSO = _plSONivel1;
                break;
            case Nivel.TransNivel1:
                break;
            case Nivel.Nivel2:
                break;
            case Nivel.TransNivel2:
                break;
            case Nivel.Nivel3:
                break;
            case Nivel.TransNivel3:
                break;
            case Nivel.NivelBoss:
                break;
            case Nivel.TransNivelBoss:
                break;
        }
        _num = RandomMethods.ReturnARandomObject(_plSO, 0);
        _initPosition = new Vector3(transform.position.x, _plSO[_num].PlatformInitialYPosition);
        var platform = Instantiate(_plSO[_num].PlatformPrefab, _initPosition, Quaternion.identity);
        _counter = 0;
        Debug.Log(platform.name);
        //if (platform != null&&_enemySpawn!=null)
            //_enemySpawn.InstantObstacle(platform);
    }
}
