using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Audio : MonoBehaviour
{
    public Sprite audioOn;
    public Sprite audioOff;
    bool audioState;
    GameObject AudioObject;
    GameObject Settings;
    public bool canDeselect;   
    public static Audio AudInstance;
    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        AudioObject = GameObject.Find("Audio");
        audioState = true;
        canDeselect = true;
       
        GetAudioSettingsInfo();
        
    }

    public void GetAudioSettingsInfo()
    {
        if (PlayerPrefs.GetInt("AudioState") == 1)
        {
            AudioObject.GetComponent<Image>().sprite = audioOff;
            audioState = false;
            //GameObject.FindObjectOfType<DontDestroy>().Sound();
            GameObject.FindObjectOfType<DontDestroy>().SoundOn();
            GameObject.FindObjectOfType<DontDestroy>().SoundPause();
        }
        else
        {
            AudioObject.GetComponent<Image>().sprite = audioOn;
            audioState = true;
            if (DontDestroy.firstPlay) {
                GameObject.FindObjectOfType<DontDestroy>().SoundOn();
            }
            

        }
    }
    public void AudioToggle()
    {
        if (audioState)
        {
            AudioObject.GetComponent<Image>().sprite = audioOff;
            audioState = false;
            PlayerPrefs.SetInt("AudioState", 1);
            GameObject.FindObjectOfType<DontDestroy>().SoundPause();
        }

        else
        {
            GameObject.FindObjectOfType<DontDestroy>().SoundUnPause();
            AudioObject.GetComponent<Image>().sprite = audioOn;
            audioState = true;
            PlayerPrefs.SetInt("AudioState", 0);
        }

    }

    public void DeselectSettings()
    {
        //  Debug.Log("deselect");
        // StartCoroutine("DelayTime");
        StartCoroutine(IEDeselect());
    }

    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(0.1f);
    }
    public void SoundBtnDown()
    {
        canDeselect = false;
    }
    public void SoundBtnUp()
    {
        StartCoroutine(IESoundBtnDown());
    }

    IEnumerator IESoundBtnDown()
    {
        yield return new WaitForSeconds(0.1f);
        canDeselect = true;
    }

    IEnumerator IEDeselect()
    {
        yield return new WaitForSeconds(0.05f);
        if (canDeselect)
        {
            Settings.GetComponent<Animator>().SetTrigger("Settings");
        }
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void NewGAme()
    {
        SceneManager.LoadScene("clim3d");
    }

    public void Exit()
    {
        Application.Quit();
    }

    
}
