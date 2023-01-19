using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GeneratePlatformController : MonoBehaviour
{
    private Vector3 _initPosition;
    private PlatformScriptableObject[] _plSO;

    [SerializeField]
    private PlatformScriptableObject[] _plSONivel1;
    [SerializeField]
    private PlatformScriptableObject[] _plSONivel2;
    [SerializeField]
    private PlatformScriptableObject[] _plSONivel3;

    [SerializeField]
    private PlatformScriptableObject[] _plSOTransition;

    [SerializeField]
    private PlatformScriptableObject[] _plSOLastTransition;

    private float _counter;
    private int _num;
    [SerializeField]
    private Rigidbody2D _cameraRB;
    [SerializeField]
    private AlPamPamYAlPiumPium _enemySpawn;

    private Niveles _nivel;
 

    // Start is called before the first frame update
    void Start()
    {
        
        _plSO = _plSONivel1;
        _num = RandomMethods.ReturnARandomObject(_plSO, 0);
        _counter = _plSO[_num].PlatgormWaitTimer;
        _enemySpawn = gameObject.GetComponent<AlPamPamYAlPiumPium>();

    }

    // Update is called once per frame
    private void Update()
    {
        if (_plSO == _plSOLastTransition || _plSO == _plSOTransition) _num = 0;
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
        _nivel = GameObject.Find("Main Camera").GetComponent<BlindColorTest>().Nivel;
        switch (_nivel)
        {
            case Niveles.Nivel1:
                _plSO = _plSONivel1;
                break;
            case Niveles.TransNivel1:
                _plSO = _plSOTransition;
                break;
            case Niveles.Nivel2:
                _plSO = _plSONivel2;
                break;
            case Niveles.TransNivel2:
                _plSO = _plSOTransition;
                break;
            case Niveles.Nivel3:
                _plSO = _plSONivel3;
                break;
            case Niveles.TransNivel3:
                _plSO = _plSOTransition;
                break;
            case Niveles.NivelBoss:
                _plSO = _plSONivel3;
                break;
            case Niveles.TransNivelBoss:
                _plSO = _plSOLastTransition;
                break;


        }
        Debug.Log(_nivel);

        _num = RandomMethods.ReturnARandomObject(_plSO, 0);
        _initPosition = new Vector3(transform.position.x, _plSO[_num].PlatformInitialYPosition);
        var platform = Instantiate(_plSO[_num].PlatformPrefab, _initPosition, Quaternion.identity);
        _counter = 0;
        if (platform != null&&_enemySpawn!=null)
            _enemySpawn.InstantObstacle(platform);
    }
}
