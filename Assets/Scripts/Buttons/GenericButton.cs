using UnityEngine;
using UnityEngine.UI;

public abstract class GenericButton : MonoBehaviour
{
    protected virtual void Start()
    {
       gameObject.GetComponent<Button>().onClick.AddListener(delegate () { TaskOnClick(); });
    }

    protected abstract void TaskOnClick();
}
