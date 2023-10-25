using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

  
	// Use this for initialization
	void Start () {
        //PlayerPrefs.DeleteAll();
	}
	
	// Update is called once per frame
	public void PlayGame()
    {
        SceneManager.LoadScene("PaperPlane");
    }

    public void Achievment()
    {

    }

    public void Leaderboard()
    {

    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Share()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }
}
