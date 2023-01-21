using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
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
    private PlatformScriptableObject[] _plSOFase1;
    [SerializeField]
    private PlatformScriptableObject[] _plSOFase2;
    [SerializeField]
    private PlatformScriptableObject[] _plSOFase3;

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

    private PlatformScriptableObject[] _plSONivel2y3;

    // Start is called before the first frame update
    void Start()
    {
        
        _plSO = _plSONivel1;
        _num = RandomMethods.ReturnARandomObject(_plSO, 0);
        if (_num < 0)
            _num = UnityEngine.Random.Range(0, _plSO.Length);
        _counter = _plSO[_num].PlatgormWaitTimer;
        _enemySpawn = gameObject.GetComponent<AlPamPamYAlPiumPium>();
        _plSONivel2y3 = GenerateNevel3();
        for(int i=0; i < _plSONivel2y3.Length;i++)
        {
            Debug.Log(_plSONivel2y3[i]);
        }
        

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
    private PlatformScriptableObject[] GenerateNevel3()
    {
        var position = (_plSONivel2.Length); 
        var position2= position + (_plSONivel3.Length);
        Array.Resize(ref _plSONivel2y3, position2);
       
        for (int i = 0; i < position; i++)
        {
            _plSONivel2y3[i] = _plSONivel2[i];

        }
        for(int i=_plSONivel2.Length;i< position2; i++)
        {
            _plSONivel2y3[i] = _plSONivel3[i-_plSONivel2.Length];
        }
        return _plSONivel2y3;

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
                _plSO = _plSONivel2y3;
                break;
            case Niveles.TransNivel3:
                _plSO = _plSOTransition;
                break;
            case Niveles.NivelBoss1:
                _plSO = _plSOFase1;
                break;
            case Niveles.NivelBoss2:
                _plSO = _plSOFase2;
                break;
            case Niveles.NivelBoss3:
                _plSO = _plSOFase3;
                break;
            case Niveles.TransNivelBoss:
                _plSO = _plSOLastTransition;
                break;


        }

        _num = RandomMethods.ReturnARandomObject(_plSO, 0);
        if (_num < 0)
            _num = UnityEngine.Random.Range(0, _plSO.Length);
        _initPosition = new Vector3(transform.position.x, _plSO[_num].PlatformInitialYPosition);
        var platform = Instantiate(_plSO[_num].PlatformPrefab, _initPosition, Quaternion.identity);
        _counter = 0;
        if (platform != null&&_enemySpawn!=null)
            _enemySpawn.InstantObstacle(platform);
    }
}
