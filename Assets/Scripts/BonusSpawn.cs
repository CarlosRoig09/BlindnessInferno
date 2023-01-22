using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawn : MonoBehaviour
{
    private Vector3 _initPosition;
    [SerializeField]
    private GameObject _enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Instantiate(GameObject platform)
    {
        int numOfObstacle = Random.Range(0, 2);
        for (var i = 0; i < numOfObstacle; i++)
        {
            float xPosition = Random.Range(platform.transform.position.x - platform.transform.localScale.x /2,platform.transform.position.x + platform.transform.localScale.x / 2);
            _initPosition = new Vector3(xPosition, platform.transform.position.y + platform.transform.localScale.y / 2 + transform.localScale.y/2);
            Instantiate(_enemy, _initPosition, Quaternion.identity);
        }
    }
}
