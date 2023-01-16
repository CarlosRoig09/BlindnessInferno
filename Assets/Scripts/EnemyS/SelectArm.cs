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
    private List<GameObject> Arms;
    private int _armCount;
    private float _count;
    [SerializeField]
    private float _countBetweenArms;
    [SerializeField]
    private float _speed;
     private void OnEnable()
     {
        _parentCBF = transform.parent.GetComponent<ControlBossFaces>();
        _parentCBF.OnEndFace += Death;
        Debug.Log("Subscribed");
    }

     private void OnDisable()
     {
        _parentCBF.OnEndFace -= Death;
        Debug.Log("DeSubscribed");
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    [SerializeField]
    private ControlBossFaces _controlBossFaces;
    private ControlBossFaces _parentCBF;
    // Start is called before the first frame update

    void Start()
    {
        Arms = new List<GameObject> { transform.GetChild(0).gameObject, transform.GetChild(1).gameObject };
        _armCount = 0;
        _count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled)
        {
            if (Arms[_armCount].GetComponent<ArmAttack>().Life < 0)
            {
                switch (Arms[_armCount].GetComponent<ArmAttack>()._aP)
                {
                    case ArmPosition.Stay:
                        Debug.Log("attack");
                        Arms[_armCount].GetComponent<ArmAttack>().Attack(_speed);
                        if (_armCount == 1)
                            Arms[_armCount].GetComponent<ArmAttack>().Attack(_speed * -1);
                        break;
                    case ArmPosition.AttackEnd:
                        if (_countBetweenArms <= _count)
                        {
                            _armCount += 1;
                            if (_armCount >= Arms.Count)
                                _armCount = 0;
                            Arms[_armCount].GetComponent<ArmAttack>()._aP = ArmPosition.Stay;
                            _count = 0;
                        }
                        else
                            _count += Time.deltaTime;
                        break;
                }
            }
            else
            {
                Arms.Remove(Arms[_armCount]);
                Destroy(Arms[_armCount]);
                _armCount = 0;
            }
        }
    }
    void Death()
    {
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        _parentCBF = transform.parent.GetComponent<ControlBossFaces>();
        _parentCBF.OnEndFace += Death;
        Arms[0].GetComponent<ArmAttack>().Life = _controlBossFaces.CurrentLife / 2;
        Arms[1].GetComponent<ArmAttack>().Life = _controlBossFaces.CurrentLife / 2;
    }

    private void OnDisable()
    {
        _parentCBF.OnEndFace -= Death;
    }
}
