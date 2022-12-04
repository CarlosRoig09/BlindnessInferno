using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassKilomiters : MonoBehaviour
{
    [SerializeField]
    PlayerData _pDSO;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _pDSO.PlayerDistance = gameObject.GetComponent<Text>().text;
    }
}
