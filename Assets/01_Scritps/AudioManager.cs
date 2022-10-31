using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource sfxAS;
    public static AudioManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void PlaySFX(AudioClip sfx)
    {
        sfxAS.PlayOneShot(sfx);
    }
    
}
