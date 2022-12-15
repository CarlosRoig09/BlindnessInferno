using UnityEngine;

public class GenericGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       /* if (IsOutTheLimits())
            DestroyObject();*/
    }

    protected bool IsOutTheLimits()
    {
        Vector3 cameraBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        return transform.position.x <= cameraBound.x/2 - gameObject.GetComponent<SpriteRenderer>().bounds.size.x/2;
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
