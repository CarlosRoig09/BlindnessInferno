using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private Vector3 _initPosition;
    [SerializeField]
    private PlatformScriptableObject[] _plSO;
    private float _counter;
    private ObstacleManager _obstacleManager;
    private EnemySpawn _enemySpawn;

    private int num;
    // Start is called before the first frame update
    void Start()
    {
        num = Random.Range(0, 3);
        _initPosition = new Vector3((Camera.main.transform.position.x + (2f*Camera.main.orthographicSize * Camera.main.aspect))/2 + _plSO[num].PlatformPrefab.transform.localScale.x, _plSO[num].PlatformInitialYPosition);
        _counter = _plSO[num].PlatgormWaitTimer;
        _obstacleManager = gameObject.GetComponent<ObstacleManager>();
        _enemySpawn = gameObject.GetComponent<EnemySpawn>();
    }

    // Update is called once per frame
    void Update()
    {
       num = Random.Range(0, 3);
 
        if (_plSO[num].PlatgormWaitTimer <= _counter)
        {
           var platform = Instantiate(_plSO[num].PlatformPrefab, _initPosition, Quaternion.identity);
           // _obstacleManager.Instantiate(platform);
            _enemySpawn.Instantiate(platform);
            _counter = 0;
       }
        else
        {
            _counter += Time.deltaTime;
        }

      

    }
}
