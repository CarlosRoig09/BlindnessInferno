using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "platforms", menuName = "platformList")]
public class PlatformScriptableObject : ScriptableObject
{
    
    [SerializeField]
    private string _platformName;
    [SerializeField]
    private GameObject _platformPrefab;
    public GameObject PlatformPrefab
    {
        get => _platformPrefab;
    }
    //Esto se modificara a la larga, al final ahora nos sirve para lo que queremos hacer, pero más adelante este campo seran para condiciones especificas.
    [SerializeField]
    private float _platformWaitTimer;
    public float PlatgormWaitTimer
    {
        get => _platformWaitTimer;
    }
    public float PlatformSpeed
    {
        get => _platformSpeed;
    }
    [SerializeField]
    private float _platformSpeed;
    public float PlatformInitialYPosition
    {
        get => _platformInitialYPosition;
    }
    [SerializeField]
    private float _platformInitialYPosition;

    public float PlatformLeftEdge
    {
        get => _platformPrefab.transform.position.x - _platformPrefab.transform.localScale.x;
    }
    public float PlatformRightEdge
    {
        get => _platformPrefab.transform.position.x + _platformPrefab.transform.localScale.x;
    }
    public float PlatformHegith
    {
        get => _platformPrefab.transform.position.y + _platformPrefab.transform.localScale.y;
    }
}
