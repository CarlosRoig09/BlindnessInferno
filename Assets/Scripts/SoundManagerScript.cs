using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    
    private  AudioClip nivel1, nivel2, nivel3, nivel4, muriendo;
    private AudioSource audioSrc;

    // Start is called before the first frame update
    void Awake()
    {
        nivel1 = Resources.Load<AudioClip>("Vsdemon");
        nivel2 = Resources.Load<AudioClip>("GodOfBlaze");
        nivel3 = Resources.Load<AudioClip>("DragonSlayer");
        nivel4 = Resources.Load<AudioClip>("RequiemDiesIraeWolfgangAmadeusMozart");
        muriendo = Resources.Load<AudioClip>("Muerte");
        audioSrc = gameObject.GetComponent<AudioSource>();

    }


    public void PlaySound(string clip)
    {
        audioSrc.Stop();
        switch (clip)
        {
            case "Vsdemon":
                audioSrc.PlayOneShot(nivel1, 0.7F);
                break;
            case "GodOfBlaze":
                audioSrc.PlayOneShot(nivel2, 0.8F);
                break;
            case "DragonSlayer":
                audioSrc.PlayOneShot(nivel3, 0.9F);
                break;
            case "RequiemDiesIraeWolfgangAmadeusMozart":
                audioSrc.PlayOneShot(nivel4, 0.95F);
                break;
          
        }
        
    }
}
