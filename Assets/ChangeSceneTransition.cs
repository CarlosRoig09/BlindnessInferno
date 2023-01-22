using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTransition : MonoBehaviour
{
    private Animator _transitionAnim;
    private AudioSource _audio;
    // Start is called before the first frame update
    void Start()
    {
        _audio = GameObject.Find("Sound").GetComponent<AudioSource>();
        _transitionAnim = GetComponent<Animator>();
    }

  public void LoadScene(string scene)
    {
        StartCoroutine(Transiciona(scene));
    }

    IEnumerator Transiciona(string scene)
    {
        _transitionAnim.SetTrigger("change");
        _audio.Stop();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
