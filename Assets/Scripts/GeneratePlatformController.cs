using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatformController : MonoBehaviour
{
    private Vector3 _initPosition;
    [SerializeField]
    private PlatformScriptableObject _plSO;
    private float _counter;
    private ObstacleManager _obstacleManager;
    private EnemySpawn _enemySpawn;
    // Start is called before the first frame update
    void Start()
    {
        _counter = _plSO.PlatgormWaitTimer;
        _obstacleManager = gameObject.GetComponent<ObstacleManager>();
        _enemySpawn = gameObject.GetComponent<EnemySpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_plSO.PlatgormWaitTimer <= _counter)
        {
           Vector3 cameraBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            _initPosition = new Vector3(cameraBound.x+Camera.main.transform.position.x, _plSO.PlatformInitialYPosition);
            var platform = Instantiate(_plSO.PlatformPrefab, _initPosition, Quaternion.identity);
           // _obstacleManager.Instantiate(platform);
           // _enemySpawn.Instantiate(platform);
            _counter = 0;
       }
        else
            _counter += Time.deltaTime;

    }
}
