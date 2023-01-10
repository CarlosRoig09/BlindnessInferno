using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatformController : MonoBehaviour
{
    private Vector3 _initPosition;
    [SerializeField]
    private PlatformScriptableObject[] _plSO;
    private float _counter;
    private int _num;
    [SerializeField]
    private Rigidbody2D _cameraRB;
    [SerializeField]
    private AlPamPamYAlPiumPium _enemySpawn;
    // Start is called before the first frame update
    void Start()
    {
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
        _num = RandomMethods.ReturnARandomObject(_plSO, 0);
        _initPosition = new Vector3(transform.position.x, _plSO[_num].PlatformInitialYPosition);
        var platform = Instantiate(_plSO[_num].PlatformPrefab, _initPosition, Quaternion.identity);
        _counter = 0;
        Debug.Log(platform.name);
        if (platform != null&&_enemySpawn!=null)
            _enemySpawn.InstantObstacle(platform);
        _num = Random.Range(0, _plSO.Length - 1);
    }
}
