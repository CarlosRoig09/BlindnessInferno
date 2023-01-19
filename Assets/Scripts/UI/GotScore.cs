using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        gameObject.GetComponent<TMPro.TMP_Text>().text = GameManager.Instance.Score.ToString();
    }


}
