using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArmPosition
{
    Stay,
    Attack,
    Elevate,
    AttackEnd
}
public class SelectArm : MonoBehaviour
{
    private ControlBossFaces _parentCBF;
    private GameObject[] Arms;
    private int _armCount;
    [SerializeField]
    private float _speed;
    /* private void OnEnable()
     {
         _parentCBF.OnEndFace += Death;
     }

     private void OnDisable()
     {
         _parentCBF.OnEndFace -= Death;
     }*/

    // Start is called before the first frame update
    void Start()
    {
        _parentCBF = transform.parent.GetComponent<ControlBossFaces>();
        Arms = new GameObject[] { transform.GetChild(0).gameObject, transform.GetChild(1).gameObject };
        _armCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Arms[_armCount].GetComponent<ArmAttack>()._aP == ArmPosition.Stay)
        {
            Debug.Log("attack");
            Arms[_armCount].GetComponent<ArmAttack>().Attack(_speed);
        }
    }

    /* void Death()
     {

     }*/
}
