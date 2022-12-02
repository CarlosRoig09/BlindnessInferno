using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private Vector3 _initPosition;
    [SerializeField]
    private GameObject _obstacle;
    public void Instantiate(GameObject platform)
    {
        int numOfObstacle = Random.Range(0, 4);
        for (var i = 0; i < numOfObstacle; i++) {
            float xPosition = Random.Range(platform.transform.position.x - transform.localScale.x / 2, platform.transform.position.x + transform.localScale.x / 2);
            _initPosition = new Vector3(xPosition, platform.transform.position.y + transform.localScale.y / 2+0.5f);
            Instantiate(_obstacle, _initPosition, Quaternion.identity);
        }
    }
}
