using UnityEngine;
using UnityEngine.UI;
public class GotDistance : MonoBehaviour
{
    [SerializeField]
    PlayerData _pDSO;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TMPro.TMP_Text>().text = _pDSO.PlayerDistance;
    }
}
