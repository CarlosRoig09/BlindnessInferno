using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AlPamPamYAlPiumPium : MonoBehaviour
{
    private Vector3 _initPosition;
    [SerializeField]
    private RandomSO[] _randomRate;
    [SerializeField]
    private GameObject[] _items;
    private GameObject instant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InstantObstacle(GameObject platform)
    {
        GameObject enemy;
       var numPlatforms = platform.transform.childCount;
      if(platform!=null)  {
            for (var i = 0; i < Random.Range(2, 5); i++)
            {
                var num = RandomMethods.ReturnARandomObject(_randomRate, 0);
                if (num >= 0)
                {
                    var currentPlatform = platform.transform.GetChild(UnityEngine.Random.Range(0, numPlatforms));
                    instant = _randomRate[num].Prefab;
                    ComproveIsAPlatform(currentPlatform);
                    if (instant != null && currentPlatform != null)
                      Instantiate(instant, _initPosition, Quaternion.identity);
                }
            }
        }
    }

    private void ComproveIsAPlatform(Transform currentPlatform)
    {
        float xPosition = Random.Range(currentPlatform.transform.position.x, currentPlatform.transform.position.x + currentPlatform.transform.localScale.x / 2);
            _initPosition = new Vector3(xPosition, currentPlatform.transform.position.y + Random.Range(-0.35f, 3));
            Debug.Log(_initPosition.y);
        RaycastHit2D hit;
        if (hit = Physics2D.Raycast(_initPosition, Vector2.up, 0.65f))
        {
            var point = hit.point.y / hit.collider.bounds.size.y;
            _initPosition.y += hit.collider.bounds.size.y / point;
        }
        if (Physics2D.Raycast(_initPosition, Vector2.down, Mathf.Infinity, 8))
        {
            _initPosition.x += 0.2f;
        }
    }

}
