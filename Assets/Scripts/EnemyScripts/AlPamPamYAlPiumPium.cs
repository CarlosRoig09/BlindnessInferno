using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlPamPamYAlPiumPium : MonoBehaviour
{
    private Vector3 _initPosition;
    [SerializeField]
    private GameObject[] _enemy;
    [SerializeField]
    private RandomSO[] _enemyRate;
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
         var num = RandomMethods.ReturnARandomObject(_enemyRate,20);
            instant = _enemy[num];
            float xPosition = Random.Range(platform.transform.position.x, platform.transform.position.x + platform.transform.localScale.x / 2);
            _initPosition = new Vector3(xPosition, platform.transform.position.y + platform.transform.localScale.y / 2 + transform.localScale.y / 2);
            if (instant != null && platform != null)
                Instantiate(instant, _initPosition, Quaternion.identity);
        }
    }

}
