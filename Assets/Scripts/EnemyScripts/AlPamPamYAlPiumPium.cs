using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlPamPamYAlPiumPium : MonoBehaviour
{
    private Vector3 _initPosition;
    [SerializeField]
    private GameObject[] _enemy;
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
      if(platform!=null)  {
        int num = Random.Range(0, 100);
        if (50 <= num)
            instant = _enemy[Random.Range(0, _enemy.Length)];
        else
        {
            instant = _items[Random.Range(0, _items.Length)];
        }
        
            float xPosition = Random.Range(platform.transform.position.x, platform.transform.position.x + platform.transform.localScale.x / 2);
            _initPosition = new Vector3(xPosition, platform.transform.position.y + platform.transform.localScale.y / 2 + transform.localScale.y / 2);
            if (instant != null && platform != null)
                Instantiate(instant, _initPosition, Quaternion.identity);
        }
    }

}
