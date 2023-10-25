using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

    public static DontDestroy AudInstance;
    public AudioSource Aud;
    public static bool soundPaused;
    public static bool firstPlay = true;
    // Use this for initialization
    void Start () {
        Aud = GetComponent<AudioSource>();
        if (AudInstance == null)
        {
            AudInstance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void SoundOn()
    {
        Aud.Play();
        firstPlay = false;
    }

    public void SoundPause()
    {
        
        Aud.Pause();
        soundPaused = true;
    }

    public void SoundUnPause()
    {
        Aud.UnPause();
        soundPaused = false;
    }
}
