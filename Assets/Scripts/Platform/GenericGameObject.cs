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
        //Mido la camara
        var platformHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        var platformWeight = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        Vector3 cameraBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Debug.Log("platform x" + transform.position.x + platformWeight * 3);
        Debug.Log("camera x (+gran)" + Camera.main.orthographicSize * -1 / 2 + Camera.main.transform.position.x);

        //return transform.position.y + platformHeight <= ((cameraBound.y * -1/2 + Camera.main.transform.position.y) )  || transform.position.x + platformWeight<= ((cameraBound.x * -1/2 + Camera.main.transform.position.x));
        return transform.position.x + platformWeight * 3 <= ((Camera.main.orthographicSize * -1 / 2 + Camera.main.transform.position.x)) || transform.position.y + platformHeight * 3 <= ((Camera.main.orthographicSize * -1 / 2 + Camera.main.transform.position.y));
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
