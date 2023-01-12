using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossFase
{
    StartBossFase1,
    BossFase1,
    StartBossFase2,
    BossFase2,
    StartBossFase3,
    BossFase3,
    Death
}
public class ControlBossFaces : MonoBehaviour
{
    private float _currentLife;
    private BossFase _currentFase;
    [SerializeField]
    private BossEnemySO BossEnemySO;
    // Start is called before the first frame update
    void Start()
    {
        _currentFase = BossFase.StartBossFase1;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentFase)
        {
            case BossFase.StartBossFase1:
                LifeForFace(BossEnemySO.LifeFirstFace);
                break;
            case BossFase.BossFase1:
                ComproveIfFaseEnd(BossFase.BossFase2, _currentLife);
                break;
            case BossFase.StartBossFase2:
                LifeForFace(BossEnemySO.LifeFirstFace);
                break;
            case BossFase.BossFase2:
                ComproveIfFaseEnd(BossFase.BossFase2, _currentLife);
                break;
            case BossFase.StartBossFase3:
                LifeForFace(BossEnemySO.LifeFirstFace);
                break;
            case BossFase.BossFase3:
                ComproveIfFaseEnd(BossFase.BossFase2, _currentLife);
                break;
            case BossFase.Death:
                Destroy(gameObject);
                break;
        }
    }

    void ComproveIfFaseEnd(BossFase BF, float life)
    {
        if (life <= 0)
            _currentFase = BF;
    }
    void LifeForFace(float newLife)
    {
        _currentLife = newLife;
    }
}
