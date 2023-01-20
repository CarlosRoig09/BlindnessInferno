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
    private bool _starFase = false;
    private ControlBossFaces _parentCBF;
    // Start is called before the first frame update

    void Start()
    {
        _armCount = 0;
        _count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled&&_starFase)
        {
            if (Arms.Count > 0)
            {
                if (Arms[_armCount].GetComponent<ArmAttack>().Life > 0)
                {
                    switch (Arms[_armCount].GetComponent<ArmAttack>()._aP)
                    {
                        case ArmPosition.Stay:
                            Debug.Log("attack");
                            Arms[_armCount].GetComponent<ArmAttack>().Attack(_speed);
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
                    Destroy(Arms[_armCount]);
                    Arms.Remove(Arms[_armCount]);
                    _armCount = 0;
                }
            }
            else
                Death();
        }
    }
    void Death()
    {
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        Arms = new List<GameObject> { transform.GetChild(0).gameObject, transform.GetChild(1).gameObject };
        _parentCBF = transform.parent.GetComponent<ControlBossFaces>();
        _parentCBF.OnEndFace += Death;
        foreach (var arm in Arms)
        {
            arm.GetComponent<ArmAttack>().Life = _parentCBF.CurrentLife / 2;
            arm.GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnDisable()
    {
        _starFase = true;
        _parentCBF.OnEndFace -= Death;
    }
}
