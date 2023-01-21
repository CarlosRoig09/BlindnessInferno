using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    [SerializeField]
    private  AudioClip nivel1, nivel2, nivel3, nivel4;
    private AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        nivel1 = Resources.Load<AudioClip>("Vs_demon");
        nivel2 = Resources.Load<AudioClip>("GodOfBlaze");
        nivel3 = Resources.Load<AudioClip>("DragonSlayer");
        nivel4 = Resources.Load<AudioClip>("RequiemDiesIraeWolfgangAmadeusMozart");
        audioSrc = gameObject.GetComponent<AudioSource>();
    }


    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Vs_demon":
                audioSrc.clip = nivel1;
                audioSrc.Play();
                break;
            case "GodOfBlaze":
                audioSrc.clip = nivel2;
                audioSrc.Play();
                break;
            case "DragonSlayer":
                audioSrc.clip = nivel3;
                audioSrc.Play();
                break;
            case "RequiemDiesIraeWolfgangAmadeusMozart":
                audioSrc.clip = nivel4;
                audioSrc.Play();
                break;
            
        }
        
    }
}
