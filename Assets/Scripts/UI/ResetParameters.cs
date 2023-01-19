using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetParameters : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Awake()
    {
        GameManager.Instance.Player = GameObject.Find("Character").GetComponent<ControlDeath>();
        
        GameManager.Instance.Score = 0;
    }

 
}
