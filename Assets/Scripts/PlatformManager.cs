using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private Vector3 _initPosition;
    [SerializeField]
    private PlatformScriptableObject _plSO;
    private float _counter;
    private ObstacleManager _obstacleManager;
    // Start is called before the first frame update
    void Start()
    {
       _initPosition = new Vector3((Camera.main.transform.position.x + (2f*Camera.main.orthographicSize * Camera.main.aspect))/2 + _plSO.PlatformPrefab.transform.localScale.x, _plSO.PlatformInitialYPosition);
        _counter = _plSO.PlatgormWaitTimer;
        _obstacleManager = gameObject.GetComponent<ObstacleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_plSO.PlatgormWaitTimer/_plSO.PlatformSpeed*-1);
        if (_plSO.PlatgormWaitTimer <= _counter)
        {
           var platform = Instantiate(_plSO.PlatformPrefab, _initPosition, Quaternion.identity);
            _obstacleManager.Instantiate(platform);
            _counter = 0;
       }
        else
            _counter += Time.deltaTime;

    }
}
