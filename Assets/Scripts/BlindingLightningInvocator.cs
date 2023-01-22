using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindingLightningInvocator : MonoBehaviour
{
    public GameObject LightningSpawn;
    private GameObject _character;
    // Start is called before the first frame update
    void Start()
    {
        _character = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject GODetected = Instantiate(LightningSpawn);
            GODetected.transform.position = new Vector3(_character.transform.position.x + 3.0f, _character.transform.position.y + 4.5f, 0);
            Destroy(gameObject);
        }
    }
}
