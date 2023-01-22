using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassKilomiters : MonoBehaviour
{
    [SerializeField]
    PlayerData _pDSO;
   // Update is called once per frame
    void Update()
    {
        _pDSO.PlayerDistance = gameObject.GetComponent<Text>().text;
    }
}
