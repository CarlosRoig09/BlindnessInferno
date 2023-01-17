using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupriseBox : MonoBehaviour
{
    [SerializeField]
    private GameObject _bats;
    private Animator _anim;

    private void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
    }

    public void BreakAnimation()
    {
        _anim.SetBool("Destroy", true);
    }
    public void FreeBats()
    {
        Instantiate(_bats,transform.position,Quaternion.identity);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
